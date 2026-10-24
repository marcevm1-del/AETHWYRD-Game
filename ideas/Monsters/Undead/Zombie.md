---
type: monster
id: mon_zombie
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Zombie

![[mon_zombie_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_zombie_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Zombie is a person-sized creature with an upright humanoid build, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show grey skin, burial clothes and a slack jaw. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 347 · 50 · 42 · 34 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override); animation set `anim_medium_biped`.
- **Dimensions:** 1.7 m high × 0.51 m long × 0.54 m wide; prefab scale 0.944.
- **Physics:** 63.9 kg, gravity ×1.5, poise 49, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 4.53 m/s, turn 307°/s, stopping distance 0.69 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zombie is a **menacing undead** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey skin, burial clothes and a slack jaw. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead F|loot_undead_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Zombie|Vesper-Touched Zombie]]
- [[Monsters/Undead/Dawn Zombie|Dawn Zombie]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F-, E-, F+, E | 3–26 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | F+, F, F-, E, E- | 3–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00807` | Whisperwood Zombie Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 1.19 m | Night | Like a typical Zombie, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00808` | Whisperwood Zombie Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 2.13 m | Night | Like a typical Zombie, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00809` | Whisperwood Zombie Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 1.7 m | Night | Like a typical Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_00810` | Aldmere Zombie Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1.7 m | Night | Like a typical Zombie, but a rare pale form with white skin or fur and red eyes. |
| `pop_00811` | Aldmere Zombie | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 1.7 m | Night | A typical adult Zombie of this region, with mud-slick, algae-streaked skin. |
| `pop_00812` | Aldmere Zombie Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.87 m | Night | Like a typical Zombie, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_00813` | Whisperwood Zombie Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 2.29 m | Night | Like a typical Zombie, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00814` | Aldmere Zombie Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.19 m | Night | Like a typical Zombie, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00815` | Whisperwood Zombie Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 1.44 m | Night | Like a typical Zombie, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00816` | Aldmere Zombie Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 2.29 m | Night | Like a typical Zombie, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_00817` | Aldmere Zombie Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.13 m | Night | Like a typical Zombie, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Contracts and story encounters

- [[Quests/Weekly Board/Gate Watch|Gate Watch]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
