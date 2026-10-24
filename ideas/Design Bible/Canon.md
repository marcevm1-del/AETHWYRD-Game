# CANON — Settled Facts & Spoilers

**This file wins.** If any other doc disagrees with Canon.md, Canon.md is right and the other doc is a bug to fix. Data files in `Data/` are canonical for numbers (stats, habitats, rings); this file is canonical for story and design rules.

⚠️ **Full spoilers below.**

---

## 1. Product (locked)
| Topic | Canon |
|---|---|
| Format | 3D, third-person, **single-player only**, PC |
| Team | The user + Claude |
| Business | Premium, one-time purchase. **Release/Steam planning deferred until near the end** |
| Engine | Unity 6 (URP), data-driven JSON content |
| Art | Bright, flowing **Genshin-style cel-shaded** anime look |
| Music | Mostly instrumental (regional folk + orchestra); anime-rock / J-pop energy for bosses |
| Voice | English first; amount of voice acting TBD by the user |
| Title | Open ("Project Ascend" placeholder). **Ask the user on/after 2026-11-01** |
| Content rules | **No fanservice.** Teen rating; serious themes deepen later. Less comedy, more warmth |

## 2. Numbers
| Thing | Canon |
|---|---|
| Ranks | F, E, D, C, B, A, S, SS, SSS (+ **EX** for monsters only), with −/+ sub-grades |
| Currency | Copper → Silver → Gold → Platinum → Mithril Coin; each denomination is worth 100 of the previous one. Prices are stored in copper and auto-displayed with change |
| Level cap | **300**, then Transcendence T1–T10 at SSS. Bands: F 1–15 · E 16–35 · D 36–60 · C 61–90 · B 91–125 · A 126–165 · S 166–210 · SS 211–260 · SSS 261–300 |
| Pacing | Main story **~200–250 hrs focused**, ~600–800 hrs at explorer pace; **SSS + secret ending ≈ 1,000+ hrs** |
| In-game day | 90 real minutes (tunable 60–120) |
| Week | **7 days**: Solenday, Maelsday, Thorsday, Sylvasday, Kaelsday, Morrowsday, Vexday (Ilvaris has none). ≈10.5 hrs of play per week. Each day has its own quest board theme (`11_Quests_Encounters/weekly_board.md`) |
| Classes | **12 base → 24 advanced → 48 expert** → master → legendary (one per world) + hidden (scenario-unlocked) + monster evolution |
| Endings | **11 main + 1 secret** (*The Thirteenth Star*, ~1,000 hrs); ~100 epilogue variations |
| Villain structure | **Demon Overlord Azrael** + **5 Generals**: Ignarok, Morthis, Zephiel, Rhaka, Lady Nocturne |
| World | **40 surface regions + 5 Underworld layers + Great Labyrinth (120 floors, 3 depth bands) + Vesper (post-game)**. Canonical list: `Data/World/regions.json` |
| Monsters | 287 core species → 640 species + 40 regional Tyrants = 680 → 6,754 population variants (`Data/Monsters/`) · **25 shared rigs** with generated motion & physics (`Data/Monsters/rigs.json`, `motion.json`; rules in `08_Bestiary/monster_motion_bible.md`) |
| NPCs | ~2,500 named NPCs, each with a backstory (150 core · 600 major · 1,750 townsfolk) |

