# World Response and Information Flow

**Status:** design proposal. Canon.md and `Data/` remain authoritative. This document connects existing systems; it does not add a new online mode, new factions, or new lore.

## 1. The connective promise

The world should not merely change in response to the player. It should help the player understand **what changed, what caused it, who knows, and what choices remain**. A broken road, a newly stocked apothecary, a companion's challenge, a rumor at the guild, and a changed monster route should feel like parts of the same world.

### Core pattern: signal → interpretation → action → consequence → receipt

1. **Signal:** something observable appears: tracks, a closed stall, a worried guard, a changed soundscape, a board notice, a companion glance.
2. **Interpretation:** the player forms a theory, asks someone, checks the journal or uses a tool.
3. **Action:** the player chooses a response: investigate, fight, bargain, prepare, help, wait, or leave.
4. **Consequence:** a system updates within its plausible range: monster behavior, quest state, safety, stock, trust, route access or a relationship.
5. **Receipt:** the player receives a clear but diegetic confirmation: a new rumor, a repaired wall, a ledger entry, a letter, a changed service, or a character remembering.

The pattern should be available across the open world without requiring every action to create a new bespoke quest. Small actions get small receipts; major choices get staged consequences.

## 2. The design gap this closes

Ascend already contains quests, siege, ecology, journals, companion memory, local markets, named NPCs, prosperity, rank, guild boards and endings. The risk is that each subsystem has an internal state but no shared rule for communicating that state. The player then experiences effects as random: prices shift without explanation, a monster migrates without a clue, an NPC reacts to news they could not know, or a quest award has no visible use.

The shared information-flow rule is:

- every state change has a **cause record**;
- every cause record names the **affected scope** (person, encounter, settlement, region, faction, story);
- each scope has a **knowledge route** (witness, party, notice, courier, public event, guild record);
- each important result has a **player-visible receipt**;
- no scope learns facts beyond its plausible sources;
- the journal distinguishes fact, report and inference.

This complements the proposed bounded NPC memory in `cultural_presence_and_named_population.md` and the evidence model in `reactive_world_and_field_journal.md`.

## 3. Information layers

### 3.1 Physical world

Use sound, silhouette, animation, light, weather, prop state, crowd behavior and traversal affordances. The player should often notice the first hint without opening a menu. Examples: fresh drag marks, an empty market stall, a lantern that has gone dark, birds refusing a cliff face, a barricade repaired overnight, or a companion watching the treeline.

### 3.2 Social world

Characters communicate what they know, need and believe. Dialogue should distinguish observation from rumor. A guard may say “I saw the eastern gate break”; a trader may say “I heard the northern road is unsafe”; a companion may say “Those tracks look too wide for the story we were told.” These lines do not become omniscient truth merely because an NPC said them.

### 3.3 Institutional world

Boards, guild records, maps, letters, trade notices and local ledgers make durable information available. Institutions are useful because they preserve facts when the witness leaves. They can also be biased, incomplete or politically shaped, but the game should indicate provenance.

### 3.4 System interface

The Status System is a helpful interpreter with an uncanny personality, not a universal narrator. It can summarize the player's observations, estimate a threat and explain a known rule. It should mark uncertainty and avoid revealing hidden causes the player has not discovered. Guidance settings determine how explicit the prompt becomes, not whether content exists.

### 3.5 Memory and recap

The journal keeps evidence, promises, contract outcomes, region changes and personally captured Memory Reel moments. It is not a transcript of every line. It should help a returning player recall *why* a place or person matters and give them a clear next lead.

## 4. Knowledge provenance model

Every world fact that can affect a reaction or decision should have one provenance label:

