# 11e-49 — Nox Dominion, the Dark Realm: Ten Side Quests (draft)

> *"The sky does not brighten here. That is no reason to stop lighting lamps."*
> — a border-town innkeeper, Gazetteer, Nox Dominion

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 3 and quest 9 plant unexplained seeds.

**Region:** `reg_nox_dominion` (the border towns and the Crimson Rest, the ash plains, the obsidian mines, the Hero's Road ruins; never the Overlord's Citadel). **Rank band:** S–SSS; this file uses S and SS. **Tone:** teen-rated, human-scale, warmth under shadow. Ordinary demons farm, haggle, worry about their children and fear the war as much as anyone.

**Placement notes.**
- Nox Dominion is a **story region** (Acts V-VI, `noSiege`) and has **no Tyrant.** It is ruled by the Demon Overlord and his five Generals, whose story is told elsewhere. **No quest here confronts, defeats, wounds or even meets the Overlord or a General;** none ends the war or changes its course. Authority is felt only through requisitions, curfews, rumours and fear.
- Customs the quests rely on: demons honour the Overlord as a saviour in public; some still pray to the day-gods in secret; the border towns trade between demons, human prisoners, deserters and traders; the economy runs on obsidian, sulphur, fire-crystals and war; lamps are lit against a sky that never brightens.
- **Race note.** The demons here use the race value **"Demon"**, which the validator accepts; please confirm it. No quest presents demons as monsters. They are cruel, kind, brave and tired, like anyone.
- **Rank note.** Quests 1-6 are S; quests 7-10 are SS (level 206+). SS rewards are first-pass and extrapolated from the guild promotion table (S to SS: level 205, GP 50,000; see `Data/World/guild_ranks.json`).
- The Dominion's own gentleness is the point. Nobody is rescued from being a demon.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | A Guest in the Cellar | S | Escort | Innkeeper Vesk Ambermaw | A human deserter, a long road home |
| 2 | What Humans Are Really Like | S | OddJob | Forge-wright Dathrak Cindermoor | A runaway child, a fearful father |
| 3 | The Statue With the Wrong Face | S | Investigation | Mason Karrow Slate | A face carved from memory |
| 4 | Ash-Wheat Before the Levy | S | Gathering | Farmer Brukka Ashfield | A harvest against a deadline |
| 5 | Two Sides of One Well | S | Faction | Wellkeeper Ysmira Dawnwell | Refugees and a shared water-rope |
| 6 | The Day-Prayer | S | Hidden | Grandmother Selka Embertongue | A prayer whispered under floorboards |
| 7 | Singing Obsidian | SS | Exploration | Shift-Boss Brannic Glassvein | A cave-in, a rope, a promise |
| 8 | The Honest Scale | SS | Investigation | Merchant Zahlia Brightscale | A requisition ledger that does not add |
| 9 | Marks on the Hero's Road | SS | Exploration | Scholar Ivrel Sootquill | Graffiti left by old heroes |
| 10 | The Lullaby Both Sides Know | SS | Faction | Bard Nerezza Lowflame | One tune, two languages |

## Cast

