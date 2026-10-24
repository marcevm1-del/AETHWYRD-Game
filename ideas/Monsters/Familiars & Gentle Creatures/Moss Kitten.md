---
type: monster
id: mon_moss_kitten
family: "Familiars & Gentle Creatures"
rank: "E+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Moss Kitten

![[mon_moss_kitten_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_moss_kitten_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,606 tris · 0.096 × 0.4 × 0.16 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Moss Kitten is a tiny creature with a compact quadruped frame, about 0.4 m long. Its coat is smooth and clean, colored in leaf greens over bark brown. Look for fur that flickers like candle flame. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It hops in little bursts, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Ember Kitten\|Ember Kitten]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1103 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.27 m high × 0.4 m long × 0.06 m wide; prefab scale 0.8.
- **Physics:** 1.9 kg, gravity ×1.6, poise 21, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 4.56 m/s, turn 854°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** fur that flickers like candle flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moss Kitten is a **charming familiar** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fur that flickers like candle flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Sylvaran|Sylvaran]], [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures E|loot_familiar_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Mossdeep\|Mossdeep]] | 3 | D+, E, D- | 26–56 | Day |
| [[Regions/Aldmere\|Aldmere]] | 3 | D, D-, D+ | 40–56 | Day |
| [[Regions/Sylvaran\|Sylvaran]] | 5 | D+, E, E-, D-, D | 19–56 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05714` | Mossdeep Moss Kitten Elderborn | [[Regions/Mossdeep\|Mossdeep]] | Elderborn | D+ | 56 | 0.54 m | Day | Like a typical Moss Kitten, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05715` | Aldmere Moss Kitten Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Moss Kitten, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05716` | Aldmere Moss Kitten Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Moss Kitten, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05717` | Sylvaran Moss Kitten Elderborn | [[Regions/Sylvaran\|Sylvaran]] | Elderborn | D+ | 56 | 0.54 m | Day | Like a typical Moss Kitten, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05718` | Sylvaran Moss Kitten Juvenile | [[Regions/Sylvaran\|Sylvaran]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Moss Kitten, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05719` | Mossdeep Moss Kitten Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | E | 26 | 0.34 m | Day | Like a typical Moss Kitten, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05720` | Mossdeep Moss Kitten Albino | [[Regions/Mossdeep\|Mossdeep]] | Albino | D- | 40 | 0.4 m | Day | Like a typical Moss Kitten, but a rare pale form with white skin or fur and red eyes. |
| `pop_05721` | Sylvaran Moss Kitten Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | E- | 19 | 0.28 m | Day | Like a typical Moss Kitten, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05722` | Aldmere Moss Kitten Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 0.54 m | Day | Like a typical Moss Kitten, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05723` | Sylvaran Moss Kitten Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | D- | 40 | 0.44 m | Day | Like a typical Moss Kitten, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05724` | Sylvaran Moss Kitten Alpha | [[Regions/Sylvaran\|Sylvaran]] | Alpha | D | 48 | 0.5 m | Day | Like a typical Moss Kitten, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
