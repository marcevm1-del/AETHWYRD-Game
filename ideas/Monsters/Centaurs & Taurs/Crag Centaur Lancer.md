---
type: monster
id: mon_crag_centaur_lancer
family: "Centaurs & Taurs"
rank: "B-"
tier: variant
tags: [monster, centaurs-taurs]
---
# Crag Centaur Lancer

![[mon_crag_centaur_lancer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_centaur_lancer_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,004 tris · 1.241 × 2.018 × 2.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Centaur Lancer is a large creature with a powerful taur build, about 2.6 m tall. Its coat is weathered and natural, colored in dapple-grey, with ochre markings. Look for a long lance and painted barding. It has dark, wary eyes. Faint runes glow along its body when it fights. It prowls, surrounded by pebbles that tremble and float near it. This Earth-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Variant of | [[Monsters/Centaurs & Taurs/Centaur Lancer\|Centaur Lancer]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 2.6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12957 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 2.73 m high × 2.6 m long × 0.62 m wide; prefab scale 1.083.
- **Physics:** 457 kg, gravity ×1.43, poise 130, knockback resistance 0.87, death style `ragdoll_slide`.
- **Navigation:** speed 7.78 m/s, turn 223°/s, stopping distance 0.82 m.
- **Attack count:** 5; **signature:** a long lance and painted barding.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Centaur Lancer is a **wild beastfolk** encountered at B- rank, around level 96. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a long lance and painted barding. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Moraveil|Moraveil]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs B|loot_centaur_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 4 | B, C+, C, B- | 76–108 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C, C+, B-, A- | 76–132 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B+, B-, B | 96–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05147` | Zaruma Crag Centaur Lancer Albino | [[Regions/Zaruma\|Zaruma]] | Albino | B | 108 | 2.6 m | Day & Night | Like a typical Crag Centaur Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05148` | Moraveil Crag Centaur Lancer Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C | 76 | 1.82 m | Day & Night | Like a typical Crag Centaur Lancer, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05149` | Zaruma Crag Centaur Lancer Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | C+ | 86 | 2.21 m | Day & Night | Like a typical Crag Centaur Lancer, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05150` | Moraveil Crag Centaur Lancer Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C+ | 86 | 2.21 m | Day & Night | Like a typical Crag Centaur Lancer, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05151` | Zaruma Crag Centaur Lancer Runt | [[Regions/Zaruma\|Zaruma]] | Runt | C | 76 | 1.82 m | Day & Night | Like a typical Crag Centaur Lancer, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05152` | Hoshizora Crag Centaur Lancer Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B+ | 120 | 3.25 m | Day & Night | Like a typical Crag Centaur Lancer, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05153` | Moraveil Crag Centaur Lancer | [[Regions/Moraveil\|Moraveil]] | Adult | B- | 96 | 2.6 m | Day & Night | A typical adult Crag Centaur Lancer of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05154` | Moraveil Crag Centaur Lancer Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A- | 132 | 3.51 m | Day & Night | Like a typical Crag Centaur Lancer, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05155` | Hoshizora Crag Centaur Lancer | [[Regions/Hoshizora\|Hoshizora]] | Adult | B- | 96 | 2.6 m | Day & Night | A typical adult Crag Centaur Lancer of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05156` | Hoshizora Crag Centaur Lancer Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B | 108 | 2.6 m | Day & Night | Like a typical Crag Centaur Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05157` | Zaruma Crag Centaur Lancer | [[Regions/Zaruma\|Zaruma]] | Adult | B- | 96 | 2.6 m | Day & Night | A typical adult Crag Centaur Lancer of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `rock_debris` · palette `#c1bfb6` `#85837c` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
