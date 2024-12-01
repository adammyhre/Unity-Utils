using System;
using System.Collections;
using System.Threading.Tasks;

namespace UnityUtils {
    public static class TaskExtensions {
        /// <summary>
        /// Wraps the provided object into a completed Task.
        /// </summary>
        /// <param name="obj">The object to be wrapped in a Task.</param>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>A completed Task containing the object.</returns>
        public static Task<T> AsCompletedTask<T>(this T obj) => Task.FromResult(obj);
        
        /// <summary>
        /// Converts the Task into an IEnumerator for Unity coroutine usage.
        /// </summary>
        /// <param name="task">The Task to convert.</param>
        /// <returns>An IEnumerator representation of the Task.</returns>
        public static IEnumerator AsCoroutine(this Task task) {
            while (!task.IsCompleted) yield return null;
            // When used on a faulted Task, GetResult() will propagate the original exception. 
            // see: https://devblogs.microsoft.com/pfxteam/task-exception-handling-in-net-4-5/
            task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Marks a task to be forgotten, meaning any exceptions thrown by the task will be caught and handled.
        /// </summary>
        /// <param name="task">The task to be forgotten.</param>
        /// <param name="onException">The optional action to execute when an exception is caught. If provided, the exception will not be rethrown.</param>
        public static async void Forget(this Task task, Action<Exception> onException = null) {
            try {
                await task;
            }
            catch (Exception exception) {
                if (onException == null)
                    throw exception;

                onException(exception);
            }
        }
    }
}