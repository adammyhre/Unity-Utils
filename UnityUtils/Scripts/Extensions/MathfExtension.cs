#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

namespace UnityUtils {
    public static class MathfExtension {
        #region Min

#if ENABLED_UNITY_MATHEMATICS
        public static half Min(half a, half b) {
            return (a < b) ? a : b;
        }

        public static half Min(params half[] values) {
            int num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] < num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        public static double Min(double a, double b) {
            return (a < b) ? a : b;
        }

        public static double Min(params double[] values) {
            int num = values.Length;
            if (num == 0) {
                return 0f;
            }

            double num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] < num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }

        #endregion

        #region Max

#if ENABLED_UNITY_MATHEMATICS
        public static half Max(half a, half b) {
            return (a > b) ? a : b;
        }

        public static half Max(params half[] values) {
            int num = values.Length;
            if (num == 0) {
                return (half) 0;
            }

            half num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] > num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }
#endif

        public static double Max(double a, double b) {
            return (a > b) ? a : b;
        }

        public static double Max(params double[] values) {
            int num = values.Length;
            if (num == 0) {
                return 0f;
            }

            double num2 = values[0];
            for (int i = 1; i < num; i++) {
                if (values[i] > num2) {
                    num2 = values[i];
                }
            }

            return num2;
        }

        #endregion
    }
}