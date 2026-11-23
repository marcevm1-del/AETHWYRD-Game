---
type: monster
id: mon_roc
family: "Avians"
rank: "A"
tier: core
tags: [monster, avians]
---
# Roc

![[mon_roc_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_roc_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 14.876 × 36.558 × 30 m · local file `Game/Assets/_Game/Art/Models/Monsters/Avians/mon_roc.fbx`

> The Roc is a colossal creature with a tall, long-legged bird build, about 30 m tall. Its plumage is rough, scarred and spiked, colored in pale buff, with pale jade markings. Survivors describe a shadow as big as a cloud. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 30 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37651 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Heavenreach\|Heavenreach]], [[Regions/Stormreach\|Stormreach]], [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 13.8 m high × 30 m long × 51.6 m wide; prefab scale 50.
- **Physics:** 340200 kg, gravity ×0.8, poise 9739, knockback resistance 0.2, death style `tumble_feathers_burst`.
- **Navigation:** speed 18.53 m/s, turn 110°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a shadow as big as a cloud.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Roc is a **menacing avian** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shadow as big as a cloud. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Heavenreach|Heavenreach]], [[Regions/Stormreach|Stormreach]], [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians A|loot_avian_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Avians/Cloud Roc|Cloud Roc]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Heavenreach\|Heavenreach]] | 3 | B+, S, A+ | 120–188 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | S, A+, S- | 159–188 | Day & Night |
| [[Regions/Quaking Lands\|Quaking Lands]] | 4 | A-, S, S-, A+ | 132–188 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 1 | A+ | 159–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02118` | Heavenreach Roc Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | B+ | 120 | 21 m | Day & Night | Like a typical Roc, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02119` | Hoshizora Roc Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S | 188 | 40.5 m | Day & Night | Like a typical Roc, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02120` | Quaking Lands Roc Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | A- | 132 | 25.5 m | Day & Night | Like a typical Roc, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02121` | Hoshizora Roc Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A+ | 159 | 33 m | Day & Night | Like a typical Roc, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02122` | Stormreach Roc Albino | [[Regions/Stormreach\|Stormreach]] | Albino | A+ | 159 | 30 m | Day & Night | Like a typical Roc, but a rare pale form with white skin or fur and red eyes. |
| `pop_02123` | Quaking Lands Roc Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | S | 188 | 40.5 m | Day & Night | Like a typical Roc, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02124` | Quaking Lands Roc Alpha | [[Regions/Quaking Lands\|Quaking Lands]] | Alpha | S- | 173 | 37.5 m | Day & Night | Like a typical Roc, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02125` | Heavenreach Roc Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | S | 188 | 40.5 m | Day & Night | Like a typical Roc, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02126` | Heavenreach Roc Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | A+ | 159 | 33 m | Day & Night | Like a typical Roc, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02127` | Hoshizora Roc Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S- | 173 | 37.5 m | Day & Night | Like a typical Roc, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02128` | Quaking Lands Roc Scarred | [[Regions/Quaking Lands\|Quaking Lands]] | Scarred | A+ | 159 | 33 m | Day & Night | Like a typical Roc, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#cfc6a0` `#8f8564` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
