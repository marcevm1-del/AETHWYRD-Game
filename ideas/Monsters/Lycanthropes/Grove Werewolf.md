---
type: monster
id: mon_grove_werewolf
family: "Lycanthropes"
rank: "D+"
tier: variant
tags: [monster, lycanthropes]
---
# Grove Werewolf

![[mon_grove_werewolf_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_grove_werewolf_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,474 tris · 0.845 × 0.54 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Grove Werewolf is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Guild sketches always show a wolf's head on a twisted human body, torn clothing still clinging. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by drifting pollen and tiny blossoms. Adapted to forest lands, it has moss-green coloring that blends with the undergrowth.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werewolf\|Werewolf]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5501 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 72, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.71 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a wolf's head on a twisted human body, torn clothing still clinging.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Grove Werewolf is a **dread cursed beast** encountered at D+ rank, around level 56. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wolf's head on a twisted human body, torn clothing still clinging. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Lycanthropes D|loot_lycan_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D, C-, D+, C+ | 48–86 | Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D-, C-, C, D+, C+ | 40–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06275` | Hoshizora Grove Werewolf Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 1.87 m | Night | Like a typical Grove Werewolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_06276` | Aldmere Grove Werewolf Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.54 m | Night | Like a typical Grove Werewolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_06277` | Hoshizora Grove Werewolf Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 2.2 m | Night | Like a typical Grove Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06278` | Aldmere Grove Werewolf Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 2.42 m | Night | Like a typical Grove Werewolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06279` | Aldmere Grove Werewolf Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.75 m | Night | Like a typical Grove Werewolf, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_06280` | Hoshizora Grove Werewolf | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 2.2 m | Night | A typical adult Grove Werewolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06281` | Aldmere Grove Werewolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 2.2 m | Night | Like a typical Grove Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_06282` | Aldmere Grove Werewolf | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 2.2 m | Night | A typical adult Grove Werewolf of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_06283` | Hoshizora Grove Werewolf Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 2.42 m | Night | Like a typical Grove Werewolf, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_06284` | Aldmere Grove Werewolf Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 2.97 m | Night | Like a typical Grove Werewolf, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_06285` | Hoshizora Grove Werewolf Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 2.97 m | Night | Like a typical Grove Werewolf, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
