# 11e-34 — The Kitsune Isles, the Isles of Fox and Promise: Ten Side Quests (draft)

> *"Every promise is witnessed by a fox, and every contract is sealed with a drop of blood and a grain of rice."*
> — Gazetteer, Kitsune Isles

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 9 plants an unexplained seed.

**Region:** `reg_kitsune_isles` (Fox Shrine Isle and the Ninefold Shrine, the spirit inns, the Sunken Isle, the Cliff of Promises). **Rank band:** C-A (data band C-A; the region is `besieged`). **Tone:** courteous, precise, eerie and kind; everyone is polite, and everyone counts.

**Placement notes.**
- **The Hollow Bride** is the region's Tyrant, and **no quest here touches her.** She walks the cliffs and the inns close at dusk; quests 5 and 10 mention the closed doors and the hush, and nothing more. No quest names her betrothed, her family or her cure, and **none uses Suzune Kagura or her family's shrine** (that arc belongs to its own set; the "fox-eared woman reclaiming a shrine" hook is deliberately left alone). Fox-spirits and shrine-keepers here are local and independent of that arc.
- Customs the quests rely on: **every promise is witnessed by a fox**, contracts are sealed with **a drop of blood and a grain of rice**, a spirit inn's **house rules are contracts** and humans are guests, each island has **one shrine on its peak** reached by a long stair, **mist** rolls in each morning and burns off by noon, and **the Ninefold** founded the isles. Spirits live off offerings, contracts and strong feelings.
- No quest here uses `SiegeDefence`; the one `Defense` quest (10) is a festival night. Rewards follow the C, B and A rows of `Data/World/guild_ranks.json` and the neighbouring files.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Rice and the Blood | C | OddJob | Apprentice Witness Sorabi Tsukigata | Comic-warm: a fox's first witnessing |
| 2 | Tea for the Sunken Shrine | C | Exploration | Amane Kozue | Quiet: low tide and an old courtesy |
| 3 | The Umbrella That Waited | C | Hidden | Kasamaro | Tender: a tool that remembers |
| 4 | The Inn That Began to Eat | B | Investigation | Innkeeper Ohane Matsukage | Tense: a house rule, a hungry house |
| 5 | The Lamp at the Door | B | Faction | Dusk-Lamp Warden Rinji Hotaru | Dilemma: open or stay closed |
| 6 | A Wedding in the Sun-Shower | B | Escort | Procession-Master Sakae Midorikawa | Warm: a fox wedding and a stubborn aunt |
| 7 | The Nine Gates | B | Exploration | Gatekeeper Toma Shirabe | Wonder: nine questions on nine stairs |
| 8 | Leaf Money | A | OddJob | Gonbei Tanukida | Comic-warm: a tanuki's debt |
| 9 | What the Tide Remembers | A | Hidden | Haruto Umikage | Grief: a family at a sunken shrine |
| 10 | Lantern Night | A | Defense | Festival-Marshal Chiyo Akatsuki | Action: a festival that must go on |

## Cast

<!-- npc
id: npc_sorabi_tsukigata
name: Sorabi Tsukigata
tier: townsfolk
race: Kitsune
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Apprentice fox-witness
backstory: A nervous two-tailed kitsune apprentice who must witness her first promise this week and has memorised the wording of four hundred of them without once saying one aloud.
-->
<!-- npc
id: npc_amane_kozue
name: Amane Kozue
tier: major
race: Human
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Keeper of the Ninth Tail Teahouse
backstory: A composed, tireless woman with fox-ears who keeps the Ninth Tail Teahouse and carries a pot of tea to the Sunken Isle every low tide of the new moon, as her family has for four generations.
-->
<!-- npc
id: npc_kasamaro
name: Kasamaro
tier: townsfolk
race: Spirit
region: reg_kitsune_isles
settlement: Spirit inns
role: Umbrella spirit
backstory: A one-eyed, one-legged paper umbrella that woke up the day its owner stopped taking it out in the rain, and has been hopping politely around the spirit inns ever since, looking for her.
-->
<!-- npc
id: npc_ohane_matsukage
name: Innkeeper Ohane Matsukage
tier: major
race: Spirit
region: reg_kitsune_isles
settlement: Spirit inns
role: Spirit innkeeper
backstory: A proud, formal tanuki-spirit innkeeper whose inn has begun, by its own rules, to eat a guest, and who is very embarrassed about it.
-->
<!-- npc
id: npc_rinji_hotaru
name: Dusk-Lamp Warden Rinji Hotaru
tier: major
race: Kitsune
region: reg_kitsune_isles
settlement: Spirit inns
role: Warden of the dusk lamps
backstory: A slight, watchful fox-woman who lights the lamp at each inn door at dusk and has been asked by half the isles to put it out.
-->
<!-- npc
id: npc_sakae_midorikawa
name: Procession-Master Sakae Midorikawa
tier: major
race: Kitsune
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Master of fox-wedding processions
backstory: An elderly kitsune who has led the sun-shower wedding procession across the isles for fifty years and has never been late for the rain.
-->
<!-- npc
id: npc_toma_shirabe
name: Gatekeeper Toma Shirabe
tier: townsfolk
race: Human
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Gatekeeper of the Ninefold Shrine
backstory: A mild shrine-keeper with fox-ears who has climbed the nine stairs of the Ninefold Shrine eleven thousand times and has never reached the ninth gate with the same answer twice.
-->
<!-- npc
id: npc_gonbei_tanukida
name: Gonbei Tanukida
tier: townsfolk
race: Spirit
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Tanuki merchant
backstory: A round, jovial tanuki merchant who pays his debts with leaves that turn to coin at noon, and who has just been sued, in the shrine court, by a very patient pearl-diver.
-->
<!-- npc
id: npc_haruto_umikage
name: Haruto Umikage
tier: townsfolk
race: Human
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Fisherman of the Umikage line
backstory: A quiet, careful man whose grandfather broke the promise that sank an island, and who has never in his life made a promise he was not sure he could keep.
-->
<!-- npc
id: npc_chiyo_akatsuki
name: Festival-Marshal Chiyo Akatsuki
tier: major
race: Kitsune
region: reg_kitsune_isles
settlement: Fox Shrine Isle
role: Marshal of Lantern Night
backstory: A brisk, red-sleeved fox-woman who has run the isles' Lantern Night for thirty years and treats it as a campaign.
-->