<!-- npc
id: npc_vesk_ambermaw
name: Innkeeper Vesk Ambermaw
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Innkeeper hiding a human deserter
backstory: A broad, soft-spoken demon of sixty with curved horns worn smooth at the tips, who has run the Crimson Rest's cellar kitchen for thirty years and has quietly hidden a frightened human deserter in it for three weeks.
-->
<!-- npc
id: npc_edrin_rook
name: Corporal Edrin Rook
tier: townsfolk
race: Human
region: reg_nox_dominion
settlement: The Border Towns
role: Human deserter in hiding
backstory: A thin, nineteen-year-old human corporal who walked away from a bad battle two months ago and who has learned to bake bread in the cellar of a demon inn.
-->
<!-- npc
id: npc_dathrak_cindermoor
name: Forge-wright Dathrak Cindermoor
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Forge-wright and father of a runaway
backstory: A heavy, anxious smith whose eight-year-old son left in the night with a satchel of bread and a list of questions about humans, and who has been told to expect the worst.
-->
<!-- npc
id: npc_karrow_slate
name: Mason Karrow Slate
tier: townsfolk
race: Demon
region: reg_nox_dominion
settlement: The Hero's Road
role: Mason who tends a ruined fortress
backstory: A sad, steady mason who mends the cracked walls of an old fortress no one uses and who has been carving, each night for a year, a face on a headless hero's statue.
-->
<!-- npc
id: npc_brukka_ashfield
name: Farmer Brukka Ashfield
tier: townsfolk
race: Demon
region: reg_nox_dominion
settlement: The ash plains
role: Ash-wheat farmer
backstory: A short, stubborn farmer with a clay pipe and four grandchildren who has until Friday to bring in a harvest the army will requisition on Saturday, and whose hired hands have all been conscripted.
-->
<!-- npc
id: npc_ysmira_dawnwell
name: Wellkeeper Ysmira Dawnwell
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Keeper of a shared well
backstory: A weathered, practical demon who keeps the only well that serves both the refugee camps on either side of a border town and who has refused to let either side claim the rope.
-->
<!-- npc
id: npc_selka_embertongue
name: Grandmother Selka Embertongue
tier: townsfolk
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Elder who prays to the day-gods
backstory: A tiny, very old demon who has whispered prayers to the day-gods under the floorboards every dawn of her life and who now fears her granddaughter has noticed.
-->
<!-- npc
id: npc_brannic_glassvein
name: Shift-Boss Brannic Glassvein
tier: major
race: Demon
region: reg_nox_dominion
settlement: The obsidian mines
role: Shift-boss of an obsidian mine
backstory: A grave, grey-horned shift-boss who has lost nobody in his tunnels in eleven years and who now has fourteen miners behind a collapse and a rule against asking for help.
-->
<!-- npc
id: npc_zahlia_brightscale
name: Merchant Zahlia Brightscale
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Merchant of fire-crystals
backstory: A quick, careful merchant who has kept honest books for twenty years and who has just been handed a requisition ledger that cannot be right.
-->
<!-- npc
id: npc_ivrel_sootquill
name: Scholar Ivrel Sootquill
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Hero's Road
role: Scholar of the old campaigns
backstory: A hunched, eager scholar of the ruined fortresses of the Hero's Road who has spent nine years copying what the heroes of past ages scratched on the walls and who has found something no one meant to leave.
-->
<!-- npc
id: npc_nerezza_lowflame
name: Bard Nerezza Lowflame
tier: major
race: Demon
region: reg_nox_dominion
settlement: The Border Towns
role: Border-town bard
backstory: A husky-voiced bard who plays at both ends of a border town for coin and who has noticed that a lullaby the demon children sing is the same one human prisoners hum.
-->

---

## 1. A Guest in the Cellar

*S · Escort · the Crimson Rest and the southern road · giver Innkeeper Vesk Ambermaw*

**The short version.** A human deserter has been hiding in Vesk's cellar for three weeks. A patrol is going door to door. Vesk wants him out of the Dominion, and cannot go himself.

**What is really going on.** Vesk is not a rebel. He is a man who found a hungry boy in his larder and could not turn him in. The road to the human lands is eighty miles of ash plain and ruined fortress, and the corporal will not make it alone. The player's job is to see one frightened stranger home without becoming a story.

**Scene 1: the cellar.**

**VESK:** "I said I'd feed him. I did not say I'd keep him. And yet. Three weeks."
**VESK:** "He bakes, you know. The best seed-loaf in the Rest. I shall miss it."
**ANSEL:** (from behind a barrel) "Sir? Is that a real adventurer?"
> ► **"Why help him?"** — **VESK:** "He was hungry. That seems like enough."
> ► **"What does the patrol know?"** — **VESK:** "They know a human walked off a wall at Ember Ridge. They do not know it's him."
> ► **"I'll take him."** — **VESK:** "Thank you. Don't let him sing."

**Scene 2: the first night.** The road out is silent and red-lit by distant lava. Edrin walks with his hood up, pausing at every glow.

**ANSEL:** "Everyone told me they eat people."
**ANSEL:** "He gave me his own *supper.*"
**ANSEL:** "I don't know what to do with that."
> ► **"Some do. Most don't."** — **ANSEL:** "That's what *I* said, about humans."
> ► **"Keep walking."** — **ANSEL:** "Yes. Yes, sir."
> ► **"Tell me about the bread."** — **ANSEL:** "Oh! Well, the secret is the ash..."

**Scene 3: the checkpoint.** At a ruined fortress gate, two demon sentries in dented plate stop the pair under a torch.

