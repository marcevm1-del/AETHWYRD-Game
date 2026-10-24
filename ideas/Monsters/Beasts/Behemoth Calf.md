---
type: monster
id: mon_behemoth_calf
family: "Beasts"
rank: "B+"
tier: core
tags: [monster, beasts]
---
# Behemoth Calf

![[mon_behemoth_calf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_behemoth_calf_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Behemoth Calf is a large creature with a powerful four-legged hunter's body, about 4 m long. Its coat is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is a stone-plated back and stump-like legs. It has dark, wary eyes. Faint runes glow along its body when it fights. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20861 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Frostveil\|Frostveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.6 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 1664 kg, gravity ×1.32, poise 112, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.1 m/s, turn 160°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a stone-plated back and stump-like legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Behemoth Calf is a **wild beast** encountered at B+ rank, around level 120. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-plated back and stump-like legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Frostveil|Frostveil]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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

- [[Monsters/Beasts/Elder Behemoth Calf|Elder Behemoth Calf]]
- [[Monsters/Beasts/Steppe Behemoth Calf|Steppe Behemoth Calf]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | B, A+, A- | 108–159 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 3 | A, B+, A+ | 120–159 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B+, A, B- | 96–146 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | A-, B- | 96–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00464` | Shen-Lu Behemoth Calf Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B | 108 | 3.4 m | Day & Night | Like a typical Behemoth Calf, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00465` | Frostveil Behemoth Calf Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | A | 146 | 5 m | Day & Night | Like a typical Behemoth Calf, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_00466` | Frostveil Behemoth Calf | [[Regions/Frostveil\|Frostveil]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Behemoth Calf of this region, with a thick, frost-rimed coat. |
| `pop_00467` | Shen-Lu Behemoth Calf Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A+ | 159 | 5.4 m | Day & Night | Like a typical Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00468` | Hoshizora Behemoth Calf | [[Regions/Hoshizora\|Hoshizora]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Behemoth Calf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00469` | Vharlen Behemoth Calf Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | A- | 132 | 4.4 m | Day & Night | Like a typical Behemoth Calf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00470` | Shen-Lu Behemoth Calf Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A- | 132 | 4 m | Day & Night | Like a typical Behemoth Calf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00471` | Frostveil Behemoth Calf Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | A+ | 159 | 5.4 m | Day & Night | Like a typical Behemoth Calf, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_00472` | Hoshizora Behemoth Calf Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A | 146 | 5 m | Day & Night | Like a typical Behemoth Calf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00473` | Hoshizora Behemoth Calf Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Behemoth Calf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00474` | Vharlen Behemoth Calf Runt | [[Regions/Vharlen\|Vharlen]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Behemoth Calf, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
