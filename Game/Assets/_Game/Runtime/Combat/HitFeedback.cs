using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>Player-facing feedback options (accessibility). Defaults come from combat_tuning.json `feedback`.</summary>
    public static class FeedbackSettings
    {
        /// <summary>0 = no camera shake, 1 = full (combat.md §2: shake is capped and has an accessibility slider).</summary>
        public static float ShakeScale = 1f;
        public static bool? DamageNumbersOverride;
        public static bool DamageNumbers => DamageNumbersOverride ?? AscendData.Db.Tuning.Feedback.DamageNumbers;
        /// <summary>Sound effects, impact particles and controller rumble (each can be turned off).</summary>
        public static bool Sfx = true, Vfx = true, Rumble = true;
        public static float SfxVolume = 0.8f;
    }

    /// <summary>Camera shake by hit weight. Real-time decay, so it reads during hit-stop. ThirdPersonCamera adds Offset.</summary>
    public static class CameraShake
    {
        static float _amp, _startAmp, _startTime = -1f;

        public static Vector3 Offset
        {
            get
            {
                if (_startTime < 0f) return Vector3.zero;
                float decay = (float)AscendData.Db.Tuning.Feedback.ShakeDecaySec;
                float t = (Time.unscaledTime - _startTime) / Mathf.Max(0.01f, decay);
                if (t >= 1f) { _startTime = -1f; _amp = 0f; return Vector3.zero; }
                _amp = _startAmp * (1f - t);
                float s = Time.unscaledTime * 60f;
                return new Vector3(Mathf.PerlinNoise(s, 0.3f) - 0.5f, Mathf.PerlinNoise(0.7f, s) - 0.5f, 0f) * (2f * _amp);
            }
        }

        public static float Amplitude => _startTime < 0f ? 0f : _amp > 0f ? _amp : _startAmp;

        public static void Kick(HitWeight weight)
        {
            var t = AscendData.Db.Tuning;
            float amp = Mathf.Min((float)t.Feedback.ShakeFor(weight), (float)t.Camera.ShakeMax) * Mathf.Clamp01(FeedbackSettings.ShakeScale);
            if (amp <= 0f || amp < Amplitude) return;
            _startAmp = _amp = amp;
            _startTime = Time.unscaledTime;
        }

        public static void Reset() { _startTime = -1f; _amp = _startAmp = 0f; }
    }

    /// <summary>A floating damage number (toggleable). Uses scaled time, so it holds still during hit-stop.</summary>
    public sealed class DamageNumber : MonoBehaviour
    {
        TextMesh _text;
        float _age, _life, _rise;
        Vector3 _start;

        public static int Live { get; private set; }

        public static DamageNumber Spawn(Vector3 position, int amount, bool crit)
        {
            if (!FeedbackSettings.DamageNumbers) return null;
            var f = AscendData.Db.Tuning.Feedback;
            var go = new GameObject("DamageNumber");
            go.transform.position = position;
            var tm = go.AddComponent<TextMesh>();
            tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            go.GetComponent<MeshRenderer>().sharedMaterial = tm.font.material;
            tm.text = crit ? $"{amount}!" : amount.ToString();
            tm.fontSize = 64; tm.characterSize = crit ? 0.05f : 0.04f;
            tm.anchor = TextAnchor.MiddleCenter; tm.alignment = TextAlignment.Center;
            tm.color = crit ? new Color(1f, 0.82f, 0.25f) : Color.white;
            var d = go.AddComponent<DamageNumber>();
            d._text = tm; d._life = (float)f.DamageNumberSec; d._rise = (float)f.DamageNumberRiseM; d._start = position;
            return d;
        }

        void OnEnable() => Live++;
        void OnDisable() => Live--;

        void Update()
        {
            _age += Time.deltaTime;
            float t = _age / Mathf.Max(0.01f, _life);
            transform.position = _start + Vector3.up * (_rise * (1f - (1f - t) * (1f - t)));
            var c = _text.color; c.a = 1f - Mathf.Clamp01((t - 0.6f) / 0.4f); _text.color = c;
            if (Camera.main != null) transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            if (t >= 1f) Destroy(gameObject);
        }
    }
}
