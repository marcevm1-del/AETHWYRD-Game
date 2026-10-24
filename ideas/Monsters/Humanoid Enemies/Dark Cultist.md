---
type: monster
id: mon_dark_cultist
family: "Humanoid Enemies"
rank: "C"
tier: core
tags: [monster, humanoid-enemies]
---
# Dark Cultist

![[mon_dark_cultist_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dark_cultist_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dark Cultist is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Survivors describe red robes and a mask shaped like a crescent moon. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8073 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 83.4 kg, gravity ×1.5, poise 73, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.17 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 5; **signature:** red robes and a mask shaped like a crescent moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dark Cultist is a **dread humanoid** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red robes and a mask shaped like a crescent moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies C|loot_humanoid_enemy_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Dark Cultist Veteran|Dark Cultist Veteran]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vharlen\|Vharlen]] | 3 | C+, B, B- | 86–108 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, C-, B-, D+, B | 56–108 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | B, B-, C+ | 86–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02751` | Vharlen Dark Cultist Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | C+ | 86 | 1.98 m | Night | Like a typical Dark Cultist, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02752` | Strife Marches Dark Cultist Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Dark Cultist, but a rare pale form with white skin or fur and red eyes. |
| `pop_02753` | Strife Marches Dark Cultist Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 1.53 m | Night | Like a typical Dark Cultist, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02754` | Aldmere Dark Cultist Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Dark Cultist, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02755` | Strife Marches Dark Cultist Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Dark Cultist, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02756` | Vharlen Dark Cultist Elderborn | [[Regions/Vharlen\|Vharlen]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Dark Cultist, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02757` | Aldmere Dark Cultist Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Dark Cultist, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02758` | Aldmere Dark Cultist Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C+ | 86 | 1.8 m | Night | Like a typical Dark Cultist, but a rare pale form with white skin or fur and red eyes. |
| `pop_02759` | Strife Marches Dark Cultist Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D+ | 56 | 1.26 m | Night | Like a typical Dark Cultist, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02760` | Vharlen Dark Cultist Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | B- | 96 | 2.25 m | Night | Like a typical Dark Cultist, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02761` | Strife Marches Dark Cultist Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B | 108 | 2.43 m | Night | Like a typical Dark Cultist, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
