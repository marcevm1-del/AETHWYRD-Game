using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// Graybox monster: stats from Data/Monsters/species.json, a floating label, and the receiving end of combat
    /// (HP, poise and stagger, hit flash, knockback, defeat and respawn). Real AI arrives in Ring 0 week 6.
    /// </summary>
    public sealed class MonsterDummy : MonoBehaviour
    {
        [SerializeField] string speciesId = "mon_goblin";
        [SerializeField] TextMesh label;
        [SerializeField] float respawnSec = 4f;

        SpeciesData _species;
        PoiseMeter _poise;
        Renderer[] _renderers;
        Collider[] _colliders;
        MaterialPropertyBlock _flashBlock;
        Vector3 _knockVelocity;
        Vector3 _labelOffset;
        float _flashLeft, _respawnLeft;

        public string SpeciesId { get => speciesId; set => speciesId = value; }
        public int MaxHp { get; private set; } = 1;
        public int Hp { get; private set; } = 1;
        public bool IsDead => Hp <= 0;
        public int Defense => _species?.Stats.Def ?? 0;
        public Element Weakness => _species?.ParsedWeakness ?? Element.None;
        public int Staggers { get; private set; }

        void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>();
            _colliders = GetComponentsInChildren<Collider>();
            _flashBlock = new MaterialPropertyBlock();
            _flashBlock.SetColor("_BaseColor", Color.white);
            _flashBlock.SetColor("_Color", Color.white);
            if (label != null) _labelOffset = label.transform.position - transform.position;
            Init();
        }

        void Init()
        {
            if (!AscendData.Db.Species.TryGetValue(speciesId, out _species)) _species = null;
            MaxHp = Hp = _species != null ? (int)_species.EffectiveMaxHp : 1;
            _poise = PoiseMeter.For(_species?.RigId ?? "medium_biped", AscendData.Db.Tuning);
            Refresh();
        }

        public void Refresh()
        {
            if (label == null) return;
            if (_species == null && !AscendData.Db.Species.TryGetValue(speciesId, out _species)) { label.text = $"? {speciesId}"; return; }
            var s = _species;
            string hp = Application.isPlaying ? (IsDead ? "Defeated" : $"HP {Hp}/{MaxHp}") : $"HP {s.Stats.Hp}";
            label.text = $"{s.Name}\nRank {s.Rank} · Lv {s.LevelRange[0]}-{s.LevelRange[1]} · {hp}";
        }

        public void SetLabel(TextMesh tm) => label = tm;

        /// <summary>Applies a landed hit. Medium+ hits and poise breaks knock the monster back further.</summary>
        public void TakeHit(int amount, HitWeight weight, Vector3 fromPosition, double poiseDamage)
        {
            if (IsDead) return;
            Hp = Mathf.Max(0, Hp - Mathf.Max(0, amount));
            bool stagger = _poise.Hit(poiseDamage);
            if (stagger) Staggers++;
            Vector3 away = transform.position - fromPosition; away.y = 0;
            away = away.sqrMagnitude > 1e-4f ? away.normalized : -transform.forward;
            _knockVelocity = away * (stagger ? 4f : weight >= HitWeight.Medium ? 2.5f : 1f);
            _flashLeft = 0.08f;
            foreach (var r in _renderers) r.SetPropertyBlock(_flashBlock);
            if (IsDead) Defeat();
            Refresh();
        }

        void Defeat()
        {
            _respawnLeft = respawnSec;
            foreach (var r in _renderers) r.enabled = false;
            foreach (var c in _colliders) c.enabled = false;
        }

        void Respawn()
        {
            foreach (var r in _renderers) { r.enabled = true; r.SetPropertyBlock(null); }
            foreach (var c in _colliders) c.enabled = true;
            Init();
        }

        void Start() => Refresh();

        void Update()
        {
            float dt = Time.deltaTime; // 0 during hit-stop: the flash and knockback hold on the frozen frame
            _poise?.Tick(dt);
            if (_flashLeft > 0f && (_flashLeft -= dt) <= 0f)
                foreach (var r in _renderers) r.SetPropertyBlock(null);
            if (_knockVelocity.sqrMagnitude > 1e-4f)
            {
                transform.position += _knockVelocity * dt;
                _knockVelocity = Vector3.MoveTowards(_knockVelocity, Vector3.zero, 14f * dt);
            }
            if (IsDead && _respawnLeft > 0f && (_respawnLeft -= dt) <= 0f) Respawn();
        }

        void LateUpdate()
        {
            if (label == null) return;
            label.transform.position = transform.position + _labelOffset;
            if (Camera.main != null)
                label.transform.rotation = Quaternion.LookRotation(label.transform.position - Camera.main.transform.position);
        }
    }
}
