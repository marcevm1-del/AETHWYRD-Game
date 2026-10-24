---
type: monster
id: mon_greater_hornet_lancer
family: "Killer Insects"
rank: "C"
tier: variant
tags: [monster, killer-insects]
---
# Greater Hornet Lancer

![[mon_greater_hornet_lancer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_hornet_lancer_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Hornet Lancer is a person-sized creature with a small winged body, about 1.9 m tall. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a lance-like stinger and humming armored wings. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hornet Lancer\|Hornet Lancer]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6354 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (keyword); animation set `anim_flyer_small`.
- **Dimensions:** 0.63 m high × 1.9 m long × 0.97 m wide; prefab scale 2.375.
- **Physics:** 301.8 kg, gravity ×1.4, poise 150, knockback resistance 0.34, death style `flip_legs_curl`.
- **Navigation:** speed 5.3 m/s, turn 363°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** a lance-like stinger and humming armored wings.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Hornet Lancer is a **menacing insectoid** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lance-like stinger and humming armored wings. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C-, C+, D+ | 56–86 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 4 | D+, C-, C, C+ | 56–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D+, C+, C, C- | 56–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03650` | Great Labyrinth (Floors 41-90) Greater Hornet Lancer Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 1.61 m | Day & Night | Like a typical Greater Hornet Lancer, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03651` | Umbravel Greater Hornet Lancer Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 1.33 m | Day & Night | Like a typical Greater Hornet Lancer, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03652` | Umbravel Greater Hornet Lancer Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 1.61 m | Day & Night | Like a typical Greater Hornet Lancer, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03653` | Great Labyrinth (Floors 1-40) Greater Hornet Lancer Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 1.33 m | Day & Night | Like a typical Greater Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03654` | Great Labyrinth (Floors 1-40) Greater Hornet Lancer Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 1.9 m | Day & Night | Like a typical Greater Hornet Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_03655` | Great Labyrinth (Floors 1-40) Greater Hornet Lancer | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 1.9 m | Day & Night | A typical adult Greater Hornet Lancer of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03656` | Great Labyrinth (Floors 1-40) Greater Hornet Lancer Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.61 m | Day & Night | Like a typical Greater Hornet Lancer, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03657` | Great Labyrinth (Floors 41-90) Greater Hornet Lancer Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 2.09 m | Day & Night | Like a typical Greater Hornet Lancer, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03658` | Great Labyrinth (Floors 41-90) Greater Hornet Lancer Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 1.33 m | Day & Night | Like a typical Greater Hornet Lancer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03659` | Umbravel Greater Hornet Lancer | [[Regions/Umbravel\|Umbravel]] | Adult | C | 76 | 1.9 m | Day & Night | A typical adult Greater Hornet Lancer of this region, with bioluminescent spots along its body. |
| `pop_03660` | Umbravel Greater Hornet Lancer Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C+ | 86 | 2.09 m | Day & Night | Like a typical Greater Hornet Lancer, but covered in old battle scars, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
