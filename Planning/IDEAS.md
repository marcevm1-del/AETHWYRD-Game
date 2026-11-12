# Ideas register

The permanent store of new possibilities that could make AETHWYRD more distinctive. **An idea is not a commitment.** Improvements to things that exist belong in `UPGRADE.md`; approved work belongs in `FEATURE_BACKLOG.md`. Template: `TASK_TEMPLATES.md` §3.

## Rules

1. Good ideas are kept. An idea is never deleted: it becomes DEFERRED or REJECTED with the reason.
2. No idea is approved automatically and none becomes a task without passing `CHANGE_CONTROL.md` stages D and E.
3. No idea is added to raise the count. Each one says why it belongs in this game in particular.
4. Overlapping ideas are merged and the merge is named in the decision history.
5. An idea that conflicts with canon says so and points to its `CANON_DISCREPANCIES.md` row.
6. Cost is stated. A distinctive player experience outranks a long feature list.

Statuses: NEW · EXPLORING · NEEDS RESEARCH · READY FOR REVIEW · APPROVED · ADDED TO BACKLOG · IN DEVELOPMENT · IMPLEMENTED · DEFERRED · REJECTED.

## Where these came from

Written on 2026-11-12 from five audits (`Planning/audits/`), which triaged the owner's four prompt documents (`AETHWYRD.odt`, `AETHWYRD 2.docx`, `AETHWYRD 3.docx`, `Aethwyrd 4.docx`). Those documents are briefs asking for audits and long lists; most of what they ask for is already built, already designed, or an upgrade. What remained as a new possibility is here: 27 candidates merged to 24, plus three taken from the audits' system tables (IDEA-001, IDEA-009, IDEA-027). The line-by-line triage of each prompt is in section 4 of each audit.

Not copied here: the 52 features of `01_Core_Concept/the_big_upgrade.md` and the 30 of `borrowed_features.md`. They are existing project documents with their own `Canon.md` §6 rows; IDEA-001 stands for the decision the first one is waiting on.

## The strongest, in the orchestrator's judgement

