# Audit 2026-11-12: Exploration, Discovery, Quests, NPCs and Narrative

AGENT: exploration-designer (with quest-designer knowledge)
MODEL TIER: sonnet
ASSIGNED TASK: read-only audit of exploration (SYS-EXP-) and quests/NPCs/narrative (SYS-QST-) as built, plus triage of the owner's AETHWYRD_3.docx (in full) and the exploration/quest/NPC parts of AETHWYRD.odt.
FILES MODIFIED: this report only.
Not run: `npm run build`, Unity, any test. Test counts below are counted by grep of test files, not by running them. Unity PlayMode last recorded result is 183 passed on 2026-11-08 (progress_log.md), not re-run.

FILES INSPECTED (key ones)
- Canon.md (§2, §6 rows 97-147, 153, 190-212), CLAUDE.md, .claude/agents/exploration-designer.md
- 01_Core_Concept/the_big_upgrade.md (§1, §2), 12_Systems/hud_and_ui.md (§9, §12, §13), 10_World/exploration_and_discovery.md, 10_World/reactive_world_and_field_journal.md, 11_Quests_Encounters/ring0_quest_expansion.md, quest_outcome_grammar.md, 02_Lore/story.md, 13_Production/living_world_v4_audit.md, archive_v7b_audit.md, dungeon_v7_audit.md, progress_log.md
- Data/Quests/quests.json, weekly_board.json, story_flags.json; Data/NPCs/npcs.json; Data/World/living_world.json, civilization_archive.json, puzzles.json, gathering.json, dungeons.json, clans.json; Data/Companions/banter.json
- Code/Ascend.Core: Bestiary, QuestLog, Quests, WeeklyBoard, LivingWorld, Puzzles, Locomotion (headers/greps), test file list and per-file test counts
- Game/Assets/_Game/Runtime: UI/JournalWindow.cs, UI/RingZeroHud.cs, UI/NpcDialog.cs, Player/PlayerBestiary.cs, PlayerQuests.cs, PlayerWorldState.cs, PlayerMap.cs, World/MonsterDummy.cs, QuestGiver/QuestBoard/EscortNpc/DefenceSpot/GatherNode/Waystone; Editor/Ring0SceneBuilder.Npcs.cs; Tests/PlayMode/QuestPlayModeTests.cs, FieldScenePlayModeTests.cs, ProgressAndHudPlayModeTests.cs, Phase1World/WindowsPlayModeTests.cs
- Proposals: .../scratchpad/docs/AETHWYRD_3.docx.txt (full), AETHWYRD.odt.txt (full read)

## Headline answers to the four questions

1. **Appraisal beyond kill-count bestiary tiers: none exists in code.** VERIFIED FACT. `MonsterDummy.AppraisalTier` (World/MonsterDummy.cs:66) is a `Func<string,int>` wired to `Bestiary.Tier` (Player/PlayerBestiary.cs:27). The "appraisal level" is derived only from sightings, kills (3 and 10) and taming (Core/Bestiary.cs:9-13, 30-45). There is no Appraisal skill, no people appraisal, no item appraisal, no "???" unidentified items, no detective flicker. Appraisal appears in Data only as a tuning note (world_tuning.json:75) and one quest summary string (quests.json:185).
2. **Lying Interface: exists in code as one hard-coded string.** VERIFIED FACT. `RingZeroHud.StatusLines()` adds `"Title: [REDACTED]"` (RingZeroHud.cs:109) and a test asserts it (ProgressAndHudPlayModeTests.cs:145). Corruption stages 0-4 (hud_and_ui.md §13), "recommended" quest lies, gold bleed, danger rounding and flicker on people exist only as docs and three audio event names (audio_sfx_event_list.md:140). The line is not tied to any flag or act.
3. **What the in-game journal records.** VERIFIED FACT. `JournalWindow` (F4) has two pages: dungeon clues (Unknown/Heard/Visited per clue and room) and the Civilization Archive. It does NOT show quests, the DiscoveryJournal (creature/landmark/region/secret), field-journal evidence, hypotheses or confidence tiers. Worse, nothing in the running game feeds either page: `HearClue`, `VisitRoom`, `Archive.Hear`, `Excavate`, `Journal.Visit` are called only from `ScreenshotRunner.cs` (screenshot sandbox, lines 138-151) and tests. Only region map knowledge is wired (PlayerMap.cs:47, 84, 90, 113: Visited on arrival, Heard on quest accept). So in a played Ring 0 session both journal pages stay empty.
4. **Quests completable in the Unity build: 19 of 32 by static analysis (REASONED CONCLUSION, not run).** I matched every giver, talk target, reach place and defend spot against what `Ring0SceneBuilder.Npcs.cs` places (13 NPC ids incl. board clerk Wendel, 13 place ids, 2 defence spots, 1 escort, 1 siege director). 13 cannot be completed: giver or talk target never placed (Brother Caspian, Tamsin, Old Hollis, Brutus Kale, Guard Tomlin, Sister Pell, Ines Valbuena, Examiner Garrick), and all 5 Salvage Warren dungeon quests plus the Lyra arc quest 1 (needs Hollis). The 19 includes the siege defence quest, whose `{settlement}` target is handled by the siege director (FieldScenePlayModeTests.cs:55). Weekly board: 37 of 45 board quests pass the same static check; 8 depend on unplaced NPCs, the dungeon or "North Gate" (the latter is handled by the live raid). Note `WeeklyQuestData.Playable` (Core/WeeklyBoard.cs:40) is `Objectives.All(o => o.Kind != null)`, so it filters nothing real.
5. **How much of Acts I-VI exists as quest data.** Prologue plus roughly Act I beats 1-7 (registration, first contracts, Lyra, red-eyed hobgoblin raid, Smiling Scarecrow, nine thrones mural, Goblin Chief trial). Beats 8 (report the runes), 9 (Rank E ceremony as a story scene) and 10 (Kiri or Aldric recruitment) have no quest data. Acts II-VI: zero quests. VERIFIED FACT: `prerequisites.act` values in quests.json are only 0 (1 quest), 1 (13 quests) or absent (18). `PlayerQuests.Act` returns only 0 or 1 (PlayerQuests.cs:85). `story_flags.json` has 19 flags; the story's own examples (`runes_reported_to`, `elira_fate`, `traitor_identity`, `vexmor_fate`, `generals_redeemed`, `allegiance`, story.md:115-125) are not in it, and 3 of the 19 (`act3_nocturne_replaces_mina`, `nocturne_unmasked`, `caspian_unmasked`) say `setBy: "story"` with no code or quest that sets them.

