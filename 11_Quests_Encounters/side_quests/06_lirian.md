# 11e-06 — Lirian, the Lantern Canals: Ten Side Quests (draft)

> *"Lirian was built over a flooded older Lirian. On quiet nights you can see its rooftops under the boats."*
> — Gazetteer, Lirian

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: this region is spoiler-light; quests 5, 9 and 10 touch the Drowned Choir.

**Region:** `reg_lirian` (the canal cities, the lagoon, the sandbar gaps, the drowned older Lirian). **Rank band:** D–B. **Tone:** witty, theatrical, a little corrupt, and truly kind underneath. Everyone wears a mask for something.

**Placement notes.**
- **The Drowned Choir** (sirens of the canals) is the region's Tyrant. Their song draws people into the water. The city has banned singing after dusk. No quest here kills the Choir; quests 2, 9 and 10 are about how Lirian *answers* them.
- **Proposal (Canon §6):** quest 9 suggests the Drowned Choir were the old city's own choir, drowned mid-hymn. It is a seed; the Tyrant and the main Choir remain.
- Lirian is a **republic** ruled by a doge elected for life by merchant houses. Elections are expensive and occasionally fatal. Quest 4 uses that.
- A coin is thrown into the canal for every deal made; Maelsday is the night the whole city lights its lanterns at once. Both customs matter.
- The outer lagoon is home to sea-elves and merfolk who trade through water-gates; quest 3 uses that.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Coin for Every Deal | D | OddJob | Pico Stella | An old promise paid at last |
| 2 | The Counter-Song | D | Investigation | Carlotta Dessi | A singer against the Choir |
| 3 | A Glass Heart for the Lagoon | D | OddJob | Maestro Orsino Vetri | A wedding across the water-gate |
| 4 | Which Doge? | C | Investigation | Secretary Fabrizio Ledo | Masks, doubles, an election |
| 5 | Under the Rooftops | C | Exploration | Nerea Salt | A drowned dinner table |
| 6 | The Deaf Gondolier | C | Escort | Tullio Brenta | Immune to the song |
| 7 | The Auction of Masks | C | Hidden | Lucia Marchetti | A stolen name |
| 8 | The Three Gaps | B | Defense | Captain Beatrice Morosina | The fast fleet, one night |
| 9 | The Last Song of Isolde Verro | B | Investigation | Paolo Verro | The Choir answered, once |
| 10 | Maelsday, All at Once | B | Faction | Lantern-Mistress Ottavia Ruzzini | A city that lights as one |

## Cast (new supporting NPCs)

<!-- npc
id: npc_pico_stella
name: Pico Stella
tier: townsfolk
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Canal diver
backstory: A scrappy eleven-year-old coin-diver who fishes thrown deal-coins out of the canals and has never once been caught keeping one.
secret: He has kept one.
-->
<!-- npc
id: npc_carlotta_dessi
name: Carlotta Dessi
tier: townsfolk
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Street singer
backstory: A defiant street singer who has been fined nine times for singing after dusk and has decided the fines are an investment.
-->
<!-- npc
id: npc_orsino_vetri
name: Maestro Orsino Vetri
tier: major
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Master glassblower
backstory: A theatrical, tender glassblower who has made a thousand mirrors and has never once been able to make a heart.
-->
<!-- npc
id: npc_fabrizio_ledo
name: Secretary Fabrizio Ledo
tier: major
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Secretary to the Doge
backstory: A dry, sleepless secretary to the Doge who has kept the republic's secrets for twenty years and is beginning to suspect one of them is keeping him.
-->
<!-- npc
id: npc_nerea_salt
name: Nerea Salt
tier: major
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Diver-captain of the Lantern Guild
backstory: A scarred, sardonic diver-captain who has mapped nine fathoms of the drowned city and refuses to talk about the tenth.
-->
<!-- npc
id: npc_tullio_brenta
name: Tullio Brenta
tier: townsfolk
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Deaf gondolier
backstory: A cheerful, entirely deaf gondolier who has spent twenty years being told he is lucky by people who have no idea what he is missing.
-->
<!-- npc
id: npc_lucia_marchetti
name: Lucia Marchetti
tier: townsfolk
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Seamstress with a stolen name
backstory: A tired seamstress who woke up three weeks ago unable to say her own name, and who found it written on a masked-auction lot.
-->
<!-- npc
id: npc_beatrice_morosina
name: Captain Beatrice Morosina
tier: major
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Captain of the fast fleet
backstory: A crisp, precise captain of Lirian's small, very fast fleet, who has never lost a race and has promised her crew she will not lose tonight.
-->
<!-- npc
id: npc_paolo_verro
name: Paolo Verro
tier: townsfolk
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Accompanist to Isolde Verro
backstory: A thin, nervous pianist who has played for his sister Isolde since she was nine and has not slept since she walked into the canal.
-->
<!-- npc
id: npc_ottavia_ruzzini
name: Lantern-Mistress Ottavia Ruzzini
tier: major
race: Human
region: reg_lirian
settlement: Lirian canal cities
role: Lantern-Mistress of Maelsday
backstory: A tall, imperious Lantern-Mistress who has organised the Maelsday lighting for forty years and holds that a city is only as bright as its quietest lantern.
-->

