using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Brindlewick's 50 buildings and its structures (Tools/blender/town_buildings.py → Art/Models/Buildings), in the
    /// anime style of 13_Production/anime_building_style.md: toon-shaded with ink outlines (Ascend/Toon).
    /// The old village rings the plaza (guild hall, inn, smithy, temple, orphanage, gatehouse and palisade); the new
    /// quarter to the south has Market Street's shops, Hall Square (fountain, town hall, clock tower, mage tower) and
    /// Rose Lane's houses; a farmstead lies east of town. Streets are filled by a packer that lines models up by their
    /// real footprints. Each model's front faces +Z at yaw 0.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        const string BuildingDir = "Assets/_Game/Art/Models/Buildings";
        const string ToonDir = "Assets/_Game/Art/Materials/Toon";

        // (model, position, yaw): placed by hand around the plaza, the square and the farmstead.
        static readonly (string id, Vector3 at, float yaw)[] TownBuildings =
        {
            ("guild_hall", new Vector3(5f, 0, -17f), 0f),
            ("inn_sleeping_griffon", new Vector3(-9f, 0, -19f), 0f),
            ("smithy", new Vector3(-3f, 0, -11f), 0f),
            ("temple", new Vector3(-26f, 0, -9f), 90f),
            ("orphanage", new Vector3(19f, 0, -13f), -90f),
            ("house_tall", new Vector3(-28f, 0, 4f), 90f),
            ("house_house", new Vector3(20f, 0, -24f), 0f),
            ("house_cottage", new Vector3(28f, 0, -6f), -90f),
            ("barn", new Vector3(33f, 0, 6f), -90f),
            ("town_gate", new Vector3(0f, 0, 20.5f), 0f),
            ("windmill", new Vector3(30f, 0, 13f), -90f),            // Millbrook's mill, sails toward the town
            ("guard_tower", new Vector3(-40f, 0, 20.8f), 0f),        // the palisade's corner towers
            ("guard_tower", new Vector3(40f, 0, 20.8f), 0f),
            // Hall Square, south of Market Street.
            ("fountain", new Vector3(0f, 0, -39f), 0f),
            ("town_hall", new Vector3(0f, 0, -55f), 0f),
            ("clock_tower", new Vector3(-12.5f, 0, -47f), 0f),        // the skyline anchor
            ("mage_tower", new Vector3(14f, 0, -48f), 0f),
            // The farmstead east of town.
            ("farmhouse", new Vector3(56f, 0, -18f), -90f),
            ("stable", new Vector3(56f, 0, -34f), -90f),
            ("granary_silo", new Vector3(65f, 0, -26f), 0f),
            ("chicken_coop", new Vector3(47f, 0, -26f), -90f),
            ("greenhouse", new Vector3(47f, 0, -8f), -90f),
            ("watermill", new Vector3(64f, 0, -4f), -90f),
            ("stone_bridge", new Vector3(70f, 0, -4f), 0f),           // over the mill race
            ("roadside_shrine", new Vector3(42f, 0, -1.5f), -90f),    // where the farm track meets the east road
            ("well", new Vector3(50f, 0, -40f), 0f),
            // The market on the gate road, lamps along the roads, crates by the yards.
            ("market_stall_red", new Vector3(-6.5f, 0, 9f), 90f),
            ("market_stall_blue", new Vector3(6.5f, 0, 16f), -90f),
            ("lamp_post", new Vector3(2.6f, 0, 8.5f), 180f),
            ("lamp_post", new Vector3(-2.6f, 0, 16f), 0f),
            ("lamp_post", new Vector3(10.5f, 0, 1.8f), 90f),
            ("lamp_post", new Vector3(17f, 0, 1.8f), 90f),
            ("lamp_post", new Vector3(-11f, 0, -5.8f), -90f),
            ("lamp_post", new Vector3(-6f, 0, -32.6f), 0f),
            ("lamp_post", new Vector3(6f, 0, -32.6f), 0f),
            ("crates", new Vector3(-6.8f, 0, -9.5f), 15f),
            ("crates", new Vector3(28.4f, 0, 9.6f), 60f),
            ("crates", new Vector3(52f, 0, -27f), 30f),
            // The training yard inside the palisade, by Captain Holt's mock raid.
            ("training_dummy", new Vector3(-7f, 0, 18.2f), 180f),
            ("training_dummy", new Vector3(-10.5f, 0, 18.5f), 170f),
            ("weapon_rack", new Vector3(-13.5f, 0, 18.8f), 180f),
            ("archery_target", new Vector3(-16.5f, 0, 18.8f), 180f),
            // The treeline camp: tents behind the adventurers, a fire for Lyra, Pell's wagon.
            ("tent", new Vector3(-8.5f, 0, 32.5f), 180f),
            ("tent_green", new Vector3(8.8f, 0, 33f), 180f),
            ("tent", new Vector3(-13.5f, 0, 34.5f), 160f),
            ("campfire", new Vector3(1.5f, 0, 31f), 0f),
            ("wagon", new Vector3(8.5f, 0, 24.5f), 90f),
        };

        // Streets filled by the packer: (models in order, where the frontage starts, the buildings' yaw, frontage length).
        // Yaw 0 faces north (+Z) and fills west → east; yaw 180 faces south and fills east → west.
        static readonly (string[] ids, Vector3 from, float yaw, float length)[] TownStreets =
        {
            (new[] { "bakery", "apothecary", "tailor", "bookshop" }, new Vector3(-50f, 0, -32.4f), 0f, 41f),          // Market Street, west
            (new[] { "general_store", "tavern", "teahouse" }, new Vector3(9f, 0, -32.4f), 0f, 29.5f),                  // Market Street, east
            (new[] { "corner_house_turret", "row_house", "townhouse_bay", "house_cottage" }, new Vector3(-9f, 0, -63.8f), 180f, 47f),  // Rose Lane, north side west
            (new[] { "row_house_balcony", "flower_shop", "carpenter_workshop" }, new Vector3(46f, 0, -63.8f), 180f, 36f),         // Rose Lane, north side east
            (new[] { "bathhouse", "cottage_round", "mushroom_house", "gazebo" }, new Vector3(-56f, 0, -68.6f), 0f, 52f),             // Rose Lane, south side west
            (new[] { "manor", "library", "guard_barracks" }, new Vector3(0f, 0, -68.6f), 0f, 56f),                                // Rose Lane, south side east
            (new[] { "observatory" }, new Vector3(30f, 0, -50f), 0f, 9.5f),                                                          // on the rise east of the square
        };

        // Flat, walkable ground pieces (no colliders, no outline): the plaza and the dirt roads (scaled to their length).
        static readonly (string id, Vector3 at, float yaw, float length, float width)[] TownGround =
        {
            ("plaza", new Vector3(0f, 0, -2f), 0f, 1f, 1f),
            ("road", new Vector3(0f, 0, 14f), 0f, 1.2f, 1f),          // plaza to the gate
            ("road", new Vector3(0f, 0, 26f), 0f, 1.2f, 1f),          // through the gate to the treeline camp
            ("road", new Vector3(19f, 0, -0.5f), 90f, 1.8f, 1f),      // east to Millbrook's farms
            ("road", new Vector3(37f, 0, -0.5f), 90f, 1.8f, 0.8f),    // on to the farmstead
            ("road", new Vector3(-16.5f, 0, -8.5f), 90f, 1.3f, 1f),   // west to the temple
            ("road", new Vector3(-19f, 0, -20.5f), 0f, 1.5f, 0.8f),   // temple road down to Market Street
            ("road", new Vector3(12f, 0, -21f), 0f, 1.4f, 0.8f),      // guild hall corner down to Market Street
            ("road", new Vector3(-7f, 0, -30f), 90f, 9.0f, 1f),       // Market Street
            ("road", new Vector3(0f, 0, -66f), 90f, 11.2f, 1f),       // Rose Lane
            ("road", new Vector3(-21f, 0, -48f), 0f, 3.4f, 0.8f),     // the lane from Market Street to Rose Lane (west)
            ("road", new Vector3(23f, 0, -48f), 0f, 3.4f, 0.8f),      // and east
        };

        static void BuildTown(Transform world)
        {
            var town = new GameObject("Brindlewick_Buildings").transform;
            town.SetParent(world, false);
            int placed = 0;
            foreach (var b in TownBuildings)
                if (Building(town, b.id, b.at, b.yaw) != null) placed++;
            foreach (var s in TownStreets)
                placed += Street(town, s.ids, s.from, s.yaw, s.length);
            foreach (var g in TownGround)
                if (Building(town, g.id, g.at, g.yaw, solid: false, scale: new Vector3(g.width, 1f, g.length), outline: false) != null) placed++;
            // The palisade either side of the gate, 8 m runs out to the corner towers.
            foreach (float x in new[] { 9.6f, 17.6f, 25.6f, 33.6f })
                foreach (float s in new[] { -1f, 1f })
                    if (Building(town, "palisade", new Vector3(s * x, 0, 20.8f), 0f, $"Palisade_{(s < 0 ? "W" : "E")}{x:0}") != null) placed++;
            if (placed == 0)
            {
                // No models exported on this machine: keep the old gate blockout so the town still has its gate.
                var wood = Mat("Wood", new Color(0.55f, 0.38f, 0.24f));
                Prim(PrimitiveType.Cube, "Gate_PillarL", new Vector3(-2.5f, 2.5f, 20), new Vector3(1, 5, 1), wood, world);
                Prim(PrimitiveType.Cube, "Gate_PillarR", new Vector3(2.5f, 2.5f, 20), new Vector3(1, 5, 1), wood, world);
                Prim(PrimitiveType.Cube, "Gate_Beam", new Vector3(0, 5.3f, 20), new Vector3(7, 0.6f, 1), wood, world);
            }
            Debug.Log($"[Ascend] Brindlewick: {placed} buildings and structures placed from {BuildingDir}");
        }

        /// <summary>
        /// Lines models up along a street frontage: each faces the street (yaw), its front on the frontage line, packed
        /// side by side with a gap by its real footprint; stops before the frontage runs out. Returns how many it placed.
        /// </summary>
        static int Street(Transform parent, string[] ids, Vector3 from, float yaw, float length, float gap = 1.2f)
        {
            var rot = Quaternion.Euler(0f, yaw, 0f);
            Vector3 right = rot * Vector3.right, forward = rot * Vector3.forward;
            float cursor = 0f;
            int placed = 0;
            foreach (var id in ids)
            {
                var go = Building(parent, id, Vector3.zero, yaw);
                if (go == null) continue;
                var b = WorldBounds(go);
                // Extents of the footprint along the street (right) and toward it (forward), relative to the pivot.
                float minR = Vector3.Dot(b.min - go.transform.position, right), maxR = Vector3.Dot(b.max - go.transform.position, right);
                float minF = Vector3.Dot(b.min - go.transform.position, forward), maxF = Vector3.Dot(b.max - go.transform.position, forward);
                float lo = Mathf.Min(minR, maxR), hi = Mathf.Max(minR, maxR), front = Mathf.Max(minF, maxF);
                if (cursor + (hi - lo) > length)
                {
                    Object.DestroyImmediate(go);
                    Debug.LogWarning($"[Ascend] {id} doesn't fit the street at {from}");
                    continue;
                }
                go.transform.position = from + right * (cursor - lo) - forward * front;
                cursor += (hi - lo) + gap;
                placed++;
            }
            return placed;
        }

        static Bounds WorldBounds(GameObject go)
        {
            var renderers = go.GetComponentsInChildren<Renderer>();
            var b = new Bounds(go.transform.position, Vector3.zero);
            foreach (var r in renderers) b.Encapsulate(r.bounds);
            return b;
        }

        /// <summary>
        /// A building or structure model, toon-shaded with an ink outline (unless flat ground), solid to walk into (a mesh
        /// collider per part) unless it's flat ground; null when it hasn't been exported. <paramref name="scale"/>
        /// stretches it (roads along their length and width).
        /// </summary>
        static GameObject Building(Transform parent, string id, Vector3 at, float yaw, string name = null, bool solid = true, Vector3? scale = null, bool outline = true)
        {
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>($"{BuildingDir}/{id}.fbx");
            if (asset == null) return null;
            var go = (GameObject)PrefabUtility.InstantiatePrefab(asset, parent);
            go.name = name ?? id;
            go.transform.SetPositionAndRotation(at, Quaternion.Euler(0f, yaw, 0f));
            if (scale.HasValue) go.transform.localScale = Vector3.Scale(go.transform.localScale, scale.Value);
            foreach (var r in go.GetComponentsInChildren<Renderer>())
            {
                var mats = r.sharedMaterials;
                for (int i = 0; i < mats.Length; i++) mats[i] = ToonMaterial(mats[i], outline);
                r.sharedMaterials = mats;
            }
            if (solid)
                foreach (var mf in go.GetComponentsInChildren<MeshFilter>())
                    mf.gameObject.AddComponent<MeshCollider>().sharedMesh = mf.sharedMesh;
            GameObjectUtility.SetStaticEditorFlags(go, StaticEditorFlags.BatchingStatic | StaticEditorFlags.OccluderStatic | StaticEditorFlags.OccludeeStatic);
            return go;
        }

        static readonly Dictionary<string, Material> ToonCache = new Dictionary<string, Material>();
        static readonly string[] Glowing = { "lamp", "coal", "rune", "ember", "magic" };

        /// <summary>The Ascend/Toon twin of an imported material (same colour; lamps, coals, runes and magic glow), saved once.</summary>
        static Material ToonMaterial(Material src, bool outline)
        {
            if (src == null) return null;
            var shader = Shader.Find("Ascend/Toon");
            if (shader == null) return src;
            string key = src.name + (outline ? "" : "_NoLine");
            if (ToonCache.TryGetValue(key, out var cached) && cached != null) return cached;
            string path = $"{ToonDir}/{key}.mat";
            var mat = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (mat == null)
            {
                Directory.CreateDirectory(ToonDir);
                mat = new Material(shader) { name = key };
                AssetDatabase.CreateAsset(mat, path);
            }
            mat.shader = shader;
            Color c = src.HasProperty("_BaseColor") ? src.GetColor("_BaseColor") : src.color;
            mat.SetColor("_BaseColor", c);
            bool glows = System.Array.Exists(Glowing, g => src.name.Contains(g));
            mat.SetColor("_EmissionColor", glows ? c * 1.4f : Color.black);
            mat.SetFloat("_OutlineWidth", outline ? 0.03f : 0f);
            EditorUtility.SetDirty(mat);
            ToonCache[key] = mat;
            return mat;
        }
    }
}
