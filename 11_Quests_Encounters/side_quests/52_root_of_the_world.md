# 11e-52 — Root of the World, Where the World Is Held: Ten Side Quests (draft)

> *"The gods knelt here to weave. Nobody asks what they were weaving on."*
> — Pilgrim's saying, Root of the World

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 2, 3, 9 and 10 plant unexplained seeds.

**Region:** `reg_root_of_the_world` (the Kneeling Stones, the Cracked Root, the Crystal Bridges, the floating islands of earth). **Rank band:** SS–EX. **Tone:** vast, reverent, quiet; small human errands against enormous silence.

**Placement notes.**
- **Nobody lives at the Root** and there is no Tyrant or siege (`noSiege: true`). The NPCs below are *visitors, pilgrims and their surface-side senders,* who give their quests at the guild's Root Landing, a rope-and-lantern way-station at the top of the final stair, or on the surface. No quest damages a root, explains the Root, or answers what the gods wove.
- Customs the quests rely on: pilgrims **take off their boots** at the Landing; nobody **cuts, scrapes or takes** anything from the roots; visitors speak softly and name no god; the Church, the elves and the dwarves each tell their own story of the Root, and the quests let all three stand. The monster families here are elementals, aberrations, plants, constructs, draconic and slimes only.
- **Rank note.** The region band is SS–EX, but the quest `rank` enum tops out at SSS and the guild table has no EX row, so every quest here is **SS** (levels 206-259 per `Data/World/guild_ranks.json`). **All SS rewards are first-pass** and extrapolated from the promotion table (SS: GP 6,000 first-pass); please approve or replace.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Shard That Grew | SS | Investigation | Sister Lioba Wren | A relic in a treasury |
| 2 | Someone Weeping | SS | Investigation | Cass Thornby | A voice inside a root |
| 3 | What the Slime Saw | SS | Hidden | Gloam | A very old witness |
| 4 | The Bridge Mapper | SS | Escort | Rook Ellery | Walking on glass over nothing |
| 5 | Three Stories, One Stone | SS | Faction | Pilgrim-Priest Ketil Anvard | Three faiths at one hollow |
| 6 | Take Nothing | SS | OddJob | Isaure Venn | A druid who wants a cutting |
| 7 | A Letter for the Landing | SS | Delivery | Pernel Gray | A dead friend's last page |
| 8 | The Old One Who Forgot | SS | Companion | Davos Quenby | Returning a name |
| 9 | The Word the Gate Wants | SS | Exploration | Imke Sorrowby | A lost password, a patient guardian |
| 10 | The Second Kneeling | SS | Hidden | Archivist Odalys Reik | Two hollows, one warm |

## Cast

<!-- npc
id: npc_lioba_wren
name: Sister Lioba Wren
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Church reliquarian
backstory: A careful, soft-voiced sister who tends the shard of root-light in the Church treasury and who has noticed, with a jeweller's eye, that its glow reaches a little further each spring.
-->
<!-- npc
id: npc_cass_thornby
name: Cass Thornby
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Adventurer who heard weeping
backstory: A cheerful, scarred ranger who has reached the Root three times and who swears, quietly and without drama, that the third time she heard someone weeping inside the Cracked Root.
-->
<!-- npc
id: npc_gloam_slime
name: Gloam
tier: major
race: Slime
region: reg_root_of_the_world
settlement: The Crystal Bridges
role: Ancient slime that learned to speak
backstory: A vast, patient slime the colour of old glass that has drifted among the roots for longer than there have been records, and that has recently learned enough words to want to be heard.
-->
<!-- npc
id: npc_rook_ellery
name: Rook Ellery
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Bridge mapper
backstory: A lean, wry mapper who has charted forty of the Crystal Bridges for the guild and who speaks to each one by name before stepping onto it.
-->
<!-- npc
id: npc_ketil_anvard
name: Pilgrim-Priest Ketil Anvard
tier: major
race: Dwarf
region: reg_root_of_the_world
settlement: Root Landing
role: Dwarven pilgrim-priest
backstory: A stout, gentle dwarf priest who has walked down a mile of stairs to see the Kneeling Stones, where his people say the first anvil stood, and who has brought two guests of other faiths.
-->
<!-- npc
id: npc_isaure_venn
name: Isaure Venn
tier: major
race: Elf
region: reg_root_of_the_world
settlement: Root Landing
role: Druid who wants a cutting
backstory: A grave, eloquent elf druid whose grove is dying and who has come to ask the Root, with great courtesy, for one small cutting of its light.
-->
<!-- npc
id: npc_pernel_gray
name: Pernel Gray
tier: townsfolk
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Courier for the dead
backstory: A plain, steady courier who carries the last letters of lost adventurers to their families and who has one letter left whose writer lies somewhere beyond the Crystal Bridges.
-->
<!-- npc
id: npc_davos_quenby
name: Davos Quenby
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Scholar of the old dragons
backstory: A quiet, bookish scholar who has traced the ancestry of an elder draconic being at the Root through nine dead languages and believes he has found its name.
-->
<!-- npc
id: npc_imke_sorrowby
name: Imke Sorrowby
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Guild linguist
backstory: A brisk, nearsighted linguist who has transcribed a dozen constructs' commands and who has been refused entry by one bridge-gate for three expeditions because she cannot recall its word.
-->
<!-- npc
id: npc_odalys_reik
name: Archivist Odalys Reik
tier: major
race: Human
region: reg_root_of_the_world
settlement: Root Landing
role: Guild archivist
backstory: A methodical archivist who measures everything and who has, on her last expedition, measured the two Kneeling Stones and been unable to put the numbers away.
-->

---

## 1. The Shard That Grew

*SS · Investigation · the Cracked Root · giver Sister Lioba Wren*

