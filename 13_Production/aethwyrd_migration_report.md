# AETHWYRD migration report (2026-11-07)

The user chose **AETHWYRD** as the title of the game and **Aethwyrd** as the name of its world (adjective **Aethwyrdian**) and authorised the rename, including `Canon.md`. This is a naming migration only: no lore, history, chronology, character, faction, mechanic or number changed. Executed by Claude under delegated creative control; the user may overrule any exception below.

## Numbers
| Item | Count |
|---|---|
| Tracked files inspected (git ls-files) | 6210 (2524 text files scanned by the script) |
| Files modified | 161 by the script, plus hand edits to `Canon.md`, `README.md`, `CLAUDE.md` and this report |
| Files or folders renamed | 0 (see "Kept on purpose") |
| World-name replacements (Aetheria, Aetherian, Aertheria, AETHERIA -> Aethwyrd forms) | 360 |
| Game-title replacements ("Project Ascend" -> AETHWYRD) | 136 |

Rules used: capitalised and upper-case forms only, never inside identifiers, paths or URLs (negative look-behind for `_ / \ word`, look-ahead for `-Game`). Case-preserving: `Aetheria` -> `Aethwyrd`, `Aetherian` -> `Aethwyrdian`, `Aertheria` -> `Aethwyrd`, `AETHERIA` -> `AETHWYRD`.

## Where
Design-bible docs and their `ideas/` vault copies, `Canon.md` (Title row and prose), `README.md`, `CLAUDE.md`, `project.yaml` (`project.name`), `Data/World/gazetteer.json`, `inns.json`, `physical_map.json` (player-facing text), `Data/Quests/story_flags.json` (description text only), the atlas HTML title and captions, Blender add-on descriptions and authors, header comments in Tools and Code, UI text `WorldMapWindow.cs` ("Aethwyrd" on the world map) and its PlayMode test, vault builder text, the user's brief notes (`upgrade vN`, `formula v.1.0`, `expansion lore`, `Expanse`) in prose only.

Canon.md Title row: old `Open ("Project Ascend" placeholder). **Ask the user on/after 2026-11-01**`; new `**AETHWYRD** (chosen by the user, 2026-11-07; ...)`. Logged in `CHANGELOG.md`.

## Kept on purpose (deliberate exceptions)
| Reference | Why kept |
|---|---|
| GitHub repo name and URLs `marcevm1-del/Aetheria-Game`, `.gitignore` entry `GitHub/Aetheria-Game/`, git remote name `aetheria` (CLAUDE.md, `.claude/agents/*`, `Tools/pc/update_and_verify.ps1`) | The task forbids renaming the repo URL or remote. |
| Working folder `E:\Ideas\Project-Ascend` and every path containing `Project-Ascend` | Outside the repo; renaming breaks local scripts. |
| C# namespaces `Ascend.*`, asmdef names, `Ascend_URP.asset`, `AscendToon.shader`, `AscendData.cs` | Internal identifiers; Unity GUID/.meta bound. No benefit, real risk. |
| Package ids `com.projectascend.core`, `com.projectascend.monsters`, `Game/Packages/manifest.json` and lock entries | Package manager ids. |
| npm package name `project-ascend-data` | Tooling id, not user-facing. |
| Unity `productName: Game` and `companyName: DefaultCompany` | The save folder `%USERPROFILE%/AppData/LocalLow/DefaultCompany/Game/` is derived from them. Changing them would orphan every existing save and the window title. A branded window title needs a save-path compatibility migration first (follow-up, not done). |
| `ProjectAscend.exe` (BuildPlayer.cs, project.yaml `run`, update_and_verify.ps1) | Build output name used by scripts and CLAUDE.md commands. |
| Story flag id `arrived_in_aetheria` (`story_flags.json`, `quests.json`, vault note `arrived_in_aetheria.md`) | Save-visible key. Only its description text was renamed. No save key changed, so no compatibility map was needed. |
| File names `02_Lore/life_in_aetheria.md`, `Tools/atlas/aetheria_atlas.html` and links to them | Renaming would break many links and the atlas path stored in `physical_map.json`. Their content is renamed. |
| `13_Production/Project_Ascend_Next_Steps.docx/.pdf` | Binary files, referenced by CI comment. |
| Rig/material profile ids `AETHERIA_HUMANOID_V3`, `AETHERIA_CREATURE_V3` and the folder sketch `aetheria_studio/` in `upgrade v3` | Identifier proposals in a brief; if built they should be created as `AETHWYRD_*`. |
| `Aetherion`, `Aetherium` (monster/material names in `Expanse 1`, `expansion lore 2`) | Different names, not the world. |
| Historical logs: `CHANGELOG.md` older entries, `13_Production/progress_log.md`, `13_Production/handover/*`, dated root notes `2026-*.md`, `reports/**/build.log` | A log must keep what was true when written. |
| Short form "Ascend" in prose ("Ascend's systems", "Ascend Creatures", "Ascend Buildings" tool names) | Tool and system names, not the title. |
| `Name Changer` | The user's instruction file. |

## Validation
- Re-search for `Aetheri|Aertheri|AETHERI`: remaining hits are only the kept items above (URL, historical logs, Aetherion/Aetherium, the two v3 profile ids).
- Re-search for `Project Ascend`: only historical logs and this report.
- File names unchanged, so Markdown links and resource paths cannot have moved. The vault was rebuilt (`node Tools/vault/build_vault.js`, 1607 notes).
- `npm run build`: data valid, 661 tests passed, 28 map warnings (same as before the rename).
- Diff review: 481 insertions, 481 deletions in the scripted pass, line-for-line replacements only; no file deleted.
- Not run: Unity PlayMode tests (the UI string and its test assertion changed together).

## Lore preserved
Only name tokens changed. Valdrisia, Vesper, the Great Weave, the Five Elder Dragons, the System, the ages and the Sundering, characters, factions, numbers and canon/draft/proposal markings are untouched; the diff has no added or removed lines other than the name substitutions.
