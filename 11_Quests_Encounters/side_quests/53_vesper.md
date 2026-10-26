# 11e-53 — Vesper, the Red Moon: Ten Side Quests (draft)

> *"Every faith fears it. Nobody on the surface remembers a different moon. That is the part that keeps me awake."*
> — Scholar Tobias Wickham, field notes

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 1, 3, 7, 8, 9 and 10 plant unexplained seeds; none touches what waits at the Red Heart.

**Region:** `reg_vesper` (the Broken Streets, the Floating Quarter, the approach to the Red Heart). **Rank band:** SS–EX. **Tone:** silent, strange, tender; the ruins remember people kindly, and the player is the one being watched.

**Placement notes.**
- **Vesper is the post-game region.** It has no Tyrant and no siege (`noSiege: true`), and these quests do **not** reveal who built the city, why the moon is red, or what lies at the Red Heart. "The ruins remember you" is used as a *feeling,* never as a mechanism.
- Customs the quests rely on: nobody lives on Vesper, so quest-givers are scholars, couriers and families who stay at a **way-camp at the edge of the Broken Streets** or on the surface (Aldmere, the Lustrine Shores). Visitors **leave a light** where they sleep; every faith fears the moon (the Church calls it an omen, the elves a wound in the sky, the Lustrine fishers a thief of light), and the quests let all three stand.
- Monster families here: vesperites, undead, shadows, aberrations, constructs, demons. Vesperites are *creatures born from the red light,* some almost human; the quests treat them as people to be understood, not solved.
- **Rank note.** The region band is SS–EX, but the quest `rank` enum tops out at SSS and the guild table has no EX row, so every quest here is **SS** (levels 206-259 per `Data/World/guild_ranks.json`). **All SS rewards are first-pass,** extrapolated from the promotion table (SS: GP 6,000 first-pass); please approve or replace.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Map That Matched | SS | Investigation | Scholar Tobias Wickham | A city on no map |
| 2 | The One Who Followed | SS | Escort | Sorrel | A vesperite looking for someone |
| 3 | The Song of the Red Flowers | SS | Investigation | Hester Lamm | An old woman recognises a tune |
| 4 | Names on the Doors | SS | OddJob | Cador Fell | Cataloguing the dead streets |
| 5 | Across the Floating Quarter | SS | Escort | Pilot Gawen Trelawn | Stepping stones in black sky |
| 6 | Three Words for the Moon | SS | Faction | Priest Petronel Voss | Church, elves, fishers |
| 7 | The Baker Who Is Not There | SS | Hidden | Wilmot Crane | A shop that still opens |
| 8 | The Edge of the Light | SS | Exploration | Cartographer Dessa Orrin | A map that stops on purpose |
| 9 | A Mother's Lantern | SS | Investigation | Margit Sallow | A son, a chalk mark |
| 10 | The White Moon | SS | Hidden | Historian Thaddeus Nole | Whose memory is right? |

## Cast

<!-- npc
id: npc_tobias_wickham
name: Scholar Tobias Wickham
tier: major
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Scholar of the red moon
backstory: A rumpled, kindly scholar who spent thirty years arguing over the dark marks on the red moon's face and who has lately received a map of those marks that matches a city on no map of the world.
-->
<!-- npc
id: npc_sorrel_vesperite
name: Sorrel
tier: major
race: Vesperite
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Vesperite searching for someone
backstory: A slender, softly glowing vesperite who followed an adventurer down to the surface once, came back, and is now searching the ruins for a person whose name it has only half heard.
-->
<!-- npc
id: npc_hester_lamm
name: Hester Lamm
tier: major
race: Human
region: reg_vesper
settlement: Aldmere
role: Old woman who knows the song
backstory: A tiny, sharp-eyed woman of ninety who hums a lullaby her grandmother sang and who was stopped dead, at the market, when a visitor played her a recording of the red flowers' song.
-->
<!-- npc
id: npc_cador_fell
name: Cador Fell
tier: townsfolk
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Delver who catalogues doors
backstory: A patient, soft-spoken delver who has copied nine hundred name-plates from the doors of the Broken Streets and who is certain that someone, someday, will want them.
-->
<!-- npc
id: npc_gawen_trelawn
name: Pilot Gawen Trelawn
tier: major
race: Half-elf
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Pilot of the Floating Quarter
backstory: A laconic half-elf pilot who has crossed the Floating Quarter's drifting stones eleven times, and who talks to the stones in a low, dry voice as if they were temperamental mules.
-->
<!-- npc
id: npc_petronel_voss
name: Priest Petronel Voss
tier: major
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Church priest of the omen
backstory: A tall, gentle priest who has preached on the red moon for twenty years and who has come to stand under it for the first time, nervous and a little ashamed of how little he knows.
-->
<!-- npc
id: npc_wilmot_crane
name: Wilmot Crane
tier: major
race: Ghost
region: reg_vesper
settlement: The Broken Streets
role: Ghostly baker of the ruins
backstory: A round, floury ghost who keeps opening a bakery in the Broken Streets every dawn, setting out loaves that are not there, and greeting customers who do not come.
-->
<!-- npc
id: npc_dessa_orrin
name: Cartographer Dessa Orrin
tier: major
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Guild cartographer
backstory: A square-shouldered cartographer who has mapped the moon's approach to the last inch and who is troubled that the last inch of her map, every time she redraws it, ends in a straight, deliberate line.
-->
<!-- npc
id: npc_margit_sallow
name: Margit Sallow
tier: townsfolk
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Mother of a lost adventurer
backstory: A weathered mother of sixty who walked to the way-camp when the moon opened, carrying the lantern her son took with him on his last expedition, and has not slept since.
-->
<!-- npc
id: npc_thaddeus_nole
name: Historian Thaddeus Nole
tier: major
race: Human
region: reg_vesper
settlement: Way-Camp at the Broken Streets
role: Collector of memories of the moon
backstory: A precise, white-haired historian who has spent a decade collecting what people say they remember of the moon, and who has found that no two accounts of its colour agree.
-->

