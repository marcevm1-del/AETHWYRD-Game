---
type: monster
id: mon_thornvine
family: "Plants & Fungi"
rank: "E"
tier: core
tags: [monster, plants-fungi]
---
# Thornvine

![[mon_thornvine_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thornvine_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,550 tris · 3.127 × 2.353 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thornvine is a large creature with a huge bulbous flower on a thick stalk, about 3 m tall. Its bark and leaves are rough, scarred and spiked, colored in leaf green over bark brown. Guild sketches always show vines covered in hooked thorns. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1454 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 3 m high × 1.2 m long × 3.6 m wide; prefab scale 1.5.
- **Physics:** 567 kg, gravity ×1, poise 118, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.57 m/s, turn 104°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** vines covered in hooked thorns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thornvine is a **menacing plant** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** vines covered in hooked thorns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Sylvaran|Sylvaran]], [[Regions/Mossdeep|Mossdeep]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi E|loot_plant_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Vesper-Touched Thornvine|Vesper-Touched Thornvine]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 3 | E+, D | 32–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | D- | 40–40 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E+, E | 26–32 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | E+ | 32–32 | Day & Night |
| [[Regions/Mossdeep\|Mossdeep]] | 2 | F+, D | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01724` | Sylvaran Thornvine Albino | [[Regions/Sylvaran\|Sylvaran]] | Albino | E+ | 32 | 3 m | Day & Night | Like a typical Thornvine, but a rare pale form with white skin or fur and red eyes. |
| `pop_01725` | Sylvaran Thornvine Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D | 48 | 4.05 m | Day & Night | Like a typical Thornvine, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01726` | Aldmere Thornvine Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 3.75 m | Day & Night | Like a typical Thornvine, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01727` | Whisperwood Thornvine Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 3.3 m | Day & Night | Like a typical Thornvine, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01728` | Greymoor Thornvine Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 3 m | Day & Night | Like a typical Thornvine, but a rare pale form with white skin or fur and red eyes. |
| `pop_01729` | Sylvaran Thornvine Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | E+ | 32 | 3.3 m | Day & Night | Like a typical Thornvine, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01730` | Whisperwood Thornvine | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 3 m | Day & Night | A typical adult Thornvine of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01731` | Mossdeep Thornvine Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | F+ | 13 | 2.1 m | Day & Night | Like a typical Thornvine, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01732` | Whisperwood Thornvine Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 3 m | Day & Night | Like a typical Thornvine, but a rare pale form with white skin or fur and red eyes. |
| `pop_01733` | Greymoor Thornvine Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | E+ | 32 | 3.3 m | Day & Night | Like a typical Thornvine, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01734` | Mossdeep Thornvine Elderborn | [[Regions/Mossdeep\|Mossdeep]] | Elderborn | D | 48 | 4.05 m | Day & Night | Like a typical Thornvine, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#5e8537` `#563b2e` `#8fd16a` · triangle-based silhouette, sharp asymmetric spikes
