# 11e-46 — Lustrine Shores, the Moon-Glass Coast: Ten Side Quests (draft)

> *"They believe the glass is the moon's tears, and they leave the largest pieces on the beach as offerings."*
> — Gazetteer, Lustrine Shores

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. ⚠️ **Spoilers (light):** quest 10 plants an unexplained seed.

**Region:** `reg_lustrine_shores` (the glass beaches, the Glass Flats, the Lamp Market, the dune villages). **Rank band:** A–S. **Tone:** dreamy, gentle, superstitious; slow sad songs, lamplight, tide and sand; loss that is carried rather than shouted.

**Placement notes.**
- **Ilyanthe, the Moon Harvester,** is the region's Tyrant, a vesperite from the red moon who descends on the high tides and gathers the light from the glass, and from people, "and does not seem to know the difference." No quest here kills, defeats, bargains with or reasons with Ilyanthe, and none ends the siege. She is a presence on the tide, glimpsed at most as a shape of light far out.
- Customs the quests rely on: the glass is the moon's tears; the largest pieces are left on the beach as offerings; nobody looks directly at the red moon; lamps never need oil; elders govern the villages and the glass-gatherers' guild controls the beaches; the songs are slow and sad, and changed key the year the red moon rose.
- **Open Canon points left alone:** where the glass comes from, and what the red moon is. Quest 6 touches the changed key and quest 10 the lantern; neither explains.
- **Rank note.** Quests 1 to 8 are rank A (level 120 to 159). Quests 9 and 10 are rank S (level 160 to 205; GP 3,000; see `Data/World/guild_ranks.json`); their rewards are extrapolated from the promotion table and the Whitewater S-rank quests, and are first-pass.
- The region is `besieged` at start. No quest here is SiegeDefence; quest 7 is a plain Defense of one stretch of beach for one night.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Lamp That Would Not Light | A | OddJob | Lampwright Isolde Thorneglass | A lamp made from a grief |
| 2 | The Tide-Table Salt | A | Delivery | Salt-Panner Osric Brinewick | Salt for a widow's wedding |
| 3 | Pale Mornings | A | OddJob | Nurse Linnet Harrowmere | Sitting with the empty-eyed |
| 4 | The Largest Piece | A | Investigation | Elder Verity Merrowdale | An offering that went missing |
| 5 | The Fledgling in the Foam | A | Hidden | Tobin Tallowmere | A very small gull and a very large tide |
| 6 | The Key the Songs Changed To | A | Faction | Singer Corwen Tidesong | Learning the old tune |
| 7 | One Night on the Dark Mile | A | Defense | Guild-Warden Marrek Soltane | A watch against the high tide |
| 8 | The Moon-Moth Count | A | Exploration | Naturalist Ilsabet Ferrow | Counting wings in the dark |
| 9 | The Beach That Went Out | S | Investigation | Beachkeeper Marit Dunmore | A dark beach and a vigil |
| 10 | The Lantern Has a Passenger | S | Exploration | Lamp-Keeper Perpetua Vask | A lamp with something inside |

## Cast

<!-- npc
id: npc_isolde_thorneglass
name: Lampwright Isolde Thorneglass
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Lampwright of the Lamp Market
backstory: A careful, soft-voiced lampwright who has made two thousand lamps and has been asked, for the first time, to make one from the glass of a drowned child's cradle.
-->
<!-- npc
id: npc_osric_brinewick
name: Salt-Panner Osric Brinewick
tier: townsfolk
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Salt-panner of the marsh pans
backstory: A stooped, wry salt-panner of seventy who rakes the same pan his father raked and who has been asked for the finest salt of his life by a widow with one week to find it.
-->
<!-- npc
id: npc_linnet_harrowmere
name: Nurse Linnet Harrowmere
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Nurse of the pale-morning house
backstory: A tireless young nurse who runs a low house on the dunes for gatherers found on the flats after Ilyanthe's visits, and who has not slept a full night since spring.
-->
<!-- npc
id: npc_verity_merrowdale
name: Elder Verity Merrowdale
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Elder of a dune village
backstory: A calm, long-boned elder who keeps the offering stones of her village and has found the greatest of them gone from the beach on the longest night of the year.
-->
<!-- npc
id: npc_tobin_tallowmere
name: Tobin Tallowmere
tier: townsfolk
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Boy who found a glass-gull fledgling
backstory: A serious nine-year-old who has rescued a glass-gull chick from the foam and is determined to return it before the next tide, whatever the grown-ups say.
-->
<!-- npc
id: npc_corwen_tidesong
name: Singer Corwen Tidesong
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Singer of the slow songs
backstory: A grey, gentle singer who is the last on the coast who remembers the songs in the key they were sung in before the red moon rose, and who has begun to forget the third verse.
-->
<!-- npc
id: npc_marrek_soltane
name: Guild-Warden Marrek Soltane
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Warden of the glass-gatherers' guild
backstory: A broad, practical guild-warden who counts the guild's gatherers every dusk and who has set a night watch on a mile of beach where the glass has begun to dim.
-->
<!-- npc
id: npc_ilsabet_ferrow
name: Naturalist Ilsabet Ferrow
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Naturalist of the moon-moth flats
backstory: A thin, cheerful naturalist who has counted the moon-moths of the Glass Flats each autumn for eleven years and who has noticed they are flying in a new direction.
-->
<!-- npc
id: npc_marit_dunmore
name: Beachkeeper Marit Dunmore
tier: major
race: Human
region: reg_lustrine_shores
settlement: Lustrine glass beaches
role: Beachkeeper of a dark beach
backstory: A weathered woman who has tended one stretch of glass beach for forty years and who is sitting beside it, night after night, because it went out in a single tide and she will not leave it alone.
-->
<!-- npc
id: npc_perpetua_vask
name: Lamp-Keeper Perpetua Vask
tier: major
race: Human
region: reg_lustrine_shores
settlement: The Lamp Market
role: Keeper of the Lamp Market's oldest lamp
backstory: A tall, composed lamp-keeper who has tended the Market's first lamp for thirty years and who has begun to see, once an hour, something move inside it.
-->

