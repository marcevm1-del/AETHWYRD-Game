# 11e-07 — Fanghold, the Wind-Plains: Ten Side Quests (draft)

> *"The nomad clans swore a water-peace three generations ago. Kade is the first man to break it and live."*
> — Gazetteer, Fanghold

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: this region is spoiler-light; quest 4 touches slavery (teen-rated, never graphic).

**Region:** `reg_fanghold` (the steppe, the nomad yurt camps, the Deep Well, the stone markers). **Rank band:** D–B. **Tone:** open, hospitable, proud, and full of weather. Every guest is fed before they are asked their name.

**Placement notes.**
- **Varrick Kade, the Slaver Lord**, is the region's Tyrant. He holds the fortress above the **Deep Well**, the only reliable water for a week's ride, and has broken the sworn **water-peace**. No quest here kills Kade. Quests 4, 8 and 10 are about how the clans *answer*.
- The clans are wolfkin, humans and half-orcs, organised into families that trace descent through their **grandmothers**. Each clan is led by its **eldest woman**. Disputes are settled by horsemanship or arm-wrestling.
- Customs the quests rely on: the **first cup of milk** each day is poured for the wind; no wall may block the wind; **eagles are sacred** and may not be hunted; the wind carries the voices of ancestors.
- Fanghold is the seat of the **Beastkin Federation** (Canon faction table). The Exalted reward there is the *Alpha title and a beast mount*. Quest 9 is the flavour source for that mount.
- Slavery is a **villain's trade**, not a spectacle. No quest dwells on cruelty; the story is about the people who refuse to be sold.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Foal Nobody Named | D | OddJob | Yaska Windtooth | A girl, a foal, the wind |
| 2 | Champion of Pasture Nine | D | Faction | Elder Oyun | A tournament that is not what it seems |
| 3 | The Eagle-Feather Trade | D | Investigation | Eagle-Keeper Batu | Sacred birds, a desperate debt |
| 4 | The Ledger Is Longer Than the Whip | C | Investigation | Mother Sarnai | Inside the fort, quietly |
| 5 | The Grandmother's Seat | C | Faction | Naran Dusksong | Succession by arm-wrestle |
| 6 | Stampede Season | C | Defense | Camp-Master Bayar | The steppe at full gallop |
| 7 | The Wind Carries the Dead | C | Hidden | Old Temuge | A widower, a stone, a voice |
| 8 | Kade's Water Tax | B | Faction | Speaker Dolgor | Who the clans become |
| 9 | The Last Free Stallion | B | Capture | Rider Khulan | A mount who chooses |
| 10 | The Moot of Nine Fires | B | Faction | Moot-Keeper Tsetseg | Nine clans, one fire |

## Cast (new supporting NPCs)

<!-- npc
id: npc_yaska_windtooth
name: Yaska Windtooth
tier: townsfolk
race: Wolfkin
region: reg_fanghold
settlement: Windtooth yurt camp
role: Ten-year-old wolfkin girl
backstory: A fierce, fast ten-year-old wolfkin girl who has decided she will not eat until a wild foal has a name.
-->
<!-- npc
id: npc_elder_oyun
name: Elder Oyun
tier: major
race: Wolfkin
region: reg_fanghold
settlement: Pasture Nine camp
role: Eldest woman of the Greymane clan
backstory: A sharp, practical wolfkin elder who has led the Greymane clan for thirty years and wants to be sure no one wins her pasture by cheating.
-->
<!-- npc
id: npc_batu_eagle
name: Eagle-Keeper Batu
tier: major
race: Human
region: reg_fanghold
settlement: The eagle crags
role: Keeper of the sacred eagles
backstory: A weathered keeper of the sacred eagles who has lost eleven birds this season to a hunter nobody can find.
-->
<!-- npc
id: npc_mother_sarnai
name: Mother Sarnai
tier: major
race: Human
region: reg_fanghold
settlement: Sarnai yurt camp
role: Eldest woman of the Ashfeather clan
backstory: A calm, formidable clan mother whose granddaughter was sold at the Deep Well last winter, and who has not raised her voice once since.
-->
<!-- npc
id: npc_naran_dusksong
name: Naran Dusksong
tier: major
race: Human
region: reg_fanghold
settlement: Dusksong yurt camp
role: Heir of the Dusksong clan, scholar
backstory: A studious, reluctant young woman who has spent six years in Aldmere's libraries and has just come home to be told she may soon lead a clan.
-->
<!-- npc
id: npc_bayar_camp
name: Camp-Master Bayar
tier: major
race: Half-orc
region: reg_fanghold
settlement: Dusksong yurt camp
role: Camp-master
backstory: A big, steady half-orc camp-master who has seen eleven stampedes and says each one is worse than the last.
-->
<!-- npc
id: npc_old_temuge
name: Old Temuge
tier: townsfolk
race: Human
region: reg_fanghold
settlement: The stone markers
role: Widower
backstory: A bent, gentle widower who has carried his wife's ashes in a leather pouch for a year and will not say where he is taking them.
-->
<!-- npc
id: npc_speaker_dolgor
name: Speaker Dolgor
tier: major
race: Human
region: reg_fanghold
settlement: The Water-Peace stone
role: Speaker of the Water-Peace
backstory: A grave, grey-haired speaker who has kept the clans' water-oath for forty years and is the only person alive who has read it in full.
-->
<!-- npc
id: npc_rider_khulan
name: Rider Khulan
tier: townsfolk
race: Wolfkin
region: reg_fanghold
settlement: Khulan yurt camp
role: Young wolfkin rider
backstory: A quick, proud young wolfkin rider who has chased the same wild stallion for three years and has never once come close.
-->
<!-- npc
id: npc_moot_keeper_tsetseg
name: Moot-Keeper Tsetseg
tier: major
race: Human
region: reg_fanghold
settlement: The Nine Fires
role: Keeper of the great moot
backstory: A brisk, no-nonsense moot-keeper who has called the clans together only twice in her life, and has no intention of doing it a third time unless it is worth it.
-->

