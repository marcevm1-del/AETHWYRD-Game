# Combat and Hunts in Open World RPGs

## How can Ascend make flashy melee combat readable and satisfying while keeping parry optional?

### Takeaway
Build combat around a small set of legible enemy tells, strong hit feedback, and multiple defensive answers. Treat parry as a high-skill reward layered over a dependable dodge, guard, spacing, and recovery loop; never make required progression depend on parry success.

### Cited Findings
- Sandfall Interactive described *Clair Obscur: Expedition 33* as a reactive turn-based RPG with real-time dodge, parry, and counter attacks. Its developers said balancing timing took iteration; the combat prototype combined real-time offense and defense, and successful parry sequences leading to counters felt rewarding. [Unreal Engine developer interview](https://www.unrealengine.com/developer-interviews/inside-the-development-journey-of-clair-obscur-expedition-33) (published 2025; page date not shown in search extract).
- In a developer interview about *Expedition 33*, the team described making combat audio cues consistent and adding an audio setting to raise battle sound effects relative to exploration, after recognizing those cues helped players time defense. [GamesRadar interview](https://www.gamesradar.com/games/rpg/parrying-was-not-easy-clair-obscur-expedition-33-devs-had-to-turn-to-sound-to-fix-an-integral-part-of-the-jrpgs-combat/) (2025; exact date should be checked on page).
- *Dragon’s Dogma 2*’s official manual describes distinct defensive affordances by vocation: Fighter can defend and carefully timed blocks deflect attacks; Mage’s Swift Step evades. This is an official example of distinct combat identities that do not all require a parry. [Official manual: Vocations](https://game.capcom.com/manual/dd2/en/ps5/page/1/5) (accessed 2026-10-23; page publication date not stated).
- *Granblue Fantasy: Relink*’s official manual says attacks build an enemy stun gauge; filling it creates a Link Chance for a coordinated Link Attack, and shared Link Gauge can trigger Link Time. This makes team coordination and offense feed a conspicuous payoff loop. [Official online manual: Battles](https://relink.granbluefantasy.jp/manual/detail?s=battles) (accessed 2026-10-23; page date not stated).
- *Final Fantasy XIV*’s official battle guide describes melee as close-range combat emphasizing combos and careful positioning. [Official Job Guide](https://na.finalfantasyxiv.com/jobguide/battle/) (live guide; accessed 2026-10-23; current guide says updated for Patch 7.5).

### Inferences
- **Inference — readable action grammar:** Give each threat a few attack families with consistent wind-up, silhouette, sound, and recovery. Vary timing and follow-ups within that grammar; avoid changing the visual language every time an attack’s damage tier changes.
- **Inference — fair optional parry:** Every mandatory attack should have at least one non-parry answer (dodge/step, guard, move out of range, interrupt, or use cover). Parry may grant a counter window, stagger, rank progress, or style score, but should not be the only way to avoid unavoidable damage or unlock a mandatory gate.
- **Inference — small-team scope:** Make one shared combat readability checklist for all enemy attacks: anticipation, active danger, recovery, hit reaction, audio cue, and at least one viable counter. Reuse a limited set of animation/cue patterns across monster families, then differentiate with timing, area shape, and behavior.
- **Inference — flashy without noise:** Reserve the brightest effects for high-value state changes (guard break, wound, stagger, ally link, boss phase); keep ordinary hits visually quieter so rank-readable threats and enemy tells survive visual spectacle.
- **Inference — accompaniment:** Companions can call out a move family or create an opening, but should not solve the defense puzzle automatically. Give companion help readable setup and cooldowns so their intervention supports player agency.

### Gaps
- Official *Expedition 33* material reviewed here does not quantify timing windows, accessibility options, or whether every encounter has a non-parry solution. Avoid presenting those as established facts.
- No official source located in this bounded pass directly compares parry-only and non-parry completion rates across the cited games.

## How should hunts reward investigation and ecology, not just repeated kills?

### Takeaway
Make observation useful in the next encounter: species behavior, time, weather, tracks, wounds, feeding, and territory should provide actionable predictions or routes. Let investigation produce both knowledge and practical preparation, and make the ecosystem legible through repeated behaviors rather than a large simulation burden.

### Cited Findings
- The official *Pokémon Legends: Arceus* gameplay page says species differ in disposition (some attack, others flee), some species or behaviors depend on time and weather, and observation helps players choose an approach. Research tasks improve Pokédex entries and team rank, which unlocks new areas. [Official gameplay page](https://legends.arceus.pokemon.com/en-us/gameplay/) (2022 game launch era; page date not shown).
- The same official page describes seamless transitions into battles, base camps for rest and crafting, and stealth tools such as smoke bombs that reduce visibility to aid approach. This supports a hunt loop that includes scouting, approach choice, and field preparation. [Official gameplay page](https://legends.arceus.pokemon.com/en-us/gameplay/) (page date not shown).
- Capcom’s official *Dragon’s Dogma 2* manual describes the Simple pawn inclination as observant of surroundings and oriented toward exploration and gathering; other inclinations prioritize support, survival, or direct aggression. [Official manual: Pawn Inclinations](https://game.capcom.com/manual/dd2/en/ps5/page/4/2) (accessed 2026-10-23; page date not stated).
- A PlayStation starter guide for *Monster Hunter Wilds* explains that Focus Mode highlights wounds for Focus Strikes, which destroy wounds, stun the monster, and award bonus resources; it also notes that resting can change environment/time and help trigger particular monsters and endemic life. [PlayStation starter guide](https://www.playstation.com/en-us/games/monster-hunter-wilds/monster-hunter-wilds-starters-guide/) (accessed 2026-10-23; page date not shown). This is a platform-holder guide, not a Capcom developer talk.

### Inferences
- **Inference — investigation should change decisions:** Use a compact field journal with observable evidence (tracks, calls, feeding remains, terrain marks) that unlocks predictions such as likely route, aggression trigger, vulnerability window, or weather preference. Avoid purely collectible lore that has no gameplay consequence.
- **Inference — ecology on a two-person budget:** Author a small number of behavior rules per species (territory, prey/food, flee-or-fight response, one interaction with another species) and reuse them across time/weather variants. Show ecological relationships through occasional authored encounters instead of simulating a full food web continuously.
- **Inference — hunt variation without grind:** Give an investigation objective optional completion routes: follow sign, observe a behavior, use a prepared lure, or take the direct fight. All should contribute to a hunt record; a failed or interrupted hunt should retain discovered clues.
- **Inference — rank readability:** Let investigation reveal a monster’s threat rank and behavior tells before engagement, then present an in-combat indicator for the current danger state. Separate rank from raw health: rank should guide preparation and signal expected move complexity, not serve as an opaque damage wall.
- **Inference — companion contribution:** Allow a companion to notice or interpret one clue, track a fleeing target, or create a brief opening. Keep the same information discoverable by the player to avoid companion dependency.

### Gaps
- The official sources reviewed do not provide granular documentation of *Monster Hunter*’s full ecology simulation, its design costs, or exact research mechanics. The *Wilds* guide is a secondary platform guide, so its specific mechanics should be verified against in-game documentation before implementation.
- No exact numerical evidence was found here for how much ecology or investigation reduces repetitive hunts.

## How can Ascend sustain a very long progression path without turning it into grind?

### Takeaway
Use long progression as a sequence of meaningful capability and knowledge unlocks, not a single steep XP curve. Make several kinds of play advance durable goals, let players choose how to spend effort, and keep old regions or hunts useful through new information and optional challenges rather than mandatory repetition.

### Cited Findings
- *Pokémon Legends: Arceus* ties research tasks to Pokédex completion and Galaxy Team rank; rank grants access to new areas. Its tasks include observing and interacting with species rather than only defeating them. [Official gameplay page](https://legends.arceus.pokemon.com/en-us/gameplay/) (page date not shown).
- In a July 5, 2024 developer discussion, HoYoverse said *Genshin Impact* would let daily Encounter Points accumulate as Long-Term Encounter Points, then convert them into usable points by spending Original Resin. The stated change lets accumulated activity count toward daily reward claims later. [Genshin Developers Discussion](https://genshin.hoyoverse.com/en/news/detail/124539) (2024-07-05).
- The official *Genshin Impact* Version 4.8 update details specify that long-term points persist until the next Version x.0 and are converted by consuming Original Resin. [Version 4.8 update details](https://genshin.hoyoverse.com/m/en/news/detail/124837) (2024; page lists Version 4.8 update details).
- *Final Fantasy XIV*’s official manual documents Duty Support, which allows certain instanced duties to be entered with NPC allies, and Hall of the Novice training exercises for basic combat roles. [Duty Support manual](https://na.finalfantasyxiv.com/game_manual/dutysupport/) and [Game Manual](https://na.finalfantasyxiv.com/game_manual/) (accessed 2026-10-23; manual updated 2026-10-13 per page metadata). These are accessibility/onboarding patterns, not evidence of a specific progression curve.
- *Dragon’s Dogma 2*’s official manual says the four starting vocations have distinct strengths and weaknesses and can be changed at a vocation guild. [Official manual: Vocations](https://game.capcom.com/manual/dd2/en/ps5/page/1/5) (accessed 2026-10-23; page date not stated).

### Inferences
- **Inference — progression architecture:** Separate the “long path” into three tracks: character mastery (new moves/combos), hunting knowledge (rank intel, behavior clues, investigation tools), and expedition access (regions, routes, companion capabilities). Give each track visible, bounded milestones so the player can see progress without facing an enormous anonymous level counter.
- **Inference — reduce grind pressure:** Let combat, tracking, discovery, helping a companion, crafting from found materials, and completing a hunt objective each advance at least one durable track. Repeatedly killing the same species should be one valid path, not the uniquely efficient path.
- **Inference — respect missed sessions:** Use a capped carryover or “field study credit” system for unspent daily/weekly progress. It should preserve effort and permit flexible play; it should not require a currency conversion that creates a new recurring chore.
- **Inference — two-person content strategy:** Use a small number of progression currencies and avoid per-monster bespoke skill trees. A reusable reward table can grant materials, mastery points, and research evidence according to actions performed, with a few authored milestones for each major species/region.
- **Inference — retain meaningful challenge:** Add optional mastery goals (clean hunt, no healing, environmental takedown, companion-assisted investigation) that grant cosmetic, knowledge, or convenience rewards. Keep mandatory progression achievable through ordinary combat and non-parry strategies.

### Gaps
- No official sources reviewed establish a universal formula for a satisfying very long leveling path, or directly measure grind perception. The recommendations above are design inferences, not claims about what any cited developer explicitly endorses.
- The official sources describe systems and affordances, but do not provide development effort estimates; the two-person scope guidance is a production inference.
