---
type: monster
id: mon_briar_gargoyle
family: "Demons"
rank: "C+"
tier: variant
tags: [monster, demons]
---
# Briar Gargoyle

![[mon_briar_gargoyle_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_briar_gargoyle_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Briar Gargoyle is a person-sized creature with a lean, wing-armed drake frame, about 2 m long. Its hide is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe a stone body that cracks when it moves. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Gargoyle\|Gargoyle]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10057 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 1 m high × 2 m long × 3.05 m wide; prefab scale 0.333.
- **Physics:** 36.8 kg, gravity ×1, poise 27, knockback resistance 0.89, death style `crash_slide`.
- **Navigation:** speed 3.76 m/s, turn 424°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a stone body that cracks when it moves.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Briar Gargoyle is a **menacing demon** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone body that cracks when it moves. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons C|loot_demon_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 6 | B+, B, B-, C, C+ | 76–120 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C, B-, C+ | 76–96 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | C-, B- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04722` | Strife Marches Briar Gargoyle Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B+ | 120 | 2.7 m | Day & Night | Like a typical Briar Gargoyle, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04723` | Strife Marches Briar Gargoyle Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B | 108 | 2.5 m | Day & Night | Like a typical Briar Gargoyle, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04724` | Strife Marches Briar Gargoyle Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 2.2 m | Day & Night | Like a typical Briar Gargoyle, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04725` | Aldmere Briar Gargoyle Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 1.7 m | Day & Night | Like a typical Briar Gargoyle, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04726` | Lumbaya Briar Gargoyle Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C- | 65 | 1.4 m | Day & Night | Like a typical Briar Gargoyle, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04727` | Lumbaya Briar Gargoyle Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B- | 96 | 2 m | Day & Night | Like a typical Briar Gargoyle, but a rare pale form with white skin or fur and red eyes. |
| `pop_04728` | Strife Marches Briar Gargoyle Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 2 m | Day & Night | Like a typical Briar Gargoyle, but a rare pale form with white skin or fur and red eyes. |
| `pop_04729` | Aldmere Briar Gargoyle Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 2.2 m | Day & Night | Like a typical Briar Gargoyle, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04730` | Aldmere Briar Gargoyle | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 2 m | Day & Night | A typical adult Briar Gargoyle of this region, with dust-grey coloring and old rune scars. |
| `pop_04731` | Strife Marches Briar Gargoyle Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C | 76 | 1.7 m | Day & Night | Like a typical Briar Gargoyle, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04732` | Strife Marches Briar Gargoyle | [[Regions/Strife Marches\|Strife Marches]] | Adult | C+ | 86 | 2 m | Day & Night | A typical adult Briar Gargoyle of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `demon_hide_emissive` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