---

## 1. The Rice and the Blood

*C · OddJob · Fox Shrine Isle · giver Apprentice Witness Sorabi Tsukigata*

**The short version.** Sorabi must witness her first promise this week: a boat loan between a fisherman and a tanuki, neither of whom trusts the other's wording. She knows every phrase. She has never said one. She wants the player to stand with her.

**What is really going on.** A witness's job is not to judge but to *remember exactly.* Sorabi's fear is that a promise, once witnessed, is real, and that if she mishears one word two neighbours will be bound to the wrong thing. The player's job is to help her find the plain version of what the two parties want, and not to let either of them cheat it.

**Scene 1: the shrine.**

**SORABI:** "Four hundred promises, word for word. I could say them in my sleep. I *do.*"
**SORABI:** "Tomorrow I witness a real one. A drop of blood, a grain of rice, a fox who remembers."
**SORABI:** "If I get it wrong, two people are bound to something they didn't mean."
> ► **"What if you stumble?"** — **SORABI:** "Then I stumble *and* they're bound."
> ► **"I'll stand with you."** — **SORABI:** "Thank you. Don't say anything. *Please.*"
> ► **"Who are the parties?"** — **SORABI:** "A fisherman, Kenji, and a tanuki, Pompo. About a boat."

**Scene 2: the two parties.** On a shingle beach, Kenji, a lean fisherman with a bad shoulder, and Pompo, a cheerful tanuki in a merchant's coat, argue over a boat Kenji wants to lease. Each has a clause. Kenji wants "until the tide turns." Pompo wants "until the loan is repaid." Neither says what they mean.

**KENJI:** "I'll pay when I'm able."
**POMPO:** "*Able.* That's a stretchy word."
**SORABI:** (whispering) "A stretchy word is how islands sink."
> ► **"Ask each of them what 'able' means."** — The argument slows.
> ► **"Offer a date."** — Both are uneasy.
> ► **"Let Sorabi write it down."** — She is terrified, and does.

**Scene 3: the witness.** On the shore, Sorabi, in her ceremonial sash, holds a bowl of rice and a small blade. Kenji and Pompo have settled on: *"until Kenji's second catch of silver-fish, or the first frost, whichever comes first."* A drop of each party's blood, a grain of rice on each thumb. Sorabi begins.

**SORABI:** "I w-witness. That Kenji borrows. The boat *Pearl-Gull.*"
**SORABI:** (breathes) "Until the second silver-fish catch, or the first frost."
The fox who appears at her side, an old grey one with a white-tipped tail, listens, sniffs once, and sits.
> ► **(Stay silent.)** — She finishes alone.
> ► **(Mouth the words with her.)** — A small help.
> ► **(Repeat each phrase to Kenji and Pompo.)** — Careful, and slow.

**Scene 4: the seal.** The fox lays its paw on the bowl. A faint warmth runs along the shingle. The promise is real. Sorabi, wobbling, sits on a rock and laughs.

**SORABI:** "I *said* it. All of it. Nobody's sinking."
The old grey fox yawns, as if to say that a first witnessing is always like this.

**Afterword: the shingle.** Weeks later the player passes Kenji mending his nets beside the *Pearl-Gull.* He calls out that the first silver-fish catch came in on the second morning and he has already paid Pompo the last of the loan. Pompo, sitting on an upturned crate and eating a rice ball, looks faintly offended not to have been asked to renegotiate. "The grey fox came to see the boat paid," Kenji adds. "Sat on the bow the whole afternoon. Very correct."

**Outcomes and receipt.**
- The promise is sealed in plain terms. If the player let the two parties argue it out, Sorabi is steadier and takes the next witnessing alone; if the player prompted each phrase, she leans on them for a month.
- **Receipt:** a grain of rice kept in a tiny jar on Sorabi's belt; the old grey fox follows her to every witnessing thereafter.

<!-- quest
id: qst_kit_rice_blood
title: The Rice and the Blood
rank: C
type: OddJob
giver: npc_sorabi_tsukigata
region: reg_kitsune_isles
level: 58
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: kit_witness_done
summary: An apprentice fox-witness must witness her first promise, a boat loan between a fisherman and a tanuki, and is terrified of mishearing a word.
objectives:
  talk npc_sorabi_tsukigata
  reach kitsune_shingle_beach
  choice silence_mouth_or_repeat
-->

---

## 2. Tea for the Sunken Shrine

*C · Exploration · the Sunken Isle · giver Amane Kozue*

**The short version.** On the new-moon low tide, the shrine on the Sunken Isle stands bare of water for an hour. For four generations the keepers of the Ninth Tail Teahouse have carried a pot of tea out across the wet sand and left it on the shrine's step. Amane has hurt her ankle. The tide waits for no one.

**What is really going on.** The tea is an apology, never explained in words, from a family that is *not* the fisherman's family and has no obvious debt. The teahouse's founder is said to have been the first human who was kind to the island after it sank. The player's job is a long wet walk, a pot that must stay hot, and an hour that ends whether you are ready or not.

**Scene 1: the teahouse.**

**AMANE:** "Every new moon. Four generations. I've never been late."
**AMANE:** "I've a turned ankle and a pot that must stay hot. Will you carry it?"
**AMANE:** "You'll have an hour. Not an hour and a minute."
> ► **"Why tea?"** — **AMANE:** "Because no one else brought any."
> ► **"What's the tide?"** — **AMANE:** "Out for an hour. Then *in.*"
> ► **"I'll go."** — **AMANE:** "Walk on the dark sand. The pale sand is soft."

