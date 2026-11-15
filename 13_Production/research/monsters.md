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

### 1.5 What the comparison looks like side by side

The talk's own frames make the contrast concrete (`tv.py scan` sheet 3). At
50:47 a Watcher: one glowing eye-head on a long neck above two bird legs. Nine
seconds later a Thunderjaw-class machine: a hulking quadruped with a disc
weapon slung on its flank. Earlier, Tallnecks read as giraffes from a kilometre
away across a valley. Three machines, three silhouettes nobody could confuse,
out of a roster of **25**.

Set that against `13_Production/screenshots/creatures/dragons.png`: **29**
entries, one winged quadruped, twenty-four palettes. The difference is not
budget or polish — our blockouts are fine blockouts. It is that Horizon spent
its variety on *shape* and we spent ours on *count*.

### 1.6 What makes a creature memorable a week later

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

## 3. Ecology and plausibility

### 3.1 What a bestiary earns by having an ecology

The Horizon talk ties form to niche directly:

> "It's not just about the efficiency of the biomechanics that influence the
> shapes of living things. Often a creature's niche in an ecosystem is also what
> drives these evolutionary processes that adopt certain shapes and behaviours.
> And we wanted to show a large variety of different machines, each with clear
> and distinct shapes and behaviours **that were coherent to the function that
> they would have in our ecosystem**." (~42:40)

Read that carefully: ecology's job in that account is **not** to be noticed by
the player. It is a **constraint on the designer** that forces shapes and
behaviours apart. The Watcher is "the guard dog of the ecosystem… a walking alarm
bell" — the niche decides what it does, which decides how it looks and moves. The
player never reads a food web; they meet a thing that is obviously a sentry.

That is the useful distinction, and it is the one that decides our spend.

### 3.2 Which half is worth paying for

| Ecology artefact | Does the player see it? | Our verdict |
|---|---|---|
| **Niche as a design constraint** (sentry / grazer / ambusher / scavenger / pack caller) | Only through behaviour — and that is the point | **Pay for it.** It is the cheapest generator of §2 difference we have. |
| **Idle behaviour before aggro** (feeding, guarding, grooming, watching the road) | Yes, every single encounter | **Pay for it.** Highest visibility per unit of work in this table. |
| **Aftermath clues** (tracks, kills, residue, damaged objects) | Yes, and Canon already wants it | **Pay for it** — Canon line 103 has already approved *field journal and hunt deduction*, which needs clues to exist. |
| **Habitat logic** (why it lives here) | Indirectly, via where you meet it | **Partly.** We already have it: `habitats` + `population.json`. Keep, do not extend. |
| **Region phases** (Lean / Storm / Plenty) | Yes, as changed spawns | **Already approved** (Canon line 100, borrowed feature 14). Keep. |
| **Diet** as a data field | No | **Decoration**, unless it drives a visible idle — a grazer that is actually *grazing* when you arrive. |
| **Predator/prey graph between species** | Almost never; monsters rarely fight each other in front of the player | **Decoration** for us. A food web is worth building only if the world simulates it visibly, and we do not. |
| **Population dynamics** (numbers responding to hunting) | No, in an offline single-player RPG of this size | **Decoration.** |

**What we actually have.** `Data/Monsters/` has **no diet, prey, predator or
ecology field at all** (grepped). `08_Bestiary/regional_ecology.md`, despite the
name, is a generated region x species distribution report, not an ecology.
`12_Systems/living_world.md` contains no ecology terms. So the food-web half we
do not need is correctly absent — and the niche half we do need is absent too,
except as the 8 `behavior` labels of which 4 execute (§2.2).

### 3.3 The one real plausibility defect in the data

