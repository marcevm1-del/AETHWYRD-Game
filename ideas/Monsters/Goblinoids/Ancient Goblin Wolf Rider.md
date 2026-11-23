---
type: monster
id: mon_ancient_goblin_wolf_rider
family: "Goblinoids"
rank: "C"
tier: variant
tags: [monster, goblinoids]
---
# Ancient Goblin Wolf Rider

![[mon_ancient_goblin_wolf_rider_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_goblin_wolf_rider_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,998 tris · 1.363 × 0.842 × 1.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_ancient_goblin_wolf_rider.fbx`

> The Ancient Goblin Wolf Rider is a person-sized creature with a scrawny biped with long arms and bowed legs, about 1.5 m tall. Its skin is rough, scarred and spiked, colored in grey-green and patched leather. Its most striking feature is a bone saddle on a snarling war-wolf mount. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Wolf Rider\|Goblin Wolf Rider]] (ancient) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.5 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5861 · 314 · 251 · 154 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.5 m high × 0.45 m long × 0.6 m wide; prefab scale 1.364.
- **Physics:** 54 kg, gravity ×1.5, poise 51, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 6.22 m/s, turn 343°/s, stopping distance 0.7 m.
- **Attack count:** 4; **signature:** a bone saddle on a snarling war-wolf mount.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Ancient Goblin Wolf Rider is a **menacing humanoid** encountered at C rank, around level 76. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bone saddle on a snarling war-wolf mount. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids C|loot_goblinoid_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | B, C+, C, D+, B- | 56–108 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | B-, C-, B, C+ | 65–108 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | C-, B- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03126` | Aldmere Ancient Goblin Wolf Rider Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 2.03 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03127` | Moraveil Ancient Goblin Wolf Rider Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B- | 96 | 1.88 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03128` | Aldmere Ancient Goblin Wolf Rider Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 1.65 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03129` | Strife Marches Ancient Goblin Wolf Rider Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 1.27 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03130` | Moraveil Ancient Goblin Wolf Rider Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C- | 65 | 1.27 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03131` | Aldmere Ancient Goblin Wolf Rider | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 1.5 m | Day & Night | A typical adult Ancient Goblin Wolf Rider of this region, with golden, grass-toned coloring. |
| `pop_03132` | Moraveil Ancient Goblin Wolf Rider Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B | 108 | 2.03 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03133` | Moraveil Ancient Goblin Wolf Rider Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C+ | 86 | 1.5 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but a rare pale form with white skin or fur and red eyes. |
| `pop_03134` | Aldmere Ancient Goblin Wolf Rider Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.05 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03135` | Aldmere Ancient Goblin Wolf Rider Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 1.88 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03136` | Strife Marches Ancient Goblin Wolf Rider Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 1.88 m | Day & Night | Like a typical Ancient Goblin Wolf Rider, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#7c8e6a` `#5a4632` `#b5cf9a` · triangle-based silhouette, sharp asymmetric spikes