**Scene 2: the crossing.** Wet sand, pools full of small, indignant crabs, the long grey ribs of old posts. The pot, wrapped in a quilted cloth, is warm against the player's chest. Halfway across, the mist rises and the shore vanishes. A small voice from the sand.

**CRAB:** (a surprisingly polite click) "*Left, please.*"
> ► **"Follow the crab."** — It leads, grandly.
> ► **"Trust the dark sand."** — Safe, slower.
> ► **"Hurry."** — The pale sand sucks at a boot.

**Scene 3: the shrine.** The Sunken Isle's shrine is a small thing of black wood, furred with weed, its step slick and green. On the step, a ring of rings: old teacups, one for each visit, all upside down. The player sets the pot on the step and pours.

**AMANE (in the memory of her instructions):** "Pour three. One for the shrine, one for the sea, one for the one who left. Say nothing."
The tea steams. A tiny fox-shaped shadow in the doorway, there and gone.
> ► **(Say nothing.)** — Amane's instruction, kept.
> ► **(Say, "We remember.")** — A small, new thing.
> ► **(Pour a fourth cup.)** — For the player's own.

**Scene 4: the tide.** The water returns with a quiet hiss. The player runs the last stretch with the empty pot, soaked to the knees, and arrives at the teahouse's steps with water in one boot and a grin. Amane, her ankle bound, meets them with a towel.

**AMANE:** "Did it take the cups?"
**AMANE:** "Then it was a good visit."

**Afterword: the wall of stewards.** Amane insists the player sit in the teahouse and be served, which is an honour reserved, as the waitresses whisper, for people who have been to the Sunken Isle and come back dry above the knee. She talks, for the first time, about her great-grandmother, who walked the same sand on the first new moon and left the first cup. "She said it was not an apology," Amane says. "She said it was a *hello,* and that nobody had said it yet."

**Outcomes and receipt.**
- The tea is delivered. If the player poured the fourth cup or spoke, the cups on the step are found, next month, set the right way up, once. If the player hurried, a boot is lost to the sand.
- **Receipt:** a new teacup, upside down, among the old ones; Amane's family adds the player's name to the teahouse's long wall of stewards.

<!-- quest
id: qst_kit_tea_sunken
title: Tea for the Sunken Shrine
rank: C
type: Exploration
giver: npc_amane_kozue
region: reg_kitsune_isles
level: 62
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: kit_tea_done
summary: A teahouse keeper with a turned ankle needs a pot of tea carried across the sand to the Sunken Isle's shrine in the one hour the tide allows.
objectives:
  talk npc_amane_kozue
  reach kitsune_sunken_isle_shrine
  choice silent_speak_or_fourth
-->

---

## 3. The Umbrella That Waited

*C · Hidden · the spirit inns · giver Kasamaro*

**The short version.** A paper umbrella with one eye and one leg has been hopping from inn to inn for three weeks. It woke up the day its owner stopped taking it out in the rain, and it would like, very politely, to be picked up again. Nobody has yet understood what it is saying.

**What is really going on.** Tsukumogami are tools that have been used long enough to wake. Kasamaro's owner, an old woman called Yoshiko, did not abandon it; she grew too frail to walk to the market, and it was left in the stand by the door. Kasamaro does not want to be *used.* It wants to be *carried by her once more,* in the one kind of rain she liked.

**Scene 1: the inn.**

**KASAMARO:** (a small, rustling, sing-song voice, subtitled) *"Excuse me. Excuse me. I'm looking for the lady with the green sleeves."*
**KASAMARO:** *"I stood in the stand. I was very patient. Nobody came."*
**KASAMARO:** *"I think she's cross with me."*
> ► **"Who is she?"** — **KASAMARO:** *"Yoshiko. She walks slowly. She hums."*
> ► **"Is she cross?"** — **KASAMARO:** *"I broke a rib on the cherry tree. Last winter."*
> ► **"I'll help you look."** — **KASAMARO:** *"Oh. Thank you. Be gentle with my paper."*

**Scene 2: the search.** Yoshiko is easy to find once the player asks the right question: a small, silver-haired woman in a house at the foot of the long stair, in a chair by the window, unable to climb the lane to market. She has not been out in a year.

**YOSHIKO:** "My umbrella? It's in the stand. I haven't had the heart to take it to the shrine to be mended."
**YOSHIKO:** "I thought it was *tired.*"
**YOSHIKO:** "Surely it's not *wandering?*"
> ► **"It's looking for you."** — **YOSHIKO:** "Oh, you *poor* thing."
> ► **"It misses the rain."** — **YOSHIKO:** "So do I."
> ► **"It wants to walk with you."** — **YOSHIKO:** "I can't walk to the corner."

**Scene 3: the rain.** On a grey, drizzling evening, the player carries Yoshiko in a litter the neighbours built for the purpose, with Kasamaro held above her head. The rain is a fine, warm, drifting one, the kind she liked. Kasamaro hums with every drop.

**KASAMARO:** *"There. That's the *sound.*"*
**YOSHIKO:** (quietly) "I've missed that."
> ► **(Carry her to the shrine stair.)** — A long, gentle walk.
> ► **(Let her sit under the umbrella in the garden.)** — A short, still one.
> ► **(Take them both to the sea.)** — Salt rain, and a wider sky.

**Scene 4: the mend.** At the shrine, a tsukumogami-mender, a tiny crane-spirit with a brush, repairs the broken rib with a splint of cedar and a hair from Yoshiko's own comb.

**MENDER:** "There. It will outlast you both."
**YOSHIKO:** "That's *rude.*"
**MENDER:** "It's a compliment."
Kasamaro's one eye closes. It sleeps, upright, against her chair.

