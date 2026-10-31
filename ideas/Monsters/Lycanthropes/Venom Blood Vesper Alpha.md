---
type: monster
id: mon_venom_blood_vesper_alpha
family: "Lycanthropes"
rank: "B+"
tier: variant
tags: [monster, lycanthropes]
---
# Venom Blood Vesper Alpha

![[mon_venom_blood_vesper_alpha_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_venom_blood_vesper_alpha_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,768 tris · 1.335 × 2.456 × 3.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Venom Blood Vesper Alpha is a large creature with a broad-shouldered humanoid build, about 3.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in wolf-grey, with sickly green markings. Look for red-veined fur that only appears under the red moon. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Blood Vesper Alpha\|Blood Vesper Alpha]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19380 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.02 m wide; prefab scale 1.778.
- **Physics:** 426 kg, gravity ×1.5, poise 107, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.68 m/s, turn 224°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** red-veined fur that only appears under the red moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Venom Blood Vesper Alpha is a **dread cursed beast** encountered at B+ rank, around level 120. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red-veined fur that only appears under the red moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Moraveil|Moraveil]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Moraveil\|Moraveil]] | 4 | B-, A, B+, A+ | 96–159 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 5 | A, A+, A-, B+, B | 108–159 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | A+, B+ | 120–159 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03474` | Moraveil Venom Blood Vesper Alpha Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B- | 96 | 2.24 m | Night | Like a typical Venom Blood Vesper Alpha, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03475` | Moraveil Venom Blood Vesper Alpha Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A | 146 | 4 m | Night | Like a typical Venom Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03476` | Xochitl Mire Venom Blood Vesper Alpha Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | A | 146 | 4 m | Night | Like a typical Venom Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03477` | Moraveil Venom Blood Vesper Alpha | [[Regions/Moraveil\|Moraveil]] | Adult | B+ | 120 | 3.2 m | Night | A typical adult Venom Blood Vesper Alpha of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03478` | Moraveil Venom Blood Vesper Alpha Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A+ | 159 | 4.32 m | Night | Like a typical Venom Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03479` | Xochitl Mire Venom Blood Vesper Alpha Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | A+ | 159 | 4.32 m | Night | Like a typical Venom Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03480` | Hoshizora Venom Blood Vesper Alpha Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A+ | 159 | 4.32 m | Night | Like a typical Venom Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03481` | Xochitl Mire Venom Blood Vesper Alpha Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | A- | 132 | 3.2 m | Night | Like a typical Venom Blood Vesper Alpha, but a rare pale form with white skin or fur and red eyes. |
| `pop_03482` | Xochitl Mire Venom Blood Vesper Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | B+ | 120 | 3.2 m | Night | A typical adult Venom Blood Vesper Alpha of this region, with mud-slick, algae-streaked skin. |
| `pop_03483` | Xochitl Mire Venom Blood Vesper Alpha Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | B | 108 | 2.72 m | Night | Like a typical Venom Blood Vesper Alpha, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03484` | Hoshizora Venom Blood Vesper Alpha | [[Regions/Hoshizora\|Hoshizora]] | Adult | B+ | 120 | 3.2 m | Night | A typical adult Venom Blood Vesper Alpha of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#85868c` `#595a60` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
