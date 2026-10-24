---
type: monster
id: mon_raikaru_the_storm_roc
family: "Avians"
rank: "S"
tier: core
tags: [monster, avians, tyrant, unique]
---
# Raikaru, the Storm Roc

![[mon_raikaru_the_storm_roc_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_raikaru_the_storm_roc_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,822 tris · 33.058 × 26.029 × 35 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Raikaru, the Storm Roc is a colossal creature with a tall, long-legged bird build, about 35 m tall. Its plumage is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe wings that carry the weekly world-storm on their back. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 35 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 56869 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 261258 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Stormreach\|Stormreach]] |
| Tyrant | Yes |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 16.1 m high × 35 m long × 60.2 m wide; prefab scale 58.333.
- **Physics:** 600250 kg, gravity ×1, poise 16037, knockback resistance 0.23, death style `tumble_feathers_burst`.
- **Navigation:** speed 18.2 m/s, turn 101°/s, stopping distance 7.4 m.
- **Attack count:** 5; **signature:** wings that carry the weekly world-storm on their back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Raikaru, the Storm Roc is a **menacing avian** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that carry the weekly world-storm on their back. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians S|loot_avian_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06740` | Raikaru, the Storm Roc | [[Regions/Stormreach\|Stormreach]] | Unique | S | 188 | 35 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
