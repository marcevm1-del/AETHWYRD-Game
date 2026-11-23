---
type: monster
id: mon_vesper_touched_orc_warrior
family: "Orcs, Ogres & Giants"
rank: "C-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Vesper-Touched Orc Warrior

![[mon_vesper_touched_orc_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_orc_warrior_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.416 × 1.025 × 2.1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_vesper_touched_orc_warrior.fbx`

> The Vesper-Touched Orc Warrior is a person-sized creature with a lean humanoid frame, about 2.1 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in olive-green, with crimson markings. Look for a fur mantle and rust-stained chain mail. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Warrior\|Orc Warrior]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.1 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6749 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.1 m high × 0.63 m long × 0.67 m wide; prefab scale 1.167.
- **Physics:** 132.4 kg, gravity ×1.5, poise 78, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.33 m/s, turn 276°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a fur mantle and rust-stained chain mail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Orc Warrior is a **dread giant** encountered at C- rank, around level 65. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a fur mantle and rust-stained chain mail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants C|loot_orc_giant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | C, D, D+, C-, B-, C+ | 48–96 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | B-, C-, C+, D | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03969` | Aldmere Vesper-Touched Orc Warrior Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C | 76 | 2.1 m | Night | Like a typical Vesper-Touched Orc Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_03970` | Aldmere Vesper-Touched Orc Warrior Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 1.47 m | Night | Like a typical Vesper-Touched Orc Warrior, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03971` | Aldmere Vesper-Touched Orc Warrior Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D+ | 56 | 1.78 m | Night | Like a typical Vesper-Touched Orc Warrior, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03972` | Strife Marches Vesper-Touched Orc Warrior Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B- | 96 | 2.84 m | Night | Like a typical Vesper-Touched Orc Warrior, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03973` | Strife Marches Vesper-Touched Orc Warrior | [[Regions/Strife Marches\|Strife Marches]] | Adult | C- | 65 | 2.1 m | Night | A typical adult Vesper-Touched Orc Warrior of this region, with golden, grass-toned coloring. |
| `pop_03974` | Aldmere Vesper-Touched Orc Warrior | [[Regions/Aldmere\|Aldmere]] | Adult | C- | 65 | 2.1 m | Night | A typical adult Vesper-Touched Orc Warrior of this region, with golden, grass-toned coloring. |
| `pop_03975` | Aldmere Vesper-Touched Orc Warrior Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C | 76 | 2.31 m | Night | Like a typical Vesper-Touched Orc Warrior, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03976` | Aldmere Vesper-Touched Orc Warrior Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B- | 96 | 2.84 m | Night | Like a typical Vesper-Touched Orc Warrior, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03977` | Strife Marches Vesper-Touched Orc Warrior Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C+ | 86 | 2.63 m | Night | Like a typical Vesper-Touched Orc Warrior, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03978` | Aldmere Vesper-Touched Orc Warrior Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C+ | 86 | 2.63 m | Night | Like a typical Vesper-Touched Orc Warrior, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03979` | Strife Marches Vesper-Touched Orc Warrior Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D | 48 | 1.47 m | Night | Like a typical Vesper-Touched Orc Warrior, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `blood_mist` · palette `#638144` `#43572e` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
