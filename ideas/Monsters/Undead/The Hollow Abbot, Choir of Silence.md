---
type: monster
id: mon_the_hollow_abbot_choir_of_silence
family: "Undead"
rank: "C+"
tier: core
tags: [monster, undead, tyrant, unique]
---
# The Hollow Abbot, Choir of Silence

![[mon_the_hollow_abbot_choir_of_silence_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_hollow_abbot_choir_of_silence_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,660 tris · 1.598 × 1.653 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Hollow Abbot, Choir of Silence is a person-sized creature with a bodiless, glowing form, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a monk with no face beneath his cowl who erases the names of the dead. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7557 · 212 · 248 · 496 · 460 · 90 |
| XP · gold | 74865 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Greymoor\|Greymoor]] |
| Tyrant | Yes |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 2.2 m high × 0.66 m long × 1.41 m wide; prefab scale 2.2.
- **Physics:** 1.1 kg, gravity ×0, poise 22, knockback resistance 0.09, death style `dissolve_into_motes`.
- **Navigation:** speed 7.6 m/s, turn 485°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** a monk with no face beneath his cowl who erases the names of the dead.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Hollow Abbot, Choir of Silence is a **dread undead** encountered at C+ rank, around level 86. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a monk with no face beneath his cowl who erases the names of the dead. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead C|loot_undead_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Greymoor\|Greymoor]] | 1 | C+ | 86–86 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06717` | The Hollow Abbot, Choir of Silence | [[Regions/Greymoor\|Greymoor]] | Unique | C+ | 86 | 2.2 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
