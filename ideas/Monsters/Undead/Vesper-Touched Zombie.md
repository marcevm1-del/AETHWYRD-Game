---
type: monster
id: mon_vesper_touched_zombie
family: "Undead"
rank: "E-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Zombie

![[mon_vesper_touched_zombie_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_zombie_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,498 tris · 0.653 × 0.695 × 1.7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Zombie is a person-sized creature with a lean humanoid frame, about 1.7 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in dusk-violet. Look for grey skin, burial clothes and a slack jaw. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Zombie\|Zombie]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1059 · 103 · 86 · 69 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 56, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 4.31 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** grey skin, burial clothes and a slack jaw.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Zombie is a **dread undead** encountered at E- rank, around level 19. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey skin, burial clothes and a slack jaw. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E-, E | 19–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E, F, E+, D-, E- | 8–40 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | E-, F+, F | 8–19 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03705` | Great Labyrinth (Floors 1-40) Vesper-Touched Zombie | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E- | 19 | 1.7 m | Night | A typical adult Vesper-Touched Zombie of this region, with dust-grey coloring and old rune scars. |
| `pop_03706` | Whisperwood Vesper-Touched Zombie Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E | 26 | 1.7 m | Night | Like a typical Vesper-Touched Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_03707` | Aldmere Vesper-Touched Zombie | [[Regions/Aldmere\|Aldmere]] | Adult | E- | 19 | 1.7 m | Night | A typical adult Vesper-Touched Zombie of this region, with mud-slick, algae-streaked skin. |
| `pop_03708` | Great Labyrinth (Floors 1-40) Vesper-Touched Zombie Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E | 26 | 1.7 m | Night | Like a typical Vesper-Touched Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_03709` | Aldmere Vesper-Touched Zombie Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F+ | 13 | 1.44 m | Night | Like a typical Vesper-Touched Zombie, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03710` | Great Labyrinth (Floors 1-40) Vesper-Touched Zombie Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E | 26 | 1.87 m | Night | Like a typical Vesper-Touched Zombie, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03711` | Whisperwood Vesper-Touched Zombie Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F | 8 | 1.19 m | Night | Like a typical Vesper-Touched Zombie, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03712` | Whisperwood Vesper-Touched Zombie Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E+ | 32 | 2.13 m | Night | Like a typical Vesper-Touched Zombie, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03713` | Aldmere Vesper-Touched Zombie Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 1.19 m | Night | Like a typical Vesper-Touched Zombie, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03714` | Whisperwood Vesper-Touched Zombie Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D- | 40 | 2.29 m | Night | Like a typical Vesper-Touched Zombie, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03715` | Whisperwood Vesper-Touched Zombie | [[Regions/Whisperwood\|Whisperwood]] | Adult | E- | 19 | 1.7 m | Night | A typical adult Vesper-Touched Zombie of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#4c4c75` `#3e3f65` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
