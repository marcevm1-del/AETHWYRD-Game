# Upgrade register

The permanent record of improvements to things that already exist or already have an established design. A new possibility belongs in `IDEAS.md`; approved work belongs in `FEATURE_BACKLOG.md`. Template: `TASK_TEMPLATES.md` §2.

## Rules

1. An entry is never deleted. Set it to REJECTED or DEFERRED and say why in its decision history.
2. No duplicates. Merge, and keep what each duplicate contributed (the "source" in the decision history names the audit findings merged here).
3. PROPOSED is not approved. Only APPROVED or READY entries may have tasks in the backlog.
4. VERIFIED needs the evidence `QUALITY_GATES.md` asks for; IMPLEMENTED needs a test.
5. Every entry names the system it improves by its `SYSTEM_INVENTORY.md` ID.
6. Approval follows `CHANGE_CONTROL.md`: the orchestrator for minor changes, the owner for anything in its §4.

Statuses: PROPOSED · INVESTIGATION · APPROVED · READY · IN PROGRESS · BLOCKED · IMPLEMENTED · VERIFIED · DEFERRED · REJECTED.
Priority: P0 critical defect or blocker · P1 essential · P2 high value · P3 useful · P4 optional refinement.

## Where these came from

The first 39 entries were written on 2026-11-12 from five audits (`Planning/audits/`). The four specialist audits proposed 42 candidates and the technical audit added its findings; overlapping ones were merged. The owner's earlier `upgrade v2` to `upgrade v11` documents were audited in `13_Production/*_audit.md` when they arrived, and what was adopted from them is already built or in `Canon.md` §6; their unbuilt remainder is covered here only where an audit found it still worth doing. They are kept at the repo root as source material.

## Index

| ID | Title | System | Priority | Complexity | Status |
|---|---|---|---|---|---|
| UPG-001 | Run and record the Ring 0 fun test | SYS-CMB-32, SYS-CORE-09 | P0 | S | APPROVED |
| UPG-002 | Wire group tactics into the game for the goblin pack | SYS-CMB-20, SYS-ECO-09, SYS-CMP-06 | P1 | M | PROPOSED |
| UPG-003 | Feed `reactions.json` to the game | SYS-CMB-07, SYS-CMB-08 | P1 | S | PROPOSED |
| UPG-004 | Magical damage path | SYS-CMB-06, SYS-PRG-06 | P2 | S | PROPOSED |
| UPG-005 | Enforce `launchable` so heavy monsters stay grounded | SYS-CMB-03 | P1 | S | PROPOSED |
| UPG-006 | Wire the sword moveset to the Swordsman | SYS-CMB-15 | P2 | M | PROPOSED |
| UPG-007 | Give Grukk's fight verbs: phase attack sets, armour and one weak point | SYS-CMB-21, SYS-CMB-22, SYS-CMB-10 | P1 | L | PROPOSED |
| UPG-008 | Show what the player has learned in a fight | SYS-CMB-17, SYS-EXP-04 | P2 | M | PROPOSED |
| UPG-009 | A small discovery registry and world objects that write to the journals | SYS-EXP-08, SYS-EXP-10, SYS-EXP-12, SYS-EXP-19 | P1 | M | PROPOSED |
| UPG-010 | Journal window: a discoveries page and a quest page | SYS-EXP-08, SYS-QST-14 | P1 | S | PROPOSED |
| UPG-011 | One bestiary knowledge vocabulary, research tasks and a route that needs no killing | SYS-ECO-10, SYS-EXP-04 | P1 | M | PROPOSED |
| UPG-012 | Settle what 'Appraisal' is and give it one hook | SYS-EXP-04, SYS-EXP-05 | P2 | S | PROPOSED |
| UPG-013 | Quest choices that change something, with a receipt | SYS-QST-07 | P1 | M | PROPOSED |
| UPG-014 | Every quest completable, or visibly parked | SYS-QST-03, SYS-QST-08 | P1 | S | PROPOSED |
| UPG-015 | Acts and story flags as data | SYS-QST-06, SYS-QST-11 | P2 | S | PROPOSED |
| UPG-016 | Tie the Status Window's redacted line to story flags | SYS-EXP-06 | P1 | S | PROPOSED |
| UPG-017 | Guidance setting: quest markers on or off | SYS-EXP-17 | P3 | S | PROPOSED |
| UPG-018 | Liberation delta: the freed region visibly changes | SYS-WLD-09, SYS-EXP-18 | P1 | M | PROPOSED |
| UPG-019 | Fix rank-band defects in Whisperwood before anything spawns from data | SYS-ECO-04, SYS-ECO-01 | P1 | S | PROPOSED |
| UPG-020 | Spawn the field from `encounters.json` | SYS-WLD-12, SYS-ECO-05 | P1 | M | PROPOSED |
| UPG-021 | A small ecology layer: role tags and a four-state region cycle | SYS-ECO-06, SYS-ECO-08 | P2 | L | PROPOSED |
| UPG-022 | Apply living-world event effects, rumours first | SYS-WLD-10, SYS-EXP-13 | P2 | S | PROPOSED |
| UPG-023 | Three ambient monster behaviours outside combat | SYS-ECO-09 | P3 | M | PROPOSED |
| UPG-024 | Creature art: only the next ring, and a safe home for the files | SYS-ECO-13, SYS-TEC-08 | P1 | M | PROPOSED |
| UPG-025 | Report data that nothing reads; make CI see untracked generated files | SYS-CORE-02, SYS-TEC-01 | P2 | S | PROPOSED |
| UPG-026 | A recorded PC verify run every week | SYS-TEC-04, SYS-TEC-05, SYS-TEC-03 | P0 | S | APPROVED |
| UPG-027 | First performance measurement, then the known allocation fixes | SYS-TEC-10 | P1 | S | PROPOSED |
| UPG-028 | Save version rule and product identity | SYS-CORE-03, SYS-TEC-06 | P1 | S | PROPOSED |
| UPG-029 | Documentation drift sweep | SYS-TEC-11 and docs across the repo | P2 | S | PROPOSED |
| UPG-030 | Sound in the game: play the Ring 0 cue sheet | SYS-CORE-08 | P2 | M | BLOCKED |
| UPG-031 | A player character in the game | SYS-CMB-01, SYS-EXP-01 (the player's body and animation; the character model has no inventory row of its own) | P1 | M | BLOCKED |
| UPG-032 | Choose the shipping UI technology before polishing any screen | SYS-CORE-06 | P2 | M | PROPOSED |
| UPG-033 | Quest board guard and a banter trace | SYS-QST-04, SYS-QST-13 | P3 | S | PROPOSED |
| UPG-034 | Decide the class line-up for Ring 0 and the slice, and say it in the docs | SYS-PRG-04, SYS-CMB-14 | P1 | S to M | PROPOSED |
| UPG-035 | Respec and point allocation | SYS-PRG-13, SYS-PRG-01 | P2 | M | PROPOSED |
| UPG-036 | An economy sink plan before housing and farming open | SYS-ECN-12 | P3 | M | PROPOSED |
| UPG-037 | Reach one rules-only system from a Ring 0 station | SYS-ECN-08, SYS-ECN-09, SYS-ECN-10 | P3 | M | PROPOSED |
| UPG-038 | Dialogue as data | SYS-QST-09, SYS-QST-08 | P2 | M | PROPOSED |
| UPG-040 | Kill credit when a companion or partner lands the last hit | SYS-CMB-26, SYS-CMP-04, SYS-CMP-07 | P0 | S | PROPOSED |
| UPG-039 | Write the architecture decisions down | SYS-CORE-01 | P2 | S | PROPOSED |

## Entries

### UPG-001: Run and record the Ring 0 fun test

- **Existing System:** SYS-CMB-32, SYS-CORE-09
- **Current Implementation Status:** Checklist DOCUMENTED; never run
- **Current Problem:** The Ring 0 exit gate has never been measured. All 12 boxes in `combat.md` §12 are unchecked; `ring0_plan.md` speaks of 6 checks; four items depend on systems the game does not use yet.
- **Evidence:** `12_Systems/combat.md` §12; `13_Production/ring0_plan.md` lines 36 to 39; `roadmap_after_upgrade_waves.md` (M1)
- **Proposed Improvement:** Split §12 into items testable today (launcher chain, dodge and parry, Firestorm, Style Rank, hit weight) and items that need wiring (pack from several sides, boss armour and weak points). The owner plays the first group for 10 minutes with a record sheet; each box gets pass or fail, date, settings and one sentence. Failures become tasks.
- **Player Benefit:** The first thing a player does is known to be fun, or known not to be, before more is built on it.
- **Technical Benefit:** Turns an unknown into a defect list.
- **Gameplay Benefit:** Sets the feel baseline every later combat change is compared with.
- **Dependencies:** Owner time (about an hour); a current Ring 0 build (UPG-026)
- **Affected Systems:** Combat, Ring 0 gate
- **Affected Files:** `12_Systems/combat.md`, a dated note in `13_Production/`
- **Priority:** P0
- **Complexity:** S
- **Risk:** Feel problems surface late. That is the purpose.
- **Acceptance Criteria:** Every testable box is marked pass or fail with date and settings; every fail has a backlog task; the 6-versus-12 count is reconciled.
- **Testing Requirements:** Manual playtest by the owner. Record difficulty, camera shake and damage-number settings.
- **Status:** APPROVED
- **Related Ideas:** IDEA-008
- **Related Tasks:** T-002, T-003
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-1; already milestone M1 of the roadmap); approved by the orchestrator because it is already part of the owner-accepted roadmap.