---

## 1. A Coin for Every Deal

*D · OddJob · the canals · giver Pico Stella*

**The short version.** Every deal in Lirian is sealed with a coin thrown in the canal. Pico dives for them. Today he found one that *sings* when you hold it. He would like to know whose it is.

**What is really going on.** The coin is eight hundred years old. It was thrown by a drowned-city merchant, **Aurelio Bassi**, who promised to deliver a cargo of salt to a sea-spirit in return for a safe passage. He never did. The spirit is still waiting. The coin sings because the deal is *unpaid*.

**Scene 1: the quay.**

**PICO:** "Don't tell the guild. I'm *supposed* to hand in everything. But look."
*He holds up a green-black coin, no bigger than a thumbnail. As he turns it, it chimes: one clear, thin note.*
**PICO:** "Isn't that *weird*? I found it in the mud by the old pillar. It's been singing for three days."
**PICO:** "I want to keep it. But it feels like it's *waiting* for something."
> ► **"What does the inscription say?"** — **PICO:** "'Aurelio Bassi. A cargo of salt. For passage.' Eight hundred years old, my sister says."
> ► **"Who would know?"** — **PICO:** "The old divers. The ones with the *scars*."
> ► **"Let me see it."** — **PICO:** "Don't *drop* it."

**Scene 2: the old divers.** At a smoky canal-side tavern, an elderly diver, Nonno Gigi, listens to the coin's note with his eyes closed.

**GIGI:** "That's a deal-coin. Unpaid. You can hear it, if you've heard enough of them."
**GIGI:** "An unpaid deal pulls at the water. At the wrong time, the *sea* may collect."
**GIGI:** "Take it to the Bassi tomb. There's a tradition: you carry the cargo to where the deal was struck."
> ► **"What was the cargo?"** — **GIGI:** "Salt. A hundred measures."
> ► **"Where was it struck?"** — **GIGI:** "Under the Pillar of the Nine Bells. At low tide."

**Scene 3: the salt.** The player buys a hundred measures of salt from the Consortium's dock, a small, ludicrous expense, and carries them in a rowboat to the Pillar.

**PICO:** "It's going to rain. That's a *terrible* sign."
**PICO:** "Do we just... *throw* it in?"
> ► **"Pour it slowly."** — The water turns a sudden, glittering white.
> ► **"Say the name."** — A thin voice answers from the deep.
> ► **"Leave the coin on the pillar."** — The note changes pitch.

**Scene 4: the spirit.** A pale, pearl-coloured shape rises out of the water.

**SPIRIT:** *(a slow, silvery voice)* "Aurelio Bassi. You are *late*."
**PICO:** "He's... dead, madam. About eight hundred years."
**SPIRIT:** "Ah. Then the salt is *very* late."
*The spirit looks at the salt, then at Pico, then at the player.*
**SPIRIT:** "...Accepted. The account is closed."
*The coin stops singing. A last, faint chime. Then silence.*

**Outcomes and receipt.**
- The deal is closed; Pico keeps the coin (now quiet) as a lucky charm, or hands it to the Divers' Guild for the museum.
- **Receipt:** a small pearl-white stone sits on the Pillar of the Nine Bells; the canal tide runs a little cleaner there.

<!-- quest
id: qst_lir_coin_deal
title: A Coin for Every Deal
rank: D
type: OddJob
giver: npc_pico_stella
region: reg_lirian
level: 38
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: lir_coin_resolved
summary: A coin-diver finds a singing deal-coin from an eight-hundred-year-old unpaid bargain. The sea-spirit is still waiting.
objectives:
  talk npc_pico_stella
  reach lirian_pillar_nine_bells
  choice pour_say_or_leave
-->

---

## 2. The Counter-Song

*D · Investigation · the canals · giver Carlotta Dessi*

**The short version.** Singing after dusk is banned. Carlotta sings anyway. She says it is not a rebellion; it is a *defence*.

**What is really going on.** The Drowned Choir sings in a particular key. Carlotta, who has perfect pitch, has found that singing a *counter-melody* in the opposite key interrupts the call. She has saved six people this month. The city watch fines her every time.

**Scene 1: the arch.**

**CARLOTTA:** "Nine fines. Nine! And I don't regret one."
**CARLOTTA:** "I *know* it's illegal. The Doge's decree says no singing, and I understand why. The Choir *takes* people."
**CARLOTTA:** "But I've found something. A trick. And no one will listen."
> ► **"What trick?"** — **CARLOTTA:** "If you sing a certain *interval* against the Choir, the call breaks."
> ► **"Who have you saved?"** — **CARLOTTA:** "A baker. A sailor. A little girl on the Via Cori."
> ► **"Why won't the watch listen?"** — **CARLOTTA:** "They think I'm *attracting* it."

