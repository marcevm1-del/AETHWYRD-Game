using System.Linq;
using Ascend.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>Placeholder feedback (combat.md §11): synthesized sounds exist and are audible, effects respect the settings.</summary>
    public sealed class CombatFxPlayModeTests
    {
        [TearDown]
        public void TearDown()
        {
            FeedbackSettings.Sfx = FeedbackSettings.Vfx = FeedbackSettings.Rumble = true;
            foreach (var p in Object.FindObjectsByType<ParticleSystem>(FindObjectsSortMode.None)) Object.DestroyImmediate(p.gameObject);
        }

        [Test]
        public void EverySoundIsSynthesizedAndAudible()
        {
            foreach (CombatFx.Sfx s in System.Enum.GetValues(typeof(CombatFx.Sfx)))
            {
                var clip = CombatFx.Clip(s);
                Assert.IsNotNull(clip, $"{s} exists");
                Assert.Greater(clip.length, 0.05f, $"{s} has length");
                var data = new float[clip.samples];
                clip.GetData(data, 0);
                Assert.Greater(data.Max(Mathf.Abs), 0.05f, $"{s} is audible");
                Assert.LessOrEqual(data.Max(Mathf.Abs), 1f, $"{s} never clips");
            }
        }

        [Test]
        public void HitsPlaySoundAndSparksUnlessTurnedOff()
        {
            int sounds = CombatFx.Played, bursts = CombatFx.Bursts;
            CombatFx.Hit(Vector3.zero, HitWeight.Heavy);
            Assert.Greater(CombatFx.Played, sounds, "a hit plays sound (whoosh + impact)");
            Assert.Greater(CombatFx.Bursts, bursts, "a hit throws sparks");

            FeedbackSettings.Sfx = false; FeedbackSettings.Vfx = false;
            sounds = CombatFx.Played; bursts = CombatFx.Bursts;
            CombatFx.Hit(Vector3.zero, HitWeight.Heavy);
            Assert.AreEqual(sounds, CombatFx.Played, "sound off");
            Assert.AreEqual(bursts, CombatFx.Bursts, "particles off");
        }
    }
}