| Label | Meaning | Example |
|---|---|---|
| **Witnessed** | The player or NPC directly observed it | “I watched the goblins drag the bell from the mill.” |
| **Measured** | A tool or trained skill produced a reading | Appraisal estimates a core's rank; tracking identifies a fresh trail |
| **Reported** | A named source or institution conveyed it | The guild board reports a caravan missing |
| **Inferred** | Evidence supports a hypothesis, but it may be wrong | The monster may be avoiding the river after the storm |
| **Rumored** | The source chain is uncertain | Someone heard that a shrine is glowing at night |
| **Revealed** | A quest or story scene confirms a hidden fact | A forged record is exposed by testimony and proof |

The player-facing journal can use clear language and icons rather than forcing them to learn abstract labels. A clue card includes source, date, confidence, what it suggests, and what could disprove it. Confidence changes only when new evidence arrives, not because the player waited.

### Knowledge decay and correction

Facts about a past event do not disappear. Current conditions can change: a road report becomes stale, a nest moves, a market shortage resolves. Mark only volatile facts as time-sensitive. When a rumor proves false, preserve the original claim and add the correction so the player can see how the misunderstanding spread.

## 5. Consequence horizons

Give each player action a consequence horizon. Not every interaction should propagate everywhere.

| Horizon | Time | Examples | Receipt |
|---|---|---|---|
| **Immediate** | Seconds to minutes | Hit, break, rescue, lie exposed, companion assist | Animation, sound, short response |
| **Local** | Same visit/day | Shop stock, a witness reaction, guard patrol, open path | Service/prop/dialogue change |
| **Near-term** | Several in-game days | Board request, merchant arrival, rumor travel, repairs | Notice, letter, schedule event |
| **Regional** | Weeks or a Tyrant outcome | Liberation festival, road safety, migration shift | World-state scene and region summary |
| **Personal** | Across a relationship arc | Promise kept, trust broken, companion departure/reunion | Conversation, callback, quest state |
| **Story-long** | Acts and endings | Alliance, god's attention, hidden truth, ending variation | Milestone scene and journal record |

Use the smallest horizon that makes the choice meaningful. If every side quest changes the ending, endings lose authorship. If a major choice has no near-term sign, the player cannot connect action to result.

## 6. Shared event vocabulary

To keep multiple systems consistent, authored events can be represented using a small vocabulary:

- `ThreatSpotted`, `ThreatMisidentified`, `ThreatDefeated`, `ThreatEscaped`, `ThreatRelocated`
- `PartRecovered`, `CoreRecovered`, `CoreSpoiled`, `MonsterSpared`, `MonsterNegotiated`, `CommunityHarmed`
- `ContractAccepted`, `ContractCompleted`, `ContractFailed`, `ContractAbandoned`, `ProofFiled`
- `SettlementAttacked`, `DefenceWon`, `DefenceMissed`, `RouteOpened`, `RouteBlocked`, `BuildingRepaired`
- `PromiseMade`, `PromiseKept`, `PromiseBroken`, `WitnessProtected`, `WitnessLost`
- `MarketSupplied`, `MarketScarcity`, `CommissionFulfilled`, `ServiceRestored`
- `CompanionSupported`, `CompanionChallenged`, `CompanionLeft`, `CompanionReturned`

This is a proposed vocabulary for data and authoring, not 20 new standalone features. Start with events already needed by implemented quests, siege, item rewards and relationship states. Events need an owner, source, scope, timestamp, story-state conditions and a list of permitted reactions.

### Finite event record and response bundles

Use a finite, authored event ledger; it is a record of consequential facts, not an open-ended simulation. A record stores: stable `eventId` and `causeId`; event type and source kind/ID; place and in-game time; affected scope; witnesses or named report path; confidence/evidence; plausible audience and propagation channel/delay; allowed response IDs; expiry/recency rule for volatile conditions; and the player-facing receipt ID/status. Preserve conflicting reports as separate records. The same event must not silently become more certain through time alone. Save records deterministically, deduplicate by event/result key, and cap routine history by authored retention rules while retaining story-critical records.

