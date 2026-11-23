---
type: monster
id: mon_wererat
family: "Lycanthropes"
rank: "D-"
tier: core
tags: [monster, lycanthropes]
---
# Wererat

![[mon_wererat_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_wererat_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.812 × 1.342 × 1.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Lycanthropes/mon_wererat.fbx`

> The Wererat is a person-sized creature with an upright humanoid build, about 1.5 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in snow-white, with sickly green markings. Survivors describe a hunched rodent body with human hands. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1.5 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2943 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.5 m high × 0.45 m long × 0.48 m wide; prefab scale 0.833.
- **Physics:** 43.9 kg, gravity ×1.5, poise 59, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 4.58 m/s, turn 327°/s, stopping distance 0.66 m.
- **Attack count:** 5; **signature:** a hunched rodent body with human hands.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Wererat is a **dread cursed beast** encountered at D- rank, around level 40. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hunched rodent body with human hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes D|loot_lycan_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Elder Wererat|Elder Wererat]]
- [[Monsters/Lycanthropes/Greater Wererat|Greater Wererat]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 4 | E, D, E+ | 26–48 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 2 | E, D- | 26–40 | Night |
| [[Regions/Greymoor\|Greymoor]] | 1 | E | 26–26 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C-, E+, D+ | 32–65 | Night |
| [[Regions/Iron Hold\|Iron Hold]] | 1 | D | 48–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00542` | Moraveil Wererat Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E | 26 | 1.05 m | Night | Like a typical Wererat, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00543` | Xochitl Mire Wererat Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | E | 26 | 1.05 m | Night | Like a typical Wererat, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00544` | Moraveil Wererat Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 1.65 m | Night | Like a typical Wererat, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00545` | Moraveil Wererat Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D | 48 | 1.5 m | Night | Like a typical Wererat, but a rare pale form with white skin or fur and red eyes. |
| `pop_00546` | Greymoor Wererat Runt | [[Regions/Greymoor\|Greymoor]] | Runt | E | 26 | 1.05 m | Night | Like a typical Wererat, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_00547` | Aldmere Wererat Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 2.03 m | Night | Like a typical Wererat, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00548` | Aldmere Wererat Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 1.27 m | Night | Like a typical Wererat, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00549` | Moraveil Wererat Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | E+ | 32 | 1.27 m | Night | Like a typical Wererat, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00550` | Aldmere Wererat Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 1.88 m | Night | Like a typical Wererat, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00551` | Iron Hold Wererat Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D | 48 | 1.65 m | Night | Like a typical Wererat, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00552` | Xochitl Mire Wererat | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D- | 40 | 1.5 m | Night | A typical adult Wererat of this region, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#f7f9fe` `#a7acb8` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