`regional_ecology.md` reports **167 species sitting above their region's top
rank** (Tyrants excluded) — thirteen C+ species in Aldmere alone, a band-F–C
region. The design kit explicitly wants some of this (*"danger spikes inside a
rank band"*, *"irregulars"*, about a 1% chance). But 167 of 680 is not a 1%
irregular rate; it is a quarter of the bestiary living permanently out of band.
Either the irregular rule should be a spawn-weight rule rather than a roster
fact, or the bands need widening. That is a data question for `bestiary-designer`
and I am flagging it, not settling it.

---

## 4. The rubric

### 4.1 Design

**100 points, five categories of 20.** Every criterion is checkable against
`Data/Monsters/`, `Tools/blender/ascend_creatures/` or a grep of the shipped
code. None of them is a matter of taste. The scorer is
`Tools/bestiary_rubric/score.js`.

Three rules, from `.claude/rules/skill-authoring.md`:

1. **A criterion scores only if something reads the field.** Obligation 2 in
   reverse: a key with a writer and no reader earns no points, because it changes
   nothing a player experiences. That is why `feintChance`, `circleRadius`,
   per-species `poise` and the `+stalker` suffix are absent from the rubric
   despite being present in the data.
2. **Perceivable resolution, not stored resolution.** B1 uses the collapsed fight
   profile of §2.5. Scoring the data vector instead would award marks for decimal
   places, and would have reported that 680 species are 638 different fights,
   which is false.
3. **NOT ASSESSED is a real value and outranks the pass.** Three things cannot be
   settled from data, and are carried as NOT ASSESSED on **every** species, so no
   species can reach an unqualified pass from a data run alone:
   - the rendered silhouette at the 1-second / 64px test,
   - the gait and animation reading the creature's weight and speed,
   - the audio alert cue.

   The verdict labels say so: the top band is **"STRONG (data only)"**, never
   "STRONG". A species earns an unqualified verdict only once a person has looked
   at its render and heard its cue. The scorer prints the three outstanding
   checks on every entry, so a skipped step announces itself (obligation 3).

### 4.2 The criteria

**A · Reads at a glance (20)**

| | Points | Check |
|---|---|---|
| A1 | 8 | `profile.py`/`plans.py` carries a silhouette rule keyed to this creature's shape, or its base species'. Variant treatments — elder, ancient, corrupted, greater — do **not** count: they are bulk and scars on a borrowed shape. |
| A2 | 6 | Its `designRecipe.parts` differ from every rig-mate's (max Jaccard below 0.6 scores full; 1.0 scores zero). |
| A3 | 6 | No rig-mate in a shared region sits in its size class. |

**B · Different to fight (20)**

| | Points | Check |
|---|---|---|
| B1 | 10 | No other species in its **own region and ring** has the same perceivable fight profile. |
| B2 | 6 | At least one attack no other species on its rig has (3 points if 3 or fewer rig-mates share it). |
| B3 | 4 | It spans more than one reach class, so spacing is a live question. |

**C · Tells are fair and learnable (20)**

| | Points | Check |
|---|---|---|
| C1 | 6 | Every windup clears the species' own `minTelegraphSec` floor. |
| C2 | 6 | Longest recovery at least 0.5 s (3 points at 0.35 s) — a punish window a player can use. |
| C3 | 4 | `windupJitter` at most 0.17, the Weber fraction at this duration (§2.1). Above it, the creature's own tell is noisier than the gap between tell tiers. |
| C4 | 4 | Uses 3 or more telegraph colours (2 points for 2), so defence is a choice rather than a reflex. |

**D · Earns belief (20)**

| | Points | Check |
|---|---|---|
| D1 | 6 | At most 2 habitats (4 points for at most 4). A creature that lives everywhere lives nowhere. |
| D2 | 6 | Its `fieldNote` names an action, not only a fact. "Weak to Lightning." on its own scores **zero**. |
| D3 | 4 | Its role is in data (a non-default approach class) plus 2 or more behaviour notes. |
| D4 | 4 | Two or more out-of-combat hooks from `freezeWhenObserved`, `audioRevealRadius`, `retreatHpPct`. |

**E · Remembered a week later (20)**

| | Points | Check |
|---|---|---|
| E1 | 6 | Its `signature` names a physical feature in 4 or more words, not a colour or a mood. |
| E2 | 4 | No other species uses the same signature line. |
| E3 | 4 | At most 1 other species shares both its rig and its whole fight profile. |
| E4 | 6 | No rig-mate shares its menace + element + material. |

**Bands:** 70+ STRONG (data only) · 50–69 WORKABLE (data only) · 30–49 THIN ·
under 30 INTERCHANGEABLE · and NOT ASSESSED where a species has no motion entry
or no player-reachable attack.

### 4.3 The whole bestiary, scored

```
species: 680   scored: 680   NOT ASSESSED: 0
mean total: 59.0 / 100
  A reads at a glance        7.7 / 20
  B different to fight      11.7 / 20
  C fair tells              17.4 / 20
  D earns belief            13.8 / 20
  E remembered               8.3 / 20
verdicts: STRONG (data only) 90 (13.2%) · WORKABLE 478 (70.3%) · THIN 112 (16.5%)
```

The shape of that result is the finding. **What a generator can do, we did well:
C is 87% of maximum.** Timings, telegraph floors and punish windows are
consistent and fair across 680 species — more consistent than most hand-authored
rosters manage. **What a generator cannot do, nobody did: A is 39% and E is
42%.** Silhouette, signature and memorability need an author, and 680 of them
were never authored.

### 4.4 The ten

**Sampling rule, fixed before any score was read:** stratify across rings 0 to 8
and rank bands F− to EX, and require the ten to include (a) one species from the
largest collision class, (b) one variant together with its base, (c) at least one
Tyrant or unique, (d) at least one `freezeWhenObserved` species, (e) six or more
distinct rigs and six or more distinct families. The ten below satisfy all five.

| # | Species | Ring | Rank | Rig | Score | Verdict |
|---|---|---|---|---|---|---|
| 1 | Blue Slime | 0 | F− | blob | **63** | WORKABLE (data only) |
| 2 | Horned Rabbit | 0 | F− | quad_small | **65** | WORKABLE (data only) |
| 3 | Elder Horned Rabbit *(variant of 2)* | 2 | E− | quad_small | **65** | WORKABLE (data only) |
| 4 | Smiling Scarecrow | 1 | F | medium_biped | **63** | WORKABLE (data only) |
| 5 | Forest Wolf | 1 | F+ | quad_large | **63** | WORKABLE (data only) |
| 6 | Killer Ant | 2 | E | hexapod | **56** | WORKABLE (data only) |
| 7 | Werewolf | 2 | D | medium_biped | **49** | **THIN** |
| 8 | Mycelia, the Spore Lord *(Tyrant)* | 3 | B+ | plant_walker | **83** | **STRONG (data only)** |
| 9 | Ignivar, the Ember Throne *(unique)* | 4 | EX | dragon | **58** | WORKABLE (data only) |
| 10 | Hive Mother of the Abyss *(unique)* | 8 | EX | aberrant | **66** | WORKABLE (data only) |

All ten carry the same three NOT ASSESSED checks (§4.1).

### 4.5 What the ten reveal

**1 · The hand-written one wins, and it is not close.** Mycelia scores **83**,
seventeen points clear of the next, and takes **20/20 on category A** — the only
species in the sample to do so. It has a silhouette rule, a part list unlike its
rig-mates', a size class nobody in its region shares, and a signature nobody
reuses ("a crown of glowing fungus fed by the World Tree's Blight"). Mycelia is a
Tyrant somebody sat down and wrote. **That is the whole argument of this note in
one row.**

**2 · Rank does not buy identity.** Ignivar, the Ember Throne is **EX rank — the
top of the world — and scores 58**, below a ring-0 Horned Rabbit. It takes
**0/8 on A1** (no silhouette rule; it falls through to the bare dragon plan),
**0/6 on A2** (Jaccard 1.00 — its part list is *identical* to another dragon's),
and **9 species share both its rig and its whole fight profile**. Its field note
states facts and names no action (2/6). The game's most dramatic creature is, in
data, one of twenty-nine interchangeable winged quadrupeds — which is exactly
what the 64px silhouette test in §1.3 shows.

**3 · The Werewolf is the shape of the problem.** 49/100, the only THIN entry,
and it fails in the most expensive possible way: **A = 10/20 but B = 2/20.** It
*has* a bespoke silhouette rule — somebody wrote werewolf-specific muzzle, eye
and brow code, and the 2026-11-02 review fixed its eyes twice. And then **36
species share both its rig and its entire fight profile, 11 of them inside its
own region and ring.** We paid for the art and got no fight. A Menace-4 "Dread"
lycanthrope plays exactly like a Kobold Warlord.

**4 · The variant is indistinguishable from its base — and that is fine, if we
say so.** Horned Rabbit and Elder Horned Rabbit both score **65** with nearly
identical breakdowns; the Elder differs only in approach class (`skittish` to
`hold`) and loses a behaviour hook. Across the bestiary, 36.3% of variants are
exact fight-profile copies of their base. The problem is not the copy. It is that
the bestiary UI, the field journal and the rank ladder present it as a separate
species to learn.

**5 · The low ranks are in better shape than the high ones.** Blue Slime (63),
Horned Rabbit (65), Smiling Scarecrow (63) and Forest Wolf (63) all beat Ignivar
(58). These are the species the design kit hand-specified in its F-rank roster
table, and it shows: Smiling Scarecrow takes **20/20 on D**, the only perfect
category in the sample, because it has a specific habitat, an actionable field
note ("Burn it at dawn"), a real role and two out-of-combat hooks
(`freezeWhenObserved` plus an audio reveal radius). **Attention, not rank,
predicts the score.**

**6 · Two systemic defects show up in nearly every entry.** `B2` is **0/6 on nine
of the ten** — almost nothing has a move of its own. And several signature lines
are shared verbatim: Blue Slime's, Horned Rabbit's and Forest Wolf's each appear
on two other species. The one-clause claim that is supposed to make a creature
memorable is, for those species, somebody else's claim too.

---

## 5. The first thing I would change

**Make `aiPattern` execute.** One change, in one file, that moves the worst
category for the most species.

`MonsterBrain` already has the states it needs — `Idle`, `Chase`, `Reposition`,
`Windup`, `Active`, `Recovery`, `Staggered`, `Flee`, `Return` — and the data
already carries 16 pattern names, `circleRadius`, `feintChance` and
`preferredRange` for every one of 680 species. Nothing needs to be generated.
Three prefix tests in `MonsterAi.cs:145–159` are all that stands between 16
declared behaviours and 4 executed ones.

The minimum worth doing, in order of value per line changed:

1. **Make `ambush_strike` ambush** (135 species). Stay in `Idle` until the player
   is inside a much smaller strike radius, then open with a gap-closer. Today an
   ambusher walks at you from 14 m.
2. **Make `passive_wander` passive** (62 species). Do not enter `Chase` from
   `Idle` on proximity alone; enter it when struck. Today a creature labelled
   Passive charges you, which is worse than unimplemented — it is a label that
   lies, and the taming system (Canon line 150) reads wildness off the same
   behaviour field.
3. **Read `circleRadius`** — it is already deserialised in both the Core brain and
   the Unity profile and used by neither. It is the difference between a ranged
   attacker that kites and one that stands still.
4. **Read `feintChance`** — set on 1,067 attack instances, read by nothing. A
   feint is the cheapest way to make a tell worth learning rather than worth
   reacting to.
5. **Cut `windupJitter` to 0.17 or below** where it exceeds the Weber fraction
   (§2.1). It is currently non-zero on 2,458 of 3,367 attack instances, often at
   0.25–0.35, which makes a creature's own tell vary by more than the gap between
   two tell tiers. This one is a data change and makes fights *more* learnable
   by doing less.

Expected effect, from the rubric's own model: items 1 and 2 alone split the
"rush" approach class into three, which breaks up the 39-species largest
collision class and most of the 284 in-region duplicates. **It is the highest
ratio of perceived variety to work anywhere in this note**, because the content
is already written — it is simply not being read.

The second thing, if there is room: **give each family's signature attack a
distinct tell tier.** `FAMILY_SIGNATURE` already guarantees one attack per family
that no other family on that rig has, and there is a test for it. It is currently
timed like its neighbours. Timing it one tier apart turns a name into a tell.

---

## 6. Should 680 stay 680?

**Yes — keep all 680 rows. Cut the number of species the game asks the player to
learn to about 40, and demote the rest to population.**

That is not a dodge, and it is not "halve it". It is a different axis of cut.

### 6.1 Why not halve it

The completion dashboard scores quantity x quality and puts the bestiary at 25%:
680 of 680, all at blockout. Halving to 340 would move quantity from 1.0 to about
0.5 while leaving quality untouched, because **nothing about having 340 species
makes any one of them better.** The quality deficit is not caused by the count.
It is caused by A and E being unauthored (§4.3), and deleting rows authors
nothing. Halving costs real content and buys zero quality — the worst available
trade.

### 6.2 Why not keep the promise either

The ceiling in §2.1 is **40–80 genuinely distinct fights**, and we are two
people, which puts us near 40. We currently present 680 species as 680 things to
learn — each with a bestiary entry, a field-journal slot and a rank. Against a
measured 193 perceivable fight profiles, 100 of them ignoring size and flight,
that promise is false, and the player discovers it is false somewhere in Aldmere,
where 226 species deliver 91 distinct fights.

Worse, it is *expensively* false. Every one of the 680 currently costs a
bestiary entry, a loot table reference, a population roll and eventually a
baked low-poly, a rig and LODs (`creature_system.md`, *Not done yet*). Six
hundred and eighty of those at working quality is not a two-person job on any
schedule.

### 6.3 The cut that actually scores

Three tiers, applied to the rows we already have:

| Tier | Count | What it gets | What it costs |
|---|---|---|---|
| **Learned species** | **~40** | Bespoke silhouette rule, one move of its own, its own approach class, idle tell, audio cue, bestiary entry, field-journal slot | Full authoring. This is where the next year of creature work goes. |
| **Residents** | **~250** | The rig's moveset and family signature, a palette, a habitat, a field note. Named, fought, looted — but presented as *a kind of thing*, not a species to study | What they cost today |
| **Population** | **~390** (incl. most of the 353 variants) | Appear in the world and in loot; **no separate bestiary page**; shown as a variation under their base's entry | Less than today, because the journal entries go away |

Nothing is deleted. `species.json` keeps 680 rows, Canon line 35 stays true, and
the Ring 2 trim row in Canon §6 is satisfied by promotion-and-demotion rather
than deletion.

**Why this scores better on quantity x quality.** Quantity stays at 680 rows.
Quality rises because the 40 that carry the game get authored to the level
Mycelia already reaches (83/100), and because the rubric stops averaging them
against 390 entries that were never meant to be studied. The dashboard's 25% is
currently *correct* and will stay correct for as long as we grade 680 blockouts
against a promise of 680 authored species. Change the promise and the same work
scores what it is worth.

**The 40 pick themselves.** The rubric already ranks all 680. Take the 90 that
score STRONG (data only), intersect with one-per-region-and-rank-band coverage,
and the Tyrant roster (40 regional Tyrants, Canon line 99) is most of the list
already — those are the hand-written ones, and Mycelia shows what they score when
somebody writes them.

### 6.4 Canon §6 proposal

> **Bestiary tiers.** `species.json` keeps all 680 rows. Species are tiered
> **Learned (~40) / Resident (~250) / Population (~390)**. Only Learned species
> get a bespoke silhouette rule, an attack no rig-mate shares, their own
> executed approach class and a field-journal entry. Residents keep their rig
> moveset and family signature. Population variants appear under their base
> species' bestiary entry rather than their own. The Learned list is chosen by
> `Tools/bestiary_rubric/score.js` plus region and rank-band coverage, and the
> 40 regional Tyrants are Learned by default.
>
> *Relation to the existing Ring 2 row:* this supersedes "trim ~145 tagged
> species to ~60 cores" with a tiering that deletes nothing. If you prefer the
> deletion, the rubric gives a defensible order for it — lowest total first — but
> §6.1 argues deletion buys no quality.

**This needs your OK.** It changes what the bestiary promises, which is a
design-identity call, not a creative detail inside Canon.

---

## 7. Sources, and what could not be sourced

**Measured in this repo** (reproduce with `node Tools/bestiary_rubric/score.js .`
and `node Tools/bestiary_rubric/ceiling.js .`):
all species/vector/collision counts, the per-rig shared movesets, the
element-to-weakness function, the executed-axis table, the rubric scores.

**Grepped in this repo:** every "declared but not executed" claim in §2.2, each
against `Code/Ascend.Core`, `Code/Unity/Runtime` and `Game/Assets/_Game/Runtime`.

**External:**

- Miller, G. A. (1956). *The Magical Number Seven, Plus or Minus Two.*
  [psychclassics.yorku.ca/Miller](https://psychclassics.yorku.ca/Miller/) —
  channel capacity for unidimensional absolute judgment, about 2.5 bits.
- Cowan, N. (2001). *The magical number 4 in short-term memory.* BBS 24(1).
  [PDF](https://memory.psych.missouri.edu/assets/doc/articles/2001/cowan-bbs-2001.pdf)
- Getty, D. J. (1975). *Discrimination of short temporal intervals.* Perception &
  Psychophysics 18, 1–8.
  [PDF](https://link.springer.com/content/pdf/10.3758/BF03199358.pdf) — Weber
  fraction roughly constant for durations up to about 2 s.
- Rammsayer, T. H., Borter, N., & Troche, S. J. (2015). *Visual-auditory
  differences in duration discrimination.* Frontiers in Psychology 6:1626.
  [PMC4620148](https://pmc.ncbi.nlm.nih.gov/articles/PMC4620148/) — adjusted
  Weber fractions 0.173 / 0.175 at a 1000 ms standard.
- van Beek, J.-B. (GDC 2018). *A No-Nonsense Approach to Designing Horizon Zero
  Dawn's Robot Dinosaurs.* Mined with `Tools/tutorial_vision/tv.py`, cache id
  `Youtube_iDqDPsjrz94`; quotations are from the auto-caption track with
  timestamps given inline. Ideas only — no art, text or data taken.
- Roster counts: Horizon's 25 machine species
  ([GamesRadar](https://www.gamesradar.com/horizon-zero-dawns-mechanical-animals-were-inspired-by-angry-chickens-and-emus-fighting-kangaroos));
  Monster Hunter: World 37 at launch / 71 with Iceborne
  ([Twinfinite](https://twinfinite.net/guides/monster-hunter-world-iceborne-how-long-it-is-how-many-monsters-there-are/)).
- Shape language, skeleton reuse and palette-swap practice are already sourced in
  `08_Bestiary/monster_design_kit.md` §1 and are not re-derived here.

**Gaps, wired to the verdicts rather than noted beside them:**

- `NOT SOURCEABLE — no study or published design account gives a number for how
  many distinct enemy types a player can tell apart in one game.` The 40–80
  ceiling in §2.1 is an **inference** from Miller/Cowan/Getty plus shipped roster
  counts, not a measurement. It is the load-bearing number behind §6, and it is
  an inference; if it is wrong in the generous direction the tier counts move,
  but the 193-vs-680 gap that motivates tiering is measured, not inferred, and
  does not depend on it.
- `NOT SOURCEABLE — no study of player recall of game creature designs over days
  or weeks was found.` §1.6 is therefore reasoning, and category E scores only
  data proxies for memorability. E can never establish that a creature *is*
  memorable; it can only establish that it has the ingredients.
- `NOT SOURCEABLE — the "one role, one weakness per demon" framing often
  attributed to Doom Eternal could not be confirmed from a primary source` (the
  NoClip "Designing Demons" interview was not readable in this session), so it is
  not used as support anywhere above.
- The GDC talk was mined as both transcript and frames: `tv.py scan` returned
  36 frames, 40 crops and 3 contact sheets over 3,657 s (it failed twice first,
  on an incomplete download and then on the muxing temp file). Quotations carry
  caption timestamps; the frame observation in §1.5 is from sheet 3.
- **NOT ASSESSED — every rendered, animated and audio check**, for all 680
  species (§4.1). The contact sheets in
  `13_Production/screenshots/creatures/` were inspected for the dragon family
  only, and that sheet predates the 2026-11-02 wing fixes; the 64px silhouette
  evidence in §1.3 is post-fix and comes from
  `reports/blender_wave_2026-11-02/creatures/`.
