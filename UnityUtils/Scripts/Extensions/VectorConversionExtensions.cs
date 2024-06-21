using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityUtils {
    public static class VectorConversionExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 ToUnityVector(this System.Numerics.Vector2 vector) {
            return new Vector2(vector.X, vector.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Vector2 ToSystemVector(this Vector2 vector) {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 ToUnityVector(this System.Numerics.Vector3 vector) {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Vector3 ToSystemVector(this Vector3 vector) {
            return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
        }
    }
}