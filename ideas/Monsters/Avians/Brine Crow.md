---
type: monster
id: mon_brine_crow
family: "Avians"
rank: "F+"
tier: variant
tags: [monster, avians]
---
# Brine Crow

> The Brine Crow is a small creature with a broad-winged bird frame, about 0.6 m tall. Its plumage is weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show a beak full of stolen shiny things. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Giant Crow\|Giant Crow]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 0.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 350 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Lightning. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (override (base species)); animation set `anim_avian`.
- **Dimensions:** 0.28 m high × 0.6 m long × 1.03 m wide; prefab scale 1.
- **Physics:** 3.2 kg, gravity ×1, poise 14, knockback resistance 0.05, death style `tumble_feathers_burst`.
- **Navigation:** speed 2.31 m/s, turn 775°/s, stopping distance 0.52 m.
- **Attack count:** 5; **signature:** a beak full of stolen shiny things.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Brine Crow is a **wild avian** encountered at F+ rank, around level 13. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beak full of stolen shiny things. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians F|loot_avian_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | E-, F+, E+, E, F-, F | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04917` | Aldmere Brine Crow Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.6 m | Day & Night | Like a typical Brine Crow, but a rare pale form with white skin or fur and red eyes. |
| `pop_04918` | Aldmere Brine Crow | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.6 m | Day & Night | A typical adult Brine Crow of this region, with golden, grass-toned coloring. |
| `pop_04919` | Aldmere Brine Crow Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.81 m | Day & Night | Like a typical Brine Crow, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_04920` | Aldmere Brine Crow Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 0.75 m | Day & Night | Like a typical Brine Crow, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_04921` | Aldmere Brine Crow Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.66 m | Day & Night | Like a typical Brine Crow, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04922` | Aldmere Brine Crow Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.42 m | Day & Night | Like a typical Brine Crow, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_04923` | Aldmere Brine Crow Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.51 m | Day & Night | Like a typical Brine Crow, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
