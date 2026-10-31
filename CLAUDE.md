# Project Ascend — notes for Claude sessions and agents

A 3D third-person, single-player, offline-complete anime fantasy RPG (Unity 6 URP, data-driven JSON). This repo is the design bible, the data, the tools, the Unity project and the Obsidian vault at once.

## Rules that always apply
- **Canon wins:** `Canon.md` beats every other doc; `Data/` is canonical for numbers. Never edit a locked Canon row; propose changes in Canon §6 for the user's OK.
- **Commercial game:** take only ideas and mechanics from other studios' games, never their code, art, text or data. Third-party assets only as listed in `13_Production/third_party_assets.md`.
- **Content:** teen rating, no fanservice, warmth over comedy.
- **Git:** `git -c safe.directory=E:/Ideas/Project-Ascend <cmd>`; never change global git config. Remote `aetheria`, branch `main`.
- **Never touch** the player's save at `%USERPROFILE%/AppData/LocalLow/DefaultCompany/Game/slot0.json`. Don't create accounts, enter keys or buy anything.
- **Before reporting work as done,** run its checks and say exactly what ran and what it returned.
- **After each push,** add a row to `13_Production/progress_log.md`, update the dated note at the repo root (`YYYY-MM-DD.md`) and run `node Tools/vault/build_vault.js`.
- **Shell:** bash heredocs with apostrophes or non-ASCII break, so write scripts to files. Background anything slower than about 2 minutes.

## Layout
| Path | What |
|---|---|
| `00_Questions` … `13_Production` | The design bible (13_Production holds plans, the progress log and the system docs) |
| `Data/` | Canonical game data (JSON, validated by `Data/Schemas/`) |
| `Code/Ascend.Core` + `.Tests` | Engine-agnostic C# rules and their tests |
| `Code/Unity/Runtime` | Shared Unity runtime package (monster motion, springs, hurtboxes) |
| `Game/` | The Unity project (`Assets/_Game/{Runtime,Editor,Tests,Art,Scenes}`) |
| `Tools/` | Data generators, the validator, the vault builder, the atlas, and the Blender pipelines (`Tools/blender/`) |
| `Art/` | Blender sources; generated libraries and third-party packs stay local (gitignored) |
| `ideas/` | The generated Obsidian vault (rebuild with `npm run vault`) |

## Commands
- **Data and rules tests (what CI runs):** `npm run build`. Rules tests only: `node Tools/run_tests.js`.
- **Unity:** `"E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe" -batchmode -projectPath Game -logFile <log>` with one of:
  - `-quit -executeMethod Ascend.EditorTools.Ring0SceneBuilder.BuildBatch` (scene)
  - `-quit -executeMethod Ascend.EditorTools.BuildPlayer.BuildRing0` (player)
  - `-runTests -testPlatform PlayMode -testResults <xml>` (tests)
- **Update this PC and check everything:** double-click `Tools/pc/update_and_verify.cmd` (pulls `main`, runs `npm run build`, rebuilds the scene, runs PlayMode tests, builds the player, takes screenshots; logs in `Game/Logs/verify_<time>/`).
- **In-game screenshot:** `Game/Builds/Ring0/ProjectAscend.exe -screen-width 1600 -screen-height 900 -screen-fullscreen 0 -ascendShot <png> [-ascendShotAt x,z] [-ascendShotYaw deg]`
- **Blender 5.2:** `E:/SteamLibrary/steamapps/common/Blender/blender.exe -b --factory-startup -P <script>`
  - Buildings: `Tools/blender/build_building_library.py` (docs: `13_Production/building_system.md`).
  - Creatures: `Tools/blender/build_creature_library.py` (docs: `13_Production/creature_system.md`).

## The agent team
There are 26 specialist subagents in `.claude/agents/`. Each owns a set of files and knows its checks. The roster, the ownership map and how to run them in parallel waves are in `13_Production/agent_team.md`. Start a multi-agent push with the **producer**.
