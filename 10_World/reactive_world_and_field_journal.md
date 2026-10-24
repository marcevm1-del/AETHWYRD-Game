# The Field Journal and the World That Remembers

> **Proposal; not canon.** This design connects exploration, monster research, hunts, local consequences and liberation. It is deliberately small enough to prototype in Ring 0 before it grows into a world-wide content promise. Shared information provenance and consequence receipts are expanded in [[world_response_and_information_flow]].

## Design promise

Aetheria should reward attention. The player sees a disturbed fence, hears a villager's version, compares it with a monster's tracks, then chooses whether to prepare, ask around, follow the trail or simply go fight. The game should preserve what the player actually learned and make its next response understandable.

The journal is a field notebook, not an omniscient quest log. It separates direct observation from testimony and inference. NPC memory is local and plausible, not a magical global reputation feed. A region's state is expressed through a small number of readable changes rather than hidden simulation meters.

## The core loop

### Returning after a break

Offer a compact, opt-in **Welcome Back** recap on load or from the journal: current region/state, the last major outcome and its known cause, active promises/quests, the player's pinned lead, and one or more next-step choices. Keep it limited to already discovered information; do not reveal hidden quest stages, secret identities, unrevealed causes, or future consequences. Distinguish observed facts, reports and hypotheses, and let the player dismiss or reopen the recap. Recaps must not invent urgency from elapsed real-world time. The shared provenance framework is in [[../01_Core_Concept/world_response_and_information_flow]].

1. **Notice:** world, NPC, weather, sound, prop, track or monster produces a cue.
2. **Record:** the journal captures source, time, place and confidence.
3. **Interpret:** player or companion connects evidence to a known behavior, habitat, weakness or social fact.
4. **Choose:** follow a broad lead, prepare a counter, ask a witness, use stealth, craft a tool or fight directly.
5. **Resolve:** encounter and quest systems produce a result; no single deduction is required to finish ordinary content.
6. **Remember:** relevant witnesses, settlement state, bestiary knowledge and quest flags update.
7. **Show receipt:** dialogue, board entries, patrols, props, routes or encounters make the result legible.

The loop should feel like discovery and adventure, not paperwork. Most entries are automatic and concise. The player may pin, compare or dismiss a lead, but is never asked to manually sort hundreds of clues.

## Field journal architecture

### Evidence record

Each clue has a stable identifier and compact fields:

- `id`: stable content key.
- `subject`: species, person, place, event or unknown.
- `sourceType`: observed, testimony, document, appraisal or companion interpretation.
- `sourceId`: the NPC, object, event or system that supplied it.
- `regionId` and optional location cell.
- `timeWindow`: exact time when meaningful, otherwise day/season/weather band.
- `confidence`: confirmed, corroborated, plausible, disputed or rumor.
- `evidenceTags`: tracks, feeding, damage, sound, residue, testimony, elemental trace, behavior.
- `supports` / `contradicts`: hypothesis IDs; never silently overwrite conflicting testimony.
- `reusableRuleId`: optional general rule taught by this clue.
- `questFlag`: optional progression consequence, only when authored.

The data is authored once and referenced by quests, species, regions and NPC dialogue. Do not duplicate whole paragraphs in every system. Player-facing text stays short; opening an entry gives source context and an actionable interpretation.

### Confidence and disagreement

- **Observed:** directly witnessed, measured or examined by the player.
- **Corroborated:** independent clues support the same reading.
- **Plausible:** a reasonable inference with incomplete evidence.
- **Disputed:** credible sources or clues conflict.
- **Rumor:** a lead that might be false or stale.

A confidence label is about evidence quality, not a moral judgment of the speaker. Named NPC testimony can be mistaken for understandable reasons: poor visibility, fear, a lie, old information or unfamiliarity with the creature. The UI should show why two accounts disagree and when each was recorded.

### Hypotheses, not answer keys

A hypothesis can state: likely species family, possible den area, likely active time, observed elemental behavior and a suggested counter. It must distinguish what was observed from what the system inferred. The journal may offer multiple plausible hypotheses. Appraisal can refine them according to class, skill and knowledge, but it should not reveal every answer at level one.

A player can reject the suggestion and fight anyway. Incorrect preparation costs time or consumables, not access to the main story. A failed inference should produce new evidence, not a dead end.

## Monster research and hunt integration

Every shipped species needs a lean field-research packet:

