# Dependency map

What must come before what. It covers the whole project at the level of systems and tasks; the branch-level Unity merge order from 2026-11-09 stays in `13_Production/unity_integration_dependency_map.md` and is still valid for the PC branches it lists.

## 1. The three gates everything hangs on

```text
OWNER'S PC (Unity)          OWNER'S DECISIONS                 USAGE WINDOWS
 verify run, PlayMode,       canon batch, slice scope,         2 agents at once,
 profiler, builds,           character, licences,              about 4 jobs per window
 playtests                   new data types
```

Anything that needs Unity waits for a PC slot. Anything in `CHANGE_CONTROL.md` §4 waits for the owner. Everything else is limited only by windows.

## 2. Task graph to the slice gate

```text
T-001 PC verify run ──────────────┬──────────────────────────────────────────────┐
                                  │                                              │
T-002 split fun test ─> T-003 owner plays ─> feel fixes (P0, if any)             │
                                  │                                              │
                                  ├─> T-012 profiler capture ─> T-014 allocation fixes (only if shown)
                                  │
   (cloud, no Unity)              │   (Unity, after T-001)
T-005 magical branch in Core      ├─> T-004 reaction table into the game ─┐
T-008 rank-band fix ─┐            ├─> T-006 launchable                    ├─> retest fun-test items 7 to 12
T-013 dead-data report            ├─> T-007 group tactics ────────────────┘
T-020 documentation sweep         ├─> T-009 quest reachability test ─> park or place quests
T-021 decision records            │
                     │            │
                     └─> T-018 encounter tables as spawn source ─┐
                                                                 │
OWNER: approve slice + discovery data type ─> T-011 discoveries ─┼─> T-010 journal pages
OWNER: approve choice data ─> T-017 choice outcomes ─────────────┤
OWNER: CD-011 ─> bestiary vocabulary and research tasks ─────────┤
                                  Grukk's verbs (needs T-004) ───┤
                                                                 ├─> liberation delta ─> SLICE LOOP (gate 1 to 6)
OWNER: names ─> T-022 save version rule and identity ────────────┘

OWNER: character ─> import, animation tests ─┐
OWNER: art route ─> T-015 one creature end to end ─> 21 slice species ─┼─> SLICE PRESENTABLE (gate 7, 8)
OWNER: audio licences ─> playback ───────────┘
```

## 3. System dependencies worth knowing

| System | Depends on | Why it matters |
|---|---|---|
| Any second class | Magical damage path (UPG-004); class line-up decision (UPG-034) | Enabling a caster before UPG-004 ships a wrong formula |
| Reaction synergies, Grukk's armour | Reaction table in the game (UPG-003) | Same construction site in `MonsterDummy.cs` |
| Fun-test items 7 to 12 | UPG-002, UPG-003, UPG-007 | They cannot pass before the wiring |
| Encounter tables as spawn source | Rank-band fix (UPG-019); region filing of Brindlewick (CD-009) | Otherwise over-rank monsters spawn in the starter wood |
| Ecology layer (UPG-021) | Encounter tables (UPG-020); CD-008, CD-014 | Region state acts by swapping tables |
| Research tasks, dens and signs | One bestiary vocabulary (UPG-011); ambient behaviours (UPG-023); discoveries (UPG-009) | Nothing to observe otherwise |
| Journal pages | Discovery registry (UPG-009) for content | Pages without writers already exist |
| Lying Interface stages | CD-002; acts and flags as data (UPG-015); UI technology (UPG-032) | Text swaps need flags; effects need the real UI |
| Liberation delta | Encounter tables; discoveries | The delta is made of those |
| Humanoid animation, foot IK | A humanoid model (UPG-031) | Untestable on a capsule |
| Audio | Licensed sources registered in `third_party_assets.md` | No file, no playback |
| Terrain in the game | Owner's tile-size, rebase and out-of-map decisions | Out of the slice |
| Any new save field | Save version rule (UPG-028); an old-save test | R7, R19 |
| `MonsterAi.cs`, `Companions.cs`, `BossPhases.cs` | One engineer per wave (shared ownership) | UPG-002 and UPG-023 cannot run in the same wave |

## 4. What blocks the most

Counted from §2: the PC verify run (T-001) is upstream of every Unity task. The owner's approval of the slice scope is upstream of all phase 3 content. The character and the art route are upstream of everything visual. These three are the critical path; no amount of agent time shortens them.

## 5. What can proceed with no dependency at all

In the cloud, today, on approval of the first wave: T-002, T-005, T-008 (once the rule is chosen), T-013, T-020, T-021.
