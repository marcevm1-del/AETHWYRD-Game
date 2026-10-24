---
type: monster
id: mon_elder_orc_disaster
family: "Orcs, Ogres & Giants"
rank: "SS"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Elder Orc Disaster

> The Elder Orc Disaster is a huge creature with a massive hunched brute frame, about 6.4 m tall. Its hide is rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show a body bloated with devoured power and a crown of bones. It has eyes that catch torchlight like coins. The air distorts slightly around its outline. It charges without hesitation, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Disaster\|Orc Disaster]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 6.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 84638 · 954 · 1431 · 572 · 954 · 70 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Calamity Steppe\|Calamity Steppe]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 6.4 m high × 1.92 m long × 2.69 m wide; prefab scale 1.829.
- **Physics:** 4718.6 kg, gravity ×1.3, poise 388, knockback resistance 0.96, death style `heavy_fall_dust`.
- **Navigation:** speed 8.93 m/s, turn 150°/s, stopping distance 1.68 m.
- **Attack count:** 5; **signature:** a body bloated with devoured power and a crown of bones.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Orc Disaster is a **menacing giant** encountered at SS rank, around level 236. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body bloated with devoured power and a crown of bones. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Calamity Steppe|Calamity Steppe]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants SS|loot_orc_giant_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Calamity Steppe\|Calamity Steppe]] | 7 | SSS-, SS-, SS+, SSS, SS, S+ | 203–281 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | S+, SS+, SS- | 203–253 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04068` | Calamity Steppe Elder Orc Disaster Alpha | [[Regions/Calamity Steppe\|Calamity Steppe]] | Alpha | SSS- | 267 | 8 m | Day & Night | Like a typical Elder Orc Disaster, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_04069` | Calamity Steppe Elder Orc Disaster Juvenile | [[Regions/Calamity Steppe\|Calamity Steppe]] | Juvenile | SS- | 218 | 5.44 m | Day & Night | Like a typical Elder Orc Disaster, but young, with brighter colors and unworn features, with wind-burnt coloring and a lean frame. |
| `pop_04070` | Calamity Steppe Elder Orc Disaster Albino | [[Regions/Calamity Steppe\|Calamity Steppe]] | Albino | SS+ | 253 | 6.4 m | Day & Night | Like a typical Elder Orc Disaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_04071` | Calamity Steppe Elder Orc Disaster Elderborn | [[Regions/Calamity Steppe\|Calamity Steppe]] | Elderborn | SSS | 281 | 8.64 m | Day & Night | Like a typical Elder Orc Disaster, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_04072` | Calamity Steppe Elder Orc Disaster Scarred | [[Regions/Calamity Steppe\|Calamity Steppe]] | Scarred | SS+ | 253 | 7.04 m | Day & Night | Like a typical Elder Orc Disaster, but covered in old battle scars, with wind-burnt coloring and a lean frame. |
| `pop_04073` | Calamity Steppe Elder Orc Disaster | [[Regions/Calamity Steppe\|Calamity Steppe]] | Adult | SS | 236 | 6.4 m | Day & Night | A typical adult Elder Orc Disaster of this region, with wind-burnt coloring and a lean frame. |
| `pop_04074` | Calamity Steppe Elder Orc Disaster Runt | [[Regions/Calamity Steppe\|Calamity Steppe]] | Runt | S+ | 203 | 4.48 m | Day & Night | Like a typical Elder Orc Disaster, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_04075` | Nox Dominion Elder Orc Disaster Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S+ | 203 | 4.48 m | Day & Night | Like a typical Elder Orc Disaster, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04076` | Nox Dominion Elder Orc Disaster Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS+ | 253 | 6.4 m | Day & Night | Like a typical Elder Orc Disaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_04077` | Nox Dominion Elder Orc Disaster Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SS- | 218 | 5.44 m | Day & Night | Like a typical Elder Orc Disaster, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04078` | Nox Dominion Elder Orc Disaster Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS+ | 253 | 7.04 m | Day & Night | Like a typical Elder Orc Disaster, but covered in old battle scars, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
