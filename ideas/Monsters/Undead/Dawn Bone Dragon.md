---
type: monster
id: mon_dawn_bone_dragon
family: "Undead"
rank: "S+"
tier: variant
tags: [monster, undead]
---
# Dawn Bone Dragon

> The Dawn Bone Dragon is a colossal creature with an ancient, serpentine dragon body, about 20 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a dragon skeleton held together by green fire. It has eyes set slightly too far apart. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Dragon\|Bone Dragon]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 20 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 98879 · 1069 · 986 · 1069 · 986 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 11.2 m high × 20 m long × 28.2 m wide; prefab scale 1.667.
- **Physics:** 52440 kg, gravity ×0.9, poise 981, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 8.17 m/s, turn 134°/s, stopping distance 2 m.
- **Attack count:** 6; **signature:** a dragon skeleton held together by green fire.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grave Grasp\|Grave Grasp]] | grab | 1.2 | 10 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dawn Bone Dragon is a **dread undead** encountered at S+ rank, around level 203. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dragon skeleton held together by green fire. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Vesper|Vesper]], [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 5 | S+, SS-, SS+, S- | 173–253 | Night |
| [[Regions/Vesper\|Vesper]] | 6 | SS-, S, S+, SS, S- | 173–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03859` | Sky Archipelago Dawn Bone Dragon | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | S+ | 203 | 20 m | Night | A typical adult Dawn Bone Dragon of this region, with dust-grey coloring and old rune scars. |
| `pop_03860` | Vesper Dawn Bone Dragon Albino | [[Regions/Vesper\|Vesper]] | Albino | SS- | 218 | 20 m | Night | Like a typical Dawn Bone Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_03861` | Vesper Dawn Bone Dragon Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | S | 188 | 17 m | Night | Like a typical Dawn Bone Dragon, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_03862` | Vesper Dawn Bone Dragon | [[Regions/Vesper\|Vesper]] | Adult | S+ | 203 | 20 m | Night | A typical adult Dawn Bone Dragon of this region, with red-black coloring with faint ember veins. |
| `pop_03863` | Sky Archipelago Dawn Bone Dragon Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS- | 218 | 20 m | Night | Like a typical Dawn Bone Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_03864` | Sky Archipelago Dawn Bone Dragon Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SS+ | 253 | 27 m | Night | Like a typical Dawn Bone Dragon, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03865` | Sky Archipelago Dawn Bone Dragon Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S- | 173 | 14 m | Night | Like a typical Dawn Bone Dragon, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03866` | Sky Archipelago Dawn Bone Dragon Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS- | 218 | 22 m | Night | Like a typical Dawn Bone Dragon, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03867` | Vesper Dawn Bone Dragon Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS- | 218 | 22 m | Night | Like a typical Dawn Bone Dragon, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_03868` | Vesper Dawn Bone Dragon Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SS | 236 | 25 m | Night | Like a typical Dawn Bone Dragon, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_03869` | Vesper Dawn Bone Dragon Runt | [[Regions/Vesper\|Vesper]] | Runt | S- | 173 | 14 m | Night | Like a typical Dawn Bone Dragon, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `rot_bone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
