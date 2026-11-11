using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The placeholder player body at runtime: the same "Visual" bone hierarchy and parts as the editor-built rig
    /// (PlayerAnimationAssets.BuildPlaceholderRig), so the title screen preview and the in-game player look alike, and
    /// <see cref="Apply"/> tints and shapes either one from a look. A real body prefab per Body (<see cref="PlayerBodyLibrary"/>)
    /// replaces <see cref="Build"/>; Apply works by part name and degrades quietly when a part is missing.
    /// </summary>
    public static class PlaceholderPlayerBody
    {
        public const float HipsY = 0.95f;
        public const string HairName = "Hair";
        public const string FaceName = "Face";

        /// <summary>Builds the rig under <paramref name="parent"/> (replacing an older "Visual") and returns the "Visual" object. A body prefab wins when the library has one.</summary>
        public static GameObject Build(Transform parent, Body body = Body.Masculine)
        {
            var old = parent.Find("Visual");
            if (old != null) { old.name = "Visual_old"; old.gameObject.SetActive(false); Object.Destroy(old.gameObject); }

            var prefab = PlayerBodyLibrary.Get(body);
            if (prefab != null)
            {
                var inst = Object.Instantiate(prefab, parent);
                inst.name = "Visual";
                inst.transform.localPosition = Vector3.zero; inst.transform.localRotation = Quaternion.identity;
                return inst;
            }

            var visual = new GameObject("Visual");
            visual.transform.SetParent(parent, false);
            var hips = Bone(visual.transform, "Hips", new Vector3(0f, HipsY, 0f));
            Part(hips, PrimitiveType.Cube, "Pelvis", Vector3.zero, new Vector3(0.34f, 0.2f, 0.22f));
            var spine = Bone(hips, "Spine", new Vector3(0f, 0.1f, 0f));
            Part(spine, PrimitiveType.Capsule, "Torso", new Vector3(0f, 0.3f, 0f), new Vector3(0.36f, 0.3f, 0.24f));
            var head = Bone(spine, "Head", new Vector3(0f, 0.72f, 0f));
            Part(head, PrimitiveType.Sphere, "Skull", Vector3.zero, new Vector3(0.26f, 0.28f, 0.26f));
            Part(head, PrimitiveType.Cube, "Nose", new Vector3(0f, -0.01f, 0.14f), new Vector3(0.08f, 0.06f, 0.1f));
            var armL = Bone(spine, "ArmL", new Vector3(-0.26f, 0.58f, 0f));
            Part(armL, PrimitiveType.Capsule, "ArmMeshL", new Vector3(0f, -0.27f, 0f), new Vector3(0.1f, 0.27f, 0.1f));
            var armR = Bone(spine, "ArmR", new Vector3(0.26f, 0.58f, 0f));
            Part(armR, PrimitiveType.Capsule, "ArmMeshR", new Vector3(0f, -0.27f, 0f), new Vector3(0.1f, 0.27f, 0.1f));
            var legL = Bone(hips, "LegL", new Vector3(-0.12f, -0.05f, 0f));
            Part(legL, PrimitiveType.Capsule, "LegMeshL", new Vector3(0f, -0.43f, 0f), new Vector3(0.15f, 0.43f, 0.15f));
            var footL = Bone(legL, "FootL", new Vector3(0f, -0.86f, 0f));
            Part(footL, PrimitiveType.Cube, "FootMeshL", new Vector3(0f, 0f, 0.06f), new Vector3(0.13f, 0.08f, 0.28f));
            var legR = Bone(hips, "LegR", new Vector3(0.12f, -0.05f, 0f));
            Part(legR, PrimitiveType.Capsule, "LegMeshR", new Vector3(0f, -0.43f, 0f), new Vector3(0.15f, 0.43f, 0.15f));
            var footR = Bone(legR, "FootR", new Vector3(0f, -0.86f, 0f));
            Part(footR, PrimitiveType.Cube, "FootMeshR", new Vector3(0f, 0f, 0.06f), new Vector3(0.13f, 0.08f, 0.28f));
            return visual;
        }

        static Transform Bone(Transform parent, string name, Vector3 localPos)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.transform.localPosition = localPos;
            return go.transform;
        }

        static GameObject Part(Transform bone, PrimitiveType type, string name, Vector3 localPos, Vector3 scale)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = name;
            var col = go.GetComponent<Collider>();
            if (col != null) Object.DestroyImmediate(col); // visuals only: the CharacterController is the player's body
            go.transform.SetParent(bone, false);
            go.transform.localPosition = localPos;
            go.transform.localScale = scale;
            return go;
        }

        // ------------------------------------------------------------------ appearance

        public static Color ToColour(AppearanceColour c, Color fallback) =>
            c != null && AppearanceRules.TryParseHex(c.Hex, out var r, out var g, out var b) ? new Color(r, g, b, 1f) : fallback;

        public static AppearanceColour Find(System.Collections.Generic.IEnumerable<AppearanceColour> list, string id)
        {
            AppearanceColour first = null;
            if (list == null) return null;
            foreach (var c in list) { first ??= c; if (c.Id == id) return c; }
            return first;
        }

        static Material NewMaterial(Color c)
        {
            var shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Universal Render Pipeline/Simple Lit") ?? Shader.Find("Standard") ?? Shader.Find("Sprites/Default");
            var m = new Material(shader);
            Tint(m, c);
            if (m.HasProperty("_Smoothness")) m.SetFloat("_Smoothness", 0.25f);
            return m;
        }

        static void Tint(Material m, Color c)
        {
            if (m.HasProperty("_BaseColor")) m.SetColor("_BaseColor", c);
            if (m.HasProperty("_Color")) m.SetColor("_Color", c);
        }

        /// <summary>
        /// Tints and shapes a body from a look. <paramref name="root"/> holds the "Visual" rig (the player root or the preview root).
        /// Skin: Skull, Nose, ArmMesh*. Outfit: Pelvis, Torso, LegMesh*, boots (FootMesh*) in a darker shade. Hair and a simple face are
        /// rebuilt under the Head bone. Each renderer gets its own material copy, so the shared scene materials are never changed.
        /// </summary>
        public static void Apply(Transform root, AppearanceChoice look, PlayerAppearanceFile data)
        {
            if (root == null || look == null) return;
            var visual = root.Find("Visual");
            if (visual == null) return;
            Color skin = ToColour(Find(data?.SkinTones, look.SkinTone), new Color(0.94f, 0.79f, 0.66f));
            Color outfit = ToColour(Find(data?.OutfitColours, look.OutfitColour), new Color(0.3f, 0.45f, 0.95f));
            Color hair = ToColour(Find(data?.HairColours, look.HairColour), new Color(0.42f, 0.26f, 0.15f));
            Color boots = new Color(outfit.r * 0.45f, outfit.g * 0.45f, outfit.b * 0.45f, 1f);

            foreach (var r in visual.GetComponentsInChildren<Renderer>(true))
            {
                string n = r.gameObject.name;
                if (n == "Skull" || n == "Nose" || n.StartsWith("ArmMesh")) SetColour(r, skin);
                else if (n.StartsWith("FootMesh")) SetColour(r, boots);
                else if (n == "Pelvis" || n == "Torso" || n.StartsWith("LegMesh")) SetColour(r, outfit);
            }

            // Proportions: widths only (the animator drives rotations and hip height, foot IK needs the height unchanged).
            var shape = AppearanceRules.BodyOf(data, look.Body);
            SetWidth(visual, "Hips/Pelvis", 0.34f, (float)shape.HipWidth);
            SetWidth(visual, "Hips/Spine/Torso", 0.36f, (float)shape.TorsoWidth);
            SetArm(visual, "Hips/Spine/ArmL", -0.26f, (float)shape.TorsoWidth);
            SetArm(visual, "Hips/Spine/ArmR", 0.26f, (float)shape.TorsoWidth);

            var head = visual.Find("Hips/Spine/Head");
            if (head != null) BuildHeadDetails(head, look, hair);
        }

        const string HairPath = "Hips/Spine/Head/" + HairName;

        static void SetColour(Renderer r, Color c)
        {
            var m = r.material; // an instance owned by this renderer
            if (m == null) return;
            Tint(m, c);
        }

        static void SetWidth(Transform visual, string path, float baseX, float mult)
        {
            var t = visual.Find(path);
            if (t == null) return;
            var s = t.localScale; s.x = baseX * mult; t.localScale = s;
        }

        static void SetArm(Transform visual, string path, float baseX, float mult)
        {
            var t = visual.Find(path);
            if (t == null) return;
            var p = t.localPosition; p.x = baseX * mult; t.localPosition = p;
        }

        static void BuildHeadDetails(Transform head, AppearanceChoice look, Color hairColour)
        {
            foreach (var name in new[] { HairName, FaceName })
            {
                var old = head.Find(name);
                if (old != null) { old.gameObject.SetActive(false); Object.Destroy(old.gameObject); old.name = name + "_old"; }
            }
            var face = new GameObject(FaceName).transform; face.SetParent(head, false);
            var ink = new Color(0.1f, 0.12f, 0.2f, 1f);
            foreach (float sx in new[] { -0.065f, 0.065f })
            {
                var eye = Part(face, PrimitiveType.Sphere, sx < 0 ? "Eye_L" : "Eye_R", new Vector3(sx, 0.02f, 0.115f), new Vector3(0.045f, 0.06f, 0.03f));
                eye.GetComponent<Renderer>().sharedMaterial = NewMaterial(ink);
            }

            var hair = new GameObject(HairName).transform; hair.SetParent(head, false);
            // Every style has the cap; the rest differs. Placeholder shapes until real hair meshes exist.
            Hair(hair, "Hair_Cap", PrimitiveType.Sphere, new Vector3(0f, 0.055f, -0.01f), new Vector3(0.29f, 0.22f, 0.29f), hairColour);
            switch (look.HairStyle)
            {
                case "long":
                    Hair(hair, "Hair_Back", PrimitiveType.Cube, new Vector3(0f, -0.2f, -0.12f), new Vector3(0.26f, 0.5f, 0.07f), hairColour);
                    Hair(hair, "Hair_SideL", PrimitiveType.Cube, new Vector3(-0.14f, -0.06f, -0.03f), new Vector3(0.04f, 0.3f, 0.2f), hairColour);
                    Hair(hair, "Hair_SideR", PrimitiveType.Cube, new Vector3(0.14f, -0.06f, -0.03f), new Vector3(0.04f, 0.3f, 0.2f), hairColour);
                    break;
                case "ponytail":
                    var tail = Hair(hair, "Hair_Tail", PrimitiveType.Capsule, new Vector3(0f, -0.1f, -0.19f), new Vector3(0.09f, 0.22f, 0.09f), hairColour);
                    tail.transform.localRotation = Quaternion.Euler(20f, 0f, 0f);
                    break;
                case "bun":
                    Hair(hair, "Hair_Bun", PrimitiveType.Sphere, new Vector3(0f, 0.2f, -0.04f), new Vector3(0.12f, 0.12f, 0.12f), hairColour);
                    break;
                default: // "short": the cap and a fringe
                    Hair(hair, "Hair_Fringe", PrimitiveType.Cube, new Vector3(0f, 0.07f, 0.115f), new Vector3(0.22f, 0.05f, 0.06f), hairColour);
                    break;
            }
        }

        static GameObject Hair(Transform parent, string name, PrimitiveType type, Vector3 pos, Vector3 scale, Color c)
        {
            var go = Part(parent, type, name, pos, scale);
            go.GetComponent<Renderer>().sharedMaterial = NewMaterial(c);
            return go;
        }
    }
}
