---
type: monster
id: mon_vesper_touched_tengu
family: "Yokai-Inspired Spirits"
rank: "B-"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched Tengu

> The Vesper-Touched Tengu is a person-sized creature with a feathered avian body, about 2 m tall. Its form is rough, scarred and spiked, colored in pale jade and cloud white. Guild sketches always show crow wings, a long red mask and a feather fan. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Tengu\|Tengu]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9154 · 394 · 315 · 276 · 315 · 135 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.92 m high × 2 m long × 3.44 m wide; prefab scale 3.333.
- **Physics:** 100.8 kg, gravity ×0.8, poise 134, knockback resistance 0.17, death style `tumble_feathers_burst`.
- **Navigation:** speed 4.13 m/s, turn 424°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** crow wings, a long red mask and a feather fan.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Tengu is a **menacing spirit** encountered at B- rank, around level 96. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** crow wings, a long red mask and a feather fan. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Haneul|Haneul]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits B|loot_yokai_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Haneul\|Haneul]] | 4 | B-, A-, C, C+ | 76–132 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B-, B+, A- | 96–132 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | B-, C, B+, B | 76–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05356` | Haneul Vesper-Touched Tengu | [[Regions/Haneul\|Haneul]] | Adult | B- | 96 | 2 m | Day & Night | A typical adult Vesper-Touched Tengu of this region, with slate-grey coloring and hardened hide. |
| `pop_05357` | Hoshizora Vesper-Touched Tengu | [[Regions/Hoshizora\|Hoshizora]] | Adult | B- | 96 | 2 m | Day & Night | A typical adult Vesper-Touched Tengu of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05358` | Shen-Lu Vesper-Touched Tengu | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B- | 96 | 2 m | Day & Night | A typical adult Vesper-Touched Tengu of this region, with slate-grey coloring and hardened hide. |
| `pop_05359` | Shen-Lu Vesper-Touched Tengu Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C | 76 | 1.4 m | Day & Night | Like a typical Vesper-Touched Tengu, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05360` | Hoshizora Vesper-Touched Tengu Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B+ | 120 | 2.5 m | Day & Night | Like a typical Vesper-Touched Tengu, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05361` | Haneul Vesper-Touched Tengu Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | A- | 132 | 2.7 m | Day & Night | Like a typical Vesper-Touched Tengu, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05362` | Hoshizora Vesper-Touched Tengu Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A- | 132 | 2.7 m | Day & Night | Like a typical Vesper-Touched Tengu, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05363` | Haneul Vesper-Touched Tengu Runt | [[Regions/Haneul\|Haneul]] | Runt | C | 76 | 1.4 m | Day & Night | Like a typical Vesper-Touched Tengu, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_05364` | Haneul Vesper-Touched Tengu Juvenile | [[Regions/Haneul\|Haneul]] | Juvenile | C+ | 86 | 1.7 m | Day & Night | Like a typical Vesper-Touched Tengu, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05365` | Shen-Lu Vesper-Touched Tengu Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B+ | 120 | 2.5 m | Day & Night | Like a typical Vesper-Touched Tengu, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05366` | Shen-Lu Vesper-Touched Tengu Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B | 108 | 2 m | Day & Night | Like a typical Vesper-Touched Tengu, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `paper_ink_spirit` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
