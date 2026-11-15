# What makes a bestiary worth fighting through

> Research note for AETHWYRD, 2026-11-15. Scope: what makes a creature read, what
> makes two species genuinely different to fight, how much ecology is worth
> paying for, and a rubric that scores one species out of 100 against criteria
> that can be checked rather than argued about.
>
> **Runnable:** `node Tools/bestiary_rubric/score.js .` scores all 680.
> `node Tools/bestiary_rubric/ceiling.js .` prints the variety numbers.
> Every figure below came out of one of those two runs or out of a grep named in
> the text. Nothing here is recalled.
>
> **Canon:** nothing in this note edits Canon. The recommendation in §6 is a
> proposal for Canon §6 and engages with the open row *"Ring 2 roster — trim
> ~145 tagged species to ~60 cores"*, not a reopening of the locked 680 count in
> Canon line 35.
>
> **Sister work:** `art-research` owns stylised character art generally. This
> note stays on what is specific to creatures and to fighting them.

---

## 0. The three sentences

1. The bestiary's problem is not that 680 is too many names. It is that 680
   species resolve to **193 fight profiles a player could tell apart**, 25
   silhouette families and **4 executed behaviours** — and 41.8% of species
   duplicate another species' entire fight profile inside their own region and
   ring.
2. The parts that were generated systematically — attack timings, telegraph
   floors, punish windows — are **good**: the rubric's "fair tells" category
   averages 17.4/20 across all 680. The parts that need an author — silhouette,
   signature, role — average 7.7 and 8.3 out of 20.
3. So the answer to *should 680 stay 680* is: **keep the 680 rows, cut the 680
   promises.** §6 says what that means in practice and why it scores better on
   the quantity × quality dashboard than either keeping or halving.

---

## 1. Creature design that reads

### 1.1 The strongest single lever is a borrowed body

Guerrilla's art director describes scrapping Horizon's entire first machine
direction — military/industrial "monsters of war" — because the designs made the
player feel like *a soldier*, not *a hunter*, and failed to read as life forms at
all. The fix was to make the machines animals. On why that worked:

> "By using familiar shapes such as the famous T-rex, everybody immediately
> understood their relationship to it. If something really big and dangerous
> stands in front of you, you understand that it's dangerous, but you don't need
> to explain it through complex animations or backstories."
> — Jan-Bart van Beek, GDC 2018, *A No-Nonsense Approach to Designing Horizon
> Zero Dawn's Robot Dinosaurs*, ~36:40 (mined with `tv.py`, id
> `Youtube_iDqDPsjrz94`)

He adds that this bought **emotional clarity at the cost of intellectual
coherence** ("vikings hunting robot dinosaurs is completely ridiculous") and that
the trade was worth it (~37:30).

The lever: a real animal archetype does communication work that no amount of
animation, lore or VFX can buy back. It arrives pre-installed in the player.

**Where we stand.** `Tools/blender/ascend_creatures/profile.py` + `plans.py`
carry **138 shape tokens**, of which **93 are ever matched by a species name**.
**292 of 680 species match none**, and get the bare body-plan default: a
`medium_biped` with a palette. The most-reused matches are `ancient` (37) and
`elder` (31) — variant *treatments*, not shapes. So the generator's real
silhouette vocabulary is a few dozen animal archetypes spread over 680 species.

### 1.2 For an invented creature, behaviour carries identity, not shape

The same talk is explicit about the opposite case. The Watcher is not a known
animal — it started as "a snake on legs":

> "The key thing to get this to work, because it would not really be a known
> creature, would be to get the behaviour right. Because if we got that right we
> figured the audience might be able to understand them and see them as something
> beyond a machine." (~44:00)
>
> "You could even empathize with them… by the way that they communicated you
> could anticipate what they were going to do." (~44:40)

And on why shape could be stretched so far:

> "We could actually change the shape of these creatures quite a lot and still
> communicate what they want to do. They didn't literally need to be dogs or
> meerkats to communicate their function." (~43:30)

**The rule this gives us.** A creature's identity rides on *one* of two rails:

| Rail | Carries identity | Cost | Fails when |
|---|---|---|---|
| **Known archetype** (wolf, boar, spider, skeleton) | Silhouette | Cheap — the player already has it | You have more species than archetypes |
| **Invented** (Hollow Mourner, Lantern Leech, Floor-born) | Behaviour the player can anticipate | Expensive — needs its own AI branch | The behaviour is shared with 100 others |

AETHWYRD has roughly 140 archetypes' worth of silhouette vocabulary and **4**
executed behaviours (§2.2). So the ~540 species that are not a clean archetype
have **neither rail**. That is the mechanism behind "one monster in 680
palettes" — not laziness in the art, a missing rail.

### 1.3 What the 64-pixel test already told us