An allowed response is explicitly whitelisted for that event and scope: for example, a nearby witness bark, a local board entry after proof is filed, a route/patrol/service state, a journal update, or an authored quest callback. Distant residents and institutions react only after a valid channel and delay. Each consequential record identifies at least one receipt; major outcomes use a durable journal/board receipt plus a perceivable world or social change. This operationalizes Canon §6's proposed bounded memory and information rules; it does not authorize procedural rumor propagation.

For liberation and quest outcomes, author reusable **local response bundles** rather than branching every resident. A bundle references a small set of response slots—environment/route, patrol or encounter pressure, service/merchant, board/rumor, ambient/social cue, and journal recap—and supplies before/after state keys plus eligibility conditions. A liberation bundle can stop siege notices, open a safe route or service, adjust local faction pressure, and acknowledge recovery while ordinary ecology and repairable damage remain. A quest bundle selects only slots justified by its stakes and witnesses. Reuse templates, but keep region-specific cues authored; never imply that settlements were destroyed, companions died, or losses occurred contrary to Canon §5. Full field definitions and journal behavior live in [[../10_World/reactive_world_and_field_journal]].

## 7. Cross-system response matrix

| Player action | Immediate result | Local response | Longer response | Avoid |
|---|---|---|---|---|
| Identify a monster's feeding site | Bestiary clue becomes observed | Nearby hunters can comment if they know the player found it | Contract offers a more precise route or safer approach | Telepathic region-wide knowledge |
| Recover a clean core | Inventory and journal record its rank/trait | Guild researcher offers use or exchange | A local recipe, study or supply request progresses | Making every core mandatory currency |
| Sell surplus cores | Exact payment and quantity preview | Guild stock receipt or posted price | None unless an authored request uses them | Price whiplash after ordinary sale |
| Spare an intelligent monster | Combat ends or negotiation begins | Companions and witnesses react by values | Monster community may change trust or future access | Treating all monsters as morally identical |
| Defeat a siege wave | Prosperity/reputation reward is posted | Guards and residents acknowledge defense | Board records who helped; next wave still follows world rules | Infinite grind loop or missed-event punishment |
| Kill a Tyrant | Liberation sequence starts | Main settlement and board update | Routes, safety, services and rumors change | Erasing grief or all local danger instantly |
| Help a market shortage | Goods become available after clear time | Shopkeeper explains source and stock | Route or prosperity changes if authored | Simulating every household purchase |
| Fail or abandon a contract | Failure reason is recorded | Clerk updates standing and gives recovery info | Client or region reacts proportionately | Combining gold fine, demotion and permanent loss for a routine job |
| Make a public promise | Journal records promise and scope | Companions ask why it matters | Later reminder before a genuine deadline | Hidden timers or surprise betrayal by the quest system |
| Use a shortcut or teleport | Time/cost shown before use | Arrival cues show where the player landed | Discovery of route connection is recorded | Making known travel artificially tedious |

## 8. The player-facing receipt

A receipt can be a non-UI event as well as a text notification. For each important consequence choose the best channel:

- **Visual:** repaired shutters, a new sign, a cleared road, a changed monster den.
- **Audio:** new market calls, quieter watch bell, changed local music, a familiar voice calling the player by rank.
- **Social:** thanks, suspicion, negotiation, an argument, a remembered promise.
- **Institutional:** board update, new contract, modified guild note, posted wanted notice.
- **Mechanical:** shop service, route access, craft recipe, reduced threat, a safe rest point.
- **Journal:** a compact record of what changed and the known reason.
- **Photo/memory:** a player-chosen moment, not an automatically forced screenshot.

Do not display all channels on every event. Use one strong immediate signal and one durable record for major outcomes. Minor moments can remain implicit unless the player investigates.

### Status Window response format

When helpful, the System can summarize:

**Observed:** the east granary is damaged.  
**Reported:** the guard captain says the attack came before dawn.  
**Likely:** a fast ground creature crossed the ditch.  
**Next lead:** inspect the mud trail or ask the night watch.  
**Uncertain:** the trail does not yet identify the species.

