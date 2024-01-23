using UnityEngine;

namespace UnityUtils {
    public static class RendererExtensions {
        /// <summary>
        /// Enables ZWrite for materials in this Renderer that have a '_Color' property. This will allow the materials 
        /// to write to the Z buffer, which could be used to affect how subsequent rendering is handled, 
        /// for instance, ensuring correct layering of transparent objects.
        /// </summary>    
        public static void EnableZWrite(this Renderer renderer) {
            foreach (Material material in renderer.materials) {
                if (material.HasProperty("_Color")) {
                    material.SetInt("_ZWrite", 1);
                    material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
                }
            }
        }

        /// <summary>
        /// Disables ZWrite for materials in this Renderer that have a '_Color' property. This would stop 
        /// the materials from writing to the Z buffer, which may be desirable in some cases to prevent subsequent 
        /// rendering from being occluded, like in rendering of semi-transparent or layered objects.
        /// </summary>
        public static void DisableZWrite(this Renderer renderer) {
            foreach (Material material in renderer.materials) {
                if (material.HasProperty("_Color")) {
                    material.SetInt("_ZWrite", 0);
                    material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent + 100;
                }
            }
        }
    }
}