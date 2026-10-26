# 11e-56 — The Deep Labyrinth, the Drowned Floors (41-90): Ten Side Quests (draft)

> *"Parties that never came back left chalk marks behind them. Some of the marks point to rooms that no longer exist."*
> — Gazetteer, Great Labyrinth (Floors 41-90)

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 3, 8 and 10 plant unexplained seeds.

**Region:** `reg_labyrinth_deep` (floors 41 to 90: the sunken city on floors 55-58, the inverted forest on 66, the upside-down library on 72, the raid camps, the Gnome Walls, the floor-90 stair). **Rank band:** B–S. **Tone:** cold, damp, lantern-lit; solidarity between strangers; quiet courage rather than glory.

**Placement notes.**
- **No Tyrant, no siege.** This is a dungeon band. **No quest touches the Maze King or the killer on floor 39** (they sit in other bands), and no quest fights a floor guardian; the tenth-floor guardians are mentioned only as a distant threat.
- Customs the quests rely on: **raid councils** of several parties, with oaths recorded at the guild; **a lantern per council, and if it goes out the raid turns back;** adventurers **stop praying to Vex below floor sixty;** the **deep gnomes** trade mana crystals and maps for surface food and news and never haggle; **a community of adventurers who stayed too long** lives in the sunken city.
- **Rank note.** Quests 1 to 3 are rank B, 4 to 7 rank A, 8 to 10 rank S (levels 166-176). S rewards are extrapolated from `Data/World/guild_ranks.json` and are first-pass.
- **Not repeated here:** the Upper Labyrinth's Reset Hour (file 33). Nothing here depends on it.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Door That Wandered | B | Hidden | Burl Wallknock | A gnome's missing door |
| 2 | News for the Gnome Walls | B | Delivery | Quillow Deepbarrow | Surface news, honestly told |
| 3 | Chalk to Nowhere | B | Investigation | Clerk Sorrel Dunmarch | Marks that point to missing rooms |
| 4 | The Oath of the Third Share | A | Faction | Council-Keeper Corwin Verrow | A broken oath, a hungry party |
| 5 | The Ones Who Stayed | A | Escort | Tobin Reedwater | A young adventurer wants home |
| 6 | Read in the Right Direction | A | Investigation | Scholar Emmerich Vaneholt | A book from the upside-down library |
| 7 | When the Lantern Goes Out | A | Hidden | Lantern-Bearer Alder Oilwright | A turn-back that cost a life |
| 8 | The Lantern at the Stair | S | Exploration | Raid-Captain Ione Carrowby | What the council left on floor 90 |
| 9 | Nests That Hang Down | S | Escort | Naturalist Pomeroy Featherstone | Birds that fly upside down |
| 10 | The City Changed Its Streets | S | Investigation | Cartographer Rosamund Wetherby | A mapper's daughter |

## Cast

<!-- npc
id: npc_burl_wallknock
name: Burl Wallknock
tier: major
race: Gnome
region: reg_labyrinth_deep
settlement: The Gnome Walls
role: Deep gnome who lost a door
backstory: A blunt, soft-handed deep gnome who has guided his family's tunnels for sixty years and has just found that one of their doors is no longer in its wall.
-->
<!-- npc
id: npc_quillow_deepbarrow
name: Quillow Deepbarrow
tier: major
race: Gnome
region: reg_labyrinth_deep
settlement: The Gnome Walls
role: Deep gnome trader
backstory: A courteous deep gnome trader who never haggles and who has asked, this season, for news of one particular surface family.
-->
<!-- npc
id: npc_sorrel_dunmarch
name: Clerk Sorrel Dunmarch
tier: townsfolk
race: Human
region: reg_labyrinth_deep
settlement: Raid camp, floor 52
role: Clerk of a raid council
backstory: A methodical clerk who records every raid council's chalk marks and has noticed that fourteen of them lead to rooms that are not on any map.
-->
<!-- npc
id: npc_corwin_verrow
name: Council-Keeper Corwin Verrow
tier: major
race: Human
region: reg_labyrinth_deep
settlement: Raid camp, floor 52
role: Keeper of a raid council's oath
backstory: A stiff, honest oath-keeper who has watched one party break the third-share rule and has a council that wants blood.
-->
<!-- npc
id: npc_tobin_reedwater
name: Tobin Reedwater
tier: townsfolk
race: Human
region: reg_labyrinth_deep
settlement: The Sunken City
role: Young adventurer who stayed too long
backstory: A twenty-year-old who came down at sixteen for a single season, stayed for four years, and has begun to dream of a sky he can no longer remember.
-->
<!-- npc
id: npc_marit_pellwater
name: Marit Pellwater
tier: major
race: Human
region: reg_labyrinth_deep
settlement: The Sunken City
role: Elder of the adventurers who stayed
backstory: A grey, strong-handed woman who has lived in the Sunken City for twenty-two years and does not intend to leave or to stop anyone else from leaving.
-->
<!-- npc
id: npc_emmerich_vaneholt
name: Scholar Emmerich Vaneholt
tier: major
race: Human
region: reg_labyrinth_deep
settlement: Raid camp, floor 71
role: Scholar who wants a book read right way up
backstory: A bookish, anxious scholar who has paid for three expeditions to the upside-down library and wants the title of one particular book.
-->
<!-- npc
id: npc_alder_oilwright
name: Lantern-Bearer Alder Oilwright
tier: townsfolk
race: Human
region: reg_labyrinth_deep
settlement: Raid camp, floor 60
role: Lantern-bearer of a raid council
backstory: A freckled eighteen-year-old who carried the council's lantern the night it went out, and whose council turned back at the last stair.
-->
<!-- npc
id: npc_ione_carrowby
name: Raid-Captain Ione Carrowby
tier: major
race: Human
region: reg_labyrinth_deep
settlement: Raid camp, floor 84
role: Survivor of the floor-ninety raid
backstory: A lean captain who led half a council to floor ninety and brought half of it home, and who left a lit lantern at the stair.
-->
<!-- npc
id: npc_pomeroy_featherstone
name: Naturalist Pomeroy Featherstone
tier: major
race: Halfling
region: reg_labyrinth_deep
settlement: The Inverted Forest
role: Naturalist of the inverted forest
backstory: A round, enthusiastic halfling who has counted the upside-down birds of floor sixty-six for six years and wants a nest measured before the season ends.
-->
<!-- npc
id: npc_rosamund_wetherby
name: Cartographer Rosamund Wetherby
tier: major
race: Human
region: reg_labyrinth_deep
settlement: The Sunken City
role: Cartographer, daughter of the first mapper
backstory: A sharp, patient cartographer whose father drew the whole Sunken City and whose city, the week after, changed its streets.
-->

