# Worldbuilding Research: Turning History into Play

**Research pass:** 2026-10-24  
**Scope:** official developer and publisher sources on open-world exploration, settlement identity, ecological creature design, quest consequences and scalable level design.  
**Status:** research and design proposals only. Canon.md wins. No borrowed setting, character, visual signature or story content is being proposed for direct use.

## Findings from primary sources

### 1. A world can guide without placing the player on rails

Sucker Punch describes the Guiding Wind as an exploration aid that points toward the selected objective while leaving route-finding to the player. Wind also works as an art-direction thread across foliage, cloth, particles and weather. The studio says it limited biome foliage variety to make landscapes more recognizable, and built procedural tools because hand-placing a very large world would not scale. ([Sucker Punch: Crafting the World of Tsushima](https://blog.playstation.com/2020/07/09/crafting-the-world-of-tsushima/), [Sucker Punch: How visual effects bring Tsushima to life](https://blog.playstation.com/?p=345372), [PlayStation Q&A](https://blog.playstation.com/2020/05/29/ghost-of-tsushima-your-questions-answered/))

**Ascend application (inference):** history can guide through visual motifs rather than map text: a repeated stitch mark, a road stone, a wind-bent tree line, or a sound heard at several sites. Keep direct route guidance available as a player option. Give each region a controlled palette of landmark materials, plants, sounds and silhouettes so 49 regions remain distinguishable without 49 unrelated asset libraries.

### 2. Ecology is strongest when creatures have a reason to be there

Guerrilla explains that Horizon machines were assigned ecological roles, placed in ecological zones and designed to interact with environments and humans. Their teams defined a machine's function, interactive parts and attacks in a design document before concept art, rigging and animation iteration. The stated aim was for the machine system to work together rather than feel like disconnected enemy types. ([Guerrilla: Rebuilding the machines of Horizon Forbidden West](https://blog.playstation.com/?p=356418))

**Ascend application (inference):** for each monster family, record the local niche (food, shelter, migration cue, competitor, scavenger or Aether response) beside the combat kit. A kill should change only a bounded local state—tracks, prey pressure, scavenging or a migration chance—not simulate a global ecosystem the team cannot author or test. Monster investigation should let players distinguish evidence from rumor and retain brute-force play as a valid option.

Capcom's own account of *Monster Hunter: World* likewise describes designing creatures around what makes their behavior distinctive, what they eat, and whether their needs make sense alongside the field's plants. A later interview about *Monster Hunter Wilds* describes herds tuned to each habitat and weather that can alter which monsters are available. ([Capcom: Creative Minds—Monster Hunter World](https://www.capcom.co.jp/ir/english/feature/2017_mh_crvoice.html), [PlayStation Blog: Monster Hunter Wilds interview](https://blog.playstation.com/?p=393257))

**Additional Ascend inference:** use *predictable variability*. A field guide may say “often seen at dusk after rain,” while a clue from a hunter narrows today's chance. The player can plan around ecology without a calendar becoming an exact spawn spreadsheet. Keep one signature behavior per family and reserve multi-creature herd logic for a few species that visibly benefit from it.

### 3. A settlement tells its history through what people need

Guerrilla's account of Horizon settlements ties materials, objects, food and technology to the inhabitants' isolation, resource access and daily habits. Their stated goal is that objects and people should look as if they belong there and have always been there. ([Guerrilla: An authentic world](https://blog.playstation.com/?p=356989))

**Ascend application (inference):** each town's history should be visible in its work surfaces, repairs, storage, cooking, water handling and social spaces. A town's identity should not depend on an NPC explaining its lore. Build one convincing lived-in loop per settlement size, then add region-specific details from existing clans and gazetteer data.

Guerrilla also describes starting tribe work with history, beliefs, disputes and how the group fits the world, then translating that framework into settlement behavior and visual cues. The studio specifically notes that ruins can shape present-day gestures whose original meaning residents no longer fully understand. ([Guerrilla: An authentic world](https://blog.playstation.com/?p=356989))

**Additional Ascend inference:** give each region a “survival grammar”: the daily actions that make sense there. A floodplain stores goods above water; a mobile settlement marks its route; a forge-town makes safety and ventilation visible; a shrine community distinguishes welcome from sacred access. Those are authored material behaviors, not uniform rules assigned to an entire race.

### 4. Multi-activity quests feel like expeditions, not repeated errands

Guerrilla's Sea of Sands article describes combining tracking, combat, stealth and traversal puzzles, with water and hiding spaces designed alongside enemy patrol paths. Its quest team began with a narrative summary, then built a design document and iterated in 3D. The article also describes a visible restoration payoff after the quest. ([Guerrilla: How the team created Vegas in Horizon Forbidden West](https://blog.playstation.com/2022/08/10/how-guerrilla-created-vegas-in-horizon-forbidden-west/))

**Ascend application (inference):** a monster contract can use a small authored sequence—prepare, locate, interpret, approach, resolve, return—without requiring every stage to be mandatory. Combine two or three verbs per contract and ensure an alternate route if the player skips one. When a quest repairs or restores a place, reserve one memorable visual reveal that reflects the actual world-state change.

### 5. In-world games make culture playable

Guerrilla says Machine Strike began as an activity to help settlements feel alive, then gained rules tied to Tenakth culture and machine traits. The studio expanded it beyond random pieces by giving machines individual statistics. ([Guerrilla: The making of Machine Strike](https://blog.playstation.com/?p=365702))

**Ascend application (inference):** taverns, guild halls, temples and clan gatherings can host small games whose rules express local history: a route-marking game in a caravan town, a cooperative defense board in a besieged settlement, or a memory-recitation game at a shrine. Reuse one compact rules engine with local pieces and stakes. Do not build a separate full board game for every culture.

### 6. Consequences can arrive later, but the player must be able to read their causes

CD Projekt RED quest designer Sarah Grummer describes turning emotional goals into playable challenges and character development, and says consequences may be revealed hours after an action. The studio also emphasizes testing long player paths because a change can break a distant scene. ([CDPR: Turning Emotions, Story, and Big Moments Into Gameplay](https://www.cdprojektred.com/en/blog/155/turning-emotions-story-and-big-moments-into-gameplay))

**Ascend application (inference):** delay some social outcomes so Aetheria feels independent, but give the player a causal receipt later: a changed contract, a letter, a rumor, a companion's question or a settlement detail. Track a small number of meaningful flags and test representative long paths. This supports the existing bounded-NPC-memory proposal without implying that every named NPC simulates every event.

### 7. Player agency and world scale compete for the same content budget

CD Projekt RED's level-design discussion describes planning points of interest, then asking where level design or quest design can support player choices without limiting them. It also characterizes this as difficult work and highlights convergence between space and quest behavior. ([CDPR: Paths and Possibilities: The Art of Level Design](https://www.cdprojektred.com/en/blog/188/paths-and-possibilities-the-art-of-level-design-transcript-included))

**Ascend application (inference):** every major location should answer three questions before it is expanded: what can the player notice, what can they do differently here, and how does the world respond? If a space has no distinctive answer, combine it with another location or keep it as a short travel landmark. This protects the fantasy of a huge world from becoming a huge checklist.

### 8. A clear vision is a practical scope tool

Sucker Punch's post-launch reflection describes the scale multipliers in building a large open world—world size, foliage, dialogue, missions and characters—and credits a clear core vision with helping the team navigate an ambitious project. ([Sucker Punch: The road to launch](https://blog.playstation.com/2020/07/16/ghost-of-tsushima-the-road-to-launch/))

**Ascend application (inference):** the core promise is not “put every anime trope in.” It is: *become an adventurer in a beautiful, dangerous anime-fantasy world; learn how its people and monsters work; make choices that visibly change how safe and hopeful it feels.* Any new system should strengthen at least one part of that sentence and reuse existing data, scenes or tools where possible.

### 9. Regional music can carry place memory

HoYoverse's *Genshin Impact* music feature describes coordinating with the world, gameplay, visual and IP teams, then choosing musical elements that fit the distinctive styles of each location. It also describes refining local tempo and mood while keeping a coherent overarching musical identity. ([HoYoverse: Behind the Music of Genshin Impact](https://genshin.hoyoverse.com/en/news/detail/5000))

**Ascend application (inference):** use one recognizable Aetheria musical motif, then let regional instrumentation and arrangement carry local history. A place can alter its arrangement after liberation or after a quest without needing an entirely new song. Treat actual cultural instrumentation with research and review; broad “exotic” shorthand is not enough.

The official *Genshin Impact* game page describes an immersive single-player campaign, but that game's wider online/service model is outside Ascend's locked single-player premium premise. The transferable reference here is regional identity and traversal presentation, not co-op, live events, monetization or an update treadmill. ([HoYoverse: Genshin Impact](https://genshin.hoyoverse.com/en/game))

## Options to add to Ascend

All options below are proposals. The first three are suitable for early prototyping; later options wait until the foundational loop proves fun.

| Priority | Option | Player-facing result | Small-team implementation shape | Main risk |
|---|---|---|---|---|
| **Now: Ring 0–1** | **Regional memory signatures** | Each region has 3 recognizable historical clues: a material/shape, a local sound or saying, and a civic custom | Author one short record in the gazetteer for each Data region; reuse existing geometry/material kits and NPC lines | Turning atmosphere into an indiscriminate collectibles checklist |
| **Now: Ring 0–1** | **Evidence-backed hunt journal** | Players compare tracks, habitat, weather and witness accounts before selecting a counter or route | Add a confidence/source field to hunt clues; keep suggestions optional and allow direct combat | Making investigation mandatory or leaking boss counters too early |
| **Now: Ring 0–1** | **Town memory ledger** | A handful of visible changes follow a quest or liberation: repairs, notices, patrols, stock and conversation | Reuse the existing Prosperity, siege, quest-flag and rumor systems; author a small response bundle per milestone | Promising full simulation for 2,500 named NPCs |
| **Now: Ring 0–1** | **One ecology card per starter family** | The player learns where a creature lives, what it seeks and one behavior that changes the fight | Pair the existing Ring 0 monster data with one authored habitat clue, one field clue and one tactical behavior | Adding more fields without making them visible in play |
| **Next** | **Travel as an information channel** | Smoke, birds, flags, road marks, weather and distant sound signal discoveries before UI markers | Layer deterministic environmental cues and accessibility equivalents onto existing landmarks | Cues becoming vague, repetitive or inaccessible |
| **Next** | **History told differently in each venue** | A Guild clerk cites a contract; an innkeeper sings an old verse; a shrine keeper names the dead | Three short variants per high-value historical reveal, gated by faction/quest flags | Excessive dialogue authoring and accidental spoiler leaks |
| **Next** | **Regional sound memory** | A familiar motif changes instrumentation as the player enters a new culture or returns after a major change | Reuse a compact motif stem; author a few region arrangements and liberation-state variations | Generic cultural shorthand or a score system too expensive for the content budget |
| **Next** | **Local pastime with historical rules** | Repeated visits teach a town's values through a compact game or contest | One reusable minigame framework with region-specific pieces, stakes and dialogue | Minigames diverting time from combat and exploration |
| **Next** | **Aftermath scenes** | The player returns after days or weeks and sees repairs, migration, changed prices or memorial additions | A small number of authored calendar/state checkpoints; no real-world timers | Players missing a change or believing it happened instantly |
| **Later** | **Historical reconstruction** | The player arranges fragments, route marks or testimony to understand an event | A reusable evidence board; conclusions can preserve uncertainty | Becoming a logic gate that blocks the main quest |
| **Later** | **Regional memory routes** | Optional multi-region investigations connect water, roads, oaths, memorials or craft | Use the five routes already outlined in `history.md`; connect existing POIs and quests | Too much backtracking or every region feeling like a lore museum |
| **Later** | **Public memory choices** | The player can amend a memorial or archive; groups react differently | One dialogue choice plus a few environment/rumor variants | Framing one real-world-inspired culture as morally monolithic |

## Recommended design rules

1. **Every historical detail has a present function.** It changes a route, custom, relationship, belief, material practice or current decision.
2. **Every major claim has provenance.** Record who says it, when they learned it, what evidence supports it and what they do not know.
3. **Culture is not a costume set.** Show internal disagreements, mixed households, changing generations, practical constraints and individual exceptions.
4. **Ecology is a relationship graph.** A region's monster roster should include competitors, prey, scavengers, shelter-users and migrations—not only a list of encounter slots.
5. **Do not reward grind for its own sake.** Repeated contracts should add new context, a new tactic or a visible world response.
6. **Use the world to guide, with adjustable UI backup.** Environmental discovery and clear accessibility are compatible.
7. **Keep consequences legible and recoverable.** The player can be surprised by character motives, but not by hidden permanent punishment inconsistent with Canon.
8. **Build one signature before multiplying.** Prove a complete regional loop in Whisperwood: rumor → clue → preparation → hunt → consequence → tavern retelling. Then scale the authoring pattern.

## Next research questions

- How do official Genshin Impact developer interviews describe regional identity, traversal and recurring festivals?
- Which Monster Hunter developer materials explain readable ecology and hunt preparation without requiring players to study a large encyclopedia?
- What do official RPG accessibility guidelines recommend for diegetic navigation, color/shape redundancy and information disclosure?
- Which low-cost narrative techniques help single-player games signal that a settlement is safer after liberation?
- How can the history and naming of real-world-inspired cultures be reviewed respectfully before any region becomes production-ready?

## Source notes

All sources below are official publisher or developer channels, or a first-party studio post. Claims above are paraphrases; the “Ascend application” sections are our design inferences, not claims made by the cited developers.

- Sucker Punch / PlayStation Blog, [Crafting the World of Tsushima](https://blog.playstation.com/2020/07/09/crafting-the-world-of-tsushima/) (2020-07-09): biome identity, environmental guidance, procedural world-building and scope.
- Sucker Punch / PlayStation Blog, [Ghost of Tsushima: Your questions answered](https://blog.playstation.com/2020/05/29/ghost-of-tsushima-your-questions-answered/) (2020-05-29): exploration, optional flute moments, weather and difficulty philosophy.
- Sucker Punch / PlayStation Blog, [How stunning visual effects bring Ghost of Tsushima to life](https://blog.playstation.com/?p=345372) (2021-01-12): world data reused across wind, weather, particles and character/environment interactions.
- Guerrilla / PlayStation Blog, [Rebuilding the machines of Horizon Forbidden West](https://blog.playstation.com/?p=356418) (2021-11-08): ecological roles, environment interactions and cross-discipline creature production.
- Guerrilla / PlayStation Blog, [Horizon Forbidden West: An authentic world](https://blog.playstation.com/?p=356989) (2021-11-22): settlements grounded in resources, technology and everyday life.
- Guerrilla / PlayStation Blog, [How Guerrilla created Vegas in Horizon Forbidden West](https://blog.playstation.com/2022/08/10/how-guerrilla-created-vegas-in-horizon-forbidden-west/) (2022-08-10): quest iteration, multi-verb play, level layout and visible restoration.
- Guerrilla / PlayStation Blog, [The making of Machine Strike](https://blog.playstation.com/?p=365702) (2022-06-04): culturally situated minigame and mechanically meaningful pieces.
- CD PROJEKT RED, [Turning Emotions, Story, and Big Moments Into Gameplay](https://www.cdprojektred.com/en/blog/155/turning-emotions-story-and-big-moments-into-gameplay) (2025-07-23): playable emotional goals and delayed consequences.
- CD PROJEKT RED, [Paths and Possibilities: The Art of Level Design](https://www.cdprojektred.com/en/blog/188/paths-and-possibilities-the-art-of-level-design-transcript-included) (2026): location planning, points of interest and agency across disciplines.
- Sucker Punch / PlayStation Blog, [The road to launch](https://blog.playstation.com/2020/07/16/ghost-of-tsushima-the-road-to-launch/) (2020-07-16): scale multipliers and value of a clear project vision.
- Capcom, [Creative Minds: Voices from the Frontline of Development](https://www.capcom.co.jp/ir/english/feature/2017_mh_crvoice.html) (2017): Monster Hunter: World team discusses designing creatures as part of an ecosystem and making dense environments usable in hunts.
- PlayStation Blog interview with Capcom, [Monster Hunter Wilds: How Capcom is evolving its apex franchise](https://blog.playstation.com/?p=393257) (2024-06-13): herd behavior tuned to habitat, dynamic conditions and player adaptation.
- HoYoverse, [Behind the Music of Genshin Impact](https://genshin.hoyoverse.com/en/news/detail/5000) (2020): regional musical identity coordinated with visual and gameplay direction.
- HoYoverse, [Genshin Impact official game page](https://genshin.hoyoverse.com/en/game) (current page, accessed 2026-10-24): describes its campaign as immersive single-player; consulted only to separate transferable world presentation from its service model.
# Additional source notes — exchange, memory and open-world pacing

This addendum extends the earlier official-source review. It records developer statements separately from design inference; it does not make new lore canon.

| Source | Reported design point | Possible Ascend application (inference) |
|---|---|---|
| [Hidetaka Miyazaki interview on Elden Ring](https://blog.playstation.com/?p=359935) | FromSoftware discusses balancing freedom, boss encounters, event progression and pacing in a large open world; it also describes using color and traces of a former golden age to counterbalance oppressive areas. | Cross-region history should reward detours while preserving readable pacing; contrast hopeful, lived-in spaces with the dark history underneath. Don't make every region relentlessly grim. |
| [BioWare: Discover the Dragon Age](https://blog.bioware.com/2014/03/06/discover-the-dragon-age/) | The studio describes regional ecosystems, predator-prey encounters and population states that respond to local conditions. | Connect historical routes to ecology and settlement life through a few authored indicators, rather than simulating all populations. |
| [BioWare: Writing Our Worlds](https://blog.bioware.com/2022/09/29/bioware-community-update-writing-our-worlds/) | Writers describe coordinating narrative, mission design, audio, art and localization; large RPG stories involve nonlinear interdependent parts. | Keep cultural traces modular and consistent: every key exchange gets a source, local variation, presentation cue and localization note. |
| [Xbox Wire: Fable — Living Population](https://news.xbox.com/en-us/2026/06/10/fable-living-population-details-explained-xbox-games-showcase-2026/) | Playground describes settlement traits and local reputation reflecting actions, while using recovery/population rules to avoid consequences that trap a save. This is a developer description of a forthcoming game, not a post-release evaluation. | Use local, witness-based reputation and visible settlement-state summaries; make serious consequences recoverable and never lock essential services behind irreversible collateral damage. This aligns with Ascend's Canon §5 loss rules. |
| [Xbox Wire: Fable — open-world freedom and consequence](https://news.xbox.com/en-us/2026/01/22/fable-interview-overview-details-developer-direct-2026/) | Playground describes a story that waits while players explore, locally perceived reputation, and choices whose social consequences are not framed as a universal moral score. | Let the main story wait during ordinary exploration; represent reputation through what specific NPCs and settlements believe, with routes to clarify or repair misunderstandings. Keep mandatory progression independent from optional social systems. |
| [Xbox Wire: Fable — long-form interview](https://news.xbox.com/en-us/2026/09/09/fable-how-playground-games-is-building-albion-for-a-new-generation-official-xbox-podcast/amp/) | Playground discusses supporting both players who pursue the main quest and those who roam, plus choices with different scales of consequence. This remains a pre-release description. | Give recurring town activities a predictable return cycle, keep ordinary exploration from expiring the main quest, and reserve high-consequence deadlines for clearly signposted authored moments. |

These sources do not prove that Ascend should use any specific mechanic. The corridor concepts in `history.md` are original proposals derived from existing Gazetteer material and must be checked against the map. The Fable interviews describe announced design intentions before the game's release; they are not evidence of player reception or final shipped behavior.

