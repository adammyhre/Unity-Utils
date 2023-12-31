#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

public struct MathfExtension
{
	#region Min
		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static long Min(long a, long b)
		{
			return (a < b) ? a : b;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static half Min(half a, half b)
		{
			return (a < b) ? a : b;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double Min(double a, double b)
		{
			return (a < b) ? a : b;
		}

		/// <summary>
		/// Returns the smallest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static long Max(long a, long b)
		{
			return (a > b) ? a : b;
		}

		/// <summary>
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static half Max(half a, half b)
		{
			return (a > b) ? a : b;
		}

		/// <summary>
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double Max(double a, double b)
		{
				return (a > b) ? a : b;
		}

		/// <summary>
		/// Returns the largest of two or more values.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
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