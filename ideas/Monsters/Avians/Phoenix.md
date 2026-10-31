---
type: monster
id: mon_phoenix
family: "Avians"
rank: "S"
tier: core
tags: [monster, avians]
---
# Phoenix

![[mon_phoenix_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phoenix_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,240 tris · 2.998 × 9.932 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phoenix is a huge creature with a broad-winged bird frame, about 6 m tall. Its plumage is smooth and clean, colored in pale buff, with ember-orange markings. Look for feathers of living flame that fall as embers. It has wide curious eyes with star-shaped highlights. Its regal silhouette is crowned by a halo-like ring of aura. It waddles, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | S · 188 (173–203) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 35850 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 2.76 m high × 6 m long × 10.32 m wide; prefab scale 10.
- **Physics:** 3024 kg, gravity ×1, poise 907, knockback resistance 0.23, death style `tumble_feathers_burst`.
- **Navigation:** speed 6.28 m/s, turn 245°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** feathers of living flame that fall as embers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phoenix is a **charming avian** encountered at S rank, around level 188. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** feathers of living flame that fall as embers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians S|loot_avian_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Avians/Vesper-Touched Phoenix|Vesper-Touched Phoenix]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 5 | SS, S+, S-, S | 173–236 | Day |
| [[Regions/Dragon Spine\|Dragon Spine]] | 6 | S+, SS, S, S-, SS-, A+ | 159–236 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02129` | Quaking Lands Phoenix Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | SS | 236 | 8.1 m | Day | Like a typical Phoenix, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02130` | Quaking Lands Phoenix Scarred | [[Regions/Quaking Lands\|Quaking Lands]] | Scarred | S+ | 203 | 6.6 m | Day | Like a typical Phoenix, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02131` | Quaking Lands Phoenix Albino | [[Regions/Quaking Lands\|Quaking Lands]] | Albino | S+ | 203 | 6 m | Day | Like a typical Phoenix, but a rare pale form with white skin or fur and red eyes. |
| `pop_02132` | Dragon Spine Phoenix Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S+ | 203 | 6 m | Day | Like a typical Phoenix, but a rare pale form with white skin or fur and red eyes. |
| `pop_02133` | Dragon Spine Phoenix Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | SS | 236 | 8.1 m | Day | Like a typical Phoenix, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02134` | Dragon Spine Phoenix | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | S | 188 | 6 m | Day | A typical adult Phoenix of this region, with slate-grey coloring and hardened hide. |
| `pop_02135` | Dragon Spine Phoenix Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | S- | 173 | 5.1 m | Day | Like a typical Phoenix, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02136` | Quaking Lands Phoenix Juvenile | [[Regions/Quaking Lands\|Quaking Lands]] | Juvenile | S- | 173 | 5.1 m | Day | Like a typical Phoenix, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02137` | Dragon Spine Phoenix Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | SS- | 218 | 7.5 m | Day | Like a typical Phoenix, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02138` | Dragon Spine Phoenix Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | A+ | 159 | 4.2 m | Day | Like a typical Phoenix, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02139` | Quaking Lands Phoenix | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | S | 188 | 6 m | Day | A typical adult Phoenix of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `embers_heat_haze` · palette `#bbb390` `#81795a` `#ff7a3d` · circle-based, soft silhouette
