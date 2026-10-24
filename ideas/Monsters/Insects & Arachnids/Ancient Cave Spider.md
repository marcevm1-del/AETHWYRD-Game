---
type: monster
id: mon_ancient_cave_spider
family: "Insects & Arachnids"
rank: "E+"
tier: variant
tags: [monster, insects-arachnids]
---
# Ancient Cave Spider

> The Ancient Cave Spider is a small creature with an eight-legged arachnid body, about 1 m long. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a pale body that glows faintly in the dark. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by a low toxic haze that clings to the ground. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Cave Spider\|Cave Spider]] (ancient) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1436 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (override (base species)); animation set `anim_octopod`.
- **Dimensions:** 0.28 m high × 1 m long × 0.68 m wide; prefab scale 1.
- **Physics:** 33 kg, gravity ×1.4, poise 36, knockback resistance 0.23, death style `flip_legs_curl`.
- **Navigation:** speed 5.19 m/s, turn 600°/s, stopping distance 0.65 m.
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

Ancient Cave Spider is a **menacing insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a pale body that glows faintly in the dark. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E+, D-, E | 26–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 7 | D, E+, E-, D-, D+, E | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03518` | Great Labyrinth (Floors 1-40) Ancient Cave Spider | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 1 m | Day & Night | A typical adult Ancient Cave Spider of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03519` | Aldmere Ancient Cave Spider Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Ancient Cave Spider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03520` | Aldmere Ancient Cave Spider | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1 m | Day & Night | A typical adult Ancient Cave Spider of this region, with golden, grass-toned coloring. |
| `pop_03521` | Great Labyrinth (Floors 1-40) Ancient Cave Spider Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 1 m | Day & Night | Like a typical Ancient Cave Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_03522` | Aldmere Ancient Cave Spider Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Ancient Cave Spider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03523` | Aldmere Ancient Cave Spider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Ancient Cave Spider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03524` | Aldmere Ancient Cave Spider Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 1.35 m | Day & Night | Like a typical Ancient Cave Spider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03525` | Aldmere Ancient Cave Spider Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Ancient Cave Spider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03526` | Aldmere Ancient Cave Spider Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1 m | Day & Night | Like a typical Ancient Cave Spider, but a rare pale form with white skin or fur and red eyes. |
| `pop_03527` | Great Labyrinth (Floors 1-40) Ancient Cave Spider Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Ancient Cave Spider, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03528` | Great Labyrinth (Floors 1-40) Ancient Cave Spider Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Ancient Cave Spider, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
