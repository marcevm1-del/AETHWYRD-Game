---
type: monster
id: mon_varos_herald_of_the_red_gate
family: "Demons"
rank: "A+"
tier: core
tags: [monster, demons, tyrant, unique]
---
# Varos, Herald of the Red Gate

![[mon_varos_herald_of_the_red_gate_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_varos_herald_of_the_red_gate_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 1.523 × 2.205 × 3.001 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_varos_herald_of_the_red_gate.fbx`

> The Varos, Herald of the Red Gate is a large creature with a lean humanoid frame, about 3 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in brimstone red, with violet-edged markings. Guild sketches always show a demon who steps out of every Gate that opens in Haneul's towns. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28876 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 199864 · 1815 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Haneul\|Haneul]] |
| Tyrant | Yes |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 351 kg, gravity ×1.05, poise 130, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 5.46 m/s, turn 231°/s, stopping distance 0.91 m.
- **Attack count:** 5; **signature:** a demon who steps out of every Gate that opens in Haneul's towns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Varos, Herald of the Red Gate is a **dread demon** encountered at A+ rank, around level 159. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a demon who steps out of every Gate that opens in Haneul's towns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons A|loot_demon_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Haneul\|Haneul]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06730` | Varos, Herald of the Red Gate | [[Regions/Haneul\|Haneul]] | Unique | A+ | 159 | 3 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `void_distortion` · palette `#a13129` `#5a2826` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
