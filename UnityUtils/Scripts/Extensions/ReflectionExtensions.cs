using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UnityUtils {
    public static class ReflectionExtensions {
        static readonly Dictionary<Type, string> TypeDisplayNames = new() {
            { typeof(int), "int" },
            { typeof(float), "float" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(string), "string" },
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(sbyte), "sbyte" },
            { typeof(uint), "uint" },
            { typeof(short), "short" },
            { typeof(ushort), "ushort" },
            { typeof(long), "long" },
            { typeof(ulong), "ulong" },
            { typeof(char), "char" },
            { typeof(object), "object" }
        };

        static readonly Type[] ValueTupleTypes = {
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>)
        };

        static readonly Type[][] PrimitiveTypeCastHierarchy = {
            new[] { typeof(byte), typeof(sbyte), typeof(char) },
            new[] { typeof(short), typeof(ushort) },
            new[] { typeof(int), typeof(uint) },
            new[] { typeof(long), typeof(ulong) },
            new[] { typeof(float) },
            new[] { typeof(double) }
        };

        /// <summary>
        /// Returns the default value for the given type.
        /// </summary>
        /// <param name="type">The type for which to get the default value.</param>
        /// <returns>An instance of the type with default value, or null if the type is a reference type.</returns>
        public static object Default(this Type type) {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        /// <summary>
        /// Determines if a type is assignable from the specified generic type parameter.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <param name="type">The type to check.</param>
        /// <returns>True if the specified type is assignable from the generic type parameter T, otherwise false.</returns>
        public static bool Is<T>(this Type type) {
            return typeof(T).IsAssignableFrom(type);
        }

        /// <summary>
        /// Determines if a type is a delegate.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>True if the type is a delegate, otherwise false.</returns>
        public static bool IsDelegate(this Type type) => typeof(Delegate).IsAssignableFrom(type);

        /// <summary>
        /// Determines if a type is a strongly typed delegate.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>True if the type is a strongly typed delegate, otherwise false.</returns>
        public static bool IsStrongDelegate(this Type type) {
            if (!type.IsDelegate()) return false;

            return !type.IsAbstract;
        }

        /// <summary>
        /// Determines if a field is a delegate.
        /// </summary>
        /// <param name="fieldInfo">The field to check.</param>
        /// <returns>True if the field is a delegate, otherwise false.</returns>
        public static bool IsDelegate(this FieldInfo fieldInfo) => fieldInfo.FieldType.IsDelegate();

        /// <summary>
        /// Determines if a field is a strongly typed delegate.
        /// </summary>
        /// <param name="fieldInfo">The field to query.</param>
        /// <returns>True if the field is a strongly typed delegate, otherwise false.</returns>
        public static bool IsStrongDelegate(this FieldInfo fieldInfo) => fieldInfo.FieldType.IsStrongDelegate();

        /// <summary>
        /// Determines if the type is a generic type of the given non-generic type.
        /// </summary>
        /// <param name="genericType">The Type to be used</param>
        /// <param name="nonGenericType">The non-generic type to test against.</param>
        /// <returns>If the type is a generic type of the non-generic type.</returns>
        public static bool IsGenericTypeOf(this Type genericType, Type nonGenericType) {
            if (!genericType.IsGenericType) { return false; }

            return genericType.GetGenericTypeDefinition() == nonGenericType;
        }

        /// <summary>
        /// Determines if the type is a derived type of the given base type.
        /// </summary>
        /// <param name="type">this type</param>
        /// <param name="baseType">The base type to test against.</param>
        /// <returns>If the type is a derived type of the base type.</returns>
        public static bool IsDerivedTypeOf(this Type type, Type baseType) => baseType.IsAssignableFrom(type);

        /// <summary>
        /// Determines if an object the given type can be cast to the specified type.
        /// </summary>
        /// <param name="from">this object</param>
        /// <param name="to">The destination type of the cast.</param>
        /// <param name="implicitly">If only implicit casts should be considered.</param>
        /// <returns>If the cast can be performed.</returns>
        public static bool IsCastableTo(this Type from, Type to, bool implicitly = false)
            => to.IsAssignableFrom(from) || from.HasCastDefined(to, implicitly);

        /// <summary>
        /// Determines if a cast is defined between two types.
        /// </summary>
        /// <param name="from">The source type to check for cast definitions.</param>
        /// <param name="to">The destination type to check for cast definitions.</param>
        /// <param name="implicitly">If only implicit casts should be considered.</param>
        /// <returns>True if a cast is defined between the types, otherwise false.</returns>
        static bool HasCastDefined(this Type from, Type to, bool implicitly) {
            if ((!from.IsPrimitive && !from.IsEnum) || (!to.IsPrimitive && !to.IsEnum)) {
                return IsCastDefined
                       (
                           to,
                           m => m.GetParameters()[0].ParameterType,
                           _ => from,
                           implicitly,
                           false
                       )
                       || IsCastDefined
                       (
                           from,
                           _ => to,
                           m => m.ReturnType, implicitly,
                           true
                       );
            }

            if (!implicitly) {
                return from == to || (from != typeof(bool) && to != typeof(bool));
            }

            IEnumerable<Type> lowerTypes = Enumerable.Empty<Type>();
            foreach (Type[] types in PrimitiveTypeCastHierarchy) {
                if (types.Any(t => t == to)) {
                    return lowerTypes.Any(t => t == from);
                }

                lowerTypes = lowerTypes.Concat(types);
            }

            return false; // IntPtr, UIntPtr, Enum, Boolean
        }

        /// <summary>
        /// Determines if a cast is defined between two types.
        /// </summary>
        /// <param name="type">The type to check for cast definitions.</param>
        /// <param name="baseType">A function to get the base type from a method.</param>
        /// <param name="derivedType">A function to get the derived type from a method.</param>
        /// <param name="implicitly">If only implicit casts should be considered.</param>
        /// <param name="lookInBase">If the base hierarchy should be searched for cast definitions.</param>
        /// <returns>True if a cast is defined between the types, otherwise false.</returns>
        static bool IsCastDefined(
            Type type,
            Func<MethodInfo, Type> baseType,
            Func<MethodInfo, Type> derivedType,
            bool implicitly,
            bool lookInBase
        ) {
            // Set the binding flags to search for public and static methods, and optionally include the base hierarchy.
            var flags = BindingFlags.Public | BindingFlags.Static | (lookInBase ? BindingFlags.FlattenHierarchy : BindingFlags.DeclaredOnly);

            // Get all methods from the type with the specified binding flags.
            MethodInfo[] methods = type.GetMethods(flags);

            // Check if any method is an implicit or explicit cast operator and if the base type is assignable from the derived type.
            return methods.Where(m => m.Name == "op_Implicit" || (!implicitly && m.Name == "op_Explicit"))
                .Any(m => baseType(m).IsAssignableFrom(derivedType(m)));
        }

        /// <summary>
        /// Dynamically casts an object to the specified type.
        /// </summary>
        /// <param name="type">The destination type of the cast.</param>
        /// <param name="data">The object to cast.</param>
        /// <returns>The dynamically cast object.</returns>
        public static object Cast(this Type type, object data) {
            if (type.IsInstanceOfType(data)) {
                return data;
            }

            try {
                return Convert.ChangeType(data, type);
            }
            catch (InvalidCastException) {
                var srcType = data.GetType();
                var dataParam = Expression.Parameter(srcType, "data");
                Expression body = Expression.Convert(Expression.Convert(dataParam, srcType), type);

                var run = Expression.Lambda(body, dataParam).Compile();
                return run.DynamicInvoke(data);
            }
        }

        /// <summary>
        /// Determines if the given method is an override.
        /// </summary>
        /// <param name="methodInfo">The method to check.</param>
        /// <returns>True if the method is an override, otherwise false.</returns>
        public static bool IsOverride(this MethodInfo methodInfo)
            => methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType;

        /// <summary>
        /// Checks if the specified attribute is present on the provider.
        /// </summary>
        /// <typeparam name="T">The attribute to test.</typeparam>
        /// <param name="provider">The attribute provider.</param>
        /// <param name="searchInherited">If base declarations should be searched.</param>
        /// <returns>True if the attribute is present, otherwise false.</returns>
        public static bool HasAttribute<T>(this ICustomAttributeProvider provider, bool searchInherited = true) where T : Attribute {
            try {
                return provider.IsDefined(typeof(T), searchInherited);
            }
            catch (MissingMethodException) {
                return false;
            }
        }

        /// <summary>
        /// Gets a formatted display name for a given type.
        /// </summary>
        /// <param name="type">The type to generate a display name for.</param>
        /// <param name="includeNamespace">If the namespace should be included when generating the typename.</param>
        /// <returns>The generated display name.</returns>
        public static string GetDisplayName(this Type type, bool includeNamespace = false) {
            if (type.IsGenericParameter) {
                return type.Name;
            }

            if (type.IsArray) {
                int rank = type.GetArrayRank();
                string innerTypeName = GetDisplayName(type.GetElementType(), includeNamespace);
                return $"{innerTypeName}[{new string(',', rank - 1)}]";
            }

            if (TypeDisplayNames.TryGetValue(type, out string baseName1)) {
                if (!type.IsGenericType || type.IsConstructedGenericType)
                    return baseName1;
                Type[] genericArgs = type.GetGenericArguments();
                return $"{baseName1}<{new string(',', genericArgs.Length - 1)}>";

            }

            if (type.IsGenericTypeOf(typeof(Nullable<>))) {
                var innerType = type.GetGenericArguments()[0];
                return $"{innerType.GetDisplayName()}?";
            }

            if (type.IsGenericType) {
                var baseType = type.GetGenericTypeDefinition();
                Type[] genericArgs = type.GetGenericArguments();

                if (ValueTupleTypes.Contains(baseType)) {
                    return GetTupleDisplayName(type, includeNamespace);
                }

                if (type.IsConstructedGenericType) {
                    var genericNames = new string[genericArgs.Length];
                    for (var i = 0; i < genericArgs.Length; i++) {
                        genericNames[i] = GetDisplayName(genericArgs[i], includeNamespace);
                    }

                    string baseName = GetDisplayName(baseType, includeNamespace).Split('<')[0];
                    return $"{baseName}<{string.Join(", ", genericNames)}>";
                }

                string typeName = includeNamespace
                    ? type.FullName
                    : type.Name;

                return $"{typeName?.Split('`')[0]}<{new string(',', genericArgs.Length - 1)}>";
            }

            var declaringType = type.DeclaringType;
            if (declaringType == null) {
                return includeNamespace
                    ? type.FullName
                    : type.Name;
            }

            string declaringName = GetDisplayName(declaringType, includeNamespace);
            return $"{declaringName}.{type.Name}";

        }

        /// <summary>
        /// Gets a formatted display name for a tuple type.
        /// </summary>
        /// <param name="type">The tuple type to generate a display name for.</param>
        /// <param name="includeNamespace">If the namespace should be included when generating the typename.</param>
        /// <returns>The generated display name for the tuple type.</returns>
        static string GetTupleDisplayName(this Type type, bool includeNamespace = false) {
            IEnumerable<string> parts = type
                .GetGenericArguments()
                .Select(x => x.GetDisplayName(includeNamespace));

            return $"({string.Join(", ", parts)})";
        }

        /// <summary>
        /// Determines if two methods from different types have the same signature.
        /// </summary>
        /// <param name="a">First method</param>
        /// <param name="b">Second method</param>
        /// <returns><c>true</c> if they are equal</returns>
        public static bool AreMethodsEqual(MethodInfo a, MethodInfo b) {
            if (a.Name != b.Name) return false;

            ParameterInfo[] paramsA = a.GetParameters();
            ParameterInfo[] paramsB = b.GetParameters();

            if (paramsA.Length != paramsB.Length) return false;
            for (var i = 0; i < paramsA.Length; i++) {
                var pa = paramsA[i];
                var pb = paramsB[i];

                if (pa.Name != pb.Name) return false;
                if (pa.HasDefaultValue != pb.HasDefaultValue) return false;

                var ta = pa.ParameterType;
                var tb = pb.ParameterType;

                if (ta.ContainsGenericParameters || tb.ContainsGenericParameters)
                    continue;
                if (ta != tb) return false;
            }

            if (a.IsGenericMethod != b.IsGenericMethod) return false;

            if (!a.IsGenericMethod || !b.IsGenericMethod) return true;
            {
                Type[] genericA = a.GetGenericArguments();
                Type[] genericB = b.GetGenericArguments();

                if (genericA.Length != genericB.Length) return false;
                for (var i = 0; i < genericA.Length; i++) {
                    var ga = genericA[i];
                    var gb = genericB[i];

                    if (ga.Name != gb.Name) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Rebase a method onto a new type by finding the corresponding method with an equal signature.
        /// </summary>
        /// <param name="method">Method to rebase</param>
        /// <param name="newBase">New type to rebase the method onto</param>
        /// <returns>The rebased method</returns>
        public static MethodInfo RebaseMethod(this MethodInfo method, Type newBase) {
            var flags = BindingFlags.Default;

            flags |= method.IsStatic ? BindingFlags.Static : BindingFlags.Instance;

            flags |= method.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic;

            MethodInfo[] candidates = newBase.GetMethods(flags)
                .Where(x => AreMethodsEqual(x, method))
                .ToArray();

            if (candidates.Length == 0) {
                throw new ArgumentException($"Could not rebase method {method} onto type {newBase} as no matching candidates were found");
            }

            if (candidates.Length > 1) {
                throw new ArgumentException($"Could not rebase method {method} onto type {newBase} as too many matching candidates were found");
            }

            return candidates[0];
        }
    }
}
