---
type: monster
id: mon_goblin_general
family: "Goblinoids"
rank: "C"
tier: core
tags: [monster, goblinoids]
---
# Goblin General

> The Goblin General is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a war banner and a horn carved from an ogre's tusk. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8647 · 377 · 314 · 176 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 80, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.73 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 4; **signature:** a war banner and a horn carved from an ogre's tusk.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin General is a **menacing humanoid** encountered at C rank, around level 76. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a war banner and a horn carved from an ogre's tusk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids C|loot_goblinoid_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Vesper-Touched Goblin General|Vesper-Touched Goblin General]]
- [[Monsters/Goblinoids/Goblin General Veteran|Goblin General Veteran]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 3 | C, C+, B | 76–108 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | C, D+, B, B-, C- | 56–108 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C+, D+ | 56–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00244` | Moraveil Goblin General | [[Regions/Moraveil\|Moraveil]] | Adult | C | 76 | 2.2 m | Day & Night | A typical adult Goblin General of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00245` | Aldmere Goblin General | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 2.2 m | Day & Night | A typical adult Goblin General of this region, with golden, grass-toned coloring. |
| `pop_00246` | Aldmere Goblin General Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.54 m | Day & Night | Like a typical Goblin General, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00247` | Aldmere Goblin General Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 2.97 m | Day & Night | Like a typical Goblin General, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00248` | Strife Marches Goblin General Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 2.2 m | Day & Night | Like a typical Goblin General, but a rare pale form with white skin or fur and red eyes. |
| `pop_00249` | Strife Marches Goblin General Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C+ | 86 | 2.42 m | Day & Night | Like a typical Goblin General, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00250` | Moraveil Goblin General Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C+ | 86 | 2.2 m | Day & Night | Like a typical Goblin General, but a rare pale form with white skin or fur and red eyes. |
| `pop_00251` | Strife Marches Goblin General Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D+ | 56 | 1.54 m | Day & Night | Like a typical Goblin General, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00252` | Aldmere Goblin General Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 2.75 m | Day & Night | Like a typical Goblin General, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00253` | Moraveil Goblin General Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B | 108 | 2.97 m | Day & Night | Like a typical Goblin General, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00254` | Aldmere Goblin General Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 1.87 m | Day & Night | Like a typical Goblin General, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
