---
type: monster
id: mon_ancient_silver_fenrir
family: "Beasts"
rank: "SS"
tier: variant
tags: [monster, beasts]
---
# Ancient Silver Fenrir

![[mon_ancient_silver_fenrir_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_silver_fenrir_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,784 tris · 2.07 × 9 × 4.041 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Silver Fenrir is a huge creature with a powerful four-legged hunter's body, about 9 m long. Its coat is weathered and natural, colored in warm brown, with gold markings. Guild sketches always show silver fur that glows like moonlight. It has alert animal eyes. The air distorts slightly around its outline. It lopes in long strides, surrounded by soft radiance and floating motes of light. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Silver Fenrir\|Silver Fenrir]] (ancient) |
| Rank · level | SS · 236 (218–253) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 73530 · 1145 · 954 · 763 · 859 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Dark. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 5.85 m high × 9 m long × 1.44 m wide; prefab scale 2.25.
- **Physics:** 13851 kg, gravity ×1.08, poise 215, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 13.24 m/s, turn 107°/s, stopping distance 2.2 m.
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

Ancient Silver Fenrir is a **wild beast** encountered at SS rank, around level 236. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** silver fur that glows like moonlight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Calamity Steppe|Calamity Steppe]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts SS|loot_beast_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 7 | SS, SS-, SSS, S+, SSS-, SS+ | 203–281 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03390` | Calamity Steppe Ancient Silver Fenrir | [[Regions/Calamity Steppe\|Calamity Steppe]] | Adult | SS | 236 | 9 m | Day & Night | A typical adult Ancient Silver Fenrir of this region, with wind-burnt coloring and a lean frame. |
| `pop_03391` | Calamity Steppe Ancient Silver Fenrir Juvenile | [[Regions/Calamity Steppe\|Calamity Steppe]] | Juvenile | SS- | 218 | 7.65 m | Day & Night | Like a typical Ancient Silver Fenrir, but young, with brighter colors and unworn features, with wind-burnt coloring and a lean frame. |
| `pop_03392` | Calamity Steppe Ancient Silver Fenrir Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | SSS | 281 | 12.15 m | Day & Night | Like a typical Ancient Silver Fenrir, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_03393` | Calamity Steppe Ancient Silver Fenrir Runt | [[Regions/Calamity Steppe\|Calamity Steppe]] | Runt | S+ | 203 | 6.3 m | Day & Night | Like a typical Ancient Silver Fenrir, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_03394` | Calamity Steppe Ancient Silver Fenrir Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | SSS- | 267 | 11.25 m | Day & Night | Like a typical Ancient Silver Fenrir, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_03395` | Calamity Steppe Ancient Silver Fenrir Scarred | [[Regions/Calamity Steppe\|Calamity Steppe]] | Scarred | SS+ | 253 | 9.9 m | Day & Night | Like a typical Ancient Silver Fenrir, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_03396` | Calamity Steppe Ancient Silver Fenrir Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | SS+ | 253 | 9 m | Day & Night | Like a typical Ancient Silver Fenrir, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `holy_motes` · palette `#826542` `#543f2d` `#ffd166` · real-animal silhouette with one fantasy exaggeration
