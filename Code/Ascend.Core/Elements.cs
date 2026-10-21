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

        static readonly Dictionary<(Element, Element), Reaction> Pairs = new Dictionary<(Element, Element), Reaction>();

        static Elements()
        {
            void Both(Element a, Element b, Reaction r) { Pairs[(a, b)] = r; Pairs[(b, a)] = r; }
            Both(Element.Fire, Element.Wind, Reaction.Firestorm);
            Both(Element.Water, Element.Lightning, Reaction.StormPrison);
            Both(Element.Water, Element.Ice, Reaction.Freeze);
            Both(Element.Fire, Element.Ice, Reaction.ThermalShock);
            Both(Element.Earth, Element.Fire, Reaction.Magma);
            Both(Element.Nature, Element.Fire, Reaction.Wildfire);
            Both(Element.Light, Element.Dark, Reaction.TwilightBurst);
            Both(Element.Poison, Element.Fire, Reaction.MiasmaBlast);
            Both(Element.Lightning, Element.Earth, Reaction.Grounded);
        }

        /// <summary>
        /// Reaction when <paramref name="trigger"/> hits a target carrying <paramref name="aura"/>.
        /// Specific pairs win; otherwise Wind meeting any other element is a Swirl.
        /// </summary>
        public static Reaction React(Element aura, Element trigger)
        {
            if (aura == Element.None || trigger == Element.None || aura == trigger) return Reaction.None;
            if (Pairs.TryGetValue((aura, trigger), out var r)) return r;
            if (aura == Element.Wind || trigger == Element.Wind) return Reaction.Swirl;
            return Reaction.None;
        }
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
        public Reaction Apply(Element element, double now)
        {
            if (element == Element.None) return Reaction.None;
            var aura = Current(now);
            var reaction = Elements.React(aura, element);
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
            else
            {
                Aura = Element.None;                  // reactions consume the aura
                ExpiresAt = now;
            }
            return reaction;
        }
    }
}