**The short version.** A shard of root-light sits in the Church treasury, brought back a generation ago. Sister Lioba has measured it every spring. This spring it was a hair larger. She asks the player to carry a sealed reading-glass to the Cracked Root and compare the two lights.

**What is really going on.** *Nothing is explained.* The two lights match, but the Root's light has a slow pulse and the shard's pulse, when Lioba's glass is held up to the Root, has *quickened to match it,* as if they were two clocks set side by side.

**Scene 1: the reliquary.** A cool vault, a silver case, a faint pale glow.

**LIOBA:** "It's the size of a plum stone. It was the size of a *pea* when it was brought."
**LIOBA:** "I measure it with this."
*She lifts a brass gauge, graduated in tenths of a hair.*
**LIOBA:** "Every spring, a little more. And I do not know whether to tell the Bishop or to light a candle."
> ► **"What do you want me to do?"** — **LIOBA:** "Hold my glass to the Root's light. Tell me if they agree."
> ► **"Perhaps the glow is only brighter in the spring."** — **LIOBA:** "I thought so. For six years."
> ► **"I will go."** — **LIOBA:** "Take your boots off at the Landing. They will ask."

**Scene 2: the Cracked Root.** At the foot of the split root, light leaks in slow, golden threads. The player holds the glass open. Inside it, a drop of the shard's own light, sealed, has been shivering faintly since the stair. At the root's crack it settles, and then, slowly, begins to *beat,* exactly with the Root.

*(Gameplay: a quiet approach through a bridge-field; no combat unless the player provokes a root-guardian.)*

**JOURNAL (auto):** *Two lights. One heartbeat. I do not know which learned from which.*
> ► **(Record it plainly.)** — The glass dims a little.
> ► **(Hold it closer to the crack.)** — The beat doubles, and the player's fingertips feel warm.
> ► **(Cap the glass and leave.)** — The light settles, reluctantly.

**Scene 3: the vault again.** Lioba sets the glass beside the shard. The two lights pulse together, once, twice, three times.

**LIOBA:** "They *agree.*"
**LIOBA:** "...Oh. I did not want them to."
> ► **"What does it mean?"** — **LIOBA:** "I do not know. Nobody does."
> ► **"Tell the Bishop."** — **LIOBA:** "I will. After I have said a prayer."
> ► **"Keep measuring."** — **LIOBA:** "Every spring. And now, every night."

**Scene 4: the candle.** She closes the case and lights a candle beside it.

**LIOBA:** "Not for fear. For company."
**LIOBA:** "It has been alone in the dark a long time."

**Scene 5: the Bishop's door.** Whichever way the player chose, Lioba lingers at the vault a moment longer than she needs to.

**LIOBA:** "When I took the vows I thought the hard part would be doubt."
**LIOBA:** "It is not doubt. It is *attention.* Once you attend to a thing, you cannot stop."
> ► **"Is that a burden?"** — **LIOBA:** "A kind one."
> ► **"Perhaps the shard wants to be watched."** — **LIOBA:** "A comfortable thought. I will keep it."
> ► **"Rest, Sister."** — **LIOBA:** "After the next reading."
*She closes the case, and the silver catches the candle, and for a heartbeat the shard and the flame beat together.*

**If the player held the glass closer to the crack.** The tips of their fingers keep a faint warmth for three days, and Lioba, noticing, asks to measure that too, with a small and apologetic smile.

**Outcomes and receipt.**
- If the player tells the Bishop, the Church begins a quiet, official watch. If they urge Lioba to keep measuring alone, she keeps the secret and the candle.
- **Receipt:** a pea-sized glass bead in the Journal that pulses once when opened (cosmetic).
- **Canon-safe:** pure seed. The shard's growth, the synchronised beat and the Root's cracks are not explained or linked to any Canon event.

<!-- quest
id: qst_rot_shard_grew
title: The Shard That Grew
rank: SS
type: Investigation
giver: npc_lioba_wren
region: reg_root_of_the_world
level: 208
act: 5
requires_rank: SS
reward: 130000 | 6000 | 700000
sets: rot_shard_grew_done
summary: A Church shard of root-light grows a hair each spring. A sister asks the player to compare it with the Cracked Root.
objectives:
  talk npc_lioba_wren
  reach rot_cracked_root
  choice record_closer_or_leave
-->

---

## 2. Someone Weeping

*SS · Investigation · the Cracked Root · giver Cass Thornby*

**The short version.** On her third trip to the Root, Cass heard someone weeping inside the Cracked Root. She told two people and was laughed at by both. She does not need to be believed; she needs to know whether she was right to leave.

**What is really going on.** *Nothing is explained.* The player listens at the crack. There is a sound: low, patient, very like a person crying quietly so as not to wake a household. It does not stop when the player speaks, and it does not answer.

**Scene 1: the Landing.**

**CASS:** "I've fought wyrms and a thing the size of a barn. I've never been afraid of the dark."
**CASS:** "But I left. I heard somebody weeping, and I *left.*"
**CASS:** "I'd like to know whether I should have stayed."
> ► **"Did it sound human?"** — **CASS:** "It sounded like my sister, the year our mother died."
> ► **"Why come back?"** — **CASS:** "Because it's been three years and I still hear it."
> ► **"I'll listen with you."** — **CASS:** "That's all I wanted."

**Scene 2: the crack.** The Cracked Root rises in the dark like a split tower, light leaking from it in slow gold rivulets. The player and Cass press their palms to the stone. Cold. Then, faintly, through the stone, a long, shuddering breath, and a quiet, steady crying.

*(Gameplay: a quiet, reverent stop; no enemies appear. The player may speak or stay silent.)*

