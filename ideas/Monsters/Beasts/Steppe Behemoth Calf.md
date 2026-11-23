---
type: monster
id: mon_steppe_behemoth_calf
family: "Beasts"
rank: "A-"
tier: variant
tags: [monster, beasts]
---
# Steppe Behemoth Calf

![[mon_steppe_behemoth_calf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_steppe_behemoth_calf_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 1.828 × 4 × 2.89 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_steppe_behemoth_calf.fbx`

> The Steppe Behemoth Calf is a large creature with a heavy, muscular quadruped frame, about 4 m long. Its coat is weathered and natural, colored in warm brown, with pale jade markings. Guild sketches always show a stone-plated back and stump-like legs. It has alert animal eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It stalks low to the ground, surrounded by swirling leaves and a constant breeze. Adapted to steppe lands, it has wind-burnt coloring and a lean frame.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Behemoth Calf\|Behemoth Calf]] (regional) |
| Rank · level | A- · 132 (120–146) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 24051 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Bastion\|Bastion]], [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.6 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 1152 kg, gravity ×0.96, poise 123, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 8.34 m/s, turn 160°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a stone-plated back and stump-like legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Steppe Behemoth Calf is a **wild beast** encountered at A- rank, around level 132. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-plated back and stump-like legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Bastion|Bastion]], [[Regions/Calamity Steppe|Calamity Steppe]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts A|loot_beast_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Bastion\|Bastion]] | 5 | A, B+, S-, B, A- | 108–173 | Day & Night |
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 6 | B, S-, A-, A, A+ | 108–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06209` | Bastion Steppe Behemoth Calf Scarred | [[Regions/Bastion\|Bastion]] | Scarred | A | 146 | 4.4 m | Day & Night | Like a typical Steppe Behemoth Calf, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_06210` | Calamity Steppe Steppe Behemoth Calf Runt | [[Regions/Calamity Steppe\|Calamity Steppe]] | Runt | B | 108 | 2.8 m | Day & Night | Like a typical Steppe Behemoth Calf, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_06211` | Calamity Steppe Steppe Behemoth Calf Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | S- | 173 | 5.4 m | Day & Night | Like a typical Steppe Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_06212` | Calamity Steppe Steppe Behemoth Calf | [[Regions/Calamity Steppe\|Calamity Steppe]] | Adult | A- | 132 | 4 m | Day & Night | A typical adult Steppe Behemoth Calf of this region, with wind-burnt coloring and a lean frame. |
| `pop_06213` | Bastion Steppe Behemoth Calf Juvenile | [[Regions/Bastion\|Bastion]] | Juvenile | B+ | 120 | 3.4 m | Day & Night | Like a typical Steppe Behemoth Calf, but young, with brighter colors and unworn features, with wind-burnt coloring and a lean frame. |
| `pop_06214` | Calamity Steppe Steppe Behemoth Calf Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | A | 146 | 4 m | Day & Night | Like a typical Steppe Behemoth Calf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06215` | Calamity Steppe Steppe Behemoth Calf Scarred | [[Regions/Calamity Steppe\|Calamity Steppe]] | Scarred | A | 146 | 4.4 m | Day & Night | Like a typical Steppe Behemoth Calf, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_06216` | Bastion Steppe Behemoth Calf Elderborn | [[Regions/Bastion\|Bastion]] | Elderborn | S- | 173 | 5.4 m | Day & Night | Like a typical Steppe Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_06217` | Bastion Steppe Behemoth Calf Runt | [[Regions/Bastion\|Bastion]] | Runt | B | 108 | 2.8 m | Day & Night | Like a typical Steppe Behemoth Calf, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_06218` | Calamity Steppe Steppe Behemoth Calf Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | A+ | 159 | 5 m | Day & Night | Like a typical Steppe Behemoth Calf, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_06219` | Bastion Steppe Behemoth Calf | [[Regions/Bastion\|Bastion]] | Adult | A- | 132 | 4 m | Day & Night | A typical adult Steppe Behemoth Calf of this region, with wind-burnt coloring and a lean frame. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `wind_ribbons` · palette `#7f6541` `#523f2c` `#8fe0bd` · real-animal silhouette with one fantasy exaggeration
