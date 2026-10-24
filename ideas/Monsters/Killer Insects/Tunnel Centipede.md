---
type: monster
id: mon_tunnel_centipede
family: "Killer Insects"
rank: "D+"
tier: core
tags: [monster, killer-insects]
---
# Tunnel Centipede

![[mon_tunnel_centipede_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tunnel_centipede_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Tunnel Centipede is a huge creature with a coiling, legless body, about 6 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a hundred legs and a head like a split mask. It has eyes that never blink. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 6 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5906 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.24 m high × 6 m long × 0.6 m wide; prefab scale 1.5.
- **Physics:** 496.8 kg, gravity ×1.2, poise 127, knockback resistance 0.46, death style `limp_chain`.
- **Navigation:** speed 6.63 m/s, turn 122°/s, stopping distance 0.61 m.
- **Attack count:** 5; **signature:** a hundred legs and a head like a split mask.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tunnel Centipede is a **dread insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hundred legs and a head like a split mask. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects D|loot_killer_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Iron Centipede|Iron Centipede]]
- [[Monsters/Killer Insects/Radiant Centipede|Radiant Centipede]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 4 | D-, D+, D, C+ | 40–86 | Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D+, D, C-, C+ | 48–86 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C+, D | 48–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00763` | Umbravel Tunnel Centipede Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D- | 40 | 4.2 m | Night | Like a typical Tunnel Centipede, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_00764` | Umbravel Tunnel Centipede | [[Regions/Umbravel\|Umbravel]] | Adult | D+ | 56 | 6 m | Night | A typical adult Tunnel Centipede of this region, with bioluminescent spots along its body. |
| `pop_00765` | Umbravel Tunnel Centipede Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D | 48 | 5.1 m | Night | Like a typical Tunnel Centipede, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00766` | Umbravel Tunnel Centipede Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C+ | 86 | 8.1 m | Night | Like a typical Tunnel Centipede, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00767` | Moraveil Tunnel Centipede | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 6 m | Night | A typical adult Tunnel Centipede of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00768` | Great Labyrinth (Floors 1-40) Tunnel Centipede Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 8.1 m | Night | Like a typical Tunnel Centipede, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00769` | Moraveil Tunnel Centipede Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 5.1 m | Night | Like a typical Tunnel Centipede, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00770` | Great Labyrinth (Floors 1-40) Tunnel Centipede Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 5.1 m | Night | Like a typical Tunnel Centipede, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00771` | Moraveil Tunnel Centipede Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 6 m | Night | Like a typical Tunnel Centipede, but a rare pale form with white skin or fur and red eyes. |
| `pop_00772` | Moraveil Tunnel Centipede Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 8.1 m | Night | Like a typical Tunnel Centipede, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00773` | Moraveil Tunnel Centipede Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 6.6 m | Night | Like a typical Tunnel Centipede, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
