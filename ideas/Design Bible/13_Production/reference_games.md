# Reference games

Ideas borrowed from games on the E: drive and from your own earlier projects. **Rule:** from other studios' games we take mechanics, patterns and orders of magnitude only — never their code, art, text or data files (AETHWYRD is a commercial Steam game; their code is proprietary). Your own projects (Project Greyborn) can lend code as well as ideas. Each entry says what we took, where it went, and what's left to consider.

## RimWorld (Ludeon) — read from its plain-text Defs (data, not code)

**What we looked at:** taming fields on the 61 core animals — `wildness` (0 for cats and cows … 0.985 for the thrumbo), `trainability` (none / intermediate / advanced), `manhunterOnTameFailChance` (0 for most prey, 0.1–0.4 for predators, 1.0 for the emu), `nuzzleMtbHours` (pets nuzzle colonists every ~12 h on average).

**Taken (built 2026-10-24):**
- **Wildness by behaviour** — `world_tuning.json → taming.wildnessByBehavior` (Passive 0.2 … Aggressive 0.85), subtracted from the offer chance × `wildnessWeight`. A lantern moth is now easier to win over than a forest wolf at the same rank.
- **Temper on a failed offer** — `enrageByBehavior` replaces the flat 35%: a moth never turns on you, a skittish boar bolts (5%), a pack hunter fights back 40%, an aggressive one 50%.
- **Nuzzling** — partners come over to nuzzle you now and then (mean `nuzzleEveryMinutes` = 8 real minutes, exponential so it feels spontaneous); it counts toward Bond like a shared win.

**Built since:** partner orders (Z / LB cycles Follow → Hold → Focus) limited by **trainability by family** (`taming.trainabilityByFamily`: beasts, birds and dragons learn all three; slimes, insects and spirits Follow and Hold; plants only Follow).

**To consider:** RimWorld's "bonded animal" grief when a partner is released could feed the Karma/Thread effect in systems.md §7.4.

## Project Greyborn (yours) — `E:\project-greyborn\game\src\sim\botAI.ts`

Your 4v4 evolution PvP game (TypeScript, three.js). Being yours, its code can be ported, not just its ideas.

**Taken (built 2026-10-24):**
- **Unsticking** (`goTo`): a bot that's barely moved for a couple of seconds sidesteps perpendicular to its path. Ported to `MonsterController.Unstick`: after 1.5 s stuck, a monster walks sideways for 1.2 s, alternating sides — a goblin that hits a short wall head-on now works its way round instead of standing pressed against it.
- **Reflex hop** (`combatReflexes`): a badly hurt bot that was just hit sometimes evades. Ported as a hop back for skittish and ambushing monsters below 40% HP (25% per hit); aggressive ones stand their ground.

**To consider:**
- **Utility goals with hysteresis** (`think`): score every option, add a little noise and a bonus for the current goal so bots don't flip-flop. A good fit for partner AI once partners choose between fighting, fetching, scouting and following.
- **A path budget** (`pathBudget`): at most a few A* searches per tick, so many monsters repathing at once can't cause a hitch — needed when Ring 1 gets a navmesh.
- ~~**Fight-or-flee odds**~~ — **built:** pack and swarm monsters (105 species by their aiPattern) cry out when hit, so their own kind within 12 m join in even from beyond their alert radius; a pack hunter left alone below half HP falls back home.
- **Evolution stages by level** (`formForLevel`, `stageForLevel`): Greyborn's three stages over 20 levels map naturally onto the Reborn Monster origin in `04_Classes/monster_evolution.md`.

## Grounded (Obsidian) and Subnautica (Unknown Worlds) — mechanics from play, not files

Both ship compiled, so these are the design patterns, from how the games play.

**Taken (built 2026-10-24):**
- **Discover recipes by handling materials** (Grounded's resource analyzer, Subnautica's scanner), shaped to our own rule in `09_Equipment/item_and_economy_design.md` §6.2 ("known / hypothesis / missing clue", "optional experimentation"): once you've held every material a recipe needs, you get an *idea* toast; at the right station you can **experiment** — the materials are used, you make the item and learn the recipe for free. The teacher's paid lesson stays as the other route (§6.1: at least two routes per step). Experimenting also counts as learning a life skill for the F→E promotion.

**To consider:** Grounded's tiered tool unlocks (a better axe opens a harder node) for gathering; Subnautica's depth-gated materials as Whisperwood's deeper camps' unique drops; Grounded's base-defence raids already exist here as sieges.
