---
type: monster
id: mon_vesper_touched_spirit_king
family: "Elementals & Spirits"
rank: "SS-"
tier: variant
tags: [monster, elementals-spirits]
---
# Vesper-Touched Spirit King

> The Vesper-Touched Spirit King is a huge creature with a broad-shouldered humanoid build, about 6 m tall. Its body is rough, scarred and spiked, colored in warm gold and pearl white. Guild sketches always show a crowned elemental giant of pure mana. It has narrow glowing eyes. The air distorts slightly around its outline. It circles its prey, surrounded by soft radiance and floating motes of light. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Spirit King\|Spirit King]] (corrupted) |
| Rank · level | SS- · 218 (203–236) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 57902 · 1058 · 882 · 706 · 794 · 100 |
| XP · gold | 16552 · 2821 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 1.92 m wide; prefab scale 3.333.
- **Physics:** 2667.6 kg, gravity ×1.35, poise 187, knockback resistance 0.51, death style `ragdoll`.
- **Navigation:** speed 8.11 m/s, turn 163°/s, stopping distance 1.42 m.
- **Attack count:** 5; **signature:** a crowned elemental giant of pure mana.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Spirit King is a **menacing elemental** encountered at SS- rank, around level 218. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crowned elemental giant of pure mana. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits SS|loot_elemental_ss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/SS-Rank Monster Core\|SS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 5 | S+, S, SS, SS- | 188–236 | Day & Night |
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 6 | SSS-, S+, SS, S, SS- | 188–267 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04550` | Nox Dominion Vesper-Touched Spirit King Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | S+ | 203 | 5.1 m | Day & Night | Like a typical Vesper-Touched Spirit King, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04551` | Sky Archipelago Vesper-Touched Spirit King Elderborn | [[Regions/Sky Archipelago\|Sky Archipelago]] | Elderborn | SSS- | 267 | 8.1 m | Day & Night | Like a typical Vesper-Touched Spirit King, but old and wise, with greying features and a cautious hunting style, with cloud-pale coloring and lighter bones. |
| `pop_04552` | Sky Archipelago Vesper-Touched Spirit King Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | S+ | 203 | 5.1 m | Day & Night | Like a typical Vesper-Touched Spirit King, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_04553` | Sky Archipelago Vesper-Touched Spirit King Scarred | [[Regions/Sky Archipelago\|Sky Archipelago]] | Scarred | SS | 236 | 6.6 m | Day & Night | Like a typical Vesper-Touched Spirit King, but covered in old battle scars, with cloud-pale coloring and lighter bones. |
| `pop_04554` | Sky Archipelago Vesper-Touched Spirit King Runt | [[Regions/Sky Archipelago\|Sky Archipelago]] | Runt | S | 188 | 4.2 m | Day & Night | Like a typical Vesper-Touched Spirit King, but smaller and scrappier than usual, with cloud-pale coloring and lighter bones. |
| `pop_04555` | Nox Dominion Vesper-Touched Spirit King Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | S | 188 | 4.2 m | Day & Night | Like a typical Vesper-Touched Spirit King, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04556` | Nox Dominion Vesper-Touched Spirit King Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SS | 236 | 6.6 m | Day & Night | Like a typical Vesper-Touched Spirit King, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04557` | Sky Archipelago Vesper-Touched Spirit King | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | SS- | 218 | 6 m | Day & Night | A typical adult Vesper-Touched Spirit King of this region, with cloud-pale coloring and lighter bones. |
| `pop_04558` | Nox Dominion Vesper-Touched Spirit King Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SS | 236 | 6 m | Day & Night | Like a typical Vesper-Touched Spirit King, but a rare pale form with white skin or fur and red eyes. |
| `pop_04559` | Nox Dominion Vesper-Touched Spirit King | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SS- | 218 | 6 m | Day & Night | A typical adult Vesper-Touched Spirit King of this region, with ash-dark coloring with glowing cracks. |
| `pop_04560` | Sky Archipelago Vesper-Touched Spirit King Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | SS | 236 | 6 m | Day & Night | Like a typical Vesper-Touched Spirit King, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