This supports both the user's anime interface preference and fair mystery. Make the System voice brief and personal, and let players reduce its frequency.

## 9. Environmental guidance and player agency

Ghost of Tsushima's developers describe turning an established visual direction—wind and movement—into a navigation aid that could guide players toward tracked objectives and optional discoveries. Their stated goal included keeping players in the world. Ascend inference: the Status System's “Thread” or a region's natural signals could guide toward a known lead without laying a permanent glowing road. Keep conventional map markers and accessibility options available. [PlayStation Blog: Ghost of Tsushima questions answered](https://blog.playstation.com/2020/05/29/ghost-of-tsushima-your-questions-answered/)

The three guidance strengths:

1. **World cue:** sound, wind, flock, light, tracks, companion attention or architecture.
2. **Search area:** a region or landmark highlighted in the journal/map.
3. **Direct route:** a clear marker and route line for a tracked objective.

Players can choose the strongest active guidance channel. Essential objectives always have an accessible route. Optional mysteries can be discoverable without being necessary for rank or story progression.

## 10. Guild, markets and world information

The guild is the main information router for adventurers, not the source of all truth. It verifies contracts, stores proof, reports monster ranks, circulates route notes, announces defense events and posts requests for materials. The branch should distinguish:

- confirmed facts from filed proof;
- a client's account from a guild assessment;
- rumors worth investigating;
- market wanted notices and exchange offers;
- urgent events and repeatable work.

Guild chatter makes this system social. An adventurer may disagree with a report, tell a rookie to check evidence, complain about the price of a silver repair, or decide whether to sell a core or reserve it for crafting. These conversations point toward systems while conveying character.

Markets should give reasons for their stock. A trader can say which route reopened, an apothecary can explain a shortage, and a smith can point to a local material. The final price remains visible and stable enough to plan. No rumor is a secret price modifier.

## 11. Region state as a compact dashboard

Each region can track a compact world state, not a full simulation:

- **Threat:** current siege/Tyrant pressure and ordinary world-event alert.
- **Safety:** patrols, defensible roads, recent attacks.
- **Prosperity:** material capacity, trade access, repairs and market range.
- **Morale:** public confidence, grief, celebration and trust in institutions.
- **Ecology:** a few monitored species populations, migration signals and den states.
- **Knowledge:** known routes, confirmed monster information, unresolved rumors.
- **Relationships:** local faction and clan attitudes that have authored consequences.

The player does not need a numeric dashboard for every value. Numbers can drive data and the HUD can summarize “stable,” “strained,” “recovering” or “under pressure,” with a link to the visible reasons. Keep exact numbers available in a detailed status view for players who want them.

### State change budget

For each major state transition, select no more than a few high-signal effects for the first implementation: one environment change, one social or schedule change, one service/board change, and one optional story callback. This ensures the transition reads clearly while limiting authored branch multiplication.

## 12. The ecology-to-economy bridge

Monster ecology becomes more meaningful when it joins the economy carefully:

1. Weather, food or a den change alters a small species population state.
2. Field clues and rumor let the player discover why the species moved.
3. The contract can offer removal, relocation, defense or negotiation where fitting.
4. The outcome shifts a limited stock group (forage, hides, tools, medicine or travel goods).
5. A merchant, crafter or community gives a visible response.
6. The journal records the new local condition and a future lead.

Do not create a player-driven market collapse for every kill. Population and price changes occur at weekly or authored milestones with bounded effects. Ecosystem health changes resource access and encounter patterns first; prices are a supporting signal, not the sole consequence.

## 13. Companion interpretation and disagreement

Companions are witnesses with distinct values, skills and knowledge. They should not be a notification layer that explains every landmark. Their field dialogue can:

- notice something their role would plausibly notice;
- offer a hypothesis and mark it as theirs;
- disagree with another party member;
- ask the player why they favor a certain route or outcome;
- recall a prior promise at a relevant moment;
- stop commenting when the topic is exhausted.

