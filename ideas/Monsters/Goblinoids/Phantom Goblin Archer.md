---
type: monster
id: mon_phantom_goblin_archer
family: "Goblinoids"
rank: "E-"
tier: variant
tags: [monster, goblinoids]
---
# Phantom Goblin Archer

![[mon_phantom_goblin_archer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_goblin_archer_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Goblin Archer is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a crooked bow strung with gut and a quiver of bone-tipped arrows. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Archer\|Goblin Archer]] (spirit) |
| Rank · level | E- · 19 (13–26) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 685 · 86 · 69 · 60 · 69 · 135 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 15.2 kg, gravity ×1.35, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.07 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a crooked bow strung with gut and a quiver of bone-tipped arrows.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Goblin Archer is a **dread humanoid** encountered at E- rank, around level 19. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crooked bow strung with gut and a quiver of bone-tipped arrows. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Goblinoids E|loot_goblinoid_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F+, E-, D-, E | 13–40 | Night |
| [[Regions/Aldmere\|Aldmere]] | 7 | F, D-, E+, E, E-, F+ | 8–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03071` | Whisperwood Phantom Goblin Archer Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F+ | 13 | 0.85 m | Night | Like a typical Phantom Goblin Archer, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_03072` | Aldmere Phantom Goblin Archer Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F | 8 | 0.7 m | Night | Like a typical Phantom Goblin Archer, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03073` | Aldmere Phantom Goblin Archer Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 1.35 m | Night | Like a typical Phantom Goblin Archer, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03074` | Aldmere Phantom Goblin Archer Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 1.25 m | Night | Like a typical Phantom Goblin Archer, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03075` | Whisperwood Phantom Goblin Archer | [[Regions/Whisperwood\|Whisperwood]] | Adult | E- | 19 | 1 m | Night | A typical adult Phantom Goblin Archer of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_03076` | Aldmere Phantom Goblin Archer Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E | 26 | 1 m | Night | Like a typical Phantom Goblin Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_03077` | Aldmere Phantom Goblin Archer | [[Regions/Aldmere\|Aldmere]] | Adult | E- | 19 | 1 m | Night | A typical adult Phantom Goblin Archer of this region, with golden, grass-toned coloring. |
| `pop_03078` | Whisperwood Phantom Goblin Archer Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D- | 40 | 1.35 m | Night | Like a typical Phantom Goblin Archer, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03079` | Aldmere Phantom Goblin Archer Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E | 26 | 1.1 m | Night | Like a typical Phantom Goblin Archer, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03080` | Whisperwood Phantom Goblin Archer Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E | 26 | 1.1 m | Night | Like a typical Phantom Goblin Archer, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_03081` | Aldmere Phantom Goblin Archer Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F+ | 13 | 0.85 m | Night | Like a typical Phantom Goblin Archer, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
