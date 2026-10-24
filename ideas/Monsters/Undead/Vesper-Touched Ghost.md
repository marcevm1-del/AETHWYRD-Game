---
type: monster
id: mon_vesper_touched_ghost
family: "Undead"
rank: "D-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Ghost

> The Vesper-Touched Ghost is a person-sized creature with a bodiless, glowing form, about 1.7 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a translucent figure frozen in its last moment. It has pale, pupil-less eyes. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Ghost\|Ghost]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2234 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.7 m high × 0.51 m long × 1.09 m wide; prefab scale 1.7.
- **Physics:** 0.5 kg, gravity ×0, poise 12, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 6.68 m/s, turn 552°/s, stopping distance 0.83 m.
- **Attack count:** 5; **signature:** a translucent figure frozen in its last moment.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Ghost is a **dread undead** encountered at D- rank, around level 40. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a translucent figure frozen in its last moment. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead D|loot_undead_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, E, D | 26–65 | Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E+, D, C-, E, D+ | 26–65 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | D, E | 26–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03760` | Strife Marches Vesper-Touched Ghost Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C- | 65 | 2.29 m | Night | Like a typical Vesper-Touched Ghost, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03761` | Aldmere Vesper-Touched Ghost Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 1.44 m | Night | Like a typical Vesper-Touched Ghost, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03762` | Strife Marches Vesper-Touched Ghost Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E | 26 | 1.19 m | Night | Like a typical Vesper-Touched Ghost, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03763` | Great Labyrinth (Floors 1-40) Vesper-Touched Ghost Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D | 48 | 1.7 m | Night | Like a typical Vesper-Touched Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_03764` | Great Labyrinth (Floors 1-40) Vesper-Touched Ghost Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E | 26 | 1.19 m | Night | Like a typical Vesper-Touched Ghost, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03765` | Aldmere Vesper-Touched Ghost Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 1.87 m | Night | Like a typical Vesper-Touched Ghost, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03766` | Strife Marches Vesper-Touched Ghost Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D | 48 | 1.7 m | Night | Like a typical Vesper-Touched Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_03767` | Aldmere Vesper-Touched Ghost Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 2.29 m | Night | Like a typical Vesper-Touched Ghost, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03768` | Strife Marches Vesper-Touched Ghost Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D | 48 | 1.87 m | Night | Like a typical Vesper-Touched Ghost, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03769` | Aldmere Vesper-Touched Ghost Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E | 26 | 1.19 m | Night | Like a typical Vesper-Touched Ghost, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03770` | Aldmere Vesper-Touched Ghost Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 2.13 m | Night | Like a typical Vesper-Touched Ghost, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