**CASS (whispering):** "That's it. That's the sound."
> ► **(Speak softly: "We are here.")** — The weeping softens, though it does not stop.
> ► **(Ask: "Who is there?")** — Nothing answers, and the light in the crack dims.
> ► **(Stay silent and listen.)** — The sound continues, as if grateful for the company.

**Scene 3: leaving.** They cannot find a way inside, and neither of them will break the root.

**CASS:** "I thought if I came back, I'd find a door."
**CASS:** "There isn't one."
> ► **"You didn't fail it."** — **CASS:** "I'd like to believe that."
> ► **"We can come back."** — **CASS:** "We will."
> ► **"Some things can't be answered."** — **CASS:** "I hate that. And I think it's true."

**Scene 4: the light.** As they climb away, Cass looks back once.

**CASS:** "It stopped. When we left."
**CASS:** "Or it's gone on, and we simply can't hear."

**Scene 5: the stair.** On the long climb back, Cass talks more than she has in three years.

**CASS:** "My sister cried like that. Very quietly. As if she did not want to be a trouble."
**CASS:** "I never told her it was no trouble. I was always busy."
> ► **"Tell her now."** — **CASS:** "I will. When I'm up. Tonight."
> ► **"You are listening now."** — **CASS:** "It is the only thing I seem to be good at."
> ► **"What will you do about the Root?"** — **CASS:** "Come back. Sit. Not fix. Just sit."
*At the top, she takes off her gloves and puts them away, as if finished with a long job.*

**If the player spoke to the root.** On their next visit, the weeping will be softer and, once, there will be a pause in it, as if someone were listening in turn. Cass never learns of it, and the player may choose whether to tell her.

**Outcomes and receipt.**
- Cass thanks the player and says nothing to anyone else. If the player spoke to the root, the weeping is, on later visits, a little quieter.
- **Receipt:** a pressed glove-print in gold dust on the player's Journal page.
- **Canon-safe:** pure seed. Who or what weeps is not stated, and the Cracked Root is not opened.

<!-- quest
id: qst_rot_someone_weeping
title: Someone Weeping
rank: SS
type: Investigation
giver: npc_cass_thornby
region: reg_root_of_the_world
level: 214
act: 5
requires_rank: SS
reward: 135000 | 6000 | 710000
sets: rot_someone_weeping_done
summary: An adventurer heard weeping inside the Cracked Root, was laughed at, and wants someone to listen with her.
objectives:
  talk npc_cass_thornby
  reach rot_cracked_root_crack
  choice speak_ask_or_silent
-->

---

## 3. What the Slime Saw

*SS · Hidden · the Crystal Bridges · giver Gloam*

**The short version.** A vast, very old slime has learned to speak. It has a lot to say and no way of knowing which parts are memory and which are dream. It asks the player to listen to all of it, and to say which parts are worth keeping.

**What is really going on.** *Nothing is explained.* Gloam's account is gentle, rambling, full of slow tides of light and of the sound of a "great loom, patient." It cannot say what it saw. It can say only that it was warm and that someone was humming.

**Scene 1: the bridge.** Under a span of green crystal, a pool of clear jelly the size of a wagon, faintly shining, shifts and rises as the player approaches.

**GLOAM:** "...Hello. I have been practising the word."
**GLOAM:** "I have a great many things to say. Will you hear them?"
> ► **"Of course."** — **GLOAM:** "Then sit. It takes a while."
> ► **"What are you?"** — **GLOAM:** "I am what drank the light for the longest."
> ► **"Why me?"** — **GLOAM:** "You were quiet when you walked."

**Scene 2: the telling.** For an hour, Gloam speaks, in slow, floating phrases. It tells of long dark seasons, of the first hard crystal, of "the day the light first leaned." It speaks of a loom, of hands, of humming. It is sometimes lucid, sometimes only bright noise.

*(Gameplay: a seated dialogue scene; the player chooses what to ask Gloam to repeat.)*

**GLOAM:** "There were hands. Or what I would call hands. Many. Very patient."
**GLOAM:** "They hummed while they worked."
> ► **(Ask it to repeat the humming.)** — Gloam hums three notes, slowly, with a sound like water under ice.
> ► **(Ask what they wove.)** — **GLOAM:** "I did not see. I only saw the thread."
> ► **(Ask nothing; just listen.)** — Gloam is quiet, content.

**Scene 3: the keeping.** At last Gloam grows still.

**GLOAM:** "I do not know which is true. I do not know which is dreaming."
**GLOAM:** "Tell me what to keep."
> ► **"Keep the humming."** — **GLOAM:** "Yes. That, I think, is real."
> ► **"Keep it all."** — **GLOAM:** "That is kind. It is also heavy."
> ► **"Tell it to someone else too."** — **GLOAM:** "I will. If they sit."

**Scene 4: parting.** The slime shifts, brighter, and subsides.

**GLOAM:** "Thank you for the sitting. It has been long since anyone sat."

**Scene 5: the pool.** Before the player leaves, Gloam asks one more thing, very shyly.

**GLOAM:** "Will you tell me a story? I have given you so many."
> ► **(Tell it about the surface.)** — Gloam listens to rain, and bread, and bells, and shines.
> ► **(Tell it about someone you love.)** — Gloam is quiet for a long time.
> ► **(Tell it a joke.)** — The slime wobbles, bewildered, then delighted.
*Whatever is told, Gloam repeats a few words of it, wrongly, with great care.*

**If the player asked about the humming.** Gloam hums the three notes a few more times, and on the third the nearest crystal bridge answers, very softly, in a different key. Neither the player nor Gloam remarks on it.