IDEA-001 (Lying Interface), IDEA-003 (dens and signs), IDEA-011 (the companion's eye), IDEA-007 (fight-local pattern shifts), IDEA-014 (returner recap). The first three share one quality: they make the game's existing pillars visible at low content cost.

## Index

| ID | Title | Category | Complexity | Priority | Status |
|---|---|---|---|---|---|
| IDEA-001 | The Lying Interface: a Status System that hides and bends the truth | Identity / UI / narrative | M per stage | P2 | READY FOR REVIEW |
| IDEA-002 | 'The Seams': an appraisal flicker that lets a sharp player catch an impostor early | Exploration / identity | M | P3 | NEW |
| IDEA-003 | Dens and signs: a creature leaves evidence before you meet it | Exploration / ecology | M | P2 | NEW |
| IDEA-004 | The migration notice | Living world | S to M | P3 | NEW |
| IDEA-005 | One weather-driven behaviour per region, not a weather system | Ecology / presentation | M | P3 | NEEDS RESEARCH |
| IDEA-006 | Roaming rare monsters: authored and memoryless | Encounters | M | P3 | NEW |
| IDEA-007 | Fight-local pattern shifts | Combat AI | M | P3 | NEEDS RESEARCH |
| IDEA-008 | Training yard | Onboarding | M | P3 | NEW |
| IDEA-009 | Fight-only wounds and part breaks on ordinary monsters | Combat | L | P4 | DEFERRED |
| IDEA-010 | Restoration through care | Progression / ecology | M | P3 | NEW |
| IDEA-011 | The companion's eye | Companions / exploration | S to M | P2 | NEW |
| IDEA-012 | Egg-and-den taming path | Taming | M | P4 | DEFERRED |
| IDEA-013 | A region page in the journal | UI | S to M | P3 | NEW |
| IDEA-014 | Returner recap | Journal | S | P3 | READY FOR REVIEW |
| IDEA-015 | The map as a journal | UX | M | P3 | NEW |
| IDEA-016 | The System's thread | Guidance / identity | M to L | P4 | NEW |
| IDEA-017 | Quest receipts on the board | Social | S | P3 | NEW |
| IDEA-018 | Field sketch at a landmark | Exploration / photo mode | M | P4 | NEW |
| IDEA-019 | Hunter's mark from appraisal | Combat / identity | M | P3 | NEW |
| IDEA-020 | Three material classes in the world | Combat / environment | L | P4 | DEFERRED |
| IDEA-021 | Directional guard for shield classes | Combat | M | P4 | DEFERRED |
| IDEA-022 | Tell clips in the journal | Knowledge | M | P4 | DEFERRED |
| IDEA-023 | Readable pack composure | Combat feedback | S | P3 | NEW |
| IDEA-024 | Companion as teacher | Companions / progression | M | P3 | NEW |
| IDEA-025 | Lying appraisal on gear | Crafting / identity | M | P4 | NEW |
| IDEA-026 | The home farm as the economy's teacher, with a festival sink | Economy | M | P4 | DEFERRED |
| IDEA-027 | A status-effect framework beyond freeze and stun | Combat | L | P4 | DEFERRED |

## Entries

### IDEA-001: The Lying Interface: a Status System that hides and bends the truth

- **Category:** Identity / UI / narrative
- **Description:** The System's windows are not neutral. Lines are redacted, 'recommended' quests are slanted, and the interface degrades in stages as the story exposes what the System is.
- **Player Experience:** The player slowly realises the UI they trusted since the first minute has an agenda.
- **Gameplay Purpose:** Turns the HUD, the most-used screen in the game, into a story device and a source of deduction.
- **Why It Belongs in AETHWYRD:** It is the project's own signature idea (`01_Core_Concept/the_big_upgrade.md`, `12_Systems/hud_and_ui.md` §13) and no other part of the design is as distinctive.
- **Player Benefit:** A mystery that lives in every menu.
- **Affected Systems:** Status Window, HUD, quest board, story flags, audio events
- **Potential Dependencies:** Owner decision CD-002; UPG-015 (acts and flags as data); UPG-016 (the first hook); a styled UI (UPG-032)
- **Suggested Implementation:** Stage 0 is today's single redacted line. Add stages only as flag-driven text swaps in existing windows; no new screens.
- **Technical Considerations:** Text swaps are cheap; visual corruption effects need the shipping UI technology. Every lie needs an accessible, truthful fallback so the game stays playable.
- **Content Requirements:** Per stage: a handful of altered strings and three audio cues already named in the sound list.
- **Complexity:** M per stage
- **Priority:** P2
- **Risks:** If a lie makes the player fail without recourse it reads as a bug. Must never misreport anything a player needs to finish a quest.
- **Design Questions:** Is the Big Upgrade approved (CD-002)? How many stages are in the slice: only stage 0 and 1?
- **Related Ideas:** IDEA-002, IDEA-016, IDEA-019, IDEA-025
- **Related Upgrades:** UPG-015, UPG-016
- **Related Files:** `01_Core_Concept/the_big_upgrade.md`, `12_Systems/hud_and_ui.md` §13, `Runtime/UI/RingZeroHud.cs`
- **Status:** READY FOR REVIEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: existing design; exploration audit SYS-EXP-06); an existing project design, recorded as READY FOR REVIEW for the owner. Not a commitment.

### IDEA-002: 'The Seams': an appraisal flicker that lets a sharp player catch an impostor early

- **Category:** Exploration / identity
- **Description:** For a fraction of a second a character's Status shows a different line. A player who looks, or who has the Appraisal Eye, can catch a disguised villain before the story reveals them.
- **Player Experience:** A detective payoff from a stat screen: 'wait, what did that say?'
- **Gameplay Purpose:** Rewards attention; gives Appraisal a use on people.
- **Why It Belongs in AETHWYRD:** Uses the Lying Interface and the canon secrets about who certain NPCs really are.
- **Player Benefit:** The feeling of having outsmarted the game.
- **Affected Systems:** Appraisal, NPC states, dialogue
- **Potential Dependencies:** IDEA-001; UPG-012; UPG-015; UPG-038
- **Suggested Implementation:** An NPC state flag plus an overlay that renders alternative text for about 0.1 s.
- **Technical Considerations:** UI overlay only; must have a non-timing route (a clue elsewhere) for accessibility.
- **Content Requirements:** One or two NPCs.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Spoilers: Canon §3 secrets must stay gated by act.
- **Design Questions:** Which acts? Does catching it early change anything, or only add a journal note?
- **Related Ideas:** IDEA-001, IDEA-019
- **Related Upgrades:** UPG-012
- **Related Files:** `Canon.md` §3 (spoilers), `Data/NPCs/npcs.json`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I1); recorded as NEW. Not a commitment.

### IDEA-003: Dens and signs: a creature leaves evidence before you meet it

