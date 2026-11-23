---
type: monster
id: mon_thrakka_sabretooth_khan_of_the_steppe_horde
family: "Beasts"
rank: "S"
tier: core
tags: [monster, beasts, tyrant, unique]
---
# Thrakka, Sabretooth Khan of the Steppe Horde

![[mon_thrakka_sabretooth_khan_of_the_steppe_horde_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thrakka_sabretooth_khan_of_the_steppe_horde_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 0.84 × 4.001 × 2.062 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_thrakka_sabretooth_khan_of_the_steppe_horde.fbx`

> The Thrakka, Sabretooth Khan of the Steppe Horde is a large creature with a long-legged predatory quadruped build, about 4 m long. Its coat is rough, scarred and spiked, colored in cream, with frost-blue markings. Guild sketches always show two sabre fangs as long as spears and a horde that follows its howl. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40805 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Bastion\|Bastion]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.6 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 1408 kg, gravity ×1.26, poise 153, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.1 m/s, turn 160°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** two sabre fangs as long as spears and a horde that follows its howl.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thrakka, Sabretooth Khan of the Steppe Horde is a **menacing beast** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** two sabre fangs as long as spears and a horde that follows its howl. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Bastion|Bastion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts S|loot_beast_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Bastion\|Bastion]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06749` | Thrakka, Sabretooth Khan of the Steppe Horde | [[Regions/Bastion\|Bastion]] | Unique | S | 188 | 4 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `frost_trail_snow` · palette `#ded5ad` `#9f9473` `#9fdcff` · triangle-based silhouette, sharp asymmetric spikes
