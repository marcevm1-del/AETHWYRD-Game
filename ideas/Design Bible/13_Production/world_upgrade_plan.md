# World upgrade plan (started 2026-11-02)

The user asked the team to "upgrade the world with all agents" and keep it running on a long plan. The main session runs the waves: **at most two agents at once, never two on the same files, no commits or pushes without the user, Canon changes only as §6 proposals.** Each wave ends with its own checks; every third wave the code-reviewer and qa-tester check everything that changed.

Status keys: ✅ done · 🔄 running · ⏳ waiting on a slot · ❓ waiting on the user.

## Done today
| Item | Owner | Result |
|---|---|---|
| Map data: smooth rivers, 51 settlements, 13 roads | world-designer | ✅ additive, deterministic, build green |
| Diorama views (continent, heartland, Dragon Spine) | technical-artist | ✅ 5 rounds, director approved the look |
| World terrain tiles, dressing, natural-landscape pass | environment-artist | ✅ seams 0, peaks 0.00 %, Ring 0 flat |
| Whole-world sector build (150 tiles, 6 sectors) | main session | ✅ split proven identical |
| Unity terrain import spec + stub | technical-artist | ✅ stub compiles and imports a tile |

## The plan
| Wave | Agents (2 at once) | Job | Proof of done | Status |
|---|---|---|---|---|
| 1 | creature-artist | Dragon spade, dragon body vs wing ratio, wyvern wings off Gargoyle/Arch Demon | Renders of the affected species | ✅ wing ratio 1.6x (needs director OK) |
| 2a | tools-pipeline-engineer | Validator rules: road grade, settlement slope/lake, river joins (warnings) | `npm run build` green with counts | ✅ 0 errors, 28 warnings |
| 2b | world-designer | Fix river_20's 22 m hang; propose (not apply) moves for the 21 steep and 2 lake settlements; switchback waypoints for roads 04/05/06/12 | Validator findings drop; proposals listed | ⏳ after the place renders |
| 3 | environment-artist | Natural pass 2: Cinderhole bowl, river valleys and fans readable at 10 km, oxbows, terrace steps at towns; new `_albedo.png` + `_dressing.json` exports for Unity | Director review of the place renders | ⏳ |
| 3 | bestiary-designer | Spore Lords rank C; Orc Grunt look text (sword) | Build green, contradiction check 0 | 🔄 |
| 4 | canon-keeper | One Canon §6 batch: 9 road names, range/pass/river names, "Karak" echo, snow on volcanic ground | Proposals cite their data | ⏳ |
| 4 | narrative-writer | In-world blurbs for the 51 settlements (drafts) | Names match the gazetteer | 🔄 |
| 5 | anime-fantasy-director | Review every town and area render + dioramas + creatures; rank fixes | `reports/design_review_2026-11-02.md` | ⏳ |
| 5 | systems-designer | Travel times on the 13 roads vs world_tuning | Table, build green | ⏳ |
| 6 | quest-designer | Quest targets sit on the new settlements and roads | 0 orphans | ⏳ |
| 6 | items-designer | Loot and recipes after the Bestiary change | Validator recipe rule passes | ⏳ |
| 7 | code-reviewer | Review all uncommitted work | Findings, blockers first | ⏳ |
| 7 | qa-tester | `npm run build`, PlayMode, screenshots | Counts and logs | ⏳ |
| 8 | world-builder-engineer | Terrain placement builder on the import spec (behind a flag, Ring 0 untouched) | Batch build runs, PlayMode green | ⏳ needs ❓ 10.24 km + rebase |
| 8 | save-platform-engineer | Save safety audit (slot0 never touched) | Audit note | ⏳ |
| 9 | creature-artist | Toon contact-sheet rebuild (GPU, 1–2 h, background) | Sheets regenerated | ⏳ GPU free |
| 9 | environment-artist | Iron Hold fountain, building preview camera | Building sheet renders | ⏳ |
| 10 | class-skill-designer, combat-designer, ux-designer, ui-engineer, core-rules-engineer, gameplay-engineer, ai-engineer, animator-rigger, audio-designer, youtube-beta | Audits and specs from the producer's list (in pairs) | Each agent's own check | ⏳ |
| 11 | producer | Progress log, daily note, vault | Vault builds | ⏳ |
| Loop | main session | Rebuild world + re-render places after each terrain change; repeat director review → fixes | Live page | ongoing |

## Waiting on the user
1. Canon: 9 road names, §6 map names, "Karak" echo, snow on volcanic ground.
2. Settlement moves (proposals only until approved).
3. Unity: rebuild tiles at 10.24 km, rebase to Brindlewick, out-of-map area = open sea?
4. Display-serif font for labels (licence entry).
5. MCP bridges for Blender and Unity.
6. Committing today's work (map, terrain, dioramas, rebuilt Ring 0 scene).
7. Pack licences, TripoSR, the title (from 2026-10-25).
