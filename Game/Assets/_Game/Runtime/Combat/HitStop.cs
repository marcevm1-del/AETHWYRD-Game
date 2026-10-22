using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Hit-stop (combat.md §4.2): freezes game time for a few hundredths of a second when a hit lands, so every
    /// hit *lands*. Overlapping stops extend to the longest. Durations come from combat_tuning.json `hitstop`.
    /// </summary>
    public static class HitStop
    {
        static float _until = -1f, _restoreScale = 1f;
        static Runner _runner;

        public static bool Active => _until >= 0f;

        public static void Trigger(float seconds)
        {
            if (seconds <= 0f || !Application.isPlaying) return;
            if (!Active) _restoreScale = Time.timeScale;
            _until = Mathf.Max(_until, Time.unscaledTime + seconds);
            Time.timeScale = 0f;
            if (_runner == null)
            {
                var go = new GameObject("[HitStop]") { hideFlags = HideFlags.HideAndDontSave };
                Object.DontDestroyOnLoad(go);
                _runner = go.AddComponent<Runner>();
            }
        }

        /// <summary>Ends any stop immediately (scene unload, pause menu).</summary>
        public static void Clear()
        {
            if (!Active) return;
            Time.timeScale = _restoreScale;
            _until = -1f;
        }

        sealed class Runner : MonoBehaviour
        {
            void Update() { if (Active && Time.unscaledTime >= _until) Clear(); }
            void OnDestroy() => Clear();
        }
    }
}