---

## 1. The Lamp That Would Not Light

*A · OddJob · the Lamp Market · giver Lampwright Isolde Thorneglass*

**The short version.** A drowned child's mother has asked Isolde to make a lamp from the glass of the child's cradle. The glass will not glow.

**What is really going on.** Lustrine lamps glow from the moon's light held in the glass. The cradle was made before the red moon rose, from ordinary glass. It will glow only if it is *given* light, and the light has to be given by people who loved the child. The player gathers it.

**Scene 1: the workshop.**

**ISOLDE:** "Two thousand lamps. I know how to coax a glow out of a dead stone. This one I cannot."
**ISOLDE:** "It is clear glass. Pretty. Nothing in it."
**ISOLDE:** "Her mother comes every dusk and sits and does not ask. I would rather she asked."
> ► **"Why won't it glow?"** — **ISOLDE:** "It is not moon-glass. It never was."
> ► **"What does a lamp need?"** — **ISOLDE:** "Light. From somewhere. From someone."
> ► **"What can I do?"** — **ISOLDE:** "Ask the people who held her."

**Scene 2: the village.** The player visits a midwife, a grandfather and a neighbour girl. Each tells a small story of the child, Wenlow, aged three.

**MIDWIFE:** "She laughed at the tide. Every time. As if it had told a joke."
**GRANDFATHER:** "She liked to eat sand. I told her it was not good for her. She ate it anyway."
> ► **"Tell me more."** — Each gives a memory, and a thread of faint light hangs in the air.
> ► **"Would you give a little of your light?"** — They agree, shyly.
> ► **"Is there a song?"** — The neighbour girl sings four notes.

**Scene 3: the glass.** In the workshop, Isolde sets the cradle-glass in the furnace. The player holds the glass and speaks each memory aloud. The glass warms.

**ISOLDE:** "Hold it. Don't let go."
*A faint, honey-coloured glow starts at the lip and fills the whole bowl. It is not the cold white of moon-glass. It is warm.*
> ► **"Shape it as a cradle lamp."** — Isolde nods.
> ► **"Shape it as a small boat."** — **ISOLDE:** "She loved the tide. Yes."
> ► **"Leave it as it is."** — **ISOLDE:** "A lamp should be useful. But yes."

**Scene 4: the mother.** At dusk, the mother arrives. The lamp is set in the window of the workshop. She does not speak for a long time.

**MOTHER:** "That is her colour."
**MOTHER:** "She is not dead in it. She is *visiting.*"
**ISOLDE:** (very quietly) "I did not know a lamp could."

**Scene 5: the market.** Word spreads; by the end of the week three other families have come to the workshop with a small broken thing and a longer story.

**ISOLDE:** "I make lamps from the moon. I think I might make a few from people."
> ► **"Take the commissions."** — She nods and starts a list.
> ► **"Take only one a month."** — **ISOLDE:** "Yes. They are heavy to hold."
> ► **"Ask the families to tell the stories first."** — **ISOLDE:** "That is how it works."

**Scene 6: the window.** A month later the player passes the mother's house at dusk. The honey-coloured lamp is lit in the window, and a second, smaller lamp has been set beside it: a child's tin cup with a pebble of glass in it.

**MOTHER (at the door):** "The neighbour girl made it. It does not glow. She says it is waiting."
**MOTHER:** "I told her that was all right."
> ► **"It will glow."** — **MOTHER:** "Perhaps. I am not in a hurry."
> ► **"May I sit a moment?"** — She brings a stool and two cups of tea.
> ► **"Say nothing."** — She nods, grateful.

**Outcomes and receipt.**
- The cradle lamp is made, warm-gold rather than cold-white, and hangs in the mother's window. The three other commissions are accepted at a gentle pace.
- **Receipt:** a small honey-coloured glass bead, warm to the touch, from the cradle lamp's first cut.

<!-- quest
id: qst_lus_cradle_lamp
title: The Lamp That Would Not Light
rank: A
type: OddJob
giver: npc_isolde_thorneglass
region: reg_lustrine_shores
level: 126
act: 4
requires_rank: A
reward: 29500 | 1480 | 130000
sets: lus_cradle_lamp_done
summary: A lampwright cannot make a lamp from a drowned child's cradle-glass because it holds no moon-light. The people who loved the child must give it.
objectives:
  talk npc_isolde_thorneglass
  reach lus_lamp_market_workshop
  choice shape_cradle_boat_or_plain
-->

---

## 2. The Tide-Table Salt

*A · Delivery · the salt pans · giver Salt-Panner Osric Brinewick*

**The short version.** A widow marrying again wants the finest salt the marsh has made, in a week. Osric has the salt. He needs it carried across a tide-flat at the one hour the flat can be crossed.

**What is really going on.** The salt is for the groom's mother, a famously hard woman. Osric knows her and wants the salt to say, politely, *welcome.* The tide table is the real quest: the player must read the flat and the moons.

**Scene 1: the pans.**

**OSRIC:** "My father raked this pan. My grandfather raked this pan. I rake this pan, and nobody has ever asked for the *fine* salt."
**OSRIC:** "She asked. Seven days. A widow marrying again. I want it to be right."
> ► **"Why does the salt matter?"** — **OSRIC:** "It is what you give a house. Bread and salt."
> ► **"What is wrong?"** — **OSRIC:** "The flat. It floods at the changing of the moons. Two hours, no more."
> ► **"I'll carry it."** — **OSRIC:** "Don't spill. Don't hurry. Don't look at the red one."

