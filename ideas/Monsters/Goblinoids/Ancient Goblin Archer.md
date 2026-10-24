---
type: monster
id: mon_ancient_goblin_archer
family: "Goblinoids"
rank: "E+"
tier: variant
tags: [monster, goblinoids]
---
# Ancient Goblin Archer

> The Ancient Goblin Archer is a person-sized creature with a small, compact humanoid body, about 1.5 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show a crooked bow strung with gut and a quiver of bone-tipped arrows. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Archer\|Goblin Archer]] (ancient) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1644 · 138 · 110 · 68 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (override (base species)); animation set `anim_small_biped`.
- **Dimensions:** 1.5 m high × 0.45 m long × 0.6 m wide; prefab scale 1.364.
- **Physics:** 54 kg, gravity ×1.5, poise 40, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 6.52 m/s, turn 343°/s, stopping distance 0.7 m.
- **Attack count:** 4; **signature:** a crooked bow strung with gut and a quiver of bone-tipped arrows.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Toss\|Sand Toss]] | debuff | 0 | 12 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Ancient Goblin Archer is a **menacing humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crooked bow strung with gut and a quiver of bone-tipped arrows. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 7 | E, D-, D, E+, E-, D+ | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D-, E, D+ | 26–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05912` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 1.27 m | Day & Night | Like a typical Ancient Goblin Archer, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05913` | Aldmere Ancient Goblin Archer Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 1.65 m | Day & Night | Like a typical Ancient Goblin Archer, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05914` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 1.65 m | Day & Night | Like a typical Ancient Goblin Archer, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05915` | Aldmere Ancient Goblin Archer Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.27 m | Day & Night | Like a typical Ancient Goblin Archer, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05916` | Aldmere Ancient Goblin Archer Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D+ | 56 | 2.03 m | Day & Night | Like a typical Ancient Goblin Archer, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05917` | Aldmere Ancient Goblin Archer Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 1.5 m | Day & Night | Like a typical Ancient Goblin Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05918` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 1.5 m | Day & Night | Like a typical Ancient Goblin Archer, but a rare pale form with white skin or fur and red eyes. |
| `pop_05919` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 1.88 m | Day & Night | Like a typical Ancient Goblin Archer, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05920` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 1.5 m | Day & Night | A typical adult Ancient Goblin Archer of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05921` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 1.05 m | Day & Night | Like a typical Ancient Goblin Archer, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05922` | Great Labyrinth (Floors 1-40) Ancient Goblin Archer Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 2.03 m | Day & Night | Like a typical Ancient Goblin Archer, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