**Scene 2: the demonstration.** At dusk, in a quiet campo, the player waits with Carlotta. The water begins to hum: a long, sweet, aching note rising from nowhere. A man at a cafe table stands, glassy-eyed, and steps toward the canal.

**CARLOTTA:** (whispering) "Now. Listen."
*She sings: a low, wavering interval that runs counter to the Choir's. The man stops. He blinks. He sits down heavily, bewildered.*
**MAN:** "...What was I doing?"
**CARLOTTA:** "Having a *drink*."
> ► **"It works."** — **CARLOTTA:** "It works *every time*. Only I can't be everywhere."
> ► **"Can anyone learn it?"** — **CARLOTTA:** "Anyone with *half an ear*."
> ► **"Show the watch."** — **CARLOTTA:** "They'll arrest me."

**Scene 3: the watch.** At the watch-house, Captain Moro stands arms folded.

**MORO:** "The decree is the decree."
**MORO:** "I don't care *what* she's doing. If the Choir hears *anyone*, it comes closer."
**MORO:** "I've lost two men to the canals this year. I'm not risking a third."
> ► **"Test it, at the watch."** — **MORO:** "...In daylight."
> ► **"Let her train the watch."** — **MORO:** "That's a *serious* ask."
> ► **"Ask the Doge."** — **MORO:** "The Doge is *away*."

**Scene 4: the choir.** The player arranges a supervised test. At dusk, in front of a ring of watchmen, the Choir's song rises; Carlotta sings the counter-melody; half the watch stand frozen, the rest, with a quick lesson, *join in*.

**MORO:** (hoarse) "...That's six men who just *didn't* walk into the canal."
**MORO:** "I'll revoke the fines. All nine."
**CARLOTTA:** "I'd like them framed, please."

**Outcomes and receipt.**
- The watch adopts the counter-song as a standard drill; Carlotta becomes the "Voice of the Watch."
- **Receipt:** every watch-house keeps a small tuning fork; the singing ban remains but has a *carve-out*.

<!-- quest
id: qst_lir_counter_song
title: The Counter-Song
rank: D
type: Investigation
giver: npc_carlotta_dessi
region: reg_lirian
level: 40
act: 2
requires_rank: D
reward: 1600 | 95 | 6500
sets: lir_song_resolved
summary: A street singer has found a counter-melody that breaks the Drowned Choir's call. The singing ban says she's breaking the law.
objectives:
  talk npc_carlotta_dessi
  reach lirian_watch_house
  choice test_train_or_doge
-->

---

## 3. A Glass Heart for the Lagoon

*D · OddJob · Lirian glassworks · giver Maestro Orsino Vetri*

**The short version.** A merfolk groom has commissioned a glass heart for his sea-elf bride, a heart that *beats*. Orsino has never made a heart in his life.

**What is really going on.** The heart is a *wedding gift* that must survive being worn underwater for a hundred years. It cannot be solid glass; it cannot be hollow. It must be *alive*. The only material that works is **tide-glass**, a rare crystal that grows only in the *spaces between* the water-gates, where the lagoon and the sea mix.

**Scene 1: the workshop.**

**ORSINO:** "A *heart*, they say. A *beating* one. To wear. Under water. For a hundred years."
**ORSINO:** "I have made mirrors, chandeliers, a goblet that sings when you cry into it. I have never made a *heart*."
**ORSINO:** "The groom is Marenko, a merman of the outer reef. The bride is Selmae, a sea-elf cartographer. They are very, very in love, and I am very, very *afraid*."
> ► **"Why a glass heart?"** — **ORSINO:** "It's traditional. Where they come from. The heart is given, not kept."
> ► **"What do you need?"** — **ORSINO:** "Tide-glass. And a miracle."
> ► **"I'll fetch the tide-glass."** — **ORSINO:** "Bless you. And take a lantern."

**Scene 2: the gate.** At the eastern water-gate, where fresh water meets salt, a faint glitter lies in the silt. A sea-elf gate-keeper, **Ondine**, watches with folded arms.

**ONDINE:** "Tide-glass is *sacred.* You may take one shard. And you must *ask*."
**ONDINE:** "You are a land-walker. You cannot ask in our tongue. But you may ask in *yours*, and listen for the water."
> ► **"May I take a shard?"** — A ripple answers.
> ► **"I need it for a wedding."** — **ONDINE:** "...Whose?"
> ► **"I'll give something in return."** — **ONDINE:** "That is... customary."

**Scene 3: the heart.** In the glassworks, Orsino and the player work through a long night: the fire, the breath, the long slow turning. The heart takes shape: faintly blue, translucent, pulsing with a thin gold light.

**ORSINO:** "It's *wrong*. It doesn't beat."
**ORSINO:** "It needs... a *rhythm*."
*The player places a hand on the glass. A slow, even pulse begins.*
**ORSINO:** "...It's yours. The heart *remembers* the one who holds it last."

**Scene 4: the wedding.** On a moonlit sandbar, merfolk and sea-elves gather in a ring of lanterns. The bride and groom exchange the heart. It beats, once, twice, and then settles into a perfect, steady, golden rhythm.

