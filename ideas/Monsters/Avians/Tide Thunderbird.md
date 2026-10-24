---
type: monster
id: mon_tide_thunderbird
family: "Avians"
rank: "B+"
tier: variant
tags: [monster, avians]
---
# Tide Thunderbird

> The Tide Thunderbird is a huge creature with a feathered avian body, about 8 m tall. Its plumage is rough, scarred and spiked, colored in deep blues with a glassy shine. Look for wings that drum thunder. It has burning slit pupils. Faint runes glow along its body when it fights. It circles its prey, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Thunderbird\|Thunderbird]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 8 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19977 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Stormreach\|Stormreach]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Lightning. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 3.68 m high × 8 m long × 13.76 m wide; prefab scale 13.333.
- **Physics:** 7526.4 kg, gravity ×1, poise 1209, knockback resistance 0.17, death style `tumble_feathers_burst`.
- **Navigation:** speed 9.67 m/s, turn 212°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** wings that drum thunder.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tide Thunderbird is a **menacing avian** encountered at B+ rank, around level 120. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that drum thunder. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians B|loot_avian_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 4 | A-, B-, B, B+ | 96–132 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | A, B, B- | 96–146 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | B, B+, A-, A | 108–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04968` | Stormreach Tide Thunderbird Albino | [[Regions/Stormreach\|Stormreach]] | Albino | A- | 132 | 8 m | Day & Night | Like a typical Tide Thunderbird, but a rare pale form with white skin or fur and red eyes. |
| `pop_04969` | Kitsune Isles Tide Thunderbird Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | A | 146 | 10 m | Day & Night | Like a typical Tide Thunderbird, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04970` | Hoshizora Tide Thunderbird Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B | 108 | 6.8 m | Day & Night | Like a typical Tide Thunderbird, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04971` | Stormreach Tide Thunderbird Runt | [[Regions/Stormreach\|Stormreach]] | Runt | B- | 96 | 5.6 m | Day & Night | Like a typical Tide Thunderbird, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04972` | Kitsune Isles Tide Thunderbird Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | B | 108 | 6.8 m | Day & Night | Like a typical Tide Thunderbird, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04973` | Stormreach Tide Thunderbird Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | B | 108 | 6.8 m | Day & Night | Like a typical Tide Thunderbird, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04974` | Stormreach Tide Thunderbird | [[Regions/Stormreach\|Stormreach]] | Adult | B+ | 120 | 8 m | Day & Night | A typical adult Tide Thunderbird of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04975` | Hoshizora Tide Thunderbird | [[Regions/Hoshizora\|Hoshizora]] | Adult | B+ | 120 | 8 m | Day & Night | A typical adult Tide Thunderbird of this region, with slate-grey coloring and hardened hide. |
| `pop_04976` | Hoshizora Tide Thunderbird Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A- | 132 | 8 m | Day & Night | Like a typical Tide Thunderbird, but a rare pale form with white skin or fur and red eyes. |
| `pop_04977` | Hoshizora Tide Thunderbird Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A | 146 | 10 m | Day & Night | Like a typical Tide Thunderbird, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04978` | Kitsune Isles Tide Thunderbird Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | B- | 96 | 5.6 m | Day & Night | Like a typical Tide Thunderbird, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
