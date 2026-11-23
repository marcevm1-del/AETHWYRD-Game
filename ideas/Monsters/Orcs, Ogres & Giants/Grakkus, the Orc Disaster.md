---
type: monster
id: mon_grakkus_the_orc_disaster
family: "Orcs, Ogres & Giants"
rank: "S-"
tier: core
tags: [monster, orcs-ogres-giants, tyrant, unique]
---
# Grakkus, the Orc Disaster

![[mon_grakkus_the_orc_disaster_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_grakkus_the_orc_disaster_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 5.316 × 2.477 × 4.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_grakkus_the_orc_disaster.fbx`

> The Grakkus, the Orc Disaster is a large creature with a towering, heavy-limbed body, about 4.5 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with violet markings. Guild sketches always show a body swollen with devoured power and a crown of goblin bones. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | S- · 173 (159–188) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 4.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 47639 · 702 · 1053 · 421 · 702 · 70 |
| XP · gold | 228733 · 2042 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.5 m high × 1.35 m long × 1.89 m wide; prefab scale 1.286.
- **Physics:** 1640.3 kg, gravity ×1.3, poise 347, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 7.86 m/s, turn 179°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** a body swollen with devoured power and a crown of goblin bones.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grakkus, the Orc Disaster is a **menacing giant** encountered at S- rank, around level 173. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body swollen with devoured power and a crown of goblin bones. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 1 | S- | 173–173 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06723` | Grakkus, the Orc Disaster | [[Regions/Moraveil\|Moraveil]] | Unique | S- | 173 | 4.5 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `shadow_wisps` · palette `#82954f` `#576435` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
