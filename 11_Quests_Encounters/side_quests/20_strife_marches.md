# 11e-20 — The Strife Marches, the Contested Borderlands: Ten Side Quests (draft)

> *"Every baron here can point to the treaty that makes him the rightful one. None of the treaties agree."*
> — Gazetteer, Strife Marches

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3, 7, 9 and 10 touch the Choir of Chains. Its leader's identity and the Red Prophet are not touched.

**Region:** `reg_strife_marches` (border baronies, mercenary forts, Castle Varn, the Field of Coins, the East Road). **Rank band:** C–B. **Tone:** cynical, tough, funny in a black way, and fiercely loyal at the neighbour level. Chapels are the first buildings armies burn, so people keep their gods quietly.

**Placement notes.**
- **Diego Alvarez, Voice of the Choir of Chains,** is the region's Tyrant. His followers chant over battlefields; the fighting turns savage, the dead rise, old feuds reopen. Canon: he cannot be reasoned with or redeemed. No quest here kills him; several are about the *people* his song reaches.
- **Dorran "Red Ledger" Hask** (Canon, redeemable) is **not used** here; his arc belongs to the main story.
- The Marches bury their dead with a coin from each kingdom, so the dead can pay their way whichever side wins.
- Earlier pattern quests here: *The Wedding Tent*, *A Lantern for the Unclaimed*, *The Highwayman Who Took Only Burdens*.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Coin From Every Kingdom | C | Investigation | Sexton Ansgar Tull | A thief with a good reason |
| 2 | Two Barons, One Village | C | Faction | Mistress Edith Wray | A village that decides for itself |
| 3 | The Man Whose Father Sings | C | Investigation | Cobb Hearn | A lullaby in the wrong mouth |
| 4 | A Contract With an Exit | B | Faction | Captain Edda Greyhand | Mercenary lawyering |
| 5 | The Horse That Broke the Peace | B | Exploration | Steward Aldous Reed | A ghost host with a grudge |
| 6 | Smuggler's Honour | C | OddJob | Nell Quickfingers | Three borders in a day |
| 7 | The Deserter's Song | C | Hidden | Corporal Ambrose Fenn | A counter-song |
| 8 | Wheat on the Field of Coins | B | OddJob | Sergeant Bertil Roke | A veteran's retirement |
| 9 | A Chapel in the Cellar | C | Faction | Sister Odile | Quiet faith, under floorboards |
| 10 | The Choir's Quiet Door | B | Investigation | Ilse Brandt | A brother, a belonging |

## Cast

<!-- npc
id: npc_sexton_ansgar_tull
name: Sexton Ansgar Tull
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The Field of Coins
role: Sexton of the battlefield
backstory: A lean, dry sexton who tends the Field of Coins, resets every grave-coin the crows pull up, and has not had a night's uninterrupted sleep in twenty years.
-->
<!-- npc
id: npc_edith_wray
name: Mistress Edith Wray
tier: major
race: Human
region: reg_strife_marches
settlement: Hollowmere
role: Village headwoman of Hollowmere
backstory: A tough, tired headwoman whose village has been claimed by two barons at once and who has decided it is time someone asked the village.
-->
<!-- npc
id: npc_cobb_hearn
name: Cobb Hearn
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: Hearn's Rest
role: Farmer whose father sings
backstory: A broad, anxious farmer who swears his dead father has started singing in his sleep, and who has begun to sleep in the barn.
-->
<!-- npc
id: npc_captain_edda_greyhand
name: Captain Edda Greyhand
tier: major
race: Human
region: reg_strife_marches
settlement: Greyhand's Fort
role: Mercenary captain
backstory: A weathered mercenary captain who wants out of her contract before the Choir reaches her fort and has read her own contract nine times looking for a way.
-->
<!-- npc
id: npc_steward_aldous_reed
name: Steward Aldous Reed
tier: major
race: Ghost
region: reg_strife_marches
settlement: Castle Varn
role: Ghost steward of Castle Varn
backstory: A punctilious ghost steward who has kept Castle Varn's great table laid for the peace feast for sixty years and has strong opinions about who broke it.
-->
<!-- npc
id: npc_nell_quickfingers
name: Nell Quickfingers
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The East Road
role: Smuggler
backstory: A quick, cheerful smuggler who has crossed three borders a day for eleven years and has been paid, by her own count, in almost no honour at all.
-->
<!-- npc
id: npc_corporal_ambrose_fenn
name: Corporal Ambrose Fenn
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The hill camps
role: Deserter and songwriter
backstory: A thin, sleepless deserter who left his company after hearing the Choir and has been writing a tune ever since that he hopes will cancel it out.
-->
<!-- npc
id: npc_sergeant_bertil_roke
name: Sergeant Bertil Roke
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The Field of Coins
role: Retired mercenary sergeant
backstory: A grizzled mercenary sergeant, retired after thirty-one campaigns, who has bought a patch of the Field of Coins and means to grow wheat on it out of pure spite.
-->
<!-- npc
id: npc_sister_odile
name: Sister Odile
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: Millbank
role: Hidden chapel-keeper
backstory: A stern, soft-voiced sister who keeps a small chapel in a cellar, because the last chapel was burned by the army before it.
-->
<!-- npc
id: npc_ilse_brandt
name: Ilse Brandt
tier: townsfolk
race: Human
region: reg_strife_marches
settlement: The East Road
role: Sister of a Choir convert
backstory: A fierce, worn young woman whose younger brother left home to join the Choir of Chains and who has walked the East Road for six weeks looking for him.
-->