**SELMAE:** "It beats like him."
**MARENKO:** "It beats like *her*."
**ORSINO:** (in tears) "...Oh. *Oh*. That's what a heart does."

**Outcomes and receipt.**
- The player's touch gave the heart its first beat, and a quiet link to the lagoon: the sea-elves recognise the player at the water-gates.
- **Receipt:** a small blue light hangs in Orsino's window; the outer lagoon sends a basket of pearls every spring.

<!-- quest
id: qst_lir_glass_heart
title: A Glass Heart for the Lagoon
rank: D
type: OddJob
giver: npc_orsino_vetri
region: reg_lirian
level: 42
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: lir_heart_resolved
summary: A merfolk groom has commissioned a glass heart that beats, for a sea-elf bride. The glassblower has never made one.
objectives:
  talk npc_orsino_vetri
  reach lirian_east_water_gate
  choice ask_trade_or_pledge
-->

---

## 4. Which Doge?

*C · Investigation · the Doge's palace · giver Secretary Fabrizio Ledo*

**The short version.** The Doge has three identical masked doubles for security. Last night one of them died. Nobody knows which.

**What is really going on.** The *real* Doge is alive and hiding in a cellar, because he suspects a council faction has been trying to *replace* him with a double who will sign what they want. The dead double was an accident of the plot. The secretary does not know any of this.

**Scene 1: the palace.**

**FABRIZIO:** "A death in the palace. A masked death. And nobody knows whom."
**FABRIZIO:** "The Doge has *three* doubles. Four, if you count him. Each wears the same mask, speaks in the same voice, signs with the same hand. It is a *brilliant* system."
**FABRIZIO:** "I am beginning to suspect it is *too* brilliant."
> ► **"How do I tell them apart?"** — **FABRIZIO:** "You do not. That is the *point*."
> ► **"Who benefits?"** — **FABRIZIO:** "Anyone who wants an obedient Doge."
> ► **"What do you want from me?"** — **FABRIZIO:** "To find out which one is real. Quietly."

**Scene 2: the masks.** The player interviews three masked Doges in turn, each calm, urbane and utterly convincing. Each is *slightly* off.
- **Doge A:** speaks of the council with warmth, a little *too* warm.
- **Doge B:** cites three precedents, all perfectly correct, all *slightly* in the wrong order.
- **Doge C:** says nothing at all, and offers tea, like a man who has *never* poured it.

> ► **"Which of you is the real Doge?"** — **DOGE A:** "All of us. And none." **DOGE B:** "A strange question." **DOGE C:** *(pours tea)*

**Scene 3: the cellar.** In the palace cellar, behind a false wine rack, a tired old man in a plain cloak sits on a barrel, eating cheese.

**REAL DOGE:** "...Ah. A person I do not know. Good."
**REAL DOGE:** "I'm hiding. I've been hiding for three weeks. I suspect that the council wants a *puppet*."
**REAL DOGE:** "I'd come out. But I'm *not sure which of my doubles is theirs*."
> ► **"I can help."** — **REAL DOGE:** "Please."
> ► **"The dead one?"** — **REAL DOGE:** "My own man. Poor Lorenzo. A good double."
> ► **"Who is the puppet?"** — **REAL DOGE:** "Only one way to find out."

**Scene 4: the unmasking.** The player arranges a *dinner*. All four Doges (the real one under a plain hood) sit at the table. A hidden test (a joke in the old Lirian dialect, a cup of ceremonial sea-wine, a particular salute) will catch the impostor.

**FABRIZIO:** (sotto voce) "Doge C did not laugh."
**DOGE C:** *(stiffly)* "...I do not find it amusing."
**REAL DOGE:** "Ah. *There* he is."
> ► **(Expose the impostor publicly.)** — A long, tense scene in the grand hall.
> ► **(Turn him quietly.)** — The puppet-master is revealed.
> ► **(Let the real Doge decide.)** — He does, with a slow, tired smile.

**Outcomes and receipt.**
- The council faction is exposed or neutralised; the real Doge returns to office with a *new* security system (a single mask, a single face).
- **Receipt:** the Doge's palace now has a single, unmasked portrait; Fabrizio is promoted; the republic holds a *special election*.

<!-- quest
id: qst_lir_which_doge
title: Which Doge?
rank: C
type: Investigation
giver: npc_fabrizio_ledo
region: reg_lirian
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: lir_doge_resolved
summary: The Doge has three masked doubles, and one has died. The real Doge is hiding in a cellar.
objectives:
  talk npc_fabrizio_ledo
  reach lirian_doge_cellar
  choice expose_turn_or_let_doge
-->

---

## 5. Under the Rooftops

*C · Exploration · the drowned city · giver Nerea Salt*

**The short version.** Nerea has mapped nine fathoms of the drowned older Lirian. The tenth, she will not discuss. She has decided it is time to go back.

**What is really going on.** The tenth fathom holds a *house*. The family inside is still at dinner, preserved in an air-pocket held by an old sea-spell. They do not know that eight centuries have passed. They are waiting for a *guest*.

**Scene 1: the dock.**

