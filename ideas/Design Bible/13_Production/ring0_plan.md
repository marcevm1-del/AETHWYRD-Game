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

- **v0.11:** player stats and XP curve (`Data/Classes/progression.json`), the Swordsman's Ring 0 kit (`Data/Classes/classes.json`), Ring 0 monsters at F- with level spreads, real Freeze/Storm Prison, poise regen. Balance check: a Lv 1 Swordsman kills a goblin in 3 light hits and survives 9 goblin hits; at Lv 10 everything dies in one hit (`ASCEND_REPORT=1 npm test`).

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

## Progress (2026-10-24)
| Week | State |
|---|---|
| 1 Project boots | ✅ Done |
| 2 Run around | ✅ Done (capsule stand-in until your VRoid character) |
| 3 Your face in the game | ⏳ Waiting on your VRM export |
| 4 Swing a sword | ✅ Light string, tap/charged heavy (3 levels, guard break at 2+), hit-stop, capped camera shake, damage numbers |
| 5 Dodge & parry | ✅ Perfect dodge → Flash Time + stamina refund, parry → stagger + riposte, block (red ignores it, gold grabs) |
| 6 First monsters | ✅ Monster AI from motion.json (chase, telegraph ring + !, strike, recovery), aggro tokens (≤ 2 attackers), leash, stagger, skittish rabbits. Rigging and animation still to do |
| 7 Air combat | ✅ L L H launcher, jump-cancel, air chain with hang time, slam (launch-to-slam), lock-on with flick switching |
| 8 Skills & Firestorm | ✅ Swordsman skills by data kind, Ultimate (Thousand Petal Blade), Fire Bomb, Wind + Fire = Firestorm (burst + burning zone), Combo Budget |
| 9 Status & Style | ✅ XP and level-ups, Style Rank C → SSS (XP bonus), Awakening, HUD and Status Window (IMGUI placeholder until the styled HUD) |
| 10 Polish & the fun test | 🔶 Standalone Windows build (*Assets ▸ Ascend ▸ Build Ring 0 Player*, output in `Game/Builds/Ring0/`); the fun-test field has 3 slimes, a goblin pack of 5 and 2 rabbits. Your playtest notes next |
| Beyond the plan | ✅ Monster projectiles, straight charges that stick in walls, grabs; wall sliding. Coins and loot on kill (Style Rank luck), purse and pickup toasts. Death screen (killer, rank, its field-note tip), difficulty penalty (Adventurer drops 10% in a blue coin lantern, newest only), waystone respawns. Save/load (JSON slot, autosave at waystones and on respawn; bad saves kept as .bad, never loaded). 677 procedural blockout models in Unity (local) |

**Controls** (`12_Systems/hud_and_ui.md` §15): WASD/left stick move · Shift/B dodge (hold to sprint) · Space/A jump · LMB/X light · RMB/Y heavy (hold to charge; after two lights = launcher; in the air = slam) · Q/RT block/parry · MMB/R3 lock-on · 1–4 or RB + face skills · R or L3+R3 Ultimate · G or D-pad up Fire Bomb · Tab/Esc/Start Status Window.

**Tests:** 100 rules + 64 Unity PlayMode.
