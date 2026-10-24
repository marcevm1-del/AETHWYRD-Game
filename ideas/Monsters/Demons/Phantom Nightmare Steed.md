---
type: monster
id: mon_phantom_nightmare_steed
family: "Demons"
rank: "A-"
tier: variant
tags: [monster, demons]
---
# Phantom Nightmare Steed

![[mon_phantom_nightmare_steed_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_nightmare_steed_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,256 tris · 0.77 × 2.5 × 2.121 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Nightmare Steed is a large creature with a long-legged predatory quadruped build, about 2.5 m long. Its hide is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show flame hooves and a mane of smoke. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Nightmare Steed\|Nightmare Steed]] (spirit) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 2.5 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20559 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.63 m high × 2.5 m long × 0.4 m wide; prefab scale 0.625.
- **Physics:** 296.9 kg, gravity ×1.08, poise 97, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.4 m/s, turn 202°/s, stopping distance 0.9 m.
- **Attack count:** 5; **signature:** flame hooves and a mane of smoke.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Nightmare Steed is a **dread demon** encountered at A- rank, around level 132. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** flame hooves and a mane of smoke. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons A|loot_demon_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | A-, S-, A, A+ | 132–173 | Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | A, B+, A+, A-, B, S- | 108–173 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04755` | Nox Dominion Phantom Nightmare Steed | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | A- | 132 | 2.5 m | Night | A typical adult Phantom Nightmare Steed of this region, with red-black coloring with faint ember veins. |
| `pop_04756` | Nox Dominion Phantom Nightmare Steed Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | S- | 173 | 3.38 m | Night | Like a typical Phantom Nightmare Steed, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_04757` | Sky Archipelago Phantom Nightmare Steed Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | A | 146 | 2.75 m | Night | Like a typical Phantom Nightmare Steed, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04758` | Sky Archipelago Phantom Nightmare Steed Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | B+ | 120 | 2.13 m | Night | Like a typical Phantom Nightmare Steed, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04759` | Sky Archipelago Phantom Nightmare Steed Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | A+ | 159 | 3.13 m | Night | Like a typical Phantom Nightmare Steed, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04760` | Nox Dominion Phantom Nightmare Steed Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | A | 146 | 2.75 m | Night | Like a typical Phantom Nightmare Steed, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_04761` | Sky Archipelago Phantom Nightmare Steed | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A- | 132 | 2.5 m | Night | A typical adult Phantom Nightmare Steed of this region, with dust-grey coloring and old rune scars. |
| `pop_04762` | Sky Archipelago Phantom Nightmare Steed Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | B | 108 | 1.75 m | Night | Like a typical Phantom Nightmare Steed, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04763` | Nox Dominion Phantom Nightmare Steed Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | A | 146 | 2.5 m | Night | Like a typical Phantom Nightmare Steed, but a rare pale form with white skin or fur and red eyes. |
| `pop_04764` | Sky Archipelago Phantom Nightmare Steed Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | S- | 173 | 3.38 m | Night | Like a typical Phantom Nightmare Steed, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04765` | Nox Dominion Phantom Nightmare Steed Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | A+ | 159 | 3.13 m | Night | Like a typical Phantom Nightmare Steed, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `demon_hide_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
