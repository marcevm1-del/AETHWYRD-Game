---
type: monster
id: mon_vesper_touched_werebear
family: "Lycanthropes"
rank: "B-"
tier: variant
tags: [monster, lycanthropes]
---
# Vesper-Touched Werebear

![[mon_vesper_touched_werebear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_werebear_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,204 tris · 1.152 × 2.118 × 3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Werebear is a large creature with a lean humanoid frame, about 3 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Look for tribal tattoos showing through thick bear fur. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werebear\|Werebear]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13598 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 456.3 kg, gravity ×1.65, poise 103, knockback resistance 0.57, death style `ragdoll`.
- **Navigation:** speed 6.14 m/s, turn 231°/s, stopping distance 0.91 m.
- **Attack count:** 5; **signature:** tribal tattoos showing through thick bear fur.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Werebear is a **dread cursed beast** encountered at B- rank, around level 96. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tribal tattoos showing through thick bear fur. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes B|loot_lycan_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | B, A-, B+, B- | 96–132 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | B-, B | 96–108 | Night |
| [[Regions/Zarvan\|Zarvan]] | 3 | C+, B, C | 76–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03452` | Hoshizora Vesper-Touched Werebear Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B | 108 | 3.3 m | Night | Like a typical Vesper-Touched Werebear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03453` | Shen-Lu Vesper-Touched Werebear | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B- | 96 | 3 m | Night | A typical adult Vesper-Touched Werebear of this region, with slate-grey coloring and hardened hide. |
| `pop_03454` | Zarvan Vesper-Touched Werebear Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | C+ | 86 | 2.55 m | Night | Like a typical Vesper-Touched Werebear, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03455` | Shen-Lu Vesper-Touched Werebear Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B | 108 | 3.3 m | Night | Like a typical Vesper-Touched Werebear, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03456` | Hoshizora Vesper-Touched Werebear Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A- | 132 | 4.05 m | Night | Like a typical Vesper-Touched Werebear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03457` | Zarvan Vesper-Touched Werebear Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B | 108 | 3 m | Night | Like a typical Vesper-Touched Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03458` | Shen-Lu Vesper-Touched Werebear Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B | 108 | 3 m | Night | Like a typical Vesper-Touched Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03459` | Hoshizora Vesper-Touched Werebear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B | 108 | 3 m | Night | Like a typical Vesper-Touched Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_03460` | Hoshizora Vesper-Touched Werebear Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B+ | 120 | 3.75 m | Night | Like a typical Vesper-Touched Werebear, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03461` | Hoshizora Vesper-Touched Werebear | [[Regions/Hoshizora\|Hoshizora]] | Adult | B- | 96 | 3 m | Night | A typical adult Vesper-Touched Werebear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03462` | Zarvan Vesper-Touched Werebear Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C | 76 | 2.1 m | Night | Like a typical Vesper-Touched Werebear, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
