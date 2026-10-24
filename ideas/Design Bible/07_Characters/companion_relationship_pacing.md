# Companion Relationships Across a Long Adventure

> **Proposal.** Companions are central to the emotional fantasy, remain AI-controlled, can challenge the player and may leave over consequential choices. This document offers a pacing and authoring structure; Canon and the user's roster/romance decisions remain authoritative.

## Relationship promise

A companion is a person with their own needs, history, limits and sense of humor. The player can become close, remain a trusted friend, disagree, reconcile, pursue romance where eligible, or part ways. The relationship should grow from what the pair actually experience, not from repeatedly selecting the most agreeable dialogue option.

Obsidian's *Avowed* team says companions react to side and main quests, express opinions, and can leave depending on how the player handles important choices. The interview also describes using short-, medium- and long-term consequence horizons and foreshadowing major outcomes. ([Xbox Wire, Jan 24 2025](https://news.xbox.com/en-us/2025/01/24/avowed-choose-your-own-adventure-incredible-freedom/)) Ascend can apply the principle while keeping its larger open-world structure: companions can comment on optional content, but the main plot must remain playable if the player travels elsewhere.

## Relationship dimensions

Do not reduce a companion to one visible like/dislike number. Store a small set of understandable relationship facts:

- **Trust:** do they believe the player will keep promises and protect confidences?
- **Respect:** do they recognize the player's judgment, skill or courage?
- **Closeness:** how much personal vulnerability and everyday life do they share?
- **Tension:** what unresolved disagreement or hurt remains active?
- **Romance path:** whether both characters have opted into a romantic relationship, where available.
- **Shared history:** a compact list of pivotal events, promises and rescues.

These are design categories, not necessarily displayed as meters. Dialogue can explain the reason behind a reaction. One kind of relationship does not automatically imply another: respect can coexist with disagreement; romance does not guarantee trust; close friends can remain nonromantic.

## Relationship event grammar

A durable relationship change should come from a meaningful beat:

1. **Context:** companion's value, current concern or promise is relevant.
2. **Choice:** player takes an action with understandable stakes.
3. **Immediate reaction:** companion speaks, acts or chooses silence.
4. **Interpretation:** the companion explains the reason if asked or when the moment permits.
5. **Follow-through:** later action, combat posture, personal scene or boundary reflects the event.
6. **Repair or acceptance:** where appropriate, player can apologize, make restitution, reaffirm the choice or accept lasting distance.

Do not award hidden relationship points for every line of banter. A single major choice can matter more than twenty agreeable responses.

## Companions challenge the player

Disagreement should reveal what the companion believes and what they fear losing. The companion can:

- question a risky contract or under-ranked boss;
- object to harming an intelligent creature or community;
- challenge a promise the player may be neglecting;
- disagree about guild, noble or religious authority;
- ask why the player chose a method when another was available;
- change their mind after evidence or consequences.

The companion's objection is perspective, not a hidden correct answer. The player can ask for the reasoning, disagree, compromise, postpone or reassure. Never have every companion converge on the same moral opinion.

## Pacing the long arc

Use distinct story temperatures rather than a constant stream of relationship scenes:

- **First impression:** competence, boundary or small kindness; not a biography dump.
- **Working trust:** shared task reveals values and practical habits.
- **Friction:** different beliefs create an earned disagreement.
- **Choice:** player supports, challenges or makes an independent decision.
- **Quiet intimacy:** optional meal, travel conversation, training, festival or repair scene.
- **Crisis:** meaningful promise, risk, departure or rescue; only when the story earns it.
- **Integration:** callback demonstrates how the relationship has changed daily behavior.

A character's arc can span many hours, but scenes should have local payoff. The player should not need to grind hangouts to unlock the companion's basic story.

## Romance and boundaries

Romance remains optional. The writing should respect the user's no-fanservice rule and keep attraction rooted in personality, trust, shared values and mutually chosen vulnerability.

- Make romantic intent clear enough that players can opt in or remain friends.
- Provide a graceful nonromantic response without bond collapse.
- Do not use flirtation as a compulsory route to the companion's best combat skill or personal history.
- Establish the character's adult status and boundaries in the world record and dialogue.
- Romance can include warmth, humor, tenderness and disagreement without sexualized camera framing.
- Major romantic steps require both characters' agency; player choices do not guarantee reciprocation.
- If gender/orientation preferences are part of the user's intended choice set, represent them consistently and privately in character data; do not assume every companion has identical attraction rules until locked.

## Departure, return and death

Leaving is a dramatic consequence, not routine party maintenance. Foreshadow a boundary, show the turning point, give the player a chance to answer, and retain a record of what happened. Where canon and story allow, the companion can return after a repair quest or a meaningful change. Some departures may be permanent because of a major choice; make that cost legible.

Permanent companion death follows the existing opt-in loss rules. A companion cannot die because of a pathing error, a missed payment, an inaccessible side quest or an unannounced timer. If someone dies, their personal arc resolves with a memorial and a lasting but playable consequence.

## Companion presence in the open world

Use an authored comment budget to avoid chatter fatigue:

- one first-visit observation per region per eligible companion;
- an occasional response to a genuinely new clue or event;
- a short post-fight beat when the encounter changes a relationship or reveals behavior;
- cooldowns and a quiet-mode setting;
- no duplicate comment from every party member on the same trigger.

The player can optionally ask a companion to discuss a pinned journal clue, current contract or recent choice. This creates a reliable conversation path without making voice lines fire automatically every few minutes.

## Scene architecture and workload

Give every companion a reusable packet: voice and gesture rules, values, boundaries, goals, combat identity, 3–5 relationship themes, key flags, a small number of personal quest beats, optional romance beats, and representative barks. The exact scene count is a production decision, not a locked quota.

Use a scene matrix to share trigger infrastructure but preserve individual content:

| Trigger | Shared structure | Character-specific content |
|---|---|---|
| First hire/join | reason to travel together | motivation and boundary |
| Major quest choice | reaction and conversation | value conflict |
| Inn/camp pause | optional scene slot | habit, joke, vulnerability |
| Boss/elite | combat callout or assist | tactical voice and signature behavior |
| Region arrival | observation slot | history, curiosity or discomfort |
| Act transition | recap and next intention | personal goal changes |

The architecture is reusable; lines and key scenes are not randomly recombined. Keep relationship-critical scenes authored and regression-test the combinations of party, flag and act state.

## Ring 0 prototype

Use one placeholder companion in Brindlewick:

1. They offer a practical reason to join without explaining their whole backstory.
2. They comment once on a monster clue and label the thought as their interpretation.
3. They disagree with one approach to a contract and explain why.
4. The player can ask, agree, disagree or move forward; no option blocks the job.
5. The companion's assist action changes one combat beat without taking control.
6. An inn/camp conversation offers friendship tone and a clear opt-out.
7. Reloading the save preserves the choice, reaction and callback state.

Ask playtesters which values they think the companion holds, whether they felt pressured into romance, and whether the disagreement made the companion feel more or less trustworthy.

## Production risks

- Romance for every companion, permanent death, departures and endings multiply dialogue states; keep the human roster bounded.
- A single relationship meter creates optimization behavior and moral flattening.
- Too many callbacks create repetitive chatter; use contextual cooldowns.
- Personal quests can turn optional content into mandatory level gates; keep main story progress independent.
- State combinations can become untestable; use shared event grammar and a compact flag audit.

## Related files

- [[companions_and_npcs]]
- [[companion_field_ai]]
- [[party_synergy]]
- [[life_in_aetheria]]
- [[Canon]]