---
type: monster
id: mon_orc_lord
family: "Orcs, Ogres & Giants"
rank: "B"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Lord

![[mon_orc_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_orc_lord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,508 tris · 1.532 × 1.646 × 2.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Orc Lord is a large creature with a lean humanoid frame, about 2.6 m tall. Its hide is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a horned helm and a cloak of wolf pelts. It has narrow glowing eyes. Faint runes glow along its body when it fights. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15443 · 530 · 442 · 248 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Vharlen\|Vharlen]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.6 m high × 0.78 m long × 0.83 m wide; prefab scale 1.444.
- **Physics:** 228.5 kg, gravity ×1.5, poise 96, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 5.93 m/s, turn 248°/s, stopping distance 0.84 m.
- **Attack count:** 4; **signature:** a horned helm and a cloak of wolf pelts.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Orc Lord is a **menacing giant** encountered at B rank, around level 108. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horned helm and a cloak of wolf pelts. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Vharlen|Vharlen]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants B|loot_orc_giant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Lord|Meadow Orc Lord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 4 | B-, B+, C+ | 86–120 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 3 | A-, B+ | 120–132 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 4 | C+, B, B+, A | 86–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01116` | Iron Hold Orc Lord Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B- | 96 | 2.21 m | Day & Night | Like a typical Orc Lord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01117` | Iron Hold Orc Lord Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B+ | 120 | 2.6 m | Day & Night | Like a typical Orc Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01118` | Vharlen Orc Lord Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A- | 132 | 3.25 m | Day & Night | Like a typical Orc Lord, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_01119` | Vharlen Orc Lord Albino | [[Regions/Vharlen\|Vharlen]] | Albino | B+ | 120 | 2.6 m | Day & Night | Like a typical Orc Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_01120` | Vharlen Orc Lord Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B+ | 120 | 2.86 m | Day & Night | Like a typical Orc Lord, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01121` | Fanghold Orc Lord Runt | [[Regions/Fanghold\|Fanghold]] | Runt | C+ | 86 | 1.82 m | Day & Night | Like a typical Orc Lord, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01122` | Iron Hold Orc Lord Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C+ | 86 | 1.82 m | Day & Night | Like a typical Orc Lord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01123` | Fanghold Orc Lord | [[Regions/Fanghold\|Fanghold]] | Adult | B | 108 | 2.6 m | Day & Night | A typical adult Orc Lord of this region, with golden, grass-toned coloring. |
| `pop_01124` | Iron Hold Orc Lord Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B+ | 120 | 2.86 m | Day & Night | Like a typical Orc Lord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01125` | Fanghold Orc Lord Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | B+ | 120 | 2.86 m | Day & Night | Like a typical Orc Lord, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01126` | Fanghold Orc Lord Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | A | 146 | 3.51 m | Day & Night | Like a typical Orc Lord, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
