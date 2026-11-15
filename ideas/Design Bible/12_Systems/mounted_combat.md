# 12c — Mounted Combat (ground mounts)

**Data:** `Data/Combat/mounted_combat.json` (schema `Data/Schemas/mounted_combat.schema.json`, rules in `Tools/validate/weapon_checks.js`). It **adds to** the limits already in `Data/Companions/mounts.json` `mountedCombat` and in [[Design Bible/12_Systems/companions_and_mounts|companions_and_mounts.md]]; it never repeats them. Weapon identity comes from [[Design Bible/12_Systems/weapon_movesets|weapon_movesets.md]]. All numbers are **proposals** for the user to tune.

**Hard rules (Canon):** ground mounts only (horse, wolf, bear, desert beast, large ground monster). No flying, celestial, dragon or aquatic mounts and no aerial mounted skills; flight stays an ability. No mounting in interior dungeons (so no mounted boss rooms). A mount is never killed: a downed mount is knocked out (`knockoutOnly`; only Mortal Bonds changes that). Nothing here creates a monster hierarchy (Canon 4d); monsters treat a mounted player exactly like any player.

## The shape of mounted fighting
Mounted combat is **a different rhythm, not a stronger one**: you trade your dodge and heavy skills for speed, a charge and a sturdier stagger limit. It is for crossing open ground and clearing small packs, not for beating bosses.

| Rule | Value (in the data) | Why |
|---|---|---|
| Base limits (from `mounts.json`) | damage x0.85, 3 chain hits, reach 2.5 m, banned tags big / aerial / channelled | Already built in Core (`MountedCombatRules`); unchanged |
| **Charge** | needs 6 m of run-up at 6 m/s or more; wind-up 0.25 s, active 0.4 s, recovery 0.5 s; power x1.2, heavy weight, knockback 2 m, each target once per charge; costs 25 mount stamina | The mounted payoff: a clear, committed move with a recovery |
| **Trample** | automatic on a charge: knocks aside targets up to medium_biped poise (50), power x0.6, once per 3 s, 5 stamina; **bosses are immune** | Clears slimes, goblins and rabbits; never trivialises elites |
| **Mounted dodge** | the mount sidesteps 3.2 m in 0.5 s with 0.18 s invulnerability (rider dodge is 0.24 s over 4.2 m), one in a row, 15 stamina | Clumsier than on foot, so you must still read telegraphs |
| **Perfect dodge / Flash Time** | works with the mounted dodge | The reward for reading the tell stays |
| **Guard and parry** | follow the weapon family; a parry riposte from the saddle is one chain hit | A mounted shield still protects |
| **Poise** | rider poise x the mount family multiplier: horse 1.2, wolf 1.1, bear 1.6, desert beast 1.4, large ground monster 2.0 | Heavier mounts are harder to unseat |
| **Dismount** | only when poise breaks (a stagger); not on a flinch. After it: 1.0 s invulnerable, 3 s before you can remount; calling the mount takes 2 s, mounting up 0.8 s | The existing "stagger dismounts" rule with a fair recovery |
| **Mount stamina** | combat moves share the mount's stamina block; area attacks (ground zones, shockwaves) drain 10% of the block. At zero the rider is set down gently (no damage, no stagger) and mounted bonuses stop until the mount recovers | Gives area attacks an answer without killing the mount |

## Weapon families while mounted
Every family from the moveset spec has a rule (the validator derives the list, so a new family cannot ship without one).

| Family | Mounted? | Chain hits | Reach cap | Note |
|---|---|---|---|---|
| Sword, Twin Blades, Katana, Sword and Shield, Daggers, Censer/Mace, Instruments | Yes | 2-3 | 2.0-2.5 m | Strikes only; banned skill tags apply (Shield Wall, Earth Stomp, Sanctuary, songs) |
| Greatsword | Yes | 1 | 2.8 m | One wide swing per pass |
| **Spear and Polearm** | Yes, the best | 3 | **3.4 m** | The mounted weapon: reach exception, charge x1.4 power |
| Whip and Rod | Yes | 3 | 3.0 m | Wide reach exception |
| Bow and Crossbow | Yes | 3 | ranged | Free aim with a wider reticle drift while moving |
| Staff, Wand, Grimoire | Yes | 3 | ranged | Bolts only; every channelled or big cast is banned |
| Fists and Gauntlets | **No** | 0 | 0 | Needs footing |
| Hammer and Tools | **No** | 0 | 0 | Needs footing; deployables banned |

## Telegraph and fairness rules
- Monster telegraph colours do not change (combat.md section 5). A red unblockable stays dodge-only: the mounted dodge answers it, at a stamina cost and with shorter invulnerability.
- Nothing mounted removes a threat's tell or a boss's armor and weak-point rules (combat.md 7c, 7d): a charge counts as a heavy hit for armor, trample ignores bosses, and no boss fight needs a mount.
- Mounting is announced (a short call sound and animation); the player is vulnerable while mounting up, so mounting mid-fight is a choice with a cost.

## Fun-test checklist (adds to combat.md section 12)
- [ ] A new rider can charge through a goblin pack and feels powerful, and a second charge straight away feels stamina-limited, not blocked.
- [ ] Mounted combat feels different from foot combat, not simply better; a player still chooses to dismount for a hard fight.
- [ ] A polearm rider feels like the mounted specialist; a fists user is told clearly why they cannot fight mounted.
- [ ] Being dismounted by a stagger feels like a lesson (you saw the hit coming), never a surprise, and the 1 s grace stops a chain of dismount hits.
- [ ] A bear or large-monster mount feels sturdier than a horse without making the player invincible.
- [ ] Area attacks that drain the mount are readable, and being set down gently at zero never hurts or kills the mount.

## Decisions (user can overrule)
- **Polearm and whip reach exceptions** (3.4 m and 3 m) and the greatsword's 2.8 m raise the 2.5 m base cap per family instead of changing the global cap: mounted lance play needs more reach than the base allows.
- **Mounted dodge is weaker than the rider's**, so mounted combat is a rhythm change, not a defensive upgrade.
- **Fists and workshop tools cannot fight mounted**, a clear identity rule rather than a hidden penalty.
- **Bosses are immune to trample** and no mounted boss encounter is proposed: interior dungeons already ban mounts.

## Hand-offs
- **core-rules-engineer:** read `mounted_combat.json` next to `MountedCombatRules` (charge, trample, mounted dodge, family poise, per-family chain and reach caps, mount stamina drain); keep the existing parity with `mounts.json`.
- **gameplay-engineer:** the charge move, mounted dodge, dismount grace and the free-aim reticle drift once the Core side exists.
- **animator-rigger:** saddle poses and a charge animation per mount family.
- **audio-designer:** the mount call and the charge-recovery sound cues.
Gap: **no Core or Unity code reads this file yet.**
