using System.IO;
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
        // (species, count, centre x, centre z, spread): near the gate are the gentle and early camps; deeper are wolves,
        // archers and the undead; the far clearing is the tyrant's.
        static readonly (string id, int count, float x, float z, float spread)[] WhisperwoodCamps =
        {
            ("mon_fluffcap_sheep", 3, 12f, 32f, 2.5f),
            ("mon_moss_tortoise", 1, -12f, 33f, 0f),
            ("mon_lantern_moth", 2, 4f, 36f, 1.5f),
            ("mon_green_slime", 4, -6f, 38f, 2f),
            ("mon_grove_goblin", 3, 10f, 44f, 2f),
            ("mon_kobold_scavenger", 2, -16f, 44f, 1.5f),
            ("mon_giant_ant", 4, 0f, 48f, 2f),
            ("mon_walking_mushroom", 2, -9f, 52f, 1.5f),
            ("mon_puffcap_mushroom", 2, -12f, 54f, 1.5f),
            ("mon_mandrake", 1, 16f, 54f, 0f),
            ("mon_giant_crow", 2, 20f, 60f, 2f),
            ("mon_forest_wolf", 3, -4f, 62f, 2.5f),
            ("mon_goblin_archer", 2, 9f, 66f, 3f),
            ("mon_cave_spider", 2, -18f, 66f, 2f),
            ("mon_skeleton", 2, 0f, 74f, 3f),
            ("mon_grukk_goblin_chief_of_hollowpine", 1, 0f, 88f, 0f),
        };

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
            var ws = Prim(PrimitiveType.Cylinder, "Waystone_Whisperwood", new Vector3(-3, 1.1f, 27), new Vector3(0.8f, 1.1f, 0.8f), Mat("Waystone", new Color(0.45f, 0.7f, 0.95f), 0.6f), root);
            ws.AddComponent<Ascend.Game.Waystone>();

            // Trees: seeded so the layout is the same every build; kept clear of the path, the camps and the clearing.
            var rng = new System.Random(1);
            int placed = 0;
            for (int tries = 0; tries < 600 && placed < 110; tries++)
            {
                var at = new Vector3((float)(rng.NextDouble() * 66 - 33), 0, (float)(rng.NextDouble() * 66 + 27));
                if (Mathf.Abs(at.x) < 2.5f) continue; // the path north
                if (new Vector2(at.x, at.z - 88f).magnitude < 11f) continue; // Grukk's clearing
                bool nearCamp = false;
                foreach (var c in WhisperwoodCamps) if (new Vector2(at.x - c.x, at.z - c.z).magnitude < c.spread + 2.5f) { nearCamp = true; break; }
                if (nearCamp) continue;
                float h = 3f + (float)rng.NextDouble() * 4f;
                Prim(PrimitiveType.Cylinder, $"Trunk_{placed}", at + Vector3.up * h * 0.5f, new Vector3(0.5f, h * 0.5f, 0.5f), bark, root);
                float crown = 2.2f + (float)rng.NextDouble() * 1.6f;
                Prim(PrimitiveType.Sphere, $"Crown_{placed}", at + Vector3.up * (h + crown * 0.3f), Vector3.one * crown, leaves, root, keepCollider: false);
                placed++;
            }
            // Ruins in the clearing (Whisperwood is forest and ruins).
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
