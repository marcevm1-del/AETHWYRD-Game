---
type: monster
id: mon_ancient_hippogriff
family: "Avians"
rank: "B"
tier: variant
tags: [monster, avians]
---
# Ancient Hippogriff

> The Ancient Hippogriff is a large creature with a heavy, muscular quadruped frame, about 4.2 m long. Its plumage is weathered and natural, colored in pale jade and cloud white. Guild sketches always show an eagle's head on a horse's body. It has dark, wary eyes. Faint runes glow along its body when it fights. It stalks low to the ground, surrounded by swirling leaves and a constant breeze. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Hippogriff\|Hippogriff]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 4.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18111 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Stormreach\|Stormreach]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.73 m high × 4.2 m long × 0.67 m wide; prefab scale 1.05.
- **Physics:** 1333.6 kg, gravity ×0.96, poise 115, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 8.95 m/s, turn 156°/s, stopping distance 1.24 m.
- **Attack count:** 5; **signature:** an eagle's head on a horse's body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Hippogriff is a **wild avian** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an eagle's head on a horse's body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Stormreach\|Stormreach]] | 6 | A-, C+, B, A, B-, B+ | 86–146 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | B, B-, A-, C+, A | 86–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04957` | Stormreach Ancient Hippogriff Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | A- | 132 | 5.25 m | Day & Night | Like a typical Ancient Hippogriff, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04958` | Hoshizora Ancient Hippogriff | [[Regions/Hoshizora\|Hoshizora]] | Adult | B | 108 | 4.2 m | Day & Night | A typical adult Ancient Hippogriff of this region, with slate-grey coloring and hardened hide. |
| `pop_04959` | Stormreach Ancient Hippogriff Runt | [[Regions/Stormreach\|Stormreach]] | Runt | C+ | 86 | 2.94 m | Day & Night | Like a typical Ancient Hippogriff, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04960` | Stormreach Ancient Hippogriff | [[Regions/Stormreach\|Stormreach]] | Adult | B | 108 | 4.2 m | Day & Night | A typical adult Ancient Hippogriff of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04961` | Hoshizora Ancient Hippogriff Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B- | 96 | 3.57 m | Day & Night | Like a typical Ancient Hippogriff, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04962` | Stormreach Ancient Hippogriff Elderborn | [[Regions/Stormreach\|Stormreach]] | Elderborn | A | 146 | 5.67 m | Day & Night | Like a typical Ancient Hippogriff, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04963` | Hoshizora Ancient Hippogriff Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A- | 132 | 5.25 m | Day & Night | Like a typical Ancient Hippogriff, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04964` | Stormreach Ancient Hippogriff Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | B- | 96 | 3.57 m | Day & Night | Like a typical Ancient Hippogriff, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04965` | Hoshizora Ancient Hippogriff Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C+ | 86 | 2.94 m | Day & Night | Like a typical Ancient Hippogriff, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04966` | Stormreach Ancient Hippogriff Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | B+ | 120 | 4.62 m | Day & Night | Like a typical Ancient Hippogriff, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04967` | Hoshizora Ancient Hippogriff Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A | 146 | 5.67 m | Day & Night | Like a typical Ancient Hippogriff, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