**Afterword: the bench.** The covered bench the neighbours build is, by general agreement, over-engineered. It has a roof, a rail, a footrest and a small shelf for Kasamaro to sleep on. On the first wet evening Yoshiko sits under it with the umbrella furled at her knee, humming, and a line of children comes by to ask the umbrella what the rain was like in the old days. Kasamaro, deeply flattered, tells them for an hour.

**Outcomes and receipt.**
- Kasamaro is mended and kept. If the player took them to the sea, Yoshiko stays out past dusk for the first time in a year and sleeps well. If the player only sat them in the garden, the umbrella is content and goes quiet.
- **Receipt:** a cedar splint on one paper rib; the neighbours build a covered bench by Yoshiko's door, so that she can sit out in any weather.

<!-- quest
id: qst_kit_umbrella
title: The Umbrella That Waited
rank: C
type: Hidden
giver: npc_kasamaro
region: reg_kitsune_isles
level: 66
act: 3
requires_rank: C
reward: 4100 | 225 | 15500
sets: kit_umbrella_done
summary: A one-eyed paper umbrella that woke when its owner stopped going out in the rain is hopping from inn to inn, looking for her.
objectives:
  talk npc_kasamaro
  reach kitsune_yoshiko_house
  choice shrine_garden_or_sea
-->

---

## 4. The Inn That Began to Eat

*B · Investigation · a spirit inn · giver Innkeeper Ohane Matsukage*

**The short version.** A careless guest broke a house rule: he removed the inn's lamp from its post to read by. By the inn's own contract, the inn is now entitled to consume him. It has begun, slowly, from the feet. The guest is not a villain. The innkeeper is not a monster. The inn is simply keeping its word.

**What is really going on.** Spirit-inn contracts are law, and the law has no mercy clause because no one ever thought to write one. The innkeeper cannot revoke the rule; the guest cannot unsign it. But a contract is also a *promise,* and promises can be witnessed again, by a fox, with new terms, if both parties will speak. The inn's pride is the obstacle.

**Scene 1: the parlour.**

**OHANE:** "I have never lost face at my own threshold. Until tonight."
**OHANE:** "Rule four: *the lamp is not to leave its post.* He took it to the garden."
**OHANE:** "The house has begun to... *claim* him. I cannot stop it. I am ashamed."
> ► **"Where is he?"** — **OHANE:** "In the Plum Room. Trying not to look at his feet."
> ► **"Can't you stop the house?"** — **OHANE:** "The house keeps its word. That is why it is a house."
> ► **"I'll look at the contract."** — **OHANE:** "Please. It is in the lacquer box."

**Scene 2: the guest.** In the Plum Room, a thin, polite man named Dai sits on a mat, his ankles faintly translucent, like paper in water. He is courteous even now.

**DAI:** "I wanted to read a letter. The lamp was the only good light."
**DAI:** "I did not read the rules. I thought it was a *form.*"
**DAI:** "Is the house angry?"
> ► **"It's keeping its word."** — **DAI:** "Then I understand."
> ► **"We'll find a way."** — **DAI:** "Please do. I have a mother."
> ► **"Why were you reading?"** — **DAI:** "A letter from her."

**Scene 3: the contract.** The player reads the lacquered contract. There are eleven rules, none of them cruel on its face. Rule four carries the penalty, in a careful hand: *"the lamp is not to leave its post, on pain of the guest becoming the house's."* Nothing prohibits a second contract.

**JOURNAL (auto):** *A new promise, witnessed by a fox, may amend a house rule if both sides agree.*
> ► **"Offer a lamp of your own."** — The innkeeper ponders.
> ► **"Let him serve a season as the inn's lamp-bearer."** — The innkeeper's eyes widen.
> ► **"Dispute the rule's wording."** — A tricky, legal path.

**Scene 4: the amendment.** A fox is fetched. Dai and Ohane speak across the tatami. The new clause, written by the player and witnessed by the old fox: *"The guest shall tend the lamp for a season, in place of his debt."* A drop of blood, a grain of rice. The translucence fades from Dai's ankles.

**OHANE:** (stiffly) "I admit that the solution is... elegant."
**DAI:** "May I read my letter now?"
**OHANE:** "In the *garden.* By the *post.*"

**Afterword: the twelfth rule.** Weeks later the player returns to find the lacquer box open on Ohane's desk and a new line written in a firm hand beneath rule eleven: *"A guest in error may be offered a season of service in place of forfeit."* Ohane, formal as ever, does not mention that two other inns have copied it out. "Contracts should be strict," she says. "They should not be *stupid.* It took a stranger to remind me."

**Outcomes and receipt.**
- The inn's claim is lifted. If the player argued the wording, Ohane accepts the new clause but loses face with the other inns. If the player proposed the lamp-bearer, Dai serves, and the inn is glad of him.
- **Receipt:** a twelfth rule on the lacquered contract; a small lamp by the post that Dai relights each dusk.

<!-- quest
id: qst_kit_inn_eat
title: The Inn That Began to Eat
rank: B
type: Investigation
giver: npc_ohane_matsukage
region: reg_kitsune_isles
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: kit_inn_done
summary: A guest broke a house rule at a spirit inn, and the inn is keeping its contract by consuming him. The rule has no mercy clause.
objectives:
  talk npc_ohane_matsukage
  reach kitsune_plum_room
  choice lamp_season_or_dispute
-->

---

## 5. The Lamp at the Door

*B · Faction · the spirit inns · giver Dusk-Lamp Warden Rinji Hotaru*

**The short version.** At dusk the spirit inns close their doors, and Rinji lights a lamp at each threshold so that no traveller is stranded in the dark. Half the isles want the lamps put out, so that nothing is *invited* to the doors. The other half want them brighter. Rinji wants the player to decide, or at least to help her listen.

**What is really going on.** The inns are afraid of what walks the cliffs after dusk, and no one on the isles agrees on how to answer. This quest does not answer it. It is about *neighbours:* how an archipelago of polite, precise people argues when frightened, and what a lamp means to someone locked out. **The Hollow Bride is not named and is not addressed.**

