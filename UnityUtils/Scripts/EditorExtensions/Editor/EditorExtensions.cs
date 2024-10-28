using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityUtils {
    /// <summary>
    /// Provides extension methods for various editor functionalities.
    /// </summary>
    public static class EditorExtensions {
        /// <summary>
        /// Checks if a file exists at the specified path and prompts the user for confirmation to overwrite it.
        /// </summary>
        /// <param name="path">The file path to check.</param>
        /// <returns>True if the file does not exist or the user confirms to overwrite it; otherwise, false.</returns>
        public static bool ConfirmOverwrite(this string path) {
            if (File.Exists(path)) {
                return EditorUtility.DisplayDialog
                (
                    "File Exists",
                    "The file already exists at the specified path. Do you want to overwrite it?",
                    "Yes",
                    "No"
                );
            }

            return true;
        }

        /// <summary>
        /// Opens a folder browser dialog and returns the selected folder path.
        /// </summary>
        /// <param name="defaultPath">The default path to open the folder browser at.</param>
        /// <returns>The selected folder path.</returns>
        public static string BrowseForFolder(this string defaultPath) {
            return EditorUtility.SaveFolderPanel
            (
                "Choose Save Path",
                defaultPath,
                ""
            );
        }

        /// <summary>
        /// Pings and selects the specified asset in the Unity Editor.
        /// </summary>
        /// <param name="asset">The asset to ping and select.</param>
        public static void PingAndSelect(this Object asset) {
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }
    }
}