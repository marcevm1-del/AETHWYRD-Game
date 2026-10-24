---
type: monster
id: mon_sahuagin
family: "Aquatic"
rank: "D"
tier: core
tags: [monster, aquatic]
---
# Sahuagin

> The Sahuagin is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Guild sketches always show a shark-like head and webbed hands. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 1.9 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4168 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Greymoor\|Greymoor]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 93.6 kg, gravity ×1.5, poise 67, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.07 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a shark-like head and webbed hands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Sahuagin is a **menacing aquatic** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shark-like head and webbed hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Greymoor|Greymoor]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic D|loot_aquatic_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Vesper-Touched Sahuagin|Vesper-Touched Sahuagin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Greymoor\|Greymoor]] | 1 | D- | 40–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | C, D+, D, E+, D- | 32–76 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | D+, E+, D, D-, C | 32–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01952` | Greymoor Sahuagin Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | D- | 40 | 1.61 m | Day & Night | Like a typical Sahuagin, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01953` | Aldmere Sahuagin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 2.56 m | Day & Night | Like a typical Sahuagin, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01954` | Kitsune Isles Sahuagin Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D+ | 56 | 1.9 m | Day & Night | Like a typical Sahuagin, but a rare pale form with white skin or fur and red eyes. |
| `pop_01955` | Aldmere Sahuagin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.09 m | Day & Night | Like a typical Sahuagin, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01956` | Aldmere Sahuagin | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.9 m | Day & Night | A typical adult Sahuagin of this region, with mud-slick, algae-streaked skin. |
| `pop_01957` | Kitsune Isles Sahuagin Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 1.33 m | Day & Night | Like a typical Sahuagin, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01958` | Kitsune Isles Sahuagin | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 1.9 m | Day & Night | A typical adult Sahuagin of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01959` | Kitsune Isles Sahuagin Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 1.61 m | Day & Night | Like a typical Sahuagin, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01960` | Kitsune Isles Sahuagin Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 2.56 m | Day & Night | Like a typical Sahuagin, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01961` | Aldmere Sahuagin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E+ | 32 | 1.33 m | Day & Night | Like a typical Sahuagin, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01962` | Aldmere Sahuagin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.61 m | Day & Night | Like a typical Sahuagin, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
