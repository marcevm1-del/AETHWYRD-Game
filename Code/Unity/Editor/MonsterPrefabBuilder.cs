// Project Ascend — builds one prefab per species from a rig FBX and motion.json.
// Usage: select a rig model in the Project window (e.g. rig_small_biped.fbx), then
//        right-click > Ascend > Build Monster Prefabs From Rig.
// Every species in motion.json whose rigKey matches the file name gets a prefab in Assets/_Game/Prefabs/Monsters,
// scaled to its size, with NavMeshAgent, body collider, hurtboxes, breakable parts, spring bones and Menace components.
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Ascend.Monsters.Editor
{
    public static class MonsterPrefabBuilder
    {
        /// <summary>Copy inside the Unity project, used when the repo's Data folder is not next to it (same rule as AscendData).</summary>
        public const string MotionJsonPath = "Assets/_Game/Data/Monsters/motion.json";
        public const string OutputFolder = "Assets/_Game/Prefabs/Monsters";
        const string HurtboxLayerName = "Hurtbox";

        [MenuItem("Assets/Ascend/Build Monster Prefabs From Rig", true)]
        static bool Validate() => Selection.activeObject is GameObject go && AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(go)) is ModelImporter;

        [MenuItem("Assets/Ascend/Build Monster Prefabs From Rig")]
        static void BuildFromSelection()
        {
            var model = (GameObject)Selection.activeObject;
            string path = AssetDatabase.GetAssetPath(model);
            string rigKey = RigKeyFromPath(path);
            var file = LoadMotion();
            if (file == null) return;
            var matches = file.species.Where(s => s.rigKey == rigKey).ToArray();
            if (matches.Length == 0) { Debug.LogWarning($"[Ascend] No species in motion.json use rig '{rigKey}' (from {path})."); return; }
            EnsureFolder(OutputFolder);
            int n = 0;
            try
            {
                foreach (var p in matches)
                {
                    EditorUtility.DisplayProgressBar("Ascend", $"Building {p.speciesId}", (float)n / matches.Length);
                    BuildOne(model, p);
                    n++;
                }
            }
            finally { EditorUtility.ClearProgressBar(); }
            AssetDatabase.SaveAssets();
            Debug.Log($"[Ascend] Built {n} monster prefab(s) from {Path.GetFileName(path)} into {OutputFolder}.");
        }

        [MenuItem("Ascend/Monsters/Report Motion Data")]
        static void Report()
        {
            var file = LoadMotion();
            if (file == null) return;
            var groups = file.species.GroupBy(s => s.rigKey).OrderByDescending(g => g.Count());
            Debug.Log("[Ascend] motion.json: " + file.species.Length + " species\n" + string.Join("\n", groups.Select(g => $"  rig_{g.Key}.fbx → {g.Count()} species")));
        }

        static string RigKeyFromPath(string path)
        {
            string f = Path.GetFileNameWithoutExtension(path);
            int at = f.IndexOf('@'); // rig_small_biped@walk.fbx animation files
            if (at >= 0) f = f.Substring(0, at);
            return f.StartsWith("rig_") ? f.Substring(4) : f;
        }

        /// <summary>The repo's Data/Monsters/motion.json next to the Unity project (Game/../Data), else the copy in Assets.</summary>
        public static string MotionJsonFile()
        {
            string repo = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "Data", "Monsters", "motion.json"));
            return File.Exists(repo) ? repo : MotionJsonPath;
        }

        static MotionFile LoadMotion()
        {
            string src = MotionJsonFile();
            if (!File.Exists(src)) { Debug.LogError($"[Ascend] motion.json not found (looked for Data/Monsters/motion.json next to the Unity project and {MotionJsonPath}). Run `npm run motion` in the repo."); return null; }
            var file = JsonUtility.FromJson<MotionFile>(File.ReadAllText(src));
            if (file?.species == null) { Debug.LogError("[Ascend] motion.json could not be parsed."); return null; }
            return file;
        }

        static void BuildOne(GameObject model, MonsterProfile p)
        {
            var root = new GameObject(p.speciesId);
            try
            {
                var inst = (GameObject)PrefabUtility.InstantiatePrefab(model);
                inst.name = "Model";
                inst.transform.SetParent(root.transform, false);
                inst.transform.localScale = Vector3.one * Mathf.Max(0.01f, p.prefabScale);

                // --- navigation & body
                var agent = root.AddComponent<NavMeshAgent>();
                if (p.navAgent != null)
                {
                    agent.radius = p.navAgent.radius; agent.height = p.navAgent.height; agent.speed = p.navAgent.speed;
                    agent.angularSpeed = p.navAgent.angularSpeed; agent.acceleration = p.navAgent.acceleration;
                    agent.stoppingDistance = p.navAgent.stoppingDistance; agent.baseOffset = p.navAgent.baseOffset;
                }
                AddBodyCollider(root, p);
                var rb = root.AddComponent<Rigidbody>();
                rb.isKinematic = true;        // the NavMeshAgent moves it; switch to dynamic for knockback/launch
                rb.useGravity = false;
                rb.mass = Mathf.Max(0.1f, p.physics != null ? p.physics.massKg : 1f);
                rb.interpolation = RigidbodyInterpolation.Interpolate;

                // --- motion component
                var anim = inst.GetComponentInChildren<Animator>();
                if (!anim) anim = inst.AddComponent<Animator>();
                anim.applyRootMotion = false;
                var motion = root.AddComponent<MonsterMotion>();
                motion.animator = anim;
                motion.profileJson = JsonUtility.ToJson(p);

                // --- hurtboxes & parts
                int hurtLayer = LayerMask.NameToLayer(HurtboxLayerName);
                if (hurtLayer < 0) Debug.LogWarning($"[Ascend] Add a '{HurtboxLayerName}' layer (Project Settings > Tags and Layers); using Default for now.");
                foreach (var hb in p.hurtboxes ?? new HurtboxDef[0])
                {
                    var bone = FindDeep(inst.transform, hb.bone);
                    if (!bone) { Debug.LogWarning($"[Ascend] {p.speciesId}: bone '{hb.bone}' not found for hurtbox"); continue; }
                    var go = new GameObject("hurtbox_" + hb.bone);
                    go.transform.SetParent(bone, false);
                    if (hurtLayer >= 0) go.layer = hurtLayer;
                    float s = Mathf.Max(1e-4f, bone.lossyScale.x);
                    Collider col;
                    switch (hb.shape)
                    {
                        case "capsule":
                            var cc = go.AddComponent<CapsuleCollider>();
                            cc.direction = 1; // along the bone (FBX primary bone axis Y)
                            cc.radius = hb.radius / s;
                            cc.height = Mathf.Max(hb.height, hb.radius * 2f) / s;
                            col = cc; break;
                        case "box":
                            var bc = go.AddComponent<BoxCollider>();
                            if (hb.size != null && hb.size.Length == 3) bc.size = new Vector3(hb.size[0], hb.size[2], hb.size[1]) / s;
                            col = bc; break;
                        default:
                            var sc = go.AddComponent<SphereCollider>();
                            sc.radius = Mathf.Max(0.01f, hb.radius) / s;
                            if (hb.center != null && hb.center.Length == 3) go.transform.position = bone.position + root.transform.rotation * BlenderToUnity(hb.center);
                            col = sc; break;
                    }
                    col.isTrigger = true;
                    var h = go.AddComponent<Hurtbox>();
                    h.owner = motion; h.dmgMult = hb.dmgMult <= 0 ? 1f : hb.dmgMult; h.partId = hb.partId;
                    if (!string.IsNullOrEmpty(hb.partId))
                    {
                        var def = p.parts?.FirstOrDefault(x => x.partId == hb.partId);
                        if (def != null) h.part = AddPart(go, def);
                    }
                }
                foreach (var def in p.parts ?? new PartDef[0])
                {
                    if (root.GetComponentsInChildren<BreakablePart>().Any(x => x.partId == def.partId)) continue;
                    var bone = FindDeep(inst.transform, def.bone);
                    if (bone) AddPart(bone.gameObject, def);
                }

                // --- secondary motion
                foreach (var sp in p.springs ?? new SpringDef[0])
                {
                    var bone = FindDeep(inst.transform, sp.root);
                    if (!bone) continue;
                    var chain = root.AddComponent<SpringChain>();
                    chain.rootBone = bone; chain.length = Mathf.Max(1, sp.length);
                    chain.stiffness = sp.stiffness; chain.damping = sp.damping; chain.gravity = sp.gravity;
                    chain.followAnimation = sp.root.StartsWith("tail") || sp.root.StartsWith("trail");
                }
                if (p.rigKey == "blob" || (p.menace != null && p.menace.squashStretch > 1.01f))
                {
                    var ss = root.AddComponent<SquashStretch>();
                    ss.body = inst.GetComponentInChildren<SkinnedMeshRenderer>();
                    ss.scaleFallback = inst.transform;
                    ss.amount = p.menace != null ? Mathf.Max(0.3f, p.menace.squashStretch) : 1f;
                }

                // --- Menace components
                if (p.menace != null && p.menace.steppedAnimFps > 0)
                {
                    var st = root.AddComponent<SteppedAnimator>();
                    st.animator = anim; st.fps = p.menace.steppedAnimFps;
                    st.speed = p.locomotion != null ? p.locomotion.playRate : 1f;
                    st.smoothBurstChancePerSec = p.menace.level >= 5 ? 0.15f : 0f;
                    st.enabled = false; // the AI enables it when the monster is unobserved or hunting (see motion bible §5)
                }
                if (p.menace != null && p.menace.freezeWhenObserved) root.AddComponent<FreezeWhenObserved>();

                string outPath = $"{OutputFolder}/{p.speciesId}.prefab";
                PrefabUtility.SaveAsPrefabAsset(root, outPath);
            }
            finally { Object.DestroyImmediate(root); }
        }

        static BreakablePart AddPart(GameObject go, PartDef def)
        {
            var part = go.AddComponent<BreakablePart>();
            part.partId = def.partId; part.maxHp = Mathf.Max(1, def.hp); part.hp = part.maxHp;
            part.materialTag = def.materialTag; part.onBreak = def.onBreak;
            return part;
        }

        static void AddBodyCollider(GameObject root, MonsterProfile p)
        {
            var ph = p.physics;
            if (ph == null) return;
            if (ph.colliderType == "sphere")
            {
                var sc = root.AddComponent<SphereCollider>();
                sc.radius = ph.colliderRadius; sc.center = new Vector3(0, Mathf.Max(ph.colliderRadius, p.heightM * 0.45f), 0);
            }
            else
            {
                var cc = root.AddComponent<CapsuleCollider>();
                cc.radius = ph.colliderRadius;
                // colliderAxis "y" = along the body (Blender Y → Unity Z); otherwise upright
                bool lengthwise = ph.colliderAxis == "y";
                cc.direction = lengthwise ? 2 : 1;
                cc.height = Mathf.Max(ph.colliderHeight, ph.colliderRadius * 2f);
                cc.center = new Vector3(0, lengthwise ? Mathf.Max(ph.colliderRadius, p.heightM * 0.55f) : cc.height * 0.5f, 0);
            }
        }

        /// <summary>Blender (x, y, z; Z up, faces -Y) → Unity (x, y, z; Y up, faces +Z).</summary>
        static Vector3 BlenderToUnity(float[] v) => new Vector3(-v[0], v[2], -v[1]);

        static Transform FindDeep(Transform t, string name)
        {
            if (t.name == name) return t;
            for (int i = 0; i < t.childCount; i++) { var r = FindDeep(t.GetChild(i), name); if (r) return r; }
            return null;
        }

        static void EnsureFolder(string folder)
        {
            if (AssetDatabase.IsValidFolder(folder)) return;
            string parent = Path.GetDirectoryName(folder).Replace('\\', '/');
            EnsureFolder(parent);
            AssetDatabase.CreateFolder(parent, Path.GetFileName(folder));
        }
    }
}
