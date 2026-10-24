---
type: monster
id: mon_giant_crow
family: "Avians"
rank: "F"
tier: core
tags: [monster, avians]
---
# Giant Crow

![[mon_giant_crow_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_giant_crow_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,770 tris · 0.567 × 0.446 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Giant Crow is a small creature with a feathered avian body, about 0.6 m tall. Its plumage is weathered and natural, colored in ink black with bruised violet. Guild sketches always show a beak full of stolen shiny things. It has amber predator eyes. It has no ornament at all: simple, readable shapes. It stalks low to the ground, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (override); animation set `anim_avian`.
- **Dimensions:** 0.28 m high × 0.6 m long × 1.03 m wide; prefab scale 1.
- **Physics:** 3 kg, gravity ×1, poise 13, knockback resistance 0.05, death style `tumble_feathers_burst`.
- **Navigation:** speed 2.21 m/s, turn 775°/s, stopping distance 0.52 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Giant Crow is a **wild avian** encountered at F rank, around level 8. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beak full of stolen shiny things. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians F|loot_avian_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Brine Crow|Brine Crow]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F-, E-, F+, E, F | 3–26 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F+, E-, E | 13–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02052` | Aldmere Giant Crow Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Giant Crow, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02053` | Whisperwood Giant Crow Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.6 m | Day & Night | Like a typical Giant Crow, but a rare pale form with white skin or fur and red eyes. |
| `pop_02054` | Whisperwood Giant Crow Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Giant Crow, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02055` | Aldmere Giant Crow Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Giant Crow, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02056` | Aldmere Giant Crow Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.66 m | Day & Night | Like a typical Giant Crow, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02057` | Aldmere Giant Crow Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.81 m | Day & Night | Like a typical Giant Crow, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02058` | Aldmere Giant Crow | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Giant Crow of this region, with golden, grass-toned coloring. |
| `pop_02059` | Aldmere Giant Crow Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.51 m | Day & Night | Like a typical Giant Crow, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02060` | Aldmere Giant Crow Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.6 m | Day & Night | Like a typical Giant Crow, but a rare pale form with white skin or fur and red eyes. |
| `pop_02061` | Whisperwood Giant Crow Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.66 m | Day & Night | Like a typical Giant Crow, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02062` | Whisperwood Giant Crow Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.81 m | Day & Night | Like a typical Giant Crow, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Contracts and story encounters

- [[Quests/Mina's Lost Earring|Mina's Lost Earring]] — rank F, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/The Fortune Is Always Bad|The Fortune Is Always Bad]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