---

## 1. The Door That Wandered

*B · Hidden · the Gnome Walls, floor 48 · giver Burl Wallknock*

**The short version.** A deep gnome's family door is gone from its wall. Burl wants it found, and does not want to say who last used it.

**What is really going on.** Gnome Walls doors are not hinged; they are *agreed.* Burl's family door left its wall because the last person to use it, his late sister, never came home through it, and the door has gone looking for her. It is, in its way, grieving.

**Scene 1: the wall.** A smooth stone face in a cold passage, with a rectangular patch of paler stone.

**BURL:** "Sixty years that door was here. My mother's door. Her mother's."
**BURL:** "I went to the wall this morning. It was wall."
**BURL:** "I do not know how to ask a surface person for help. I ask anyway. Please."
> ► **"When did it vanish?"** — **BURL:** "Three nights ago. I felt it go, like a tooth."
> ► **"Who used it last?"** — **BURL:** (a pause) "My sister. Ottoline. Four years ago."
> ► **"Where might it be?"** — **BURL:** "Where it was *needed.* I cannot say more."

**Scene 2: the search.** The player follows chalk-dust and a faint, sweet smell of old mortar through three floors of cold tunnel. In a dead-end gallery on floor fifty, a small wooden door stands alone in the open air, half-open, its hinges nowhere.

**DOOR (not a voice; a feeling like a held breath):** *...waiting...*
*Through the gap the player sees only more gallery. But the dust on the sill is disturbed, as if someone has been sitting there.*
**BURL (arriving, out of breath):** "It came to the place where she died."

**Scene 3: the asking.** Burl stands before his family's door.

**BURL:** "Ottoline died here. A fall. We never found a body. I did not know."
**BURL:** "I think the door wanted to stay with her. I think it would not come home without her."
> ► **"Carry it home."** — Burl lifts the frame. It is surprisingly light.
> ► **"Leave it where she died."** — **BURL:** "...Then I must build another door."
> ► **"Knock on it."** — The player knocks. From within comes a single, soft answering knock.

**Scene 4: the settling.** Burl lays his palm flat against the wood.

**BURL:** "Sister. It is time. Come home with the door."
*The air is very still. Then the door swings once, gently, on hinges that are not there.*
**BURL:** "She heard me."

**Scene 3b: the sister's chair.** In the gallery the player finds, beside the door, a small folding stool and a tin cup, coated in dust.

**BURL:** "Hers. She sat here to wait for the shift change. She always waited a little longer than she needed."
**BURL:** "She liked a door that was still open. She said it meant someone might yet come through."
**BURL:** "I scolded her for it. I said doors are for going through, not for sitting beside."
*He wipes the cup with his sleeve, slowly, as if she might want it again.*
**BURL:** "I think the door was only doing what she taught it."
> ► **"Sit with it a while."** — He lowers himself onto the stool, and does not speak for a long time.

**Outcomes and receipt.**
- Carry: the door returns to the family wall and the paler patch fills in. Leave: Burl builds a new door in the wall and leaves the old one with a candle. Knock: the door answers once; Burl decides, with the player, which way to go.
- **Receipt:** a small gnome-made latch, warm to the touch, that never quite closes.

<!-- quest
id: qst_ldp_door_wandered
title: The Door That Wandered
rank: B
type: Hidden
giver: npc_burl_wallknock
region: reg_labyrinth_deep
level: 90
act: 4
requires_rank: B
reward: 11000 | 650 | 46000
sets: ldp_door_wandered_done
summary: A deep gnome family's door has left its wall. It has gone to the place where its last user died.
objectives:
  talk npc_burl_wallknock
  reach labyrinth_floor50_gallery
  choice carry_leave_or_knock
-->

---

## 2. News for the Gnome Walls

*B · Delivery · the Gnome Walls, floor 44 · giver Quillow Deepbarrow*

**The short version.** Quillow trades mana crystals for surface food and news. He has one standing request: news of the Marrow family in a certain surface village. Nobody has ever brought it.

**What is really going on.** The Marrows' eldest daughter, Hettie, was Quillow's friend before she grew old and died. He knows this. He does not want a report; he wants someone to tell it *kindly,* and to carry a bowl of her bread back.

**Scene 1: the stall.** A low trade-table, lit by mushroom-glow.

