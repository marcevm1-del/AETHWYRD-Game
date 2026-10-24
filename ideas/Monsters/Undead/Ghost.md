---
type: monster
id: mon_ghost
family: "Undead"
rank: "E"
tier: core
tags: [monster, undead]
---
# Ghost

> The Ghost is a person-sized creature with a bodiless, glowing form, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Look for a translucent figure frozen in its last moment. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1198 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 1.7 m high × 0.51 m long × 1.09 m wide; prefab scale 1.7.
- **Physics:** 0.5 kg, gravity ×0, poise 10, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 7.02 m/s, turn 552°/s, stopping distance 0.83 m.
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

Ghost is a **menacing undead** encountered at E rank, around level 26. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a translucent figure frozen in its last moment. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor|Greymoor]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Ghost|Vesper-Touched Ghost]]
- [[Monsters/Undead/Blight Ghost|Blight Ghost]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 1 | E- | 19–19 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F+, E, E-, D | 13–48 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | D-, E | 26–40 | Night |
| [[Regions/Lirian\|Lirian]] | 1 | F+ | 13–13 | Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | E+, E, D | 26–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00862` | Aldmere Ghost Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.44 m | Night | Like a typical Ghost, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_00863` | Great Labyrinth (Floors 1-40) Ghost Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 1.19 m | Night | Like a typical Ghost, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00864` | Whisperwood Ghost Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 2.13 m | Night | Like a typical Ghost, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00865` | Great Labyrinth (Floors 1-40) Ghost | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 1.7 m | Night | A typical adult Ghost of this region, with dust-grey coloring and old rune scars. |
| `pop_00866` | Whisperwood Ghost | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 1.7 m | Night | A typical adult Ghost of this region, with dust-grey coloring and old rune scars. |
| `pop_00867` | Lirian Ghost Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 1.19 m | Night | Like a typical Ghost, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_00868` | Great Labyrinth (Floors 1-40) Ghost Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 1.44 m | Night | Like a typical Ghost, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00869` | Greymoor Ghost Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 1.7 m | Night | Like a typical Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_00870` | Greymoor Ghost | [[Regions/Greymoor\|Greymoor]] | Adult | E | 26 | 1.7 m | Night | A typical adult Ghost of this region, with mud-slick, algae-streaked skin. |
| `pop_00871` | Great Labyrinth (Floors 1-40) Ghost Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 2.29 m | Night | Like a typical Ghost, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00872` | Greymoor Ghost Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D | 48 | 2.29 m | Night | Like a typical Ghost, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