**Outcomes and receipt.**
- The player's notes are the only record. Whatever the player asked Gloam to keep, it hums to itself on later visits, a little louder.
- **Receipt:** three notes of a hummed tune in the Journal's music page, with no source.
- **Canon-safe:** pure seed. Gloam's memories are labelled unreliable; the loom, the hands and the humming are not identified as the gods or anything else.

<!-- quest
id: qst_rot_slime_saw
title: What the Slime Saw
rank: SS
type: Hidden
giver: npc_gloam_slime
region: reg_root_of_the_world
level: 222
act: 5
requires_rank: SS
reward: 140000 | 6200 | 730000
sets: rot_slime_saw_done
summary: An ancient slime that has learned to speak asks the player to hear all it remembers and say which parts are worth keeping.
objectives:
  talk npc_gloam_slime
  reach rot_crystal_bridge_pool
  choice humming_all_or_share
-->

---

## 4. The Bridge Mapper

*SS · Escort · the Crystal Bridges · giver Rook Ellery*

**The short version.** Rook has charted forty of the Crystal Bridges and speaks to each before stepping on it. He has forty-one to go, and his knees are failing. He needs a guard, a steady hand, and someone who will not laugh when he apologises to a bridge.

**What is really going on.** The bridges are only bridges. But Rook's courtesy is a kind of survival: he has noticed that crystal rings differently under a nervous foot, and that apologising slows his pulse. The player learns to walk the same way.

**Scene 1: the Landing.**

**ROOK:** "Forty bridges. Forty apologies. Not one fall."
**ROOK:** "I say to each: *excuse me. I am only passing.*"
**ROOK:** "Laugh if you like."
> ► **"I won't laugh."** — **ROOK:** "Good. I'd hate to have to push you off one."
> ► **"Does it work?"** — **ROOK:** "I'm still alive."
> ► **"I'll try it."** — **ROOK:** "Quietly. And with feeling."

**Scene 2: the first span.** A thin ribbon of clear crystal over a gulf that has no bottom. Rook murmurs his apology and steps on. The crystal hums, a low, clear note. The player follows, and their own boots add a second, lower note.

*(Gameplay: escort across narrow spans; footing matters; no combat unless a root-guardian wakes.)*

**ROOK:** "Hear that? A chord. That's a good bridge."
> ► **(Say your own apology.)** — The chord steadies.
> ► **(Walk without a word.)** — The note wobbles, and Rook winces.
> ► **(Walk lightly and hum.)** — The bridge answers in harmony.

**Scene 3: the long span.** Halfway across the longest bridge, Rook stops, white-knuckled.

**ROOK:** "It's *quiet.* Too quiet."
**ROOK:** "I can't hear the note."
> ► **"Take my arm."** — **ROOK:** "Thank you. I'd rather be embarrassed than dead."
> ► **"Apologise again."** — **ROOK:** "...Excuse me. I am only passing."
> ► **"Turn back."** — **ROOK:** "No. If I turn, it will remember I was afraid."

**Scene 4: the far side.** The note returns, deep and warm. They step off onto an island of green earth.

**ROOK:** "That's forty-one."
**ROOK:** "I'll draw her tonight."

**Scene 5: the drawing.** At the Landing that night Rook draws the new bridge by the lantern's light, with the player looking on.

**ROOK:** "I used to think I was drawing the bridges."
**ROOK:** "I think now I am drawing the *crossing.* Same lines. Different thing."
> ► **"Draw the chord."** — **ROOK:** "I can't. But I can draw the pause before it."
> ► **"Will you keep going?"** — **ROOK:** "Until my knees say no. Then I'll sit and draw from memory."
> ► **"Teach me to apologise."** — **ROOK:** "It is not a technique. It is just being polite on purpose."
*He signs the map in small, even letters, and leaves a space beside his name.*

**If the player turned back.** Rook is silent. Then he says, gently, *"You were right to ask. I should have been braver about being afraid,"* and the next span is crossed with the player's hand on his elbow.

**Outcomes and receipt.**
- The bridge is added to the guild map with the player's name beside Rook's. The player may keep walking the bridges with a gentle chord from then on.
- **Receipt:** a small hand-drawn bridge map in the Journal, with a note: *"excuse me, I am only passing."*
- **Canon-safe:** no bridge is explained; the chords are a pleasant feature, not a lore claim.

<!-- quest
id: qst_rot_bridge_mapper
title: The Bridge Mapper
rank: SS
type: Escort
giver: npc_rook_ellery
region: reg_root_of_the_world
level: 226
act: 5
requires_rank: SS
reward: 140000 | 6200 | 740000
sets: rot_bridge_mapper_done
summary: A mapper with failing knees must chart the forty-first Crystal Bridge, and apologises to each span before he steps on it.
objectives:
  talk npc_rook_ellery
  escort npc_rook_ellery
  choice apologise_hum_or_silent
-->

---

## 5. Three Stories, One Stone

*SS · Faction · the Kneeling Stones · giver Pilgrim-Priest Ketil Anvard*

**The short version.** Ketil, a dwarf, has brought two companions to the Kneeling Stones: an elf who believes it is the root of the World Tree, and a Church deacon who believes it is the foundation stone of creation. Each is certain. The stones are big enough for all three, but the three are beginning to argue.

**What is really going on.** None of them is wrong, and none can be proved right. The player is asked to walk with the three through a day of reverence, and to help them find a way to stand together without agreeing.

**Scene 1: the Landing.**

**KETIL:** "I came to see the first anvil. Here are Aelwyn, who sees the World Tree, and Deacon Marro, who sees the foundation."
**KETIL:** "They are good people. They are shouting."
**AELWYN:** "It is *not* an anvil."
**MARRO:** "It is *not* a tree."
> ► **"What do you want from me?"** — **KETIL:** "Keep the peace. Keep us humble."
> ► **"Why not let them argue?"** — **KETIL:** "Because the stones are listening."
> ► **"I'll walk with you."** — **KETIL:** "Gladly. Take your boots off."

