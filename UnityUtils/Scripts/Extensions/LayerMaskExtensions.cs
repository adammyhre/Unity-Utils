using UnityEngine;

namespace UnityUtils {
    public static class LayerMaskExtensions {
        /// <summary>
        /// Checks if the given layer number is contained in the LayerMask.
        /// </summary>
        /// <param name="mask">The LayerMask to check.</param>
        /// <param name="layerNumber">The layer number to check if it is contained in the LayerMask.</param>
        /// <returns>True if the layer number is contained in the LayerMask, otherwise false.</returns>
        public static bool Contains(this LayerMask mask, int layerNumber) {
            return mask == (mask | (1 << layerNumber));
        }
    }
}