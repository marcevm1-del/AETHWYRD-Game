---
type: monster
id: mon_man_eater_plant
family: "Plants & Fungi"
rank: "D"
tier: core
tags: [monster, plants-fungi]
---
# Man-Eater Plant

![[mon_man_eater_plant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_man_eater_plant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,762 tris · 2.606 × 1.961 × 2.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Man-Eater Plant is a large creature with a rooted plant body, about 2.5 m tall. Its bark and leaves are rough, scarred and spiked, colored in leaf greens over bark brown. Guild sketches always show a flower with jaws made of petals. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3330 · 121 · 141 · 283 · 263 · 90 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 2.5 m high × 1 m long × 3 m wide; prefab scale 1.25.
- **Physics:** 328.1 kg, gravity ×1, poise 100, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.57 m/s, turn 114°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a flower with jaws made of petals.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Man-Eater Plant is a **menacing plant** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a flower with jaws made of petals. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi D|loot_plant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Vine Man-Eater Plant|Vine Man-Eater Plant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | E+, D+, D, D- | 32–56 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | D-, C- | 40–65 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C-, C, D | 48–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D, C- | 48–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01735` | Aldmere Man-Eater Plant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 1.75 m | Day & Night | Like a typical Man-Eater Plant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01736` | Aldmere Man-Eater Plant Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.75 m | Day & Night | Like a typical Man-Eater Plant, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01737` | Moraveil Man-Eater Plant Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D- | 40 | 2.13 m | Day & Night | Like a typical Man-Eater Plant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01738` | Xochitl Mire Man-Eater Plant Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C- | 65 | 3.13 m | Day & Night | Like a typical Man-Eater Plant, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01739` | Aldmere Man-Eater Plant | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 2.5 m | Day & Night | A typical adult Man-Eater Plant of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01740` | Xochitl Mire Man-Eater Plant Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | C | 76 | 3.38 m | Day & Night | Like a typical Man-Eater Plant, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01741` | Aldmere Man-Eater Plant Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 2.13 m | Day & Night | Like a typical Man-Eater Plant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01742` | Strife Marches Man-Eater Plant | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2.5 m | Day & Night | A typical adult Man-Eater Plant of this region, with dust-grey coloring and old rune scars. |
| `pop_01743` | Moraveil Man-Eater Plant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 3.13 m | Day & Night | Like a typical Man-Eater Plant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01744` | Xochitl Mire Man-Eater Plant | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D | 48 | 2.5 m | Day & Night | A typical adult Man-Eater Plant of this region, with mud-slick, algae-streaked skin. |
| `pop_01745` | Strife Marches Man-Eater Plant Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 3.13 m | Day & Night | Like a typical Man-Eater Plant, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