---

## 1. The Coin From Every Kingdom

*C · Investigation · the Field of Coins · giver Sexton Ansgar Tull*

**The short version.** The Marches bury their dead with a coin from each kingdom. Someone has been digging the coins back up, one grave at a time.

**What is really going on.** The thief is an eight-year-old girl called **Maisy**, who has been taking the coins to buy bread for six younger children in a burnt barn. She puts back *a button* in each grave, as an apology.

**Scene 1: the field.**

**ANSGAR:** "Three hundred and forty graves. A coin from each kingdom. That's *three* coins. Per grave. I count them every dawn."
**ANSGAR:** "Eleven graves have *buttons.* Where the coins were."
**ANSGAR:** "Someone's *robbing the dead.* And *apologising* about it."
> ► **"Why a button?"** — **ANSGAR:** "That's what I'd like to know."
> ► **"Who'd do this?"** — **ANSGAR:** "A thief with *manners.*"
> ► **"I'll watch tonight."** — **ANSGAR:** "Bring a blanket. The crows are rude."

**Scene 2: the stakeout.** At night, among the crooked graves, a small, quiet figure slips between mounds, a bag at her hip, a very small shovel. She kneels at a grave, whispers, and lays a button in the earth.

**MAISY:** "I'm sorry. I'm so sorry. I'll pay you back. I *swear.*"
> ► **"Who are you talking to?"** — **MAISY:** (a squeak) "Nobody!"
> ► **"What are the buttons for?"** — **MAISY:** "...They're *IOUs.*"
> ► **"I'll help."** — **MAISY:** "...You *will?*"

**Scene 3: the barn.** In a burnt-out barn, six children sit around a small fire.

**MAISY:** "I'm in *charge.* I'm eight and a *half.*"
**MAISY:** "I only take the *smallest* coin. And I say *sorry.*"
**MAISY:** "The soldiers don't *mind.* They *can't.* They're *dead.*"
**ANSGAR (arriving, quietly):** "...They'd *mind.*"
**ANSGAR:** "But they'd *understand.*"

**Scene 4: the arrangement.** The sexton, the player and Maisy work out a plan: the Marches' dead need a *caretaker*, and a caretaker needs *wages.* Maisy and the six become the *Field's* keepers; each grave's coin is *shared*, by custom, with the living.

**ANSGAR:** "I have been looking for an *apprentice* for twenty years."
**MAISY:** "...An *apprentice?*"
**ANSGAR:** "*Seven.* If you count the *small ones.*"

**Outcomes and receipt.**
- The children are housed and fed; the Marches add a *quiet custom:* a fourth coin, *for the living.*
- **Receipt:** a small tin on every grave, marked *"For the keepers."*

<!-- quest
id: qst_mar_coin_every_kingdom
title: The Coin From Every Kingdom
rank: C
type: Investigation
giver: npc_sexton_ansgar_tull
region: reg_strife_marches
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: mar_coin_done
summary: Someone is digging the grave-coins up on the Field of Coins and leaving buttons behind as an apology.
objectives:
  talk npc_sexton_ansgar_tull
  reach marches_coin_field_night
  choice help_report_or_arrange
-->

---

## 2. Two Barons, One Village

*C · Faction · Hollowmere · giver Mistress Edith Wray*

**The short version.** Baron Harl and Baron Venn both claim Hollowmere. Each has a treaty. Neither treaty agrees. The villagers would like someone to decide, and Edith has a better idea.

**What is really going on.** Edith does not want the player to pick a baron. She wants the player to *witness* a village moot and to make sure no baron's men *interrupt it.* The village will vote on its own future.

**Scene 1: the green.**

