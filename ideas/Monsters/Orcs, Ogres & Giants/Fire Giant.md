---
type: monster
id: mon_fire_giant
family: "Orcs, Ogres & Giants"
rank: "A+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Fire Giant

![[mon_fire_giant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fire_giant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,238 tris · 7.73 × 4.544 × 9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Fire Giant is a huge creature with a giant, barrel-chested humanoid body, about 9 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with ember-orange markings. Look for skin like cooling lava and a forge-hammer. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 51829 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 9993 · 1815 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Zaruma\|Zaruma]], [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 9 m high × 2.7 m long × 3.78 m wide; prefab scale 2.571.
- **Physics:** 13122 kg, gravity ×1.3, poise 393, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 11.65 m/s, turn 127°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** skin like cooling lava and a forge-hammer.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fire Giant is a **menacing giant** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** skin like cooling lava and a forge-hammer. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Zaruma|Zaruma]], [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants A|loot_orc_giant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Cinder Giant|Cinder Giant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 1 | S- | 173–173 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 2 | A-, S- | 132–173 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | A, S-, A- | 132–173 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | S+, S- | 173–203 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 2 | A+, S+ | 159–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01160` | Nox Dominion Fire Giant Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S- | 173 | 9 m | Day & Night | Like a typical Fire Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01161` | Zarvan Fire Giant Runt | [[Regions/Zarvan\|Zarvan]] | Runt | A- | 132 | 6.3 m | Day & Night | Like a typical Fire Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01162` | Zaruma Fire Giant Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | A | 146 | 7.65 m | Day & Night | Like a typical Fire Giant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01163` | Iron Hold Fire Giant Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | S+ | 203 | 12.15 m | Day & Night | Like a typical Fire Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01164` | Zarvan Fire Giant Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | S- | 173 | 9.9 m | Day & Night | Like a typical Fire Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01165` | Iron Hold Fire Giant Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | S- | 173 | 9.9 m | Day & Night | Like a typical Fire Giant, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01166` | Zaruma Fire Giant Albino | [[Regions/Zaruma\|Zaruma]] | Albino | S- | 173 | 9 m | Day & Night | Like a typical Fire Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01167` | Dragon Spine Fire Giant | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | A+ | 159 | 9 m | Day & Night | A typical adult Fire Giant of this region, with slate-grey coloring and hardened hide. |
| `pop_01168` | Zaruma Fire Giant Runt | [[Regions/Zaruma\|Zaruma]] | Runt | A- | 132 | 6.3 m | Day & Night | Like a typical Fire Giant, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01169` | Dragon Spine Fire Giant Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | S+ | 203 | 12.15 m | Day & Night | Like a typical Fire Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01170` | Iron Hold Fire Giant Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | S- | 173 | 9 m | Day & Night | Like a typical Fire Giant, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#668948` `#455c31` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
