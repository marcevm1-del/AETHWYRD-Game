using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace Ascend.Game
{
    /// <summary>
    /// The missing half of a finished feature. `AccessibilityWindow` has drawn six volume sliders and saved them for
    /// some time, and nothing applied them to anything: `VolumeSettings` was read by the UI and by tests, and by no
    /// audio code at all (13_Production/research/audio_plan.md §3.3).
    ///
    /// This routes every sound through the mixer's six Canon buses and drives their volumes from
    /// `AccessibilitySettings.Volumes`. It also replaces `AudioSource.PlayClipAtPoint`, which cannot be routed to a
    /// mixer group at all — so every sound played that way bypassed every bus and every slider — and which allocates
    /// a GameObject per sound. Sources here are pooled.
    ///
    /// The mixer asset is built headlessly by `Ascend.EditorTools.CreateAudioMixer` so it can be reviewed and rebuilt
    /// rather than hand-made in the editor.
    /// </summary>
    public static class AudioBuses
    {
        public enum Bus { Effects, UI, Music, Ambience, Dialogue, Callouts }

        public const string MixerResource = "AethwyrdMixer";
        const int PoolSize = 24;                 // comfortably above the busiest combat moment measured so far
        const float MinDb = -80f;                // the mixer's own floor: below this a bus is silent

        static AudioMixer _mixer;
        static readonly Dictionary<Bus, AudioMixerGroup> Groups = new Dictionary<Bus, AudioMixerGroup>();
        static readonly List<AudioSource> Pool = new List<AudioSource>();
        static GameObject _host;
        static int _next;

        /// <summary>True once the mixer asset was found and its groups resolved. False means sound still plays, but
        /// unrouted — the caller should say so rather than claim the buses are working.</summary>
        public static bool Ready { get; private set; }

        /// <summary>Why the mixer is not ready, for reporting. Empty when it is.</summary>
        public static string Problem { get; private set; } = "not initialised";

        public static int PoolInUse { get; private set; }

        static string ParamFor(Bus b)
        {
            switch (b)
            {
                case Bus.Music: return "vol_music";
                case Bus.Ambience: return "vol_ambience";
                case Bus.Dialogue: return "vol_dialogue";
                case Bus.Callouts: return "vol_callouts";
                case Bus.UI: return "vol_ui";
                default: return "vol_effects";
            }
        }

        static string GroupFor(Bus b)
        {
            switch (b)
            {
                case Bus.Music: return "Music";
                case Bus.Ambience: return "Ambience";
                case Bus.Dialogue: return "Dialogue";
                case Bus.Callouts: return "Callouts";
                case Bus.UI: return "UI";
                default: return "Effects";
            }
        }

        public static bool Init()
        {
            if (Ready) return true;
            _mixer = Resources.Load<AudioMixer>(MixerResource);
            if (_mixer == null)
            {
                Problem = "no AudioMixer at Resources/" + MixerResource;
                return false;
            }
            Groups.Clear();
            foreach (Bus b in System.Enum.GetValues(typeof(Bus)))
            {
                var name = GroupFor(b);
                var found = _mixer.FindMatchingGroups(name);
                AudioMixerGroup g = null;
                foreach (var cand in found)
                    if (cand != null && cand.name == name) { g = cand; break; }
                if (g == null)
                {
                    Problem = "mixer has no group named " + name;
                    return false;
                }
                Groups[b] = g;
            }
            Problem = "";
            Ready = true;
            return true;
        }

        /// <summary>Linear 0..1 to the mixer's decibels. 0 goes to the floor, not to -infinity, which SetFloat rejects.</summary>
        public static float ToDecibels(double linear)
        {
            var v = Mathf.Clamp01((float)linear);
            return v <= 0.0001f ? MinDb : Mathf.Max(MinDb, Mathf.Log10(v) * 20f);
        }

        /// <summary>Pushes the player's saved volumes onto the buses. Call after loading settings and on every change.</summary>
        public static bool Apply(VolumeSettings v)
        {
            if (v == null || !Init()) return false;
            var master = _mixer.SetFloat("vol_master", ToDecibels(v.Master));
            _mixer.SetFloat("vol_music", ToDecibels(v.Music));
            _mixer.SetFloat("vol_effects", ToDecibels(v.Effects));
            _mixer.SetFloat("vol_ui", ToDecibels(v.Effects));        // UI rides the effects slider until it has its own
            _mixer.SetFloat("vol_ambience", ToDecibels(v.Ambience));
            _mixer.SetFloat("vol_dialogue", ToDecibels(v.Dialogue));
            _mixer.SetFloat("vol_callouts", ToDecibels(v.Callouts));
            if (!master) Problem = "SetFloat rejected vol_master: the parameter is not exposed on the mixer";
            return master;
        }

        /// <summary>Reads a bus volume back in decibels. Returns false when the parameter is not exposed.</summary>
        public static bool TryRead(Bus b, out float db) => Init()
            ? _mixer.GetFloat(ParamFor(b), out db)
            : (db = 0f) != 0f;

        static AudioSource Source()
        {
            if (_host == null)
            {
                _host = new GameObject("AudioBuses");
                Object.DontDestroyOnLoad(_host);
                _host.hideFlags = HideFlags.DontSave;
                Pool.Clear();
            }
            while (Pool.Count < PoolSize)
            {
                var src = _host.AddComponent<AudioSource>();
                src.playOnAwake = false;
                src.spatialBlend = 1f;          // positional, like PlayClipAtPoint was
                Pool.Add(src);
            }
            // round robin, preferring one that is not busy
            for (int i = 0; i < Pool.Count; i++)
            {
                var s = Pool[(_next + i) % Pool.Count];
                if (s != null && !s.isPlaying)
                {
                    _next = (_next + i + 1) % Pool.Count;
                    return s;
                }
            }
            var fallback = Pool[_next % Pool.Count];
            _next = (_next + 1) % Pool.Count;
            return fallback;           // everything busy: steal the oldest rather than drop the sound
        }

        /// <summary>Plays a clip at a point through a bus. The drop-in replacement for AudioSource.PlayClipAtPoint.</summary>
        public static void PlayAt(AudioClip clip, Vector3 at, float volume, Bus bus)
        {
            if (clip == null || !Application.isPlaying) return;
            var src = Source();
            if (src == null) return;
            src.transform.position = at;
            src.clip = clip;
            src.volume = Mathf.Clamp01(volume);
            if (Init() && Groups.TryGetValue(bus, out var g)) src.outputAudioMixerGroup = g;
            src.Play();
            PoolInUse = Pool.Count;
        }

        /// <summary>For tests: forget the pool and the mixer so the next call rebuilds them.</summary>
        public static void Reset()
        {
            if (_host != null) Object.DestroyImmediate(_host);
            _host = null;
            Pool.Clear();
            Groups.Clear();
            _mixer = null;
            Ready = false;
            Problem = "not initialised";
            _next = 0;
            PoolInUse = 0;
        }
    }
}
