# Act I Scene Scripts: *The Wooden Card* (first hours)

> **Status:** writer's draft by the narrative-writer agent, 2026-11-09. Follows `story.md` (Act I beats 1-10) and the draft `whisperwood_kinship_arc.md`. `Canon.md` wins on any conflict.
> **How to read this file.** Every scene has a **Script** block (player-facing: nothing in it may reveal a Canon §3 secret) and a **Writer notes (SPOILERS)** block (never shipped to the player; it says what the plain-sight clue is and when it pays off). Only Script blocks go into dialogue data.
> **Voice rules:** warm, specific, short lines; humour comes from character, never slapstick; no fanservice; teen rating. The System Voice speaks to the *character*, never the player (Canon §4).
> **Name status:** "Sella" is the working name of the Wolfskin scout (provisional in the kinship arc). Quest and NPC ids are from `Data/Quests/quests.json` and `Data/NPCs/npcs.json`.
> **Format:** `NAME: line.` *Italic* lines are stage directions. `[CHOICE]` marks a player choice; `{flag}` marks a story flag set (names are proposals, see the end of the file).

---

## Scene index

| # | Scene | Quest / beat | Where | Cast |
|---|---|---|---|---|
| 1 | Status Granted | `qst_main_status_granted` | Whisperwood clearing | System Voice, Mochi, Sella, Lyra |
| 2 | The Long Way In | same | Brindlewick north gate | Lyra, gate guard, Hollis |
| 3 | A Bowl of Stew | `qst_main_bowl_of_stew` | Sleeping Griffon, then the Orphanage | Marta, Brother Caspian, Tamsin, Bo, Whiskers |
| 4 | The Wooden Card | `qst_main_wooden_card` | Guild hall | Mina, Rodrick, Wendel |
| 5 | A Thousand Swings | `qst_class_thousand_swings` | Hollis's yard | Hollis, Teo |
| 6 | Lyra's Debt | story beat 3 | Griffon porch, evening | Lyra |
| 7 | Granny Mabel's Chickens | tutorial loop | Mabel's farm | Mabel |
| 8 | Night of the Smiling Scarecrow | `qst_inv_smiling_scarecrow` | Millbrook, Odo's field | Odo, Lyra |
| 9 | The Mural of Nine Thrones | `qst_explore_nine_thrones` | Whisperwood ruins | Eolande |
| 10 | The Chief of Hollowpine | `qst_trial_f_goblin_chief` | Hollowpine Camp | Sella, Chief, party |
| 11 | Report the Runes | story beat 8 | Guild hall / chapel | Rodrick, Mina, Inquisitor |
| 12 | Rank E | story beat 9 | Sleeping Griffon | Marta, Mina, Rodrick, Whiskers |
| 13 | Two Roads: Kiri or Aldric | story beat 10 | Ashby road / the inn | Kiri, Aldric |
| 14 | The Swelling Moon | Act I ending | Brindlewick green | Hollis, party |

---

## 1. Status Granted
*Origin: Transported. Other origins skip to scene 2 or 3 (see variants at the end).*

### Script
*Black screen. Rain. A half-finished sentence in the player's own voice, close to the ear.*

PLAYER-CHARACTER (V.O.): "...I'll call you back when I get off, I just have to..."

*A drop of rain hangs, then falls upward. Two moons through the trees, one white, one red. A puddle shows a small blue shape before the slime hops into view.*

SYSTEM VOICE: Status... gr-granted.
SYSTEM VOICE: Soul origin: [ERROR]. Growth ceiling: [NONE].
SYSTEM VOICE: ...That is not a normal reading. Please remain calm.

*Mochi tilts its whole body at you. It makes a small wet sound that is plainly a question.*

SYSTEM VOICE: Prompt: you can look around. Move when ready.

*(Free movement. Inspect the clearing: old-world shoes, wet grass, trampled moss, a trap-wire at the edge. Each inspect gets one short System line, e.g. "Moss. Soft. Not dangerous." No tutorial wall.)*

*A sharp click in the dark. A wire snaps. A masked goblin is flung into the clearing and rolls to a stop between you and the trees. Something large and furred is behind them.*

