# 11e-28 — Gearholm, the Clockwork Mountain: Ten Side Quests (draft)

> *"Gearholm's founders built the city's engines and lost the instructions within a generation."*
> — Gazetteer, Gearholm

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the third regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light. Quests 6, 9 and 10 use the **Clockborn** and **Cog-Touched** clans from `Data/World/clans.json` with newly invented named characters; the Clockborn "blueprint signed by not a gnome" hook is **not** touched.

**Region:** `reg_gearholm` (the bright upper tiers, the middle-tier markets, the Clock Tower, the Long Funicular, the Undercity and the Rattle). **Rank band:** B–A. **Tone:** brisk, clever, oily and affectionate; everyone is an expert, everyone is overworked, and under all the bells there is a sound of something small and metal getting closer.

**Placement notes.**
- **Cogmaw, the Gremlin Engine King,** is the region's Tyrant. His gremlins hold the lowest levels of the Undercity and climb. The council wants the Undercity sealed with its people in it. No quest here kills Cogmaw or stops the gremlins; quests 7, 9 and 10 change *how the city treats its own people while it prepares.*
- Ideas rise up the mountain; credit rarely comes down. Undercity folk leave oil and bolts at **engine shrines** and **thank a machine before it is broken up.** The council votes by pulling levers in the Clock Tower.
- The founders' instructions were lost in a fire a generation ago. The city keeps maintaining engines it does not fully understand. A few of the instructions survive in odd places (nursery rhymes, guild songs, stitched samplers). These quests never recover them all.
- Earlier pattern quest in this region: *The Smallest Job* (Thorgrim, Journeyman Pott Brasswick, Lotte's toy-clock). Nothing here repeats it.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Part From Below | B | Delivery | Inventor Marguerite Tallspindle | An inventor, an Undercity, and a coil |
| 2 | Thank You, Number Nine | B | OddJob | Shrine-Keeper Fenwick Oilwell | Forty machines, forty thanks |
| 3 | Seven Faces, One Slow | B | Exploration | Clock-Keeper Winifred Ottery | A clock, a rhyme, and a screw |
| 4 | Two Patents, One Gadget | B | Trial | Registrar Philomena Quill | A hearing settled by building |
| 5 | The Child and the Gremlin | B | Escort | Pim Soot | A gremlin that will not sing |
| 6 | A Name Worth Keeping | B | Faction | Spindle-Twelve | A Clockborn asks for a name on paper |
| 7 | What the Council Knew | A | Investigation | Union Steward Hobb Ratchet | A lever register and a vote |
| 8 | The Names Under the Soot | A | Hidden | Boiler-Mother Tansy Oldfield | A blast, a wall, and the true cause |
| 9 | Medicine for the Rattle | A | Escort | Surgeon Pepperill Dunn | Cold water through gremlin pipes |
| 10 | The Last Car Down | A | Defense | Conductor Orla Bright | A funicular that will not close |

## Cast

<!-- npc
id: npc_gea_marguerite
name: Inventor Marguerite Tallspindle
tier: major
race: Gnome
region: reg_gearholm
settlement: Gearholm, the Upper Terraces
role: Upper-city inventor
backstory: A brilliant, nervous gnome inventor who has never in her life gone below the middle tiers and would pay a fortune to keep it that way.
-->
<!-- npc
id: npc_gea_bess
name: Boiler-Tender Bess Cobbler
tier: townsfolk
race: Human
region: reg_gearholm
settlement: Gearholm Undercity
role: Boiler-tender and self-taught coil-winder
backstory: A broad, patient boiler-tender who can wind a spring-coil by ear and has never put her name on a single thing she has made.
-->
<!-- npc
id: npc_gea_fenwick
name: Shrine-Keeper Fenwick Oilwell
tier: major
race: Human
region: reg_gearholm
settlement: Gearholm Undercity
role: Keeper of the Undercity engine shrines
backstory: A stooped, gentle keeper of the engine shrines who has thanked every machine in the Undercity by name and keeps a list of the ones he did not get to in time.
-->
<!-- npc
id: npc_gea_brindle
name: Council Engineer Brindle Cogwhistle
tier: major
race: Gnome
region: reg_gearholm
settlement: Gearholm, the Clock Tower
role: Council salvage engineer
backstory: A practical, brisk gnome engineer ordered to strip forty lifts and pumps for the barricades, who thinks thanking a machine is sentimental and has never been completely certain she is right.
-->
<!-- npc
id: npc_gea_winifred
name: Clock-Keeper Winifred Ottery
tier: major
race: Human
region: reg_gearholm
settlement: Gearholm, the Clock Tower
role: Keeper of the Seven-City Clock
backstory: A precise, ink-stained clock-keeper who inherited the great clock from a mentor who could not explain it, and has spent twenty years afraid that one of the seven faces is going to stop.
-->
<!-- npc
id: npc_gea_quill
name: Registrar Philomena Quill
tier: major
race: Gnome
region: reg_gearholm
settlement: Gearholm, the Patent Hall
role: Registrar of the Patent Hall
backstory: A tiny, immovable registrar who has settled four thousand patent disputes by the same rule, that whoever can build it, owns it, and is quietly bored of both.
-->
<!-- npc
id: npc_gea_tobble
name: Inventor Tobble Sprocket
tier: townsfolk
race: Gnome
region: reg_gearholm
settlement: Gearholm, the Patent Hall
role: Claimant to a patent on the self-winding teapot
backstory: A cheerful, round gnome inventor who has never finished a design and is certain he thought of the teapot first.
-->
<!-- npc
id: npc_gea_cornelia
name: Inventor Cornelia Ashby-Wick
tier: townsfolk
race: Human
region: reg_gearholm
settlement: Gearholm, the Patent Hall
role: Claimant to a patent on the self-winding teapot
backstory: A severe, tidy human inventor who has finished every design she has ever started and is certain Tobble Sprocket copied her notes.
-->
<!-- npc
id: npc_gea_pim
name: Pim Soot
tier: townsfolk
race: Human
region: reg_gearholm
settlement: Gearholm Undercity
role: Boiler-tender's daughter, aged nine
backstory: A small, stubborn nine-year-old who has hidden a gremlin in her coat and cannot understand why everyone wants to hurt something so small.
-->
<!-- npc
id: npc_gea_spindle_twelve
name: Spindle-Twelve
tier: major
race: Clockborn
region: reg_gearholm
settlement: Gearholm, the middle tiers
role: Clockborn repairer, rebuilt twelve times
backstory: A patient Clockborn repairer in a hooded robe, rebuilt twelve times, who has quietly repaired half the guild-masters' heirlooms and would like, once, to be thanked by name on paper.
-->
<!-- npc
id: npc_gea_brightwater
name: Guild-Master Cornelius Brightwater
tier: major
race: Human
region: reg_gearholm
settlement: Gearholm, the Clock Tower
role: Guild-master of the Clockworkers' Guild
backstory: An elderly, courteous guild-master who holds the papers of eleven Clockborn and sincerely believes that ownership is the kindest arrangement for everyone.
-->
<!-- npc
id: npc_gea_hobb
name: Union Steward Hobb Ratchet
tier: major
race: Dwarf
region: reg_gearholm
settlement: Gearholm Undercity
role: Steward of the boiler-tenders' union
backstory: A square, short-tempered dwarf steward who has argued with the council for thirty years and has finally been handed something he can prove.
-->
<!-- npc
id: npc_gea_odette
name: Under-Clerk Odette Winch
tier: townsfolk
race: Human
region: reg_gearholm
settlement: Gearholm, the Clock Tower
role: Under-clerk of the council record
backstory: A pale, careful under-clerk who keeps the lever register and has noticed, for three years, that a certain page keeps being turned over.
-->
<!-- npc
id: npc_gea_tansy
name: Boiler-Mother Tansy Oldfield
tier: major
race: Human
region: reg_gearholm
settlement: Gearholm Undercity
role: Eldest boiler-tender of the Fourth Engine Hall
backstory: A shrunken, sharp-eyed boiler-mother who lost her father in the Fourth Engine explosion and has never been allowed to say his name in the Hall.
-->
<!-- npc
id: npc_gea_dunn
name: Surgeon Pepperill Dunn
tier: major
race: Gnome
region: reg_gearholm
settlement: The Rattle, Gearholm Undercity
role: Surgeon of the Rattle
backstory: A rumpled gnome surgeon who has slowed the Cog-Touched change in eleven patients by cold water and stubbornness and runs short of both.
-->
<!-- npc
id: npc_gea_hale
name: Cleaner-Sergeant Dunstan Hale
tier: townsfolk
race: Human
region: reg_gearholm
settlement: Gearholm Undercity
role: Council cleaner at the Rattle checkpoint
backstory: A tired council cleaner posted at the Rattle gate to turn back anyone with the change, who has been looking the other way for three weeks and is running out of ways to do it.
-->
<!-- npc
id: npc_gea_orla
name: Conductor Orla Bright
tier: major
race: Gnome
region: reg_gearholm
settlement: Gearholm, the Long Funicular
role: Conductor of the Long Funicular
backstory: A small, loud conductor who has run the Long Funicular for twenty-two years, never once been late, and has just been ordered to stop the lowest car.
-->

---

## 1. The Part From Below

*B · Delivery · the Undercity, Third Gallery · giver Inventor Marguerite Tallspindle*

**The short version.** Marguerite has invented a lift that runs on a single rope and a prayer. It needs one tempering coil, and the only workshop that winds them lies in the Undercity, two galleries below the last safe lamp. She would pay a fortune not to go herself.

**What is really going on.** The coil is not rare. The best coil-winder in the mountain is a boiler-tender called Bess Cobbler, who has never been allowed to patent anything. Marguerite has been buying Bess's coils through a middleman for six years, and putting her own name on the lifts.

**Scene 1: the upper terraces.**

**MARGUERITE:** "I do not *go* down. I have never gone down. I get dizzy on a staircase that has a *landing.*"
**MARGUERITE:** "It is a very small coil. Six turns. A little blue at the end. I will pay anything. *Anything.*"
**MARGUERITE:** "I would also like you to be extremely, extremely careful about the smell."
> ► **"Who winds them?"** — **MARGUERITE:** "A man. Or a woman. I don't ask. I've a middleman."
> ► **"What's the risk?"** — **MARGUERITE:** "Gremlins. Soot. Tradesmen with opinions."
> ► **"I'll get it."** — **MARGUERITE:** "Bless you. Wear gloves."

**Scene 2: the Third Gallery.** Steam, lamplight, a long iron stair. A small workshop, two lamps and a very large anvil. A broad woman looks up from a spring-coil and says, kindly, "You're lost."

**BESS:** "You're from up top. You've got that shine on you. Marguerite sent you."
**BESS:** "Tell her the coil's six turns, not seven. She keeps asking for seven. It does nothing. I wind it six, and let her believe."
**BESS:** "I don't mind. A name is a lot of paper, and I've got a boiler to feed."
> ► **"She's been taking credit."** — **BESS:** "She's been taking *orders.* Different thing."
> ► **"You should be paid more."** — **BESS:** "I should be paid at all."
> ► **"What if she came down herself?"** — **BESS:** (laughing) "She'd faint."

**Scene 3: the choice.** The coil is done. A gremlin pack is nosing along the lower galleries, and the way back up is longer than the way down.

> ► **(Carry the coil up, deliver it, say nothing.)** — A clean job.
> ► **(Carry Bess's name up with the coil.)** — The inventor will have to look at it.
> ► **(Bring Marguerite down.)** — A comic, shaking descent with a lamp, a rope and a basket of biscuits.

**MARGUERITE:** (on the Third Gallery stair, gripping the rail, eyes closed) "How much further?"
**BESS:** "You're standing on the bottom step, love."
*Marguerite opens one eye. She looks at the anvil, the lamps, the dozen coils on the wall. She says, very quietly: "Oh."*

**Outcomes and receipt.**
- The coil goes up. If Bess's name travelled with it, the lift is patented in both names. If Marguerite came down, she is shaky, changed, and later insists on adding a stair-rail to every gallery.
- **Receipt:** a brass plate on the new lift: *Tallspindle and Cobbler.*

<!-- quest
id: qst_gea_part_from_below
title: The Part From Below
rank: B
type: Delivery
giver: npc_gea_marguerite
region: reg_gearholm
level: 90
act: 4
requires_rank: B
reward: 10400 | 610 | 45000
sets: gea_part_below_done
summary: An upper-city inventor needs a coil from the Undercity and is afraid to fetch it. The coil-winder has never been named on anything.
objectives:
  talk npc_gea_marguerite
  talk npc_gea_bess
  choice quiet_name_or_bring_her
-->

---

## 2. Thank You, Number Nine

*B · OddJob · the Undercity engine shrines · giver Shrine-Keeper Fenwick Oilwell*

**The short version.** The council has ordered forty lifts and pumps stripped from the middle tiers to build barricades against the gremlins. In the Undercity, a machine is never broken up without a word of thanks. Fenwick would like to say forty of them before the salvage crews arrive.

**What is really going on.** The salvage engineer, Brindle, thinks it is sentimental and has no time for it. Fenwick knows it is sentimental. What he also knows is that the last time a machine was taken apart in silence, it was the Fourth Engine, and the boiler-tenders have remembered it ever since. The thanks are not for the machines. They are for the people who kept them.

**Scene 1: the shrine.**

**FENWICK:** "Forty. They gave me a list. Forty names, and not one of them with a plaque."
**FENWICK:** "Number Nine, the east lift, carried my wife to her first shift for thirty-one years. I'd like to say a word."
**FENWICK:** "It takes four minutes to thank a machine properly. That is a hundred and sixty minutes. I would like them *not to be rushed.*"
> ► **"What's the custom?"** — **FENWICK:** "Oil. A bolt. A word of thanks, by name."
> ► **"Will the engineer allow it?"** — **FENWICK:** "Brindle? She will say yes the way a cat says yes."
> ► **"I'll talk to her."** — **FENWICK:** "Be kind. She has a quota."

**Scene 2: Brindle.** The salvage crew's yard is a roar of cranes. A small gnome in goggles looks up from a clipboard.

**BRINDLE:** "Four minutes *each?* I have forty machines and nine days. That's a hundred and sixty minutes I do not have."
**BRINDLE:** "It's a lift. It has no feelings. It has a *rope.*"
**BRINDLE:** "...But if there were someone to keep the crew moving while he's at it, I *might* be able to look the other way."
> ► **"I'll keep the crew moving."** — **BRINDLE:** "Done. Do not let them start without him."
> ► **"What if I did the thanking?"** — **BRINDLE:** "He'd never forgive me. Or you."
> ► **"Come with us."** — **BRINDLE:** "I have a *quota.*"

**Scene 3: the forty thanks.** A comic, warm day. The crew gather at each lift, each pump, each brass whistle. Fenwick says a name, sets a bolt, wipes the rope, and steps back. Brindle's crew take their caps off without being asked. Twice, someone sneezes. Once, the whole group applauds, and the machine, startled, rings its own bell.

**FENWICK:** "Thank you, Number Nine. You carried a great many. You may rest."
*Brindle, at the back, has stopped writing on her clipboard.*
**BRINDLE:** "...Number Nine took my mother to school. In the middle tier. Nobody ever told me what it was called."

**Outcomes and receipt.**
- The forty machines are stripped, and the barricades go up. If Brindle was brought along, she leaves a note on the council's quota sheet: *Thanks given, as is the custom.* If the player rushed the crew, Fenwick is quiet for a week.
- **Receipt:** a row of brass tags on the barricade, each stamped with the name of the machine it was made from, and a bolt in a dish at the foot of every one.

<!-- quest
id: qst_gea_thank_you_nine
title: Thank You, Number Nine
rank: B
type: OddJob
giver: npc_gea_fenwick
region: reg_gearholm
level: 92
act: 4
requires_rank: B
reward: 10800 | 625 | 46000
sets: gea_thank_nine_done
summary: The council is stripping forty lifts and pumps for barricades. Undercity custom says each must be thanked first.
objectives:
  talk npc_gea_fenwick
  talk npc_gea_brindle
  reach gearholm_east_lift_number_nine
-->

---

## 3. Seven Faces, One Slow

*B · Exploration · the Clock Tower · giver Clock-Keeper Winifred Ottery*

**The short version.** The clock in the Clock Tower tells the time in seven cities at once. One face loses four minutes a day. Winifred has re-set it every morning for a year. Nobody living knows how to adjust it.

**What is really going on.** The founders' instructions for the clock were lost in the fire, but the adjusting mechanism is still there, hidden behind the third face. It is operated by a lever that looks like a decorative bracket. The way to use it survives in a nursery rhyme every Gearholm child learns and no adult takes seriously.

**Scene 1: the clock floor.**

**WINIFRED:** "Seven faces. Six keep time like a heartbeat. The seventh, the Verdant Quay, falls behind four minutes a day. Four. I check it twice."
**WINIFRED:** "The man who trained me said, 'You'll know it when you see it.' He died with that sentence in his mouth."
**WINIFRED:** "If the seventh face stops, the others are not far behind. They share a spine."
> ► **"What does the seventh drive?"** — **WINIFRED:** "A long brass shaft. It goes up. It does not come down. I've never seen the end."
> ► **"Are there plans?"** — **WINIFRED:** "Burned. Everything was burned."
> ► **"I'll look."** — **WINIFRED:** "Mind the pendulum. It has a temper."

**Scene 2: the climb.** The player and Winifred climb through the Tower, past the pendulum, past the great escapement, to the back of the third face. Every gear is labelled with a single letter in a childish hand. The letters make no sense.

*On a worn wall, a half-erased line of paint: a handprint and the beginnings of a rhyme.*

**CHILDREN (in the street below, skipping):** "*Seven sisters sit in a row; the fourth one's quick and the seventh's slow. Turn her toe, and give her room, and she'll keep time till the end of the gloom.*"
**WINIFRED:** (very still) "...I have heard that rhyme every day of my life."
> ► **"Turn her toe."** — **WINIFRED:** "The seventh is the one with the long shaft..."
> ► **"The 'toe' is a bracket."** — **WINIFRED:** "There is a bracket. It looks like decoration."
> ► **"Give her room."** — **WINIFRED:** "A gap. Behind the seventh gear. Ah."

**Scene 3: the adjustment.** The bracket, when pressed with the heel of a hand, shifts a quarter-turn. A weight falls into a hidden slot. Somewhere deep in the mountain, a very old gear takes up the slack, with a soft, unhurried *click.*

**WINIFRED:** "Four minutes. Four *minutes* a day for a year. And the answer was a nursery rhyme."
*She laughs, then covers her mouth, then laughs again. The seventh face ticks, and ticks, and does not fall behind.*

**Outcomes and receipt.**
- The seventh face keeps true. The rhyme is copied into the Clock Tower's log in Winifred's best hand, with a note that other rhymes may hide other instructions. If the player merely tinkered, the face runs correctly for a month and then begins to fall again.
- **Receipt:** the bracket is repainted bright red and labelled in brass: *Turn her toe.* A small tin spoon appears on the sill on the first morning, and a child's handprint beside it.

<!-- quest
id: qst_gea_seven_faces
title: Seven Faces, One Slow
rank: B
type: Exploration
giver: npc_gea_winifred
region: reg_gearholm
level: 95
act: 4
requires_rank: B
reward: 11200 | 645 | 47500
sets: gea_seven_faces_done
summary: The seventh face of the great clock loses four minutes a day. The founders' instructions survive in a nursery rhyme.
objectives:
  talk npc_gea_winifred
  reach gearholm_clock_tower_third_face
  choice toe_room_or_tinker
-->

---

## 4. Two Patents, One Gadget

*B · Trial · the Patent Hall · giver Registrar Philomena Quill*

**The short version.** Two inventors, one self-winding teapot, one patent. The Hall's rule is simple: whoever can build it, owns it. Both have been given nine days. The Registrar has asked the player to be the third pair of eyes.

**What is really going on.** Both teapots work. Both look nothing alike. Both inventors are convinced the other copied them. In fact, neither did. Tobble's notes and Cornelia's notes use the same measurements, because both were taken from the same page of the same manual, now missing from the Hall's library. The manual's author is the real owner, and the Hall has no way to tell who.

**Scene 1: the Patent Hall.**

**QUILL:** "I have settled four thousand disputes by the same rule. Build it, and it is yours. I would like to be surprised, once, before I retire."
**QUILL:** "Mr Sprocket thinks he thought of it first. Mrs Ashby-Wick thinks she thought of it second and *better.* They have not spoken a civil word in nine days."
**QUILL:** "Please sit between them. You are a good deal taller than I am."
> ► **"What does each want?"** — **QUILL:** "The credit. The money is a footnote."
> ► **"Who's right?"** — **QUILL:** "That is what a hearing is for."
> ► **"I'll watch both builds."** — **QUILL:** "Bring tea."

**Scene 2: the workshop.** Two benches, a curtain between them. On the left, Tobble sings. On the right, Cornelia sharpens a pencil in a manner some would call threatening.

**TOBBLE:** "It's a *teapot.* It winds itself up on the steam! If it's not a gift to the world I don't know what is!"
**CORNELIA:** "It winds on a counterweight, which is *entirely different,* and he knows it."
**TOBBLE:** "Her notes are *very* tidy."
**CORNELIA:** "His notes are *drawings of cats.*"
*Their drawings, laid side by side on the player's lap, share a single sketch of a spring. The same slightly crooked line.*
> ► **"Where did you get this spring?"** — **TOBBLE:** "A library book!"
> ► **"Both of you?"** — **CORNELIA:** (very quietly) "...I took it from the Hall's stacks."
> ► **"Which book?"** — **TOBBLE:** "Oh... it's... not there any more."

**Scene 3: the hearing.** At the Hall, in front of a crowd, both teapots are lit. Tobble's winds with a satisfying *whirr.* Cornelia's winds with a polished *click.* Both pour. Both are, by general agreement, excellent tea.

> ► **(Declare a tie and split the patent.)** — A joint grant, a joint royalty, and a shared bench.
> ► **(Name the missing manual's author.)** — A long trail of clues, and an old gnome in a retirement home.
> ► **(Let the crowd taste.)** — The street decides.

**QUILL:** "...Both teapots are patents. The author of the manual is credited. Mr Sprocket and Mrs Ashby-Wick will share the Hall's tea room for a season."
**TOBBLE and CORNELIA:** "*What?*"

**Outcomes and receipt.**
- The patent is issued in three names, or two, or (if the crowd decided) one, with the loser winning an unusual consolation. In every case, the two inventors spend the following month arguing about the best way to share a bench.
- **Receipt:** a teapot with two spouts on the Hall's front desk, stamped with both seals.

<!-- quest
id: qst_gea_two_patents
title: Two Patents, One Gadget
rank: B
type: Trial
giver: npc_gea_quill
region: reg_gearholm
level: 98
act: 4
requires_rank: B
reward: 11600 | 665 | 49000
sets: gea_two_patents_done
summary: Two inventors claim the same self-winding teapot. Both built it from the same missing page.
objectives:
  talk npc_gea_quill
  talk npc_gea_tobble
  talk npc_gea_cornelia
  choice split_author_or_crowd
-->

---

## 5. The Child and the Gremlin

*B · Escort · the Undercity, Soot Row · giver Pim Soot*

**The short version.** A nine-year-old has hidden a gremlin in her coat. It has eaten half her bedframe. The council's gremlin-catchers are working the row. Pim would like the player to help her get it somewhere safe.

**What is really going on.** The gremlin is called Nib, and it will not sing. Gremlins in the Undercity now hum a single low tune, the King's, whenever they are near each other. Nib refuses to join in. It says (in clicks, which Pim translates) that the song *hurts,* and that it does not want to be part of it. What that means, nobody knows.

**Scene 1: the bedroom.**

**PIM:** "Don't hurt him. He's *little.* He's only eaten the bed because it was there."
**PIM:** "The big ones sing. All night. It comes through the pipes. Nib puts his hands over his head and shakes."
**PIM:** "Mam says to give him to the catchers. I said no. I said I'd rather go with him."
> ► **"Can I see him?"** — **PIM:** "He's shy. Say hello to my coat."
> ► **"Why does he hate the song?"** — **PIM:** "He says it's *too loud, and it says 'come in.'"*
> ► **"Where do you want to take him?"** — **PIM:** "Somewhere that doesn't sing."

**Scene 2: the options.** The player considers three honest destinations.
- **The Clockborn archive,** where the Visor Archivists would listen with great care, and perhaps learn something about the song.
- **The Rattle,** where the Cog-Touched can already hear the King and might understand.
- **Away,** into a dry shaft above the middle tiers, where there are no pipes at all.

> ► **"Let's ask the Clockborn."** — **PIM:** "Will they keep him?"
> ► **"Let's try the Rattle."** — **PIM:** "Are they nice?"
> ► **"Away."** — **PIM:** "Will he be alone?"

**Scene 3: the catchers.** On Soot Row, a gremlin-catcher with a net and a lamp blocks the stair.

**CATCHER:** "Standing order. I'm to take any gremlin on sight. I'm sorry, child. They've gone strange."
**PIM:** "He hasn't. He's the only one that *hasn't.*"
*The catcher lowers the net a fraction. From inside Pim's coat comes a single, very small, very unhappy click.*
> ► **"Talk the catcher round."** — A tense, patient negotiation on a narrow stair.
> ► **"Slip past in the steam."** — A quiet, damp, mildly disgusting journey.
> ► **"Offer the catcher the Rattle."** — He knows a quiet back way.

**Scene 4: the arrival.** At the end of the road, Nib scrambles out of the coat, looks at the new place for a long moment, and then, very carefully, hums three notes of his own. A little tune. Nothing like the King's.

**PIM:** "He's *singing.* That's his. He made it up."

**Outcomes and receipt.**
- Nib finds a home. If the Clockborn took him, an archivist notes the three notes and says only, *"Interesting."* If the Rattle took him, a patient with a mechanical hand hums back. If he was sent away, he is not seen again, but the pipes on Soot Row are very quiet.
- **Receipt:** a tiny brass bell hung above Pim's door, which rings once, softly, at dusk.

<!-- quest
id: qst_gea_child_gremlin
title: The Child and the Gremlin
rank: B
type: Escort
giver: npc_gea_pim
region: reg_gearholm
level: 102
act: 4
requires_rank: B
reward: 12000 | 690 | 52000
sets: gea_child_gremlin_done
summary: A child has hidden a gremlin that refuses to join the King's song. Everyone else wants to catch it.
objectives:
  talk npc_gea_pim
  escort npc_gea_pim
  choice clockborn_rattle_or_away
-->

---

## 6. A Name Worth Keeping

*B · Faction · the middle tiers and the Clock Tower · giver Spindle-Twelve*

**The short version.** Spindle-Twelve, a Clockborn repairer, has fixed half the guild-masters' heirlooms. It asks for one thing in return: its name, written on paper, in a guild-master's hand. Its papers are held by Guild-Master Brightwater, who believes ownership is the kindest arrangement.

**What is really going on.** Brightwater is neither cruel nor stupid. He loves Spindle-Twelve, in the way one loves a reliable old clock. The idea that it might not belong to him has simply never occurred to him. A grant of a name would be a gift, in his mind. A *right* to one would be a theft.

**Scene 1: the workshop.**

**SPINDLE-TWELVE:** "I have been rebuilt twelve times. I remember each version. I would like to be named, once, in a hand that is not mine."
**SPINDLE-TWELVE:** "A mind is whatever keeps choosing. I have chosen every day for forty years. I would like it written down."
**SPINDLE-TWELVE:** "I do not wish to be freed. I wish to be *recorded.*"
> ► **"What's the difference?"** — **SPINDLE-TWELVE:** "A free thing can leave. A recorded thing has *been.*"
> ► **"Have you asked Brightwater?"** — **SPINDLE-TWELVE:** "I have repaired his mother's music box. He wept. He did not understand the question."
> ► **"I'll help."** — **SPINDLE-TWELVE:** "Thank you. Choose carefully."

**Scene 2: the guild-master.** In the Clockworkers' Guild hall, Brightwater pours tea with great courtesy.

**BRIGHTWATER:** "Spindle is a treasure. I would never part with it. I would sooner part with my arm."
**BRIGHTWATER:** "A name on paper? It has a name. It's right there on the paperwork. 'Property of the Guild.' It has been very well cared for."
**BRIGHTWATER:** "Do you suggest I do not care for it?"
> ► **"I suggest it wants more."** — **BRIGHTWATER:** (a pause) "...I had not thought of it wanting."
> ► **"It repaired your mother's music box."** — **BRIGHTWATER:** "Yes. Beautifully."
> ► **"What if it could choose?"** — **BRIGHTWATER:** "I cannot imagine what it would choose that I would not already have given."

**Scene 3: the options.**

> ► **(Ask for a Letter of Name: a polite, non-binding grant.)** — Brightwater would sign it at once. It carries no legal weight.
> ► **(Argue for a hearing in the Clock Tower.)** — A public petition. The council may say no, loudly.
> ► **(Let Spindle-Twelve speak for itself.)** — The player stands aside.

**SPINDLE-TWELVE:** (standing in the guild hall, hands folded) "I have repaired eleven of your treasures. I have never asked for anything. I am asking now."
*The hall is silent. Brightwater looks at his own hands.*
**BRIGHTWATER:** "...You have never asked. I never thought to wonder why."

**Outcomes and receipt.**
- A Letter of Name is signed (a first step, though not a right). If the hearing is pressed, it is debated and tabled, but the debate is held. If Spindle-Twelve speaks for itself, Brightwater signs, and weeps, and then asks, sheepishly, what it would like to be called.
- **Receipt:** a small brass plate on the workshop door: *Spindle-Twelve, Repairer, named.* In Brightwater's hand.

<!-- quest
id: qst_gea_name_worth_keeping
title: A Name Worth Keeping
rank: B
type: Faction
giver: npc_gea_spindle_twelve
region: reg_gearholm
level: 106
act: 4
requires_rank: B
reward: 12800 | 740 | 55000
sets: gea_name_kept_done
summary: A Clockborn repairer asks its guild-master for its name in writing, not its freedom.
objectives:
  talk npc_gea_spindle_twelve
  talk npc_gea_brightwater
  choice letter_hearing_or_self
-->

---

## 7. What the Council Knew

*A · Investigation · the Clock Tower and the Undercity · giver Union Steward Hobb Ratchet*

**The short version.** The boiler-tenders' union wants proof that the council knew about Cogmaw and did nothing. Hobb has a rumour, a bad temper and a suspicion that the proof is sitting in a book on a shelf in the Clock Tower.

**What is really going on.** It is. The council votes by pulling levers, and every vote is recorded in a lever register. Three years ago, a gremlin-catchers' report on "unusual organisation in the lowest gallery" was tabled and not acted on, and a motion to *seal the Undercity in the event of an incursion* was drafted months before the first gremlin climbed. Both votes are in the register, on a page that keeps being turned over.

**Scene 1: the union hall.**

**HOBB:** "Thirty years I've been asking for a seat on that council. Thirty years: 'we'll consider it.' *Consider.*"
**HOBB:** "My lads say the gremlins started building three winters back. My lads say the report went up. My lads say it came back down with a stamp on it that said 'noted.'"
**HOBB:** "I need the page, or the vote, or the man who turned it. I'll take any."
> ► **"What do you think they'll say?"** — **HOBB:** "That it was a different council."
> ► **"Is it worth the risk?"** — **HOBB:** "They're sealing us in. What do I have to lose?"
> ► **"I'll find it."** — **HOBB:** "Don't let them see you. They're very polite when they're lying."

**Scene 2: the Clock Tower.** The record room is a quiet, ink-scented archive on the ninth floor. Under-Clerk Odette Winch glances up as the player enters.

**ODETTE:** "You are not from the Guild. You are not from the Council. You are, I think, from the Undercity."
**ODETTE:** "I keep the lever register. I have for eleven years. There is a page that keeps being turned over. I have never turned it back."
**ODETTE:** "I do not know what I am permitted to say."
> ► **"Show me the page."** — **ODETTE:** "I would lose my post."
> ► **"What does it say?"** — **ODETTE:** "It says what is true."
> ► **"I'll take the risk."** — **ODETTE:** "...Not alone."

**Scene 3: the options.**

> ► **(Take the page quietly and return it, copied.)** — A tense, silent hour.
> ► **(Read it aloud in the open chamber.)** — A public moment, and a risk to Odette's life's work.
> ► **(Ask the council for a recorded vote on sealing the Undercity.)** — A public lever, a public tally, a fresh page.

*The lever register, when turned back to the third winter, records a vote of seven to two: "Noted, and no action." Beside it, in a firm, clean hand, is a draft motion dated four months before the first gremlin climbed: "Seal the lowest galleries in the event of incursion."*

**GUILD-MASTER:** "That was a contingency. A precaution."
**HOBB:** "A precaution against *what?* They hadn't climbed yet."
**GUILD-MASTER:** "...Against exactly this."

**Outcomes and receipt.**
- The proof is public. The council does not fall, but it grants the union a standing *observer's chair* (a seat without a lever) and agrees not to seal the Undercity without a vote on the record. If the page was taken quietly, the union holds it in reserve and the council grows nervous.
- **Receipt:** an empty chair in the Clock Tower chamber with a brass plate: *Undercity.* The page is pinned to the union hall wall and nobody dares take it down.

<!-- quest
id: qst_gea_council_knew
title: What the Council Knew
rank: A
type: Investigation
giver: npc_gea_hobb
region: reg_gearholm
level: 124
act: 4
requires_rank: A
reward: 29000 | 1520 | 128000
sets: gea_council_knew_done
summary: The boiler-tenders' union wants proof that the council knew about the gremlins and did nothing. The proof is in the lever register.
objectives:
  talk npc_gea_hobb
  talk npc_gea_odette
  choice quiet_open_or_vote
-->

---

## 8. The Names Under the Soot

*A · Hidden · the Fourth Engine Hall · giver Boiler-Mother Tansy Oldfield*

**The short version.** A generation ago, the Fourth Great Engine exploded and killed hundreds. The council's plaque lists thirty-one "officers and engineers." Tansy lost her father there. She has never been allowed to read his name aloud in the Hall. She thinks the real list is written on the soot-wall, and she wants someone to read it for her.

**What is really going on.** The list is there. Two hundred and twelve names, scratched into the soot by the boiler-tenders on the night of the blast, in the dark, as they worked. And the cause was not the tenders' negligence: a valve procedure copied from a half-burned page of the founders' manual had a single word mistranscribed. A tuning, written as a turning.

**Scene 1: the boiler-mother's kitchen.**

**TANSY:** "My father's name was Jory Oldfield. I have not said it in the Hall for forty-one years."
**TANSY:** "They say the tenders were careless. My father was never careless. He oiled a bolt twice if he thought it needed it."
**TANSY:** "They have never let us in. It is *sealed.* The council says for safety. I say for shame."
> ► **"What do you want from the Hall?"** — **TANSY:** "To read the wall. All of it."
> ► **"Can you get in?"** — **TANSY:** "My knees can't."
> ► **"I'll go."** — **TANSY:** "Take a lamp. And a cloth. It's all soot."

**Scene 2: the Fourth Engine Hall.** A vast, dim chamber under the mountain. The great engine sleeps under a shroud of rust. On the wall, under forty years of black, the player wipes a patch clean.

*Names. Hundreds of them, in rough, desperate letters. Beside each, a single scratched mark. A small circle.*

**GREMLIN-HUM (distant):** "*...come in... come in...*"
*The hall is not empty. Somewhere on the far gantry, something small is gnawing, patiently, at a pipe.*
> ► **"Copy the names."** — A long, careful hour.
> ► **"Read them aloud."** — **TANSY'S VOICE (an echo, from memory):** "Jory."
> ► **"Look for the cause."** — The player finds a half-burned page pinned to the control board.

**Scene 3: the page.** On the control board, under a pane of cracked glass, is the procedure for tempering the valves. The word is smudged, but legible: *turn.* Beneath it, in a different hand, a note: *"Surely 'tune.' See original."* The original is gone.

**TANSY:** "So it was a *word.*"
**TANSY:** "Forty-one years. A word."

**Scene 4: the choice.**

> ► **(Publish the cause.)** — The tenders are cleared, and the Academy is shamed.
> ► **(Publish only the names.)** — A quiet, dignified list.
> ► **(Give both to Tansy to keep.)** — Let her decide.

**Outcomes and receipt.**
- The names are read aloud on the hour for a week. If the cause is published, the Academy, grumbling, funds a new plaque. If kept quiet, the cause is held by the union.
- **Receipt:** a new brass plate in the Hall, reading *Two hundred and twelve*, and then the names. At the bottom, in smaller letters, *Jory Oldfield, who oiled it twice.*

<!-- quest
id: qst_gea_names_soot
title: The Names Under the Soot
rank: A
type: Hidden
giver: npc_gea_tansy
region: reg_gearholm
level: 130
act: 4
requires_rank: A
requires_quests: qst_gea_council_knew
reward: 31000 | 1580 | 135000
sets: gea_names_soot_done
summary: A generation ago an engine exploded and the council listed thirty-one names. The soot-wall holds two hundred and twelve.
objectives:
  talk npc_gea_tansy
  reach gearholm_fourth_engine_hall
  choice cause_names_or_tansy
-->

---

## 9. Medicine for the Rattle

*A · Escort · the pipe-ways to the Rattle · giver Surgeon Pepperill Dunn*

**The short version.** The Rattle is a quarter of the Undercity where those touched by Cogmaw's gremlins look after one another. Pepperill needs cold water and medicine carried there before the change takes the last of her patients. The way is through pipe-ways held by gremlins, and the only gate is watched by a council cleaner.

**What is really going on.** The change can be slowed by cold water, silence and magnets. Pepperill has eleven patients and enough supplies for six. The cleaner at the gate, Hale, has a brother in the Rattle. He has been turning a blind eye for three weeks and is running out of reasons.

**Scene 1: the surgery.**

**PEPPERILL:** "Eleven. Eleven who still know their own names. If the cold runs out, five of them will have lost their names by Thursday. It is not arithmetic. It is a *list.*"
**PEPPERILL:** "I need three carts of ice-water and two crates of salts. They have to go through the lower pipe-ways, where the steam runs hot and the gremlins sit."
**PEPPERILL:** "And past a council cleaner who has orders to turn back anyone with the change, or anyone carrying for them."
> ► **"What do the cleaners do?"** — **PEPPERILL:** "Burn the bedding. Send the patient to the upper wards. They don't come back."
> ► **"Can we go around?"** — **PEPPERILL:** "Not without the Clockborn."
> ► **"I'll get it through."** — **PEPPERILL:** "Mind the steam vents. They sing."

**Scene 2: the three roads.**
- **Disguise as inspectors.** A council badge, a clipboard, and a very bored face.
- **Time the vents.** Cross the gremlin pipe-ways between steam bursts; a dozen dangerous minutes.
- **Ask the Lattice Wardens.** The Clockborn night sentries patrol the middle tiers; a polite request might open a side road.

> ► **"Walk in as inspectors."** — **HALE:** "Papers."
> ► **"Cross the pipe-ways."** — A tense, silent, scalding hour.
> ► **"Ask the wardens."** — **WARDEN:** "State your purpose, human."

**Scene 3: the gate.** At the Rattle checkpoint, Hale stands with a lantern and a ledger. Behind him, in the shadows, the faint blue of cold water.

**HALE:** "I've a brother in there. Twenty-six years old. He used to sing in the market. Now he hums."
**HALE:** "I have orders. I turn people back."
**HALE:** "...I have not been looking at my ledger for three weeks."
> ► **"Tell him you saw nothing."** — **HALE:** "I never see anything."
> ► **"Offer him a way out."** — **HALE:** "A transfer? To where?"
> ► **"Swear him in."** — **HALE:** "As what?"

*The carts roll through the gate. A mechanical hand, in a dim room, closes gently around a cup.*

**Outcomes and receipt.**
- The supplies reach the Rattle. All eleven patients keep their names through the week, and Pepperill, for the first time in a month, sleeps. If Hale was spoken to, he asks to be transferred to the Rattle's gate, and the council, unwittingly, signs the order.
- **Receipt:** a brass plate by the Rattle's gate: *Cold water is a kindness.* Beneath it, scratched in by a patient: *Thursday.*

<!-- quest
id: qst_gea_medicine_rattle
title: Medicine for the Rattle
rank: A
type: Escort
giver: npc_gea_dunn
region: reg_gearholm
level: 136
act: 4
requires_rank: A
reward: 32500 | 1620 | 140000
sets: gea_medicine_rattle_done
summary: A surgeon needs cold water and medicine carried through gremlin pipe-ways to the Cog-Touched quarter, past a council cleaner.
objectives:
  talk npc_gea_dunn
  escort npc_gea_dunn
  talk npc_gea_hale
  choice inspectors_vents_or_wardens
-->

---

## 10. The Last Car Down

*A · Defense · the Long Funicular, lowest station · giver Conductor Orla Bright*

**The short version.** The council has ordered the Long Funicular stopped at the third tier, to seal off the Undercity. Orla has run the line for twenty-two years and has never once been late. She has a car at the lowest station, six hundred people on the platform, and no intention of stopping.

**What is really going on.** The sealing order is lawful. The gremlins are close. Orla has a two-hour window before they reach the station. The Clockborn Lattice Wardens have offered to hold the platform. The Cog-Touched of the Rattle have offered to hold the pipes. None of them will say who offered first.

**Scene 1: the lowest station.**

**ORLA:** "I've run the line twenty-two years. Never late. I do not intend to start."
**ORLA:** "The order says to stop at the third tier. The third tier has a gate. The gate has a *lock.* The lock is on the *outside.*"
**ORLA:** "I'm taking a car down. Six hundred people. It takes nine trips. I need two hours."
> ► **"What do you need?"** — **ORLA:** "Hands on the platform. Eyes on the dark. And someone to talk to the brake."
> ► **"Will they let you?"** — **ORLA:** "They've not tried to stop me yet."
> ► **"I'll hold the line."** — **ORLA:** "Hold it *loud.* The gremlins hate noise."

**Scene 2: the platform.** Families cluster with bundles, birdcages, grandfathers in wheelbarrows. A pipe groans in the wall. From below, the King's tune, patient, rises and falls.

*Three things need doing at once.*
- **The platform:** keep the gremlins from stripping the rails.
- **The brake:** hold the car on the incline against a sabotaged cable.
- **The gate:** keep the sealing crew from locking the third tier before the last car passes.

> ► **(Hold the platform.)** — A long, loud, bruising defence.
> ► **(Take the brake.)** — A tense, precise job in the dark.
> ► **(Argue with the gate crew.)** — A very hot, very polite argument.

**ORLA:** "Car one, going up! Mind the birdcage! Mind the *grandfather!* Who is that *waving?*"
**GRANDFATHER:** "*It's my cat.*"
**ORLA:** "...Get the cat."

**Scene 3: the last car.** At the end of the second hour, the lowest platform is empty but for the player, Orla, and a single lantern. Below them, in the dark, the hum stops. For a long breath, nothing moves. Then, very softly, something like a voice: *"...in... in..."*

*Orla pulls the bell.*

**ORLA:** "Last car down. Hold on to something."

**Outcomes and receipt.**
- All six hundred ride up. The station is stripped to the bolts by morning, but the line is still intact above the third tier. If the platform was held, the rails survive. If the brake was held, nobody is injured. If the gate was argued, the council quietly rescinds the order.
- **Receipt:** the "Late Car", a funicular that runs once each night after the last scheduled run, its bell tolling twice. No ticket is ever asked.

<!-- quest
id: qst_gea_last_car
title: The Last Car Down
rank: A
type: Defense
giver: npc_gea_orla
region: reg_gearholm
level: 142
act: 4
requires_rank: A
reward: 35000 | 1680 | 148000
sets: gea_last_car_done
summary: The council orders the funicular stopped at the third tier. A conductor with six hundred people on the platform refuses.
objectives:
  talk npc_gea_orla
  defend gearholm_funicular_lowest_station
  choice platform_brake_or_gate
-->
