---
type: monster
id: mon_aquilon_the_roc_sovereign
family: "Avians"
rank: "S"
tier: core
tags: [monster, avians, tyrant, unique]
---
# Aquilon, the Roc Sovereign

![[mon_aquilon_the_roc_sovereign_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_aquilon_the_roc_sovereign_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,172 tris · 18.824 × 62.356 × 40 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Aquilon, the Roc Sovereign is a colossal creature with a feathered avian body, about 40 m tall. Its plumage is rough, scarred and spiked, colored in crow-black, with pale jade markings. Look for a shadow as big as a cloud over the plateau. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 40 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 58539 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]] |
| Tyrant | Yes |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 18.4 m high × 40 m long × 68.8 m wide; prefab scale 66.667.
- **Physics:** 806400 kg, gravity ×0.8, poise 19000, knockback resistance 0.23, death style `tumble_feathers_burst`.
- **Navigation:** speed 19.45 m/s, turn 95°/s, stopping distance 8.4 m.
- **Attack count:** 5; **signature:** a shadow as big as a cloud over the plateau.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Aquilon, the Roc Sovereign is a **menacing avian** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shadow as big as a cloud over the plateau. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Heavenreach\|Heavenreach]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06745` | Aquilon, the Roc Sovereign | [[Regions/Heavenreach\|Heavenreach]] | Unique | S | 188 | 40 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#53515d` `#44424b` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