### UPG-002: Wire group tactics into the game for the goblin pack

- **Existing System:** SYS-CMB-20, SYS-ECO-09, SYS-CMP-06
- **Current Implementation Status:** Rules TESTED; game NOT WIRED
- **Current Problem:** Packs do not flank, yield or retreat as designed. `MonsterController` passes only distance, home distance, HP, token, packmates and ward to the brain. Two fun-test items cannot pass without it. Eight tuning keys are reserved and read by nothing.
- **Evidence:** `Runtime/World/MonsterController.cs` lines 187 to 193; `Code/Ascend.Core/GroupTactics.cs`; `13_Production/handover/group_tactics_wiring.md` (brief written, not executed)
- **Proposed Improvement:** Execute the written brief: pass player HP fraction, allies near, flank slot and count, yield token; set the brain's tactics from tuning. Goblin pack only. Check first whether the PC branch `agent/ai-engineer/companion-presets-tactics` already does this.
- **Player Benefit:** A pack of five surrounds the player and visibly falls back when losing.
- **Technical Benefit:** All logic and tests already exist; this is wiring.
- **Gameplay Benefit:** Makes the level-1 goblin pack the danger the design says it is.
- **Dependencies:** Unity on the PC; the state of the unmerged PC branch
- **Affected Systems:** Monster AI, aggro tokens
- **Affected Files:** `Runtime/World/MonsterController.cs`, `AggroDirector`, one new PlayMode test
- **Priority:** P1
- **Complexity:** M
- **Risk:** Yield rule can cycle with three or more contenders (noted in the brief). Must keep Canon §4d: no leader, no memory.
- **Acceptance Criteria:** In a PlayMode test five goblins take at least three distinct approach angles; no state survives the fight; `enabled=false` restores today's behaviour.
- **Testing Requirements:** New PlayMode test; Core suite unchanged at 755 or more.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-023
- **Related Tasks:** T-007
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-2, ecology U6); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-003: Feed `reactions.json` to the game

- **Existing System:** SYS-CMB-07, SYS-CMB-08
- **Current Implementation Status:** Rules TESTED; game uses the built-in default table
- **Current Problem:** Editing the reaction data changes nothing in play. The game builds its reaction state without the loaded table, so synergies are unreachable.
- **Evidence:** `Runtime/World/MonsterDummy.cs` line 61; `Code/Ascend.Core/Data.cs` lines 220 to 262; no Runtime reference to `ReactionTable`
- **Proposed Improvement:** Pass the loaded table when the reaction state is created. Keep the parity test that pins the data to the defaults.
- **Player Benefit:** None visible on day one; reactions then behave as the design data says.
- **Technical Benefit:** The file designers tune becomes the file the game reads.
- **Gameplay Benefit:** Six reaction synergies become reachable.
- **Dependencies:** None
- **Affected Systems:** Elements and reactions
- **Affected Files:** `Runtime/World/MonsterDummy.cs`, one PlayMode test
- **Priority:** P1
- **Complexity:** S
- **Risk:** Low: values are pinned by existing tests.
- **Acceptance Criteria:** Changing one multiplier in the JSON changes both the headless sandbox result and the in-game hit by the expected factor.
- **Testing Requirements:** PlayMode test applying Fire then Wind through both paths.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-020
- **Related Tasks:** T-004
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-3); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-004: Magical damage path

- **Existing System:** SYS-CMB-06, SYS-PRG-06
- **Current Implementation Status:** Rules PARTIAL (an enum only); game NOT WIRED
- **Current Problem:** `DamageCalculator.Compute` never reads the damage kind. Every hit in the game is physical, MP cost is never spent, MATK and MDEF are unused. A Mage, Cleric or Occultist would be a physical attacker. Dormant today because only the Swordsman is playable.
- **Evidence:** `Code/Ascend.Core/Damage.cs` lines 52 to 71; `Runtime/Combat/PlayerCombat.Skills.cs` line 134; `MonsterController.cs` line 397; `CompanionAI.cs` line 202; `12_Systems/combat.md` §9
- **Proposed Improvement:** Add the magical branch in Core (MATK against MDEF), set the kind from the skill's data, spend MP on cast. Core only first; the Unity call sites follow in a PC slot.
- **Player Benefit:** Caster classes become possible.
- **Technical Benefit:** Removes a silent mismatch between the documented formula and the code.
- **Gameplay Benefit:** Opens the second damage axis the class system assumes.
- **Dependencies:** A damage-kind field on skill data
- **Affected Systems:** Damage, skills, classes, companions
- **Affected Files:** `Code/Ascend.Core/Damage.cs`, new Core tests, later `PlayerCombat.Skills.cs`
- **Priority:** P2
- **Complexity:** S
- **Risk:** ATK-versus-MATK balance has never been exercised.
- **Acceptance Criteria:** Same attacker with equal ATK and MATK against different DEF and MDEF gives the documented ratio; MP drops by the cost; physical results are unchanged.
- **Testing Requirements:** Core unit tests (can be written and run in the cloud).
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-005
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-4, progression U1); recorded as PROPOSED; not in the actionable backlog until approved. 2026-11-12, orchestrator, after the red-team review (M3): priority changed from P1 to P2 to follow the vertical slice.

### UPG-005: Enforce `launchable` so heavy monsters stay grounded

- **Existing System:** SYS-CMB-03
- **Current Implementation Status:** Game TESTED for launching; the restriction data is ignored
- **Current Problem:** The launcher lifts every monster. 266 species carry a restriction (147 only while staggered, 98 never, 21 head only) that no code reads, against `combat.md` §4.3.
- **Evidence:** `Runtime/World/MonsterDummy.cs` line 171; `PlayerCombat.cs` line 287; `Data/Monsters/motion.json`
- **Proposed Improvement:** `Launch` reads the species value and gives a 'resisted' cue when refused.
- **Player Benefit:** Big monsters feel heavy; the launcher becomes a choice.
- **Technical Benefit:** A stated rule becomes true.
- **Gameplay Benefit:** Staggering a large monster gains a payoff.
- **Dependencies:** The existing motion-data loader
- **Affected Systems:** Air combat
- **Affected Files:** `Runtime/World/MonsterDummy.cs`, one PlayMode test
- **Priority:** P1
- **Complexity:** S
- **Risk:** Changes how Grukk plays.
- **Acceptance Criteria:** A staggered large biped can be launched; the same monster unstaggered cannot.
- **Testing Requirements:** PlayMode test.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-006
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-5); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-006: Wire the sword moveset to the Swordsman

