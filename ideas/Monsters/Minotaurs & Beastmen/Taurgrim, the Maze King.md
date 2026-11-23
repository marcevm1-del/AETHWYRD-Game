---
type: monster
id: mon_taurgrim_the_maze_king
family: "Minotaurs & Beastmen"
rank: "S"
tier: core
tags: [monster, minotaurs-beastmen, unique]
---
# Taurgrim, the Maze King

![[mon_taurgrim_the_maze_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_taurgrim_the_maze_king_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.342 × 5.621 × 5.999 m · local file `Game/Assets/_Game/Art/Models/Monsters/Minotaurs & Beastmen/mon_taurgrim_the_maze_king.fbx`

> The Taurgrim, the Maze King is a huge creature with a towering, heavy-limbed body, about 6 m tall. Its hide is rough, scarred and spiked, colored in tan, with ochre markings. Guild sketches always show a crown fused to its horns and a labrys of starmetal. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Minotaurs & Beastmen|Minotaurs & Beastmen]] · Beastman |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 59047 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 261258 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Labyrinth Myth |
| Trope | The minotaur that appears where it shouldn't (DanMachi), Greek labyrinth myth |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 2.52 m wide; prefab scale 1.714.
- **Physics:** 5054.4 kg, gravity ×1.43, poise 401, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.34 m/s, turn 155°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a crown fused to its horns and a labrys of starmetal.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Horn Charge\|Horn Charge]] | dash | 1.8 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Taurgrim, the Maze King is a **menacing beastman** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown fused to its horns and a labrys of starmetal. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Minotaurs & Beastmen S|loot_minotaur_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horn\|Horn]] | 60% | 1–3 |
| [[Items/Labyrinth Bronze\|Labyrinth Bronze]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01245` | Taurgrim, the Maze King | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Unique | S | 188 | 6 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `short_hide` · VFX `rock_debris` · palette `#92614d` `#624034` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
