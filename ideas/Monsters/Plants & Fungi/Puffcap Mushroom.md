---
type: monster
id: mon_puffcap_mushroom
family: "Plants & Fungi"
rank: "F"
tier: core
tags: [monster, plants-fungi]
---
# Puffcap Mushroom

> The Puffcap Mushroom is a small creature with a mushroom-capped walking body, about 0.5 m tall. Its bark and leaves are smooth and clean, colored in leaf greens over bark brown. Look for a spotted cap that sneezes giggle-spores. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It waddles, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 214 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override); animation set `anim_plant_walker`.
- **Dimensions:** 0.5 m high × 0.42 m long × 0.42 m wide; prefab scale 1.
- **Physics:** 21.9 kg, gravity ×1.5, poise 27, knockback resistance 0.05, death style `topple_puff`.
- **Navigation:** speed 1.95 m/s, turn 424°/s, stopping distance 0.55 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Puffcap Mushroom is a **charming plant** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a spotted cap that sneezes giggle-spores. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi F|loot_plant_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Frost Puffcap Mushroom|Frost Puffcap Mushroom]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E-, F+, F-, E, F | 3–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 6 | F-, E-, E, F, F+ | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01702` | Whisperwood Puffcap Mushroom Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.63 m | Day | Like a typical Puffcap Mushroom, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01703` | Whisperwood Puffcap Mushroom Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Puffcap Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01704` | Aldmere Puffcap Mushroom Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Puffcap Mushroom, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01705` | Aldmere Puffcap Mushroom Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.63 m | Day | Like a typical Puffcap Mushroom, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01706` | Whisperwood Puffcap Mushroom Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Puffcap Mushroom, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01707` | Aldmere Puffcap Mushroom Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.68 m | Day | Like a typical Puffcap Mushroom, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01708` | Aldmere Puffcap Mushroom | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.5 m | Day | A typical adult Puffcap Mushroom of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01709` | Whisperwood Puffcap Mushroom Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.68 m | Day | Like a typical Puffcap Mushroom, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01710` | Aldmere Puffcap Mushroom Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Puffcap Mushroom, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01711` | Aldmere Puffcap Mushroom Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Puffcap Mushroom, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01712` | Whisperwood Puffcap Mushroom | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.5 m | Day | A typical adult Puffcap Mushroom of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
