# Session Prompt — v0.11: Siege System, Weekly Board & Inns in Code + Review Fixes

You're working on **AETHWYRD**, a single-player 3D open-world isekai RPG (Unity 6, data-driven JSON), in the folder `E:\Ideas\Project-Ascend` (a Git repo). Read `README.md`, `Canon.md` and `CHANGELOG.md` first, then `12_Systems/systems.md` (Regional Siege & Liberation), `11_Quests_Encounters/weekly_board.md` and `12_Systems/inns.md`. **Canon.md wins every conflict.** I'm the creative director and I prefer you to decide and build rather than ask. Flag anything that needs my OK in `Canon.md` §6 (Proposed Locks) and keep going. Keep docs concise.

Do the work in this order. Commit after each part. **This session is code and data**: build what's already designed; don't redesign it. The feature docs (`01_Core_Concept/the_big_upgrade.md`, `borrowed_features.md`, `12_Systems/hud_and_ui.md`) are proposals in Canon §6; don't implement them yet unless a task below says so.

---

## Part A — Regional Siege → Liberation (designed; now build it)

**The rule:** every region has a **Tyrant**, its "big bad". Until the Tyrant is slain, the region is **Besieged**: its settlements (cities, towns, villages) face **defence events 1–2 times per in-game week**. Once the Tyrant dies, the region becomes **Liberated**: the attacks stop, and the region's quest board switches to normal **monster-hunting contracts**.

### Design (already written in `12_Systems/systems.md` → Regional Siege & Liberation and Canon §4b; summary below. Link it from `11_Quests_Encounters/quests_and_encounters.md`)
1. **Region states:** `Besieged` → `Liberated` (permanent). Optional middle state `Weakened` once the Tyrant's lieutenants/dens are cleared (defences get easier).
2. **Weekly defence:** a Besieged region attacks one of its settlements **1–2 times per in-game week**, at random, usually at dusk, never two days in a row.
   - The week is **7 days** (Canon §2, Solenday → Vexday). At 90 real minutes per day, that's roughly one attack every 5–10.5 hours of play.
   - Each attack is posted on the guild board and the rumor board **one in-game day ahead**, so the player can travel there and prepare.
   - Waves are themed to the Tyrant's faction (e.g. goblin warbands for a goblin Tyrant). They scale to the region's rank band, and the last wave has a lieutenant.
   - Target length: 5–8 minutes. Rewards: gold, GP, XP, Prosperity Safety, and settlement reputation.
   - **Escalation:** each in-game week the Tyrant lives, its faction's strength rises a step, up to a cap. That pushes the player to go hunt the Tyrant, never to grind defences.
