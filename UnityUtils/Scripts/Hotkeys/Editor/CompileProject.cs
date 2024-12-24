using UnityEditor;
using UnityEditor.Compilation;

public static class CompileProject {
    [MenuItem("File/Compile _F5")]
    static void Compile() {
        CompilationPipeline.RequestScriptCompilation(RequestScriptCompilationOptions.CleanBuildCache);
    }
}