- **Existing System:** SYS-CMB-15
- **Current Implementation Status:** DATA ONLY: no code reads `weapon_movesets.json`
- **Current Problem:** Fourteen weapon families are designed and validated, and tuning them changes nothing. All four Swordsman weapon types play as one generic sword.
- **Evidence:** `Data/Combat/weapon_movesets.json`; `12_Systems/weapon_movesets.md` ('no Unity or Core code reads this file yet')
- **Proposed Improvement:** One Core reader and one family (`wf_sword`) driving reach, arc, lunge and the five roles. The other thirteen stay data until this path is proven.
- **Player Benefit:** The sword has an identity that data can tune.
- **Technical Benefit:** One proven path before more weapons.
- **Gameplay Benefit:** Foundation for weapon identity.
- **Dependencies:** UPG-001 result first
- **Affected Systems:** Player attack chain
- **Affected Files:** `Code/Ascend.Core` (new reader), `Runtime/Combat/PlayerCombat.cs`
- **Priority:** P2
- **Complexity:** M
- **Risk:** Two sources for the same numbers (`attackTiming` and the moveset): pick one.
- **Acceptance Criteria:** Editing `wf_sword` changes swing timing in the game; a parity test holds today's values.
- **Testing Requirements:** Core and PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-008
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-8); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-007: Give Grukk's fight verbs: phase attack sets, armour and one weak point

- **Existing System:** SYS-CMB-21, SYS-CMB-22, SYS-CMB-10
- **Current Implementation Status:** Phases IMPLEMENTED (banner, summons); armour and weak points rules TESTED, game NOT WIRED; Break gauge key has no reader
- **Current Problem:** Boss phases only add a banner and summons. Armour, break and weak points exist as tested rules that the game never calls. `combat.md` §4.3 promises a Break gauge that does not exist.
- **Evidence:** `Runtime/World/MonsterController.cs` lines 111 to 143; `Code/Ascend.Core/BossWeakPoints.cs`; `Data/Monsters/boss_weakpoints.json`; `combat_tuning.json` `bossBreakKnockdownSec`
- **Proposed Improvement:** For Grukk only: let a phase switch the attack set, connect the weak-point rules to his hit path, show the rune brand, and either build the Break gauge or strike it from the Ring 0 text.
- **Player Benefit:** The first boss asks a new question in each phase and rewards watching it.
- **Technical Benefit:** Proves the boss framework on one fight before five more.
- **Gameplay Benefit:** The Ring 0 boss earns four fun-test items.
- **Dependencies:** UPG-003; hurtbox part names in rig data (unverified); an armour-crack cue (art, audio)
- **Affected Systems:** Bosses
- **Affected Files:** `Runtime/World/MonsterController.cs`, `Data/Monsters/boss_phases.json`, `BossPhaseTests`
- **Priority:** P1
- **Complexity:** L
- **Risk:** Needs art and sound cues that do not exist.
- **Acceptance Criteria:** Grukk's second phase uses an attack the first does not; hitting the exposed brand breaks armour once per fight at most; a fight that ignores armour is still winnable.
- **Testing Requirements:** Extended Core boss tests; PlayMode with sandbox parity.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-009
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-9, U-11); recorded as PROPOSED; not in the actionable backlog until approved. 2026-11-12, orchestrator, after the red-team review (M3): priority changed from P2 to P1 to follow the vertical slice.

### UPG-008: Show what the player has learned in a fight

- **Existing System:** SYS-CMB-17, SYS-EXP-04
- **Current Implementation Status:** Damage uses weakness; the player cannot see why
- **Current Problem:** High or low damage is unexplained, and attack tells the player has learned are recorded nowhere.
- **Evidence:** `Runtime/Combat/LockOn.cs`; `Runtime/Player/PlayerBestiary.cs`
- **Proposed Improvement:** After the first hit with an element, the lock-on shows weak or resist. The bestiary entry records per species which attacks were seen, dodged or parried and reveals a tell note.
- **Player Benefit:** Observation pays off; combat is readable.
- **Technical Benefit:** Reuses species and attack data.
- **Gameplay Benefit:** Rewards attention over grinding.
- **Dependencies:** UPG-011 (one knowledge vocabulary); a save field
- **Affected Systems:** Bestiary, lock-on, save
- **Affected Files:** `PlayerBestiary.cs`, bestiary window, `SaveGame.cs`
- **Priority:** P2
- **Complexity:** M
- **Risk:** Save format change; screen clutter.
- **Acceptance Criteria:** A weak-element hit shows a distinct number colour and icon; after parrying an attack the entry lists it; an old save still loads.
- **Testing Requirements:** Save round-trip test; PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-019, IDEA-022
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat U-6, U-7); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-009: A small discovery registry and world objects that write to the journals

- **Existing System:** SYS-EXP-08, SYS-EXP-10, SYS-EXP-12, SYS-EXP-19
- **Current Implementation Status:** Journal rules TESTED and saved; game PARTIAL: nothing in the world writes to them
- **Current Problem:** Both journal pages are unreachable in play. `HearClue`, `VisitRoom`, the archive and discovery calls are made only by tests and the screenshot sandbox. Exploration has no content: the only exploration quest is one reach point.
- **Evidence:** `Runtime/UI/ScreenshotRunner.cs` lines 138 to 151 (the only callers); `Runtime/Player/PlayerMap.cs` (the one wired knowledge system)
- **Proposed Improvement:** One data file of discoveries (id, kind, place, clue text, what it records, reward) and one pickup component that calls the existing journal methods. Four to six hand-placed discoveries in the Whisperwood field, including one chain of two clues. This replaces the 'Curiosity Reward Director' the owner's prompt asks for with the smallest thing that does the job.
- **Player Benefit:** Looking closer finds something, and the journal remembers it.
- **Technical Benefit:** Connects three tested systems to the world with one component.
- **Gameplay Benefit:** Exploration becomes a loop instead of a document.
- **Dependencies:** A new data file and schema (a major change: owner approval); UPG-010
- **Affected Systems:** Discovery journal, archive, dungeon knowledge, map
- **Affected Files:** `Data/World/` (new file), `Data/Schemas/`, `Runtime/World/` (new component), scene builder
- **Priority:** P1
- **Complexity:** M
- **Risk:** Authoring cost per region must be stated before it spreads beyond Whisperwood.
- **Acceptance Criteria:** Each placed discovery, when found in play, appears in the journal and survives save and load; the two-clue chain completes from either end.
- **Testing Requirements:** Core test for the registry rules; PlayMode pickup test; save round-trip.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-003, IDEA-015, IDEA-018
- **Related Tasks:** T-011
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U2); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-010: Journal window: a discoveries page and a quest page

- **Existing System:** SYS-EXP-08, SYS-QST-14
- **Current Implementation Status:** Window IMPLEMENTED with two pages (dungeon clues, archive)
- **Current Problem:** The journal does not show quests or discoveries, the two things a player opens a journal for.
- **Evidence:** `Runtime/UI/JournalWindow.cs`
- **Proposed Improvement:** Add a page listing the discovery journal and a page listing active and finished quests with their outcome.
- **Player Benefit:** One place to see what you know and what you are doing.
- **Technical Benefit:** Uses state that is already saved.
- **Gameplay Benefit:** Makes discoveries legible.
- **Dependencies:** UPG-009 for content
- **Affected Systems:** Journal UI
- **Affected Files:** `Runtime/UI/JournalWindow.cs`
- **Priority:** P1
- **Complexity:** S
- **Risk:** IMGUI placeholder work that a styled UI will replace (UPG-032).
- **Acceptance Criteria:** Both pages list live state in a PlayMode test and in a screenshot.
- **Testing Requirements:** PlayMode window test.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-013, IDEA-014
- **Related Tasks:** T-010
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U3); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-011: One bestiary knowledge vocabulary, research tasks and a route that needs no killing

