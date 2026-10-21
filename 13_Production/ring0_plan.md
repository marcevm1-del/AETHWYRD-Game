# 13c — Ring 0 Plan: "It's Alive" (target: January 2027)

**Goal:** one graybox field where your own anime character runs, dodges and fights Blue Slimes, Goblins and Horned Rabbits with combat that already *feels* good. Spec: `12_Systems/combat.md`. Tuning: `Data/Combat/combat_tuning.json`.

**Budget:** ~10 weeks × 4–5 hrs/week of **your** time (~45 hrs). Claude writes the code and data between sessions; your hours go to running the project, testing, making your character and art-directing.

## Tech Setup (decided)
| Piece | Choice | Why |
|---|---|---|
| Engine | **Unity 6000.6.7f1** (already installed on E:) | Matches your install |
| Project folder | `Project-Ascend/Game/` (inside this Git repo) | Design, data and game versioned together |
| Render pipeline | **URP** + Unity Toon Shader | Genshin-style cel shading, runs on a GTX 1650 |
| Input | **Input System** package | Controller + keyboard/mouse, rebinding |
| Camera | **Cinemachine** | Orbit, lock-on and cinematic cameras with little code |
| Character | **VRoid Studio** → VRM → **UniVRM** importer | Fast, free anime characters |
| Animation | Mixamo (free) to start | Placeholder combat animations; upgrade later |
| Data | JSON in `Data/` read at runtime by a C# importer | Same files the validator checks |

## Already done (while Unity is blocked)
- **`Code/Ascend.Core`**: the combat rules as plain C# (no Unity dependency): ranks and levels, element auras and reactions, damage formula, Style Rank meter, loot rolls, poise, aggro tokens, and data models for every JSON file. **22 tests pass** (`npm test`), including a cross-check that every monster's level matches the rank rules. Unity will use this code directly.

## Milestones
| Week | Milestone | You | Claude |
|---|---|---|---|
| 1 | **Project boots** | Open `Game/` in Unity Hub; confirm it loads; sign in if asked | Project created, packages, URP + toon setup, folder layout, data importer stub |
| 2 | **Run around** | Make your character in VRoid Studio, export VRM | Third-person controller (walk/run/sprint/jump), Cinemachine orbit camera, graybox field |
| 3 | **Your face in the game** | Drop the VRM in; check it looks right | UniVRM import, toon material setup, Mixamo retarget pipeline |
| 4 | **Swing a sword** | Test feel, report what's floaty | L-chain, heavy/charge, hit detection, hit-stop, camera shake, damage numbers |
| 5 | **Dodge & parry** | Try to break it | Dodge with i-frames, perfect dodge → Flash Time, parry + riposte, telegraph colors |
| 6 | **First monsters** | Fight them, rate the fun | Blue Slime, Goblin (pack AI + aggro tokens), Horned Rabbit, all read from `species.json` |
| 7 | **Air combat** | Combo practice | Launcher, air chain, slam, Combo Budget, lock-on + free aim toggle |
| 8 | **Skills & Firestorm** | "Whoa" test | 4 Swordsman skills, Fire Bomb, element auras, Firestorm reaction |
| 9 | **Status & Style** | Check the UI looks "anime System window" | Status Window, XP and level-ups, Style Rank meter (C→SSS) |
| 10 | **Polish & the fun test** | Run the checklist in `combat.md` §12 | Fixes from your notes, build a standalone .exe |

## What "done" looks like
The 6 checks in `combat.md` §12 pass, and a standalone build runs on your PC at a steady 60 fps in the graybox field.

## ⚠️ Blocker found (2026-10-22): the Unity editor install is incomplete
A test project creation failed: `E:\6000.6.7f1\Editor\Data\Resources\PackageManager\Server\` (Unity's Package Manager) is missing, along with some compiler analyzer files. Likely causes: an interrupted install or antivirus quarantine. Unity Hub also reported no sign-in token.
**Fix (you, ~15–30 min):**
1. Open **Unity Hub** and **sign in** (a free Personal license is fine).
2. **Installs** → the ⚙ next to 6000.6.7f1 → **Uninstall**, then **Install Editor** again (or pick the newest **LTS** version Hub recommends). Keep the install location on `E:`.
3. If your antivirus quarantined `UnityPackageManager.exe`, restore it and add an exclusion for the Unity install folder.
4. Tell Claude when it's done; Claude creates the project from the command line and sets up packages.

## Your Week-1 Checklist
1. *(After the fix above, once Claude has created it)* Open **Unity Hub** → *Add project from disk* → `E:\Ideas\Project-Ascend\Game`.
2. Open it with **6000.6.7f1**. The first open downloads packages (needs internet, a few minutes).
3. Tell me if anything shows a red error in the Console.
4. Install **VRoid Studio** (free, Steam or vroid.com) whenever you're ready for Week 2–3.
