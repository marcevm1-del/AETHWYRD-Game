---
type: monster
id: mon_ancient_rogue_mage
family: "Humanoid Enemies"
rank: "B"
tier: variant
tags: [monster, humanoid-enemies]
---
# Ancient Rogue Mage

![[mon_ancient_rogue_mage_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_rogue_mage_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Rogue Mage is a large creature with a broad-shouldered humanoid build, about 2.7 m tall. Its clothing and gear are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is burnt academy robes and ink-stained fingers. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Rogue Mage\|Rogue Mage]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15642 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.7 m high × 0.81 m long × 0.86 m wide; prefab scale 1.5.
- **Physics:** 255.9 kg, gravity ×1.5, poise 98, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.98 m/s, turn 243°/s, stopping distance 0.86 m.
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

Ancient Rogue Mage is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** burnt academy robes and ink-stained fingers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Zarvan\|Zarvan]] | 3 | B-, A, C+ | 86–146 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 4 | B-, B+, B, A- | 96–132 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | B-, A-, A, B | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05604` | Zarvan Ancient Rogue Mage Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B- | 96 | 2.29 m | Day & Night | Like a typical Ancient Rogue Mage, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05605` | Vharlen Ancient Rogue Mage Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | B- | 96 | 2.29 m | Day & Night | Like a typical Ancient Rogue Mage, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05606` | Iron Hold Ancient Rogue Mage Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B- | 96 | 2.29 m | Day & Night | Like a typical Ancient Rogue Mage, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05607` | Zarvan Ancient Rogue Mage Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 3.65 m | Day & Night | Like a typical Ancient Rogue Mage, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05608` | Zarvan Ancient Rogue Mage Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 1.89 m | Day & Night | Like a typical Ancient Rogue Mage, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05609` | Vharlen Ancient Rogue Mage Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B+ | 120 | 2.97 m | Day & Night | Like a typical Ancient Rogue Mage, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05610` | Iron Hold Ancient Rogue Mage Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A- | 132 | 3.38 m | Day & Night | Like a typical Ancient Rogue Mage, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05611` | Vharlen Ancient Rogue Mage | [[Regions/Vharlen\|Vharlen]] | Adult | B | 108 | 2.7 m | Day & Night | A typical adult Ancient Rogue Mage of this region, with golden, grass-toned coloring. |
| `pop_05612` | Iron Hold Ancient Rogue Mage Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A | 146 | 3.65 m | Day & Night | Like a typical Ancient Rogue Mage, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05613` | Iron Hold Ancient Rogue Mage | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 2.7 m | Day & Night | A typical adult Ancient Rogue Mage of this region, with slate-grey coloring and hardened hide. |
| `pop_05614` | Vharlen Ancient Rogue Mage Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A- | 132 | 3.38 m | Day & Night | Like a typical Ancient Rogue Mage, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
