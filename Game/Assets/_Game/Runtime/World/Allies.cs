using System.Collections.Generic;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>Someone on your side that monsters can turn on: a tamed partner or a companion.</summary>
    public interface IAlly
    {
        Transform Transform { get; }
        bool Down { get; }
        /// <summary>The monster it's fighting (monsters fight back at whoever is fighting them).</summary>
        MonsterDummy Engaged { get; }
        /// <summary>Draws monsters from close by even when not fighting them (a Vanguard partner).</summary>
        bool Taunts { get; }
        void TakeAllyHit(int damage, Vector3 from);
    }

    public static class Allies
    {
        static readonly List<IAlly> _all = new List<IAlly>();
        public static IReadOnlyList<IAlly> All => _all;
        public static void Add(IAlly a) { if (!_all.Contains(a)) _all.Add(a); }
        public static void Remove(IAlly a) => _all.Remove(a);
    }
}