---

## 1. The Foal Nobody Named

*D · OddJob · Windtooth yurt camp · giver Yaska Windtooth*

**The short version.** A wild foal has followed ten-year-old Yaska into camp and refuses to leave. By clan custom, a wild thing may not be named by a person. It must be named by the wind. Yaska has decided she will not eat until it has a name.

**What is really going on.** The foal's mother died in a stampede. The wind *can* name it; it simply requires a particular quiet that a hungry, determined ten-year-old does not know how to give. The real lesson is patience, and the real danger is that the foal is being hunted.

**Scene 1: the camp.**

**YASKA:** "I'm *not* hungry."
**YASKA:** "I'm *not*. I've decided. I won't eat until he has a name."
**YASKA'S MOTHER:** (from the cookfire) "She's been like this since dawn. Please. Talk sense into her."
> ► **"Why a name?"** — **YASKA:** "Because he has no mother. Somebody should call him *something*."
> ► **"Who names a wild thing?"** — **YASKA:** "The wind. But the wind *won't*."
> ► **"I'll help you ask."** — **YASKA:** "Really? You'd ask the wind?"

**Scene 2: the quiet.** The player and Yaska climb a ridge at dusk, the foal at her heels. It is a long wait. Yaska fidgets, sniffs, counts stones.

**YASKA:** "It's *not working*."
**PLAYER (gently):** "Listen."
**YASKA:** "To *what*?"
**PLAYER:** "To the grass. To the hooves. To nothing."
*(Gameplay: a short quiet-sequence. The player must hold still while the wind builds. Fidgeting resets it.)*
> ► **"Pour the first cup."** — A thin line of milk onto the stone; the grass leans.
> ► **"Tell it about the foal."** — Yaska talks too long, the wind shifts.
> ► **"Say nothing."** — A long, patient silence.

**Scene 3: the hunter.** As the wind finally rises, a flicker of movement at the ridge's far side: a slaver's scout, a lasso at his hip, eyeing the foal.

**SCOUT:** "That's a fine one. Worth fifty silver to a Kade man."
**YASKA:** (very small) "He's *mine*."
**SCOUT:** "He's no one's. He's wild."
> ► **"He's under the wind's protection."** — **SCOUT:** "The wind doesn't pay."
> ► **"Leave."** — The scout rides off; a brief, easy skirmish.
> ► **"Let the foal choose."** — The foal steps *behind* Yaska.

**Scene 4: the naming.** The wind arrives all at once, in a single great breath that flattens the grass and lifts Yaska's hair. For a heartbeat, every blade of grass points the same way, toward the foal.

**YASKA:** (awestruck) "He's... *Dusk-Runner*. That's his name. I *heard* it."
**FOAL:** *(a short, bright whinny)*
**YASKA'S MOTHER:** (from the camp, faint) "Does that mean she'll *eat* now?"

**Outcomes and receipt.**
- The foal is named by the wind; he is not tamed, only *accompanied*. Yaska will ride him in four years.
- **Receipt:** a small carved horse hangs over the Windtooth yurt door; Dusk-Runner grazes at the camp's edge and runs when the player passes.

<!-- quest
id: qst_fan_foal_nobody_named
title: The Foal Nobody Named
rank: D
type: OddJob
giver: npc_yaska_windtooth
region: reg_fanghold
level: 38
act: 2
requires_rank: D
reward: 1500 | 90 | 6200
sets: fan_foal_resolved
summary: A wild foal has followed a ten-year-old into camp. By custom only the wind may name it, and she won't eat until it does.
objectives:
  talk npc_yaska_windtooth
  reach fanghold_windtooth_ridge
  choice milk_story_or_silence
-->

---

## 2. Champion of Pasture Nine

*D · Faction · Pasture Nine · giver Elder Oyun*

**The short version.** Two clans claim the same pasture. Custom says: settle it with a contest. Elder Oyun needs a champion, and she needs someone to notice who is paying the other champion.

**What is really going on.** The rival clan's champion, a famous arm-wrestler named **Zorig**, has been *paid*. A merchant in Kade's pay has been offering silver to anyone who will put the clans at each other's throats.

**Scene 1: the camp.**

