# Combat audit: `upgrade v5` vs what exists (Wave A2)

> Written by combat-designer. Status key: **Built** (file), **Wave A2** (data and rules text this wave; code in the same wave, Unity wiring in A3), **Deferred** (reason), **Rejected** (Canon or forbidden list). Canon wins; nothing here edits a locked row. Proposals for the user are at the bottom.

| # | upgrade v5 item | Status | Where / reason |
|---|---|---|---|
| 1 | Light and heavy attacks, combo chains, charged attacks | Built | `12_Systems/combat.md` 4.1; `Data/Combat/combat_tuning.json` `combo`, `attackTiming` |
| 2 | Dodge and roll, perfect dodge, Flash Time | Built | combat.md 3; tuning `dodge`, `flashTime` |
| 3 | Block and parry, riposte | Built | combat.md 5; tuning `parry` |
| 4 | Stagger, poise, knockback, interruptible attacks | Built | combat.md 4.3; tuning `poise`, `poiseRegen`, `bossBreakKnockdownSec` |
| 5 | Aerial combat, launchers, slam | Built | combat.md 4.1 (launcher, air chain, slam) |
| 6 | Target locking, soft lock | Built | combat.md 2; tuning `softLockAngleDeg` |
| 7 | Finishing moves, dynamic finishers | Deferred | Ultimate cinematics exist (combat.md 2, 4.2); a context-sensitive finisher set needs animation budget (Ring 2+) |
| 8 | Combat Flow (dodge, recovery, counter, resource) | Built | Perfect dodge to counter flurry (4.1); Style Rank and Awakening (sections 6, 8) |
| 9 | Directional attacks, context-sensitive attacks | Deferred | Not in Ring 0 feel scope; revisit with weapon families |
| 10 | Weapon-specific movesets, weapon families | Deferred | combat.md 13 "Weapon identity as rhythm" sets the rules; per-family data belongs to class-skill-designer and items-designer |
| 11 | Weapon mastery trees, combat perks, combo unlocks | Rejected for A2 | Forbidden list in `13_Production/combat_wave_a2_plan.md` (mastery trees). Canon progression is class-based; any mastery layer needs the user's OK (proposal P3) |
| 12 | Enemy archetypes (Berserker, Archer, Brute, Hunter, Mage...) | Built | `aiPattern` in species data; combat.md 10; `Code/Ascend.Core/MonsterAi.cs` |
| 13 | Archetype "Commander coordinates nearby enemies" | Rejected | Canon 4d: no enemy hierarchy, no captains. Replaced by symmetric peer tactics (combat.md 10a) |
| 14 | Archetype "Shapeshifter changes tactics" | Deferred | Handled as boss phases (`Data/Monsters/boss_phases.json`), not a monster archetype |
| 15 | Threat assessment | Wave A2 | combat.md 10a; tuning `groupTactics.threat` (stateless, recomputed per tick) |
| 16 | Player movement prediction, adaptive attack selection, "bosses that adapt" | Rejected | Canon 4d: monsters never learn from or adapt to the player; sieges adapt only as a region-level wave rule, not personal memory. Fixed telegraphs also protect fairness |
| 17 | Attack telegraphing | Built | combat.md 5 telegraph colours; `Data/Monsters/attacks.json`; section 13 response ladder |
| 18 | Tactical positioning, group coordination, flanking | Wave A2 | combat.md 10a; tuning `groupTactics.flank`; aggro tokens already built (`ai.maxSimultaneousAttackers`) |
| 19 | Retreat and regroup | Wave A2 | tuning `groupTactics.retreat`; base `RetreatHpPct` and `LoneRetreatHp` already built in `MonsterAi.cs` |
| 20 | Protect weaker allies ("advanced enemy teamwork") | Wave A2 (partial) | `groupTactics.yield` lets a hurt peer give up its slot or token; active guarding of allies is Deferred (needs a Guardian role without a leader; proposal P5) |
| 21 | Environmental awareness for AI | Deferred | Needs navigation hazard data from the world team (Wave A3+) |
| 22 | Difficulty scaling by encounter design | Built | combat.md 14 Encounter Grammar; Canon combat/readability contract (difficulty changes pressure before HP) |
| 23 | Boss framework: multiple phases, transitions, summons | Built | `Data/Monsters/boss_phases.json`; Grukk's three phases; `Code/Ascend.Core/BossPhases.cs` |
| 24 | Boss weak points | Wave A2 | `Data/Monsters/boss_weakpoints.json`; combat.md 7d; Grukk starter record |
| 25 | Boss armor destruction | Wave A2 | boss_weakpoints.json `armor`; combat.md 7c |
| 26 | Boss environmental hazards | Deferred | Reaction hazard zones are Wave A2 data; arena-wide boss hazards need scene work (world-builder-engineer) |
| 27 | Special executions, unique victory sequences | Deferred | Cinematic and animation budget; see item 7 |
| 28 | Dynamic music states | Built (design) | combat.md 8 (Style drives music); Canon adaptive-music row; engine work with audio-designer |
| 29 | Elemental reactions | Built | combat.md 7; `Code/Ascend.Core/Elements.cs` (10 pairs) |
| 30 | Reactions as data, DoT, hazards, swirl spread | Wave A2 | `Data/Combat/reactions.json`; combat.md 7a |
| 31 | Ability synergies (ice then shatter) | Built + Wave A2 | Freeze then heavy shatter built (`ReactionState.HitMultiplier`); reaction-to-reaction synergies in reactions.json; combat.md 7b |
| 32 | Water amplifies lightning, wind spreads fire | Built | Storm Prison and Swirl/Firestorm in the 10 pairs |
| 33 | Earth barriers, shadow stealth bonus | Deferred | Stealth x2 built (tuning `damage.stealthMult`); earth barriers belong to class-skill-designer |
| 34 | Magic schools list (Fire to Blood magic) | Built | `Element` enum covers Fire, Water, Ice, Lightning, Earth, Wind, Nature, Poison, Light, Dark, Blood, Void; skill data is class-skill-designer territory |
| 35 | Damage types, armor, resistance, crit, weakness | Built | combat.md 9; tuning `damage` |
| 36 | Status effects, DoT, healing | Built + Wave A2 | Freeze, stun built; reaction DoT (Wildfire) is a proposal; healing is class-skill territory |
| 37 | Hitboxes and hurtboxes, attack windows, hit reactions | Built | `Data/Monsters/rigs.json` hurtboxes; `Code/Unity/Runtime`; tuning `attackTiming` |
| 38 | Root motion, motion blending, foot placement, animation cancel | Deferred | Animator work is outside A2 (animator-rigger, gameplay-engineer) |
| 39 | Destructible objects, explosive barrels, cover, traps | Deferred | Environment content, not a combat-data task. Fire and Earth zones from reactions are the A2 slice |
| 40 | Destructible boss arenas, arena destruction | Rejected for A2 | Forbidden list (destructible arenas). Authored per-phase arena changes remain in bosses doc section 1 |
| 41 | New game modes (arena, boss rush, horde, duel, survival, faction battles) | Rejected for A2 | Forbidden list. Siege defence and hunting contracts already exist as world events (Canon 4b) |
| 42 | Training grounds | Deferred | Training yard idea is in combat.md 13; a mode needs the user's OK |
| 43 | Ability and elemental specialisation | Deferred | Class and skill designers; Canon progression rows |
| 44 | Enemy knowledge, boss challenge rewards, combat achievements | Deferred | Journal and achievement systems (ux-designer, systems-designer) |
| 45 | Hitbox/hurtbox visualiser, AI inspector, attack timing inspector | Deferred | Unity editor tooling, later wave |
| 46 | Damage calculator, status debugger, encounter simulation | Wave A2 (via sandbox) | combat.md 7e; `Code/Ascend.Core/CombatSandbox.cs` |
| 47 | Combat sandbox (spawn any enemy, test interactions) | Wave A2 | combat.md 7e; tuning `sandbox`. Headless Core harness; Unity PlayMode check is Task 5 |
| 48 | Boss phase editor, weapon and ability editors | Deferred | Data files plus schema validation cover this for now |
| 49 | Legendary weapon abilities | Deferred | items-designer; no combat rule needed yet |
| 50 | Combat performance profiler | Deferred | performance-analyst, Unity side |

