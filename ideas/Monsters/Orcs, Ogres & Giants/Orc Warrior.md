---
type: monster
id: mon_orc_warrior
family: "Orcs, Ogres & Giants"
rank: "D"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Warrior

![[mon_orc_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_orc_warrior_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,995 tris · 1.426 × 1.197 × 2.1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_orc_warrior.fbx`

> The Orc Warrior is a person-sized creature with a broad-shouldered humanoid build, about 2.1 m tall. Its hide is rough, scarred and spiked, colored in olive-green. Guild sketches always show a fur mantle and rust-stained chain mail. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2.1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4314 · 242 · 202 · 113 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.1 m high × 0.63 m long × 0.67 m wide; prefab scale 1.167.
- **Physics:** 120.4 kg, gravity ×1.5, poise 70, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.33 m/s, turn 276°/s, stopping distance 0.76 m.
- **Attack count:** 4; **signature:** a fur mantle and rust-stained chain mail.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Orc Warrior is a **menacing giant** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a fur mantle and rust-stained chain mail. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants D|loot_orc_giant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Orc Warrior|Vesper-Touched Orc Warrior]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 2 | D-, C | 40–76 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | D+, E+, D- | 32–56 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 3 | D+, D-, E+ | 32–56 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | D | 48–48 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 1 | C | 76–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01072` | Aldmere Orc Warrior Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.78 m | Day & Night | Like a typical Orc Warrior, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01073` | Hoshizora Orc Warrior Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 2.31 m | Day & Night | Like a typical Orc Warrior, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01074` | Aldmere Orc Warrior Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 2.84 m | Day & Night | Like a typical Orc Warrior, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_01075` | Fanghold Orc Warrior Albino | [[Regions/Fanghold\|Fanghold]] | Albino | D+ | 56 | 2.1 m | Day & Night | Like a typical Orc Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_01076` | Strife Marches Orc Warrior | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 2.1 m | Day & Night | A typical adult Orc Warrior of this region, with golden, grass-toned coloring. |
| `pop_01077` | Fanghold Orc Warrior Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | D- | 40 | 1.78 m | Day & Night | Like a typical Orc Warrior, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_01078` | Hoshizora Orc Warrior Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 1.47 m | Day & Night | Like a typical Orc Warrior, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01079` | Hoshizora Orc Warrior Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 2.1 m | Day & Night | Like a typical Orc Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_01080` | Fanghold Orc Warrior Runt | [[Regions/Fanghold\|Fanghold]] | Runt | E+ | 32 | 1.47 m | Day & Night | Like a typical Orc Warrior, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_01081` | Hoshizora Orc Warrior Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.78 m | Day & Night | Like a typical Orc Warrior, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01082` | Iron Hold Orc Warrior Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 2.84 m | Day & Night | Like a typical Orc Warrior, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `dust_puffs` · palette `#698446` `#47592f` `#a0cb6b` · triangle-based silhouette, sharp asymmetric spikes
