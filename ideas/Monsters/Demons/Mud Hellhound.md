---
type: monster
id: mon_mud_hellhound
family: "Demons"
rank: "D+"
tier: variant
tags: [monster, demons]
---
# Mud Hellhound

![[mon_mud_hellhound_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mud_hellhound_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.39 × 1.5 × 0.944 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_mud_hellhound.fbx`

> The Mud Hellhound is a person-sized creature with a long-legged predatory quadruped build, about 1.5 m long. Its hide is rough, scarred and spiked, colored in char-black, with ochre markings. Guild sketches always show a dog with a furnace glow inside its ribs. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by pebbles that tremble and float near it. This Earth-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Hellhound\|Hellhound]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4825 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.98 m high × 1.5 m long × 0.24 m wide; prefab scale 0.375.
- **Physics:** 87.8 kg, gravity ×1.32, poise 56, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 4.79 m/s, turn 261°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a dog with a furnace glow inside its ribs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mud Hellhound is a **menacing demon** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog with a furnace glow inside its ribs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons D|loot_demon_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | C, C+, D, D+, C-, D- | 40–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C+, D+, C-, D | 48–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04700` | Iron Hold Mud Hellhound Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 1.88 m | Day & Night | Like a typical Mud Hellhound, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_04701` | Iron Hold Mud Hellhound Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 2.03 m | Day & Night | Like a typical Mud Hellhound, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_04702` | Great Labyrinth (Floors 1-40) Mud Hellhound Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 2.03 m | Day & Night | Like a typical Mud Hellhound, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04703` | Great Labyrinth (Floors 1-40) Mud Hellhound | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 1.5 m | Day & Night | A typical adult Mud Hellhound of this region, with dust-grey coloring and old rune scars. |
| `pop_04704` | Iron Hold Mud Hellhound Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 1.27 m | Day & Night | Like a typical Mud Hellhound, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04705` | Iron Hold Mud Hellhound | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.5 m | Day & Night | A typical adult Mud Hellhound of this region, with ash-dark coloring with glowing cracks. |
| `pop_04706` | Great Labyrinth (Floors 1-40) Mud Hellhound Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 1.65 m | Day & Night | Like a typical Mud Hellhound, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04707` | Great Labyrinth (Floors 1-40) Mud Hellhound Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 1.5 m | Day & Night | Like a typical Mud Hellhound, but a rare pale form with white skin or fur and red eyes. |
| `pop_04708` | Iron Hold Mud Hellhound Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 1.5 m | Day & Night | Like a typical Mud Hellhound, but a rare pale form with white skin or fur and red eyes. |
| `pop_04709` | Iron Hold Mud Hellhound Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 1.05 m | Day & Night | Like a typical Mud Hellhound, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04710` | Great Labyrinth (Floors 1-40) Mud Hellhound Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 1.27 m | Day & Night | Like a typical Mud Hellhound, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `demon_hide_emissive` · VFX `rock_debris` · palette `#4b4855` `#3e3a46` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
