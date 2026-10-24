---
type: monster
id: mon_siren
family: "Aquatic"
rank: "C+"
tier: core
tags: [monster, aquatic]
---
# Siren

![[mon_siren_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_siren_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Siren is a person-sized creature with a humanoid upper body on a long serpent tail, about 2 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a fish tail and a voice that sounds like home. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10057 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Stormreach\|Stormreach]], [[Regions/Hollow Sea\|Hollow Sea]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 0.92 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 29 kg, gravity ×1.3, poise 31, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 2.67 m/s, turn 247°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a fish tail and a voice that sounds like home.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Siren is a **dread aquatic** encountered at C+ rank, around level 86. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a fish tail and a voice that sounds like home. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Stormreach|Stormreach]], [[Regions/Hollow Sea|Hollow Sea]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic C|loot_aquatic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Ancient Siren|Ancient Siren]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 2 | B, B- | 96–108 | Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 2 | B+, B- | 96–120 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 4 | C+, B-, C- | 65–96 | Night |
| [[Regions/Hollow Sea\|Hollow Sea]] | 3 | C, C-, B- | 65–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01985` | Stormreach Siren Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | B | 108 | 2.5 m | Night | Like a typical Siren, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01986` | True-Name Isles Siren Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | B+ | 120 | 2.7 m | Night | Like a typical Siren, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01987` | Goldmere Coast Siren | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | C+ | 86 | 2 m | Night | A typical adult Siren of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01988` | Stormreach Siren Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | B- | 96 | 2.2 m | Night | Like a typical Siren, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01989` | Goldmere Coast Siren Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | B- | 96 | 2.2 m | Night | Like a typical Siren, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01990` | True-Name Isles Siren Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | B- | 96 | 2 m | Night | Like a typical Siren, but a rare pale form with white skin or fur and red eyes. |
| `pop_01991` | Hollow Sea Siren Juvenile | [[Regions/Hollow Sea\|Hollow Sea]] | Juvenile | C | 76 | 1.7 m | Night | Like a typical Siren, but young, with brighter colors and unworn features, with deep-water coloring and glowing lures. |
| `pop_01992` | Goldmere Coast Siren Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | C- | 65 | 1.4 m | Night | Like a typical Siren, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01993` | Hollow Sea Siren Runt | [[Regions/Hollow Sea\|Hollow Sea]] | Runt | C- | 65 | 1.4 m | Night | Like a typical Siren, but smaller and scrappier than usual, with deep-water coloring and glowing lures. |
| `pop_01994` | Hollow Sea Siren Scarred | [[Regions/Hollow Sea\|Hollow Sea]] | Scarred | B- | 96 | 2.2 m | Night | Like a typical Siren, but covered in old battle scars, with deep-water coloring and glowing lures. |
| `pop_01995` | Goldmere Coast Siren Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | B- | 96 | 2 m | Night | Like a typical Siren, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
