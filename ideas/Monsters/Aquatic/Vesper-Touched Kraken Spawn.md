---
type: monster
id: mon_vesper_touched_kraken_spawn
family: "Aquatic"
rank: "A"
tier: variant
tags: [monster, aquatic]
---
# Vesper-Touched Kraken Spawn

![[mon_vesper_touched_kraken_spawn_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_kraken_spawn_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,732 tris · 23.934 × 25 × 23.667 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Kraken Spawn is a colossal creature with a huge many-armed sea body, about 25 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in sea-blue. Its most striking feature is a galleon-sized body with hooked tentacles. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It copies the walk of whatever it hunts, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Kraken Spawn\|Kraken Spawn]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Water · Lightning |
| Size | 25 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42476 · 743 · 535 · 535 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/True-Name Isles\|True-Name Isles]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 13.75 m high × 25 m long × 30 m wide; prefab scale 8.333.
- **Physics:** 328125 kg, gravity ×1, poise 3930, knockback resistance 0.85, death style `sink_limp`.
- **Navigation:** speed 18.91 m/s, turn 60°/s, stopping distance 5.4 m.
- **Attack count:** 5; **signature:** a galleon-sized body with hooked tentacles.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Tentacle Slap\|Tentacle Slap]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Drag Under\|Drag Under]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ink Cloud\|Ink Cloud]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Kraken Spawn is a **horror aquatic** encountered at A rank, around level 146. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a galleon-sized body with hooked tentacles. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/True-Name Isles|True-Name Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_cephalopod`, animation set `anim_cephalopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic A|loot_aquatic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 4 | B+, S-, S, A+ | 120–188 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 7 | A-, A, S-, A+, B+, S | 120–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04873` | True-Name Isles Vesper-Touched Kraken Spawn Runt | [[Regions/True-Name Isles\|True-Name Isles]] | Runt | B+ | 120 | 17.5 m | Night | Like a typical Vesper-Touched Kraken Spawn, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04874` | Goldmere Coast Vesper-Touched Kraken Spawn Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | A- | 132 | 21.25 m | Night | Like a typical Vesper-Touched Kraken Spawn, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04875` | Goldmere Coast Vesper-Touched Kraken Spawn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | A | 146 | 25 m | Night | A typical adult Vesper-Touched Kraken Spawn of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04876` | Goldmere Coast Vesper-Touched Kraken Spawn Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | S- | 173 | 31.25 m | Night | Like a typical Vesper-Touched Kraken Spawn, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04877` | Goldmere Coast Vesper-Touched Kraken Spawn Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | A+ | 159 | 25 m | Night | Like a typical Vesper-Touched Kraken Spawn, but a rare pale form with white skin or fur and red eyes. |
| `pop_04878` | Goldmere Coast Vesper-Touched Kraken Spawn Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | A+ | 159 | 27.5 m | Night | Like a typical Vesper-Touched Kraken Spawn, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04879` | Goldmere Coast Vesper-Touched Kraken Spawn Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | B+ | 120 | 17.5 m | Night | Like a typical Vesper-Touched Kraken Spawn, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04880` | True-Name Isles Vesper-Touched Kraken Spawn Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | S- | 173 | 31.25 m | Night | Like a typical Vesper-Touched Kraken Spawn, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04881` | Goldmere Coast Vesper-Touched Kraken Spawn Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | S | 188 | 33.75 m | Night | Like a typical Vesper-Touched Kraken Spawn, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04882` | True-Name Isles Vesper-Touched Kraken Spawn Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | S | 188 | 33.75 m | Night | Like a typical Vesper-Touched Kraken Spawn, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04883` | True-Name Isles Vesper-Touched Kraken Spawn Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | A+ | 159 | 25 m | Night | Like a typical Vesper-Touched Kraken Spawn, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#396c94` `#274967` `#4fa8e8` · broken symmetry, mimicry, audio-first reveal