SELLA: *(clipped, to the dark)* Not this way. Not this way!
SYSTEM VOICE: Translating... "Hurt. Behind. You. Down."
SELLA: *(to you, harder)* Down! DOWN!

*Combat tutorial fight: a forest wolf, then its pack-mate. Sella marks the first target with an amber line and shouts its next move. The player's job is to read the wind-up and make the opening.*

SELLA: Left! It goes left!
SYSTEM VOICE: Translating... "Left. It goes. Left." *(a small glyph and a half-second pause)* ...Left.
SELLA: *(short laugh, pained)* You are slow. You are alive. Good.

*The trap Sella set fails; the player's hit on the root-pinned leg lands. Wolf down.*

*Quiet. Sella is on one knee, a hand pressed to a torn mantle. The player steps closer. Sella's hand moves to a small knife.*

SELLA: Stay.
SYSTEM VOICE: Translating... "Stay. Or I will cut you."
SELLA: *(a beat, sees the System text in your face, lowers the knife)* ...No. That was not the word. Stay. *Wait.* Wait.
SELLA: Water?

*Sella offers a flask. The player can drink or decline. Either is fine; drinking gets a small warm sound.*

SELLA: *(touches the carved token on their belt, unhooks it, sets it on a rock between you)* Wolfskin. Hollowpine. Six marks. *(holds up six fingers)* Six.
SYSTEM VOICE: Translating... "Clan. Home. Six." Names are unreliable. Proceed with kindness.

*Boots crashing through undergrowth. A bright voice, out of breath.*

