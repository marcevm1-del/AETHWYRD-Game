using System.IO;
using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// Phase 1B front end: menu entries, creator state and data-driven colours, the appearance round trip through a save, the body
    /// library fallback and the loading tips. Saves live in a temporary folder; the player's real slot0.json is never read or written.
    /// </summary>
    public sealed class FrontEndPlayModeTests
    {
        string _folder, _folderWas;
        GameObject _go;

        [SetUp]
        public void SetUp()
        {
            _folderWas = PlayerSave.Folder;
            _folder = Path.Combine(Path.GetTempPath(), "ascend_qa_frontend_" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_folder);
            PlayerSave.Folder = _folder;
            FrontEndSession.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            if (_go != null) Object.DestroyImmediate(_go);
            PlayerBodyLibrary.Set(Body.Masculine, null);
            PlayerBodyLibrary.Set(Body.Feminine, null);
            FrontEndSession.Clear();
            PlayerSave.Folder = _folderWas;
            try { Directory.Delete(_folder, true); } catch (System.Exception) { }
        }

        [Test]
        public void ContinueIsHiddenWithoutASaveAndShownWithOne()
        {
            Assert.IsFalse(FrontEndSession.HasSave, "an empty temp folder has no save");
            var none = FrontEndMenu.Entries(FrontEndSession.HasSave);
            CollectionAssert.AreEqual(new[] { FrontEndMenu.Entry.NewGame, FrontEndMenu.Entry.Settings, FrontEndMenu.Entry.Quit }, none);

            FrontEndSession.SeedDemoSave(_folder);
            Assert.IsTrue(File.Exists(Path.Combine(_folder, "slot0.json")), "the demo save went to the temp folder");
            Assert.IsTrue(FrontEndSession.HasSave);
            var with = FrontEndMenu.Entries(FrontEndSession.HasSave);
            Assert.AreEqual(FrontEndMenu.Entry.Continue, with[0]);
            StringAssert.Contains("Wren", FrontEndSession.SaveSummary());
        }

        [Test]
        public void AnUnreadableSaveDoesNotShowContinue()
        {
            File.WriteAllText(Path.Combine(_folder, "slot0.json"), "{ not json");
            Assert.IsFalse(FrontEndSession.HasSave);
        }

        [Test]
        public void TheControllerBuildsItsMenuFromTheSaveFolder()
        {
            _go = new GameObject("FrontEndTest");
            var c = _go.AddComponent<FrontEndController>();
            Assert.IsFalse(c.MenuEntries.Contains(FrontEndMenu.Entry.Continue));
            FrontEndSession.SeedDemoSave(_folder);
            c.RefreshMenu();
            Assert.IsTrue(c.MenuEntries.Contains(FrontEndMenu.Entry.Continue));
        }

        [Test]
        public void CreatorChoicesStayInsideTheDataAndColoursComeFromIt()
        {
            var data = AscendData.PlayerAppearance;
            Assert.IsNotNull(data, "Data/Characters/player_appearance.json loads");
            var st = new CharacterCreatorState(data);
            for (int i = 0; i < data.HairColours.Count * 2 + 1; i++) st.Cycle(CharacterCreatorState.Field.HairColour, 1);
            Assert.IsTrue(data.HairColours.Any(c => c.Id == st.Look.HairColour));
            st.Cycle(CharacterCreatorState.Field.Body, 1);
            Assert.AreEqual(Body.Feminine, st.Look.Body);
            st.Cycle(CharacterCreatorState.Field.Body, 1);
            Assert.AreEqual(Body.Masculine, st.Look.Body, "the body choice wraps");

            st.SetName(new string('z', 99));
            Assert.AreEqual(data.MaxNameLength, st.Look.PlayerName.Length, "names clamp to the data limit");
            st.SetName("   ");
            Assert.AreEqual(data.DefaultName, st.Finish().PlayerName, "a blank name falls back");

            var swatch = st.Swatch(CharacterCreatorState.Field.SkinTone);
            Assert.IsTrue(swatch.HasValue);
            var entry = data.SkinTones.First(c => c.Id == st.Look.SkinTone);
            Assert.IsTrue(ColorUtility.TryParseHtmlString(entry.Hex, out var expected));
            Assert.AreEqual(expected.r, swatch.Value.r, 0.01f);
            Assert.AreEqual(expected.g, swatch.Value.g, 0.01f);
            Assert.AreEqual(expected.b, swatch.Value.b, 0.01f);
        }

        [Test]
        public void AppearanceIsAppliedToThePlaceholderBodyAndRoundTripsThroughASave()
        {
            var data = AscendData.PlayerAppearance;
            _go = new GameObject("TestBody");
            PlaceholderPlayerBody.Build(_go.transform, Body.Feminine);
            var look = new AppearanceChoice { PlayerName = "Wren", Body = Body.Feminine, HairStyle = "bun", HairColour = "sky", SkinTone = "tan", OutfitColour = "plum" };
            PlaceholderPlayerBody.Apply(_go.transform, look, data);

            var torso = _go.transform.Find("Visual/Hips/Spine/Torso").GetComponent<Renderer>();
            var plum = data.OutfitColours.First(c => c.Id == "plum");
            ColorUtility.TryParseHtmlString(plum.Hex, out var want);
            var got = torso.sharedMaterial.HasProperty("_BaseColor") ? torso.sharedMaterial.GetColor("_BaseColor") : torso.sharedMaterial.color;
            Assert.AreEqual(want.r, got.r, 0.01f, "the outfit colour comes from the data");
            Assert.IsNotNull(_go.transform.Find("Visual/Hips/Spine/Head/Hair/Hair_Bun"), "the bun hair style was built");

            var s = new SaveGame();
            AppearanceRules.WriteTo(s, look);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(s, new Newtonsoft.Json.Converters.StringEnumConverter());
            var back = SaveRules.Upgrade(Newtonsoft.Json.JsonConvert.DeserializeObject<SaveGame>(json, new Newtonsoft.Json.Converters.StringEnumConverter()));
            var read = AppearanceRules.ReadFrom(back, data);
            Assert.AreEqual("Wren", read.PlayerName);
            Assert.AreEqual(Body.Feminine, read.Body);
            Assert.AreEqual("bun", read.HairStyle);
            Assert.AreEqual("sky", read.HairColour);
            Assert.AreEqual("tan", read.SkinTone);
            Assert.AreEqual("plum", read.OutfitColour);
        }

        [Test]
        public void PlayerAppearanceComponentCapturesAndLoadsALook()
        {
            _go = new GameObject("TestPlayer");
            var a = PlayerAppearance.Ensure(_go);
            a.Set(new AppearanceChoice { PlayerName = "Kit", Body = Body.Feminine, HairStyle = "long", HairColour = "ember", SkinTone = "deep", OutfitColour = "teal" });
            var s = new SaveGame();
            a.Capture(s);
            Assert.AreEqual("Kit", s.PlayerName);
            Assert.AreEqual(Body.Feminine, s.PlayerBody);
            var b = new GameObject("Other"); var a2 = PlayerAppearance.Ensure(b);
            a2.Load(s);
            Assert.AreEqual("ember", a2.Current.HairColour);
            Object.DestroyImmediate(b);
        }

        [Test]
        public void TheBodyLibraryFallsBackToThePlaceholderAndAcceptsAPrefab()
        {
            Assert.IsNull(PlayerBodyLibrary.Get(Body.Masculine), "no prefab yet: callers use the placeholder");
            var prefab = new GameObject("PrefabBody");
            PlayerBodyLibrary.Set(Body.Masculine, prefab);
            Assert.AreSame(prefab, PlayerBodyLibrary.Get(Body.Masculine));
            Assert.IsNull(PlayerBodyLibrary.Get(Body.Feminine));
            PlayerBodyLibrary.Set(Body.Masculine, null);
            Object.DestroyImmediate(prefab);
        }

        [Test]
        public void SettingsRoundTripBesideTheSavesAndMissingMeansDefaults()
        {
            Assert.IsNull(GameSettings.TryLoad(), "no settings.json yet");
            var s = new AccessibilitySettings { TextScale = 1.5, HighContrastPanels = true };
            GameSettings.Save(s);
            Assert.IsTrue(File.Exists(Path.Combine(_folder, "settings.json")));
            var back = GameSettings.TryLoad();
            Assert.AreEqual(1.5, back.TextScale, 0.001);
            Assert.IsTrue(back.HighContrastPanels);
            File.WriteAllText(Path.Combine(_folder, "settings.json"), "garbage");
            Assert.IsNull(GameSettings.TryLoad(), "an unreadable file falls back to defaults");
        }

        [Test]
        public void LoadingTipsLoadFromData()
        {
            var tips = AscendData.LoadingTips;
            Assert.IsNotNull(tips);
            Assert.GreaterOrEqual(tips.Tips.Count, 5);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tips.Pick(123).Text));
        }
    }
}
