using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The one owner of Time.timeScale during combat. Hit-stop (freeze on impact, combat.md §4.2) and Flash Time
    /// (slow-motion after a perfect dodge, §3) overlap safely: hit-stop wins while active, then Flash Time's scale
    /// resumes, then normal speed. Both run on real (unscaled) time. Durations come from combat_tuning.json.
    /// </summary>
    public static class GameTime
    {
        static float _stopUntil = -1f, _flashUntil = -1f, _flashScale = 1f;
        static Runner _runner;
        static float _pausedAt;

        /// <summary>The pause menu holds the game: timeScale stays 0 until it lets go, whatever combat effects ask for.</summary>
        public static bool Paused { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics() { Paused = false; _stopUntil = _flashUntil = -1f; }

        /// <summary>Pauses or resumes. Hit-stop and Flash Time keep the time they had left.</summary>
        public static void SetPaused(bool paused)
        {
            if (paused == Paused || !Application.isPlaying) return;
            if (paused) _pausedAt = Time.unscaledTime;
            else
            {
                float held = Time.unscaledTime - _pausedAt;
                if (_stopUntil >= 0f) _stopUntil += held;
                if (_flashUntil >= 0f) _flashUntil += held;
            }
            Paused = paused;
            Apply();
        }

        public static bool HitStopActive => Application.isPlaying && Time.unscaledTime < _stopUntil;
        public static bool FlashTimeActive => Application.isPlaying && Time.unscaledTime < _flashUntil;

        public static void HitStop(float seconds)
        {
            if (seconds <= 0f || !Application.isPlaying) return;
            _stopUntil = Mathf.Max(_stopUntil, Time.unscaledTime + seconds);
            Apply();
        }

        public static void FlashTime(float scale, float seconds)
        {
            if (seconds <= 0f || !Application.isPlaying) return;
            _flashScale = Mathf.Clamp(scale, 0.05f, 1f);
            _flashUntil = Mathf.Max(_flashUntil, Time.unscaledTime + seconds);
            Apply();
        }

        /// <summary>Ends every effect immediately (scene unload, pause menu, tests).</summary>
        public static void Clear()
        {
            _stopUntil = _flashUntil = -1f;
            Time.timeScale = Paused ? 0f : 1f;
        }

        static void Apply()
        {
            Time.timeScale = Paused ? 0f : HitStopActive ? 0f : FlashTimeActive ? _flashScale : 1f;
            if (_runner == null)
            {
                var go = new GameObject("[GameTime]") { hideFlags = HideFlags.HideAndDontSave };
                Object.DontDestroyOnLoad(go);
                _runner = go.AddComponent<Runner>();
            }
        }

        sealed class Runner : MonoBehaviour
        {
            void Update()
            {
                if (Paused) return; // effects wait for the resume
                if (_stopUntil >= 0f || _flashUntil >= 0f) Apply();
                if (!HitStopActive && !FlashTimeActive) _stopUntil = _flashUntil = -1f;
            }
            void OnDestroy() { Paused = false; Clear(); }
        }
    }

    /// <summary>Hit-stop facade (kept for existing callers and tests).</summary>
    public static class HitStop
    {
        public static bool Active => GameTime.HitStopActive;
        public static void Trigger(float seconds) => GameTime.HitStop(seconds);
        public static void Clear() => GameTime.Clear();
    }
}
