# Party Synergy: Anime Teamwork Without Character Swapping

> **Proposal.** The player always controls the protagonist. Companions remain autonomous AI characters and cannot be directly swapped into. This document explores how to make teamwork visible and mechanically satisfying without violating that rule.

## The player fantasy

The protagonist is not a solo fighter followed by decorative NPCs. Companions notice openings, protect one another, contribute their own style and remember the fights they shared. The player can create a moment for them, call for a coordinated move, or let them act on their own. Teamwork should feel earned and readable, not like a second UI game.

Square Enix's *Final Fantasy VII Rebirth* interview describes synergy moves as a way for players to feel character relationships through battle, with combinations unlocked through growth systems. ([PlayStation Blog](https://blog.playstation.com/?p=384274)) This is evidence that combat can express bonds. Ascend's adaptation is intentionally different: companions stay AI-controlled and the player never swaps control to them.

## Design principles

- The player creates the opening; companions contribute the follow-through.
- The companion remains autonomous and owns their animation and positioning.
- One synergy action has a clear cause, cost, effect and recovery.
- Bond progression adds distinct behavior or a variant, not just larger multipliers.
- Core combat remains fully playable without synergy.
- Synergy should not trigger so often that the protagonist's attacks become background noise.

## Three layers of cooperation

### Ambient cooperation

No player command required: companion calls a warning, interrupts a minor enemy approaching from behind, applies a small buff at a safe moment or helps a downed ally. These are low-impact, context-limited actions.

### Tactical assist

An optional command or agreed control input asks the selected companion to use a role action: mark, pull, guard, heal, stagger, set an elemental primer or create distance. The player remains active during this action.

### Signature synergy

A short, authored two-character technique triggered by a specific situation: player launcher + companion aerial follow-up; player guard break + vanguard strike; companion elemental primer + player reaction; rescue + counterattack. It has a distinct animation, sound cue and cooldown or resource cost. It is not a full cinematic.

## Readable trigger grammar

A synergy action should be available when the state makes sense, for example:

- target is launched, staggered or recovering;
- companion and player are within valid range;
- companion has the required skill and resource;
- player recently performed a compatible action or issued Assist;
- target is not invulnerable or in an incompatible boss phase;
- the action's cooldown and safety checks pass.

A subtle icon or controller hint can indicate a high-value opportunity. The hint is optional and configurable. The game should not show a button prompt for every possible combo.

## Bond and identity

Bond can unlock a signature assist when the character arc reaches its authored moment. Each companion gets one mechanically distinct synergy first; variants come later only if the prototype proves useful. The scene can reflect trust: early assist is cautious and practical; later assist is confident and coordinated. Avoid making romance a condition for combat competence.

Example abstract role pairings (not final character lore):

- **Guardian + protagonist:** intercepts a heavy strike, creating a brief counter window.
- **Ranger + protagonist:** marks a weak point after the protagonist forces a turn.
- **Arcanist + protagonist:** primes an element, then the protagonist triggers a reaction.
- **Mender + protagonist:** grants a short safe recovery after the protagonist disengages.
- **Skirmisher + protagonist:** attacks from a flank when the player holds enemy attention.

Do not give every pairing a unique cutscene. Shared timing templates plus individual pose, sound, line and effect can preserve character while limiting production cost.

## Resource options

Pick one resource model for a prototype:

1. **Cooldown only:** easy to understand, lower UI burden; may feel automatic.
2. **Team gauge:** fills from clean defense and varied attacks; strong anime payoff, but risks optimizing every encounter around meter.
3. **Context-only window:** no gauge; synergy appears after authored opportunities. Clear but less player-directed.
4. **Command plus cooldown:** player asks for the move when available. Best balance of autonomy and agency, but adds input complexity.

**Recommended prototype:** one Assist command with a companion-specific cooldown, no global meter. Add a team gauge only if playtests show players want a more deliberate crescendo.

## Fairness and anti-friction

- Never spend rare items without consent.
- Never spend the player's ultimate resource automatically.
- Do not make companions interrupt an active player combo.
- A boss can resist or adapt to repeated synergy, but should not invalidate the mechanic unpredictably.
- Add an assist-frequency setting and allow disabling contextual prompts.
- Avoid forced camera locks longer than the move needs; preserve manual camera control where possible.
- Telemetry/debug should report why a synergy was unavailable: range, cooldown, phase, skill or safety.

## Ring 0 prototype

One placeholder companion, Swordsman player, Goblin and Horned Rabbit:

1. Player performs Rising Cut; companion ranger uses a short aerial follow-up if nearby and available.
2. If no companion is present, the player still gets a complete air combo.
3. Assist uses a cooldown, not a global meter.
4. It has a distinct telegraph and compact animation; the player keeps control after the hit.
5. The command can be ignored, disabled or remapped.
6. Record whether players notice that the assist helped, whether it interrupted their intended combo, and whether they can explain its trigger.

Only scale this after the regular combat loop feels good. The first slice should prove one readable collaboration moment, not a complete team-combo matrix.

## Open decisions

- Should synergy be commanded or emerge automatically from state?
- Should the player choose one active companion assist before combat?
- Do bosses have a specific resistance/response to repeated team moves?
- How should AI-only companion builds contribute if the player never uses the command wheel?
- Which options belong in the accessibility menu versus gameplay settings?

## Related files

- [[companion_field_ai]]
- [[combat]]
- [[signature_gameplay_loops]]
- [[adaptive_music_and_scene_pacing]]
- [[Canon]]