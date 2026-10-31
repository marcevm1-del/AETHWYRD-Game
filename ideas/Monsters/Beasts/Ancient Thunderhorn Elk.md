---
type: monster
id: mon_ancient_thunderhorn_elk
family: "Beasts"
rank: "B"
tier: variant
tags: [monster, beasts]
---
# Ancient Thunderhorn Elk

![[mon_ancient_thunderhorn_elk_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_thunderhorn_elk_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,708 tris · 1.619 × 4.2 × 3.654 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Thunderhorn Elk is a large creature with a heavy, muscular quadruped frame, about 4.2 m long. Its coat is weathered and natural, colored in dark brown, with electric-yellow markings. Look for branching antlers that crackle in storms. It has alert animal eyes. Faint runes glow along its body when it fights. It prowls, surrounded by crackling arcs that jump across its body. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Thunderhorn Elk\|Thunderhorn Elk]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 4.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18111 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Earth. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.73 m high × 4.2 m long × 0.67 m wide; prefab scale 1.05.
- **Physics:** 1481.8 kg, gravity ×1.2, poise 115, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 8.55 m/s, turn 156°/s, stopping distance 1.24 m.
- **Attack count:** 5; **signature:** branching antlers that crackle in storms.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Thunderhorn Elk is a **wild beast** encountered at B rank, around level 108. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** branching antlers that crackle in storms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Shen-Lu\|Shen-Lu]] | 7 | A, B+, B-, A-, B, C+ | 86–146 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B-, A, B+ | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06187` | Shen-Lu Ancient Thunderhorn Elk Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | A | 146 | 5.67 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06188` | Shen-Lu Ancient Thunderhorn Elk Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B+ | 120 | 4.62 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06189` | Shen-Lu Ancient Thunderhorn Elk Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B- | 96 | 3.57 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06190` | Shen-Lu Ancient Thunderhorn Elk Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A- | 132 | 5.25 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06191` | Shen-Lu Ancient Thunderhorn Elk Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B+ | 120 | 4.2 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but a rare pale form with white skin or fur and red eyes. |
| `pop_06192` | Hoshizora Ancient Thunderhorn Elk Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B- | 96 | 3.57 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06193` | Shen-Lu Ancient Thunderhorn Elk | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B | 108 | 4.2 m | Day & Night | A typical adult Ancient Thunderhorn Elk of this region, with slate-grey coloring and hardened hide. |
| `pop_06194` | Shen-Lu Ancient Thunderhorn Elk Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C+ | 86 | 2.94 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_06195` | Hoshizora Ancient Thunderhorn Elk Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A | 146 | 5.67 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06196` | Hoshizora Ancient Thunderhorn Elk Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B+ | 120 | 4.2 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but a rare pale form with white skin or fur and red eyes. |
| `pop_06197` | Hoshizora Ancient Thunderhorn Elk Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B+ | 120 | 4.62 m | Day & Night | Like a typical Ancient Thunderhorn Elk, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `arc_sparks` · palette `#644b44` `#473633` `#ffe14d` · real-animal silhouette with one fantasy exaggeration
