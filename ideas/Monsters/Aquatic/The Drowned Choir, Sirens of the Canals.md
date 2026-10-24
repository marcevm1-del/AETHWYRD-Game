---
type: monster
id: mon_the_drowned_choir_sirens_of_the_canals
family: "Aquatic"
rank: "B"
tier: core
tags: [monster, aquatic, tyrant, unique]
---
# The Drowned Choir, Sirens of the Canals

![[mon_the_drowned_choir_sirens_of_the_canals_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_drowned_choir_sirens_of_the_canals_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (6,032 tris · 0.913 × 2 × 1.673 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Drowned Choir, Sirens of the Canals is a person-sized creature with an elegant serpentfolk build, about 2 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Survivors describe three sirens who sing in harmony; silence one and the song breaks. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14120 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 107715 · 1057 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Lirian\|Lirian]] |
| Tyrant | Yes |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 0.92 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 29 kg, gravity ×1.3, poise 39, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 2.94 m/s, turn 247°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** three sirens who sing in harmony; silence one and the song breaks.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Drowned Choir, Sirens of the Canals is a **dread aquatic** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** three sirens who sing in harmony; silence one and the song breaks. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic B|loot_aquatic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 1 | B | 108–108 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06720` | The Drowned Choir, Sirens of the Canals | [[Regions/Lirian\|Lirian]] | Unique | B | 108 | 2 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
