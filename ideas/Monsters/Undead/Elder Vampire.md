---
type: monster
id: mon_elder_vampire
family: "Undead"
rank: "A+"
tier: variant
tags: [monster, undead]
---
# Elder Vampire

> The Elder Vampire is a large creature with an upright humanoid build, about 2.9 m tall. Its flesh and bone are rough, scarred and spiked, colored in arterial crimson and dried-blood brown. Look for aristocratic clothes and eyes like garnets. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by a faint red mist that smells of iron. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire\|Vampire]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 2.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28549 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.9 m high × 0.87 m long × 0.93 m wide; prefab scale 1.611.
- **Physics:** 348.8 kg, gravity ×1.5, poise 111, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 6.89 m/s, turn 235°/s, stopping distance 0.89 m.
- **Attack count:** 5; **signature:** aristocratic clothes and eyes like garnets.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Vampire is a **menacing undead** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** aristocratic clothes and eyes like garnets. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead A|loot_undead_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | A-, A+, S+, S | 132–203 | Night |
| [[Regions/Sunscar\|Sunscar]] | 4 | A, S, S+, A+ | 146–203 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | A-, S+, S | 132–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03826` | Nox Dominion Elder Vampire Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A- | 132 | 2.03 m | Night | Like a typical Elder Vampire, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_03827` | Sunscar Elder Vampire Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A | 146 | 2.46 m | Night | Like a typical Elder Vampire, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_03828` | Nox Dominion Elder Vampire | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | A+ | 159 | 2.9 m | Night | A typical adult Elder Vampire of this region, with red-black coloring with faint ember veins. |
| `pop_03829` | Sunscar Elder Vampire Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | S | 188 | 3.63 m | Night | Like a typical Elder Vampire, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_03830` | Sunscar Elder Vampire Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | S+ | 203 | 3.92 m | Night | Like a typical Elder Vampire, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_03831` | Sunscar Elder Vampire | [[Regions/Sunscar\|Sunscar]] | Adult | A+ | 159 | 2.9 m | Night | A typical adult Elder Vampire of this region, with sun-bleached, sand-scoured coloring. |
| `pop_03832` | Nox Dominion Elder Vampire Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S+ | 203 | 3.92 m | Night | Like a typical Elder Vampire, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_03833` | Nox Dominion Elder Vampire Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S | 188 | 3.63 m | Night | Like a typical Elder Vampire, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_03834` | Lumbaya Elder Vampire Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | A- | 132 | 2.03 m | Night | Like a typical Elder Vampire, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03835` | Lumbaya Elder Vampire Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | S+ | 203 | 3.92 m | Night | Like a typical Elder Vampire, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03836` | Lumbaya Elder Vampire Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | S | 188 | 3.63 m | Night | Like a typical Elder Vampire, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · triangle-based silhouette, sharp asymmetric spikes
