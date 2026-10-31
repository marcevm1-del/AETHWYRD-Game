---
type: monster
id: mon_elder_wererat
family: "Lycanthropes"
rank: "C-"
tier: variant
tags: [monster, lycanthropes]
---
# Elder Wererat

![[mon_elder_wererat_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_wererat_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,804 tris · 0.921 × 1.695 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Wererat is a person-sized creature with a lean humanoid frame, about 2.4 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in snow-white, with sickly green markings. Its most striking feature is a hunched rodent body with human hands. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Wererat\|Wererat]] (elder) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7064 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.4 m high × 0.72 m long × 0.77 m wide; prefab scale 1.333.
- **Physics:** 179.7 kg, gravity ×1.5, poise 84, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 5.79 m/s, turn 258°/s, stopping distance 0.81 m.
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

Elder Wererat is a **dread cursed beast** encountered at C- rank, around level 65. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hunched rodent body with human hands. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 5 | B-, C, C-, D | 48–96 | Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | B-, D+ | 56–96 | Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | D, B-, D+, C+ | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03441` | Aldmere Elder Wererat Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B- | 96 | 3.24 m | Night | Like a typical Elder Wererat, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03442` | Greymoor Elder Wererat Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | B- | 96 | 3.24 m | Night | Like a typical Elder Wererat, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03443` | Aldmere Elder Wererat Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C | 76 | 2.64 m | Night | Like a typical Elder Wererat, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03444` | Moraveil Elder Wererat Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D | 48 | 1.68 m | Night | Like a typical Elder Wererat, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03445` | Aldmere Elder Wererat Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C | 76 | 2.4 m | Night | Like a typical Elder Wererat, but a rare pale form with white skin or fur and red eyes. |
| `pop_03446` | Moraveil Elder Wererat Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B- | 96 | 3.24 m | Night | Like a typical Elder Wererat, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03447` | Moraveil Elder Wererat Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D+ | 56 | 2.04 m | Night | Like a typical Elder Wererat, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03448` | Aldmere Elder Wererat | [[Regions/Aldmere\|Aldmere]] | Adult | C- | 65 | 2.4 m | Night | A typical adult Elder Wererat of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03449` | Moraveil Elder Wererat Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C+ | 86 | 3 m | Night | Like a typical Elder Wererat, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03450` | Aldmere Elder Wererat Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 1.68 m | Night | Like a typical Elder Wererat, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03451` | Greymoor Elder Wererat Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | D+ | 56 | 2.04 m | Night | Like a typical Elder Wererat, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#d7dadd` `#9199a0` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
