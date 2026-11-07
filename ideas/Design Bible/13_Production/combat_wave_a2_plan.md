# Wave A2: combat gaps from upgrade v5

> Producer plan. Scope is the combat gaps in `upgrade v5` only. Canon wins; nothing here edits a locked Canon row. Work happens in this worktree (branch `claude/wave-a2-combat-18be8b`); nothing is committed or pushed until the user says so.

## Scope and hard limits

In: (a) data-driven reactions and synergies, (b) boss weak points and armor break, (c) group tactics for monsters, (d) combat sandbox harness, (e) audit note.

Forbidden (reject in review): new game modes, destructible arenas, gore, weapon mastery trees, any edit to `Game/Assets/_Game/Runtime/Player/PlayerMotor.cs`, animator work. Group tactics: NO commanders, captains, warchiefs or ranks among monsters, and NO learning or adapting to the player (Canon §4d). Peer coordination is symmetric and per-fight only: nothing is remembered between fights.

Out of Wave A2 (listed so nobody drifts): wiring the new data into Unity (`AscendData.cs`, `Runtime/Combat/`, `Runtime/World/MonsterController.cs`) is Wave A3 for gameplay-engineer and ai-engineer. Wave A2 must keep Unity compiling and behaving exactly as today.

## Frozen contracts (so the agents can start in parallel)

These are the shapes every agent codes to. Change only through the producer.

