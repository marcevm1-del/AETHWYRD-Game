---
type: monster
id: mon_behemoth_ascendant
family: "Beasts"
rank: "SSS"
tier: core
tags: [monster, beasts]
---
# Behemoth Ascendant

![[mon_behemoth_ascendant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_behemoth_ascendant_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 17.683 × 40.003 × 28.111 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_behemoth_ascendant.fbx`

> The Behemoth Ascendant is a colossal creature with a heavy, muscular quadruped frame, about 40 m long. Its coat is rough, scarred and spiked, colored in cream, with ochre markings. Guild sketches always show a back that carries the ruins of a fortress it once trampled. It has burning slit pupils. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 40 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 138271 · 1361 · 1134 · 907 · 1021 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 26 m high × 40 m long × 6.4 m wide; prefab scale 10.
- **Physics:** 1664000 kg, gravity ×1.32, poise 487, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 22.46 m/s, turn 60°/s, stopping distance 8.4 m.
- **Attack count:** 5; **signature:** a back that carries the ruins of a fortress it once trampled.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Behemoth Ascendant is a **menacing beast** encountered at SSS rank, around level 281. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a back that carries the ruins of a fortress it once trampled. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Calamity Steppe|Calamity Steppe]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts SSS|loot_beast_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Beasts/Ember Behemoth Ascendant|Ember Behemoth Ascendant]]
- [[Monsters/Beasts/Phantom Behemoth Ascendant|Phantom Behemoth Ascendant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 6 | SSS, EX-, SS+, EX, SSS+, SSS- | 253–300 | Day & Night |
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 5 | SSS, SSS+, SSS-, EX, EX- | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00497` | Moraveil Behemoth Ascendant | [[Regions/Moraveil\|Moraveil]] | Adult | SSS | 281 | 40 m | Day & Night | A typical adult Behemoth Ascendant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00498` | Calamity Steppe Behemoth Ascendant | [[Regions/Calamity Steppe\|Calamity Steppe]] | Adult | SSS | 281 | 40 m | Day & Night | A typical adult Behemoth Ascendant of this region, with wind-burnt coloring and a lean frame. |
| `pop_00499` | Calamity Steppe Behemoth Ascendant Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | SSS+ | 294 | 40 m | Day & Night | Like a typical Behemoth Ascendant, but a rare pale form with white skin or fur and red eyes. |
| `pop_00500` | Calamity Steppe Behemoth Ascendant Juvenile | [[Regions/Calamity Steppe\|Calamity Steppe]] | Juvenile | SSS- | 267 | 34 m | Day & Night | Like a typical Behemoth Ascendant, but young, with brighter colors and unworn features, with wind-burnt coloring and a lean frame. |
| `pop_00501` | Moraveil Behemoth Ascendant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | EX- | 300 | 50 m | Day & Night | Like a typical Behemoth Ascendant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00502` | Moraveil Behemoth Ascendant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | SS+ | 253 | 28 m | Day & Night | Like a typical Behemoth Ascendant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00503` | Moraveil Behemoth Ascendant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | EX | 300 | 54 m | Day & Night | Like a typical Behemoth Ascendant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00504` | Calamity Steppe Behemoth Ascendant Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | EX | 300 | 54 m | Day & Night | Like a typical Behemoth Ascendant, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_00505` | Moraveil Behemoth Ascendant Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SSS+ | 294 | 44 m | Day & Night | Like a typical Behemoth Ascendant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00506` | Moraveil Behemoth Ascendant Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | SSS- | 267 | 34 m | Day & Night | Like a typical Behemoth Ascendant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00507` | Calamity Steppe Behemoth Ascendant Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | EX- | 300 | 50 m | Day & Night | Like a typical Behemoth Ascendant, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#cbb59e` `#917c69` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