The repo has already run the right test and the result is in
`reports/blender_wave_2026-11-02/creatures/silhouette_64px_dragons_vs_wolf_x4.png`.
Four dragon species rendered to 64px silhouettes:

| Species | True size | Silhouette at 64px |
|---|---|---|
| Hatchling | 0.37 m | identical |
| Adult Dragon | 18.7 m | identical |
| Drake Lord | 7.13 m | identical |
| Bone Dragon | 15.0 m | identical |

They are pixel-identical to each other and distinguishable only from the control
wolf. A 0.37 m hatchling and an 18.7 m adult dragon have the same shape; the
preview camera normalises scale, so even size does not read. `creature_system.md`
already lists this under *Still open*: "all four dragon species share one
silhouette." The contact sheet `13_Production/screenshots/creatures/dragons.png`
(Oct 25, so **before** the 2026-11-02 wing fixes) shows the same thing across all
29 dragon-family entries: one winged quadruped in ~24 palettes.

**Practice to adopt, from Guerrilla's own method and from the existing test:**
render every new or changed species to a 64px silhouette beside two of its
rig-mates and the control wolf. If a stranger cannot sort them, the species does
not have a silhouette — it has a palette. This is cheap and we already have the
script path.

### 1.4 Weight, speed and hostility

Shape language (circles friendly, triangles aggressive, broken symmetry
unsettling) is already codified in `08_Bestiary/monster_design_kit.md` §4 as the
Menace axis, with sources. I am not re-deriving it. Two creature-specific
additions:

- **Weight reads from timing, not mass.** `motion.json` stores `physics.massKg`
  and `footstepShake`, but what the player feels is `windupSec` × `lungeDistance`
  × `recoverySec`. Our data already does this correctly: `aoe` attacks have a
  median 1.40 s windup against `melee`'s 0.47 s. The heavy things telegraph
  heavy. This is a genuine strength and the rubric scores it (category C, 17.4/20
  mean).
- **Hostility reads from approach, and ours mostly doesn't.** `menace.posture`
  has exactly 5 values (`upright_bouncy`, `natural`, `head_low_stalking`,
  `too_still`, `broken_symmetry`) and is read by `MonsterAnimator.cs`. That is a
  real, working readability channel with 5 states — more than the 4 the AI brain
  has. It is the cheapest existing lever for making a creature *look* like it
  will do something different.

### 1.5 What makes a creature memorable a week later

`NOT SOURCEABLE — no study of player recall of game creature designs over days
or weeks was found in the searches run for this note (Miller 1956, Cowan 2001,
Getty 1975 and the Rammsayer 2015 duration work cover identification and
short-term capacity, not long-term recall of fictional creatures).` What follows
is inference from the identification limits in §2.1, flagged as such, and from
the design accounts cited above — it is reasoning, not evidence, and the rubric
treats category E accordingly (it scores proxies for memorability, and lists the
rendered/animated check as NOT ASSESSED).

