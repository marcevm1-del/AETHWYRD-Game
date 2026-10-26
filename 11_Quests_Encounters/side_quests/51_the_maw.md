# 11e-51 — The Maw, the Breathing Pit: Ten Side Quests (draft)

> *"We do not say the pit is alive. We say it is on the count."*
> — Watch Camp saying, The Maw

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quests 1, 2, 7 and 10 plant unexplained seeds.

**Region:** `reg_the_maw` (the Rim, the Watch Camp, the Throat, the sinking farms beyond the ridge). **Rank band:** S–SS. **Tone:** hushed, watchful, tired, and tender toward anyone who has had to listen for a living.

**Placement notes.**
- **The Hive Mother** is the region's Calamity and a *world event*, not a siege (`noSiege: true`). No quest here wakes her, fights her, kills her, or tells the player what she is. The region is `liberated`; there is no siege to end.
- Customs the quests rely on: the watchers **count the breaths** (one hour in, one hour out) and log every count in the Breath Ledger; nobody says the Hive Mother's name aloud inside the Watch Camp, they say "the sleeper"; a watcher who finishes a shift says "*counted and kept*"; parties descending leave a lantern on the Rim lit until they return.
- **Rank note.** Band S–SS (levels 166-205 for S, 206-259 for SS; see `Data/World/guild_ranks.json`). Quests 1-6 are S; 7-8 are S/SS; 9 and 10 are SS. **All S and SS rewards are first-pass,** extrapolated from the Whitewater S-rank rewards and the promotion table (S: GP 3,000; SS: GP 6,000 first-pass), and need approval.
- The swarm's castes are never named beyond "workers, soldiers, flyers." No quest invents a new caste.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Second Rhythm | S | Investigation | Breath-Counter Harl Brennick | Something under the count |
| 2 | One Word From Below | S | Investigation | Marshal Dagna Fenwick | A message with one word |
| 3 | A Foot of Field | S | OddJob | Piet Haldane | A sinking farm, a song |
| 4 | Resin for the Ledger | S | Gathering | Archivist Ibb Quillon | Careful hands on a sticky wall |
| 5 | The Rim Walk | S | Escort | Surveyor Sabeth Corran | Measuring the sink |
| 6 | The Honest Count | S | Faction | Quartermaster Halvard Stone | A camp that wants to leave |
| 7 | What the Workers Carry | S | Investigation | Scholar Tessaly Mourne | A worker going the wrong way |
| 8 | A Bell for the Third Province | SS | OddJob | Ottoline Reeve | A memorial, rung softly |
| 9 | The Quiet Cull | SS | Subjugation | Captain Brannoch Gale | A cull with a hesitation |
| 10 | The Held Breath | SS | Hidden | Night-Watcher Wyl Ashgrove | A pause that grows |

## Cast

<!-- npc
id: npc_harl_brennick
name: Breath-Counter Harl Brennick
tier: major
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Chief breath-counter of the Watch Camp
backstory: A stooped, soft-spoken counter who has logged thirty-one years of breaths in the Breath Ledger and who has, this season, started hearing a rhythm that is not in the count.
-->
<!-- npc
id: npc_dagna_fenwick
name: Marshal Dagna Fenwick
tier: major
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Marshal of the Watch Camp
backstory: A broad, tired marshal with a scar through one eyebrow who sent a party of S-rank friends into the Throat and has kept their lantern lit for forty days.
-->
<!-- npc
id: npc_piet_haldane
name: Piet Haldane
tier: townsfolk
race: Human
region: reg_the_maw
settlement: Haldane Farm
role: Farmer on the sinking ground
backstory: A patient, weathered farmer who refuses to leave land his family has ploughed for six generations, even though his barley field dropped a foot overnight and something beneath it hums.
-->
<!-- npc
id: npc_ibb_quillon
name: Archivist Ibb Quillon
tier: major
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Archivist of the Breath Ledger
backstory: A small, ink-stained archivist who keeps the Breath Ledger dry, ordered and honest, and who believes the Throat's resin remembers every pressure that has ever touched it.
-->
<!-- npc
id: npc_sabeth_corran
name: Surveyor Sabeth Corran
tier: major
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Land surveyor of the sinking Rim
backstory: A brisk, dry-humoured surveyor who has measured the Rim's slope every month for nine years and who is quietly certain the land is sinking in steps, not in a slide.
-->
<!-- npc
id: npc_halvard_stone
name: Quartermaster Halvard Stone
tier: major
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Quartermaster of the Watch Camp
backstory: A gruff quartermaster who feeds two hundred watchers, and who has noticed that the number who ask for transfers has doubled since the breathing quickened.
-->
<!-- npc
id: npc_tessaly_mourne
name: Scholar Tessaly Mourne
tier: major
race: Elf
region: reg_the_maw
settlement: The Watch Camp
role: Scholar of the swarm
backstory: A precise, curious elf scholar who has spent a century drawing the swarm's workers and who has just drawn one she cannot explain.
-->
<!-- npc
id: npc_ottoline_reeve
name: Ottoline Reeve
tier: townsfolk
race: Human
region: reg_the_maw
settlement: Reeve's Rest
role: Survivor of the stripped provinces
backstory: A quiet seventy-year-old who was a girl when the swarm stripped the Third Province, who still has her mother's house-bell, and who has never been allowed to ring it.
-->
<!-- npc
id: npc_brannoch_gale
name: Captain Brannoch Gale
tier: major
race: Dwarf
region: reg_the_maw
settlement: The Watch Camp
role: Captain of the culling parties
backstory: A thick-armed dwarf captain who has led two hundred descents and who has, lately, begun to count the soldiers that stop and wait for him to leave.
-->
<!-- npc
id: npc_wyl_ashgrove
name: Night-Watcher Wyl Ashgrove
tier: townsfolk
race: Human
region: reg_the_maw
settlement: The Watch Camp
role: Night-watcher on the Rim
backstory: A young, serious night-watcher who has a perfect ear for the breath and was the first to notice that the pause between the in-breath and the out-breath is getting longer.
-->

---

## 1. The Second Rhythm

