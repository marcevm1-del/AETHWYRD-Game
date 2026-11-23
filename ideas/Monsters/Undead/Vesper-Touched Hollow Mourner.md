---
type: monster
id: mon_vesper_touched_hollow_mourner
family: "Undead"
rank: "E-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Hollow Mourner

![[mon_vesper_touched_hollow_mourner_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_hollow_mourner_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,996 tris · 0.585 × 0.371 × 1.7 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_vesper_touched_hollow_mourner.fbx`

> The Vesper-Touched Hollow Mourner is a person-sized creature with an upright humanoid build, about 1.7 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in grave-mould grey-green, with violet markings. Its most striking feature is a weeping figure that moves only when you look away. It has no eyes at all, only a wide and patient mouth. Small scars and rough edges mark it as a survivor. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Hollow Mourner\|Hollow Mourner]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1059 · 103 · 86 · 69 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 56, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.54 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** a weeping figure that moves only when you look away.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Hollow Mourner is a **horror undead** encountered at E- rank, around level 19. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a weeping figure that moves only when you look away. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 5 | F+, D-, E+, F, E | 8–40 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 6 | E+, E, D-, F+, F | 8–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06572` | Aldmere Vesper-Touched Hollow Mourner Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F+ | 13 | 1.44 m | Night | Like a typical Vesper-Touched Hollow Mourner, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06573` | Whisperwood Vesper-Touched Hollow Mourner Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E+ | 32 | 2.13 m | Night | Like a typical Vesper-Touched Hollow Mourner, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_06574` | Whisperwood Vesper-Touched Hollow Mourner Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E | 26 | 1.7 m | Night | Like a typical Vesper-Touched Hollow Mourner, but a rare pale form with white skin or fur and red eyes. |
| `pop_06575` | Whisperwood Vesper-Touched Hollow Mourner Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D- | 40 | 2.29 m | Night | Like a typical Vesper-Touched Hollow Mourner, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_06576` | Whisperwood Vesper-Touched Hollow Mourner Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E | 26 | 1.87 m | Night | Like a typical Vesper-Touched Hollow Mourner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_06577` | Whisperwood Vesper-Touched Hollow Mourner Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F+ | 13 | 1.44 m | Night | Like a typical Vesper-Touched Hollow Mourner, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_06578` | Aldmere Vesper-Touched Hollow Mourner Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 2.29 m | Night | Like a typical Vesper-Touched Hollow Mourner, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06579` | Aldmere Vesper-Touched Hollow Mourner Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 2.13 m | Night | Like a typical Vesper-Touched Hollow Mourner, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06580` | Whisperwood Vesper-Touched Hollow Mourner Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F | 8 | 1.19 m | Night | Like a typical Vesper-Touched Hollow Mourner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_06581` | Aldmere Vesper-Touched Hollow Mourner Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 1.19 m | Night | Like a typical Vesper-Touched Hollow Mourner, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_06582` | Aldmere Vesper-Touched Hollow Mourner Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E | 26 | 1.7 m | Night | Like a typical Vesper-Touched Hollow Mourner, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#8f9b7b` `#5d6750` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
