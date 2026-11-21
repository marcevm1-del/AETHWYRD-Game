using System.Collections;
using Ascend.Core;
using Ascend.Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Ascend.Game.Tests
{
    /// <summary>
    /// The six volume sliders had no effect on anything for as long as they have existed. These check that they do
    /// now: that the mixer asset ships, that its parameters are exposed (the first attempt at building it produced a
    /// mixer with none, which looked fine until something tried to set one), that a bus actually changes when the
    /// player moves a slider, and that combat sound goes through a bus instead of round it.
    /// </summary>
    public sealed class AudioBusesPlayModeTests
    {
        [TearDown]
        public void TearDown() => AudioBuses.Reset();

        [Test]
        public void Init_ResolvesEveryGroup()
        {
            Assert.IsTrue(AudioBuses.Init(), "mixer did not initialise: " + AudioBuses.Problem);
            Assert.AreEqual("", AudioBuses.Problem);
        }

        [Test]
        public void EveryBus_HasAnExposedVolumeParameter()
        {
            Assert.IsTrue(AudioBuses.Init(), AudioBuses.Problem);
            foreach (AudioBuses.Bus b in System.Enum.GetValues(typeof(AudioBuses.Bus)))
                Assert.IsTrue(AudioBuses.TryRead(b, out _),
                    "bus " + b + " has no exposed parameter on the mixer, so nothing can set its volume");
        }

        [Test]
        public void MusicSliderToZero_TakesTheMusicBusToTheFloor()
        {
            var v = new VolumeSettings { Master = 1.0, Music = 1.0, Effects = 1.0, Ambience = 1.0, Dialogue = 1.0, Callouts = 1.0 };
            Assert.IsTrue(AudioBuses.Apply(v), "Apply failed: " + AudioBuses.Problem);
            Assert.IsTrue(AudioBuses.TryRead(AudioBuses.Bus.Music, out var loud));

            v.Music = 0.0;
            Assert.IsTrue(AudioBuses.Apply(v));
            Assert.IsTrue(AudioBuses.TryRead(AudioBuses.Bus.Music, out var silent));

            Assert.Less(silent, loud, "turning the music slider down did not lower the music bus");
            Assert.LessOrEqual(silent, -79f, "a slider at zero should take the bus to the mixer's floor, not near it");
        }

        [Test]
        public void AmbienceSliderToZero_LeavesTheMusicBusAlone()
        {
            var v = new VolumeSettings { Master = 1.0, Music = 1.0, Effects = 1.0, Ambience = 1.0, Dialogue = 1.0, Callouts = 1.0 };
            AudioBuses.Apply(v);
            v.Ambience = 0.0;
            Assert.IsTrue(AudioBuses.Apply(v));
            Assert.IsTrue(AudioBuses.TryRead(AudioBuses.Bus.Ambience, out var amb));
            Assert.IsTrue(AudioBuses.TryRead(AudioBuses.Bus.Music, out var music));
            Assert.LessOrEqual(amb, -79f, "ambience should have gone to the floor");
            Assert.Greater(music, -1f, "music should not have moved when ambience did");
        }

        [UnityTest]
        public IEnumerator CombatHit_RoutesThroughTheEffectsBus()
        {
            AudioBuses.Init();
            var before = CombatFx.Played;
            CombatFx.Play(CombatFx.Sfx.HitLight, Vector3.zero, 1f);
            yield return null;
            Assert.Greater(CombatFx.Played, before, "the hit did not play");

            var host = GameObject.Find("AudioBuses");
            Assert.IsNotNull(host, "no pooled audio host: the sound did not go through AudioBuses");
            var sources = host.GetComponents<AudioSource>();
            Assert.Greater(sources.Length, 0, "the pool has no sources");

            var routed = 0;
            foreach (var s in sources)
                if (s.outputAudioMixerGroup != null && s.outputAudioMixerGroup.name == "Effects") routed++;
            Assert.Greater(routed, 0, "no pooled source was routed to the Effects group");
        }

        [UnityTest]
        public IEnumerator FortySounds_ReuseThePoolInsteadOfAllocating()
        {
            AudioBuses.Init();
            for (int i = 0; i < 40; i++)
            {
                CombatFx.Play(CombatFx.Sfx.Whoosh, Vector3.zero, 0.2f);
                yield return null;
            }
            var hosts = Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
            Assert.LessOrEqual(hosts.Length, 32,
                "40 sounds created " + hosts.Length + " AudioSources: the pool is not being reused");
        }

        [Test]
        public void ToDecibels_MapsZeroToTheFloorAndOneToUnity()
        {
            Assert.LessOrEqual(AudioBuses.ToDecibels(0.0), -79f);
            Assert.AreEqual(0f, AudioBuses.ToDecibels(1.0), 0.001f, "full volume should be 0 dB, not a boost");
        }
    }
}