- two or three evidence motifs shared with its family;
- one signature behavior that can be observed in the world;
- one variable (time, weather, region state or injury) that changes that behavior;
- one or two counters or approach advantages;
- one common misreading or rumor, optional by story importance;
- a hunt-resolution hook that retains evidence on retreat or failure.

Research tiers can be: **Unseen → Encountered → Observed → Understood → Mastered**. They unlock at most a small number of practical facts each: silhouette/name, habitat and rank band, signature behavior, known counters and materials/variant notes. No tier should require killing a talking or socially organized creature when the quest supports another resolution.

Evidence can be gathered by looking, tracking, hearing, surviving a move, observing feeding, questioning a local, examining damage or using a class skill. Give overlapping routes so a player who misses one clue can keep moving. No clue requires color vision alone or a frame-perfect camera angle.

### Ecology stays bounded

The world can feel alive with local rules rather than a continuous ecosystem simulation. A species can be represented by a small state set: resting, feeding, hunting, sheltering, migrating, guarding a nest or responding to siege. Trigger state changes from time, weather, population pressure, story flags and authored events. Use a population-pressure value only where it visibly affects migration, encounter likelihood, drops or community safety.

Player-driven ecology change should have a limit and a recovery path. Removing common predators can increase prey sightings or crop damage; overhunting a rare species can reduce its contracts and materials until seasonal recovery. Avoid irreversible species extinction in ordinary play. The player can learn the effect and help restore a healthier balance. Intelligent communities use diplomatic, legal and story consequences in addition to ecology consequences.

## NPC memory and rumor travel

### Finite event memory and local response bundles

Use the shared finite event record in [[../01_Core_Concept/world_response_and_information_flow]]: source, place/time, confidence/evidence, plausible audience and propagation route, allowed responses, and a player-facing receipt. NPCs do not receive a generic reputation update; a witness, party member, board, courier, merchant route or authored public event must carry the fact. Record reports separately from the underlying event, retain meaningful disagreement, and age only volatile conditions (such as a route hazard), never historical facts. Resolve delayed responses by in-game ticks and stable result IDs so save/load cannot duplicate a reward or receipt.

Liberation and quest outcomes should select reusable **local response bundles** from that shared framework. Bundles combine only justified local slots—route/environment, patrol or encounter pressure, service, board/rumor, ambient/social cue and journal receipt—while preserving region-specific authored details. Liberation ends siege pressure permanently as Canon states; it does not erase ordinary danger or grief. Missed defenses still auto-resolve, settlements are never destroyed, and no bundle may override Canon §5's opt-in death and recovery protections.

### Memory tiers

1. **Scene-critical:** unique story state and authored dialogue; always preserved.
2. **Nearby named NPC:** schedule, relationship, current need and a few recent relevant events; reacts when the player can interact.
3. **Distant named resident:** compact durable facts plus clock-driven schedule/state changes; no expensive per-frame simulation.
4. **Background population:** settlement-level aggregates such as safety, prosperity, work, fear and celebration.

A character's simulation tier may change with distance, but story facts cannot disappear during that transition. An injured resident must not resume a normal routine until the injury state resolves. Critical state has precedence over schedule.

### Witness plausibility

A public action creates a witness event only for NPCs who could plausibly perceive it. Use sight, sound, proximity, publicness and occlusion bands rather than full forensic simulation. A witness record includes the event, approximate time, confidence and emotional valence. A witness may misidentify details; do not make uncertainty a random punishment.

Rumors propagate through explicit channels: household, guard report, guild board, merchant route, temple, clan messenger or local conversation. Channels have reach and delay. A remote settlement should not know instantly. On arrival, the player can hear versions with source and age; the journal preserves contradictions until resolved.

Important outcomes should produce a player-facing receipt within a suitable horizon:

- immediate: nearby reaction, guard intervention, companion response;
- same day: local rumor, board update, service refusal or thanks;
- later: traveler's report, regional dialogue, changed patrol or quest;
- major story: a visible settlement or faction state and an authored scene.

Failure consequences can be serious, but never imply a choice was consequential if the game did not signal the stakes. Critical path recovery, alternatives or a deliberate ending prevent a missed quest from silently bricking a long save.

## Liberation delta

For each siege-enabled region, author a compact before/after package:

