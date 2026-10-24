---
type: monster
id: mon_sabretooth_king
family: "Beasts"
rank: "A"
tier: core
tags: [monster, beasts]
---
# Sabretooth King

![[mon_sabretooth_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_sabretooth_king_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Sabretooth King is a large creature with a heavy, muscular quadruped frame, about 3.2 m long. Its coat is rough, scarred and spiked, colored in pale blues and frost-white. Look for two sabre fangs as long as swords. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3.2 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25975 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Frostveil\|Frostveil]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.08 m high × 3.2 m long × 0.51 m wide; prefab scale 0.8.
- **Physics:** 720.9 kg, gravity ×1.26, poise 110, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.62 m/s, turn 179°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** two sabre fangs as long as swords.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sabretooth King is a **menacing beast** encountered at A rank, around level 146. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** two sabre fangs as long as swords. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Frostveil|Frostveil]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts A|loot_beast_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Beasts/Ancient Sabretooth King|Ancient Sabretooth King]]
- [[Monsters/Beasts/Night Sabretooth King|Night Sabretooth King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | A+, B+, A- | 120–159 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 6 | A-, A+, S-, S, A | 132–188 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 1 | A- | 132–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00475` | Shen-Lu Sabretooth King Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | A+ | 159 | 3.52 m | Day & Night | Like a typical Sabretooth King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00476` | Shen-Lu Sabretooth King Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A+ | 159 | 3.2 m | Day & Night | Like a typical Sabretooth King, but a rare pale form with white skin or fur and red eyes. |
| `pop_00477` | Frostveil Sabretooth King Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | A- | 132 | 2.72 m | Day & Night | Like a typical Sabretooth King, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_00478` | Frostveil Sabretooth King Albino | [[Regions/Frostveil\|Frostveil]] | Albino | A+ | 159 | 3.2 m | Day & Night | Like a typical Sabretooth King, but a rare pale form with white skin or fur and red eyes. |
| `pop_00479` | Frostveil Sabretooth King Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | S- | 173 | 4 m | Day & Night | Like a typical Sabretooth King, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_00480` | Shen-Lu Sabretooth King Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B+ | 120 | 2.24 m | Day & Night | Like a typical Sabretooth King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00481` | Shen-Lu Sabretooth King Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A- | 132 | 2.72 m | Day & Night | Like a typical Sabretooth King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00482` | Frostveil Sabretooth King Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | S | 188 | 4.32 m | Day & Night | Like a typical Sabretooth King, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_00483` | Vharlen Sabretooth King Juvenile | [[Regions/Vharlen\|Vharlen]] | Juvenile | A- | 132 | 2.72 m | Day & Night | Like a typical Sabretooth King, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00484` | Frostveil Sabretooth King Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | A+ | 159 | 3.52 m | Day & Night | Like a typical Sabretooth King, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_00485` | Frostveil Sabretooth King | [[Regions/Frostveil\|Frostveil]] | Adult | A | 146 | 3.2 m | Day & Night | A typical adult Sabretooth King of this region, with a thick, frost-rimed coat. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
