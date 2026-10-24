---
type: monster
id: mon_bog_spore_lord
family: "Plants & Fungi"
rank: "C+"
tier: variant
tags: [monster, plants-fungi]
---
# Bog Spore Lord

![[mon_bog_spore_lord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_spore_lord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Bog Spore Lord is a large creature with a tall, tree-like walking frame, about 3 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for a mushroom crown and a cloak of mycelium. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Spore Lord\|Spore Lord]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10495 · 443 · 319 · 319 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_walker` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (keyword); animation set `anim_plant_walker`.
- **Dimensions:** 3 m high × 1.2 m long × 3.6 m wide; prefab scale 1.5.
- **Physics:** 567 kg, gravity ×1, poise 149, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.58 m/s, turn 104°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a mushroom crown and a cloak of mycelium.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Branch Sweep\|Branch Sweep]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Slam\|Root Slam]] | aoe | 1.5 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Regrow\|Regrow]] | heal | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Spore Lord is a **dread plant** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a mushroom crown and a cloak of mycelium. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_walker`, animation set `anim_plant_walker`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi C|loot_plant_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 5 | B-, C+, C, C- | 65–96 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 6 | B-, C+, B+, C, C- | 65–120 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04634` | Aldmere Bog Spore Lord Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Bog Spore Lord, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04635` | Aldmere Bog Spore Lord | [[Regions/Aldmere\|Aldmere]] | Adult | C+ | 86 | 3 m | Night | A typical adult Bog Spore Lord of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04636` | Aldmere Bog Spore Lord Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 2.55 m | Night | Like a typical Bog Spore Lord, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04637` | Xochitl Mire Bog Spore Lord Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | B- | 96 | 3.3 m | Night | Like a typical Bog Spore Lord, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04638` | Xochitl Mire Bog Spore Lord Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | B- | 96 | 3 m | Night | Like a typical Bog Spore Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_04639` | Xochitl Mire Bog Spore Lord | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C+ | 86 | 3 m | Night | A typical adult Bog Spore Lord of this region, with mud-slick, algae-streaked skin. |
| `pop_04640` | Xochitl Mire Bog Spore Lord Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | B+ | 120 | 4.05 m | Night | Like a typical Bog Spore Lord, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04641` | Aldmere Bog Spore Lord Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 3 m | Night | Like a typical Bog Spore Lord, but a rare pale form with white skin or fur and red eyes. |
| `pop_04642` | Aldmere Bog Spore Lord Runt | [[Regions/Aldmere\|Aldmere]] | Runt | C- | 65 | 2.1 m | Night | Like a typical Bog Spore Lord, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04643` | Xochitl Mire Bog Spore Lord Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | C | 76 | 2.55 m | Night | Like a typical Bog Spore Lord, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04644` | Xochitl Mire Bog Spore Lord Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | C- | 65 | 2.1 m | Night | Like a typical Bog Spore Lord, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