- **Category:** Exploration / ecology
- **Description:** Each Ring 1 species with a role gets one sign: tracks, feeding remains, a den, a call at dusk. Three approaches to a damaged granary can each show a different culprit's traces.
- **Player Experience:** You read the field before the fight, like a hunter.
- **Gameplay Purpose:** Makes ecology visible and feeds the journal and research tasks.
- **Why It Belongs in AETHWYRD:** Matches the evidence-led field journal already designed and the game's promise of discovery over markers.
- **Player Benefit:** Fights you saw coming because you paid attention.
- **Affected Systems:** Bestiary, encounters, journal
- **Potential Dependencies:** UPG-009, UPG-011, UPG-020, UPG-021
- **Suggested Implementation:** A sign is a tagged prop chosen from the species' role; observing it counts as a research task and can be a clue in a discovery chain.
- **Technical Considerations:** Graybox props suffice at first; placement by encounter zone.
- **Content Requirements:** One sign per Ring 0 and Ring 1 species (21).
- **Complexity:** M
- **Priority:** P2
- **Risks:** Becomes a checklist if every sign is marked.
- **Design Questions:** Shown in the world only, or pencilled on the map once seen?
- **Related Ideas:** IDEA-011, IDEA-013
- **Related Upgrades:** UPG-009, UPG-011, UPG-021
- **Related Files:** `10_World/reactive_world_and_field_journal.md`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I1 merged with exploration I4); recorded as NEW. Not a commitment.

### IDEA-004: The migration notice

- **Category:** Living world
- **Description:** One authored 'the herd has moved' event per region phase swaps which species roam a zone for a few in-game days and posts a line on the board.
- **Player Experience:** 'The elk are in the east meadow this week', and hunting contracts follow.
- **Gameplay Purpose:** Bounded migration without simulating anything.
- **Why It Belongs in AETHWYRD:** Delivers the ecology prompt's migration wish inside the 'bounded, not simulated' canon rule.
- **Player Benefit:** A familiar wood that is not always the same.
- **Affected Systems:** Event director, encounter tables, board
- **Potential Dependencies:** UPG-020, UPG-021, UPG-022
- **Suggested Implementation:** Event pool rows that override a zone's encounter table.
- **Technical Considerations:** A table override per event; saved with the event state.
- **Content Requirements:** A few pool rows per region.
- **Complexity:** S to M
- **Priority:** P3
- **Risks:** Looks scripted if too regular.
- **Design Questions:** Calendar-driven or state-driven?
- **Related Ideas:** IDEA-005, IDEA-006
- **Related Upgrades:** UPG-022
- **Related Files:** `Data/World/living_world.json`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I2); recorded as NEW. Not a commitment.

### IDEA-005: One weather-driven behaviour per region, not a weather system

- **Category:** Ecology / presentation
- **Description:** A single authored rule per region tied to a clear, rain or fog toggle: rain brings slimes into the open; fog hides ambushers.
- **Player Experience:** Places you know change character.
- **Gameplay Purpose:** Most of the value of gameplay weather at a fraction of its cost.
- **Why It Belongs in AETHWYRD:** Regions gain identity through behaviour, not only looks.
- **Player Benefit:** Variety without new content.
- **Affected Systems:** Monster AI, encounters, clock
- **Potential Dependencies:** Owner decision CD-014
- **Suggested Implementation:** A region weather flag read by the encounter selection.
- **Technical Considerations:** A full weather system is an unbounded art and audio cost; this is one flag.
- **Content Requirements:** One rule per region.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Scope creep into a weather system.
- **Design Questions:** Do seasons exist at all?
- **Related Ideas:** IDEA-004
- **Related Upgrades:** UPG-021, UPG-023
- **Related Files:** `Code/Ascend.Core/Calendar.cs`
- **Status:** NEEDS RESEARCH
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I3); recorded as NEEDS RESEARCH: an owner decision or a canon check comes first. Not a commitment.

### IDEA-006: Roaming rare monsters: authored and memoryless

- **Category:** Encounters
- **Description:** A few named roaming monsters appear by region state and time of day and are announced on the rumour board. They never remember the player.
- **Player Experience:** A rumour worth chasing.
- **Gameplay Purpose:** Regional legends without a nemesis system.
- **Why It Belongs in AETHWYRD:** Gives the owner's 'rare roaming monsters' wish inside Canon §4d.
- **Player Benefit:** Stories the player tells afterwards.
- **Affected Systems:** Encounters, board, bestiary
- **Potential Dependencies:** UPG-020, UPG-022
- **Suggested Implementation:** Authored rows with spawn conditions; listed as rumours.
- **Technical Considerations:** No per-player memory; nothing persists but 'defeated'.
- **Content Requirements:** Three or four per region.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Any promotion or memory would break locked canon.
- **Design Questions:** Do they respawn?
- **Related Ideas:** IDEA-004
- **Related Upgrades:** UPG-020
- **Related Files:** `Canon.md` §4d
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I4); recorded as NEW. Not a commitment.