**QUILLOW:** "I do not haggle. I tell you the price. You tell me yes or no."
**QUILLOW:** "Today I ask for something else. News. The Marrow family. A village called Dunmere, in the north."
**QUILLOW:** "Hettie Marrow. Is she well?"
> ► **"I'll find out."** — **QUILLOW:** "Thank you. I ask nothing for it."
> ► **"How do you know her?"** — **QUILLOW:** "She traded with me when she was a child. She was thirty."
> ► **"What if the news is bad?"** — **QUILLOW:** "Then tell it plainly. I do not like soft lies."

**Scene 2: the surface.** In Dunmere the player finds the Marrows' farmhouse. A young man opens the door.

**MARROW:** "Hettie? That was my great-grandmother. She passed eleven years back."
**MARROW:** "She spoke of a little man in a wall. We thought she was telling stories."
*On the mantel stands a clay bowl, lopsided, in which sits a ring of dried flowers.*
**MARROW:** "She left a bowl of bread to be taken down, if anyone ever came asking. The bread is stale. I baked another yesterday."

**Scene 3: the carrying.** The player brings the news, and a fresh loaf, back down.

**QUILLOW:** (quietly) "She is dead."
**QUILLOW:** "I thought so. Nothing comes up from the north unless it is dead or late."
**QUILLOW:** "Tell me: was it gentle?"
> ► **"It was gentle."** — He nods. "Good."
> ► **"I don't know."** — **QUILLOW:** "Then say you do not know. That is honest."
> ► **"She left you bread."** — Quillow takes the loaf in both hands.

**Scene 4: the table.** He sets the bread on his trade-table, unwrapped, and eats a small piece.

**QUILLOW:** "It tastes of her. It tastes of a girl who was not afraid of walls."
*He does not offer the player any. He slides a mana crystal across the table instead, without a word.*

**Scene 2b: the old kitchen.** Before leaving Dunmere, the young Marrow shows the player the kitchen where Hettie baked, a low room with a crooked oven.

**MARROW:** "She said she traded bread for crystals when she was little. We thought she was dreaming of a fairy tale."
**MARROW:** "She kept a crystal in the window all her life. It glowed on the longest nights."
*On the sill stands a small, dull stone. When the player lifts it, it brightens, as if answering a hand it knows.*
**MARROW:** "Take it down, if you like. I think it has been waiting."
> ► **"I'll take it to Quillow."** — **MARROW:** "Tell him the oven still works."

**Outcomes and receipt.**
- Quillow is told honestly. If the player lied that it was gentle, he suspects but does not say. If the player brings the bread, the Marrows are invited into the Gnome Walls trade as a second family.
- **Receipt:** a small crystal that glows faintly when held near bread.

<!-- quest
id: qst_ldp_gnome_news
title: News for the Gnome Walls
rank: B
type: Delivery
giver: npc_quillow_deepbarrow
region: reg_labyrinth_deep
level: 94
act: 4
requires_rank: B
reward: 11500 | 680 | 48000
sets: ldp_gnome_news_done
summary: A deep gnome trader wants news of a surface family. The news is eleven years late.
objectives:
  talk npc_quillow_deepbarrow
  reach labyrinth_dunmere_farmhouse
  choice gentle_unknown_or_bread
-->

---

## 3. Chalk to Nowhere

*B · Investigation · raid camp, floor 52 · giver Clerk Sorrel Dunmarch*

**The short version.** Fourteen chalk marks point to rooms that are not on any map. Sorrel has checked each one, twice.

**What is really going on.** The rooms are not gone; they are *between.* The deep floors rearrange themselves in the hours when no one is watching, and the marks point to where a room was on the night it was chalked. They are the last record of people who vanished with their rooms. Sorrel does not want the rooms explained. She wants the marks *answered.*

**Scene 1: the ledger.**

**SORREL:** "Every council logs its chalk. Left arrow, right arrow, a circle for safe. I copy them."
**SORREL:** "Fourteen arrows in the last season point at walls."
**SORREL:** "Not at doors. At *walls.* I stood and looked."
> ► **"Could they be old?"** — **SORREL:** "Fresh chalk. Last week."
> ► **"Who drew them?"** — **SORREL:** "Parties that did not log back."
> ► **"I'll follow one."** — **SORREL:** "Take the third. It is the shortest."

**Scene 2: the arrow.** On floor fifty-three, an arrow in white chalk on a bare wall, thick-lined, fresh. Below it, a small circle: *safe.*

**SORREL:** "They said it was safe. Whatever they found, they found it there."
*The player runs a hand across the wall. The stone is warm. Very faintly, from somewhere within it, comes a sound like someone shifting in their sleep.*
**SORREL:** "Do you hear that?"
**SORREL:** "I have heard it fourteen times."

**Scene 3: the answer.** Sorrel produces a fresh stick of chalk.

**SORREL:** "I have never dared to answer. If I draw a mark, I am speaking to something."
**SORREL:** "But I have also never dared *not.*"
> ► **"Draw a circle."** — Sorrel draws it, and the warm stone settles.
> ► **"Draw a question mark."** — The wall is silent. Then the arrow beneath it is slowly, carefully smudged.
> ► **"Leave it alone."** — **SORREL:** "...I think I needed someone to say that."

**Scene 4: the log.**

**SORREL:** "I will log it. *'Arrow, wall, warm. No answer needed.'*"
**SORREL:** "Then I will light a candle for each of the fourteen."
*She does. Fourteen small flames burn on a ledge in the raid camp, and no one disturbs them.*

**Scene 2b: the camp's ledge.** That evening Sorrel shows the player the shelf where she keeps the logbooks of every council that has passed through floor fifty-two, a hundred and six volumes in all.

