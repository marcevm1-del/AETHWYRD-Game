---
type: monster
id: mon_hunger_colossus
family: "Yokai-Inspired Spirits"
rank: "A"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Hunger Colossus

> The Hunger Colossus is a colossal creature with a giant, barrel-chested humanoid body, about 30 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a skeleton giant built from the bones of the starved. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 30 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 62014 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Haneul\|Haneul]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 30 m high × 9 m long × 12.6 m wide; prefab scale 8.571.
- **Physics:** 486000 kg, gravity ×1.3, poise 717, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 20.26 m/s, turn 69°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a skeleton giant built from the bones of the starved.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hunger Colossus is a **dread spirit** encountered at A rank, around level 146. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a skeleton giant built from the bones of the starved. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Haneul|Haneul]], [[Regions/Everdusk|Everdusk]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits A|loot_yokai_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Rain Hunger Colossus|Rain Hunger Colossus]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 3 | A+, A | 146–159 | Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 1 | S- | 173–173 | Night |
| [[Regions/Haneul\|Haneul]] | 3 | A-, S-, A+ | 132–173 | Night |
| [[Regions/Everdusk\|Everdusk]] | 2 | A-, A+ | 132–159 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | A-, A+ | 132–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02538` | Hoshizora Hunger Colossus Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A+ | 159 | 33 m | Night | Like a typical Hunger Colossus, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02539` | Kitsune Isles Hunger Colossus Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | S- | 173 | 37.5 m | Night | Like a typical Hunger Colossus, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02540` | Haneul Hunger Colossus Juvenile | [[Regions/Haneul\|Haneul]] | Juvenile | A- | 132 | 25.5 m | Night | Like a typical Hunger Colossus, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02541` | Haneul Hunger Colossus Alpha | [[Regions/Haneul\|Haneul]] | Alpha | S- | 173 | 37.5 m | Night | Like a typical Hunger Colossus, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02542` | Everdusk Hunger Colossus Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | A- | 132 | 25.5 m | Night | Like a typical Hunger Colossus, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02543` | Shen-Lu Hunger Colossus Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | A- | 132 | 25.5 m | Night | Like a typical Hunger Colossus, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02544` | Haneul Hunger Colossus Albino | [[Regions/Haneul\|Haneul]] | Albino | A+ | 159 | 30 m | Night | Like a typical Hunger Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_02545` | Shen-Lu Hunger Colossus Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A+ | 159 | 30 m | Night | Like a typical Hunger Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_02546` | Hoshizora Hunger Colossus | [[Regions/Hoshizora\|Hoshizora]] | Adult | A | 146 | 30 m | Night | A typical adult Hunger Colossus of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02547` | Hoshizora Hunger Colossus Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A+ | 159 | 30 m | Night | Like a typical Hunger Colossus, but a rare pale form with white skin or fur and red eyes. |
| `pop_02548` | Everdusk Hunger Colossus Scarred | [[Regions/Everdusk\|Everdusk]] | Scarred | A+ | 159 | 33 m | Night | Like a typical Hunger Colossus, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
