---
type: monster
id: mon_phantom_werebear
family: "Lycanthropes"
rank: "C+"
tier: variant
tags: [monster, lycanthropes]
---
# Phantom Werebear

![[mon_phantom_werebear_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_werebear_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.487 × 1.97 × 3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Lycanthropes/mon_phantom_werebear.fbx`

> The Phantom Werebear is a large creature with an upright humanoid build, about 3 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in brown, with gold markings. Look for tribal tattoos showing through thick bear fur. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werebear\|Werebear]] (spirit) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11544 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 3 m high × 0.9 m long × 0.96 m wide; prefab scale 1.667.
- **Physics:** 333.5 kg, gravity ×1.35, poise 94, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 6.67 m/s, turn 231°/s, stopping distance 0.91 m.
- **Attack count:** 5; **signature:** tribal tattoos showing through thick bear fur.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Werebear is a **dread cursed beast** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tribal tattoos showing through thick bear fur. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes C|loot_lycan_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | B, B+, C+, B- | 86–120 | Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 6 | B, B+, C+, B-, C | 76–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06297` | Hoshizora Phantom Werebear Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B | 108 | 3.75 m | Night | Like a typical Phantom Werebear, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06298` | Hoshizora Phantom Werebear Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B+ | 120 | 4.05 m | Night | Like a typical Phantom Werebear, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06299` | Hoshizora Phantom Werebear | [[Regions/Hoshizora\|Hoshizora]] | Adult | C+ | 86 | 3 m | Night | A typical adult Phantom Werebear of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06300` | Hoshizora Phantom Werebear Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Phantom Werebear, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06301` | Shen-Lu Phantom Werebear Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B | 108 | 3.75 m | Night | Like a typical Phantom Werebear, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06302` | Hoshizora Phantom Werebear Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B- | 96 | 3 m | Night | Like a typical Phantom Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_06303` | Shen-Lu Phantom Werebear Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | B+ | 120 | 4.05 m | Night | Like a typical Phantom Werebear, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_06304` | Shen-Lu Phantom Werebear | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | C+ | 86 | 3 m | Night | A typical adult Phantom Werebear of this region, with slate-grey coloring and hardened hide. |
| `pop_06305` | Shen-Lu Phantom Werebear Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Phantom Werebear, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06306` | Shen-Lu Phantom Werebear Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | B- | 96 | 3 m | Night | Like a typical Phantom Werebear, but a rare pale form with white skin or fur and red eyes. |
| `pop_06307` | Shen-Lu Phantom Werebear Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C | 76 | 2.55 m | Night | Like a typical Phantom Werebear, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `holy_motes` · palette `#70573b` `#4c3d2a` `#ffd166` · elongated, irregular silhouette; still-then-sudden timing
