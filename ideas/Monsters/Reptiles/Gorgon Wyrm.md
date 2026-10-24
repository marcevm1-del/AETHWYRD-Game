---
type: monster
id: mon_gorgon_wyrm
family: "Reptiles"
rank: "S"
tier: core
tags: [monster, reptiles]
---
# Gorgon Wyrm

> The Gorgon Wyrm is a huge creature with a coiling, legless body, about 14 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Its most striking feature is a stone-crusted body that leaves statues in its wake. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It glides without moving its legs, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 14 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 45633 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 13063 · 2293 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Stormreach\|Stormreach]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.56 m high × 14 m long × 1.4 m wide; prefab scale 3.5.
- **Physics:** 8204.6 kg, gravity ×1.32, poise 761, knockback resistance 0.73, death style `limp_chain`.
- **Navigation:** speed 10.06 m/s, turn 80°/s, stopping distance 0.89 m.
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

Gorgon Wyrm is a **dread reptile** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-crusted body that leaves statues in its wake. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]], [[Regions/Whitewater Reach|Whitewater Reach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles S|loot_reptile_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Reptiles/Elder Gorgon Wyrm|Elder Gorgon Wyrm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 5 | SS-, S+, S-, S, SS | 173–236 | Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 6 | A+, SS, S, S+, SS-, S- | 159–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01319` | Stormreach Gorgon Wyrm Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | SS- | 218 | 17.5 m | Night | Like a typical Gorgon Wyrm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01320` | Whitewater Reach Gorgon Wyrm Runt | [[Regions/Whitewater Reach\|Whitewater Reach]] | Runt | A+ | 159 | 9.8 m | Night | Like a typical Gorgon Wyrm, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01321` | Whitewater Reach Gorgon Wyrm Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | SS | 236 | 18.9 m | Night | Like a typical Gorgon Wyrm, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01322` | Stormreach Gorgon Wyrm Albino | [[Regions/Stormreach\|Stormreach]] | Albino | S+ | 203 | 14 m | Night | Like a typical Gorgon Wyrm, but a rare pale form with white skin or fur and red eyes. |
| `pop_01323` | Stormreach Gorgon Wyrm Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | S- | 173 | 11.9 m | Night | Like a typical Gorgon Wyrm, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01324` | Stormreach Gorgon Wyrm | [[Regions/Stormreach\|Stormreach]] | Adult | S | 188 | 14 m | Night | A typical adult Gorgon Wyrm of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01325` | Whitewater Reach Gorgon Wyrm | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | S | 188 | 14 m | Night | A typical adult Gorgon Wyrm of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01326` | Whitewater Reach Gorgon Wyrm Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | S+ | 203 | 15.4 m | Night | Like a typical Gorgon Wyrm, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01327` | Whitewater Reach Gorgon Wyrm Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | SS- | 218 | 17.5 m | Night | Like a typical Gorgon Wyrm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01328` | Whitewater Reach Gorgon Wyrm Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | S- | 173 | 11.9 m | Night | Like a typical Gorgon Wyrm, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01329` | Stormreach Gorgon Wyrm Elderborn | [[Regions/Stormreach\|Stormreach]] | Elderborn | SS | 236 | 18.9 m | Night | Like a typical Gorgon Wyrm, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
