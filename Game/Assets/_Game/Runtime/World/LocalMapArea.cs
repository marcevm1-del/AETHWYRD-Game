using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The playable patch a scene covers, for the map (12_Systems/world_map.md): a square of ground centred on this
    /// object, the region it lies in, and the settlement it surrounds, which pins the area to the world map
    /// (one world-map unit is a kilometre, so the whole Ring 0 field is a fifth of a unit across).
    /// </summary>
    public sealed class LocalMapArea : MonoBehaviour
    {
        public const float MetresPerMapUnit = 1000f;

        [SerializeField] string areaId = "whisperwood_brindlewick";
        [SerializeField] string regionId = "reg_whisperwood";
        [SerializeField] string placeName = "Brindlewick";
        [SerializeField] string title = "Brindlewick and the Whisperwood edge";
        [SerializeField] float size = 200f;

        public string AreaId { get => areaId; set => areaId = value; }
        public string RegionId { get => regionId; set => regionId = value; }
        public string PlaceName { get => placeName; set => placeName = value; }
        public string Title { get => title; set => title = value; }
        public float Size { get => size; set => size = value; }
        public float MinX => transform.position.x - size / 2f;
        public float MinZ => transform.position.z - size / 2f;

        /// <summary>Where the area's settlement sits on the world map (map units), from regions.json.</summary>
        public Vector2 MapAnchor
        {
            get
            {
                if (regionId != null && AscendData.Db.Regions.TryGetValue(regionId, out var r) && r.Map != null)
                {
                    if (placeName != null && r.Map.Places != null && r.Map.Places.TryGetValue(placeName, out var p)) return new Vector2((float)p[0], (float)p[1]);
                    return new Vector2((float)r.Map.X, (float)r.Map.Y);
                }
                return new Vector2(75f, 58f);
            }
        }

        /// <summary>A scene position on the world map: the anchor plus the offset in kilometres (north is up on the map).</summary>
        public Vector2 ToWorldMap(Vector3 position)
        {
            Vector3 d = position - transform.position;
            return MapAnchor + new Vector2(d.x, -d.z) / MetresPerMapUnit;
        }

        /// <summary>A scene position as 0–1 across the local map (x east, y north), unclamped.</summary>
        public Vector2 ToLocal(Vector3 position) => new Vector2((position.x - MinX) / size, (position.z - MinZ) / size);

        /// <summary>The scene's area, or a default 200 m square at the origin when the scene has none (tests).</summary>
        public static LocalMapArea Current
        {
            get
            {
                var a = FindFirstObjectByType<LocalMapArea>();
                return a != null ? a : new GameObject("LocalMapArea (default)").AddComponent<LocalMapArea>();
            }
        }
    }
}