- one route state: patrol restored, gate reopened, bridge repaired or safer approach;
- one settlement routine: guards, market, work crew or festival changes;
- one board/rumor state: defence notices stop and liberated-region contracts appear;
- one encounter rule: faction pressure falls; ordinary ecology remains;
- a small set of ambient barks, props, color/light and music transitions;
- one optional remembrance beat if losses or promises matter.

The settlement is never destroyed. Damage is repairable, and the player can see recovery progress. The package is data-driven and reuses rigs, props, schedules and dialogue templates, but the region's silhouette and cultural details stay distinctive.

Liberation is not a management phase. The player does not have to budget every building or assign every villager. Prosperity and safety summarize authored consequences; optional restoration quests provide direct agency.

## Quest authoring patterns

Use a shared quest grammar that supports different anime-adventure moods:

- a simple request with a personal reason;
- an uncertain threat with incomplete facts;
- a hunt whose public rank estimate is deliberately conservative;
- a rescue with route and preparation choices;
- a social dispute with witnesses who disagree;
- a monster-community negotiation;
- a seasonal festival or tournament;
- a defense event that auto-resolves safely if ignored;
- a companion promise that can be kept, renegotiated or broken;
- a multi-stage mystery where clues recontextualize the first request.

Every quest should state what is known, what is hidden, what methods work, what failure changes, what remains available and how the world reports the outcome. Avoid making every ordinary contract secretly a catastrophe: quiet requests make major revelations land harder.

## Production and validation rules

- Author a Ring 0 vertical slice before extending data to all regions.
- Every evidence item references an existing species, NPC, region, quest or flag.
- Every hypothesis is supported by at least one evidence route and has a fallback route.
- Every witness event specifies plausible audience and propagation channels.
- Every major consequence has an authored receipt and a recovery/ending rule.
- Every liberation delta changes at least two perceivable channels and never contradicts settlement no-destruction canon.
- Keep simulation state finite, serializable and deterministic where possible.
- Add a debug view showing why the journal chose a hypothesis, why an NPC reacted, and which liberation delta is active.
- Track content coverage in a data report, not a giant hand-maintained checklist.

## Ring 0 prototype

Use the Blue Slime, Goblin and Horned Rabbit in and around Brindlewick:

1. Let a resident report a damaged grain store without naming the culprit.
2. Put tracks and slime residue on different approaches; one is misleading because it is old.
3. Let a companion point out a behavior after seeing it, while leaving the player free to ignore the clue.
4. Offer a direct fight and a prepared route with different cost/time/risk profiles.
5. Let a nearby witness react if the player creates danger in town; do not make distant NPCs instantly know.
6. Show a compact journal entry with source, confidence and reason for its hypothesis.
7. Verify that failure, retreat and alternate resolution preserve a playable next step.

The aim is not a large content volume. It is to prove that one clue changes what the player notices, one decision changes how an encounter feels, and one local outcome returns as visible world feedback.

## Options to consider later

These are separate proposals, not approved systems:

- **Field sketching:** photo-mode-like journal captures with a short visual annotation; no requirement to draw.
- **Companion expertise:** party members interpret different clue types based on origin/class and may disagree respectfully.
- **Guild research exchange:** turn duplicate specimens/materials into public safety notices or better contract estimates.
- **Regional almanac:** seasonal migration and weather calendars, unlocked through observation rather than full map reveal.
- **False lead stories:** rare authored misinformation with a discoverable source and fair correction; never used to trap a main quest.
- **Ethical hunt resolutions:** disperse, relocate, negotiate, capture or slay where the creature's intelligence and quest context justify them.
- **Accessibility journal mode:** stronger cue repetition, plain-language hypotheses, text log and no color-only evidence.
- **Post-liberation memory montage:** show a few captured scenes and named local changes after a major arc; keep it optional and save-aware.

## Risks and limits

Evidence can become clutter; cap active leads and group related observations. NPC memory can seem arbitrary; expose source, time and distance. Ecology can become a hidden chore; avoid decay timers that punish absence. Consequences can make players anxious; foreshadow stakes and provide recovery. Simulation can exceed the team's production capacity; use aggregate states and test one representative region before scaling.

The cited research supports the general design direction but does not establish ideal clue count, NPC memory size, encounter frequency, staffing or production cost. Those must be measured in Ascend's own playable slice.

## Related design and research

- [[exploration_and_discovery]]
- [[combat]]
- [[monster_design_kit]]
- [[systems]]
- [[open_world_rpg_research_2026]]
