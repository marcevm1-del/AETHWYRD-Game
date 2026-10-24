---
type: monster
id: mon_night_silver_fenrir
family: "Beasts"
rank: "S+"
tier: variant
tags: [monster, beasts]
---
# Night Silver Fenrir

![[mon_night_silver_fenrir_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_night_silver_fenrir_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Night Silver Fenrir is a huge creature with a heavy, muscular quadruped frame, about 6 m long. Its coat is weathered and natural, colored in ink black with bruised violet. Guild sketches always show silver fur that glows like moonlight. It has alert animal eyes. Its regal silhouette is crowned by a halo-like ring of aura. It prowls, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Silver Fenrir\|Silver Fenrir]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52042 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.9 m high × 6 m long × 0.96 m wide; prefab scale 1.5.
- **Physics:** 4320 kg, gravity ×1.2, poise 163, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.93 m/s, turn 131°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** silver fur that glows like moonlight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Night Silver Fenrir is a **wild beast** encountered at S+ rank, around level 203. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver fur that glows like moonlight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts S|loot_beast_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 5 | SS-, SS+, S+, S- | 173–253 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | SS-, SS, S, S-, S+, SS+ | 173–253 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06231` | Quaking Lands Night Silver Fenrir Scarred | [[Regions/Quaking Lands\|Quaking Lands]] | Scarred | SS- | 218 | 6.6 m | Day & Night | Like a typical Night Silver Fenrir, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06232` | Moraveil Night Silver Fenrir Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SS- | 218 | 6.6 m | Day & Night | Like a typical Night Silver Fenrir, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06233` | Moraveil Night Silver Fenrir Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | SS | 236 | 7.5 m | Day & Night | Like a typical Night Silver Fenrir, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06234` | Quaking Lands Night Silver Fenrir Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | SS+ | 253 | 8.1 m | Day & Night | Like a typical Night Silver Fenrir, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06235` | Quaking Lands Night Silver Fenrir | [[Regions/Quaking Lands\|Quaking Lands]] | Adult | S+ | 203 | 6 m | Day & Night | A typical adult Night Silver Fenrir of this region, with slate-grey coloring and hardened hide. |
| `pop_06236` | Quaking Lands Night Silver Fenrir Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | S- | 173 | 4.2 m | Day & Night | Like a typical Night Silver Fenrir, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06237` | Quaking Lands Night Silver Fenrir Albino | [[Regions/Quaking Lands\|Quaking Lands]] | Albino | SS- | 218 | 6 m | Day & Night | Like a typical Night Silver Fenrir, but a rare pale form with white skin or fur and red eyes. |
| `pop_06238` | Moraveil Night Silver Fenrir Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | S | 188 | 5.1 m | Day & Night | Like a typical Night Silver Fenrir, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06239` | Moraveil Night Silver Fenrir Runt | [[Regions/Moraveil\|Moraveil]] | Runt | S- | 173 | 4.2 m | Day & Night | Like a typical Night Silver Fenrir, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06240` | Moraveil Night Silver Fenrir | [[Regions/Moraveil\|Moraveil]] | Adult | S+ | 203 | 6 m | Day & Night | A typical adult Night Silver Fenrir of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06241` | Moraveil Night Silver Fenrir Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | SS+ | 253 | 8.1 m | Day & Night | Like a typical Night Silver Fenrir, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
