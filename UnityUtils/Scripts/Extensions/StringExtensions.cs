using System;

public static class StringExtensions {
    /// <summary>Checks if a string is Null or white space</summary>
    public static bool IsNullOrWhiteSpace(this string val) => string.IsNullOrWhiteSpace(val);

    /// <summary>Checks if a string is Null or empty</summary>
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

    /// <summary>Checks if a string contains null, empty or white space.</summary>
    public static bool IsBlank(this string val) => val.IsNullOrWhiteSpace() || val.IsNullOrEmpty();

    /// <summary>Returns an empty string if the string is null or empty or white space.</summary>
    public static string OrEmpty(this string val) => val.IsBlank() ? string.Empty : val;

    /// <summary>
    /// Shortens a string to the specified maximum length. If the string's length
    /// is less than the maxLength, the original string is returned.
    /// </summary>
    public static string Shorten(this string val, int maxLength) {
        if (val.IsBlank()) return val;
        return val.Length <= maxLength ? val : val.Substring(0, maxLength);
    }

    /// <summary>Slices a string from the start index to the end index.</summary>
    /// <result>The sliced string.</result>
    public static string Slice(this string val, int startIndex, int endIndex) {
        if (val.IsBlank()) {
            throw new ArgumentNullException(nameof(val), "Value cannot be null or empty.");
        }

        if (startIndex < 0 || startIndex > val.Length - 1) {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        // If the end index is negative, it will be counted from the end of the string.
        endIndex = endIndex < 0 ? val.Length + endIndex : endIndex;

        if (endIndex < 0 || endIndex < startIndex || endIndex > val.Length) {
            throw new ArgumentOutOfRangeException(nameof(endIndex));
        }

        return val.Substring(startIndex, endIndex - startIndex);
    }
}