---

## 1. The Map That Matched

*SS · Investigation · the Broken Streets · giver Scholar Tobias Wickham*

**The short version.** For thirty years scholars have argued over the dark marks on the red moon's face. Tobias has been sent a map of those marks, drawn from the surface by a patient hand. It matches, street for street, a city that appears on no map of the world. He asks the player to walk one street and see.

**What is really going on.** *Nothing is explained.* The street is real, and has a bakery, a well and a school. The map names them. A name on the map matches a name on a door. Whether the city was ever on the world below, or only looked down on it, is not said.

**Scene 1: the way-camp.**

**TOBIAS:** "I have the map. I have the marks. I have a pencil, and I am afraid of it."
**TOBIAS:** "Look. This line is a street. This one a square. This, a well."
*He lays the map over a star-chart of the moon. The lines fit as a glove fits a hand.*
**TOBIAS:** "And here: *a school.* Someone wrote *school.*"
> ► **"Who drew the map?"** — **TOBIAS:** "A child, I think. In a village. A hundred years ago."
> ► **"What do you want me to do?"** — **TOBIAS:** "Walk Willow Row. Find the school. Tell me if it is there."
> ► **"Is this proof of something?"** — **TOBIAS:** "Proof of a coincidence, if I'm lucky."

**Scene 2: Willow Row.** A long, silent street of broken houses under a black sky. Red dust drifts at ankle height. Doors hang open. At the end of the street a low building stands with its roof gone, a bell-rope hanging from a stub of beam, and a faded board above its door.

*(Gameplay: a quiet walk; vesperites drift at a distance and do not approach unless the player draws a weapon.)*

**JOURNAL (auto):** *The board says SCHOOL. It is carved, not painted. The letters are the same hand as the map's.*
> ► **(Touch the board.)** — The wood is faintly warm.
> ► **(Pull the bell-rope.)** — A single, very small bell rings from somewhere inside the stone.
> ► **(Copy the lettering.)** — The hand is clean, careful, and young.

**Scene 3: the report.** Back at the camp, Tobias lays the copy beside the map.

**TOBIAS:** "Same hand. Same word. Same street."
**TOBIAS:** "I should be thrilled. I am only sad."
> ► **"What would you ask the mapmaker?"** — **TOBIAS:** "How they knew. And whether they were afraid."
> ► **"It could be a coincidence."** — **TOBIAS:** "A coincidence with a bell-rope."
> ► **"Publish it."** — **TOBIAS:** "I will. With a great many question marks."

**Scene 4: the school.** That night Tobias walks to the edge of the camp and looks up at the red disc.

**TOBIAS:** "A school. For children."
**TOBIAS:** "And no one has ever said whose."

**Scene 5: the lesson.** Before the player leaves, Tobias gives them a child's slate he found by the school door, with a single line of sums on it, half-finished.

**TOBIAS:** "Someone stopped at seven times eight."
> ► **"Fifty-six."** — **TOBIAS:** "Yes. I wrote it. In pencil. I hope that is not rude."
> ► **"Leave it unfinished."** — **TOBIAS:** "Perhaps. Some lessons wait."
> ► **"I will keep it."** — **TOBIAS:** "Then it has a pupil again."

**Outcomes and receipt.**
- Tobias publishes with the player's name beside his; the scholars' argument ends and a larger one begins.
- **Receipt:** a child's slate in the Journal relic page (cosmetic), with a line of sums.
- **Canon-safe:** pure seed. The city's builders, its relation to the surface and the red moon's colour are not explained.

<!-- quest
id: qst_ves_map_matched
title: The Map That Matched
rank: SS
type: Investigation
giver: npc_tobias_wickham
region: reg_vesper
level: 208
act: 6
requires_rank: SS
reward: 130000 | 6000 | 700000
sets: ves_map_matched_done
summary: A scholar's map of the red moon's marks matches a city on no map of the world, and he asks the player to walk one street to see whether the school exists.
objectives:
  talk npc_tobias_wickham
  reach ves_willow_row_school
  choice touch_ring_or_copy
-->

---

## 2. The One Who Followed

*SS · Escort · the Broken Streets · giver Sorrel*

**The short version.** Years ago a vesperite followed an adventurer to the surface and was frightened by it. It came back. It has now returned to the ruins to find someone whose name it has only half heard. It asks the player to go with it, because it is afraid of the shadows.

**What is really going on.** Sorrel is gentle and slow of speech, and the person it seeks does not appear. At the end of the street, the player and Sorrel find the person's name carved on a door, and a second name beneath it that Sorrel recognises as its own.

