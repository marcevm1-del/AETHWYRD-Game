---
type: monster
id: mon_thorn_imp
family: "Demons"
rank: "E+"
tier: variant
tags: [monster, demons]
---
# Thorn Imp

![[mon_thorn_imp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thorn_imp_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,828 tris · 1.25 × 1.019 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thorn Imp is a small creature with a bat-like flying frame, about 0.6 m tall. Its hide is weathered and natural, colored in brimstone red, with leaf-green markings. Guild sketches always show bat wings, a pointed tail and a cheeky grin. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Imp\|Imp]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1228 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/membrane_flyer\|membrane_flyer]] · `anim_flyer_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/membrane_flyer|membrane_flyer]] (override (base species)); animation set `anim_flyer_small`.
- **Dimensions:** 0.26 m high × 0.6 m long × 1.2 m wide; prefab scale 1.2.
- **Physics:** 4.3 kg, gravity ×0.8, poise 19, knockback resistance 0.08, death style `flutter_fall`.
- **Navigation:** speed 0.57 m/s, turn 900°/s, stopping distance 0.51 m.
- **Attack count:** 5; **signature:** bat wings, a pointed tail and a cheeky grin.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thorn Imp is a **wild demon** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** bat wings, a pointed tail and a cheeky grin. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons E|loot_demon_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | D, D+, D-, E- | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 7 | E-, D+, E+, D, D-, E | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04689` | Whisperwood Thorn Imp Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 0.75 m | Day & Night | Like a typical Thorn Imp, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04690` | Aldmere Thorn Imp Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.42 m | Day & Night | Like a typical Thorn Imp, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04691` | Aldmere Thorn Imp Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 0.81 m | Day & Night | Like a typical Thorn Imp, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04692` | Aldmere Thorn Imp | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.6 m | Day & Night | A typical adult Thorn Imp of this region, with dust-grey coloring and old rune scars. |
| `pop_04693` | Whisperwood Thorn Imp Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 0.81 m | Day & Night | Like a typical Thorn Imp, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04694` | Aldmere Thorn Imp Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 0.75 m | Day & Night | Like a typical Thorn Imp, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04695` | Aldmere Thorn Imp Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.6 m | Day & Night | Like a typical Thorn Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_04696` | Whisperwood Thorn Imp Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | D- | 40 | 0.66 m | Day & Night | Like a typical Thorn Imp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04697` | Whisperwood Thorn Imp Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 0.42 m | Day & Night | Like a typical Thorn Imp, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04698` | Aldmere Thorn Imp Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.66 m | Day & Night | Like a typical Thorn Imp, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04699` | Aldmere Thorn Imp Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.51 m | Day & Night | Like a typical Thorn Imp, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `demon_hide_emissive` · VFX `pollen_petals` · palette `#a5342a` `#5d2a27` `#8fd16a` · real-animal silhouette with one fantasy exaggeration