## 1. System table

Status words per brief. "Core" = Code/Ascend.Core(+Tests); "Game" = Unity runtime.

| System ID | System | Description | Core status | In-game status | Source files (evidence) | Depends on | Known issues | Next action | Priority |
|---|---|---|---|---|---|---|---|---|---|
| SYS-EXP-01 | Traversal: walk/run/sprint/jump/dodge | Ring 0 movement | n/a | IMPLEMENTED, TESTED (PlayerPlayModeTests) | Player/PlayerMotor.cs:7 | Locomotion.json | Docs promise climbing, swimming, gliding; none exist | Keep out of Ring 0 | P4 |
| SYS-EXP-02 | Climb / glide / swim | Promised in exploration_and_discovery.md prototype section; dungeon_v7_audit lists them as deferred | none | DOCUMENTED | dungeon_v7_audit.md:66 | Level geometry | Docs say "test climbing duration" with no climbing | Decide if Ring 0 needs any | P4 |
| SYS-EXP-03 | Ground mounts | Mounts table, 15 Core tests | Core TESTED | PARTIAL: only a list in CompanionWindow.cs:84-94; no riding | Core/Mounts.cs, MountTests.cs | Stables, Taming | Banter has 11 "mounted" lines with no mounted state | Defer past Ring 0 | P3 |
| SYS-EXP-04 | Appraisal (monster tiers) | Tier 0-3 labels from kills | Core TESTED (4 tests) | IMPLEMENTED, TESTED (BestiaryPlayModeTests, 2) | Bestiary.cs, PlayerBestiary.cs, MonsterDummy.cs:66-78 | Bestiary | Tiers come from kills, not from an Appraisal level; tier 3 "attacks, drops, lore" shown only in window | Rename in docs; see Problem 1 | P1 |
| SYS-EXP-05 | Appraisal (people, items, detective) | hud_and_ui §9 people tiers, big_upgrade §2 flicker, "???" items | none | DOCUMENTED (DESIGNED for Mina/Caspian/Whiskers examples only) | the_big_upgrade.md:19-27; hud_and_ui.md:123-131, 155 | Appraisal skill, NPC states | No Appraisal stat or skill in Data/Classes; NpcState exists (2 NPCs) as the only hook | Design one stat and one flicker for Ring 0 or defer | P2 |
| SYS-EXP-06 | Lying Interface | Status Window that lies; corruption stages | none | PROTOTYPE (one static [REDACTED] line, tested) | RingZeroHud.cs:109 | Act state, story flags | Not flag-driven; docs assume Acts II-V | Keep as one line until Act II exists | P3 |
| SYS-EXP-07 | Field Journal (evidence, confidence, hypotheses) | Evidence record with sourceType, confidence, supports/contradicts | none (no class, no data, no schema) | DOCUMENTED (DESIGNED to field level) | reactive_world_and_field_journal.md:27-62 | Bestiary, quests | Two confidence vocabularies (see Problem 4) | Pick one Ring 0 slice (slime/goblin/rabbit) | P2 |
| SYS-EXP-08 | Discovery journal (creature/landmark/region/secret) | Unknown/Heard/Visited per category entry | Core TESTED (LivingWorldTests, 21 incl. director) | PARTIAL: held in PlayerWorldState and saved; no UI page; no writer except tests | LivingWorld.cs:201-244; PlayerWorldState.cs:101, 128, 301; Phase1WorldPlayModeTests.cs:107 | SaveGame | Not wired to anything player-visible | Wire to landmark/mural visit and add a page | P1 |
| SYS-EXP-09 | Map knowledge | Regions Unknown/Heard/Visited, local fog | Core TESTED (WorldMapTests 12) | IMPLEMENTED, TESTED (MapPlayModeTests 6) | MapKnowledge.cs; Player/PlayerMap.cs:47-113 | Region data | 28 map warnings (orchestrator run, not investigated here) | Leave | P3 |
| SYS-EXP-10 | Dungeon knowledge (rooms and clues) | Heard/Visited per room and clue | Core TESTED (DungeonKnowledgeTests 9, DungeonTests) | PARTIAL: Journal page reads it; no dungeon in the scene, no clue pickup | DungeonKnowledge.cs; JournalWindow.cs:44-80; ScreenshotRunner.cs:135-141 | Dungeon scene | Page always empty in play | See SYS-EXP-08 | P2 |
| SYS-EXP-11 | Dungeon puzzles | 3 puzzles (lever, weight, rune), optional with free assist | Core TESTED (PuzzleTests 20) | DOCUMENTED in game terms: data loaded (AscendData.cs:110), no puzzle object | Puzzles.cs; Data/World/puzzles.json (3) | Dungeon scene | None at game level | Defer | P4 |
| SYS-EXP-12 | Civilization Archive | 5 civs, 13 entries, 11 fragments, restore | Core TESTED (ArchiveTests 11) | PARTIAL: Journal page only; no inscription or fragment in the world | CivilizationArchive.cs; civilization_archive.json; JournalWindow.cs:85-120 | Place props | Same wiring gap | Wire 2 to 3 Whisperwood entries | P2 |
| SYS-EXP-13 | Living world events and NPC schedules | EventDirector (caravans etc), schedule resolver | Core TESTED (LivingWorldTests) | PARTIAL: `ActiveEvents` property exists (PlayerWorldState.cs:148-157); nothing calls it, no resolver calls in Game; NPCs are static capsules | LivingWorld.cs:83-196; living_world_v4_audit.md:29 | WorldClock | Audit itself lists "Unity wiring" as undone | Wire one caravan and Wendel's rumour board line | P2 |
| SYS-EXP-14 | Gathering | 4 node types, regrow | Core TESTED (GatheringTests 2) | IMPLEMENTED, TESTED (QuestPlayModeTests.cs:272) | Gathering.cs, GatherNode.cs, Ring0SceneBuilder.Npcs.cs:104-135 | Inventory | 13 nodes placed | Leave | P4 |
| SYS-EXP-15 | Waystones | Respawn attune; fast travel not decided | none needed | IMPLEMENTED (2 placed, test) | Waystone.cs; PlayerRespawn.cs:34; FieldScenePlayModeTests.cs:78 | Save | Fast travel waits on Canon WF11 | Leave | P4 |
| SYS-EXP-16 | Photo mode | Poses, filters, hide HUD; session-only overrides | Core TESTED (PhotoMode.cs 269 lines; tests not counted by me) | IMPLEMENTED, TESTED (Phase1WindowsPlayModeTests.cs:203) | PhotoModeController.cs | Canon photo contract | None found | Leave | P4 |
| SYS-EXP-17 | Guidance channels (diegetic guidance, clue parity) | Choose System thread / natural cues / companion / markers / none | none | DOCUMENTED; the game has only one conventional channel: HUD quest marker and "!/?" markers | RingZeroHud.cs:400-535; Canon §6 rows 106, 124, 147 | Settings | Canon rows are "Evaluate", no data or settings entry | Build the marker on/off switch first | P2 |
| SYS-EXP-18 | Exploration rewards | Knowledge, access, shortcuts | none specific | DOCUMENTED; the only exploration quest is `qst_explore_nine_thrones` (reach a place) | exploration_and_discovery.md; quests.json | Discovery registry | No discovery has a reward record | See Upgrade 3 | P2 |
| SYS-EXP-19 | Ring 0 exploration prototype (3 discoveries, clue chain) | Design list in docs | none | DOCUMENTED (the prototype list in AETHWYRD_3 is the first concrete spec) | AETHWYRD_3.docx.txt | all above | Not built | Scope to Upgrade 2 | P1 |
| SYS-QST-01 | Quest engine (QuestLog) | Accept, progress, ready, turn-in, save | Core TESTED (QuestLogTests 7, BoardQuestTests 4) | IMPLEMENTED, TESTED (QuestPlayModeTests 16) | QuestLog.cs; PlayerQuests.cs | Data | Act tracked as 0/1 only | Leave, extend Act | P2 |
| SYS-QST-02 | Objective types | kill, collect, reach, talk, defend, choice, escort, tame | Core TESTED | IMPLEMENTED (escort EscortNpc.cs:127, tame PlayerTaming.cs:139); the QuestLog header comment (QuestLog.cs:30-33) and WeeklyBoard.cs:39 comment disagree about which kinds exist | quests.json kinds: kill 19, collect 15, choice 10, reach 9, talk 9, defend 2 | Scene content | No "observe", "appraise", "photograph", "deliver" kind | Add 1 or 2 only if Upgrade 2 needs them | P2 |
| SYS-QST-03 | Quest data | 32 quests: F 17, E 14, C 1; Aldmere 18, Whisperwood 9, Labyrinth 5 | validated by `npm run build` (orchestrator) | 19 of 32 completable (static) | quests.json | NPCs, places | See headline 4 | Place missing NPCs or hide quests | P1 |
| SYS-QST-04 | Weekly guild board | 45 posted quests, daily/special/weekly slots, twists, siege warning | Core TESTED (BoardQuestTests, BoardAndInnTests) | IMPLEMENTED, TESTED (QuestPlayModeTests.cs:144) | weekly_board.json; QuestBoard.cs; NpcDialog.cs:119-135 | WorldClock | Day themes: all 7 weekdays have posts (Solenday 6, Sylvasday 6, Maelsday 5, Thorsday 5, Kaelsday 5, Morrowsday 5, Vexday 5, Any 7, Week 1). I did not check each against weekly_board.md themes | Leave | P3 |
| SYS-QST-05 | Escort / defence / siege events | Ottoline escort, Hesk granary, training yard, live raids | Core TESTED (SiegeTests 9, SiegeBattleTests 5) | IMPLEMENTED, TESTED (SiegePlayModeTests, QuestPlayModeTests) | EscortNpc.cs, DefenceSpot.cs, SiegeDirector.cs | Siege rules Canon §4b | Only Whisperwood governed | Leave | P3 |
| SYS-QST-06 | Story flags and acts | 19 flags | Core: flags are a HashSet<string> | PARTIAL: only quest-set flags work; `Act` is 0/1 | story_flags.json; PlayerQuests.cs:85, 156 | Story data | "story" flags have no setter; Acts II-VI have no representation | Add Act as data before writing Act II quests | P1 |
| SYS-QST-07 | Quest outcome grammar (choices with consequences, receipts) | 5-step spine, outcome record | none | DOCUMENTED. Choices are recorded (`QuestProgress.Choices`) but have no effect on rewards, flags or later dialogue; any option completes the objective | quest_outcome_grammar.md:56-72; QuestLog.cs:125-127; NpcDialog.cs:80-90 | Flags | 10 choice objectives in quests.json do nothing different per option | Upgrade 1 | P1 |
| SYS-QST-08 | NPC data | 39 NPCs: core 8, major 12, townsfolk 19; 2 have story states, 6 have schedules | validated | Only 12 placed as capsules; schedule and state data unused at runtime | npcs.json; Ring0SceneBuilder.Npcs.cs | Scene | Canon target ~2,500 NPCs (150 core), 39 exist | Leave scale; place the 8 missing quest NPCs | P1 |
| SYS-QST-09 | NPC dialogue and talk window | Menu of: hand in, accept, trade, craft, companion, rank-up | Core n/a | IMPLEMENTED, TESTED. The "dialogue" is one line: the NPC's role string (NpcDialog.cs:44), plus canned replies ("Good luck out there.") | NpcDialog.cs:41-140 | Quests | No dialogue data, no branching, no tone wheel (hud_and_ui §8), no per-NPC text, no state variants applied | Needs narrative-writer data schema first | P1 |
| SYS-QST-10 | Factions, clans, reputation | 87 clans, 17 guardians, 15 fauna in clans.json; NPC `faction` strings | Core: none for reputation | DOCUMENTED. No reputation counter exists in Core or Game (grep). Data/World/clans.json mentions it | clans.json | Dialogue | AETHWYRD.odt asks for "dialogue based on player reputation": nothing to base it on | Decide whether Ring 0 has reputation | P3 |
| SYS-QST-11 | Six-act story as data | Prologue + Acts I-VI prose in story.md (282 lines), act1_scene_scripts.md (427 lines) | none | Prologue and Act I partial as quests (see headline 5) | story.md; quests.json | Acts | Acts II-VI prose only | Out of Ring 0 | P4 |
| SYS-QST-12 | Companion story arcs | 14 companions; arc quests for 2 (Lyra 1, Torvald 1) | Core TESTED (RelationshipTests 20, CompanionV8Tests 20) | Lyra only in scene (CompanionAI, off until Status Granted); arc quest 1 unreachable (Hollis not placed) | quests.json; Ring0SceneBuilder.Npcs.cs:31-35 | NPC placement | Torvald arc quest 1 is completable | Place Hollis | P2 |
| SYS-QST-13 | Companion banter | 108 lines across 14 companions; triggers regionArrival, afterFight, restStop, lowHealth, revived, mounted, questDone, idle, monsterSeen, campfire | Core: cooldown rule only (Companions.cs:79-81) | UNCERTAIN: CompanionAI references `CompanionBrain.MaySpeak` (CompanionAI.cs:249) but I did not trace whether banter.json lines are read at runtime; grep shows no other banter reference in Runtime | banter.json | Companion AI | I could not confirm text comes from the data file | Trace in next pass | P2 |
| SYS-QST-14 | Quest tracker / markers | HUD tracker lines, "!/?" markers, map pencilling on accept | Core n/a | IMPLEMENTED | PlayerQuests.cs:164-190; RingZeroHud.cs:515-535 | Quests | Marker always on; no "no marker" option (Canon guidance rows) | See SYS-EXP-17 | P2 |

