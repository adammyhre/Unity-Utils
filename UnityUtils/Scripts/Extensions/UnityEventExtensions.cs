using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils {
    public static class UnityEventExtensions {
        /// <summary>
        /// Converts a UnityEvent with a parameter into an Awaitable that completes when the event is invoked.
        /// </summary>
        /// <param name="unityEvent">The UnityEvent to convert.</param>
        /// <typeparam name="T">The type of the event parameter.</typeparam>
        /// <returns>An Awaitable that completes with the event's parameter value when invoked.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unityEvent is null.</exception>
        public static Awaitable<T> AsAwaitable<T>(this UnityEvent<T> unityEvent) {
            if (unityEvent == null) throw new ArgumentNullException(nameof(unityEvent));

            var acs = new AwaitableCompletionSource<T>();
            UnityAction<T> handler = null;
            handler = value => {
                unityEvent.RemoveListener(handler);
                acs.TrySetResult(value);
            };

            unityEvent.AddListener(handler);
            return acs.Awaitable;
        }

        /// <summary>
        /// Converts a UnityEvent into an Awaitable that completes when the event is invoked.
        /// </summary>
        /// <param name="unityEvent">The UnityEvent to convert.</param>
        /// <returns>An Awaitable that completes when the event is invoked.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unityEvent is null.</exception>
        public static Awaitable AsAwaitable(this UnityEvent unityEvent) {
            if (unityEvent == null) throw new ArgumentNullException(nameof(unityEvent));

            var completionSource = new AwaitableCompletionSource();
            UnityAction handler = null;
            handler = () => {
                unityEvent.RemoveListener(handler);
                completionSource.TrySetResult();
            };

            unityEvent.AddListener(handler);
            return completionSource.Awaitable;
        }

        /// <summary>
        /// Converts a UnityEvent with a parameter into a Task that completes when the event is invoked.
        /// </summary>
        /// <param name="unityEvent">The UnityEvent to convert.</param>
        /// <typeparam name="T">The type of the event parameter.</typeparam>
        /// <returns>A Task that completes with the event's parameter value when invoked.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unityEvent is null.</exception>
        public static Task<T> AsTask<T>(this UnityEvent<T> unityEvent) {
            if (unityEvent == null) throw new ArgumentNullException(nameof(unityEvent));

            var tcs = new TaskCompletionSource<T>();
            UnityAction<T> handler = null;
            handler = value => {
                unityEvent.RemoveListener(handler);
                tcs.TrySetResult(value);
            };

            unityEvent.AddListener(handler);
            return tcs.Task;
        }

        /// <summary>
        /// Converts a UnityEvent into a Task that completes when the event is invoked.
        /// </summary>
        /// <param name="unityEvent">The UnityEvent to convert.</param>
        /// <returns>A Task that completes when the event is invoked.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unityEvent is null.</exception>
        public static Task AsTask(this UnityEvent unityEvent) {
            if (unityEvent == null) throw new ArgumentNullException(nameof(unityEvent));

            var tcs = new TaskCompletionSource<bool>();
            UnityAction handler = null;
            handler = () => {
                unityEvent.RemoveListener(handler);
                tcs.TrySetResult(true);
            };

            unityEvent.AddListener(handler);
            return tcs.Task;
        }
    }
}