*S · Investigation · the Watch Camp and the Rim · giver Breath-Counter Harl Brennick*

**The short version.** Harl has counted the Maw's breath for thirty-one years. Under the in-breath, lately, there is a second rhythm, slower, like a pulse under a pulse. He wants someone with a better ear and better legs to listen from three places on the Rim and tell him he is wrong.

**What is really going on.** *Nothing is explained.* The player records the second rhythm at three stations. Each recording agrees. Harl's fear is the quiet kind: if the second rhythm is real, the Ledger's whole method is built on only half the count.

**Scene 1: the counting hut.**

**HARL:** "Thirty-one years. In an hour, out an hour. Counted and kept."
**HARL:** "Then, in the spring, I hear a *knock.* Under the breath. Once every eleven of the in-breaths."
**HARL:** "I am an old man. I would like to be wrong."
> ► **"What do you want me to do?"** — **HARL:** "Stand at the north, east and west stones. Press a hand to the ground. Count what you feel."
> ► **"Have you told the marshal?"** — **HARL:** "I told her I was tired. It is easier."
> ► **"I believe you."** — **HARL:** "Don't. Not yet. Listen first."

**Scene 2: the three stones.** The player kneels on each of three listening stones as the Rim drags and pushes at their coat. At each, under the roar of air, there is a faint, regular *knock,* slow as a cathedral bell, and at the western stone it is slightly *louder,* as though nearer.

*(Gameplay: three short listening stations; the wind periodically knocks the player flat; time the exhale.)*