**NEREA:** "I've dived the old city for twenty years. Nine fathoms. Streets, courtyards, a bell-tower. And then... a house."
**NEREA:** "A house with a *lit window*."
**NEREA:** "I never went in. I told myself it was a trick of the light. It isn't."
> ► **"Why now?"** — **NEREA:** "Because I'm *tired* of not knowing."
> ► **"What do you need?"** — **NEREA:** "Someone who isn't afraid of drowned things."
> ► **"I'll dive with you."** — **NEREA:** "Good. Stay close. Don't touch anything."

**Scene 2: the descent.** The dive is a long, hushed, beautiful gameplay sequence: through ruined streets, past a bell with a barnacled clapper, under a shattered archway, into a courtyard where fish swim through the ghosts of washing lines.

**NEREA (via speaking-tube):** "There. Past the third arch."
*Through the water, a small golden square of light.*

**Scene 3: the house.** The door is open. Inside, a bubble of dry air. A long table, set for six. Candles burn. A family of five sit at their places: a father, a mother, three children. They look up as the player enters.

**FATHER:** "Ah. Our guest. You are *very* late."
**FATHER:** "Sit, sit. Dinner is cooling."
**MOTHER:** "Mind the water on the floor. The tide came in during the soup."
> ► **"What year is it?"** — **FATHER:** "Why, the year of the Great Fair, of course."
> ► **"I'm not your guest."** — **MOTHER:** "Nonsense. Everyone is a guest."
> ► **"Please, may I sit?"** — **FATHER:** "Of *course*."

**Scene 4: the meal.** The meal is a quiet, uncanny, loving scene: the children ask about the surface; the father tells a joke; the mother passes bread that tastes of salt. At the end, the eldest child, a girl of about ten, takes the player's hand.

**GIRL:** "Will you come back?"
**GIRL:** "It's been so long since anyone came."
> ► **"I'll come back."** — **GIRL:** "Promise?"
> ► **"I'll tell them you're here."** — **GIRL:** "Oh, don't. They'd *take* us."
> ► **"Do you want to leave?"** — **GIRL:** "...Where would we go?"

**Outcomes and receipt.**
- The family remains in the drowned house; the player may return once a season, for supper, or choose to *free* them with the Lantern Guild's rite (they vanish in a warm gold light).
- **Receipt:** a lit window in the tenth fathom, marked on Nerea's map; a small dry bread-loaf arrives at the player's door each Maelsday.

<!-- quest
id: qst_lir_under_rooftops
title: Under the Rooftops
rank: C
type: Exploration
giver: npc_nerea_salt
region: reg_lirian
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: lir_rooftops_resolved
summary: A diver-captain has found a house in the drowned city with a lit window. The family inside is still at dinner.
objectives:
  talk npc_nerea_salt
  reach lirian_drowned_house
  choice stay_free_or_promise
-->

---

## 6. The Deaf Gondolier

*C · Escort · the canals · giver Tullio Brenta*

**The short version.** Tullio is completely deaf. The Drowned Choir cannot reach him. The gondolier's guild wants him to ferry passengers across the worst canals at dusk. He wants to be asked as a *gondolier*, not as a charm.

**What is really going on.** Tullio is a masterful gondolier, quick, graceful, humorous, who has spent his career being treated as a lucky talisman. He wants to ferry a bride to her wedding without being called "the deaf one."

**Scene 1: the landing.**

**TULLIO:** (signing; subtitled) "They call me *Lucky Tullio*. I am not lucky. I am *deaf*."
**TULLIO:** "The guild wants me to take people across the Choir's canals at dusk. Because I can't hear."
**TULLIO:** "I'm good at it. I'm also *very* good at all the other canals. I would like someone to say so."
> ► **"I'll say so."** — **TULLIO:** "Thank you."
> ► **"What do you need?"** — **TULLIO:** "A passenger. A reason. And no one saying 'lucky.'"
> ► **"I'll ride with you."** — **TULLIO:** "Good. Do not sing."

**Scene 2: the bride.** A young woman, **Alisa**, in a white veil, climbs aboard, shaking.

**ALISA:** "The wedding is across the Via Maggiore. The *only* way is the north canal. The *Choir's* canal."
**ALISA:** "I was told I could trust you."
**TULLIO:** (signing) "You can trust my *hands*."

**Scene 3: the crossing.** The gondola glides into dusk. The water hums. A sweet, aching note rises. Alisa sways. The player must hold her gently still while Tullio, utterly unbothered, poles through a labyrinth of narrow canals, reading the water and the light.

**ALISA:** (dreamily) "Do you hear that?"
**PLAYER:** "Don't listen."
**TULLIO:** (signing, to the player) "Hum something. A *dull* tune."
> ► **(Hum a dull tune.)** — Alisa laughs, breaks the spell.
> ► **(Cover her ears.)** — Alisa starts, then calms.
> ► **(Talk loudly.)** — Alisa squints, annoyed, and *stops listening*.

**Scene 4: the shore.** At the wedding steps, Alisa steps off, blinking, and turns back.

