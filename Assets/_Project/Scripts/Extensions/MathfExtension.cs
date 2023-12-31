#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

/// <summary>
/// A utility struct providing extension methods for Mathf.
/// </summary>
public struct MathfExtension
{
	#region Min
	/// <summary>
	/// Returns the smaller of two long values.
	/// </summary>
	public static long Min(long a, long b)
	{
		return (a < b) ? a : b;
	}

	/// <summary>
	/// Returns the smallest value among an array of long values.
	/// </summary>
	public static long Min(params long[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return 0;
		}

		long num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] < num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}

#if ENABLED_UNITY_MATHEMATICS
	/// <summary>
	/// Returns the smaller of two half-precision floating-point values.
	/// </summary>
	public static half Min(half a, half b)
	{
		return (a < b) ? a : b;
	}

	/// <summary>
	/// Returns the smallest value among an array of half-precision floating-point values.
	/// </summary>
	public static half Min(params half[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return (half)0;
		}

		half num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] < num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}
#endif

	/// <summary>
	/// Returns the smaller of two double-precision floating-point values.
	/// </summary>
	public static double Min(double a, double b)
	{
		return (a < b) ? a : b;
	}

	/// <summary>
	/// Returns the smallest value among an array of double-precision floating-point values.
	/// </summary>
	public static double Min(params double[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return 0f;
		}

		double num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] < num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}
	#endregion

	#region Max
	/// <summary>
	/// Returns the larger of two long values.
	/// </summary>
	public static long Max(long a, long b)
	{
		return (a > b) ? a : b;
	}

	/// <summary>
	/// Returns the largest value among an array of long values.
	/// </summary>
	public static long Max(params long[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return 0;
		}

		long num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] > num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}

#if ENABLED_UNITY_MATHEMATICS
	/// <summary>
	/// Returns the larger of two half-precision floating-point values.
	/// </summary>
	public static half Max(half a, half b)
	{
		return (a > b) ? a : b;
	}

	/// <summary>
	/// Returns the largest value among an array of half-precision floating-point values.
	/// </summary>
	public static half Max(params half[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return (half)0;
		}

		half num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] > num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}
#endif

	/// <summary>
	/// Returns the larger of two double-precision floating-point values.
	/// </summary>
	public static double Max(double a, double b)
	{
		return (a > b) ? a : b;
	}

	/// <summary>
	/// Returns the largest value among an array of double-precision floating-point values.
	/// </summary>
	public static double Max(params double[] values)
	{
		int num = values.Length;
		if (num == 0)
		{
			return 0f;
		}

		double num2 = values[0];
		for (int i = 1; i < num; i++)
		{
			if (values[i] > num2)
			{
				num2 = values[i];
			}
		}

		return num2;
	}

	#endregion
}