**OYUN:** "A dispute is a dispute. In my mother's time it took a day, a horse and a hard hand."
**OYUN:** "This time it's pasture nine. The Greymane claim it, so do the Ironfoot. We meet at dawn."
**OYUN:** "I need a champion. Not a Greymane. *You.*"
> ► **"Why not one of yours?"** — **OYUN:** "Because they'll cheat. They always do."
> ► **"What are the contests?"** — **OYUN:** "Three. Arm-wrestle. Horseback. And a riddle, because the Ironfoot like riddles."
> ► **"I'll do it."** — **OYUN:** "Good. Eat first. A hungry champion is a *fool*."

**Scene 2: the contests.** At dawn on the open pasture, two clans form a ring.
- **Arm-wrestle (Zorig):** a strength contest with a hidden advantage; Zorig's wrist is bound with a *cheating* strap.
- **Horseback:** a short course of gates and ditches.
- **Riddle:** a quick-fire exchange, the Ironfoot grandmother's own.

**ZORIG:** (grunting) "You'll lose."
**PLAYER:** "You're wearing a strap."
**ZORIG:** (a long, startled pause) "...It's *ceremonial.*"
> ► **"Expose the strap."** — A roar from the Greymane side.
> ► **"Ignore it and win."** — A harder, fairer fight.
> ► **"Tell Oyun."** — She strides in and cuts the strap with a knife.

**Scene 3: the paymaster.** After the contest, Zorig corners the player behind a yurt.

**ZORIG:** "I *needed* the silver. My herd's sick. A man came, with a *fat purse*, and said just... *win*."
**ZORIG:** "He called himself Jorvik. He had a Kade seal on his belt."
**ZORIG:** "I didn't know. I swear it."
> ► **"Where is Jorvik?"** — **ZORIG:** "At the well-road. Waiting for the report."
> ► **"You're lucky."** — **ZORIG:** "Am I?"
> ► **"Come back with me."** — **ZORIG:** "To tell Oyun?"

**Scene 4: the settlement.** In front of both clans, Zorig admits the plot. The two elders look at each other. The pasture is *shared*. A new custom is born: the Ironfoot and Greymane herd in alternating seasons, and the "silver paymaster" is publicly named.

**OYUN:** "A pasture is *not worth* a feud."
**IRONFOOT ELDER:** "No. Not worth our *grandchildren*."

**Outcomes and receipt.**
- The player decides whether Zorig is punished, forgiven or enlisted; the paymaster Jorvik is exposed and fled.
- **Receipt:** a stone cairn marks the border between the Greymane and Ironfoot pastures; both clans leave a cup of milk there each dawn.

<!-- quest
id: qst_fan_champion_pasture
title: Champion of Pasture Nine
rank: D
type: Faction
giver: npc_elder_oyun
region: reg_fanghold
level: 40
act: 2
requires_rank: D
reward: 1600 | 95 | 6500
sets: fan_pasture_resolved
summary: Two clans claim the same pasture. The rival champion has been paid to win, and the silver is Kade's.
objectives:
  talk npc_elder_oyun
  reach fanghold_pasture_nine
  choice expose_win_or_tell
-->

---

## 3. The Eagle-Feather Trade

*D · Investigation · the eagle crags · giver Eagle-Keeper Batu*

**The short version.** Eagles are sacred and may not be hunted. Eleven have died this season. Their feathers are appearing at the Fanghold market.

**What is really going on.** The hunter is **Altan**, a fourteen-year-old orphan who owes a debt to Kade's agents and was told eagle-feathers would clear it. He has never killed anything bigger than a hare. The eagles he "killed" are mostly *dead of the cold*; he gathered feathers from carcasses and is terrified of being caught.

**Scene 1: the crags.**

**BATU:** "Eleven. *Eleven* of my birds, in one season."
**BATU:** "The eagles are not mine. They're *the wind's*. I only keep them."
**BATU:** "Whoever is doing this is not a hunter. A hunter would take the *birds*. This one takes the *feathers*."
> ► **"What's the difference?"** — **BATU:** "A hunter wants meat. A thief wants coin."
> ► **"Who sells feathers?"** — **BATU:** "Ten stalls in the market. I know every one."
> ► **"I'll find them."** — **BATU:** "Be quiet. The eagles can *hear* guilt."

**Scene 2: the market.** A trail of bright feathers in a dozen hands. At the ninth stall, a nervous boy, bundled in too-big clothes, sells a single, perfect tail-feather.

**ALTAN:** "It's... a gift! I found it."
**PLAYER:** "Where?"
**ALTAN:** "In the... grass. It was *just there*."
**ALTAN:** (breaking) "Please don't tell."
> ► **"Come with me."** — **ALTAN:** "To the keeper?"
> ► **"What's the debt?"** — **ALTAN:** "Forty silver. To a man from the well."
> ► **"I won't tell. Yet."** — **ALTAN:** "Thank you."

**Scene 3: the carcasses.** In a cold gully, rows of dead eagles lie frozen in the snow-crust. They have not been shot, only starved. A harsh winter and a lost thermal have killed them.

