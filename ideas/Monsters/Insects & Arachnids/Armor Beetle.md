---
type: monster
id: mon_armor_beetle
family: "Insects & Arachnids"
rank: "E+"
tier: core
tags: [monster, insects-arachnids]
---
# Armor Beetle

![[mon_armor_beetle_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_armor_beetle_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,860 tris · 1.26 × 1.2 × 1.102 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Armor Beetle is a person-sized creature with a six-legged armored body, about 1.2 m long. Its chitin is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe a shell like polished bronze. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1.2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2511 · 138 · 207 · 83 · 138 · 70 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.4 m high × 1.2 m long × 0.61 m wide; prefab scale 1.5.
- **Physics:** 98.8 kg, gravity ×1.54, poise 65, knockback resistance 0.43, death style `flip_legs_curl`.
- **Navigation:** speed 3.8 m/s, turn 456°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** a shell like polished bronze.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Armor Beetle is a **wild insectoid** encountered at E+ rank, around level 32. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell like polished bronze. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids E|loot_insect_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Vesper-Touched Armor Beetle|Vesper-Touched Armor Beetle]]
- [[Monsters/Insects & Arachnids/Meadow Armor Beetle|Meadow Armor Beetle]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, E-, E | 19–40 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | E+, D, D- | 32–48 | Day & Night |
| [[Regions/Sylvaran\|Sylvaran]] | 4 | E-, D-, E+ | 19–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00641` | Aldmere Armor Beetle Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.2 m | Day & Night | Like a typical Armor Beetle, but a rare pale form with white skin or fur and red eyes. |
| `pop_00642` | Great Labyrinth (Floors 1-40) Armor Beetle | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 1.2 m | Day & Night | A typical adult Armor Beetle of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00643` | Aldmere Armor Beetle Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.84 m | Day & Night | Like a typical Armor Beetle, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00644` | Aldmere Armor Beetle Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.02 m | Day & Night | Like a typical Armor Beetle, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00645` | Great Labyrinth (Floors 1-40) Armor Beetle Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 1.5 m | Day & Night | Like a typical Armor Beetle, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00646` | Sylvaran Armor Beetle Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | E- | 19 | 0.84 m | Day & Night | Like a typical Armor Beetle, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00647` | Sylvaran Armor Beetle Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | D- | 40 | 1.32 m | Day & Night | Like a typical Armor Beetle, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00648` | Aldmere Armor Beetle Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.32 m | Day & Night | Like a typical Armor Beetle, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00649` | Great Labyrinth (Floors 1-40) Armor Beetle Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.32 m | Day & Night | Like a typical Armor Beetle, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00650` | Sylvaran Armor Beetle Albino | [[Regions/Sylvaran\|Sylvaran]] | Albino | D- | 40 | 1.2 m | Day & Night | Like a typical Armor Beetle, but a rare pale form with white skin or fur and red eyes. |
| `pop_00651` | Sylvaran Armor Beetle | [[Regions/Sylvaran\|Sylvaran]] | Adult | E+ | 32 | 1.2 m | Day & Night | A typical adult Armor Beetle of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