**Scene 1: the first lamp.**

**RINJI:** "I light forty-one lamps a night. Forty-one doors. They close behind them."
**RINJI:** "Half the isles say: put the lamps out. A light invites. The other half say: put them out and we are *alone.*"
**RINJI:** "I'd like someone who is neither island nor inn to go door to door. And *listen.*"
> ► **"What's the risk?"** — **RINJI:** "The lamps are all I have."
> ► **"Who's loudest?"** — **RINJI:** "The Pine Inn. And the Crane."
> ► **"I'll go."** — **RINJI:** "Take the long lantern. Don't open any door after dusk."

**Scene 2: the doors.** Over three evenings, the player visits inns. At the Pine Inn, a stern old spirit wants the lamps dark. At the Crane, a fox-widow wants them doubled, for her sister's sake, out walking late on the far shore. At a small tea-stall, a tanuki bows low and says only that he'd like the lamp to be *warm.*

**PINE-KEEPER:** "A light is an invitation."
**CRANE-WIDOW:** "A dark is an *abandonment.*"
**TANUKI:** "Could it be warm? That's all. Warm."
> ► **"Dim them, don't douse them."** — The Pine-keeper considers.
> ► **"Light every door, everywhere."** — The Crane approves.
> ► **"Ask what each door wants."** — Slow, and strange.

**Scene 3: the meeting.** In the great room of the Ninth Tail Teahouse, forty innkeepers sit in a ring, each with a lamp at their knee. Rinji stands in the middle, a small figure with a long hook.

**RINJI:** "I light the lamps. I'll light whatever you decide. I'd like it decided *kindly.*"
A long silence, in which forty lamps flicker. The player is asked to speak.
> ► **"A dim lamp at every door. Warm, low, steady."** — A compromise, with grumbling.
> ► **"Let each inn choose, and tell its neighbours."** — A loose peace.
> ► **"Put them all out, and sit up together."** — A bold, risky vote.

**Scene 4: the vote.** The innkeepers' vote is a show of lamps held high. The result is close. Rinji counts, carefully.

**RINJI:** "...Thirty-one to nine."
**RINJI:** "Thank you for not telling them what to want."

**Afterword: the long hook.** Rinji hangs her lighting-hook in the Teahouse beside the old clan banners and, to the player's surprise, sits on the floor beneath it and cries a little, quickly and without fuss. "Forty-one doors," she says. "I thought I was lighting them alone." She asks if the player will visit one lamp at dusk, any lamp, and watch it burn for an hour. The player can, or can simply say that it burns well. Either answer is enough.

**Outcomes and receipt.**
- The isles agree to the player's proposal. If the dim-warm lamp was chosen, the isles are at ease but not safer. If the choice was left to each inn, three inns burn bright and two go dark, and Rinji visits all five.
- **Receipt:** a warm, low lamp at every spirit-inn door at dusk; Rinji's long hook, hung in the Teahouse, labelled *With thanks.*
- **Canon-safe:** this quest does not explain what walks the cliffs.

<!-- quest
id: qst_kit_dusk_lamp
title: The Lamp at the Door
rank: B
type: Faction
giver: npc_rinji_hotaru
region: reg_kitsune_isles
level: 94
act: 4
requires_rank: B
reward: 11000 | 640 | 47000
sets: kit_lamp_done
summary: The inns close at dusk and the isles are split over whether the door-lamps should shine brighter or be put out.
objectives:
  talk npc_rinji_hotaru
  reach kitsune_teahouse_great_room
  choice dim_each_or_dark
-->

---

## 6. A Wedding in the Sun-Shower

*B · Escort · between the isles · giver Procession-Master Sakae Midorikawa*

**The short version.** A kitsune groom and a human bride are to be married in the old fox-wedding style: a procession through a sun-shower, from Fox Shrine Isle across the straits. The sun-shower is due on the third day. The bride's aunt has said she will not attend. The procession must not be late for the rain.

**What is really going on.** The procession is easy; the aunt is the problem. She is a respected shrine-keeper who believes human-kitsune marriages bring luck to the family only if the human side keeps its customs. The groom's family keep theirs. The bride, Yuna, wants both. The player escorts the whole procession, and must keep the aunt, a basket of rice, a litter and a very anxious groom all arriving at the same time.

**Scene 1: the shrine.**

**SAKAE:** "Fifty years. I've never been late for the rain."
**SAKAE:** "The bride's aunt won't come. The groom's father is sulking. The rice is damp."
**SAKAE:** "I need someone who can walk and *mediate.*"
> ► **"What's a sun-shower?"** — **SAKAE:** "Rain from a clear sky. It means the foxes approve."
> ► **"What do you need?"** — **SAKAE:** "A path. A basket. An aunt."
> ► **"I'll escort them."** — **SAKAE:** "You'll be paid in cake."

**Scene 2: the aunt.** The aunt, Reiko, a tall, immovable woman in a grey kimono, receives the player in a plain room.

**REIKO:** "A fox wedding is a courtesy to *foxes.* Where is the courtesy to my side?"
**REIKO:** "My niece will be wed in a way I do not know."
> ► **"Come as you are."** — **REIKO:** "That is not an answer."
> ► **"Bring one custom of your own."** — **REIKO:** "...What custom?"
> ► **"She wants you there."** — **REIKO:** "She has not said so."

**Scene 3: the procession.** On the third morning, with the light high and thin, the procession sets out: groom in white and gold, bride in a plain veil, a dozen bearers, a drummer, and one reluctant aunt carrying a small lacquered box of her own mother's salt. The route winds through pine, across a shingle spit and over a rope bridge slung between two islands. Halfway, the sky, which was clear, rains.

**GROOM:** "It's *starting.*"
**SAKAE:** "Don't stop!"
**BEARER:** "The bridge is slippery."
> ► **(Keep the line moving.)** — A steady push.
> ► **(Carry the bride across.)** — Gallant, and risky.
> ► **(Let the aunt lead.)** — She does, with a firmness that steadies everyone.

