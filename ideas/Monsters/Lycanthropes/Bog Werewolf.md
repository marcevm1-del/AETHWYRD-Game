---
type: monster
id: mon_bog_werewolf
family: "Lycanthropes"
rank: "D+"
tier: variant
tags: [monster, lycanthropes]
---
# Bog Werewolf

> The Bog Werewolf is a person-sized creature with an upright humanoid build, about 2.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for a wolf's head on a twisted human body, torn clothing still clinging. It has eyes set slightly too far apart. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Werewolf\|Werewolf]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5501 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.7 m wide; prefab scale 1.222.
- **Physics:** 138.4 kg, gravity ×1.5, poise 72, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.54 m/s, turn 270°/s, stopping distance 0.77 m.
- **Attack count:** 5; **signature:** a wolf's head on a twisted human body, torn clothing still clinging.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Moon Frenzy\|Moon Frenzy]] | buff | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Werewolf is a **dread cursed beast** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wolf's head on a twisted human body, torn clothing still clinging. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Greymoor\|Greymoor]] | 5 | D-, D, C-, D+, C | 40–76 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C-, D-, D | 40–65 | Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C-, D | 48–65 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03430` | Greymoor Bog Werewolf Runt | [[Regions/Greymoor\|Greymoor]] | Runt | D- | 40 | 1.54 m | Night | Like a typical Bog Werewolf, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_03431` | Greymoor Bog Werewolf Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | D | 48 | 1.87 m | Night | Like a typical Bog Werewolf, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03432` | Aldmere Bog Werewolf Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 2.2 m | Night | Like a typical Bog Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03433` | Xochitl Mire Bog Werewolf Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C- | 65 | 2.2 m | Night | Like a typical Bog Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03434` | Aldmere Bog Werewolf Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.54 m | Night | Like a typical Bog Werewolf, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_03435` | Xochitl Mire Bog Werewolf Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D | 48 | 1.87 m | Night | Like a typical Bog Werewolf, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_03436` | Greymoor Bog Werewolf Albino | [[Regions/Greymoor\|Greymoor]] | Albino | C- | 65 | 2.2 m | Night | Like a typical Bog Werewolf, but a rare pale form with white skin or fur and red eyes. |
| `pop_03437` | Greymoor Bog Werewolf | [[Regions/Greymoor\|Greymoor]] | Adult | D+ | 56 | 2.2 m | Night | A typical adult Bog Werewolf of this region, with mud-slick, algae-streaked skin. |
| `pop_03438` | Aldmere Bog Werewolf Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 1.87 m | Night | Like a typical Bog Werewolf, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03439` | Greymoor Bog Werewolf Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | C | 76 | 2.75 m | Night | Like a typical Bog Werewolf, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_03440` | Xochitl Mire Bog Werewolf Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | C- | 65 | 2.42 m | Night | Like a typical Bog Werewolf, but covered in old battle scars, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
