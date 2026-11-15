using System.Collections;
using System.IO;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// The character customization layer in Unity: the creator's "Customize look" row, colours per renderer through property
    /// blocks (never shared between characters), part visibility on a generated-style hierarchy, the face driver on blend
    /// shapes, the saved-looks book on disk, and the custom look through a save. Files live in a temporary folder; the player's
    /// real slot0.json is never touched. Written 2026-11-15 in a session without Unity: not yet run.
    /// </summary>
    public sealed class CharacterCustomizationPlayModeTests
    {
        string _folder, _folderWas;
        GameObject _a, _b;

        [SetUp]
        public void SetUp()
        {
            _folderWas = CharacterPresetStore.Folder;
            _folder = Path.Combine(Path.GetTempPath(), "ascend_qa_custom_" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_folder);
            CharacterPresetStore.Folder = _folder;
        }

        [TearDown]
        public void TearDown()
        {
            if (_a != null) Object.DestroyImmediate(_a);
            if (_b != null) Object.DestroyImmediate(_b);
            CharacterPresetStore.Folder = _folderWas;
            try { Directory.Delete(_folder, true); } catch (System.Exception) { }
        }

        /// <summary>A stand-in for a generated character: a Visual root with parts named the way the generator names them.</summary>
        static GameObject GeneratedLike(string name)
        {
            var root = new GameObject(name);
            var visual = new GameObject("Visual"); visual.transform.SetParent(root.transform, false);
            foreach (var part in new[] { "body", "hair", "top", "bottom", "skirt", "cloak" })
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = "human_female_base_" + part;
                go.transform.SetParent(visual.transform, false);
            }
            return root;
        }

        [Test]
        public void CustomizationData_Loads_WithBothFamiliesAndEightPalettes()
        {
            var f = AscendData.Customization;
            Assert.IsNotNull(f, "Data/Characters/customization.json loads");
            Assert.IsNotNull(f.Family("feminine")); Assert.IsNotNull(f.Family("masculine"));
            Assert.GreaterOrEqual(f.Palettes.Count, 8);
            Assert.IsNotNull(AscendData.FaceExpressions, "face_expressions.json loads");
        }

        [Test]
        public void Applier_ColoursEachCharacterOnItsOwnAndHidesUnwornParts()
        {
            var f = AscendData.Customization;
            _a = GeneratedLike("A"); _b = GeneratedLike("B");
            var lookA = CustomizationRules.Default(f, "feminine");
            var lookB = lookA.Clone();
            CustomizationRules.ApplyPalette(lookB, f.Palette("pal_ice"), f);
            lookB.Outfit.Remove("outer");

            var appA = CharacterAppearanceApplier.Ensure(_a.transform.Find("Visual").gameObject);
            var appB = CharacterAppearanceApplier.Ensure(_b.transform.Find("Visual").gameObject);
            appA.Apply(lookA, Color.white, f);
            appB.Apply(lookB, Color.white, f);

            var topA = _a.transform.Find("Visual/human_female_base_top").GetComponent<Renderer>();
            var topB = _b.transform.Find("Visual/human_female_base_top").GetComponent<Renderer>();
            Assert.AreSame(topA.sharedMaterial, topB.sharedMaterial, "both still share one material: nothing was copied");
            var pa = new MaterialPropertyBlock(); topA.GetPropertyBlock(pa);
            var pb = new MaterialPropertyBlock(); topB.GetPropertyBlock(pb);
            int primary = CharacterSlots.Index(f, "cloth_primary");
            var ca = pa.GetVectorArray(CharacterSlots.SlotColorsId)[primary];
            var cb = pb.GetVectorArray(CharacterSlots.SlotColorsId)[primary];
            Assert.AreNotEqual(ca, cb, "each character keeps its own primary colour");
            Assert.IsTrue(_a.transform.Find("Visual/human_female_base_cloak").gameObject.activeSelf, "A wears the cloak");
            Assert.IsFalse(_b.transform.Find("Visual/human_female_base_cloak").gameObject.activeSelf, "B took it off");
        }

        [Test]
        public void Applier_ListsAskedForItemsThatHaveNoModelYet()
        {
            var f = AscendData.Customization;
            _a = GeneratedLike("A");
            var look = CustomizationRules.Normalize(CustomizationRules.FromPreset(f.Look("look_violet_samurai_f"), f), f, allowPlanned: true);
            var app = CharacterAppearanceApplier.Ensure(_a.transform.Find("Visual").gameObject);
            app.Apply(look, Color.white, f);
            Assert.Contains("wpn_katana", app.Missing, "the katana is designed but not modelled");
            Assert.Contains(look.HairStyle, app.Missing, "so is the samurai ponytail");
        }

        [UnityTest]
        public IEnumerator FaceDriver_BlendsTheChosenExpressionOntoBlendShapes()
        {
            var faces = AscendData.FaceExpressions;
            var key = faces.Expressions["joy"].Keys.First();
            _a = new GameObject("Face");
            var mesh = new Mesh { vertices = new[] { Vector3.zero, Vector3.right, Vector3.up }, triangles = new[] { 0, 1, 2 } };
            mesh.AddBlendShapeFrame(key, 100f, new[] { Vector3.up * 0.01f, Vector3.zero, Vector3.zero }, null, null);
            var smr = _a.AddComponent<SkinnedMeshRenderer>(); smr.sharedMesh = mesh;
            var driver = FaceExpressionDriver.Ensure(_a);
            driver.Rebind();
            Assert.AreEqual(1, driver.Driven, "one blend shape found by name");
            driver.Show("expr_happy");   // the creator's "happy" is the rig's "joy"
            for (int i = 0; i < 30; i++) yield return null;
            Assert.Greater(smr.GetBlendShapeWeight(0), 1f, "the expression reached the mesh");
        }

        [Test]
        public void PresetStore_SavesAndLoadsTheBookBesideTheSave()
        {
            var f = AscendData.Customization;
            var book = new CharacterPresetBook();
            book.Put("Mine", CustomizationRules.Randomize(f, "masculine", new DeterministicRandom(5)));
            CharacterPresetStore.Save(book);
            Assert.IsTrue(File.Exists(Path.Combine(_folder, CharacterPresetStore.FileName)));
            var back = CharacterPresetStore.Load();
            Assert.AreEqual(1, back.Entries.Count);
            Assert.AreEqual("Mine", back.Entries[0].Name);
            Assert.AreEqual(book.Entries[0].Look.HairStyle, back.Entries[0].Look.HairStyle);
        }

        [Test]
        public void Creator_CustomizeRowOpensTheScreenAndQuickRowsWriteIntoTheLook()
        {
            var st = new CharacterCreatorState(AscendData.PlayerAppearance, new AppearanceChoice { Body = Body.Feminine });
            Assert.Contains(CharacterCreatorState.Field.Customize, CharacterCreatorState.Order);
            Assert.IsNotNull(st.Look.Custom, "a custom look exists from the start");
            st.Cycle(CharacterCreatorState.Field.HairColour, 1);
            var hex = AscendData.PlayerAppearance.HairColours.First(c => c.Id == st.Look.HairColour).Hex;
            Assert.AreEqual(ColourMath.Guard(hex, AscendData.Customization.StyleGuard), st.Look.Custom.Colours["hair_base"], "hair colour row writes hair_base");
            st.Cycle(CharacterCreatorState.Field.Body, 1);
            Assert.AreEqual(CustomizationRules.FamilyOf(st.Look.Body), st.Look.Custom.Family, "body row switches the family");
            Assert.AreEqual(st.Look.Custom.Family, st.Finish().Custom.Family, "the finished look carries it");
        }

        [Test]
        public void PlayerAppearance_SavesAndLoadsTheCustomLook()
        {
            _a = new GameObject("P1");
            var a = PlayerAppearance.Ensure(_a);
            var f = AscendData.Customization;
            var custom = CustomizationRules.Randomize(f, "feminine", new DeterministicRandom(9));
            a.Set(new AppearanceChoice { PlayerName = "Mika", Body = Body.Feminine, Custom = custom });
            var s = new SaveGame();
            a.Capture(s);
            Assert.IsNotNull(s.Customization);
            _b = new GameObject("P2");
            var b = PlayerAppearance.Ensure(_b);
            b.Load(s);
            Assert.AreEqual(custom.HairStyle, b.Current.Custom.HairStyle);
            Assert.AreEqual(custom.Colours["cloth_primary"], b.Current.Custom.Colours["cloth_primary"]);
        }
    }
}