### IDEA-007: Fight-local pattern shifts

- **Category:** Combat AI
- **Description:** A shared, stateless rule per behaviour pattern: if you dodge the same attack twice in one fight, the monster chains its follow-up. It resets when the fight ends.
- **Player Experience:** Fights feel alive without grudges.
- **Gameplay Purpose:** Stops one answer solving a whole fight.
- **Why It Belongs in AETHWYRD:** Delivers the owner's 'enemies adapt' wish in the only form compatible with the locked named-monster rule.
- **Player Benefit:** Depth for skilled players.
- **Affected Systems:** Monster AI, attack data
- **Potential Dependencies:** A sentence in Canon §6 and the owner's OK (CD-003)
- **Suggested Implementation:** A counter in the brain cleared at fight end; a follow-up id on about ten attacks.
- **Technical Considerations:** No persistence; deterministic with the injected random source.
- **Content Requirements:** Follow-up ids on about ten attacks.
- **Complexity:** M
- **Priority:** P3
- **Risks:** May be read as 'learning'. As described it reacts to the player's dodges, which `12_Systems/combat.md` §10a forbids outright ('no learning or adapting to the player'), and Canon §4d exists for a legal reason that needs an IP review before release. This idea cannot be built without a canon change by the owner.
- **Design Questions:** Does the owner accept this as inside §4d?
- **Related Ideas:** IDEA-023
- **Related Upgrades:** UPG-002
- **Related Files:** `Canon.md` §4d, `12_Systems/combat.md` §10a
- **Status:** NEEDS RESEARCH
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I1); recorded as NEEDS RESEARCH: an owner decision or a canon check comes first. Not a commitment.

### IDEA-008: Training yard

- **Category:** Onboarding
- **Description:** A corner of Brindlewick with dummies for parry, launcher and guard break, where a weapon's five roles can be tried.
- **Player Experience:** Learn by doing, no tutorial text.
- **Gameplay Purpose:** Teaches the mastery ladder.
- **Why It Belongs in AETHWYRD:** `combat.md` §13 already promises a short training-room trial.
- **Player Benefit:** Confidence before the first real fight.
- **Affected Systems:** Scene, combat sandbox
- **Potential Dependencies:** UPG-001, UPG-006
- **Suggested Implementation:** Sandbox-style dummies in the Ring 0 field.
- **Technical Considerations:** Reuses the headless sandbox logic.
- **Content Requirements:** Three dummies and their prompts.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Scope.
- **Design Questions:** In town, or at the guild?
- **Related Ideas:** -
- **Related Upgrades:** UPG-001, UPG-006
- **Related Files:** `12_Systems/combat.md` §13
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I2); recorded as NEW. Not a commitment.

### IDEA-009: Fight-only wounds and part breaks on ordinary monsters

- **Category:** Combat
- **Description:** Hitting a limb or horn enough within a fight impairs that monster for the rest of the fight: a limp, a weaker attack.
- **Player Experience:** Aiming matters.
- **Gameplay Purpose:** Extends boss weak points to the field.
- **Why It Belongs in AETHWYRD:** Fits the anatomy data the 25 shared rigs already carry.
- **Player Benefit:** Tactical choice beyond damage.
- **Affected Systems:** Rig hurtboxes, monster AI, damage
- **Potential Dependencies:** UPG-007 proven on one boss first
- **Suggested Implementation:** Reuse the boss weak-point rules with a per-rig table.
- **Technical Considerations:** Hurtbox part names must exist in rig data (unverified).
- **Content Requirements:** A part table per rig (25).
- **Complexity:** L
- **Priority:** P4
- **Risks:** Persistent wounds and gear wear are ruled out by canon (CD-004).
- **Design Questions:** Is this wanted at all before Ring 2?
- **Related Ideas:** -
- **Related Upgrades:** UPG-007
- **Related Files:** `Data/Monsters/rigs.json`
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat SYS-CMB-30; owner's combat prompt Part 7); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-010: Restoration through care

