---
type: monster
id: mon_phantom_nine_tailed_vixen_queen
family: "Yokai-Inspired Spirits"
rank: "S+"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Phantom Nine-Tailed Vixen Queen

![[mon_phantom_nine_tailed_vixen_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_nine_tailed_vixen_queen_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Nine-Tailed Vixen Queen is a huge creature with a powerful four-legged hunter's body, about 8 m long. Its form is rough, scarred and spiked, colored in warm gold and pearl white. Survivors describe nine tails that each hold a different spell. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Nine-Tailed Vixen Queen\|Nine-Tailed Vixen Queen]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 56724 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 5.2 m high × 8 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 9728 kg, gravity ×1.08, poise 188, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 10.92 m/s, turn 113°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** nine tails that each hold a different spell.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Nine-Tailed Vixen Queen is a **menacing spirit** encountered at S+ rank, around level 203. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** nine tails that each hold a different spell. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits S|loot_yokai_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | SS-, S+, SS+, S, SS | 188–253 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 5 | S-, SS, SS-, S+ | 173–236 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05411` | Shen-Lu Phantom Nine-Tailed Vixen Queen Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_05412` | Everdusk Phantom Nine-Tailed Vixen Queen Runt | [[Regions/Everdusk\|Everdusk]] | Runt | S- | 173 | 5.6 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05413` | Everdusk Phantom Nine-Tailed Vixen Queen Alpha | [[Regions/Everdusk\|Everdusk]] | Alpha | SS | 236 | 10 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05414` | Shen-Lu Phantom Nine-Tailed Vixen Queen | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Phantom Nine-Tailed Vixen Queen of this region, with slate-grey coloring and hardened hide. |
| `pop_05415` | Everdusk Phantom Nine-Tailed Vixen Queen Albino | [[Regions/Everdusk\|Everdusk]] | Albino | SS- | 218 | 8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_05416` | Shen-Lu Phantom Nine-Tailed Vixen Queen Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | SS- | 218 | 8.8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05417` | Shen-Lu Phantom Nine-Tailed Vixen Queen Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | SS+ | 253 | 10.8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05418` | Everdusk Phantom Nine-Tailed Vixen Queen | [[Regions/Everdusk\|Everdusk]] | Adult | S+ | 203 | 8 m | Day & Night | A typical adult Phantom Nine-Tailed Vixen Queen of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05419` | Shen-Lu Phantom Nine-Tailed Vixen Queen Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | S | 188 | 6.8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_05420` | Shen-Lu Phantom Nine-Tailed Vixen Queen Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | SS | 236 | 10 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05421` | Everdusk Phantom Nine-Tailed Vixen Queen Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | SS- | 218 | 8.8 m | Day & Night | Like a typical Phantom Nine-Tailed Vixen Queen, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `paper_ink_spirit` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
