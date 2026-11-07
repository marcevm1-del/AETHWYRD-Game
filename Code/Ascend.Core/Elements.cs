using System;
using System.Collections.Generic;

namespace Ascend.Core
{
    public enum Element { None, Fire, Water, Ice, Lightning, Earth, Wind, Nature, Poison, Light, Dark, Blood, Void }

    /// <summary>Element reactions from 12_Systems/combat.md §7.</summary>
    public enum Reaction { None, Firestorm, StormPrison, Freeze, ThermalShock, Magma, Swirl, Wildfire, TwilightBurst, MiasmaBlast, Grounded }

    public static class Elements
    {
        /// <summary>Default weakness per element (matches the monster generator).</summary>
        public static Element WeaknessOf(Element e)
        {
            switch (e)
            {
                case Element.Fire: return Element.Water;
                case Element.Water: return Element.Lightning;
                case Element.Ice: return Element.Fire;
                case Element.Lightning: return Element.Earth;
                case Element.Earth: return Element.Wind;
                case Element.Wind: return Element.Fire;
                case Element.Nature: return Element.Fire;
                case Element.Poison: return Element.Light;
                case Element.Light: return Element.Dark;
                case Element.Dark: return Element.Light;
                case Element.Blood: return Element.Light;
                case Element.Void: return Element.Light;
                default: return Element.Fire;
            }
        }

        /// <summary>
        /// Reaction when <paramref name="trigger"/> hits a target carrying <paramref name="aura"/>.
        /// Specific pairs win; otherwise Wind meeting any other element is a Swirl.
        /// Uses <see cref="ReactionTable.Default"/>; pass a table to use loaded data.
        /// </summary>
        public static Reaction React(Element aura, Element trigger) => ReactionTable.Default.React(aura, trigger);

        public static Reaction React(Element aura, Element trigger, ReactionTable table) => (table ?? ReactionTable.Default).React(aura, trigger);
    }

    /// <summary>
    /// Tracks the element aura on one target (combat.md §7). Time is passed in, so this is engine-agnostic.
    /// </summary>
    public sealed class AuraState
    {
        readonly double _durationSec;
        public Element Aura { get; private set; } = Element.None;
        public double ExpiresAt { get; private set; }

        public AuraState(double auraDurationSec)
        {
            if (auraDurationSec <= 0) throw new ArgumentOutOfRangeException(nameof(auraDurationSec));
            _durationSec = auraDurationSec;
        }

        public Element Current(double now) => now < ExpiresAt ? Aura : Element.None;

        /// <summary>Applies an element hit and returns the triggered reaction, if any.</summary>
        public Reaction Apply(Element element, double now) => Apply(element, now, null);

        /// <summary>As <see cref="Apply(Element,double)"/>, using <paramref name="table"/> (null = the default table).</summary>
        public Reaction Apply(Element element, double now, ReactionTable table)
        {
            table = table ?? ReactionTable.Default;
            if (element == Element.None) return Reaction.None;
            var aura = Current(now);
            var reaction = table.React(aura, element);
            if (reaction == Reaction.None)
            {
                Aura = element;                       // new or refreshed aura
                ExpiresAt = now + _durationSec;
            }
            else if (reaction == Reaction.Swirl)
            {
                // Swirl spreads the *non-wind* element; the target keeps it.
                Aura = aura == Element.Wind ? element : aura;
                ExpiresAt = now + _durationSec;
            }
            else if (table.ConsumesAura(reaction))
            {
                Aura = Element.None;                  // reactions consume the aura
                ExpiresAt = now;
            }
            // else: the table says this reaction leaves the aura as it is
            return reaction;
        }
    }

    /// <summary>
    /// A target's elemental state including reaction side effects (combat.md §7):
    /// Freeze holds the target for freezeDurationSec and the next heavy hit Shatters it for shatterBonus;
    /// Storm Prison stuns for stormPrisonStunSec.
    /// </summary>
    public sealed class ReactionState
    {
        readonly ReactionTuning _t;
        readonly ReactionTable _table;
        Reaction _lastReaction = Reaction.None;
        double _lastReactionAt = double.NegativeInfinity;
        public AuraState Aura { get; }
        public double FrozenUntil { get; private set; } = double.NegativeInfinity;
        public double StunnedUntil { get; private set; } = double.NegativeInfinity;

        public ReactionState(ReactionTuning tuning) : this(tuning, null) { }

        /// <summary>A state driven by <paramref name="table"/> (null = <see cref="ReactionTable.Default"/>).</summary>
        public ReactionState(ReactionTuning tuning, ReactionTable table)
        {
            _t = tuning ?? throw new ArgumentNullException(nameof(tuning));
            _table = table ?? ReactionTable.Default;
            Aura = new AuraState(_t.AuraDurationSec);
        }

        public ReactionTable Table => _table;
        /// <summary>The last reaction this target suffered (for synergies), None before any.</summary>
        public Reaction LastReaction => _lastReaction;
        public double LastReactionAt => _lastReactionAt;

        public bool IsFrozen(double now) => now < FrozenUntil;
        public bool IsStunned(double now) => now < StunnedUntil;
        /// <summary>Frozen and stunned targets can't act.</summary>
        public bool CanAct(double now) => !IsFrozen(now) && !IsStunned(now);

        public Reaction ApplyElement(Element element, double now) => ApplyElementDetailed(element, now).Reaction;

        /// <summary>
        /// Applies an element hit and returns everything it caused: the reaction, its bonus multiplier, DoT, hazard,
        /// Swirl spread info and any synergy completed (a second reaction within the synergy window).
        /// </summary>
        public ReactionResult ApplyElementDetailed(Element element, double now)
        {
            var before = Aura.Current(now);
            var r = Aura.Apply(element, now, _table);
            if (r == Reaction.None) return ReactionResult.None;
            var res = _table.Describe(r, before, element, _t);
            if (res.StatusKind == "freeze") FrozenUntil = now + res.StatusDurationSec;
            else if (res.StatusKind == "stun") StunnedUntil = Math.Max(StunnedUntil, now + res.StatusDurationSec);
            var syn = _table.FindSynergy(_lastReaction, r, now - _lastReactionAt);
            if (syn != null) { res.Synergy = syn; res.SynergyMult = syn.BonusDamageMult > 0 ? syn.BonusDamageMult : 1.0; }
            _lastReaction = r;
            _lastReactionAt = now;
            return res;
        }

        /// <summary>
        /// Damage multiplier for a hit landing now. A heavy (or stronger) hit on a frozen target shatters it:
        /// bonus damage, and the freeze ends.
        /// </summary>
        public double HitMultiplier(HitWeight weight, double now)
        {
            if (!IsFrozen(now)) return 1.0;
            bool heavy = weight == HitWeight.Heavy || weight == HitWeight.Ultimate || weight == HitWeight.Launch;
            if (!heavy) return 1.0;
            FrozenUntil = now; // shattered
            return _t.ShatterBonus;
        }
    }
}
