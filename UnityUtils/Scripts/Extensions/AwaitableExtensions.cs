using System;
using UnityEngine;

namespace UnityUtils {
    public static class AwaitableExtensions {
        /// <summary>
        /// Repeatedly polls a condition until it returns true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="pollIntervalMs">Time between condition checks in milliseconds. Default is 33ms (≈ one frame at 30 FPS).</param>
        /// <returns>An Awaitable that completes when the condition returns true.</returns>
        /// <exception cref="ArgumentNullException">Thrown when condition is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when pollIntervalMs is not positive.</exception>
        public static Awaitable WaitUntil(this Func<bool> condition, int pollIntervalMs = 33) {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            if (pollIntervalMs <= 0)
                throw new ArgumentOutOfRangeException(nameof(pollIntervalMs), "Poll interval must be positive");

            var source = new AwaitableCompletionSource();

            if (condition()) {
                source.SetResult();
                return source.Awaitable;
            }

            var interval = TimeSpan.FromMilliseconds(pollIntervalMs);

            async void Poll() {
                while (!condition()) {
                    await Awaitable.WaitForSecondsAsync((float)interval.TotalSeconds);
                }

                source.SetResult();
            }

            Poll();
            return source.Awaitable;
        }
    }
}