**Scene 4: the arrival.** They arrive at the far shrine in the thinning sun-shower, damp and radiant. Reiko steps forward and sets her box of salt on the altar beside the rice.

**REIKO:** "For the house. From my side."
The bride, weeping, bows. The groom's father, who has been sulking all week, bows back. Sakae, soaked, turns away to hide a tear.

**SAKAE:** "Not late for the rain."
**SAKAE:** "Not *once.*"

**Afterword: the salt.** Late that night Reiko and Sakae sit on the shrine step sharing a flask, two old women with very little left to prove. Reiko mutters that the procession was disorganised, the rice was wet and the rain arrived four minutes late. Sakae pours another cup and says that, in fifty years, it was the first wedding where the family had argued the whole way and still arrived together. "That," she says, "is how you know it will last."

**Outcomes and receipt.**
- The wedding is held. If the player asked Reiko to bring a custom, both sides are visibly reconciled; if the player only told her to come, she attends coolly and mellows slowly.
- **Receipt:** a small box of salt on the shrine altar beside the rice; the couple's first child is born with one fox-ear and one human, and no one minds.

<!-- quest
id: qst_kit_sun_shower
title: A Wedding in the Sun-Shower
rank: B
type: Escort
giver: npc_sakae_midorikawa
region: reg_kitsune_isles
level: 98
act: 4
requires_rank: B
reward: 11800 | 680 | 49500
sets: kit_wedding_done
summary: A fox-wedding procession must cross the straits in the sun-shower, with a stubborn aunt, a damp basket of rice and an anxious groom.
objectives:
  talk npc_sakae_midorikawa
  escort npc_sakae_midorikawa
  choice keep_carry_or_aunt
-->

---

## 7. The Nine Gates

*B · Exploration · the Ninefold Shrine · giver Gatekeeper Toma Shirabe*

**The short version.** The Ninefold Shrine has nine gates and nine stairs. At each gate a question is asked of those who climb, not by a person but by the gate. Toma has climbed them eleven thousand times and has never given the same answer twice. This year the gates have begun asking *different* questions.

**What is really going on.** The questions change with the climber. They have always done so, but Toma, who is gentle and unimaginative, never noticed until a pilgrim asked him what he had said at the eighth gate and he could not remember. The gates are listening, patiently. The player's job is to climb, to answer honestly, and to record what the gates ask.

**Scene 1: the foot of the stair.**

**TOMA:** "Nine gates. Nine stairs. Each has a question. I answer. It lets me through."
**TOMA:** "Lately the questions are... *harder.* Or I've grown less clever."
**TOMA:** "Climb with me. Say what you think. The gates can tell."
> ► **"What's the first question?"** — **TOMA:** "'What did you leave at home?' Always."
> ► **"What happens if I lie?"** — **TOMA:** "The stairs get longer."
> ► **"Let's climb."** — **TOMA:** "Mind the third step."

**Scene 2: the first four gates.** The first gate asks what the climber left at home; the player answers. The second asks *whom they carry.* The third asks *what they owe.* The fourth, in a voice like wind in cedar, asks *what they have broken.* Toma replies quickly. The player answers slowly.

**GATE:** (soft, many-voiced) *"What have you broken?"*
> ► **"A promise."** — The stairs lengthen, a little, then settle.
> ► **"Nothing I can name."** — The gate waits.
> ► **"A friend's trust."** — A wind passes, warm.

**Scene 3: the next four.** The fifth gate asks *whom you forgave.* The sixth, *who forgave you.* The seventh, a question that Toma goes pale at: *"What will you not say?"* The eighth is silent, and the player must choose how long to wait. Behind them, an old pilgrim has begun to cry.

**TOMA:** "I never reached the eighth gate this way before."
**TOMA:** "It asked *me* something."
> ► **"What did it ask you?"** — **TOMA:** "'*Who do you serve?*'"
> ► **"You don't have to say."** — **TOMA:** "Thank you."
> ► **"Wait with the gate."** — A long, kind silence.

**Scene 4: the ninth gate.** At the top, in a courtyard open to the sky, a small gate of unpainted wood. It asks only one thing, in a child's voice.

**GATE:** *"Are you ready to come in?"*
> ► **"Yes."** — The gate opens on a plain room with a lantern.
> ► **"Not yet."** — The gate nods; the way down is easy.
> ► **"What is inside?"** — **TOMA:** "Nobody knows. That's why it asks."

**Afterword: the list.** Toma copies the nine questions into a small book with a plain cover and gives it to the player. He says he will not use it: the gates ask each person differently, and writing the questions down is, he supposes, a kind of rudeness. But he wants one copy to exist somewhere, in case he forgets, as the old pilgrim did. On the first page, below the title, he has written in small neat characters: *Answer as you would to a friend.*

**Outcomes and receipt.**
- The climb is recorded. If the player said yes, they see a lantern in an empty room; nothing more. If not yet, the gate lets them down gently and remembers.
- **Receipt:** a list of nine questions in Toma's neat hand, shared with every pilgrim; the player's answers are kept by the gates, not by Toma.

<!-- quest
id: qst_kit_nine_gates
title: The Nine Gates
rank: B
type: Exploration
giver: npc_toma_shirabe
region: reg_kitsune_isles
level: 104
act: 4
requires_rank: B
reward: 13000 | 760 | 56000
sets: kit_gates_done
summary: The nine gates of the Ninefold Shrine have begun asking harder questions, and a gatekeeper who has climbed them eleven thousand times wants company.
objectives:
  talk npc_toma_shirabe
  reach kitsune_ninth_gate
  choice yes_not_yet_or_ask
-->

---

## 8. Leaf Money

*A · OddJob · Fox Shrine Isle market · giver Gonbei Tanukida*

