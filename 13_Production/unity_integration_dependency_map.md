# Unity integration dependency map (producer, 2026-11-09)

Job 2 of the producer queue. Built from `git rev-list` of the live agent branches against `aetheria/main` (`ae78c53f`), `phase1_api.md`, `animation_v11_audit.md`, `group_tactics_wiring.md`, the v4-v11 audits and `world_upgrade_plan.md`. Items marked *unverified* were read from docs and commit messages only; no Unity or code was inspected beyond that.

## 1. Ground truth about Unity

- **Corrected after reading the progress log:** Unity PlayMode was run on 2026-11-08: 163 of 163 passed on merged main (waves A1 to F-lite, rename, living world; commit 5311b936), then phase 1 (commit 18963dd8) reported 746 Core tests + 183 PlayMode tests with screenshots (`phase1_*.png`). The older handover line "nothing compiled since 2026-10-31" is out of date.
- Still unverified in Unity: the `agent/ai-engineer/companion-presets-tactics` branch ("unverified" in its commit message), anything the phase 1 handoff lists as "Not persisted" (companion presets and bonds), the humanoid foot-IK path (needs a humanoid import), and everything after phase 1b.
- A verify run (`Tools/pc/update_and_verify.cmd`) is still step 0 of any Unity slot that merges new branches, to prove the baseline before and after.
- Only one Unity process on `Game/` at a time, and only with "UNITY OK" in the GO.

## 2. Branch inventory (ahead of `aetheria/main`)

| Branch | Ahead | Content | Touches Unity? |
|---|---|---|---|
| `agent/ai-engineer/companion-presets-tactics` | 1 | Companion presets, retreat and group enemy tactics wired into the runtime ("unverified") | **Yes** (`Runtime/World/`, `Code/Unity/Runtime/`) |
| `claude/humans-base-aca467` | 7 | Character base pipeline (CLI works across drives) | Likely Tools/Blender; check before merge |
| `agent/core-rules-engineer/save-migration-tests` | 1 | Core save migration tests | No (Core only); unblocks save fields |
| `agent/class-skill-designer/rune-enchant-kits` | 1 | 9 gear skills, schema, validator | Data only |
| `agent/audio-designer/music-cue-sheet` | 1 | Music cue sheet | Docs; feeds audio wiring |
| `agent/bestiary-designer/open-fixes` | 3 | Ecology notes, generator | Data/tools |
| `agent/canon-keeper/rename-audit` | 5 | Rename audit docs | Docs |
| `agent/anime-fantasy-director/review-humans` | 4 | Style checklist docs | Docs |
| `agent/code-reviewer/core-perf-review` | 2 | Tech-debt register | Docs |
| 12 other agent/claude/integrate branches | 0 | At or inside the base (the wave B-F branches and phase1 are already in `ae78c53f`) | none |

Worktrees at base with nothing to merge (cleanup candidates, see the risk register): `animator-rigger-locomotion`, `audio-designer-sfx-event-list`, `class-skill-designer-companion-kits`, `integrate-agents-1`, `library-shelf`, plus branches without worktrees.

## 3. Dependency graph (what must come before what)

```
baseline verify run (qa-tester, UNITY OK)  <- every new Unity merge below
  |
  +-> A. Phase 1 wiring: ALREADY GREEN (183 PlayMode); re-check only after merges (gameplay-engineer)
  |     |  PlayerWorldState, PlayerSave new fields, crafting, journal, accessibility
  |     +-> B. save-migration-tests merge (Core, no Unity)  -- must land BEFORE any new save field
  |     +-> C. UI windows (crafting, companions, journal, accessibility, photo) PlayMode screenshots (ui-engineer)
  |     +-> D. Persist companion presets/bonds (not in the save file yet, per phase1_api "Not persisted")
  |            needs B first, then save-platform-engineer + gameplay-engineer
  |
  +-> E. Companion presets/tactics branch merge   (ai-engineer)
  |     needs A green (shares Runtime/World). Core files MonsterAi/Companions/BossPhases:
  |     only ONE of ai-engineer / core-rules-engineer edits them per wave.
  |     +-> F. group_tactics_wiring: MonsterController passes AiSense fields (AlliesNear, FlankSlot, YieldToken ...)
  |
  +-> G. Wave A1 animation PlayMode tests (foot IK, driver) (animator-rigger + qa-tester)
  |     humanoid path stays untested until a humanoid import exists (user's VRM, or humans-base output)
  |     +-> H. Humanoid import of the player character  [waits on user VRM / humans-base]
  |
  +-> I. Terrain placement builder behind a flag   (world-builder-engineer)
        needs user answers: 10.24 km tiles, rebase to Brindlewick, out-of-map = open sea
        needs technical-artist import stub (done) + world_upgrade_plan wave 3 terrain finish
  +-> J. Audio: music state logger -> real playback (audio-designer + gameplay-engineer)
        needs the cue sheet branch merged; no new packages; voice amount is a user decision
```

Hard rules that create edges: no new packages; saves backward compatible (old-save test per field); one owner per file (see `agent_team.md`); Ring 0 scene must not change behaviour while features sit behind flags.

## 4. Recommended order (2 working agents per slot, Unity slots only one process)

| Slot | Agents | Work | Exit check |
|---|---|---|---|
| U0 | qa-tester | Baseline verify run on `aetheria/main` (expect 746 + 183); stop if it regressed | Log in `Game/Logs/verify_*`, counts in report |
| U1 | core-rules-engineer (no Unity: merge `save-migration-tests`) + gameplay-engineer | B, then persist companion presets and bonds (D) | `npm run build` and PlayMode green |
| U2 | ai-engineer + ui-engineer | E then F; C screenshots (disjoint folders `Runtime/World` vs `Runtime/UI`) | PlayMode green, screenshots |
| U3 | animator-rigger + save-platform-engineer | G; D | Foot IK tests green; old-save test passes |
| U4 | world-builder-engineer + audio-designer | I behind flag; J | Ring 0 scene unchanged (screenshot diff), Batch build runs |
| U5 | code-reviewer, qa-tester, anime-fantasy-director | Review and visual check of everything merged | Findings fixed |

Non-Unity work (design, data, docs) fills the other slot whenever Unity is occupied, subject to the working cap in `risk_register_and_usage_budget.md`.

## 5. Merge order for the branches in section 2

1. `save-migration-tests` (Core only, no conflicts expected).
2. Data-only branches: `rune-enchant-kits`, `open-fixes`, `music-cue-sheet`.
3. Docs branches: `rename-audit`, `review-humans`, `core-perf-review`, producer notes.
4. `companion-presets-tactics` after the U0 baseline, then re-run PlayMode (it is unverified).
5. `humans-base`: inspect first; do not merge binaries.

Run `npm run build` after each merge (746+ tests, 28 warnings, 0 graph findings must hold).

## 6. Open questions that block items

| Needs | Blocks |
|---|---|
| User VRM export or the humans-base character | H, humanoid foot IK |
| Terrain tile size 10.24 km, Brindlewick rebase, out-of-map behaviour | I |
| Voice amount, display-serif font licence | J, map labels |
| Canon §6 batch (12 rows) | Content that uses the new names |
