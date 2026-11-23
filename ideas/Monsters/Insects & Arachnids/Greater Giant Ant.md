---
type: monster
id: mon_greater_giant_ant
family: "Insects & Arachnids"
rank: "E"
tier: variant
tags: [monster, insects-arachnids]
---
# Greater Giant Ant

![[mon_greater_giant_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_giant_ant_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.886 × 1.001 × 0.514 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_greater_giant_ant.fbx`

> The Greater Giant Ant is a small creature with a low, wide insectoid build, about 1 m long. Its chitin is weathered and natural, colored in glossy brown, with ochre markings. Look for red-brown chitin and mandibles like pliers. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Giant Ant\|Giant Ant]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1754 · 114 · 171 · 68 · 114 · 70 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (override (base species)); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 57.2 kg, gravity ×1.54, poise 49, knockback resistance 0.43, death style `flip_legs_curl`.
- **Navigation:** speed 3.31 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** red-brown chitin and mandibles like pliers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Giant Ant is a **wild insectoid** encountered at E rank, around level 26. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red-brown chitin and mandibles like pliers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | F+, E+, E-, D-, E | 13–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | F+, E+, E-, E, D, D- | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06352` | Great Labyrinth (Floors 1-40) Greater Giant Ant Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 0.7 m | Day & Night | Like a typical Greater Giant Ant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06353` | Aldmere Greater Giant Ant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.7 m | Day & Night | Like a typical Greater Giant Ant, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06354` | Great Labyrinth (Floors 1-40) Greater Giant Ant Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical Greater Giant Ant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06355` | Aldmere Greater Giant Ant Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical Greater Giant Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06356` | Great Labyrinth (Floors 1-40) Greater Giant Ant Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical Greater Giant Ant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06357` | Aldmere Greater Giant Ant Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical Greater Giant Ant, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06358` | Aldmere Greater Giant Ant | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Greater Giant Ant of this region, with golden, grass-toned coloring. |
| `pop_06359` | Aldmere Greater Giant Ant Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.35 m | Day & Night | Like a typical Greater Giant Ant, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06360` | Great Labyrinth (Floors 1-40) Greater Giant Ant Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Greater Giant Ant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06361` | Great Labyrinth (Floors 1-40) Greater Giant Ant | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 1 m | Day & Night | A typical adult Greater Giant Ant of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06362` | Aldmere Greater Giant Ant Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical Greater Giant Ant, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#75422e` `#4b2b1f` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