**Scene 2: the flat.** The player waits for the ebb, reading Osric's chalk table. Two moons pull the water two ways and the flat, for an hour, is a mirror.

**OSRIC (earlier):** "Walk with the white moon on your left. The red moon is behind you. Do not look at her."
*Gameplay: a quiet crossing, no combat; glass-shrimp light the footprints.*
> ► **"Cross fast."** — A near thing.
> ► **"Cross slow, listening."** — The tide's song carries you through.
> ► **"Wait for a better ebb."** — Safe, but the hour runs short.

**Scene 3: the house.** In the groom's house the groom's mother receives the salt on a plain plate and tastes it with a wet fingertip.

**MOTHER:** "Hm."
**WIDOW:** (nervously) "It is from Osric's pan."
**MOTHER:** "I know whose pan. I have eaten that pan's salt for sixty years. It is the first time anyone has *brought* it."
> ► **"He wanted to say welcome."** — The mother's mouth twitches.
> ► **"It is the finest the marsh has made."** — **MOTHER:** "It is not the finest. It is the most *careful.*"
> ► **"Wish them well."** — The widow cries a little.

**Scene 4: the bread.** The mother breaks the bread and salts it, and passes it to the widow.

**MOTHER:** "You will do."

**Scene 5: the pan.** When the player returns, Osric is already out on the pan in the grey morning, raking.

**OSRIC:** "Well?"
> ► **"She said you will do."** — **OSRIC:** "She said that to the widow."
> ► **"She tasted it twice."** — **OSRIC:** "Twice? Hm. Good."
> ► **"She never said whose pan."** — **OSRIC:** "She did not need to."

**Scene 6: the long way home.** The tide has turned by the time the player starts back, and the flat is already shining with the first wet glass. A seal rests on a sandbar, watching the walker with huge calm eyes.

**OSRIC (earlier, in his chalk-table):** "If the seal is on the bar, you have time. If the seal is gone, run."
*The seal is there. It slides into the water without hurry.*
> ► **"Wave to it."** — It dips under in what looks like a bow.
> ► **"Leave it be."** — It lets you pass.
> ► **"Check the table again."** — A good habit.

**Outcomes and receipt.**
- The wedding goes ahead. Crossing slow earns a tide-reader's nod at the flats; crossing fast earns nothing but a story.
- **Receipt:** a pinch of fine marsh salt in a twist of paper, "bread and salt," from the groom's mother.

<!-- quest
id: qst_lus_tide_salt
title: The Tide-Table Salt
rank: A
type: Delivery
giver: npc_osric_brinewick
region: reg_lustrine_shores
level: 122
act: 4
requires_rank: A
reward: 28000 | 1400 | 125000
sets: lus_tide_salt_done
summary: A salt-panner needs his finest salt carried across a flooding tide-flat for a widow's wedding.
objectives:
  talk npc_osric_brinewick
  reach lus_groom_house_across_flat
  choice cross_fast_slow_or_wait
-->

---

## 3. Pale Mornings

*A · OddJob · the pale-morning house · giver Nurse Linnet Harrowmere*

**The short version.** Gatherers found on the flats after Ilyanthe's visits wake pale and empty-eyed. Linnet cares for nine. One has begun to hum.

**What is really going on.** The light taken from a person is not returned, but the *person* can be reminded, by small things: a tune, a smell, a hand held. Linnet needs someone to sit with the humming man and carry his tune home.

**Scene 1: the house.**

**LINNET:** "Nine. Four are children. Five are fishermen who went out for glass and came back for nothing."
**LINNET:** "They eat. They sleep. They do not look at anything for long."
**LINNET:** "One of them hums."
> ► **"What does he hum?"** — **LINNET:** "A tune I do not know. It repeats."
> ► **"Can they be cured?"** — **LINNET:** "I do not use that word."
> ► **"I'll sit with him."** — **LINNET:** "Thank you. Tell me what you hear."

**Scene 2: the humming man.** A broad fisherman sits by a window, pale, hands folded. He hums eight bars and stops. Eight bars and stops.

**FISHERMAN (flat, gentle):** "...Is it time?"
> ► **"Not yet."** — He nods and hums.
> ► **"What are you humming?"** — He turns toward you slowly.
> ► **"Hum it with me."** — The player does; he looks at the player's mouth.

**Scene 3: the village.** The player carries the tune down to the harbour, asking. An old net-mender recognises it.

**NET-MENDER:** "That's the tune you hum when the nets are wet. His wife sang it."
**NET-MENDER:** "She's been dead six years. He used to hum it when he had no one to sing to."
> ► **"Fetch her old net."** — The net-mender has it in a chest.
> ► **"Bring his son."** — The son, eleven, comes at a run.
> ► **"Bring the tune back whole."** — The net-mender sings the second half.

**Scene 4: the return.** In the house the player lays the old net in the fisherman's lap. His son stands at his knee, sings the second half. The man's hands move.

**FISHERMAN:** "...Marit?"
**SON:** "No, Da. It's Jory."
**FISHERMAN:** (a long pause) "...Jory."
*It is not a cure. It is the first name he has said in nine weeks.*

**Scene 5: Linnet's list.** Linnet writes a name in her book, and makes a mark beside it.

**LINNET:** "One. I will write 'one.' I will not write 'cured.'"
> ► **"What about the other eight?"** — **LINNET:** "We find their nets."
> ► **"Rest tonight."** — **LINNET:** "I would, if I knew how."
> ► **"I'll help find them."** — **LINNET:** "Then you are the second."

