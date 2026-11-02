---
type: monster
id: mon_vesper_touched_sahuagin
family: "Aquatic"
rank: "C-"
tier: variant
tags: [monster, aquatic]
---
# Vesper-Touched Sahuagin

![[mon_vesper_touched_sahuagin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_sahuagin_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,230 tris · 0.729 × 1.342 × 1.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Sahuagin is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in silver, with sea-blue markings. Survivors describe a shark-like head and webbed hands. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Sahuagin\|Sahuagin]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1.9 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6521 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 93.6 kg, gravity ×1.5, poise 74, knockback resistance 0.39, death style `ragdoll`.
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

Vesper-Touched Sahuagin is a **dread aquatic** encountered at C- rank, around level 65. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shark-like head and webbed hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic C|loot_aquatic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 6 | D+, C, C-, B-, C+ | 56–96 | Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 5 | D, C, B-, C+, C- | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04818` | Goldmere Coast Vesper-Touched Sahuagin Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | D+ | 56 | 1.61 m | Night | Like a typical Vesper-Touched Sahuagin, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04819` | Goldmere Coast Vesper-Touched Sahuagin Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | C | 76 | 2.09 m | Night | Like a typical Vesper-Touched Sahuagin, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04820` | Goldmere Coast Vesper-Touched Sahuagin | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | C- | 65 | 1.9 m | Night | A typical adult Vesper-Touched Sahuagin of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04821` | True-Name Isles Vesper-Touched Sahuagin Runt | [[Regions/True-Name Isles\|True-Name Isles]] | Runt | D | 48 | 1.33 m | Night | Like a typical Vesper-Touched Sahuagin, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04822` | True-Name Isles Vesper-Touched Sahuagin Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | C | 76 | 1.9 m | Night | Like a typical Vesper-Touched Sahuagin, but a rare pale form with white skin or fur and red eyes. |
| `pop_04823` | True-Name Isles Vesper-Touched Sahuagin Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | B- | 96 | 2.56 m | Night | Like a typical Vesper-Touched Sahuagin, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04824` | True-Name Isles Vesper-Touched Sahuagin Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | C+ | 86 | 2.38 m | Night | Like a typical Vesper-Touched Sahuagin, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04825` | True-Name Isles Vesper-Touched Sahuagin | [[Regions/True-Name Isles\|True-Name Isles]] | Adult | C- | 65 | 1.9 m | Night | A typical adult Vesper-Touched Sahuagin of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04826` | Goldmere Coast Vesper-Touched Sahuagin Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | B- | 96 | 2.56 m | Night | Like a typical Vesper-Touched Sahuagin, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04827` | Goldmere Coast Vesper-Touched Sahuagin Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | C | 76 | 1.9 m | Night | Like a typical Vesper-Touched Sahuagin, but a rare pale form with white skin or fur and red eyes. |
| `pop_04828` | Goldmere Coast Vesper-Touched Sahuagin Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | C+ | 86 | 2.38 m | Night | Like a typical Vesper-Touched Sahuagin, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `wet_scale` · VFX `mist_droplets` · palette `#8f99a4` `#5d6571` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
