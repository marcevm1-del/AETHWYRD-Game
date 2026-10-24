---
type: monster
id: mon_ancient_mandrake
family: "Plants & Fungi"
rank: "E"
tier: variant
tags: [monster, plants-fungi]
---
# Ancient Mandrake

> The Ancient Mandrake is a tiny creature with a walking body of bark and root, about 0.4 m tall. Its bark and leaves are weathered and natural, colored in leaf greens over bark brown. Look for a screaming root with a leafy tuft. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by drifting pollen and tiny blossoms. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Mandrake\|Mandrake]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 963 · 143 · 103 · 103 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/stub_biped\|stub_biped]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/stub_biped|stub_biped]] (override (base species)); animation set `anim_plant_walker`.
- **Dimensions:** 0.4 m high × 0.34 m long × 0.34 m wide; prefab scale 0.8.
- **Physics:** 11.2 kg, gravity ×1.5, poise 22, knockback resistance 0.08, death style `topple_puff`.
- **Navigation:** speed 1.94 m/s, turn 474°/s, stopping distance 0.52 m.
- **Attack count:** 5; **signature:** a screaming root with a leafy tuft.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Mandrake is a **wild plant** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a screaming root with a leafy tuft. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi E|loot_plant_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, E, D, E+, E- | 13–48 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | D-, E+ | 32–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, F+, D, E+ | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04568` | Whisperwood Ancient Mandrake Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.28 m | Day & Night | Like a typical Ancient Mandrake, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04569` | Greymoor Ancient Mandrake Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | D- | 40 | 0.5 m | Day & Night | Like a typical Ancient Mandrake, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04570` | Whisperwood Ancient Mandrake | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.4 m | Day & Night | A typical adult Ancient Mandrake of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04571` | Aldmere Ancient Mandrake Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.5 m | Day & Night | Like a typical Ancient Mandrake, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04572` | Whisperwood Ancient Mandrake Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.54 m | Day & Night | Like a typical Ancient Mandrake, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04573` | Whisperwood Ancient Mandrake Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.4 m | Day & Night | Like a typical Ancient Mandrake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04574` | Whisperwood Ancient Mandrake Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.34 m | Day & Night | Like a typical Ancient Mandrake, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04575` | Greymoor Ancient Mandrake Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 0.4 m | Day & Night | Like a typical Ancient Mandrake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04576` | Aldmere Ancient Mandrake Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.28 m | Day & Night | Like a typical Ancient Mandrake, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04577` | Aldmere Ancient Mandrake Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.54 m | Day & Night | Like a typical Ancient Mandrake, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04578` | Aldmere Ancient Mandrake Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.44 m | Day & Night | Like a typical Ancient Mandrake, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