**ALTAN:** "I didn't *kill* them. I swear. I just... *found* them."
**BATU (arriving):** "...The cold took them."
**BATU:** (very quietly) "And you took their feathers."
*A long, terrible silence.*
> ► **"He's a boy."** — **BATU:** "He's a *thief*."
> ► **"He's in debt."** — **BATU:** "That's not my concern."
> ► **"Let him make it right."** — **BATU:** "...How?"

**Scene 4: the debt.** Batu sets a penance: Altan must serve as a keeper's helper for a year, tending the crags, burying the eagles, learning the wind-songs. The player settles his debt in Kade's records by buying out the contract.

**ALTAN:** "I'll work. I'll work *every day*."
**BATU:** "You will work *every day, and every night*."
**BATU:** "...And you will learn to see them *fly*."

**Outcomes and receipt.**
- Altan becomes Batu's apprentice. The eagle deaths are explained; the Kade agent who sold the debt is named.
- **Receipt:** a line of eagle feathers is tied to the crags' gate; Altan sings the eagle-songs each dawn.

<!-- quest
id: qst_fan_eagle_feathers
title: The Eagle-Feather Trade
rank: D
type: Investigation
giver: npc_batu_eagle
region: reg_fanghold
level: 42
act: 2
requires_rank: D
reward: 1700 | 100 | 6800
sets: fan_eagle_resolved
summary: Eleven sacred eagles have died this season and their feathers are on sale. The thief is a fourteen-year-old with a debt.
objectives:
  talk npc_batu_eagle
  reach fanghold_market_ninth_stall
  choice report_hide_or_penance
-->

---

## 4. The Ledger Is Longer Than the Whip

*C · Investigation · the Deep Well fortress · giver Mother Sarnai*

**The short version.** Mother Sarnai's granddaughter was sold at the Deep Well last winter. She wants the ledger that records it, so that the clans can name every person Kade has traded.

**What is really going on.** The ledger is kept by Kade's *clerk*, a frightened man named **Jorvik**, who has begun to feel sick at his own handwriting. He is *willing* to give it up, but he is watched. The player's job is not to fight. It is to *carry a book out*.

**Scene 1: the yurt.**

**SARNAI:** "Sit. Eat. I am not angry. I am past anger. I am *thorough*."
**SARNAI:** "My granddaughter's name is Mira. She was twelve. A man at the well said she would be 'useful.'"
**SARNAI:** "He keeps a ledger. Every person. Every price. I want it."
> ► **"How do I get in?"** — **SARNAI:** "As a buyer. Kade welcomes buyers."
> ► **"Who's the clerk?"** — **SARNAI:** "A man called Jorvik. I am told he is a coward."
> ► **"I'll do it."** — **SARNAI:** "Thank you. Do not fight. Fighting gets people *killed*."

**Scene 2: the fortress.** A stealth-and-conversation sequence. The player enters the fort as a rich buyer. The Deep Well is a vast stone pit, ringed by watchmen and iron cages. Kade himself appears briefly, courteous, amused and utterly unafraid.

**KADE:** "A new customer. How *delightful*. What does a person of taste require?"
**KADE:** "Labour? Companionship? A *specialist*? I have everything. For a price."
> ► **"Water."** — **KADE:** "Ah. Water is the *dearest* thing in Fanghold."
> ► **"A clerk."** — **KADE:** "I have the best. His name is Jorvik."
> ► **"I'd like to see the ledger."** — **KADE:** (laughs) "Everyone does."

**Scene 3: the clerk.** Late at night, in a small, locked room behind the well, Jorvik sits among stacks of books, a candle burning low.

**JORVIK:** "I know why you're here. I knew from the moment you walked in."
**JORVIK:** "I've written eleven hundred names. Every night I wake and recite them."
**JORVIK:** "Take it. Please. *Take it.*"
> ► **"Come with us."** — **JORVIK:** "I can't. Kade would know."
> ► **"Where's the ledger?"** — **JORVIK:** "Under the third floorboard."
> ► **"What's her name?"** — **JORVIK:** "...Mira. Sold to a Strife Marches baron. She's alive."

**Scene 4: the escape.** In a tense, quiet sequence, the player lifts the ledger, slips it into a grain-sack and rides out with a returning grain wagon. At the clan gate, Sarnai takes the book in both hands.

**SARNAI:** "Eleven hundred names."
**SARNAI:** "And *Mira*. Alive. In the Marches."
**SARNAI:** (very quietly) "Thank you. I will remember this when the *wind* turns."

**Outcomes and receipt.**
- The ledger gives the clans a list of every person Kade has traded. If the player takes Jorvik, he lives under clan protection; if not, he gets a quiet message when the clans march.
- **Receipt:** the ledger is kept at the Water-Peace stone; Mira's name has a small mark beside it; Sarnai begins asking for *rides*.

<!-- quest
id: qst_fan_ledger_whip
title: The Ledger Is Longer Than the Whip
rank: C
type: Investigation
giver: npc_mother_sarnai
region: reg_fanghold
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: fan_ledger_resolved
summary: A clan mother's granddaughter was sold at the Deep Well. She wants the ledger that names everyone Kade has traded.
objectives:
  talk npc_mother_sarnai
  reach fanghold_deep_well_clerk_room
  choice carry_take_clerk_or_leave