**Scene 1: the way-camp.** A soft, rose-gold figure stands at the camp's edge, human in outline, with a face like a lamp seen through frosted glass.

**SORREL:** "I am Sorrel. I have been looking."
**SORREL:** "There was a woman. She smelled of rain. She sang. I followed her to a cold place and I was afraid."
**SORREL:** "I do not remember her name. I remember the sound of it."
> ► **"What was the sound?"** — **SORREL:** "Like a bell, put down gently."
> ► **"Why come back?"** — **SORREL:** "Because it is where I was made."
> ► **"I'll go with you."** — **SORREL:** "Thank you. The shadows frighten me."

**Scene 2: the streets.** They walk through a district of low, wide houses, the dust faintly luminous around Sorrel's feet. Shadows slide along the walls; twice the player must step between Sorrel and something long and thin that withdraws without attacking.

*(Gameplay: escort through ruins; shadows test but do not hunt the player unless attacked.)*

**SORREL:** "She walked here, I think."
**SORREL:** "There was a door with a blue edge."
> ► **(Look for the blue door.)** — A door with a thread of blue paint stands half-open.
> ► **(Ask Sorrel to hum the sound.)** — Three notes, bell-like.
> ► **(Keep walking and say nothing.)** — Sorrel presses closer.

**Scene 3: the door.** On the blue door a plate is carved: *Ilse and Wren Marrowby.* Beneath it, in smaller, more recent letters: *and Sorrel.*

**SORREL:** "...I did not write that."
**SORREL:** "I do not remember writing it."
> ► **"Perhaps someone wrote it for you."** — **SORREL:** "Who?"
> ► **"It is your name."** — **SORREL:** "It is a name. It fits."
> ► **"We can leave it."** — **SORREL:** "No. I want to stay a while."

**Scene 4: the sitting.** Sorrel sits on the step of the blue door and glows a little brighter.

**SORREL:** "I think I was a child here. Or a friend of one."
**SORREL:** "I do not know. But I think I was loved."

**Scene 5: the walk back.** On the way, Sorrel asks for one last favour.

**SORREL:** "If you see the woman who smelled of rain, tell her I came home."
> ► **"I will."** — **SORREL:** "Thank you."
> ► **"Perhaps she will find you."** — **SORREL:** "Perhaps."
> ► **"I cannot promise."** — **SORREL:** "That is honest. I like it."

**Outcomes and receipt.**
- Sorrel stays near the blue door and hums in the evenings. If the player promised to carry the message, a later scene shows a letter left for a woman at Aldmere's rain-gate.
- **Receipt:** a small blue chip of paint from the door-edge (cosmetic).
- **Canon-safe:** Sorrel's origin, the names on the door and the "woman who smelled of rain" are not explained.

<!-- quest
id: qst_ves_one_followed
title: The One Who Followed
rank: SS
type: Escort
giver: npc_sorrel_vesperite
region: reg_vesper
level: 214
act: 6
requires_rank: SS
reward: 135000 | 6000 | 710000
sets: ves_one_followed_done
summary: A vesperite that once followed an adventurer to the surface asks the player to help it find the person whose name it half remembers.
objectives:
  talk npc_sorrel_vesperite
  escort npc_sorrel_vesperite
  choice blue_door_hum_or_walk
-->

---

## 3. The Song of the Red Flowers

*SS · Investigation · the Broken Streets and Aldmere · giver Hester Lamm*

**The short version.** In the ruins, flowers of red light open and sing a slow, wordless tune. An old woman in Aldmere heard a song-crystal of it and stopped in the middle of the market. It is, she says, the lullaby her grandmother sang. She wants to know where her grandmother learned it.

**What is really going on.** *Nothing is explained.* The player carries Hester's own humming to the flowers, and the flowers sing the second half, which Hester has never known. She weeps, and does not ask what it means.

**Scene 1: Aldmere.** A small house on a crooked lane, a kettle, a cat.

**HESTER:** "My grandmother sang this to my mother. Every night. Not a word in it."
*She hums, thin and sweet, a falling line of seven notes.*
**HESTER:** "A young bard played me a song-crystal. The flowers on the moon. They sang *this.*"
**HESTER:** "I should like to know why."
> ► **"Where did your grandmother learn it?"** — **HESTER:** "She said, *from her mother.* Nobody ever said further."
> ► **"What do you want me to do?"** — **HESTER:** "Carry my humming. Sing it to the flowers."
> ► **"Is it dangerous?"** — **HESTER:** "At my age? I should hope so."

**Scene 2: the garden of light.** In a courtyard of broken columns, flowers of red light open slowly, their petals fine as breath. The player hums Hester's seven notes. The flowers brighten, and sing them back. Then, softly, they sing a *further* line of five notes that Hester's version has never had.

*(Gameplay: stand in the garden and hum; the player may record the answer by ear.)*

**JOURNAL (auto):** *Seven notes, then five. The five feel like a door closing gently.*
> ► **(Hum the new five back.)** — The flowers hold the last note for a long breath.
> ► **(Only listen, and write it down.)** — The petals settle.
> ► **(Pick a flower.)** — Its light goes out in your hand.

**Scene 3: the kitchen.** Back in Aldmere, the player hums the five notes. Hester sits very still.

