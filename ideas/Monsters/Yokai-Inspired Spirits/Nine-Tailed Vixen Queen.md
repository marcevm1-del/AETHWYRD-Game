---
type: monster
id: mon_nine_tailed_vixen_queen
family: "Yokai-Inspired Spirits"
rank: "S"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Nine-Tailed Vixen Queen

![[mon_nine_tailed_vixen_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_nine_tailed_vixen_queen_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Nine-Tailed Vixen Queen is a huge creature with a powerful four-legged hunter's body, about 8 m long. Its form is weathered and natural, colored in ember reds fading to soot black. Guild sketches always show nine tails that each hold a different spell. It has dark, wary eyes. Its regal silhouette is crowned by a halo-like ring of aura. It lopes in long strides, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | S · 188 (173–203) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 50569 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Everdusk\|Everdusk]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 5.2 m high × 8 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 10240 kg, gravity ×1.2, poise 188, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 12.01 m/s, turn 113°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** nine tails that each hold a different spell.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Nine-Tailed Vixen Queen is a **wild spirit** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** nine tails that each hold a different spell. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Everdusk|Everdusk]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits S|loot_yokai_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Phantom Nine-Tailed Vixen Queen|Phantom Nine-Tailed Vixen Queen]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | S-, A+, S+, SS-, S | 159–218 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 5 | S+, S, SS, SS- | 188–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02560` | Shen-Lu Nine-Tailed Vixen Queen Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S- | 173 | 6.8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02561` | Shen-Lu Nine-Tailed Vixen Queen Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | A+ | 159 | 5.6 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02562` | Everdusk Nine-Tailed Vixen Queen Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | S+ | 203 | 8.8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02563` | Shen-Lu Nine-Tailed Vixen Queen Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | S+ | 203 | 8.8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02564` | Everdusk Nine-Tailed Vixen Queen Albino | [[Regions/Everdusk\|Everdusk]] | Albino | S+ | 203 | 8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_02565` | Everdusk Nine-Tailed Vixen Queen | [[Regions/Everdusk\|Everdusk]] | Adult | S | 188 | 8 m | Day & Night | A typical adult Nine-Tailed Vixen Queen of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02566` | Shen-Lu Nine-Tailed Vixen Queen Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | S+ | 203 | 8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_02567` | Everdusk Nine-Tailed Vixen Queen Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | SS | 236 | 10.8 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02568` | Shen-Lu Nine-Tailed Vixen Queen Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS- | 218 | 10 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02569` | Shen-Lu Nine-Tailed Vixen Queen | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S | 188 | 8 m | Day & Night | A typical adult Nine-Tailed Vixen Queen of this region, with slate-grey coloring and hardened hide. |
| `pop_02570` | Everdusk Nine-Tailed Vixen Queen Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | SS- | 218 | 10 m | Day & Night | Like a typical Nine-Tailed Vixen Queen, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
