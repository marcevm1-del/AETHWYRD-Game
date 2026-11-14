using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The one place that converts between the map (kilometres, x east, y SOUTH, from the north-west corner) and Unity scene
    /// metres (x east, z north). Unity (0, 0, 0) is the Ring 0 anchor (Brindlewick) at its pad height, so the hand-built
    /// Ring 0 field opens unchanged on the streamed terrain. The anchor comes from the terrain manifest (baked from the tile
    /// sidecars), so no world number is hard-coded here; defaults only apply before a manifest is read.
    /// Canon's world origin stays the map's north-west corner (world_scale.json); this is only the render-space offset
    /// (13_Production/open_world_streaming_plan.md section 5).
    /// </summary>
    public static class WorldOrigin
    {
        public static double AnchorMapXKm { get; private set; } = 72.6;
        public static double AnchorMapYKm { get; private set; } = 60.0;
        public static float AnchorHeightM { get; private set; } = 298.649f;

        public static void Configure(double mapXKm, double mapYKm, float heightM)
        {
            AnchorMapXKm = mapXKm; AnchorMapYKm = mapYKm; AnchorHeightM = heightM;
        }

        /// <summary>Map position (km) and a height above sea level (m) to a Unity position.</summary>
        public static Vector3 ToUnity(double mapXKm, double mapYKm, float heightM = 0f) =>
            new Vector3((float)((mapXKm - AnchorMapXKm) * 1000.0), heightM - AnchorHeightM, (float)(-(mapYKm - AnchorMapYKm) * 1000.0));

        /// <summary>A Unity position to the map (km).</summary>
        public static void ToMapKm(Vector3 unity, out double mapXKm, out double mapYKm)
        {
            mapXKm = AnchorMapXKm + unity.x / 1000.0;
            mapYKm = AnchorMapYKm - unity.z / 1000.0;
        }

        /// <summary>Height above sea level (m) of a Unity y.</summary>
        public static float HeightMOf(float unityY) => unityY + AnchorHeightM;
    }
}