**JOURNAL (auto):** *At the third stone the knock came before I was ready for it. It was not a sound so much as a lean in the ground.*
> ► **(Record exactly what you felt.)** — The entry is flat and honest.
> ► **(Round the count to Harl's eleven.)** — A kindness that is also a lie.
> ► **(Mark the western stone as louder.)** — A fact Harl will not enjoy.

**Scene 3: the Ledger.** Harl reads the player's figures twice, and writes the western stone on a new page headed with a blank.

**HARL:** "It *is* real."
**HARL:** "...Good. I mean, not good. But I was not mad."
**HARL:** "The count was never half. It was only the half I could hear."
> ► **"Tell the marshal together."** — **HARL:** "I'd like that."
> ► **"Do you want me to say it?"** — **HARL:** "No. It is my Ledger."
> ► **"Keep it in the Ledger only, for now."** — **HARL:** "...That is how things stay quiet until they are not."

**Scene 4: the blank page.** Harl leaves the new page's title empty.

**HARL:** "I will not name it. Naming is for things you understand."

**Scene 5: the marshal's door.** Whatever the player chose, Harl walks the Ledger to the marshal's tent himself, one slow step at a time, and the player walks beside him.

**DAGNA:** "Harl. You look like a man with a letter."
**HARL:** "It is not a letter. It is a *correction.*"
**DAGNA:** "Read it."
*He reads. She listens to the end without moving, then lays her palm flat on the table, as if to feel for a knock.*
**DAGNA:** "How long have you carried this?"
**HARL:** "Since the spring. I was afraid you would send me home."
**DAGNA:** "I would have sent you to bed. It is not the same."
> ► **"He heard it first."** — **DAGNA:** "I know. It is in the Ledger. It will stay there."
> ► **"The western stone is louder."** — **DAGNA:** "Then we put a watcher there. Tonight."
> ► **"Give him an assistant."** — **HARL:** "I would like a young one with good ears."

**If the figure is rounded to eleven.** Harl catches it within the hour, because he has counted for thirty-one years. *"You were kind,"* he says. *"Do not be kind to the Ledger. Be kind to me."* He crosses out the eleven himself and writes the true number, which is seven.

**Outcomes and receipt.**
- If the player is honest and tells the marshal, the Watch Camp adds a standing second-rhythm watch. If they keep it in the Ledger only, Harl goes on alone, and is a little greyer in later scenes.
- **Receipt:** a page in the player's Journal headed *Under the Breath,* with three marks and no explanation.
- **Canon-safe:** pure seed. The second rhythm is not identified as the Hive Mother's heartbeat or anything else.

<!-- quest
id: qst_maw_second_rhythm
title: The Second Rhythm
rank: S
type: Investigation
giver: npc_harl_brennick
region: reg_the_maw
level: 168
act: 5
requires_rank: S
reward: 68000 | 3000 | 310000
sets: maw_second_rhythm_done
summary: A veteran breath-counter hears a slow second rhythm under the Maw's breath, and needs a better ear to tell him whether he is wrong.
objectives:
  talk npc_harl_brennick
  reach maw_rim_listening_stones
  choice honest_rounded_or_ledger_only
-->

---

## 2. One Word From Below

*S · Investigation · the Throat · giver Marshal Dagna Fenwick*

**The short version.** Forty days ago an S-rank party of five went down the Throat. One message came back, tied to a line: a single word. Marshal Fenwick keeps their lantern lit on the Rim and wants the player to bring back anything more.

**What is really going on.** *Nothing is explained.* The word, written in the party's healer's hand, is *"warm."* The player finds the party's anchor line on the second landing, cut clean, and a camp where nobody is, with five cups set out, each half full and each cooled long ago.

**Scene 1: the Rim.**

**DAGNA:** "Five of them. Sully, Mere, the twins, and Orrin, who I trained."
**DAGNA:** "Forty days. They tied this to the line."
*She hands over a scrap of waxed paper. One word, in a neat hand.*
**DAGNA:** "*Warm.* That's all. No 'help.' No 'retreat.' *Warm.*"
> ► **"Could it be a code?"** — **DAGNA:** "We had no code. Mere hated codes."
> ► **"Is the lantern still lit?"** — **DAGNA:** "Every night. I keep it myself."
> ► **"I'll go down."** — **DAGNA:** "To the second landing. No further. Promise me."

**Scene 2: the second landing.** The Throat's ribbed walls glisten. The player's boots stick. At the second landing, the anchor line hangs from its iron ring, cut at an angle too clean for any claw, and a small camp sits ready: bedrolls, a cold stove, five tin cups, each with a mouthful of tea in the bottom, all faintly warm to the touch.

*(Gameplay: a quiet descent; no combat; the swarm's workers pass in the far tunnels and do not look at the player.)*

**JOURNAL (auto):** *The cups are warm. The stove is stone cold. I do not know how long they have been warm.*
> ► **(Take the cups.)** — Five tin cups, damp with something that is not tea.
> ► **(Leave the cups where they are.)** — The camp stays as it was found.
> ► **(Call down the shaft.)** — Your voice comes back from further down than the shaft allows.

**Scene 3: the answer.** Back on the Rim, Dagna turns the cups over without speaking.

**DAGNA:** "Orrin always drank his tea last."
**DAGNA:** "Is he alive?"
> ► **"I do not know."** — **DAGNA:** "...Honest. Thank you."
> ► **"I think they were comfortable."** — **DAGNA:** "Comfortable is not alive."
> ► **"I'll keep looking."** — **DAGNA:** "Not on my order. On yours."

**Scene 4: the lantern.** That night Dagna trims the Rim lantern, and does not relight the others.

**DAGNA:** "Forty days. I'll make it forty-one."

**Scene 5: the lantern line.** Before the player goes, Dagna walks them to the Rim, where the anchor line runs over the edge into the dark, and shows the five hooks where the party's names are scratched.

**DAGNA:** "Sully hated heights. She went anyway. Mere would not shut up for the whole climb, and Orrin hummed."
**DAGNA:** "I have been trying to remember what Orrin hummed."
> ► **"What do you remember?"** — **DAGNA:** "Three notes. Down, down, up. Like a question."
> ► **"I will hum it, if I hear it."** — **DAGNA:** "Do not. Not if it hums back."
> ► **"They knew the risk."** — **DAGNA:** "Everybody knows the risk. It is not the same as being ready."
*She presses her thumb to each hook in turn, as another person might touch a doorframe.*
**DAGNA:** "Counted and kept."

**Outcomes and receipt.**
- The party is not found, and not declared dead. The marshal adds "warm" to the camp's list of words nobody says, and the Ledger records the cups.
- **Receipt:** a tin cup, warm for a day after the player holds it, in the Journal's relic page (cosmetic).
- **Canon-safe:** pure seed. The party's fate, the clean cut and the warmth are not explained.

<!-- quest
id: qst_maw_one_word
title: One Word From Below
rank: S
type: Investigation
giver: npc_dagna_fenwick
region: reg_the_maw
level: 172
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: maw_one_word_done
summary: A lost S-rank party sent back one word. A marshal keeps their lantern lit and wants the player to bring back anything more.
objectives:
  talk npc_dagna_fenwick
  reach maw_throat_second_landing
  choice take_leave_or_call
-->

---

## 3. A Foot of Field

*S · OddJob · Haldane Farm, beyond the ridge · giver Piet Haldane*

**The short version.** A farmer's barley field dropped a foot overnight, and something under it is singing. He does not want a hero. He wants someone to tell him whether it is safe to plough.

**What is really going on.** *Nothing is explained.* The song is a long, low, wordless tune, almost a lullaby, and it is not the swarm's hum. The farm's dog has stopped barking at the field and lies in it. The question is whether the farmer stays.

**Scene 1: the farmhouse.**

**PIET:** "Six generations. My great-grandmother ploughed the first furrow."
**PIET:** "Tuesday, the field dropped. A *foot.* Clean. Like a step."
**PIET:** "And it sings. At dusk."
> ► **"Have you told the camp?"** — **PIET:** "They sent a lad with a measuring pole. He went white and left."
> ► **"Can I hear it?"** — **PIET:** "Come at dusk. Bring a coat."
> ► **"Is it dangerous?"** — **PIET:** "The dog doesn't think so. That's what worries me."

**Scene 2: dusk in the field.** The barley stands upright on the lowered ground. Insects are silent. The song begins: a few notes, then a rest, then the same few notes, patient as a mother at a cot.

*(Gameplay: stand in the field and wait; no enemies; the player can hum along.)*

**PIET (whispering):** "That's what I hear. Do you hear it?"
> ► **(Hum the tune back.)** — The song pauses, and then resumes a note higher.
> ► **(Press an ear to the ground.)** — The tune is nearer than the ground is deep.
> ► **(Stay silent.)** — The song finishes, and the dog sighs.

**Scene 3: the advice.** At the table, Piet sets out a pot of tea.

**PIET:** "Tell me honestly. Do I leave?"
> ► **"Stay, and keep watch."** — **PIET:** "I'd have said so myself."
> ► **"Leave, for the children's sake."** — **PIET:** "I have no children. I have a dog."
> ► **"I can't tell you. I'm sorry."** — **PIET:** "That's the first honest answer I've had."

**Scene 4: the furrow.** Whatever he chooses, Piet ploughs one furrow along the new step, carefully, and leaves the last row of barley standing at its edge.

**PIET:** "For whoever's singing."

**Scene 5: the dog.** After supper Piet takes the player out to the porch, where the farm's old dog, a grey-muzzled herder called Biscuit, is lying with her nose pointed at the field.

**PIET:** "She won't come in. First time in fourteen years."
**PIET:** "I carried her out last night. She walked back."
> ► **"She is not frightened."** — **PIET:** "No. That is the thing."
> ► **"Maybe she knows the song."** — **PIET:** "Maybe I do. I only wish I knew from where."
> ► **"Sit with her a while."** — **PIET:** "I have been. It's restful. Which is a strange thing to be, on ground that is sinking."
*The dog thumps her tail once, slowly, in the rhythm of the tune.*
**PIET:** "There. You see. She keeps time."

**If the player stays on a day or two.** Piet teaches them the old farm rule: *never plough toward dusk.* On the second evening the song is a little nearer the surface, and Piet, without looking up, sets a cup of milk on the edge of the step, as his grandmother once left milk for the house-cat. In the morning it is gone, and the cup is warm.

**Outcomes and receipt.**
- If the player advises staying, a later camp scene mentions Piet's lantern in the field at dusk. If leaving, the farm's gate is tied with a red cord, and the barley is left to seed.
- **Receipt:** four notes of the song, hummable in the Journal's music page.
- **Canon-safe:** pure seed. The singer, the foot of sinking and the lullaby are not explained.

<!-- quest
id: qst_maw_foot_of_field
title: A Foot of Field
rank: S
type: OddJob
giver: npc_piet_haldane
region: reg_the_maw
level: 170
act: 5
requires_rank: S
reward: 66000 | 3000 | 300000
sets: maw_foot_of_field_done
summary: A farmer's barley field dropped a foot overnight and something beneath it sings at dusk. He wants to know whether to plough.
objectives:
  talk npc_piet_haldane
  reach maw_haldane_field
  choice stay_leave_or_unsure
-->

---

## 4. Resin for the Ledger

*S · Gathering · the Throat's upper wall · giver Archivist Ibb Quillon*

**The short version.** Ibb believes the resin on the Throat's walls records every pressure that touches it, a second ledger written by the pit itself. He needs three clean samples, taken without scraping, from the upper wall.

**What is really going on.** The resin is only resin. But Ibb's real fear is that his own Breath Ledger will be proven wrong by the walls. The player gathers; the samples show the same rhythm as Harl's, and *older,* in the deepest layers. Ibb must decide whether to publish.

**Scene 1: the archive.**

**IBB:** "The Ledger is what *we* heard. The wall is what *it* felt."
**IBB:** "I need three samples. Soft, from the upper wall. Do not scrape. Press, wait, peel."
> ► **"Why not scrape?"** — **IBB:** "Scraping tears the layers. Layers are the whole point."
> ► **"What will you do with them?"** — **IBB:** "Hold them to the light. Read them like tree rings."
> ► **"I'll be careful."** — **IBB:** "Your gloves will be ruined. Take two pairs."

**Scene 2: the wall.** Hanging from a rope above the Throat, the player presses a glass plate to the resin, waits, peels. Each sample comes off as a pale, amber leaf, faintly warm, with fine striations. The third is hardest: a patch of resin that *ripples* away from the plate's edge, and must be coaxed.

*(Gameplay: a delicate rope-and-pressure minigame; the exhale will blow the player off the wall if mistimed.)*

**JOURNAL (auto):** *Three leaves, each different. The oldest is nearly clear.*
> ► **(Take the third leaf carefully.)** — It comes off whole.
> ► **(Press harder to speed it up.)** — The layers tear, and Ibb will notice.
> ► **(Leave the third and report two.)** — Honest, but short.

**Scene 3: the reading.** At the light, Ibb's face changes.

**IBB:** "The rings match the Ledger. For thirty years. And before that, further back than any counter, a *slower* ring. It's been *breathing slower* for a thousand years, and it's *speeding up.*"
**IBB:** "I should publish."
> ► **"Publish."** — **IBB:** "They'll panic."
> ► **"Warn the marshal first."** — **IBB:** "Yes. That's the order."
> ► **"Seal the samples."** — **IBB:** "...Hiding data. I wouldn't be proud."

**Scene 4: the leaves.** He mounts the three leaves in a frame and hangs it above the Ledger.

**IBB:** "Not to alarm. To remember."

**Scene 5: the second ledger.** Late that night Ibb finds the player still at the archive table, and sets down two cups of watered wine.

**IBB:** "Do you know the worst of it? I want the walls to be wrong."
**IBB:** "I have kept the Ledger for twenty years. If the pit has been keeping its own, then mine is a child's copybook."
> ► **"Yours is the one with names in it."** — **IBB:** "...Yes. That's true. Nobody wrote the wall's *names.*"
> ► **"Both can be true."** — **IBB:** "That is a scholar's answer. I will take it."
> ► **"Keep the leaves close."** — **IBB:** "I will sleep with them under the pillow, like a boy with a stolen apple."
*He turns a leaf to the lamp. The amber lights from within, and for a moment the whole table is the colour of a late afternoon.*

**If the samples are torn.** Ibb takes it hard but honestly. *"My own fault. I should have gone myself."* He tapes the torn leaf into the Ledger anyway, labelled *damaged, still true,* and for a week afterwards leaves a small dish of honey on the player's bunk, which nobody has ever been able to explain.

**Outcomes and receipt.**
- Choosing to publish or warn first earns a standing nod from Marshal Fenwick; sealing earns Ibb's quiet disappointment. Torn layers make the samples less readable but not useless.
- **Receipt:** a framed amber leaf in the camp archive, labelled with the player's name.
- **Canon-safe:** the resin's record of slowing then quickening is observational only; the Maw's cause and the Hive Mother's nature are not addressed.

<!-- quest
id: qst_maw_resin_ledger
title: Resin for the Ledger
rank: S
type: Gathering
giver: npc_ibb_quillon
region: reg_the_maw
level: 174
act: 5
requires_rank: S
reward: 72000 | 3000 | 325000
sets: maw_resin_ledger_done
summary: An archivist wants three layered resin samples from the Throat's upper wall, a second ledger written by the pit itself.
objectives:
  talk npc_ibb_quillon
  collect maw_resin_leaf 3
  choice publish_warn_or_seal
-->

---

## 5. The Rim Walk

*S · Escort · the Rim · giver Surveyor Sabeth Corran*

**The short version.** Sabeth measures the Rim's slope every month, from fixed pegs. This month the pegs have moved. She needs a guard on the full circuit, because the Rim cracks, and she will not skip a peg.

**What is really going on.** The land is sinking in steps, not in a slide. The player escorts Sabeth round the Rim, and at each peg she records a drop. Near the end, a peg is *gone,* with a clean hollow where it stood. The choice is how fast to walk the last stretch.

**Scene 1: the camp gate.**

**SABETH:** "Nine years. Two hundred and eight pegs. I've never skipped one."
**SABETH:** "The Rim is cracking. I need someone who can catch me if I fall."
> ► **"How long is the walk?"** — **SABETH:** "A day and a half, if the breath is kind."
> ► **"Can't a patrol do it?"** — **SABETH:** "Patrols hurry. I measure."
> ► **"Lead on."** — **SABETH:** "*You* lead. I'll read."

**Scene 2: the circuit.** The Rim is a cracked shelf of grey stone, slanting toward the pit. At every peg Sabeth kneels, sights a line, writes a number. The breath comes in; the player holds her belt; the breath goes out; they walk on. At the hundred-and-fortieth peg, the stone drops a hand's-breadth *under their feet* with a deep, shivering *thunk.*

*(Gameplay: escort along a crumbling ledge; a fall-risk timing mechanic.)*

**SABETH:** "A step. See? Not a slide. A *step.*"
> ► **(Steady her.)** — **SABETH:** "Thank you. I wasn't falling. I was nearly falling."
> ► **(Mark the peg yourself.)** — **SABETH:** "No. My numbers. My name."
> ► **(Suggest turning back.)** — **SABETH:** "Not yet."

**Scene 3: the missing peg.** At the two-hundred-and-third peg there is no peg, only a smooth, round hollow where an iron post had been, edges glazed with resin.

**SABETH:** "It was *here.* I drove it myself."
> ► **"Hurry to the next."** — **SABETH:** "...I can't leave it unmeasured."
> ► **"Measure it, then go."** — **SABETH:** "Thank you."
> ► **"Leave a marker."** — **SABETH:** "A good idea. A *cairn.*"

**Scene 4: the closing.** At the camp, Sabeth writes the last number and tears the page from the book.

**SABETH:** "I've been afraid to say it for nine years. The land is not *falling.* It's being *drawn.*"
**SABETH:** "...No. Cross that out. I don't know what it's being."

**Scene 5: the camp fire.** Sabeth does not go straight to her tent. She sits at the camp fire with her boots off and her feet on a stone, and the player sits beside her.

**SABETH:** "My mother thought I was mad. Measuring a hole."
**SABETH:** "I told her: someone has to write down what it did *before* it did something."
> ► **"You will be in the history."** — **SABETH:** "As a footnote. I'd like that. Footnotes are the true record."
> ► **"Do you ever want to stop?"** — **SABETH:** "Every month. And then I see a peg, and I think: *that one will move.*"
> ► **"I will walk the next circuit with you."** — **SABETH:** "Bring better boots."
*She laughs, and the fire pops, and for a minute the Rim is only a place where two people sit and are tired.*

**If the player marks the peg themselves.** Sabeth lets them, then quietly redraws it in her own hand that evening. *"Not out of pride,"* she says. *"Out of habit. Habits keep people alive on the Rim."* She keeps the player's mark in the margin, smaller, like a signature on a witness line.

**Outcomes and receipt.**
- A cairn marks the missing peg. Sabeth's report goes to the guild with the player's name beside hers.
- **Receipt:** a survey page in the Journal with a numbered circuit and a crossed-out line.
- **Canon-safe:** the cause of the sinking and of the missing peg is not explained.

<!-- quest
id: qst_maw_rim_walk
title: The Rim Walk
rank: S
type: Escort
giver: npc_sabeth_corran
region: reg_the_maw
level: 176
act: 5
requires_rank: S
reward: 72000 | 3000 | 325000
sets: maw_rim_walk_done
summary: A surveyor must walk the Rim's full circuit to measure a sinking that has started to move in steps, and she needs a guard.
objectives:
  talk npc_sabeth_corran
  escort npc_sabeth_corran
  choice hurry_measure_or_cairn
-->

---

## 6. The Honest Count

*S · Faction · the Watch Camp · giver Quartermaster Halvard Stone*

**The short version.** Since the breathing quickened, requests for transfer have doubled. Halvard feeds two hundred watchers, and he believes the camp is about to leave in the night. He wants the player to find out what each faction in the camp is afraid of, and to carry it to the marshal.

**What is really going on.** The watchers are not cowards. They are afraid of the *quiet,* and of having nothing to do but count. The player listens to three groups, and the best answer may not be an order at all.

**Scene 1: the stores.**

**HALVARD:** "Two hundred mouths. Last month, forty asked to go home."
**HALVARD:** "I can feed people. I can't feed *fear.*"
> ► **"Who's afraid?"** — **HALVARD:** "The new ones. The old ones. The ones in between."
> ► **"What do you want?"** — **HALVARD:** "I want them to stay because they *choose* to."
> ► **"I'll talk to them."** — **HALVARD:** "Bring tea."

**Scene 2: three tables.** At the newcomers' table, a young watcher admits she cannot sleep for the hum. At the veterans' table, an old man says the breathing used to put him to sleep and now it keeps him awake. At the night-shift table, a woman says nobody has asked what they *hear.*

**NEW WATCHER:** "I count and I count and I don't know what for."
**VETERAN:** "It used to be a lullaby. Now it's a question."
**NIGHT-WATCHER:** "Nobody asks us. We just write the number."
> ► **(Promise each table a say.)** — A circle of nods.
> ► **(Tell them to be brave.)** — Polite silence.
> ► **(Offer to carry their words to the marshal.)** — The first real smile of the night.

**Scene 3: the marshal.** Dagna Fenwick listens to all three, arms folded.

**DAGNA:** "I give orders. I don't ask. That was my mistake."
> ► **"Hold a camp meeting."** — **DAGNA:** "Tonight."
> ► **"Rotate the night shift."** — **DAGNA:** "It's overdue."
> ► **"Let the ones who want to go, go."** — **DAGNA:** "...Then who counts?"

**Scene 4: the meeting.** In the mess tent, two hundred watchers speak, one at a time.

**HALVARD (quietly):** "That's the most I've heard them say in a year."

**Scene 5: the new sign.** The next morning Halvard finds the player in the mess tent, helping a young watcher paint letters on a board.

**HALVARD:** "Who gave you permission?"
**WATCHER:** "Nobody. We just started."
**HALVARD:** "Good. That's the first thing in a year nobody ordered."
> ► **"Add a line for the cooks."** — **HALVARD:** "Ha. *Say what you taste.*"
> ► **"Will they keep it up?"** — **HALVARD:** "A sign is not a promise. But it is a start."
> ► **"What happens when someone says something hard?"** — **HALVARD:** "Then we are lucky. Hard things are the only ones worth hearing."
*He takes the brush, finishes the last letter himself, and does not say a word about the stew.*

**If the player argues for letting people go.** Forty watchers leave within the month, with the marshal's blessing and a hot meal each. Halvard stands at the gate and counts them out, as he counted them in, and says, to each: *"Counted and kept."* Three of them come back before winter, and nobody mentions it.

**Outcomes and receipt.**
- Whatever the choice, requests for transfer fall by a third over the next season; letting people go lowers morale but raises honesty, and the camp is smaller and steadier.
- **Receipt:** a hand-lettered sign over the mess tent door: *"Say what you hear."*
- **Canon-safe:** pure human drama; the Maw's nature is untouched.

<!-- quest
id: qst_maw_honest_count
title: The Honest Count
rank: S
type: Faction
giver: npc_halvard_stone
region: reg_the_maw
level: 178
act: 5
requires_rank: S
reward: 74000 | 3000 | 330000
sets: maw_honest_count_done
summary: A quartermaster fears the watch camp will leave in the night. The player listens to three groups of watchers and carries their fear to the marshal.
objectives:
  talk npc_halvard_stone
  talk npc_dagna_fenwick
  choice meeting_rotate_or_release
-->

---

## 7. What the Workers Carry

*S · Investigation · the Throat's mouth · giver Scholar Tessaly Mourne*

**The short version.** For a century Tessaly has drawn the swarm's workers carrying the surface down: grain, timber, bronze, once a whole cart. Last week she drew one carrying something *up.*

**What is really going on.** *Nothing is explained.* The worker is small, slow, and clutches a tiny, flat, grey stone in its forelimbs, which it sets on the Rim's edge, in the same place, every night, then retreats. The player watches. The stone is a river pebble, worn smooth, not from here.

**Scene 1: the sketchbook.**

**TESSALY:** "A hundred years of workers. Down. Always down."
*She turns a page. A worker, drawn precisely, head bowed, a small flat stone in its forelimbs.*
**TESSALY:** "Up. At dusk. To the same spot. And then it goes back."
> ► **"What does it do with the stone?"** — **TESSALY:** "Sets it down. Aligns it. Leaves."
> ► **"Have there been others?"** — **TESSALY:** "I've seen one. Only one."
> ► **"Can I watch?"** — **TESSALY:** "Keep still. Keep downwind. Keep quiet."

**Scene 2: the watch.** The player lies behind a boulder on the Rim at dusk. The in-breath passes. The worker climbs out of the Throat, small and pale, a flat grey pebble in its forelimbs. At the same spot, at the same angle, it sets the pebble down, beside twenty-nine other pebbles, laid in a slow arc.

*(Gameplay: stealth observation; no combat.)*

**TESSALY (whispering):** "Thirty. One a night. It's *counting.*"
> ► **(Take a pebble.)** — A flat grey stone, cold, warm on the underside.
> ► **(Add a pebble of your own.)** — The worker will not touch it.
> ► **(Leave everything.)** — The arc is undisturbed.

**Scene 3: the tent.** Tessaly rubs her eyes.

**TESSALY:** "What does a worker count? What does it *want?*"
> ► **"It may be a message."** — **TESSALY:** "To whom?"
> ► **"It may be a habit."** — **TESSALY:** "Habits don't climb."
> ► **"It may be nothing."** — **TESSALY:** "I've drawn nothing for a hundred years. It looked different."

**Scene 4: the thirty-first night.** The player and Tessaly return. The arc is there; the worker is not. A thirty-first pebble lies in the place, and next to it, a tiny scratch like a tally mark.

**TESSALY:** "...It left a *mark.*"

**Scene 5: the drawing.** Tessaly spends the next day drawing the worker from memory, and asks the player to look over her shoulder.

**TESSALY:** "I keep getting the head wrong. It's tilted. I don't remember tilting it."
**TESSALY:** "I think it was looking back."
> ► **"At what?"** — **TESSALY:** "At the pit, I think. Or at me."
> ► **"Leave it tilted."** — **TESSALY:** "Yes. Accuracy is not always measurement."
> ► **"Draw the pebbles too."** — **TESSALY:** "I have. Thirty-one. I keep wanting to draw a thirty-second."
*She pins the sketch above her bed, beside a hundred years of workers walking the other way.*

**If the player adds a pebble.** The worker does not move it, but on the third night it walks a wide, careful half-circle around it, the way a guest steps around a child's toy. Tessaly writes this down and underlines it twice, then crosses out the underline.

**Outcomes and receipt.**
- Tessaly adds the arc to her catalogue as "Worker, Ascending, Unexplained." If the player added a pebble, the next morning it has been moved one finger-width to the left of the arc, politely.
- **Receipt:** a sketch of a worker carrying a pebble, and thirty-one pebbles in a curve.
- **Canon-safe:** pure seed. The worker's purpose, the arc and the tally mark are not explained, and no caste is named.

<!-- quest
id: qst_maw_workers_carry
title: What the Workers Carry
rank: S
type: Investigation
giver: npc_tessaly_mourne
region: reg_the_maw
level: 182
act: 5
requires_rank: S
reward: 76000 | 3200 | 340000
sets: maw_workers_carry_done
summary: A scholar of the swarm has drawn a worker carrying a pebble up from the pit instead of down, and laying it in an arc on the Rim.
objectives:
  talk npc_tessaly_mourne
  reach maw_rim_pebble_arc
  choice take_add_or_leave
-->

---

## 8. A Bell for the Third Province

*SS · OddJob · Reeve's Rest and the Rim · giver Ottoline Reeve*

**The short version.** When Ottoline was a girl the swarm stripped the Third Province in a week. She carried out her mother's house-bell and has never been allowed to ring it, because bells carry, and the camp forbids noise on the Rim. She wants to ring it once, at the exhale, for the dead.

**What is really going on.** The ban is sensible: nobody knows what sounds the pit answers. The player must weigh respect for the dead against a risk that cannot be measured. The bell is small and sweet.

**Scene 1: the porch.**

**OTTOLINE:** "I was nine. Three days. By the fourth there was nothing."
**OTTOLINE:** "My mother rang this bell to call us in. I carried it out under my coat."
*She sets a small brass bell on the table, its lip worn bright.*
**OTTOLINE:** "I would like to ring it once. On the Rim. At the out-breath."
> ► **"The camp forbids noise."** — **OTTOLINE:** "I know. I wrote to them six times."
> ► **"Why the out-breath?"** — **OTTOLINE:** "So the wind carries it *away.*"
> ► **"I'll ask."** — **OTTOLINE:** "Thank you. I've forgotten how."

**Scene 2: the marshal's tent.** Dagna Fenwick listens, jaw tight.

**DAGNA:** "I cannot promise it won't be heard."
**DAGNA:** "I cannot promise it *will.* Nobody knows what it hears."
> ► **"One ring. Softly."** — **DAGNA:** "I'll stand by the lantern."
> ► **"Ring it far from the Rim."** — **DAGNA:** "That, I can approve."
> ► **"Do not ring it."** — **DAGNA:** "...I would rather have you argue."

**Scene 3: the ringing.** At dusk, Ottoline stands on the Rim with her bell under her coat, the player at her elbow, the watchers silent in a long line. The breath turns. The player nods. She lifts the bell, and rings it, once. A single clear note drifts out over the pit and is carried away on the wind.

*Far below, a very long moment later, something answers: not a note, not a word, but a single breath held, and then let go.*

**OTTOLINE (whispering):** "...Did you hear?"
> ► **"I heard."** — **OTTOLINE:** "So did my mother."
> ► **"It was only the wind."** — **OTTOLINE:** "Perhaps."
> ► **(Say nothing.)** — She squeezes your hand.

**Scene 4: the porch.** Ottoline hangs the bell by her door.

**OTTOLINE:** "I'll ring it again, someday. Not soon."

**Scene 5: the neighbour.** At Reeve's Rest, a neighbour, a gruff man named Alwin whose own grandmother died in the Third Province, comes to the gate after the ringing.

**ALWIN:** "I heard it from my field."
**ALWIN:** "My gran had a bell. She never got it out."
> ► **"Ottoline will lend you hers."** — **ALWIN:** "I could not. But I will come on the day, if she rings it again."
> ► **"It was beautiful."** — **ALWIN:** "It was. It was also a risk. I'm glad she took it."
> ► **"Did you hear anything else?"** — **ALWIN:** "...No. And I would sooner not."
*He takes off his cap, stands a moment, and puts it back on.*

**If Ottoline rings the bell alone.** The player is told, afterwards, by two farmers who heard it from different fields, and who describe it in the same words: *"It sounded like someone calling a child in for supper."* The player may leave a coin on her porch rail; it is gone by morning, and a ribbon is tied there instead.

**Outcomes and receipt.**
- If the player argued against ringing it, Ottoline rings it anyway, alone, at the farm; the quest still completes, and she is a little cooler to the player.
- **Receipt:** a small brass bell ring in the Journal's relic page (cosmetic).
- **Canon-safe:** pure seed. The breath's answer is not explained and may be coincidence.

<!-- quest
id: qst_maw_third_province_bell
title: A Bell for the Third Province
rank: SS
type: OddJob
giver: npc_ottoline_reeve
region: reg_the_maw
level: 212
act: 5
requires_rank: SS
reward: 130000 | 6000 | 700000
sets: maw_third_province_bell_done
summary: A survivor of the stripped Third Province wants to ring her mother's house-bell once, at the out-breath, on a Rim where noise is forbidden.
objectives:
  talk npc_ottoline_reeve
  talk npc_dagna_fenwick
  choice ring_far_or_refuse
-->

---

## 9. The Quiet Cull

*SS · Subjugation · the Throat's second tier · giver Captain Brannoch Gale*

**The short version.** Brannoch has led two hundred culling descents. This season, soldiers at the second tier have stopped attacking, and wait for the party to leave. He must thin the flyers before they breach the Rim, and he wants the player to choose how.

**What is really going on.** The cull is necessary: the flyers would strip the farms. But a few of the soldiers have simply stepped aside. Brannoch is a good captain, not a cruel one, and is troubled by killing creatures that have stopped fighting. The player decides how hard to push.

**Scene 1: the camp.**

**BRANNOCH:** "Two hundred descents. I know their rhythm."
**BRANNOCH:** "Now the soldiers wait. Shield-up, mandibles still, until we go."
**BRANNOCH:** "I don't know what it means. I only know the flyers *do* come."
> ► **"Are they surrendering?"** — **BRANNOCH:** "Bugs don't surrender. I thought."
> ► **"What do you need?"** — **BRANNOCH:** "Thin the flyers at the second tier. Quick and clean."
> ► **"I'll go with you."** — **BRANNOCH:** "I'd be glad. Mind the third rope."

**Scene 2: the second tier.** A hollow cavern, ribbed and resin-slick, filled with the slow thrum of wings. The party fights the flyers: swift, flickering things, a storm of pale wings, that the party cuts down in the hundreds. At the edge of the cavern, a line of soldiers stands, shields up, motionless, watching.

*(Gameplay: a swarm battle against flyers; soldiers do not engage unless attacked.)*

**BRANNOCH (shouting):** "Leave the soldiers! We're here for the wings!"
> ► **(Fight only the flyers.)** — The soldiers do not move.
> ► **(Press through the soldier line.)** — They fight back, fiercely, as if grieving.
> ► **(Call a halt, and pull back.)** — Brannoch's face is unreadable.

**Scene 3: the withdrawal.** In the lull, Brannoch kneels by a fallen flyer.

**BRANNOCH:** "I never stopped to look at one before."
**BRANNOCH:** "They're small. They're *so small.*"
> ► **"It's still the job."** — **BRANNOCH:** "It is. I'll do it."
> ► **"We could cull less."** — **BRANNOCH:** "And let the farms fall?"
> ► **"Report the soldiers' behaviour."** — **BRANNOCH:** "To whom? And say what?"

**Scene 4: the report.** Back at camp, Brannoch writes two lines in the Ledger.

**BRANNOCH:** "*Flyers thinned. Soldiers at rest.* That's all I can write."

**Scene 5: the mess.** That night Brannoch drinks one cup of ale, which is his limit, and the rest of the party eats in silence.

**BRANNOCH:** "I was a young man when I first went down. We cheered every kill."
**BRANNOCH:** "I do not know when we stopped cheering. I didn't notice."
> ► **"Do you want to stop?"** — **BRANNOCH:** "I want to be *sure.* And I cannot be."
> ► **"The farms need you."** — **BRANNOCH:** "They do. That is why I go."
> ► **"What would you tell a new recruit?"** — **BRANNOCH:** "Look. Look at the one in front of you. Then decide."
*He turns his cup a quarter-turn on the table and does not drink.*

**If the player presses the soldier line.** The soldiers fight with an odd, formal grief, one at a time, without calling for help. Brannoch will not speak of it that night. In the Ledger, he writes only the number, and underneath it, in very small letters, the word *sorry,* then blots the page with his sleeve.

**Outcomes and receipt.**
- Pressing the soldier line makes the cull larger but costs Brannoch's trust; fighting only the flyers or pulling back leaves the soldiers unharmed and the farms safe for another season.
- **Receipt:** a note from Brannoch: *"Soldiers at rest,"* and a drawing of a small flyer.
- **Canon-safe:** no caste is named beyond "soldiers" and "flyers"; the soldiers' waiting is not explained.

<!-- quest
id: qst_maw_quiet_cull
title: The Quiet Cull
rank: SS
type: Subjugation
giver: npc_brannoch_gale
region: reg_the_maw
level: 220
act: 5
requires_rank: SS
reward: 135000 | 6200 | 730000
sets: maw_quiet_cull_done
summary: A culling captain must thin the flyers before they breach the Rim, while a line of soldiers stands aside and waits for the party to leave.
objectives:
  talk npc_brannoch_gale
  reach maw_throat_second_tier
  choice flyers_only_press_or_withdraw
-->

---

## 10. The Held Breath

*SS · Hidden · the Rim at night · giver Night-Watcher Wyl Ashgrove*

**The short version.** Wyl has the best ear in the camp. He has noticed that the pause between the in-breath and the out-breath is getting longer, a hair at a time. Tonight it was nine seconds. He wants someone to stand with him through a full night and hold the count.

**What is really going on.** *Nothing is explained.* Through the night, the pause lengthens, and at the darkest hour the Maw holds its breath for almost a minute, and the whole camp holds theirs without being asked. Then it breathes out, softly.

**Scene 1: the Rim at midnight.**

**WYL:** "Nine seconds. Two years ago it was two."
**WYL:** "I'm not supposed to say it aloud."
**WYL:** "I would like company."
> ► **"What do you want me to do?"** — **WYL:** "Count the pause. Don't breathe until it does."
> ► **"Why not tell the marshal?"** — **WYL:** "I did. She said: *counted and kept.*"
> ► **"I'll stay."** — **WYL:** "Thank you."

**Scene 2: the pause.** The player and Wyl sit side by side on a cold stone shelf. The in-breath comes, vast and slow, then stops. Seconds pass. Ten. Twenty. Thirty. The watchers along the Rim, one by one, stop breathing too. Forty. Fifty. The air is still. The resin glimmers faintly. Somewhere far below, so low it is felt through the stones, something *shifts,* as a sleeper does when a dream is nearly done.

*(Gameplay: the player holds the button for a count; there is no failure, but long holds change the final line.)*

**WYL (whispering):** "...It's *listening.*"
> ► **(Hold your breath with it.)** — The silence deepens.
> ► **(Breathe normally.)** — The silence ends sooner, and the out-breath is a little rough.
> ► **(Speak softly into the pit.)** — Nothing answers, and the pause gets a heartbeat longer.

**Scene 3: the out-breath.** At last the Maw breathes out: slow, gentle, long.

**WYL:** "I thought it might not."
> ► **"It always does."** — **WYL:** "It *used* to."
> ► **"What do you think it's waiting for?"** — **WYL:** "I think it's waiting to be sure we're all here."
> ► **"Write it down."** — **WYL:** "I will."

**Scene 4: the Ledger.** At dawn, Wyl writes in the Breath Ledger: *"Pause, fifty-eight seconds. Held with company."*

**WYL:** "The marshal will say counted and kept."
**WYL:** "I'll say: *and not alone.*"

**Scene 5: the other watchers.** At first light, three other watchers drift over to the stone shelf and sit near them, saying nothing.

**WATCHER:** "We held it too."
**WYL:** "I know. I heard no one breathing."
**WATCHER:** "Is it always like that?"
**WYL:** "No. It has never been like that."
> ► **"Will you tell the marshal?"** — **WYL:** "We will tell her together."
> ► **"You are not alone in this."** — **WYL:** "It is the first time I have believed it."
> ► **"Get some sleep."** — **WYL:** "I will. After one more count."
*The sun comes up. Nobody speaks. Then, almost at once, they all breathe.*

**If the player speaks into the pit.** Nothing answers. But for three nights afterwards the pause is exactly one heartbeat longer than it was, and Wyl, who tells nobody, copies the player's words into the Ledger's margin in pencil, so that they can be erased if they were a mistake.

**Outcomes and receipt.**
- The pause is recorded in the Ledger. Holding the breath for the full count leaves the whole Rim in a hush the next dawn; breathing normally leaves a little tension.
- **Receipt:** a line in the player's Journal, *"Held with company,"* and a number.
- **Canon-safe:** pure seed. What the Maw is listening for, and whether it is the Hive Mother, is not stated.

<!-- quest
id: qst_maw_held_breath
title: The Held Breath
rank: SS
type: Hidden
giver: npc_wyl_ashgrove
region: reg_the_maw
level: 228
act: 5
requires_rank: SS
reward: 140000 | 6500 | 760000
sets: maw_held_breath_done
summary: A night-watcher has noticed the pause between the Maw's breaths lengthening, and wants company to hold the count through the darkest hour.
objectives:
  talk npc_wyl_ashgrove
  reach maw_rim_night_station
  choice hold_breathe_or_speak
-->
