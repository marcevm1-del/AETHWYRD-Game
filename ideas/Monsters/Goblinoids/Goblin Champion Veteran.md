---
type: monster
id: mon_goblin_champion_veteran
family: "Goblinoids"
rank: "C+"
tier: variant
tags: [monster, goblinoids]
---
# Goblin Champion Veteran

![[mon_goblin_champion_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_goblin_champion_veteran_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.959 × 1.703 × 3.201 m · local file `Game/Assets/_Game/Art/Models/Monsters/Goblinoids/mon_goblin_champion_veteran.fbx`

> The Goblin Champion Veteran is a large creature with a lean humanoid frame, about 3.2 m tall. Its skin is rough, scarred and spiked, colored in moss green and leather brown. Its most striking feature is a trophy cloak stitched from adventurers' capes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Champion\|Goblin Champion]] (elder) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 3.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11796 · 425 · 354 · 198 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.02 m wide; prefab scale 1.778.
- **Physics:** 426 kg, gravity ×1.5, poise 97, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.91 m/s, turn 224°/s, stopping distance 0.94 m.
- **Attack count:** 4; **signature:** a trophy cloak stitched from adventurers' capes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Goblin Champion Veteran is a **menacing humanoid** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a trophy cloak stitched from adventurers' capes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Strife Marches\|Strife Marches]] | 6 | B+, B-, C, C-, B | 65–120 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | B-, B, B+, C- | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05978` | Strife Marches Goblin Champion Veteran Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B+ | 120 | 4.32 m | Day & Night | Like a typical Goblin Champion Veteran, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05979` | Moraveil Goblin Champion Veteran Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Goblin Champion Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05980` | Moraveil Goblin Champion Veteran Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B | 108 | 4 m | Day & Night | Like a typical Goblin Champion Veteran, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05981` | Strife Marches Goblin Champion Veteran Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 3.2 m | Day & Night | Like a typical Goblin Champion Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_05982` | Strife Marches Goblin Champion Veteran Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 3.52 m | Day & Night | Like a typical Goblin Champion Veteran, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05983` | Moraveil Goblin Champion Veteran Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B+ | 120 | 4.32 m | Day & Night | Like a typical Goblin Champion Veteran, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05984` | Strife Marches Goblin Champion Veteran Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C | 76 | 2.72 m | Day & Night | Like a typical Goblin Champion Veteran, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05985` | Moraveil Goblin Champion Veteran Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B- | 96 | 3.52 m | Day & Night | Like a typical Goblin Champion Veteran, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05986` | Strife Marches Goblin Champion Veteran Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Goblin Champion Veteran, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05987` | Strife Marches Goblin Champion Veteran Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B | 108 | 4 m | Day & Night | Like a typical Goblin Champion Veteran, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05988` | Moraveil Goblin Champion Veteran Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C- | 65 | 2.24 m | Day & Night | Like a typical Goblin Champion Veteran, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#58aa43` `#876834` `#a1fc64` · triangle-based silhouette, sharp asymmetric spikes