LYRA: -and I *said* the trail went north, the trail always goes north, why do I never- *(stops, takes in the scene, steps between you and Sella with her blade half-drawn)* Back off, goblin!
SELLA: *(hands open, not rising)* I do not. Fight. You.
LYRA: *(looks at Sella's wound, then the dead wolves, then you)* ...Oh. Oh, you did this together. *(lowers the blade)* Sorry. Habit. Are you hurt? Is anyone hurt? I'm Lyra. You look terrible. Do you have a name? Do you remember your name? Great, keep that one.
LYRA: *(to Sella)* You're bleeding. There's a healer in town who doesn't ask what clan anybody's from.
SELLA: *(a pause, then a small shake of the head)* Home. First. *(to you, pointing at the token)* Keep. Return. Later.

*Sella is gone into the trees before the player can answer. Mochi hops onto your shoulder as if it had always lived there.*

LYRA: Come on. Brindlewick's an hour that way. There's stew. Probably. There's always *something*.

**Objective complete: reach Brindlewick north gate.** `{arrived_in_aetheria}` `{met_sella_clearing}` `{sella_token_kept}`

### Writer notes (SPOILERS)
- The "Stay" mistranslation teaches the System's limits (`whisperwood_kinship_arc.md` translation rules) without a lecture.
- The System's *Fractured* personality glitches here by default. It is the same stutter Caspian triggers later (foreshadow #8), so keep the glitch rate low in scene 1 and let it spike in scene 3.
- The red moon is just *there* at night. Players will not think about it until Act I's ending.

---

## 2. The Long Way In

### Script
*Dusk road. Brindlewick north gate: a squat tower, bread left on a grey step by the road.*

LYRA: Little tradition. Bread on the waystation steps, for anybody who didn't make it back. *(she leaves a heel of her own bread)* Costs me a meal. Worth it.
LYRA: Brindlewick's not much. Two wells, one bridge, a guild hall that leaks. But the people are the kind who save you a seat.
LYRA: *(a little too brightly)* I'm broke, by the way. It comes up. It will come up again.

*Gate guard (HOLT, tired, kind) lifts a lantern at you.*

GUARD: Odd clothes. Odd glow on you. *(sniffs)* Wet slime. Guild's still open for a bit. Registration costs nothing. The stew costs whatever Marta says it costs.
SYSTEM VOICE: Location: Brindlewick, northern gate. Rank: [none]. The registration desk is nearby.

*Across the green, a one-armed old man is thrashing a hay dummy with a broom handle. Without turning:*

HOLLIS: You hold a sword like it owes you money! Come see me tomorrow!
LYRA: That's Old Hollis. Don't take it personally. He says that to everyone. He means it kindly. Mostly.

### Writer notes (SPOILERS)
- The bread on the step is a Whisperwood custom (kinship arc): it is also the recurring image against the forged orders later.

---

## 3. A Bowl of Stew
*Brindlewick's heart. Quest: `qst_main_bowl_of_stew`. Canon: Caspian gives you your first meal in this world. Reconciled with the quest text: Caspian cooks it, Marta hosts it.*

### Script
*The Sleeping Griffon at dusk. A fat orange cat asleep on the warmest table. A sword hangs over the bar.*

MARTA: *(booming, not unkind)* Sit. Don't argue. You look like something the cat dragged in, and he doesn't drag.
MARTA: Marta Gruel. That's a "mistress of the house" voice, so don't forget it. Bed's two silver. *(a look at your empty hands)* Which you don't have. So: on credit. I keep a very long list. Nobody ever finishes it. *(a beat)* That's a joke. Mostly.
LYRA: She means it. She's never collected on one yet.
MARTA: *(sharp)* Lyra Brightwood, you and your mouth.

*Whiskers opens one eye. Studies you. Closes it again. The System Voice stutters for half a word.*

SYSTEM VOICE: A cat. ...Observing.

*The door opens. A tall man in plain brown robes enters with a covered pot, a blindfold of undyed linen across his eyes. A line of small children follows, each carrying a bowl or a spoon.*

CASPIAN: Marta, the Small Lantern borrows your hearth again. *(he sets the pot down without fumbling, as if he could see the table)* We made too much. The children always overestimate how much they can eat.
TAMSIN: *(eight, folded arms)* I did the counting. We made the *right* amount. Brother Caspian just likes giving it away.
CASPIAN: *(smiling toward her)* Guilty.

*He turns his face toward you, a small distance off, exactly right.*

CASPIAN: You must be new. You smell like rain and... a long way from here. *(gently)* Sit. Eat. The first meal in a new place ought to be given, not bought.

*He ladles a bowl and puts it in your hands himself. Warm. Real. Salt and onion and something green.*

SYSTEM VOICE: Hunger status... corrected. *(the line glitches)* Corr-corrected.

CASPIAN: Tamsin, find our guest a blanket. Bo, don't hide behind the cat, he's busy.

*A very small rabbit-kin child (BO) peers from behind Whiskers, says nothing, and then, very quietly, to the cat:*
BO: He's got two moons in his eyes.
*(Only Whiskers and the player hear it. Whiskers swishes his tail.)*

CASPIAN: The orphanage has a spare cot, if the guild bed is too far or too dear. No payment. We only ask that if you pass the baker, you remember there are children who love sweet things.
TAMSIN: *(to you, businesslike)* He means *bring us buns*. Get used to hearing it said nicely.

**[CHOICE] where to sleep:** the Griffon on credit / the orphanage cot. Either way the player gets the blanket. `{met_brother_caspian}`

*If the player visits the orphanage later: Whiskers refuses to cross the threshold and sits on the step, glaring at nothing.*

CASPIAN: *(about the cat, mild)* He has opinions about the porch. We respect them.
CASPIAN: *(when the player mentions their Rank, if they do)* Rank? *(a small shake of the head)* Rank is a cage, child. Come in. The soup is hot.

### Variants for other origins
- **Summoned Hero:** Caspian meets you at the Cathedral gate on the night you are "sent to train," brings the stew there, same line about the first meal.
- **Reincarnated / Native / Reborn Monster:** he turns up at your first Brindlewick night, same ladle, same sentence.

### Writer notes (SPOILERS)
- Caspian is Malgareth's current host. Everything he says here must stay *true as a statement, kind as a gesture*, because on a replay each line reads differently. He does not lie to you in this scene.
- Foreshadow clues planted (Canon `story.md`, foreshadowing list): #3 Whiskers refuses to cross the orphanage threshold; #4 Caspian knows exactly where the player stands ("a small distance off, exactly right"); #7 "Rank is a cage, child."; #8 the System glitch spikes in his presence. Do not add a further clue; four is already generous.
- Bo's line is about both moons and about the red moon looking down; Bo draws the red moon with buildings on it (`npcs.json`). He is the closest thing to a witness in Act I.

---

## 4. The Wooden Card

### Script
*The Brindlewick guild hall, morning. A leaking roof, a clerk's desk buried in paper, a counter with a brass bell.*

MINA: *(bright, a little breathless)* Welcome to the Adventurers' Guild, Brindlewick branch! Name, please. And please don't say "adventurer," we say "client" until the paperwork clears.
WENDEL: *(from behind a tower of forms)* Triplicate. Everything in triplicate. I'm sorry. It's a family illness.

*Mina slides the appraisal crystal across the counter. It glows pale gold, then flickers: a thin line of red, a flash of white, and a sound like a struck bell underwater.*

MINA: *(stares, very fast)* ...Oh. *(smile snaps back)* Old crystal! Old, old crystal. Equipment's old, ha ha. Happens twice a year. Nothing to see.
SYSTEM VOICE: Appraisal glitch detected. Growth ceiling: [NONE]. *(quieter)* Please do not repeat that number.

*Mina presses an oak card into your palm. It is plain, warm, a little rough.*

MINA: Rank F. Oak card. Everyone starts at the bottom. Some of us stayed a while. *(a private smile)* Don't tell anybody that part.

*A huge, grey-furred bear-kin leans in the doorway, a mug the size of a bucket in one hand.*

RODRICK: Mina, who's the glow?
MINA: New client, Guildmaster. Crystal glitch.
RODRICK: *(studying you for one long second)* Crystal glitches don't usually come back with a human attached. *(to you, gruff and warm)* Rodrick Hale. They call me Old Bear because I was young once. Welcome. Don't die on my floor, the paperwork is worse than the cleaning.

**Objective complete: talk to Mina, talk to Rodrick.** `{guild_registered}`

### Writer notes (SPOILERS)
- Mina is the real Mina here. Her "Equipment's old, ha ha" is the cover-up from `story.md` beat 1 and the **inside joke** the fake Mina forgets in Act III (so keep one phrase to repeat: the crystal joke "old, old crystal"; **Mina writes with her right hand**; she faints at big feats).
- Wendel's crush on the Guild Master's handwriting is a throwaway gag from `npcs.json`: keep it unspoken.

---

## 5. A Thousand Swings

### Script
*Hollis's yard at sunrise. A hay dummy, a rack of wooden swords, a broom leaning on the fence.*

HOLLIS: You hold a sword like it owes you money. Hold it like it *likes* you. *(raps your wrist with the broom)* No. Elbow. Again.
HOLLIS: A thousand swings. Not a hundred, not nine hundred. If your arms aren't complaining by the three-hundredth, you're swinging it wrong.
TEO: *(from the fence, whispering)* Mister Hollis, I have a *broom* too...
HOLLIS: *(without turning)* Teo Gruel, your mother thinks you are mucking stalls.
TEO: *(freezing)* ...I'm very good at mucking stalls.
HOLLIS: *(a beat, almost a smile)* Go and muck them. Then come back at dusk.

**On finishing:** HOLLIS: Not good. Not yet. *(he puts the broom away)* But you stopped looking at your hands. That's the first thing. Come back tomorrow.

### Writer notes (SPOILERS)
- Teo is secretly training with Hollis at night (`npcs.json`). Hollis is also a later tearjerker (his last lesson): the warmth here is what that scene spends.

---

## 6. Lyra's Debt

### Script
*The Griffon's porch, an evening later. Lyra is counting a handful of coppers, then counting them again.*

LYRA: Eleven. Yesterday it was fourteen. I'm certain a rabbit took three.
LYRA: *(not looking up)* My village owes the Count's collectors a sum, and they're nice about it, which is how you know it's bad. I'm the one who left, so I'm the one who sends coin. That's the deal.
LYRA: I'm not asking you to... *(puffs a breath)* Okay. I am. Do you want a partner? I'm loud and I eat a lot, but I don't run when it gets bad. I tried it once. Felt worse.

**[CHOICE]** *Yes, partners.* / *Let me think, but yes.* / *What does a share look like?* (all three lead to the same join; only the next line changes)

LYRA: *(a huge grin, a heartbeat of relief)* Good. Great. Fantastic. First rule of the party: I'm allowed to say "we did it" even when you did most of it.
LYRA: Second rule: if we find food, we share.
MOCHI: *(bounces, once, solemnly)*
LYRA: Mochi gets a vote. Mochi votes yes.

`{lyra_joined}` `{lyra_debt_known}`

### Writer notes (SPOILERS)
- Her village's collector is the same debt chain that eventually leads to Dorran "Red Ledger" Hask (he burned the village). Do not name Hask in Act I. "Nice collectors" is the plain-sight phrase.

---

## 7. Granny Mabel's Chickens

### Script
*A sunlit farm. Forty "chickens" strut about; a few are too tall, one has a snake's tail.*

MABEL: Mind the white one. She's friendly. *(a cockatrice pecks a gate post and the post turns slowly to grey stone)* ...Mostly friendly.
MABEL: Taming isn't about the whip, dear. It's about patience. They only bite the ones who flinch. *(hands you a small seed bag)* Hold it flat. Don't flinch. There. See? Not a single petrification.
MABEL: *(proud)* My chickens, you understand, are the best layers in Whisperwood.
MOCHI: *(wobbles slowly toward the nearest cockatrice and bounces off its beak with a tiny squeak)*
MABEL: Oh, Mochi's brave. You'd get on.

### Writer notes (SPOILERS)
- Mabel passes peacefully in a later tearjerker and leaves you her farm. Keep her sentences slow and generous.

---

## 8. Night of the Smiling Scarecrow
*First horror quest (teaches the Menace system). `qst_inv_smiling_scarecrow`.*

### Script
*Millbrook, Odo's east field, moonlight. The scarecrow stands where it did not stand yesterday.*

ODO: It's in a different field every morning. I turned it to face the road. By dawn it was facing the house.
LYRA: *(very quietly)* Don't look away. I'm going to keep saying that and you'll hate me for it.
SYSTEM VOICE: Menace rising. Do not blink for longer than necessary.
*(Each time the player glances away from the scarecrow for more than a few seconds, it is one step closer on the next look. Lyra counts aloud, steadier and steadier.)*
LYRA: One. *(a breath)* Two. It's just a stick and some straw, I fought a stick once.
*(At the end, the scarecrow lunges, the player holds their ground, the straw dissolves into moths.)*
ODO: *(from the porch, weakly)* ...Thank the Lantern. Come in, the kettle's hot. And please don't tell my wife the scarecrow was *that* close.

### Writer notes (SPOILERS)
- No cult link. This is a genuine Menace tutorial; keep it a pure creepy-folklore night and give the player a laugh at the end. The cult hint belongs in scene 10.

---

## 9. The Mural of Nine Thrones

### Script
*Whisperwood ruins, afternoon. Green stone, vines, a wide painted wall. Nine carved thrones in a ring. One has been scratched out so thoroughly that the rock has gone pale.*

EOLANDE: *(sketchbook, breathless)* Do you see it? Nine thrones, and the ninth... the stone's been *rubbed*. Not worn. Rubbed. Someone wanted it forgotten and came back more than once to do it.
EOLANDE: I'm an archivist, not an adventurer. If I draw it, will you stand nearby and look intimidating?
SYSTEM VOICE: Note added to the Journal: *Nine Thrones. One erased.* This cannot be translated. It was not meant to be read, only seen.

*Four skeletons climb out of the moss. Combat. Afterward:*

EOLANDE: *(sketching quickly)* Oh. Oh, it's beautiful. And awful. I think that's how all the best things are. Thank you. I'll copy it three times, one for me, one for the Guild, and one for someone who might need it later.

`{saw_nine_thrones_mural}`

### Writer notes (SPOILERS)
- The scratched throne is Ezrath, the Forgotten Ninth (Canon §3). The SYSTEM line ("not meant to be read, only seen") is as much as the System can honestly say. Do not name a god anywhere in Act I.

---

## 10. The Chief of Hollowpine
*Rank trial. `qst_trial_f_goblin_chief`. Sella's cameo and the red-eyed hobgoblin's runes.*

### Script
*Hollowpine Camp: a ruined waystation, a sinkhole cave, rope bridges, soot and warm amber lamps. Not a lair: a busy, cramped village.*

SELLA: *(unmasked for the first time, sitting with their back to a wall)* You came. I thought the Guild would send soldiers. *(they glance at your oak card)* Not a soldier. Good.
SELLA: My chief fights because we are hungry. He does not like it. *(a pause)* Neither do I. But he is my chief.
SELLA: I will not stop you. I will not help you. If you spare someone, remember who.

*Combat: the red-eyed hobgoblin leads a raid wave, then the Chief. After the fight:*

LYRA: *(kneeling beside the fallen hobgoblin)* ...Hey. Look at his chest. Those lines aren't tattoos.
SYSTEM VOICE: Pattern: carved runes. Origin: [UNKNOWN]. *(a half-second glitch)* This was done to him. Not by him.
SELLA: *(quietly, from the doorway)* My clan does not carve. We do not know these marks.
LYRA: Then somebody made him. Who makes a goblin raid the way a farmer harvests?

*The Chief, spent, speaks to you directly. The System translates cleanly, which is somehow worse.*

CHIEF: There is a winter coming. Tell the village I am sorry. Tell them *someone* else lit the fire at the granary.

**Trial complete.** `{hollowpine_chief_defeated}` `{runes_found}`

### Writer notes (SPOILERS)
- The runes are Red Moon Cult work; their stitching pattern matches Caspian's blindfold (foreshadow #6). Do NOT describe the stitching in this scene. A player who looks back at the blindfold in scene 3 can find it; that is the fair clue. Art note: reuse the same thread motif on the hobgoblin's runes and the blindfold hem.
- The Chief's line about "someone else lit the fire" matches the kinship arc's forged-orders thread and the Grukk the Younger revenge arc. Keep the Chief's name unsaid (the kinship arc and Canon disagree on whether he is "Grukk" or Grukk's father; resolve that in a §6 proposal before names are written).

