# Reference games

Ideas borrowed from games on the E: drive and from your own earlier projects. **Rule:** from other studios' games we take mechanics, patterns and orders of magnitude only — never their code, art, text or data files (Project Ascend is a commercial Steam game; their code is proprietary). Your own projects (Project Greyborn) can lend code as well as ideas. Each entry says what we took, where it went, and what's left to consider.

## RimWorld (Ludeon) — read from its plain-text Defs (data, not code)

**What we looked at:** taming fields on the 61 core animals — `wildness` (0 for cats and cows … 0.985 for the thrumbo), `trainability` (none / intermediate / advanced), `manhunterOnTameFailChance` (0 for most prey, 0.1–0.4 for predators, 1.0 for the emu), `nuzzleMtbHours` (pets nuzzle colonists every ~12 h on average).

**Taken (built 2026-10-24):**
- **Wildness by behaviour** — `world_tuning.json → taming.wildnessByBehavior` (Passive 0.2 … Aggressive 0.85), subtracted from the offer chance × `wildnessWeight`. A lantern moth is now easier to win over than a forest wolf at the same rank.
- **Temper on a failed offer** — `enrageByBehavior` replaces the flat 35%: a moth never turns on you, a skittish boar bolts (5%), a pack hunter fights back 40%, an aggressive one 50%.
- **Nuzzling** — partners come over to nuzzle you now and then (mean `nuzzleEveryMinutes` = 8 real minutes, exponential so it feels spontaneous); it counts toward Bond like a shared win.

**To consider:** a per-species `trainability` that limits which partner orders a species can learn (Vanguard taunt, Scout call-outs) once partner commands exist; RimWorld's "bonded animal" grief when a partner is released could feed the Karma/Thread effect in systems.md §7.4.