Companion cues should be redundant for essential information: a visual or journal path remains available. Their opinions affect trust and conversation, not a secret correctness meter. A companion can think a choice is wrong and remain loyal; departures follow their authored thresholds and Canon loss rules.

## 14. Questions and player learning

Every new mechanic should teach through a small chain:

1. **First example:** safe, explicit, low-pressure.
2. **Second example:** changes one condition so the player applies the rule.
3. **Mastery case:** combines the rule with another system and rewards anticipation.
4. **Counterexample:** a later encounter shows the limits of the rule.

Example: the player learns that a horned rabbit's hind-leg crouch predicts a charge; then sees one use a feint; later discovers the herd responds to a wounded member. The player's knowledge grows beyond “press dodge when icon flashes.”

Avoid dumping encyclopedic information at once. Provide a concise hint when an immediate decision depends on it, a journal entry for later recall and optional deeper material for curious players.

## 15. Event queues and scope control

An authored event record can include:

`eventId`, `causeId`, `sourceActor`, `eventType`, `scope`, `regionId`, `dayNumber`, `witnesses`, `proofIds`, `certainty`, `visibilityChannels`, `eligibleReactions`, `storyFlags`, `expiryRule`.

Only implement these fields as systems need them. A useful first version can store a stable event ID, type, owner, region, day, evidence and resulting flags. Avoid a general simulation engine capable of thousands of unseen reactions before the Ring 0 slice proves the value.

### Update order

1. Resolve the immediate encounter.
2. Record evidence and proof.
3. Update the active quest/contract.
4. Apply local settlement or ecology state.
5. Send information through plausible channels.
6. Schedule delayed reactions at the next world tick.
7. Present the receipt once, and save it for journal/history.

This order prevents a quest board from posting a result before the player reports it, or a distant merchant reacting before a rumor could arrive.

## 16. Save, reload and time behavior

Persistent world events must survive save/load without duplicating rewards or repeating major reactions. Each event has an idempotent result key. If the player reloads before a delayed rumor arrives, the event remains pending with the same due date. If the player is away, consequences resolve by coarse scheduled events, not real-world clock or live server time.

The player can pause, stop for weeks or return after a long break without companions dying from unpaid fees, prices changing while offline or a daily contract expiring due to real-world time. The calendar advances only through in-game activities under the project rules.

## 17. Accessibility and control

- Every important clue is available through more than one sensory channel: color + shape, audio + subtitle, animation + text or map + journal.
- Give adjustable subtitle size, speaker labels, background opacity and ambient-dialogue captions.
- Make guidance intensity configurable independently from difficulty.
- Allow dialogue bark frequency to be reduced; retain essential combat callouts or provide visual alternatives.
- Let players review recent important world changes in a compact journal feed.
- Avoid time-limited menus or twitch tests for prices, craft quality or rumor interpretation.
- Avoid requiring color recognition for rank or threat; pair rank colors with letters and icons.

## 18. Research: what transfers and what does not

### Ghost of Tsushima: environmental guidance

