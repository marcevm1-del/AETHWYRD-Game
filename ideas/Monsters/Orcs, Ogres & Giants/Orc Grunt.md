---
type: monster
id: mon_orc_grunt
family: "Orcs, Ogres & Giants"
rank: "E"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Grunt

> The Orc Grunt is a person-sized creature with a lean humanoid frame, about 2 m tall. Its hide is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe tusks, war paint and a dented iron axe. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1741 · 137 · 114 · 64 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 61, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.46 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** tusks, war paint and a dented iron axe.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Orc Grunt is a **menacing giant** encountered at E rank, around level 26. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tusks, war paint and a dented iron axe. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants E|loot_orc_giant_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Grunt|Meadow Orc Grunt]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | D-, E+, E-, D, E, F+ | 13–48 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 4 | F+, E, E+, D | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01061` | Aldmere Orc Grunt Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 2.5 m | Day & Night | Like a typical Orc Grunt, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_01062` | Aldmere Orc Grunt Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 2.2 m | Day & Night | Like a typical Orc Grunt, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01063` | Fanghold Orc Grunt Runt | [[Regions/Fanghold\|Fanghold]] | Runt | F+ | 13 | 1.4 m | Day & Night | Like a typical Orc Grunt, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01064` | Aldmere Orc Grunt Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.7 m | Day & Night | Like a typical Orc Grunt, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01065` | Aldmere Orc Grunt Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 2 m | Day & Night | Like a typical Orc Grunt, but a rare pale form with white skin or fur and red eyes. |
| `pop_01066` | Aldmere Orc Grunt Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 2.7 m | Day & Night | Like a typical Orc Grunt, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_01067` | Fanghold Orc Grunt | [[Regions/Fanghold\|Fanghold]] | Adult | E | 26 | 2 m | Day & Night | A typical adult Orc Grunt of this region, with golden, grass-toned coloring. |
| `pop_01068` | Aldmere Orc Grunt | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 2 m | Day & Night | A typical adult Orc Grunt of this region, with golden, grass-toned coloring. |
| `pop_01069` | Fanghold Orc Grunt Albino | [[Regions/Fanghold\|Fanghold]] | Albino | E+ | 32 | 2 m | Day & Night | Like a typical Orc Grunt, but a rare pale form with white skin or fur and red eyes. |
| `pop_01070` | Aldmere Orc Grunt Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 1.4 m | Day & Night | Like a typical Orc Grunt, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01071` | Fanghold Orc Grunt Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D | 48 | 2.7 m | Day & Night | Like a typical Orc Grunt, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