**SORREL:** "People think the Labyrinth is danger and gold. It is paperwork."
**SORREL:** "Somebody has to write down who went in. Somebody has to write down who did not come out."
**SORREL:** "I have written eleven hundred names in the second column. I know each hand."
*She runs a finger down a page of small, neat entries, and stops at a smudge.*
**SORREL:** "The fourteenth arrow was drawn by a girl who dotted her i's with stars. I recognised it."
> ► **"Add a star."** — Sorrel smiles, thinly, and does.

**Outcomes and receipt.**
- A circle: the marks stop appearing in that corridor for a season. A question: the arrow smudges, then reappears fresh the next morning. Leave: the marks are logged and the fourteen candles remain.
- **Receipt:** Sorrel's ledger page with the fourteen marks and a fifteenth, drawn by the player.
- **Canon-safe:** pure seed. The rooms the marks point to are never found, entered or explained.

<!-- quest
id: qst_ldp_chalk_nowhere
title: Chalk to Nowhere
rank: B
type: Investigation
giver: npc_sorrel_dunmarch
region: reg_labyrinth_deep
level: 98
act: 4
requires_rank: B
reward: 11800 | 700 | 49000
sets: ldp_chalk_nowhere_done
summary: A clerk has logged fourteen chalk arrows that point at bare walls. She wants someone else to look.
objectives:
  talk npc_sorrel_dunmarch
  reach labyrinth_floor53_arrow
  choice circle_question_or_leave
-->

---

## 4. The Oath of the Third Share

*A · Faction · raid camp, floor 52 · giver Council-Keeper Corwin Verrow*

**The short version.** A party broke the council's oath: the third share of any loot goes to the rescue fund. The council wants their licences. The party says they had no choice.

**What is really going on.** The party took a third-share relic to pay for their wounded healer's care and did not report it. It was the same night two of the council's other parties were trapped, and the rescue fund did not cover them. The oath was broken. The oath was also, by that night's arithmetic, *cruel.*

**Scene 1: the council tent.**

**CORWIN:** "I have kept this oath for nineteen years. It has never been broken."
**CORWIN:** "Now it is. Four people stand accused. The council is divided."
**CORWIN:** "I need an outsider who cannot be called biased."
> ► **"What does the oath say?"** — **CORWIN:** "One share in three to the fund. No exceptions."
> ► **"What do the accused say?"** — **CORWIN:** "That they had no choice. That is what all the accused say."
> ► **"I'll listen."** — **CORWIN:** "That is all anyone has asked."

**Scene 2: the party.** The accused sit on a bench: a tall woman, a boy, a grey-bearded archer, a healer lying on a cot.

**PARTY LEADER:** "Our healer was dying. We sold the relic to a deep-gnome surgeon. We told ourselves we would tell the council after."
**PARTY LEADER:** "We did not tell the council. We told ourselves we would."
**HEALER (faintly):** "It's my fault. Put it on me."
**PARTY LEADER:** "Be quiet, Tam."
> ► **"You broke the oath."** — **PARTY LEADER:** "Yes."
> ► **"Why not ask the council?"** — **PARTY LEADER:** "There was no time."
> ► **"The oath has no clause for this."** — **CORWIN:** (slowly) "...No. It does not."

**Scene 3: the hearing.** Twelve council members sit in a ring. The air is like an iron bar.

**COUNCIL MEMBER:** "If one party may break the oath for a good reason, all may."
**CORWIN:** "That is true."
**PARTY LEADER:** "Then strike us. We knew the price."
> ► **"Fine them, not strike them."** — A murmur; some nod.
> ► **"Add a clause for emergencies."** — The council leans in.
> ► **"Uphold the oath exactly."** — A heavy silence.

**Scene 4: the ruling.** The council rules: the party repays the third share within a season, and the oath gains a line: *"...except where a life is lost by the keeping."*

**CORWIN:** "It is not what I wanted. It may be what the oath needed."
**PARTY LEADER:** "Thank you."
**CORWIN:** "Do not thank me. Pay."

**Scene 2b: the healer's cot.** After the hearing is called, Tam, the healer, asks to speak to the player alone, and keeps his voice very low.

**TAM:** "I was dying. Do you know what that is like? It is not dramatic. It is extremely boring."
**TAM:** "They sold the relic, and I woke up, and the first thing I saw was Mira's face."
**TAM:** "I have been trying to be worth it since. I am not sure I am."
*His hand rests on a blanket sewn with small stars.*
**TAM:** "If the council wants blood, let it be mine. They have already paid enough."
> ► **"They would not agree."** — **TAM:** "No. That is what makes them so annoying."

**Outcomes and receipt.**
- A fine, a clause or a strike: the party keeps their licences unless the player upholds the oath exactly. If a clause is added, the oath is the first in the deep band to name an exception.
- **Receipt:** a copy of the amended oath, signed by twelve hands and one smudged thumbprint.

<!-- quest
id: qst_ldp_third_share
title: The Oath of the Third Share
rank: A
type: Faction
giver: npc_corwin_verrow
region: reg_labyrinth_deep
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: ldp_third_share_done
summary: A party broke a raid council's oath to pay for a healer. The council is divided.
objectives:
  talk npc_corwin_verrow
  reach labyrinth_council_tent
  choice fine_clause_or_strike
-->

---

## 5. The Ones Who Stayed

*A · Escort · the Sunken City, floors 55-58 · giver Tobin Reedwater*

**The short version.** Tobin came down for one season and stayed four years. He wants to go home. The community that took him in does not want to be abandoned.

**What is really going on.** Nobody is holding Tobin prisoner. He is afraid of the climb back, afraid of the light, and afraid of hurting the people who fed him. The elder, Marit, would let him go in a heartbeat; she is afraid he will forget the way and come back changed.