**The short version.** A tanuki merchant pays his debts in leaves that turn to coin at noon. A pearl-diver has taken him to the shrine court because her coins turned back to leaves at *dusk.* Gonbei swears he never meant it. The court says: prove it. The trade of the whole isle hangs on the verdict.

**What is really going on.** Tanuki magic is a joke that holds: a leaf holds coin-shape for a day, then forgets. Gonbei always paid and always meant to; the problem is that nobody had told him *day* meant *twelve hours.* The pearl-diver, Ayame, is not cruel, only broke, and her whole family's winter was in those coins.

**Scene 1: the court.**

**GONBEI:** "I'm a *merchant.* I pay my debts. I *always* pay."
**GONBEI:** "They were *very good leaves.*"
**GONBEI:** "Ayame says they turned back at dusk. I've been paying that way for forty years, and nobody *minded.*"
> ► **"Did you tell her?"** — **GONBEI:** "I... assumed."
> ► **"Do you have gold?"** — **GONBEI:** "I have *credit.*"
> ► **"I'll speak for you."** — **GONBEI:** "Oh, bless you."

**Scene 2: the diver.** Ayame is a weathered woman with salt in her hair and a child at her skirt. She sits straight and tight-lipped on the court's bench.

**AYAME:** "I sold him twelve pearls. I got twelve leaves. I paid my rent in the coins. By dusk the landlord was holding a handful of foliage."
**AYAME:** "I don't want to ruin him. I want my pearls paid."
> ► **"What do you need?"** — **AYAME:** "A winter."
> ► **"He didn't know."** — **AYAME:** "He's forty years in trade."
> ► **"I'll cover the gap."** — **AYAME:** "No charity."

**Scene 3: the plea.** The judge, an old fox-witness with a long white brush, hears both. The player argues. The court is a mix of wonder, bluster and one very loud tanuki who weeps theatrically.

**JUDGE:** "A debt is a promise. A false coin is a broken one. But a tanuki's leaf is a *custom.*"
**JUDGE:** "Is there precedent?"
> ► **"A written notice at the market gate."** — The judge nods.
> ► **"Gonbei pays in gold for three months."** — A heavy penalty.
> ► **"Gonbei teaches the diver tanuki-craft."** — A strange, generous idea.

**Scene 4: the verdict.** The judge rules: Gonbei pays Ayame in real silver, and a sign goes up at the market gate: *Tanuki leaves expire at dusk. Ask.* In return, Ayame takes on an apprentice, a small tanuki child, to learn to dive.

**GONBEI:** (blowing his nose) "A child. *Of mine.*"
**AYAME:** "A cousin's."
**GONBEI:** "A child of the *trade.*"

**Afterword: the pearl.** Ayame's first lesson to her tanuki apprentice is how to hold her breath, and the second is how to count coins in the open air, in daylight, twice. Gonbei, hovering at the market gate, is observed counting his own leaf-money with his lips moving. A week later the sign is joined by a smaller one in the child's careful hand: *Honest leaves, honest weights, honest dives.* Nobody can remember who ordered it. Gonbei, asked, denies everything, and is later seen polishing the sign.

**Outcomes and receipt.**
- The case is settled. If the player proposed tanuki-craft, Ayame learns to spot a leaf at a glance; if gold, Gonbei pays with a heavy heart but a clean name.
- **Receipt:** a wooden sign at the market gate; a pearl on Gonbei's desk that he will not sell.

<!-- quest
id: qst_kit_leaf_money
title: Leaf Money
rank: A
type: OddJob
giver: npc_gonbei_tanukida
region: reg_kitsune_isles
level: 122
act: 5
requires_rank: A
reward: 28000 | 1400 | 125000
sets: kit_leaf_done
summary: A tanuki merchant pays in leaves that turn to coin at noon, and a pearl-diver has taken him to court because hers turned back at dusk.
objectives:
  talk npc_gonbei_tanukida
  reach kitsune_shrine_court
  choice notice_gold_or_craft
-->

---

## 9. What the Tide Remembers

*A · Hidden · the Sunken Isle · giver Haruto Umikage*

**The short version.** Haruto's grandfather broke a promise to a fox-wife, and an island sank. Haruto has never made a promise he was not sure he could keep. He wants to go to the Sunken Isle's shrine at low tide and say, aloud, that his family is sorry. He is terrified that it will not matter.

**What is really going on.** *Nothing is fully explained.* The island is sunken; the fox-wife has not forgiven, and has not refused. At the shrine, the sea, the stones and a faint, patient presence answer in small ways. The quest does not say who the fox-wife was, what the promise was, or what would end the sinking. It ends on a gesture.

**Scene 1: the pier.**

**HARUTO:** "My grandfather was a good man who made one bad promise."
**HARUTO:** "The island went under in a night. Eleven houses."
**HARUTO:** "I've never said sorry. I wasn't sure I had the right."
> ► **"What did he promise?"** — **HARUTO:** "No one wrote it down. That's the worst part."
> ► **"Will it listen?"** — **HARUTO:** "I don't know."
> ► **"I'll go with you."** — **HARUTO:** "Thank you. Don't speak for me."

**Scene 2: the low tide.** The two cross the sand at the new moon's low water. The shrine stands, furred with weed. The sea draws back farther than it should, a long grey beach shining under the sky.

**HARUTO:** "There's a step. On the step is a cup."
**HARUTO:** "Someone from the Teahouse, always."
> ► **(Stand beside him.)** — Quiet company.
> ► **(Wait at the shore.)** — A respectful distance.
> ► **(Pour the tea he brought.)** — A small gesture.

**Scene 3: the apology.** On the black step, Haruto kneels and speaks. The apology is plain: *"My family broke a promise. We are sorry. We have not forgotten. We do not ask to be forgiven."*

