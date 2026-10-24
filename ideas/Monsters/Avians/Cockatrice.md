---
type: monster
id: mon_cockatrice
family: "Avians"
rank: "E"
tier: core
tags: [monster, avians]
---
# Cockatrice

![[mon_cockatrice_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cockatrice_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,120 tris · 0.376 × 1.247 × 0.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cockatrice is a small creature with a tall, long-legged bird build, about 0.8 m tall. Its plumage is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe a rooster's head and a lizard's tail. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 992 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.37 m high × 0.8 m long × 1.38 m wide; prefab scale 1.333.
- **Physics:** 9.3 kg, gravity ×1.1, poise 27, knockback resistance 0.23, death style `tumble_feathers_burst`.
- **Navigation:** speed 2.46 m/s, turn 671°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a rooster's head and a lizard's tail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cockatrice is a **wild avian** encountered at E rank, around level 26. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rooster's head and a lizard's tail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]], [[Regions/Fanghold|Fanghold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians E|loot_avian_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Vesper-Touched Cockatrice|Vesper-Touched Cockatrice]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 2 | E-, D | 19–48 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 5 | E-, E+, E, F+ | 13–32 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F+, D, D-, E+ | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02063` | Lirian Cockatrice Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | E- | 19 | 0.68 m | Day & Night | Like a typical Cockatrice, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02064` | Fanghold Cockatrice Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E- | 19 | 0.68 m | Day & Night | Like a typical Cockatrice, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02065` | Aldmere Cockatrice Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.56 m | Day & Night | Like a typical Cockatrice, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02066` | Aldmere Cockatrice Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.08 m | Day & Night | Like a typical Cockatrice, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02067` | Fanghold Cockatrice Albino | [[Regions/Fanghold\|Fanghold]] | Albino | E+ | 32 | 0.8 m | Day & Night | Like a typical Cockatrice, but a rare pale form with white skin or fur and red eyes. |
| `pop_02068` | Fanghold Cockatrice Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | E+ | 32 | 0.88 m | Day & Night | Like a typical Cockatrice, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02069` | Aldmere Cockatrice Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Cockatrice, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02070` | Aldmere Cockatrice Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.8 m | Day & Night | Like a typical Cockatrice, but a rare pale form with white skin or fur and red eyes. |
| `pop_02071` | Lirian Cockatrice Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 1.08 m | Day & Night | Like a typical Cockatrice, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02072` | Fanghold Cockatrice | [[Regions/Fanghold\|Fanghold]] | Adult | E | 26 | 0.8 m | Day & Night | A typical adult Cockatrice of this region, with golden, grass-toned coloring. |
| `pop_02073` | Fanghold Cockatrice Runt | [[Regions/Fanghold\|Fanghold]] | Runt | F+ | 13 | 0.56 m | Day & Night | Like a typical Cockatrice, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