**Scene 1: the rooftop.** Tobin sits on a half-drowned roof, feet over a black street.

**TOBIN:** "Four years. I was meant to stay one season."
**TOBIN:** "I dream of green. Only green. I wake and the walls are grey."
**TOBIN:** "If I tell Marit, she will say yes. I think that is the hardest part."
> ► **"Do you want to leave?"** — **TOBIN:** "Yes. And no. Both, at once."
> ► **"Has anyone stopped you?"** — **TOBIN:** "Nobody. They would never."
> ► **"I'll walk you up."** — **TOBIN:** "Thank you. I have forgotten the way."

**Scene 2: Marit.** In the long hall of a drowned guildhouse, Marit stirs a pot.

**MARIT:** "He told you."
**MARIT:** "I have known for a year. The ones who are going always sit on that roof."
**MARIT:** "Take him up. I will pack him bread. He will not take it, and I will pack it anyway."
> ► **"You're not angry?"** — **MARIT:** "I am proud. It is a heavy pride, but it is pride."
> ► **"Will you come too?"** — **MARIT:** "I stopped climbing twenty-two years ago."
> ► **"What do you want him to know?"** — **MARIT:** "That the door is open both ways."

**Scene 3: the climb.** Floor after floor of stair, and a surface lift at the top. On the thirty-first step Tobin sits down, shaking.

**TOBIN:** "I can't. I can't, I can't, I'm sorry."
**TOBIN:** "What if it's too bright? What if nothing there knows me?"
> ► **"Rest here."** — He leans against the stone and breathes.
> ► **"Tell me about green."** — He begins to describe a hillside, and keeps going.
> ► **"I'll carry you."** — **TOBIN:** "No. I have to do it on my feet."

**Scene 4: the stair.** At the top, the guild lift opens on the Labyrinth gate, and beyond it a thin strip of real daylight. Tobin walks into it with both hands up.

**TOBIN:** (hoarse) "It's so *bright.*"
*A pale, dusty sunbeam lies across the floor. He kneels in it.*
**TOBIN:** "Marit packed the bread in my bag. I did not see her do it."

**Scene 2b: the last supper.** On the last night Tobin eats with the whole hall, and the community takes turns telling him small things he should not forget to do on the surface.

**VOICE:** "Smell the grass. Properly. With your whole face."
**VOICE:** "Do not trust the first rain. It is warm and a liar."
**VOICE:** "Tell someone you love that they are loved. Everyone forgets."
*Tobin laughs, then cries, then laughs again, while a child tugs at his sleeve and asks if he will bring back a pebble from the top.*
**MARIT:** "He will bring back a pebble. Hush."
> ► **"I'll bring the pebble."** — The child solemnly shakes the player's hand.

**Outcomes and receipt.**
- Tobin reaches the surface. If the player carried him part way, he forgives himself more slowly; if he walked it alone, he does not forget it. Marit asks only for word that he arrived.
- **Receipt:** a hunk of stale bread, kept in a wrapper, from Marit via Tobin.

<!-- quest
id: qst_ldp_ones_stayed
title: The Ones Who Stayed
rank: A
type: Escort
giver: npc_tobin_reedwater
region: reg_labyrinth_deep
level: 124
act: 4
requires_rank: A
reward: 28000 | 1450 | 126000
sets: ldp_ones_stayed_done
summary: A young adventurer who stayed too long in the Sunken City wants to go home and has forgotten the way.
objectives:
  talk npc_tobin_reedwater
  talk npc_marit_pellwater
  escort npc_tobin_reedwater
  choice rest_green_or_carry
-->

---

## 6. Read in the Right Direction

*A · Investigation · the upside-down library, floor 72 · giver Scholar Emmerich Vaneholt*

**The short version.** A book in the library on floor 72 sits on a ceiling shelf, pages hanging open. Emmerich has read its first page upside down for years.

**What is really going on.** The book is not hard to read. It is hard to *reach.* A fall of the library's gravity at certain hours makes the ceiling the floor, and the shelf, for ten minutes at a time, comes within arm's reach. Emmerich has missed the window three times.

**Scene 1: the camp.**

**EMMERICH:** "I have paid for three expeditions. All three came back with a story and no book."
**EMMERICH:** "I do not want to own it. I want to know its *name.*"
**EMMERICH:** "I have been told it is a recipe. A hymn. A will. I would like to be told which."
> ► **"Why does it matter?"** — **EMMERICH:** "Because I have spent eleven years reading around it."
> ► **"How do I reach it?"** — **EMMERICH:** "You must be on the ceiling when the library turns."
> ► **"I'll go."** — **EMMERICH:** "Do not look down. When you are up, down is the sky."

**Scene 2: the library.** A vast hall, half drowned in gloom. Shelves climb every wall and curve across the roof. Books hang open overhead like roosting bats.

**LIBRARIAN GOLEM (a slow, creaking voice):** *"...Quiet... please..."*
*It floats near the ceiling, shelving. It does not acknowledge the player at all.*

**Scene 3: the turn.** At the appointed hour, the library groans. The floor tilts. The player's feet leave the stone. A moment of weightless nausea, and then the ceiling is under them, and the shelves rise like a hillside.

**EMMERICH (over a speaking-stone):** "Seventeen paces east. The green spine."
*The player reaches the shelf. The book is large and cold, its cover blank. It falls open at a page of dense, pale script.*
> ► **"Read the title."** — A line at the top: *"On the Keeping of Rooms."*
> ► **"Copy a page."** — The player copies the first page before the library turns back.
> ► **"Leave it on the shelf."** — The book settles back with a soft sigh.

**Scene 4: the descent.** The floor rushes back. The player lands in a heap.