Counts (35 distinct rows incl. both scopes, 33 in the table): see end of report.

## 2. WHAT IS MISSING (designed or promised, not built)

- Any Appraisal beyond bestiary tiers: skill/stat, people tiers, item identification, detective flicker (VERIFIED FACT: no code).
- Lying Interface stages 1-4, redacted-line unlock, "recommended" quest lies, gold bleed (code has one static string).
- Field Journal evidence record, confidence, hypotheses (no class, no schema, no data).
- Any world object that writes a clue, archive entry, landmark or secret to the journals (writers exist only in tests and the screenshot sandbox).
- A DiscoveryJournal page and a quest log page in the Journal window.
- Hidden locations, secret routes and environmental storytelling props: none in the scene beyond a mural reach point at Z=88 and landmark stand-ins (Ring0SceneBuilder.Npcs.cs:48-65).
- Companion observations, return exploration (post-event changes), rare phenomena, exploration challenges, regional exploration identity as data.
- Climb, glide, swim, mounted riding.
- Quest outcome consequences, outcome record, quest receipts.
- Dialogue data and branching; NPC state variants applied to what the player sees.
- Reputation, faction standing.
- Quest data for Acts II-VI and Act I beats 8-10; story flags for them.
- Eight NPCs required by quests are not in the scene; no dungeon scene for the 5 Warren quests.

