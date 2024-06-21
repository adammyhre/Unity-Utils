using System.Threading.Tasks;
using UnityEngine;

namespace UnityUtils {
    public static class AsyncOperationExtensions {
        /// <summary>
        /// Extension method that converts an AsyncOperation into a Task.
        /// </summary>
        /// <param name="asyncOperation">The AsyncOperation to convert.</param>
        /// <returns>A Task that represents the completion of the AsyncOperation.</returns>
        public static Task AsTask(this AsyncOperation asyncOperation) {
            var tcs = new TaskCompletionSource<bool>();
            asyncOperation.completed += _ => tcs.SetResult(true);
            return tcs.Task;
        }
    }
}