**Scene 6: the house at night.** The player stays late. When the lamps are lowered, the pale-morning house is very quiet, the sound of nine people breathing. Linnet sits by the window with a mug gone cold.

**LINNET:** "I used to think I was waiting for them to come back."
**LINNET:** "Now I think I am keeping the window open so they can."
> ► **"They know you are there."** — **LINNET:** "Some do. I can tell by the way they turn."
> ► **"Sleep. I'll sit up."** — She does not sleep, but she closes her eyes.
> ► **"Hum the tune."** — Very softly, from the next bed, someone hums it back.

**Outcomes and receipt.**
- One man says a name. The house learns a method: find the small thing, the song, the net. The cure is never named.
- **Receipt:** a hand-knotted net-float charm with a single bar of the tune written inside.
- **Canon-safe:** what Ilyanthe takes, and whether it can be returned, is not answered.

<!-- quest
id: qst_lus_pale_mornings
title: Pale Mornings
rank: A
type: OddJob
giver: npc_linnet_harrowmere
region: reg_lustrine_shores
level: 136
act: 4
requires_rank: A
reward: 33000 | 1650 | 145000
sets: lus_pale_mornings_done
summary: A nurse cares for gatherers found empty-eyed on the flats. One has begun to hum a tune, and the player carries it home.
objectives:
  talk npc_linnet_harrowmere
  reach lus_pale_morning_house
  choice net_son_or_second_half
-->

---

## 4. The Largest Piece

*A · Investigation · the offering beach · giver Elder Verity Merrowdale*

**The short version.** The greatest offering-stone of Verity's village, a slab of moon-glass the size of a door, is gone from the beach on the longest night.

**What is really going on.** The stone was not stolen. It was moved by the *village's own children,* who were told that the stone is the moon's tear and wanted to return it to the water so the moon would stop crying. They hid it in a sea-cave.

**Scene 1: the beach.**

**VERITY:** "Nobody steals offerings. It is not done. It has never been done."
**VERITY:** "It weighed eleven men. There are no drag marks. No cart."
> ► **"Who was here that night?"** — **VERITY:** "Everyone, until midnight. The children sang."
> ► **"Were the tides high?"** — **VERITY:** "Very. Both moons."
> ► **"I'll look."** — **VERITY:** "Please. Gently."

**Scene 2: the clues.** At the tideline the player finds small, round footprints in a line to the water, a cut length of net, and a rope slung over a rock.

**FISHER:** "My boy came home wet and would not say."
**GIRL (guarded):** "I didn't see anything."
> ► **"Say nothing."** — She watches your hands.
> ► **"Tell her you aren't angry."** — She softens.
> ► **"Ask about the moon."** — **GIRL:** "...It's *crying.* Everybody says it."

**Scene 3: the cave.** At low tide, a sea-cave below the dunes, a ring of seven children and a stone the size of a door resting on rollers of driftwood, tilted toward the water.

**BOY:** "We were going to give it back."
**GIRL:** "Because it is the moon's. And it's *sad.*"
**BOY:** "We could not push it that far."
> ► **"It's a lovely idea."** — The children light up.
> ► **"The moon doesn't need it back."** — **GIRL:** "How do you know?"
> ► **"Let's tell Verity together."** — A pause, and a nod.

**Scene 4: the elder.** Verity listens to the seven children, one after another, her face still.

**VERITY:** "The stone was for the moon, and the moon is the moon whether the stone is on the beach or in the water."
**VERITY:** "Seven children moved eleven men's worth of glass. That is a thing."
> ► **"Let them set it in the shallows."** — Verity thinks, and agrees.
> ► **"Return it to the beach."** — The children are crestfallen, but nod.
> ► **"Split it."** — **VERITY:** "No. Never."

**Scene 5: the ceremony.** On the next low tide the village rolls the stone to the edge of the water, at the children's direction, and sets it where the wave will lap it.

**VERITY:** "It is an offering, and it is a gift. Both."

**Scene 6: the first offering.** On the next full tide the village comes to the edge of the water to see the stone lapped by the first wave. The seven children stand in front, ill at ease, with sand on their knees.

**VERITY:** "Sing the first note."
**GIRL:** "Just one?"
**VERITY:** "One is how everything starts."
*She sings. The wave arrives a little late, as though it had been listening for the note.*
> ► **"Add a harmony."** — The children stare, then giggle.
> ► **"Stand with the children."** — Verity nods, approvingly.
> ► **"Watch the tide."** — It lingers.

**Outcomes and receipt.**
- The village adds a custom: the youngest child sings the first note of each offering. If the stone is returned to the beach, the children are heard but sulk; the peace is kept.
- **Receipt:** a child-sized scrap of knotted net tied to the player's belt, "the stone-rollers' thread."

<!-- quest
id: qst_lus_largest_piece
title: The Largest Piece
rank: A
type: Investigation
giver: npc_verity_merrowdale
region: reg_lustrine_shores
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: lus_largest_piece_done
summary: A village's greatest offering-stone has vanished from the beach on the longest night. The thieves are its own children.
objectives:
  talk npc_verity_merrowdale
  reach lus_children_sea_cave
  choice shallows_beach_or_split
-->

---

## 5. The Fledgling in the Foam

*A · Hidden · the tideline · giver Tobin Tallowmere*

**The short version.** A boy has a glass-gull chick in a bucket, and an hour before the high tide to get it back to the colony on the stack.

**What is really going on.** The colony is on a tidal stack that floods in an hour. The chick will drown if left, and the parents will abandon it if it smells of people. The player helps the boy get it there *without touching it.*