-->

---

## 5. The Grandmother's Seat

*C · Faction · Dusksong yurt camp · giver Naran Dusksong*

**The short version.** The Dusksong clan's eldest woman is dying. By custom, her seat goes to the winner of an arm-wrestle between her heirs. The strongest is her warrior-grandson. The wisest is Naran, a scholar who has just come home.

**What is really going on.** The old woman, **Grandmother Odval**, has never believed strength alone should decide. She has quietly set a *second test*: a three-day ride, a riddle, and a decision. Only the heir who *chooses* the right thing will keep the seat.

**Scene 1: the yurt.**

**NARAN:** "Six years in Aldmere's libraries. Six years *reading* about home. And I come back to a bed, a dying grandmother, and a seat."
**NARAN:** "I'm a scholar. I can't arm-wrestle. I can't ride. I'm not *meant* for this."
**NARAN:** "But my cousin Temur will lead the clan to war with Kade. And I'm not sure that's *right*."
> ► **"What do you want?"** — **NARAN:** "To be useful. Without lying about who I am."
> ► **"What does Odval want?"** — **NARAN:** "She won't say."
> ► **"I'll stand beside you."** — **NARAN:** "Thank you. I'll need a witness."

**Scene 2: the first test.** The arm-wrestle takes place in the camp at dusk, with the whole clan watching. Temur, a broad, handsome young man, pins Naran in seconds.

**TEMUR:** "No hard feelings, cousin."
**NARAN:** (rubbing her wrist) "None. I'd hoped to go slightly *longer*."
*The clan murmurs. It looks like the seat will go to Temur.*

**Scene 3: the second test.** At night, Odval calls the heirs to her bedside.

**ODVAL:** "A seat is not won by a wrist. Listen."
**ODVAL:** "Three days' ride. A stone marker. A riddle: *What does the wind carry that it cannot lift?*"
**ODVAL:** "And a choice, at the end. The *real* test."
> ► **(Ride with Naran.)** — A long, wind-swept trek.
> ► **(Ride with Temur.)** — A faster, rougher road.
> ► **(Stay with Odval.)** — A quiet vigil.

**Scene 4: the riddle.** At the marker, Naran stands before a carved wolf and a carved eagle. The stone is blank where the riddle's answer should be.

**NARAN:** "*What does the wind carry that it cannot lift?*"
**NARAN:** "...Voices. Words. The things that don't weigh anything. *Grief.*"
*A single breath of wind answers, ruffling her hair.*
**NARAN:** "...That's the answer."
*Behind the stone, a sealed message from Odval: "The seat is not yours to win. It is yours to *carry*."*

**Scene 5: the choice.** Back at camp, Temur and Naran stand before the dying elder.

**ODVAL:** "Which of you will *lead the clan to war*?"
**TEMUR:** "I will."
**ODVAL:** "And which of you will *not*?"
**NARAN:** (very quietly) "...I won't. Not yet. Not until every other road has failed."
**ODVAL:** (smiling, with her last breath) "...*There.* That's the leader."

**Outcomes and receipt.**
- Naran takes the seat; Temur becomes her war-captain. If the player argues for Temur, the clan marches early.
- **Receipt:** a carved wooden seat, covered in wolf-pelt, stands in the Dusksong yurt; Naran's first act as eldest is to *ask for a witness* at every dispute.

<!-- quest
id: qst_fan_grandmothers_seat
title: The Grandmother's Seat
rank: C
type: Faction
giver: npc_naran_dusksong
region: reg_fanghold
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: fan_seat_resolved
summary: A dying clan elder's seat goes to the winner of an arm-wrestle. A scholar heir faces her warrior cousin, and the old woman has set a second test.
objectives:
  talk npc_naran_dusksong
  reach fanghold_riddle_stone
  choice naran_temur_or_odval
-->

---

## 6. Stampede Season

*C · Defense · Dusksong yurt camp · giver Camp-Master Bayar*

**The short version.** Thousands of saiga are thundering toward the Dusksong camp. Something has spooked them. Bayar has fifteen minutes.

**What is really going on.** A pack of orc scouts has set fire to the grass upwind, to drive the herds across the camp and scatter the clans. It is a Kade tactic. The stampede is real; the *fire* is not natural.

**Scene 1: the ridge.**

**BAYAR:** "Eleven stampedes. Eleven. Each worse than the last."
**BAYAR:** "That's the *worst* I've seen. Look at the dust. Look at the *speed*."
**BAYAR:** "They're running from fire. Not wild fire. *Set* fire."
> ► **"What do we do?"** — **BAYAR:** "Split them. Turn them. Or die."
> ► **"How long?"** — **BAYAR:** "Fifteen minutes. If we're lucky."
> ► **"Where's the fire?"** — **BAYAR:** "Upwind. Four miles. I can't spare riders."

**Scene 2: the turn.** A fast, high-stakes defense. The player rides a horse out to the herd's flank, lighting torches, flicking whips, trying to bend the stream of animals away from the camp. A string of riders form a funnel.

*(Gameplay: horseback herding; the player turns the herd with torches, banners and calls. A mis-turn costs a yurt. A good turn saves the camp.)*

