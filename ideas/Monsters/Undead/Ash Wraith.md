---
type: monster
id: mon_ash_wraith
family: "Undead"
rank: "D+"
tier: variant
tags: [monster, undead]
---
# Ash Wraith

> The Ash Wraith is a person-sized creature with a drifting, half-formed body, about 2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Survivors describe a hooded shape of smoke with cold blue eyes. It has pale, pupil-less eyes. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Wraith\|Wraith]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3872 · 140 · 164 · 328 · 304 · 90 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2 m high × 0.6 m long × 1.28 m wide; prefab scale 2.
- **Physics:** 0.8 kg, gravity ×0, poise 15, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 8.86 m/s, turn 509°/s, stopping distance 0.9 m.
- **Attack count:** 5; **signature:** a hooded shape of smoke with cold blue eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ash Wraith is a **dread undead** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hooded shape of smoke with cold blue eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead D|loot_undead_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | C+, D, D+, D- | 40–86 | Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | C, C+, C- | 65–86 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, C, C+, D | 48–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03782` | Aldmere Ash Wraith Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Ash Wraith, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03783` | Greymoor Ash Wraith Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Ash Wraith, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03784` | Strife Marches Ash Wraith Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 2.2 m | Night | Like a typical Ash Wraith, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03785` | Greymoor Ash Wraith Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Ash Wraith, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03786` | Strife Marches Ash Wraith Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C | 76 | 2.5 m | Night | Like a typical Ash Wraith, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03787` | Aldmere Ash Wraith Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.7 m | Night | Like a typical Ash Wraith, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03788` | Strife Marches Ash Wraith Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | C+ | 86 | 2.7 m | Night | Like a typical Ash Wraith, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03789` | Aldmere Ash Wraith | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 2 m | Night | A typical adult Ash Wraith of this region, with mud-slick, algae-streaked skin. |
| `pop_03790` | Strife Marches Ash Wraith Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 1.7 m | Night | Like a typical Ash Wraith, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03791` | Aldmere Ash Wraith Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.4 m | Night | Like a typical Ash Wraith, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03792` | Greymoor Ash Wraith Albino | [[Regions/Greymoor\|Greymoor]] | Albino | C- | 65 | 2 m | Night | Like a typical Ash Wraith, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