- **Category:** Progression / ecology
- **Description:** After liberation, optional restoration bundles (seedlings, stocking a pond, moving a den) nudge the region toward plenty.
- **Player Experience:** A peaceful verb for the freed world.
- **Gameplay Purpose:** A long-term goal that is not killing.
- **Why It Belongs in AETHWYRD:** Warmth over comedy; slow life, not chores.
- **Player Benefit:** The land visibly breathes because of you.
- **Affected Systems:** Region cycle, gathering
- **Potential Dependencies:** UPG-018, UPG-021
- **Suggested Implementation:** Hand-in bundles that shift the region state weighting.
- **Technical Considerations:** A few integers per region.
- **Content Requirements:** Bundles per region.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Becomes a chore if required.
- **Design Questions:** Post-liberation only?
- **Related Ideas:** IDEA-004
- **Related Upgrades:** UPG-018, UPG-021
- **Related Files:** `01_Core_Concept/borrowed_features.md`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I5); recorded as NEW. Not a commitment.

### IDEA-011: The companion's eye

- **Category:** Companions / exploration
- **Description:** Each companion notices one kind of thing and says so: Lyra reads people and mood, Torvald stone and metal, a partner monster scents tracks.
- **Player Experience:** Travelling with someone changes what you see.
- **Gameplay Purpose:** Gives companions an exploration role and teaches without tutorials.
- **Why It Belongs in AETHWYRD:** Partners, not tools.
- **Player Benefit:** Warmth, and hints that feel like company.
- **Affected Systems:** Banter, discovery registry, bestiary research
- **Potential Dependencies:** UPG-009, UPG-033
- **Suggested Implementation:** A banter trigger kind 'clue' with one line each; observing a sign with a companion advances research.
- **Technical Considerations:** Trigger data only.
- **Content Requirements:** One or two lines per companion; start with two companions.
- **Complexity:** S to M
- **Priority:** P2
- **Risks:** Writing load for 14 companions.
- **Design Questions:** Can the remarks be turned down (quiet mode exists)?
- **Related Ideas:** IDEA-003, IDEA-024
- **Related Upgrades:** UPG-009, UPG-033
- **Related Files:** `Data/Companions/banter.json`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I6, exploration I3, combat I5 merged); recorded as NEW. Not a commitment.

### IDEA-012: Egg-and-den taming path

- **Category:** Taming
- **Description:** Dens appear in plentiful phases; slipping in yields an egg under the existing stable rules.
- **Player Experience:** A stealthy, gentle route to a partner.
- **Gameplay Purpose:** A second taming verb.
- **Why It Belongs in AETHWYRD:** Uses the built egg rules.
- **Player Benefit:** A partner you raised.
- **Affected Systems:** Taming, stables, region cycle
- **Potential Dependencies:** UPG-021
- **Suggested Implementation:** Den props spawned by region state.
- **Technical Considerations:** Stables rules exist and are saved.
- **Content Requirements:** Den props.
- **Complexity:** M
- **Priority:** P4
- **Risks:** Depends on a chain of unbuilt things.
- **Design Questions:** -
- **Related Ideas:** IDEA-003
- **Related Upgrades:** UPG-021
- **Related Files:** `12_Systems/stables.md`
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I7); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-013: A region page in the journal

- **Category:** UI
- **Description:** A generated one-page summary per region: apex creature, staple prey, current state, what the board says.
- **Player Experience:** Ecology has a visible home.
- **Gameplay Purpose:** Shows the player the system exists.
- **Why It Belongs in AETHWYRD:** The ecology prompt asks for visibility without a management screen.
- **Player Benefit:** Understanding at a glance.
- **Affected Systems:** Journal, ecology tags
- **Potential Dependencies:** UPG-010, UPG-021
- **Suggested Implementation:** Generated from tags and state; read-only.
- **Technical Considerations:** No authoring per region.
- **Content Requirements:** None.
- **Complexity:** S to M
- **Priority:** P3
- **Risks:** Empty until ecology data exists.
- **Design Questions:** -
- **Related Ideas:** IDEA-003
- **Related Upgrades:** UPG-010, UPG-021
- **Related Files:** `Runtime/UI/JournalWindow.cs`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: ecology I8); recorded as NEW. Not a commitment.

### IDEA-014: Returner recap