*Nothing happens. The wind drops. A thin line of water draws back from the step and, for one breath, a pair of small, wet footprints, fox-shaped, appear on the stone and fade.*
> ► **"She heard you."** — **HARUTO:** "Did she?"
> ► **"We should go."** — **HARUTO:** "Not yet."
> ► **"Say it again."** — **HARUTO:** "No. Once is enough."

**Scene 4: the shore.** The tide returns. The two walk back in silence. On the pier, Haruto sits, takes a long breath, and, for the first time in the player's company, laughs.

**HARUTO:** "I made a promise, you know. Just now. I told it I'd come every year."
**HARUTO:** "I think I can keep that one."

**Afterword: the footprints.** On the pier Haruto asks the player to sit with him a moment longer. He says his grandfather never told his father what the promise was, and his father never asked, and so the family has spent two generations apologising for something none of them could name. "It is a strange thing to be sorry for a silence," he says. "But I think the silence heard me." He does not ask the player to agree. The player does not have to.

**Outcomes and receipt.**
- The apology is spoken. If the player stood beside him, the footprints are seen by both; if they waited at the shore, only Haruto sees them. No further answer is given.
- **Receipt:** a cup of tea, still warm, on the step the next new moon; Haruto's name entered, in his own hand, in the Teahouse ledger of visitors.
- **Canon-safe:** this is a seed. It does not say who the fox-wife was, what the promise was, or whether the island will rise. It answers no open question, and it is **not** connected to the Hollow Bride or the Suzune arc.

<!-- quest
id: qst_kit_tide_remembers
title: What the Tide Remembers
rank: A
type: Hidden
giver: npc_haruto_umikage
region: reg_kitsune_isles
level: 128
act: 5
requires_rank: A
reward: 29500 | 1480 | 130000
sets: kit_tide_done
summary: A fisherman whose ancestor broke the promise that sank an island wants to apologise at the Sunken Isle's shrine at low tide.
objectives:
  talk npc_haruto_umikage
  reach kitsune_sunken_isle_step
  choice beside_shore_or_tea
-->

---

## 10. Lantern Night

*A · Defense · Fox Shrine Isle · giver Festival-Marshal Chiyo Akatsuki*

**The short version.** Once a year, the isles hang ten thousand paper lanterns and float them out to sea, and the dead are said to read the wishes. This year, the lanterns have woken. Old festival lanterns, stored in the shrine loft for decades, are floating off on their own, bumping into the crowd, and trying to *speak.* Chiyo has one night.

**What is really going on.** The lanterns are tsukumogami, a whole attic of them. They are not hostile; they are loud and lonely, and the crowd is frightened. The "defense" is of the festival itself, and of the crowd and the lanterns from each other. **No Hollow Bride, no siege.**

**Scene 1: the marshal's tent.**

**CHIYO:** "Thirty years, no incident. This year, the old stock *woke up.*"
**CHIYO:** "They want to join in. They keep saying so, at the top of their voices."
**CHIYO:** "Keep the crowd calm. Keep the lanterns from bumping. Keep *me* from crying."
> ► **"What do they want?"** — **CHIYO:** "To be lit."
> ► **"Is anyone hurt?"** — **CHIYO:** "A bruised shin. And my dignity."
> ► **"I'll hold the shore."** — **CHIYO:** "Mind the little ones."

**Scene 2: the shore.** *(Gameplay: crowd-and-lantern defense; the player intercepts lantern clusters, steers them to the water, and shields children, without tearing any lanterns.)* Ten thousand lanterns glow along the strand. A dozen of the old ones hop and bounce, calling out in thin voices.

**LANTERN:** *"Light me! Light me! I have waited forty years!"*
**CHILD:** "It's *talking* to me."
**LANTERN:** *"Make a wish for me!"*
> ► **"Light the old lanterns first."** — A shining line.
> ► **"Keep the children away."** — Safe, but sad.
> ► **"Let the children make a wish for each."** — Chaos, and joy.

**Scene 3: the surge.** At midnight, a gust blows the whole fleet of lanterns toward a pine grove. The old lanterns, frantic, rush ahead of it, flame-dim and shouting. The crowd scatters.

**CHIYO:** "To the water! Get them *to the water!*"
> ► **(Steer them with a net of rope.)** — Careful hands.
> ► **(Light a bonfire as a guide.)** — A gamble.
> ► **(Ask the lanterns to follow you.)** — They do, in a wobbling line.

**Scene 4: the sea.** The old lanterns drift out last, bobbing in the dark, each carrying a child's wish. One by one, they glow, then go out. The crowd stands in a long, hushed line.

**LANTERN:** *"Thank you. Thank you. It was a lovely night."*
**CHIYO:** (wiping her eyes) "Thirty years. Never lost a lantern. I think I've just lost the last of the old stock."
**CHIYO:** "And I've never been so proud."

**Afterword: the loft.** Long after the crowd has gone home, Chiyo climbs the shrine loft stairs with a lamp and finds the remaining old lanterns lying in a neat row, dark and content. She lays the unlit one at the end and covers the rest with a quilt, as one does for sleeping children. "Next year," she tells them, "you can all come out." From somewhere in the dark, a thin voice mutters that it will hold her to that.

**Outcomes and receipt.**
- The festival goes on. If the player had the children make wishes, the lanterns go gladly; if they tore any, the sea is dark for a minute. Chiyo keeps the order of the night.
- **Receipt:** a single old lantern, unlit, kept in the shrine loft with a note: *For next year;* the crowd sings the lanterns' goodbye song.

<!-- quest
id: qst_kit_lantern_night
title: Lantern Night
rank: A
type: Defense
giver: npc_chiyo_akatsuki
region: reg_kitsune_isles
level: 132
act: 5
requires_rank: A
reward: 32000 | 1600 | 140000
sets: kit_lantern_done
summary: The old festival lanterns in the shrine loft have woken and are loose on Lantern Night. The marshal wants them to the sea unharmed.
objectives:
  talk npc_chiyo_akatsuki
  defend kitsune_lantern_shore
  choice light_guard_or_wishes
-->