**BAYAR (via horn):** "*Left! Hard left! Turn the lead!*"
**RIDER:** "It's *working*! They're bending!"

**Scene 3: the fire.** The player breaks off the herd line and rides upwind alone. Four orc scouts crouch in a line of smoke, tinderboxes in their hands.

**ORC SCOUT:** "Boss says: burn the grass. Don't stop."
**ORC SCOUT:** "We don't even *like* horses."
> ► **"Stop."** — A short, brutal fight.
> ► **"Surrender."** — The scouts, confused, drop their torches.
> ► **"Who sent you?"** — **ORC SCOUT:** "A man with a *seal*."

**Scene 4: the dawn.** The fire dies. The herd, split by the player's turn, thunders past the camp's edge, scattering into the plains. Not one yurt is lost.

**BAYAR:** "...It's over."
**BAYAR:** "Twelve stampedes. And the first I've ever *won*."
*A saiga calf, separated from its herd, stumbles into camp and curls up by a yurt.*

**Outcomes and receipt.**
- The camp stands. The captured orc scouts may be released, handed to the clans, or *recruited* (in the surrender branch).
- **Receipt:** a rider's banner flies at the ridge; Bayar names a new stampede-watch after the player; the calf is raised in camp.

<!-- quest
id: qst_fan_stampede_season
title: Stampede Season
rank: C
type: Defense
giver: npc_bayar_camp
region: reg_fanghold
level: 66
act: 3
requires_rank: C
reward: 4300 | 235 | 16000
sets: fan_stampede_resolved
summary: A saiga stampede is thundering toward the Dusksong camp. The fire that spooked it was set on purpose.
objectives:
  talk npc_bayar_camp
  defend fanghold_dusksong_camp
  reach fanghold_upwind_fire
  choice stop_surrender_or_question
-->

---

## 7. The Wind Carries the Dead

*C · Hidden · the stone markers · giver Old Temuge*

**The short version.** An old man has carried his wife's ashes for a year. He will not say where he is taking them. A silent companion, a tired horse and a long, windy road.

**What is really going on.** Temuge is taking his wife, **Narantsetseg**, to a particular stone marker where, forty years ago, she said she could *hear the wind speak her mother's voice.* He does not believe in ghosts. He wants to hear whether the wind remembers *her*.

**Scene 1: the road.**

**TEMUGE:** "You're kind to stop. I'm not much company."
**TEMUGE:** "I am carrying my wife. She is in the pouch. It is not heavy, but it is... *thick*."
**TEMUGE:** "I have been carrying her for a year. I do not know how to put her down."
> ► **"Where are you going?"** — **TEMUGE:** "A marker. Past the three hills."
> ► **"May I come?"** — **TEMUGE:** "...If you would. I am afraid of getting there alone."
> ► **"Tell me about her."** — **TEMUGE:** "She was *loud*. She laughed at *everything*."

**Scene 2: the walk.** A slow, quiet trek across the steppe. Temuge tells stories: how they met at a horse fair; how she once outrode a wolf-pack; how she kept a stolen lamb in the yurt for a month.

**TEMUGE:** "She said the wind spoke to her at the stone. She said her mother's voice was in it."
**TEMUGE:** "I didn't believe her. I said: it's the *wind*."
**TEMUGE:** "...She said: 'Then you aren't *listening*.'"

**Scene 3: the stone.** At the marker, a tall grey monolith carved with a wolf, an eagle and a horse. The wind blows steadily past, humming across the stone's pitted surface.

**TEMUGE:** "Here."
*He opens the pouch. He does not pour the ashes. He holds them in both hands.*
**TEMUGE:** "I can't."
> ► **"Take your time."** — **TEMUGE:** "I've had a year."
> ► **"Say something to her."** — **TEMUGE:** "...What do I say?"
> ► **"Pour the milk first."** — A thin line of white on the stone.

**Scene 4: the voice.** The wind drops. Then, faint as a distant bell, a voice. A woman's. It laughs.

**VOICE (very faint):** "*...You're late, you old goat.*"
**TEMUGE:** (stiffening) "...Nara?"
**VOICE:** "*I've been waiting. Come on, then. Put me down.*"
*Temuge laughs, once, and then weeps. He opens his hands. The ashes lift, curl, and vanish down the valley.*

**Outcomes and receipt.**
- The wind speaks only if the player has *listened* for the whole walk. If the player rushed, the wind is silent, but Temuge pours the ashes anyway and finds peace.
- **Receipt:** a small cairn at the marker; Temuge stays to keep the stone; passing travellers leave a handful of grass.

<!-- quest
id: qst_fan_wind_carries_dead
title: The Wind Carries the Dead
rank: C
type: Hidden
giver: npc_old_temuge
region: reg_fanghold
level: 68
act: 3
requires_rank: C
reward: 4500 | 245 | 16500
sets: fan_wind_resolved
summary: An old man carries his wife's ashes to a stone marker where she once heard the wind speak. He is afraid of going alone.
objectives:
  talk npc_old_temuge
  escort npc_old_temuge
  reach fanghold_stone_marker
  choice listen_pour_or_speak
