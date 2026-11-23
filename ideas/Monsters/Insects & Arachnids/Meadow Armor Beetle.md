---
type: monster
id: mon_meadow_armor_beetle
family: "Insects & Arachnids"
rank: "D-"
tier: variant
tags: [monster, insects-arachnids]
---
# Meadow Armor Beetle

![[mon_meadow_armor_beetle_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_armor_beetle_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.049 × 1.201 × 0.607 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_meadow_armor_beetle.fbx`

> The Meadow Armor Beetle is a person-sized creature with a six-legged armored body, about 1.2 m long. Its chitin is weathered and natural, colored in amber, with pale jade markings. Its most striking feature is a shell like polished bronze. It has amber predator eyes. A distinctive marking runs along its back. It prowls, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Armor Beetle\|Armor Beetle]] (regional) |
| Rank · level | D- · 40 (32–48) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 1.2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3474 · 170 · 255 · 102 · 170 · 70 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.4 m high × 1.2 m long × 0.61 m wide; prefab scale 1.5.
- **Physics:** 68.4 kg, gravity ×1.12, poise 64, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 4.47 m/s, turn 456°/s, stopping distance 0.57 m.
- **Attack count:** 5; **signature:** a shell like polished bronze.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Armor Beetle is a **wild insectoid** encountered at D- rank, around level 40. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shell like polished bronze. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids D|loot_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | C-, D, D- | 40–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | E+, D, D-, C-, D+ | 32–65 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | E, D+, E+ | 26–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06385` | Aldmere Meadow Armor Beetle Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 1.62 m | Day & Night | Like a typical Meadow Armor Beetle, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06386` | Aldmere Meadow Armor Beetle Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 1.32 m | Day & Night | Like a typical Meadow Armor Beetle, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06387` | Moraveil Meadow Armor Beetle Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | E+ | 32 | 1.02 m | Day & Night | Like a typical Meadow Armor Beetle, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06388` | Moraveil Meadow Armor Beetle Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 1.32 m | Day & Night | Like a typical Meadow Armor Beetle, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06389` | Strife Marches Meadow Armor Beetle Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E | 26 | 0.84 m | Day & Night | Like a typical Meadow Armor Beetle, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06390` | Strife Marches Meadow Armor Beetle Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | D+ | 56 | 1.5 m | Day & Night | Like a typical Meadow Armor Beetle, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06391` | Moraveil Meadow Armor Beetle | [[Regions/Moraveil\|Moraveil]] | Adult | D- | 40 | 1.2 m | Day & Night | A typical adult Meadow Armor Beetle of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06392` | Strife Marches Meadow Armor Beetle Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | E+ | 32 | 1.02 m | Day & Night | Like a typical Meadow Armor Beetle, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06393` | Moraveil Meadow Armor Beetle Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C- | 65 | 1.62 m | Day & Night | Like a typical Meadow Armor Beetle, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06394` | Moraveil Meadow Armor Beetle Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | D+ | 56 | 1.5 m | Day & Night | Like a typical Meadow Armor Beetle, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06395` | Aldmere Meadow Armor Beetle | [[Regions/Aldmere\|Aldmere]] | Adult | D- | 40 | 1.2 m | Day & Night | A typical adult Meadow Armor Beetle of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `wind_ribbons` · palette `#c5872f` `#7d541d` `#8fe0bd` · real-animal silhouette with one fantasy exaggeration
