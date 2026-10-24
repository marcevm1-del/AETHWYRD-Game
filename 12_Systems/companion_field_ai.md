# Companion Field AI: Partners Who Fight Beside You

> **Proposal.** Companions remain autonomous characters. This document turns the AI fantasy into a bounded, testable design. It does not authorize online play, player-control swapping or unrestricted companion death.

## Player promise

A companion feels like a skilled adventurer with their own instincts. They notice threats, contribute to combat, protect their specialty, speak when something matters and can be given a simple request. The player still owns movement, target choices and combo rhythm. Commands clarify intent; they do not turn the action RPG into a party tactics simulator.

## Research basis

Capcom's published *Dragon's Dogma 2* preview describes AI partners acting on their own judgment, responding to the player's needs, using situation-appropriate skills and accepting simple commands to regroup, spread out or prioritize support. It also describes companions contributing area knowledge and travel observations. ([PlayStation Blog](https://blog.playstation.com/?p=384689)) This is a useful precedent for autonomy plus lightweight command language. Ascend should reflect its own characters, camera and single-player focus.

## Combat identity

Each companion combines a role profile with authored personality parameters.

- **Vanguard:** engages dangerous targets, creates stagger and openings, avoids chasing far from the party.
- **Guardian:** intercepts pressure, protects recovery and holds a position when asked.
- **Skirmisher:** flanks, punishes recovery and disengages from heavy telegraphs.
- **Ranger:** prioritizes flying or distant threats and maintains line of sight.
- **Arcanist:** uses elemental/status setup and area control with resource restraint.
- **Mender:** heals or cleanses when a safe opportunity and threshold are met; preserves rare resources.
- **Tamer:** coordinates owned monsters through target, hold and recall intent, respecting class limits.
- **Specialist:** a named character's signature combination of role tags, skills and personality.

Roles are not hard classes. A companion can have two role tags and one preferred role. No role solves every encounter. The player remains the main decision-maker.

Personality parameters tune initiative, caution, protectiveness, resource thrift, target preference and humor frequency. These values change choices among valid actions, not basic competence. A cautious companion still helps; they may wait for a readable opening rather than charge. Debug tools should expose why an action was selected.

## Tactical decision order

1. **Safety:** avoid lethal telegraphs, respect encounter bounds and follow recovery rules.
2. **Player request:** obey the current command if valid and safe.
3. **Role objective:** perform the companion's combat role.
4. **Encounter reaction:** respond to boss phase, element, poise, ally danger and openings.
5. **Personality:** choose among equally safe actions according to authored tendencies.
6. **Recovery:** regroup, restore resources or re-enter a useful range.

Commands expire or complete on clear conditions. The player should not have to cancel stale orders.

## Command wheel

Start with six simple intents:

- **Focus:** prioritize the player's current target.
- **Hold:** defend a location or protect an objective.
- **Assist:** coordinate on the player's target and favor combo openings.
- **Support:** favor healing, cleansing, buffs and rescue actions.
- **Conserve:** reduce expensive skills and avoid risky pressure.
- **Regroup:** return to the player and reset pursuit.

Provide a quick default and a full wheel. Support keyboard, controller and remapping. Commands receive brief icon, animation or voice feedback. Avoid an RTS-style per-skill command grid in the first build.

## Combat coherence and safety

- Companions must not block the camera or body-block narrow routes.
- Friendly effects look distinct from enemy telegraphs.
- Companions never consume rare items silently.
- They do not initiate bosses, kill intelligent creatures or trigger major choices on their own.
- If pathing fails, regroup is preferred over teleporting into an active attack.
- Auto-targeting respects the player's lock-on and never steals the primary target unexpectedly.
- Difficulty can tune ally aggression and rescue frequency without inflating enemy health.
- Downing and death follow Canon's recoverable-loss and Mortal Bonds rules; AI bugs can never cause permanent loss.

## Banter rules

Banter is a short contextual beat with eligibility, priority and cooldown:

- triggers include entering a region, noticing a clue, seeing a monster, arriving at an inn, finishing a fight or resolving a quest;
- story-critical dialogue outranks urgent tactical callouts, which outrank observations and ambient banter;
- combat danger can interrupt; nonessential thoughts can be dropped or recalled later if suitable;
- global and per-companion frequency controls include a quiet mode;
- recent line keys prevent immediate repetition;
- not every companion comments on every discovery; a look or action can carry the beat.

## Growth and trust

Combat competence grows through authored story, training and compatible equipment, not mandatory recurring fees. Bond moments may unlock a tactic variant, rescue behavior, joint skill or personal scene. Romance does not gate basic AI competence. Meals, lodging, gifts and gear can be optional support and bond flavor; companions never starve because of a clock.

A departure is a major, foreshadowed choice with direct conversation and a chance to respond. Where story allows, the player can repair the relationship. Permanent death is opt-in under the loss rules and never results from a pathing mistake.

## Player autonomy settings

- **Free Rein:** companions use role and judgment.
- **Responsive:** they favor the current target and protect resource budgets.
- **Conservative:** they stay near, avoid pursuits and preserve costly skills.

Player can tune callout frequency and combat cues independently. Assistance does not remove ordinary progression rewards.

## Future data model

Suggested authored fields: `id`, `roleTags`, `preferredRole`, `personalityTuningId`, `combatSkills`, `supportSkills`, `resourcePolicy`, `commandOverrides`, `bossBehaviorProfile`, `signatureAssist`, `banterTags`, `cooldowns`, `storyConditions`, `followDistance`, `regroupDistance`, `leashRadius`, `difficultyScalars`, `accessibilityCueIds`.

Save only compact runtime state: current order, target, tactical mode, resource state, last action, recovery timer and recent banter keys. Do not serialize transient pathfinding or animation internals.

## Ring 0 prototype

Use one AI companion placeholder and Blue Slime, Goblin and Horned Rabbit:

1. Follow and regroup without clipping through the player.
2. Respect focus-target and assist orders.
3. Respond to one enemy wind-up with readable dodge or guard.
4. Perform one signature assist after the player creates an opening.
5. Offer one optional monster observation recorded as companion interpretation, not direct player evidence.
6. Support keyboard and controller commands without unpredictable input blocking.
7. Stop banter when combat starts and honor the frequency control.
8. Recover cleanly when target dies, path is blocked or companion is hit.

Success: the player notices the help without feeling that the AI stole control, and can explain how one companion differs from another.

## Open design questions

- Active party size and its relationship to combat readability.
- Whether companions ever resist commands as characterization.
- Downing rules on default settings.
- How companion builds interact with the player's class and skills.
- Number of signature assists supportable for the initial roster.

Do not add network-sourced Pawn hiring or online sharing: single-player is locked. Future sharing, if ever considered, should be offline, user-controlled and safe to ignore.

## Related files

- [[signature_gameplay_loops]]
- [[combat]]
- [[life_in_aetheria]]
- [[Canon]]
- [[research_expansion_2026-10-24]]