## 3. The Big Secrets
| Secret | Truth | Revealed |
|---|---|---|
| The System | Ilvaris's Status System **harvests** the growth of souls who reach SSS to re-stitch the fraying Weave. Otherworld souls are summoned because they have no growth ceiling | Act V |
| Demon Overlord | **Azrael Noxveil is Adrian Vale, Hero #2** (the smashed statue). He learned the truth, refused to be harvested and was betrayed by the Church | Act V |
| The red moon | **Vesper is Valdrisia**, the lost capital, torn into the sky with its people's souls inside | Act V |
| The Red Prophet | **Malchior Vane = Malgareth Vey**, the first Demon Lord, alive for 3,000 years by body-hopping. His current host is **Brother Caspian**, the blindfolded orphanage monk who gives you your first meal. He wants to **devour Vesper** and become the only harvester. Not redeemable | Act V (Lantern Night) |
| The fake Mina | From early Act III, guild receptionist **Mina is Lady Nocturne** in disguise; the real Mina is imprisoned beneath Vharlen | Act III–IV |
| The Forgotten Ninth | **Ezrath the Unbound**, god of freedom, erased by Ilvaris at the Sundering; he is the **Hooded Traveler** | Act V |
| The inn cat | **Whiskers is Vex**, the god of luck, in disguise (secret companion) | Hidden quest |
| Nyx | A 900-year-old dragon, **Umbrael's daughter**, appearing as a child | Act IV |
| The ranks | Hero #1 **Kaede Aoyama**, a gamer, invented the F–SSS ranks from video games | Act V (her journal) |
| Ashen Gate | Malgareth was **not** destroyed at Ashen Gate; he escaped in a soldier's body | Act V |
| Tomás's seal | Hero #3 **Tomás Reyes** sealed Azrael with his own soul (the Lantern Seal); it cracks in 1024 SC | Act II |
| Floor 120 | The Loom: the Unclosed Knot at the center of the Weave (final superboss TBD) | Post-game |

## 4. Who Can Do What
| Question | Canon |
|---|---|
| Romanceable companions | **Lyra, Seraphine, Kiri, Sir Aldric, Bram, Kaito, Elira, Vexmor, Torvald, Suzune**, plus childhood friends **Tobin and Elsie** (origin-dependent). All are adults. Male and female player characters, no gender locks |
| **Not** romanceable | **Nyx** (childlike appearance, so never, whatever her true age), **Mochi**, Named-monster companions, Whiskers, **Azrael**, **Celestine** |
| Marriage & family | Yes; children are **adopted** |
| Redeemable villains | Dorran "Red Ledger" Hask, Sister Ivy Thorne, Kaito, Grukk the Younger; also Generals Ignarok, Morthis, Rhaka (and partly Zephiel) |
| Never redeemable | Malgareth / the Red Prophet, Lady Nocturne, Diego Alvarez |
| Player cannot | Become king/queen · own a guild · ride flying mounts (flight and teleport are **abilities** only; ground mounts are fine) · return to Earth |
| Dungeon cores | Never allies; dungeons stay reusable |
| Narrator | None. Only the System Voice (player picks male or female; 8 evolving personalities) |
| Fourth wall | Gods and the System speak to the **character**; only *The Unwoven Sky* and *The Thirteenth Star* address the **player** |
| Otherworld memories | Otherworlders remember their former lives and that they died, but the final day is blurred and the cause is unknown. Old-world jobs provide small practical perspectives and dialogue; the new life in Aetheria carries the story |
| Post-story play | After a world-saving ending, the player can continue in a peaceful open-ended world: explore, hunt, build bonds, pursue slow-life activities and help regions recover. Further adventures remain optional |

## 4b. Regions: Siege & Liberation
- Every region has a **Tyrant**. Until it's slain the region is **Besieged**: settlements are attacked **1–2 times per 7-day week** (never two days in a row). Killing the Tyrant **Liberates** the region permanently; its board switches to hunting contracts.
- Missed defences auto-resolve; settlements are never destroyed (§5).
- Full rules: `12_Systems/systems.md` → Regional Siege & Liberation.

## 4c. Inns
- Every settlement has an inn: rooms and rest bonuses, meals, the rumor board, tavern stage, tables, stables, mail. Regular status (Stranger → Guest → Regular → Family) per inn. Marta's tab at the Sleeping Griffon never blocks the player.
- 20 signature inns in `Data/World/inns.json`; rules in `12_Systems/inns.md`.

## 4d. Named Monsters (locked 2026-10-23)
- Named monsters are a **hand-written roster**; none are procedurally generated or promoted. **No enemy hierarchy** (no captains, warchiefs or power struggles).
- They grow with **region state** (ecology, sieges, liberation, story flags), **never from defeating the player**: no personal scars, titles or taunts. The rumor board reports their deeds.
- Sieges **adapt to the defences used** as a region-level wave rule (Big Upgrade §7), not as a personal memory.
- Taming and Name-Giving stay. Rules: `12_Systems/systems.md` → Named Monsters. Reason: Warner Bros.' Nemesis patent (to ~2036); **IP lawyer review before release.**

