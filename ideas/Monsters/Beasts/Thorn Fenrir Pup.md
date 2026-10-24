---
type: monster
id: mon_thorn_fenrir_pup
family: "Beasts"
rank: "B+"
tier: variant
tags: [monster, beasts]
---
# Thorn Fenrir Pup

![[mon_thorn_fenrir_pup_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thorn_fenrir_pup_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,832 tris · 0.387 × 1.5 × 0.872 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thorn Fenrir Pup is a person-sized creature with a heavy, muscular quadruped frame, about 1.5 m long. Its coat is weathered and natural, colored in leaf greens over bark brown. Look for frosted fur and breath that freezes the air. It has amber predator eyes. Faint runes glow along its body when it fights. It prowls, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Frost Fenrir Pup\|Frost Fenrir Pup]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 1.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14975 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Ashira Vale\|Ashira Vale]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.98 m high × 1.5 m long × 0.24 m wide; prefab scale 0.375.
- **Physics:** 67.5 kg, gravity ×1.2, poise 69, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 4.73 m/s, turn 261°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** frosted fur and breath that freezes the air.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thorn Fenrir Pup is a **wild beast** encountered at B+ rank, around level 120. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frosted fur and breath that freezes the air. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Ashira Vale|Ashira Vale]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts B|loot_beast_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Ashira Vale\|Ashira Vale]] | 4 | B, A+, A, B- | 96–159 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | A-, B+, A+, B- | 96–159 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | A-, A, B+ | 120–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03357` | Ashira Vale Thorn Fenrir Pup Juvenile | [[Regions/Ashira Vale\|Ashira Vale]] | Juvenile | B | 108 | 1.27 m | Day & Night | Like a typical Thorn Fenrir Pup, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03358` | Ashira Vale Thorn Fenrir Pup Elderborn | [[Regions/Ashira Vale\|Ashira Vale]] | Elderborn | A+ | 159 | 2.03 m | Day & Night | Like a typical Thorn Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03359` | Strife Marches Thorn Fenrir Pup Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | A- | 132 | 1.5 m | Day & Night | Like a typical Thorn Fenrir Pup, but a rare pale form with white skin or fur and red eyes. |
| `pop_03360` | Strife Marches Thorn Fenrir Pup | [[Regions/Strife Marches\|Strife Marches]] | Adult | B+ | 120 | 1.5 m | Day & Night | A typical adult Thorn Fenrir Pup of this region, with golden, grass-toned coloring. |
| `pop_03361` | Shen-Lu Thorn Fenrir Pup Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | A- | 132 | 1.65 m | Day & Night | Like a typical Thorn Fenrir Pup, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03362` | Ashira Vale Thorn Fenrir Pup Alpha | [[Regions/Ashira Vale\|Ashira Vale]] | Alpha | A | 146 | 1.88 m | Day & Night | Like a typical Thorn Fenrir Pup, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03363` | Shen-Lu Thorn Fenrir Pup Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A | 146 | 1.88 m | Day & Night | Like a typical Thorn Fenrir Pup, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_03364` | Ashira Vale Thorn Fenrir Pup Runt | [[Regions/Ashira Vale\|Ashira Vale]] | Runt | B- | 96 | 1.05 m | Day & Night | Like a typical Thorn Fenrir Pup, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03365` | Strife Marches Thorn Fenrir Pup Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A+ | 159 | 2.03 m | Day & Night | Like a typical Thorn Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03366` | Strife Marches Thorn Fenrir Pup Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | B- | 96 | 1.05 m | Day & Night | Like a typical Thorn Fenrir Pup, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03367` | Shen-Lu Thorn Fenrir Pup | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B+ | 120 | 1.5 m | Day & Night | A typical adult Thorn Fenrir Pup of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
