---
type: monster
id: mon_oni
family: "Yokai-Inspired Spirits"
rank: "B+"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Oni

![[mon_oni_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_oni_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,530 tris · 3.006 × 1.728 × 3.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Oni is a large creature with a giant, barrel-chested humanoid body, about 3.5 m tall. Its form is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe horns, a tiger-skin wrap and an iron club. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25411 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Everdusk\|Everdusk]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Haneul\|Haneul]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.5 m high × 1.05 m long × 1.47 m wide; prefab scale 1.
- **Physics:** 771.8 kg, gravity ×1.3, poise 224, knockback resistance 0.87, death style `heavy_fall_dust`.
- **Navigation:** speed 6.61 m/s, turn 203°/s, stopping distance 1.1 m.
- **Attack count:** 5; **signature:** horns, a tiger-skin wrap and an iron club.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Oni is a **menacing spirit** encountered at B+ rank, around level 120. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns, a tiger-skin wrap and an iron club. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Everdusk|Everdusk]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Haneul|Haneul]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits B|loot_yokai_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Oni|Vesper-Touched Oni]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 2 | A-, A+ | 132–159 | Day & Night |
| [[Regions/Haneul\|Haneul]] | 4 | A+, A-, B+, A | 120–159 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 3 | A-, B-, B | 96–132 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 1 | A- | 132–132 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02527` | Hoshizora Oni Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Oni, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02528` | Haneul Oni Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Oni, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02529` | Everdusk Oni Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Oni, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02530` | Haneul Oni Scarred | [[Regions/Haneul\|Haneul]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Oni, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02531` | Haneul Oni | [[Regions/Haneul\|Haneul]] | Adult | B+ | 120 | 3.5 m | Day & Night | A typical adult Oni of this region, with slate-grey coloring and hardened hide. |
| `pop_02532` | Kitsune Isles Oni Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | A- | 132 | 3.85 m | Day & Night | Like a typical Oni, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02533` | Hoshizora Oni Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A+ | 159 | 4.73 m | Day & Night | Like a typical Oni, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02534` | Shen-Lu Oni Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Oni, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02535` | Everdusk Oni Runt | [[Regions/Everdusk\|Everdusk]] | Runt | B- | 96 | 2.45 m | Day & Night | Like a typical Oni, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02536` | Everdusk Oni Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | B | 108 | 2.98 m | Day & Night | Like a typical Oni, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02537` | Haneul Oni Alpha | [[Regions/Haneul\|Haneul]] | Alpha | A | 146 | 4.38 m | Day & Night | Like a typical Oni, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
