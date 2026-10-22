# Session Prompt — v0.11: Review Fixes + Regional Siege System

You're working on **Project Ascend**, a single-player 3D open-world isekai RPG (Unity 6, data-driven JSON), in the folder `E:\Ideas\Project-Ascend` (a Git repo). Read `README.md`, `Canon.md` and `CHANGELOG.md` first. **Canon.md wins every conflict.** I'm the creative director and I prefer you to decide and build rather than ask. Flag anything that needs my OK in `Canon.md` §6 (Proposed Locks) and keep going. Keep docs concise.

Do the work in this order. Commit after each part.

---

## Part A — New feature: Regional Siege → Liberation

**The rule:** every region has a **Tyrant**, its "big bad". Until the Tyrant is slain, the region is **Besieged**: its settlements (cities, towns, villages) face **daily defence events**. Once the Tyrant dies, the region becomes **Liberated**: daily defences stop, and the region's quest board switches to normal **monster-hunting contracts**.

### Design (write it into `12_Systems/systems.md` as a new section "Regional Siege & Liberation", and link it from `11_Quests_Encounters/quests_and_encounters.md`)
1. **Region states:** `Besieged` → `Liberated` (permanent). Optional middle state `Weakened` once the Tyrant's lieutenants/dens are cleared (defences get easier).
2. **Daily defence:** once per in-game day (90 real minutes, Canon), one settlement in a Besieged region is attacked, usually at dusk. It's posted on the guild board and the rumor board, with a warning a few in-game hours ahead.
   - Waves are themed to the Tyrant's faction (e.g. goblin warbands for a goblin Tyrant). They scale to the region's rank band, and the last wave has a lieutenant.
   - Target length: 5–8 minutes. Rewards: gold, GP, XP, Prosperity Safety, and settlement reputation.
   - **Escalation:** each day the Tyrant lives, its faction's strength rises a step, up to a cap. That pushes the player to go hunt the Tyrant, never to grind defences.
3. **Not there? No disaster.** If the player skips a defence, it **auto-resolves** off-screen using the settlement's Safety, guards and any NPC adventurers there. Losses cost Prosperity (Wealth/Safety) and can damage buildings, but **a settlement is never destroyed and nothing is permanently lost** (Canon §5 Loss Rules). Damage is repairable. This must never feel like a chore in a 1,000-hour game.
4. **Defence is fun content, not filler:** build-up time to set traps, barricades, ballistae and hire guards (feeds Settlement Prosperity). Companions banter. NPC adventurers you've met fight beside you. Use the existing *Defense* quest type (waves · sabotage from inside · boss wave).
5. **The Tyrant:** a named boss with a lair, a Boss Suitability rating, and lieutenants or dens you can clear first. You can challenge it at any time (Canon: bosses are optional and rank-based).
6. **Liberation:** killing the Tyrant triggers a liberation scene and festival in the region's main settlement, a Prosperity jump, and a music change.
   - From then on the board offers hunting contracts: Subjugation, bounties, Named-monster hunts, escort and gathering.
   - Normal world events still happen (Stampedes, Calamities). Rare **remnant raids** can come back as story beats (e.g. Grukk the Younger's revenge), never as a daily cycle again.
7. **Ring 1 / Brindlewick:** use the **Goblin Chief of Hollowpine** as the Tyrant of the Brindlewick area (it fits "goblin raids grow organized"). Check this against its role as the F→E rank trial in `02_Lore/story.md`. If it clashes, propose an alternative in Canon §6. Propose Tyrants for every other region too, from existing bosses in `08_Bestiary/bosses_and_calamities.md` where possible.

### Data
- `Data/World/regions.json` and its schema: add `tyrantSpeciesId`, `siegeFaction`, `defenceSettlements` and `initialState`.
- New `Data/World/siege_waves.json` + schema: wave templates per faction × rank band (species IDs, counts, lieutenant, escalation step).
- Extend `Data/Quests/quests.json` + schema: a `siege_defence` quest type, plus a `regionState` condition so hunting contracts only appear when `Liberated` and defences only appear when `Besieged`.
- Validator: every Tyrant exists and is a unique species; wave species live in that region; every region has a Tyrant or is explicitly marked `noSiege` (e.g. Vesper, Labyrinth bands).

### C# (`Code/Ascend.Core`, engine-agnostic, time passed in, deterministic)
- `RegionThreat`: state machine (Besieged/Weakened/Liberated) plus escalation level.
- `SiegeScheduler`: given the day number, region and seed → which settlement is attacked, when, and with which wave set.
- `SiegeAutoResolve`: outcome and Prosperity/building damage from Safety + guards + escalation. It never destroys a settlement.
- Tests for all three.

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

## Finish
- Run `npm run build` (it regenerates, validates and runs the tests). If no .NET SDK is reachable from your shell, say so and leave the tests for me to run with `npm test` on Windows.
- Update `Canon.md` (Siege/Liberation rules go in §4 or a new section), add a `CHANGELOG.md` entry for **v0.11**, and update the README index.
- **Do not** add new Ring 1 lore, NPCs or quests beyond what Part A needs. Ring 0 is the priority.
- End with a short summary: what changed, what needs my OK, and the next step.
