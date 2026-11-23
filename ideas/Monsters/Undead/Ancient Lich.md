---
type: monster
id: mon_ancient_lich
family: "Undead"
rank: "S"
tier: variant
tags: [monster, undead]
---
# Ancient Lich

![[mon_ancient_lich_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_lich_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.782 × 1.834 × 3.3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_ancient_lich.fbx`

> The Ancient Lich is a large creature with a drifting, half-formed body, about 3.3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bleached bone and grave-cloth, with frost-blue markings. Look for a crowned skull with a phylactery chained to its chest. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by falling snow motes and frosted ground where it steps. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich\|Lich]] (ancient) |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 3.3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27855 · 457 · 533 · 1067 · 991 · 90 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 3.3 m high × 0.99 m long × 2.11 m wide; prefab scale 3.3.
- **Physics:** 4 kg, gravity ×0, poise 52, knockback resistance 0.18, death style `dissolve_into_motes`.
- **Navigation:** speed 9.97 m/s, turn 396°/s, stopping distance 1.23 m.
- **Attack count:** 5; **signature:** a crowned skull with a phylactery chained to its chest.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Lich is a **dread undead** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crowned skull with a phylactery chained to its chest. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead S|loot_undead_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | S+, SS-, S, A+, S- | 159–218 | Night |
| [[Regions/Vesper\|Vesper]] | 5 | S-, S, SS, A+, S+ | 159–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06682` | Nox Dominion Ancient Lich Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S+ | 203 | 3.63 m | Night | Like a typical Ancient Lich, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_06683` | Nox Dominion Ancient Lich Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SS- | 218 | 4.13 m | Night | Like a typical Ancient Lich, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_06684` | Nox Dominion Ancient Lich | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | S | 188 | 3.3 m | Night | A typical adult Ancient Lich of this region, with red-black coloring with faint ember veins. |
| `pop_06685` | Nox Dominion Ancient Lich Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A+ | 159 | 2.31 m | Night | Like a typical Ancient Lich, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_06686` | Vesper Ancient Lich Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | S- | 173 | 2.8 m | Night | Like a typical Ancient Lich, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_06687` | Vesper Ancient Lich | [[Regions/Vesper\|Vesper]] | Adult | S | 188 | 3.3 m | Night | A typical adult Ancient Lich of this region, with red-black coloring with faint ember veins. |
| `pop_06688` | Nox Dominion Ancient Lich Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S+ | 203 | 3.3 m | Night | Like a typical Ancient Lich, but a rare pale form with white skin or fur and red eyes. |
| `pop_06689` | Vesper Ancient Lich Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SS | 236 | 4.46 m | Night | Like a typical Ancient Lich, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_06690` | Nox Dominion Ancient Lich Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S- | 173 | 2.8 m | Night | Like a typical Ancient Lich, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_06691` | Vesper Ancient Lich Runt | [[Regions/Vesper\|Vesper]] | Runt | A+ | 159 | 2.31 m | Night | Like a typical Ancient Lich, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_06692` | Vesper Ancient Lich Scarred | [[Regions/Vesper\|Vesper]] | Scarred | S+ | 203 | 3.63 m | Night | Like a typical Ancient Lich, but covered in old battle scars, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#ddccb4` `#8d7e6a` `#9fdcff` · elongated, irregular silhouette; still-then-sudden timing