**EMMERICH:** "The title?"
**EMMERICH:** (when told) "...*On the Keeping of Rooms.* That is no recipe. That is no hymn."
**EMMERICH:** "I do not know what it is. But I shall now spend the next eleven years finding out."

**Scene 2b: the other readers.** In the library's lower hall the player meets two rival scholars huddled over a candle, arguing about whether the building reads the readers.

**SCHOLAR A:** "It rearranges the shelves when we leave. I have proof."
**SCHOLAR B:** "It rearranges them because *you* put them back wrong."
**SCHOLAR A:** "I have never put anything back wrong in my life."
*A book slips from a shelf above them and lands, open, on Scholar A's head.*
**SCHOLAR B:** "Page forty. I rest my case."
**EMMERICH (over the speaking-stone, sighing):** "They have been like that for six years. Ignore them. Mind the turn."

**Outcomes and receipt.**
- Title, copy or leave: Emmerich gets one of three answers. The title alone satisfies him; the page makes him weep; leaving it makes him laugh.
- **Receipt:** a copied page of pale script that no scholar can fully read.
- **Canon-safe:** the contents of the book are never explained.

<!-- quest
id: qst_ldp_right_direction
title: Read in the Right Direction
rank: A
type: Investigation
giver: npc_emmerich_vaneholt
region: reg_labyrinth_deep
level: 126
act: 4
requires_rank: A
reward: 28500 | 1500 | 127000
sets: ldp_right_direction_done
summary: A book hangs open on the ceiling of the upside-down library. A scholar wants only its title.
objectives:
  talk npc_emmerich_vaneholt
  reach labyrinth_floor72_ceiling_shelf
  choice title_copy_or_leave
-->

---

## 7. When the Lantern Goes Out

*A · Hidden · raid camp, floor 60 · giver Lantern-Bearer Alder Oilwright*

**The short version.** Alder carried the lantern the night it went out. The council turned back. A party member who wanted to go on went on alone and was not seen again.

**What is really going on.** The rule that a dead lantern ends a raid has saved more lives than any spell. It also cost one. Alder knows both are true, and has not slept properly in a month. He does not want absolution. He wants someone to tell him the rule was right *and* the cost was real.

**Scene 1: the camp fire.**

**ALDER:** "The oil didn't run out. I filled it myself. The wick just... stopped."
**ALDER:** "We turned back. That's the rule. That's the *whole* rule."
**ALDER:** "Davin didn't. He said the rule was for cowards. He went down the stair alone."
> ► **"You followed the rule."** — **ALDER:** "I know. That is the problem."
> ► **"Did he come back?"** — **ALDER:** "No."
> ► **"What do you want?"** — **ALDER:** "To know if I should have gone after him."

**Scene 2: the stair.** The player and Alder descend to the place where the lantern went out. A dark landing, a half-circle of chalk.

**ALDER:** "Here. I set the lantern down. The flame just... bent. Like it had been called."
**ALDER:** "Davin said: *did you see that?* And I said: *yes.* And he said: *then we go.* And I said: *no.*"
*The chalk circle is scuffed. Beside it lies a single glove.*

**Scene 3: the glove.** Alder lifts it and holds it in both hands.

**ALDER:** "I couldn't have gone. Three others were behind me. I would have lost them."
**ALDER:** "But I keep thinking: if I had gone *with* him, he would not be alone."
> ► **"The rule saved the others."** — **ALDER:** "Yes. And it is still a rule that kills people."
> ► **"You couldn't have known."** — **ALDER:** "That is what everyone says. It is kind. It is not helpful."
> ► **"Light the lantern again."** — **ALDER:** (slowly) "...Now?"

**Scene 4: the flame.** Alder relights the lantern with a spark. This time it holds.

**ALDER:** "Davin used to say that a lantern is not a promise to come back. It is a promise to *try.*"
**ALDER:** "I will go home. I will tell the council I broke nothing. And I will tell them I would break it for him."

**Scene 2b: the other three.** Back at the fire, the three who turned back sit apart, each with a separate silence, and the player talks to them one by one.

**GIRL:** "I would have followed him. I was so angry that I did not."
**BOY:** "I was glad Alder said no. I am ashamed of being glad."
**OLD ARCHER:** "Davin was always going to go on. I told him so at the first stair. He laughed."
*None of them look at one another. The fire pops. Alder, listening from the dark, lets out a breath he has held a month.*
**OLD ARCHER:** "There is no right way to feel about a rule, lad. Only the way you carry it."

**Outcomes and receipt.**
- Alder does not give up the lantern but takes a season off. If the player lit it again with him, he carries it down again the next year. The council quietly adds Davin's name to the lantern's staff.
- **Receipt:** a small brass tag stamped *Davin,* fastened to the lantern's handle.

<!-- quest
id: qst_ldp_lantern_out
title: When the Lantern Goes Out
rank: A
type: Hidden
giver: npc_alder_oilwright
region: reg_labyrinth_deep
level: 128
act: 4
requires_rank: A
reward: 28500 | 1500 | 127000
sets: ldp_lantern_out_done
summary: A lantern-bearer's lantern went out, the council turned back, and one man went on alone.
objectives:
  talk npc_alder_oilwright
  reach labyrinth_floor60_dark_landing
  choice rule_kind_or_relight
-->

---

## 8. The Lantern at the Stair

*S · Exploration · floor 90, the stair · giver Raid-Captain Ione Carrowby*

**The short version.** The floor-ninety raid left one lantern at the stair when half the council turned back. Ione wants it recovered. She will not say what they found.

