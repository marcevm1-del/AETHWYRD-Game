---
type: monster
id: mon_phantom_sphinx
family: "Chimeras & Mythic Beasts"
rank: "S+"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Phantom Sphinx

![[mon_phantom_sphinx_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_sphinx_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,842 tris · 1.38 × 6 × 2.694 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Sphinx is a huge creature with a long-legged predatory quadruped build, about 6 m long. Its hide is rough, scarred and spiked, colored in warm gold and pearl white. Look for a lion's body and a calm, ancient face. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Sphinx\|Sphinx]] (spirit) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52042 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.9 m high × 6 m long × 0.96 m wide; prefab scale 1.5.
- **Physics:** 4104 kg, gravity ×1.08, poise 163, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.46 m/s, turn 131°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a lion's body and a calm, ancient face.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Many-Headed Bite\|Many-Headed Bite]] | melee | 1.5 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Sphinx is a **menacing mythic beast** encountered at S+ rank, around level 203. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lion's body and a calm, ancient face. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Chimeras & Mythic Beasts S|loot_chimera_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | SS-, S, SS+, S-, S+, SS | 173–253 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 4 | S, S+, S-, SS- | 173–218 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05070` | Nox Dominion Phantom Sphinx Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS- | 218 | 6 m | Day & Night | Like a typical Phantom Sphinx, but a rare pale form with white skin or fur and red eyes. |
| `pop_05071` | Sky Archipelago Phantom Sphinx Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S | 188 | 5.1 m | Day & Night | Like a typical Phantom Sphinx, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_05072` | Sky Archipelago Phantom Sphinx | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S+ | 203 | 6 m | Day & Night | A typical adult Phantom Sphinx of this region, with dust-grey coloring and old rune scars. |
| `pop_05073` | Nox Dominion Phantom Sphinx Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S | 188 | 5.1 m | Day & Night | Like a typical Phantom Sphinx, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_05074` | Nox Dominion Phantom Sphinx Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS+ | 253 | 8.1 m | Day & Night | Like a typical Phantom Sphinx, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_05075` | Sky Archipelago Phantom Sphinx Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S- | 173 | 4.2 m | Day & Night | Like a typical Phantom Sphinx, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05076` | Nox Dominion Phantom Sphinx Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S- | 173 | 4.2 m | Day & Night | Like a typical Phantom Sphinx, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_05077` | Sky Archipelago Phantom Sphinx Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS- | 218 | 6 m | Day & Night | Like a typical Phantom Sphinx, but a rare pale form with white skin or fur and red eyes. |
| `pop_05078` | Nox Dominion Phantom Sphinx Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS- | 218 | 6.6 m | Day & Night | Like a typical Phantom Sphinx, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_05079` | Nox Dominion Phantom Sphinx | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S+ | 203 | 6 m | Day & Night | A typical adult Phantom Sphinx of this region, with red-black coloring with faint ember veins. |
| `pop_05080` | Nox Dominion Phantom Sphinx Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS | 236 | 7.5 m | Day & Night | Like a typical Phantom Sphinx, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
