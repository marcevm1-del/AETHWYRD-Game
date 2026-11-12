# Review of the planning system, 2026-11-12

Two read-only reviews were run on the `Planning/` folder before the owner was asked to approve it: a `red-team-reviewer` pass (opus), which also gave the technical-architect and QA view, and a `documentation-auditor` pass (haiku). The owner's command names five reviewers; two were used because the usage limit had already stopped three agents that day (D-012). This file is the orchestrator's record of what they found. What was done about each finding is in `DECISION_LOG.md`, "Review of the planning system".

## Red-team review

**Spot-checks (8 claims, all held):** `Damage.cs` `Compute` never reads the damage kind; `MonsterDummy.cs` line 61 builds the reaction state without the loaded table; `MonsterController.cs` lines 187 to 193 fill only the six original sense fields; `weapon_movesets` is read only by the validator; `ScreenshotRunner.cs` is the only Runtime caller of the clue and archive writers; `SaveGame.cs` has `CompanionBonds` and the game saves it; the dashboard and discrepancy counts add up.

**Judged sound:** the two-status ladder; no percentages; ideas are not commitments; canon conflicts surfaced honestly; the audit facts; the core diagnosis (rules written but not wired; the loop never judged by a person).

### Blockers

- **B1. Kills by a companion or partner give no credit.** `Killed` is raised only in `PlayerCombat.ScoreHit` (`PlayerCombat.Progress.cs` line 70). `CompanionAI.Strike` calls `TakeHit` directly (`CompanionAI.cs` lines 202 to 203) and `MonsterDummy.Defeat()` raises no event. So an ally's last hit gives no XP, loot, quest kill or bestiary tick; on Grukk it gives no liberation (`SiegeDirector.cs` lines 74 to 76), and bosses never respawn (`MonsterController.cs` line 65). Reasoned from the code, not run. Fix: a defeated event from the monster, subscribers moved onto it, a PlayMode test where a companion kills Grukk.
- **B2. The plan recorded itself as reviewed and done before that had happened.** D-012 said four agents reviewed it; the weekly plan listed six delegated audits where there were five reports and one was written by the orchestrator; MS-0 and phase 0 were marked done with the decision log as their own evidence. This is risk R14 inside the document meant to stop it.

### Major

- **M1. Acceptance criteria that pass on failure.** T-001, UPG-026 and MS-1 passed when a row was recorded, even for a red run. T-003, MS-2 and the phase 1 exit passed on "pass or fail", so phase 2 could start on a loop that failed its fun test.
- **M2. The weekly verify run can test a stale commit.** `update_and_verify.ps1` lines 46 to 48 skip the pull when the tree is dirty, and its own scene rebuild leaves a diff.
- **M3. Priorities did not follow the slice.** Slice-critical upgrades were rated P2 and P3 (UPG-007, UPG-011, UPG-016, UPG-018) while magic (UPG-004, T-005), which the slice excludes, was P1 and in the first wave. T-019 and T-023 are not in the slice. UPG-016 does not need UPG-015.
- **M4. The slice was too big for one Unity slot a week:** 8 to 11 slots before presentation, two new data types, a save change, three canon decisions; at least three to four months with nothing going wrong. Day and night cannot be shown in a 30 to 45 minute sitting. Smallest version that still proves the game: Swordsman only, today's hand-placed camps, 3 or 4 discoveries through the existing discovery journal, the pack with tactics, Grukk with one phase-specific attack, a liberation delta of three things, the redacted line flipping on the liberation flag, save and load.
- **M5. The slice gate could not be measured:** "someone who has not seen the game" evidenced by the owner; "every item kept" let failing items be cut; presence of givers stood in for completability; saved states unlisted; the target PC unnamed; nothing asked whether it is good.
- **M6. Approval holes.** New data types, save-format changes and claims on the owner's hours were not reserved for the owner; D-009 and D-010 were logged as approved while awaiting the owner; gate 10 accepted screenshots, which `ScreenshotRunner` can fake; VERIFIED accepted a PlayMode run; gate 6 compared pass counts only; a behaviour-changing one-line fix could be classed as minor.

### Minor

- Only three of the five "no Unity" tasks could really start; T-009 also waits on a decision.
- T-005 omitted its dependency on a damage-kind field, and skills already use `kind` for chain and launcher.
- `PROJECT_STATUS.md` §8 rated Ring 0 too high; §3 called the loop solid though most of it is untested.
- IDEA-007 contradicts `combat.md` §10a as described; IDEA-014 is an existing Canon §6 proposal.
- Respec is promised by Canon §5, absent in code, and had no discrepancy row.
- A fun test played on fixed camps goes stale if encounter tables replace them later.
- The planning branch is not on `main`, so the PC script and vault cannot see it.

### Strategy and weight

"Verify, wire, one slice" is right. The strongest argument against it: the bottleneck is owner hours and Unity slots, not agent time, so under a freeze agents can only produce cloud work, which without a cap becomes more documents. Twenty planning documents is too heavy for two people; the hand-typed counts, the milestone tracker, the dependency graph and release readiness will rot first. Suggested: about twelve documents, counts from a script.

### To tell the owner plainly

The plan is months of weekly sessions before an outsider can play; 25 or more decisions wait; the fun test will be judged on a silent capsule; renaming the product moves the real save folder; and B1 shows the Unity side has not been reviewed closely.

## Documentation-auditor review

Scripted checks over `Planning/*.md`. Clean: no undefined or duplicate IDs (39 upgrades, 27 ideas, 23 tasks, 34 discrepancy rows, 30 risks, 12 decisions, 9 milestones, 150 systems at the time); every upgrade-to-task link reciprocal; every status word valid; 179 file references resolved except one; the six new agent files valid; pins across 67 agent files: opus 4, sonnet 26, haiku 1, inherit 36.

Ten findings, all fixed: the dashboard's system buckets summed to 137 of 150 (uncertain and not-applicable rows missing); the tier paragraph said three new sonnet agents where there are four and did not name the studio layer's pinned agents; T-016's parent was a discrepancy row, not an upgrade; one audio path did not exist; UPG-031 cited a system ID that is not in the inventory; three roster overlaps (`10_World/`, `08_Bestiary/`, `reports/`) where the main table had not been narrowed; one status word in `PROJECT_STATUS.md` §6 outside the inventory's vocabulary.

## Not checked by either review

Anything in a running Unity editor; the owner's PC; the content of the five audit reports beyond the spot-checks; the 13_Production documents beyond those cited.
