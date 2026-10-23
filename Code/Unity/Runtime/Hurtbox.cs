// Project Ascend — hurtboxes (where a monster can be hit) and breakable parts (horns, tails, wings...).
using UnityEngine;
using UnityEngine.Events;

namespace Ascend.Monsters
{
    /// <summary>Trigger collider on a bone. Damage systems read dmgMult and partId.</summary>
    public class Hurtbox : MonoBehaviour
    {
        public MonsterMotion owner;
        public float dmgMult = 1f;
        public string partId;
        public BreakablePart part;
    }

    [System.Serializable] public class PartBrokenEvent : UnityEvent<BreakablePart> { }

    /// <summary>A part with its own HP. Breaking it drops its material and changes the moveset (onBreak tag).</summary>
    public class BreakablePart : MonoBehaviour
    {
        public string partId;
        public int maxHp = 100;
        public int hp = 100;
        public string materialTag;
        [Tooltip("Design tag from rigs.json, e.g. grounded_cannot_fly, disarm, no_tail_sweep.")]
        public string onBreak;
        public GameObject[] hideOnBreak;
        public GameObject spawnOnBreak;
        public PartBrokenEvent broken = new PartBrokenEvent();

        public bool IsBroken => hp <= 0;

        /// <summary>Applies part damage. Returns true on the hit that breaks it.</summary>
        public bool ApplyDamage(int amount)
        {
            if (IsBroken || amount <= 0) return false;
            hp = Mathf.Max(0, hp - amount);
            if (hp > 0) return false;
            foreach (var go in hideOnBreak) if (go) go.SetActive(false);
            if (spawnOnBreak) Instantiate(spawnOnBreak, transform.position, transform.rotation);
            broken.Invoke(this);
            return true;
        }
    }
}
