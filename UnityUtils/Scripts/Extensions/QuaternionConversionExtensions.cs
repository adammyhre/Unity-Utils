using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityUtils {
    public static class QuaternionConversionExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToUnityQuaternion(this System.Numerics.Quaternion quaternion) {
            return new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static System.Numerics.Quaternion ToSystemQuaternion(this Quaternion quaternion) {
            return new System.Numerics.Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}