---
type: monster
id: mon_lumen_eater_the_abyss_angler
family: "Aquatic"
rank: "A+"
tier: core
tags: [monster, aquatic, tyrant, unique]
---
# Lumen-Eater, the Abyss Angler

![[mon_lumen_eater_the_abyss_angler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lumen_eater_the_abyss_angler_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,490 tris · 4.247 × 12 × 7.312 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Lumen-Eater, the Abyss Angler is a huge creature with a heavy-jawed fish frame, about 12 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a lure of stolen moonlight dangling over a mouth of glass teeth. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 12 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40104 · 808 · 581 · 581 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Hollow Sea\|Hollow Sea]] |
| Tyrant | Yes |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 4.8 m high × 12 m long × 4.32 m wide; prefab scale 8.
- **Physics:** 39744 kg, gravity ×1, poise 2112, knockback resistance 0.45, death style `float_belly_up`.
- **Navigation:** speed 16.05 m/s, turn 115°/s, stopping distance 1.84 m.
- **Attack count:** 5; **signature:** a lure of stolen moonlight dangling over a mouth of glass teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lumen-Eater, the Abyss Angler is a **dread aquatic** encountered at A+ rank, around level 159. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lure of stolen moonlight dangling over a mouth of glass teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hollow Sea|Hollow Sea]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic A|loot_aquatic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hollow Sea\|Hollow Sea]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06742` | Lumen-Eater, the Abyss Angler | [[Regions/Hollow Sea\|Hollow Sea]] | Unique | A+ | 159 | 12 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