## 3. PROBLEMS IDENTIFIED

1. **"Appraisal" is two different things in the docs and one in code.** hud_and_ui.md §9 defines "Appraisal level" 0-4 as a character stat (level 4 = Appraiser class) and says the Bestiary "fills in the same tiers". Code defines the monster tier from kills only. skills_and_magic.md lists "Appraisal Eye" as a chosen Unique Skill. Result: proposals ask to "expand the existing Appraisal" but what exists is the Bestiary. VERIFIED FACT (all three read). Resolution: state in the bible that Ring 0 "Appraisal" = Bestiary tier, and that the Appraisal stat/skill is unbuilt.
2. **Both Journal pages are unreachable in play.** See headline 3. VERIFIED FACT. The docs (phase1_api.md, progress_log) describe these as wired in "Phase 1"; they are wired to save and UI, not to the world. Do not count them as "implemented exploration".
3. **13 of 32 quests cannot be completed in the build** and the field test only checks reach/defend targets and 7 givers (FieldScenePlayModeTests.cs:44-65); it never checks that every quest giver or talk target exists. REASONED CONCLUSION from static match; the test gap is VERIFIED FACT. The player will see no giver for those quests, so the harm today is "nothing happens", but it also means the data validator-green state hides unplayable content.
4. **Two confidence vocabularies for the journal.** exploration_and_discovery.md lists Observed / Reported / Unconfirmed; reactive_world_and_field_journal.md lists confirmed / corroborated / plausible / disputed / rumor and `sourceType` observed / testimony / document / appraisal / companion; Canon uses Unknown / Heard / Visited. VERIFIED FACT. Not a canon conflict (Canon row 147 says "evaluate"), but a build would need one mapping.
5. **Choice objectives do nothing.** 10 quests carry a `choice` objective; the option is stored and discarded. `TurnIn` sets every flag in `setsFlags` regardless of choice (PlayerQuests.cs:156). The "Spare the goblin child" style choices therefore have no outcome. VERIFIED FACT.
6. **Story flags set by "story" have no setter.** `nocturne_unmasked`, `caspian_unmasked`, `act3_nocturne_replaces_mina` have `setBy: story`; NPC `states` on Mina key off them (npcs.json), so those states can never become active. REASONED CONCLUSION (I found no setter in Core or Game).
7. **`PlayerQuests.Act` is 0 or 1.** Any Act II quest gate would be unrepresentable without a code change. VERIFIED FACT.
8. **Code comments disagree.** QuestLog.cs:30-33 lists six objective kinds; `OnEscort` and `OnTame` exist and are wired, so the data uses eight. Minor.
9. **`Playable` is vacuous** (WeeklyBoard.cs:40). Minor but it is the only "can the build track this" guard.
10. **Canon scale vs data scale:** Canon §2 names ~2,500 NPCs (150 core); data has 39 (8 core). Not a conflict (Ring 0 scope) but any reputation or dialogue plan should not assume the Canon number.