## Proposals needing the user's OK (Canon section 6 candidates, not locked)
| ID | Proposal | Why |
|---|---|---|
| P1 | Adopt `reactions.json` as the home of all reaction numbers, including the proposal values (bonus multipliers, DoT, hazards, Swirl spread, six synergies) | One data file for tuning; the existing Freeze, Storm Prison and Firestorm numbers stay as they are |
| P2 | Adopt boss armor and weak points as an optional, always-announced boss layer (never required to win) | Gives bosses readable tactical questions; matches the Canon boss-storytelling row |
| P3 | Decide whether any weapon-mastery layer exists (v5 sections 4 and 9). Default answer: no trees; weapon identity comes from rhythm (combat.md 13) | Avoids a stat treadmill; needs a product decision |
| P4 | Confirm the group-tactics ban list as Canon wording: "monster groups use symmetric peer rules only; no leader or rank, no memory of the player, nothing carried between fights" | Restates Canon 4d for the AI code and tests |
| P5 | Confirm that "Guardian protects allies" may exist as a peer behaviour (a role any monster of that pattern has, with no command authority) | Item 20; only if the user wants it |

Note (review fix pass): extra-damage multipliers (Shatter, reaction, synergy, weak point, broken armor) multiply together and are left uncapped in the rules on purpose, since every number is a proposal. The sandbox readout exposes the product per hit as `TotalExtraMult`; use it when tuning to judge how far stacking runs before any cap is proposed.
