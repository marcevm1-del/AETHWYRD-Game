---
type: monster
id: mon_vel_thara_the_web_queen
family: "Insects & Arachnids"
rank: "B+"
tier: core
tags: [monster, insects-arachnids, tyrant, unique]
---
# Vel'thara, the Web Queen

![[mon_vel_thara_the_web_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vel_thara_the_web_queen_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,999 tris · 3.54 × 4 × 1.651 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_vel_thara_the_web_queen.fbx`

> The Vel'thara, the Web Queen is a large creature with an eight-legged arachnid body, about 4 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in amber, with violet markings. Its most striking feature is a crown of spider-silk and eight jeweled eyes above Umbravel's markets. It has eyes that never blink. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16120 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 127464 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Umbravel\|Umbravel]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 1.12 m high × 4 m long × 2.74 m wide; prefab scale 4.
- **Physics:** 2112 kg, gravity ×1.4, poise 489, knockback resistance 0.32, death style `flip_legs_curl`.
- **Navigation:** speed 10.19 m/s, turn 300°/s, stopping distance 1.4 m.
- **Attack count:** 5; **signature:** a crown of spider-silk and eight jeweled eyes above Umbravel's markets.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vel'thara, the Web Queen is a **dread insectoid** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of spider-silk and eight jeweled eyes above Umbravel's markets. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids B|loot_insect_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06732` | Vel'thara, the Web Queen | [[Regions/Umbravel\|Umbravel]] | Unique | B+ | 120 | 4 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#c0842e` `#7a521c` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
