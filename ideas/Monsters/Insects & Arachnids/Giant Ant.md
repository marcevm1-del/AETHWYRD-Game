---
type: monster
id: mon_giant_ant
family: "Insects & Arachnids"
rank: "F"
tier: core
tags: [monster, insects-arachnids]
---
# Giant Ant

![[mon_giant_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_giant_ant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,168 tris · 0.546 × 0.6 × 0.279 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Giant Ant is a small creature with a low, wide insectoid build, about 0.6 m long. Its chitin is weathered and natural, colored in glossy brown, with ochre markings. Its most striking feature is red-brown chitin and mandibles like pliers. It has dark, wary eyes. It has no ornament at all: simple, readable shapes. It stalks low to the ground, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.6 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 316 · 42 · 63 · 25 · 42 · 70 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (override); animation set `anim_hexapod`.
- **Dimensions:** 0.2 m high × 0.6 m long × 0.3 m wide; prefab scale 0.75.
- **Physics:** 12.4 kg, gravity ×1.54, poise 19, knockback resistance 0.4, death style `flip_legs_curl`.
- **Navigation:** speed 2.57 m/s, turn 645°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Giant Ant is a **wild insectoid** encountered at F rank, around level 8. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red-brown chitin and mandibles like pliers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids F|loot_insect_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Ancient Giant Ant|Ancient Giant Ant]]
- [[Monsters/Insects & Arachnids/Greater Giant Ant|Greater Giant Ant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | E-, F-, F | 3–19 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 7 | F-, F, F+, E, E- | 3–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00608` | Aldmere Giant Ant Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Giant Ant, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00609` | Whisperwood Giant Ant Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.51 m | Day & Night | Like a typical Giant Ant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00610` | Whisperwood Giant Ant | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Giant Ant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00611` | Aldmere Giant Ant Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.51 m | Day & Night | Like a typical Giant Ant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00612` | Whisperwood Giant Ant Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Giant Ant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00613` | Whisperwood Giant Ant Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.66 m | Day & Night | Like a typical Giant Ant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00614` | Aldmere Giant Ant | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.6 m | Day & Night | A typical adult Giant Ant of this region, with golden, grass-toned coloring. |
| `pop_00615` | Whisperwood Giant Ant Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.6 m | Day & Night | Like a typical Giant Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00616` | Whisperwood Giant Ant Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.81 m | Day & Night | Like a typical Giant Ant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00617` | Whisperwood Giant Ant Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.75 m | Day & Night | Like a typical Giant Ant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00618` | Aldmere Giant Ant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Giant Ant, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/Weekly Board/Sewer Duty|Sewer Duty]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#78562f` `#4d3820` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
