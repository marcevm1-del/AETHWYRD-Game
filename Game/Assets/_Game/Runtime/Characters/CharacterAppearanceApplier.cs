using System.Collections.Generic;
using System.Linq;
using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Shader indices of the colour slots: 1..N in Data/Characters/customization.json order, then skin. The same order
    /// Tools/blender/ascend_characters/slots.py writes into UV1, so the generator and the game agree without a lookup table.
    /// </summary>
    public static class CharacterSlots
    {
        public const int MaxSlots = 32;
        public static readonly int SlotColorsId = Shader.PropertyToID("_SlotColors");
        public static readonly int UseSlotsId = Shader.PropertyToID("_UseSlots");

        public static int Index(CustomizationFile f, string slot)
        {
            if (f == null || slot == null) return 0;
            if (slot == "skin") return f.ColourSlots.Count + 1;
            int i = f.ColourSlots.FindIndex(s => s.Id == slot);
            return i < 0 ? 0 : i + 1;
        }

        /// <summary>Fills the shader's slot array (linear colours when the project renders in linear space).</summary>
        public static void Fill(Vector4[] dest, CustomLook look, Color skin, CustomizationFile f)
        {
            for (int i = 0; i < dest.Length; i++) dest[i] = Vector4.one;
            if (f == null || look == null) return;
            bool linear = QualitySettings.activeColorSpace == ColorSpace.Linear;
            for (int i = 0; i < f.ColourSlots.Count && i + 1 < dest.Length; i++)
            {
                var c = look.Colours != null && look.Colours.TryGetValue(f.ColourSlots[i].Id, out var hex) ? ToColour(hex, Color.grey) : Color.grey;
                dest[i + 1] = linear ? (Vector4)c.linear : (Vector4)c;
            }
            int s = f.ColourSlots.Count + 1;
            if (s < dest.Length) dest[s] = linear ? (Vector4)skin.linear : (Vector4)skin;
        }

        public static Color ToColour(string hex, Color fallback) =>
            ColourMath.TryParseHex(hex, out var c) ? new Color((float)c.R, (float)c.G, (float)c.B, 1f) : fallback;
    }

    /// <summary>
    /// Puts a <see cref="CustomLook"/> on a generated character (the FBX from Tools/blender/ascend_characters, imported by
    /// CharacterImport with the Ascend/ToonCharacter shader). Part visibility by object name, colour per renderer through one
    /// shared MaterialPropertyBlock (no material is ever copied, so characters never share or leak colours), and the weapon and
    /// accessories on sockets made under the rig's bones. Anything the look asks for that has no model yet is listed in
    /// <see cref="Missing"/> instead of failing. Works on the placeholder body too: it simply finds no generated parts.
    /// </summary>
    public sealed class CharacterAppearanceApplier : MonoBehaviour
    {
        /// <summary>Where weapon and accessory prefabs are looked up: Resources/Characters/Weapons/&lt;id&gt; and .../Accessories/&lt;id&gt;.</summary>
        public const string WeaponPath = "Characters/Weapons/", AccessoryPath = "Characters/Accessories/";
        /// <summary>Generator part names (Tools/blender/ascend_characters/export.py GROUP).</summary>
        public static readonly string[] AlwaysShown = { "body", "eyes", "brows", "mouth", "ears" };
        public static readonly string[] OutfitParts = { "top", "bottom", "skirt", "belt", "boots", "bracers", "cloak" };

        static MaterialPropertyBlock _mpb;
        readonly Vector4[] _slots = new Vector4[CharacterSlots.MaxSlots];
        readonly Dictionary<string, Transform> _sockets = new Dictionary<string, Transform>();
        readonly List<GameObject> _attached = new List<GameObject>();
        GameObject _weapon;

        /// <summary>Ids the last look asked for that have no model or socket here (shown by the creator as "not modelled yet").</summary>
        public List<string> Missing { get; } = new List<string>();
        public CustomLook Applied { get; private set; }
        /// <summary>True when the weapon is in the hand socket, false when sheathed.</summary>
        public bool WeaponDrawn { get; private set; }

        public static CharacterAppearanceApplier Ensure(GameObject visual)
        {
            var a = visual.GetComponent<CharacterAppearanceApplier>();
            return a != null ? a : visual.AddComponent<CharacterAppearanceApplier>();
        }

        /// <summary>The generator part a renderer belongs to: its object name after the last underscore ("human_female_base_top" is "top").</summary>
        public static string PartOf(string objectName)
        {
            if (string.IsNullOrEmpty(objectName)) return null;
            int i = objectName.LastIndexOf('_');
            return i >= 0 && i < objectName.Length - 1 ? objectName.Substring(i + 1) : objectName;
        }

        public void Apply(CustomLook look, Color skin, CustomizationFile f)
        {
            if (look == null || f == null) return;
            Applied = look.Clone();
            Missing.Clear();
            var visible = CustomizationRules.VisibleParts(look, f);

            // 1. which generated parts show
            foreach (var r in GetComponentsInChildren<Renderer>(true))
            {
                string part = PartOf(r.gameObject.name);
                if (part == null || (!OutfitParts.Contains(part) && part != "hair" && !AlwaysShown.Contains(part))) continue;
                r.gameObject.SetActive(visible.Contains(part));
            }

            // 2. colours: every renderer gets the slot array (generated meshes read it through UV1; others ignore it)
            if (_mpb == null) _mpb = new MaterialPropertyBlock();
            CharacterSlots.Fill(_slots, look, skin, f);
            foreach (var r in GetComponentsInChildren<Renderer>(true))
            {
                if (r is ParticleSystemRenderer) continue;
                r.GetPropertyBlock(_mpb);
                _mpb.SetVectorArray(CharacterSlots.SlotColorsId, _slots);
                _mpb.SetFloat(CharacterSlots.UseSlotsId, 1f);
                r.SetPropertyBlock(_mpb);
            }

            // 3. hair style: a generated body carries one hair; a different style needs that style's mesh (not swappable yet)
            var hair = f.HairStyles.FirstOrDefault(h => h.Id == look.HairStyle);
            if (hair != null && !hair.Built) Missing.Add(hair.Id);

            // 4. weapon and accessories on sockets
            foreach (var go in _attached) if (go != null) Destroy(go);
            _attached.Clear();
            _weapon = null;
            foreach (var id in look.Accessories ?? new List<string>())
            {
                var a = f.Accessories.FirstOrDefault(x => x.Id == id);
                var go = a != null ? Attach(f, AccessoryPath + id, a.Socket) : null;
                if (go == null) Missing.Add(id);
            }
            if (!string.IsNullOrEmpty(look.Weapon))
            {
                var w = f.Weapons.FirstOrDefault(x => x.Id == look.Weapon);
                _weapon = w != null ? Attach(f, WeaponPath + w.Id, WeaponDrawn ? w.Held : w.Sheathed) : null;
                if (_weapon == null) Missing.Add(look.Weapon);
            }
            foreach (var go in _attached)
                foreach (var r in go.GetComponentsInChildren<Renderer>(true))
                {
                    r.GetPropertyBlock(_mpb);
                    _mpb.SetVectorArray(CharacterSlots.SlotColorsId, _slots);
                    _mpb.SetFloat(CharacterSlots.UseSlotsId, 1f);
                    r.SetPropertyBlock(_mpb);
                }
        }

        /// <summary>Moves the weapon between its sheath and hand sockets (combat calls this on draw and sheathe).</summary>
        public void SetWeaponDrawn(bool drawn, CustomizationFile f)
        {
            WeaponDrawn = drawn;
            if (_weapon == null || Applied == null || f == null) return;
            var w = f.Weapons.FirstOrDefault(x => x.Id == Applied.Weapon);
            var socket = w != null ? Socket(f, drawn ? w.Held : w.Sheathed) : null;
            if (socket == null) return;
            _weapon.transform.SetParent(socket, false);
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }

        GameObject Attach(CustomizationFile f, string resource, string socketId)
        {
            var prefab = Resources.Load<GameObject>(resource);
            var socket = Socket(f, socketId);
            if (prefab == null || socket == null) return null;
            var go = Instantiate(prefab, socket, false);
            go.name = prefab.name;
            _attached.Add(go);
            return go;
        }

        /// <summary>A socket transform under its bone, made on first use from customization.json "sockets".</summary>
        public Transform Socket(CustomizationFile f, string id)
        {
            if (id == null) return null;
            if (_sockets.TryGetValue(id, out var t) && t != null) return t;
            var def = f?.Sockets.FirstOrDefault(s => s.Id == id);
            if (def == null) return null;
            var bone = FindBone(def.Bone);
            if (bone == null) return null;
            var go = new GameObject("Socket_" + id);
            go.transform.SetParent(bone, false);
            go.transform.localPosition = V(def.Position);
            go.transform.localRotation = Quaternion.Euler(V(def.RotationEuler));
            _sockets[id] = go.transform;
            return go.transform;
        }

        Transform FindBone(string name)
        {
            var anim = GetComponentInParent<Animator>();
            if (anim != null && anim.isHuman && System.Enum.TryParse(name, out HumanBodyBones hb))
            {
                var b = anim.GetBoneTransform(hb);
                if (b != null) return b;
            }
            return GetComponentsInChildren<Transform>(true).FirstOrDefault(x => x.name == name);
        }

        static Vector3 V(List<double> v) => v != null && v.Count >= 3 ? new Vector3((float)v[0], (float)v[1], (float)v[2]) : Vector3.zero;
    }
}
