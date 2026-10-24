---
type: monster
id: mon_blood_vesper_alpha
family: "Lycanthropes"
rank: "B"
tier: core
tags: [monster, lycanthropes]
---
# Blood Vesper Alpha

> The Blood Vesper Alpha is a large creature with an upright humanoid build, about 3.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Survivors describe red-veined fur that only appears under the red moon. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 3.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16561 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Apu Highlands\|Apu Highlands]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.02 m wide; prefab scale 1.778.
- **Physics:** 468.6 kg, gravity ×1.5, poise 107, knockback resistance 0.42, death style `ragdoll`.
- **Navigation:** speed 6.89 m/s, turn 224°/s, stopping distance 0.94 m.
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

Blood Vesper Alpha is a **dread cursed beast** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** red-veined fur that only appears under the red moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Apu Highlands|Apu Highlands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes B|loot_lycan_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Venom Blood Vesper Alpha|Venom Blood Vesper Alpha]]
- [[Monsters/Lycanthropes/Ancient Blood Vesper Alpha|Ancient Blood Vesper Alpha]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Apu Highlands\|Apu Highlands]] | 3 | B-, B, A | 96–146 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | B+, B | 108–120 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | C+, B, A- | 86–132 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | A-, B+, A | 120–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00575` | Apu Highlands Blood Vesper Alpha Juvenile | [[Regions/Apu Highlands\|Apu Highlands]] | Juvenile | B- | 96 | 2.72 m | Night | Like a typical Blood Vesper Alpha, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00576` | Hoshizora Blood Vesper Alpha Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B+ | 120 | 3.52 m | Night | Like a typical Blood Vesper Alpha, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00577` | Shen-Lu Blood Vesper Alpha Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | C+ | 86 | 2.24 m | Night | Like a typical Blood Vesper Alpha, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00578` | Strife Marches Blood Vesper Alpha Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 4 m | Night | Like a typical Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00579` | Hoshizora Blood Vesper Alpha | [[Regions/Hoshizora\|Hoshizora]] | Adult | B | 108 | 3.2 m | Night | A typical adult Blood Vesper Alpha of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00580` | Apu Highlands Blood Vesper Alpha | [[Regions/Apu Highlands\|Apu Highlands]] | Adult | B | 108 | 3.2 m | Night | A typical adult Blood Vesper Alpha of this region, with slate-grey coloring and hardened hide. |
| `pop_00581` | Shen-Lu Blood Vesper Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | B | 108 | 3.2 m | Night | A typical adult Blood Vesper Alpha of this region, with slate-grey coloring and hardened hide. |
| `pop_00582` | Strife Marches Blood Vesper Alpha Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 3.52 m | Night | Like a typical Blood Vesper Alpha, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00583` | Shen-Lu Blood Vesper Alpha Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | A- | 132 | 4 m | Night | Like a typical Blood Vesper Alpha, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00584` | Strife Marches Blood Vesper Alpha Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 4.32 m | Night | Like a typical Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00585` | Apu Highlands Blood Vesper Alpha Elderborn | [[Regions/Apu Highlands\|Apu Highlands]] | Elderborn | A | 146 | 4.32 m | Night | Like a typical Blood Vesper Alpha, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
