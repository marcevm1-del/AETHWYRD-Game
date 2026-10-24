---
type: monster
id: mon_imp
family: "Demons"
rank: "E"
tier: core
tags: [monster, demons]
---
# Imp

![[mon_imp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_imp_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,780 tris · 1.306 × 0.5 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Imp is a small creature with a tiny, darting winged build, about 0.6 m tall. Its hide is weathered and natural, colored in ember reds fading to soot black. Guild sketches always show bat wings, a pointed tail and a cheeky grin. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 911 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/membrane_flyer\|membrane_flyer]] · `anim_flyer_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian\|Lirian]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/membrane_flyer|membrane_flyer]] (override); animation set `anim_flyer_small`.
- **Dimensions:** 0.26 m high × 0.6 m long × 1.2 m wide; prefab scale 1.2.
- **Physics:** 4.3 kg, gravity ×0.8, poise 19, knockback resistance 0.08, death style `flutter_fall`.
- **Navigation:** speed 0.59 m/s, turn 900°/s, stopping distance 0.51 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Imp is a **wild demon** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** bat wings, a pointed tail and a cheeky grin. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons E|loot_demon_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Thorn Imp|Thorn Imp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 4 | E-, E+, E, D | 19–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, E+, D | 19–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E-, E, D- | 19–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01813` | Lirian Imp Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Imp, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01814` | Lirian Imp Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_01815` | Aldmere Imp Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Imp, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01816` | Great Labyrinth (Floors 1-40) Imp Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Imp, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01817` | Lirian Imp | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.6 m | Day & Night | A typical adult Imp of this region, with soot-stained hide and scavenged scraps. |
| `pop_01818` | Great Labyrinth (Floors 1-40) Imp | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 0.6 m | Day & Night | A typical adult Imp of this region, with dust-grey coloring and old rune scars. |
| `pop_01819` | Aldmere Imp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.66 m | Day & Night | Like a typical Imp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01820` | Lirian Imp Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Imp, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_01821` | Great Labyrinth (Floors 1-40) Imp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 0.75 m | Day & Night | Like a typical Imp, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01822` | Aldmere Imp Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_01823` | Aldmere Imp Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Imp, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `demon_hide_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