3. **Not there? No disaster.** If the player skips a defence, it **auto-resolves** off-screen using the settlement's Safety, guards and any NPC adventurers there. Losses cost Prosperity (Wealth/Safety) and can damage buildings, but **a settlement is never destroyed and nothing is permanently lost** (Canon §5 Loss Rules). Damage is repairable. This must never feel like a chore in a 1,000-hour game.
4. **Defence is fun content, not filler:** build-up time to set traps, barricades, ballistae and hire guards (feeds Settlement Prosperity). Companions banter. NPC adventurers you've met fight beside you. Use the existing *Defense* quest type (waves · sabotage from inside · boss wave).
5. **The Tyrant:** a named boss with a lair, a Boss Suitability rating, and lieutenants or dens you can clear first. You can challenge it at any time (Canon: bosses are optional and rank-based).
6. **Liberation:** killing the Tyrant triggers a liberation scene and festival in the region's main settlement, a Prosperity jump, and a music change.
   - From then on the board offers hunting contracts: Subjugation, bounties, Named-monster hunts, escort and gathering.
   - Normal world events still happen (Stampedes, Calamities). Rare **remnant raids** can come back as story beats (e.g. Grukk the Younger's revenge), never as a recurring cycle again.
7. **Ring 1 / Brindlewick:** the **Goblin Chief of Hollowpine** is the proposed Tyrant of the Brindlewick area (Canon §6). Check this against its role as the F→E rank trial in `02_Lore/story.md`. If it clashes, propose an alternative in Canon §6. Propose Tyrants for every other region too, from existing bosses in `08_Bestiary/bosses_and_calamities.md` where possible.

### Data
- `Data/World/regions.json` and its schema: add `tyrantSpeciesId`, `siegeFaction`, `defenceSettlements` and `initialState`.
- New `Data/World/siege_waves.json` + schema: wave templates per faction × rank band (species IDs, counts, lieutenant, escalation step).
- The weekly board (`Data/Quests/weekly_board.json`, `11_Quests_Encounters/weekly_board.md`) already has a `regionState` field (`any`/`besieged`/`liberated`); use the same rule. On an attack day, post the defence as the top contract.
- Extend `Data/Quests/quests.json` + schema: a `siege_defence` quest type, plus a `regionState` condition so hunting contracts only appear when `Liberated` and defences only appear when `Besieged`.
- Validator: every Tyrant exists and is a unique species; wave species live in that region; every region has a Tyrant or is explicitly marked `noSiege` (e.g. Vesper, Labyrinth bands).

### C# (`Code/Ascend.Core`, engine-agnostic, time passed in, deterministic)
- `RegionThreat`: state machine (Besieged/Weakened/Liberated) plus escalation level.
- `SiegeScheduler`: given the day number, region and seed → whether an attack happens this week (1–2 per week, never on consecutive days), which settlement, which day and time, and with which wave set.
- `SiegeAutoResolve`: outcome and Prosperity/building damage from Safety + guards + escalation. It never destroys a settlement.
- Tests for all three, including that every 7-day week has 1 or 2 attacks and none on consecutive days.

---

## Part B — Fixes from the 2026-10-22 review
1. **StyleMeter:** cap `Points` a little above the SSS threshold (make the cap a tuning value), so decay works after long combos. Add a test.
2. **Reactions:** implement real Freeze (frozen status for `freezeDurationSec`; the next heavy hit shatters for `shatterBonus`) and the Storm Prison stun (`stormPrisonStunSec`). These tuning values are currently unused.
3. **Poise:** regenerate after a delay (new tuning values). Add a test.
4. **Loot:** switch from integer % weights to a decimal `chance` (so 0.001 chase drops are possible), and make luck a **multiplier**, not a flat add. Update the loot data, schema, generator and tests.
5. **Player side for Ring 0:**
   - Define how primary stats (STR/VIT/AGI/DEX/INT/WIS/LUK/CHA) turn into ATK/DEF/MATK/MDEF/HP/SPD.
   - Add an XP curve for levels 1–300 that fits Canon's level bands and pacing.
   - Add `Data/Classes/` with the Swordsman and its Ring 0 kit (Slash Chain, Rising Cut, Flash Step, Air Slash, Ultimate: *Thousand Petal Blade*).
   - Add schemas and C# models, and a test showing a level 1 player kills a goblin in a sensible number of hits.
6. **Ring 0 monsters:** spawn at F- (about level 3), or give them a level spread, so the `combat.md` §12 fun test ("dangerous at Lv 1, trivial at Lv 10") can work. Give the Horned Rabbit its own stats (faster, more fragile than the Goblin).
7. **Quest/NPC data model:**
   - Quests: add `prerequisites` (quests, flags, act, rank) and `setsFlags`.
   - NPCs: add `states` keyed by story flag (e.g. Mina → Lady Nocturne from Act III) and a simple `schedule`.
   - Update the validator.
8. **Boss HP:** add an explicit `bossHpMult` field instead of building it into base stats (Taurgrim, S rank, 708k HP, is 3× the strongest SSS species).
9. **Attack variety:** note in `monster_design_kit.md` that 125 species share Slash/Heavy Swing/Guard Counter. Add per-family signature attacks for at least the Ring 0–2 species.
10. **Repo hygiene:** stop committing generated files: `08_Bestiary/bestiary_viewer.html` and the CSVs. Either drop the CSVs or `.gitignore` them, and remove them from the index with `git rm --cached`. Keep the JSON.

---

## Part C — Weekly Board & Inns in code (data already exists)
1. **C# models** in `Code/Ascend.Core` for `Data/Quests/weekly_board.json` (schema `weekly_quest`) and `Data/World/inns.json` (schema `inn`). Load them in `GameDatabase`.
2. **Calendar:** a `GameCalendar` helper: day number → weekday (Solenday…Vexday), week number, time of day, from the 90-minute day in `combat_tuning.json` or a new `world_tuning.json`.
3. **`WeeklyBoard`:** given the day, region, its siege state and a seed → that dawn's board: the weekday's **Day Special** (once per week), **3 dailies** from that day's pool plus the `Any` pool, filtered by `regionState` (`besieged` / `liberated`) and time of day. On a siege attack day, the defence goes on top.
4. **`InnStay`:** room tier → rest buff and duration (Rested / Well Rested, + meal and bath bonuses from `inns.md` §2), and **regular status** from nights stayed (Stranger 0 · Guest 3 · Regular 10 · Family 30 + quest flag). Marta's **tab**: a credit limit at F–E rank that never blocks anything.
5. **Tests:** every weekday produces a special plus 3 dailies; Besieged-only quests vanish after Liberation and hunting contracts appear; a Day Special can't repeat in the same week; rest buffs stack correctly; regular thresholds work.

---

## Finish
- Run `npm run build` (it regenerates, validates and runs the tests). If no .NET SDK is reachable from your shell, say so and leave the tests for me to run with `npm test` on Windows.
- Siege/Liberation, the 7-day week and inns are already in Canon (§2, §4b, §4c). Update Canon only if something changes. Add a `CHANGELOG.md` entry for **v0.11** and update the README index.
- Don't write new lore, NPCs or quests in this session; it's code and data only. Ring 0 is still the priority.
- End with a short summary: what changed, what needs my OK, and the next step.
