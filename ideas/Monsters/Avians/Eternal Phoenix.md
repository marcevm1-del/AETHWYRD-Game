---
type: monster
id: mon_eternal_phoenix
family: "Avians"
rank: "SSS"
tier: core
tags: [monster, avians]
---
# Eternal Phoenix

![[mon_eternal_phoenix_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_eternal_phoenix_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,912 tris · 32.213 × 38.192 × 30 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Eternal Phoenix is a colossal creature with a broad-winged bird frame, about 30 m tall. Its plumage is smooth and clean, colored in blue, with ember-orange markings. Survivors describe a sun-bright body that rises again from its own ash. It has wide curious eyes with star-shaped highlights. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It bounces happily, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | SSS · 281 (267–294) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 30 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 100296 · 1134 · 907 · 794 · 907 · 135 |
| XP · gold | 24842 · 4024 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 13.8 m high × 30 m long × 51.6 m wide; prefab scale 50.
- **Physics:** 378000 kg, gravity ×1, poise 12710, knockback resistance 0.29, death style `tumble_feathers_burst`.
- **Navigation:** speed 14.04 m/s, turn 110°/s, stopping distance 6.4 m.
- **Attack count:** 5; **signature:** a sun-bright body that rises again from its own ash.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Eternal Phoenix is a **charming avian** encountered at SSS rank, around level 281. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a sun-bright body that rises again from its own ash. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians SSS|loot_avian_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Avians/Brine Eternal Phoenix|Brine Eternal Phoenix]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 5 | SSS+, SSS-, SSS, EX | 267–300 | Day |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | SSS, EX, SSS-, EX-, SSS+ | 267–300 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02151` | Moraveil Eternal Phoenix Albino | [[Regions/Moraveil\|Moraveil]] | Albino | SSS+ | 294 | 30 m | Day | Like a typical Eternal Phoenix, but a rare pale form with white skin or fur and red eyes. |
| `pop_02152` | Sky Archipelago Eternal Phoenix | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SSS | 281 | 30 m | Day | A typical adult Eternal Phoenix of this region, with cloud-pale coloring and lighter bones. |
| `pop_02153` | Sky Archipelago Eternal Phoenix Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | EX | 300 | 40.5 m | Day | Like a typical Eternal Phoenix, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_02154` | Sky Archipelago Eternal Phoenix Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | SSS- | 267 | 25.5 m | Day | Like a typical Eternal Phoenix, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_02155` | Moraveil Eternal Phoenix Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | SSS- | 267 | 25.5 m | Day | Like a typical Eternal Phoenix, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02156` | Moraveil Eternal Phoenix | [[Regions/Moraveil\|Moraveil]] | Adult | SSS | 281 | 30 m | Day | A typical adult Eternal Phoenix of this region, with golden, grass-toned coloring. |
| `pop_02157` | Sky Archipelago Eternal Phoenix Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | EX- | 300 | 37.5 m | Day | Like a typical Eternal Phoenix, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_02158` | Moraveil Eternal Phoenix Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | EX | 300 | 40.5 m | Day | Like a typical Eternal Phoenix, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02159` | Sky Archipelago Eternal Phoenix Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SSS+ | 294 | 33 m | Day | Like a typical Eternal Phoenix, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_02160` | Sky Archipelago Eternal Phoenix Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SSS+ | 294 | 30 m | Day | Like a typical Eternal Phoenix, but a rare pale form with white skin or fur and red eyes. |
| `pop_02161` | Moraveil Eternal Phoenix Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | SSS+ | 294 | 33 m | Day | Like a typical Eternal Phoenix, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `embers_heat_haze` · palette `#506cb5` `#364a7e` `#ff7a3d` · circle-based, soft silhouette