- **Category:** Journal
- **Description:** On loading a save after a break, a dismissible, spoiler-safe 'where you were' summary.
- **Player Experience:** A long save is safe to come back to.
- **Gameplay Purpose:** Protects a 1,000-hour game from being abandoned after a pause.
- **Why It Belongs in AETHWYRD:** Already an open Canon §6 proposal (kept here because nothing of it is built; it would move to the upgrade register once the journal pages of UPG-010 exist).
- **Player Benefit:** No 'what was I doing?'
- **Affected Systems:** Journal, quests
- **Potential Dependencies:** UPG-010
- **Suggested Implementation:** Built from active quests and last visited entries.
- **Technical Considerations:** Read-only.
- **Content Requirements:** None.
- **Complexity:** S
- **Priority:** P3
- **Risks:** None.
- **Design Questions:** Opt-in or default?
- **Related Ideas:** -
- **Related Upgrades:** UPG-010
- **Related Files:** `Canon.md` §6 'Returner journal recap'
- **Status:** READY FOR REVIEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I2); an existing project design, recorded as READY FOR REVIEW for the owner. Not a commitment.

### IDEA-015: The map as a journal

- **Category:** UX
- **Description:** Discoveries are pencilled onto the existing map as heard-of and visited marks.
- **Player Experience:** The map becomes your own record.
- **Gameplay Purpose:** One vocabulary for knowledge.
- **Why It Belongs in AETHWYRD:** The map already shows unknown, heard and visited.
- **Player Benefit:** Orientation without markers.
- **Affected Systems:** Map window
- **Potential Dependencies:** UPG-009
- **Suggested Implementation:** An overlay on the existing map art.
- **Technical Considerations:** Uses `MapArt`.
- **Content Requirements:** None.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Clutter.
- **Design Questions:** -
- **Related Ideas:** IDEA-003
- **Related Upgrades:** UPG-009
- **Related Files:** `Runtime/UI/MapArt.cs`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I5); recorded as NEW. Not a commitment.

### IDEA-016: The System's thread

- **Category:** Guidance / identity
- **Description:** A faint guiding thread in the world, offered by the System. Later it is caught leading the player where the System benefits.
- **Player Experience:** Help you come to doubt.
- **Gameplay Purpose:** Diegetic guidance that is also plot.
- **Why It Belongs in AETHWYRD:** Connects the guidance proposal to the Lying Interface.
- **Player Benefit:** A betrayal you can see coming on a second playthrough.
- **Affected Systems:** Guidance, story
- **Potential Dependencies:** IDEA-001; UPG-017
- **Suggested Implementation:** A guidance channel with authored exceptions.
- **Technical Considerations:** Must be opt-in and never the only route.
- **Content Requirements:** Authored exceptions per act.
- **Complexity:** M to L
- **Priority:** P4
- **Risks:** Breaks trust if done badly.
- **Design Questions:** Is misleading guidance acceptable for accessibility?
- **Related Ideas:** IDEA-001
- **Related Upgrades:** UPG-017
- **Related Files:** `Canon.md` §6 'Diegetic guidance'
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I6); recorded as NEW. Not a commitment.

### IDEA-017: Quest receipts on the board

- **Category:** Social
- **Description:** The guild board pins notes of your last three outcomes.
- **Player Experience:** The town remembers what you did.
- **Gameplay Purpose:** Makes consequences visible cheaply.
- **Why It Belongs in AETHWYRD:** A world that answers.
- **Player Benefit:** Recognition.
- **Affected Systems:** Board, quests
- **Potential Dependencies:** UPG-013
- **Suggested Implementation:** Render stored receipts.
- **Technical Considerations:** None.
- **Content Requirements:** Receipt lines per quest.
- **Complexity:** S
- **Priority:** P3
- **Risks:** None.
- **Design Questions:** -
- **Related Ideas:** -
- **Related Upgrades:** UPG-013
- **Related Files:** `Runtime/World/QuestBoard.cs`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I7); recorded as NEW. Not a commitment.

### IDEA-018: Field sketch at a landmark

- **Category:** Exploration / photo mode
- **Description:** Taking a photo at a landmark counts as visiting it and adds a sketch to the journal.
- **Player Experience:** Sightseeing has a record.
- **Gameplay Purpose:** Gives photo mode a purpose.
- **Why It Belongs in AETHWYRD:** Photo mode is built.
- **Player Benefit:** A personal travel journal.
- **Affected Systems:** Photo mode, journal
- **Potential Dependencies:** UPG-009
- **Suggested Implementation:** A landmark volume checked on capture.
- **Technical Considerations:** Screenshot storage.
- **Content Requirements:** Landmark volumes.
- **Complexity:** M
- **Priority:** P4
- **Risks:** Storage.
- **Design Questions:** -
- **Related Ideas:** IDEA-015
- **Related Upgrades:** UPG-009
- **Related Files:** `Code/Ascend.Core/PhotoMode.cs`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: exploration I8); recorded as NEW. Not a commitment.

