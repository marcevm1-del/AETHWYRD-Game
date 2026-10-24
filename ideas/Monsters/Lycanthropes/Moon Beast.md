---
type: monster
id: mon_moon_beast
family: "Lycanthropes"
rank: "C+"
tier: core
tags: [monster, lycanthropes]
---
# Moon Beast

![[mon_moon_beast_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_moon_beast_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,560 tris · 1.075 × 1.977 × 2.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Moon Beast is a large creature with a lean humanoid frame, about 2.8 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is fur that ripples like oil under moonlight. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11279 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.8 m high × 0.84 m long × 0.9 m wide; prefab scale 1.556.
- **Physics:** 285.4 kg, gravity ×1.5, poise 90, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.77 m/s, turn 239°/s, stopping distance 0.88 m.
- **Attack count:** 5; **signature:** fur that ripples like oil under moonlight.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moon Beast is a **dread cursed beast** encountered at C+ rank, around level 86. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fur that ripples like oil under moonlight. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes C|loot_lycan_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Phantom Moon Beast|Phantom Moon Beast]]
- [[Monsters/Lycanthropes/Bramble Beast|Bramble Beast]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 6 | C-, C, B, B-, B+ | 65–120 | Night |
| [[Regions/Moraveil\|Moraveil]] | 1 | B | 108–108 | Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | C, C+ | 76–86 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | C-, B- | 65–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00564` | Strife Marches Moon Beast Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C- | 65 | 1.96 m | Night | Like a typical Moon Beast, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00565` | Moraveil Moon Beast Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B | 108 | 3.5 m | Night | Like a typical Moon Beast, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00566` | Strife Marches Moon Beast Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C | 76 | 2.38 m | Night | Like a typical Moon Beast, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00567` | Aldmere Moon Beast Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 2.38 m | Night | Like a typical Moon Beast, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00568` | Aldmere Moon Beast | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 2.8 m | Night | A typical adult Moon Beast of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00569` | Strife Marches Moon Beast Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B | 108 | 3.5 m | Night | Like a typical Moon Beast, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00570` | Strife Marches Moon Beast Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 3.08 m | Night | Like a typical Moon Beast, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00571` | Strife Marches Moon Beast Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 2.8 m | Night | Like a typical Moon Beast, but a rare pale form with white skin or fur and red eyes. |
| `pop_00572` | Iron Hold Moon Beast Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C- | 65 | 1.96 m | Night | Like a typical Moon Beast, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00573` | Iron Hold Moon Beast Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B- | 96 | 3.08 m | Night | Like a typical Moon Beast, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00574` | Strife Marches Moon Beast Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B+ | 120 | 3.78 m | Night | Like a typical Moon Beast, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