**Scene 1: the bucket.**

**TOBIN:** "It fell out. It was in the foam. Its wing is wet."
**TOBIN:** "I have not told Mam. She would say I'd killed it."
**TOBIN:** "The stack is far. And the tide is coming."
> ► **"Is it hurt?"** — **TOBIN:** "I don't think so. It's cold."
> ► **"Let me see."** — The chick peeps, indignant.
> ► **"We have an hour."** — **TOBIN:** "Then we run."

**Scene 2: the race.** Over wet glass flats, past anemone pools that glow like coals, with a bucket held level and a child shouting directions.

**TOBIN:** "Left! Left! The shrimp are slippery!"
*Gameplay: a short timed run; no combat; the glass is slick.*
> ► **"Carry Tobin on your back."** — He protests, then hangs on.
> ► **"Let him lead."** — He sets the pace, a good one.
> ► **"Carry the bucket yourself."** — He glares, then hands it over.

**Scene 3: the stack.** At the base of the stack, a sloping ledge of moon-glass, and above it a colony of white gulls, wheeling and screaming. The tide laps at the foot.

**TOBIN:** "I can't touch it. Mam said. Once a person touches them the parents..."
**TOBIN:** "Please."
> ► **"Use a glove."** — Better.
> ► **"Use a scrap of seaweed."** — The scent is hidden.
> ► **"Let it climb."** — The chick peeps, flaps, and clambers up a ledge.

**Scene 4: the return.** On a high ledge, a gull cocks its head. It calls once, a note like a bell. The chick answers.

**TOBIN:** "She knows it."
*The gull settles beside the chick, and the whole colony is quiet.*

**Scene 5: the walk back.** The tide is at their knees now. Tobin wades beside the player, silent and thrilled.

**TOBIN:** "Do you think it will remember me?"
> ► **"Gulls don't remember."** — **TOBIN:** "You don't know that."
> ► **"I think it might."** — He grins.
> ► **"I'll tell it about you."** — He thinks it a very good plan.

**Scene 6: the feather.** A week later a very small boy arrives at the inn where the player is staying, with a feather in a twist of cloth and an air of heavy responsibility.

**TOBIN:** "The chick has a name now. It is Brine. I do not know how I know, but I know."
**TOBIN:** "That is from him. It fell off. It is not a gift, it is a receipt."
> ► **"Thank you, Tobin."** — **TOBIN:** "You should write it down."
> ► **"What does Brine eat?"** — **TOBIN:** "Everything. It is rude."
> ► **"Will you go back?"** — **TOBIN:** "Every low tide. I told Mam."

**Outcomes and receipt.**
- The chick is returned; Tobin's mother is told nothing, then everything, and says only "Wipe your feet."
- **Receipt:** a single small, soft white feather, glowing faintly, given by the boy a week later.

<!-- quest
id: qst_lus_gull_fledgling
title: The Fledgling in the Foam
rank: A
type: Hidden
giver: npc_tobin_tallowmere
region: reg_lustrine_shores
level: 120
act: 4
requires_rank: A
reward: 27500 | 1380 | 122000
sets: lus_gull_done
summary: A boy has a glass-gull chick in a bucket and an hour before the tide floods the stack where its colony lives.
objectives:
  talk npc_tobin_tallowmere
  reach lus_gull_stack
  choice glove_seaweed_or_climb
-->

---

## 6. The Key the Songs Changed To

*A · Faction · the singers' hall · giver Singer Corwen Tidesong*

**The short version.** The fishers' songs changed key the year the red moon rose. Corwen is the last who remembers the old key, and he is forgetting the third verse.

**What is really going on.** The old key sounds *wrong* to young ears. The village singers want to keep the new key, which they love. The player brokers a quiet compromise: the old verse sung once a year.

**Scene 1: the hall.**

**CORWEN:** "Before the red moon, the songs were brighter. Higher. The boats danced to them."
**CORWEN:** "Now they are slow. Lovely. Slow."
**CORWEN:** "I have the first and second verse. I have lost the third."
> ► **"Who might have it?"** — **CORWEN:** "A woman on the far dune. She is ninety."
> ► **"Why does it matter?"** — **CORWEN:** "A key is a way of being in the world."
> ► **"Teach me."** — **CORWEN:** "You have no ear. Come anyway."

**Scene 2: the far dune.** An old woman, almost blind, sings a verse in a cracked, high, bright voice. The player writes it down.

**OLD WOMAN:** "It was a dancing song, before. We sang it at the moon, the first one, the white one."
**OLD WOMAN:** "Then there were two, and it seemed rude to sing."
> ► **"Sing it again."** — She does.
> ► **"Why did the key change?"** — **OLD WOMAN:** "Nobody said. We just drifted."
> ► **"I'll bring it back."** — She smiles and says nothing.

**Scene 3: the hall.** The village singers, young and old, hear the whole song for the first time in three generations. It is bright and strange.

**YOUNG SINGER:** "It sounds like... laughing."
**ELDER SINGER:** "It sounds like someone who has not met the red moon yet."
> ► **"Sing both keys."** — They try, and fail, and laugh.
> ► **"Keep the new key."** — Corwen nods sadly.
> ► **"Sing the old verse once a year."** — The elder singer says, "...Yes."

**Scene 4: the compromise.** The singers agree: the old key, once a year, at the longest night, for the first verse only.

**CORWEN:** "That is enough. That is a candle."

**Scene 5: the first time.** On the longest night, the village stands on the dune and Corwen begins. The old key rings out over the glass, high and clear, and the tide, for a moment, sounds like it is answering.

**CORWEN:** (afterward, hoarse) "I did not know I remembered it."
*No explanation is given for why the key changed.*

