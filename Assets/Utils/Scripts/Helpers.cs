using System.Collections.Generic;
using UnityEngine;

public static class Helpers {
    static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new(100, new FloatComparer());

    /// <summary>
    /// Returns a WaitForSeconds object for the specified duration. </summary>
    /// <param name="seconds">The duration in seconds to wait.</param>
    /// <returns>A WaitForSeconds object.</returns>
    public static WaitForSeconds GetWaitForSeconds(float seconds) {
        if (seconds < 1f / Application.targetFrameRate) return null;

        if (WaitForSecondsDict.TryGetValue(seconds, out var forSeconds)) return forSeconds;

        var waitForSeconds = new WaitForSeconds(seconds);
        WaitForSecondsDict[seconds] = waitForSeconds;
        return waitForSeconds;
    }

    class FloatComparer : IEqualityComparer<float> {
        public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
        public int GetHashCode(float obj) => obj.GetHashCode();
    }
}
