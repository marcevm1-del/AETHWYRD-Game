---
type: monster
id: mon_the_hollow_bride_matriarch_of_the_long_necks
family: "Yokai-Inspired Spirits"
rank: "A"
tier: core
tags: [monster, yokai-inspired-spirits, tyrant, unique]
---
# The Hollow Bride, Matriarch of the Long Necks

![[mon_the_hollow_bride_matriarch_of_the_long_necks_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_hollow_bride_matriarch_of_the_long_necks_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 2.244 × 2.209 × 2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Yokai-Inspired Spirits/mon_the_hollow_bride_matriarch_of_the_long_necks.fbx`

> The The Hollow Bride, Matriarch of the Long Necks is a person-sized creature with a shape that keeps rearranging itself, about 2 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in indigo, with violet markings. Its most striking feature is a wedding veil over a neck that stretches across rooftops. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20132 · 743 · 535 · 535 · 535 · 100 |
| XP · gold | 174387 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Tyrant | Yes |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2 m high × 2.14 m long × 2.1 m wide; prefab scale 1.
- **Physics:** 240 kg, gravity ×1.2, poise 125, knockback resistance 0.75, death style `collapse_and_melt`.
- **Navigation:** speed 6.25 m/s, turn 354°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a wedding veil over a neck that stretches across rooftops.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Hollow Bride, Matriarch of the Long Necks is a **dread spirit** encountered at A rank, around level 146. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wedding veil over a neck that stretches across rooftops. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits A|loot_yokai_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 1 | A | 146–146 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06727` | The Hollow Bride, Matriarch of the Long Necks | [[Regions/Kitsune Isles\|Kitsune Isles]] | Unique | A | 146 | 2 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#505783` `#3a3e5c` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
