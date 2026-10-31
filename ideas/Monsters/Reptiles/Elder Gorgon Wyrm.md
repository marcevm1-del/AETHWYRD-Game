---
type: monster
id: mon_elder_gorgon_wyrm
family: "Reptiles"
rank: "SS"
tier: variant
tags: [monster, reptiles]
---
# Elder Gorgon Wyrm

![[mon_elder_gorgon_wyrm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_gorgon_wyrm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,742 tris · 4.559 × 22.4 × 11.643 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Gorgon Wyrm is a colossal creature with a coiling, legless body, about 22.4 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in teal-grey, with ochre markings. Guild sketches always show a stone-crusted body that leaves statues in its wake. It has eyes set slightly too far apart. The air distorts slightly around its outline. It freezes whenever it is looked at, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Gorgon Wyrm\|Gorgon Wyrm]] (elder) |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 22.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 72155 · 954 · 763 · 668 · 763 · 135 |
| XP · gold | 18792 · 3152 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.9 m high × 22.4 m long × 2.24 m wide; prefab scale 5.6.
- **Physics:** 33605.9 kg, gravity ×1.32, poise 1698, knockback resistance 0.76, death style `limp_chain`.
- **Navigation:** speed 12.73 m/s, turn 63°/s, stopping distance 1.18 m.
- **Attack count:** 5; **signature:** a stone-crusted body that leaves statues in its wake.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Gorgon Wyrm is a **dread reptile** encountered at SS rank, around level 236. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-crusted body that leaves statues in its wake. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles SS|loot_reptile_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 5 | SS-, S+, SSS, SS+, SS | 203–281 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 6 | S+, SS+, SSS-, SSS, SS- | 203–281 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04208` | Whitewater Reach Elder Gorgon Wyrm Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | SS- | 218 | 19.04 m | Night | Like a typical Elder Gorgon Wyrm, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04209` | Whitewater Reach Elder Gorgon Wyrm Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | S+ | 203 | 15.68 m | Night | Like a typical Elder Gorgon Wyrm, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04210` | Whitewater Reach Elder Gorgon Wyrm Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | SSS | 281 | 30.24 m | Night | Like a typical Elder Gorgon Wyrm, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04211` | Goldmere Coast Elder Gorgon Wyrm Runt | [[Regions/Goldmere Coast\|Goldmere Coast]] | Runt | S+ | 203 | 15.68 m | Night | Like a typical Elder Gorgon Wyrm, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04212` | Goldmere Coast Elder Gorgon Wyrm Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | SS+ | 253 | 24.64 m | Night | Like a typical Elder Gorgon Wyrm, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04213` | Whitewater Reach Elder Gorgon Wyrm Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | SS+ | 253 | 24.64 m | Night | Like a typical Elder Gorgon Wyrm, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04214` | Goldmere Coast Elder Gorgon Wyrm Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | SS+ | 253 | 22.4 m | Night | Like a typical Elder Gorgon Wyrm, but a rare pale form with white skin or fur and red eyes. |
| `pop_04215` | Goldmere Coast Elder Gorgon Wyrm Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | SSS- | 267 | 28 m | Night | Like a typical Elder Gorgon Wyrm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04216` | Goldmere Coast Elder Gorgon Wyrm Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | SSS | 281 | 30.24 m | Night | Like a typical Elder Gorgon Wyrm, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04217` | Goldmere Coast Elder Gorgon Wyrm Juvenile | [[Regions/Goldmere Coast\|Goldmere Coast]] | Juvenile | SS- | 218 | 19.04 m | Night | Like a typical Elder Gorgon Wyrm, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04218` | Whitewater Reach Elder Gorgon Wyrm | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | SS | 236 | 22.4 m | Night | A typical adult Elder Gorgon Wyrm of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `rock_debris` · palette `#455e72` `#314250` `#d1a15a` · elongated, irregular silhouette; still-then-sudden timing
