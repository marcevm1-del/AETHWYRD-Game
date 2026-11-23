---
type: monster
id: mon_abyss_herald
family: "Demons"
rank: "SS"
tier: core
tags: [monster, demons]
---
# Abyss Herald

![[mon_abyss_herald_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_abyss_herald_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 5.059 × 7.289 × 10.001 m · local file `Game/Assets/_Game/Art/Models/Monsters/Demons/mon_abyss_herald.fbx`

> The Abyss Herald is a huge creature with a lean humanoid frame, about 10 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in char-black, with violet-edged markings. Its most striking feature is a tall figure with a void where its face should be. It has eyes that never blink. The air distorts slightly around its outline. It moves in jerky stop-motion bursts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | SS · 236 (218–253) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 10 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 75755 · 1145 · 954 · 763 · 859 · 100 |
| XP · gold | 18792 · 3152 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 10 m high × 3 m long × 3.2 m wide; prefab scale 5.556.
- **Physics:** 13000 kg, gravity ×1.05, poise 242, knockback resistance 0.51, death style `ragdoll`.
- **Navigation:** speed 12.18 m/s, turn 126°/s, stopping distance 2.1 m.
- **Attack count:** 5; **signature:** a tall figure with a void where its face should be.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Abyss Herald is a **dread demon** encountered at SS rank, around level 236. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Variants

- [[Monsters/Demons/Alley Abyss Herald|Alley Abyss Herald]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Vesper\|Vesper]] | 5 | SS+, S+, SS, SS- | 203–253 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | S+, SS+, SS-, SSS-, SS | 203–267 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01923` | Vesper Abyss Herald Scarred | [[Regions/Vesper\|Vesper]] | Scarred | SS+ | 253 | 11 m | Night | Like a typical Abyss Herald, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_01924` | Nox Dominion Abyss Herald Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S+ | 203 | 7 m | Night | Like a typical Abyss Herald, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_01925` | Vesper Abyss Herald Runt | [[Regions/Vesper\|Vesper]] | Runt | S+ | 203 | 7 m | Night | Like a typical Abyss Herald, but smaller and scrappier than usual, with red-black coloring with faint ember veins. |
| `pop_01926` | Vesper Abyss Herald | [[Regions/Vesper\|Vesper]] | Adult | SS | 236 | 10 m | Night | A typical adult Abyss Herald of this region, with red-black coloring with faint ember veins. |
| `pop_01927` | Nox Dominion Abyss Herald Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS+ | 253 | 10 m | Night | Like a typical Abyss Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_01928` | Nox Dominion Abyss Herald Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SS- | 218 | 8.5 m | Night | Like a typical Abyss Herald, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01929` | Vesper Abyss Herald Albino | [[Regions/Vesper\|Vesper]] | Albino | SS+ | 253 | 10 m | Night | Like a typical Abyss Herald, but a rare pale form with white skin or fur and red eyes. |
| `pop_01930` | Nox Dominion Abyss Herald Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | SSS- | 267 | 12.5 m | Night | Like a typical Abyss Herald, but larger and scarred, and others of its kind follow it, with red-black coloring with faint ember veins. |
| `pop_01931` | Nox Dominion Abyss Herald Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS+ | 253 | 11 m | Night | Like a typical Abyss Herald, but covered in old battle scars, with red-black coloring with faint ember veins. |
| `pop_01932` | Vesper Abyss Herald Juvenile | [[Regions/Vesper\|Vesper]] | Juvenile | SS- | 218 | 8.5 m | Night | Like a typical Abyss Herald, but young, with brighter colors and unworn features, with red-black coloring with faint ember veins. |
| `pop_01933` | Nox Dominion Abyss Herald | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS | 236 | 10 m | Night | A typical adult Abyss Herald of this region, with red-black coloring with faint ember veins. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `void_distortion` · palette `#575060` `#47414e` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
