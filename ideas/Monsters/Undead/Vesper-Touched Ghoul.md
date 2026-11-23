---
type: monster
id: mon_vesper_touched_ghoul
family: "Undead"
rank: "D"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Ghoul

![[mon_vesper_touched_ghoul_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_ghoul_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,996 tris · 0.529 × 0.347 × 1.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_vesper_touched_ghoul.fbx`

> The Vesper-Touched Ghoul is a person-sized creature with an upright humanoid build, about 1.6 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in bleached bone and grave-cloth, with violet markings. Its most striking feature is grey, hairless skin and long black nails. It has a human-like face in the wrong place. A distinctive marking runs along its back. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Ghoul\|Ghoul]] (corrupted) |
| Rank · level | D · 48 (40–56) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3930 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.51 m wide; prefab scale 0.889.
- **Physics:** 53.2 kg, gravity ×1.5, poise 61, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.37 m/s, turn 316°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** grey, hairless skin and long black nails.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Ghoul is a **horror undead** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey, hairless skin and long black nails. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Strife Marches\|Strife Marches]] | 5 | E+, D+, C-, C | 32–76 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | C-, D, E+, C, D+, D- | 32–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03771` | Strife Marches Vesper-Touched Ghoul Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.12 m | Night | Like a typical Vesper-Touched Ghoul, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03772` | Aldmere Vesper-Touched Ghoul Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2 m | Night | Like a typical Vesper-Touched Ghoul, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03773` | Strife Marches Vesper-Touched Ghoul Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.76 m | Night | Like a typical Vesper-Touched Ghoul, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03774` | Strife Marches Vesper-Touched Ghoul Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 1.6 m | Night | Like a typical Vesper-Touched Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_03775` | Aldmere Vesper-Touched Ghoul | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.6 m | Night | A typical adult Vesper-Touched Ghoul of this region, with mud-slick, algae-streaked skin. |
| `pop_03776` | Aldmere Vesper-Touched Ghoul Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 1.12 m | Night | Like a typical Vesper-Touched Ghoul, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03777` | Aldmere Vesper-Touched Ghoul Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 2.16 m | Night | Like a typical Vesper-Touched Ghoul, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03778` | Strife Marches Vesper-Touched Ghoul Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2 m | Night | Like a typical Vesper-Touched Ghoul, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03779` | Aldmere Vesper-Touched Ghoul Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 1.6 m | Night | Like a typical Vesper-Touched Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_03780` | Strife Marches Vesper-Touched Ghoul Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C | 76 | 2.16 m | Night | Like a typical Vesper-Touched Ghoul, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03781` | Aldmere Vesper-Touched Ghoul Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.36 m | Night | Like a typical Vesper-Touched Ghoul, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#e9d9be` `#958770` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
