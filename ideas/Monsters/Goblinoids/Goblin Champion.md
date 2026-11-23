---
type: monster
id: mon_goblin_champion
family: "Goblinoids"
rank: "D+"
tier: core
tags: [monster, goblinoids]
---
# Goblin Champion

![[mon_goblin_champion_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_champion_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.098 × 0.997 × 2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_goblin_champion.fbx`

> The Goblin Champion is a person-sized creature with an upright humanoid build, about 2 m tall. Its skin is rough, scarred and spiked, colored in moss green and leather brown. Its most striking feature is a trophy cloak stitched from adventurers' capes. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 69, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.46 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** a trophy cloak stitched from adventurers' capes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin Champion is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a trophy cloak stitched from adventurers' capes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids D|loot_goblinoid_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Vesper-Touched Goblin Champion|Vesper-Touched Goblin Champion]]
- [[Monsters/Goblinoids/Goblin Champion Veteran|Goblin Champion Veteran]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, D+, C-, D, C | 48–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D-, C-, C+, D | 40–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | C+ | 86–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00233` | Strife Marches Goblin Champion Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Goblin Champion, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00234` | Moraveil Goblin Champion Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Goblin Champion, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00235` | Moraveil Goblin Champion Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Goblin Champion, but a rare pale form with white skin or fur and red eyes. |
| `pop_00236` | Aldmere Goblin Champion Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Goblin Champion, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00237` | Strife Marches Goblin Champion | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 2 m | Day & Night | A typical adult Goblin Champion of this region, with golden, grass-toned coloring. |
| `pop_00238` | Moraveil Goblin Champion Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Goblin Champion, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00239` | Strife Marches Goblin Champion Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Goblin Champion, but a rare pale form with white skin or fur and red eyes. |
| `pop_00240` | Strife Marches Goblin Champion Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Goblin Champion, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00241` | Moraveil Goblin Champion Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 2.7 m | Day & Night | Like a typical Goblin Champion, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00242` | Moraveil Goblin Champion Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Goblin Champion, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00243` | Strife Marches Goblin Champion Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 2.5 m | Day & Night | Like a typical Goblin Champion, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#7bb548` `#905837` `#a1fc64` · triangle-based silhouette, sharp asymmetric spikes
