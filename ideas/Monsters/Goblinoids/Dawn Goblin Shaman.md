---
type: monster
id: mon_dawn_goblin_shaman
family: "Goblinoids"
rank: "E+"
tier: variant
tags: [monster, goblinoids]
---
# Dawn Goblin Shaman

![[mon_dawn_goblin_shaman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dawn_goblin_shaman_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,310 tris · 0.494 × 0.398 × 1 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dawn Goblin Shaman is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in grey-green and patched leather, with gold markings. Guild sketches always show a skull headdress and a staff hung with smoking charms. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Shaman\|Goblin Shaman]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1436 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 15.2 kg, gravity ×1.35, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.32 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a skull headdress and a staff hung with smoking charms.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dawn Goblin Shaman is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skull headdress and a staff hung with smoking charms. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | E-, D-, D, E | 19–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, E, E+, D, E- | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03093` | Great Labyrinth (Floors 1-40) Dawn Goblin Shaman Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Dawn Goblin Shaman, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03094` | Aldmere Dawn Goblin Shaman Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1 m | Day & Night | Like a typical Dawn Goblin Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_03095` | Aldmere Dawn Goblin Shaman Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Dawn Goblin Shaman, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03096` | Aldmere Dawn Goblin Shaman Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Dawn Goblin Shaman, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03097` | Aldmere Dawn Goblin Shaman | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1 m | Day & Night | A typical adult Dawn Goblin Shaman of this region, with golden, grass-toned coloring. |
| `pop_03098` | Aldmere Dawn Goblin Shaman Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Dawn Goblin Shaman, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03099` | Great Labyrinth (Floors 1-40) Dawn Goblin Shaman Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.1 m | Day & Night | Like a typical Dawn Goblin Shaman, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03100` | Aldmere Dawn Goblin Shaman Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.7 m | Day & Night | Like a typical Dawn Goblin Shaman, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03101` | Great Labyrinth (Floors 1-40) Dawn Goblin Shaman Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 1 m | Day & Night | Like a typical Dawn Goblin Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_03102` | Great Labyrinth (Floors 1-40) Dawn Goblin Shaman Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 1.25 m | Day & Night | Like a typical Dawn Goblin Shaman, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03103` | Great Labyrinth (Floors 1-40) Dawn Goblin Shaman Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.85 m | Day & Night | Like a typical Dawn Goblin Shaman, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#84966f` `#5e4834` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