**SENTRY:** "Papers."
**SENTRY:** "Who's the human?"
> ► **(Say he's a trader's apprentice.)** — The sentries exchange a look.
> ► **(Say he's a hired porter.)** — A long wait.
> ► **(Offer a fire-crystal and say nothing.)** — A pause, then the sentry looks away.

**SENTRY (quietly, handing the papers back):** "My brother's out there somewhere on the other side. ...Go."

**Scene 4: the border.** At the edge of the plain stands a lone stone marker. Beyond it, the first green the player has seen in days.

**ANSEL:** "I thought it'd feel different."
**ANSEL:** "Tell Mr. Ambermaw the loaf wants more salt."

**Outcomes and receipt.**
- Edrin reaches the human lands. If the player bribed the sentry, the sentry is later reassigned; if the player lied well, the sentry never learns.
- **Receipt:** a seed-loaf recipe, written in two scripts, left on the Crimson Rest's counter.

<!-- quest
id: qst_nox_guest_cellar
title: A Guest in the Cellar
rank: S
type: Escort
giver: npc_vesk_ambermaw
region: reg_nox_dominion
level: 164
act: 5
requires_rank: S
reward: 66000 | 2850 | 300000
sets: nox_guest_cellar_done
summary: A demon innkeeper has hidden a human deserter for three weeks and wants him taken eighty miles to the border.
objectives:
  talk npc_vesk_ambermaw
  escort npc_edrin_rook
  reach nox_southern_border_marker
  choice apprentice_porter_or_crystal
-->

---

## 2. What Humans Are Really Like

*S · OddJob · the border towns · giver Forge-wright Dathrak Cindermoor*

**The short version.** Dathrak's eight-year-old son Imrey has run away with a satchel of bread and a list of questions about humans. Dathrak fears the worst. The player is the only human he has ever spoken to.

**What is really going on.** Imrey is in no danger, only curious. He is sitting in a ruined watch-post at the edge of town, hoping a human will walk past. The player is asked to find him, and then to be what he went looking for: an honest answer.

**Scene 1: the forge.**

**DATHRAK:** "He left a note. 'Gone to find out what humans are like. Back for supper.'"
**DATHRAK:** "It has been two suppers."
**DATHRAK:** "I told him they were monsters. I told him because everyone told me."
> ► **"Where would he go?"** — **DATHRAK:** "The old watch-post. He says you can see the human lands from the top."
> ► **"Are you angry?"** — **DATHRAK:** "At myself."
> ► **"I'll find him."** — **DATHRAK:** "Thank you. Do not frighten him."

**Scene 2: the watch-post.** A cracked tower on a ridge. Halfway up the broken stair, a small boy, horns still buds, sits with a notebook.

**IMREY:** "Are you a human?"
**IMREY:** "Can I ask you questions? I have eleven."
> ► **"Ask."** — **IMREY:** "Do you really sleep on beds?"
> ► **"Your father's worried."** — **IMREY:** "I know. I left a note."
> ► **"You first. Why do you want to know?"** — **IMREY:** "Because nobody *says.*"

**Scene 3: the questions.** On the cold tower top, under a sky with no stars, the boy reads the questions one by one.

**IMREY:** "Do you have songs?"
**IMREY:** "Are you scared of us?"
**IMREY:** "Do you have a mum?"
> ► **(Answer all of them honestly.)** — He writes every answer down.
> ► **(Answer some, and ask some back.)** — He is delighted.
> ► **(Say, "Ask your father.")** — He hesitates.

**IMREY:** "I think I'll ask him. ...He'll be cross."
**PLAYER:** "He'll be relieved."

**Scene 4: the supper.** Back at the forge, Dathrak does not scold. He sits the boy on his knee and reads the notebook, line by line, from the first page. At question seven he stops, wipes his eyes with the back of a soot-black wrist, and answers it.

**DATHRAK:** "I don't know. I've never asked one."
**IMREY:** "Then we'll ask together."

**Outcomes and receipt.**
- Imrey is home. If the player said "ask your father," Dathrak is moved that his son came to him first. If the player answered everything, the notebook becomes a small, treasured thing.
- **Receipt:** a notebook of eleven questions and answers on the forge shelf; Imrey's drawing of a human, with too many fingers, pinned above the anvil.

<!-- quest
id: qst_nox_humans_like
title: What Humans Are Really Like
rank: S
type: OddJob
giver: npc_dathrak_cindermoor
region: reg_nox_dominion
level: 168
act: 5
requires_rank: S
reward: 68000 | 2950 | 310000
sets: nox_humans_like_done
summary: A demon child has run away to find out what humans are like. His father wants him home.
objectives:
  talk npc_dathrak_cindermoor
  reach nox_old_watch_post
  choice answer_ask_or_father
-->

---

## 3. The Statue With the Wrong Face

*S · Investigation · the Hero's Road · giver Mason Karrow Slate*

**The short version.** A ruined fortress on the Hero's Road holds a statue of a past hero. Its face is wrong. It has been changing, night after night, and Karrow, who mends the walls, cannot explain it.

**What is really going on.** Karrow is carving it. He does not know why, and he is ashamed. Each night he wakes with a chisel in his hand and a new line in the stone. The face he carves belongs to a human woman, long dead, who once carried him out of a burning mine as a child. The statue's real face wore away centuries ago.

**Scene 1: the fortress.**

**KARROW:** "The hero's name is lost. The face went before I was born. Now there is a face again."
**KARROW:** "I thought it was ghosts. Then I found the chisel under my pillow."
**KARROW:** "I would like to know whether I am being used."
> ► **"By whom?"** — **KARROW:** "I have no idea. That is the problem."
> ► **"Do you remember carving?"** — **KARROW:** "Only the cold. Only the cold, and the sound."
> ► **"I'll watch tonight."** — **KARROW:** "I would be grateful. I have not slept well."

**Scene 2: the vigil.** The player waits in the statue's shadow under the red-black sky. Karrow sleeps on a pallet. At the hour of the second bell he rises, eyes open and unfocused, takes his chisel and begins to work.

*The face emerges: a woman, tired, kind, with a scar over one eye. Karrow hums as he carves.*
**KARROW (in his sleep):** "She said, 'Keep your head down, little one.'"
> ► **"Wake him."** — He starts and the chisel falls.
> ► **"Let him finish."** — He completes the cheek, then sinks onto the pallet.
> ► **"Ask him who she is."** — **KARROW (asleep):** "...She was a prisoner. She gave me her water."

**Scene 3: the day.** In the morning Karrow remembers. The old story comes out slowly, a mine fire, a human prisoner who carried a demon child to the shaft, a scar from a falling beam.

**KARROW:** "I never learned her name. The guards took her the next day."
**KARROW:** "I have spent forty years trying not to think about her."
> ► **"The statue is hers now."** — **KARROW:** "It was a hero's. ...It will do."
> ► **"Finish the face."** — **KARROW:** "I will, awake, this time."
> ► **"Whose hero was this originally?"** — **KARROW:** "No one knows. That is the saddest part."

**Scene 4: the unveiling.** A week later the statue is done. The face is gentle, scarred, unnamed. A few passing demons stop. One lays a fire-crystal at its feet.

**KARROW:** "It does not need a name. It needs a face."

**Outcomes and receipt.**
- The statue is finished in daylight. Karrow sleeps through the night for the first time in a year. If the player woke him mid-carve, the cheek stays unfinished.
- **Receipt:** a scarred face on a nameless statue, a crystal at its feet, and a pallet that Karrow no longer needs.
- **Canon-safe:** the *original* hero of the statue is **left unnamed;** the quest does not say which of the heroes of past ages stood there.

<!-- quest
id: qst_nox_statue_face
title: The Statue With the Wrong Face
rank: S
type: Investigation
giver: npc_karrow_slate
region: reg_nox_dominion
level: 172
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: nox_statue_face_done
summary: A hero's statue on a ruined fortress keeps growing a new face, and the mason who mends the walls cannot say why.
objectives:
  talk npc_karrow_slate
  reach nox_hero_road_statue
  choice wake_finish_or_ask
-->

---

## 4. Ash-Wheat Before the Levy

*S · Gathering · the ash plains · giver Farmer Brukka Ashfield*

**The short version.** The army will requisition Brukka's ash-wheat on Saturday. If it is still standing, it is lost. His hands are conscripted and the sky will not brighten. He has four days.

**What is really going on.** Brukka is not asking for a miracle, only for sheaves. The player is asked to cut and bundle twelve sheaves a day against heat, ash-storms and a hellhound that has taken to the stubble. This is a quest about work, and about a family who will eat it.

**Scene 1: the field.**

**BRUKKA:** "Four hundred rows. Four days. I have four grandchildren and one good knee."
**BRUKKA:** "The army takes a third on Saturday whether it is cut or not. I would like the other two thirds in a barn."
> ► **"Where do I start?"** — **BRUKKA:** "The east end. Cut low. Don't crush the heads."
> ► **"What about the hellhound?"** — **BRUKKA:** "She's thin. She's no trouble. Don't hurt her."
> ► **"I'll cut."** — **BRUKKA:** "I'll pay in bread and gratitude. Mostly bread."

**Scene 2: the cutting.** A long day with a sickle in hot ash, bundling grey-gold stalks. The children carry water. The smallest, Tobbi, ties sheaves with a ribbon.

**TOBBI:** "You're slow."
**PLAYER:** (agrees)
**TOBBI:** "It's all right. Grandad's slow too."
*(Gameplay: collect twelve ash-wheat sheaves per day for three days, with timing and weather events.)*

**Scene 3: the storm.** On the third afternoon, an ash-storm rolls across the plain like a grey wall. Brukka stands in the field, a sickle in each hand, and does not move.

**BRUKKA:** "I'll not leave it."
> ► **"Cut what we can."** — The stalks fall fast.
> ► **"Tie the rest and weight them."** — A frantic hour of stones and rope.
> ► **"Take the children to the barn."** — **BRUKKA:** "Good. Yes. Go."

**Scene 4: the barn.** The storm passes. Two thirds of the harvest is in. The hellhound, wheeling in the doorway, is fed a bowl of scraps by Tobbi.

**BRUKKA:** "I've never brought it in on time before."
**BRUKKA:** "I'll be a liar if I say it didn't hurt. But we'll eat."

**Outcomes and receipt.**
- Two thirds of the crop is saved. If the player put the children first, the army takes slightly more, and Brukka does not mind.
- **Receipt:** a ribbon on the barn door, tied by a child who said the player was slow; a sack of ash-wheat flour.

<!-- quest
id: qst_nox_ash_wheat
title: Ash-Wheat Before the Levy
rank: S
type: Gathering
giver: npc_brukka_ashfield
region: reg_nox_dominion
level: 166
act: 5
requires_rank: S
reward: 67000 | 2900 | 305000
sets: nox_ash_wheat_done
summary: A farmer has four days to bring in a harvest the army will requisition on Saturday.
objectives:
  talk npc_brukka_ashfield
  collect nox_ashwheat_sheaf 36
  choice cut_tie_or_children
-->

---

## 5. Two Sides of One Well

*S · Faction · a border town · giver Wellkeeper Ysmira Dawnwell*

**The short version.** A border town's only well sits between two refugee camps, one demon, one human. Ysmira has kept the rope neutral for a year. Tonight someone cut it.

**What is really going on.** No one cut it on purpose. A child dropped a bucket and the rope frayed and snapped. But each camp thinks the other did it, and by dawn there will be a fight. The player must mend the rope in a way that both camps will trust.

**Scene 1: the well.**

**YSMIRA:** "One well. One rope. Two camps. Four hundred souls."
**YSMIRA:** "It was cut at midnight. Everybody is saying: *them.*"
**YSMIRA:** "I need a rope by morning, and I need both camps to believe in it."
> ► **"Who cut it?"** — **YSMIRA:** "Nobody. But try telling that to a thirsty man."
> ► **"What do they trust?"** — **YSMIRA:** "Each other's hands. Not words."
> ► **"I'll find a way."** — **YSMIRA:** "Do. And quickly."

**Scene 2: the camps.** On the demon side, soot-faced women wring their hands over empty pots. On the human side, a lanky boy and a grandfather stare at the dry well-mouth.

**DEMON ELDER:** "We were promised water."
**HUMAN ELDER:** "We were promised *safety.*"
> ► **"The rope frayed. A child dropped a bucket."** — Neither believes it.
> ► **"Let each camp weave half."** — A long pause.
> ► **"Ask them to watch the well together."** — **HUMAN ELDER:** "With *them?*"

**Scene 3: the weaving.** At dusk, two rope-makers, one demon, one human, sit on either side of the well and begin to braid, one strand each. The patterns clash: the demons' knots are flat, the humans' round.

**DEMON ROPE-MAKER:** "Your knot is ugly."
**HUMAN ROPE-MAKER:** "Yours won't hold."
**PLAYER:** (the player is asked to tie the join)
> ► **(Use the flat knot.)** — The demon side nods.
> ► **(Use the round knot.)** — The human side nods.
> ► **(Tie both, one over the other.)** — A surprised silence.

**Scene 4: the first bucket.** At dawn, a demon child and a human child draw the first bucket together. It comes up full, clear and cold.

**YSMIRA:** "That's the rope."
**YSMIRA:** "Neither of you can say whose it is. Good."

**Outcomes and receipt.**
- The well stays open to both camps. If the player used only one knot, one camp keeps a grudge; if both, the "double knot" becomes the camp sign.
- **Receipt:** a rope with two knots, one over the other, looped on the well-post.
- **Canon-safe:** the quest settles a local dispute only; it does not touch the war or the refugee situation.

<!-- quest
id: qst_nox_one_well
title: Two Sides of One Well
rank: S
type: Faction
giver: npc_ysmira_dawnwell
region: reg_nox_dominion
level: 176
act: 5
requires_rank: S
reward: 72000 | 3100 | 330000
sets: nox_one_well_done
summary: The shared well's rope has snapped, and two refugee camps blame each other.
objectives:
  talk npc_ysmira_dawnwell
  reach nox_border_town_well
  choice flat_round_or_both
-->

---

## 6. The Day-Prayer

*S · Hidden · a border-town cottage · giver Grandmother Selka Embertongue*

**The short version.** Selka has prayed to the day-gods in secret every dawn of her life, under a loose board. Her granddaughter has started rising early. Selka is afraid.

**What is really going on.** The granddaughter, Pira, has noticed, and does not want to tell. She wants to *join.* Neither knows the other knows. The player is asked to carry a message between them, and to guard a secret that is not really a secret any more.

**Scene 1: the cottage.**

**SELKA:** "Hush. Close the door. I do not say it aloud, even here."
**SELKA:** "Seventy years. Every dawn. A whisper, a candle and a loose board."
**SELKA:** "Pira has been getting up early. I think she has heard me."
> ► **"Are you in danger?"** — **SELKA:** "Everyone is, a little. It makes no difference."
> ► **"What do you want me to do?"** — **SELKA:** "Ask her. Gently. I cannot."
> ► **"I'll talk to her."** — **SELKA:** "Bring honey. She likes honey."

**Scene 2: the granddaughter.** In the garden, a girl of thirteen with small horns and a very worried face.

**PIRA:** "Has she told you? I don't want her to be afraid."
**PIRA:** "I hear her. Every morning. I put my ear to the floor."
**PIRA:** "I want to say it with her. I just don't know the words."
> ► **"Ask her to teach you."** — **PIRA:** "She'll say no."
> ► **"Tell her you know."** — **PIRA:** "She'll cry."
> ► **"I'll be there."** — **PIRA:** "Please."

**Scene 3: the dawn.** Before light, in the kitchen, Selka lifts the board. The candle is small. The two begin, very softly, in a language the player half-recognises.

**SELKA:** "Day-gods, hear us..."
**PIRA:** "...hear us."
*A thin line of pale light lies on the floor. It is only the candle. It feels like more.*
> ► **(Stand silently.)** — Respect.
> ► **(Add a word of your own.)** — Selka smiles.
> ► **(Keep watch at the window.)** — Quiet duty.

**Scene 4: the board.** When it is done, Selka does not put the board back.

**SELKA:** "I think I'll leave it up."
**PIRA:** "Gran, the neighbours..."
**SELKA:** "Then they'll learn the words."

**Outcomes and receipt.**
- A grandmother and granddaughter pray together at last. If the player kept watch, the neighbours never learn; otherwise a few curious faces appear at the window.
- **Receipt:** a loose board, left leaning; a small candle in a saucer on the sill.
- **Canon-safe:** the day-gods' existence and reach are **not** addressed. The quest is about a family's faith.

<!-- quest
id: qst_nox_day_prayer
title: The Day-Prayer
rank: S
type: Hidden
giver: npc_selka_embertongue
region: reg_nox_dominion
level: 162
act: 5
requires_rank: S
reward: 65000 | 2800 | 295000
sets: nox_day_prayer_done
summary: An old woman prays to the day-gods in secret. Her granddaughter has started getting up early.
objectives:
  talk npc_selka_embertongue
  reach nox_embertongue_cottage
  choice silent_word_or_watch
-->

---

## 7. Singing Obsidian

*SS · Exploration · the obsidian mines · giver Shift-Boss Brannic Glassvein*

**The short version.** A collapse has trapped fourteen miners behind a wall of broken rock. Brannic's rule is that no outsider enters a working tunnel. Tonight he breaks it.

**What is really going on.** The only way in is through an old vein of singing obsidian, glass so thin that it rings when struck. The miners can hear rescuers coming through it. The player must reach them without cracking the vein, and without letting the sound bring down more rock.

**Scene 1: the pithead.**

**TORVALD:** "Eleven years. Nobody dead in my tunnels."
**TORVALD:** "Fourteen behind the fall. We hear them knocking. We cannot reach them."
**TORVALD:** "The rule says no outsiders underground. I have just decided the rule is wrong."
> ► **"What's the route?"** — **TORVALD:** "The singing seam. Quiet feet."
> ► **"How long have they got?"** — **TORVALD:** "Air for a day."
> ► **"I'll go."** — **TORVALD:** "Take the rope. Take the lantern. Take care."

**Scene 2: the seam.** A thin, glittering tunnel of black glass that hums at a note just below hearing. Every footfall sets the walls ringing softly. Ahead, a faint knocking.

*(Gameplay: stealth-style traversal; heavy steps raise a ringing that loosens the roof.)*
**MINER (muffled, through stone):** "Hello? Is that a rescuer? We're out of water."
> ► **"Hold on. Stay quiet."** — Silence.
> ► **"Sing back to me."** — A low chant answers.
> ► **"How many are you?"** — **MINER:** "Fourteen. And a cat."

**Scene 3: the fall.** The wall of rubble is thick. The only way through is to strike a particular crystal, which will ring, and which could shatter the vein.

> ► **(Strike it softly, then wait.)** — The note spreads.
> ► **(Hum the pitch of the vein first.)** — The ringing dampens.
> ► **(Dig through by hand.)** — Slow, safe, hard.

A hand pushes through the hole, grey with dust. Then a second. Then a cat.

**Scene 4: the surface.** One by one, fourteen miners climb into the light of the pithead lamps, blinking at a sky that does not brighten.

**TORVALD:** "Eleven years, and one more."
**TORVALD:** "I'll amend the rule."

**Outcomes and receipt.**
- All fourteen are saved. If the player dug by hand, it takes a night longer but the seam is unharmed; if the vein was struck, the seam cracks and sings no more.
- **Receipt:** a cat named Cinder on the pithead, fed daily; a new sign at the mine: "Rescuers welcome."

<!-- quest
id: qst_nox_singing_obsidian
title: Singing Obsidian
rank: SS
type: Exploration
giver: npc_brannic_glassvein
region: reg_nox_dominion
level: 208
act: 6
requires_rank: SS
reward: 135000 | 5500 | 650000
sets: nox_singing_obsidian_done
summary: Fourteen miners are trapped behind a collapse. The only way in runs through a vein of obsidian that rings when struck.
objectives:
  talk npc_brannic_glassvein
  reach nox_singing_seam_collapse
  choice strike_hum_or_dig
-->

---

## 8. The Honest Scale

*SS · Investigation · the border towns' market · giver Merchant Zahlia Brightscale*

**The short version.** A requisition ledger arrived with Zahlia's fire-crystal order. It lists a quantity she never delivered, and the quartermaster has signed it. Either she is being robbed, or someone is stealing in her name.

**What is really going on.** A junior clerk has been padding the ledgers to feed a starving unit. He is not a villain; he is afraid. The player's job is not to expose the war, only one small, human theft, and decide what happens to a boy with a pen.

**Scene 1: the stall.**

**ZAHLIA:** "Twenty years, honest scales. Never a pinch short."
**ZAHLIA:** "This ledger says I delivered four hundred crystals to the Ninth Company. I delivered two hundred and fifty."
**ZAHLIA:** "Somebody's signed for a hundred and fifty I never saw."
> ► **"Can you prove it?"** — **ZAHLIA:** "Only by my own books."
> ► **"Who benefits?"** — **ZAHLIA:** "That's the part I can't see."
> ► **"I'll look into it."** — **ZAHLIA:** "Quietly. The quartermaster is a hard man."

**Scene 2: the depot.** A barracks yard, a counting-room, and a clerk with ink on his fingers who will not meet the player's eye.

**CLERK (Oren):** "I just copy the numbers."
**CLERK:** "I don't know about any padding."
> ► **"Where did the crystals go?"** — **OREN:** "...I can't say."
> ► **"I can see the third column."** — **OREN:** "Please don't."
> ► **"You're frightened. Tell me."** — A long breath.

**Scene 3: the truth.** In the back of the depot, behind a stack of crates, a room of thin, hollow-eyed soldiers wrapped in blankets and a stove burning the last of Zahlia's crystals.

**OREN:** "They're a supply company. They haven't been fed in a month. The quartermaster pockets the pay."
**OREN:** "I thought: if I add a number, they get warm."
> ► **"Tell Zahlia."** — **OREN:** "She'll ruin me."
> ► **"Put the numbers right and fund the stove."** — A cautious relief.
> ► **"Report the quartermaster."** — **OREN:** "He'll kill me first."

**Scene 4: the books.** Zahlia, hearing it, sits for a long time with the ledger. At last she crosses out the false line and writes a new one in her own hand.

**ZAHLIA:** "A hundred and fifty crystals. Donated. To the Ninth Company."
**ZAHLIA:** "Let the quartermaster explain *that.*"

**Outcomes and receipt.**
- The ledger is honest, the unit is warm, and the clerk is protected. If the quartermaster was reported, he is quietly reassigned and the unit's fate is uncertain.
- **Receipt:** a line in a ledger that reads "Donated," in a hand that does not shake.
- **Canon-safe:** the war's supply is touched only by one company; no General appears.

<!-- quest
id: qst_nox_honest_scale
title: The Honest Scale
rank: SS
type: Investigation
giver: npc_zahlia_brightscale
region: reg_nox_dominion
level: 212
act: 6
requires_rank: SS
reward: 140000 | 5700 | 680000
sets: nox_honest_scale_done
summary: A requisition ledger lists fire-crystals a merchant never delivered, and someone has signed for them.
objectives:
  talk npc_zahlia_brightscale
  reach nox_ninth_company_depot
  choice tell_fund_or_report
-->

---

## 9. Marks on the Hero's Road

*SS · Exploration · the Hero's Road · giver Scholar Ivrel Sootquill*

**The short version.** Ivrel has spent nine years copying what past heroes scratched on the walls of the ruined fortresses. In the deepest ruin he found a line in a child's hand.

**What is really going on.** Most of the graffiti is boasts and names. But in the oldest fortress the last wall holds a drawing: a small stick figure in a cloak, holding the hand of a taller figure with horns. Beneath, in an unfamiliar script, a single line. The scholar cannot translate it. Neither can the player. The quest is the finding, not the answer.

**Scene 1: the dig.**

**IVREL:** "Boasts. Names. A few rude drawings. Nine years of it."
**IVREL:** "Then this. At the bottom of the Sixth Fortress."
**IVREL:** "I would like a second pair of eyes before I decide I'm mad."
> ► **"What does it say?"** — **IVREL:** "I do not know. The script is not one of ours."
> ► **"Is it dangerous?"** — **IVREL:** "It is a drawing."
> ► **"I'll come."** — **IVREL:** "Wear boots. The floor is glass."

**Scene 2: the Sixth Fortress.** A shattered keep of black stone. Heroes' names climb the walls in a dozen hands: *Ardin was here. Thesk the Brave. We held the stair.* Further down, the writing thins to a single scrawl.

**IVREL:** "Look. There."
*A stick figure in a cloak, a taller figure with horns, and between them, joined hands.*
> ► **"A hero and a demon."** — **IVREL:** "That's what I thought."
> ► **"A child and a parent."** — **IVREL:** "Also possible."
> ► **"It looks friendly."** — **IVREL:** "Yes. That's the odd part."

**Scene 3: the line.** Below the drawing, a short row of curling characters that match no script the scholar or the player has seen.

**JOURNAL (auto):** *Seven characters. No known cipher. Carved with something blunt, perhaps a child's spoon.*
> ► **(Copy it exactly.)** — Ivrel beams.
> ► **(Take a rubbing.)** — Careful, clean.
> ► **(Leave it uncopied.)** — **IVREL:** "...Hm. Perhaps that's wiser."

**Scene 4: the safe house.** Back at the scholar's study, a candle burns late. Ivrel sets the copy beside his other nine years of notes and sits looking at the two together.

**IVREL:** "I always thought the road was about the heroes."
**IVREL:** "Perhaps it was about the people who followed them."

**Outcomes and receipt.**
- The drawing is recorded. Nothing is translated. If the player did not copy it, Ivrel mourns but respects the choice.
- **Receipt:** a rubbing pinned beside a candle; a scholar who has stopped copying boasts.
- **Canon-safe:** this is a **pure seed.** The script, the figures and the line are **unexplained.**

<!-- quest
id: qst_nox_hero_road_marks
title: Marks on the Hero's Road
rank: SS
type: Exploration
giver: npc_ivrel_sootquill
region: reg_nox_dominion
level: 218
act: 6
requires_rank: SS
reward: 145000 | 5900 | 700000
sets: nox_hero_marks_done
summary: In the deepest ruined fortress, among the heroes' boasts, a scholar has found a child's drawing in an unknown script.
objectives:
  talk npc_ivrel_sootquill
  reach nox_sixth_fortress_wall
  choice copy_rub_or_leave
-->

---

## 10. The Lullaby Both Sides Know

*SS · Faction · a border town's two taverns · giver Bard Nerezza Lowflame*

**The short version.** Nerezza plays in both ends of a border town, the demon tavern and the human one. She has noticed that the lullaby the demon children sing and the one human prisoners hum are the same tune.

**What is really going on.** Nobody can say where it came from. The words differ, the tune is identical. Nerezza wants one night where both sides sing it together, in one room, and she needs the player to open the door between the taverns.

**Scene 1: the tavern.**

**NEREZZA:** "Listen."
*She hums. It is soft and old, a rise and a fall.*
**NEREZZA:** "Demon mothers sing that to their babies. Human prisoners hum it in the cells. Same notes, different words."
**NEREZZA:** "I'd like to see what happens when they hear each other."
> ► **"Where does it come from?"** — **NEREZZA:** "Nobody knows. I've asked everybody."
> ► **"Is it safe?"** — **NEREZZA:** "It's a song."
> ► **"I'll open the door."** — **NEREZZA:** "There is a door between the two taverns. Nobody's opened it in six years."

**Scene 2: the door.** A narrow, rusted door in a back corridor. Beyond it, a dark passage; at the other end, a second door and the sounds of a human tavern.

**NEREZZA:** "Nobody oiled the hinges."
> ► **"Oil them."** — It opens quietly.
> ► **"Force it."** — It opens with a bang.
> ► **"Knock first."** — A silence, then a knock back.

**Scene 3: the room.** A crowd gathers: demon soldiers off-duty, human prisoners on parole, drovers, children, a thin old man with a fiddle. For a long moment, nobody speaks.

**NEREZZA:** (stepping to the middle) "I'll sing it first. In both."
*Her voice is rough and sure. At the second line, a woman in the crowd, a demon, joins in. At the third, a human.*
> ► **(Hum along.)** — Your voice blends.
> ► **(Fetch the fiddler.)** — The old man plays.
> ► **(Stand by the door.)** — You keep it open.

**Scene 4: the quiet.** When the last note dies, the room is silent. Then a child asks, in a small, clear voice:

**CHILD:** "Why do we both know it?"
**NEREZZA:** "I don't know, darling. Isn't it wonderful?"

**Outcomes and receipt.**
- The two taverns hold a shared song-night. Nothing in the war changes. If the door was forced, the first verse is lost in the noise.
- **Receipt:** a rusted door left open, hinges oiled; a lullaby sung in two languages at closing time.
- **Canon-safe:** this is a **pure seed.** The origin of the lullaby is **not explained.**

<!-- quest
id: qst_nox_shared_lullaby
title: The Lullaby Both Sides Know
rank: SS
type: Faction
giver: npc_nerezza_lowflame
region: reg_nox_dominion
level: 224
act: 6
requires_rank: SS
reward: 150000 | 6200 | 740000
sets: nox_lullaby_done
summary: Demon children and human prisoners sing the same lullaby in different words. A bard wants them to hear one another.
objectives:
  talk npc_nerezza_lowflame
  reach nox_border_town_shared_tavern
  choice oil_force_or_knock
-->