**ALISA:** "Thank you, Tullio. You are the *best gondolier* in Lirian."
**TULLIO:** (signing, delighted) "I know."
*Behind her, the guildmaster, who had been about to say* lucky*, clears his throat instead.*
**GUILDMASTER:** "...Master Brenta."

**Outcomes and receipt.**
- Tullio is promoted to Master Gondolier; the guild retires the word "lucky" for him.
- **Receipt:** a plaque on his gondola: *"Master Brenta. Best in Lirian."* Passengers ask for him by name.

<!-- quest
id: qst_lir_deaf_gondolier
title: The Deaf Gondolier
rank: C
type: Escort
giver: npc_tullio_brenta
region: reg_lirian
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: lir_gondolier_resolved
summary: A deaf gondolier, immune to the Choir's song, wants to be asked as a gondolier, not a charm.
objectives:
  talk npc_tullio_brenta
  escort npc_tullio_brenta
  reach lirian_north_canal_dusk
  choice hum_cover_or_talk
-->

---

## 7. The Auction of Masks

*C · Hidden · the masked auction · giver Lucia Marchetti*

**The short version.** Lucia woke up three weeks ago unable to say her own name. She found it on a lot at the Auction of Masks, where *identities* are sold.

**What is really going on.** A broker named **Domenico Vell** has been buying *names*, a quiet, almost-legal old-magic trade. A name sold is a name lost: the owner cannot say it, write it or answer to it. Lucia was sold *by her own landlord*, who needed to pay a debt.

**Scene 1: the seamstress.**

**LUCIA:** (writing on a slate) "I... can't... say it. My own name."
**LUCIA:** "I know I'm Lucia. I know the *shape*. But my mouth won't make the sounds."
**LUCIA:** "I found it. Lot forty-one. At the Auction of Masks."
> ► **"Who sold it?"** — **LUCIA:** "My landlord. I think."
> ► **"What's the Auction?"** — **LUCIA:** "A secret one. Masks and names. Only the rich go."
> ► **"I'll get it back."** — **LUCIA:** "Please. I would like to say *hello* again."

**Scene 2: the auction.** In a candlelit cellar, masked bidders sit in rows. A gilded auctioneer calls out lots: *a memory of the sea; a stranger's voice; a childhood summer; a name.*

**AUCTIONEER:** "Lot thirty-nine. A *lovely* name. 'Marta.' Warm, plain, good for a baker."
**BIDDER:** "Twelve silver."
**AUCTIONEER:** "Lot forty-one. 'Lucia Marchetti.' A seamstress. Quiet. Reliable."
*The player is wearing a rented mask. A bidder across the room raises a card.*
> ► **(Bid on the name.)** — The player outbids three buyers, with the Consortium's coin.
> ► **(Steal the lot.)** — A stealth sequence along a rafter, a locked case, a quick fall.
> ► **(Expose the auction.)** — The watch is called; chaos.

**Scene 3: the broker.** After the auction, in a back room, Domenico Vell counts coin.

**VELL:** "Names are *commodities*. Nobody is hurt. I merely *hold* them."
**VELL:** "She will get it back, when someone *pays*."
> ► **"You're ruining lives."** — **VELL:** "I'm filling a *market*."
> ► **"Give it back."** — **VELL:** "For what price?"
> ► **"You'll hang for this."** — **VELL:** "Prove it."

**Scene 4: the return.** In a whispered scene back at Lucia's room, the player hands her the lot: a slip of paper with a name in elegant ink. She reads it. Her lips move. Her breath catches.

**LUCIA:** "...Lucia."
**LUCIA:** "Lucia Marchetti. I'm *Lucia Marchetti*."
**LUCIA:** "Oh, I never knew how much I liked that name."

**Outcomes and receipt.**
- The player decides how to treat Vell: a quiet sting, a public exposure, or a grim bargain. In every branch Lucia gets her name.
- **Receipt:** Lucia sews a small embroidered label into every coat she makes: her full name, in clear letters.

<!-- quest
id: qst_lir_masks_auction
title: The Auction of Masks
rank: C
type: Hidden
giver: npc_lucia_marchetti
region: reg_lirian
level: 68
act: 3
requires_rank: C
reward: 4500 | 245 | 16500
sets: lir_masks_resolved
summary: A seamstress can't say her own name. It's on a lot at a secret auction where names are sold.
objectives:
  talk npc_lucia_marchetti
  reach lirian_masked_auction
  choice bid_steal_or_expose
-->

---

## 8. The Three Gaps

*B · Defense · the sandbar · giver Captain Beatrice Morosina*

**The short version.** The lagoon's only defence is its sandbar and the three gaps the city controls. Tonight, pirates are coming for all three at once.

**What is really going on.** The raid is a *diversion*. The real target is a single cargo ship carrying the Consortium's Aldmere honey (see Mossdeep quest 7), which the pirates plan to steal under cover of a three-gap assault. The captain knows.

**Scene 1: the quay.**

