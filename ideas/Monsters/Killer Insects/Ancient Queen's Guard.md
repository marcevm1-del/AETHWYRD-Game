---
type: monster
id: mon_ancient_queen_s_guard
family: "Killer Insects"
rank: "B"
tier: variant
tags: [monster, killer-insects]
---
# Ancient Queen's Guard

![[mon_ancient_queen_s_guard_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_queen_s_guard_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,996 tris · 2.631 × 3 × 1.531 m · local file `Game/Assets/_Game/Art/Models/Monsters/Killer Insects/mon_ancient_queen_s_guard.fbx`

> The Ancient Queen's Guard is a large creature with a segmented six-limbed frame, about 3 m long. Its chitin is rough, scarred and spiked, colored in black, with ochre markings. Its most striking feature is a shield-shaped head plate. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Queen's Guard\|Queen's Guard]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20627 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.99 m high × 3 m long × 1.52 m wide; prefab scale 3.75.
- **Physics:** 1544.4 kg, gravity ×1.54, poise 369, knockback resistance 0.52, death style `flip_legs_curl`.
- **Navigation:** speed 6.31 m/s, turn 289°/s, stopping distance 0.82 m.
- **Attack count:** 5; **signature:** a shield-shaped head plate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Queen's Guard is a **menacing insectoid** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shield-shaped head plate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects B|loot_killer_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | B, B+, A-, B-, C+ | 86–132 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | B-, B+, A-, C+ | 86–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03672` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B | 108 | 3 m | Day & Night | A typical adult Ancient Queen's Guard of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03673` | Umbravel Ancient Queen's Guard Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | B- | 96 | 2.55 m | Day & Night | Like a typical Ancient Queen's Guard, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03674` | Umbravel Ancient Queen's Guard Albino | [[Regions/Umbravel\|Umbravel]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Ancient Queen's Guard, but a rare pale form with white skin or fur and red eyes. |
| `pop_03675` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 3 m | Day & Night | Like a typical Ancient Queen's Guard, but a rare pale form with white skin or fur and red eyes. |
| `pop_03676` | Umbravel Ancient Queen's Guard Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Ancient Queen's Guard, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03677` | Umbravel Ancient Queen's Guard Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B+ | 120 | 3.3 m | Day & Night | Like a typical Ancient Queen's Guard, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03678` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 3.3 m | Day & Night | Like a typical Ancient Queen's Guard, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03679` | Umbravel Ancient Queen's Guard Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C+ | 86 | 2.1 m | Day & Night | Like a typical Ancient Queen's Guard, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03680` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 3.75 m | Day & Night | Like a typical Ancient Queen's Guard, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03681` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 2.55 m | Day & Night | Like a typical Ancient Queen's Guard, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03682` | Great Labyrinth (Floors 41-90) Ancient Queen's Guard Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C+ | 86 | 2.1 m | Day & Night | Like a typical Ancient Queen's Guard, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `rock_debris` · palette `#575861` `#41414a` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
