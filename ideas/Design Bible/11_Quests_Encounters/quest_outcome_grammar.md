# Quest Outcome Grammar: Many Approaches, Bounded Branches

> **Proposal.** This document expands the player's request for anime-variety contracts, mystery, social choices and visible consequences. Canon still governs story, ranks, siege and loss rules.

## The promise

A quest should feel personal because someone wants something, the player discovers what is really happening, and the resolution changes a relationship or place. Variety comes from changing the motive, evidence, encounter and aftermath—not from branching every line into an unmanageable tree.

Obsidian's *Avowed* developers describe designing choices across short, medium and long horizons, giving players room to discover while layering hints when a solution becomes too obscure. Their account also stresses foreshadowing major consequences so outcomes feel earned. ([Xbox Wire, Jan 24 2025](https://news.xbox.com/en-us/2025/01/24/avowed-choose-your-own-adventure-incredible-freedom/))

**Ascend inference:** use a stable quest spine with a few meaningful approach verbs, then let a compact outcome record drive authored receipts. Each quest need not have a completely separate story for every method.

## The quest spine

### 1. Offer

Show who posted the request, what they want, their offered reward, the rank estimate, known time pressure and whether it is repeatable. A small request may be emotionally personal without pretending to be a world-ending mystery.

### 2. Establish facts and gaps

Separate confirmed facts, witness claims, rumors, and unknowns. The player can take a job with incomplete information. A rumor can be wrong, but its source and age should make the uncertainty fair.

### 3. Let the player choose a method

Select only methods that fit the scenario. Common verbs:

- fight;
- investigate or track;
- talk, bargain or persuade;
- sneak or misdirect;
- prepare a tool, meal or counter;
- protect, rescue or escort;
- retreat, report or renegotiate.

Two or three supported methods are usually enough. The quest card may suggest methods without implying the list is exhaustive.

### 4. Change the situation

The action changes a local condition: threat contained, witness protected, evidence recovered, trust gained/lost, settlement safe, creature displaced, contract delayed or promise upheld. Record causes explicitly.

### 5. Resolve and return a receipt

Show what changed at the moment it happens, then later through an appropriate channel: NPC reaction, companion opinion, guild record, rumor, new service, changed patrol, settlement cue or story callback. A small personal quest may need only a conversation and one board update.

## Consequence horizons

| Horizon | Examples | Authoring pattern |
|---|---|---|
| Immediate | New dialogue, combat behavior, companion objection, item consumed | State tag + concise reaction |
| Quest-local | Who is rescued, what evidence survives, reward or method unlocked | One of a few resolution records |
| Regional | Safety, trust, a service, patrol or event changes | Small region-state delta and visual receipt |
| Long arc | Companion departure, alliance, act beat or ending evidence | Explicit prerequisite/flag and authored scene |

Do not make every task affect every horizon. Small jobs create texture; major decisions earn long-term consequence.

## Outcome record

A data-driven quest can store:

- `approach`: combat, investigation, social, stealth, preparation, rescue, mixed;
- `resolution`: solved, contained, negotiated, rescued, failed-forward, abandoned, unresolved;
- `evidence`: facts learned, sources, confidence and surviving proof;
- `costs`: time, consumables, injury, debt or damaged relationship (only if signposted);
- `beneficiaries` and `burdenedParties`;
- `flagsSet` and `flagsCleared`;
- `rewardBand` and explanation;
- `receipts`: immediate, local and delayed feedback;
- `recoveryRoute`: what remains possible after failure or departure.

This keeps the state legible to writers and developers. It is not intended to expose a moral score to the player.

## Failure that stays playable

- **Routine contracts:** remain available or return to the board; a small fee or trust consequence can apply only if clearly disclosed and consistent with guild rules.
- **Time-sensitive contracts:** say what is at risk and when; do not use real-world timers.
- **Failed investigations:** preserve evidence, allow another lead, or shift to a riskier direct method.
- **Failed defense:** resolve off-screen without settlement destruction; repair and recovery remain possible under Canon.
- **Abandoned promises:** companion or NPC trust changes after discussion and context, not a silent global penalty stack.
- **Main-story failure:** provide a recovery path, alternate route or clearly signposted ending; never silently make the save unwinnable.

The player's earlier preference for gold penalties or guild demotion on abandonment remains a design question; use proportionate consequences and test if those punishments feel fair before locking them.

## Quest families and anime rhythm

A board should mix these tones across a week:

- **Warm everyday request:** food, repair, medicine, an errand or family concern.
- **Adventure mystery:** unclear tracks, contradictory reports or an unknown threat.
- **Action challenge:** elite hunt, defense, tournament, dangerous escort.
- **Social complication:** a dispute between people with understandable motives.
- **Wonder:** unusual ecology, living dungeon, shrine, old-world relic or strange sky event.
- **Emotional promise:** protect, reconcile, remember, reveal or let go.
- **Comic relief:** character-driven and brief; no constant quips.

A satisfying episode often combines ordinary stakes with one surprising turn. Do not force every contract to become a tragedy or a secret conspiracy.

## Companion integration

Companions can express interest, share expertise, object or offer an approach. Use eligibility and cooldowns; do not require every companion to comment on every quest. Their opinion can reflect values without changing a hidden approval bar every time. The player can ask why, agree, disagree or move on.

For large decisions, give the player enough context to understand who could be affected, while allowing uncertainty about exact outcomes. This keeps the world mysterious without making consequences arbitrary.

## Ring 0 vertical slice

Use *Goblins in the Granary* or *Slime in the Well*:

1. Requester has a personal motive and incomplete facts.
2. One observation distinguishes fresh evidence from an old clue.
3. Player can track, prepare or go directly to combat.
4. One companion has a distinct opinion but does not block the quest.
5. The encounter has a safe resolution and a faster risky resolution.
6. Both resolutions complete the contract; outcomes alter one line, reward detail or local cue.
7. Failure/retreat preserves a next step.

Measure whether new players can state what the requester wanted, what they discovered, why they chose their approach and what changed afterward.

## Related files

- [[quests_and_encounters]]
- [[weekly_board]]
- [[reactive_world_and_field_journal]]
- [[signature_gameplay_loops]]
- [[Canon]]