**BEATRICE:** "Three gaps. Three fleets. Nine ships. And a night of fog."
**BEATRICE:** "I have never lost a race. I will not lose tonight."
**BEATRICE:** "I need someone to take the middle gap. It is the narrowest and the *most dangerous*."
> ► **"What's the plan?"** — **BEATRICE:** "Hold. Hit. Withdraw. Hold."
> ► **"How many ships?"** — **BEATRICE:** "Nine. Ours are small. Theirs are *not*."
> ► **"I'll take the middle gap."** — **BEATRICE:** "Good. Don't die."

**Scene 2: the night.** A naval defense sequence in the fog. The player commands a fast cutter, nudging, boarding, holding. Each gap has its own personality:
- **The North Gap:** wide, shallow, beloved of smugglers.
- **The Middle Gap:** narrow, deep, a place where captains die.
- **The South Gap:** a long, quiet channel, where a *hidden* ship waits.

**BEATRICE (on a signal-lamp):** "North holds. South is *quiet*. Too quiet."
**PLAYER:** "It's a diversion."
**BEATRICE:** "I know."

**Scene 3: the honey ship.** A single freighter slips through the South Gap. Pirates swarm it from three sides. The player cuts through the fog, rams a pirate sloop, and boards.

**PIRATE CAPTAIN:** "You're too late. The honey's *ours*."
**PIRATE CAPTAIN:** "We took it from the Thimblefolk's own barrels. Nobody is going to miss a few jars."
> ► **"You took it from the Thimblefolk."** — **PIRATE CAPTAIN:** "Who?"
> ► **"The honey is stolen goods."** — **PIRATE CAPTAIN:** "So is *everything*."
> ► **"Surrender."** — **PIRATE CAPTAIN:** "...Not today."

**Scene 4: the dawn.** The fog lifts. Three gaps hold. One ship is lost; nine are saved.

**BEATRICE:** "I did not lose."
**BEATRICE:** "I lost *one ship*, but I did not *lose*."
**BEATRICE:** (to the player, a rare smile) "You may call yourself an honorary admiral."

**Outcomes and receipt.**
- The pirates are broken; the honey is returned to the Thimblefolk (if the Mossdeep quest was done, it is recognised as theirs).
- **Receipt:** a small admiral's pennant flies from the player's boat; the Lirian fleet salutes the player in harbour.

<!-- quest
id: qst_lir_three_gaps
title: The Three Gaps
rank: B
type: Defense
giver: npc_beatrice_morosina
region: reg_lirian
level: 94
act: 3
requires_rank: B
reward: 11500 | 680 | 50000
sets: lir_gaps_resolved
summary: Pirates are coming for all three sandbar gaps at once. The raid is a diversion for a honey ship.
objectives:
  talk npc_beatrice_morosina
  defend lirian_sandbar_middle_gap
  reach lirian_honey_freighter
  choice ram_board_or_parley
-->

---

## 9. The Last Song of Isolde Verro

*B · Investigation · the canals · giver Paolo Verro*

**The short version.** Isolde Verro, Lirian's greatest soprano, has walked into the canal of her own accord. Her brother Paolo does not believe she is dead.

**What is really going on.** Isolde heard the Drowned Choir for years and understood that they were *not* monsters: they were *Lirian's own drowned choir*, singing the last hymn of the old city. She walked in to *sing with them*, and to teach them a closing verse so they could rest. She is still alive, in the drowned cathedral, singing.

**Scene 1: the piano.**

**PAOLO:** "She left a note. 'I am going to finish the song.' That is all."
**PAOLO:** "She is *not* dead. I would feel it. We have played together since she was nine."
**PAOLO:** "The Choir took her. That is what everyone says. I say she *went*."
> ► **"What song?"** — **PAOLO:** "The Lament of the Drowned Cathedral. She spent three years trying to complete it."
> ► **"Where would she go?"** — **PAOLO:** "The old cathedral. Under the Piazza Verde."
> ► **"I'll find her."** — **PAOLO:** "Please. And bring a tuning fork."

**Scene 2: the dive.** Through the drowned city to the cathedral, a vast, dim hall of broken pews and a flooded nave. In the choir stalls, rows of pale figures stand, mouths open in silent song. At the high altar, a woman in a white dress sings alone.

**ISOLDE:** (singing, then speaking) "...You came."
**ISOLDE:** "I hoped *someone* would. I need a second voice, to hold the harmony."
**ISOLDE:** "They are not monsters. They are *waiting to finish*."
> ► **"Finish what?"** — **ISOLDE:** "The hymn. They never did. The sea took them mid-verse."
> ► **"Come home."** — **ISOLDE:** "Not yet."
> ► **"I'll help."** — **ISOLDE:** "Stand there. Hum a third."

**Scene 3: the verse.** A long, beautiful gameplay sequence in which the player and Isolde, with the drowned choir, *complete the hymn*. The player's choices set a harmonic line: tender, solemn, or bright.

*(Gameplay: a rhythm-light sequence, with notes appearing as lantern-lights over the altar. The player may fail the line, and the choir simply starts over.)*

**ISOLDE:** "*Final verse.* Now."
**CHOIR:** *(a single, enormous chord, held, then released)*

