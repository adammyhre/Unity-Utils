using UnityEngine.UIElements;

namespace UnityUtils {
    public static class VisualElementExtensions {
        /// <summary>
        /// Creates a new child VisualElement and adds it to the parent.
        /// </summary>
        /// <param name="parent">The parent VisualElement to add the child to.</param>
        /// <param name="classes">The CSS classes to add to the child.</param>
        /// <returns>The created child VisualElement.</returns>
        public static VisualElement CreateChild(this VisualElement parent, params string[] classes) {
            var child = new VisualElement();
            child.AddClass(classes).AddTo(parent);
            return child;
        }

        /// <summary>
        /// Creates a new child of type T and adds it to the parent.
        /// </summary>
        /// <typeparam name="T">The type of the child VisualElement.</typeparam>
        /// <param name="parent">The parent VisualElement to add the child to.</param>
        /// <param name="classes">The CSS classes to add to the child.</param>
        /// <returns>The created child VisualElement of type T.</returns>
        public static T CreateChild<T>(this VisualElement parent, params string[] classes)
            where T : VisualElement, new() {
            var child = new T();
            child.AddClass(classes).AddTo(parent);
            return child;
        }

        /// <summary>
        /// Adds the child VisualElement to the parent and returns the child.
        /// </summary>
        /// <typeparam name="T">The type of the child VisualElement.</typeparam>
        /// <param name="child">The child VisualElement to add.</param>
        /// <param name="parent">The parent VisualElement to add the child to.</param>
        /// <returns>The added child VisualElement.</returns>
        public static T AddTo<T>(this T child, VisualElement parent) where T : VisualElement {
            parent.Add(child);
            return child;
        }

        /// <summary>
        /// Adds the specified CSS classes to the VisualElement.
        /// </summary>
        /// <typeparam name="T">The type of the VisualElement.</typeparam>
        /// <param name="visualElement">The VisualElement to add the classes to.</param>
        /// <param name="classes">The CSS classes to add.</param>
        /// <returns>The VisualElement with the added classes.</returns>
        public static T AddClass<T>(this T visualElement, params string[] classes) where T : VisualElement {
            foreach (string cls in classes) {
                if (!string.IsNullOrEmpty(cls)) {
                    visualElement.AddToClassList(cls);
                }
            }
            return visualElement;
        }

        /// <summary>
        /// Adds a manipulator to the VisualElement.
        /// </summary>
        /// <typeparam name="T">The type of the VisualElement.</typeparam>
        /// <param name="visualElement">The VisualElement to add the manipulator to.</param>
        /// <param name="manipulator">The manipulator to add.</param>
        /// <returns>The VisualElement with the added manipulator.</returns>
        public static T WithManipulator<T>(this T visualElement, IManipulator manipulator) where T : VisualElement {
            visualElement.AddManipulator(manipulator);
            return visualElement;
        }
        
        /// <summary>
        /// Sets the background image of a VisualElement using a Sprite.
        /// This method internally calls <see cref="SpriteToTexture"/> to convert the Sprite to a Texture2D.
        /// </summary>
        /// <param name="imageContainer">The VisualElement to set the background image for.</param>
        /// <param name="sprite">The Sprite to use as the background image.</param>
        public static void SetImage(this VisualElement imageContainer, Sprite sprite) {
            var texture = SpriteToTexture(sprite);
            if (texture) {
                imageContainer.style.backgroundImage = new StyleBackground(texture);
            }
        }
        
        /// <summary>
        /// Converts a Sprite to a Texture2D. If the sprite's dimensions exceed the texture bounds, 
        /// it resizes the texture to fit within the bounds and extracts the pixel data accordingly.
        /// </summary>
        /// <param name="sprite">The Sprite to convert to a Texture2D.</param>
        /// <returns>A Texture2D created from the Sprite's pixel data, or null if the sprite is null.</returns>
        static Texture2D SpriteToTexture(Sprite sprite) {
            if (!sprite) return null;

            // Get the sprite's dimensions and texture data
            var width = (int)sprite.rect.width;
            var height = (int)sprite.rect.height;
            int textureWidth = sprite.texture.width;
            int textureHeight = sprite.texture.height;
            var textureRectX = (int)sprite.textureRect.x;
            var textureRectY = (int)sprite.textureRect.y;
            // Clamp the dimensions to the texture bounds
            int clampedWidth = Mathf.Min(width, textureWidth - textureRectX);
            int clampedHeight = Mathf.Min(height, textureHeight - textureRectY);
            // Extract the pixel data from the sprite's texture
            var texture = new Texture2D(clampedWidth, clampedHeight, TextureFormat.RGBA32, false);
            Color[] pixels = sprite.texture.GetPixels(textureRectX, textureRectY, clampedWidth, clampedHeight);
            texture.SetPixels(pixels);
            texture.Apply();

            return texture;
        }
    }
}