### IDEA-019: Hunter's mark from appraisal

- **Category:** Combat / identity
- **Description:** Appraising a monster reveals its weakness, and under the Lying Interface it is sometimes wrong.
- **Player Experience:** Trust, then verify.
- **Gameplay Purpose:** Links knowledge to combat.
- **Why It Belongs in AETHWYRD:** Unique to this game's premise.
- **Player Benefit:** A reason to appraise.
- **Affected Systems:** Appraisal, damage
- **Potential Dependencies:** IDEA-001; UPG-008
- **Suggested Implementation:** A displayed weakness with an authored lie list.
- **Technical Considerations:** None.
- **Content Requirements:** A lie list.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Feels unfair if lies are frequent.
- **Design Questions:** How often may it lie?
- **Related Ideas:** IDEA-001, IDEA-002
- **Related Upgrades:** UPG-008, UPG-012
- **Related Files:** -
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I6); recorded as NEW. Not a commitment.

### IDEA-020: Three material classes in the world

- **Category:** Combat / environment
- **Description:** Dry grass, shallow water and ice, authored per region, so wildfire and storm reactions have places to happen.
- **Player Experience:** The terrain is a weapon.
- **Gameplay Purpose:** Environmental combat with a hard cap on scope.
- **Why It Belongs in AETHWYRD:** `combat.md` §15 asks for a small number of environmental payoffs.
- **Player Benefit:** Clever fights.
- **Affected Systems:** Reactions, scene
- **Potential Dependencies:** UPG-003
- **Suggested Implementation:** Tagged ground volumes.
- **Technical Considerations:** Zone spawning exists for Firestorm.
- **Content Requirements:** Volumes per region.
- **Complexity:** L
- **Priority:** P4
- **Risks:** Scope.
- **Design Questions:** -
- **Related Ideas:** -
- **Related Upgrades:** UPG-003
- **Related Files:** `12_Systems/combat.md` §15
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I7); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-021: Directional guard for shield classes

- **Category:** Combat
- **Description:** Block reduces damage only from the front, for classes with a shield.
- **Player Experience:** Positioning matters for the Guardian.
- **Gameplay Purpose:** Class identity.
- **Why It Belongs in AETHWYRD:** Class-based progression.
- **Player Benefit:** A distinct defensive style.
- **Affected Systems:** Defence
- **Potential Dependencies:** A playable Guardian (UPG-034)
- **Suggested Implementation:** A front cone in the defence judge.
- **Technical Considerations:** Small.
- **Content Requirements:** None.
- **Complexity:** M
- **Priority:** P4
- **Risks:** May conflict with 'viable non-parry defence'.
- **Design Questions:** -
- **Related Ideas:** -
- **Related Upgrades:** UPG-034
- **Related Files:** `Code/Ascend.Core/Defense.cs`
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I8); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-022: Tell clips in the journal

- **Category:** Knowledge
- **Description:** After seeing an attack, the journal keeps its silhouette for study.
- **Player Experience:** Homework for a hard fight.
- **Gameplay Purpose:** Staged combat knowledge.
- **Why It Belongs in AETHWYRD:** Knowledge as progression.
- **Player Benefit:** Mastery.
- **Affected Systems:** Journal, animation
- **Potential Dependencies:** UPG-008
- **Suggested Implementation:** A stored pose sequence.
- **Technical Considerations:** Needs real animation.
- **Content Requirements:** None.
- **Complexity:** M
- **Priority:** P4
- **Risks:** Needs art that does not exist.
- **Design Questions:** -
- **Related Ideas:** -
- **Related Upgrades:** UPG-008
- **Related Files:** -
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I3); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-023: Readable pack composure

- **Category:** Combat feedback
- **Description:** A pack about to break shows it: stance and ears change before they retreat.
- **Player Experience:** You can see a fight turning.
- **Gameplay Purpose:** Makes group tactics legible.
- **Why It Belongs in AETHWYRD:** Readability contract.
- **Player Benefit:** Tension and release.
- **Affected Systems:** Monster animation
- **Potential Dependencies:** UPG-002
- **Suggested Implementation:** A pose driven by the retreat chance.
- **Technical Considerations:** Procedural animation.
- **Content Requirements:** None.
- **Complexity:** S
- **Priority:** P3
- **Risks:** Animation budget.
- **Design Questions:** -
- **Related Ideas:** IDEA-007
- **Related Upgrades:** UPG-002
- **Related Files:** -
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat I4); recorded as NEW. Not a commitment.