- **Existing System:** SYS-ECO-10, SYS-EXP-04
- **Current Implementation Status:** Game TESTED for four kill-count tiers
- **Current Problem:** Knowledge comes only from sightings, 3 kills and 10 kills (or taming). The design says no tier should require killing. Three tier vocabularies exist (CD-011).
- **Evidence:** `Code/Ascend.Core/Bestiary.cs` lines 26 to 28 and 83 to 96; `10_World/reactive_world_and_field_journal.md` line 70
- **Proposed Improvement:** Adopt the five named tiers mapped onto the existing thresholds. Add two or three research tasks per Ring 0 and Ring 1 species (watch it feed, find its den, see it at night) that advance a tier without a kill.
- **Player Benefit:** A naturalist can fill the bestiary without a massacre.
- **Technical Benefit:** One vocabulary for code, docs and UI.
- **Gameplay Benefit:** Ties ecology and exploration to progression.
- **Dependencies:** Owner decision CD-011; a save field
- **Affected Systems:** Bestiary, journal, save
- **Affected Files:** `Code/Ascend.Core/Bestiary.cs`, `Data/World/world_tuning.json`, bestiary window
- **Priority:** P1
- **Complexity:** M
- **Risk:** Save change; 21 species × 2 to 3 tasks to author.
- **Acceptance Criteria:** A species reaches the top tier with zero kills; old saves keep their tiers.
- **Testing Requirements:** Core tests; save round-trip.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-003, IDEA-013
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U5); recorded as PROPOSED; not in the actionable backlog until approved. 2026-11-12, orchestrator, after the red-team review (M3): priority changed from P2 to P1 to follow the vertical slice.

### UPG-012: Settle what 'Appraisal' is and give it one hook

- **Existing System:** SYS-EXP-04, SYS-EXP-05
- **Current Implementation Status:** One word, three meanings (CD-012); code has the kill-count tier only
- **Current Problem:** Any appraisal feature would be built on an ambiguity between a character stat, a Unique Skill and the bestiary tier.
- **Evidence:** `12_Systems/hud_and_ui.md` §9; `05_Skills_Magic`; `Runtime/World/MonsterDummy.cs` line 66
- **Proposed Improvement:** For Ring 0, Appraisal means the bestiary tier. Keep the single function that returns the tier and let a skill modify it later. Rename in docs accordingly.
- **Player Benefit:** Consistent wording in the UI.
- **Technical Benefit:** One extension point instead of three designs.
- **Gameplay Benefit:** Leaves room for the Appraisal Eye without building it.
- **Dependencies:** Owner decision CD-012
- **Affected Systems:** Bestiary, UI docs
- **Affected Files:** `12_Systems/hud_and_ui.md`, `Runtime/World/MonsterDummy.cs`
- **Priority:** P2
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** Docs use one definition; one function decides what a label shows.
- **Testing Requirements:** Existing bestiary tests.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-002, IDEA-019, IDEA-025
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U10); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-013: Quest choices that change something, with a receipt

- **Existing System:** SYS-QST-07
- **Current Implementation Status:** Choices are stored and discarded
- **Current Problem:** Ten quests carry a choice objective. Whatever the player picks, every flag is set and the reward is the same.
- **Evidence:** `Runtime/Player/PlayerQuests.cs` line 156; `Data/Quests/quests.json`
- **Proposed Improvement:** Per-option flags and reward deltas in quest data; one receipt line shown at hand-in and kept in the journal.
- **Player Benefit:** Decisions matter and are remembered.
- **Technical Benefit:** Implements the smallest part of the quest outcome grammar.
- **Gameplay Benefit:** Consequences without branching every line.
- **Dependencies:** A schema change and a save field (major: owner approval)
- **Affected Systems:** Quests, journal, save
- **Affected Files:** `Data/Quests/quests.json`, schema, `Code/Ascend.Core/QuestLog.cs`, `PlayerQuests.cs`
- **Priority:** P1
- **Complexity:** M
- **Risk:** Ten quests need their options written out.
- **Acceptance Criteria:** Two different options on one quest set different flags and show different receipts; old saves load.
- **Testing Requirements:** Core tests; PlayMode; save round-trip.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-017
- **Related Tasks:** T-017
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U1); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-014: Every quest completable, or visibly parked

- **Existing System:** SYS-QST-03, SYS-QST-08
- **Current Implementation Status:** 32 quests in data; 19 completable by static analysis
- **Current Problem:** Thirteen quests cannot be finished: eight NPCs they need are not placed, and five need a dungeon scene that does not exist. The scene test checks reach targets and seven givers only.
- **Evidence:** `Game/Assets/_Game/Tests/PlayMode/FieldScenePlayModeTests.cs` lines 44 to 65; `Editor/Ring0SceneBuilder.Npcs.cs`
- **Proposed Improvement:** Extend the scene test to every giver, talk target and reach place. Then place the missing NPCs or mark the quest parked in data so the board never offers it.
- **Player Benefit:** No quest that silently cannot be finished.
- **Technical Benefit:** A test that fails when content and scene drift apart.
- **Gameplay Benefit:** Trust in the board.
- **Dependencies:** Owner choice per quest: park or place
- **Affected Systems:** Quests, scene
- **Affected Files:** Scene test, `Data/Quests/quests.json`, scene builder
- **Priority:** P1
- **Complexity:** S
- **Risk:** Placing NPCs adds dialogue debt.
- **Acceptance Criteria:** The scene test fails for any unparked quest whose giver or target is missing, and passes.
- **Testing Requirements:** PlayMode scene test.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-009
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U4); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-015: Acts and story flags as data

- **Existing System:** SYS-QST-06, SYS-QST-11
- **Current Implementation Status:** Act is 0 or 1 in code; three story flags have no setter
- **Current Problem:** An Act II gate cannot be expressed. Flags marked 'set by story' are never set, so NPC states that depend on them can never show.
- **Evidence:** `Runtime/Player/PlayerQuests.cs` line 85; `Data/Quests/story_flags.json`; `Data/NPCs/npcs.json`
- **Proposed Improvement:** Derive the act from flags in data; give every flag a setter or mark it reserved.
- **Player Benefit:** None yet.
- **Technical Benefit:** Removes a code change from the path to Act II.
- **Gameplay Benefit:** Prerequisite for story progress.
- **Dependencies:** None
- **Affected Systems:** Quests
- **Affected Files:** `PlayerQuests.cs`, `story_flags.json`, validator
- **Priority:** P2
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** The validator fails on a flag with no setter that is not marked reserved; a test moves the act to 2 by data alone.
- **Testing Requirements:** Core test; validator.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-023
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U7); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-016: Tie the Status Window's redacted line to story flags

- **Existing System:** SYS-EXP-06
- **Current Implementation Status:** PROTOTYPE: one hard-coded `Title: [REDACTED]` line
- **Current Problem:** The game's signature idea is present as a string that never changes.
- **Evidence:** `Runtime/UI/RingZeroHud.cs` line 109
- **Proposed Improvement:** Drive the line from a flag so a later act can change it. No corruption stages yet.
- **Player Benefit:** A first hint that the System hides things.
- **Technical Benefit:** The hook the Lying Interface will hang on.
- **Gameplay Benefit:** Costs almost nothing.
- **Dependencies:** Owner decision CD-002 (story flags already exist in the save, so UPG-015 is not needed first)
- **Affected Systems:** HUD
- **Affected Files:** `Runtime/UI/RingZeroHud.cs`
- **Priority:** P1
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** Setting the flag changes the line in a PlayMode test.
- **Testing Requirements:** PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-001
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U6); recorded as PROPOSED; not in the actionable backlog until approved. 2026-11-12, orchestrator, after the red-team review (M3): priority changed from P3 to P1 to follow the vertical slice.

### UPG-017: Guidance setting: quest markers on or off