**Scene 2: the stones.** Two great hollows in the rock, each wide as a barn floor, worn smooth as a river pebble. The three pilgrims stand at the rim, each speaking in turn. The dwarf lays a small hammer on the stone; the elf, a green leaf; the deacon, a plain white cloth.

*(Gameplay: a dialogue-driven scene; the player may offer a shared gesture.)*

**AELWYN:** "It is the *root.* Not a tool. Not a block."
**MARRO:** "A root is a foundation. We agree!"
**KETIL:** "A foundation is an anvil. We *all* agree."
> ► **(Suggest each place their offering side by side.)** — The three objects lie together.
> ► **(Suggest silence.)** — A long, uneasy minute.
> ► **(Suggest each say what the stone means to them.)** — Each speaks, and softens.

**Scene 3: the hollow.** In the silence, the stone hums once, faintly, a single warm note.

**AELWYN:** "Did you feel that?"
**MARRO:** "I thought it was my heartbeat."
**KETIL:** "Mine too."
> ► **"It may be all of you."** — The three smile, embarrassed.
> ► **"It may be none."** — Aelwyn bristles, then laughs.
> ► **"Take off your boots."** — They all do, and the humming deepens.

**Scene 4: the walk back.** The three climb the stair together, arguing gently about dinner.

**KETIL:** "We did not agree."
**KETIL:** "But we stood."

**Scene 5: the evening meal.** At the Landing the three share bread and a flask of weak wine, and for a while nobody is a pilgrim.

**AELWYN:** "I was rude."
**MARRO:** "So was I."
**KETIL:** "So was the stone, in its way. It would not tell us who was right."
> ► **"Perhaps that is its answer."** — **KETIL:** "That is a good answer. I will keep it."
> ► **"Perhaps all three stories are the stone's."** — **MARRO:** "I would like that. But it seems presumptuous."
> ► **"Pass the bread."** — **AELWYN:** "Wisest thing said today."
*The lantern light is warm on three tired faces, and none of them is arguing.*

**If the player proposed silence.** The three stand a full minute with eyes closed. At the end, Marro admits he heard nothing, Aelwyn that she heard rustling, and Ketil that he heard a hammer, very far off, tapping once. They agree to say nothing of it.

**Outcomes and receipt.**
- Whatever the player suggests, the three leave without settling; the guild's pilgrims' register notes the visit as "reverent."
- **Receipt:** a hammer, a leaf and a cloth drawn together in the Journal.
- **Canon-safe:** all three faiths stand; no faith is declared right, and the stones are unexplained.

<!-- quest
id: qst_rot_three_stories
title: Three Stories, One Stone
rank: SS
type: Faction
giver: npc_ketil_anvard
region: reg_root_of_the_world
level: 230
act: 5
requires_rank: SS
reward: 145000 | 6400 | 760000
sets: rot_three_stories_done
summary: A dwarf, an elf and a deacon at the Kneeling Stones each hold a different faith's story of the Root. The player helps them stand together.
objectives:
  talk npc_ketil_anvard
  reach rot_kneeling_stones
  choice offerings_silence_or_speak
-->

---

## 6. Take Nothing

*SS · OddJob · the Cracked Root · giver Isaure Venn*

**The short version.** Isaure's grove is dying. She has come to the Root, which every faith says must not be harmed, to ask it for one cutting of its light. She does not want to steal. She wants someone to witness the asking, and to say whether she asked well.

**What is really going on.** The Root cannot be asked in any way that a person can hear. The player must help Isaure decide, in the only silence there is, whether she will take what is not offered. The quest does not say what the Root would answer.

**Scene 1: the Landing.**

**ISAURE:** "The trees are going. One by one. Not a blight. A tiredness."
**ISAURE:** "The Root is the root of all trees. I thought it might spare one cutting."
**ISAURE:** "I will not cut. I will *ask.*"
> ► **"What if it says no?"** — **ISAURE:** "Then I will go home and watch the grove die."
> ► **"What if it does not answer?"** — **ISAURE:** "That is the question I am afraid of."
> ► **"I will witness it."** — **ISAURE:** "Thank you. Please be honest with me afterwards."

**Scene 2: the asking.** At the foot of a bright, slow root, Isaure kneels and speaks in the old tongue. She sets down a small silver blade, closed in a sheath, and a seed of her grove. The light pulses once. Nothing else happens. She waits an hour. Two. The root is silent.

*(Gameplay: a long, quiet wait; the player may stay or leave.)*

**ISAURE (whispering):** "It is not saying no."
**ISAURE (whispering):** "It is not saying yes."
> ► **(Stay and wait with her.)** — A third hour passes.
> ► **(Suggest she plant the seed here.)** — Isaure is shaken, then thoughtful.
> ► **(Suggest she take a leaf-fall of light from the ground.)** — She considers.

**Scene 3: the decision.** At last she rises, slowly.

**ISAURE:** "I will not cut."
**ISAURE:** "I will take what falls. If anything falls."
> ► **"Wait for it."** — A single pale mote of light drifts down, and she catches it in her sleeve.
> ► **"Go home."** — **ISAURE:** "...Perhaps."
> ► **"Plant the seed."** — She does, in a hollow of earth, and sits beside it.

**Scene 4: the mote.** The mote is tiny, perhaps no more than a speck of dust, and it hums as she folds it into her glove.

**ISAURE:** "It's not a cure. It is not a *cutting.*"
**ISAURE:** "But it is something."

**Scene 5: the road home.** On the stair Isaure walks slowly, her glove closed over the mote.