**What is really going on.** Ione's raid reached the stair on floor ninety and saw something there. Half the council went down. Half did not. The lantern was left to mark the way for those who might return. It has been burning, unattended, for eleven weeks. That is not what a lantern does.

**Scene 1: the camp.**

**IONE:** "I will not tell you what is at the stair. I do not have the words."
**IONE:** "I will tell you where the lantern is. And that it is still lit."
**IONE:** "Do not go past it. Do not go *down.* I will pay double to have you not go."
> ► **"What do you want?"** — **IONE:** "The lantern. And for you to come back."
> ► **"Why is it still lit?"** — **IONE:** "I do not know. That is the part I cannot bear."
> ► **"I'll bring it back."** — **IONE:** "Then bring it back whole. And do not read the wall."

**Scene 2: the descent.** Forty floors of cold, wet dark. At floor eighty-nine, the stair widens into a long hall, its walls inscribed from floor to ceiling with tiny writing in a language the player has never seen.

**IONE (over a speaking-stone):** "Don't read it."
*The writing seems to shift if looked at directly. The player looks at the floor.*

**Scene 3: the lantern.** At the stair on floor ninety, a single lantern stands on a flat stone, burning with a low, even flame. Its oil-reservoir is dry. It has been dry for weeks.

**IONE (faintly):** "Is it lit?"
> ► **"It's lit."** — A pause. "Bring it up."
> ► **"The oil is gone."** — A longer pause. "...Bring it up anyway."
> ► **"There's something beside it."** — A scrap of chalk on the stone: a single circle, drawn from the *inside.*

**Scene 4: the return.** The player lifts the lantern. It is warm, not hot. The flame bends toward the stair, then, slowly, back.

**IONE:** (when the player arrives) "You brought it."
**IONE:** "It's still lit. Eleven weeks. Gods."
*She takes it with both hands and says nothing for a very long time.*

**Scene 2b: the survivors.** Before the descent, Ione introduces the player to five survivors of the raid, who sit mending gear and do not speak of the stair.

**SURVIVOR:** "It was quiet. That is all I will say. It was very quiet."
**SURVIVOR:** "I stopped praying, you know. Below sixty. I started again at the stair."
**SURVIVOR:** "To whom, I do not know. But I started."
*Ione puts a hand on the survivor's shoulder, and lets it rest there.*
**IONE:** "That is all any of us have. A lantern, and a habit of hoping."
> ► **"I'll bring it back."** — **IONE:** "Do. I would like to say thank you to the flame."

**Outcomes and receipt.**
- The lantern is returned. If the player noted the chalk circle, Ione goes white and asks not to be told more. If not, she gives the lantern to the survivors, who keep it lit.
- **Receipt:** a scrap of the lantern's wick, which burns faintly in the dark and never gets shorter.
- **Canon-safe:** pure seed. What lies at the stair is **not** shown, named or explained, and the player does not go past it.

<!-- quest
id: qst_ldp_lantern_stair
title: The Lantern at the Stair
rank: S
type: Exploration
giver: npc_ione_carrowby
region: reg_labyrinth_deep
level: 166
act: 5
requires_rank: S
reward: 66000 | 2900 | 305000
sets: ldp_lantern_stair_done
summary: Survivors of the floor-ninety raid left a lantern at the stair. It is still lit, though its oil is gone.
objectives:
  talk npc_ione_carrowby
  reach labyrinth_floor90_stair_lantern
  choice lit_dry_or_circle
-->

---

## 9. Nests That Hang Down

*S · Escort · the Inverted Forest, floor 66 · giver Naturalist Pomeroy Featherstone*

**The short version.** Pomeroy has counted the inverted forest's upside-down birds for six years. A nest has just been built in the one tree he cannot reach. He wants it measured before the chicks fledge.

**What is really going on.** The birds fly upside down because the forest's sky is underfoot. Their chicks do not fly; they *fall up,* into the roots, and the parents must catch them. Pomeroy's fear is not for the nest but for the chicks that have never learned to be caught.

**Scene 1: the canopy.** A forest hangs from the ceiling, trunks pointing at the floor, leaves a green ceiling beneath the player's boots.

**POMEROY:** "Welcome to the only wood in the world where the roots are up!"
**POMEROY:** "Mind your footing. The sky is *underfoot* here, and it is not very good at being a floor."
**POMEROY:** "I need a nest measured. Nine feet up. Which is, for them, nine feet down."
> ► **"Why measure it?"** — **POMEROY:** "Because six years ago I measured the first. I like a complete record."
> ► **"Is it dangerous?"** — **POMEROY:** "The beasts, yes. The birds, only to my dignity."
> ► **"I'll go."** — **POMEROY:** "Bring the rope. And a very light step."

**Scene 2: the climb.** The player and Pomeroy cross the inverted canopy on a web of rope bridges. Below, through the leaves, a wide pale sky glows. A flock of tiny, round-bodied birds whirls past, wings beating at the stone ceiling.

**BIRD (a small, indignant whistle; subtitled):** *"Mine. Mine. Mine."*
**POMEROY:** "They like you! That is the sound of a bird that likes you!"
**POMEROY:** "It is also the sound of a bird that likes *everything.*"

**Scene 3: the nest.** In the high fork of a great trunk sits a woven nest the size of a washing-basket, full of speckled eggs, one of them cracking.

**POMEROY:** (hushed) "Oh. Oh, they're hatching."
*The shell splits. A pink, naked chick tumbles out and, with no warning, falls *up,* straight toward the roots.*
> ► **"Catch it."** — The player lunges and catches it, one-handed, as it drifts.
> ► **"Let the parents."** — A mother bird swoops, snatches the chick, and carries it back.
> ► **"Hold the nest still."** — The player steadies the branch while Pomeroy leaps and catches it in his hat.