- **Existing System:** SYS-EXP-17
- **Current Implementation Status:** One conventional channel only
- **Current Problem:** Canon §6 proposes selectable guidance; the game has only markers.
- **Evidence:** `Canon.md` §6 rows 'Diegetic guidance' and 'Guidance channels'
- **Proposed Improvement:** One setting that hides quest markers; essential objectives stay reachable through the journal text.
- **Player Benefit:** Players who want to find things themselves can.
- **Technical Benefit:** First of the guidance channels.
- **Gameplay Benefit:** Supports discovery play.
- **Dependencies:** Accessibility settings window
- **Affected Systems:** HUD, settings
- **Affected Files:** `Runtime/UI/`, `Accessibility.cs`
- **Priority:** P3
- **Complexity:** S
- **Risk:** A quest whose text does not say where to go becomes unfinishable with markers off.
- **Acceptance Criteria:** With markers off no marker draws, and every Ring 0 quest text names its place.
- **Testing Requirements:** PlayMode; a text check on quest data.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-016
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U8); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-018: Liberation delta: the freed region visibly changes

- **Existing System:** SYS-WLD-09, SYS-EXP-18
- **Current Implementation Status:** Liberation IMPLEMENTED and TESTED for Whisperwood
- **Current Problem:** Killing Grukk ends raids and raises prosperity numbers, but the place looks and plays the same.
- **Evidence:** `13_Production/ring0_plan.md` (Liberation row); Canon §6 'Region discovery and liberation delta'
- **Proposed Improvement:** A small fixed set after liberation: a new route or shortcut, a merchant or patrol, a swapped encounter table, one board notice, one ambient cue, and one discovery that only exists afterwards.
- **Player Benefit:** The world answers the player's biggest act.
- **Technical Benefit:** Reuses flags that already exist.
- **Gameplay Benefit:** Gives a reason to walk the region again.
- **Dependencies:** UPG-020 (encounter tables), UPG-009
- **Affected Systems:** Sieges, encounters, exploration
- **Affected Files:** Scene builder, `Data/World/encounters.json`, quest data
- **Priority:** P1
- **Complexity:** M
- **Risk:** Scene changes behind a flag must not break the Ring 0 tests.
- **Acceptance Criteria:** After liberation, each of the listed changes is present in a PlayMode test and absent before.
- **Testing Requirements:** PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-010
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U5, ecology U4); recorded as PROPOSED; not in the actionable backlog until approved. 2026-11-12, orchestrator, after the red-team review (M3): priority changed from P2 to P1 to follow the vertical slice.

### UPG-019: Fix rank-band defects in Whisperwood before anything spawns from data

- **Existing System:** SYS-ECO-04, SYS-ECO-01
- **Current Implementation Status:** Data defect
- **Current Problem:** 167 species-region pairs are above their region's rank band; 18 are in Whisperwood, the only playable region.
- **Evidence:** `08_Bestiary/regional_ecology.md` (Findings); recount in the ecology audit
- **Proposed Improvement:** For Whisperwood first: per pair, widen the band, drop the habitat, or mark it 'rare, deep only'. The same rule then runs over the other regions as a data pass.
- **Player Benefit:** No rank-C monster in the starter wood by accident.
- **Technical Benefit:** Encounter tables can be trusted as a spawn source.
- **Gameplay Benefit:** Keeps the F-to-E curve intact.
- **Dependencies:** Owner picks the rule (widen, drop or mark)
- **Affected Systems:** Bestiary, encounters
- **Affected Files:** `Tools/monster_gen/` inputs, `Data/Monsters/species.json` (generated)
- **Priority:** P1
- **Complexity:** S
- **Risk:** Generated data: change the generator inputs, not the JSON.
- **Acceptance Criteria:** The ecology check reports zero over-band pairs for Whisperwood; `npm run build` passes.
- **Testing Requirements:** `npm run build` (cloud).
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-008
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U3); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-020: Spawn the field from `encounters.json`

- **Existing System:** SYS-WLD-12, SYS-ECO-05
- **Current Implementation Status:** Data validated; no game code reads it
- **Current Problem:** Monsters are hand-placed by the scene builder. The finished regional encounter tables, and the 6,754 population rows, are read by nothing.
- **Evidence:** `Editor/Ring0SceneBuilder.cs` lines 213 to 221; `Data/World/encounters.json`
- **Proposed Improvement:** A Core reader and a spawner that fills the Whisperwood camps from the table by zone and time of day, behind a flag, keeping today's hand placement as the default until tested.
- **Player Benefit:** The wood changes between day and night and between visits.
- **Technical Benefit:** Content scales by data instead of by scene edits.
- **Gameplay Benefit:** The route to every later region.
- **Dependencies:** UPG-019
- **Affected Systems:** Encounters, spawning, scene
- **Affected Files:** `Code/Ascend.Core` (new reader), `Runtime/World/` spawner, scene builder
- **Priority:** P1
- **Complexity:** M
- **Risk:** Per-frame cost of spawning; the Ring 0 tests assume fixed camps.
- **Acceptance Criteria:** With the flag on, camps spawn only species listed for their zone and time; with it off, the scene is unchanged (screenshot compare).
- **Testing Requirements:** Core tests for selection; PlayMode with the flag on and off.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-004, IDEA-006
- **Related Tasks:** T-018, T-016
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U4); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-021: A small ecology layer: role tags and a four-state region cycle

- **Existing System:** SYS-ECO-06, SYS-ECO-08
- **Current Implementation Status:** DOCUMENTED; 0 of 680 species have any relationship data; nothing models populations
- **Current Problem:** The bestiary is a list. There is no predator, prey, diet or relationship field anywhere in the data, and no region state for creatures. The owner's ecology prompt asks for a 15-system network and assumes simulation levels that do not exist (CD-006).
- **Evidence:** Key listing of `Data/Monsters/species.json` and `population.json` in the ecology audit; `Code/Ascend.Core/LivingWorld.cs`
- **Proposed Improvement:** Generate per species a role tag, a diet class and a short relationship list from existing fields. Give each region one of four states saved as a few integers. Three rungs of cost: near the player real, the region as numbers, far away nothing. Every value floors at a recovery minimum (CD-007).
- **Player Benefit:** The world has cause and effect: thin out the wolves and the deer show up.
- **Technical Benefit:** Cheap: tags are generated, state is a handful of integers per region.
- **Gameplay Benefit:** Ecology that feeds encounters, clues and prices instead of a parallel simulation.
- **Dependencies:** Owner decisions CD-008 and CD-014 and the 2027 ecology scope; UPG-020; new data fields (major change)
- **Affected Systems:** Bestiary, encounters, living world, save
- **Affected Files:** `Tools/monster_gen/`, `Data/World/regions.json` or a new file, `Code/Ascend.Core/LivingWorld.cs`
- **Priority:** P2
- **Complexity:** L
- **Risk:** Scope: this is the entry most likely to grow. Keep it to Ring 1 species first.
- **Acceptance Criteria:** Every Ring 0 and Ring 1 species has a role and at least one relationship; a region's state changes the encounter table it uses; no state can reach zero permanently.
- **Testing Requirements:** Core tests for the cycle and the floor; generator determinism; save round-trip.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-003, IDEA-004, IDEA-005, IDEA-010
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U1, U2, U8); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-022: Apply living-world event effects, rumours first

- **Existing System:** SYS-WLD-10, SYS-EXP-13
- **Current Implementation Status:** Rules TESTED; game PARTIAL: events advance and save, no effect is applied
- **Current Problem:** The event director rolls caravans and wanderers each in-game day and the result changes nothing the player can see. NPC schedules are unused; NPCs stand still.
- **Evidence:** `Runtime/Player/PlayerWorldState.cs` line 273 and lines 148 to 157
- **Proposed Improvement:** Apply one effect kind first: a rumour line at the guild board. Then stock changes at one shop. Add two authored ecological events as pool rows once UPG-021 exists.
- **Player Benefit:** The town feels alive between visits.
- **Technical Benefit:** Uses state that is already computed and saved.
- **Gameplay Benefit:** Hooks for quests and discoveries.
- **Dependencies:** None for the rumour
- **Affected Systems:** Living world, board, shops
- **Affected Files:** `Runtime/World/QuestBoard.cs`, `PlayerWorldState.cs`
- **Priority:** P2
- **Complexity:** S
- **Risk:** Low.
- **Acceptance Criteria:** An active event shows its rumour on the board in a PlayMode test and disappears when it ends.
- **Testing Requirements:** PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-004
- **Related Tasks:** T-019
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U7, exploration U9); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-023: Three ambient monster behaviours outside combat