**HESTER:** "...Oh."
**HESTER:** "She *did* sing that. Right at the end. When I was almost asleep."
**HESTER:** "I thought I had dreamed it."
> ► **"Do you know what it means?"** — **HESTER:** "No. And I find I don't need to."
> ► **"Should we sing it together?"** — **HESTER:** "Yes."
> ► **"Perhaps your grandmother's grandmother came from further than you know."** — **HESTER:** "Perhaps. I'll not ask."

**Scene 4: the full song.** Hester sings all twelve notes, thin and true, and the cat stops washing.

**Scene 5: the window.** Hester leans on the sill and looks up at the red disc, not afraid.

**HESTER:** "It never frightened me, you know. Only I was told it should."
> ► **"What did it feel like?"** — **HESTER:** "Like someone leaving a light on."
> ► **"Do you want to go there?"** — **HESTER:** "At ninety? I'll send you."
> ► **"Perhaps it was always singing."** — **HESTER:** "I'd like that to be true."

**Outcomes and receipt.**
- Hester teaches the song to her neighbours' children. If the player picked a flower, it lights again, faintly, at night, on her sill, for a week.
- **Receipt:** twelve notes of a lullaby in the Journal music page; no source.
- **Canon-safe:** pure seed. Why a surface lullaby matches the flowers, and how, is never explained.

<!-- quest
id: qst_ves_red_flowers_song
title: The Song of the Red Flowers
rank: SS
type: Investigation
giver: npc_hester_lamm
region: reg_vesper
level: 220
act: 6
requires_rank: SS
reward: 140000 | 6200 | 730000
sets: ves_red_flowers_done
summary: An old woman in Aldmere recognises the song of the red moon's flowers as her grandmother's lullaby, and the player carries her humming to them.
objectives:
  talk npc_hester_lamm
  reach ves_garden_of_light
  choice hum_listen_or_pick
-->

---

## 4. Names on the Doors

*SS · OddJob · the Broken Streets · giver Cador Fell*

**The short version.** Cador has copied nine hundred name-plates from the doors of the Broken Streets into a ledger. He has two hundred to go and a bad ankle. He is certain that someone, someday, will come looking for one of these names, and wants them waiting.

**What is really going on.** The plates are ordinary, dull and affecting: *Tam Ferrier, cooper. Mother Ade. The Quill and Lamp.* The player helps copy the last two hundred, and one plate is blank, with a hook for a lamp beside it.

**Scene 1: the way-camp.**

**CADOR:** "Nine hundred. I copy them in the morning, before the dust rises."
**CADOR:** "I don't know what they're for. But names are the first thing to go."
> ► **"Who will read them?"** — **CADOR:** "Someone. I've the patience for it."
> ► **"What do you need?"** — **CADOR:** "Two hands, a steady eye, and the sense to stop for tea."
> ► **"I'll help."** — **CADOR:** "Bring a stool."

**Scene 2: the street of plates.** Row on row of narrow doors, each with a small iron plate. The player copies as Cador reads: *Pell and Daughters. The Grey Goose. Widow Marre.* A vesperite drifts up and watches them quietly, then, to the player's surprise, hands over a plate that had fallen from its door.

*(Gameplay: a repetitive, calming copying minigame; vesperites assist rather than threaten.)*

**CADOR:** "Yes, that one. Number seven-eighty."
> ► **(Copy exactly, with the spelling as-is.)** — Cador nods, pleased.
> ► **(Correct a faded letter from context.)** — Cador frowns, then shrugs.
> ► **(Leave a faded plate uncopied.)** — Cador writes *illegible* with unusual gentleness.

**Scene 3: the blank.** On the last street, a plate has no name, only a hook beside it.

**CADOR:** "I've seen it before. A blank. With a hook."
**CADOR:** "Perhaps someone ran out of time."
> ► **"Write a name on it."** — **CADOR:** "Whose?"
> ► **"Leave it blank."** — **CADOR:** "I would. A blank is a kind of name."
> ► **"Hang a lantern."** — **CADOR:** "...Yes."

**Scene 4: the ledger.** Cador writes the last name and closes the book.

**CADOR:** "Nine hundred and ninety-nine. And a blank."

**Scene 5: the tea.** They drink bad tea from tin cups on the way-camp step.

**CADOR:** "Do you think they're coming back?"
> ► **"Perhaps."** — **CADOR:** "That's enough to copy for."
> ► **"I don't know."** — **CADOR:** "Neither do I. That's why I copy."
> ► **"No."** — **CADOR:** "I'd rather not hear it. But thank you."

**Outcomes and receipt.**
- The ledger is deposited with the guild's archivist, with the player's name as second copyist. If the player hung a lantern, it is lit when they next pass.
- **Receipt:** a page from the ledger, copied in the player's hand.
- **Canon-safe:** the names belong to an unexplained city; no plate names a Canon character, and no dead resident is identified.

<!-- quest
id: qst_ves_names_doors
title: Names on the Doors
rank: SS
type: OddJob
giver: npc_cador_fell
region: reg_vesper
level: 226
act: 6
requires_rank: SS
reward: 140000 | 6200 | 740000
sets: ves_names_doors_done
summary: A delver is copying every name-plate from the doors of the Broken Streets, certain that someone will one day come looking, and needs help with the last two hundred.
objectives:
  talk npc_cador_fell
  reach ves_street_of_plates
  choice exact_correct_or_skip
