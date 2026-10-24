---
type: monster
id: mon_vesper_touched_phoenix
family: "Avians"
rank: "SS-"
tier: variant
tags: [monster, avians]
---
# Vesper-Touched Phoenix

> The Vesper-Touched Phoenix is a huge creature with a broad-winged bird frame, about 6 m tall. Its plumage is weathered and natural, colored in ember reds fading to soot black. Its most striking feature is feathers of living flame that fall as embers. It has alert animal eyes. The air distorts slightly around its outline. It prowls, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Phoenix\|Phoenix]] (corrupted) |
| Rank · level | SS- · 218 (203–236) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 44742 · 882 · 706 · 617 · 706 · 135 |
| XP · gold | 16552 · 2821 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Water. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 2.76 m high × 6 m long × 10.32 m wide; prefab scale 10.
- **Physics:** 3024 kg, gravity ×1, poise 979, knockback resistance 0.26, death style `tumble_feathers_burst`.
- **Navigation:** speed 8.37 m/s, turn 245°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** feathers of living flame that fall as embers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Phoenix is a **wild avian** encountered at SS- rank, around level 218. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** feathers of living flame that fall as embers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Avians SS|loot_avian_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 7 | S, SSS-, SS, S+, SS+, SS- | 188–267 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04990` | Sky Archipelago Vesper-Touched Phoenix Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S | 188 | 4.2 m | Day & Night | Like a typical Vesper-Touched Phoenix, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04991` | Sky Archipelago Vesper-Touched Phoenix Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SSS- | 267 | 8.1 m | Day & Night | Like a typical Vesper-Touched Phoenix, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04992` | Sky Archipelago Vesper-Touched Phoenix Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS | 236 | 6.6 m | Day & Night | Like a typical Vesper-Touched Phoenix, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04993` | Sky Archipelago Vesper-Touched Phoenix Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S+ | 203 | 5.1 m | Day & Night | Like a typical Vesper-Touched Phoenix, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04994` | Sky Archipelago Vesper-Touched Phoenix Alpha | [[Regions/Sky Archipelago\|Sky Archipelago]] | Alpha | SS+ | 253 | 7.5 m | Day & Night | Like a typical Vesper-Touched Phoenix, but larger and scarred, and others of its kind follow it, with cloud-pale coloring and lighter bones. |
| `pop_04995` | Sky Archipelago Vesper-Touched Phoenix | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS- | 218 | 6 m | Day & Night | A typical adult Vesper-Touched Phoenix of this region, with cloud-pale coloring and lighter bones. |
| `pop_04996` | Sky Archipelago Vesper-Touched Phoenix Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS | 236 | 6 m | Day & Night | Like a typical Vesper-Touched Phoenix, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
