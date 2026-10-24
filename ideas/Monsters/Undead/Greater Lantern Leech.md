---
type: monster
id: mon_greater_lantern_leech
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Greater Lantern Leech

![[mon_greater_lantern_leech_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_lantern_leech_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,938 tris · 0.204 × 1 × 0.531 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Lantern Leech is a small creature with a massive snake-like frame, about 1 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a glow on its back like a lost traveler's lantern. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by fine mist and droplets that orbit it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lantern Leech\|Lantern Leech]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lirian\|Lirian]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.04 m high × 1 m long × 0.1 m wide; prefab scale 0.25.
- **Physics:** 2.4 kg, gravity ×1.2, poise 7, knockback resistance 0.43, death style `limp_chain`.
- **Navigation:** speed 2.92 m/s, turn 300°/s, stopping distance 0.5 m.
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

Greater Lantern Leech is a **dread undead** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a glow on its back like a lost traveler's lantern. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Lirian|Lirian]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Lirian\|Lirian]] | 4 | E, D-, E-, F+ | 13–40 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E+, D-, E- | 19–40 | Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | E+, D, E- | 19–48 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06594` | Lirian Greater Lantern Leech | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 1 m | Night | A typical adult Greater Lantern Leech of this region, with soot-stained hide and scavenged scraps. |
| `pop_06595` | Aldmere Greater Lantern Leech Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 1.1 m | Night | Like a typical Greater Lantern Leech, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_06596` | Greymoor Greater Lantern Leech Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 1 m | Night | Like a typical Greater Lantern Leech, but a rare pale form with white skin or fur and red eyes. |
| `pop_06597` | Aldmere Greater Lantern Leech Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.25 m | Night | Like a typical Greater Lantern Leech, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_06598` | Lirian Greater Lantern Leech Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 1.25 m | Night | Like a typical Greater Lantern Leech, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_06599` | Lirian Greater Lantern Leech Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | E- | 19 | 0.85 m | Night | Like a typical Greater Lantern Leech, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_06600` | Lirian Greater Lantern Leech Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 0.7 m | Night | Like a typical Greater Lantern Leech, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_06601` | Greymoor Greater Lantern Leech Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | D | 48 | 1.35 m | Night | Like a typical Greater Lantern Leech, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_06602` | Greymoor Greater Lantern Leech Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | E- | 19 | 0.85 m | Night | Like a typical Greater Lantern Leech, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06603` | Aldmere Greater Lantern Leech Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.85 m | Night | Like a typical Greater Lantern Leech, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_06604` | Aldmere Greater Lantern Leech Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 1 m | Night | Like a typical Greater Lantern Leech, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `rot_bone` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