Sucker Punch describes shaping wind into a diegetic navigation cue, including tracked objectives and optional discoveries. Transfer: align guidance with the world’s visual language and preserve player attention. Do not remove direct navigation controls or assume all players can read subtle wind/foliage cues. [PlayStation Blog](https://blog.playstation.com/2020/05/29/ghost-of-tsushima-your-questions-answered/)

### Fable: coherence costs of a living population

Playground Games describes moving from incoherent procedural NPCs to hand-authored population records, and details how schedules imply homes, beds, jobs and reliable settlement layouts. Transfer: build character coherence and state ownership before promising deep simulation. For Ascend's team size, keep the aggregate + named card + anchor cast + story cast layers already proposed; do not imitate Fable's simulation scope. [Xbox Wire: How We Built the Living Population](https://news.xbox.com/en-us/2026/06/10/fable-living-population-details-explained-xbox-games-showcase-2026/)

### Horizon Forbidden West: readable cause-and-effect in hunting and markets

Guerrilla describes culturally grounded vendor roles, specific machine parts for upgrades, scanning to identify needed parts, and merchants as a fallback route for selling valuables. Transfer: show the source and use of a resource; tie a local market to local work; give the player a clue to the required part. Preserve an accessible fallback for essential materials. [PlayStation Blog: An authentic world](https://blog.playstation.com/?p=356989)

### Limits of the comparison

These are first-party descriptions of their own design processes, not independent proof that a mechanic will work in Ascend. The Ascend recommendations are design inferences. Test the information flow in one graybox route and one settlement before expanding it to all 40 regions.

## 19. Ring 0 prototype

### Scenario: “The granary trail”

Use an existing F-rank contract, current Ring 0 monsters and Millbrook/Brindlewick assets. Do not create a new named NPC or quest for the prototype.

1. The board reports a granary problem and identifies a requester, payment and uncertain threat estimate.
2. At the site, physical clues distinguish a slime trail from rabbit tracks; the player can inspect, ask a nearby worker or fight immediately.
3. A companion notices a clue only if their role and distance support it; no companion cue is required to solve the encounter.
4. The player can fight or use the contract's existing nonlethal/relocation option if present.
5. A valid core and proof are recorded once. A damaged/poorly recovered core still has a safe sale route and does not block the quest reward.
6. Turning in updates the board and coin, shows core disposition and gives one NPC a relevant response.
7. The journal records observed evidence and confirmed result separately.

### Prototype measures

- Can players tell what the contract giver knows versus what is uncertain?
- Does the first clue invite a decision without requiring pixel hunting?
- Can players complete the task if they ignore the journal or companion line?
- Does each reward have a clear use or sale value?
- Is the result acknowledged at turn-in and in the world?
- Can a player explain why the response occurred?
- Does saving/reloading avoid duplicate core, coin or reputation rewards?

## 20. Add-on options by production risk

| Option | Value | Risk/cost | Recommendation |
|---|---|---|---|
| Wind/thread environmental guide | Diegetic wayfinding | VFX consistency, accessibility | Prototype as an optional cue in one route |
| Rumor provenance card | Makes mystery fair | Journal UI and data tagging | Add to investigation contracts first |
| Settlement change postcards | Clear regional feedback | UI content overhead | Prefer diegetic board/letter plus world changes |
| Weekly town ledger | Connects routes, stock and prosperity | Could become spreadsheet | Keep to 3–5 meaningful changes |
| Named NPC memory callbacks | Emotional continuity | Authoring and QA | Reserve for anchor/story cast and witnesses |
| Automatic world-state recap | Helps 1,000-hour returners | Spoiler/overload | Make compact and opt-in at save load |
| In-world rumor correction | Makes misinformation playable | Needs consistent source paths | Use for a few authored quest chains |
| Public online rumor board | Shared discovery | Server/moderation/privacy and spoilers | Do not build into the game; community sites can exist independently |
| Online shared world state | Cooperative consequences | Contradicts single-player canon | Excluded unless the product premise changes |
| Shareable photo cards | Social sharing from photo mode | Platform integration/privacy | Optional offline export or platform share sheet only |
| Cloud save and achievements | Convenience and platform recognition | Platform-specific setup | Platform features, never progression gates |
| Live events / rotating rewards | Recurring engagement | FOMO, servers, ongoing production | Excluded for buy-once single-player RPG |

### Optional platform-feature matrix (proposal)

| Feature | Position | Offline/privacy and dependence | Save/support/tiny-team sequence |
|---|---|---|---|
| Local save | Required foundation | Fully local; no account or network | Platform-neutral versioned saves, backup/restore, and clear recovery before any sync work |
| Cloud sync | Optional later convenience | Opt-in/disableable; offline play remains complete; no developer-hosted save service | Steam Cloud is Steam-dependent. Stabilize schema first; explain conflict choices and retain recoverable local copies. Test stale, duplicate and interrupted-sync cases; support burden is meaningful. |
| Achievements | Optional after milestones settle | Platform/account-associated; never grants gameplay power or required content; secret achievements can hide spoilers | Mirror local events; no Steam initialization failure may block play or saves. Small authored set and later localization/QA. Steam-dependent. |
| Screenshot/photo export | Basic local/platform screenshot support may come early; dedicated photo mode is optional | Player chooses capture/export; uploading is an explicit platform action. No automatic upload or developer gallery. | Screenshot support is lower scope; a polished photo mode adds camera, pose, UI, scene QA and support. Steam Overlay screenshot path is Steam-dependent; local export is portable. |
| Steam Discussions and Guides | Optional external Steam Community surfaces; no in-game forum, chat or feed | Steam/account/community surface; game remains complete without it | Community presence can be limited. Guides and feedback may still need spoiler handling and moderation if the team chooses to participate. |
| Steam Input community layouts | Optional player-created controller layouts | Steam-dependent convenience; core controller support and remapping remain in-game usability work | Validate supported devices and layouts; never make a community layout necessary to play. |
| Steam Remote Play | Treat support as an unverified capability claim until tested on each advertised device | Streams the player's own session; depends on Steam and network/device conditions | Validate legibility, controls, latency tolerance and save behavior on target devices before making a claim. |
| Community posting | Exclude in-game posting, chat, live presence, leaderboards and public rumor feeds | Would create privacy, spoiler and moderation surfaces | No hosted accounts/backend. User-controlled external sharing can use exported artifacts; no team moderation promise. |
| Mods / Workshop | Defer; no launch promise | Workshop is platform-dependent; user content may include spoilers, unsafe files or canon conflicts | Requires formats/tools, validation, compatibility policy, reporting/moderation and ongoing support. Revisit only with demonstrated demand and capacity; start narrowly with data-only content if approved. |
| Excluded features | Remote Play Together, multiplayer/co-op, player trading/marketplaces, live events, rotating rewards, online-gated content/progression, real-world deadlines, telemetry backend and developer-hosted social services | Remote Play Together invites others into local multiplayer, conflicting with single-player canon; other items contradict offline-first scope or add operational obligations | Never required to launch or continue a save; any product-premise change requires explicit canon approval. |

**Offline guarantee:** launch, local saves, all progression, world state, endings and post-story play work without Steam initialization or a network connection. **Sequencing rule:** local save reliability and offline launch come first; optional cloud only after save/version/conflict handling is robust; modest spoiler-aware achievements afterward; screenshots/local export before considering a dedicated photo mode; Workshop remains deferred. Community translation and feedback moderation are possible future options only if the team budgets for curation, localization QA and ongoing support. Platform adapters must fail closed to local play. Steam release planning remains deferred under Canon §1; this is a design boundary, not a release decision.

## 21. Approval candidates for Canon §6

1. **World response contract:** important state changes record cause, scope, knowledge route and player-facing receipt; NPCs only react to plausible knowledge.
2. **Guidance channels:** offer world cue, search area and direct-route options independently; essential content retains an accessible route.
3. **Consequence budget:** major changes use a compact, high-signal set of environmental, social, service/board and journal effects rather than simulating every citizen.
4. **Offline continuity:** no real-world-time consequences, live-service deadlines or online-gated world states.

## Related docs

- [[signature_gameplay_loops]] — player and world loops.
- [[exploration_and_discovery]] — landmarks, leads, guidance and travel.
- [[reactive_world_and_field_journal]] — evidence, ecology and bounded memory.
- [[cultural_presence_and_named_population]] — NPC layers and social change.
- [[quest_outcome_grammar]] — proportionate failure and consequence horizons.
- [[guild_hall_talk_and_lexicon]] — everyday institution dialogue.
- [[item_and_economy_design]] — markets, materials and economic safety.
- [[Canon]] — locked decisions and proposals requiring approval.
