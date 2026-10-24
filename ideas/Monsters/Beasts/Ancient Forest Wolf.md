---
type: monster
id: mon_ancient_forest_wolf
family: "Beasts"
rank: "E+"
tier: variant
tags: [monster, beasts]
---
# Ancient Forest Wolf

![[mon_ancient_forest_wolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_forest_wolf_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,824 tris · 0.694 × 1.8 × 1.566 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Forest Wolf is a person-sized creature with a powerful four-legged hunter's body, about 1.8 m long. Its coat is weathered and natural, colored in muted greys and dusty browns. Its most striking feature is a grey-green coat that blends with ferns. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Forest Wolf\|Forest Wolf]] (ancient) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 1.8 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2264 · 166 · 138 · 77 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_medium\|quad_medium]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_medium|quad_medium]] (override (base species)); animation set `anim_quad_large`.
- **Dimensions:** 1.21 m high × 1.8 m long × 0.25 m wide; prefab scale 1.2.
- **Physics:** 70 kg, gravity ×1.4, poise 50, knockback resistance 0.33, death style `ragdoll_slide`.
- **Navigation:** speed 8.7 m/s, turn 298°/s, stopping distance 0.69 m.
- **Attack count:** 4; **signature:** a grey-green coat that blends with ferns.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Ancient Forest Wolf is a **wild beast** encountered at E+ rank, around level 32. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a grey-green coat that blends with ferns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts E|loot_beast_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 6 | D-, D+, E-, D, E+ | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | D, E+, E-, D+, D- | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06132` | Fanghold Ancient Forest Wolf Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D- | 40 | 1.8 m | Day & Night | Like a typical Ancient Forest Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06133` | Fanghold Ancient Forest Wolf Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 2.43 m | Day & Night | Like a typical Ancient Forest Wolf, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06134` | Aldmere Ancient Forest Wolf Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2.25 m | Day & Night | Like a typical Ancient Forest Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06135` | Aldmere Ancient Forest Wolf | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 1.8 m | Day & Night | A typical adult Ancient Forest Wolf of this region, with golden, grass-toned coloring. |
| `pop_06136` | Aldmere Ancient Forest Wolf Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.26 m | Day & Night | Like a typical Ancient Forest Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06137` | Fanghold Ancient Forest Wolf Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 1.98 m | Day & Night | Like a typical Ancient Forest Wolf, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06138` | Fanghold Ancient Forest Wolf Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E- | 19 | 1.26 m | Day & Night | Like a typical Ancient Forest Wolf, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06139` | Aldmere Ancient Forest Wolf Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 2.43 m | Day & Night | Like a typical Ancient Forest Wolf, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06140` | Aldmere Ancient Forest Wolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.8 m | Day & Night | Like a typical Ancient Forest Wolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06141` | Fanghold Ancient Forest Wolf Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 2.25 m | Day & Night | Like a typical Ancient Forest Wolf, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_06142` | Fanghold Ancient Forest Wolf | [[Regions/Fanghold\|Fanghold]] | Adult | E+ | 32 | 1.8 m | Day & Night | A typical adult Ancient Forest Wolf of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · real-animal silhouette with one fantasy exaggeration