**EDITH:** "Two barons. Two flags. Two *treaties.* Every season we pay *two* tithes. Last year, *three.* I won't explain."
**EDITH:** "I'd like to ask the *village.* We've never *been* asked."
**EDITH:** "I need a stranger to keep the peace."
> ► **"What will you ask?"** — **EDITH:** "'Whose are we?'"
> ► **"What if the barons object?"** — **EDITH:** "They *will.*"
> ► **"I'll witness."** — **EDITH:** "Thank you."

**Scene 2: the barons.** The two barons' envoys arrive with a dozen men each, glaring across the green.

**HARL'S ENVOY:** "The village is *ours.* By treaty of Castle Varn."
**VENN'S ENVOY:** "By *which* treaty? *Ours* is *newer.*"
**HARL'S ENVOY:** "*Newer* is *worse.*"
> ► **"Let the village speak."** — **EDITH:** "Thank you."
> ► **"Wait your turn."** — **HARL'S ENVOY:** "I do not *wait.*"
> ► **"Sit down."** — A tense pause.

**Scene 3: the moot.** In the long grass, a hundred villagers stand. Edith reads the question. Each person steps to one of three stones: *Harl, Venn, or Neither.*

*(Gameplay: the player keeps the peace, interposing, de-escalating, and, in a last-minute twist, defending a young farmer from a baron's thug.)*

**Scene 4: the count.** The stones are counted in the dusk.

**EDITH:** "Harl: eleven. Venn: nine. *Neither:* eighty."
**EDITH:** "We are *neither.*"
*Behind her, a hundred villagers stand in silence. The envoys look at each other.*
**HARL'S ENVOY:** "...That's *not* an *option.*"
**EDITH:** "It is *now.*"

**Outcomes and receipt.**
- Hollowmere declares itself a *free village;* both barons threaten, then, *separately,* quietly accept. If the player fails to keep the peace, the moot is *disrupted,* and Edith tries again next season.
- **Receipt:** a third flag, plain white, on the village green; a new custom: the Hollowmere moot.

<!-- quest
id: qst_mar_two_barons
title: Two Barons, One Village
rank: C
type: Faction
giver: npc_edith_wray
region: reg_strife_marches
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: mar_barons_done
summary: Two barons claim one village. The headwoman wants to ask the village instead, and needs a witness to keep the peace.
objectives:
  talk npc_edith_wray
  defend marches_hollowmere_green
  choice let_speak_wait_or_sit_down
-->

---

## 3. The Man Whose Father Sings

*C · Investigation · Hearn's Rest · giver Cobb Hearn*

**The short version.** Cobb's father died eight years ago. Now, every night, a low voice sings in the old man's room. Cobb sleeps in the barn.

**What is really going on.** The Choir of Chains has reached the village; its song has *stirred* the dead. Cobb's father is not haunting. He is *trying to finish a lullaby he never sang to his son.* The Choir's chant bends it to chains. The song is *his,* not the Choir's.

**Scene 1: the farmhouse.**

**COBB:** "He sings. At night. In his *room.* It's the old song. The one he sang when I was a boy."
**COBB:** "But *wrong.* There's something *under* it. Like *chains.*"
**COBB:** "I haven't slept in the house in a week."
> ► **"Can I listen?"** — **COBB:** "Please."
> ► **"What was the song?"** — **COBB:** "'The Barley Moon.'"
> ► **"What do you want?"** — **COBB:** "To make it *stop.* Or *finish.* I don't *know.*"

**Scene 2: the room.** At midnight, in the dark old bedroom, a faint, breathy tune rises from the pillow. Under it, a rhythm like a chain-link dragged across stone.

**VOICE (a gentle, tired baritone):** "*...and the barley bows, and the moon goes down...*"
**VOICE:** "*...and I...*"
*The voice breaks. The chain-rhythm *hits,* and the voice *stumbles.*
> ► **(Hum the missing line.)** — The player may *guess* it.
> ► **(Ask Cobb.)** — He may remember.
> ► **(Drown out the chain.)** — A clanging counter-noise.

**Scene 3: the line.** Cobb, at the foot of the bed, hums the line he *always* forgot.

**COBB:** "*...and I'll see you in the morning.*"
**COBB:** "...He never *finished* it. He always fell *asleep.*"
*A great, warm sigh fills the room. The chain-rhythm breaks.*

**Scene 4: the dawn.** Cobb sits on the bed. A faint warmth lingers in the pillow.

**COBB:** "...He finished it."
**COBB:** "He finished it. For *me.*"
*Outside, across the fields, a distant chant rises: the Choir, far away, off-key.*

**Outcomes and receipt.**
- The father is at rest; the house is *quiet.* If the player drowned the chain-noise instead, the Choir's pull *weakens* for a week, but the father's song is *unfinished.*
- **Receipt:** Cobb hums the lullaby on his porch each evening; a small barley-moon carving hangs over his door.

<!-- quest
id: qst_mar_father_sings
title: The Man Whose Father Sings
rank: C
type: Investigation
giver: npc_cobb_hearn
region: reg_strife_marches
level: 66
act: 3
requires_rank: C
reward: 4200 | 230 | 16000
sets: mar_father_done
summary: A farmer's dead father sings at night, under the Choir's chain-rhythm, a lullaby he never finished.
objectives:
  talk npc_cobb_hearn
  reach marches_hearns_rest_bedroom_night
  choice hum_ask_or_drown
-->

---

## 4. A Contract With an Exit

*B · Faction · Greyhand's Fort · giver Captain Edda Greyhand*

**The short version.** Edda's company is contracted to hold a fort until the end of the season. The Choir is two days away. She wants out. The contract has no exit clause.

**What is really going on.** The contract was drafted by a *clever lawyer.* There *is* a loophole, but it is *very small,* in clause nineteen, sub-clause *f*: *"The company shall defend the fort against all enemies of the crown, **save** in the event of a plague."* The Choir's song, by a stretch, is a plague.

**Scene 1: the fort.**

**EDDA:** "I've read this contract nine times. I've read it *backwards.* I've read it *while drunk.*"
**EDDA:** "The Choir is coming. I have forty good soldiers. I'll not see them *sing.*"
**EDDA:** "There is no way out. *Find me one.*"
> ► **"Who drafted it?"** — **EDDA:** "A Velmark lawyer. *Good.*"
> ► **"What's the penalty?"** — **EDDA:** "Hanging. For the *captain.*"
> ► **"I'll look."** — **EDDA:** "Bring a *very* good lawyer."

**Scene 2: the reading.** In a smoky tent, the player and a bored, ink-stained clerk read the contract aloud, line by line. Nineteen clauses. A hundred and twelve sub-clauses. A single, tiny footnote.

**CLERK:** "*'Save in the event of plague.'* What counts as a plague?"
**EDDA:** "Plague is *sickness.*"
**CLERK:** "Or *infestation.*"
**EDDA:** "Is a *chant* an infestation?"
**CLERK:** (slowly) "...It *spreads.* It *affects* the *health* of the *soldiers.* It *bears resemblance to a disease.*"

**Scene 3: the case.** At the baron's court, the player and Edda argue the loophole before a very bored baron's steward.

> ► **"The Choir is a plague."** — **STEWARD:** "It's a *choir.*"
> ► **"The song spreads."** — **STEWARD:** "...Go on."
> ► **"Ask any soldier."** — A hundred soldiers *nod.*
> ► **"Offer a compromise."** — Edda keeps the fort, *without* the garrison.

**Scene 4: the exit.** The steward sighs, signs a paper.

**STEWARD:** "The contract is... *dissolved.* On the grounds of *plague.*"
**EDDA:** (hoarse) "...It worked."
**EDDA:** "Forty soldiers. *Forty.* They'll *live.*"

**Outcomes and receipt.**
- The company leaves; the fort is held by the baron's levies. If the player *failed,* Edda breaks the contract and is outlawed.
- **Receipt:** a framed contract on Edda's wall, with a single clause circled; the company paints *"Plague"* on their banner.

<!-- quest
id: qst_mar_contract_exit
title: A Contract With an Exit
rank: B
type: Faction
giver: npc_captain_edda_greyhand
region: reg_strife_marches
level: 90
act: 4
requires_rank: B
reward: 10000 | 600 | 44000
sets: mar_exit_done
summary: A mercenary captain wants out of her contract before the Choir reaches her fort. The contract has no exit clause.
objectives:
  talk npc_captain_edda_greyhand
  reach marches_barons_court
  choice plague_spread_or_compromise
-->

---

## 5. The Horse That Broke the Peace

*B · Exploration · Castle Varn · giver Steward Aldous Reed*

**The short version.** Castle Varn's great peace lasted eleven years and ended because a baron's son *broke it over a horse.* The ghost steward still lays the table. He wants the *horse's* name cleared.

**What is really going on.** The horse, **Greybell,** was *innocent.* The young baron *thought* his horse had been stolen. It had merely *wandered off.* It was found, safe, three days *after* the first blow. The steward, who *brought the horse home,* has never been believed.

**Scene 1: the hall.**

**ALDOUS:** "Good evening. You are *late.* The feast began *sixty years ago.* Do take a seat."
**ALDOUS:** "I am the steward. I have laid the table *every night* for sixty years."
**ALDOUS:** "I should like to tell you about a *horse.*"
> ► **"The horse?"** — **ALDOUS:** "*Greybell.* A grey mare. A *good* horse."
> ► **"What about her?"** — **ALDOUS:** "She started a *war.*"
> ► **"I'll listen."** — **ALDOUS:** "Splendid."

**Scene 2: the story.** The ghost tells it, with great, wounded dignity.

**ALDOUS:** "The young master's horse went missing on the eve of the signing. He accused the *other* house. Words. A blow. *The peace broke.*"
**ALDOUS:** "I found Greybell *three days later,* in a barley field. *Grazing.*"
**ALDOUS:** "I brought her home. *Nobody believed me.* They had already *burnt* a village."
> ► **"Where is she now?"** — **ALDOUS:** "I do not know."
> ► **"What do you want?"** — **ALDOUS:** "For someone to *know.*"
> ► **"Can we prove it?"** — **ALDOUS:** "...Perhaps."

**Scene 3: the bell.** In the castle moat, half-buried in silt, the player finds a small, tarnished horse-bell, *engraved:* *"Greybell, found in barley."*

**ALDOUS:** (in a whisper) "...She *wore* that."
**ALDOUS:** "I took it off her. I *kept* it. I *dropped* it, the night the castle fell."
*The bell, in the player's hand, rings, once, very faintly.*

**Scene 4: the telling.** At the great table, the player lays the bell before the ghostly guests. A hundred translucent figures turn.

> ► **(Tell the story aloud.)** — The ghost-guests murmur.
> ► **(Lay the bell on the table.)** — The bell chimes.
> ► **(Say nothing; let the bell speak.)** — The ghost-guests *understand.*

**BARON'S GHOST:** (hoarse) "...It was the *horse?*"
**ALDOUS:** "It was *always the horse,* my lord."
*The ghost-feast lowers its cups. For the first time in sixty years, the table is quiet.*

**Outcomes and receipt.**
- The ghost-guests are laid to rest; the castle's door stands open. *If the player lays the bell and says nothing,* Aldous weeps in silence.
- **Receipt:** a small bronze horse on the great table; the Marches have a new saying: *"Don't blame the mare."*

<!-- quest
id: qst_mar_horse_peace
title: The Horse That Broke the Peace
rank: B
type: Exploration
giver: npc_steward_aldous_reed
region: reg_strife_marches
level: 92
act: 4
requires_rank: B
reward: 10500 | 620 | 46000
sets: mar_horse_done
summary: The great peace of Castle Varn broke over a horse. The ghost steward wants the innocent mare's name cleared.
objectives:
  talk npc_steward_aldous_reed
  reach marches_castle_varn_moat
  choice tell_lay_or_silence
-->

---

## 6. Smuggler's Honour

*C · OddJob · the East Road · giver Nell Quickfingers*

**The short version.** Nell has a crate of medicine that must cross three borders in a single day. She has three bribes, two forged passes and one very bad horse. She needs a partner.

**What is really going on.** The medicine is for a plague-struck village, and the *customs men* at each border are, in their own ways, *decent.* Each will let the crate through, if the player says the right thing, or does the right small favour.

**Scene 1: the road.**

**NELL:** "Three borders. One day. The crate's marked *'Cheese.'* It's *not* cheese."
**NELL:** "I've done this a hundred times. It's *always* a bit of *theatre.* Today, I need *two.*"
> ► **"What's in it?"** — **NELL:** "Medicine. For *Millbank.* They've got the red fever."
> ► **"Why not go straight?"** — **NELL:** "Three kingdoms. Each wants a *tax.* By the time it's *paid,* they're all *dead.*"
> ► **"I'll go."** — **NELL:** "Brilliant. Act *bored.*"

**Scene 2: the first border.** A bored guard, a rain-soaked toll-booth.

**GUARD:** "Cheese? What kind?"
**NELL:** "*Strong.*"
**GUARD:** "Let me smell it."
> ► **(Distract him with a joke.)** — **GUARD:** (laughing) "Go on, go on."
> ► **(Pay a small bribe.)** — He pockets it.
> ► **(Tell the truth.)** — **GUARD:** "...Go on. *Quickly.*"

**Scene 3: the second and third.** At the second border, a corporal wants a *song.* At the third, a captain who, it turns out, is Nell's *cousin.*

**CORPORAL:** "I'll let you through for a *rhyme.*"
**PLAYER:** (improvising) "*A crate of cheese, a crate of cheer, a corporal's heart is full this year.*"
**CORPORAL:** "...That's *terrible.* Go on."
**CAPTAIN:** "Nell! Is that cheese? ...It's not cheese."
**NELL:** "*Cousin.*"
**CAPTAIN:** "...I didn't see anything."

**Scene 4: the village.** The crate arrives at dusk, a half hour from sunset. A weeping mother, a doctor, a very small child. The medicine is *just* enough.

**NELL:** "...That's the *best* day's work I've done in *years.*"
**NELL:** "And not a single *coin* in my pocket."

**Outcomes and receipt.**
- The medicine arrives; the village survives. If the player used *only* bribes, Nell is *impressed* but *poorer.*
- **Receipt:** a tiny wheel of cheese on Nell's cart; a "Millbank" stamp in her passport.

<!-- quest
id: qst_mar_smugglers_honour
title: Smuggler's Honour
rank: C
type: OddJob
giver: npc_nell_quickfingers
region: reg_strife_marches
level: 62
act: 3
requires_rank: C
reward: 3700 | 205 | 14000
sets: mar_smuggler_done
summary: A smuggler must carry a crate of medicine across three borders in one day, past three very different customs men.
objectives:
  talk npc_nell_quickfingers
  reach marches_three_borders 3
  choice joke_bribe_or_truth
-->

---

## 7. The Deserter's Song

*C · Hidden · the hill camps · giver Corporal Ambrose Fenn*

**The short version.** A deserter has been hiding in the hills, writing a song. He says it will *cancel* the Choir's chant. He is wanted. He is also *right.*

**What is really going on.** Ambrose is a former regimental drummer. The Choir's song has a *particular* rhythm. His counter-song is an *off-beat march,* a *chant against a chant.* It works, but only if *many* people sing it *at once.* He needs a *crowd,* and he cannot show his face.

**Scene 1: the camp.**

**AMBROSE:** "I'm a deserter. Please don't hang me. I have a *song.*"
**AMBROSE:** "I heard the Choir *once.* It *got into my head.* I couldn't *stop* the beat. I left my company because I couldn't *march* to any *other.*"
**AMBROSE:** "So I wrote *another.*"
> ► **"Sing it."** — **AMBROSE:** "...Very quietly."
> ► **"Why would it work?"** — **AMBROSE:** "Because it's *wrong.* In the right *way.*"
> ► **"I'm not going to hang you."** — **AMBROSE:** "That's... *reassuring.*"

**Scene 2: the tune.** In a hollow, in the dusk, a thin, defiant, slightly absurd tune, a march in an *odd* time.

*(Gameplay: the player learns the tune. It is short and catchy. A few bars from a distant Choir chant make the player's own *humming* waver.)*

**AMBROSE:** "*Left, right, left, left, right.* You see? It *trips.*"
**AMBROSE:** "The Choir can't *follow.* It's *too* strange."

**Scene 3: the crowd.** At a market, in front of a crowd of tired soldiers, farmers and children, the player begins to hum. A few catch it. Then a few more. Then a *hundred.*

**SOLDIER:** "What's that?"
**FARMER:** "It's *ridiculous.*"
**CHILD:** "I like it."
*Across the field, the Choir's chant, faint and far, *stumbles.*

**Scene 4: the pardon.** After the market, a captain of the baron's watch steps forward, tense.

**CAPTAIN:** "That man is a *deserter.*"
> ► **"He's a songwriter."** — **CAPTAIN:** "...He's *both.*"
> ► **"The song saved your men."** — **CAPTAIN:** "...It's *annoying.* But it works."
> ► **"Arrest me instead."** — **CAPTAIN:** "...*What?*"

**CAPTAIN:** "...I didn't see him."

**Outcomes and receipt.**
- Ambrose is quietly pardoned or ignored; the *Deserter's Song* spreads along the East Road. The Choir's pull is *weakened* in the villages that sing.
- **Receipt:** soldiers hum an odd march on night watch; Ambrose's drum hangs on the player's wall.

<!-- quest
id: qst_mar_deserters_song
title: The Deserter's Song
rank: C
type: Hidden
giver: npc_corporal_ambrose_fenn
region: reg_strife_marches
level: 68
act: 3
requires_rank: C
reward: 4500 | 245 | 16500
sets: mar_song_done
summary: A deserter has written an off-beat march that trips the Choir's chant. He needs a crowd to sing it, and can't show his face.
objectives:
  talk npc_corporal_ambrose_fenn
  reach marches_market_crowd
  choice songwriter_saved_or_arrest
-->

---

## 8. Wheat on the Field of Coins

*B · OddJob · the Field of Coins · giver Sergeant Bertil Roke*

**The short version.** A retired mercenary has bought a patch of the Field of Coins. He wants to grow wheat on it. The locals think he is mad.

**What is really going on.** Bertil fought in half the battles whose dead are buried in that field. He is *old,* tired and *very stubborn.* He wants to *turn the field green.* The sexton, Ansgar, *does not want the graves disturbed.* The solution is a *wheat-ring* around each grave.

**Scene 1: the plot.**

**BERTIL:** "Thirty-one campaigns. *Thirty-one.* I buried half this field."
**BERTIL:** "I've *bought* it. A quarter acre. I mean to grow *wheat.*"
**BERTIL:** "The sexton says I'll *disturb* the dead. I say I'll *feed* the living. I'm *right.*"
> ► **"What does the sexton say?"** — **BERTIL:** "He says I'm a *ghoul.*"
> ► **"What do the dead want?"** — **BERTIL:** "I've never *asked.*"
> ► **"I'll help."** — **BERTIL:** "Bring a *very* big hoe."

**Scene 2: the argument.** Ansgar and Bertil argue across a low hedge. It's a long, comic, deeply ancient argument.

**ANSGAR:** "It is a *graveyard.*"
**BERTIL:** "It is a *field.*"
**ANSGAR:** "It is a field *with graves.*"
**BERTIL:** "Then *plant round them.*"
**ANSGAR:** "...*Plant round them?*"

**Scene 3: the planting.** A long, patient, gently funny sequence. The player and Bertil dig a ring of furrows round each grave, leaving every mound untouched. Ansgar, grumbling, supervises.

**ANSGAR:** "Not *there.* That's Private Hollis. He *hated* wheat."
**BERTIL:** "Hollis? Hollis owed me *four silver.*"
**ANSGAR:** "He's *dead.*"
**BERTIL:** "He's *still* owing."

**Scene 4: the harvest.** A season later, the field is a sea of gold, *ringed* round each grave by a single, bright strip. The first loaf of bread, baked in the sexton's oven, is shared on the field.

**BERTIL:** "...It's *good* wheat."
**ANSGAR:** "It's the best I've *tasted.*"
**BERTIL:** "They fed it, you know. All of them."

**Outcomes and receipt.**
- The field is green; the Marches' dead *feed* the living. If the player sides with Ansgar, the wheat is planted at the *edge,* and Bertil sulks.
- **Receipt:** a loaf on every grave at harvest; a small plaque: *"Planted round. — B.R."*

<!-- quest
id: qst_mar_wheat_coins
title: Wheat on the Field of Coins
rank: B
type: OddJob
giver: npc_sergeant_bertil_roke
region: reg_strife_marches
level: 94
act: 4
requires_rank: B
reward: 11000 | 650 | 48000
sets: mar_wheat_done
summary: A retired mercenary wants to grow wheat on a quarter-acre of the Field of Coins. The sexton thinks he is a ghoul.
objectives:
  talk npc_sergeant_bertil_roke
  reach marches_coin_field_plot
  choice plant_round_edge_or_argue
-->

---

## 9. A Chapel in the Cellar

*C · Faction · Millbank · giver Sister Odile*

**The short version.** Millbank's chapel was burned by an army sixty years ago. Sister Odile keeps a new one in a cellar, in secret. The Choir's chant is near. She wants it hidden *and* kept holy.

**What is really going on.** The chapel is *not* in danger from soldiers. It is in danger from *quiet.* The Choir's song makes people *forget* to pray. Odile wants a hundred villagers to *come* to the cellar on a single night and *sing* a hymn together.

**Scene 1: the cellar.**

**ODILE:** "Down here. Mind the third step. It's *loud.*"
**ODILE:** "A chapel. In a cellar. It's *absurd.* But it's *ours.*"
**ODILE:** "The Choir is *close.* I fear it will *take* us."
> ► **"How?"** — **ODILE:** "By making us *forget.* To pray. To *sing.*"
> ► **"What do you need?"** — **ODILE:** "A hundred people. A hymn. A night."
> ► **"I'll gather them."** — **ODILE:** "*Quietly.* The army has ears."

**Scene 2: the gathering.** The player moves through Millbank, a muddy, tired village, whispering invitations.

**BAKER:** "A *hymn?* I haven't sung in *twenty years.*"
**BLACKSMITH:** "I don't *believe* any more."
**OLD WOMAN:** "I'll *come.* I never *stopped.*"
> ► **(Persuade, bargain, or promise.)** — Each villager has a reason.

**Scene 3: the night.** In the dim cellar, a hundred villagers crowd between barrels and sacks. Odile raises a hand. A single candle.

**ODILE:** "The old one. The one with the three verses. You *know* it."
*They sing. It is *thin, cracked, out of tune.* In the village streets above, the Choir's chant rises, *seeking.*
> ► **(Sing.)** — The player adds a voice.
> ► **(Keep watch.)** — A tense, silent post at the cellar door.
> ► **(Lead the second verse.)** — A moment of leadership.

**Scene 4: the dawn.** The hymn ends. The Choir's chant, outside, hangs in the air, uncertain, and then, very slowly, *recedes.*

**ODILE:** "...They didn't *find* us."
**ODILE:** "They *couldn't.* We were *too loud.*"

**Outcomes and receipt.**
- Millbank *keeps* its faith, in a cellar. The Choir's pull is weaker, for a time.
- **Receipt:** a candle in the cellar's window, visible only from within; a hundred names on a bench.

<!-- quest
id: qst_mar_chapel_cellar
title: A Chapel in the Cellar
rank: C
type: Faction
giver: npc_sister_odile
region: reg_strife_marches
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: mar_chapel_done
summary: A village keeps its chapel in a cellar. The Choir's song makes people forget to pray, and a hundred voices must sing one hymn.
objectives:
  talk npc_sister_odile
  reach marches_millbank_cellar
  choice sing_watch_or_lead
-->

---

## 10. The Choir's Quiet Door

*B · Investigation · the East Road · giver Ilse Brandt*

**The short version.** Ilse's younger brother, **Jory,** left home to join the Choir of Chains. She has followed the East Road for six weeks. She wants him back, and she does not know if he *wants* to come.

**What is really going on.** Jory did not join for *belief.* He joined for *belonging.* He had been a quiet boy in a loud house. The Choir *noticed* him, *named* him and gave him a *seat.* He is *ashamed.* He is not *evil.* The player's job is not to defeat the Choir. It is to *talk to a boy.*

**Scene 1: the road.**

**ILSE:** "Six weeks. I've followed every rumour. *Jory.* He's *seventeen.* He was always *so quiet.*"
**ILSE:** "I'm not going to *fight* them. I just want to *see* him."
**ILSE:** "Will you come? I'm *afraid* of what I'll say."
> ► **"I'll come."** — **ILSE:** "Thank you."
> ► **"What if he doesn't want to leave?"** — **ILSE:** "...Then I want to *hear* it."
> ► **"What will you say?"** — **ILSE:** "I don't *know.*"

**Scene 2: the camp.** On a gloomy hillside, a Choir camp: tents, chains hanging from every pole, a single chanting circle. At its edge, a thin, pale boy sits alone, eating a crust.

**JORY:** "...Ilse?"
**ILSE:** "...Hello, Jory."
**JORY:** "How did you *find* me?"
**ILSE:** "I walked."
> ► **(Step back; let them talk.)** — A long silence.
> ► **(Offer Jory food.)** — He takes it.
> ► **(Stand beside Ilse.)** — She leans on you.

**Scene 3: the talk.**

**JORY:** "They *see* me. At home, nobody did."
**JORY:** "They *asked* me my *name.* They made me a *place.*"
**JORY:** "I know what they do. I *know.* But it's the first time I ever felt like I *belonged.*"
**ILSE:** "...I never knew."
**ILSE:** "I'm so *sorry.*"
> ► **"You can belong somewhere else."** — **JORY:** "Where?"
> ► **"Come home."** — **JORY:** "...To *what?*"
> ► **"Stay, if you must. But call."** — **ILSE:** "...*Oh.*"

**Scene 4: the door.** Jory stands. He does not leave the camp. He walks, very slowly, to its edge, and sets down his chain.

**JORY:** "I'm not coming back *yet.*"
**JORY:** "But I'm *not* staying."
**JORY:** "There's a... *place.* A *chapel,* Odile's. I'll *go* there."
*Ilse, weeping, takes his hand.*

**Outcomes and receipt.**
- Jory leaves the Choir. The *Choir's quiet door* (the unspoken way out) is *known* to the player, for later quests. If the player pushes, Jory *stays.*
- **Receipt:** a small chain, set down at a crossroads; Jory sends a letter, signed with *both* names.

<!-- quest
id: qst_mar_choir_quiet_door
title: The Choir's Quiet Door
rank: B
type: Investigation
giver: npc_ilse_brandt
region: reg_strife_marches
level: 96
act: 4
requires_rank: B
reward: 11500 | 680 | 50000
sets: mar_door_done
summary: A young woman has followed the East Road for six weeks looking for her brother, who joined the Choir of Chains for belonging.
objectives:
  talk npc_ilse_brandt
  reach marches_choir_camp
  choice step_back_food_or_stand
-->
