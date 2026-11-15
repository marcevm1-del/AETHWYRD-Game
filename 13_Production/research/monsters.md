# What makes a bestiary worth fighting through

> Research note for AETHWYRD, 2026-11-15. Scope: what makes a creature read,
> what makes two species genuinely different to fight, how much ecology is worth
> paying for, and a rubric that scores one species out of 100 against criteria
> that can be checked rather than argued about.
>
> **Runnable:** `node Tools/bestiary_rubric/score.js .` scores all 680.
> `node Tools/bestiary_rubric/ceiling.js .` prints the variety numbers.
> Every figure below came out of one of those two runs, or out of a grep named
> in the text. Nothing here is recalled.
>
> **Canon:** nothing in this note edits Canon. The proposal in §6.4 is for Canon
> §6 and engages with the open row *"Ring 2 roster — trim ~145 tagged species to
> ~60 cores"*; it does not reopen the locked 680 count in Canon line 35.
>
> **Sister work:** `art-research` owns stylised character art generally. This
> note stays on what is specific to creatures and to fighting them.

---

## 0. The three sentences

1. The bestiary's problem is not that 680 is too many names. It is that 680
   species resolve to **193 fight profiles a player could tell apart**, that
   **41.8% of species duplicate another species' entire fight profile inside
   their own region and ring**, and that the spawn tables meet all 680 at
   roughly equal frequency, so there is no core the player learns and no tail
   they meet rarely.
2. What a generator can do, we did well — the rubric's "fair tells" category
   averages **16.9/20** across all 680. What a generator cannot do, nobody did:
   "reads at a glance" averages **7.7/20** and "remembered" **8.3/20**.
3. So the answer to *should 680 stay 680* is: **keep the 680 rows, cut the 680
   promises, and make the kept ones common.** §6 shows the reasoning, including
   where it is an argument rather than an arithmetic result.

---

## 1. Creature design that reads

### 1.1 The strongest single lever is a borrowed body

Guerrilla's art director describes scrapping Horizon's entire first machine
direction — military/industrial "monsters of war" — because the designs made the
player feel like a soldier rather than a hunter, and failed to read as life forms
at all. The fix was to make the machines animals.

His argument for why that worked is the useful part: a familiar shape such as a
T-rex means the player understands their relationship to the creature
immediately, and you do not have to explain that relationship "through complex
animations or backstories" (GDC 2018, ~36:40, mined with `tv.py`, cache id
`Youtube_iDqDPsjrz94`). He grants that this bought emotional clarity at the cost
of intellectual coherence — vikings hunting robot dinosaurs — and judges the
trade worth it (~37:30).

The lever: **a real animal archetype does communication work that no amount of
animation, lore or VFX can buy back.** It arrives pre-installed in the player.

**Where we stand.** `Tools/blender/ascend_creatures/profile.py` + `plans.py`
carry roughly 138 shape tokens. Scoring all 680 species against them — and not
counting variant treatments (`elder`, `ancient`, `corrupted`, `greater`), which
are bulk and scars applied to a borrowed shape — **362 of 680 species (53.2%)
have a silhouette rule keyed to their shape, and 318 do not.** Those 318 get the
bare body-plan default: a `medium_biped` with a palette.

### 1.2 For an invented creature, behaviour carries identity, not shape

The same talk is explicit about the opposite case. The Watcher is not a known
animal — it began as "a snake on legs". Van Beek says the team found they could
change such a creature's shape a great deal and still communicate what it wanted
to do; it did not have to be literally a dog or a meerkat to read as a sentry
(~43:30). And because it was not a known creature, he says, the thing that had to
be right was its **behaviour** — get that right and the audience reads it as
something alive rather than a machine (~44:00). The payoff he names is that
players could *anticipate what it was going to do* (~44:40).

**The rule this gives us.** A creature's identity rides on one of two rails:

| Rail | Carries identity | Cost | Fails when |
|---|---|---|---|
| **Known archetype** (wolf, boar, spider, skeleton) | Silhouette | Cheap — the player already has it | You have more species than archetypes |
| **Invented** (Hollow Mourner, Lantern Leech, Floor-born) | Behaviour the player can anticipate | Expensive — needs its own AI branch | The behaviour is shared with a hundred others |

AETHWYRD has roughly 140 archetypes' worth of silhouette vocabulary and **4**
executed approach classes (§2.2). The 318 species with no silhouette rule and a
shared approach class have **neither rail**. That is the mechanism behind "one
monster in 680 palettes" — not laziness in the art, a missing rail.

### 1.3 What the 64-pixel test already told us

The repo has already run the right test, twice. In the first wave,
`reports/blender_wave_2026-11-02/creatures/silhouette_64px_dragons_vs_wolf_x4.png`
reduces four dragon species to 64px silhouettes — Hatchling (0.37 m), Adult
Dragon (18.7 m), Drake Lord (7.13 m), Bone Dragon (15.0 m). They are
indistinguishable from each other and separable only from the control wolf. A
0.37 m hatchling and an 18.7 m adult have the same shape, and the preview camera
normalises scale, so size does not read either.

The post-fix evidence is `w1_after_dragons.png` in the same folder, rendered
after the 2026-11-02 wing changes: the same four species, now with better wing
sweep and a visible tail spade — and still one silhouette in four colours. The
fixes improved the shape; they did not differentiate the species.
`creature_system.md` already lists this under *Still open*: "all four dragon
species share one silhouette." The family contact sheet
`13_Production/screenshots/creatures/dragons.png` (Oct 25, so **pre-fix**, and
cited only for breadth) shows the same pattern across all 29 dragon-family
entries: one winged quadruped in roughly two dozen palettes.

**Practice to adopt.** Render every new or changed species to a 64px silhouette
beside two rig-mates and the control wolf. If a stranger cannot sort them, the
species does not have a silhouette — it has a palette. The script path already
exists; this costs minutes.

