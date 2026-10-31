---
type: monster
id: mon_cave_spider
family: "Insects & Arachnids"
rank: "F+"
tier: core
tags: [monster, insects-arachnids]
---
# Cave Spider

![[mon_cave_spider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cave_spider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,512 tris · 0.654 × 0.7 × 0.395 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cave Spider is a small creature with an eight-legged arachnid body, about 0.7 m long. Its chitin is rough, scarred and spiked, colored in glossy brown, with sickly green markings. Look for a pale body that glows faintly in the dark. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 366 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (override); animation set `anim_octopod`.
- **Dimensions:** 0.2 m high × 0.7 m long × 0.48 m wide; prefab scale 0.7.
- **Physics:** 11.3 kg, gravity ×1.4, poise 18, knockback resistance 0.2, death style `flip_legs_curl`.
- **Navigation:** speed 4.55 m/s, turn 717°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cave Spider is a **menacing insectoid** encountered at F+ rank, around level 13. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale body that glows faintly in the dark. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids F|loot_insect_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Ancient Cave Spider|Ancient Cave Spider]]
- [[Monsters/Insects & Arachnids/Vesper-Touched Cave Spider|Vesper-Touched Cave Spider]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E-, F, E+, F- | 3–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | E-, E+, F-, E, F | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00619` | Whisperwood Cave Spider | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 0.7 m | Day & Night | A typical adult Cave Spider of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00620` | Aldmere Cave Spider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.77 m | Day & Night | Like a typical Cave Spider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00621` | Whisperwood Cave Spider Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 0.7 m | Day & Night | Like a typical Cave Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00622` | Aldmere Cave Spider Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.94 m | Day & Night | Like a typical Cave Spider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00623` | Whisperwood Cave Spider Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.59 m | Day & Night | Like a typical Cave Spider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00624` | Aldmere Cave Spider Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.49 m | Day & Night | Like a typical Cave Spider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00625` | Whisperwood Cave Spider Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E+ | 32 | 0.94 m | Day & Night | Like a typical Cave Spider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00626` | Whisperwood Cave Spider Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.49 m | Day & Night | Like a typical Cave Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00627` | Aldmere Cave Spider Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 0.88 m | Day & Night | Like a typical Cave Spider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00628` | Aldmere Cave Spider Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.7 m | Day & Night | Like a typical Cave Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_00629` | Aldmere Cave Spider Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.59 m | Day & Night | Like a typical Cave Spider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/Weekly Board/Silk for a Dress|Silk for a Dress]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#6f4c2c` `#47311d` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
