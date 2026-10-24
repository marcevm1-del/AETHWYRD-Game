---
type: monster
id: mon_primeval_titan_kin
family: "Orcs, Ogres & Giants"
rank: "SSS"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Primeval Titan-Kin

![[mon_primeval_titan_kin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_primeval_titan_kin_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Primeval Titan-Kin is a colossal creature with a towering, heavy-limbed body, about 40 m tall. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a body of living bedrock wearing fragments of Titan armor. It has narrow glowing eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 40 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 175982 · 1134 · 1701 · 680 · 1134 · 70 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 40 m high × 12 m long × 16.8 m wide; prefab scale 11.429.
- **Physics:** 1497600 kg, gravity ×1.43, poise 1041, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 21.52 m/s, turn 60°/s, stopping distance 8.4 m.
- **Attack count:** 5; **signature:** a body of living bedrock wearing fragments of Titan armor.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Primeval Titan-Kin is a **menacing giant** encountered at SSS rank, around level 281. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of living bedrock wearing fragments of Titan armor. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants SSS|loot_orc_giant_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Elder Primeval Titan-Kin|Elder Primeval Titan-Kin]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | SSS+, SS+, SSS, EX-, EX, SSS- | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01182` | Nox Dominion Primeval Titan-Kin Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 40 m | Day & Night | Like a typical Primeval Titan-Kin, but a rare pale form with white skin or fur and red eyes. |
| `pop_01183` | Nox Dominion Primeval Titan-Kin Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 28 m | Day & Night | Like a typical Primeval Titan-Kin, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_01184` | Nox Dominion Primeval Titan-Kin | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS | 281 | 40 m | Day & Night | A typical adult Primeval Titan-Kin of this region, with ash-dark coloring with glowing cracks. |
| `pop_01185` | Nox Dominion Primeval Titan-Kin Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX- | 300 | 50 m | Day & Night | Like a typical Primeval Titan-Kin, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_01186` | Nox Dominion Primeval Titan-Kin Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 44 m | Day & Night | Like a typical Primeval Titan-Kin, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_01187` | Nox Dominion Primeval Titan-Kin Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 54 m | Day & Night | Like a typical Primeval Titan-Kin, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_01188` | Nox Dominion Primeval Titan-Kin Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 34 m | Day & Night | Like a typical Primeval Titan-Kin, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