### 1.4 Weight, speed and hostility

Shape language — circles friendly, triangles aggressive, broken symmetry
unsettling — is already codified in `08_Bestiary/monster_design_kit.md` §4 as the
Menace axis, with sources. I am not re-deriving it. Two creature-specific
additions:

- **Weight reads from timing, not mass.** `motion.json` stores `physics.massKg`
  and `footstepShake`, but what the player feels is `windupSec` × `lungeDistance`
  × `recoverySec`. Our data already does this correctly: `aoe` attacks have a
  median 1.40 s windup against `melee`'s 0.47 s. Heavy things telegraph heavy.
  This is a real strength and the rubric scores it (category C, 16.9/20 mean).
- **`menace.posture` is an underused readability channel.** It has five values
  (`upright_bouncy`, `natural`, `head_low_stalking`, `too_still`,
  `broken_symmetry`) and is read by `MonsterAnimator.cs`. Five working states is
  *more* than the four the AI brain has. It is the cheapest existing lever for
  making a creature look like it will do something different.

### 1.5 What the comparison looks like side by side

The talk's own frames make the contrast concrete (`tv.py scan`, sheet 3). At
50:47 a machine stands in a turntable shot: a small head on a long forward-craned
neck over two slender bird-like legs, with a bright lens where a face would be.
Nine seconds later, a different machine fills a desert vista: a heavy-bodied
walker with a large glowing disc mounted on its flank and a dense slab of plating
along its back. Earlier, at 45:16, tall long-necked machines read clearly as
distinct shapes across a whole valley. Three creatures, three silhouettes nobody
could confuse, out of a roster of **25**.

Set that against `dragons.png`: **29** entries, one winged quadruped. The
difference is not budget or polish — our blockouts are decent blockouts. It is
that Horizon spent its variety on **shape** and we spent ours on **count**.

### 1.6 What makes a creature memorable a week later

`NOT SOURCEABLE — no study of player recall of game creature designs over days or
weeks was found in the searches run for this note. Miller 1956, Cowan 2001, Getty
1975 and the Rammsayer 2015 duration work cover identification and short-term
capacity, not long-term recall of fictional creatures.` What follows is inference
from §2.1 and from the design accounts above — reasoning, not evidence — and the
rubric is built to match: category E scores only *proxies* for memorability, and
can establish that a creature has the ingredients, never that it is memorable.

The inference: what survives a week is a **one-clause claim** — "the one that
stands still when you look at it", "the one that pretends to be a door". Not a
stat line and not a palette. Our data already has the field for exactly this
(`signature`), and E1/E2 measure whether it does the job. Across 680 the answer
is "about half the time": many signatures name a colour or a mood rather than a
feature, and some are **shared verbatim** — Blue Slime's line also appears on two
other species, as do Horned Rabbit's and Forest Wolf's.

---

## 2. Difference that matters

### 2.1 How many differences a player can actually hold

Three sourced limits, applied in order:

1. **Absolute identification on one dimension.** Miller (1956) found transmitted
   information for unidimensional absolute judgments asymptotes near **2.5 bits —
   about six equally likely alternatives**. In a fight the player gets *one* tell
   with nothing to compare it against: absolute identification, not
   discrimination. Six is the per-axis ceiling, and under time pressure that is
   generous. ([Miller 1956](https://psychclassics.yorku.ca/Miller/))
2. **Duration discrimination.** Getty (1975) found the Weber fraction for
   duration roughly constant up to about 2 s, which brackets our whole windup
   range of 0.30–2.45 s. Rammsayer, Borter & Troche (2015) report adjusted Weber
   fractions of **0.173 (visual) / 0.175 (auditory)** at a 1000 ms standard. Two
   tells must differ by roughly a fifth before a player can separate them at all.
   ([Getty 1975](https://link.springer.com/content/pdf/10.3758/BF03199358.pdf) ·
   [Rammsayer et al. 2015](https://pmc.ncbi.nlm.nih.gov/articles/PMC4620148/))
3. **How many at once.** Cowan (2001) puts the central capacity at **about four
   chunks**. A player entering a mixed encounter is holding roughly four
   creature-identities in the focus of attention, whatever the bestiary contains.
   ([Cowan 2001](https://memory.psych.missouri.edu/assets/doc/articles/2001/cowan-bbs-2001.pdf))

Multiplying per-axis ceilings gives a number in the thousands and is **wrong**,
and it is worth saying why: players do not encode a seven-dimensional vector per
species. They encode a **role label** — "the one that lunges", "the shield one" —
and Cowan's limit applies to those labels. The multiplicative bound is an upper
bound on what is distinguishable in principle, not on what gets learned.

**The empirical check.** Games whose entire identity is "learn the monster" ship
far fewer than 680:

| Game | Individuated fightable creatures | Source |
|---|---|---|
| Horizon Zero Dawn | 25 machine species | [GamesRadar](https://www.gamesradar.com/horizon-zero-dawns-mechanical-animals-were-inspired-by-angry-chickens-and-emus-fighting-kangaroos) |
| Monster Hunter: World (launch) | 37 large monsters | [Twinfinite](https://twinfinite.net/guides/monster-hunter-world-iceborne-how-long-it-is-how-many-monsters-there-are/) |
| Monster Hunter: World + Iceborne | 71 large monsters | as above (forum-corroborated; no official Capcom count found) |

`NOT SOURCEABLE — no study or published design account gives a number for how
many distinct enemy types a player can tell apart in one game. The 25/37/71
figures are shipped-roster counts, not measurements of player capacity, and the
Miller/Cowan/Getty limits are laboratory findings about judgment and memory, not
about enemy recognition.`

**The inferred ceiling: 25–70 genuinely distinct fights**, bounded below by
Horizon's shipped 25 and above by Iceborne's 71 — the latter built over years by
a team of 300+. We are two people, which puts our realistic target near the
bottom of that band. Note where it lands: at or just above our **25 rigs**. The
architecture already implies the answer.

### 2.2 The axes a designer actually has here — and which ones run

I grepped `Code/Ascend.Core`, `Code/Unity/Runtime` and
`Game/Assets/_Game/Runtime` for a reader of every field before scoring it. A
field with a writer and no reader is not an axis; it is a comment.

| Axis | Stored as | Read by | Executed levels |
|---|---|---|---|
| Telegraph colour | `attacks.json.telegraph` | `DefenseJudge.Parse` → `PlayerDefense` | **4** (red / blue / gold / none) |
| Tell length | `motion.json windupSec` | `MonsterBrain.StartWindup` | continuous; **≤6** identifiable |
| Punish window | `recoverySec` | `AiState.Recovery` | continuous; **≤6** identifiable |
| Reach | attack `kind` | `MonsterBrain.ReachOf` / `MinRangeOf` | **4** (melee / aoe / gapcloser / ranged) |
| Approach class | `aiPattern` | 3 prefix tests, `MonsterAi.cs:145–159` | **4** |
| Alert / leash / preferred range | `behavior.*Radius`, `preferredRange` | `MonsterBrain.Tick` | continuous, **and genuinely varied** — see below |
| Retreat | `retreatHpPct` | `MonsterAi.cs` → `AiState.Flee` | 4 values (0, 0.25, 0.5, 0.6) |
| Group behaviour | `PackmatesNear`, `FlankSlots` | `MonsterController.cs:104,191` | **2** |
| Resistance | `weakness` | `DamageCalculator` | **13**, but see §2.3 |
| Observation | `freezeWhenObserved` | baked to a component, `MonsterPrefabBuilder.cs:189` | **2** |
| Posture | `menace.posture` | `MonsterAnimator.cs` | **5** |

**Behaviour is differentiated by radii, not by the pattern name.** This is the
correction to the obvious reading of the code. `MonsterBrain` branches only on
`IsSkittish`, `IsPack` and `IsTerritorial`, so `aggressive_chase` (127 species
with their `+stalker` variants), `ambush_strike` (135) and `passive_wander` (62)
all take the same default branch. But the generator separates them in the numbers
the brain *does* read every tick — median values:

| Behaviour | n | alertRadius | preferredRange | retreatHpPct |
|---|---|---|---|---|
| Aggressive | 127 | **23.1 m** | 2.1 | 0 |
| Ambush | 135 | **4.6 m** | 1.6 | 0 |
| Passive | 62 | 8.8 m | **6.8 m** | **0.60** |
| Territorial | 144 | 14.2 m | 2.9 | 0 |
| Skittish | 36 | 13.5 m | 5.5 | 0.50 |
| Pack | 58 | 18.5 m | 4.1 | 0.25 |

So an Ambush species really does wait until you are 4.6 m away, where an
Aggressive one comes at you from 23 m, and a Passive one holds 6.8 m and flees at
60% HP. **The labels are not lies.** What is missing is *categorical* difference:
an ambusher has no concealment and no opening burst, and a passive creature still
enters `Chase` on proximity rather than on being struck. The difference is graded
where it should be kind-of-thing. §5 says what to do about it, and §5 measures
what it is worth.

**Declared and genuinely not executed** (no reader that acts on the value):

- **`+stalker`** — 214 species carry the suffix; only the generator and the
  schema mention it.
- **`behavior.circleRadius`** — deserialised in `MonsterAi.cs:31` and
  `MonsterMotionData.cs:72`, used by neither.
- **`attacks[].feintChance`** — set on **1,067** attack instances, read by
  nothing. No feints happen.
- **`physics.knockbackResist`** and **`menace.audioRevealRadius`** — declared,
  no reader.
- **Per-species `physics.poise`** — spans 3 to 2,508,487 and is dead:
  `PoiseMeter.For(rig, tuning)` keys the table off the **rig** (`Loot.cs:54`,
  called from `MonsterDummy.cs:60`), so stagger resistance has 25 values, not 680.
- **`attacks[].windupJitter`** — non-zero on **2,458 of 3,367** attack instances,
  and entirely inert: the only code that applies it is
  `MonsterMotion.BeginAttack` (`MonsterMotion.cs:83`), **which has no caller**,
  while `MonsterBrain.StartWindup` uses the raw `WindupSec`. Worth knowing before
  anyone wires `BeginAttack` up: at the common 0.25–0.35 settings the jitter
  exceeds the ~0.17 Weber fraction, so the same attack would visibly vary from
  swing to swing.

### 2.3 Resistance is a 13-row table, not a per-species fact

Across all 680 species, `weakness` is a **pure function of `element`** — zero
conflicts (`Water→Lightning`, `Fire→Water`, `Dark→Light`, …). `DamageCalculator`
takes two element inputs: the defender's weakness and the element it resists (its
own). The player learns one 13-row table once and it never surprises them again.

That is a defensible choice — consistent, teachable, cheap — but count it
honestly: **resistance contributes about zero to per-species difference.** Treat
element as palette and VFX, which is mostly what it is.

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
attack per family, with a test. That helped at family level; at species level it
did not. **Only 9.4% of species (64 of 680) have a single attack that no other
species on their rig also has.** For the other 90%, the moveset is the rig's.

### 2.5 The number: 680 species → 193 perceivable fight profiles

`ceiling.js` builds two vectors per species over the executed axes:

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

The gap between 638 and 193 is the problem in one line: **the data is almost
entirely unique, and almost none of that uniqueness is perceivable.** 638
measures how many decimal places the generator wrote. 193 measures how many
fights exist.

The largest class — `melee+ranged | blue+red | mid tell | open punish | rush |
ground | human-size` — holds **39 species**, including Kobold Warlord, Werewolf,
Wererat, Skinchanger, War Shadow, Shade Knight, Mirror Shade, Lesser Demon,
Charmfiend, Demon Knight, Vesper Shard-Thrall and Moon Archer. Those span six
families and four Menace levels and are the same fight.

### 2.6 What the player actually meets, region by region

Totals overstate the player's experience, because they never meet it all at once.
Measured inside one region and one ring — what a player faces in a stretch of
play:

| Region / ring | Species | Distinct fight profiles |
|---|---|---|
| Aldmere / ring 2 | 128 | 70 |
| Aldmere / ring 3 | 76 | 46 |
| Great Labyrinth upper / ring 2 | 72 | 50 |
| Whisperwood / ring 2 | 47 | 33 |
| Iron Hold / ring 4 | 39 | 27 |
| **All bands of ≥ 8 species** | **1,372** | **1,078** |

And the headline from `score.js`: **284 of 680 species (41.8%) share their entire
perceivable fight profile with at least one other species in their own region and
ring.** The worst collision group has **12 species** in one region+ring fighting
identically.

Aldmere matters most: a Ring 2 region holding 226 species, the player's main
early stretch, where 128 ring-2 species deliver 70 distinct fights.

### 2.7 Variants, and the flat spawn curve

353 of 680 species are variants (elemental, elder, ancient, corrupted, spirit,
regional). By design they are "palette + 1 part + VFX"
(`monster_design_kit.md` §7), and the measurement agrees: **128 of 353 variants
(36.3%) share their base species' entire fight profile.** The rest usually differ
by one tell tier or one reach class — a real difference, but a small one.

That is not automatically bad. A Frost Goblin that fights like a Goblin but burns
to Fire is legitimate, cheap content. It is bad only if it is *presented* as a
species to learn.

What is worse is the shape of the spawn tables. `population.json` holds 6,754
entries across **all 680** species, and the distribution is almost perfectly
flat: the most common species appears 11 times, the average is 9.9, and **the top
40 species account for only 6.5% of all population entries.** A well-shaped
bestiary has a handful of creatures you meet constantly and a long tail you meet
rarely — that is what makes the common ones worth learning and the rare ones
worth remembering. **Ours has neither a core nor a tail.** Everything is equally
common, which means nothing is familiar.

---

## 3. Ecology and plausibility

### 3.1 What a bestiary earns by having an ecology

Van Beek ties form to niche directly: biomechanical efficiency is not the only
thing shaping a living creature, he says — a creature's **niche in an ecosystem**
also drives the shapes and behaviours it ends up with, and Guerrilla wanted a
large variety of machines whose distinct shapes and behaviours were *coherent
with the function they had in the ecosystem* (~42:40).

Read that carefully: ecology's job in that account is **not** to be noticed by
the player. It is a **constraint on the designer** that forces shapes and
behaviours apart. The Watcher is the ecosystem's guard dog, a walking alarm bell;
the niche decides what it does, which decides how it looks and moves. The player
never reads a food web. They meet a thing that is obviously a sentry.

That distinction decides our spend.

### 3.2 Which half is worth paying for

| Ecology artefact | Does the player see it? | Verdict |
|---|---|---|
| **Niche as a design constraint** (sentry / grazer / ambusher / scavenger / pack caller) | Only through behaviour — and that is the point | **Pay for it.** The cheapest generator of §2 difference we have. |
| **Idle behaviour before aggro** | Yes, every encounter | **Pay for it.** Highest visibility per unit of work here. |
| **Aftermath clues** (tracks, kills, residue) | Yes, and Canon already wants them | **Pay for it** — Canon line 103 approved *field journal and hunt deduction*, which needs clues to exist. |
| **Habitat logic** | Indirectly, via where you meet it | **Partly.** Already have it (`habitats` + `population.json`). Keep, do not extend. |
| **Region phases** (Lean / Storm / Plenty) | Yes, as changed spawns | **Already approved** (Canon line 100, borrowed feature 14). Keep. |
| **Diet** as a data field | No | **Decoration**, unless it drives a visible idle — a grazer actually *grazing* when you arrive. |
| **Predator/prey graph** | Almost never; monsters rarely fight each other in front of the player | **Decoration** for us. Worth building only if the world simulates it visibly, and ours does not. |
| **Population dynamics** | No, in an offline single-player RPG this size | **Decoration.** |

**What we actually have.** `Data/Monsters/` has **no diet, prey, predator or
ecology field at all** (grepped). `08_Bestiary/regional_ecology.md`, despite its
name, is a generated region × species distribution report.
`12_Systems/living_world.md` contains no ecology terms. So the food-web half we
do not need is correctly absent — and the niche half we do need is absent too,
except as graded radii (§2.2).

### 3.3 The one real plausibility defect in the data

`regional_ecology.md` reports **167 species sitting above their region's top
rank** (Tyrants excluded) — thirteen C+ species in Aldmere alone, a band-F–C
region. The design kit wants some of this (*"danger spikes inside a rank band"*,
*"irregulars"*, about 1%). But 167 of 680 is not a 1% irregular rate; it is a
quarter of the bestiary living permanently out of band. Either the irregular rule
should be a spawn-weight rule rather than a roster fact, or the bands need
widening. A data question for `bestiary-designer` — flagged, not settled.

---

## 4. The rubric

### 4.1 Design

**100 points, five categories of 20.** Every criterion is checkable against
`Data/Monsters/`, `Tools/blender/ascend_creatures/` or a grep of the shipped
code. None is a matter of taste. The scorer is `Tools/bestiary_rubric/score.js`.

Three rules, from `.claude/rules/skill-authoring.md`:

1. **A criterion scores only if something reads the field.** Obligation 2 in
   reverse: a key with a writer and no reader earns no points, because it changes
   nothing a player experiences. This is why `feintChance`, `circleRadius`,
   `knockbackResist`, `audioRevealRadius`, per-species `poise`, `windupJitter`,
   `behavior.notes` and the `+stalker` suffix are all **absent** from the rubric
   despite sitting in the data. Three of them were in the first draft of this
   rubric and were removed when the grep came back empty.
2. **Perceivable resolution, not stored resolution.** B1 uses the collapsed fight
   profile (§2.5). Scoring the data vector would award marks for decimal places,
   and would have reported 680 species as 638 different fights, which is false.
3. **NOT ASSESSED is a real value and outranks the pass.** Three things cannot be
   settled from data and are carried as NOT ASSESSED on **every** species, so no
   species reaches an unqualified pass from a data run alone:
   - the rendered silhouette at the 1-second / 64px test,
   - the gait and animation reading the creature's weight and speed,
   - the audio alert cue.

   The verdict labels say so: the top band is **"STRONG (data only)"**, never
   "STRONG". The scorer prints the three outstanding checks on every entry, so a
   skipped step announces itself (obligation 3).

### 4.2 The criteria

**A · Reads at a glance (20)**

| | Pts | Check |
|---|---|---|
| A1 | 8 | `profile.py`/`plans.py` carries a silhouette rule keyed to this creature's shape, or its base species'. Variant treatments — elder, ancient, corrupted, greater — do **not** count. |
| A2 | 6 | Its `designRecipe.parts` differ from every rig-mate's (max Jaccard < 0.6 full; 1.0 zero). |
| A3 | 6 | No rig-mate in a shared region sits in its size class. |

**B · Different to fight (20)**

| | Pts | Check |
|---|---|---|
| B1 | 10 | No other species in its **own region and ring** has the same perceivable fight profile. |
| B2 | 6 | At least one attack no other species on its rig has (3 if ≤ 3 rig-mates share it). |
| B3 | 4 | It spans more than one reach class, so spacing is a live question. |

**C · Tells are fair and learnable (20)**

| | Pts | Check |
|---|---|---|
| C1 | 6 | Every windup clears the species' own `minTelegraphSec` floor. |
| C2 | 6 | Longest recovery ≥ 0.5 s (3 at ≥ 0.35 s) — a punish window a player can use. |
| C3 | 4 | Its own attacks span more than one tell tier (3 for two tiers), so the moveset is not one attack wearing hats. |
| C4 | 4 | Uses ≥ 3 telegraph colours (2 for two), so defence is a choice not a reflex. |

**D · Earns belief (20)**

| | Pts | Check |
|---|---|---|
| D1 | 6 | ≤ 2 habitats (4 for ≤ 4). A creature that lives everywhere lives nowhere. |
| D2 | 6 | Its `fieldNote` names an action, not only a fact. "Weak to Lightning." alone scores **zero**. |
| D3 | 4 | Its `alertRadius` and `preferredRange` sit outside the bestiary's middle 50% — it notices you, or holds its distance, unlike the crowd. Both are read every tick by `MonsterBrain.Tick`. |
| D4 | 4 | Out-of-combat behaviour the player can see: `freezeWhenObserved` (2) and `retreatHpPct > 0` (2). Both read. |

**E · Remembered a week later (20)**

| | Pts | Check |
|---|---|---|
| E1 | 6 | Its `signature` names a physical feature in ≥ 4 words, not a colour or a mood. |
| E2 | 4 | No other species uses the same signature line. |
| E3 | 4 | ≤ 1 other species shares both its rig and its whole fight profile. |
| E4 | 6 | No rig-mate shares its menace + element + material. |

**Bands:** ≥ 70 STRONG (data only) · 50–69 WORKABLE (data only) · 30–49 THIN ·
< 30 INTERCHANGEABLE · NOT ASSESSED where a species has no motion entry or no
player-reachable attack.

### 4.3 The whole bestiary, scored

```
species: 680   scored: 680   NOT ASSESSED: 0
mean total: 57.4 / 100
  A reads at a glance        7.7 / 20
  B different to fight      11.7 / 20
  C fair tells              16.9 / 20
  D earns belief            12.7 / 20
  E remembered               8.3 / 20
verdicts: STRONG (data only) 74 (10.9%) · WORKABLE 459 (67.5%) · THIN 147 (21.6%)
```

The shape of that result is the finding. **What a generator can do, we did well:
C is 85% of maximum.** Timings, telegraph floors and punish windows are
consistent and fair across 680 species — more consistent than most hand-authored
rosters manage. **What a generator cannot do, nobody did: A is 39% and E is
42%.** Silhouette, signature and memorability need an author.

**Rank buys very little.** Mean score by rank band, all 680:

| Band | n | Total | A | B | E |
|---|---|---|---|---|---|
| F | 56 | 58.6 | 7.5 | 12.0 | 8.9 |
| E | 89 | 53.0 | 6.7 | 10.0 | 7.5 |
| D | 110 | 54.6 | 7.9 | 10.3 | 7.8 |
| C | 106 | 56.6 | 7.1 | 11.5 | 8.9 |
| B | 96 | 56.7 | 7.5 | 12.0 | 8.0 |
| A | 91 | 58.5 | 8.6 | 12.3 | 8.1 |
| S | 69 | 61.5 | 8.7 | 13.6 | 8.4 |
| SS | 16 | 59.8 | 8.1 | 13.1 | 7.9 |
| SSS | 23 | 62.9 | 8.3 | 13.5 | 8.6 |
| **EX** | 24 | **66.8** | 8.8 | 14.5 | 11.4 |

An F-rank species averages 58.6 and an EX averages 66.8 — **eight points across
the entire power range of the game.** Category A rises by 1.3 points from F to
EX. The creatures meant to be the climax of a hundred hours are, by these
measures, barely more distinct than the ones in the tutorial meadow.

### 4.4 The ten

**Sampling rule, fixed before any score was read:** stratify across rings 0→8 and
rank bands F−→EX, and require the ten to include (a) one species from the largest
collision class, (b) one variant together with its base, (c) at least one Tyrant
or unique, (d) at least one `freezeWhenObserved` species, (e) ≥ 6 distinct rigs
and ≥ 6 distinct families. The ten satisfy all five: rings 0,0,1,2,2,3,4,5,6,8;
8 rigs; 9 families.

| # | Species | Ring | Rank | Rig | Score | Verdict |
|---|---|---|---|---|---|---|
| 1 | Blue Slime | 0 | F− | blob | **58** | WORKABLE (data only) |
| 2 | Horned Rabbit | 0 | F− | quad_small | **60** | WORKABLE (data only) |
| 3 | Smiling Scarecrow | 1 | F | medium_biped | **60** | WORKABLE (data only) |
| 4 | Killer Ant | 2 | E | hexapod | **57** | WORKABLE (data only) |
| 5 | Werewolf | 2 | D | medium_biped | **52** | WORKABLE (data only) |
| 6 | Mycelia, the Spore Lord *(Tyrant)* | 3 | B+ | plant_walker | **84** | **STRONG (data only)** |
| 7 | Ignivar, the Ember Throne *(unique)* | 4 | EX | dragon | **57** | WORKABLE (data only) |
| 8 | Basilisk | 5 | C | quad_large | **64** | WORKABLE (data only) |
| 9 | Greater Basilisk *(elder variant of 8)* | 6 | B | quad_large | **64** | WORKABLE (data only) |
| 10 | Hive Mother of the Abyss *(unique)* | 8 | EX | aberrant | **67** | WORKABLE (data only) |

All ten carry the same three NOT ASSESSED checks (§4.1).

### 4.5 What the ten reveal

**1 · The hand-written one wins, and it is not close.** Mycelia scores **84**,
seventeen points clear of the next and seventeen above the EX band average, and
takes **20/20 on category A** — the only species in the sample to do so. It has a
silhouette rule, a part list unlike its rig-mates', a size class nobody in its
region shares, and a signature nobody reuses ("a crown of glowing fungus fed by
the World Tree's Blight"). Mycelia is a Tyrant somebody sat down and wrote.
**That is the whole argument of this note in one row.**

**2 · Rank does not buy identity, and the data agrees.** Ignivar, the Ember
Throne is **EX rank and scores 57** — below a ring-0 Horned Rabbit, and ten
points below its own band's mean. It takes **0/8 on A1** (no silhouette rule; it
falls through to the bare dragon plan), **0/6 on A2** (Jaccard 1.00 — its part
list is *identical* to another dragon's), and **9 species share both its rig and
its whole fight profile**. Its field note states facts and names no action. The
game's most dramatic creature is, in data, one of twenty-nine interchangeable
winged quadrupeds — exactly what the 64px test in §1.3 shows.

**3 · The Werewolf is the shape of the problem.** 52/100, lowest in the sample,
and it fails in the most expensive possible way: **A = 10/20 but B = 2/20.** It
*has* a bespoke silhouette rule — somebody wrote werewolf-specific muzzle, eye
and brow code, and the 2026-11-02 review fixed its eyes twice. And then **36
species share both its rig and its entire fight profile, 11 of them inside its
own region and ring.** We paid for the art and got no fight. A Menace-4 "Dread"
lycanthrope plays exactly like a Kobold Warlord.

**4 · The variant is indistinguishable from its base — and that is fine, if we
say so.** Basilisk and Greater Basilisk both score **64**, with the same
breakdown in every category. Across the bestiary, 36.3% of variants are exact
fight-profile copies of their base. The problem is not the copy. It is that the
bestiary UI, the field journal and the rank ladder present it as a separate
species to learn, one rank band higher.

**5 · Attention predicts the score; rank barely does.** Smiling Scarecrow, an
F-rank tutorial-zone creature, scores 60 and beats an EX dragon, because somebody
hand-specified it in the design kit's F-rank roster table: a specific habitat, an
actionable field note ("Burn it at dawn"), a distinctive engagement profile and
`freezeWhenObserved`. The rank-band table in §4.3 makes the same point across all
680 — eight points from F to EX, against Mycelia's seventeen-point lead from
being written.

**6 · Two systemic defects show up in nearly every entry.** `B2` is **0/6 on nine
of the ten** — almost nothing has a move of its own. And several signature lines
are shared verbatim: Blue Slime's, Horned Rabbit's and Forest Wolf's each appear
on two other species. The one-clause claim meant to make a creature memorable is,
for those species, somebody else's claim too.

---

## 5. The first thing I would change

**Split the default approach class — make `ambush_strike` and `passive_wander`
categorically different, not just differently tuned.**

The radii already separate them (§2.2): an ambusher notices you at 4.6 m against
an aggressive chaser's 23 m. What is missing is a difference in *kind*. And the
cost of adding it is small, because `MonsterBrain` already has the states —
`Idle`, `Chase`, `Reposition`, `Windup`, `Active`, `Recovery`, `Staggered`,
`Flee`, `Return` — and the data already carries the pattern names for all 680.

**What it is worth, measured.** Splitting the default class into its three
declared patterns takes the bestiary from **193 to 247 distinct fight profiles, a
28% gain** (`ceiling.js`), without adding one row of content. It also breaks up
the 39-species largest collision class, since the Werewolf's class is a `rush`
class.

In order of value per line changed:

1. **Give `ambush_strike` an opening** (135 species). It already waits at 4.6 m;
   let it open from `Idle` with a gap-closer instead of walking into range first.
2. **Make `passive_wander` aggro on damage, not proximity** (62 species). It
   already holds 6.8 m and flees at 60% HP; the missing piece is one condition at
   `MonsterAi.cs:233`. This also matters outside combat: taming (Canon line 150)
   reads wildness off the same behaviour field.
3. **Read `circleRadius`** — already deserialised in both the Core brain and the
   Unity profile, used by neither. It is the difference between a ranged attacker
   that kites and one that stands still.
4. **Read `feintChance`** — set on 1,067 attack instances, read by nothing. A
   feint is the cheapest way to make a tell worth *learning* rather than merely
   reacting to.
5. **Decide about `windupJitter` before wiring up `BeginAttack`.** It is inert
   today (§2.2). If it is ever switched on, cap it at 0.17 — above that a
   creature's own tell varies more than the Weber fraction, and the same attack
   reads differently swing to swing.

**It is the highest ratio of perceived variety to work anywhere in this note,
because the content is already written — it is simply not being read.**

Second, if there is room: **give each family's signature attack a distinct tell
tier.** `FAMILY_SIGNATURE` already guarantees one attack per family that no other
family on that rig has, and there is a test for it. It is currently timed like
its neighbours. Timing it one tier apart turns a name into a tell.

---

## 6. Should 680 stay 680?

**Yes — keep all 680 rows. Cut the number of species the game asks the player to
learn to about 40, and make those 40 the ones the player actually meets.**

That is not a dodge and it is not "halve it". It is a different axis of cut.

### 6.0 What I could not check

`NOT ASSESSED — the completion dashboard.` The peer session reports that a
dashboard scores every goal as quantity × quality and puts the bestiary at 25%. I
searched this repo for it — `13_Production`, `Tools`, `Data`, and a repo-wide
grep for "dashboard" — and **found no file defining that score.** My worktree is
cut from `8a81418e`, so it may be newer, or live outside the repo.

**Therefore I have not computed the three options under its real formula, and I
do not claim to have.** What follows argues from measured facts — 193 profiles,
41.8% in-region duplication, the flat spawn curve, the authoring cost — and flags
exactly where the dashboard would decide it. If the dashboard grades every
species row alike with no notion of tiers, then tiering moves the number only if
the formula is changed to match, and §6.3 is a proposal about what to grade, not
a way to score better against the current grader. That should be checked before
anyone quotes a projected percentage.

### 6.1 Why not halve it

Halving to 340 would cut quantity by half while leaving quality where it is,
because **nothing about having 340 species makes any one of them better.** The
quality deficit is not caused by the count — it is caused by A and E being
unauthored (§4.3), and deleting rows authors nothing.

The honest counter-argument, which the peer's framing raises: halving **frees
budget**. If the 340 deleted species would otherwise consume baked low-polys,
rigs and LODs (`creature_system.md`, *Not done yet*), then deleting them pays for
authoring the rest. That is true, and it is the strongest case for deletion. My
answer is that **tiering captures the same saving without the loss**: a Population
-tier species costs a palette and a spawn row, not a rig and a bespoke silhouette,
because it shares its base's assets. You get the freed budget and keep the
content. If it turns out tiering cannot actually hold that line in production —
if every row demands a unique asset regardless of tier — then deletion becomes
the better option and the rubric gives a defensible order for it, lowest total
first.

### 6.2 Why not keep the promise either

The ceiling in §2.1 is 25–70 genuinely distinct fights, and we are two people. We
currently present 680 species as 680 things to learn — each with a bestiary
entry, a field-journal slot and a rank. Against 193 perceivable profiles, 100 of
them ignoring size and flight, that promise is false, and the player finds out in
Aldmere, where 128 ring-2 species deliver 70 fights.

The flat spawn curve (§2.7) makes it worse: with every species about equally
common, the player never builds familiarity with a core group, so the repetition
registers as *sameness* rather than as *recognition*.

### 6.3 The cut that actually scores

Three tiers over the rows we already have:

| Tier | Count | What it gets | What it costs |
|---|---|---|---|
| **Learned** | **~40** | Bespoke silhouette rule, one move of its own, its own approach class, an idle tell, an audio cue, a bestiary entry, a field-journal slot — **and a raised spawn weight** | Full authoring. This is where the next year of creature work goes. |
| **Resident** | **~250** | The rig's moveset and family signature, a palette, a habitat, a field note. Named, fought, looted — presented as *a kind of thing*, not a species to study | About what they cost today |
| **Population** | **~390** (incl. most of the 353 variants) | Appear in the world and in loot; **no separate bestiary page**; shown as a variation under their base's entry | Less than today — the journal entries go away |

Nothing is deleted. `species.json` keeps 680 rows, Canon line 35 stays true, and
the Ring 2 trim row in Canon §6 is satisfied by promotion-and-demotion rather
than deletion.

**How to pick the 40 — and why not by current spawn frequency.** The obvious
method is to author whatever the player meets most. That does not work here:
§2.7 shows spawn frequency is nearly uniform, with the top 40 species covering
6.5% of population entries. There is no existing core to find. So the 40 must be
**chosen and then made common**:

1. Take the rubric's ranking (74 species already score STRONG on data alone).
2. Constrain to coverage: at least one per rig, per region cluster and per rank
   band, so no stretch of the game is made of Residents only.
3. Add the ones already written — Mycelia shows what a hand-written Tyrant
   scores. But **do not let the 40 be mostly Tyrants**: a Tyrant is one boss per
   region, met once. If the 40 are all bosses, Aldmere's everyday 128 species
   still deliver 70 fights and nothing the player meets daily improves. Aim for
   roughly a quarter Tyrants, three quarters everyday species.
4. **Then raise their spawn weight** in `population.json` so the Learned 40 are
   genuinely the creatures a player sees most, and lower the Population tier's.
   This step is what converts the authoring into felt quality, and it is cheap —
   it is a data change.

### 6.4 Canon §6 proposal

| Row | Question | Recommendation | Touches | Decision |
|---|---|---|---|---|
| **M1** | **Bestiary tiers.** Should species be tiered by how much identity the game promises them, instead of trimming the roster? | `species.json` keeps all **680** rows. Species are tiered **Learned (~40) / Resident (~250) / Population (~390)**. Only Learned species get a bespoke silhouette rule, an attack no rig-mate shares, their own executed approach class, a field-journal entry **and a raised spawn weight**. Residents keep their rig moveset and family signature. Population variants appear **under their base species' bestiary entry**, not their own. The Learned list is picked by `Tools/bestiary_rubric/score.js` plus rig/region/rank coverage, with Tyrants at most a quarter of it. **Supersedes** the open Ring 2 row ("trim ~145 tagged species to ~60 cores"), which deletes content this keeps; §6.1 gives the case for deletion if tiering cannot hold its cost line in production. | `Data/Monsters/species.json` (a `tier` field); `population.json` (spawn weights); `08_Bestiary/monster_design_kit.md` §7; the bestiary viewer and field journal; Canon §6 Ring 2 roster row | Approve tiers [ ] · Keep the trim instead [ ] · Neither [ ] |

**Interaction with Canon line 150 (taming), checked.** That locked row gives a
tamed partner one permanent evolution at Bond 5 "into a variant of its species
(elemental, elder, ancient, regional…) chosen with a preview". Demoting variants
to Population does **not** break it: the evolution targets and the preview both
still exist as species rows, and the preview shows the variant as a variation
card under its base's entry rather than opening a page of its own. Nothing about
the taming numbers, the family list or the Bond ladder changes. This is a
presentation change, not a roster change — which is the point of tiering.

**This needs your OK.** It changes what the bestiary promises, which is a
design-identity call rather than a creative detail inside Canon.

---

## 7. Sources, and what could not be sourced

**Measured in this repo** (reproduce with `node Tools/bestiary_rubric/score.js .`
and `node Tools/bestiary_rubric/ceiling.js .`): all species, vector and collision
counts; the per-rig shared movesets; the element-to-weakness function; the
behaviour-radii table; the rank-band means; the spawn-frequency distribution; the
rubric scores.

**Grepped in this repo:** every "executed" and "not executed" claim in §2.2, each
against `Code/Ascend.Core`, `Code/Unity/Runtime` and `Game/Assets/_Game/Runtime`.

**External:**

- Miller, G. A. (1956). *The Magical Number Seven, Plus or Minus Two.*
  [psychclassics.yorku.ca/Miller](https://psychclassics.yorku.ca/Miller/)
- Cowan, N. (2001). *The magical number 4 in short-term memory.* BBS 24(1).
  [PDF](https://memory.psych.missouri.edu/assets/doc/articles/2001/cowan-bbs-2001.pdf)
- Getty, D. J. (1975). *Discrimination of short temporal intervals.* Perception &
  Psychophysics 18, 1–8.
  [PDF](https://link.springer.com/content/pdf/10.3758/BF03199358.pdf)
- Rammsayer, T. H., Borter, N., & Troche, S. J. (2015). *Visual-auditory
  differences in duration discrimination.* Frontiers in Psychology 6:1626.
  [PMC4620148](https://pmc.ncbi.nlm.nih.gov/articles/PMC4620148/)
- van Beek, J.-B. (GDC 2018). *A No-Nonsense Approach to Designing Horizon Zero
  Dawn's Robot Dinosaurs.* Mined with `Tools/tutorial_vision/tv.py`, cache id
  `Youtube_iDqDPsjrz94`: 36 frames, 40 crops and 3 contact sheets over 3,657 s,
  plus the caption track. Positions given inline are caption timestamps; §1.5
  describes frames from sheet 3. Points are paraphrased, not quoted at length.
  **Ideas only — no art, text or data taken.**
- Roster counts: Horizon's 25 machine species
  ([GamesRadar](https://www.gamesradar.com/horizon-zero-dawns-mechanical-animals-were-inspired-by-angry-chickens-and-emus-fighting-kangaroos));
  Monster Hunter: World 37 at launch / 71 with Iceborne
  ([Twinfinite](https://twinfinite.net/guides/monster-hunter-world-iceborne-how-long-it-is-how-many-monsters-there-are/)).
- Shape language, skeleton reuse and palette-swap practice are already sourced in
  `08_Bestiary/monster_design_kit.md` §1 and are not re-derived here.

**Gaps, wired to the verdicts rather than noted beside them:**

- `NOT SOURCEABLE — no study or published design account gives a number for how
  many distinct enemy types a player can tell apart in one game.` The 25–70
  ceiling in §2.1 is an **inference** from Miller/Cowan/Getty plus shipped roster
  counts. It is load-bearing for §6, and it is an inference. If it is wrong in
  the generous direction the tier counts move — but the 193-against-680 gap that
  motivates tiering is **measured**, not inferred, and does not depend on it.
- `NOT SOURCEABLE — no study of player recall of game creature designs over days
  or weeks was found.` §1.6 is reasoning, and category E therefore scores only
  data proxies. E can never establish that a creature *is* memorable, only that
  it has the ingredients. Any species' E score should be read with that limit.
- `NOT SOURCEABLE — the "one role, one weakness per demon" framing often
  attributed to Doom Eternal could not be confirmed from a primary source` (the
  NoClip "Designing Demons" interview was not readable in this session). It is
  not used as support anywhere above.
- **NOT ASSESSED — the completion dashboard** (§6.0). No definition of it was
  found in this repo, so no projected quantity × quality figure is claimed here.
- **NOT ASSESSED — every rendered, animated and audio check**, for all 680
  species (§4.1). Contact sheets were inspected for the dragon family only; the
  64px silhouette evidence is from `reports/blender_wave_2026-11-02/creatures/`,
  where `silhouette_64px_dragons_vs_wolf_x4.png` is first-wave and
  `w1_after_dragons.png` is post-fix.
- **NOT ASSESSED — whether any of this survives contact with a player.** No
  playtest informs this note. Everything here is measured off data, code and
  renders.