---

## 11. Report the Runes

### Script
*The guild hall, evening. Rodrick has the sketch of the runes flat on the counter.*

RODRICK: I don't know this pattern, and I've seen most of them. *(rolls up the sketch)* Two roads. The Guild can look into this quietly. Or the Church sends an Inquisitor, loudly. Your call. You've earned the right.

**[CHOICE] `runes_reported_to`:**
- **Guild.** MINA: *(touches your sleeve)* We'll be careful. I'll write nothing down where it can be read. *(a ghost of the old A-rank in her smile)* Trust the front desk.
- **Church.** *(an Inquisitor in grey and white arrives two days later, polite and watchful)*
  INQUISITOR: I'm Sister Aurelle. Thank you for coming forward. *(she looks at you a beat too long)* The Church is... interested in this report. And in you.

### Writer notes (SPOILERS)
- Church route: the Inquisitor is suspiciously interested in *you* because of your Soul origin (Canon §3: the System's secret). She cannot say it; she can only stare at the player's empty ceiling.
- Guild route: Mina and Rodrick investigate quietly. Mina's investigation is where she is captured between Acts II and III, so make her *especially* warm here.

---

## 12. Rank E

### Script
*The Sleeping Griffon, a party. Paper lanterns, a bad fiddler, Marta's stew in a vat.*

MARTA: *(banging a spoon)* A toast! To a new Rank E, who has, as of tonight, only owed me the *one* thing. *(a long look)* I'm taking it off the list. Don't tell the others.
MINA: *(applauding, a little teary)* I always cry at these. Every time. Wendel keeps tissues in a drawer.
WENDEL: *(from the corner)* I do. They're organized by weeping tier.
RODRICK: *(raising a mug)* To E. Don't let it go to your head. It's the second rung of a very long ladder.
LYRA: To E! *(she hugs you without warning)* We're a party now. A real one.

*On the warmest table, Whiskers has not looked away from you for a full minute. He blinks, slowly, and one sharp tooth shows.*

SYSTEM VOICE: A cat. *(the voice slows)* Unusually... attentive.

### Writer notes (SPOILERS)
- Whiskers is Vex, god of luck, doing what gods do at parties: checking whether you are the person he bet on. He stays friendly in Act I.

---

## 13. Two Roads: Kiri or Aldric
*Mutually exclusive in Act I; the other returns later, changed. `act1_recruit`.*

### Script (A: Kiri)
*The Ashby road, a slaver's wagon half-hidden in brush. A young wolf-kin girl in the cage, silent, watching.*
KIRI: *(flat, wary, in a clipped voice)* You will not open it. Everyone who stops tries to sell me again.
LYRA: *(hands visible)* We're not selling anyone.
KIRI: *(a long look, then, without hope)* Prove it.
*(Rescue fight, or pay the slaver: the two routes differ in Karma and dialogue.)*
KIRI: *(rubbing her wrists, eyes everywhere)* I'm hungry. I'm not saying thank you. I'll say it after I've eaten.

### Script (B: Sir Aldric)
*The Griffon at midnight. A big man slumped over a cup of something strong, a battered tabard on the chair.*
ALDRIC: *(not looking up)* If you've come to arrest me for being drunk, the line starts behind the barkeep.
MARTA: *(under her breath, to you)* He used to be the Captain of the Guard. Don't ask. I've asked.
ALDRIC: *(finally looking up, dry)* The Oath at Greyhollow isn't a story for strangers. But I can hold a shield. And I can listen.

**[CHOICE]** `act1_recruit` = Kiri | Aldric. *(the other leaves a trace: a wolf's track by the gate / an empty chair at the Griffon)*

### Writer notes (SPOILERS)
- The non-chosen companion returns "changed" later; leave a small physical sign so the player knows they are not gone.

---

## 14. The Swelling Moon

### Script
*Brindlewick green at noon, the next week. Everyone stops. The sky is pale blue and, low over the roofs, a red disc as large as a barn door.*

TEO: *(pointing)* It's the middle of the day. Moons don't do that.
LYRA: *(very quietly)* ...Is it bigger?
*(The kids stop playing. A baker drops a tray. Mochi presses against your leg.)*
HOLLIS: *(leaning on his broom, not looking at you, his voice dry as old paper)* That's not supposed to happen for another hundred years.
SYSTEM VOICE: Celestial event detected. *(a pause)* Please do not panic. *(another pause)* ...Please.

*Fade out on the red moon. The first act's music resolves, then turns minor.*

**Act I complete.** `{act1_done}` *(Rank E, one companion chosen, the red moon visible in daytime.)*

### Writer notes (SPOILERS)
- The only thing the player should leave Act I thinking is "the moon is wrong." Not why.

---

## Proposed story flags (for `Data/Quests/story_flags.json`; owner: quest-designer)

`arrived_in_aetheria`, `met_sella_clearing`, `sella_token_kept`, `met_brother_caspian`, `guild_registered`, `lyra_joined`, `lyra_debt_known`, `saw_nine_thrones_mural`, `hollowpine_chief_defeated`, `runes_found`, `runes_reported_to` (guild | church), `act1_recruit` (kiri | aldric), `act1_done`. Several already exist in `Data/Quests/quests.json`; new ones are proposals.

## Open questions for the next pass (flag to canon-keeper / quest-designer)

1. **The Chief's name.** `story.md` villain table calls Grukk the Younger the son of "the Goblin Chief you killed"; `whisperwood_kinship_arc.md` calls the chief "Grukk." Scripts here leave the Chief unnamed.
2. **Brindlewick's region** (Canon §6 already asks this; blurbs follow `regions.json`, quests use `reg_aldmere`). Scripts avoid naming the region.
3. **Sella's name** is provisional; if it changes, search-and-replace `SELLA`.
4. **Inquisitor Sister Aurelle** is a new minor NPC (scene 11). If kept, add her to `Data/NPCs/npcs.json` as a townsfolk-tier entry.
