using System;
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
        ReactionState _reactions;
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
        /// <summary>Monster level for XP (the low end of its species level range).</summary>
        public int Level => _species != null && _species.LevelRange.Count > 0 ? _species.LevelRange[0] : Math.Max(1, _species?.Level ?? 1);
        public bool IsUnique => _species != null && (_species.IsUnique || _species.IsTyrant);
        /// <summary>Raised when poise breaks or a parry staggers this monster (its AI cancels the attack).</summary>
        public event Action Staggered;
        /// <summary>Raised on every landed hit (animation recoil).</summary>
        public event Action Damaged;
        /// <summary>Seconds the body stays visible after death (a death animation plays meanwhile).</summary>
        public float HideDelay { get; set; }
        float _hideLeft = -1f;

        void Awake()
        {
            RefreshRenderers();
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
            _reactions = new ReactionState(AscendData.Db.Tuning.Reactions);
            Refresh();
        }

        /// <summary>Bestiary tier per species for labels (hud_and_ui.md §9): 0 "???", 1 name and rank, 2+ HP too. Null shows everything.</summary>
        public static System.Func<string, int> AppraisalTier { get; set; }

        public void Refresh()
        {
            if (label == null) return;
            if (_species == null && !AscendData.Db.Species.TryGetValue(speciesId, out _species)) { label.text = $"? {speciesId}"; return; }
            var s = _species;
            string hp = Application.isPlaying ? (IsDead ? "Defeated" : $"HP {Hp}/{MaxHp}") : $"HP {s.Stats.Hp}";
            var aura = Application.isPlaying ? Aura : Element.None;
            int tier = Application.isPlaying && AppraisalTier != null && !IsPartner ? AppraisalTier(speciesId) : 3;
            string auraText = aura != Element.None ? $"\n[{aura}]" : "";
            if (tier <= 0) label.text = "???" + auraText;                                   // never seen
            else if (tier == 1) label.text = $"{s.Name}\nRank {s.Rank}" + auraText;         // name and rank; HP bars come at appraisal 2
            else label.text = $"{s.Name}\nRank {s.Rank} · Lv {s.LevelRange[0]}-{s.LevelRange[1]} · {hp}" + auraText;
        }

        public void SetLabel(TextMesh tm) => label = tm;
        /// <summary>False for raiders and other one-off monsters: once defeated they stay down.</summary>
        public bool Respawns { get; set; } = true;

        /// <summary>A tamed partner: on your side. Its colliders become triggers, so attacks (which ignore triggers) pass through it.</summary>
        public bool IsPartner { get; private set; }

        /// <summary>Restores HP (partners rest to full).</summary>
        public void Heal(int amount) { if (!IsDead) { Hp = Mathf.Min(MaxHp, Hp + Mathf.Max(0, amount)); Refresh(); } }

        /// <summary>Back on its feet at full health (a knocked-out partner after its rest).</summary>
        public void Revive()
        {
            Respawn();
            if (IsPartner) foreach (var c in GetComponentsInChildren<Collider>()) c.isTrigger = true;
        }

        /// <summary>A partner grows with you: max HP from the species' base times this factor (heals to full).</summary>
        public void ScaleMaxHp(double factor)
        {
            if (_species == null) return;
            MaxHp = Hp = Mathf.Max(1, (int)System.Math.Round(_species.EffectiveMaxHp * System.Math.Max(1, factor)));
            Refresh();
        }

        public void BecomePartner()
        {
            IsPartner = true;
            Respawns = false;
            foreach (var c in GetComponentsInChildren<Collider>()) c.isTrigger = true;
            if (label != null) label.color = new Color(1f, 0.7f, 0.85f);
        }

        /// <summary>The element aura on this monster now (combat.md §7), or None.</summary>
        public Element Aura => _reactions?.Aura.Current(Time.timeAsDouble) ?? Element.None;

        /// <summary>Applies an element; returns the reaction it triggers against the current aura.</summary>
        public Reaction ApplyElement(Element e)
        {
            if (_reactions == null || IsDead) return Reaction.None;
            var r = _reactions.ApplyElement(e, Time.timeAsDouble);
            Refresh();
            return r;
        }

        /// <summary>Freeze-shatter bonus and similar, for a hit of this weight landing now.</summary>
        public double ReactionHitMultiplier(HitWeight w) => _reactions?.HitMultiplier(w, Time.timeAsDouble) ?? 1.0;

        /// <summary>Applies a landed hit. Medium+ hits and poise breaks knock the monster back further.</summary>
        public void TakeHit(int amount, HitWeight weight, Vector3 fromPosition, double poiseDamage)
        {
            if (IsDead) return;
            Hp = Mathf.Max(0, Hp - Mathf.Max(0, amount));
            bool stagger = _poise.Hit(poiseDamage);
            Damaged?.Invoke();
            if (stagger) { Staggers++; Staggered?.Invoke(); }
            Vector3 away = transform.position - fromPosition; away.y = 0;
            away = away.sqrMagnitude > 1e-4f ? away.normalized : -transform.forward;
            _knockVelocity = away * (stagger ? 4f : weight >= HitWeight.Medium ? 2.5f : 1f);
            if (IsAirborne) _knockVelocity *= 0.15f; // juggled targets stay in reach
            _flashLeft = 0.08f;
            foreach (var r in _renderers) r.SetPropertyBlock(_flashBlock);
            if (IsDead) Defeat();
            Refresh();
        }

        /// <summary>A forced stagger (the player parried this monster): heavy knockback, poise refilled.</summary>
        public void Stagger(Vector3 fromPosition)
        {
            if (IsDead) return;
            Staggers++;
            Staggered?.Invoke();
            Vector3 away = transform.position - fromPosition; away.y = 0;
            _knockVelocity = (away.sqrMagnitude > 1e-4f ? away.normalized : -transform.forward) * 4f;
        }

        // ---------------------------------------------------------------- airborne (launch, juggle, slam)
        const float Gravity = -25f;
        float _groundY = float.NaN, _vy;
        bool _slammed;

        public bool IsAirborne => !float.IsNaN(_groundY) && (transform.position.y > _groundY + 0.02f || _vy > 0f);
        public float HeightAboveGround => float.IsNaN(_groundY) ? 0f : transform.position.y - _groundY;
        /// <summary>True once after a slam lands (for the launch-to-slam Style bonus).</summary>
        public bool LaunchedSinceLanding { get; private set; }
        /// <summary>Raised when an airborne monster lands (its AI treats it as a knockdown).</summary>
        public event Action Landed;

        /// <summary>Launcher: throw the monster straight up (it is then juggleable).</summary>
        public void Launch(float upSpeed)
        {
            if (IsDead) return;
            if (float.IsNaN(_groundY)) _groundY = transform.position.y;
            _vy = Mathf.Max(_vy, upSpeed);
            LaunchedSinceLanding = true;
            _knockVelocity = Vector3.zero;
        }

        /// <summary>An air hit keeps it up a little longer.</summary>
        public void Pop(float upSpeed) { if (IsAirborne) _vy = Mathf.Max(_vy, upSpeed); }

        /// <summary>Slam: drive an airborne monster into the ground.</summary>
        public void Slam(float downSpeed) { if (IsAirborne) { _vy = -Mathf.Abs(downSpeed); _slammed = true; } }

        void AirStep(float dt)
        {
            if (dt <= 0f || float.IsNaN(_groundY) || (!IsAirborne && _vy == 0f)) return; // frozen in hit-stop, or grounded
            _vy += Gravity * dt;
            var p = transform.position; p.y += _vy * dt;
            if (p.y <= _groundY && _vy <= 0f) // land only while falling (a launch starts at ground height)
            {
                p.y = _groundY; _vy = _slammed ? 3f : 0f; _slammed = false;
                transform.position = p;
                if (_vy == 0f) { LaunchedSinceLanding = false; Landed?.Invoke(); }
                return;
            }
            transform.position = p;
        }

        /// <summary>Re-reads the renderers (after MonsterAnimator moves them under its visual pivot).</summary>
        public void RefreshRenderers() => _renderers = GetComponentsInChildren<Renderer>();

        void Defeat()
        {
            _respawnLeft = Respawns ? respawnSec : -1f;
            foreach (var c in _colliders) c.enabled = false;
            if (HideDelay > 0f) _hideLeft = HideDelay;
            else foreach (var r in _renderers) r.enabled = false;
        }

        void Respawn()
        {
            _hideLeft = -1f;
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
            if (_hideLeft > 0f && (_hideLeft -= dt) <= 0f) foreach (var r in _renderers) r.enabled = false;
            AirStep(dt);
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
