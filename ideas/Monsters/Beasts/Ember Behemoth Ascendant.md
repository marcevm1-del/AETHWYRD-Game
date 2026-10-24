---
type: monster
id: mon_ember_behemoth_ascendant
family: "Beasts"
rank: "SSS+"
tier: variant
tags: [monster, beasts]
---
# Ember Behemoth Ascendant

> The Ember Behemoth Ascendant is a colossal creature with a heavy, muscular quadruped frame, about 40 m long. Its coat is rough, scarred and spiked, colored in ember reds fading to soot black. Look for a back that carries the ruins of a fortress it once trampled. It has eyes that catch torchlight like coins. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Behemoth Ascendant\|Behemoth Ascendant]] (elemental) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 40 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 147963 · 1423 · 1186 · 949 · 1067 · 100 |
| XP · gold | 26706 · 4286 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Water. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 26 m high × 40 m long × 6.4 m wide; prefab scale 10.
- **Physics:** 1280000 kg, gravity ×1.2, poise 487, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 30.77 m/s, turn 60°/s, stopping distance 8.4 m.
- **Attack count:** 5; **signature:** a back that carries the ruins of a fortress it once trampled.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ember Behemoth Ascendant is a **menacing beast** encountered at SSS+ rank, around level 294. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 4 | EX, EX+, EX- | 300–300 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 7 | EX+, SSS-, SSS+, EX-, SSS, EX | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03397` | Calamity Steppe Ember Behemoth Ascendant Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | EX | 300 | 50 m | Day & Night | Like a typical Ember Behemoth Ascendant, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_03398` | Moraveil Ember Behemoth Ascendant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | EX+ | 300 | 54 m | Day & Night | Like a typical Ember Behemoth Ascendant, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03399` | Moraveil Ember Behemoth Ascendant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | SSS- | 267 | 28 m | Day & Night | Like a typical Ember Behemoth Ascendant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03400` | Calamity Steppe Ember Behemoth Ascendant Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | EX+ | 300 | 54 m | Day & Night | Like a typical Ember Behemoth Ascendant, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_03401` | Moraveil Ember Behemoth Ascendant | [[Regions/Moraveil\|Moraveil]] | Adult | SSS+ | 294 | 40 m | Day & Night | A typical adult Ember Behemoth Ascendant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03402` | Moraveil Ember Behemoth Ascendant Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | EX- | 300 | 44 m | Day & Night | Like a typical Ember Behemoth Ascendant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03403` | Calamity Steppe Ember Behemoth Ascendant Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | EX- | 300 | 40 m | Day & Night | Like a typical Ember Behemoth Ascendant, but a rare pale form with white skin or fur and red eyes. |
| `pop_03404` | Calamity Steppe Ember Behemoth Ascendant Scarred | [[Regions/Calamity Steppe\|Calamity Steppe]] | Scarred | EX- | 300 | 44 m | Day & Night | Like a typical Ember Behemoth Ascendant, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_03405` | Moraveil Ember Behemoth Ascendant Albino | [[Regions/Moraveil\|Moraveil]] | Albino | EX- | 300 | 40 m | Day & Night | Like a typical Ember Behemoth Ascendant, but a rare pale form with white skin or fur and red eyes. |
| `pop_03406` | Moraveil Ember Behemoth Ascendant Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | SSS | 281 | 34 m | Day & Night | Like a typical Ember Behemoth Ascendant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03407` | Moraveil Ember Behemoth Ascendant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | EX | 300 | 50 m | Day & Night | Like a typical Ember Behemoth Ascendant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