**Scene 6: the apprentice.** After the first night, a girl of eleven asks Corwen to teach her the verse. She has no ear and a great deal of nerve.

**CORWEN:** "Your voice is flat."
**GIRL:** "I will be flat in the old key."
**CORWEN:** "That is... practically a promise."
> ► **"Teach her."** — Corwen sighs, delighted.
> ► **"Lend her your notes."** — The page goes into her fist.
> ► **"Sing with her once."** — It is awful, and everyone smiles.

**Outcomes and receipt.**
- A yearly custom of the old key is begun. If the player pushes to restore the old key entirely, the young singers refuse; Corwen accepts the compromise.
- **Receipt:** a hand-copied page of the third verse, in the player's Journal, with the old key's name written in the margin.
- **Canon-safe:** a pure seed. The quest does not say why the key changed or whether the red moon caused it.

<!-- quest
id: qst_lus_old_key
title: The Key the Songs Changed To
rank: A
type: Faction
giver: npc_corwen_tidesong
region: reg_lustrine_shores
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: lus_old_key_done
summary: The fishers' songs changed key the year the red moon rose. The last singer of the old key is forgetting the third verse.
objectives:
  talk npc_corwen_tidesong
  reach lus_singers_hall
  choice both_new_or_yearly
-->

---

## 7. One Night on the Dark Mile

*A · Defense · the Dark Mile · giver Guild-Warden Marrek Soltane*

**The short version.** A mile of beach has gone dim. At the next high tide, Marrek expects Ilyanthe's light-gatherers to come. He needs a watch to bring every gatherer home.

**What is really going on.** Ilyanthe herself does not appear. Her lesser gatherers, thin moths of red light, drift over the sand and pull at anything that glows. The night's job is to keep people *dark,* dim lamps and quiet voices, and walk them off.

**Scene 1: the guildhouse.**

**MARREK:** "I count them at dusk. I count them at dawn. Last month I was short two."
**MARREK:** "The Dark Mile is a mile of beach that has gone out. The light is gone. They come for what is left."
> ► **"What do I do?"** — **MARREK:** "Cover the lamps. Whisper. Walk people home."
> ► **"Who comes?"** — **MARREK:** "Red moths. Small. They only want the glow."
> ► **"How many gatherers?"** — **MARREK:** "Forty."

**Scene 2: the dusk.** Forty gatherers, lamps shuttered, on a pale mile of sand. The red moon rises behind a cloud.

**GATHERER:** "Don't look at it."
**GATHERER:** "I'm not."
*Gameplay: defend the line; the threats are red moths; the aim is to bring the gatherers off the sand alive, not to kill.*
> ► **"Cover the glass with sand."** — The beach dims further.
> ► **"Lead them in a line, hand to shoulder."** — Slow, safe.
> ► **"Set a decoy lamp at the far end."** — The moths veer.

**Scene 3: the tide.** At the turn, a slow wave of red light moves across the flats. The moths part around the line of hushed gatherers. Something very high up, very far, hangs like a lantern and does not come nearer.

**GATHERER (whispering):** "...Is that her?"
**MARREK:** "Walk."
> ► **"Hold the rear."** — Hands steady.
> ► **"Take the stragglers."** — A child on your back.
> ► **"Keep them quiet."** — A lullaby, low.

**Scene 4: the count.** At the dunes, Marrek counts them in.

**MARREK:** "...Thirty-eight. Thirty-nine."
*A pause. A small figure comes out of the dark, dragging a sack of glass.*
**MARREK:** "Forty."

**Scene 5: the morning.** Marrek writes the number in the guild book and does not look up.

**MARREK:** "Forty out of forty. I am not sure I have ever written that."
> ► **"Do it again tomorrow?"** — **MARREK:** "Every night until she stops."
> ► **"Rest."** — **MARREK:** "After I have counted them twice."
> ► **"I'll be back."** — **MARREK:** "I know."

**Scene 6: the quiet hour.** Between the third and fourth bell the sand is silent and the water lies like glass. The player sits with a woman from the line, a weaver with one hand wrapped in a cloth.

**WEAVER:** "Do you think she knows we are here?"
**WEAVER:** "I think she knows there is something. I think that is all she knows."
> ► **"That is enough to fear."** — **WEAVER:** "It is enough to stop being afraid, too."
> ► **"Hold the lamp lower."** — She nods, and does.
> ► **"Tell me about your hand."** — A long, quiet story about a loom.

**Outcomes and receipt.**
- All forty come home. The Dark Mile stays dim, the siege goes on, and the watch becomes a guild custom.
- **Receipt:** a guild tally-stick with forty notches, the last one cut by Marrek's own hand.

<!-- quest
id: qst_lus_dark_mile
title: One Night on the Dark Mile
rank: A
type: Defense
giver: npc_marrek_soltane
region: reg_lustrine_shores
level: 146
act: 4
requires_rank: A
reward: 35000 | 1750 | 152000
sets: lus_dark_mile_done
summary: A mile of glass beach has gone dim, and the guild-warden needs forty gatherers walked safely home at the high tide.
objectives:
  talk npc_marrek_soltane
  defend lus_dark_mile
  choice sand_line_or_decoy
-->

---

## 8. The Moon-Moth Count

*A · Exploration · the Glass Flats · giver Naturalist Ilsabet Ferrow*

**The short version.** The moon-moths of the Glass Flats are flying in a new direction. Ilsabet wants someone to follow one flock to where it goes.

**What is really going on.** The moths are flying toward a quiet cove where the glass still glows, the last undimmed pocket on the coast. They are *finding* it, and they will lead Ilyanthe's gatherers there too if people are careless.

**Scene 1: the field-hut.**