### Canon conflicts
None found for scope A/B. Notes: (a) Big Upgrade row (Canon.md:97) sits in the §6 "Proposed Locks" table and has no "Decided" marker, while README and other docs treat the 52 features as adopted. Whether the Lying Interface and Appraisal-as-detective are approved is therefore ambiguous: OPEN QUESTION for the owner. (b) Canon §3 bars "ride flying mounts"; no proposal in scope conflicts. (c) AETHWYRD.odt Part 3 and Part 8 mention named-monster memories; Canon §4d bars them, and the proposal itself says to preserve that.

## 4. Triage of the owner's proposals

### AETHWYRD_3.docx (exploration master prompt)
- Absolute rules 1-12: ALREADY DESIGNED (they restate Canon §6 guidance rows and exploration_and_discovery.md). Rule 12 ("verify existing implementations") is what this audit did.
- 1 Curiosity Reward Network (7 discovery types): ALREADY DESIGNED partly (three layers, leads, unmarked discoveries in exploration_and_discovery.md); the 7-type taxonomy is an IDEA candidate as authoring labels only.
- 2 Hidden Discovery System: UPGRADE candidate (Upgrade 2), built on DiscoveryJournal category "secret" and "landmark".
- 3 Environmental Storytelling: ALREADY DESIGNED (doc principle); needs art props; TOO COSTLY NOW beyond 3 to 5 props.
- 4 Appraisal Exploration (historical markings, hidden mechanisms, material properties): IDEA candidate; depends on SYS-EXP-05, which does not exist. TOO COSTLY NOW as a system; one "appraise" object in Whisperwood is feasible.
- 5 Discovery Chains: UPGRADE candidate (Upgrade 2/3). Existing parts: clue Heard/Visited rule and "rumour only pencils, finding opens" (Canon §6 row 130). Chain persistence already works in saves via DungeonKnowledge and DiscoveryJournal.
- 6 Exploration Rewards (knowledge, access, shortcuts, services...): ALREADY DESIGNED as principle (agent rule "mostly knowledge, access"); achievements are an IDEA candidate (no achievement system found).
- 7 Companion Exploration: IDEA candidate; companion banter has triggers `monsterSeen` and `regionArrival` but no clue trigger.
- 8 Return Exploration: ALREADY DESIGNED (liberation delta, reactive doc §116); built: nothing. UPGRADE candidate (Upgrade 5) tied to the siege state that already exists.
- 9 Rare World Phenomena: IDEA candidate; TOO COSTLY NOW (needs weather, mana and sky systems; Core has none for exploration).
- 10 Regional Exploration Identity: ALREADY DESIGNED (region kit, exploration_and_discovery.md:107-120); no data.
- 11 Exploration Challenges: IDEA candidate; TOO COSTLY NOW.
- 12 Curiosity Reward Director (modular tracker, reward resolution): TOO COSTLY NOW as a new "director". The pieces exist: `DiscoveryJournal`, `DungeonKnowledge`, `CivilizationArchive`, `EventDirector`, save fields. UPGRADE candidate: a small registry file, not a new system (Upgrade 2).
- Technical requirements list (stable ID, region, method, reward, journal ref, repeatability, save): ALREADY BUILT in part: stable ids, Unknown/Heard/Visited, save persistence and "never twice" fragments (ArchiveTests); missing: a discovery data file with method and reward fields.
- "No required progression locked behind optional secrets": ALREADY DESIGNED (Canon puzzle contract row 127, archive "gates nothing").
- Phase 1 audit: DELIVERED by this report. Phases 2-10: TOO COSTLY NOW as listed (about 10 phases for a team of two with 4 to 5 hours a week).
- First playable prototype (Whisperwood: 5 small discoveries, 3 hidden locations, 1 chain, 1 Appraisal secret, 1 companion observation, 1 ecology discovery, 1 changing location, 1 multi-stage mystery): UPGRADE candidate only if cut to about a third (Upgrade 2). Whisperwood already has the mural, ruins, waystone, gather nodes, Lyra and the siege state. Full list is 13 authored items: too much for the January target.

