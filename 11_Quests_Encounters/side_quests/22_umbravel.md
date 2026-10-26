# 11e-22 — Umbravel, the Silk City Below: Ten Side Quests (draft)

> *"Umbravel's founders fled the surface during the Sundering and chose the dark over the sky."*
> — Gazetteer, Umbravel

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[side_quests_index]]). The hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`. Spoilers: light.

**Region:** `reg_umbravel` (the hanging city, the Lantern Bridges, the silk lifts, the Silk Contract Hall, the cocooned districts, the Deep Webs). **Rank band:** C–B. **Tone:** lamplight and held breath. A quiet, beautiful, slightly formal city that chose the dark and made it lovely, and which has just learned that the dark had a landlord. Warm where people hold a lantern for each other.

**Placement notes.**
- **Vel'thara, the Web Queen,** is the region's Tyrant. She rose when the weaver-guilds broke the silk contract, and calls the city a web she has merely lent. No quest here kills her or ends the siege; quests 6-10 change how the city *prepares* and what the Queen says first, and quest 10 lets the player read her opening terms.
- Umbravelers honour the day-gods **with lanterns in place of the sun**; a lantern is lit at dawn-hour for each household and a **silk offering** is left in the deep webs. Strands are tuned like instruments. Spiders are tended like livestock, and are named.
- The city is run by **weaver-guilds**; the guild of the oldest webs has the most say. The **silk contract** is the founding law, and the guilds broke it within living memory to sell more silk to the surface.
- Earlier pattern quest in this region: *The Thread That Hums* (riddle). Not a prerequisite.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | Dawn-Lamp Hour | C | OddJob | Lamplighter Ainsel Corvane | Comic-warm: the moths have opinions |
| 2 | A Family in the Cocoon | C | Escort | Sevrin Loomis | Tense and tender: cut them out, or ask |
| 3 | Honey for the Deep Webs | C | Delivery | Trader Hortensia Bellweather | Comic-warm: a surface cargo the brood wants |
| 4 | Who Cut the Bridge? | C | Investigation | Bridgewarden Teodric Vane | Mystery and dilemma: shears, not claws |
| 5 | A Line of Daylight | C | Exploration | Bat-Warden Linden Amber | Wonder: the bats are leaving upward |
| 6 | Restored, Quietly | B | Faction | Guildmistress Ysaline Orrin | Dilemma: the contract, without the families |
| 7 | The Vigil at Lift Nine | B | Defense | Lift-Warden Orsa Venn | Action: the brood climbs the cables |
| 8 | The Knot She Always Tied | B | Hidden | Old Tamsin Brightwire | Tender mystery: an offering that is answered |
| 9 | Chain or Silk | B | OddJob | Engineer Pellory Gimblewick | Comic-warm: a spider who refuses to retire |
| 10 | A Letter in the Web | B | Investigation | Strand-Reader Lissandre Veyl | Puzzle: the Queen's opening terms |

## Cast

<!-- npc
id: npc_ainsel_corvane
name: Lamplighter Ainsel Corvane
tier: townsfolk
race: Human
region: reg_umbravel
settlement: Umbravel, the Low Lantern Ward
role: District lamplighter
backstory: A thin, tireless lamplighter who has lit the dawn-lamps of the Low Ward for thirty years and has just been out-argued by a moth.
-->
<!-- npc
id: npc_sevrin_loomis
name: Sevrin Loomis
tier: townsfolk
race: Human
region: reg_umbravel
settlement: Umbravel, the Spindle Terrace
role: Husband of a cocooned family
backstory: A gentle silk-dyer whose wife and daughter were sealed in a cocoon along with their whole terrace, and who has been talking to the wall every night for nine days.
-->
<!-- npc
id: npc_hortensia_bellweather
name: Trader Hortensia Bellweather
tier: major
race: Human
region: reg_umbravel
settlement: Umbravel, the Trade Landing
role: Surface honey-trader
backstory: A cheerful, round surface trader stranded in the city with forty jars of honey that the brood on the lower webs will not stop asking for.
-->
<!-- npc
id: npc_teodric_vane
name: Bridgewarden Teodric Vane
tier: major
race: Dark Elf
region: reg_umbravel
settlement: Umbravel, the Lantern Bridges
role: Warden of the cut bridges
backstory: A grave dark elf who has inspected every strand of the Lantern Bridges for twenty years and knows the difference between a claw-cut and a blade-cut by its sound.
-->
<!-- npc
id: npc_guildmaster_ilario_spoole
name: Guildmaster Ilario Spoole
tier: major
race: Gnome
region: reg_umbravel
settlement: Umbravel, the Weavers' Row
role: Guildmaster of the Shuttle-Makers
backstory: A rotund, soft-spoken gnome who is perfectly polite about everything and has never yet been seen on the wrong side of a cut bridge.
-->
<!-- npc
id: npc_linden_amber
name: Bat-Warden Linden Amber
tier: major
race: Dark Elf
region: reg_umbravel
settlement: Umbravel, the Roost Gallery
role: Warden of the blind bats
backstory: A quiet dark elf who counts the city's blind bats every dusk and has just counted them leaving, upward, in tens.
-->
<!-- npc
id: npc_little_mip
name: Mip
tier: townsfolk
race: Gnome
region: reg_umbravel
settlement: Umbravel, the Roost Gallery
role: Bat-warden's apprentice, aged nine
backstory: A small gnome child who has never seen daylight and wants, more than anything, to know what the bats are going toward.
-->
<!-- npc
id: npc_ysaline_orrin
name: Guildmistress Ysaline Orrin
tier: major
race: Human
region: reg_umbravel
settlement: Umbravel, the Silk Contract Hall
role: Guildmistress of the oldest webs
backstory: A composed, silver-haired guildmistress who signed the contract that broke the old one, and who now wants it mended before anyone asks her why.
-->
<!-- npc
id: npc_orsa_venn
name: Lift-Warden Orsa Venn
tier: major
race: Dark Elf
region: reg_umbravel
settlement: Umbravel, Lift Nine
role: Warden of the lift cables
backstory: A tough, laconic lift-warden with calluses on both palms, who has kept Lift Nine running for twenty years and is not going to stop for a spider.
-->
<!-- npc
id: npc_old_tamsin_brightwire
name: Old Tamsin Brightwire
tier: major
race: Gnome
region: reg_umbravel
settlement: Umbravel, the Underweb Stair
role: Retired blind weaver
backstory: A tiny, blind, very old gnome weaver who walks the Underweb Stair every night with a bundle of silk, and who is called mad by the people who have never followed her.
-->
<!-- npc
id: npc_pellory_gimblewick
name: Engineer Pellory Gimblewick
tier: major
race: Gnome
region: reg_umbravel
settlement: Umbravel, Lift Three
role: Chief engineer of the lifts
backstory: A brisk, excitable gnome engineer who has just been funded to replace the silk lifts with iron chain, and who has not yet told the spider that runs Lift Three.
-->
<!-- npc
id: npc_lissandre_veyl
name: Strand-Reader Lissandre Veyl
tier: major
race: Dark Elf
region: reg_umbravel
settlement: Umbravel, the Silk Contract Hall
role: Reader of tuned strands
backstory: A careful dark elf scholar who can hear what a plucked strand says, and who has been handed a message from the deep webs that no one else dares to touch.
-->

---

## 1. Dawn-Lamp Hour

*C · OddJob · the Low Lantern Ward · giver Lamplighter Ainsel Corvane*

**The short version.** The dawn-lamps of the Low Ward will not light. The luminous moths that feed them have deserted the lanterns for a single, enormous, glowing, rude cave-moth, and Ainsel has until the hour bell to get them back.

**What is really going on.** The big moth is a female with a nest of eggs in a crack under the ward's oldest lantern. Every smaller moth in the district has gathered to guard her. Move her and the ward is dark for a week; leave her and the dawn-lamps stay unlit. A third option is to let her be the dawn-lamp.

**Scene 1: the lamp-shop.**

**AINSEL:** "Thirty years I've lit the Low Ward. Thirty years the moths came to the lanterns *like they were told.*"
**AINSEL:** "This morning, nothing. Not a wing. They're all *sitting on a crack,* in a *crowd.*"
**AINSEL:** "I tried asking nicely. I tried *humming.* It *looked* at me."
> ► **"Show me the crack."** — **AINSEL:** "Mind your head. It *drops.*"
> ► **"What do moths want?"** — **AINSEL:** "Light, mostly. And not to be shouted at."
> ► **"I'll try."** — **AINSEL:** "I'll make tea. For when it goes wrong."

**Scene 2: the crack.** A hundred small wings, stacked like tiles, around a single glowing shape the size of a bread-board.

**AINSEL:** "That's *Madam.* I named her just now. She seems to like it."
**AINSEL:** "She's got eggs. I can see them. They're like pearls."
*The big moth fixes the player with an enormous, patient, many-faceted stare.*

**Scene 3: the negotiation.** Over the next hour, the player tries to persuade a moth.

> ► **"Move her gently."** — A slow, tense lift; Madam allows it, and then drifts straight back.
> ► **"Offer her a better lamp."** — Ainsel builds a warm, glowing nest-lantern from a spare globe and a basket.
> ► **"Light the ward around her."** — The lanterns are relit by hand, one by one, with Madam in the middle.

**AINSEL:** "She's *deciding.* She does that with her whole body."
**NEIGHBOUR (hanging out a window):** "Is that the *dawn-lamp?* Is it *meant* to be that big?"

**Scene 4: the dawn.** The hour bell rings. The big moth rises. In her wake, a hundred small ones flutter back to the lanterns, one by one, until every lamp in the ward is lit.

**AINSEL:** "Thirty years. I never *once* thought of asking."

**Outcomes and receipt.**
- The Low Ward lights again. If the player built a nest-lantern or lit the ward around her, Madam remains as the ward's living dawn-lamp, brooding her eggs.
- **Receipt:** a glowing nest-lantern hung over the Low Ward gate; a small brass plate reading *"Madam. Please do not move."*

<!-- quest
id: qst_umb_dawn_lamp_hour
title: Dawn-Lamp Hour
rank: C
type: OddJob
giver: npc_ainsel_corvane
region: reg_umbravel
level: 58
act: 3
requires_rank: C
reward: 3600 | 200 | 14000
sets: umb_dawn_lamp_done
summary: A lamplighter's moths desert his lanterns for one enormous, brooding cave-moth.
objectives:
  talk npc_ainsel_corvane
  reach low_lantern_ward_crack
  choice move_nest_or_light
-->

---

## 2. A Family in the Cocoon

*C · Escort · the Spindle Terrace · giver Sevrin Loomis*

**The short version.** A whole terrace of the city has been wrapped in white silk, thick as bread-dough. Sevrin's wife and daughter are inside, and he can hear them knocking. The guild says do nothing, because to cut the silk is to insult the Queen.

**What is really going on.** The cocoon is not a killing. It is *keeping.* The silk is warm, dry and airy, and the people inside are asleep or half-awake, safe. The Queen considers them "lent" and has stored them. A cut will free them, but the brood nearby will take it as theft. A request, with a silk offering, will be answered. Slowly.

**Scene 1: the terrace.**

**SEVRIN:** "I talk to the wall at night. They knock back. Twice for *yes.* Once for *no.* Their code. We made it up."
**SEVRIN:** "The guild says the Queen would be *offended.*"
**SEVRIN:** "I have a knife. I am afraid to use it. I would like someone to tell me which kind of afraid is *correct.*"
> ► **"I'll look."** — **SEVRIN:** "Thank you. Please don't touch the silk with iron."
> ► **"Can you hear them now?"** — **SEVRIN:** "Always."
> ► **"We could ask."** — **SEVRIN:** "...Ask whom?"

**Scene 2: the cocoon.** A great white wall, humming faintly. Tiny sounds inside: a child's counting rhyme, muffled.

**DAUGHTER (through the silk):** "Papa? Is it day?"
**SEVRIN:** "It's day, love."
**DAUGHTER:** "It doesn't feel like it. Is the lamp still lit?"
*The player sets a hand to the silk. It is warm and breathes, very slightly.*

**Scene 3: the choice.**

> ► **"Cut a door, gently."** — A sharp, quick job with bone-needles and glass-knives. A brood-spider appears at the far end of the terrace and watches.
> ► **"Leave a silk offering and wait."** — Nine hours of quiet, a thread of lamp-light, and a slow, soft unwrapping from the inside.
> ► **"Bargain with the watcher."** — A long, tense exchange in tapped signals with the brood-spider overhead.

**SEVRIN:** (very quietly) "She's *opening* it."

**Scene 4: the unwrapping.** Out of the white steps a woman, groggy, blinking at the lantern-light. Behind her, a small girl clutching a stuffed spider.

**DAUGHTER:** "Papa! I counted to *five thousand!*"

**Outcomes and receipt.**
- The family is freed. If the player cut the cocoon, the spider on the roof withdraws, and a single thread is left across the terrace like a warning. If the player waited and offered, the silk is removed with care, and the thread left on the doorstep is a gift.
- **Receipt:** a hanging lantern at the terrace gate with a knotted silk ribbon; the knocking-code written on the wall in chalk.

<!-- quest
id: qst_umb_family_cocoon
title: A Family in the Cocoon
rank: C
type: Escort
giver: npc_sevrin_loomis
region: reg_umbravel
level: 61
act: 3
requires_rank: C
reward: 3800 | 210 | 14500
sets: umb_cocoon_family_freed
summary: A silk-dyer's wife and daughter are alive inside a cocoon, and the guilds say cutting it would insult the Queen.
objectives:
  talk npc_sevrin_loomis
  reach spindle_terrace_cocoon
  escort npc_sevrin_loomis
  choice cut_offer_or_bargain
-->

---

## 3. Honey for the Deep Webs

*C · Delivery · the Trade Landing · giver Trader Hortensia Bellweather*

**The short version.** Hortensia is a surface trader with forty jars of honey and no buyers. The spiders on the lower webs have noticed the smell and will not stop coming up to look at it. She would like someone to take it somewhere before she becomes a legend.

**What is really going on.** The brood has never tasted honey. The Queen's spiders have been tapping a very polite request on the lower cables for two days. Hortensia wants to sell the honey to the guilds. The guilds want the cargo as a bargaining chip. The spiders only want to see what the jars are *for.*

**Scene 1: the landing.**

**HORTENSIA:** "I came to sell *honey.* To *people.* Instead I have a spider on my roof, a spider on my cart and a spider *in my bed.*"
**HORTENSIA:** "They don't *take* anything. They just *look.* And tap."
**HORTENSIA:** "I've been told it means 'please.'"
> ► **"What do they want?"** — **HORTENSIA:** "The *jars.* I think. Or the *smell.* It's hard to tell with eight eyes."
> ► **"Who wants to buy?"** — **HORTENSIA:** "The guilds. At a *very* high price, with a *very* odd clause."
> ► **"Let's take them down."** — **HORTENSIA:** "Wonderful. I'll pack a spoon."

**Scene 2: the stair.** Down the Underweb Stair, with forty jars on a hand-cart. The stair creaks. Spiders gather behind the cart in a patient line, like a parade.

**HORTENSIA:** "Is it me, or are they *following?*"
**GUILD CLERK (appearing from a landing):** "That cargo is guild property under the third articles of trade."
**HORTENSIA:** "It's *honey,* sir."
**GUILD CLERK:** "It is *leverage.*"

**Scene 3: the choice.** At the edge of the deep webs, a spider the size of a cart waits, one leg raised in the air, as if to ask a question.

> ► **"Give them the lot."** — Forty jars, laid in a row at the edge of the web.
> ► **"Sell half to the guilds, and give half."** — A tidy, fair compromise, if a little smug.
> ► **"Open one jar and let them taste."** — The brood-spider samples a tiny dab, and goes very still.

**HORTENSIA:** "Is it *dying?*"
**BROOD-SPIDER:** (a rapid, delighted tapping)
**HORTENSIA:** "Oh. Oh no. It's *happy.*"

**Scene 4: the dusk.** At the lantern hour, forty empty jars hang on silk cords along the stair, each with a bright pearl of honey left in the bottom.

**HORTENSIA:** "I've sold my whole cargo and I've not made a *coin.* And I've never been so pleased."

**Outcomes and receipt.**
- The honey is delivered. If the player gave it all, the brood leaves silk in return: a bolt of fine, bright thread. If the player sold half, the guilds are satisfied and the spiders are polite. If the player tasted first, the brood becomes inexplicably friendly with Hortensia for life.
- **Receipt:** a row of honey jars hanging from the Underweb Stair; a small, glowing silk banner on Hortensia's stall reading *"Spiders welcome."*

<!-- quest
id: qst_umb_honey_deep_webs
title: Honey for the Deep Webs
rank: C
type: Delivery
giver: npc_hortensia_bellweather
region: reg_umbravel
level: 64
act: 3
requires_rank: C
reward: 4000 | 225 | 15000
sets: umb_honey_delivered
summary: A stranded surface trader has forty jars of honey the Queen's brood keep asking about, and the guilds want it as leverage.
objectives:
  talk npc_hortensia_bellweather
  reach underweb_stair_honey_landing
  choice give_split_or_taste
-->

---

## 4. Who Cut the Bridge?

*C · Investigation · the Lantern Bridges · giver Bridgewarden Teodric Vane*

**The short version.** The west bridge to Weavers' Row was cut in the night. The guilds say the Web Queen did it. Teodric, who has inspected the fall, says the strands were cut with a blade.

**What is really going on.** The cut was made by a rival guild's agents, to isolate the Weavers' Row during the confusion and take over their export contracts. The guild that benefits is the Shuttle-Makers, led by Ilario Spoole, who has been polite about it all week. The Queen is a convenient scapegoat.

**Scene 1: the cut.**

**TEODRIC:** "A claw leaves a rough edge. A blade leaves a clean one. A *spider's* cut hums. This one doesn't."
**TEODRIC:** "Someone cut my bridge. Someone who knows how silk *sings.*"
**TEODRIC:** "I would like it said by someone other than me."
> ► **"What did you find?"** — **TEODRIC:** "A shuttle-maker's mark on the severed knot."
> ► **"Who benefits?"** — **TEODRIC:** "Anyone who owns the other side."
> ► **"Let me check."** — **TEODRIC:** "Please. Carefully."

**Evidence.**
- **The cut** is clean, made with a hooked bridge-knife of a type used by the Shuttle-Makers' maintenance crew.
- **A dropped bobbin** of black thread, dyed in Spoole's own colour.
- **A witness**, an apprentice dyer, who saw two lanterns on the bridge at midnight and thought nothing of it.
- **A ledger** in the Shuttle-Makers' hall showing a payment for "repairs" a day before the cut.

**Scene 2: the guildhall.** Guildmaster Ilario Spoole receives the player in a warm, drowsy sitting-room.

**SPOOLE:** "Dear me. A bridge. What a *dreadful* business."
**SPOOLE:** "Naturally, one assumes the Queen."
> ► **"Show the bobbin."** — He looks at it, and his smile does not change.
> ► **"Ask about the repairs."** — **SPOOLE:** "A clerical matter."
> ► **"Mention the apprentice."** — **SPOOLE:** (a very small pause) "How *distressing.*"

**Scene 3: the verdict.** The council meets on a bridge that is still standing. The guilds are waiting to hear whose fault it is.

> ► **"Accuse Spoole openly."** — The Shuttle-Makers are censured; the council splits in two.
> ► **"Offer Spoole a quiet way to repay the damage."** — He pays in silk and in coin, and the bridge is rebuilt at his cost.
> ► **"Let Teodric decide."** — The bridgewarden reads the cut aloud, strand by strand.

**TEODRIC:** "It wasn't her. It was never her."

**Outcomes and receipt.**
- The bridge is mended and the blame placed where it belongs. If Spoole is accused, the Shuttle-Makers lose a seat; if he pays, he keeps it and owes the city a favour. Whichever way, the Queen's name is cleared on this one count.
- **Receipt:** a new bridge-span with a bright lantern at the middle; Teodric's inspection tag, signed, tied to the first strand.

<!-- quest
id: qst_umb_who_cut_bridge
title: Who Cut the Bridge?
rank: C
type: Investigation
giver: npc_teodric_vane
region: reg_umbravel
level: 67
act: 3
requires_rank: C
reward: 4100 | 230 | 15500
sets: umb_bridge_cut_solved
summary: A bridge to Weavers' Row was cut with a blade, not a claw, and the guilds blame the Queen.
objectives:
  talk npc_teodric_vane
  talk npc_guildmaster_ilario_spoole
  choice accuse_repay_or_bridgewarden
-->

---

## 5. A Line of Daylight

*C · Exploration · the Roost Gallery · giver Bat-Warden Linden Amber*

**The short version.** The city's blind bats have started leaving, upward, in tens, every dusk. Linden has counted them all his life. He would like to follow them, and cannot climb, and has a nine-year-old apprentice who is very good at it.

**What is really going on.** High above the cavern roof, a narrow crack leads to the surface. A single beam of daylight slants through it for twenty minutes at noon. The bats have been moving toward it for years. Something has made them hurry. The apprentice, Mip, has never seen the sun.

**Scene 1: the gallery.**

**LINDEN:** "Four hundred and twelve this dusk. Sixty fewer than yesterday."
**LINDEN:** "They go up. They don't come back. They are *blind,* and they go *up.*"
**LINDEN:** "I would like to know toward what."
> ► **"Can we follow?"** — **LINDEN:** "Not me. I have a knee."
> ► **"What do you think?"** — **LINDEN:** "I think they know something we've forgotten."
> ► **"Where's your apprentice?"** — **LINDEN:** "Right behind you."

**Scene 2: the climb.** Mip scrambles ahead with a lantern on a stick, and the player follows up the silk ladders into the roof of the world. The bats stream past like smoke.

**MIP:** "What's up *there?*"
**MIP:** "Mr Amber says there's a thing called a *sky.* He says it's like a lantern but you can't blow it out."
> ► **"It is."** — **MIP:** "Is it *bright?*"
> ► **"You'll see."** — **MIP:** "Is it *scary?*"
> ► **"Tell me what you see."** — **MIP:** "...A line. A *line* of white."

**Scene 3: the crack.** At the roof of the cavern, a long thin fissure, and through it, a slanting bar of white. Dust turns in it like snow. Bats rise through it, vanishing.

**MIP:** (whisper) "It's *warm.*"
**MIP:** "It's warm on my face. It's like someone put their *hand* there."

> ► **"Let her stand in it."** — Mip stands very still for the twenty minutes of noon.
> ► **"Mark the crack on a map."** — A careful survey, for the guilds.
> ► **"Seal it, for safety."** — A hard decision; the bats will not forgive it.

**Scene 4: the descent.** Back at the gallery, Linden listens, saying nothing, as Mip describes the sun in her own words.

**LINDEN:** "It was never mine to see."
**MIP:** "It's *everyone's.* I'll show you."

**Outcomes and receipt.**
- The line of daylight is found. If it is mapped, the guilds argue over what to do with it. If it is left alone, it becomes a gallery for the city's children, one noon at a time. If sealed, the bats leave anyway.
- **Receipt:** a silk-ladder to the roof crack, hung with small lanterns; a painted bat on the Roost Gallery wall with a gold stripe across its back.

<!-- quest
id: qst_umb_line_of_daylight
title: A Line of Daylight
rank: C
type: Exploration
giver: npc_linden_amber
region: reg_umbravel
level: 70
act: 3
requires_rank: C
reward: 4300 | 240 | 16000
sets: umb_daylight_found
summary: The city's blind bats are leaving upward, toward a crack in the cavern roof where a bar of sunlight falls at noon.
objectives:
  talk npc_linden_amber
  reach cavern_roof_daylight_crack
  choice stand_map_or_seal
-->

---

## 6. Restored, Quietly

*B · Faction · the Silk Contract Hall · giver Guildmistress Ysaline Orrin*

**The short version.** The oldest weaver-guild wants the original silk contract restored, without a public vote, without a confession and without the lower-web families being told why. Ysaline needs a neutral witness to sign it into the Contract Hall.

**What is really going on.** The contract, when read, binds the guilds to give the spiders "one lantern in ten, lit and kept for them in the deep." The guilds broke it a generation ago. Restoring it quietly would please the Queen and spare the guilds' reputation, but the families who lost homes to cocooning would never be told their city's law had changed.

**Scene 1: the hall.**

**YSALINE:** "I signed the contract that broke it. I was thirty. I thought it was an *adjustment.*"
**YSALINE:** "I would like it mended. Tonight. Before the Queen comes up for her answer."
**YSALINE:** "I would like it done *quietly.*"
> ► **"Why quietly?"** — **YSALINE:** "Because the city is frightened. And I am too."
> ► **"What does it say?"** — **YSALINE:** "'One lantern in ten, lit for the spiders.' It is the simplest law we ever had."
> ► **"Who else knows?"** — **YSALINE:** "Four guildmasters. And now you."

**Scene 2: the lower webs.** In a cramped, lamplit terrace, a woman with a baby listens to the player explain.

**TERRACE-MOTHER (Nell Ormand):** "You'll mend it, and nobody will say *sorry?*"
**TERRACE-MOTHER:** "We were cocooned for nine days. Nobody said *sorry.*"
**TERRACE-MOTHER:** "You can mend it quietly. But then I'll never know it was *mended.*"

**Scene 3: the signing.** In the Contract Hall, under a hundred hanging lanterns, the old contract waits, strand by strand, on its frame.

> ► **"Restore it quietly."** — The guilds are relieved. The lower webs are not told.
> ► **"Restore it, and announce it."** — Ysaline's face does not move; the Hall fills with listeners.
> ► **"Restore it, and ask the families to witness."** — A slow, humble ceremony, with the lower-web families seated first.

**YSALINE:** "I was afraid that if I said it aloud, it would be a *confession.*"
**YSALINE:** "It is. I think that's why it works."

**Scene 4: the knot.** As the last strand is tied, the lanterns in the Hall dim, all at once, and in the dark, a single new knot appears at the end of the contract. Nobody saw it tied. It is not in a guild's hand.

**YSALINE:** (very low) "That wasn't there."

**Outcomes and receipt.**
- The contract is restored. How: in silence, in public or in front of the lower-web families, decides who forgives whom. The knot is left unread; quest 10 may read it.
- **Receipt:** the restored contract on its frame in the Hall, with a new knot at the end; a bench for the lower-web families at the front of the Hall.

<!-- quest
id: qst_umb_restored_quietly
title: Restored, Quietly
rank: B
type: Faction
giver: npc_ysaline_orrin
region: reg_umbravel
level: 88
act: 4
requires_rank: B
requires_quests: qst_umb_who_cut_bridge
reward: 10000 | 600 | 44000
sets: umb_contract_restored
summary: A guildmistress wants the broken silk contract restored without public vote, and the families who lost homes would never be told.
objectives:
  talk npc_ysaline_orrin
  reach silk_contract_hall_frame
  choice quiet_public_or_witnessed
-->

---

## 7. The Vigil at Lift Nine

*B · Defense · Lift Nine · giver Lift-Warden Orsa Venn*

**The short version.** The brood has begun climbing the lift cables from below. Lift Nine carries the lower-web families up to the safer districts, and Orsa will not close it while people are still waiting. She needs help to keep it open through one night.

**What is really going on.** The brood is not attacking the lift. They are climbing the cables because the cables are *strands,* and strands are theirs. If the lift is allowed to run, the spiders ride it up and into the city; if it is cut, hundreds of families are trapped below. The best defence is to hold the lift's cage, hold the cables and keep the line moving, until the last family is up.

**Scene 1: the lift-house.**

**ORSA:** "I've run Lift Nine twenty years. I do not stop for weather. I do not stop for *spiders.*"
**ORSA:** "They're on the lower cable. They're not *biting.* They're *testing.*"
**ORSA:** "Four hundred up. Three hundred still waiting. I've got till dawn-lamp."
> ► **"What do you need?"** — **ORSA:** "Two hands on the brake, one on the cage, and somebody *calm.*"
> ► **"What are they doing?"** — **ORSA:** "Climbing. Slowly. Like they're *reading.*"
> ► **"I'll hold the cage."** — **ORSA:** "Good. It sticks."

**Scene 2: the night.** The lift groans up, carries eight at a time, and swings out over the dark. Below, a grey ripple of legs rises up the cable.

**ORSA:** "Hold! They're on the pulley!"
**LIFT CHILD (to her mother):** "They're *looking* at us."
> ► **"Hold the pulley."** — A hard, close struggle at the winch.
> ► **"Light the cable."** — A hundred lanterns hung along the strands; the spiders slow, dazzled.
> ► **"Cut the lower cable."** — A grim, risky choice that strands the last fifty families.

**Scene 3: the last cage.** The queue is a hundred long, and the grey ripple is at the winch-house door.

> ► **"Send a decoy up first."** — A bundle of silk and lantern-light draws the spiders aside.
> ► **"Carry the slow ones yourself."** — A frantic, heroic last run on foot.
> ► **"Let the brood ride."** — A sullen, tense passage, with spiders in the back of the cage.

**ORSA:** "Last cage! *Go!*"

**Scene 4: the dawn-lamp.** The last family steps out. Orsa, grey with dust, sets the brake and sits on the winch.

**ORSA:** "Four hundred and fifty-three up. Not one lost."
**ORSA:** "I'll do it again tomorrow."

**Outcomes and receipt.**
- The lift holds. Which method the player chose decides what Lift Nine becomes: a fortress, a lantern-road or a shared passage. The brood withdraws at dawn-lamp, as if called.
- **Receipt:** a lantern strung on every cable of Lift Nine; Orsa's tally of names chalked on the winch-house wall.

<!-- quest
id: qst_umb_vigil_lift_nine
title: The Vigil at Lift Nine
rank: B
type: Defense
giver: npc_orsa_venn
region: reg_umbravel
level: 92
act: 4
requires_rank: B
reward: 11000 | 650 | 47000
sets: umb_lift_nine_held
summary: The brood climbs the cables of the lift that carries lower-web families to safety, and the lift-warden will not close it.
objectives:
  talk npc_orsa_venn
  defend lift_nine_winch_house
  choice pulley_lanterns_or_ride
-->

---

## 8. The Knot She Always Tied

*B · Hidden · the Underweb Stair · giver Old Tamsin Brightwire*

**The short version.** Old Tamsin has walked the Underweb Stair every night for fifty years with a bundle of silk, alone, in the dark, and the city calls her mad. Tonight her knees have given out, and she asks the player to carry the bundle and not to ask questions until they are past the second landing.

**What is really going on.** She leaves a silk offering at the deepest edge of the webs, and she ties the same knot every time. The spiders know it. The brood does not touch her. She learned the knot from her mother, who learned it from someone who learned it from the first weavers, before the contract was written down. It is not in any guild book. It says, in silk, *"I owe you."*

**Scene 1: the stair.**

**TAMSIN:** "I'm not mad. I'm *old.* There's a difference. It's mostly in the eyes."
**TAMSIN:** "Take the bundle. Don't undo it. Don't run."
**TAMSIN:** "If you hear anything, it is probably me."
> ► **"Where are we going?"** — **TAMSIN:** "Down."
> ► **"Why do you do this?"** — **TAMSIN:** "Because nobody else does."
> ► **"I'll carry it."** — **TAMSIN:** "Thank you, love."

**Scene 2: the dark.** Down, past the last lantern, along a cold silk walkway with a sheer drop on both sides. Small taps, far below, answer the old woman's cane.

**TAMSIN:** "That's the sentries. They know my step. They'll let us by."
**TAMSIN:** "Hold the bundle at your chest. Not too tight. They're curious."
*A white shape, bigger than a cart, uncurls in the dark and watches them go.*

**Scene 3: the edge.** At the end of the stair, the web simply stops. Beyond, the dark. Tamsin kneels, her hands shaking, and ties a knot.

**TAMSIN:** "It's three turns and a pull. My mother taught me. She said it means *I am here.*"
**TAMSIN:** "I think it means more than that. But I've never been brave enough to ask."

> ► **"Help her tie it."** — Her hands guide yours; the knot is easy and strange.
> ► **"Ask what it means."** — **TAMSIN:** "Nobody's told me. I'm afraid of the answer."
> ► **"Add a second knot."** — A small, brave, wrong gesture.

*From below, a long moment later, a single thread rises, and ties itself to the offering.*

**Scene 4: the return.** The walk back is slow. Tamsin leans on the player's arm.

**TAMSIN:** "Fifty years. I thought I was talking to myself."
**TAMSIN:** "I think I might have been *answered.*"

**Outcomes and receipt.**
- The offering is laid and, for the first time Tamsin can remember, taken. If the player added a second knot, the web below tightens and the thread that rises is a different colour. What the knot says is left to the weavers.
- **Receipt:** Tamsin's knot, copied onto a banner at the head of the Underweb Stair; a single answering thread tied to the rail, glowing faintly in the dark.

<!-- quest
id: qst_umb_knot_she_tied
title: The Knot She Always Tied
rank: B
type: Hidden
giver: npc_old_tamsin_brightwire
region: reg_umbravel
level: 96
act: 4
requires_rank: B
reward: 12000 | 700 | 50000
sets: umb_tamsin_knot_tied
summary: An old blind weaver has left a silk offering at the edge of the deep webs every night for fifty years, and tonight someone answers.
objectives:
  talk npc_old_tamsin_brightwire
  reach underweb_stair_deep_edge
  choice tie_ask_or_second_knot
-->

---

## 9. Chain or Silk

*B · OddJob · Lift Three · giver Engineer Pellory Gimblewick*

**The short version.** The guilds have funded Pellory to replace Lift Three's silk cables with iron chain, so the lift no longer depends on the spiders. The spider that runs the lift, an old female named Threadbare, has not been told. Pellory would like the player there when she is.

**What is really going on.** Threadbare has worked Lift Three for thirty years, spinning and mending its cables, and has views. She does not want to be replaced. But her silk is fraying, and an iron chain would be stronger. The only fair way through is for Threadbare to be asked, not told, and for the chain and the silk to be given a chance to agree.

**Scene 1: the lift-house.**

**PELLORY:** "It's a *marvel.* A chain that never frays. I've the plans, the funding, a team of nineteen."
**PELLORY:** "I have not told Threadbare."
**PELLORY:** "She is *quite* big."
> ► **"Who is Threadbare?"** — **PELLORY:** "The lift. In a manner of speaking."
> ► **"Why not tell her?"** — **PELLORY:** "She'll look at me."
> ► **"I'll come with you."** — **PELLORY:** "Thank you. Please stand in front."

**Scene 2: the rafters.** In the dark above the lift shaft, a spider the size of a hay-cart looks down. Its legs are grey with age and silk-dust.

**PELLORY:** "Threadbare! I have news! Good news! Possibly!"
**THREADBARE:** (a long, slow, dry rattle)
**PELLORY:** "She's saying 'no.' I think."

**Scene 3: the argument.** An hour of comic shouting, tapping and gesture. Pellory shows her the plans. She eats one corner. He shows her the chain. She wraps it in silk, delicately, and drops it down the shaft.

> ► **"Let her spin around the chain."** — A hybrid cable: iron core, silk wrap.
> ► **"Replace her by degrees."** — A slow handover, one cable at a time.
> ► **"Tell the guilds the plan is off."** — Pellory looks at his plans, and at the spider, and sighs.

**PELLORY:** "I've built a better chain. She's built a *better lift.*"
**THREADBARE:** (a satisfied click)

**Scene 4: the first ride.** At the lantern hour, a full cage of passengers rises. The cable that carries them is bright steel wrapped in pale silk, and Threadbare rides the cage, dangling from the roof, supervising.

**PELLORY:** "She's *inspecting* it."
**THREADBARE:** (a click that might mean *adequate*)

**Outcomes and receipt.**
- The new cable is built, or the old one kept. Whichever is chosen, Threadbare keeps her post; the guilds are told "a joint solution." The city has, without knowing it, begun to let its spiders help design the lifts.
- **Receipt:** a plaque on Lift Three reading *"Built by P. Gimblewick and Threadbare, jointly";* a small silk hammock in the lift-house roof.

<!-- quest
id: qst_umb_chain_or_silk
title: Chain or Silk
rank: B
type: OddJob
giver: npc_pellory_gimblewick
region: reg_umbravel
level: 99
act: 4
requires_rank: B
reward: 12500 | 730 | 52000
sets: umb_lift_three_hybrid
summary: A gnome engineer wants to replace a lift's silk cables with chain, and the spider that runs it has not been told.
objectives:
  talk npc_pellory_gimblewick
  reach lift_three_rafters
  choice hybrid_gradual_or_cancel
-->

---

## 10. A Letter in the Web

*B · Investigation · the Silk Contract Hall · giver Strand-Reader Lissandre Veyl*

**The short version.** The deep webs have sent a message: a single long strand of silk, knotted in a hundred places, left at the Contract Hall door. Nobody dares read it. Lissandre can hear what a strand says, but this one says too much for one pair of ears.

**What is really going on.** It is the Queen's opening terms. It is not a threat. It is a *list*: what the city has taken, what it has spun for itself and what it has failed to leave in the deep. It ends on the new knot from the restored contract (if quest 6 was done) or a bare, expectant loop. The terms are not answered by the player; they are *read,* and the city must decide how to respond.

**Scene 1: the hall door.**

**LISSANDRE:** "I have been a strand-reader for forty years. I know when a strand is angry, when it is afraid and when it is lying."
**LISSANDRE:** "This one is *none* of those."
**LISSANDRE:** "It is... patient."
> ► **"Can you read it?"** — **LISSANDRE:** "Not alone."
> ► **"What does it say?"** — **LISSANDRE:** "That is the problem."
> ► **"Where did it come from?"** — **LISSANDRE:** "The deep. It was *tied to the door.*"

**Scene 2: the reading.** In a silent chamber, with six tuners and a bell-glass, the player helps Lissandre pluck the strand, knot by knot. Each note is a word.

**Evidence.**
- **The first fifty knots** are a count: lanterns lit, lanterns owed, in the old tally-system.
- **The next thirty** are names: families the brood has taken into its cocoons, with *how long* each has been kept.
- **The last twenty** are a question, repeated in four different ways.

**LISSANDRE:** (very quietly) "It is asking *what we intend.*"
**TUNER:** "It's a negotiation."
**LISSANDRE:** "It is the *opening* of one."

**Scene 3: the reply.** The council gathers, divided between those who want to answer and those who want to burn the strand.

> ► **"Answer in silk."** — A single, careful knot is tied to the end of the strand and sent down.
> ► **"Answer in the Hall."** — The council reads the terms aloud; the city hears them for the first time.
> ► **"Hold the strand until the guilds agree."** — A careful, responsible, slow delay.

**LISSANDRE:** "I will not translate what I am not sure of. But I am sure *enough.*"

**Scene 4: the silence.** When the knot is tied, the Hall's lanterns flicker once and are still. In the deep, something very large shifts its weight, and the whole web trembles gently, once.

**Outcomes and receipt.**
- The Queen's terms are read and answered, or held. Nothing is settled. The Queen has said what she will say before the fight, and the city, for the first time, has listened.
- **Receipt:** the strand hung in the Contract Hall, labelled in Lissandre's hand; a new chair at the council table, left empty.

<!-- quest
id: qst_umb_letter_in_web
title: A Letter in the Web
rank: B
type: Investigation
giver: npc_lissandre_veyl
region: reg_umbravel
level: 108
act: 4
requires_rank: B
requires_quests: qst_umb_restored_quietly
reward: 14000 | 800 | 60000
sets: umb_queens_terms_read
summary: The deep webs have sent a knotted strand to the Contract Hall, and reading it shows the Queen's opening terms.
objectives:
  talk npc_lissandre_veyl
  reach silk_contract_hall_reading_chamber
  choice answer_silk_hall_or_hold
-->
