---
type: monster
id: mon_silver_fenrir
family: "Beasts"
rank: "S"
tier: core
tags: [monster, beasts]
---
# Silver Fenrir

![[mon_silver_fenrir_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_silver_fenrir_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.768 × 6 × 3.709 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_silver_fenrir.fbx`

> The Silver Fenrir is a huge creature with a powerful four-legged hunter's body, about 6 m long. Its coat is weathered and natural, colored in warm brown, with gold markings. Its most striking feature is silver fur that glows like moonlight. It has alert animal eyes. Its regal silhouette is crowned by a halo-like ring of aura. It lopes in long strides, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 46394 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.9 m high × 6 m long × 0.96 m wide; prefab scale 1.5.
- **Physics:** 4104 kg, gravity ×1.08, poise 163, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.46 m/s, turn 131°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** silver fur that glows like moonlight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Silver Fenrir is a **wild beast** encountered at S rank, around level 188. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver fur that glows like moonlight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts S|loot_beast_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Beasts/Ancient Silver Fenrir|Ancient Silver Fenrir]]
- [[Monsters/Beasts/Night Silver Fenrir|Night Silver Fenrir]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 7 | S+, A+, S-, SS, SS-, S | 159–236 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 4 | A+, S-, S+ | 159–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00486` | Shen-Lu Silver Fenrir Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 6.6 m | Day & Night | Like a typical Silver Fenrir, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00487` | Shen-Lu Silver Fenrir Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Silver Fenrir, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00488` | Shen-Lu Silver Fenrir Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S- | 173 | 5.1 m | Day & Night | Like a typical Silver Fenrir, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00489` | Shen-Lu Silver Fenrir Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS | 236 | 8.1 m | Day & Night | Like a typical Silver Fenrir, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00490` | Heavenreach Silver Fenrir Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | A+ | 159 | 4.2 m | Day & Night | Like a typical Silver Fenrir, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00491` | Shen-Lu Silver Fenrir Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 7.5 m | Day & Night | Like a typical Silver Fenrir, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00492` | Heavenreach Silver Fenrir Juvenile | [[Regions/Heavenreach\|Heavenreach]] | Juvenile | S- | 173 | 5.1 m | Day & Night | Like a typical Silver Fenrir, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00493` | Heavenreach Silver Fenrir Scarred | [[Regions/Heavenreach\|Heavenreach]] | Scarred | S+ | 203 | 6.6 m | Day & Night | Like a typical Silver Fenrir, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00494` | Shen-Lu Silver Fenrir | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S | 188 | 6 m | Day & Night | A typical adult Silver Fenrir of this region, with slate-grey coloring and hardened hide. |
| `pop_00495` | Heavenreach Silver Fenrir Albino | [[Regions/Heavenreach\|Heavenreach]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Silver Fenrir, but a rare pale form with white skin or fur and red eyes. |
| `pop_00496` | Shen-Lu Silver Fenrir Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 6 m | Day & Night | Like a typical Silver Fenrir, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#886845` `#58412f` `#ffd166` · real-animal silhouette with one fantasy exaggeration