**Scene 4: the measuring.** Pomeroy measures the nest with a bit of string, then spools it away.

**POMEROY:** "Nine inches across. Six deep. Five eggs, now four chicks and an egg."
**POMEROY:** "I have never held a chick in my hat before. I will never wash it."

**Scene 2b: the sky underfoot.** On the rope bridge Pomeroy stops to show the player the one thing he has never explained to anyone, a patch of the pale floor-sky that looks like dawn.

**POMEROY:** "It is not the sun, of course. It is a kind of reflection off the ceiling stone of the floor below."
**POMEROY:** "But I always think: somewhere up there, a morning is starting."
**POMEROY:** "The birds think so too. They sing at it. Every day. A little earlier than the day before."
*A tiny bird lands on his hat and sings, shrill and joyful, at the glow beneath them.*
**POMEROY:** "Yes, yes. I see it too."
> ► **"It's beautiful."** — He beams, and says nothing more.

**Outcomes and receipt.**
- The chick is caught, by hand, by the parents or by hat. Each way leaves the nest whole. Pomeroy publishes the record in the guild library under the player's name.
- **Receipt:** a speckled feather that always falls toward the ceiling.

<!-- quest
id: qst_ldp_nests_hang
title: Nests That Hang Down
rank: S
type: Escort
giver: npc_pomeroy_featherstone
region: reg_labyrinth_deep
level: 170
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: ldp_nests_hang_done
summary: A naturalist wants a nest measured in the inverted forest, where chicks fall up.
objectives:
  talk npc_pomeroy_featherstone
  escort npc_pomeroy_featherstone
  choice catch_parents_or_hold
-->

---

## 10. The City Changed Its Streets

*S · Investigation · the Sunken City · giver Cartographer Rosamund Wetherby*

**The short version.** Rosamund's father drew the whole Sunken City, once. The week after, the city changed its streets. She wants to know whether the city objected to being drawn.

**What is really going on.** The city does not object; it *replies.* Each time a complete map is made, the streets rearrange. It may be habit, or a kind of privacy, or a game. Rosamund has spent her life drawing and redrawing, and wants one thing: to learn whether the city can be asked.

**Scene 1: the map room.** A cold, wet room, its walls hung with a thousand maps, each one a different city.

**ROSAMUND:** "My father drew every street. It took four years. He finished on a Tuesday."
**ROSAMUND:** "By the following Monday the streets were different."
**ROSAMUND:** "I have drawn the city seventeen times. It has changed seventeen times."
> ► **"Is it hiding?"** — **ROSAMUND:** "Or shy. Or playing. I cannot tell."
> ► **"What do you want to know?"** — **ROSAMUND:** "Whether it minds."
> ► **"How do we ask?"** — **ROSAMUND:** "We draw it. Once more. And we watch."

**Scene 2: the survey.** From a drowned tower's roof, the player and Rosamund survey the city: its canals, its black glassy windows, its bridges that arch over nothing.

**ROSAMUND:** "Look. That bridge. It was not there last week."
**ROSAMUND:** "And that tower leans. It did not lean."
*A faint ripple runs through the water, and a street, half a mile off, quietly slides sideways.*
**ROSAMUND:** (whispering) "It's doing it *now.*"

**Scene 3: the map.** On a sheet of waxed paper, Rosamund finishes a final, careful map.

**ROSAMUND:** "There. Complete. Every street. Every canal."
**ROSAMUND:** "In a week it will be wrong."
> ► **"Burn it."** — She stares. "...What?"
> ► **"Leave it blank in the middle."** — **ROSAMUND:** "A blank? ...A place the city can keep?"
> ► **"Show it to the city."** — The player holds the map up toward the water. A long, slow ripple answers.

**Scene 4: the answer.** Whichever choice is made, the city's response is gentle: a single street, near the map room, does not shift that week.

**ROSAMUND:** "One street. Out of ten thousand."
**ROSAMUND:** "I think that is a *yes.* I think that is a *thank you.*"
*She sets her pen down for the first time in thirty years.*

**Scene 2b: the father's study.** Before the survey Rosamund opens her father's old chest, in which his first maps lie wrapped in oilcloth, the lines faded but fine.

**ROSAMUND:** "He drew with a quill from a bird that no longer exists. He said the city liked a steady hand."
**ROSAMUND:** "Look. In the margin, he wrote: *'I think it is looking back.'*"
**ROSAMUND:** "He wrote it in the fourth year. I did not read it until after he died."
*She closes the chest gently, as one closes a door on a sleeping child.*
**ROSAMUND:** "I used to be angry at the city. Now I am only curious. I think that is what he would have wanted."

**Outcomes and receipt.**
- The blank is left, the map shown or the map burnt. In every case a single street stays still for a week. Rosamund hangs the final map, blank centre and all, in her map room.
- **Receipt:** a map with a small blank space marked *"the city's."*
- **Canon-safe:** pure seed. Why the city rearranges itself is not explained, and no one is revealed to be behind it.

<!-- quest
id: qst_ldp_city_streets
title: The City Changed Its Streets
rank: S
type: Investigation
giver: npc_rosamund_wetherby
region: reg_labyrinth_deep
level: 176
act: 5
requires_rank: S
reward: 75000 | 3200 | 340000
sets: ldp_city_streets_done
summary: A cartographer's father mapped the Sunken City completely, and the city changed its streets. She wants to know whether it minds.
objectives:
  talk npc_rosamund_wetherby
  reach labyrinth_sunken_city_survey_tower
  choice burn_blank_or_show
-->