## 5. Loss Rules (protecting a 1,000-hour game)
- **Companion combat death is opt-in** (*Mortal Bonds* option; Hardcore turns it on). Otherwise downed companions are only "gravely wounded."
- **Story deaths** happen only through clearly signposted choices.
- Pack animals and porters are knocked out (cargo recoverable) on default settings; they die only with Hardcore/Mortal Bonds.
- Respec is always possible (free to Lv 10; one free token per class-tier change).
- Character level and learned skills are never lost on class change.

## 6. Proposed Locks (need the user's OK)
| Item | Proposal | Why |
|---|---|---|
| Companion roster | **12 companions + 2 childhood friends**, no more human-cast companions added after this | Romance + permadeath + mutual exclusivity + 12 endings multiply writing; capping the cast caps that |
| Named-monster companions | A **lighter dialogue tier**: personality, banter, bond levels, no romance or full personal arc | Lets the named-monster-to-companion path scale (Canon §4d) |
| **Big Upgrade** | Adopt the 52 signature features in `01_Core_Concept/the_big_upgrade.md` (Lying Interface, Appraisal detective work, hidden Thread growth, Otherworld Knowledge economy, the Next Summoning NG+, Legend system, learning Tyrants, chant mastery, monster cuisine, Adventurer Times & Rankings, mentoring newcomers, and more) and the HUD/UI spec in `12_Systems/hud_and_ui.md` | Gives Ascend its own identity on top of the full trope set |
| Ring 1 Tyrant | **Goblin Chief of Hollowpine** is the Tyrant of **Whisperwood** (his camp's region); his raids hit Brindlewick and Millbrook. His death is also the F→E trial, so Brindlewick's first siege ends with Act I. Aldmere's own Tyrant is **Ashgrave, the Oathless Baron** (C+) | No clash with the story: the trial *is* the Tyrant fight, and Grukk the Younger's revenge returns later as a remnant raid |
| Tyrant roster | 40 regional Tyrants (table in `12_Systems/systems.md`), mostly bosses already in the bestiary; 9 regions exempt (`noSiege`). Generals stay Act IV story bosses, not Tyrants | Every region needs one; band-appropriate Tyrants keep sieges beatable when the region is reached |
| Borrowed features | Adopt the 30 adapted mechanics in `01_Core_Concept/borrowed_features.md` (companion inclinations, hangouts, party skits, class affinity, wounds & part breaks, Echo Shards, class path actions, research tasks, egg nests, Mana Motes, ecology cycles, lantern echoes, restoration bundles, monster workers, villager traits, field outfits, material traits, feasts, guiding wisp, evening choices, Switch hand-offs, Command vs Free Rein, Death Game presentation for Hardcore, waystone respawns, Labyrinth raid councils, the Day the Windows Glitched, the Veilborn Circle) | Proven fun, built on existing systems |
| Ring 2 roster | Trim ~145 tagged species to ~60 cores during Ring 2 planning | Art budget for two people |
| Whisperwood Kinship Arc | Draft the Sella relationship arc in `02_Lore/whisperwood_kinship_arc.md`: mutual first fight, inherited clan mistrust, Azrael's agents forging history, a preventable summit attack, and a joint response to monster migration | Builds on Hollowpine and gives the opening a character-led anime arc. Sella's long-term companion status may require a companion-roster decision |
| Field journal and hunt deduction | Connect observed/reported clues to bestiary hypotheses, counter suggestions and hunt route choices; keep uncertainty explicit and let brute force remain viable | Makes investigation valuable while avoiding a mandatory puzzle gate |
| Bounded NPC memory | Nearby and scene-critical NPCs react to plausible witnessed events; rumors move through explicit local channels; distant populations update in cheaper tiers | Makes consequences believable without claiming bespoke simulation for all 2,500 named residents |
| Region discovery and liberation delta | Use the landmark/lead/unmarked-discovery kit and give each liberated region a small visible delta: route, patrol/merchant, encounter, board/rumor and ambient cues | Makes exploration legible and liberation perceptible while controlling combinatorial content |
| Diegetic guidance | Let the player choose System thread, natural cues, companion guidance, conventional markers or no active guidance; retain accessibility equivalents | Makes navigation feel native to Aetheria while preserving player control |
| Ring 0 combat/readability contract | Prioritize weapon-specific rhythm, redundant attack cues, adjustable assists and viable non-parry defense; difficulty changes pressure and patterns before enemy health | Protects the promised fluid combat and broadens accessibility |
| Companion support economy | Optional meals, lodging, gifts and equipment create bond moments; companions never require recurring survival payments | Grounds party life without turning upkeep into a daily chore or surprise loss |
| Companion field AI | Partners act autonomously through role/personality profiles and a small intent-command wheel; autonomy, banter and cues are adjustable | Makes allies feel capable and individual without taking control away from the player |
| Progression without repetition debt | Make long-term advancement combine levels, skill mastery, professional trust, world knowledge and legacy; no daily decay or mandatory repeated contracts | Protects the 1,000-hour ambition from becoming a grind wall |
| Cultural presence kit | Express cultures through material, gesture, sound, social rhythm and internal variety; use reviewed authored NPC records at several depth tiers | Makes cultures memorable while keeping 2,500 named residents distinct from 2,500 bespoke full simulations |
| Quest outcome grammar | Use a clear quest spine with a few meaningful approaches, proportionate consequence horizons and a playable recovery route | Preserves player freedom and anime-variety contracts without branching every line |
| Adaptive music and anime punctuation | Use gameplay-state music transitions and brief authored flourishes for high-value moments; preserve control in ordinary combat | Gives fights and bonds emotional identity while containing cinematics and composition scope |
| Party synergy | Add short AI-controlled companion assists triggered by player-created openings; player control never leaves the protagonist | Makes bonds tangible in combat while respecting the no-character-swap rule |
| Boss encounter storytelling | Make phase changes alter tactical questions; tie monologues and music to safe, authored triggers; preserve control in ordinary combat | Makes anime drama emerge from the fight while keeping tells fair |
| Companion relationship pacing | Track trust, respect, closeness and tension separately; romance is opt-in; departures are foreshadowed and follow existing recovery/loss rules | Keeps companions emotionally rich without one approval meter or forced romance |
| Item economy guardrails | Use bounded, visible market modifiers and show the final quote; guild rank does not exponentially inflate routine goods | Lets the player plan purchases and avoids runaway inflation |
| Default gear condition | Gear never loses combat effectiveness or breaks through ordinary wear; any performance penalties are opt-in and recoverable | Keeps a long open-world trip from becoming a maintenance chore |
| Relic acquisition | Pure-random drops may accelerate a chase but cannot be the only route to essential or signature gear | Protects long-term progression from bad luck while preserving exciting drops |
| Material usefulness | Production materials need a primary use, a secondary sink and a clear sell/storage route; consolidate redundant variants | Limits dead inventory and content bloat |
| Monster-core price curve | Use the proposed 2c–1,024c F–EX Guild buyback ladder in `09_Equipment/monster_core_pricing.md`; cores remain crafting-first materials, with optional specialist requests | Makes guaranteed core drops predictable side-income without turning rank farming into the main economy |
| Offline-first economy | No player marketplace, real-money currency, loot boxes, daily timers or online-gated rewards under the single-player premium premise | Keeps the game playable offline and aligned with its product promise |
| World response and information | Important reactions record a plausible cause and knowledge path; NPCs respond only to facts they could learn, with a visible receipt for major outcomes | Makes the world reactive without omniscience or untraceable state changes |
| Guidance channels | Let players choose world cues, broad search areas or direct routes independently; essential objectives remain accessible | Supports discovery, personal navigation preference and accessibility |
| Consequence authoring budget | Major state changes use a compact set of high-signal environment, social, service/board and journal feedback | Preserves readable impact while containing branch and writing scope |
| In-game-time continuity | No real-world-time deadlines, live-service world states or online-gated consequences | Protects the long single-player save from offline penalties |
| Town and tavern kit | Treat inns/taverns as social hubs and build town identity through a compact set of legible, useful venues; Brindlewick additions remain optional proposals | Makes towns worth revisiting without turning them into repetitive service menus |
| Deep-history connective detail | Expand the existing chronology with lived experience, competing archives, regional memory and present-day consequences; additions in `02_Lore/history.md` remain draft until reviewed | Gives the mythic timeline human scale while protecting Canon's dates, secrets and spoiler order |
| Veilborn roster and journals | Keep Kaede, Adrian and Tomás as the three formal Heroes. Decide whether the five planned journals include non-Hero witnesses; Amara, Lukas, Ingrid, Chen, Priya and Diego's detailed historical biographies remain unapproved candidates | Resolves the mismatch between the three settled Heroes and older drafts that introduced extra named Veilborn |
| History evidence rule | For major historical claims, pair an account with material or ecological evidence and show who benefits from the public version; treat BSC dates as approximate | Makes investigation playable and avoids a single omniscient history lecture |
| Regional memory atlas | Expand all 49 existing Gazetteer echoes into optional, place-specific evidence and present-day questions as drafted in `02_Lore/history.md`; do not add regions, rulers or dated wars without approval | Turns the established regional hooks into playable history while keeping `Data/World/regions.json` authoritative |
| Worldbuilding research options | Evaluate the proposals in `02_Lore/worldbuilding_research_2026-10-24.md`: bounded ecology links, environmental guidance, town memory, local pastimes and delayed consequence receipts | Applies first-party RPG development lessons to Ascend without copying another game's setting or overpromising simulation |
| Cultural exchange atlas | Treat the six route corridors and exchange threads in `02_Lore/history.md` §XX as map-dependent hypotheses; no new routes, migrations or cultural origins become canon until checked against the world map and approved | Makes regional history feel interconnected while preserving local identity and geographic truth |
| Everyday exchange guidance | Use `02_Lore/life_in_aetheria.md` §14 as optional writing guidance; verify imports, exports and carriers against the map and established region records before treating them as facts | Makes cultural exchange legible in daily life without turning regions into one-note exhibits |
| Local reputation and recoverability | Evaluate the Fable-inspired research options in `02_Lore/worldbuilding_research_2026-10-24.md`: settlement-specific witness-based reputation, story-waits exploration, and recoverable consequences; do not adopt any unreleased game's unverified implementation as fact | Supports the player's freedom to explore while preserving visible social consequences and Canon §5 save safety |
| Recurring town-life rhythm | Evaluate `02_Lore/life_in_aetheria.md` §15: use the locked week/day for readable routines, keep recurring activities optional, avoid real-time pressure, and protect essential access | Makes settlements feel inhabited without turning the calendar into a chore or contradicting the save-safety rules |
| Finite world event memory and response bundles | Evaluate the finite provenance record and reusable local response bundles in `01_Core_Concept/world_response_and_information_flow.md` and `10_World/reactive_world_and_field_journal.md`: source, place/time, confidence, plausible audience/propagation, allowed responses, and a player-facing receipt | Makes reactions traceable and major outcomes legible without open-ended procedural simulation; remains subject to locked siege, single-player, offline and §5 loss rules |
| Returner journal recap and clue parity | Evaluate a dismissible spoiler-safe recap plus independently selectable guidance and accessible equivalent clue channels in `10_World/exploration_and_discovery.md` and `10_World/reactive_world_and_field_journal.md` | Helps players resume a long save and reach essential leads through their preferred sensory/navigation channel without revealing undiscovered content |
| Optional platform-feature boundary | Evaluate the offline-first matrix in `01_Core_Concept/world_response_and_information_flow.md`: local saves first; optional cloud sync, achievements and screenshot/photo export; defer Workshop; exclude in-game community services and online-gated play | Clarifies privacy, Steam dependence, conflict handling and tiny-team support costs while preserving a complete offline single-player game; no release/platform commitment |
| Old-life memory and agency model | Evaluate the four-step memory → hypothesis → verified Aetherian knowledge → capability model in `06_Races_Origins/races_and_origins.md`; bound job recognition to a small set of optional authored moments, preserve alternate routes to essential clues, and validate agency, replay variation and production scope | Gives old-world work recurring dialogue and practical perspective while leaving reliable knowledge and capability to Aetherian evidence and ordinary progression; one primary job plus optional sensory memories remains a proposal |
