using UnityEngine;
using UnityEngine.Rendering;

public static class ResourcesUtils {
    public static void LoadVolumeProfile(this Volume volume, string path) {
        var profile = Resources.Load<VolumeProfile>(path);
        volume.profile = profile;
    }
}