-->

---

## 5. Across the Floating Quarter

*SS · Escort · the Floating Quarter · giver Pilot Gawen Trelawn*

**The short version.** Part of the old city drifts above the moon in the black sky: arches, towers, a half-roof. Gawen has crossed it eleven times, hopping from stone to drifting stone. He needs a guard for the twelfth, to retrieve a survey marker he left behind.

**What is really going on.** The stones drift on a slow, regular pattern, and Gawen's skill is timing. The marker is on the far arch. The risk is real, and so is Gawen's habit of talking to the stones.

**Scene 1: the launch.**

**GAWEN:** "Eleven crossings. They're mules, the stones. Stubborn and slow, and they'll still kick you."
**GAWEN:** "Twelfth time. I left a marker on the Archway. Surveyors get touchy about their markers."
> ► **"What do I do?"** — **GAWEN:** "Step when I say. Not before."
> ► **"What if I fall?"** — **GAWEN:** "There is a lot of sky."
> ► **"Is it worth it?"** — **GAWEN:** "To a surveyor, yes."

**Scene 2: the stones.** The player and Gawen step off the way-camp platform onto the first stone, a slab the size of a cart, drifting very slowly. Beyond it, others, spaced across a gulf of stars. Low gravity makes every step a long glide.

*(Gameplay: timed jumps across moving platforms; shadows and construct sentries may patrol the larger fragments.)*

**GAWEN:** "Now."
**GAWEN:** "...Not yet. *Now.*"
> ► **(Jump on his word.)** — Clean landing.
> ► **(Wait one beat longer.)** — The gap widens, and Gawen hisses.
> ► **(Jump early.)** — A scramble, a grab, a laugh.

**Scene 3: the Archway.** On the far arch, the marker stands, a brass pole with a red ribbon, quite undisturbed. Beyond it, in a ruined room, is a table laid for six, plates and cups and a vase of dried flowers, all under a film of red dust.

**GAWEN:** "I never go in. It feels rude."
> ► **"Enter quietly."** — The room is still.
> ► **"Close the door."** — Gawen smiles faintly.
> ► **"Take the marker and go."** — **GAWEN:** "Aye. That's what I came for."

**Scene 4: the return.** They glide home across the stones, the marker under Gawen's arm.

**GAWEN:** "Twelve."
**GAWEN:** "I'll give them names, next time. They're past being just stones."

**Scene 5: the platform.** Back at the camp he pats the platform's edge.

**GAWEN:** "Good mules."
> ► **"Thank you for taking me."** — **GAWEN:** "Thank you for not falling."
> ► **"Will you go again?"** — **GAWEN:** "Until the stones stop."
> ► **"What was the table for?"** — **GAWEN:** "I never ask."

**Outcomes and receipt.**
- Gawen retrieves the marker and adds the player's name to his log. If the player entered the dining room, a later scene mentions a sixth plate that was washed, once, by hand.
- **Receipt:** a brass marker pole with a red ribbon (cosmetic).
- **Canon-safe:** the table and its dust are unexplained; no inhabitants are shown.

<!-- quest
id: qst_ves_floating_quarter
title: Across the Floating Quarter
rank: SS
type: Escort
giver: npc_gawen_trelawn
region: reg_vesper
level: 232
act: 6
requires_rank: SS
reward: 145000 | 6400 | 760000
sets: ves_floating_quarter_done
summary: A pilot who talks to the drifting stones needs a guard for his twelfth crossing of the Floating Quarter, to retrieve a surveyor's marker.
objectives:
  talk npc_gawen_trelawn
  escort npc_gawen_trelawn
  choice enter_close_or_marker
-->

---

## 6. Three Words for the Moon

*SS · Faction · the way-camp · giver Priest Petronel Voss*

**The short version.** Petronel has come to the way-camp to see, with his own eyes, the moon he has preached about for twenty years. On the same day arrive an elf who calls it a wound and a Lustrine fisher who calls it a thief of light. Each wants to be right. The camp is small, and the three have only one fire.

**What is really going on.** Each faith's word is a way of being afraid. The player is asked to sit with them and help them say what each is truly afraid of, without deciding who is right.

**Scene 1: the fire.**

**PETRONEL:** "An omen. That is what I have said. Twenty years, from a pulpit."
**ELF (Linnea):** "A wound. In the sky. Bleeding light."
**FISHER (Bellamy Crow):** "A thief. It took our shallow fish. It took the pearl-glow."
**PETRONEL:** "We are, I think, a little *loud.*"
> ► **"What is each of you afraid of?"** — The three look at the fire.
> ► **"Perhaps you are all describing the same fear."** — **LINNEA:** "That is annoying."
> ► **"Let the fire be quiet a minute."** — A hush.

**Scene 2: the confessions.** One at a time they speak.

**PETRONEL:** "I'm afraid I have lied to my flock for twenty years, by sounding certain."
**LINNEA:** "I'm afraid it is *ours.* That we did something, long ago, and forgot."
**BELLAMY:** "I'm afraid for my daughters. Their nets come up empty."
*(Gameplay: dialogue only; the player picks whom to speak to next.)*
> ► **(Speak to Petronel.)** — He nods, and says nothing.
> ► **(Speak to Linnea.)** — She looks away.
> ► **(Speak to Bellamy.)** — He grips his cap.

