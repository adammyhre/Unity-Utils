using UnityEngine;

public static class Vector2Extensions
{
	/// <summary>
	/// Adds to any x y values of a Vector2
	/// </summary>
	public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0)
	{
		return new Vector2(vector2.x + x, vector2.y + y);
	}

	/// <summary>
	/// Sets any x y values of a Vector2
	/// </summary>
	public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null)
	{
		return new Vector2(x ?? vector2.x, y ?? vector2.y);
	}

	/// <summary>
	/// Returns a Boolean indicating whether the current Vector2 is in a given range from another Vector2
	/// </summary>
	/// <param name="current">The current Vector2 position</param>
	/// <param name="target">The Vector2 position to compare against</param>
	/// <param name="range">The range value to compare against</param>
	/// <returns>True if the current Vector2 is in the given range from the target Vector2, false otherwise</returns>
	public static bool InRangeOf(this Vector2 current, Vector2 target, float range)
	{
		return (current - target).sqrMagnitude <= range * range;
	}
}