**ISAURE:** "I wanted a miracle. I asked for a cutting. I received a speck."
**ISAURE:** "I am, I think, ashamed of wanting more."
> ► **"It is a gift."** — **ISAURE:** "It is. I must learn to receive it as one."
> ► **"The grove may still die."** — **ISAURE:** "It may. I will be there when it does."
> ► **"You asked well."** — **ISAURE:** "Thank you. That was what I needed to hear."
*At the Landing she puts on her boots again and ties them with unusual care.*

**If the seed was planted at the Root.** The player may visit the hollow later and find nothing at all: no sprout, no mark. But the earth there is turned over, as by a small and careful hand.

**Outcomes and receipt.**
- If the player waits with her, Isaure receives the mote. If the seed is planted, the Root's earth keeps it. If she goes home empty-handed, her grove's last tree blooms once, late.
- **Receipt:** a pinch of faint light in the Journal that vanishes by morning.
- **Canon-safe:** the mote's fall is not an answer; no root is cut, and the Root is not given a will.

<!-- quest
id: qst_rot_take_nothing
title: Take Nothing
rank: SS
type: OddJob
giver: npc_isaure_venn
region: reg_root_of_the_world
level: 234
act: 5
requires_rank: SS
reward: 145000 | 6400 | 770000
sets: rot_take_nothing_done
summary: A druid whose grove is dying asks the Root, courteously, for one cutting of its light, and needs a witness to the asking.
objectives:
  talk npc_isaure_venn
  reach rot_bright_root
  choice wait_plant_or_leave
-->

---

## 7. A Letter for the Landing

*SS · Delivery · the Crystal Bridges · giver Pernel Gray*

**The short version.** Pernel carries the last letters of lost adventurers to their families. One letter, from a friend who vanished beyond the farthest bridge, is addressed to the *Landing,* not to a family. Pernel does not know why, and does not want to open it.

**What is really going on.** The letter is a plain, human page. The writer asks only that someone leave a lantern at the Landing, lit, each night. The player finds the writer's last camp, takes the lantern, and delivers it.

**Scene 1: the Landing.**

**PERNEL:** "I've delivered four hundred last letters."
**PERNEL:** "This one is for the *Landing.* Not a person. A *place.*"
**PERNEL:** "I won't open it. It isn't mine."
> ► **"Who wrote it?"** — **PERNEL:** "Hesk. A friend. He went beyond the last bridge nine years ago."
> ► **"Where is the camp?"** — **PERNEL:** "Past the sixth island. I can't go. My legs."
> ► **"I'll find him."** — **PERNEL:** "Not him. His lantern. That's what the letter asks."

**Scene 2: the camp.** Beyond the sixth island, on a ledge over nothing, a small camp lies undisturbed: a bedroll, a pack, a battered brass lantern, still faintly warm. A page lies under it, folded: *"If you find this, take the lantern to the Landing. Keep it lit. Someone should be waiting."*

*(Gameplay: a quiet traverse of two bridges; no combat unless provoked.)*

**JOURNAL (auto):** *The lantern is lit. Nobody lit it.*
> ► **(Take the lantern.)** — It is warm and light.
> ► **(Light a second lantern beside it, and leave.)** — The camp is less alone.
> ► **(Search the pack.)** — A map, a spoon, and a child's drawing of a dog.

**Scene 3: the Landing.** Back at the Landing, Pernel reads the letter at last, aloud, in a steady voice.

**PERNEL:** "*Someone should be waiting.*"
**PERNEL:** "Well. I can do that."
> ► **"I'll help hang it."** — **PERNEL:** "On the left post. He liked the left."
> ► **"Keep it lit tonight."** — **PERNEL:** "Every night."
> ► **"What was he like?"** — **PERNEL:** "Late for everything. Always."

**Scene 4: the light.** The lantern hangs by the stair, small and gold in the dark.

**PERNEL:** "Hesk, you're early."

**Scene 5: the left post.** Pernel and the player hang the lantern together, and Pernel steps back to look at it.

**PERNEL:** "Four hundred letters. I've never kept one."
**PERNEL:** "This is the first that asked me to stay."
> ► **"You don't have to stay forever."** — **PERNEL:** "No. But tonight, yes."
> ► **"Hesk would be pleased."** — **PERNEL:** "He'd say it was crooked."
> ► **"Shall I stay with you?"** — **PERNEL:** "An hour. Then go and sleep."
*The lantern sways, a little, and the light on the stair sways with it.*

**If the player searched the pack.** The child's drawing of the dog is delivered to Hesk's sister on the surface; she writes back one line, *"he always had a dog,"* and Pernel keeps the reply folded inside his hat.

**Outcomes and receipt.**
- The lantern burns at the Landing thereafter. If the player took the pack's drawing to Hesk's family, a small extra reward is the family's thanks.
- **Receipt:** a brass lantern in the Journal's relic page (cosmetic).
- **Canon-safe:** the lantern's warmth and the missing writer's fate are not explained.

<!-- quest
id: qst_rot_letter_landing
title: A Letter for the Landing
rank: SS
type: Delivery
giver: npc_pernel_gray
region: reg_root_of_the_world
level: 238
act: 5
requires_rank: SS
reward: 150000 | 6500 | 780000
sets: rot_letter_landing_done
summary: A courier holds a lost adventurer's last letter, addressed to a place, asking only that a lantern be kept lit.
objectives:
  talk npc_pernel_gray
  reach rot_hesk_camp
  collect rot_hesk_lantern 1
  choice hang_double_or_search
-->

---

## 8. The Old One Who Forgot

*SS · Companion · the Cracked Root's foot · giver Davos Quenby*

**The short version.** An elder draconic being has lived at the Root so long it has forgotten what it was. Davos has traced its lineage through nine dead languages and believes he has its name. He wants the player to read the name to it, and to choose whether to.

