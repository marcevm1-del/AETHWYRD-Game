---
type: monster
id: mon_vesper_touched_cave_spider
family: "Insects & Arachnids"
rank: "E"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Cave Spider

![[mon_vesper_touched_cave_spider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_cave_spider_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (4,152 tris · 0.617 × 0.7 × 0.943 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Cave Spider is a small creature with a squat, many-legged arachnid build, about 0.7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in glossy brown, with sickly green markings. Survivors describe a pale body that glows faintly in the dark. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Cave Spider\|Cave Spider]] (corrupted) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 0.7 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 953 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (override (base species)); animation set `anim_octopod`.
- **Dimensions:** 0.2 m high × 0.7 m long × 0.48 m wide; prefab scale 0.7.
- **Physics:** 11.3 kg, gravity ×1.4, poise 20, knockback resistance 0.23, death style `flip_legs_curl`.
- **Navigation:** speed 3.94 m/s, turn 717°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** a pale body that glows faintly in the dark.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Cave Spider is a **dread insectoid** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale body that glows faintly in the dark. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids E|loot_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 2 | E, E+ | 26–32 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E+, D, E-, F+ | 13–48 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E-, D, E+, E | 19–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06363` | Aldmere Vesper-Touched Cave Spider | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.7 m | Night | A typical adult Vesper-Touched Cave Spider of this region, with golden, grass-toned coloring. |
| `pop_06364` | Whisperwood Vesper-Touched Cave Spider Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.77 m | Night | Like a typical Vesper-Touched Cave Spider, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06365` | Great Labyrinth (Floors 1-40) Vesper-Touched Cave Spider Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 0.59 m | Night | Like a typical Vesper-Touched Cave Spider, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06366` | Great Labyrinth (Floors 1-40) Vesper-Touched Cave Spider Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 0.94 m | Night | Like a typical Vesper-Touched Cave Spider, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06367` | Whisperwood Vesper-Touched Cave Spider Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.7 m | Night | Like a typical Vesper-Touched Cave Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_06368` | Great Labyrinth (Floors 1-40) Vesper-Touched Cave Spider Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 0.77 m | Night | Like a typical Vesper-Touched Cave Spider, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06369` | Aldmere Vesper-Touched Cave Spider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.77 m | Night | Like a typical Vesper-Touched Cave Spider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06370` | Whisperwood Vesper-Touched Cave Spider Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.94 m | Night | Like a typical Vesper-Touched Cave Spider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06371` | Great Labyrinth (Floors 1-40) Vesper-Touched Cave Spider | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 0.7 m | Night | A typical adult Vesper-Touched Cave Spider of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06372` | Whisperwood Vesper-Touched Cave Spider Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.59 m | Night | Like a typical Vesper-Touched Cave Spider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06373` | Whisperwood Vesper-Touched Cave Spider Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.49 m | Night | Like a typical Vesper-Touched Cave Spider, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#7f6232` `#513f21` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