**Reactions** (`Data/Combat/reactions.json`):
- Root: `{ "version": 1, "notes": str, "swirl": {...}, "reactions": [...], "synergies": [...] }`.
- Each reaction: `id` (must equal an existing `Reaction` enum name: Firestorm, StormPrison, Freeze, ThermalShock, Magma, Swirl, Wildfire, TwilightBurst, MiasmaBlast, Grounded), `elements` (two Element names; order does not matter), `consumesAura` (bool), optional `bonusDamageMult` (default 1.0), optional `dot` {`element`, `damagePerSecMult`, `durationSec`, `tickSec`}, optional `hazard` {`kind` (string id), `radiusM`, `durationSec`, `damagePerSecMult`}, optional `status` {`kind` (`freeze` or `stun`), `durationSec`}.
- `swirl`: {`element` "Wind", `spreadRadiusM`, `spreadDamageMult`, `maxSpreadTargets`}. Wind meeting a non-Wind element spreads the non-Wind element to neighbours and the aura is kept (today's behaviour).
- Each synergy: `id`, `first` and `then` (reaction ids), `windowSec`, `bonusDamageMult`, optional `note`. A synergy fires when `then` triggers within `windowSec` of `first` on the same target. No new `Reaction` enum values: synergies are separate records.
- Backward compatibility rule: `Elements.React`, `AuraState.Apply`, `ReactionState(ReactionTuning)`, `HitMultiplier` and the existing 10 pairs keep identical results when no table is supplied. Freeze/stun/shatter numbers stay in `combat_tuning.json` `reactions` (the table's `status.durationSec` for Freeze and StormPrison must equal them; a test asserts it).

**Boss weak points** (`Data/Monsters/boss_weakpoints.json`, separate file; `boss_phases.json` is not touched):
- Root: `{ "version": 1, "notes": str, "bosses": [ { "speciesId", "armor": { "maxArmor", "breakSec", "damageTakenMultWhileBroken", "regenDelaySec" }, "weakPoints": [ { "id", "label", "bodyPart", "damageMult", "armorDamageMult", "exposedInPhases": [phase names], "exposedSec"? } ] } ] }`.
- `speciesId` must exist in species.json. `exposedInPhases` names must exist in that boss's `boss_phases.json` phases when the boss has one. Grukk gets one starter record; its phases stay exactly as they are (a test pins the three phases).
- Core API (new file `BossWeakPoints.cs`): `BossWeakPointFile`, `BossArmor` (tracks armor value, break and regen against a passed-in clock), `BossTargeting.Resolve(bossData, phaseName, hitPartId, hitWeight)` returning damage multiplier plus armor damage. Engine-free, time passed in.

**Group tactics** (`Code/Ascend.Core/GroupTactics.cs`, new; `MonsterAi.cs` gets minimal hooks):
- Types: `GroupTacticsTuning` (defined in `GroupTactics.cs`, all fields defaulted), `ThreatAssessor` (scores threat to a monster from player HP fraction, nearby allies, own HP; no memory), `FlankSlots` (assigns N distinct angular slots around the target, deterministic from member order), `RetreatRule` (low-HP retreat, with the existing `RetreatHpPct` and `LoneRetreatHp` as the base), `PeerCoordinator` (symmetric: a monster in `Reposition` yields a slot or a token to a healthier peer; no leader role).
- `MonsterBrain.Tick` keeps its signature. New data arrives through optional new fields on `AiSense` (defaults make old callers identical). `MonsterAiTests` must stay green unmodified.
- `combat_tuning.json` gets a `groupTactics` object after Wave A2 integration; until then everything defaults in code.

**Sandbox** (`Code/Ascend.Core/CombatSandbox.cs`, new): `CombatSandbox` spawns N dummies (species id, element, HP, optional armor), applies scripted hits (`SandboxHit`: element, weight, weight class, body part, attacker id), advances a clock, and returns a `SandboxReadout` (per hit: damage dealt, multiplier breakdown, reaction fired, synergy fired, armor and break state; per dummy: HP, aura, status). Deterministic: takes an `IRandom`. Uses `DamageCalculator`, `ReactionState`/`ReactionTable` and `BossArmor`; no UnityEngine.

## Agents, files and checks

Five agents. File ownership is disjoint; each shared file has exactly one editor.

### Task 1. combat-designer: data and rules text
Owns (edits only these):
- `Data/Combat/reactions.json` (new)
- `Data/Monsters/boss_weakpoints.json` (new)
- `Data/Combat/combat_tuning.json` (adds `groupTactics` block and, if needed, a `sandbox` block; existing keys unchanged)
- `12_Systems/combat.md` (new subsections for reaction table, synergies, weak points and armor, group tactics, sandbox)
- `08_Bestiary/bosses_and_calamities.md` (weak points and armor notes only)
- `13_Production/combat_v5_audit.md` (new; the audit note, see below)

Do:
1. Write `reactions.json` to the frozen contract: all 10 existing reactions with numbers that reproduce today's behaviour (aura consumed or not, freeze and stun seconds copied from `combat_tuning.json`), plus the added DoT, hazard and bonus-damage values as proposals marked in `notes`. At least 4 synergies.
2. Write `boss_weakpoints.json` with the Grukk starter record and one commented-out-in-notes template for future bosses. Do not touch `boss_phases.json`.
3. Add `groupTactics` numbers to `combat_tuning.json` (flank slot count 2-4, retreat HP fraction, threat weights, yield timings). Keep `ai.maxSimultaneousAttackers` as is.
4. Document each in `combat.md`; keep teen rating and no gore. Describe group tactics as symmetric peer behaviour with no leaders and no memory.
5. Write `combat_v5_audit.md`: table of every combat line in `upgrade v5` (elemental reactions, weak points, armor destruction, group tactics, sandbox, ability synergies, executions, hazards, arena destruction, mastery trees, and so on) with status: Already built (file), Wave A2, Deferred (reason), or Rejected (Canon/forbidden). Cite files. New rules needing the user's OK go to Canon §6 as a proposal list in this note, not into locked rows.
Done when: both JSON files parse; the numbers named in the contract exist; `git diff` shows `Data/Monsters/boss_phases.json` unchanged; every `upgrade v5` combat item has a row in the audit.
Checks (exact):
- `node -e "for (const f of ['Data/Combat/reactions.json','Data/Monsters/boss_weakpoints.json','Data/Combat/combat_tuning.json']) JSON.parse(require('fs').readFileSync(f,'utf8')); console.log('json ok')"`
- `git -c safe.directory=E:/Ideas/Project-Ascend diff --stat -- Data/Monsters/boss_phases.json` (must print nothing)
- After Task 2 lands: `node Tools/validate/validate.js`

### Task 2. tools-pipeline-engineer: schemas and validation
Owns:
- `Data/Schemas/reactions.schema.json` (new)
- `Data/Schemas/boss_weakpoints.schema.json` (new)
- `Tools/validate/validate.js` (the only editor of this file in the wave)
- `Tools/validate/build_schemas.js` only if it must register the new schemas
- `Tools/vault/` only if the vault builder needs to list the new data

Do:
1. Schemas to the frozen contracts (additionalProperties false, enums for Element and Reaction names).
2. `validate.js`: load both new files when present (guard with `fs.existsSync`, like `boss_phases.json` at line 153); check reaction `id` is a known Reaction, `elements` are known Elements and the unordered pair is unique, synergy `first`/`then` exist in `reactions`, weak-point `speciesId` is a real species and `exposedInPhases` match `boss_phases.json` phase names, `status.durationSec` for Freeze/StormPrison equals `combat_tuning.json` `reactions`.
3. Add the group tactics numbers range checks (fractions between 0 and 1, slot counts 1-6) if Task 1 has put them in.
Depends on: contract only; to verify against real data it needs Task 1's files (run the final check after Task 1 merges).
Checks (exact):
- `node Tools/validate/build_schemas.js`
- `node Tools/validate/validate.js` (must exit 0 with the new files present; also deliberately break a copy of one value in a scratch file to prove each new rule fails, and report that)
- `node Tools/vault/build_vault.js`

### Task 3. core-rules-engineer: reactions, weak points, sandbox, data plumbing
Owns:
- `Code/Ascend.Core/ReactionTable.cs` (new)
- `Code/Ascend.Core/Elements.cs`
- `Code/Ascend.Core/BossWeakPoints.cs` (new; `BossPhases.cs` is NOT edited, it stays with the shared-owner rule and is not needed)
- `Code/Ascend.Core/CombatSandbox.cs` (new)
- `Code/Ascend.Core/Data.cs` (the only editor in the wave: new optional `GameDatabase` constructor parameters appended AFTER `bosses`, new `Reactions` and `BossWeakPoints` properties)
- `Code/Ascend.Core/CombatTuning.cs` (the only editor in the wave: adds `GroupTactics` property in the integration step, see Wave 2; may also add a `Sandbox` tuning class)

Do:
1. `ReactionTable`: load from the `reactions.json` shape; `ReactionTable.Default` rebuilds today's hardcoded 10 pairs so `Elements.React` and every existing test is unchanged. `Elements` delegates to `Default` when no table is passed. Add `ReactionState` overload taking a table that returns a `ReactionResult` (reaction, bonus multiplier, dot, hazard, swirl spread info, synergy fired) while the old `ApplyElement` returning `Reaction` still works.
2. `BossWeakPoints.cs` per the contract (armor value, break, regen, weak point multiplier by phase).
3. `CombatSandbox.cs` per the contract.
4. `Data.cs`: new optional ctor params `ReactionFile reactions = null, BossWeakPointFile weakPoints = null`; null means defaults, so every existing caller compiles.
Done when: all existing rules tests pass untouched; `Elements.React` over all Element pairs gives the same results as before (a before/after table is in the report); the sandbox runs a scripted fight in a unit test.
Checks (exact):
- `node Tools/run_tests.js`
- `dotnet build Code/Ascend.Core/Ascend.Core.csproj -warnaserror` if the csproj exists, else the build step inside `node Tools/run_tests.js`
- Confirm nothing under `Game/` references a removed or renamed public member: `grep -rn "Elements\.\|ReactionState\|AuraState\|BossFight" Game/Assets/_Game/Runtime` and list each use as still valid.

### Task 4. ai-engineer: group tactics
Owns:
- `Code/Ascend.Core/GroupTactics.cs` (new)
- `Code/Ascend.Core/MonsterAi.cs` (the only editor in the wave; shared-owner rule with core-rules-engineer: core-rules-engineer does NOT edit it this wave)
- `13_Production/handover/` entry for AI wiring (new file, e.g. `handover/group_tactics_wiring.md`)

Does NOT touch: `Runtime/World/MonsterController.cs` and other Unity AI components (Wave A3), `CombatTuning.cs` and `Data.cs` (core-rules-engineer).

Do:
1. `GroupTacticsTuning` with in-code defaults, `ThreatAssessor`, `FlankSlots`, `RetreatRule`, `PeerCoordinator` per the contract.
2. Hooks in `MonsterBrain`: optional `AiSense` fields (e.g. `FlankSlot`, `AlliesNear`, `PlayerHpFraction`, `YieldToken`), a `ThreatLevel` output. Default values reproduce the current brain exactly.
3. Hard rules, enforced in code and a test comment: no leader or rank field, no per-player memory, no state that survives `Reset`, no randomness except through the injected `IRandom`.
4. Write the Unity wiring brief for Wave A3 (what `MonsterController` must pass in `AiSense`, how slots are assigned each frame from the live pack list).
Done when: `MonsterAiTests.cs` and `MonsterMotionTests.cs` pass unmodified; new behaviours are demonstrable by qa-tester's tests (Task 5) through the public API only.
Checks (exact):
- `node Tools/run_tests.js`
- `grep -n -i "captain\|commander\|warchief\|leader\|learn\|adapt" Code/Ascend.Core/GroupTactics.cs Code/Ascend.Core/MonsterAi.cs` must show no such concept (comments restating the ban are fine; say so in the report)

### Task 5. qa-tester: tests, sandbox PlayMode test, regression guard
Owns:
- `Code/Ascend.Core.Tests/` (all new test files plus `Program.cs` as the only editor: `Repo.Db` gains `Load<ReactionFile>(...)` and `Load<BossWeakPointFile>(...)` once those files and types exist)
- New files: `ReactionTableTests.cs`, `BossWeakPointTests.cs`, `GroupTacticsTests.cs`, `CombatSandboxTests.cs`
- `BossPhaseTests.cs` (additive only: a test pinning Grukk's three phases, tempo and damage values)
- `Game/Assets/_Game/Tests/PlayMode/CombatSandboxPlayModeTests.cs` (new, plus its `.meta` generated by Unity)
- `reports/` for the results

Do:
1. Tests written against the frozen contracts first (they will not compile until Tasks 3 and 4 land; keep them in a branch-local state and run them at the Wave 2 gate).
2. Backward compatibility: a test that runs every Element x Element pair through `Elements.React` and through `ReactionTable.Default` and requires equal results; a test that freeze duration, shatter bonus and storm prison stun equal `combat_tuning.json`.
3. Weak points: Grukk's data loads, armor breaks and regenerates by clock, weak point multiplier applies only in `exposedInPhases`.
4. Group tactics: slots are distinct, retreat at low HP, a lone hurt pack monster yields, behaviour with default `AiSense` equals the old brain tick for tick, and a source-scan test that fails if a type or member named `Captain`, `Commander`, `Warchief` or a per-player memory store appears in `GroupTactics.cs`.
5. Sandbox: scripted fight gives a stable, asserted readout.
6. PlayMode: `CombatSandboxPlayModeTests` builds dummies in code (existing `MonsterDummy`, no new runtime and no scene file) and checks a Fire-then-Ice hit sequence reads out the expected reaction. No scene edits (Scenes belong to world-builder-engineer).
Checks (exact):
- `node Tools/run_tests.js` (all pass, new count reported)
- `npm run build`
- Unity PlayMode (background, over 2 minutes): `"E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe" -batchmode -projectPath Game -logFile Game/Logs/a2_playmode.log -runTests -testPlatform PlayMode -testResults Game/Logs/a2_playmode.xml`; read the XML pass/fail counts

## Ordering

Wave 1 (parallel, no shared files): Task 1 combat-designer, Task 2 tools-pipeline-engineer, Task 3 core-rules-engineer, Task 4 ai-engineer, Task 5 qa-tester (tests written against contracts; may leave failing-to-compile tests unmerged until Wave 2).

Merge order inside Wave 1: Task 1 first (data), then Task 2 (validation runs against real data), then Tasks 3 and 4 (independent Core files; `MonsterAi.cs` and `Elements.cs` are different files), then Task 5.

Wave 2 (sequential, small): integration by core-rules-engineer, then qa-tester.
1. core-rules-engineer: add `GroupTactics` property of type `GroupTacticsTuning` to `CombatTuning.cs` (type comes from Task 4's `GroupTactics.cs`) so the `groupTactics` block loads; bump nothing else.
2. qa-tester: update `Program.cs` `Repo.Db`, turn on the contract tests, run the full gate: `npm run build`, then PlayMode tests.

Wave 3 (review gate, read-only, same day): code-reviewer on the whole diff (checks: forbidden list, Canon §4d ban, `boss_phases.json` unchanged, no `PlayerMotor.cs` edit: `git diff --stat -- Game/Assets/_Game/Runtime/Player/PlayerMotor.cs` is empty), canon-keeper on `combat_v5_audit.md` and any proposals (Canon §6 only).

After the user approves a push: producer adds a `progress_log.md` row, updates the daily note, runs `node Tools/vault/build_vault.js`.

## File ownership map (no overlaps)

| File or folder | Sole editor in Wave A2 |
|---|---|
| `Data/Combat/reactions.json`, `Data/Monsters/boss_weakpoints.json`, `Data/Combat/combat_tuning.json` | combat-designer |
| `12_Systems/combat.md`, `08_Bestiary/bosses_and_calamities.md`, `13_Production/combat_v5_audit.md` | combat-designer |
| `Data/Schemas/reactions.schema.json`, `Data/Schemas/boss_weakpoints.schema.json`, `Tools/validate/validate.js`, `build_schemas.js`, `Tools/vault/` | tools-pipeline-engineer |
| `ReactionTable.cs`, `Elements.cs`, `BossWeakPoints.cs`, `CombatSandbox.cs`, `Data.cs`, `CombatTuning.cs` | core-rules-engineer |
| `GroupTactics.cs`, `MonsterAi.cs`, `13_Production/handover/group_tactics_wiring.md` | ai-engineer |
| `Code/Ascend.Core.Tests/*` (incl. `Program.cs`), `Game/Assets/_Game/Tests/`, `reports/` | qa-tester |
| `13_Production/combat_wave_a2_plan.md`, `progress_log.md`, daily note | producer |
| `BossPhases.cs`, `boss_phases.json`, `PlayerMotor.cs`, `AscendData.cs`, `Runtime/`, `Scenes/` | nobody (frozen this wave) |

## Risks and watch items

- Task 5 tests cannot compile until Tasks 3 and 4 expose their types: the contract section names every public type to prevent drift; any rename must go through the producer.
- `GameDatabase` has a long positional constructor; Task 3 appends optional parameters only, never reorders. A reorder would break `AscendData.cs` and `Program.cs` silently.
- `MonsterAi.cs` is shared with core-rules-engineer by rule: confirm core-rules-engineer is not editing it in the same wave.
- Numbers for new DoT, hazard and synergy values are proposals until the user tunes them (put under "Waiting on you" in the daily note when Wave A2 is reported).
- Unity wiring of any of this is Wave A3; until then the new data is exercised only by Core tests and the sandbox.
