---
type: monster
id: mon_blight_ghoul
family: "Undead"
rank: "D-"
tier: variant
tags: [monster, undead]
---
# Blight Ghoul

![[mon_blight_ghoul_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blight_ghoul_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.536 × 0.557 × 1.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_blight_ghoul.fbx`

> The Blight Ghoul is a person-sized creature with a lean humanoid frame, about 1.6 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with sickly green markings. Look for grey, hairless skin and long black nails. It has eyes that never blink. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Ghoul\|Ghoul]] (elemental) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3008 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.51 m wide; prefab scale 0.889.
- **Physics:** 53.2 kg, gravity ×1.5, poise 61, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 4.73 m/s, turn 316°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** grey, hairless skin and long black nails.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blight Ghoul is a **dread undead** encountered at D- rank, around level 40. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** grey, hairless skin and long black nails. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead D|loot_undead_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 4 | D, C-, D+, D- | 40–65 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | D, C-, D+, D- | 40–65 | Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | D, C-, D- | 40–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06616` | Aldmere Blight Ghoul Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 1.6 m | Night | Like a typical Blight Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_06617` | Xochitl Mire Blight Ghoul Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | D | 48 | 1.6 m | Night | Like a typical Blight Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_06618` | Aldmere Blight Ghoul Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 2.16 m | Night | Like a typical Blight Ghoul, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06619` | Aldmere Blight Ghoul Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 2 m | Night | Like a typical Blight Ghoul, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06620` | Xochitl Mire Blight Ghoul Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | C- | 65 | 2.16 m | Night | Like a typical Blight Ghoul, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06621` | Xochitl Mire Blight Ghoul Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | D+ | 56 | 2 m | Night | Like a typical Blight Ghoul, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06622` | Xochitl Mire Blight Ghoul | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D- | 40 | 1.6 m | Night | A typical adult Blight Ghoul of this region, with mud-slick, algae-streaked skin. |
| `pop_06623` | Aldmere Blight Ghoul | [[Regions/Aldmere\|Aldmere]] | Adult | D- | 40 | 1.6 m | Night | A typical adult Blight Ghoul of this region, with mud-slick, algae-streaked skin. |
| `pop_06624` | Greymoor Blight Ghoul Albino | [[Regions/Greymoor\|Greymoor]] | Albino | D | 48 | 1.6 m | Night | Like a typical Blight Ghoul, but a rare pale form with white skin or fur and red eyes. |
| `pop_06625` | Greymoor Blight Ghoul Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | C- | 65 | 2.16 m | Night | Like a typical Blight Ghoul, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06626` | Greymoor Blight Ghoul | [[Regions/Greymoor\|Greymoor]] | Adult | D- | 40 | 1.6 m | Night | A typical adult Blight Ghoul of this region, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `toxic_fog` · palette `#dfcbb5` `#8e7c6b` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