### AETHWYRD.odt, exploration/quest/NPC/narrative parts
- Part 5 Exploration and Discovery (15 lines): mostly the same as AETHWYRD_3; "exploration achievements" IDEA candidate; "expand the existing Appraisal mechanic" rests on a false premise (Problem 1).
- Part 6 Appraisal and Lying Interface (15 lines): ALREADY DESIGNED (big_upgrade §1-2, hud_and_ui §13); "misleading descriptions where lore supports", "multi-stage appraisal discoveries": IDEA candidate behind SYS-EXP-05. "Ensure the Lying Interface remains consistent with its established rules": DOCUMENTED rule, see Problem 6.
- Part 7 World and regions: ALREADY DESIGNED (region kit); TOO COSTLY NOW at scale.
- Part 8 NPCs and settlements: NPC routines ALREADY BUILT in Core (schedule resolver, 6 NPCs with schedules), not wired in Game (SYS-EXP-13); "dialogue based on reputation": TOO COSTLY NOW (no reputation, no dialogue data); "acknowledge major achievements": UPGRADE candidate via the quest receipt (Upgrade 1).
- Part 9 Quests: optional objectives, multi-stage quests, alternative resolutions: ALREADY DESIGNED (quest_outcome_grammar.md); built: none of the outcome grammar. Warren chain is the one multi-stage chain (5 quests, unreachable in game). "Hidden quest chains": 2 Hidden quests exist as data.
- Part 10 Guild: ALREADY BUILT in part (GuildRank, rank-up at Mina's desk, 3 Core tests, test QuestPlayModeTests.cs:236); ceremonies as scenes are IDEA.
- Part 13 World events: siege and liberation ALREADY BUILT (Whisperwood); "environmental changes after events" UPGRADE (Upgrade 5).
- Part 15/16 Legacy, Lost World Mysteries, Celestial, Legendary, Historical Memory: A. Adventurer's Legacy: ALREADY DESIGNED (big_upgrade §6 Legend log); B and G: ALREADY DESIGNED via Archive (13 entries, DOCUMENTED + Core TESTED); C Living Home: ALREADY BUILT in Core (Housing.cs; not in scope); D Celestial and E Legendary: IDEA candidate, TOO COSTLY NOW.
- Part 17 "connect the systems" example chain (guild contract, companion notices tracks, appraisal reveals history, ...): it is the design target for Upgrade 2 and Idea 1. Every link beyond the contract and the encounter is unbuilt.

## 5. UPGRADE candidates (improvements to things that exist), strongest first

### U1. Give choice objectives consequences and a receipt line
- Existing system: QuestLog `choice` objectives, NpcDialog choice options, `setsFlags`.
- Current status: Core TESTED, Game IMPLEMENTED; consequences none.
- Problem: 10 quests ask the player to decide; the decision changes nothing (Problem 5).
- Evidence: PlayerQuests.cs:156; NpcDialog.cs:80-90; QuestLog.cs:125-127.
- Proposed improvement: allow `setsFlags` and reward overrides per option in quests.json (data shape agreed with tools-pipeline-engineer), a one-line NPC "receipt" next time you talk to the giver, per quest_outcome_grammar.md "Resolve and return a receipt". Start with the 3 Ring 0 choices (slime relocate or slay, goblin child, runes report).
- Player benefit: decisions are visible. Technical benefit: Act I beat 8 and flags like `runes_reported_to` become real.
- Dependencies: schema change, narrative-writer lines. Affected files: Data/Quests/quests.json, Data/Schemas, Core/Quests.cs, QuestLog.cs, PlayerQuests.cs, NpcDialog.cs.
- Priority P1. Complexity M. Risk: save migration for `Choices` (low; already saved). 
- Acceptance: choosing option A vs B sets different flags and shows different giver text after hand-in; both complete the quest.
- Testing: Core test per option; PlayMode test through the dialog; save/load round trip.

### U2. A small discovery registry plus world pickups (replaces "Curiosity Reward Director")
- Existing: DiscoveryJournal, DungeonKnowledge, CivilizationArchive, QuestPlace, Waystone.
- Current status: Core TESTED, Game PARTIAL (state and save but no writers).
- Problem: nothing in the world records a discovery (headline 3).
- Evidence: ScreenshotRunner.cs:135-151 is the only non-test writer.
- Proposed improvement: one `Data/World/discoveries.json` (id, regionId, category, method [walk-in, appraise, talk, read], clue text, journal entry, reward = knowledge or access or a small item, repeatable false) and one `DiscoverySpot` component like `QuestPlace` that calls `Journal.Visit` or `Archive.ReadFromClue`. Cut the AETHWYRD_3 prototype to: 2 environmental discoveries, 1 hidden place, 1 three-step chain (rumour at Wendel's board, tracks, mural), 1 Archive entry. Four to six items, about 30 hand-placed lines of data.
- Player benefit: first time the Journal fills from exploring. Dependency: schema from tools-pipeline-engineer; scene placement by world-designer/level-designer.
- Priority P1. Complexity M. Risk: scope growth (R11). 
- Acceptance: a player with no quest marker finds the mural, the Journal page shows the entry, save/load keeps it, the reward is knowledge or a shortcut, no progression is gated.
- Testing: Core test for registry validation (ids exist, region exists); PlayMode test that stepping on a spot writes the journal and survives save.

### U3. Journal window: add a DiscoveryJournal page and a quest page
- Existing: JournalWindow with 2 pages.
- Problem: neither Journal page nor any other screen shows the creature/landmark/region/secret categories or completed quests.
- Proposed: add two pages (Discoveries, Quests: active, completed, choices made) using existing `Journal.Count/StatusOf` and `QuestLog.Completed`. Fits IMGUI placeholder.
- Priority P1. Complexity S. Dependencies: U2 for content. Files: UI/JournalWindow.cs, Tests/PlayMode/Phase1WindowsPlayModeTests.cs.
- Acceptance: page lists Heard (wording only) and Visited entries, counts unknown ones. Testing: extend the existing window test.

### U4. Make every quest completable or visibly parked
- Problem 3. Proposed: place Hollis, Caspian, Tamsin, Tomlin, Sister Pell, Ines, Brutus (capsule NPCs, as the builder already does) or tag the 13 quests as parked in data so the giver never offers them; add a PlayMode test "every quest giver and talk target exists in the field, or the quest is parked". Dungeon quests: park until the Warren scene exists.
- Priority P1. Complexity S. Files: Ring0SceneBuilder.Npcs.cs (gameplay-engineer or world-builder), FieldScenePlayModeTests.cs, optional `parked` field. Risk: low.
- Acceptance: test lists zero unreachable quests. Testing: that test.

### U5. Liberation delta for exploration (return exploration, bounded)
- Existing: siege state Besieged/Liberated, quest `regionState`, `tyrant_slain_reg_whisperwood` flag.
- Proposed: 2 discoveries in U2 gated on the Whisperwood Liberated state (Canon row 105 already asks for "route, patrol/merchant, board/rumor and ambient cues"). Reuse `QuestContext.RegionState`.
- Priority P2. Complexity S after U2. Risk low.
- Acceptance: a spot is inactive while besieged, active after the Chief falls; save-safe.

### U6. Tie the Status Window redacted line to story flags
- Existing: one static string. Proposed: `redactedLines` data keyed by flag, with the line text changing when `caspian_unmasked` etc. Today only the first line; sets up Act II glitch.
- Priority P3. Complexity S. Files RingZeroHud.cs, a small data file. Risk: low. Acceptance: toggling a flag changes the line; test updated.

### U7. Act as data, not 0/1
- `PlayerQuests.Act` from `Log.Completed`; replace with the highest `act` among completed main quests or a flag. Required before any Act II quest.
- Priority P2. Complexity S. Files PlayerQuests.cs, QuestGate (Quests.cs:92). Testing: QuestLogTests.

### U8. Guidance switch: quest marker on/off
- Existing: always-on HUD markers. Canon rows 106, 124 want independent channels. First step: a setting to hide "!/?" and the tracker arrow while keeping the text tracker (accessible equivalent). Priority P2. Complexity S. Files RingZeroHud.cs, AccessibilityWindow.cs, accessibility data. Acceptance: with markers off, a quest is still completable using the tracker text; test.

### U9. Wire the EventDirector to the clock (one caravan, one rumour)
- Existing: Core TESTED, `ActiveEvents` unused. Proposed: day-change call, show the event text on the board clerk dialog, one shop-stock effect. Priority P2. Complexity M. Files WorldClock.cs, PlayerWorldState.cs, NpcDialog.cs. Risk: save upgrade paths already covered in Core tests.

### U10. Appraisal naming and a single tier-by-skill hook
- Rename in docs "Appraisal tier = Bestiary tier"; add an `appraisal` level read from a stat so tier can rise with the skill, not only kills. Hold until the owner decides Decision D2. Priority P3. Complexity M.

### U11. Banter data trace and trigger coverage test
- Confirm banter.json lines are what CompanionAI says; add a test that every companion has lines for each trigger the scene can fire. Priority P3. Complexity S.

### U12. Quest board "Playable" guard
- Replace the vacuous `Playable` with a real check against placed givers/places at load, plus a validator warning. Priority P3. Complexity S. Files WeeklyBoard.cs, Tools validator.

## 6. IDEA candidates (new, distinctive)

1. **"The Seams" appraisal flicker (Ring 1).** Category: exploration + identity. A one-frame Race flicker on Mina's Status after Act III; players with the Appraisal Eye can catch Nocturne early. Player experience: detective payoff from the stat screen. Belongs: it is the Big Upgrade §2 hook and uses the Lying Interface. Systems: Appraisal, NPC states, dialogue. Dependencies: SYS-EXP-05, Act data (U7). Implementation: `NpcState` flag plus an appraisal overlay that renders alternative text for 0.1 s. Technical: UI only. Content: 3 to 4 NPCs. Complexity M. Risks: needs Act III; players may miss it (that is intended, add a replay hint). Questions: is the Appraisal stat a Unique Skill or a rank-based gain?
2. **Return-a-clue journal (Returner recap).** Category: journal. A spoiler-safe "last seen" summary on resume. Canon row 147 already proposes it. Player: long saves feel safe to resume. Systems: Journal, Quest log. Implementation: from `Log.Active` and last Visited entries. Complexity S. Question: opt-in or default?
3. **Companion eye.** Category: companion exploration. Each companion notices one clue type (Lyra: people and mood; Torvald: stonework and metal). A banter trigger `clue` with 1 line each. Dependencies: U2. Complexity S to M. Risk: voice writing load for 14 companions; do 2.
4. **Ecology tracks as the clue chain.** Category: ecology link. Tracks of slime residue, rabbit droppings, goblin boot prints on three approaches to a damaged granary (the reactive doc's Ring 0 prototype). Systems: Bestiary tier, Journal, quest outcome. Complexity M. Questions: show in world or only in journal?
5. **Map-as-journal pencilling.** Category: UX. Discoveries pencilled onto the existing map as Heard/Visited marks (uses MapArt overlay). Complexity M.
6. **Diegetic guidance: "the System's thread".** Category: UX/identity. A faint thread in the world that the Lying Interface later betrays (it leads somewhere that benefits the System). Ties Canon row 106 to the Act III "recommended" lie. Complexity M to L. Risk: breaks trust if poorly done; opt-in only.
7. **Quest receipts at the board.** Category: social. Wendel's board shows your last 3 outcomes as pinned notes. Uses U1. Complexity S.
8. **Field sketch at a landmark.** Category: photo-mode link. Taking a photo at a landmark counts as Visited with a sketch in the journal (reactive doc "field sketching"). Uses PhotoMode (IMPLEMENTED). Complexity M. Risk: screenshot storage; optional.

## 7. RISKS

| Risk | Prob / Impact | Type |
|---|---|---|
| Journal pages look finished but stay empty in a real session, so progress reports overstate exploration | High / Medium | Confirmed defect (reporting risk) |
| 13 unreachable quests in the build; playtesters find dead quest data | High / Low-Medium | Confirmed (static analysis) |
| Exploration scope creep from AETHWYRD_3 (10 phases, 13 prototype items) against a January target | High / High | Theoretical |
| Choice quests keep shipping with no consequence and testers read them as bugs | Medium / Medium | Confirmed defect |
| Act 0/1 and missing story-flag setters block any Act II work | Medium / Medium | Confirmed defect for later work |
| Two or three confidence vocabularies make the Field Journal hard to build | Medium / Low | Confirmed doc conflict |
| Banter lines may not be what the game says (untraced) | Low-Medium / Low | Unverified assumption |
| NPC capsule placement hides that dialogue is one line | Medium / Medium | Confirmed |
| PlayMode result (183 passed) is 4 days old and not re-run in this audit | Low / Medium | Theoretical |

## 8. DECISIONS REQUIRED from the owner

- D1. Is the Big Upgrade (Lying Interface, Appraisal detective) approved? Canon §6 row 97 carries no decision marker.
- D2. What is "Appraisal" in Ring 0: Bestiary tier only (my recommendation), or a skill with its own level?
- D3. Approve a small discovery registry (U2) instead of a Curiosity Reward Director; approve scaling the Whisperwood prototype to 4 to 6 items.
- D4. Park or place the 13 unreachable quests (U4)?
- D5. Which one confidence vocabulary does the Field Journal use (Canon's Unknown/Heard/Visited plus the source label)?
- D6. Is a "markers off" guidance setting wanted for Ring 0 (U8)?
- D7. Is reputation in or out of Ring 0?

TESTING REQUIRED (for any item adopted): Core tests for new data rules; `npm run build` after any Data/Schema change; PlayMode tests for the quest/journal wiring; a field-scene test that every quest giver, talk target and reach place exists; save round-trip for new journal and choice data. None of this was run in this audit.

CONFIDENCE
- High: headline 1, 2, 3 (read the code and greps for writers), quest data counts and objective kinds (computed from JSON).
- Medium: "19 of 32 completable" and "37 of 45 board quests" (static text match of the scene builder; I did not run Unity, did not check item drops, monster spawns or prerequisite flags such as `rank_e_reached` being set).
- Low: banter runtime path, weekday themes vs weekly_board.md, Photo mode and Core test counts (counted by grep patterns; not run).

UNRESOLVED QUESTIONS
- Does CompanionAI speak lines from banter.json? (not traced)
- Is `rank_e_reached` set by the trial quest (needed by the first Warren quest)? (not checked)
- Are the 3 "story" flags meant to be set by cutscene code that does not exist yet?
- Did the PlayMode 183 count include the Journal windows test with real writers? (the test I read seeds state directly)

FINAL STATUS
Audit delivered (a recommendation set, not completed implementation). Status counts for the 33 table rows (Core / in-game): Core TESTED 17 rows, Core DOCUMENTED-or-none 12, n/a 4; in game: IMPLEMENTED/TESTED 8, PARTIAL 9, PROTOTYPE 1, DOCUMENTED 12, UNCERTAIN 1, VERIFIED 0, COMPLETE 0. No row reaches VERIFIED: no evidence of a running-game check was available to me.
