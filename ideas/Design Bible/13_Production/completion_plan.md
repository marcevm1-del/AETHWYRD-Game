# How finished AETHWYRD is, and what moves the number

The dashboard (`Tools/dashboard/agent_dashboard.py`) reports one percentage. This is the plan behind it: what the
number means, what raises it, and what each milestone demands. The goals themselves live in
`Data/completion_goals.json`, which is the file to edit — this document explains it, it does not duplicate it.

**As of 2026-11-15 the game is 25.4% finished.** That is a real number, not a feeling, and it is low for a reason
worth stating plainly: we have a great deal of content at blockout quality and almost nothing at shipping quality.

## The model

Every goal scores twice.

**Quantity** is counted from the repo — 32 of a target 120 quests, 680 of 680 species. The dashboard reads the data
files directly, so this half cannot drift from reality or be talked up.

**Quality** is a level from 0 to 4, set deliberately by a person or a gate:

| Level | Name | What it means |
|---|---|---|
| 0 | absent | Nothing exists, or nothing that runs in the game |
| 1 | blockout | Exists but is placeholder: right shape, wrong finish |
| 2 | working | In the game and functioning, not yet good |
| 3 | polished | Good enough to show someone without apologising |
| 4 | shippable | Passes its gates and would survive a review |

**A goal's score is quantity × quality.** 680 blockout monsters score 25%, not 100%, because 680 placeholders are
not a finished bestiary. This is the whole point of the model: counting alone would have told us we were nearly
done with monsters, which is false.

The overall figure is the weighted average. Weights say what matters to *this* game — quests weigh 5, the library
weighs 1 — and they are arguable. Argue with them in `Data/completion_goals.json`, not in your head.

### Two rules that keep the number honest

**A missing file is NOT ASSESSED, never 0%.** If `Data/Quests/quests.json` disappears, the dashboard says it could
not assess quests. A dashboard that reports a missing file as zero has invented a fact, and the permissive reading
of an unknown is exactly the failure `.claude/rules/skill-authoring.md` is about.

**Estimated targets are marked `est`.** The 120-quest target is a guess at what a 30-hour RPG needs. Every `est`
in the table is a number nobody has justified yet, and replacing guesses with a real content plan is itself work.

## Milestones

| Milestone | Overall | What it actually means |
|---|---|---|
| **Vertical slice** | 35% | One region playable end to end at *polished* quality: quests, audio, art and UI all at level 3 in Ring 0, even while the rest of the world stays blockout. The point is to prove the game is good somewhere before making it big everywhere. |
| **Alpha** | 55% | Every system exists and runs. Content complete to half its targets. Nothing at level 0: every discipline has something in the game, audio included. |
| **Beta** | 75% | Content complete. Everything at level 2 or better, the critical path at 3. Steam page live, build uploading, age rating submitted. |
| **Ship** | 90% | Critical path at 4. Nothing below 2. Every `est` target replaced by a real one and met. |

We are at 25.4%, which puts the vertical slice as the next milestone and makes its gap clear: **audio at 0% and
Ring 0's art at blockout are what stand between us and 35%**, not more content.

## What raises each goal

Ordered by what buys the most percentage for the least work. Weight × the gap is the arithmetic; judgement is in
the ordering.

### Audio — 0%, weight 4, the single biggest hole
Not one sound plays. This is the largest weighted zero on the board and the cheapest to move: going from silence to
footsteps, hits, UI clicks and one ambient bed takes audio from level 0 to level 2 and moves the overall figure by
roughly two points on its own. **Blocked on one decision** — Unity's built-in audio versus FMOD or Wwise — which
`audio-research` was started to settle.

### Ring 0 art — blockout, weight 2 to 3 each
Buildings, terrain and props are stand-ins. Polishing *one region* rather than improving all 49 is what the vertical
slice asks for, and it is the difference between a demo that reads as a game and one that reads as a prototype.

### Quests — 32 of 120, weight 5
The heaviest weight on the board, and the most expensive to move, because quests are writing. 13% today. Every ten
quests at working quality is about a point of overall progress.

### Animation — generated but never imported
106 combat clips, 55 rider clips and 19 facial expressions per base exist in Blender and have **never been played on
a character in Unity**. Until they are, how any of it feels is NOT ASSESSED. Importing them is a day's work that
turns a level 1 into a level 2 across a weight-3 goal.

### Monsters — 680 at blockout
The largest quantity in the project at the lowest quality. The honest question `monster-research` was asked is
whether 680 should stay 680: half as many at *working* quality would score higher and play better.

### Steam — 0%, weight 3
Nothing but a line of config. Several steps have waiting periods — the tax interview, the age rating — so this is
worth starting long before it feels urgent.

## How the dashboard stays true

**Cheap numbers are live.** Counts come from the data files on every page load, so content progress needs no
maintenance and cannot be overstated.

**Expensive numbers are cached** in `13_Production/status_snapshot.json`: the rules test count after `npm run build`,
the Unity count after a PlayMode run. Refresh it when you run them, and keep `checkedOn` honest — stale is better
than wrong, but only if it admits it is stale.

**Quality levels are promoted on evidence, never on effort.** A level goes up when something specific is true:

- → **1 blockout**: it exists and loads in the game.
- → **2 working**: it functions in a build, and a test or a check covers it.
- → **3 polished**: its own gate passes (`check_characters.py`, the art rubric, the boss review checklist), *and*
  somebody looked at it and did not wince.
- → **4 shippable**: level 3 plus it survives review by the relevant agent — `anime-fantasy-director` for art,
  `qa-tester` for systems — and has not regressed in a month.

Writing a level up without the evidence is how a dashboard becomes decoration. If a level is argued rather than
demonstrated, the `evidence` field in `completion_goals.json` must say so in plain words — every goal carries one
today, and several of them admit what has not been checked.

**Review cadence**: levels get a hard look at every milestone, and whenever a gate first passes. The `evidence`
strings are the audit trail; they are prose on purpose, so that a claim cannot hide inside a number.
