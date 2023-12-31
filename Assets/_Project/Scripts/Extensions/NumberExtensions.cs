using UnityEngine;
#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

public static class NumberExtensions
{
	public static float PercentageOf(this float part, float whole)
	{
		if (whole == 0) return 0;
		return (float)part / whole;
	}

	public static double PercentageOf(this double part, double whole)
	{
		if (whole == 0) return 0;
		return (double)part / whole;
	}

	public static byte AtLeast(this byte value, short min) => (byte)Mathf.Max(value, min);
	public static byte AtMost(this byte value, short min) => (byte)Mathf.Min(value, min);

	public static short AtLeast(this short value, short min) => (short)Mathf.Max(value, min);
	public static short AtMost(this short value, short min) => (short)Mathf.Min(value, min);

	public static int AtLeast(this int value, int min) => Mathf.Max(value, min);
	public static int AtMost(this int value, int max) => Mathf.Min(value, max);

	public static long AtLeast(this long value, long max) => MathfExtension.Max(value, max);
	public static long AtMost(this long value, long max) => MathfExtension.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
	public static half AtLeast(this half value, half max) => MathfExtension.Max(value, max);
	public static half AtMost(this half value, half max) => MathfExtension.Min(value, max);
#endif

	public static float AtLeast(this float value, float min) => Mathf.Max(value, min);
	public static float AtMost(this float value, float max) => Mathf.Min(value, max);

	public static double AtLeast(this double value, double min) => MathfExtension.Max(value, min);
	public static double AtMost(this double value, double min) => MathfExtension.Min(value, min);
}