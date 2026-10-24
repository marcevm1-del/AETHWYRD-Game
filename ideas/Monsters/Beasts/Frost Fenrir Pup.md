---
type: monster
id: mon_frost_fenrir_pup
family: "Beasts"
rank: "B"
tier: core
tags: [monster, beasts]
---
# Frost Fenrir Pup

![[mon_frost_fenrir_pup_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_fenrir_pup_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Fenrir Pup is a person-sized creature with a heavy, muscular quadruped frame, about 1.5 m long. Its coat is weathered and natural, colored in pale blues and frost-white. Look for frosted fur and breath that freezes the air. It has dark, wary eyes. Faint runes glow along its body when it fights. It stalks low to the ground, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 1.5 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12797 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Frostveil\|Frostveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.98 m high × 1.5 m long × 0.24 m wide; prefab scale 0.375.
- **Physics:** 74.3 kg, gravity ×1.26, poise 69, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 4.97 m/s, turn 261°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** frosted fur and breath that freezes the air.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Fenrir Pup is a **wild beast** encountered at B rank, around level 108. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frosted fur and breath that freezes the air. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Frostveil|Frostveil]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts B|loot_beast_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Beasts/Thorn Fenrir Pup|Thorn Fenrir Pup]]
- [[Monsters/Beasts/Steppe Fenrir Pup|Steppe Fenrir Pup]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 5 | B-, A, B+, A-, C+ | 86–146 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | A-, A, B, B+, C+ | 86–146 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | B+ | 120–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00453` | Frostveil Frost Fenrir Pup Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | B- | 96 | 1.27 m | Day & Night | Like a typical Frost Fenrir Pup, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_00454` | Shen-Lu Frost Fenrir Pup Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A- | 132 | 1.88 m | Day & Night | Like a typical Frost Fenrir Pup, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00455` | Shen-Lu Frost Fenrir Pup Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A | 146 | 2.03 m | Day & Night | Like a typical Frost Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00456` | Frostveil Frost Fenrir Pup Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | A | 146 | 2.03 m | Day & Night | Like a typical Frost Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_00457` | Shen-Lu Frost Fenrir Pup | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B | 108 | 1.5 m | Day & Night | A typical adult Frost Fenrir Pup of this region, with slate-grey coloring and hardened hide. |
| `pop_00458` | Shen-Lu Frost Fenrir Pup Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B+ | 120 | 1.5 m | Day & Night | Like a typical Frost Fenrir Pup, but a rare pale form with white skin or fur and red eyes. |
| `pop_00459` | Shen-Lu Frost Fenrir Pup Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C+ | 86 | 1.05 m | Day & Night | Like a typical Frost Fenrir Pup, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00460` | Frostveil Frost Fenrir Pup Scarred | [[Regions/Frostveil\|Frostveil]] | Scarred | B+ | 120 | 1.65 m | Day & Night | Like a typical Frost Fenrir Pup, but covered in old battle scars, with a thick, frost-rimed coat. |
| `pop_00461` | Hoshizora Frost Fenrir Pup Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B+ | 120 | 1.5 m | Day & Night | Like a typical Frost Fenrir Pup, but a rare pale form with white skin or fur and red eyes. |
| `pop_00462` | Frostveil Frost Fenrir Pup Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | A- | 132 | 1.88 m | Day & Night | Like a typical Frost Fenrir Pup, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_00463` | Frostveil Frost Fenrir Pup Runt | [[Regions/Frostveil\|Frostveil]] | Runt | C+ | 86 | 1.05 m | Day & Night | Like a typical Frost Fenrir Pup, but smaller and scrappier than usual, with a thick, frost-rimed coat. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
