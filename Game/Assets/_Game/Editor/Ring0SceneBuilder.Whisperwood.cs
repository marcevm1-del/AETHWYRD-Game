using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ascend.EditorTools
{
    /// <summary>
    /// The Whisperwood test field (Ring 1, reg_whisperwood): a forest strip north of the Brindlewick gate with a
    /// waystone at the treeline and camps that rise in level the deeper you go, ending in Grukk's clearing. Every
    /// monster is a species from species.json using its blockout model when one has been exported (local only),
    /// else a labelled primitive, so the field works on any machine.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        // The town ward over Brindlewick, Millbrook's fields and the treeline camp (x -38..38, z -60..33).
        static readonly Vector2 WardCentre = new Vector2(0f, -13.5f), WardSize = new Vector2(76f, 93f);
        static readonly Vector3 WatchtowerAt = new Vector3(-29.5f, 0f, 42.5f);

        // (species, count, centre x, centre z, spread). Every camp sits outside the town ward and is spaced so their
        // alert circles don't chain: Ring 0's level-3 camps just past the treeline (the well, the goblin pack) and in the
        // east meadow; the level-8 camps through the middle of the wood and the passive grazers in the meadows beyond its
        // flanks; the level-13 camps deep in, each 24 m or more from Grukk so a fight there doesn't pull the tyrant.
        static readonly (string id, int count, float x, float z, float spread)[] FieldCamps =
        {
            ("mon_blue_slime", 3, 26f, 40f, 2.4f),     // Millbrook's old well (Slime in the Well)
            ("mon_goblin", 5, -22f, 46f, 2.4f),        // the goblin pack, by the Old Watchtower
            ("mon_horned_rabbit", 2, 48f, 34f, 3f),    // the east meadow beyond the trees (Rabbit Season)
        };

        static readonly (string id, int count, float x, float z, float spread)[] WhisperwoodCamps =
        {
            ("mon_lantern_moth", 2, 4f, 42f, 2f),
            ("mon_moss_tortoise", 1, -46f, 48f, 0f),   // west meadow, beyond the trees
            ("mon_fluffcap_sheep", 3, 50f, 54f, 4f),   // east meadow, beyond the trees
            ("mon_green_slime", 4, 22f, 56f, 3f),
            ("mon_kobold_scavenger", 2, -28f, 62f, 2f),
            ("mon_giant_ant", 4, -2f, 62f, 3f),
            ("mon_giant_crow", 2, 34f, 68f, 2f),
            ("mon_grove_goblin", 3, 16f, 70f, 2.5f),
            ("mon_walking_mushroom", 2, -14f, 70f, 2f),
            ("mon_puffcap_mushroom", 2, -30f, 80f, 2f),
            ("mon_mandrake", 1, 30f, 82f, 0f),
            ("mon_forest_wolf", 3, -24f, 74f, 3f),
            ("mon_goblin_archer", 2, 24f, 76f, 3f),
            ("mon_cave_spider", 2, -30f, 92f, 2f),
            ("mon_skeleton", 2, 28f, 92f, 2.5f),
            ("mon_grukk_goblin_chief_of_hollowpine", 1, 0f, 88f, 0f),
        };

        /// <summary>Where a camp's monsters stand: evenly round its centre (the centre itself for a single monster).</summary>
        static IEnumerable<Vector3> CampSpots((string id, int count, float x, float z, float spread) c)
        {
            for (int i = 0; i < c.count; i++)
            {
                float a = i / (float)c.count * Mathf.PI * 2f;
                yield return c.count == 1 ? new Vector3(c.x, 0, c.z) : new Vector3(c.x + Mathf.Cos(a) * c.spread, 0, c.z + Mathf.Sin(a) * c.spread);
            }
        }

        static void BuildWhisperwood(Transform world, Material ground, Material wood, Material accent)
        {
            var root = new GameObject("Whisperwood").transform;
            root.SetParent(world, false);
            var floor = Mat("ForestFloor", new Color(0.30f, 0.44f, 0.28f));
            var leaves = Mat("Leaves", new Color(0.22f, 0.45f, 0.26f));
            var bark = Mat("Bark", new Color(0.36f, 0.26f, 0.18f));
            var fallback = Mat("MonsterStandIn", new Color(0.8f, 0.45f, 0.55f));
            Prim(PrimitiveType.Cube, "ForestFloor", new Vector3(0, 0.01f, 60), new Vector3(70, 0.02f, 70), floor, root, keepCollider: false);

            // Treeline waystone: attune it and you respawn here instead of at the start.
            var ws = Building(root, "waystone", new Vector3(-3, 0, 27), 0f, "Waystone_Whisperwood")
                ?? Prim(PrimitiveType.Cylinder, "Waystone_Whisperwood", new Vector3(-3, 1.1f, 27), new Vector3(0.8f, 1.1f, 0.8f), Mat("Waystone", new Color(0.45f, 0.7f, 0.95f), 0.6f), root);
            ws.AddComponent<Ascend.Game.Waystone>();
            // The Old Watchtower ruin, behind its landmark post (the goblin pack camps in its shadow).
            Building(root, "watchtower_ruin", WatchtowerAt, 210f, "Old_Watchtower");

            // Trees: seeded so the layout is the same every build; kept clear of the path, the camps and the clearing.
            var rng = new System.Random(1);
            int placed = 0;
            for (int tries = 0; tries < 600 && placed < 110; tries++)
            {
                var at = new Vector3((float)(rng.NextDouble() * 66 - 33), 0, (float)(rng.NextDouble() * 66 + 27));
                if (Mathf.Abs(at.x) < 2.5f) continue; // the path north
                if (new Vector2(at.x, at.z - 88f).magnitude < 11f) continue; // Grukk's clearing
                if (new Vector2(at.x - WatchtowerAt.x, at.z - WatchtowerAt.z).magnitude < 6.5f) continue; // the watchtower ruin
                if (at.z < 37f && Mathf.Abs(at.x) < 17f) continue; // the treeline camp's clearing
                bool nearCamp = false;
                foreach (var c in WhisperwoodCamps.Concat(FieldCamps)) if (new Vector2(at.x - c.x, at.z - c.z).magnitude < c.spread + 2.5f) { nearCamp = true; break; }
                if (nearCamp) continue;
                float h = 3f + (float)rng.NextDouble() * 4f;
                Prim(PrimitiveType.Cylinder, $"Trunk_{placed}", at + Vector3.up * h * 0.5f, new Vector3(0.5f, h * 0.5f, 0.5f), bark, root);
                float crown = 2.2f + (float)rng.NextDouble() * 1.6f;
                Prim(PrimitiveType.Sphere, $"Crown_{placed}", at + Vector3.up * (h + crown * 0.3f), Vector3.one * crown, leaves, root, keepCollider: false);
                placed++;
            }
            // Ruins in the clearing (Whisperwood is forest and ruins) and Grukk's camp among them.
            var ruins = new (string id, Vector3 at, float yaw)[]
            {
                ("ruin_arch", new Vector3(0f, 0, 97.5f), 0f), ("ruin_mural_wall", new Vector3(-7f, 0, 94.5f), 30f),
                ("ruin_column_whole", new Vector3(9f, 0, 88f), 0f), ("ruin_column", new Vector3(-9f, 0, 88f), 120f),
                ("ruin_column", new Vector3(6.4f, 0, 81.6f), 40f), ("ruin_column_whole", new Vector3(-6.4f, 0, 81.6f), 0f),
                ("goblin_hut", new Vector3(8.5f, 0, 95f), 220f), ("goblin_hut", new Vector3(12.5f, 0, 86f), 270f),
                ("goblin_totem", new Vector3(3f, 0, 82f), 180f),
            };
            int ruinModels = 0;
            foreach (var r in ruins) if (Building(root, r.id, r.at, r.yaw) != null) ruinModels++;
            if (ruinModels == 0)
                for (int i = 0; i < 6; i++)
                {
                    float a = i / 6f * Mathf.PI * 2f;
                    Prim(PrimitiveType.Cube, $"Ruin_{i}", new Vector3(Mathf.Cos(a) * 9f, 1.2f, 88f + Mathf.Sin(a) * 9f), new Vector3(1.2f, 2.4f - (i % 3) * 0.6f, 1.2f), Mat("Stone", new Color(0.68f, 0.68f, 0.72f)), root);
                }

            var monsters = new GameObject("Whisperwood_Monsters").transform;
            int models = 0;
            foreach (var c in WhisperwoodCamps)
            {
                for (int i = 0; i < c.count; i++)
                {
                    float a = c.count == 1 ? 0f : i / (float)c.count * Mathf.PI * 2f;
                    var at = new Vector3(c.x + Mathf.Cos(a) * c.spread, 0, c.z + Mathf.Sin(a) * c.spread);
                    if (Model(monsters, c.id, c.id, at)) { models++; continue; }
                    float size = Ascend.Game.AscendData.Db.Species.TryGetValue(c.id, out var sp) && sp.SizeMeters > 0 ? (float)sp.SizeMeters : 1f;
                    var s = new Vector3(size * 0.45f, size * 0.5f, size * 0.45f);
                    Dummy(monsters, c.id, PrimitiveType.Capsule, at + Vector3.up * s.y, s, fallback);
                }
            }
            Debug.Log($"[Ascend] Whisperwood: {placed} trees, {monsters.childCount} monster objects ({models} with models)");
        }

        /// <summary>A still from the gate looking up the Whisperwood path (13_Production/screenshots/whisperwood_field.png).</summary>
        static void RenderWhisperwoodPreview()
        {
            var go = new GameObject("PreviewCam");
            var cam = go.AddComponent<Camera>();
            cam.fieldOfView = 55f;
            go.transform.position = new Vector3(0f, 7f, 22f);
            go.transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, 62f) - go.transform.position);
            foreach (var label in Object.FindObjectsByType<TextMesh>(FindObjectsSortMode.None))
                label.transform.rotation = Quaternion.LookRotation(label.transform.position - go.transform.position);
            bool asyncWas = EditorSettings.asyncShaderCompilation;
            EditorSettings.asyncShaderCompilation = false;
            var rt = new RenderTexture(1280, 720, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB) { antiAliasing = 4 };
            cam.targetTexture = rt;
            cam.Render(); cam.Render();
            EditorSettings.asyncShaderCompilation = asyncWas;
            RenderTexture.active = rt;
            var tex = new Texture2D(1280, 720, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            tex.Apply();
            RenderTexture.active = null;
            string path = Path.Combine(Path.GetDirectoryName(ScreenshotPath), "whisperwood_field.png");
            File.WriteAllBytes(path, tex.EncodeToPNG());
            Object.DestroyImmediate(tex);
            rt.Release();
            Object.DestroyImmediate(go);
            Debug.Log("[Ascend] Preview saved: " + path);
        }
    }
}
