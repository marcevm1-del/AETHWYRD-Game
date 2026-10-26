# 11e-01 — Whisperwood and Millbrook: Ten Side Quests (draft)

> *"Every adventurer's first map is a map of this wood. Most of them never notice it was already full of people."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the 100-quest side-quest set (see [[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks in this file are read by `Tools/quests/build_side_quests.js` to produce the game data; edit them together with the prose. Spoilers: this region is spoiler-light.

**Region:** `reg_whisperwood` (Whisperwood, the Hush, Millbrook, the old-road waystations). **Rank band:** F–E. **Tone:** cozy, small, kind. These ten are meant to be played between the main beats of Act I and II; none is required.

**Placement notes.**
- The Hollowpine goblins are *besieged* territory until the Goblin Chief falls (`tyrant_slain_reg_whisperwood`). Quests that need the goblins at the table are gated on that flag.
- Millbrook is listed under Whisperwood in `regions.json`. These quests use `reg_whisperwood`; the existing Millbrook quests use `reg_aldmere` (see the Canon §6 region question).
- Named monsters never hold personal grudges (Canon §4d). Nobody here "remembers" the player's fights.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Bread on the Step | F | OddJob | Nan Corrow | Gentle ghost story |
| 2 | Glowcap Night | F | Gathering | Fenna Tilly | Festival, a small moral choice |
| 3 | The White Stag | E | Exploration | Wren Ashbourne | Quiet, protective |
| 4 | The Mill That Ran Backwards | E | Investigation | Hesper Dunn | A negotiation with a child spirit |
| 5 | Lost in the Hush | E | Escort | Marit Holloway | Silence as a mechanic |
| 6 | The Last Contract of the Silver Ladle | E | Escort | Tobias Pryce | Old heroes, one more time |
| 7 | Lanterns, Not Lamp Oil | E | Faction | Pocket | Comic labour dispute |
| 8 | The Wolf Who Counted Sheep | E | Subjugation | Tilda Cobb | Mercy or bounty |
| 9 | Stew Diplomacy | E | Faction | Grandmother Brub | The goblin clans at one table |
| 10 | Eight Lamps and an Empty Niche | E | Exploration | Eolande Fairweather | A seed, left open |

## Cast (new supporting NPCs)

<!-- npc
id: npc_nan_corrow
name: Nan Corrow
tier: townsfolk
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Millbrook grandmother, keeper of the bread step
backstory: A brusque, kind widow who has left a loaf on the old waystation step every dusk since she was a girl, because her grandmother did, and her grandmother's grandmother before her.
secret: She has never once been sure why she does it.
-->
<!-- npc
id: npc_linnet_holloway
name: Linnet Holloway
tier: townsfolk
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Seven-year-old who visits her grandfather
backstory: A small, fearless seven-year-old who has learned to sign with her hands so that she can talk to her grandfather, and who has decided that the grown-ups are being silly.
-->
<!-- npc
id: npc_fenna_tilly
name: Fenna Tilly
tier: townsfolk
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Weaver, aunt to the Glowcap twins
backstory: A cheerful weaver who runs Millbrook's yearly Glowcap Night and has strong opinions about who counts as a fair winner.
-->
<!-- npc
id: npc_hesper_dunn
name: Hesper Dunn
tier: major
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Miller of Millbrook
backstory: A harried, practical miller whose family wheel has run the same stream for five generations, and who has never once had a quiet week.
-->
<!-- npc
id: npc_marit_holloway
name: Marit Holloway
tier: townsfolk
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Charcoal burner, mother of Linnet
backstory: A tired charcoal burner who works from dawn to dusk and has told her daughter a hundred times not to go past the last marker stone.
secret: She sent her own father away because his shouting frightened the children.
-->
<!-- npc
id: npc_tobias_pryce
name: Tobias "Ladle" Pryce
tier: major
race: Human
region: reg_whisperwood
settlement: Millbrook
role: Retired adventurer, Silver Ladle party
backstory: A boastful former B-Rank shield-bearer who retired to Millbrook forty years ago and has told every story twice since. He keeps a ladle on his belt as a joke that stopped being funny.
-->
<!-- npc
id: npc_pocket_kobold
name: Pocket
tier: major
race: Kobold
region: reg_whisperwood
settlement: Whisperwood quarry
role: Kobold foreman, quarry crew
backstory: A small, fierce kobold foreman who speaks of himself in the third person and has never once forgotten a promise made to his crew.
-->
<!-- npc
id: npc_tilda_cobb
name: Tilda Cobb
tier: townsfolk
race: Human
region: reg_whisperwood
settlement: Cobb Farm
role: Shepherd girl
backstory: A stubborn twelve-year-old who has kept her family's fluffcap flock alone since her father's leg broke, and who talks to the flock more than to people.
-->
<!-- npc
id: npc_grandmother_brub
name: Grandmother Brub
tier: major
race: Goblin
region: reg_whisperwood
settlement: Hollowpine
role: Moss-Tooth clan cook
backstory: An ancient, shrewd goblin cook of the Moss-Tooth clan who believes every war can be ended with the right bowl of soup, and has the recipes to prove it.
-->

---

## 1. Bread on the Step

*F · OddJob · Millbrook · giver Nan Corrow*

**The short version.** Every dusk, Nan leaves a loaf on the steps of a ruined waystation outside Millbrook, for travellers who never came home. Tonight the bread is gone before she turns around.

**What is really going on.** The traveller did come home. He is eighty years late. He is a courier called **Pellam Ketch**, who died in a storm on the old road with a letter in his coat, and he has been trying to deliver it ever since. The letter is for Nan's grandmother.

**Scene 1: the offer (Millbrook, dusk).**

**NAN:** "Chick. Sit. No, you're not too busy. Nobody's too busy for bread."
**NAN:** "Every dusk, one loaf on the step of the old waystation. My gran did it. Her gran did it. Nobody can tell me why. 'For the ones who never came home.' That's all they ever said."
**NAN:** "Tonight I turned my back for the length of a sneeze, and the loaf was *gone*. Not eaten. Not taken. *Gone.* And the step was warm."
> ► **"A fox?"** — **NAN:** "Foxes leave crumbs. I know crumbs."
> ► **"Maybe somebody's hungry."** — **NAN:** "Then they can ask. I've never turned anyone away from this door."
> ► **"I'll stay until dark."** — **NAN:** "Good chick. Take a blanket."

**Scene 2: the waystation (night).** The ruin is quiet. A ring of pale footprints leads in from the road; each one is slightly smaller than the last. At the step a figure forms: a lean man in a rain-cape the colour of old paper, a satchel at his hip.

**PELLAM:** "Good evening. Forgive me. I do not wish to alarm you."
**PELLAM:** "I am Pellam Ketch, courier of the Royal Road Post. I have a letter for the Corrow house at Millbrook, and I am extremely late."
**PELLAM:** "The road took a turn I did not expect. I have been trying to find the house ever since. Every evening, someone leaves bread on this step, and I think: *this is a house that remembers its guests.* So I come back."
> ► **"How late are you?"** — **PELLAM:** "I have lost count of the harvests. Eighty, perhaps. I stopped keeping the ledger when the ink faded."
> ► **"Can I take the letter?"** — **PELLAM:** "You may *carry* it. It must be *delivered*. I am sorry. The Post is particular."
> ► **"Why a loaf of bread?"** — **PELLAM:** "It is the oldest rule of the road. A traveller who is fed is not yet lost."

He hands you the satchel. Inside is a single letter, waxed shut, the seal a plain thumbprint.

**Scene 3: the delivery.** Nan takes the letter at her kitchen table. She reads the name on the front twice.

**NAN:** "That's my gran's name. That's Aldith Corrow."
*She breaks the seal. She reads in silence for a long time.*
**NAN:** "It's from Edmund. My grandfather. He was a soldier of the old levy. He says: *I'll be home by harvest, love. Keep the step warm.*"
**NAN:** "She did, you know. Her whole life. She kept the step warm. She said he'd come by when he could. I thought she was an old woman who liked a ritual."
> ► **(Read it aloud with her.)** — Nan hears it twice; she laughs, then does not.
> ► **(Leave her to read it alone.)** — Nan thanks you quietly the next day.

**Scene 4: the last loaf.** At dusk the next day Nan puts out a loaf; Pellam is on the step, brighter than before.

**PELLAM:** "Madam Corrow. Letter delivered, receipted. The Post thanks you."
**NAN:** "You sit down and eat, you daft man. You've walked eighty years."
**PELLAM:** "I... may I? ... Is the bread still warm?"
**NAN:** "It's always warm."

**Outcomes and receipt.**
- Both branches release Pellam. The *read aloud* branch gives Nan a line about the player in the Millbrook inn; the *alone* branch gives the player a private thank-you item.
- **Receipt:** the waystation step now glows faintly at dusk; the loaf is still gone every evening, and now Millbrook's children leave a second one.
- **Proposed item (flavour, not in data):** *Royal Road Post satchel*, an empty, very old bag.

<!-- quest
id: qst_ww_bread_on_the_step
title: Bread on the Step
rank: F
type: OddJob
giver: npc_nan_corrow
region: reg_whisperwood
level: 4
act: 1
requires_flags: guild_registered
reward: 80 | 9 | 230 | itm_healing_herb
sets: ww_bread_step_resolved
summary: Nan's bread vanishes from a ruined waystation step every night. The thief is an eighty-year-late courier with a letter for her grandmother.
objectives:
  reach whisperwood_waystation_step
  talk npc_nan_corrow
  choice read_aloud_or_leave_alone
-->

---

## 2. Glowcap Night

*F · Gathering · Millbrook · giver Fenna Tilly*

**The short version.** Once a year Millbrook's children go into the edge of the wood with jars and lantern moths to catch the first glow of the glowcaps. The prize is the Lantern of the Year. Two twins want it, for different reasons.

**What is really going on.** **Dob** wants to win. **Wick** wants to *free* the biggest moth he finds, because last year one died in a jar. They have not told each other.

**Scene 1: the rules.**

**FENNA:** "Glowcap Night! Oldest festival in Millbrook after Harvest Home and the Great Pie Quarrel. The rules are simple."
**FENNA:** "One jar. One hour. Glowcaps only, no moths in the jar, and *no cheating*. I'm looking at you, Dob."
**DOB:** "I never cheated!"
**FENNA:** "You never *got caught*, which is a different skill."
**FENNA:** "My nephews need a grown-up to walk them to the glowcap dell. You'll do. You have a sword, which is more than I have."

**Scene 2: the dell.** Lantern moths drift like slow stars. The twins argue as they work.

**DOB:** "The big caps are by the stump. I know where, and I'm not telling Wick."
**WICK:** "I'm not racing. I just want to see the moths."
**DOB:** "That's what losers say."
> ► **"Share the work."** — Both twins grumble, then fill the jar faster than either could alone.
> ► **"Let each go their own way."** — Dob sprints ahead; Wick lingers; you walk the middle.

**Scene 3: the moth.** At the stump the glowcaps burn blue-white. In a net of spider silk, a great lantern moth is tangled, beating its wings.

**WICK:** (very quietly) "That's the biggest one I ever saw."
**DOB:** "Put it in the jar. It'll win by a mile."
**WICK:** "It'll *die* in the jar."
**DOB:** "It's a moth!"
**WICK:** "Last year's was a moth, too."
*Dob's face changes. He didn't know.*
> ► **"Free the moth."** — You cut the web. It circles once and the whole dell brightens.
> ► **"Take it, but keep the jar open."** — A compromise that satisfies nobody and works anyway.
> ► **"Ask the twins what they want."** — They do not agree. They say it out loud, for the first time.

**Scene 4: the judging.** At the village green, jars are lifted. The winning lantern is the jar with *the most glowcaps*, but a ring of freed moths follows the twins home like a halo.

**FENNA:** "...I've been running this festival thirty years. I've never seen the moths *follow* someone."
**FENNA:** "The Lantern goes to... both of them. Share it. It's heavy anyway."

**Outcomes and receipt.**
- The player decides who is right; the twins reconcile in every branch. Which branch you pick sets Dob's and Wick's lines for the rest of the save.
- **Receipt:** at dusk the dell glows blue-white year-round, and a ring of moths follows the twins around Millbrook.
- **Postcard moment:** the first time the player sees the Hush by lantern light.

<!-- quest
id: qst_ww_glowcap_night
title: Glowcap Night
rank: F
type: Gathering
giver: npc_fenna_tilly
region: reg_whisperwood
level: 5
act: 1
requires_flags: guild_registered
reward: 70 | 8 | 200 | itm_healing_herb
sets: ww_glowcap_night_resolved
summary: Millbrook's children gather glowcaps for the Lantern of the Year. One twin wants the prize; the other wants to free a moth.
objectives:
  reach whisperwood_glowcap_dell 3
  choice free_share_or_ask
-->

---

## 3. The White Stag

*E · Exploration · the Hush · giver Wren Ashbourne*

**The short version.** Wren has tracked the White Stag for ten years without ever drawing her bow. She asks you to help her find where he sleeps, and she will not say why.

**What is really going on.** She is not hunting him. She is trailing him because the White Stag *leads the last herd of Whisperwood's white deer away from poachers*. Wren's habit is to learn where he goes so she can warn the herd. She has never told anyone, because the poachers include people she knows.

**Scene 1: the treehouse (dawn).**

**WREN:** "You're quiet. Good."
**WREN:** "Ten years. A stag. White as a candle. I've seen him eighty-one times. I have never once drawn."
**WREN:** "You'll ask why."
> ► **"Why?"** — **WREN:** "Not yet."
> ► **"I won't ask."** — **WREN:** "...Good. Come."

**Scene 2: the track.** The Hush swallows sound. Hoofprints cross a stream and vanish onto bare stone. Wren points without speaking. Her hand signals are crisp, wordless, a language the player slowly learns: *stop, wait, stay low, look.*

**WREN:** (whisper) "He doubles back at the third stone. He always does."
**WREN:** "He's testing me. Every time I pass, he waits. Every time I fail, he leaves."
> ► **"He's testing you?"** — **WREN:** "He's *teaching* me. I just don't know what."

**Scene 3: the hollow.** At the bottom of a ravine, six white fawns lie in a bed of moss. A fox-snare has been set at the entrance. A bootprint is pressed into the mud.

**WREN:** "There."
*She does not draw. She kneels and cuts the snare.*
**WREN:** "That's why. I couldn't shoot him because he's *keeping the last of them alive*. And someone is paying for white pelts in Aldmere."
**WREN:** "I know the boot. It's Hobb, the trapper's boy. He's nineteen. His mother owes the fur dealer in Ashby."
> ► **"Tell the Guild."** — **WREN:** "Then Hobb hangs for something his mother started. ...I won't stop you."
> ► **"Talk to Hobb first."** — **WREN:** "Good. He listens to people who bring him bread."
> ► **"Set a ward against the snares."** — **WREN:** "A ward lasts a year. A promise lasts longer."

**Scene 4: the stag.** At the edge of the hollow stands the White Stag, light as breath.

**WREN:** "He's looking at you."
*He steps forward, lowers his head, and touches the player's hand with his nose. Then he turns and leads the fawns out of the ravine, through the moonlight.*
**WREN:** "He's never done that. Not once."

**Outcomes and receipt.**
- **Guild report:** Hobb is fined; the fur dealer is named; Wren is quiet for a week.
- **Talk to Hobb:** he gives up trapping, apprentices to Wren, and the Ashby dealer loses a supplier.
- **Ward:** a short-term fix; Wren returns to the player in Act III with a longer-term idea.
- **Receipt:** the White Stag becomes a rare, peaceful sighting at dawn; Wren's treehouse has a white antler on the wall.

<!-- quest
id: qst_ww_white_stag
title: The White Stag
rank: E
type: Exploration
giver: npc_wren_ashbourne
region: reg_whisperwood
level: 12
act: 1
requires_flags: rank_e_reached
reward: 240 | 18 | 780
sets: ww_white_stag_resolved
summary: Wren has tracked the White Stag for ten years without ever drawing her bow. The stag is guarding the last white fawns from poachers.
objectives:
  reach whisperwood_stag_ravine
  talk npc_wren_ashbourne
  choice report_talk_or_ward
-->

---

## 4. The Mill That Ran Backwards

*E · Investigation · Millbrook · giver Hesper Dunn*

**The short version.** The Millbrook wheel has started turning the wrong way every night at moonrise, grinding wheat into dust and spoiling the flour. Hesper wants it fixed before the Harvest Home bake.

**What is really going on.** A new weir upstream has choked a small brook that was home to a river child, a young undine called **Little Brindle**, who does not know how to ask for help and so has *turned the wheel herself*, to be noticed.

**Scene 1: the mill.**

**HESPER:** "Look at it. LOOK at it. Backwards! At night! I have flour in my hair, flour in my *boots*, and a hundred loaves due for Harvest Home!"
**HESPER:** "My grandmother ran this wheel. Her grandmother ran this wheel. Nothing like this has ever happened, and I will *not* be the one who tells the village the mill is haunted."
> ► **"It might be a spirit."** — **HESPER:** "Don't say that word in my mill."
> ► **"I'll watch tonight."** — **HESPER:** "Please. And bring a mop."

**Scene 2: the night watch.** At moonrise the wheel groans, stutters, and turns against the current. In the shallows, a girl-shaped ripple stands on the water, ankle-deep in her own reflection.

**BRINDLE:** "Hello! Hello hello hello! You can see me!"
**BRINDLE:** "Nobody looks. I turn the wheel and turn the wheel and nobody looks, only the miller, and she shouts."
**BRINDLE:** "My brook is going away. Somebody put a wall in it. I can't swim up. I can't swim *down*."
> ► **"You turned the wheel?"** — **BRINDLE:** "Yes! It was the only thing that *listened*."
> ► **"Where does your brook start?"** — **BRINDLE:** "Up, up, up, past the three oaks. It's gone thin."

**Scene 3: the weir.** Upstream, a new log weir diverts the brook into a pond the charcoal burners dug for quenching. A burner's apprentice, Joss, is embarrassed.

**JOSS:** "We didn't know there was anyone *in* it."
**JOSS:** "I'll lose three weeks' work if we move the weir. But... I was a kid once. I used to talk to the brook."
> ► **"Make a fishway."** — A compromise: the pond stays; a side channel keeps the brook alive.
> ► **"Take the weir down."** — Joss's boss is furious; Brindle swims home.
> ► **"Ask Brindle to move."** — She is heartbroken; the brook is reborn elsewhere.

**Scene 4: the quiet.** At moonrise the wheel turns the right way. Flour is white again. Brindle sits on the sluice with her feet in the race.

**BRINDLE:** "It's the same wheel. But it's *wrong* to turn it for me. I'll turn it for you if you ask nicely."
**HESPER:** (to the empty sluice) "...Thank you. And, um, would you mind turning it a bit slower?"

**Outcomes and receipt.**
- **Fishway:** the best outcome; Brindle becomes a friendly spirit who gifts the mill a lucky flour sack.
- **Weir removed:** the charcoal burners lose a week; Joss quietly pays the player back in charcoal.
- **Brindle moves:** the spirit returns once a year, melancholy.
- **Receipt:** Millbrook's loaves are *very* good this Harvest Home; the Brindle brook has a small carved stone on its bank.

<!-- quest
id: qst_ww_mill_runs_backwards
title: The Mill That Ran Backwards
rank: E
type: Investigation
giver: npc_hesper_dunn
region: reg_whisperwood
level: 11
act: 1
requires_flags: rank_e_reached
reward: 250 | 18 | 800
sets: ww_mill_resolved
summary: Millbrook's wheel turns backwards every night. A displaced river child is doing it to be noticed.
objectives:
  reach millbrook_mill_night
  talk npc_hesper_dunn
  reach brindle_weir
  choice fishway_remove_or_relocate
-->

---

## 5. Lost in the Hush

*E · Escort · the Hush · giver Marit Holloway*

**The short version.** Seven-year-old Linnet has gone past the last marker stone into the Hush, where sound dies. Her mother cannot follow because she cannot hear herself think.

**What is really going on.** Linnet is not lost. She is visiting her grandfather, **Anselm Dray**, a deaf ex-bard who lives in the Hush because noise hurts him. Marit sent him away years ago; Linnet has been carrying him bread in secret.

**Scene 1: the road.**

**MARIT:** "She went *past the stone*. I told her. I told her a hundred times."
**MARIT:** "The Hush swallows sound, you know. You can scream and no one hears. Gods, if she's calling and I can't—"
> ► **"I'll find her."** — **MARIT:** "Take my lantern. Light carries where sound doesn't."
> ► **"Where was she heading?"** — **MARIT:** "I don't *know*. She just *went*."

**Scene 2: into the silence.** At the marker stone, the music thins. Your footsteps vanish. Subtitles replace speech: the System Voice, gently, in brackets.

**[SYSTEM]** *Environmental suppression detected. Verbal commands unavailable. Lantern signals recommended.*

Lantern moths flicker in a long line. Following them, you find a small blue ribbon on a branch, then a shoe, then another.

**Scene 3: the hut.** A low hut covered in moss. A child sits cross-legged on the porch, signing with her hands to an old man who signs back.

**LINNET:** *(signing; subtitled)* "Grandpa says the quiet is better. He says it doesn't *hurt*."
**ANSELM:** *(signing)* "I am sorry to frighten your mother. I am sorry to have been frightened of her."
*He looks at you.*
**ANSELM:** "Will you take her home? She will not go alone, and I cannot walk her."
> ► **"Come with us."** — **ANSELM:** "The noise... I cannot."
> ► **"Bring your mother here."** — **ANSELM:** "That would be... kind."
> ► **"I'll tell Marit the truth."** — **ANSELM:** "Then you must tell all of it."

**Scene 4: the reunion.** Back at the marker stone, Marit hugs Linnet so hard the child squeaks.

**MARIT:** "Where were you?"
**LINNET:** "Visiting Grandpa."
*Silence. Marit's face goes through four emotions.*
**MARIT:** "...Is he well?"
> ► **"He's well. He misses you."** — Marit weeps.
> ► **"He lives in the Hush because noise hurts."** — Marit goes very still.
> ► **"He doesn't know you were frightened of him."** — Marit says nothing, and then, very quietly, "Take me to him."

**Outcomes and receipt.**
- In every branch Marit and Anselm are reunited within the week. The player decides *how* the reunion goes.
- **Receipt:** a small bell hangs on the last marker stone; Linnet can now cross it with a lantern.

<!-- quest
id: qst_ww_lost_in_the_hush
title: Lost in the Hush
rank: E
type: Escort
giver: npc_marit_holloway
region: reg_whisperwood
level: 12
act: 1
requires_flags: rank_e_reached
reward: 260 | 20 | 830
sets: ww_hush_resolved
summary: A child has walked into the Hush, where sound dies. She is visiting her deaf grandfather in secret.
objectives:
  reach whisperwood_hush_marker
  escort npc_linnet_holloway
  choice how_to_tell_marit
-->

---

## 6. The Last Contract of the Silver Ladle

*E · Escort · a sinkhole cave · giver Tobias "Ladle" Pryce*

**The short version.** The four old adventurers of the Silver Ladle party want to go back to the sinkhole where their leader died and bring home his lute. They are seventy.

**What is really going on.** **Ansel Maur**, the Ladle's leader, died forty years ago and the party never went back for his lute, because none of them could face it. Tobias is dying (slowly, of age) and wants it done.

**Scene 1: the inn.**

**TOBIAS:** "Sit, lad, sit. Have a mug. I'll tell you the story of the Silver Ladle, and you'll stay for all of it."
**MIRELLE:** "He'll tell it twice."
**TOBIAS:** "Mirelle! Healer's tongue, sharp as ever."
**MIRELLE:** "I'm seventy-two, Tobias. I've earned my tongue."
**TOBIAS:** "We want to go back for Ansel's lute. The cave at the old sinkhole. Forty years. We need someone who can fight, in case..."
**GANT:** "...in case we forget which end of the sword is which."
> ► **"I'll go with you."** — **TOBIAS:** "Good lad. You'll do *exactly* as Ysolde says."
> ► **"Are you sure?"** — **MIRELLE:** "No. That's why we asked you."

**Scene 2: the sinkhole.** The old party falls into formation almost without thinking. Tobias at the front with a shield that is too heavy; Mirelle on healing; Gant picking a lock he left unfinished decades ago; Ysolde murmuring a flame-spell with terrible old rhythm.

*(Gameplay: the NPCs fight in their old "Ladle formation". The player may help or stay back. The old party is surprisingly good.)*

**YSOLDE:** "Left! The slimes are on the left! I remember the slimes!"
**GANT:** "That was a goblin."
**YSOLDE:** "It was a *very small* goblin."

**Scene 3: the lute.** At the back of the cave, the lute leans against a stone, its strings long rotted. A single page of sheet music is tucked inside.

**TOBIAS:** "...There he is."
*He sits down, heavily.*
**TOBIAS:** "Forty years I told that story and left this out. Ansel wasn't killed by the beast. He was *waiting for us*. He sent us ahead with the chest. He said, 'I'll catch up.' He never did."
**MIRELLE:** "We always knew, Tobias."
**TOBIAS:** "We never *said* it."
> ► **(Say nothing; let them sit.)**
> ► **"What was on the page?"** — **YSOLDE:** "It's a song. Unfinished. He never gave it a name."
> ► **"We'll finish it."** — **GANT:** "That's the most useless and wonderful thing I've heard all day."

**Scene 4: the ballad.** In the Millbrook inn that night, Gant repairs the lute with new strings. Ysolde writes a last verse. Rosie Quill from Brindlewick, passing through, offers to carry it.

**TOBIAS:** "*The Ballad of the Silver Ladle.* It has a verse for each of us. And a verse for the one who waited."

**Outcomes and receipt.**
- The old party survives the dungeon; if the player does not help, they get hurt but win anyway.
- **Receipt:** Rosie Quill sings the ballad at the Sleeping Griffon; the Silver Ladle's four chairs are reserved at the Millbrook inn.

<!-- quest
id: qst_ww_silver_ladle
title: The Last Contract of the Silver Ladle
rank: E
type: Escort
giver: npc_tobias_pryce
region: reg_whisperwood
level: 13
act: 1
requires_flags: rank_e_reached
reward: 280 | 22 | 900
sets: ww_silver_ladle_resolved
summary: Four seventy-year-old adventurers go back to a sinkhole to bring home their dead leader's lute, and need someone to watch their backs.
objectives:
  reach whisperwood_old_sinkhole
  escort npc_tobias_pryce
  kill mon_goblin 4
  kill mon_blue_slime 4
  choice let_them_lead_or_help
-->

---

## 7. Lanterns, Not Lamp Oil

*E · Faction · Whisperwood quarry · giver Pocket*

**The short version.** The kobold crew at the Whisperwood quarry has gone on strike. Their demand is unusual: they want *lanterns*, not oil lamps, because oil lamps burn their whiskers.

**What is really going on.** The quarry owner, **Adelle Fenn**, has been quietly ignoring a collapse warning the kobolds shouted on the last shift. Nobody was hurt, but only because kobolds shout "ROCK!" a full second before anyone else. The strike is about *respect*, and about the fact that nobody thanked them.

**Scene 1: the picket line.**

**POCKET:** "Pocket speaks for the crew. Pocket says: NO LAMP OIL."
**POCKET:** "Pocket says: oil burns whiskers. Pocket says: lanterns do not burn whiskers. Pocket says: Fenn will not listen."
**POCKET:** "Pocket says... pocket also says THANK YOU for coming."
> ► **"What do you want?"** — **POCKET:** "Lanterns. And a hat."
> ► **"A hat?"** — **POCKET:** "A HAT. With a lantern ON it."

**Scene 2: the office.** Adelle Fenn is a weary woman with ink on her cuffs.

**FENN:** "Lanterns. Gods. Do you know what a lantern costs? Do you know what *forty* lanterns cost?"
**FENN:** "I'm not a monster. I just have a quarry, and a debt, and a Guild contract that says I deliver ten carts of limestone by Vexday."
**FENN:** "...Is it true? About the collapse?"
> ► **"Yes. They saved six men."** — **FENN:** "Nobody *told* me."
> ► **"It's about the hat."** — **FENN:** "...I'll hear the hat."
> ► **"Let me inspect the face."** — A short, tense scene on the quarry wall: the ceiling really is loose.

**Scene 3: the deal.** The player brokers a compromise: lanterns for the shift, a monthly safety hour, and a small hat per crew member, hand-sewn by Fenna Tilly.

**POCKET:** "Pocket says: acceptable."
**FENN:** "Pocket, would you... like to stay for supper?"
**POCKET:** "Pocket says: yes. Pocket says: with the hat."

**Outcomes and receipt.**
- A *fair* deal (lanterns, hat, safety hour) is the best outcome. A cheap deal leaves a simmering resentment that resurfaces in a Ring 2 quest.
- **Receipt:** the quarry glows with blue lantern-light at night; the kobolds wear tiny hats; Pocket salutes the player on sight.

<!-- quest
id: qst_ww_lanterns_not_lamp_oil
title: Lanterns, Not Lamp Oil
rank: E
type: Faction
giver: npc_pocket_kobold
region: reg_whisperwood
level: 11
act: 1
requires_flags: rank_e_reached
reward: 240 | 18 | 760
sets: ww_quarry_resolved
summary: The kobold quarry crew is on strike. They want lanterns instead of lamp oil, and a small hat.
objectives:
  talk npc_pocket_kobold
  reach whisperwood_quarry_office
  choice fair_cheap_or_inspect
-->

---

## 8. The Wolf Who Counted Sheep

*E · Subjugation · Cobb Farm · giver Tilda Cobb*

**The short version.** A wolf has been seen among the Cobb flock at night. The neighbours want the bounty. Tilda wants you to look first.

**What is really going on.** The wolf is a lone she-wolf whose pack was trapped for pelts last winter. She has been sleeping beside the flock, which keeps *other* wolves away. Tilda has been feeding her scraps and has told nobody.

**Scene 1: the barn.**

**TILDA:** "They want her *dead*. The Ashby men put a bounty on her. Fifteen silver. Fifteen!"
**TILDA:** "She's never taken a sheep. Not one. She *counts* them. I've watched her. She walks the line every night and sits at the end."
**TILDA:** "Please. Look before you decide. That's all."
> ► **"I'll look."** — **TILDA:** "Thank you. Be quiet. She knows people."
> ► **"The bounty is real."** — **TILDA:** "I *know*. That's why you have to see."

**Scene 2: the night.** From the hayloft you see her: a grey wolf, ribs showing, walking the fence line. She stops at each sheep and tilts her head. At the end of the row she sits and watches the dark.

**TILDA:** (whisper) "Eighty-one. She always stops at eighty-one."
**TILDA:** "I call her Counter."
> ► **"She's protecting them."** — **TILDA:** "Yes!"
> ► **"She'll take one in winter."** — **TILDA:** "...Maybe. She's hungry."

**Scene 3: the neighbour.** Next morning Ben Cobb, Tilda's father, limps out on a crutch.

**BEN:** "Tilda says you're deciding for us."
**BEN:** "I'm not a hard man. But I have a flock and a girl and a bad leg. I'll abide whatever you say, if you tell me why."
> ► **"Take the bounty."** — **BEN:** "...All right."
> ► **"Relocate her to Wren's."** — **BEN:** "That's... decent."
> ► **"Tame her as a flock-dog."** — **BEN:** "Can that even be done?"

*(Gameplay: the tame option uses the Taming system. A calmed Counter becomes a farm dog; a refused taming ends with Counter leaving.)*

**Scene 4: the last night.** Whichever you choose, Counter walks the fence one last time. She stops at eighty-one.

**TILDA:** "...Goodbye, Counter."
*(In the taming branch, Counter sits at the end of the line and does not leave.)*

**Outcomes and receipt.**
- **Bounty:** the wolf dies; Tilda does not speak to the player for a week, then leaves a flower on the porch.
- **Relocate:** she lives in Wren's woods; Tilda visits at Harvest Home.
- **Tame:** Counter guards the flock; fluffcap sheep become "Cobb's best."
- **Receipt:** the Cobb farm has a new gate-latch and a small wolf-shaped carving over the barn door.

<!-- quest
id: qst_ww_wolf_counted_sheep
title: The Wolf Who Counted Sheep
rank: E
type: Subjugation
giver: npc_tilda_cobb
region: reg_whisperwood
level: 12
act: 1
requires_flags: rank_e_reached
reward: 220 | 16 | 740
sets: ww_counter_resolved
summary: A bounty is on a lone wolf that sleeps beside the Cobb flock. The girl who feeds her asks you to look first.
objectives:
  reach cobb_farm_barn_night
  choice bounty_relocate_or_tame
-->

---

## 9. Stew Diplomacy

*E · Faction · Hollowpine · giver Grandmother Brub*

*Requires the Goblin Chief's death (`tyrant_slain_reg_whisperwood`).*

**The short version.** With the Chief gone, the six Hollowpine clans are on the edge of a feud. Grandmother Brub believes *no goblin has ever refused a bowl he helped salt*. She needs a cook who can walk between camps.

**What is really going on.** The clans are not enemies; they are six families who have not eaten at one table since the Chief took the best cooks. Each clan keeps one signature ingredient. Without all six, Brub's old stew cannot be made.

**Scene 1: the camp.**

**BRUB:** "Sit. Eat. I don't talk to people with empty bellies. They lie."
**BRUB:** "Six clans. Six pots. Six fires. And not one of them will pass the salt to the other. The Chief held them together with fear and now there's nothing but sulking."
**BRUB:** "My stew needs *six hands*. One ingredient from every clan, brought by someone *none* of them hates yet. That's you."
> ► **"Why me?"** — **BRUB:** "Because you killed the Chief and *they're still too scared to hate you*."
> ► **"I'll do it."** — **BRUB:** "Good. Take a spoon."

**Scene 2: the six camps.** Each camp is a short scene with its own voice:
- **Moss-Tooth** (mushroom farmers, shy): "Brub sent you? Take the *good* mushrooms. Don't tell the others."
- **Ember-Thumb** (smokers, proud): "Smoked fat. For *her*. Not for them."
- **Bent-Spear** (hunters, gruff): "The marrow bone. One bone. You'll carry it yourself."
- **Blue-Ear** (miners, suspicious): "Salt. From the old vein. You'll earn it."
- **Quick-Knot** (traders, slick): "Wild garlic. For a favour."
- **Hollow-Drum** (ritualists, solemn): "Honeyroot. We drum it three days. You wait."
> ► **(Barter, fight, favour, or wait; each camp has its own approach.)**

**Scene 3: the feast.** The six clans assemble in the Hollowpine clearing. Awkward silences. Brub stirs the pot.

**BRUB:** "Six hands. Now *taste*."
*A pause. The Ember-Thumb elder takes a bite. His face changes.*
**EMBER-THUMB:** "...That's my mother's soup."
**BENT-SPEAR:** "It's *my* mother's."
**MOSS-TOOTH:** "It's all of ours. It was always all of ours."

**Scene 4: the oath.** The clans do not sign a treaty. They pass the ladle.

**BRUB:** "That's how we do peace. We don't write it. We *eat* it."

**Outcomes and receipt.**
- The player chooses how to approach each camp; success at all six unlocks the full ending.
- **Receipt:** a Hollowpine market opens once a week; the six clan marks are painted on the Millbrook inn door. The Whisperwood Kinship Arc's goblin scenes gain a "shared table" line.

<!-- quest
id: qst_ww_stew_diplomacy
title: Stew Diplomacy
rank: E
type: Faction
giver: npc_grandmother_brub
region: reg_whisperwood
level: 14
act: 1
requires_flags: tyrant_slain_reg_whisperwood
reward: 320 | 24 | 1100
sets: ww_stew_resolved
summary: The six Hollowpine goblin clans will not share a table. Grandmother Brub needs one ingredient from each clan for a stew nobody has made in a generation.
objectives:
  talk npc_grandmother_brub
  reach hollowpine_six_camps 6
  choice barter_favour_or_wait
-->

---

## 10. Eight Lamps and an Empty Niche

*E · Exploration · the old road · giver Eolande Fairweather*

**The short version.** Eolande has noticed that the old kingdom's waystations along the Whisperwood road each have a lamp-niche. Eight are carved. A ninth is *scratched out*. She wants you to relight what you can.

**What is really going on.** *Nothing is revealed.* This is a seed, left open on purpose. The lamps are plain oil lamps; relighting them makes the old road safe at night. The ninth niche is empty and clawed, and the quest does not say why.

**Scene 1: the library.**

**EOLANDE:** "I've been cataloguing waystations. There are eight, between here and Millbrook. Each has a niche for a lamp. Each lamp is a different shape."
**EOLANDE:** "And the ninth waystation, the one at the crossroads, has the niche cut and then... *damaged*. Someone took a chisel to it."
**EOLANDE:** "I'd go myself, but I'm a librarian with a bad back."
> ► **"Why does it matter?"** — **EOLANDE:** "Because somebody once thought a lamp was worth defacing a wall for."
> ► **"I'll light them."** — **EOLANDE:** "Thank you. And take notes."

**Scene 2: the lamps.** Each of the eight niches holds a lamp of a different design: a fish, a leaf, a hammer, a coin, a lantern-with-a-cat's-ear, a spindle, a sword, and a moon. Each lights with a flame that is *slightly the wrong colour* for a moment, then settles.

*(Gameplay: a brief exploration route with light combat. No puzzles beyond reaching each niche.)*

**Scene 3: the ninth.** At the crossroads the niche is smooth stone, scored deep with claw or chisel marks. A pale flower grows in the gap.

**EOLANDE:** (via a Journal note) "Don't touch it. Don't explain it. Just... draw it."
> ► **(Sketch the niche.)** — The Journal records it.
> ► **(Place a plain lamp.)** — It will not stay lit.
> ► **(Leave a coin.)** — A gesture, nothing more.

**Scene 4: the road at night.** Back in Brindlewick, Eolande looks at the sketch for a long time.

**EOLANDE:** "Eight lamps, and the ninth gone. ...You know what that reminds me of."
*She does not say it. She puts the sketch in a drawer and locks it.*

**Outcomes and receipt.**
- The old road is lit at night; random night encounters on it drop by half.
- The ninth niche is a pure seed: no flag beyond the quest's own and no change to Canon.
- **Receipt:** eight lamps glow along the old road; a small flower grows in the ninth niche.

<!-- quest
id: qst_ww_eight_lamps
title: Eight Lamps and an Empty Niche
rank: E
type: Exploration
giver: npc_eolande_fairweather
region: reg_whisperwood
level: 12
act: 1
requires_flags: saw_nine_thrones_mural
reward: 270 | 20 | 880
sets: ww_eight_lamps_resolved
summary: Eolande wants the old kingdom's waystation lamps relit. Eight are carved. The ninth niche has been defaced.
objectives:
  reach whisperwood_old_road_lamps 8
  reach whisperwood_ninth_niche
  choice sketch_lamp_or_coin
-->
