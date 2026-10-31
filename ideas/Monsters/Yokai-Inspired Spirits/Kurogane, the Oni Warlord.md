---
type: monster
id: mon_kurogane_the_oni_warlord
family: "Yokai-Inspired Spirits"
rank: "A+"
tier: core
tags: [monster, yokai-inspired-spirits, tyrant, unique]
---
# Kurogane, the Oni Warlord

![[mon_kurogane_the_oni_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kurogane_the_oni_warlord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,498 tris · 3.865 × 2.222 × 4.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kurogane, the Oni Warlord is a large creature with a towering, heavy-limbed body, about 4.5 m tall. Its form is rough, scarred and spiked, colored in lacquer red, with ember-orange markings. Guild sketches always show an iron club wrapped in torn prayer chains and a mask of red lacquer. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 41992 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 199864 · 1815 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]] |
| Tyrant | Yes |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 4.5 m high × 1.35 m long × 1.89 m wide; prefab scale 1.286.
- **Physics:** 1640.3 kg, gravity ×1.3, poise 319, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 7.12 m/s, turn 179°/s, stopping distance 1.3 m.
- **Attack count:** 5; **signature:** an iron club wrapped in torn prayer chains and a mask of red lacquer.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kurogane, the Oni Warlord is a **menacing spirit** encountered at A+ rank, around level 159. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an iron club wrapped in torn prayer chains and a mask of red lacquer. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Hoshizora\|Hoshizora]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06726` | Kurogane, the Oni Warlord | [[Regions/Hoshizora\|Hoshizora]] | Unique | A+ | 159 | 4.5 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#a65737` `#683826` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
