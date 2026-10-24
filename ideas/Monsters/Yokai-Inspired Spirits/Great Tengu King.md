---
type: monster
id: mon_great_tengu_king
family: "Yokai-Inspired Spirits"
rank: "SSS"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Great Tengu King

![[mon_great_tengu_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_great_tengu_king_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,160 tris · 2.623 × 5.77 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Great Tengu King is a huge creature with a tall, long-legged bird build, about 6 m tall. Its form is weathered and natural, colored in pale jade and cloud white. Its most striking feature is a mask of red lacquer and a fan that summons typhoons. It has alert animal eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It lopes in long strides, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | SSS · 281 (267–294) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 65435 · 1134 · 907 · 794 · 907 · 135 |
| XP · gold | 24842 · 4024 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 2.76 m high × 6 m long × 10.32 m wide; prefab scale 10.
- **Physics:** 2721.6 kg, gravity ×0.8, poise 1009, knockback resistance 0.29, death style `tumble_feathers_burst`.
- **Navigation:** speed 7.18 m/s, turn 245°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a mask of red lacquer and a fan that summons typhoons.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Great Tengu King is a **wild spirit** encountered at SSS rank, around level 281. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Variants

- [[Monsters/Yokai-Inspired Spirits/Ruin Great Tengu King|Ruin Great Tengu King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | SSS+, EX, SSS-, EX-, SS+ | 253–300 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 5 | SSS+, EX, SS+, SSS-, SSS | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02549` | Shen-Lu Great Tengu King Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | SSS+ | 294 | 6.6 m | Day & Night | Like a typical Great Tengu King, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02550` | Shen-Lu Great Tengu King Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | EX | 300 | 8.1 m | Day & Night | Like a typical Great Tengu King, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02551` | Everdusk Great Tengu King Albino | [[Regions/Everdusk\|Everdusk]] | Albino | SSS+ | 294 | 6 m | Day & Night | Like a typical Great Tengu King, but a rare pale form with white skin or fur and red eyes. |
| `pop_02552` | Everdusk Great Tengu King Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | EX | 300 | 8.1 m | Day & Night | Like a typical Great Tengu King, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02553` | Everdusk Great Tengu King Runt | [[Regions/Everdusk\|Everdusk]] | Runt | SS+ | 253 | 4.2 m | Day & Night | Like a typical Great Tengu King, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02554` | Shen-Lu Great Tengu King Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | SSS+ | 294 | 6 m | Day & Night | Like a typical Great Tengu King, but a rare pale form with white skin or fur and red eyes. |
| `pop_02555` | Shen-Lu Great Tengu King Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | SSS- | 267 | 5.1 m | Day & Night | Like a typical Great Tengu King, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02556` | Shen-Lu Great Tengu King Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | EX- | 300 | 7.5 m | Day & Night | Like a typical Great Tengu King, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02557` | Shen-Lu Great Tengu King Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | SS+ | 253 | 4.2 m | Day & Night | Like a typical Great Tengu King, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02558` | Everdusk Great Tengu King Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | SSS- | 267 | 5.1 m | Day & Night | Like a typical Great Tengu King, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02559` | Everdusk Great Tengu King | [[Regions/Everdusk\|Everdusk]] | Adult | SSS | 281 | 6 m | Day & Night | A typical adult Great Tengu King of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `paper_ink_spirit` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