-->

---

## 8. Kade's Water Tax

*B · Faction · the Water-Peace stone · giver Speaker Dolgor*

**The short version.** Kade has begun charging a tax on the Deep Well's water. The clans, furious, are talking of *denying water to Kade's men*. Speaker Dolgor warns that they would be breaking the oath they swore to defend.

**What is really going on.** The water-peace says: *no clan may deny water to another.* If the clans deny Kade's men water, they become oath-breakers, which is exactly what Kade wants. He has *baited* the clans. Dolgor has been trying, in vain, to convince the elders that the oath is worth keeping *even against an enemy*.

**Scene 1: the stone.**

**DOLGOR:** "The Water-Peace is carved on this stone. It says: *We will not deny water to any who thirst.* It does not say: *except our enemies.*"
**DOLGOR:** "Kade has broken it. I know. Everyone knows. But if we break it *back*, what are we?"
**DOLGOR:** "I have been the speaker for forty years. I have never been so afraid."
> ► **"What do the elders say?"** — **DOLGOR:** "Half want blood. Half want water. None want *both*."
> ► **"What do you need?"** — **DOLGOR:** "A voice from outside. Someone the elders cannot call a coward."
> ► **"I'll speak."** — **DOLGOR:** "Thank you. Be honest. They'll know if you are not."

**Scene 2: the elders.** In a great circle of yurts, nine elders sit on felt mats. The mood is thick with anger.

**ELDER A:** "He denies *our* water. We deny *his*. It is *simple*."
**ELDER B:** "He has broken the oath. The oath is *dead*."
**ELDER C:** "A dead oath is a *shield*. I would not throw mine away."
> ► **"Break the oath."** — A roar of approval from half the circle.
> ► **"Keep the oath."** — A roar of fury from the other half.
> ► **"Find a third way."** — A long silence.

**Scene 3: the third way.** The player proposes a *water convoy* to the clans' own wells, plus a *public declaration* that the Water-Peace stands, even for Kade's men: *we will give water to the thirsty, and we will take the Well by force from the one who hoards it.*

**DOLGOR:** "...That is not in the oath."
**DOLGOR:** "But it is in its *spirit*."
**ELDER C:** (slowly) "It is a *better* answer than any I had."

**Scene 4: the oath renewed.** At dusk, the nine elders stand at the stone. Each pours a cup of water on its base. Each speaks the oath, one line at a time.

**DOLGOR:** "*We will not deny water to any who thirst.*"
**ALL:** "*We will not deny water to any who thirst.*"
*A thin wind rises, carrying the words across the steppe.*

**Outcomes and receipt.**
- The clans keep the oath. Kade's baiting fails; his men's thirst is quietly relieved. The march on the well remains, but under *rules*.
- **Receipt:** a second line is carved on the Water-Peace stone: *"Not even for an enemy."*; the clans' banners bear a water-drop.

<!-- quest
id: qst_fan_water_tax
title: Kade's Water Tax
rank: B
type: Faction
giver: npc_speaker_dolgor
region: reg_fanghold
level: 94
act: 3
requires_rank: B
reward: 11500 | 680 | 50000
sets: fan_tax_resolved
summary: Kade has taxed the Deep Well. The clans are tempted to deny his men water, which would break the oath they swore to defend.
objectives:
  talk npc_speaker_dolgor
  reach fanghold_water_peace_stone
  choice break_keep_or_third_way
-->

---

## 9. The Last Free Stallion

*B · Capture · the open steppe · giver Rider Khulan*

**The short version.** Khulan has chased the same wild stallion for three years. Tonight Kade's slavers are hunting him, too. She wants someone to keep him *free*.

**What is really going on.** The stallion, **Wind-Under-Stars**, is the last of the old wild herds, never broken, never caught. He is Khulan's *obsession*. But the real story is that she doesn't want to *ride* him. She wants him to have *someone to run with*.

**Scene 1: the camp.**

**KHULAN:** "Three years. Every dawn. Every dusk. I follow him. I have never *once* been close."
**KHULAN:** "He's the last of the Old Herd. Kade wants him. Kade's riders are circling."
**KHULAN:** "I want him *free*. Not mine. Free."
> ► **"What do you need?"** — **KHULAN:** "A decoy. A fast horse. And patience."
> ► **"Why don't you want to ride him?"** — **KHULAN:** "Because he's the *wind*."
> ► **"I'll help."** — **KHULAN:** "Good. Ride soft."

**Scene 2: the chase.** A long, beautiful gameplay chase across the steppe. Kade's riders, in black, swing lassos and nets. The stallion is a grey blur, always just ahead, always just beyond. The player draws riders away with feints and shouts; Khulan circles in the dust.

**KHULAN:** "*Left! Left! Over the ridge!*"
**SLAVER RIDER:** "He's *mine*!"
*The stallion leaps a gully six horses wide.*

**Scene 3: the fall.** On a high plateau, the stallion is cornered against a cliff edge. Slavers close in from three sides. Khulan, sobbing with effort, rides between them.