**What is really going on.** Giving a being its name back is not obviously kind. The dragon has been content, in its forgetting. The player decides whether to remind it, and the name is, in any case, never confirmed to be right.

**Scene 1: the study.**

**DAVOS:** "Nine languages, all dead. One name, in the end."
**DAVOS:** "I do not know if it is *correct.* I only know it is the best I can do."
**DAVOS:** "It has been alone a very long time."
> ► **"What if it is wrong?"** — **DAVOS:** "Then it is only a sound."
> ► **"Is the dragon dangerous?"** — **DAVOS:** "It has not hurt anyone in a thousand years."
> ► **"Will it want the name?"** — **DAVOS:** "I do not know. That is why I need you."

**Scene 2: the dragon.** In a hollow of crystal, a vast, scaled shape lies curled, its eyes half-open, its breath shaping slow motes of light. It is the colour of old pewter, and it does not seem to notice the player at all.

*(Gameplay: a quiet approach; the dragon does not attack unless provoked.)*

**DAVOS (whispering):** "Say it gently."
> ► **(Read the name aloud.)** — The dragon's eye moves slowly to the player.
> ► **(Ask the dragon whether it wants a name.)** — A slow breath, like laughter.
> ► **(Say nothing and sit.)** — The dragon's eye closes again.

**Scene 3: the answer.** If the name is read, the dragon is silent for a long time. Then, in a voice like a closing door:

**DRAGON:** "...That is *close.*"
**DRAGON:** "It is not the name. But it is the shape of it."
> ► **"What was it?"** — **DRAGON:** "I do not remember. I think I liked it."
> ► **"I am sorry."** — **DRAGON:** "Do not be. It was a good sound."
> ► **"We can keep looking."** — **DRAGON:** "Perhaps. Not today."

**Scene 4: the return.** At the Landing, Davos writes the dragon's answer in his book.

**DAVOS:** "*Close.* That is a better word than *correct.*"

**Scene 5: the book.** At the Landing Davos shows the player the page where he wrote *close.*

**DAVOS:** "I spent six years looking for a certainty."
**DAVOS:** "And the answer is that the thing remembers *the shape.*"
> ► **"Is that enough?"** — **DAVOS:** "For it, I think. For me, nearly."
> ► **"Will you try again?"** — **DAVOS:** "Perhaps in a decade. Perhaps never."
> ► **"What will you tell the guild?"** — **DAVOS:** "That an old one sleeps, and that someone read it a name."
*He closes the book softly, as if it too were sleeping.*

**If the name was never read.** Davos burns the page, and the player may choose whether to watch. He says, afterwards, that there is a kind of reverence in not knowing, and that he will practise it.

**Outcomes and receipt.**
- If the player declined to read the name, Davos keeps it unread, and respects it. If read, the dragon thereafter lifts its head when the player passes.
- **Receipt:** a pewter scale in the Journal's relic page, and a word, written once and rubbed out.
- **Canon-safe:** the dragon's name and nature are never given; it is not a Tyrant or a Calamity.

<!-- quest
id: qst_rot_old_one_forgot
title: The Old One Who Forgot
rank: SS
type: Companion
giver: npc_davos_quenby
region: reg_root_of_the_world
level: 242
act: 5
requires_rank: SS
reward: 150000 | 6500 | 790000
sets: rot_old_one_done
summary: A scholar believes he has found the name of an elder draconic being that has forgotten what it was, and asks the player whether to say it.
objectives:
  talk npc_davos_quenby
  reach rot_dragon_hollow
  choice read_ask_or_sit
-->

---

## 9. The Word the Gate Wants

*SS · Exploration · a Crystal Bridge gate · giver Imke Sorrowby*

**The short version.** A construct stands in a gate at the end of a bridge and asks for a word. Imke has failed three times to remember it. She is certain she once knew it. She asks the player to stand with her, and to try anything but force.

**What is really going on.** The construct was once friendly to a party she led, and has been refusing everyone since. The word is not a magic password. It is the name of a thing she said once, in passing, and the player helps her recall it.

**Scene 1: the Landing.**

**IMKE:** "I led a party here nine years ago. The gate opened for us."
**IMKE:** "I said something. I do not remember what."
**IMKE:** "The gate remembers *me.* And it has not forgiven me."
> ► **"How do you know?"** — **IMKE:** "It faces me when I come."
> ► **"Could it be a grudge?"** — **IMKE:** "Constructs do not hold grudges. Do they?"
> ► **"What did you eat that day?"** — **IMKE:** "...That is oddly exact. Why?"

**Scene 2: the gate.** At the end of a bridge, a tall figure of grey stone and crystal stands before a doorway, motionless, a single blue eye glowing in its face.

**GATE:** "SPEAK."
**IMKE:** "I... have forgotten."
**GATE:** "SPEAK."
*(Gameplay: dialogue; failure is gentle; no combat unless the player attempts to force the gate.)*
> ► **(Ask the gate what it wants.)** — **GATE:** "THE WORD."
> ► **(Ask it for a clue.)** — **GATE:** "A THING YOU CARRIED."
> ► **(Try to force the gate.)** — The gate raises one hand, and the bridge hums in warning.

**Scene 3: the memory.** Imke sits on the bridge with her head in her hands.

**IMKE:** "A thing I carried. Hesk carried the lantern. I carried..."
**IMKE:** "...a sack of dried apricots."
> ► **"Say apricot."** — Imke says it, in a small voice.
> ► **"Say the whole story."** — She tells it, laughing a little.
> ► **"Say nothing, and think."** — A long silence.

**Scene 4: the opening.** The gate's eye brightens, gently.