The inference: what survives a week is a **one-clause claim** — "the one that
stands still when you look at it", "the one that pretends to be a door". Not a
stat line, not a palette. Our data already has a field for exactly this
(`signature`), and the rubric's E1/E2 measure whether it is doing the job. The
answer across 680 is "about half the time": many signatures name a colour or a
mood rather than a feature, and some are **shared verbatim by several species**
(Blue Slime's signature line appears on 2 other species; Horned Rabbit's on 2;
Forest Wolf's on 2).

---

## 2. Difference that matters

### 2.1 How many differences a player can actually hold

Three sourced limits, applied in order:

1. **Absolute identification on one dimension.** Miller (1956) measured
   transmitted information for unidimensional absolute judgments and found it
   asymptotes near **2.5 bits — about six equally likely alternatives**. In a
   fight the player gets *one* tell with nothing to compare it against, which is
   absolute identification, not discrimination. Six is the per-axis ceiling, and
   under time pressure it is generous.
   ([Miller 1956](https://psychclassics.yorku.ca/Miller/))
2. **Duration discrimination.** Getty (1975) found the Weber fraction for
   duration roughly constant up to about 2 s (and both models failing above it) —
   which brackets our whole windup range of 0.30–2.45 s. Rammsayer, Borter &
   Troche (2015) report adjusted Weber fractions of **0.173 (visual) / 0.175
   (auditory)** at a 1000 ms standard. So two tells must differ by roughly a
   **fifth** before a player can tell them apart at all.
   ([Getty 1975](https://link.springer.com/content/pdf/10.3758/BF03199358.pdf) ·
   [Rammsayer et al. 2015](https://pmc.ncbi.nlm.nih.gov/articles/PMC4620148/))
3. **How many at once.** Cowan (2001) puts the central capacity at **about four
   chunks**, not seven. A player entering a mixed encounter is holding ~4
   creature-identities in the focus of attention, whatever the bestiary contains.
   ([Cowan 2001](https://memory.psych.missouri.edu/assets/doc/articles/2001/cowan-bbs-2001.pdf))

Multiplying per-axis ceilings gives a number in the thousands and is **wrong**,
and it is worth saying why: players do not encode a seven-dimensional vector per
species. They encode a **role label** — "the one that lunges", "the shield one" —
and Cowan's limit applies to those labels. So the multiplicative bound is an
upper bound on what is *distinguishable in principle*, not on what gets learned.

**The empirical check.** Games whose entire identity is "learn the monster" ship
far fewer than our 680:

| Game | Individuated fightable creatures | Source |
|---|---|---|
| Horizon Zero Dawn | 25 machine species | [GamesRadar](https://www.gamesradar.com/horizon-zero-dawns-mechanical-animals-were-inspired-by-angry-chickens-and-emus-fighting-kangaroos) |
| Monster Hunter: World (launch) | 37 large monsters | [Twinfinite](https://twinfinite.net/guides/monster-hunter-world-iceborne-how-long-it-is-how-many-monsters-there-are/) |
| Monster Hunter: World + Iceborne | 71 large monsters | as above (forum-corroborated; no official Capcom count found) |

`NOT SOURCEABLE — no study or published design account gives a number for "how
many distinct enemy types a player can tell apart in one game". The 25/37/71
figures above are shipped-roster counts, not measurements of player capacity, and
the Miller/Cowan/Getty limits are laboratory findings about judgment and memory,
not about enemy recognition. The ceiling below is an inference from both, stated
as an inference.`

**The inferred ceiling: 40–80 genuinely distinct fights.** Lower bound from
Horizon's 25 and MH:World's launch 37; upper bound from Iceborne's 71, a roster
built over years by a 300-person team. We are two people. **Our realistic ceiling
is at the bottom of that band, around 40.** Note that this lands almost exactly
on our 25 rigs plus a modest number of role treatments — the architecture already
implies the answer.

### 2.2 The axes a designer actually has here — and which ones run

I grepped `Code/Ascend.Core`, `Code/Unity/Runtime` and
`Game/Assets/_Game/Runtime` for a reader of every field before scoring it. A
field with a writer and no reader is not an axis; it is a comment.

| Axis | Stored as | Read by | Executed levels |
|---|---|---|---|
| Telegraph colour | `attacks.json.telegraph` | `DefenseJudge.Parse` → `PlayerDefense` | **4** (red / blue / gold / none) |
| Tell length | `motion.json windupSec` | `MonsterBrain.StartWindup`, `MonsterMotion.cs:83` | continuous; **≤6** identifiable (Miller) |
| Punish window | `recoverySec` | `AiState.Recovery` | continuous; **≤6** identifiable |
| Reach | attack `kind` | `MonsterBrain.ReachOf` / `MinRangeOf` | **4** (melee / aoe / gapcloser / ranged) |
| Approach pattern | `aiPattern` | 3 prefix tests in `MonsterAi.cs:145–159` | **4** — see below |
| Group behaviour | `PackmatesNear`, `FlankSlots` | `MonsterController.cs:104,191` | **2** (pack-aware / not) |
| Resistance | `weakness` | `DamageCalculator.ElementMultiplier` | **13**, but see §2.3 |
| Mobility | `canFly` | `MonsterAnimator.cs:55` (hover/bob only) | **2**, cosmetic |
| Posture | `menace.posture` | `MonsterAnimator.cs` | **5** |

**Declared but not executed** (grep found no reader that acts on the value):

- **`aiPattern` collapses 16 → 4.** `MonsterBrain` branches only on
  `IsSkittish`, `IsPack` (pack|swarm) and `IsTerritorial` (territorial|guardian).
  Everything else takes the default chase. So `aggressive_chase` (78 species),
  `ambush_strike` (73) and `passive_wander` (50) are **the same brain**. A
  "Passive" creature enters `Chase` the moment you cross its alert radius
  (`MonsterAi.cs:233`); an "Ambush" creature does not ambush. Those two labels
  are not merely unimplemented, they are contradicted by the code.
- **`+stalker` has no reader at all.** 214 species carry the suffix; only
  `Tools/monster_gen/generate.js` (the writer) and the schema mention it.
- **`behavior.circleRadius`** — deserialised in both `MonsterAi.cs:31` and
  `MonsterMotionData.cs:72`, used by neither.
- **`attacks[].feintChance`** — set on **1,067** attack instances; declared in
  `MonsterMotionData.cs`, no logic reads it. No feints happen.
- **`physics.knockbackResist`** — declared, no reader.
- **Per-species `physics.poise`** — spans 3 to 2,508,487 across the bestiary and
  is **dead**: `PoiseMeter.For(rig, tuning)` keys the poise table off the **rig**
  (`Loot.cs:54`), so stagger resistance has 25 values, not 680.

One field *is* read and works against us: **`windupJitter`** (`MonsterMotion.cs:83`)
randomises each windup by ±jitter. It is non-zero on **2,458 of 3,367** attack
instances, and values of 0.25–0.35 are common. Against a Weber fraction near 0.17
(§2.1), a ±0.25 jitter means a creature's own tell varies by more than the
difference between two neighbouring tell tiers. That is unlearnable by
construction, and the rubric penalises it (C3).

### 2.3 Resistance is a 13-row table, not a per-species fact

Across all 680 species, `weakness` is a **pure function of `element`** — zero
conflicts (`Water→Lightning`, `Fire→Water`, `Dark→Light`, …). `DamageCalculator`
takes exactly two element inputs: the defender's weakness and the element it
resists (its own). So the player learns one 13-row table once, early, and it never
yields a surprise again. There is no species whose resistance profile is worth
discovering.

This is a defensible choice — it is consistent, teachable, and cheap — but it
should be counted honestly: **resistance contributes ~0 to per-species
difference.** Treat the element as palette and VFX, which is what it mostly is.

### 2.4 Movesets are per-rig, not per-species

Each rig has 3–4 attacks shared by **every** species on it, plus 1–2 element
attacks:

```
rig_medium_biped (132 species)  shared: slash, heavy_swing, guard_counter
rig_quad_large   (79)           shared: maul, pounce, howl
rig_small_biped  (57)           shared: stab, thrown_junk, frenzied_lunge
rig_blob         (43)           shared: body_slam, engulf, split, acid_splash
```

`monster_design_kit.md` already flags this and added one `FAMILY_SIGNATURE`
attack per family, with a test. That helped at family level. At species level it
did not: **only 9.4% of species (64 of 680) have a single attack that no other
species on their rig also has.** For the other 90%, the moveset is the rig's.

### 2.5 The number: 680 species → 193 perceivable fight profiles

`ceiling.js` builds two vectors per species over the executed axes of §2.2:

- **data vector** — every axis at stored resolution
- **fight profile** — each axis collapsed to identifiable levels (3 tell tiers,
  3 punish tiers, 4 size classes, per §2.1)

| Measure | Count |
|---|---|
| Species | 680 |
| Distinct **data** vectors | **638** |
| Distinct **fight profiles** | **193** |
| Fight profiles ignoring size and flight (pure combat) | **100** |
| Fight profile **+ rig** (what you see *and* how it fights) | **258** |
| Median species per fight profile | **2** |
| Largest single profile | **39 species** |

The gap between 638 and 193 is the whole problem in one line: **the data is
almost entirely unique, and almost none of that uniqueness is perceivable.** 638
measures how many decimal places the generator wrote. 193 measures how many
fights exist.

The largest class — `melee+ranged | blue+red | mid tell | open punish | rush |
ground | human-size` — holds **39 species** including Kobold Warlord, Werewolf,
Wererat, Skinchanger, War Shadow, Shade Knight, Mirror Shade, Lesser Demon,
Charmfiend, Demon Knight, Vesper Shard-Thrall and Moon Archer. Those span six
families and four Menace levels and are the same fight.

### 2.6 What the player actually meets, region by region

Totals across the bestiary overstate the player's experience, because they never
meet it all at once. Measured inside one region and one ring — what a player
faces in a stretch of play:

| Region / ring | Species | Distinct fight profiles | Distinct |
|---|---|---|---|
| Aldmere / ring 2 | 128 | 70 | 55% |
| Aldmere / ring 3 | 76 | 46 | 61% |
| Great Labyrinth upper / ring 2 | 72 | 50 | 69% |
| Whisperwood / ring 2 | 47 | 33 | 70% |
| Iron Hold / ring 4 | 39 | 27 | 69% |
| **All bands of ≥8 species** | **1,372** | **1,078** | **79%** |

And the headline from `score.js`: **284 of 680 species (41.8%) share their entire
perceivable fight profile with at least one other species in their own region and
ring.** The worst collision group has **12 species** in one region+ring fighting
identically.

Aldmere is the worst case and it matters most: it is a Ring 2 region holding 226
species, the player's main early-game stretch, and only 40% of what lives there
fights differently from everything else there.

### 2.7 Variants

353 of 680 species are variants (elemental, elder, ancient, corrupted, spirit,
regional). By design they are "palette + 1 part + VFX" (`monster_design_kit.md`
§7), and the measurement agrees: **128 of 353 variants (36.3%) share their base
species' entire fight profile.** The other 64% differ, usually by one tell tier
or one reach class, which is a real difference but a small one.

This is not automatically bad. A Frost Goblin that fights like a Goblin but burns
to Fire is a legitimate, cheap piece of content. It is bad only if it is
*presented* as a species to learn. See §6.

---
