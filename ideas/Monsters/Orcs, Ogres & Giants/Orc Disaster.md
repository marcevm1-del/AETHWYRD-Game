---
type: monster
id: mon_orc_disaster
family: "Orcs, Ogres & Giants"
rank: "S"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Disaster

![[mon_orc_disaster_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_orc_disaster_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 4.764 × 2.405 × 4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_orc_disaster.fbx`

> The Orc Disaster is a large creature with a giant, barrel-chested humanoid body, about 4 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with violet markings. Look for a body bloated with devoured power and a crown of bones. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 51934 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.143.
- **Physics:** 1152 kg, gravity ×1.3, poise 284, knockback resistance 0.93, death style `heavy_fall_dust`.
- **Navigation:** speed 7.06 m/s, turn 190°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a body bloated with devoured power and a crown of bones.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Orc Disaster is a **menacing giant** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body bloated with devoured power and a crown of bones. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants S|loot_orc_giant_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Elder Orc Disaster|Elder Orc Disaster]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | S+, A+, S, S-, SS-, SS | 159–236 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | S, S+, S-, A+ | 159–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01171` | Nox Dominion Orc Disaster Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 4.4 m | Day & Night | Like a typical Orc Disaster, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_01172` | Moraveil Orc Disaster | [[Regions/Moraveil\|Moraveil]] | Adult | S | 188 | 4 m | Day & Night | A typical adult Orc Disaster of this region, with golden, grass-toned coloring. |
| `pop_01173` | Moraveil Orc Disaster Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | S+ | 203 | 4.4 m | Day & Night | Like a typical Orc Disaster, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01174` | Nox Dominion Orc Disaster Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 2.8 m | Day & Night | Like a typical Orc Disaster, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_01175` | Nox Dominion Orc Disaster | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 4 m | Day & Night | A typical adult Orc Disaster of this region, with ash-dark coloring with glowing cracks. |
| `pop_01176` | Nox Dominion Orc Disaster Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 3.4 m | Day & Night | Like a typical Orc Disaster, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_01177` | Moraveil Orc Disaster Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S- | 173 | 3.4 m | Day & Night | Like a typical Orc Disaster, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01178` | Moraveil Orc Disaster Albino | [[Regions/Moraveil\|Moraveil]] | Albino | S+ | 203 | 4 m | Day & Night | Like a typical Orc Disaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_01179` | Nox Dominion Orc Disaster Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 5 m | Day & Night | Like a typical Orc Disaster, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_01180` | Moraveil Orc Disaster Runt | [[Regions/Moraveil\|Moraveil]] | Runt | A+ | 159 | 2.8 m | Day & Night | Like a typical Orc Disaster, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01181` | Nox Dominion Orc Disaster Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS | 236 | 5.4 m | Day & Night | Like a typical Orc Disaster, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `shadow_wisps` · palette `#768a49` `#4f5d31` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
