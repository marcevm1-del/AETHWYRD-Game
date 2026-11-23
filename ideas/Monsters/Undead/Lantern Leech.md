---
type: monster
id: mon_lantern_leech
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Lantern Leech

![[mon_lantern_leech_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lantern_leech_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.206 × 0.6 × 0.301 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_lantern_leech.fbx`

> The Lantern Leech is a small creature with a massive snake-like frame, about 0.6 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in grave-mould grey-green, with sea-blue markings. Survivors describe a glow on its back like a lost traveler's lantern. It has eyes that never blink. It has no ornament at all: simple, readable shapes. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 0.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.02 m high × 0.6 m long × 0.06 m wide; prefab scale 0.15.
- **Physics:** 0.5 kg, gravity ×1.2, poise 3, knockback resistance 0.4, death style `limp_chain`.
- **Navigation:** speed 1.85 m/s, turn 387°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a glow on its back like a lost traveler's lantern.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lantern Leech is a **dread undead** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a glow on its back like a lost traveler's lantern. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead F|loot_undead_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Ancient Lantern Leech|Ancient Lantern Leech]]
- [[Monsters/Undead/Greater Lantern Leech|Greater Lantern Leech]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E, F- | 3–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E-, F+, F-, F | 3–19 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | F, F+, E | 8–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00851` | Great Labyrinth (Floors 1-40) Lantern Leech Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 0.81 m | Night | Like a typical Lantern Leech, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00852` | Whisperwood Lantern Leech Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.75 m | Night | Like a typical Lantern Leech, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00853` | Whisperwood Lantern Leech Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.6 m | Night | Like a typical Lantern Leech, but a rare pale form with white skin or fur and red eyes. |
| `pop_00854` | Whisperwood Lantern Leech Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.42 m | Night | Like a typical Lantern Leech, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00855` | Aldmere Lantern Leech | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.6 m | Night | A typical adult Lantern Leech of this region, with mud-slick, algae-streaked skin. |
| `pop_00856` | Great Labyrinth (Floors 1-40) Lantern Leech Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.42 m | Night | Like a typical Lantern Leech, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00857` | Great Labyrinth (Floors 1-40) Lantern Leech Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 0.51 m | Night | Like a typical Lantern Leech, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00858` | Aldmere Lantern Leech Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.66 m | Night | Like a typical Lantern Leech, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00859` | Aldmere Lantern Leech Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.81 m | Night | Like a typical Lantern Leech, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_00860` | Whisperwood Lantern Leech Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.51 m | Night | Like a typical Lantern Leech, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00861` | Whisperwood Lantern Leech | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.6 m | Night | A typical adult Lantern Leech of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `rot_bone` · VFX `mist_droplets` · palette `#90a683` `#5e6e56` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
