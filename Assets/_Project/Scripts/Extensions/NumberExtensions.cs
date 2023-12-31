using UnityEngine;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

/// <summary>
/// Extension methods for various numeric types to provide convenient functionality.
/// </summary>
public static class NumberExtensions
{
	/// <summary>
	/// Calculates the percentage of one integer value relative to another.
	/// </summary>
	/// <param name="part">The numerator or part of the whole.</param>
	/// <param name="whole">The denominator or the total.</param>
	/// <returns>The percentage of the part relative to the whole.</returns>
	public static float PercentageOf(this int part, int whole)
	{
		if (whole == 0) return 0; // Handling division by zero
		return (float)part / whole;
	}

	/// <summary>
	/// Ensures that a byte value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original byte value.</param>
	/// <param name="min">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static byte AtLeast(this byte value, short min) => (byte)Mathf.Max(value, min);

	/// <summary>
	/// Ensures that a byte value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original byte value.</param>
	/// <param name="min">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static byte AtMost(this byte value, short min) => (byte)Mathf.Min(value, min);

	/// <summary>
	/// Ensures that a short value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original short value.</param>
	/// <param name="min">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static short AtLeast(this short value, short min) => (short)Mathf.Max(value, min);

	/// <summary>
	/// Ensures that a short value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original short value.</param>
	/// <param name="min">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static short AtMost(this short value, short min) => (short)Mathf.Min(value, min);

	/// <summary>
	/// Ensures that an integer value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original integer value.</param>
	/// <param name="min">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static int AtLeast(this int value, int min) => Mathf.Max(value, min);

	/// <summary>
	/// Ensures that an integer value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original integer value.</param>
	/// <param name="max">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static int AtMost(this int value, int max) => Mathf.Min(value, max);

	/// <summary>
	/// Ensures that a long value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original long value.</param>
	/// <param name="max">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static long AtLeast(this long value, long max) => MathfExtension.Max(value, max);

	/// <summary>
	/// Ensures that a long value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original long value.</param>
	/// <param name="max">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static long AtMost(this long value, long max) => MathfExtension.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
	/// <summary>
	/// Ensures that a half-precision floating-point value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original half-precision floating-point value.</param>
	/// <param name="max">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static half AtLeast(this half value, half max) => MathfExtension.Max(value, max);

	/// <summary>
	/// Ensures that a half-precision floating-point value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original half-precision floating-point value.</param>
	/// <param name="max">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static half AtMost(this half value, half max) => MathfExtension.Min(value, max);
#endif

	/// <summary>
	/// Ensures that a single-precision floating-point value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original single-precision floating-point value.</param>
	/// <param name="min">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static float AtLeast(this float value, float min) => Mathf.Max(value, min);

	/// <summary>
	/// Ensures that a single-precision floating-point value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original single-precision floating-point value.</param>
	/// <param name="max">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static float AtMost(this float value, float max) => Mathf.Min(value, max);

	/// <summary>
	/// Ensures that a double-precision floating-point value is at least a specified minimum value.
	/// </summary>
	/// <param name="value">The original double-precision floating-point value.</param>
	/// <param name="min">The minimum value to ensure.</param>
	/// <returns>The original value if greater than or equal to the specified minimum; otherwise, the minimum value.</returns>
	public static double AtLeast(this double value, double min) => MathfExtension.Max(value, min);

	/// <summary>
	/// Ensures that a double-precision floating-point value is at most a specified maximum value.
	/// </summary>
	/// <param name="value">The original double-precision floating-point value.</param>
	/// <param name="min">The maximum value to ensure.</param>
	/// <returns>The original value if less than or equal to the specified maximum; otherwise, the maximum value.</returns>
	public static double AtMost(this double value, double min) => MathfExtension.Min(value, min);
}