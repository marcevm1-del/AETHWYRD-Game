using System.Collections.Generic;
using Ascend.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Placeholder combat feedback until real assets exist (combat.md §11 checklist items 3, 4 and 7): synthesized
    /// sound effects, impact particle bursts and controller rumble, all scaled by hit weight. Sounds are generated once
    /// at startup (no audio files), layered whoosh + impact as the spec asks, and play at the hit point.
    /// Settings: FeedbackSettings.Sfx / Vfx / Rumble.
    /// </summary>
    public static class CombatFx
    {
        public enum Sfx { Whoosh, HitLight, HitHeavy, Parry, PerfectDodge, Block, LevelUp, Firestorm, Telegraph, PlayerHurt }

        const int Rate = 44100;
        static readonly Dictionary<Sfx, AudioClip> Clips = new Dictionary<Sfx, AudioClip>();
        static float _rumbleUntil = -1f;
        static RumbleRunner _runner;

        public static int Played { get; private set; }
        public static int Bursts { get; private set; }

        public static AudioClip Clip(Sfx s)
        {
            if (!Clips.TryGetValue(s, out var c)) Clips[s] = c = Make(s);
            return c;
        }

        public static void Play(Sfx s, Vector3 at, float volume = 1f)
        {
            if (!FeedbackSettings.Sfx || !Application.isPlaying) return;
            AudioSource.PlayClipAtPoint(Clip(s), at, Mathf.Clamp01(volume * FeedbackSettings.SfxVolume));
            Played++;
        }

        /// <summary>Sound, sparks and rumble for a landed hit of this weight.</summary>
        public static void Hit(Vector3 at, HitWeight w)
        {
            bool heavy = w == HitWeight.Heavy || w == HitWeight.Ultimate || w == HitWeight.Launch;
            Play(Sfx.Whoosh, at, 0.35f);
            Play(heavy ? Sfx.HitHeavy : Sfx.HitLight, at, heavy ? 1f : 0.8f);
            Burst(at, heavy ? 18 : 8, heavy ? new Color(1f, 0.8f, 0.4f) : Color.white, heavy ? 4f : 2.5f);
            Rumble(w);
        }

        // ---------------------------------------------------------------- particles
        public static void Burst(Vector3 at, int count, Color color, float speed)
        {
            if (!FeedbackSettings.Vfx || !Application.isPlaying) return;
            var go = new GameObject("ImpactBurst");
            go.transform.position = at;
            var ps = go.AddComponent<ParticleSystem>();
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            var main = ps.main;
            main.duration = 0.3f; main.loop = false; main.startLifetime = 0.25f; main.startSpeed = speed;
            main.startSize = 0.08f; main.startColor = color; main.gravityModifier = 0.6f; main.maxParticles = 64;
            main.stopAction = ParticleSystemStopAction.Destroy;
            var emission = ps.emission; emission.rateOverTime = 0;
            var shape = ps.shape; shape.shapeType = ParticleSystemShapeType.Sphere; shape.radius = 0.05f;
            var r = go.GetComponent<ParticleSystemRenderer>();
            r.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit") ?? Shader.Find("Sprites/Default"));
            ps.Emit(count);
            Bursts++;
        }

        // ---------------------------------------------------------------- rumble
        public static void Rumble(HitWeight w)
        {
            if (!FeedbackSettings.Rumble || Gamepad.current == null || !Application.isPlaying) return;
            float low, high, sec;
            switch (w)
            {
                case HitWeight.Light: low = 0.05f; high = 0.15f; sec = 0.05f; break;
                case HitWeight.Medium: low = 0.2f; high = 0.3f; sec = 0.08f; break;
                case HitWeight.Ultimate: low = 0.8f; high = 0.8f; sec = 0.3f; break;
                default: low = 0.45f; high = 0.4f; sec = 0.12f; break;
            }
            Gamepad.current.SetMotorSpeeds(low, high);
            _rumbleUntil = Mathf.Max(_rumbleUntil, Time.unscaledTime + sec);
            if (_runner == null)
            {
                var go = new GameObject("[Rumble]") { hideFlags = HideFlags.HideAndDontSave };
                Object.DontDestroyOnLoad(go);
                _runner = go.AddComponent<RumbleRunner>();
            }
        }

        sealed class RumbleRunner : MonoBehaviour
        {
            void Update()
            {
                if (_rumbleUntil >= 0f && Time.unscaledTime >= _rumbleUntil) { Gamepad.current?.SetMotorSpeeds(0f, 0f); _rumbleUntil = -1f; }
            }
            void OnDisable() => Gamepad.current?.SetMotorSpeeds(0f, 0f);
        }

        // ---------------------------------------------------------------- synthesis
        static AudioClip Make(Sfx s)
        {
            switch (s)
            {
                case Sfx.Whoosh: return Synth(s, 0.16f, (t, n) => Noise(n) * Env(t, 0.16f, 0.06f) * 0.5f, lowpass: 0.25f);
                case Sfx.HitLight: return Synth(s, 0.12f, (t, n) => (Noise(n) * 0.6f + Sine(t, 180f - 600f * t) * 0.6f) * Env(t, 0.12f, 0.003f));
                case Sfx.HitHeavy: return Synth(s, 0.3f, (t, n) => (Noise(n) * 0.5f + Sine(t, 90f - 120f * t) * 0.9f) * Env(t, 0.3f, 0.004f), lowpass: 0.35f);
                case Sfx.Parry: return Synth(s, 0.45f, (t, n) => (Sine(t, 1320f) + Sine(t, 1980f) * 0.5f + Sine(t, 2640f) * 0.3f) * Env(t, 0.45f, 0.002f) * 0.5f);
                case Sfx.PerfectDodge: return Synth(s, 0.5f, (t, n) => Sine(t, 600f + 1400f * t) * Env(t, 0.5f, 0.02f) * 0.45f);
                case Sfx.Block: return Synth(s, 0.15f, (t, n) => (Noise(n) * 0.4f + Sine(t, 300f) * 0.6f) * Env(t, 0.15f, 0.002f));
                case Sfx.LevelUp: return Synth(s, 0.9f, (t, n) => (Sine(t, t < 0.2f ? 523f : t < 0.4f ? 659f : 784f) + Sine(t, 1046f) * 0.2f) * Env(t, 0.9f, 0.01f) * 0.45f);
                case Sfx.Firestorm: return Synth(s, 1.2f, (t, n) => Noise(n) * (0.4f + 0.3f * Mathf.Sin(t * 30f)) * Env(t, 1.2f, 0.08f), lowpass: 0.15f);
                case Sfx.Telegraph: return Synth(s, 0.18f, (t, n) => Sine(t, 880f) * Env(t, 0.18f, 0.005f) * 0.35f);
                default: return Synth(s, 0.2f, (t, n) => (Noise(n) * 0.3f + Sine(t, 140f) * 0.7f) * Env(t, 0.2f, 0.003f));
            }
        }

        static AudioClip Synth(Sfx name, float seconds, System.Func<float, int, float> f, float lowpass = 1f)
        {
            int n = Mathf.CeilToInt(seconds * Rate);
            var data = new float[n];
            float y = 0f;
            for (int i = 0; i < n; i++)
            {
                float x = Mathf.Clamp(f(i / (float)Rate, i), -1f, 1f);
                y += (x - y) * lowpass; // one-pole low-pass for softer noise
                data[i] = y;
            }
            var clip = AudioClip.Create("sfx_" + name, n, 1, Rate, false);
            clip.SetData(data, 0);
            return clip;
        }

        static float Sine(float t, float hz) => Mathf.Sin(2f * Mathf.PI * hz * t);
        static float Noise(int i) { uint x = (uint)i * 2654435761u; x ^= x >> 13; x *= 0x5bd1e995u; x ^= x >> 15; return (x & 0xFFFF) / 32767.5f - 1f; }
        /// <summary>Attack then exponential-ish decay to silence at the end.</summary>
        static float Env(float t, float len, float attack) => t < attack ? t / attack : Mathf.Pow(1f - Mathf.Clamp01((t - attack) / (len - attack)), 2f);
    }
}
