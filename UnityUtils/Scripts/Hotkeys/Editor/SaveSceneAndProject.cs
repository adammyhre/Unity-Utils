using UnityEngine;
using UnityEditor;

public static class SaveSceneAndProject {
    [MenuItem("File/Save Scene And Project %#&s")]
    public static void FunctionSaveSceneAndProject() {
        EditorApplication.ExecuteMenuItem("File/Save");
        EditorApplication.ExecuteMenuItem("File/Save Project");
        Debug.Log("Saved scene and project");
    }
}