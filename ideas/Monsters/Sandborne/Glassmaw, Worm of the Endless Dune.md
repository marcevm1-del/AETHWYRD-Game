---
type: monster
id: mon_glassmaw_worm_of_the_endless_dune
family: "Sandborne"
rank: "A+"
tier: core
tags: [monster, sandborne, tyrant, unique]
---
# Glassmaw, Worm of the Endless Dune

![[mon_glassmaw_worm_of_the_endless_dune_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_glassmaw_worm_of_the_endless_dune_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,584 tris · 18.634 × 70 × 26.632 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Glassmaw, Worm of the Endless Dune is a colossal creature with a massive snake-like frame, about 70 m long. Its sand-scoured hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a round mouth ringed with teeth of desert glass. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 70 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 51050 · 646 · 517 · 452 · 517 · 135 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Tyrant | Yes |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 2.8 m high × 70 m long × 7 m wide; prefab scale 17.5.
- **Physics:** 1025570 kg, gravity ×1.32, poise 9757, knockback resistance 0.7, death style `limp_chain`.
- **Navigation:** speed 21.48 m/s, turn 60°/s, stopping distance 2.85 m.
- **Attack count:** 5; **signature:** a round mouth ringed with teeth of desert glass.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Glassmaw, Worm of the Endless Dune is a **menacing desert beast** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a round mouth ringed with teeth of desert glass. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dunewhale Drift|Dunewhale Drift]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne A|loot_sandborne_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06737` | Glassmaw, Worm of the Endless Dune | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Unique | A+ | 159 | 70 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