**KHULAN:** "*Run*, you idiot, *run*!"
*The stallion looks at her. It does not run. It steps forward, lowers its head, and presses it into her shoulder.*
**KHULAN:** (frozen) "...He's *letting* me."
> ► **"Ride him."** — **KHULAN:** "I can't. He's not mine."
> ► **"Let him choose."** — **KHULAN:** "...Yes."
> ► **"Fight the slavers."** — A short, savage skirmish on the plateau.

**Scene 4: the choice.** After the slavers are driven off, Wind-Under-Stars stands in the red light of the dying sun. He looks at the player, at Khulan, at the horizon.

**KHULAN:** (hoarse) "He can go. He's free."
*The stallion paces forward, circles Khulan once, and then, very deliberately, lowers himself to his knees.*
**KHULAN:** "...He's *asking*."
*She mounts. He rises. They ride together into the wind, and for a moment the whole steppe seems to lean.*

**Outcomes and receipt.**
- If the player lets the stallion choose, he accepts Khulan; if not, he is free and still follows her at a distance. In both cases he is *safe*.
- **Receipt:** a grey stallion runs on the horizon at dawn; the Beastkin Federation's **beast mount** reward is themed on his line.

<!-- quest
id: qst_fan_last_stallion
title: The Last Free Stallion
rank: B
type: Capture
giver: npc_rider_khulan
region: reg_fanghold
level: 98
act: 3
requires_rank: B
reward: 12500 | 720 | 54000
sets: fan_stallion_resolved
summary: A rider has chased the last wild stallion of the Old Herd for three years. Kade's slavers are hunting him tonight.
objectives:
  talk npc_rider_khulan
  reach fanghold_stallion_plateau
  choice ride_free_or_fight
-->

---

## 10. The Moot of Nine Fires

*B · Faction · the Nine Fires · giver Moot-Keeper Tsetseg*

*Best played after quests 4, 5 and 8.*

**The short version.** The clans have not met in a full moot in a generation. Tsetseg has called one. Nine clans, nine fires, one decision: do they march on the Deep Well?

**What is really going on.** Every clan has its own grievance, its own fear, its own price. Without a *common cause*, the moot will split. The player's role is not to command but to *listen* and to *thread* the arguments together.

**Scene 1: the Nine Fires.**

**TSETSEG:** "Twice in my life I have called the moot. Both times I regretted it."
**TSETSEG:** "This will be the third. The clans are *angry*. The clans are *afraid*. I would like them to be angry and afraid *together*."
**TSETSEG:** "Walk the fires. Listen. Then tell me what you heard."
> ► **"What am I listening for?"** — **TSETSEG:** "The thing they don't say."
> ► **"How long do I have?"** — **TSETSEG:** "Until the last fire is lit."
> ► **"I'll walk the fires."** — **TSETSEG:** "Walk *slowly*."

**Scene 2: the fires.** The player visits nine fires, each with an elder and a concern:
- **Greymane (Oyun):** "We want our pastures *safe*."
- **Ashfeather (Sarnai):** "We want our *children* back."
- **Dusksong (Naran):** "We want *rules*."
- **Windtooth (Yaska's mother):** "We want our daughters to *ride*."
- **Ironfoot:** "We want to be *asked*."
- **Redrock:** "We want our *dead* honoured."
- **Whitemane:** "We want *food*."
- **Blackwater:** "We want *revenge*."
- **Fleetfoot:** "We want to *leave*."

*(Past quests change what each elder says: Sarnai has the ledger; Naran has the seat; Oyun has the pasture.)*

**Scene 3: the speech.** At the central fire, all nine elders and a thousand clansfolk face the player. This is not a battle. It is a *speech*, a sequence of choices stitching the nine concerns together.

> ► **"We march for the children."** — Sarnai's fire flares.
> ► **"We march for the water."** — Dolgor's oath rings.
> ► **"We march for each other."** — The whole circle shifts.

**TSETSEG:** (softly) "Careful. They will *remember* what you say."

**Scene 4: the vote.** The elders drop *stones* into a great bronze bowl, one for each fire. When the last stone is dropped, the bowl rings like a bell.

**TSETSEG:** "Nine for. Nine *for*."
**TSETSEG:** (hoarse) "...I thought I would never hear that."
*Behind her, nine fires flare as one.*

**Outcomes and receipt.**
- The clans march together on the Deep Well, but in an *order*: first water, then people, then Kade. The siege is *not* ended; the Tyrant fight is now supported by the clans' banners.
- **Receipt:** nine banners hang at the Water-Peace stone; Tsetseg sleeps for three days.

<!-- quest
id: qst_fan_moot_nine_fires
title: The Moot of Nine Fires
rank: B
type: Faction
giver: npc_moot_keeper_tsetseg
region: reg_fanghold
level: 102
act: 3
requires_rank: B
requires_quests: qst_fan_ledger_whip, qst_fan_water_tax
reward: 14000 | 800 | 60000
sets: fan_moot_resolved
summary: The clans meet in a full moot for the first time in a generation to decide whether to march on the Deep Well.
objectives:
  talk npc_moot_keeper_tsetseg
  reach fanghold_nine_fires 9
  choice children_water_or_each_other
-->
