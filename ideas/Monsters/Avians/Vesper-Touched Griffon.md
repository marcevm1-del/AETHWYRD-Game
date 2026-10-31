---
type: monster
id: mon_vesper_touched_griffon
family: "Avians"
rank: "B-"
tier: variant
tags: [monster, avians]
---
# Vesper-Touched Griffon

![[mon_vesper_touched_griffon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_griffon_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,374 tris · 0.773 × 3 × 1.745 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Griffon is a large creature with a powerful four-legged hunter's body, about 3 m long. Its plumage is rough, scarred and spiked, colored in crow-black, with pale jade markings. Survivors describe an eagle's front and a lion's back. It has burning slit pupils. Faint runes glow along its body when it fights. It circles its prey, surrounded by swirling leaves and a constant breeze. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Variant of | [[Monsters/Avians/Griffon\|Griffon]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13598 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Heavenreach\|Heavenreach]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 486 kg, gravity ×0.96, poise 97, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 7.22 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** an eagle's front and a lion's back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Feather Volley\|Feather Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Griffon is a **menacing avian** encountered at B- rank, around level 96. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an eagle's front and a lion's back. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vharlen|Vharlen]], [[Regions/Heavenreach|Heavenreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Vharlen\|Vharlen]] | 6 | B+, A-, B, C, B- | 76–132 | Day & Night |
| [[Regions/Heavenreach\|Heavenreach]] | 5 | C, B+, A-, B-, C+ | 76–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04946` | Vharlen Vesper-Touched Griffon Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | B+ | 120 | 3.75 m | Day & Night | Like a typical Vesper-Touched Griffon, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_04947` | Vharlen Vesper-Touched Griffon Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | A- | 132 | 4.05 m | Day & Night | Like a typical Vesper-Touched Griffon, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_04948` | Vharlen Vesper-Touched Griffon Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | B | 108 | 3.3 m | Day & Night | Like a typical Vesper-Touched Griffon, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_04949` | Vharlen Vesper-Touched Griffon Runt | [[Regions/Vharlen\|Vharlen]] | Runt | C | 76 | 2.1 m | Day & Night | Like a typical Vesper-Touched Griffon, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_04950` | Heavenreach Vesper-Touched Griffon Runt | [[Regions/Heavenreach\|Heavenreach]] | Runt | C | 76 | 2.1 m | Day & Night | Like a typical Vesper-Touched Griffon, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04951` | Heavenreach Vesper-Touched Griffon Alpha | [[Regions/Heavenreach\|Heavenreach]] | Alpha | B+ | 120 | 3.75 m | Day & Night | Like a typical Vesper-Touched Griffon, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04952` | Heavenreach Vesper-Touched Griffon Elderborn | [[Regions/Heavenreach\|Heavenreach]] | Elderborn | A- | 132 | 4.05 m | Day & Night | Like a typical Vesper-Touched Griffon, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04953` | Heavenreach Vesper-Touched Griffon | [[Regions/Heavenreach\|Heavenreach]] | Adult | B- | 96 | 3 m | Day & Night | A typical adult Vesper-Touched Griffon of this region, with slate-grey coloring and hardened hide. |
| `pop_04954` | Vharlen Vesper-Touched Griffon | [[Regions/Vharlen\|Vharlen]] | Adult | B- | 96 | 3 m | Day & Night | A typical adult Vesper-Touched Griffon of this region, with golden, grass-toned coloring. |
| `pop_04955` | Heavenreach Vesper-Touched Griffon Juvenile | [[Regions/Heavenreach\|Heavenreach]] | Juvenile | C+ | 86 | 2.55 m | Day & Night | Like a typical Vesper-Touched Griffon, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04956` | Vharlen Vesper-Touched Griffon Albino | [[Regions/Vharlen\|Vharlen]] | Albino | B | 108 | 3 m | Day & Night | Like a typical Vesper-Touched Griffon, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#4e505a` `#404148` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
