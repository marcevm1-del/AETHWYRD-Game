---
type: monster
id: mon_inquisitor
family: "Humanoid Enemies"
rank: "B"
tier: core
tags: [monster, humanoid-enemies]
---
# Inquisitor

![[mon_inquisitor_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_inquisitor_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,058 tris · 1.119 × 0.776 × 1.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Inquisitor is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in leather browns and dull steel, with gold markings. Guild sketches always show silver anti-magic chains and a sun-shaped mask. It has burning slit pupils. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13874 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 84.7 kg, gravity ×1.35, poise 82, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.32 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** silver anti-magic chains and a sun-shaped mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Inquisitor is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver anti-magic chains and a sun-shaped mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies B|loot_humanoid_enemy_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Cinder Inquisitor|Cinder Inquisitor]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 3 | B+, A, B- | 96–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | B+, B, A | 108–146 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | A, B+, B- | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02773` | Vharlen Inquisitor Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B+ | 120 | 2.09 m | Day & Night | Like a typical Inquisitor, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02774` | Vharlen Inquisitor Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A | 146 | 2.56 m | Day & Night | Like a typical Inquisitor, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02775` | Shen-Lu Inquisitor Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B+ | 120 | 1.9 m | Day & Night | Like a typical Inquisitor, but a rare pale form with white skin or fur and red eyes. |
| `pop_02776` | Hoshizora Inquisitor Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A | 146 | 2.56 m | Day & Night | Like a typical Inquisitor, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02777` | Vharlen Inquisitor Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B- | 96 | 1.61 m | Day & Night | Like a typical Inquisitor, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02778` | Hoshizora Inquisitor Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B+ | 120 | 2.09 m | Day & Night | Like a typical Inquisitor, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02779` | Shen-Lu Inquisitor Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B+ | 120 | 2.09 m | Day & Night | Like a typical Inquisitor, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02780` | Shen-Lu Inquisitor | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B | 108 | 1.9 m | Day & Night | A typical adult Inquisitor of this region, with slate-grey coloring and hardened hide. |
| `pop_02781` | Hoshizora Inquisitor Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B+ | 120 | 1.9 m | Day & Night | Like a typical Inquisitor, but a rare pale form with white skin or fur and red eyes. |
| `pop_02782` | Hoshizora Inquisitor Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B- | 96 | 1.61 m | Day & Night | Like a typical Inquisitor, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02783` | Shen-Lu Inquisitor Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A | 146 | 2.56 m | Day & Night | Like a typical Inquisitor, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `holy_motes` · palette `#8c6336` `#5b5f68` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