**GATE:** "...APRICOT."
*The doorway opens onto a floating island of green earth, quiet and lovely.*
**IMKE:** "It was never a password."
**IMKE:** "It was a *kindness.*"

**Scene 5: the garden.** Beyond the gate the island holds a small stone bench and a single, silver-leaved tree that was not on any map.

**IMKE:** "No treasure. No danger. A *bench.*"
**IMKE:** "I was so sure it was a vault."
> ► **"Sit a while."** — **IMKE:** "I will. I have not sat in nine years."
> ► **"Shall we map it?"** — **IMKE:** "Let it stay unmapped for a night."
> ► **"The gate remembered you."** — **IMKE:** "It did. I find that more moving than I expected."
*She sits, takes out the sack of apricots, and offers the player one.*

**If the player tried to force the gate.** The bridge sings a warning note, deep and rebuking; the construct does not raise a hand, only turns its eye away, until Imke, quietly, apologises on the player's behalf, and the eye turns back.

**Outcomes and receipt.**
- Forcing the gate fails and costs a little health; the right path is Imke's memory. The island beyond is a quiet garden; no discovery is made.
- **Receipt:** an apricot, dried, in the player's inventory (cosmetic, gift).
- **Canon-safe:** the construct is not explained; the garden's beauty is only that.

<!-- quest
id: qst_rot_gate_word
title: The Word the Gate Wants
rank: SS
type: Exploration
giver: npc_imke_sorrowby
region: reg_root_of_the_world
level: 246
act: 5
requires_rank: SS
reward: 155000 | 6600 | 800000
sets: rot_gate_word_done
summary: A construct gate has refused a linguist for nine years because she cannot recall the word she gave it. It was never a password.
objectives:
  talk npc_imke_sorrowby
  reach rot_bridge_gate
  choice ask_clue_or_force
-->

---

## 10. The Second Kneeling

*SS · Hidden · the Kneeling Stones · giver Archivist Odalys Reik*

**The short version.** Odalys has measured the two Kneeling Stones and has numbers she cannot file. The hollows are the same size. One is cold and one is warm. She asks the player to stand at the warm one, and to say what they feel.

**What is really going on.** *Nothing is explained.* The warm hollow has a fresh, shallow impression at its centre, as of a person's hands pressed flat. Nobody has been there. The question the quest ends on is: *who is the second kneeling for?*

**Scene 1: the Landing.**

**ODALYS:** "Same depth. Same width. Same curve to a hair."
**ODALYS:** "One is cold, as stone should be. One is warm. Not warm like a fire. Warm like a hand."
**ODALYS:** "That's not a thing I can write."
> ► **"What do you want me to do?"** — **ODALYS:** "Stand at the warm one. Tell me if it fits."
> ► **"Fits what?"** — **ODALYS:** "I don't know. That's the question."
> ► **"I'll look."** — **ODALYS:** "Take your boots off."

**Scene 2: the hollow.** At the Kneeling Stones, in the dark, the two great hollows lie side by side. The left is cold; the right is faintly warm. In its centre, shallow and fresh, two flat impressions, side by side, as of palms pressed to stone.

*(Gameplay: a silent walk-in; the player may stand, kneel, or only watch.)*

**JOURNAL (auto):** *The prints are hand-sized. Mine are too large. Or too small. I cannot tell.*
> ► **(Kneel in the warm hollow.)** — The warmth deepens.
> ► **(Press your hands to the prints.)** — They do not fit, but the stone seems to know you tried.
> ► **(Stand at the rim and do nothing.)** — The warmth stays as it was.

**Scene 3: the report.** Odalys listens with her pencil raised.

**ODALYS:** "Does it fit?"
**ODALYS:** "...Not quite?"
**ODALYS:** "I measured the left hollow yesterday. The prints were not there."
> ► **"Is someone else coming?"** — **ODALYS:** "I do not know."
> ► **"Maybe it is for the one who needs it."** — **ODALYS:** "Maybe."
> ► **"Do not measure it again."** — **ODALYS:** "I have to. I'll try to do it gently."

**Scene 4: the note.** She writes, in a small hand, on a fresh page: *"The second kneeling is not empty."*

**ODALYS:** "That is all I can say."

**Scene 5: the second night.** The player and Odalys return to the Stones in the dark with a single lantern.

**ODALYS:** "The prints are gone."
**ODALYS:** "I measured twice. They were never there. Or they were, and left."
> ► **"Could someone have been here?"** — **ODALYS:** "In a place no one lives?"
> ► **"Maybe the stone remembers."** — **ODALYS:** "I will write that. In pencil."
> ► **"Rest. It will keep."** — **ODALYS:** "I know. That is what frightens me."
*She sets her lantern down on the rim between the hollows. The flame leans, very slightly, toward the warm one.*

**If the player knelt.** For the length of one slow breath the warmth moves beneath their knees, as a sleeper might shift on being touched. Odalys does not see. The player may tell her, or write it only in the Journal.

**Outcomes and receipt.**
- Whatever the player does, the prints are gone by the next visit. If the player knelt, the warmth is faintly still there when they return.
- **Receipt:** a measurement slip with two numbers and a question mark.
- **Canon-safe:** pure seed. Who the second kneeling is for, and the warm hollow's prints, are not explained.

<!-- quest
id: qst_rot_second_kneeling
title: The Second Kneeling
rank: SS
type: Hidden
giver: npc_odalys_reik
region: reg_root_of_the_world
level: 252
act: 5
requires_rank: SS
reward: 160000 | 6800 | 820000
sets: rot_second_kneeling_done
summary: Two Kneeling Stones share every measurement but one is warm, and its hollow holds a fresh pair of handprints no one made.
objectives:
  talk npc_odalys_reik
  reach rot_kneeling_stones_warm
  choice kneel_press_or_watch
-->