- **Existing System:** SYS-ECO-09
- **Current Implementation Status:** Monster brain has combat states only
- **Current Problem:** Monsters wait in place until a fight. Nothing feeds, rests or sleeps, so there is nothing to observe.
- **Evidence:** `Code/Ascend.Core/MonsterAi.cs` (state list)
- **Proposed Improvement:** Add feed, rest and sleep-by-time-of-day as idle states for the Ring 0 and Ring 1 species, driven by the existing behaviour and spawn fields.
- **Player Benefit:** Creatures can be watched, approached asleep, or found at a food source.
- **Technical Benefit:** Small extension of a tested state machine.
- **Gameplay Benefit:** Makes research tasks (UPG-011) possible.
- **Dependencies:** UPG-002 first (same file, one owner per wave)
- **Affected Systems:** Monster AI
- **Affected Files:** `Code/Ascend.Core/MonsterAi.cs`, `MonsterController.cs`
- **Priority:** P3
- **Complexity:** M
- **Risk:** Procedural animation must sell the states without authored clips.
- **Acceptance Criteria:** A grazer feeds by day and sleeps at night in a PlayMode test; combat behaviour is unchanged.
- **Testing Requirements:** Core and PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-003, IDEA-005
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U6); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-024: Creature art: only the next ring, and a safe home for the files

- **Existing System:** SYS-ECO-13, SYS-TEC-08
- **Current Implementation Status:** 3 creature models in git; every other species is a capsule unless local files exist on the PC
- **Current Problem:** Three documents describe three different model routes (CD-035). 677 blockout models exist only on one PC. No baked, budgeted creature has gone from Blender into the shipping scene.
- **Evidence:** `Art/Generation/monster_models.json`; `13_Production/monster_model_pipeline.md`; `creature_system.md`; `.gitignore`
- **Proposed Improvement:** Choose one route. Run one Ring 1 creature through generate, bake to budget, import, place, and record the steps. Then do the 21 Ring 0 and Ring 1 species and nothing else. Back up the local folders.
- **Player Benefit:** The first wood is full of creatures, not capsules.
- **Technical Benefit:** A proven pipeline before 680 runs of it.
- **Gameplay Benefit:** The slice can be shown to someone.
- **Dependencies:** Owner picks the route; PC and GPU time
- **Affected Systems:** Art pipeline, scene
- **Affected Files:** `Tools/blender/`, `13_Production/monster_model_pipeline.md`
- **Priority:** P1
- **Complexity:** M
- **Risk:** GPU hours; style consistency.
- **Acceptance Criteria:** One creature in the Ring 0 scene meets its triangle and material budget and passes the director's review; the route is written on one page.
- **Testing Requirements:** `art_budgets.md` check; screenshot review.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-015
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology U9); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-025: Report data that nothing reads; make CI see untracked generated files

- **Existing System:** SYS-CORE-02, SYS-TEC-01
- **Current Implementation Status:** Validator passes; several data files and keys have no consumer
- **Current Problem:** Dead data looks tunable (R24). A generated schema sat uncommitted because the CI check uses `git diff`.
- **Evidence:** Combat audit P-3, P-5, P-8; `ci.yml` last step; `Data/Schemas/encounters.schema.json`
- **Proposed Improvement:** A validator report listing each data file and whether Core or Runtime references it, with an allow-list of files marked 'reserved'. Change the CI step to fail on untracked files under `Data/`.
- **Player Benefit:** None directly.
- **Technical Benefit:** Stops tuning of no-ops; keeps generated files honest.
- **Gameplay Benefit:** -
- **Dependencies:** None
- **Affected Systems:** Tools
- **Affected Files:** `Tools/validate/`, `.github/workflows/ci.yml`
- **Priority:** P2
- **Complexity:** S
- **Risk:** False positives from reflection-style loading.
- **Acceptance Criteria:** The report lists `weapon_movesets.json`, `population.json` and `encounters.json` as unread today; CI fails when a generated file is untracked.
- **Testing Requirements:** `npm run build` (cloud).
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-013
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-026: A recorded PC verify run every week

- **Existing System:** SYS-TEC-04, SYS-TEC-05, SYS-TEC-03
- **Current Implementation Status:** Last recorded PlayMode run 2026-11-08; two merge batches since; logs are gitignored
- **Current Problem:** Unity is outside CI, and no run leaves a record in the repo. The current state of compile and PlayMode is unknown.
- **Evidence:** `13_Production/progress_log.md`; `Tools/pc/update_and_verify.cmd`; `.gitignore` (Logs)
- **Proposed Improvement:** Run the verify script on current `main` plus this branch. After every run, add one row to `QUALITY_GATES.md` §3 (date, commit, counts, pass or fail). One slot a week.
- **Player Benefit:** A build that is known to start.
- **Technical Benefit:** A baseline every Unity task can cite.
- **Gameplay Benefit:** -
- **Dependencies:** Owner's PC
- **Affected Systems:** All Unity work
- **Affected Files:** `Planning/QUALITY_GATES.md`
- **Priority:** P0
- **Complexity:** S
- **Risk:** The run may fail; then fixing it is the next task.
- **Acceptance Criteria:** For the current `main`: the pull step succeeded, the hash is recorded, Core passes, PlayMode has 0 failures and no fewer passes than the last baseline. A red run is recorded as Failed and does not satisfy this entry.
- **Testing Requirements:** The run itself.
- **Status:** APPROVED
- **Related Ideas:** -
- **Related Tasks:** T-001
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit; already step 0 of the dependency map); approved by the orchestrator because it is already part of the owner-accepted roadmap.

### UPG-027: First performance measurement, then the known allocation fixes

- **Existing System:** SYS-TEC-10
- **Current Implementation Status:** No measurement exists; six per-frame allocation sites are known
- **Current Problem:** The 60 fps target and the art budgets are asserted. TD-01 to TD-06 are open and unmeasured.
- **Evidence:** `13_Production/perf_review_core_2026-11-08.md`; `tech_debt_register.md`
- **Proposed Improvement:** One Unity Profiler capture in the Ring 0 field with the goblin pack fighting. Record frame time, allocations per frame and draw calls. Fix TD-01 to TD-04 only if the capture shows them.
- **Player Benefit:** Smooth fights.
- **Technical Benefit:** Optimisation by evidence.
- **Gameplay Benefit:** -
- **Dependencies:** Owner's PC; UPG-026
- **Affected Systems:** Runtime, Core
- **Affected Files:** `13_Production/` (a perf note), `Code/Ascend.Core/MonsterAi.cs`, `Loot.cs`
- **Priority:** P1
- **Complexity:** S
- **Risk:** Rewrites of the AI choice code must keep the random draw order (TD-03).
- **Acceptance Criteria:** A committed note with the three numbers; any fix shows a before and after from the same scene.
- **Testing Requirements:** Profiler capture; Core tests unchanged.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-012, T-014
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit; TD-01 to TD-06); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-028: Save version rule and product identity

- **Existing System:** SYS-CORE-03, SYS-TEC-06
- **Current Implementation Status:** Save rules TESTED; version constant still 1; product 'Game', company 'DefaultCompany'
- **Current Problem:** There is no version step to attach a real migration to, and the save folder depends on names that will change (R19).
- **Evidence:** `Code/Ascend.Core/SaveGame.cs` line 14; `Game/ProjectSettings/ProjectSettings.asset` lines 15 to 16
- **Proposed Improvement:** Write the rule (bump on any field whose default is not safe; one old-save test per bump). Decide product, company and executable names once; add the path migration the rename report describes.
- **Player Benefit:** Saves survive updates and the rename.
- **Technical Benefit:** One rule instead of case-by-case.
- **Gameplay Benefit:** -
- **Dependencies:** Owner decides the names
- **Affected Systems:** Save, build
- **Affected Files:** `SaveGame.cs`, `PlayerSave.cs`, `ProjectSettings.asset`, `BuildPlayer.cs`
- **Priority:** P1
- **Complexity:** S
- **Risk:** Never touch the player's real save in tests.
- **Acceptance Criteria:** A save written before the change loads after it, from the old folder.
- **Testing Requirements:** Core migration tests; PlayMode with a temp folder.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-022
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit; `aethwyrd_migration_report.md`); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-029: Documentation drift sweep

