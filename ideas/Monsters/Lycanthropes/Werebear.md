---
type: monster
id: mon_werebear
family: "Lycanthropes"
rank: "C"
tier: core
tags: [monster, lycanthropes]
---
# Werebear

> The Werebear is a large creature with an upright humanoid build, about 3 m tall. Its fur is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe tribal tattoos showing through thick bear fur. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9607 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Stormreach\|Stormreach]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 456.3 kg, gravity ×1.65, poise 94, knockback resistance 0.54, death style `ragdoll`.
- **Navigation:** speed 6.44 m/s, turn 231°/s, stopping distance 0.91 m.
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

Werebear is a **menacing cursed beast** encountered at C rank, around level 76. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tribal tattoos showing through thick bear fur. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes C|loot_lycan_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Vesper-Touched Werebear|Vesper-Touched Werebear]]
- [[Monsters/Lycanthropes/Phantom Werebear|Phantom Werebear]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | C+, B, C-, D+, B- | 56–108 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 4 | C-, C+, D+ | 56–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | C, C+ | 76–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00553` | Shen-Lu Werebear Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical Werebear, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00554` | Stormreach Werebear Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical Werebear, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00555` | Shen-Lu Werebear Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | B | 108 | 4.05 m | Day & Night | Like a typical Werebear, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00556` | Hoshizora Werebear | [[Regions/Hoshizora\|Hoshizora]] | Adult | C | 76 | 3 m | Day & Night | A typical adult Werebear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00557` | Stormreach Werebear Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | C+ | 86 | 3.3 m | Day & Night | Like a typical Werebear, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00558` | Stormreach Werebear Runt | [[Regions/Stormreach\|Stormreach]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical Werebear, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00559` | Hoshizora Werebear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_00560` | Shen-Lu Werebear Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C- | 65 | 2.55 m | Day & Night | Like a typical Werebear, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00561` | Stormreach Werebear Albino | [[Regions/Stormreach\|Stormreach]] | Albino | C+ | 86 | 3 m | Day & Night | Like a typical Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_00562` | Shen-Lu Werebear Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | D+ | 56 | 2.1 m | Day & Night | Like a typical Werebear, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00563` | Shen-Lu Werebear Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B- | 96 | 3.75 m | Day & Night | Like a typical Werebear, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
