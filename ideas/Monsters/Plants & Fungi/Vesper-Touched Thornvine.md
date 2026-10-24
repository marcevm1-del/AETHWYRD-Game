---
type: monster
id: mon_vesper_touched_thornvine
family: "Plants & Fungi"
rank: "D-"
tier: variant
tags: [monster, plants-fungi]
---
# Vesper-Touched Thornvine

> The Vesper-Touched Thornvine is a large creature with a cluster of vines around a central bloom, about 3 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Survivors describe vines covered in hooked thorns. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by drifting pollen and tiny blossoms. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Thornvine\|Thornvine]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2711 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 3 m high × 1.2 m long × 3.6 m wide; prefab scale 1.5.
- **Physics:** 567 kg, gravity ×1, poise 134, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.6 m/s, turn 104°/s, stopping distance 0.76 m.
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

Vesper-Touched Thornvine is a **dread plant** encountered at D- rank, around level 40. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** vines covered in hooked thorns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi D|loot_plant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, E+, D, E, C- | 26–65 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | E+, D+, C-, D-, E | 26–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04601` | Aldmere Vesper-Touched Thornvine | [[Regions/Aldmere\|Aldmere]] | Adult | D- | 40 | 3 m | Night | A typical adult Vesper-Touched Thornvine of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04602` | Strife Marches Vesper-Touched Thornvine Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | E+ | 32 | 2.55 m | Night | Like a typical Vesper-Touched Thornvine, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04603` | Aldmere Vesper-Touched Thornvine Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 2.55 m | Night | Like a typical Vesper-Touched Thornvine, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04604` | Strife Marches Vesper-Touched Thornvine Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | D+ | 56 | 3.75 m | Night | Like a typical Vesper-Touched Thornvine, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04605` | Aldmere Vesper-Touched Thornvine Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 3.3 m | Night | Like a typical Vesper-Touched Thornvine, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04606` | Strife Marches Vesper-Touched Thornvine Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C- | 65 | 4.05 m | Night | Like a typical Vesper-Touched Thornvine, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04607` | Strife Marches Vesper-Touched Thornvine | [[Regions/Strife Marches\|Strife Marches]] | Adult | D- | 40 | 3 m | Night | A typical adult Vesper-Touched Thornvine of this region, with dust-grey coloring and old rune scars. |
| `pop_04608` | Aldmere Vesper-Touched Thornvine Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E | 26 | 2.1 m | Night | Like a typical Vesper-Touched Thornvine, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04609` | Aldmere Vesper-Touched Thornvine Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 3 m | Night | Like a typical Vesper-Touched Thornvine, but a rare pale form with white skin or fur and red eyes. |
| `pop_04610` | Aldmere Vesper-Touched Thornvine Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 4.05 m | Night | Like a typical Vesper-Touched Thornvine, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04611` | Strife Marches Vesper-Touched Thornvine Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E | 26 | 2.1 m | Night | Like a typical Vesper-Touched Thornvine, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
