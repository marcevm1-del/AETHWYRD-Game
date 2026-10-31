---
type: monster
id: mon_cinder_inquisitor
family: "Humanoid Enemies"
rank: "B+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Cinder Inquisitor

![[mon_cinder_inquisitor_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cinder_inquisitor_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,094 tris · 1.03 × 0.714 × 1.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cinder Inquisitor is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in leather browns and dull steel, with ember-orange markings. Survivors describe silver anti-magic chains and a sun-shaped mask. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Inquisitor\|Inquisitor]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16235 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 89.2 kg, gravity ×1.5, poise 82, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.85 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** silver anti-magic chains and a sun-shaped mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinder Inquisitor is a **menacing humanoid** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver anti-magic chains and a sun-shaped mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies B|loot_humanoid_enemy_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | A, B-, A+, B, A- | 96–159 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 6 | A, A-, B, B+, B-, A+ | 96–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05615` | Zarvan Cinder Inquisitor Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A | 146 | 2.38 m | Day & Night | Like a typical Cinder Inquisitor, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05616` | Zarvan Cinder Inquisitor Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B- | 96 | 1.33 m | Day & Night | Like a typical Cinder Inquisitor, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05617` | Vharlen Cinder Inquisitor Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A | 146 | 2.38 m | Day & Night | Like a typical Cinder Inquisitor, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05618` | Zarvan Cinder Inquisitor Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A+ | 159 | 2.56 m | Day & Night | Like a typical Cinder Inquisitor, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05619` | Vharlen Cinder Inquisitor Albino | [[Regions/Vharlen\|Vharlen]] | Albino | A- | 132 | 1.9 m | Day & Night | Like a typical Cinder Inquisitor, but a rare pale form with white skin or fur and red eyes. |
| `pop_05620` | Vharlen Cinder Inquisitor Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B | 108 | 1.61 m | Day & Night | Like a typical Cinder Inquisitor, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05621` | Zarvan Cinder Inquisitor Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B | 108 | 1.61 m | Day & Night | Like a typical Cinder Inquisitor, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05622` | Zarvan Cinder Inquisitor Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A- | 132 | 1.9 m | Day & Night | Like a typical Cinder Inquisitor, but a rare pale form with white skin or fur and red eyes. |
| `pop_05623` | Vharlen Cinder Inquisitor | [[Regions/Vharlen\|Vharlen]] | Adult | B+ | 120 | 1.9 m | Day & Night | A typical adult Cinder Inquisitor of this region, with golden, grass-toned coloring. |
| `pop_05624` | Vharlen Cinder Inquisitor Runt | [[Regions/Vharlen\|Vharlen]] | Runt | B- | 96 | 1.33 m | Day & Night | Like a typical Cinder Inquisitor, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05625` | Vharlen Cinder Inquisitor Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A+ | 159 | 2.56 m | Day & Night | Like a typical Cinder Inquisitor, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `embers_heat_haze` · palette `#874834` `#585f64` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
