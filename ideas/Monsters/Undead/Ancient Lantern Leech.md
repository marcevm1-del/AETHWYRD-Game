---
type: monster
id: mon_ancient_lantern_leech
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Ancient Lantern Leech

![[mon_ancient_lantern_leech_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_lantern_leech_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,992 tris · 0.308 × 0.9 × 0.449 m · local file `Game/Assets/_Game/Art/Models/Monsters/Undead/mon_ancient_lantern_leech.fbx`

> The Ancient Lantern Leech is a small creature with a long, sinuous serpentine body, about 0.9 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in grave-mould grey-green, with sea-blue markings. Its most striking feature is a glow on its back like a lost traveler's lantern. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lantern Leech\|Lantern Leech]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 0.9 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1030 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.04 m high × 0.9 m long × 0.09 m wide; prefab scale 0.225.
- **Physics:** 1.8 kg, gravity ×1.2, poise 6, knockback resistance 0.43, death style `limp_chain`.
- **Navigation:** speed 2.77 m/s, turn 316°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a glow on its back like a lost traveler's lantern.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Lantern Leech is a **dread undead** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a glow on its back like a lost traveler's lantern. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Greymoor|Greymoor]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Undead E|loot_undead_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 5 | E, D, E+, D-, F+ | 13–48 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D, E+ | 32–48 | Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | E-, F+, E+ | 13–32 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03749` | Lirian Ancient Lantern Leech | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 0.9 m | Night | A typical adult Ancient Lantern Leech of this region, with soot-stained hide and scavenged scraps. |
| `pop_03750` | Aldmere Ancient Lantern Leech Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.22 m | Night | Like a typical Ancient Lantern Leech, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_03751` | Aldmere Ancient Lantern Leech Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.99 m | Night | Like a typical Ancient Lantern Leech, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03752` | Lirian Ancient Lantern Leech Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 1.22 m | Night | Like a typical Ancient Lantern Leech, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_03753` | Lirian Ancient Lantern Leech Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 0.9 m | Night | Like a typical Ancient Lantern Leech, but a rare pale form with white skin or fur and red eyes. |
| `pop_03754` | Greymoor Ancient Lantern Leech Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | E- | 19 | 0.77 m | Night | Like a typical Ancient Lantern Leech, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03755` | Aldmere Ancient Lantern Leech Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.9 m | Night | Like a typical Ancient Lantern Leech, but a rare pale form with white skin or fur and red eyes. |
| `pop_03756` | Greymoor Ancient Lantern Leech Runt | [[Regions/Greymoor\|Greymoor]] | Runt | F+ | 13 | 0.63 m | Night | Like a typical Ancient Lantern Leech, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03757` | Lirian Ancient Lantern Leech Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 1.13 m | Night | Like a typical Ancient Lantern Leech, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_03758` | Greymoor Ancient Lantern Leech Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | E+ | 32 | 0.99 m | Night | Like a typical Ancient Lantern Leech, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_03759` | Lirian Ancient Lantern Leech Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.63 m | Night | Like a typical Ancient Lantern Leech, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `rot_bone` · VFX `mist_droplets` · palette `#859b7b` `#576751` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
