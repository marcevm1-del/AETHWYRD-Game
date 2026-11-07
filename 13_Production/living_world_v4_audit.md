# Upgrade v4 audit: what was taken, what was left (2026-11-07)

Source: `upgrade v4` (the user's brief, "Living World, World Intelligence & Dynamic Narrative"). Decided and built by Claude under delegated creative control; the user may overrule. Checked against Canon §4d (named monsters: no hierarchy, no nemesis memory), §5 (loss rules) and the §6 offline-first and in-game-time rows.

## Built (rules, data, tests; docs in `12_Systems/living_world.md`)
| v4 section | What was built | Why it is Canon-safe |
|---|---|---|
| 3. NPC intelligence (schedules only) | `NpcScheduleResolver` over the existing `schedule` field; optional, essential NPCs always available | Never gates essential access (§6 recurring town-life row) |
| 6/7. World events | `EventDirector`: caravans and small wandering encounters from `living_world.json`, calendar-driven, cooldowns, caps, deterministic | In-game days only; four harmless effect kinds; no settlement or ownership change |
| 5. Exploration and discovery (journal only) | `DiscoveryJournal`, Unknown / Heard / Visited, plus `SaveGame.LivingWorld` that defaults safely | Same vocabulary as the map (§6 map knowledge, WF1) |

Tests: 21 new Core tests in `LivingWorldTests.cs` (build 661 -> 682). The validator now checks the data (`living_checks.js`, schema `living_schemas.js`).

## Left out, with the reason
| v4 section | Left out because |
|---|---|
| 1. World simulation | Open-ended simulation; breaks the finite, readable-state rule (§6 world response rows) |
| 2. Quest generation | Procedural quests; quests stay authored (quest outcome grammar row) |
| 3. Relationships and memory beyond schedules | Already covered by Wave C relationship tracks and bounded NPC memory |
| 4. Faction and political simulation | Faction war, politics, succession: out of scope and against §4d (no hierarchy) |
| 5. Exploration beyond the journal | Landmark, lead and unmarked-discovery kit already proposed and decided; the rest is content |
| 6. Events with persistent consequences, multi-stage events, "ancient ruin becomes active" | Persistent change to the world; later, one authored event at a time |
| 7. Economy and trading | Dynamic economy; the item economy guardrails row keeps prices bounded and visible |
| 8. Progression and identity | Covered by "progression without repetition debt" |
| 9. Technical systems | Existing data-driven JSON and validator cover it |
| 11. Extra ambitious ideas (settlement evolution, legendary events) | Settlement change is excluded |

## Follow-ups
- Unity wiring (gameplay-engineer, ui-engineer): call `Advance` on day change, show extra stock, a journal screen; keep schedules switchable in settings.
- More pool rows (narrative-writer, quest-designer) once the regions' rumour boards exist.
- A real boat or fast-travel decision (Canon §6 WF11) is not needed by any of this.