**Scene 3: the three words.** The player suggests each give the moon a new word, one they can say without a creed.

**PETRONEL:** "Mine is: *unknown.*"
**LINNEA:** "Mine is: *old.*"
**BELLAMY:** "Mine is: *far.*"
> ► **"Those are true."** — The three nod.
> ► **"Those are small."** — **BELLAMY:** "Small is what I can carry."
> ► **"Keep them."** — **PETRONEL:** "I shall put them in my next sermon."

**Scene 4: the fire.** They add wood together, and watch the sparks rise.

**Scene 5: the departure.** Three travellers leave in three directions at dawn, each looking back once.

**LINNEA:** "I did not agree with either of them."
**LINNEA:** "I liked them both."
> ► **"That is enough."** — **LINNEA:** "It is a great deal."
> ► **"Will you meet again?"** — **BELLAMY:** "We'll write."
> ► **"Safe road."** — **PETRONEL:** "And a quiet sky."

**Outcomes and receipt.**
- The three leave without a settled answer. The player may add a fourth word, which Petronel records in the margin of his prayer-book.
- **Receipt:** three words on a slip: *unknown, old, far.*
- **Canon-safe:** all three faiths stand; none is confirmed.

<!-- quest
id: qst_ves_three_words
title: Three Words for the Moon
rank: SS
type: Faction
giver: npc_petronel_voss
region: reg_vesper
level: 238
act: 6
requires_rank: SS
reward: 150000 | 6500 | 780000
sets: ves_three_words_done
summary: A priest, an elf and a Lustrine fisher meet at the way-camp, each with a different word for the moon, and the player helps them say what each truly fears.
objectives:
  talk npc_petronel_voss
  reach ves_way_camp_fire
  choice petronel_linnea_or_bellamy
-->

---

## 7. The Baker Who Is Not There

*SS · Hidden · the Broken Streets · giver Wilmot Crane*

**The short version.** In the Broken Streets a ghost opens a bakery every dawn, sets out loaves that are not there and greets customers who do not come. The player may be the first customer in a very long time. Wilmot asks only that they buy a loaf.

**What is really going on.** *Nothing is explained.* The loaves are invisible, but the smell is real. The player buys one with a coin from the surface. The coin, afterwards, is found in the shop's till, which is not there either.

**Scene 1: the shop.** A shopfront, half a wall, a door-frame with no door. A round, floury ghost in an apron stands behind a counter that is not quite there.

**WILMOT:** "Good morning! We have rye, we have white, we have a plum bun."
**WILMOT:** "I'm afraid the rye is a little late."
> ► **"I'll take a loaf."** — **WILMOT:** "Wonderful! A coin, if you please."
> ► **"Are you all right?"** — **WILMOT:** "Never better. Mornings are busy."
> ► **"What day is it?"** — **WILMOT:** "Market day. Always market day."

**Scene 2: the purchase.** The player counts out a coin. It lands in the empty air and rings faintly, as on a counter. A warm, yeasty smell fills the street.

*(Gameplay: a gentle interaction; no enemies; vesperites watch from a distance.)*

**WILMOT:** "That's a good one. Heavy."
**WILMOT:** "And would you like it wrapped?"
> ► **(Accept an imaginary loaf.)** — The player holds a smell like bread.
> ► **(Ask him if anyone else comes.)** — **WILMOT:** "Oh, now and then. Mostly the Pell girls."
> ► **(Tell him the truth.)** — **WILMOT:** "...I know, dear. But it's *nice* to be asked."

**Scene 3: the plum bun.** Wilmot, with great ceremony, offers a plum bun on the house.

**WILMOT:** "For the traveller. It's a long way up."
> ► **"Thank you."** — The scent of plum rises.
> ► **"Save it for the Pell girls."** — **WILMOT:** "You are kind."
> ► **"Eat it with me."** — **WILMOT:** "I would love that."

**Scene 4: the till.** As the player leaves, Wilmot opens his empty till, and the player's coin is lying in it, warm.

**WILMOT:** "There. Safely put away."

**Scene 5: the evening.** Dusk is falling. Wilmot flips the sign he does not have, and sighs.

**WILMOT:** "Another day. Thank you for coming."
> ► **"I'll come back."** — **WILMOT:** "I'll bake extra."
> ► **"Rest now."** — **WILMOT:** "Tomorrow's market day."
> ► **"Do you remember who you are?"** — **WILMOT:** "A baker. What else is there?"

**Outcomes and receipt.**
- Wilmot is gone each dusk and back each dawn. If the player shared the bun, the next dawn the street smells faintly of plum for an hour.
- **Receipt:** a coin, warm, in the player's pocket, though they gave it away.
- **Canon-safe:** Wilmot's history, the shop's persistence and the Pell girls are not explained.

<!-- quest
id: qst_ves_baker_not_there
title: The Baker Who Is Not There
rank: SS
type: Hidden
giver: npc_wilmot_crane
region: reg_vesper
level: 242
act: 6
requires_rank: SS
reward: 150000 | 6500 | 790000
sets: ves_baker_done
summary: A ghost opens a bakery in the Broken Streets every dawn for customers who do not come, and asks the first visitor in an age to buy a loaf.
objectives:
  talk npc_wilmot_crane
  reach ves_baker_shopfront
  choice buy_ask_or_truth
