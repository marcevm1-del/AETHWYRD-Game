# Grounded transfer of modern-world knowledge into fantasy RPG play

## What is directly documented by official sources?

### Takeaway
Official examples show several distinct knowledge models: a background can shape how the world recognizes the protagonist; practiced research can reveal actionable enemy information; and training systems can let characters pursue skills beyond their apparent role. The clearest primary-source evidence here comes from BioWare/EA, CD Projekt RED, and Nintendo. Public official sources located for Kingdom Come: Deliverance and Skyrim were insufficient to substantiate detailed knowledge mechanics, so those remain evidence gaps rather than assumed facts.

### Cited Findings
- **Dragon Age: Origins (pre-release announcement, not a post-launch audit):** BioWare/EA announced six distinct origin stories, each with locations, characters, and events; the origin choice establishes how the protagonist perceives the world and how the world perceives them, and affects later story elements, dialogue, and plot branches. The announcement described hours of unique prelude gameplay. [EA/BioWare announcement](https://news.ea.com/press-releases/press-releases-details/2009/BioWare-Reveals-All-Six-Dragon-Age-Origin-Stories/default.aspx)
- **Dragon Age II (developer interview):** lead writer David Gaider said a fixed human protagonist with an integral background let the team use that background as a continuing plot hook; he contrasted this with Origins’ origins, which introduced the world well but had limited relevance to the larger plot after their opening. This is a developer’s design rationale, not a claim that every player agreed. [Reactor interview with David Gaider and Mike Laidlaw](https://reactormag.com/dragon-age-ii-an-interview-with-designers-david-gaider-and-mike-laidlaw/)
- **Baldur’s Gate 3 (shipped support documentation):** Larian describes Origin characters as pre-designed characters with personal backstories, quests, motivations, and unique ways of interacting with the world; companions’ experiences and attitudes affect opinions and relationships. [Larian gameplay FAQ](https://larian.com/support/faqs/gameplay-information_52)
- **The Witcher 3 (official developer/publisher material):** CD Projekt RED’s official monster article says players learn where monsters are found, their attack patterns, and what they fear, then work out how to kill them. The official game page describes Geralt as trained from childhood as a monster slayer, and says preparation includes elixirs, blade oils, and two swords. This is professional domain expertise paired with investigation and preparation, rather than an everyday background granting instant universal knowledge. [Official monster article](https://www.thewitcher.com/us/en/news/1018); [official game page](https://www.thewitcher.com/us/en/witcher3)
- **Fire Emblem: Three Houses (shipped publisher documentation):** Nintendo describes the protagonist as a travelling mercenary turned teacher and lets the player develop students through study, goals, training, and certification. Students can pursue classes outside their natural/personal goals, though unrelated skills improve more slowly; skill requirements gate some certifications. This models aptitude and learning as progression rather than a permanent class lock. [Nintendo UK game guide](https://www.nintendo.com/en-gb/Games/Nintendo-Switch-games/Fire-Emblem-Three-Houses-1175482.html); [Nintendo Australia gameplay guide](https://www.nintendo.com/au/news-and-articles/fire-emblem-three-houses-101/)
- **Kingdom Come: Deliverance:** searches found official Warhorse community forums, but the retrieved relevant posts were player discussions, not sufficiently authoritative developer documentation. They describe Henry learning to read and improving through reading, but should not be presented as verified shipped facts on this evidence. [Warhorse forum thread (community discussion)](https://forum.kingdomcomerpg.com/t/leveling-reading-skill/40789)
- **Skyrim:** no sufficiently specific official Bethesda documentation was located in this research pass to cite the details of skill books, learned lore, or appraisal. Do not rely on recalled wiki descriptions as first-party evidence.

### Inferences
- The most transferable pattern is to distinguish **who the protagonist used to be** (background and social perspective), **what they can currently do** (practiced skill), and **what they have discovered in this world** (journal/bestiary/appraisal). Those answer different player questions and should not collapse into one omniscience flag.
- Background relevance can persist in small, recurring ways after the opening without requiring a long branching origin campaign: a few tailored lines, a contextual observation, or a different way of interpreting a clue can make the past feel present.
- The Witcher’s evidence supports a knowledge loop of observation/research → hypothesis about a creature → preparation. It does not support giving the player exact answers for free simply because their former job was “scientist,” “gamer,” or “engineer.”
- Fire Emblem’s flexible progression suggests a useful distinction for Ascend: background may confer a starting edge or alternate explanation, while later competence is earned through the game’s ordinary training and skill systems.

### Gaps
- No primary, official source was retrieved that fully documents Skyrim’s in-game knowledge/appraisal or skill-book mechanics.
- No reliable primary source was retrieved detailing Kingdom Come: Deliverance’s shipped reading/alchemy learning loop; the forum material found is user discussion.
- The official Witcher material located documents the intended monster-preparation concept, not the precise unlock rules, bestiary UI, or whether every entry is gated by in-game investigation.

## What is an inference for Ascend?

### Takeaway
Ascend should treat a former Earth job as a small, authored perspective modifier, not as a class, skill tree, or answer key. Use it to change what the protagonist notices, asks, or tentatively suggests; let local evidence, Aethwyrdian teaching, and the established game systems determine reliable knowledge and actual capability.

### Cited Findings
- **Canon constraint:** Ascend’s canon says otherworlders remember their former lives and that they died, but not the cause; jobs provide “small practical perspectives and dialogue,” and Aethwyrd carries the story. The protagonist cannot return to Earth. [AETHWYRD Canon.md](../../Canon.md)
- **Canon constraint on job design:** the origin document says the job is a lens, not a cheat code; it must not instantly rebuild society or bypass whole quest paths. It also frames early Earth memories as ordinary and sensory rather than an exposition dump. Treat these as design-document guidance; Canon.md remains the authority. [Origins design notes](../../06_Races_Origins/races_and_origins.md)
- **Existing proposal to reconcile:** the origins draft currently proposes choosing three old-world memories/jobs and lists perks such as engineer “Crafting precision +1” with ideas including pulleys, printing, and plumbing. Its adjacent text also says perks/dialogue should stay small. This is a proposal in the design file, not settled canon, and some examples risk expanding into broad invention or profession systems. [Origins design notes](../../06_Races_Origins/races_and_origins.md)
- **Existing system hooks:** Ascend already sketches Otherworld Knowledge as introducing goods such as soap and printed books, potentially changing trades; it also sketches Engineering (Otherworld) as a crafting category. These are design proposals, not firm permission for a job to unlock those technologies unaided. [Systems design notes](../../12_Systems/systems.md)
- **Existing appraisal direction:** Ascend’s UI notes connect Appraisal level to what target details are visible; Canon’s proposed field-journal direction links observations and reports to bestiary hypotheses and counter suggestions, with uncertainty retained and brute force viable. This provides a native Aethwyrdian knowledge path alongside Earth memories. [HUD/UI notes](../../12_Systems/hud_and_ui.md); [Canon.md proposed field journal item](../../Canon.md)

### Inferences
- **Use three knowledge layers:**
  1. **Earth memory:** a narrow principle, work habit, vocabulary, or sensory association plausibly retained from the chosen job.
  2. **Aethwyrdian knowledge:** facts learned from NPCs, books, practice, guild instruction, field observation, appraisal, and the journal.
  3. **Capability:** what the character can reliably execute in gameplay, governed by skills, tools, materials, facilities, class abilities, and training—not by remembering Earth.
- **Good job option examples (proposals):**
  - **Cook:** recognize a food-safety or heat-transfer clue, suggest a preparation question, or recall a familiar technique; does not grant every recipe, ingredient identification, or master-quality cooking.
  - **Nurse/health worker:** notice a symptom pattern or ask about wound care; does not diagnose magical disease, replace healing magic, or confer combat medicine mastery.
  - **Engineer/technician:** recognize leverage, load, drainage, or a simple mechanical principle; can propose a test or flag a structural risk, but needs local materials, tools, skilled collaborators, and experimentation to build anything.
  - **Farmer/gardener:** notice soil, irrigation, season, or crop stress; does not identify alien plants or create high-yield agriculture without local learning.
  - **Clerk/accountant/office worker:** notice a ledger inconsistency or process bottleneck; does not automatically expose fraud without evidence or social access.
  - **Student/researcher:** form a cautious comparison and organize evidence; does not grant facts from an Earth encyclopedia or make the character a universal scholar.
- Each job should have a small number of authored “recognition moments” across the whole game, plus occasional low-stakes dialogue variants. These are more memorable and predictable to produce than a large generic skill/perk matrix.
- Make job options **bonus lines or alternate approaches**, not exclusive mandatory gates. Let other backgrounds reach the same conclusion through clues, companions, local experts, or ordinary skills. This protects role-play choice and avoids making one old job the “correct” pick.
- Label epistemic certainty in writing and UI: “this resembles…,” “you suspect…,” and “you confirmed…” should correspond to memory, hypothesis, and evidence respectively. The player should see when a job-based thought is a lead rather than established fact.
- Do not let job choice grant a universal recipe set, crafting tier, permanent quality multiplier, or broad profession unlock. If a numerical perk survives, keep it modest, visible, domain-bounded, and non-exclusive; ordinary play should be able to match or exceed it.
- Consider a single primary job (or one primary plus a small optional personal memory) rather than three mechanically active jobs. Three picks multiply combinations and authoring burden, while Canon specifically says “old-world jobs” plural but does not lock a number. A few sensory memories can supply personal texture without becoming extra mechanical tracks.
- Frame “modern knowledge” as incomplete and contextual. Earth knowledge may be inaccurate for Aethwyrdian physics, magic, ecology, anatomy, materials, and social institutions; test-and-learn should be the dramatic payoff. A practical insight can create a useful question or experiment, not a guaranteed technology tree.
- Keep the protagonist’s origin subordinate to their new-life agency. The origin can color a scene, but relationships, choices, practice, and knowledge acquired in Aethwyrd should drive long-term identity and capability.

### Gaps
- Canon settles the job’s small practical/dialogue role but not the final job roster, number of selections, exact benefit format, or how it interacts mechanically with class, crafting, and Appraisal.
- No approved Ascend rules were found that define what Appraisal can infer versus what the protagonist personally knows. The field journal and appraisal references are proposals; the exact boundary should be decided in the relevant system specs.
- A full job-by-job scene inventory has not been produced. Without it, it is unknown whether each selectable job will receive enough authored moments to feel worth choosing.

## What tradeoffs or risks matter for a tiny team?

### Takeaway
A compact, data-driven set of distinct recognition moments is the strongest fit for a tiny team: it preserves agency and makes backgrounds legible without requiring a sprawling branch graph or simulation. The main risk is the breadth already implied by Ascend’s large world and cast: even “small” unique options become expensive if every job is supported in every quest, conversation, recipe, and appraisal screen.

### Cited Findings
- **Dragon Age II’s developer interview explicitly discusses tradeoffs:** Gaider says choosing a protagonist with a fixed background created opportunities to integrate that background into the larger plot; the Origins approach offered multiple introductions but their larger-plot relevance was limited after the origin segment. [Reactor interview](https://reactormag.com/dragon-age-ii-an-interview-with-designers-david-gaider-and-mike-laidlaw/)
- **Nintendo’s shipped Three Houses documentation shows an authored compromise:** study goals and classes allow substantial character customization, but skills outside a character’s goals improve more slowly, and some advanced roles require skill thresholds. This makes flexibility legible while retaining progression costs. [Nintendo UK guide](https://www.nintendo.com/en-gb/Games/Nintendo-Switch-games/Fire-Emblem-Three-Houses-1175482.html)
- **Ascend’s own scale is material to cost:** Canon describes a very large planned world, 2,500 named NPCs, 287 core monster species scaling to 680 listed species/Tyrants, and long-form playtime targets. These are project targets, not verified shipped scope, but they indicate that per-content combinatorics are a serious design constraint. [AETHWYRD Canon.md](../../Canon.md)
- **Ascend already proposes bounded knowledge and world reaction:** the canon’s proposed field journal keeps hypotheses uncertain and brute force viable; the world-response rule says important reactions should have plausible causes and knowledge paths. These can support evidence-led information design if implemented selectively. [AETHWYRD Canon.md](../../Canon.md)

### Inferences
- With a tiny team, every background-specific option should ideally reuse the same quest outcome and gameplay interaction. The job changes a line, clue framing, or low-cost approach; it should not require a wholly separate quest chain, bespoke animation set, or parallel crafting economy.
- Choose a small roster of jobs that are easy to explain and materially distinct. Avoid near-duplicates (engineer/mechanic, nurse/doctor) unless their different play expression justifies separate authored coverage.
- Budget coverage explicitly: for each job, author a short list of guaranteed showcase scenes, then allow only a few shared generic cues elsewhere. This prevents silently promising ubiquitous reactivity across thousands of NPCs.
- Prefer content tags and reusable line variants over hard-coded branches. A quest can ask whether the protagonist has the relevant “hands-on food prep” or “ledger work” memory, while preserving the same objective, success conditions, rewards, and follow-up state.
- Use existing Appraisal and bestiary progression for reliable facts; avoid duplicating those facts as job perks. The job can alter the first observation or question, while field evidence unlocks the durable journal entry and tactical recommendation.
- Do not gate required crafting recipes, core progression, or critical safety information behind an origin. Optional efficiency, an extra clue, or a different conversation is a safer benefit.
- Track authoring cost in a small matrix: job × scene × effect. If a new job adds only one indistinguishable line, combine it; if it requires unique mechanics, validate the value before adding it.
- Because offline access is a canon product rule, all job recognition, knowledge flags, journal content, and progression must be locally saved and usable without network checks or external lookup. This follows directly from the premium offline-first constraint, rather than from any cited multiplayer/live-service precedent.

### Gaps
- No production estimate or current implementation inventory was available to quantify the cost of adding background flags to Ascend’s quest/dialogue pipeline.
- The proposed world scale may change during production; this note does not treat its targets as a promise that all listed content will ship.
- This research pass found useful first-party coverage for Dragon Age, Witcher, and Fire Emblem, but not adequate official shipped-mechanic detail for Skyrim or Kingdom Come. Those comparisons should not be used to justify specific Ascend rules until stronger primary sources are found.
