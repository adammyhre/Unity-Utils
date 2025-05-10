using System;
using Unity.Properties;

public static class PropertyPathExtensions
{
    /// <summary>
    /// Converts a string representation of a property path into a PropertyPath object.
    /// </summary>
    /// <param name="pathString">A string representing the property path. Can include dot-separated property names and array indices in square brackets.</param>
    /// <returns>A PropertyPath object representing the parsed path.</returns>
    /// <exception cref="ArgumentException">Thrown when the input string is null, empty, or consists only of whitespace.</exception>
    /// <exception cref="FormatException">Thrown when the path contains an invalid array index or unmatched square brackets.</exception>
    /// <example>
    /// Valid path strings:
    /// "propertyName"
    /// "parent.child"
    /// "array[0]"
    /// "parent.children[2].name"
    /// "matrix[0][1]"
    /// </example>
    public static PropertyPath ToPropertyPath(this string pathString) {
        if (string.IsNullOrWhiteSpace(pathString))
            throw new ArgumentException("Path string is null or empty.");

        var path = default(PropertyPath);
        foreach (var part in pathString.Split('.')) {
            int bracketStart = part.IndexOf('[');
            if (bracketStart < 0) {
                path = PropertyPath.AppendName(path, part);
                continue;
            }

            path = PropertyPath.AppendName(path, part[..bracketStart]);
            int bracketEnd;
            while ((bracketEnd = part.IndexOf(']', bracketStart)) >= 0) {
                if (!int.TryParse(part[(bracketStart + 1)..bracketEnd], out var index))
                    throw new FormatException($"Invalid index in path: {part[(bracketStart + 1)..bracketEnd]}");
                
                path = PropertyPath.AppendIndex(path, index);
                bracketStart = part.IndexOf('[', bracketEnd);
                if (bracketStart < 0) break;
            }
            
            if (bracketStart >= 0)
                throw new FormatException($"Unmatched '[' in path: {part}");
        }
        return path;
    }
}