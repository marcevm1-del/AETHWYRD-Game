---
type: monster
id: mon_venom_bone_weevil
family: "Killer Insects"
rank: "C+"
tier: variant
tags: [monster, killer-insects]
---
# Venom Bone Weevil

![[mon_venom_bone_weevil_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_venom_bone_weevil_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.905 × 0.999 × 0.525 m · local file `Game/Assets/_Game/Art/Models/Monsters/Killer Insects/mon_venom_bone_weevil.fbx`

> The Venom Bone Weevil is a small creature with a six-legged armored body, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in lacquer-red, with sickly green markings. Survivors describe a shell made from the bones it eats. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Bone Weevil\|Bone Weevil]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10133 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 44 kg, gravity ×1.4, poise 55, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 3.49 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a shell made from the bones it eats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Venom Bone Weevil is a **dread insectoid** encountered at C+ rank, around level 86. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell made from the bones it eats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects C|loot_killer_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | B, C-, B-, B+ | 65–120 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | B-, C, C- | 65–96 | Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | B-, B, C- | 65–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03683` | Great Labyrinth (Floors 41-90) Venom Bone Weevil Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 1.25 m | Night | Like a typical Venom Bone Weevil, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03684` | Great Labyrinth (Floors 1-40) Venom Bone Weevil Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 1 m | Night | Like a typical Venom Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_03685` | Umbravel Venom Bone Weevil Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | B- | 96 | 1.1 m | Night | Like a typical Venom Bone Weevil, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03686` | Great Labyrinth (Floors 1-40) Venom Bone Weevil Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 0.85 m | Night | Like a typical Venom Bone Weevil, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03687` | Great Labyrinth (Floors 41-90) Venom Bone Weevil Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 0.7 m | Night | Like a typical Venom Bone Weevil, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03688` | Great Labyrinth (Floors 1-40) Venom Bone Weevil Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 0.7 m | Night | Like a typical Venom Bone Weevil, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03689` | Great Labyrinth (Floors 41-90) Venom Bone Weevil Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B- | 96 | 1 m | Night | Like a typical Venom Bone Weevil, but a rare pale form with white skin or fur and red eyes. |
| `pop_03690` | Umbravel Venom Bone Weevil Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B | 108 | 1.25 m | Night | Like a typical Venom Bone Weevil, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03691` | Great Labyrinth (Floors 41-90) Venom Bone Weevil Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 1.35 m | Night | Like a typical Venom Bone Weevil, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03692` | Umbravel Venom Bone Weevil Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C- | 65 | 0.7 m | Night | Like a typical Venom Bone Weevil, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03693` | Great Labyrinth (Floors 41-90) Venom Bone Weevil Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 1.1 m | Night | Like a typical Venom Bone Weevil, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#b62f3b` `#662b32` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