**ILSABET:** "Eleven autumns. They go east to the marsh, always east. This year, west."
**ILSABET:** "I do not like unexplained things. I like them explained in the field."
> ► **"What do you need?"** — **ILSABET:** "A second pair of eyes. And boots."
> ► **"Where are they going?"** — **ILSABET:** "A cove I did not know existed."
> ► **"Let's follow."** — **ILSABET:** "Quietly. They startle."

**Scene 2: the flats at night.** Hundreds of pale wings lifting off the glass. The two walk after, shuttered lamp, silent.

**ILSABET:** (whispering) "Eleven hundred. Twelve hundred. Look at them."
> ► **"Count with her."** — Fingers moving in the dark.
> ► **"Watch the red moon."** — A cloud covers it, gratefully.
> ► **"Follow the lead moth."** — A big silver one.

**Scene 3: the cove.** A small sheltered cove, and its glass still shining white-blue, undimmed, with a thousand moths resting on it like snow.

**ILSABET:** "Oh. Oh, that is the loveliest thing."
**ILSABET:** "And I think we have just found the next thing to go dark."
> ► **"Keep the location secret."** — **ILSABET:** "Yes. For now."
> ► **"Tell the guild."** — **ILSABET:** "They would guard it. Or they would gather it."
> ► **"Mark it on the naturalist's map only."** — **ILSABET:** "In pencil."

**Scene 4: the choice.** Back at the hut, Ilsabet tears out the page.

**ILSABET:** "A count of twelve hundred and fifty moths. That is all the paper will say."

**Scene 5: the cove, later.** A week on, the player passes the cove from the cliff path. The glass still shines, the moths still rest. Nobody else is on the beach.

**ILSABET (note, tied to a cairn):** "Not yet."

**Scene 6: the tally.** Ilsabet hands the player a tiny booklet of counts, eleven years of pencil, every page in the same square hand.

**ILSABET:** "Twelve hundred and fifty. Thank you for counting. I always lose count at the thousand."
**ILSABET:** "I am very bad at being the only one who counts."
> ► **"Write my name in the book."** — She does, small, in the margin.
> ► **"Come back next year."** — **ILSABET:** "Oh, I shall."
> ► **"Share a flask."** — She produces two cups.

**Scene 7: the last page.** Before she lets the player go, Ilsabet reads aloud the last page of her notebook, a list of every place the moths have rested this autumn, in the order they chose.

**ILSABET:** "A drift of pine. A cracked boat. A lamp on a post. The cove. Do you see it? They are not looking for glass. They are looking for *company.*"
> ► **"Perhaps they are lonely."** — **ILSABET:** "Perhaps we all are."
> ► **"Perhaps they are just moths."** — **ILSABET:** "Perhaps. I like my version."
> ► **"Add a line for me."** — She hands you the pencil.

**Outcomes and receipt.**
- The cove stays secret for now. Telling the guild brings guards, and a gatherers' dispute; keeping it quiet keeps it dim and safe.
- **Receipt:** a pencilled field-map, one corner torn off, with a small moth drawn where the cove would be.

<!-- quest
id: qst_lus_moth_count
title: The Moon-Moth Count
rank: A
type: Exploration
giver: npc_ilsabet_ferrow
region: reg_lustrine_shores
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: lus_moth_count_done
summary: The moon-moths of the Glass Flats are flying in a new direction, to a cove where the glass still shines.
objectives:
  talk npc_ilsabet_ferrow
  reach lus_moth_cove
  choice secret_guild_or_pencil
-->

---

## 9. The Beach That Went Out

*S · Investigation · the dark beach · giver Beachkeeper Marit Dunmore*

**The short version.** Marit's beach went out in a single tide. She sits beside it every night. She wants to know whether a beach that has gone dark can be called back.

**What is really going on.** Nothing in the beach is broken. The glass has been *emptied,* and people are the only thing on the coast that gives light back. A vigil of gatherers, each speaking a name of someone they love into the glass, brings back a faint, steady glimmer. Not the old light. Another.

**Scene 1: the dune.**

**MARIT:** "Forty years. I swept this beach. I knew every shell."
**MARIT:** "It went out on a Tuesday. In one tide. Like a lamp blown."
**MARIT:** "I have sat here every night since. I do not know why."
> ► **"Has anything changed?"** — **MARIT:** "Nothing. Nothing at all."
> ► **"What do you hope for?"** — **MARIT:** "A glimmer. Any."
> ► **"I'll sit with you."** — **MARIT:** "You will be cold."

**Scene 2: the vigil.** The player sits through a night with Marit. The glass is dull, grey, ordinary. In the small hours, she begins to talk to it, not to anything in it.

**MARIT:** "My husband used to say the glass listened. I said he was soft."
> ► **"Say his name."** — She does, and the glass is silent.
> ► **"Say yours."** — She laughs.
> ► **"Say nothing."** — The quiet is the answer.

**Scene 3: the gathering.** In the morning Marit speaks to the guild. A dozen gatherers come, grudging. Each is asked to speak the name of one person they love, into a handful of the dead glass.

**GATHERER:** "It's a handful of sand."
**MARIT:** "Then it won't hurt."
*One at a time, quietly, they speak. The tenth speaks her daughter's name, and the glass in her palm warms, just a little, with a faint grey glow.*
> ► **"Lay the glass back on the beach."** — A slow, small constellation.
> ► **"Keep it in your hand."** — The glow lasts until dusk.
> ► **"Take it to the water."** — The tide takes it, glowing.

**Scene 4: the glimmer.** By dusk, a hundred small grey lights shine along a hundred yards of beach, each from a handful of dead glass, each fed by a name.