- **Existing System:** SYS-TEC-11 and docs across the repo
- **Current Implementation Status:** 18 documentation rows open in `CANON_DISCREPANCIES.md` part B
- **Current Problem:** Stale counts, a stale handover, charters that describe data that is elsewhere.
- **Evidence:** `CANON_DISCREPANCIES.md` CD-021 to CD-039
- **Proposed Improvement:** Fix each row in its owner's file; no rule changes.
- **Player Benefit:** -
- **Technical Benefit:** New sessions start from true statements.
- **Gameplay Benefit:** -
- **Dependencies:** None
- **Affected Systems:** Docs
- **Affected Files:** Listed per row
- **Priority:** P2
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** Every part B row is RESOLVED or has an owner decision pending.
- **Testing Requirements:** `documentation-auditor` re-check.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-020
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: all audits); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-030: Sound in the game: play the Ring 0 cue sheet

- **Existing System:** SYS-CORE-08
- **Current Implementation Status:** Rules TESTED; game NOT WIRED; no audio assets
- **Current Problem:** The game is silent apart from placeholder combat cues.
- **Evidence:** `Runtime/Combat/CombatFx.cs` (the only `AudioSource`); `13_Production/audio_music_cue_sheet.md`, `audio_source_shortlist.md`
- **Proposed Improvement:** Connect the music state machine to real playback and add the first SFX set, once sources are licensed.
- **Player Benefit:** Hits, music and the world can be heard.
- **Technical Benefit:** -
- **Gameplay Benefit:** Combat feel depends on sound.
- **Dependencies:** Owner: audio sources and licences; `third_party_assets.md` entries
- **Affected Systems:** Audio
- **Affected Files:** `Game/Assets/_Game/Runtime/Audio/`, plus an asset folder to be created
- **Priority:** P2
- **Complexity:** M
- **Risk:** Licence slip (R10).
- **Acceptance Criteria:** The Ring 0 states each play a track and cross-fade; every file is in the asset register.
- **Testing Requirements:** PlayMode state test; a listening pass.
- **Status:** BLOCKED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit; roadmap M3); recorded as BLOCKED: it waits on the owner.

### UPG-031: A player character in the game

- **Existing System:** SYS-CMB-01, SYS-EXP-01 (the player's body and animation; the character model has no inventory row of its own)
- **Current Implementation Status:** A capsule stands in
- **Current Problem:** No character model. Humanoid animation, foot IK and every picture of the game are waiting on it (R28).
- **Evidence:** `13_Production/ring0_plan.md` week 3; dependency map item H
- **Proposed Improvement:** The owner exports a VRM, or approves the humans-base route; then import, toon materials, retarget.
- **Player Benefit:** You are someone.
- **Technical Benefit:** Unblocks the humanoid animation path and its tests.
- **Gameplay Benefit:** -
- **Dependencies:** Owner
- **Affected Systems:** Character, animation
- **Affected Files:** `Game/Assets/_Game/Art/`
- **Priority:** P1
- **Complexity:** M
- **Risk:** -
- **Acceptance Criteria:** The character runs, fights and is lit by the toon shader in the Ring 0 scene; animation tests pass.
- **Testing Requirements:** PlayMode animation tests.
- **Status:** BLOCKED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: roadmap M1 and M3); recorded as BLOCKED: it waits on the owner.

### UPG-032: Choose the shipping UI technology before polishing any screen

- **Existing System:** SYS-CORE-06
- **Current Implementation Status:** IMGUI placeholders
- **Current Problem:** Every window is drawn with IMGUI, which will not ship. Each new window adds to what must be rebuilt.
- **Evidence:** `Runtime/UI/` (SystemWindow 646 lines, WorldMapWindow 581, RingZeroHud 555); TD-11, TD-12
- **Proposed Improvement:** A written decision between UI Toolkit and UGUI with one screen rebuilt as proof, then a rule: no new IMGUI windows beyond debug.
- **Player Benefit:** The 'System window' look the game is named for.
- **Technical Benefit:** Stops growing throwaway UI.
- **Gameplay Benefit:** -
- **Dependencies:** `ux-designer` specs; engine reference notes
- **Affected Systems:** UI
- **Affected Files:** `13_Production/` (decision record), `Runtime/UI/`
- **Priority:** P2
- **Complexity:** M
- **Risk:** Unity 6 UI knowledge must be checked against `docs/engine-reference/unity/`.
- **Acceptance Criteria:** A decision record exists and the Status Window is rebuilt in the chosen technology.
- **Testing Requirements:** PlayMode window tests; screenshot review.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-033: Quest board guard and a banter trace

- **Existing System:** SYS-QST-04, SYS-QST-13
- **Current Implementation Status:** Board TESTED; banter path UNCERTAIN
- **Current Problem:** The board's 'playable' guard is always true. Whether the 108 banter lines are ever spoken was not established.
- **Evidence:** `Code/Ascend.Core/WeeklyBoard.cs` line 40; `Runtime/World/CompanionAI.cs` line 249
- **Proposed Improvement:** Make the guard check that a job's targets exist; trace banter from data to speech and add a coverage test.
- **Player Benefit:** The board never offers a job that cannot be done; Lyra speaks her lines.
- **Technical Benefit:** Removes two unknowns.
- **Gameplay Benefit:** -
- **Dependencies:** UPG-014
- **Affected Systems:** Board, companions
- **Affected Files:** `WeeklyBoard.cs`, `CompanionAI.cs`
- **Priority:** P3
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** A board job with a missing target is not offered; a test triggers one line per banter trigger kind.
- **Testing Requirements:** Core and PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-011
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration U11, U12); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-034: Decide the class line-up for Ring 0 and the slice, and say it in the docs

- **Existing System:** SYS-PRG-04, SYS-CMB-14
- **Current Implementation Status:** 12 base classes in data and Core tests; one playable; 24 advanced and 48 expert classes have no data
- **Current Problem:** The class field defaults to Swordsman in the scene; there is no class choice. Canon progression is class-based, so this is the widest gap between the documents and the game.
- **Evidence:** `Runtime/Combat/PlayerCombat.cs` line 24; `Ring0_Graybox.unity`; `Data/Classes/classes.json`
- **Proposed Improvement:** Either lock Ring 0 to Swordsman in writing, or add a pre-game choice that writes the class to the save. For the slice, at most a second class, and only after UPG-004.
- **Player Benefit:** An honest promise now; a real choice later.
- **Technical Benefit:** Avoids shipping eleven untested kits.
- **Gameplay Benefit:** -
- **Dependencies:** Owner decision; UPG-004 for any caster
- **Affected Systems:** Classes, save
- **Affected Files:** `PlayerCombat.cs`, save, `ring0_plan.md`
- **Priority:** P1
- **Complexity:** S to M
- **Risk:** Kit quality is first-pass for eleven classes.
- **Acceptance Criteria:** The Ring 0 documents state the line-up; if a selector exists, a new game with each offered class runs its basic chain and one skill.
- **Testing Requirements:** A smoke loop over the offered class ids.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression U2, combat SYS-CMB-14); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-035: Respec and point allocation

