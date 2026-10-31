---
type: monster
id: mon_ancient_blood_vesper_alpha
family: "Lycanthropes"
rank: "A"
tier: variant
tags: [monster, lycanthropes]
---
# Ancient Blood Vesper Alpha

![[mon_ancient_blood_vesper_alpha_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_blood_vesper_alpha_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,806 tris · 1.843 × 2.577 × 4.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Blood Vesper Alpha is a large creature with a broad-shouldered humanoid build, about 4.8 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in wolf-grey, with crimson markings. Guild sketches always show red-veined fur that only appears under the red moon. It has eyes that never blink. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Blood Vesper Alpha\|Blood Vesper Alpha]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 4.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29649 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 4.8 m high × 1.44 m long × 1.54 m wide; prefab scale 2.667.
- **Physics:** 1581.5 kg, gravity ×1.5, poise 143, knockback resistance 0.45, death style `ragdoll`.
- **Navigation:** speed 8.44 m/s, turn 183°/s, stopping distance 1.22 m.
- **Attack count:** 5; **signature:** red-veined fur that only appears under the red moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Blood Vesper Alpha is a **dread cursed beast** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red-veined fur that only appears under the red moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes A|loot_lycan_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 4 | A+, S, A, S- | 146–188 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 7 | A-, S, B+, A+, A, S- | 120–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06319` | Shen-Lu Ancient Blood Vesper Alpha Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | A+ | 159 | 4.8 m | Night | Like a typical Ancient Blood Vesper Alpha, but a rare pale form with white skin or fur and red eyes. |
| `pop_06320` | Hoshizora Ancient Blood Vesper Alpha Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | A- | 132 | 4.08 m | Night | Like a typical Ancient Blood Vesper Alpha, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06321` | Hoshizora Ancient Blood Vesper Alpha Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | S | 188 | 6.48 m | Night | Like a typical Ancient Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06322` | Shen-Lu Ancient Blood Vesper Alpha Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | S | 188 | 6.48 m | Night | Like a typical Ancient Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06323` | Shen-Lu Ancient Blood Vesper Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | A | 146 | 4.8 m | Night | A typical adult Ancient Blood Vesper Alpha of this region, with slate-grey coloring and hardened hide. |
| `pop_06324` | Shen-Lu Ancient Blood Vesper Alpha Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | S- | 173 | 6 m | Night | Like a typical Ancient Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06325` | Hoshizora Ancient Blood Vesper Alpha Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | B+ | 120 | 3.36 m | Night | Like a typical Ancient Blood Vesper Alpha, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06326` | Hoshizora Ancient Blood Vesper Alpha Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | A+ | 159 | 4.8 m | Night | Like a typical Ancient Blood Vesper Alpha, but a rare pale form with white skin or fur and red eyes. |
| `pop_06327` | Hoshizora Ancient Blood Vesper Alpha Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A+ | 159 | 5.28 m | Night | Like a typical Ancient Blood Vesper Alpha, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06328` | Hoshizora Ancient Blood Vesper Alpha | [[Regions/Hoshizora\|Hoshizora]] | Adult | A | 146 | 4.8 m | Night | A typical adult Ancient Blood Vesper Alpha of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06329` | Hoshizora Ancient Blood Vesper Alpha Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | S- | 173 | 6 m | Night | Like a typical Ancient Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `blood_mist` · palette `#7f7f86` `#55555c` `#e0344a` · elongated, irregular silhouette; still-then-sudden timing