**MARIT:** "It is not the old light."
**MARIT:** "It is *ours.*"
**GATHERER:** "It might be gone by morning."
**MARIT:** "Then we say them again tomorrow."

**Scene 5: the tide.** At the next high tide the red moon rises. Marit does not look at it. Out on the water, something very faint and very far goes still, as if listening.

**MARIT:** (whispering) "...Don't look."
*The quest does not say what listened.*

**Scene 6: a thing Marit says.** After the vigil, Marit walks the player to the edge of the dune and speaks to the empty beach as if it were a patient animal.

**MARIT:** "I will see you tomorrow."
**MARIT:** "I used to think I was keeping the beach. I was keeping myself company."
> ► **"It was good company."** — She smiles properly for the first time.
> ► **"I will say a name for you."** — **MARIT:** "Say it for the beach."
> ► **"Come and have supper."** — She goes, for once, without looking back.

**Outcomes and receipt.**
- The beach is not restored. A fragile, human light is kept alive by a nightly vigil, and the guild adopts the custom. The siege goes on.
- **Receipt:** a handful of dim grey glass, warm in the palm, with a name written in it that only the player can feel.
- **Canon-safe:** the quest does not say whether Ilyanthe responded, and does not explain the glass.

<!-- quest
id: qst_lus_dark_beach
title: The Beach That Went Out
rank: S
type: Investigation
giver: npc_marit_dunmore
region: reg_lustrine_shores
level: 166
act: 5
requires_rank: S
reward: 70000 | 3000 | 320000
sets: lus_dark_beach_done
summary: A beachkeeper's glass beach went dark in a single tide. A vigil of gatherers speaking names into the glass brings back a faint, human light.
objectives:
  talk npc_marit_dunmore
  reach lus_dark_beach_vigil
  choice lay_keep_or_water
-->

---

## 10. The Lantern Has a Passenger

*S · Exploration · the Lamp Market's first lamp · giver Lamp-Keeper Perpetua Vask*

**The short version.** The Lamp Market's oldest lamp, lit three hundred years, has begun to show something moving inside once an hour. Perpetua asks the player to sit the night beside it.

**What is really going on.** *Nothing is explained.* The shape in the lamp is small, upright and slow, like a person walking down a long corridor. At the third watch it reaches the glass and presses a hand to it. Its hand is the player's own hand, in the lamp's light. The quest ends on that, and does not say whose light it is.

**Scene 1: the stall.**

**PERPETUA:** "Thirty years I've kept this lamp. Never an oil, never a trim. It's the first one, they say. The one that began the Market."
**PERPETUA:** "Once an hour, something moves inside it."
**PERPETUA:** "I have not told the guild. They would take the lamp out of the stall."
> ► **"What does it look like?"** — **PERPETUA:** "A person. Walking."
> ► **"Is it dangerous?"** — **PERPETUA:** "It has never done anything."
> ► **"I'll watch."** — **PERPETUA:** "Bring a blanket. And do not blink at the wrong time."

**Scene 2: the night.** A cold night beside a lamp. The market is shuttered. At the first hour, a tiny figure appears, far down in the glass, walking.

**ENV (journal):** *The figure is smaller than a thumb. It walks away from you, slowly, and does not turn.*
> ► **"Speak to it."** — No answer.
> ► **"Hold up a light."** — The figure pauses.
> ► **"Say nothing."** — The figure walks on.

**Scene 3: the third watch.** The figure has come a long way. It is larger now, nearer the glass. It stops. It turns.

**PERPETUA:** (barely) "It has never turned."
*It raises one hand and presses it, palm flat, to the inside of the glass. The player raises a hand without thinking. The two palms align.*
> ► **"Press back."** — The glass is warm.
> ► **"Step away."** — The hand slowly lowers.
> ► **"Ask: who are you?"** — The lamp flickers once, softly.

**Scene 4: the dawn.** In the morning light the lamp is only a lamp. Perpetua pours tea from a flask and sits beside the player.

**PERPETUA:** "I thought it would be someone I knew."
**PERPETUA:** "It was not. I think it was *looking* for someone."

**Scene 5: the Market.** The stalls open. Nobody looks at the oldest lamp. Perpetua sets a small chair beside it, and a blanket.

**PERPETUA:** "I'll keep the watch. In case it comes back."

**Scene 6: the chair.** The next evening Perpetua is in her stall with the lamp, the blanket and the small chair, and has set out two cups.

**PERPETUA:** "I do not know if it will come tonight."
**PERPETUA:** "I thought the least I could do was look as though I were expecting company."
> ► **"I will stay."** — **PERPETUA:** "Then it is two of us expecting."
> ► **"Leave the lamp lit."** — **PERPETUA:** "It has never needed asking."
> ► **"Ask the lamp."** — The glass is warm, and gives nothing back.

**Outcomes and receipt.**
- The lamp is left in its stall; the guild is told nothing. A small chair is added beside the lamp, and a blanket.
- **Receipt:** a sketch in the Journal of a small figure with its palm to the glass, and the player's palm beside it.
- **Canon-safe:** a pure seed. It does not say who the figure is, where the lamp's light comes from or whether Ilyanthe is involved.

<!-- quest
id: qst_lus_lantern_passenger
title: The Lantern Has a Passenger
rank: S
type: Exploration
giver: npc_perpetua_vask
region: reg_lustrine_shores
level: 178
act: 5
requires_rank: S
reward: 76000 | 3250 | 345000
sets: lus_lantern_done
summary: The Lamp Market's oldest lamp shows something walking inside it once an hour. A keeper asks the player to watch the night.
objectives:
  talk npc_perpetua_vask
  reach lus_lamp_market_first_lamp
  choice press_step_or_ask
-->
