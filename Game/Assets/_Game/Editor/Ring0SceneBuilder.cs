using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Ascend.Game;

namespace Ascend.EditorTools
{
    /// <summary>
    /// Builds the Ring 0 graybox field (13_Production/ring0_plan.md, weeks 1–2) and configures URP.
    ///   Unity.exe -batchmode -projectPath Game -executeMethod Ascend.EditorTools.Ring0SceneBuilder.BuildBatch
    /// Regenerating is safe: it overwrites the scene and the graybox assets it owns.
    /// </summary>
    public static partial class Ring0SceneBuilder
    {
        const string Root = "Assets/_Game";
        const string ScenePath = Root + "/Scenes/Ring0_Graybox.unity";
        const string SettingsDir = Root + "/Settings";
        const string MatDir = Root + "/Art/Graybox";
        const string ModelDir = Root + "/Art/Models/Monsters";
        static string ScreenshotPath => Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "13_Production", "screenshots", "ring0_graybox.png"));

        [MenuItem("Ascend/Ring 0/Build Graybox Scene")]
        public static void Build() => BuildInternal(false);

        public static void BuildBatch() => BuildInternal(true);

        static void BuildInternal(bool batch)
        {
            try
            {
                EnsureUrp();
                BuildScene();
                RenderPreview();
                RenderWhisperwoodPreview();
                Debug.Log("[Ascend] Ring 0 graybox built: " + ScenePath);
                if (batch) EditorApplication.Exit(0);
            }
            catch (System.Exception e)
            {
                Debug.LogError("[Ascend] Ring 0 build failed: " + e);
                if (batch) EditorApplication.Exit(1);
            }
        }

        // ---------- URP ----------
        static void EnsureUrp()
        {
            Directory.CreateDirectory(SettingsDir);
            var rendererPath = SettingsDir + "/Ascend_Renderer.asset";
            var assetPath = SettingsDir + "/Ascend_URP.asset";
            var urp = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(assetPath);
            if (urp == null)
            {
                var renderer = ScriptableObject.CreateInstance<UniversalRendererData>();
                AssetDatabase.CreateAsset(renderer, rendererPath);
                urp = UniversalRenderPipelineAsset.Create(renderer);
                AssetDatabase.CreateAsset(urp, assetPath);
            }
            PlayerSettings.colorSpace = ColorSpace.Linear; // URP's intended color space
            urp.shadowDistance = 60f;
            urp.supportsHDR = true;
            urp.msaaSampleCount = 4;
            EditorUtility.SetDirty(urp);
            GraphicsSettings.defaultRenderPipeline = urp;
            int current = QualitySettings.GetQualityLevel();
            for (int i = 0; i < QualitySettings.names.Length; i++) { QualitySettings.SetQualityLevel(i, false); QualitySettings.renderPipeline = urp; }
            QualitySettings.SetQualityLevel(current, false);
            AssetDatabase.SaveAssets();
            Debug.Log("[Ascend] URP assigned: " + assetPath);
        }

        static Material Mat(string name, Color color, float smoothness = 0.2f)
        {
            Directory.CreateDirectory(MatDir);
            var path = $"{MatDir}/{name}.mat";
            var m = AssetDatabase.LoadAssetAtPath<Material>(path);
            if (m == null)
            {
                m = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                AssetDatabase.CreateAsset(m, path);
            }
            m.SetColor("_BaseColor", color);
            m.SetFloat("_Smoothness", smoothness);
            EditorUtility.SetDirty(m);
            return m;
        }

        // ---------- Scene ----------
        static GameObject Prim(PrimitiveType type, string name, Vector3 pos, Vector3 scale, Material mat, Transform parent = null, Quaternion? rot = null, bool keepCollider = true)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = name;
            if (parent != null) go.transform.SetParent(parent, false);
            go.transform.localPosition = pos;
            go.transform.localRotation = rot ?? Quaternion.identity;
            go.transform.localScale = scale;
            go.GetComponent<Renderer>().sharedMaterial = mat;
            if (!keepCollider) Object.DestroyImmediate(go.GetComponent<Collider>());
            return go;
        }

        static void BuildScene()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ScenePath));
            var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

            var ground = Mat("Ground", new Color(0.47f, 0.66f, 0.42f));
            var stone = Mat("Stone", new Color(0.68f, 0.68f, 0.72f));
            var accent = Mat("Accent", new Color(0.95f, 0.62f, 0.32f));
            var wood = Mat("Wood", new Color(0.55f, 0.38f, 0.24f));
            var player = Mat("Player", new Color(0.30f, 0.45f, 0.95f), 0.5f);
            var slime = Mat("Slime", new Color(0.35f, 0.7f, 1f), 0.9f);
            var goblin = Mat("Goblin", new Color(0.42f, 0.55f, 0.25f));
            var rabbit = Mat("Rabbit", new Color(0.96f, 0.94f, 0.9f));

            // Light & sky: bright, warm, anime-friendly.
            var sun = Object.FindFirstObjectByType<Light>();
            sun.name = "Sun";
            sun.transform.rotation = Quaternion.Euler(48f, -35f, 0f);
            sun.color = new Color(1f, 0.95f, 0.86f);
            sun.intensity = 1.6f;
            sun.shadows = LightShadows.Soft;
            new GameObject("WorldClock").AddComponent<WorldClock>().Sun = sun; // day/night: moves this sun at runtime
            RenderSettings.ambientMode = AmbientMode.Trilight;
            RenderSettings.ambientSkyColor = new Color(0.62f, 0.74f, 0.95f);
            RenderSettings.ambientEquatorColor = new Color(0.62f, 0.66f, 0.62f);
            RenderSettings.ambientGroundColor = new Color(0.35f, 0.32f, 0.28f);

            // Ground & obstacles.
            var world = new GameObject("Graybox").transform;
            Prim(PrimitiveType.Plane, "Ground", Vector3.zero, new Vector3(20, 1, 20), ground, world);
            // The map's local area: the 200 m field around Brindlewick, in Whisperwood (12_Systems/world_map.md).
            var mapArea = new GameObject("LocalMapArea").AddComponent<LocalMapArea>();
            mapArea.transform.SetParent(world, false);
            for (int i = 0; i < 4; i++) // ledges of rising height (climb / jump tests)
                Prim(PrimitiveType.Cube, $"Ledge_{i + 1}m", new Vector3(-22 + i * 3.2f, (i + 1) * 0.5f, 14), new Vector3(3, i + 1, 3), stone, world);
            Prim(PrimitiveType.Cube, "Ramp", new Vector3(8, 1.1f, 4), new Vector3(4, 0.4f, 10), stone, world, Quaternion.Euler(-14, 0, 0));
            Prim(PrimitiveType.Cube, "Platform", new Vector3(8, 2.2f, 11), new Vector3(6, 0.4f, 6), stone, world);
            // Brindlewick's buildings, gatehouse and palisade (Ring0SceneBuilder.Town.cs).
            BuildTown(world);
            for (int i = 0; i < 6; i++) // stair steps
                Prim(PrimitiveType.Cube, $"Step_{i}", new Vector3(-14, 0.15f + i * 0.3f, -4 + i * 0.6f), new Vector3(3, 0.3f + i * 0.6f, 0.6f), stone, world);
            for (int i = 0; i < 8; i++) // pillars for camera-collision checks (not in the gateway or the guild hall)
                if (i != 2 && i != 6) Prim(PrimitiveType.Cylinder, $"Pillar_{i}", new Vector3(Mathf.Cos(i * 0.785f) * 18, 2, Mathf.Sin(i * 0.785f) * 18), new Vector3(1, 2, 1), accent, world);

            // Waystone beside the start: walking up to it attunes it as the respawn point.
            var ws = Building(world, "waystone", new Vector3(-3, 0, -3), 0f, "Waystone")
                ?? Prim(PrimitiveType.Cylinder, "Waystone", new Vector3(-3, 1.1f, -3), new Vector3(0.8f, 1.1f, 0.8f), Mat("Waystone", new Color(0.45f, 0.7f, 0.95f), 0.6f), world);
            ws.AddComponent<Waystone>();

            // Player: CharacterController root with a capsule body and a "nose" to show facing.
            var p = new GameObject("Player");
            var cc = p.AddComponent<CharacterController>();
            cc.height = 1.8f; cc.radius = 0.35f; cc.center = new Vector3(0, 0.9f, 0); cc.stepOffset = 0.35f; cc.slopeLimit = 50f;
            Prim(PrimitiveType.Capsule, "Body", new Vector3(0, 0.9f, 0), new Vector3(0.7f, 0.9f, 0.7f), player, p.transform, keepCollider: false);
            Prim(PrimitiveType.Cube, "Facing", new Vector3(0, 1.45f, 0.33f), new Vector3(0.18f, 0.12f, 0.2f), accent, p.transform, keepCollider: false);
            p.AddComponent<PlayerMotor>();
            p.AddComponent<PlayerCombat>();
            // Animated placeholder visual (Ring0SceneBuilder.PlayerRig.cs): Animator + Visual rig on the root; the legacy capsule stays but is hidden.
            AttachPlayerVisual(p, player, accent);
            foreach (var legacy in new[] { "Body", "Facing" })
            {
                var lt = p.transform.Find(legacy);
                if (lt != null && lt.TryGetComponent<Renderer>(out var lr)) lr.enabled = false;
            }
            p.AddComponent<CombatAnimationBridge>();
            p.AddComponent<FootIK>();
            p.AddComponent<PlayerAnimationDriver>();
            p.AddComponent<PlayerDefense>();
            p.AddComponent<LockOn>();
            p.AddComponent<PlayerInventory>();
            p.AddComponent<PlayerRespawn>();
            p.AddComponent<PlayerQuests>();
            p.AddComponent<PlayerRest>();
            p.AddComponent<PlayerTaming>();
            p.AddComponent<PlayerCrafting>();
            p.AddComponent<PlayerBestiary>();
            p.AddComponent<PlayerMap>();
            p.AddComponent<PlaytestShortcuts>();
            p.AddComponent<PlayerSave>();
            var driver = p.AddComponent<PlayerInputDriver>();

            // Camera.
            var cam = Camera.main;
            cam.name = "Main Camera";
            var tpc = cam.gameObject.AddComponent<ThirdPersonCamera>();
            cam.gameObject.AddComponent<RingZeroHud>();
            tpc.Target = p.transform;
            var so = new SerializedObject(driver);
            so.FindProperty("cameraTransform").objectReferenceValue = cam.transform;
            so.ApplyModifiedPropertiesWithoutUndo();

            // The town ward (TownWard): Brindlewick, Millbrook's fields and the treeline camp. The field's own monsters
            // stay out of it; raids, ambushes and defence events still come in.
            var ward = new GameObject("Brindlewick_Ward").AddComponent<Ascend.Game.TownWard>();
            ward.transform.SetParent(world, false);
            ward.transform.position = new Vector3(WardCentre.x, 0f, WardCentre.y);
            ward.Size = WardSize;

            // Ring 0 monsters: Blender models (Tools/blender/ring0_monsters.py) when present, else labelled primitives.
            // The fun-test field (combat.md §12), now out of town: a slime patch at Millbrook's old well just past the
            // treeline, the goblin pack of 5 deeper in on the west side, rabbits in the east meadow beyond the trees.
            var monsters = new GameObject("Ring0_Monsters").transform;
            var well = FieldCamps[0];
            if (Building(world, "well", new Vector3(well.x, 0, well.z), 30f, "Millbrook_Old_Well") == null)
                Prim(PrimitiveType.Cylinder, "Millbrook_Old_Well", new Vector3(well.x, 0.45f, well.z), new Vector3(1.6f, 0.45f, 1.6f), Mat("Stone", new Color(0.62f, 0.62f, 0.66f)), world);
            Label(world, new Vector3(well.x, 3.6f, well.z), "Millbrook's old well", new Color(1f, 0.92f, 0.7f), 0.03f);
            foreach (var at in CampSpots(FieldCamps[0]))
                if (!Model(monsters, "mon_blue_slime", "Blue_Slime", at))
                    Dummy(monsters, "mon_blue_slime", PrimitiveType.Sphere, at + Vector3.up * 0.25f, new Vector3(0.55f, 0.45f, 0.55f), slime);
            foreach (var at in CampSpots(FieldCamps[1]))
                if (!Model(monsters, "mon_goblin", "Goblin", at))
                    Dummy(monsters, "mon_goblin", PrimitiveType.Capsule, at + Vector3.up * 0.5f, new Vector3(0.45f, 0.5f, 0.45f), goblin);
            foreach (var at in CampSpots(FieldCamps[2]))
                if (!Model(monsters, "mon_horned_rabbit", "Horned_Rabbit", at))
                {
                    var rab = Dummy(monsters, "mon_horned_rabbit", PrimitiveType.Cube, at + Vector3.up * 0.2f, new Vector3(0.3f, 0.3f, 0.45f), rabbit);
                    Prim(PrimitiveType.Cylinder, "Horn", new Vector3(0, 0.75f, 0.45f), new Vector3(0.15f, 0.5f, 0.15f), accent, rab.transform, Quaternion.Euler(40, 0, 0), keepCollider: false);
                }

            // Past the Brindlewick gate: the edge of Whisperwood (Ring 1), its own waystone and field.
            BuildWhisperwood(world, ground, wood, accent);
            BuildQuestNpcs(world);

            EditorSceneManager.SaveScene(scene, ScenePath);
            var scenes = EditorBuildSettings.scenes.Where(s => s.path != ScenePath).ToList();
            scenes.Insert(0, new EditorBuildSettingsScene(ScenePath, true));
            EditorBuildSettings.scenes = scenes.ToArray();
        }

        /// <summary>Places a monster model (feet at <paramref name="pos"/>, facing the player start) with a fitted capsule. False if the FBX is missing.</summary>
        static bool Model(Transform parent, string speciesId, string modelName, Vector3 pos)
        {
            // Generated per-species models (Models/Monsters/<Family>/<species_id>.fbx) win over the Ring 0 blockouts.
            GameObject asset = null;
            if (AscendData.Db.Species.TryGetValue(speciesId, out var sp))
                asset = AssetDatabase.LoadAssetAtPath<GameObject>($"{ModelDir}/{sp.Family.Replace('/', '-')}/{speciesId}.fbx");
            if (asset == null) asset = AssetDatabase.LoadAssetAtPath<GameObject>($"{ModelDir}/{modelName}.fbx");
            if (asset == null) return false;
            var go = (GameObject)PrefabUtility.InstantiatePrefab(asset, parent);
            go.name = speciesId;
            go.transform.SetPositionAndRotation(pos, Quaternion.LookRotation(new Vector3(-pos.x, 0, -pos.z)));
            var bounds = new Bounds(go.transform.position, Vector3.zero);
            foreach (var r in go.GetComponentsInChildren<Renderer>()) bounds.Encapsulate(r.bounds);
            var col = go.AddComponent<CapsuleCollider>();
            col.height = bounds.size.y;
            col.radius = Mathf.Min(bounds.extents.x, bounds.extents.z);
            col.center = go.transform.InverseTransformPoint(bounds.center);
            AddLabel(go, speciesId, bounds.max.y);
            go.AddComponent<MonsterController>();
            go.AddComponent<MonsterAnimator>();
            return true;
        }

        static GameObject Dummy(Transform parent, string speciesId, PrimitiveType shape, Vector3 pos, Vector3 scale, Material mat)
        {
            var go = Prim(shape, speciesId, pos, scale, mat, parent);
            AddLabel(go, speciesId, pos.y + scale.y);
            go.AddComponent<MonsterController>();
            go.AddComponent<MonsterAnimator>();
            return go;
        }

        static void AddLabel(GameObject go, string speciesId, float topY)
        {
            var label = new GameObject("Label");
            label.transform.SetParent(go.transform.parent, false);
            label.transform.position = new Vector3(go.transform.position.x, topY + 0.35f, go.transform.position.z);
            var tm = label.AddComponent<TextMesh>();
            tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            label.GetComponent<MeshRenderer>().sharedMaterial = tm.font.material;
            tm.characterSize = 0.035f; tm.fontSize = 48; tm.anchor = TextAnchor.LowerCenter; tm.alignment = TextAlignment.Center;
            tm.color = Color.white;
            var dummy = go.AddComponent<MonsterDummy>();
            dummy.SpeciesId = speciesId;
            dummy.SetLabel(tm);
            dummy.Refresh();
        }

        // ---------- Preview ----------
        static void RenderPreview()
        {
            var cam = Camera.main;
            var tpc = cam.GetComponent<ThirdPersonCamera>();
            tpc.SetAngles(-14f, 14f, 6f);
            tpc.Place();
            foreach (var label in Object.FindObjectsByType<TextMesh>(FindObjectsSortMode.None))
                label.transform.rotation = Quaternion.LookRotation(label.transform.position - cam.transform.position);

            // The editor compiles shaders asynchronously and draws a cyan placeholder meanwhile; render synchronously.
            bool asyncWas = EditorSettings.asyncShaderCompilation;
            EditorSettings.asyncShaderCompilation = false;
            var rt = new RenderTexture(1280, 720, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB) { antiAliasing = 4 };
            cam.targetTexture = rt;
            cam.Render(); // first render compiles the variants
            cam.Render();
            EditorSettings.asyncShaderCompilation = asyncWas;
            RenderTexture.active = rt;
            var tex = new Texture2D(1280, 720, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            tex.Apply();
            cam.targetTexture = null;
            RenderTexture.active = null;
            Directory.CreateDirectory(Path.GetDirectoryName(ScreenshotPath));
            File.WriteAllBytes(ScreenshotPath, tex.EncodeToPNG());
            Object.DestroyImmediate(tex);
            rt.Release();
            Debug.Log("[Ascend] Preview saved: " + ScreenshotPath);
        }
    }
}