- **Existing System:** SYS-PRG-13, SYS-PRG-01
- **Current Implementation Status:** Loss rules TESTED; respec has no code; no allocation UI
- **Current Problem:** Canon §5 promises respec; nothing implements it.
- **Evidence:** grep for respec in `Code/Ascend.Core` (none); `Canon.md` §5
- **Proposed Improvement:** Respec rules as data, one Core method, a simple UI.
- **Player Benefit:** Mistakes in a long build are recoverable.
- **Technical Benefit:** -
- **Gameplay Benefit:** Protects a 1,000-hour save.
- **Dependencies:** None
- **Affected Systems:** Progression
- **Affected Files:** `Code/Ascend.Core/Player.cs`, `progression.json`
- **Priority:** P2
- **Complexity:** M
- **Risk:** None.
- **Acceptance Criteria:** Respec restores points and never touches level or XP.
- **Testing Requirements:** Core tests.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression U3); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-036: An economy sink plan before housing and farming open

- **Existing System:** SYS-ECN-12
- **Current Implementation Status:** Only shop and inn sinks exist in the game
- **Current Problem:** Most documented sinks are unbuilt. No exploit was found (buy prices exceed sell values everywhere), but faucets will outrun sinks once farming is reachable, and the loot faucet has not been sampled.
- **Evidence:** `12_Systems/systems.md` sink list; progression audit §3
- **Proposed Improvement:** A one-page sink and faucet table with numbers sampled from loot tables, then one or two sinks as data.
- **Player Benefit:** Money keeps meaning.
- **Technical Benefit:** Balance by measurement.
- **Gameplay Benefit:** -
- **Dependencies:** None
- **Affected Systems:** Economy
- **Affected Files:** `12_Systems/systems.md`, `Data/Items/`
- **Priority:** P3
- **Complexity:** M
- **Risk:** None.
- **Acceptance Criteria:** A table of copper in and out per hour of Ring 0 play, from data.
- **Testing Requirements:** A script over the loot tables; Core tests.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-026
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression U5); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-037: Reach one rules-only system from a Ring 0 station

- **Existing System:** SYS-ECN-08, SYS-ECN-09, SYS-ECN-10
- **Current Implementation Status:** Meal buffs, runes and enchanting, housing and farming: rules TESTED and saved; no UI or call site
- **Current Problem:** Four finished rule sets cannot be reached by the player.
- **Evidence:** grep in the progression audit (no plant, harvest, socket or enchant call in Runtime)
- **Proposed Improvement:** Pick one (meal buffs at the campfire is the smallest) and wire it. The others stay parked until after the slice gate.
- **Player Benefit:** Cooking does something.
- **Technical Benefit:** Proves the Phase 1 pattern on one more system.
- **Gameplay Benefit:** -
- **Dependencies:** Owner picks which
- **Affected Systems:** Crafting, combat stats
- **Affected Files:** `Runtime/Player/PlayerCrafting.cs`, `PlayerCombat.cs`
- **Priority:** P3
- **Complexity:** M
- **Risk:** Each wired system is one more thing to keep working.
- **Acceptance Criteria:** Eating a crafted meal changes a stat for its duration in a PlayMode test.
- **Testing Requirements:** PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression U6); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-038: Dialogue as data

- **Existing System:** SYS-QST-09, SYS-QST-08
- **Current Implementation Status:** Talk window TESTED; an NPC's dialogue is one role line plus canned replies
- **Current Problem:** There is no dialogue data and no branching. Twelve NPCs are placed; NPC state variants are never shown. Canon asks for about 2,500 named NPCs (R27).
- **Evidence:** `Runtime/UI/NpcDialog.cs` line 44; `Data/NPCs/npcs.json`
- **Proposed Improvement:** Choose a small dialogue data format (lines keyed by NPC, state and flag), write it for the Ring 0 cast, and show state variants.
- **Player Benefit:** People in Brindlewick say things.
- **Technical Benefit:** A format before more text is written.
- **Gameplay Benefit:** Carrier for clues, rumours and receipts.
- **Dependencies:** A new data file and schema (major change)
- **Affected Systems:** NPCs, quests
- **Affected Files:** `Data/NPCs/`, `NpcDialog.cs`
- **Priority:** P2
- **Complexity:** M
- **Risk:** Writing volume.
- **Acceptance Criteria:** Each placed NPC has at least a greeting, one state variant and one line that reacts to a flag.
- **Testing Requirements:** Validator; PlayMode.
- **Status:** PROPOSED
- **Related Ideas:** IDEA-011, IDEA-017
- **Related Tasks:** -
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration audit SYS-QST-09); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-039: Write the architecture decisions down

- **Existing System:** SYS-CORE-01
- **Current Implementation Status:** Layer rule followed in practice; nothing recorded
- **Current Problem:** The layer rule, the save version rule, the UI technology, scene and streaming plan are implicit. The studio layer expects decision records and finds none.
- **Evidence:** `13_Production/project-stage-report.md` (no ADRs)
- **Proposed Improvement:** Four short decision records: rules layer and Unity layer; save versioning; UI technology (with UPG-032); scenes and streaming for more than one region.
- **Player Benefit:** -
- **Technical Benefit:** New agents stop re-deriving the architecture.
- **Gameplay Benefit:** -
- **Dependencies:** `technical-director`
- **Affected Systems:** Architecture
- **Affected Files:** `13_Production/` or `docs/architecture/` (ask the owner before creating the folder)
- **Priority:** P2
- **Complexity:** S
- **Risk:** None.
- **Acceptance Criteria:** Four records exist, each with context, decision, alternatives and consequences.
- **Testing Requirements:** Review by the `red-team-reviewer`.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-021
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: technical audit); recorded as PROPOSED; not in the actionable backlog until approved.

### UPG-040: Kill credit when a companion or partner lands the last hit

- **Existing System:** SYS-CMB-26, SYS-CMP-04, SYS-CMP-07
- **Current Implementation Status:** Companion and partner combat IMPLEMENTED; the kill event is raised only by the player's own hits
- **Current Problem:** If Lyra or a tamed partner lands the killing blow, the player gets no XP, no loot, no quest kill and no bestiary tick. If that blow lands on Grukk, Whisperwood is not liberated, and a Tyrant does not respawn, so the Ring 0 trial and the liberation can be lost. Found by the red-team review by reading the code; **not reproduced in Unity**.
- **Evidence:** `Runtime/Combat/PlayerCombat.Progress.cs` lines 24 and 70 (the only place `Killed` is raised); `Runtime/World/CompanionAI.cs` line 203 and `Runtime/World/PartnerFollower.cs` line 125 (call `TakeHit` directly); subscribers in `SiegeDirector.cs` line 64, `PlayerBestiary.cs` line 26, `PlayerInventory.cs` line 43; `MonsterDummy.cs` line 204 (`Defeat` raises nothing)
- **Proposed Improvement:** Raise a defeated event from the monster itself, carrying who struck, and move the subscribers onto it. Decide in data how much credit an ally's kill gives (recommended: full credit).
- **Player Benefit:** Fighting beside a partner never costs you the reward, or the story.
- **Technical Benefit:** One source of truth for a death.
- **Gameplay Benefit:** Removes a way to soft-lock the first region's main goal.
- **Dependencies:** A Unity slot (T-001 first)
- **Affected Systems:** Combat, companions, partners, quests, bestiary, loot, sieges
- **Affected Files:** `Runtime/World/MonsterDummy.cs`, `PlayerCombat.Progress.cs`, `SiegeDirector.cs`, `PlayerBestiary.cs`, `PlayerInventory.cs`, `PlayerQuests.cs`, a new PlayMode test
- **Priority:** P0
- **Complexity:** S
- **Risk:** Double credit if both paths fire; XP balance if allies kill often.
- **Acceptance Criteria:** In a PlayMode test a companion lands the last hit on Grukk and liberation, XP, loot, quest credit and the bestiary tick all happen exactly once.
- **Testing Requirements:** New PlayMode test; first reproduce the defect on the current build.
- **Status:** PROPOSED
- **Related Ideas:** -
- **Related Tasks:** T-024
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the red-team review of the planning system (finding B1); the orchestrator re-read the cited lines and confirms the code path, for partners as well as companions. Recorded as PROPOSED; recommended as the first Unity task after the verify run.
