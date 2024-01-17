using UnityEngine;

public static class Vector3Extensions {
    /// <summary>
    /// Sets any x y z values of a Vector3
    /// </summary>
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }

    /// <summary>
    /// Adds to any x y z values of a Vector3
    /// </summary>
    public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) {
        return new Vector3(vector.x + x, vector.y + y, vector.z + z);
    }

    /// <summary>
    /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
    /// </summary>
    /// <param name="current">The current Vector3 position</param>
    /// <param name="target">The Vector3 position to compare against</param>
    /// <param name="range">The range value to compare against</param>
    /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
    public static bool InRangeOf(this Vector3 current, Vector3 target, float range) {
        return (current - target).sqrMagnitude <= range * range;
    }
}