### IDEA-024: Companion as teacher

- **Category:** Companions / progression
- **Description:** A relationship stage unlocks a technique or a class hint taught by that companion.
- **Player Experience:** Friends make you better.
- **Gameplay Purpose:** Ties the relationship tracks to play.
- **Why It Belongs in AETHWYRD:** Partners, not tools.
- **Player Benefit:** Bonds with a tangible gift.
- **Affected Systems:** Companions, skills
- **Potential Dependencies:** More than one recruitable companion
- **Suggested Implementation:** A reward field on relationship stages.
- **Technical Considerations:** Data only.
- **Content Requirements:** One technique per companion.
- **Complexity:** M
- **Priority:** P3
- **Risks:** Scope with 14 companions.
- **Design Questions:** -
- **Related Ideas:** IDEA-011
- **Related Upgrades:** -
- **Related Files:** `Data/Companions/companion_rules.json`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression I1); recorded as NEW. Not a commitment.

### IDEA-025: Lying appraisal on gear

- **Category:** Crafting / identity
- **Description:** Rune descriptions are misleading until your craft skill reveals the truth.
- **Player Experience:** The System undersells what it does not want you to use.
- **Gameplay Purpose:** Gives life skills a discovery role.
- **Why It Belongs in AETHWYRD:** The Lying Interface applied to items.
- **Player Benefit:** Hidden gems.
- **Affected Systems:** Runes, life skills
- **Potential Dependencies:** IDEA-001; runes reachable (UPG-037)
- **Suggested Implementation:** Two description strings and a skill gate.
- **Technical Considerations:** Data only.
- **Content Requirements:** Alternate strings.
- **Complexity:** M
- **Priority:** P4
- **Risks:** Confusing shop decisions.
- **Design Questions:** -
- **Related Ideas:** IDEA-001
- **Related Upgrades:** UPG-037
- **Related Files:** `Data/Classes/rune_skills.json`
- **Status:** NEW
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression I2); recorded as NEW. Not a commitment.

### IDEA-026: The home farm as the economy's teacher, with a festival sink

- **Category:** Economy
- **Description:** The first farm plot teaches faucets and sinks; a seasonal festival consumes goods.
- **Player Experience:** Your crops matter to the town.
- **Gameplay Purpose:** A drain for the farming faucet.
- **Why It Belongs in AETHWYRD:** Slow life, not chores.
- **Player Benefit:** A reason to grow things.
- **Affected Systems:** Housing, farming, calendar
- **Potential Dependencies:** Farming reachable (UPG-037); CD-014
- **Suggested Implementation:** A weekly-board festival that buys goods.
- **Technical Considerations:** Uses the weekly board.
- **Content Requirements:** Festival rows.
- **Complexity:** M
- **Priority:** P4
- **Risks:** None.
- **Design Questions:** -
- **Related Ideas:** -
- **Related Upgrades:** UPG-036
- **Related Files:** `12_Systems/housing_and_farming.md`
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: progression I3); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.

### IDEA-027: A status-effect framework beyond freeze and stun

- **Category:** Combat
- **Description:** Bleed, poison, slow and the rest as one data-driven framework.
- **Player Experience:** Builds and counters.
- **Gameplay Purpose:** Depth for classes and monsters.
- **Why It Belongs in AETHWYRD:** Elements and reactions already create states.
- **Player Benefit:** More ways to fight.
- **Affected Systems:** Damage, UI
- **Potential Dependencies:** UPG-003, UPG-004
- **Suggested Implementation:** One effect table and a tick.
- **Technical Considerations:** Per-frame cost per affected actor.
- **Content Requirements:** Effect data.
- **Complexity:** L
- **Priority:** P4
- **Risks:** Fourteen effects asked for; cost is high.
- **Design Questions:** Ring 1 or later?
- **Related Ideas:** -
- **Related Upgrades:** UPG-003
- **Related Files:** `12_Systems/combat.md` §7a
- **Status:** DEFERRED
- **Date Added:** 2026-11-12
- **Decision History:** 2026-11-12, orchestrator: entered from the 2026-11-12 audits (source: combat SYS-CMB-09; owner's combat prompt Part 8); DEFERRED: too costly or too dependent before the vertical slice gate; kept so it is not lost. Not a commitment.
