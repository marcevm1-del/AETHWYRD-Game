---
type: monster
id: mon_rogue_mage
family: "Humanoid Enemies"
rank: "C"
tier: core
tags: [monster, humanoid-enemies]
---
# Rogue Mage

![[mon_rogue_mage_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_rogue_mage_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,606 tris · 0.976 × 1.605 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Rogue Mage is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in leather browns and dull steel, with ember-orange markings. Guild sketches always show burnt academy robes and ink-stained fingers. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8073 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 73, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.7 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** burnt academy robes and ink-stained fingers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Rogue Mage is a **menacing humanoid** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** burnt academy robes and ink-stained fingers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Vharlen|Vharlen]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies C|loot_humanoid_enemy_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Ancient Rogue Mage|Ancient Rogue Mage]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | C-, B-, D+, C+ | 56–96 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 5 | C+, B-, C, B | 76–108 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | D+, C | 56–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02762` | Aldmere Rogue Mage Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 1.53 m | Day & Night | Like a typical Rogue Mage, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02763` | Aldmere Rogue Mage Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 2.25 m | Day & Night | Like a typical Rogue Mage, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02764` | Zarvan Rogue Mage Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C+ | 86 | 1.98 m | Day & Night | Like a typical Rogue Mage, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02765` | Vharlen Rogue Mage Runt | [[Regions/Vharlen\|Vharlen]] | Runt | D+ | 56 | 1.26 m | Day & Night | Like a typical Rogue Mage, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02766` | Vharlen Rogue Mage | [[Regions/Vharlen\|Vharlen]] | Adult | C | 76 | 1.8 m | Day & Night | A typical adult Rogue Mage of this region, with golden, grass-toned coloring. |
| `pop_02767` | Aldmere Rogue Mage Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.26 m | Day & Night | Like a typical Rogue Mage, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02768` | Zarvan Rogue Mage Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | B- | 96 | 2.25 m | Day & Night | Like a typical Rogue Mage, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02769` | Zarvan Rogue Mage | [[Regions/Zarvan\|Zarvan]] | Adult | C | 76 | 1.8 m | Day & Night | A typical adult Rogue Mage of this region, with slate-grey coloring and hardened hide. |
| `pop_02770` | Aldmere Rogue Mage Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 1.8 m | Day & Night | Like a typical Rogue Mage, but a rare pale form with white skin or fur and red eyes. |
| `pop_02771` | Zarvan Rogue Mage Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 1.8 m | Day & Night | Like a typical Rogue Mage, but a rare pale form with white skin or fur and red eyes. |
| `pop_02772` | Zarvan Rogue Mage Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | B | 108 | 2.43 m | Day & Night | Like a typical Rogue Mage, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `embers_heat_haze` · palette `#864c34` `#575e63` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
