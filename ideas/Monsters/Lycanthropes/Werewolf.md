---
type: monster
id: mon_werewolf
family: "Lycanthropes"
rank: "D"
tier: core
tags: [monster, lycanthropes]
---
# Werewolf

![[mon_werewolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_werewolf_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.328 × 1.856 × 2.2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Lycanthropes/mon_werewolf.fbx`

> The Werewolf is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in brown, with violet markings. Survivors describe a wolf's head on a twisted human body, torn clothing still clinging. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4383 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 72, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 6 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a wolf's head on a twisted human body, torn clothing still clinging.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Werewolf is a **dread cursed beast** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wolf's head on a twisted human body, torn clothing still clinging. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes D|loot_lycan_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Bog Werewolf|Bog Werewolf]]
- [[Monsters/Lycanthropes/Grove Werewolf|Grove Werewolf]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D-, D+ | 40–56 | Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | D, D+, C-, E+ | 32–65 | Night |
| [[Regions/Moraveil\|Moraveil]] | 1 | D+ | 56–56 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D+, D- | 40–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00531` | Iron Hold Werewolf Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 1.87 m | Night | Like a typical Werewolf, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00532` | Iron Hold Werewolf Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 2.2 m | Night | Like a typical Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00533` | Strife Marches Werewolf | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2.2 m | Night | A typical adult Werewolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00534` | Strife Marches Werewolf Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 2.42 m | Night | Like a typical Werewolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00535` | Moraveil Werewolf Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 2.42 m | Night | Like a typical Werewolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00536` | Strife Marches Werewolf Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 2.75 m | Night | Like a typical Werewolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00537` | Aldmere Werewolf Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 2.42 m | Night | Like a typical Werewolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00538` | Strife Marches Werewolf Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | D+ | 56 | 2.2 m | Night | Like a typical Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00539` | Aldmere Werewolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 2.2 m | Night | Like a typical Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_00540` | Aldmere Werewolf Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.87 m | Night | Like a typical Werewolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00541` | Strife Marches Werewolf Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | E+ | 32 | 1.54 m | Night | Like a typical Werewolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#806243` `#564530` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
