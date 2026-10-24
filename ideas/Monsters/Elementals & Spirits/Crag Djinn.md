---
type: monster
id: mon_crag_djinn
family: "Elementals & Spirits"
rank: "A-"
tier: variant
tags: [monster, elementals-spirits]
---
# Crag Djinn

> The Crag Djinn is a large creature with a floating, cloth-like shape, about 4 m tall. Its body is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a cloud body with lightning tattoos. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Storm Djinn\|Storm Djinn]] (regional) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17491 · 323 · 377 · 753 · 699 · 90 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 4 m high × 1.2 m long × 2.56 m wide; prefab scale 4.
- **Physics:** 8.3 kg, gravity ×0, poise 67, knockback resistance 0.3, death style `dissolve_into_motes`.
- **Navigation:** speed 10.48 m/s, turn 360°/s, stopping distance 1.4 m.
- **Attack count:** 5; **signature:** a cloud body with lightning tattoos.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Djinn is a **menacing elemental** encountered at A- rank, around level 132. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cloud body with lightning tattoos. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits A|loot_elemental_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | S-, B, B+, A, A- | 108–173 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | B+, B, S-, A | 108–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04539` | Shen-Lu Crag Djinn Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S- | 173 | 5.4 m | Day & Night | Like a typical Crag Djinn, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04540` | Shen-Lu Crag Djinn Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | B | 108 | 2.8 m | Day & Night | Like a typical Crag Djinn, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04541` | Hoshizora Crag Djinn Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B+ | 120 | 3.4 m | Day & Night | Like a typical Crag Djinn, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04542` | Shen-Lu Crag Djinn Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | B+ | 120 | 3.4 m | Day & Night | Like a typical Crag Djinn, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04543` | Hoshizora Crag Djinn Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B | 108 | 2.8 m | Day & Night | Like a typical Crag Djinn, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04544` | Hoshizora Crag Djinn Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S- | 173 | 5.4 m | Day & Night | Like a typical Crag Djinn, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04545` | Hoshizora Crag Djinn Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A | 146 | 4.4 m | Day & Night | Like a typical Crag Djinn, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04546` | Shen-Lu Crag Djinn Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | A | 146 | 4.4 m | Day & Night | Like a typical Crag Djinn, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04547` | Shen-Lu Crag Djinn Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A | 146 | 4 m | Day & Night | Like a typical Crag Djinn, but a rare pale form with white skin or fur and red eyes. |
| `pop_04548` | Shen-Lu Crag Djinn | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A- | 132 | 4 m | Day & Night | A typical adult Crag Djinn of this region, with slate-grey coloring and hardened hide. |
| `pop_04549` | Hoshizora Crag Djinn Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A | 146 | 4 m | Day & Night | Like a typical Crag Djinn, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
