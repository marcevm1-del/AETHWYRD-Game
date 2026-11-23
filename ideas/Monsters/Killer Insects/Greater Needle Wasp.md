---
type: monster
id: mon_greater_needle_wasp
family: "Killer Insects"
rank: "D+"
tier: variant
tags: [monster, killer-insects]
---
# Greater Needle Wasp

![[mon_greater_needle_wasp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_needle_wasp_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 5,992 tris · 1.049 × 0.607 × 0.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Killer Insects/mon_greater_needle_wasp.fbx`

> The Greater Needle Wasp is a small creature with a small winged body, about 0.5 m tall. Its chitin is rough, scarred and spiked, colored in black, with sickly green markings. Guild sketches always show a stinger as long as its body. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Needle Wasp\|Needle Wasp]] (elder) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2649 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (override (base species)); animation set `anim_flyer_small`.
- **Dimensions:** 0.17 m high × 0.5 m long × 0.25 m wide; prefab scale 0.625.
- **Physics:** 5.5 kg, gravity ×1.4, poise 17, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 2.72 m/s, turn 707°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a stinger as long as its body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Needle Wasp is a **menacing insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stinger as long as its body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects D|loot_killer_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C+, C, C-, D+ | 56–86 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 6 | C-, D+, C, D-, D | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06484` | Great Labyrinth (Floors 1-40) Greater Needle Wasp Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 0.68 m | Day & Night | Like a typical Greater Needle Wasp, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06485` | Umbravel Greater Needle Wasp Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C- | 65 | 0.5 m | Day & Night | Like a typical Greater Needle Wasp, but a rare pale form with white skin or fur and red eyes. |
| `pop_06486` | Umbravel Greater Needle Wasp | [[Regions/Umbravel\|Umbravel]] | Adult | D+ | 56 | 0.5 m | Day & Night | A typical adult Greater Needle Wasp of this region, with bioluminescent spots along its body. |
| `pop_06487` | Great Labyrinth (Floors 1-40) Greater Needle Wasp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 0.63 m | Day & Night | Like a typical Greater Needle Wasp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06488` | Umbravel Greater Needle Wasp Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C- | 65 | 0.55 m | Day & Night | Like a typical Greater Needle Wasp, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_06489` | Great Labyrinth (Floors 1-40) Greater Needle Wasp Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 0.5 m | Day & Night | Like a typical Greater Needle Wasp, but a rare pale form with white skin or fur and red eyes. |
| `pop_06490` | Umbravel Greater Needle Wasp Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C | 76 | 0.63 m | Day & Night | Like a typical Greater Needle Wasp, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_06491` | Great Labyrinth (Floors 1-40) Greater Needle Wasp | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 0.5 m | Day & Night | A typical adult Greater Needle Wasp of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06492` | Umbravel Greater Needle Wasp Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D- | 40 | 0.35 m | Day & Night | Like a typical Greater Needle Wasp, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_06493` | Great Labyrinth (Floors 1-40) Greater Needle Wasp Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 0.55 m | Day & Night | Like a typical Greater Needle Wasp, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06494` | Umbravel Greater Needle Wasp Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D | 48 | 0.42 m | Day & Night | Like a typical Greater Needle Wasp, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#565660` `#414049` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
