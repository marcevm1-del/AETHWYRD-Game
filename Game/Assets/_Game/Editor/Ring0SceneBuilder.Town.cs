using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Brindlewick's buildings (Tools/blender/town_buildings.py → Art/Models/Buildings): the guild hall, the Sleeping
    /// Griffon, the smithy, houses, the temple and orphanage by their landmarks, the barn at Millbrook's granary, the north
    /// gatehouse with its palisade, and the waystones, the well and the Old Watchtower out past the treeline. Each model's
    /// front door faces +Z at yaw 0. Buildings ring the plaza so the start, the NPCs and the movement test course stay open.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        const string BuildingDir = "Assets/_Game/Art/Models/Buildings";

        // (model, position, yaw): doors face the plaza or the street.
        static readonly (string id, Vector3 at, float yaw)[] TownBuildings =
        {
            ("guild_hall", new Vector3(5f, 0, -17f), 0f),
            ("inn_sleeping_griffon", new Vector3(-9f, 0, -19f), 0f),
            ("smithy", new Vector3(-3f, 0, -11f), 0f),
            ("temple", new Vector3(-26f, 0, -9f), 90f),
            ("orphanage", new Vector3(19f, 0, -13f), -90f),
            ("house_cottage", new Vector3(-22f, 0, -24f), 20f),
            ("house_tall", new Vector3(-28f, 0, 4f), 90f),
            ("house_house", new Vector3(20f, 0, -24f), 0f),
            ("house_cottage", new Vector3(28f, 0, -6f), -90f),
            ("barn", new Vector3(33f, 0, 6f), -90f),
            ("town_gate", new Vector3(0f, 0, 20.5f), 0f),
            ("windmill", new Vector3(30f, 0, 13f), -90f),            // Millbrook's mill, sails toward the town
            // The market on the gate road, lamps along the roads, crates by the yards.
            ("market_stall_red", new Vector3(-6.5f, 0, 9f), 90f),
            ("market_stall_blue", new Vector3(6.5f, 0, 16f), -90f),
            ("lamp_post", new Vector3(2.6f, 0, 8.5f), 180f),
            ("lamp_post", new Vector3(-2.6f, 0, 16f), 0f),
            ("lamp_post", new Vector3(10.5f, 0, 1.8f), 90f),
            ("lamp_post", new Vector3(17f, 0, 1.8f), 90f),
            ("lamp_post", new Vector3(-11f, 0, -5.8f), -90f),
            ("crates", new Vector3(-6.8f, 0, -9.5f), 15f),
            ("crates", new Vector3(-14.6f, 0, -14.6f), -30f),
            ("crates", new Vector3(28.4f, 0, 9.6f), 60f),
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

        // Flat, walkable ground pieces (no colliders): the plaza and the dirt roads (scaled along their length).
        static readonly (string id, Vector3 at, float yaw, float length)[] TownGround =
        {
            ("plaza", new Vector3(0f, 0, -2f), 0f, 1f),
            ("road", new Vector3(0f, 0, 14f), 0f, 1.2f),          // plaza to the gate
            ("road", new Vector3(0f, 0, 26f), 0f, 1.2f),          // through the gate to the treeline camp
            ("road", new Vector3(19f, 0, -0.5f), 90f, 1.8f),      // east to Millbrook's farms
            ("road", new Vector3(-16.5f, 0, -8.5f), 90f, 1.3f),   // west to the temple
        };

        static void BuildTown(Transform world)
        {
            var town = new GameObject("Brindlewick_Buildings").transform;
            town.SetParent(world, false);
            int placed = 0;
            foreach (var b in TownBuildings)
                if (Building(town, b.id, b.at, b.yaw) != null) placed++;
            foreach (var g in TownGround)
                if (Building(town, g.id, g.at, g.yaw, solid: false, scale: new Vector3(1f, 1f, g.length)) != null) placed++;
            // The palisade either side of the gate, 8 m runs out to the edge of the ward.
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
            Debug.Log($"[Ascend] Brindlewick: {placed} buildings placed from {BuildingDir}");
        }

        /// <summary>
        /// A building or structure model, solid to walk into (a mesh collider per part) unless it's flat ground; null when it
        /// hasn't been exported. <paramref name="scale"/> stretches it (roads along their length).
        /// </summary>
        static GameObject Building(Transform parent, string id, Vector3 at, float yaw, string name = null, bool solid = true, Vector3? scale = null)
        {
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>($"{BuildingDir}/{id}.fbx");
            if (asset == null) return null;
            var go = (GameObject)PrefabUtility.InstantiatePrefab(asset, parent);
            go.name = name ?? id;
            go.transform.SetPositionAndRotation(at, Quaternion.Euler(0f, yaw, 0f));
            if (scale.HasValue) go.transform.localScale = Vector3.Scale(go.transform.localScale, scale.Value);
            if (solid)
                foreach (var mf in go.GetComponentsInChildren<MeshFilter>())
                    mf.gameObject.AddComponent<MeshCollider>().sharedMesh = mf.sharedMesh;
            GameObjectUtility.SetStaticEditorFlags(go, StaticEditorFlags.BatchingStatic | StaticEditorFlags.OccluderStatic | StaticEditorFlags.OccludeeStatic);
            return go;
        }
    }
}
