---
type: monster
id: mon_vesper_touched_kobold_tunnel_queen
family: "Kobolds"
rank: "A-"
tier: variant
tags: [monster, kobolds]
---
# Vesper-Touched Kobold Tunnel-Queen

![[mon_vesper_touched_kobold_tunnel_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_kobold_tunnel_queen_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.996 × 1.89 × 1.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_vesper_touched_kobold_tunnel_queen.fbx`

> The Vesper-Touched Kobold Tunnel-Queen is a person-sized creature with a small, compact humanoid body, about 1.6 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in slate-blue, with ochre markings. Its most striking feature is a bloated, jewel-encrusted body carried on a litter. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Tunnel-Queen\|Kobold Tunnel-Queen]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13638 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.64 m wide; prefab scale 1.455.
- **Physics:** 85.2 kg, gravity ×1.65, poise 63, knockback resistance 0.45, death style `ragdoll_crumple`.
- **Navigation:** speed 5.9 m/s, turn 332°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a bloated, jewel-encrusted body carried on a litter.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Kobold Tunnel-Queen is a **dread humanoid** encountered at A- rank, around level 132. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bloated, jewel-encrusted body carried on a litter. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds A|loot_kobold_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | A, B+, B, S-, A- | 108–173 | Night |
| [[Regions/The Maw\|The Maw]] | 5 | B+, A+, B, A | 108–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03269` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A | 146 | 1.6 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_03270` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B+ | 120 | 1.36 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03271` | The Maw Vesper-Touched Kobold Tunnel-Queen Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | B+ | 120 | 1.36 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03272` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B | 108 | 1.12 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03273` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S- | 173 | 2.16 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03274` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A- | 132 | 1.6 m | Night | A typical adult Vesper-Touched Kobold Tunnel-Queen of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03275` | The Maw Vesper-Touched Kobold Tunnel-Queen Alpha | [[Regions/The Maw\|The Maw]] | Alpha | A+ | 159 | 2 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03276` | The Maw Vesper-Touched Kobold Tunnel-Queen Runt | [[Regions/The Maw\|The Maw]] | Runt | B | 108 | 1.12 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03277` | The Maw Vesper-Touched Kobold Tunnel-Queen Albino | [[Regions/The Maw\|The Maw]] | Albino | A | 146 | 1.6 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_03278` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Tunnel-Queen Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | A | 146 | 1.76 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03279` | The Maw Vesper-Touched Kobold Tunnel-Queen Scarred | [[Regions/The Maw\|The Maw]] | Scarred | A | 146 | 1.76 m | Night | Like a typical Vesper-Touched Kobold Tunnel-Queen, but covered in old battle scars, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#688fa8` `#445d70` `#d1a15a` · elongated, irregular silhouette; still-then-sudden timing
