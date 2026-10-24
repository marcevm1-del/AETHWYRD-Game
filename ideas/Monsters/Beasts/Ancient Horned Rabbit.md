---
type: monster
id: mon_ancient_horned_rabbit
family: "Beasts"
rank: "E-"
tier: variant
tags: [monster, beasts]
---
# Ancient Horned Rabbit

![[mon_ancient_horned_rabbit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_horned_rabbit_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Horned Rabbit is a small creature with a small, quick four-legged body, about 0.6 m long. Its coat is weathered and natural, colored in muted greys and dusty browns. Guild sketches always show a single spiral horn and oversized hind feet. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Horned Rabbit\|Horned Rabbit]] (ancient) |
| Rank · level | E- · 19 (13–26) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 0.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 585 · 86 · 69 · 42 · 69 · 135 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (override (base species)); animation set `anim_quad_small`.
- **Dimensions:** 0.41 m high × 0.6 m long × 0.08 m wide; prefab scale 1.2.
- **Physics:** 6.5 kg, gravity ×1.6, poise 25, knockback resistance 0.08, death style `ragdoll_tumble`.
- **Navigation:** speed 7.84 m/s, turn 697°/s, stopping distance 0.5 m.
- **Attack count:** 4; **signature:** a single spiral horn and oversized hind feet.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |

## Field guide

Ancient Horned Rabbit is a **wild beast** encountered at E- rank, around level 19. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a single spiral horn and oversized hind feet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]], [[Regions/Mossdeep|Mossdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Fanghold\|Fanghold]] | 5 | E-, D-, E, F+, F | 8–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, E+, F | 8–40 | Day & Night |
| [[Regions/Mossdeep\|Mossdeep]] | 3 | E, E+, F+ | 13–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03280` | Fanghold Ancient Horned Rabbit | [[Regions/Fanghold\|Fanghold]] | Adult | E- | 19 | 0.6 m | Day & Night | A typical adult Ancient Horned Rabbit of this region, with golden, grass-toned coloring. |
| `pop_03281` | Aldmere Ancient Horned Rabbit Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 0.81 m | Day & Night | Like a typical Ancient Horned Rabbit, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03282` | Aldmere Ancient Horned Rabbit Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 0.75 m | Day & Night | Like a typical Ancient Horned Rabbit, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03283` | Fanghold Ancient Horned Rabbit Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D- | 40 | 0.81 m | Day & Night | Like a typical Ancient Horned Rabbit, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03284` | Fanghold Ancient Horned Rabbit Albino | [[Regions/Fanghold\|Fanghold]] | Albino | E | 26 | 0.6 m | Day & Night | Like a typical Ancient Horned Rabbit, but a rare pale form with white skin or fur and red eyes. |
| `pop_03285` | Aldmere Ancient Horned Rabbit Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 0.42 m | Day & Night | Like a typical Ancient Horned Rabbit, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03286` | Fanghold Ancient Horned Rabbit Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | F+ | 13 | 0.51 m | Day & Night | Like a typical Ancient Horned Rabbit, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03287` | Mossdeep Ancient Horned Rabbit Albino | [[Regions/Mossdeep\|Mossdeep]] | Albino | E | 26 | 0.6 m | Day & Night | Like a typical Ancient Horned Rabbit, but a rare pale form with white skin or fur and red eyes. |
| `pop_03288` | Mossdeep Ancient Horned Rabbit Alpha | [[Regions/Mossdeep\|Mossdeep]] | Alpha | E+ | 32 | 0.75 m | Day & Night | Like a typical Ancient Horned Rabbit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03289` | Fanghold Ancient Horned Rabbit Runt | [[Regions/Fanghold\|Fanghold]] | Runt | F | 8 | 0.42 m | Day & Night | Like a typical Ancient Horned Rabbit, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03290` | Mossdeep Ancient Horned Rabbit Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | F+ | 13 | 0.51 m | Day & Night | Like a typical Ancient Horned Rabbit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_groom` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · real-animal silhouette with one fantasy exaggeration
