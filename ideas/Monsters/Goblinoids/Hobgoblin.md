---
type: monster
id: mon_hobgoblin
family: "Goblinoids"
rank: "E+"
tier: core
tags: [monster, goblinoids]
---
# Hobgoblin

![[mon_hobgoblin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hobgoblin_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hobgoblin is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Look for a broad scarred chest and a helmet two sizes too small. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2264 · 166 · 138 · 77 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override); animation set `anim_medium_biped`.
- **Dimensions:** 1.8 m high × 0.54 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 75.8 kg, gravity ×1.5, poise 57, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.43 m/s, turn 298°/s, stopping distance 0.71 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Hobgoblin is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a broad scarred chest and a helmet two sizes too small. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Moss Hobgoblin|Moss Hobgoblin]]
- [[Monsters/Goblinoids/Vesper-Touched Hobgoblin|Vesper-Touched Hobgoblin]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | E, D-, E-, D+, D | 19–56 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E+, E-, D+, D, E | 19–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00200` | Aldmere Hobgoblin Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.53 m | Day & Night | Like a typical Hobgoblin, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00201` | Aldmere Hobgoblin Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.8 m | Day & Night | Like a typical Hobgoblin, but a rare pale form with white skin or fur and red eyes. |
| `pop_00202` | Whisperwood Hobgoblin | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 1.8 m | Day & Night | A typical adult Hobgoblin of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00203` | Whisperwood Hobgoblin Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | E- | 19 | 1.26 m | Day & Night | Like a typical Hobgoblin, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00204` | Aldmere Hobgoblin Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.98 m | Day & Night | Like a typical Hobgoblin, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00205` | Whisperwood Hobgoblin Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 2.43 m | Day & Night | Like a typical Hobgoblin, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00206` | Aldmere Hobgoblin Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.26 m | Day & Night | Like a typical Hobgoblin, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00207` | Whisperwood Hobgoblin Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D | 48 | 2.25 m | Day & Night | Like a typical Hobgoblin, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00208` | Whisperwood Hobgoblin Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 1.53 m | Day & Night | Like a typical Hobgoblin, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00209` | Aldmere Hobgoblin Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 2.43 m | Day & Night | Like a typical Hobgoblin, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00210` | Aldmere Hobgoblin Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2.25 m | Day & Night | Like a typical Hobgoblin, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/The Goblin Chief of Hollowpine|The Goblin Chief of Hollowpine]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Hold the Line- {settlement}|Hold the Line: {settlement}]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Fresh Posters|Fresh Posters]] — rank undefined, in [[Regions/Whisperwood|Whisperwood]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
