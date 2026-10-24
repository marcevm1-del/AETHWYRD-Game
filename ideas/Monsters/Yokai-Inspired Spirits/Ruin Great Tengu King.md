---
type: monster
id: mon_ruin_great_tengu_king
family: "Yokai-Inspired Spirits"
rank: "SSS+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Ruin Great Tengu King

![[mon_ruin_great_tengu_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_great_tengu_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,302 tris · 2.623 × 8.689 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Great Tengu King is a huge creature with a tall, long-legged bird build, about 6 m tall. Its form is weathered and natural, colored in ink black with bruised violet. Survivors describe a mask of red lacquer and a fan that summons typhoons. It has amber predator eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It lopes in long strides, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Great Tengu King\|Great Tengu King]] (regional) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 70021 · 1186 · 949 · 830 · 949 · 135 |
| XP · gold | 26706 · 4286 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 2.76 m high × 6 m long × 10.32 m wide; prefab scale 10.
- **Physics:** 3024 kg, gravity ×1, poise 1051, knockback resistance 0.29, death style `tumble_feathers_burst`.
- **Navigation:** speed 7.67 m/s, turn 245°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a mask of red lacquer and a fan that summons typhoons.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Great Tengu King is a **wild spirit** encountered at SSS+ rank, around level 294. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a mask of red lacquer and a fan that summons typhoons. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits SSS|loot_yokai_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | EX+, EX, SSS-, EX-, SSS+ | 267–300 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 5 | SSS-, EX-, SSS, EX, EX+ | 267–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05400` | Shen-Lu Ruin Great Tengu King Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | EX+ | 300 | 8.1 m | Day & Night | Like a typical Ruin Great Tengu King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05401` | Shen-Lu Ruin Great Tengu King Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | EX | 300 | 7.5 m | Day & Night | Like a typical Ruin Great Tengu King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05402` | Shen-Lu Ruin Great Tengu King Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | SSS- | 267 | 4.2 m | Day & Night | Like a typical Ruin Great Tengu King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05403` | Shen-Lu Ruin Great Tengu King Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | EX- | 300 | 6.6 m | Day & Night | Like a typical Ruin Great Tengu King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05404` | Everdusk Ruin Great Tengu King Runt | [[Regions/Everdusk\|Everdusk]] | Runt | SSS- | 267 | 4.2 m | Day & Night | Like a typical Ruin Great Tengu King, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05405` | Everdusk Ruin Great Tengu King Albino | [[Regions/Everdusk\|Everdusk]] | Albino | EX- | 300 | 6 m | Day & Night | Like a typical Ruin Great Tengu King, but a rare pale form with white skin or fur and red eyes. |
| `pop_05406` | Shen-Lu Ruin Great Tengu King | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | SSS+ | 294 | 6 m | Day & Night | A typical adult Ruin Great Tengu King of this region, with slate-grey coloring and hardened hide. |
| `pop_05407` | Everdusk Ruin Great Tengu King Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | SSS | 281 | 5.1 m | Day & Night | Like a typical Ruin Great Tengu King, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05408` | Everdusk Ruin Great Tengu King Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | EX | 300 | 7.5 m | Day & Night | Like a typical Ruin Great Tengu King, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05409` | Shen-Lu Ruin Great Tengu King Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | EX- | 300 | 6 m | Day & Night | Like a typical Ruin Great Tengu King, but a rare pale form with white skin or fur and red eyes. |
| `pop_05410` | Everdusk Ruin Great Tengu King Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | EX+ | 300 | 8.1 m | Day & Night | Like a typical Ruin Great Tengu King, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
