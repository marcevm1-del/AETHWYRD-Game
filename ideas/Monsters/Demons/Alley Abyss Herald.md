---
type: monster
id: mon_alley_abyss_herald
family: "Demons"
rank: "SS+"
tier: variant
tags: [monster, demons]
---
# Alley Abyss Herald

> The Alley Abyss Herald is a huge creature with a lean humanoid frame, about 10 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in muted greys and dusty browns. Guild sketches always show a tall figure with a void where its face should be. It has eyes that never blink. The air distorts slightly around its outline. It glides without moving its legs. It has no visible aura; you hear its breathing before you see it. Adapted to city lands, it has soot-stained hide and scavenged scraps.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Abyss Herald\|Abyss Herald]] (regional) |
| Rank · level | SS+ · 253 (236–267) |
| Menace | 4 · Dread |
| Element · weakness | None · Fire |
| Size | 10 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 84071 · 1226 · 1022 · 572 · 920 · 100 |
| XP · gold | 21003 · 3474 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 10 m high × 3 m long × 3.2 m wide; prefab scale 5.556.
- **Physics:** 13000 kg, gravity ×1.5, poise 242, knockback resistance 0.51, death style `ragdoll`.
- **Navigation:** speed 9.97 m/s, turn 126°/s, stopping distance 2.1 m.
- **Attack count:** 4; **signature:** a tall figure with a void where its face should be.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Alley Abyss Herald is a **dread demon** encountered at SS+ rank, around level 253. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a tall figure with a void where its face should be. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]], [[Regions/Vesper|Vesper]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons SS|loot_demon_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 6 | SSS-, SS+, SSS+, SSS, SS | 236–294 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | SS+, SSS, SS-, SSS- | 218–281 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04789` | Vesper Alley Abyss Herald Albino | [[Regions/Vesper\|Vesper]] | Albino | SSS- | 267 | 10 m | Night | Like a typical Alley Abyss Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_04790` | Nox Dominion Alley Abyss Herald | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS+ | 253 | 10 m | Night | A typical adult Alley Abyss Herald of this region, with red-black coloring with faint ember veins. |
| `pop_04791` | Nox Dominion Alley Abyss Herald Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SSS | 281 | 12.5 m | Night | Like a typical Alley Abyss Herald, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_04792` | Nox Dominion Alley Abyss Herald Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS- | 218 | 7 m | Night | Like a typical Alley Abyss Herald, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_04793` | Vesper Alley Abyss Herald | [[Regions/Vesper\|Vesper]] | Adult | SS+ | 253 | 10 m | Night | A typical adult Alley Abyss Herald of this region, with red-black coloring with faint ember veins. |
| `pop_04794` | Nox Dominion Alley Abyss Herald Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS- | 267 | 10 m | Night | Like a typical Alley Abyss Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_04795` | Vesper Alley Abyss Herald Elderborn | [[Regions/Vesper\|Vesper]] | Elderborn | SSS+ | 294 | 13.5 m | Night | Like a typical Alley Abyss Herald, but old and wise, with greying features and a cautious hunting style, with red-black coloring with faint ember veins. |
| `pop_04796` | Vesper Alley Abyss Herald Alpha | [[Regions/Vesper\|Vesper]] | Alpha | SSS | 281 | 12.5 m | Night | Like a typical Alley Abyss Herald, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_04797` | Vesper Alley Abyss Herald Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SS | 236 | 8.5 m | Night | Like a typical Alley Abyss Herald, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_04798` | Vesper Alley Abyss Herald Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SSS- | 267 | 11 m | Night | Like a typical Alley Abyss Herald, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_04799` | Nox Dominion Alley Abyss Herald Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS- | 267 | 11 m | Night | Like a typical Alley Abyss Herald, but covered in old battle scars, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · elongated, irregular silhouette; still-then-sudden timing