**Scene 4: the silence.** When the last note fades, the drowned choir lowers its heads. One by one they dissolve into silver light and rise through the water like bubbles. Isolde sits down on the altar steps and weeps.

**ISOLDE:** "...They're gone."
**ISOLDE:** "Not *all* of them. There are more. The *Choir* is bigger than this cathedral. But these ones are *free*."
**PAOLO:** (arriving breathless) "You *idiot*."
**ISOLDE:** "I know. I love you too."

**Outcomes and receipt.**
- A part of the Drowned Choir is laid to rest; the Tyrant and the main Choir remain. The player's harmonic choices are quoted in the *Lament of the Drowned Cathedral*.
- **Receipt:** the Lament is performed on Maelsday; Isolde sings it each year, and Paolo plays.

<!-- quest
id: qst_lir_isolde_verro
title: The Last Song of Isolde Verro
rank: B
type: Investigation
giver: npc_paolo_verro
region: reg_lirian
level: 98
act: 3
requires_rank: B
reward: 12500 | 720 | 54000
sets: lir_isolde_resolved
summary: Lirian's greatest soprano has walked into the canal to finish a hymn with the Drowned Choir.
objectives:
  talk npc_paolo_verro
  reach lirian_drowned_cathedral
  choice tender_solemn_or_bright
-->

---

## 10. Maelsday, All at Once

*B · Faction · the whole city · giver Lantern-Mistress Ottavia Ruzzini*

*Best played after quests 2 and 9.*

**The short version.** On Maelsday every lantern in Lirian is lit at the same instant. This year someone is trying to *stop* it.

**What is really going on.** The synchronised lighting is an old ward against the Drowned Choir; the coordinated light interrupts their song for one night. A faction of the Consortium, who profit from the Choir's *fear* (they sell protective charms), want the lighting to fail. A single dark canal is enough to draw the Choir into the city.

**Scene 1: the lantern house.**

**OTTAVIA:** "Forty years. Every Maelsday. Every lantern, every window, every gondola. At the stroke of the *last bell*."
**OTTAVIA:** "A city is only as bright as its *quietest lantern*."
**OTTAVIA:** "Someone is sabotaging the oil. Someone is *cutting the wicks*. And I have until dusk to find out who."
> ► **"How many lanterns?"** — **OTTAVIA:** "Sixty thousand."
> ► **"What do you need?"** — **OTTAVIA:** "Eyes. In every district."
> ► **"I'll take the east canals."** — **OTTAVIA:** "Good. Don't dim."

**Scene 2: the lamplighters.** The player moves through six districts, each with its own sabotage and its own solution:
- **The Fish Market:** oil barrels watered down; the fishmonger mixes new oil with fish-fat.
- **The Glassworks:** lantern glass cracked; Orsino Vetri provides spare panes (if quest 3 is done).
- **The Divers' Quay:** wicks cut; Pico (quest 1) mans a second shift.
- **The Singing Court:** a lantern-chain cut; Carlotta (quest 2) rigs a counter-song.
- **The Gondoliers' Landing:** Tullio (quest 6) navigates a dark canal.
- **The Palace Steps:** the Consortium agent is waiting.

**Scene 3: the agent.** On the palace steps, a masked man holds a knife to the last lantern chain.

**AGENT:** "A city of *sixty thousand* lanterns, and I need only one to fail."
**AGENT:** "The Choir will come. People will pay. It's very simple."
> ► **"People will die."** — **AGENT:** "People die *anyway*."
> ► **"You'll be on the wrong side of history."** — **AGENT:** "History is a *market*."
> ► **"Look around you."** — The lanterns of a thousand windows glow at once.

**Scene 4: the lighting.** At the stroke of the last bell, the city lights. Sixty thousand lanterns, window by window, boat by boat, in a wave that rolls from the Piazza to the sandbar. The water glitters. The canals hum. Far under the lagoon, the Choir's song falters, stutters, and *stops*.

**OTTAVIA:** (hoarse) "...All at once."
**OTTAVIA:** "Look. *Look*."
*Along every canal, people stand on their balconies and sing. Not the Choir's song. Their own.*

**Outcomes and receipt.**
- The sabotage is foiled or *absorbed* (a diminished lighting, with consequences for the Choir's strength next season).
- **Receipt:** a new Maelsday custom: every household lights *one extra lantern*, for the player. A wall of lanterns carries the names of everyone who helped.

<!-- quest
id: qst_lir_maelsday
title: Maelsday, All at Once
rank: B
type: Faction
giver: npc_ottavia_ruzzini
region: reg_lirian
level: 102
act: 3
requires_rank: B
requires_quests: qst_lir_counter_song, qst_lir_isolde_verro
reward: 14000 | 800 | 60000
sets: lir_maelsday_resolved
summary: On Maelsday every lantern in Lirian is lit at once. This year someone is sabotaging the lighting.
objectives:
  talk npc_ottavia_ruzzini
  reach lirian_six_districts 6
  reach lirian_palace_steps
  choice confront_expose_or_inspire
-->
