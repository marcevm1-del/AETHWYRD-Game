---
type: monster
id: mon_kraken_spawn
family: "Aquatic"
rank: "B+"
tier: core
tags: [monster, aquatic]
---
# Kraken Spawn

![[mon_kraken_spawn_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kraken_spawn_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,696 tris · 21.532 × 25 × 28.961 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kraken Spawn is a colossal creature with a huge many-armed sea body, about 25 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in sea-blue. Look for a galleon-sized body with hooked tentacles. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 25 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31691 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/tentacled\|tentacled]] · `anim_cephalopod` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Lirian\|Lirian]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/tentacled|tentacled]] (rigId); animation set `anim_cephalopod`.
- **Dimensions:** 13.75 m high × 25 m long × 30 m wide; prefab scale 8.333.
- **Physics:** 328125 kg, gravity ×1, poise 3593, knockback resistance 0.82, death style `sink_limp`.
- **Navigation:** speed 17.16 m/s, turn 60°/s, stopping distance 5.4 m.
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

Kraken Spawn is a **dread aquatic** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a galleon-sized body with hooked tentacles. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_cephalopod`, animation set `anim_cephalopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic B|loot_aquatic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Vesper-Touched Kraken Spawn|Vesper-Touched Kraken Spawn]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 4 | B-, B+, A+, A | 96–159 | Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 4 | B-, A, A-, A+ | 96–159 | Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 1 | A- | 132–132 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 2 | B-, A | 96–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02007` | Lirian Kraken Spawn Runt | [[Regions/Lirian\|Lirian]] | Runt | B- | 96 | 17.5 m | Night | Like a typical Kraken Spawn, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02008` | Whitewater Reach Kraken Spawn Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | B- | 96 | 17.5 m | Night | Like a typical Kraken Spawn, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02009` | True-Name Isles Kraken Spawn Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | A- | 132 | 25 m | Night | Like a typical Kraken Spawn, but a rare pale form with white skin or fur and red eyes. |
| `pop_02010` | Whitewater Reach Kraken Spawn Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | A | 146 | 31.25 m | Night | Like a typical Kraken Spawn, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02011` | Whitewater Reach Kraken Spawn Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | A- | 132 | 25 m | Night | Like a typical Kraken Spawn, but a rare pale form with white skin or fur and red eyes. |
| `pop_02012` | Whitewater Reach Kraken Spawn Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | A+ | 159 | 33.75 m | Night | Like a typical Kraken Spawn, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02013` | Goldmere Coast Kraken Spawn Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | B- | 96 | 17.5 m | Night | Like a typical Kraken Spawn, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02014` | Lirian Kraken Spawn | [[Regions/Lirian\|Lirian]] | Adult | B+ | 120 | 25 m | Night | A typical adult Kraken Spawn of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02015` | Goldmere Coast Kraken Spawn Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | A | 146 | 31.25 m | Night | Like a typical Kraken Spawn, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02016` | Lirian Kraken Spawn Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | A+ | 159 | 33.75 m | Night | Like a typical Kraken Spawn, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02017` | Lirian Kraken Spawn Alpha | [[Regions/Lirian\|Lirian]] | Alpha | A | 146 | 31.25 m | Night | Like a typical Kraken Spawn, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#3e7c9f` `#2a5470` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
