using UnityEditor;
using UnityEngine;

public static class CloseWindowTab {
    [MenuItem("File/Close Window Tab %w")]
    static void CloseTab() {
        var focusedWindow = EditorWindow.focusedWindow;
        if (focusedWindow != null) {
            CloseTab(focusedWindow);
        } else {
            Debug.LogWarning("Found no focused window to close");
        }
    }

    static void CloseTab(EditorWindow editorWindow) {
        editorWindow.Close();
    }
}