-->

---

## 8. The Edge of the Light

*SS · Exploration · the approach to the Red Heart · giver Cartographer Dessa Orrin*

**The short version.** Dessa has mapped every approach to the Red Heart to the last inch. At the last inch, every time she redraws her map, the line ends straight. She asks the player to walk it with her and see whether her hand or the ground is making it so.

**What is really going on.** *Nothing is explained.* At the edge, the light grows too bright to look into. The ground does not end. The player may go no further because, at that point, the light asks politely to be left alone. Dessa draws it as it is.

**Scene 1: the way-camp.**

**DESSA:** "Twelve maps. Twelve straight lines."
**DESSA:** "I thought it was fatigue. I thought it was a habit of the hand."
**DESSA:** "Come and tell me it isn't."
> ► **"What do you want me to do?"** — **DESSA:** "Walk the last mile with me. Say what you see."
> ► **"What if it is the ground?"** — **DESSA:** "Then the ground is drawing itself, and that is worse."
> ► **"I'll come."** — **DESSA:** "Bring dark glasses."

**Scene 2: the approach.** The way narrows between shattered columns, dust glowing faintly rose. The light ahead grows without source, as if the air itself were thinning to brightness. Shadows keep their distance. A vesperite stands motionless at the roadside, head bowed.

*(Gameplay: a long, quiet walk; no enemies; the player's screen warms to red-gold.)*

**DESSA:** "Here. This is where the line goes straight."
*The road runs on, perfectly clear, for as far as can be seen. But the player feels, with the clarity of a held breath, that this is where they should stop.*
> ► **(Stop at the line.)** — The light does not change.
> ► **(Take one step past.)** — The light softens, and the step feels like intruding.
> ► **(Call out.)** — Nothing answers, but the air seems to listen.

**Scene 3: the map.** Dessa unrolls her paper on a flat stone and draws, slowly.

**DESSA:** "I'll draw it as it is. A road, a light, and a place I did not go."
> ► **"Draw the line straight."** — **DESSA:** "That's honest."
> ► **"Draw it curving on."** — **DESSA:** "That is invention."
> ► **"Leave it blank."** — **DESSA:** "...Yes. That's the truest."

**Scene 4: the return.** Behind them, the light dims only as they walk away, as a host dims a lamp for departing guests.

**Scene 5: the map room.** Back at the camp, Dessa pins the new map above the old twelve.

**DESSA:** "Thirteen."
**DESSA:** "The first that I believe."
> ► **"What will you do with it?"** — **DESSA:** "Send it. Without commentary."
> ► **"Will anyone go further?"** — **DESSA:** "Perhaps. Not by my map."
> ► **"What do you think is there?"** — **DESSA:** "I think someone is expected."

**Outcomes and receipt.**
- The guild receives a map with a clear road and a blank. If the player stepped past the line, a faint warmth clings to their boots for a day.
- **Receipt:** a map fragment: a road, a light, a blank.
- **Canon-safe:** pure seed. The Red Heart and what waits there are not described or explained.

<!-- quest
id: qst_ves_edge_light
title: The Edge of the Light
rank: SS
type: Exploration
giver: npc_dessa_orrin
region: reg_vesper
level: 246
act: 6
requires_rank: SS
reward: 155000 | 6600 | 800000
sets: ves_edge_light_done
summary: A cartographer's maps of the Red Heart approach always end in a straight line. She asks the player to walk the last mile and say whether it is her hand or the ground.
objectives:
  talk npc_dessa_orrin
  reach ves_edge_of_light
  choice stop_step_or_call
-->

---

## 9. A Mother's Lantern

*SS · Investigation · the Broken Streets · giver Margit Sallow*

**The short version.** Margit's son Brin took her lantern with him on his last expedition and never returned. She has walked to the way-camp, with the lantern's twin. She does not hope to find him. She hopes to find a sign that he was here.

**What is really going on.** *Nothing is explained.* The player finds Brin's chalk mark on a lintel, a small lantern and a date, and below it a second mark, in different chalk, a small hand. Nobody knows whose.

**Scene 1: the way-camp.**

**MARGIT:** "He was twenty-six. He laughed at the lamp. *You'll be fine, Mum,* he said, *I'll take the old one.*"
**MARGIT:** "I have the other. They were a pair."
*She lifts a small brass lantern. It glows faintly, as though something far away were answering it.*
> ► **"It's lit."** — **MARGIT:** "It lit itself. At the foot of the stair."
> ► **"Do you want me to find him?"** — **MARGIT:** "No. A sign. Just a sign."
> ► **"I'll look."** — **MARGIT:** "Thank you. Be gentle with the dust."

**Scene 2: the lintel.** The twin lantern pulls, very gently, in the player's hand, toward a ruined archway. On the lintel, a small chalk drawing: a lantern and a date, in Brin's cheerful, crooked hand. Beneath it, in a different chalk, fresher, a small open hand.

*(Gameplay: a guided walk led by the lantern's warmth; no combat unless provoked.)*

**JOURNAL (auto):** *The date is eleven days after his last letter. The hand is smaller than any adult's.*
> ► **(Copy the marks.)** — The chalk comes off on the player's fingers.
> ► **(Place your own mark beneath.)** — The chalk does not smear.
> ► **(Leave the lintel as it is.)** — The lantern's glow steadies.

**Scene 3: the report.** Margit listens with her hand over her mouth.

**MARGIT:** "Eleven days after. He was *alive.*"
**MARGIT:** "And someone drew a hand beside him."
> ► **"Perhaps a friend."** — **MARGIT:** "I'd like that."
> ► **"I don't know whose hand it is."** — **MARGIT:** "No. But it is a kind one."
> ► **"I'm sorry I found no more."** — **MARGIT:** "You found all I asked."

**Scene 4: the lantern.** She hangs the twin lantern at the way-camp's edge, and the small lamp in it burns steady.

**MARGIT:** "Both lit. That's how it should be."

**Scene 5: the leaving.** She gives the player a cup of tea and a handful of boiled sweets.

**MARGIT:** "He always wanted sweets on the road."
> ► **"Thank you."** — **MARGIT:** "Go carefully."
> ► **"May I copy the mark for you?"** — **MARGIT:** "Please."
> ► **"I'll look again."** — **MARGIT:** "Not on my account."

**Outcomes and receipt.**
- Margit stays at the way-camp a season, keeping the lantern. If the player added a mark beneath the others, she sets her own beside it before she leaves.
- **Receipt:** a chalk rubbing of a lantern, a date and a small hand.
- **Canon-safe:** Brin's fate, the second hand and the lantern's glow are not explained.

<!-- quest
id: qst_ves_mothers_lantern
title: A Mother's Lantern
rank: SS
type: Investigation
giver: npc_margit_sallow
region: reg_vesper
level: 250
act: 6
requires_rank: SS
reward: 160000 | 6800 | 820000
sets: ves_mothers_lantern_done
summary: A mother who walked to the way-camp with her missing son's lantern twin asks the player to find a sign that he was here.
objectives:
  talk npc_margit_sallow
  reach ves_chalk_lintel
  choice copy_mark_or_leave
-->

---

## 10. The White Moon

*SS · Hidden · the way-camp · giver Historian Thaddeus Nole*

**The short version.** Thaddeus has spent a decade collecting what people remember of the moon's colour. No two accounts agree. Today he asks the player the only question he has left: *what do you remember?*

**What is really going on.** *Nothing is explained.* The quest does not tell the player whether the moon was ever white. It records the player's answer, and Thaddeus, after a long silence, writes it down without comment.

**Scene 1: the historian's tent.** Crates of notebooks, a lantern, a battered table with a hundred slips of paper.

**THADDEUS:** "Silver, said a sailor. White, said a nun. Gold, said a child."
**THADDEUS:** "Red, say the scholars, and always have."
**THADDEUS:** "I have nine hundred answers. None agrees."
> ► **"Why does it matter?"** — **THADDEUS:** "Because everyone is sure."
> ► **"What are you looking for?"** — **THADDEUS:** "A pattern. Or a gap in one."
> ► **"What do you want from me?"** — **THADDEUS:** "Your memory. Honestly."

**Scene 2: the question.** He sets a blank slip on the table.

**THADDEUS:** "Close your eyes. Think of the moon when you were small."
*(Gameplay: the player chooses what they remember; each answer is accepted.)*
> ► **(Say: "Red, as always.")** — He writes *red.*
> ► **(Say: "White, I think.")** — He writes *white,* and underlines nothing.
> ► **(Say: "I do not remember.")** — He writes *no memory,* and smiles.

**Scene 3: the reaction.** Thaddeus reads his slip, then lays it among the others.

**THADDEUS:** "Nine hundred and one."
**THADDEUS:** "And not one of us can say why we are certain."
> ► **"Does it frighten you?"** — **THADDEUS:** "It would, if I let it."
> ► **"Maybe it doesn't matter."** — **THADDEUS:** "It always matters. It just may not be answerable."
> ► **"Keep collecting."** — **THADDEUS:** "That, I can promise."

**Scene 4: the sky.** He steps outside and looks up.

**THADDEUS:** "When I was a boy, I thought the moon was a lantern someone forgot to put out."
**THADDEUS:** "I still think that, a little."

**Scene 5: the tent flap.** Before the player leaves, he presses a slip into their hand.

**THADDEUS:** "Your answer. In your own hand. If you change your mind, change it."
> ► **"Thank you."** — **THADDEUS:** "Thank *you.*"
> ► **"What if I never change it?"** — **THADDEUS:** "Then it is yours."
> ► **"Will you ever finish?"** — **THADDEUS:** "I hope not."

**Outcomes and receipt.**
- Thaddeus's collection reaches nine hundred and one. The player's slip is the only one that could be added to or amended later.
- **Receipt:** a slip of paper with the player's own answer, in their own words, in the Journal.
- **Canon-safe:** pure seed. The moon's original colour and why the surface "remembers it red" are not stated.

<!-- quest
id: qst_ves_white_moon
title: The White Moon
rank: SS
type: Hidden
giver: npc_thaddeus_nole
region: reg_vesper
level: 256
act: 6
requires_rank: SS
reward: 165000 | 7000 | 840000
sets: ves_white_moon_done
summary: A historian has nine hundred contradictory memories of the moon's colour, and asks the player the only question he has left.
objectives:
  talk npc_thaddeus_nole
  reach ves_historian_tent
  choice red_white_or_none
-->
