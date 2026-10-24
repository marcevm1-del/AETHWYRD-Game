---
type: monster
id: mon_gargoyle
family: "Demons"
rank: "C"
tier: core
tags: [monster, demons]
---
# Gargoyle

![[mon_gargoyle_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gargoyle_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gargoyle is a person-sized creature with a lean, wing-armed drake frame, about 2 m long. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Guild sketches always show a stone body that cracks when it moves. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8369 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Vharlen\|Vharlen]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 1 m high × 2 m long × 3.05 m wide; prefab scale 0.333.
- **Physics:** 47.8 kg, gravity ×1.1, poise 29, knockback resistance 1, death style `crash_slide`.
- **Navigation:** speed 3.46 m/s, turn 424°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a stone body that cracks when it moves.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gargoyle is a **menacing demon** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone body that cracks when it moves. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Vharlen|Vharlen]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons C|loot_demon_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Briar Gargoyle|Briar Gargoyle]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C-, D+, B- | 56–96 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | C+, B, C- | 65–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C+, B-, C, C- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01846` | Great Labyrinth (Floors 41-90) Gargoyle Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Gargoyle, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01847` | Vharlen Gargoyle Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 2.2 m | Day & Night | Like a typical Gargoyle, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_01848` | Great Labyrinth (Floors 1-40) Gargoyle Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Gargoyle, but a rare pale form with white skin or fur and red eyes. |
| `pop_01849` | Vharlen Gargoyle Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | B | 108 | 2.7 m | Day & Night | Like a typical Gargoyle, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_01850` | Great Labyrinth (Floors 1-40) Gargoyle Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 2.5 m | Day & Night | Like a typical Gargoyle, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01851` | Great Labyrinth (Floors 41-90) Gargoyle Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 1.4 m | Day & Night | Like a typical Gargoyle, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01852` | Vharlen Gargoyle Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Gargoyle, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01853` | Great Labyrinth (Floors 1-40) Gargoyle | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 2 m | Day & Night | A typical adult Gargoyle of this region, with dust-grey coloring and old rune scars. |
| `pop_01854` | Great Labyrinth (Floors 1-40) Gargoyle Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Gargoyle, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01855` | Great Labyrinth (Floors 1-40) Gargoyle Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C+ | 86 | 2.2 m | Day & Night | Like a typical Gargoyle, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01856` | Great Labyrinth (Floors 41-90) Gargoyle Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 2.5 m | Day & Night | Like a typical Gargoyle, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `demon_hide_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
