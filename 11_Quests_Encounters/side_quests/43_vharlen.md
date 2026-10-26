# 11e-43 — Vharlen, the Shield of the Empire: Ten Side Quests (draft)

> *"Every child knows the horns. Every parent knows what they cost."*
> — Vharlen saying

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. Part of the second regional set ([[second_set_index]]). Hidden `<!-- quest -->` and `<!-- npc -->` blocks feed `Tools/quests/build_side_quests.js`.

**Region:** `reg_vharlen` (the Imperial Capital, the frontier forts, garrison towns, the barracks pledge). **Rank band:** B–A. **Tone:** disciplined, proud, dry and dark-humoured; duty with a human face.

**Placement notes.**
- **Morvane, Vanguard of the Overlord,** is the Tyrant; he respects Vharlen as a worthy enemy. No quest here defeats Morvane, ends the frontier war or reveals the full pledge text. The pledge is only ever glimpsed.
- Customs used: every citizen serves in the legions; rank shapes social standing; each legion carries a shrine; succession is by appointment; the spy service is feared; recruits swear the barracks pledge.
- Two forts have fallen and the capital is full of rumours; quests are small human stories inside that pressure.

| # | Quest | Rank | Type | Giver | Mood |
|---|---|---|---|---|---|
| 1 | The Recruit Who Could Not Swear | B | OddJob | Drillmaster Hana Corvus | A boy and an oath |
| 2 | Horn Practice | B | OddJob | Warden Pell Orrin | Children and the alarm horns |
| 3 | A Grain Wagon for Fort Seven | B | Escort | Quartermaster Ilsa Brandt | Plain logistics, tense roads |
| 4 | The Spy Who Paid His Bill | B | Investigation | Innkeeper Gerd Aldous | Quiet intrigue |
| 5 | Letters From the Fallen Fort | B | Delivery | Clerk Tobin Wray | Grief by post |
| 6 | The Senate Dinner | A | Faction | Senator Valeria Dunmore | Politics over soup |
| 7 | Rank and File | A | Faction | Sergeant Joss Harrow | A promotion that should not happen |
| 8 | The General Who Wanted to Retire | A | OddJob | General Auric Stolt | A tired heir-candidate |
| 9 | What the Pledge Cost | A | Investigation | Chaplain Merel Voss-Aden | A rubbing and a silence |
| 10 | The Night the Horns Failed | A | Defense | Watch-Captain Rhea Kordan | A false alarm, a real one |

## Cast

<!-- npc
id: npc_hana_corvus
name: Drillmaster Hana Corvus
tier: major
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: Drillmaster of the capital recruits
backstory: A scarred drillmaster who has trained nine thousand recruits and still remembers each name, and who has one recruit this season she cannot make swear.
-->
<!-- npc
id: npc_pell_orrin
name: Warden Pell Orrin
tier: townsfolk
race: Human
region: reg_vharlen
settlement: Garrison towns
role: Horn-warden of a garrison town
backstory: A patient warden who teaches town children the alarm calls and quietly dreads the day a drill becomes real.
-->
<!-- npc
id: npc_ilsa_brandt
name: Quartermaster Ilsa Brandt
tier: townsfolk
race: Human
region: reg_vharlen
settlement: The frontier forts
role: Quartermaster of Fort Seven
backstory: A sharp quartermaster who counts every grain and every sandal, and whose count for Fort Seven is two days short.
-->
<!-- npc
id: npc_gerd_aldous
name: Innkeeper Gerd Aldous
tier: townsfolk
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: Innkeeper in the diplomats' quarter
backstory: A round, observant innkeeper who has hosted informants of every nation and has noticed a guest who pays too promptly.
-->
<!-- npc
id: npc_tobin_wray
name: Clerk Tobin Wray
tier: townsfolk
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: Clerk of the dead-letter office
backstory: A young clerk who holds the last letters of soldiers from the two fallen forts and cannot decide how to deliver them.
-->
<!-- npc
id: npc_valeria_dunmore
name: Senator Valeria Dunmore
tier: major
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: Senator of the generals' bench
backstory: A calm senator who hosts the dinner at which the empire's next heir will be quietly sounded out.
-->
<!-- npc
id: npc_joss_harrow
name: Sergeant Joss Harrow
tier: townsfolk
race: Human
region: reg_vharlen
settlement: Garrison towns
role: Sergeant offered a promotion
backstory: A blunt veteran offered an officer's commission he is sure he does not deserve, because the man who earned it died in his place.
-->
<!-- npc
id: npc_auric_stolt
name: General Auric Stolt
tier: major
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: General named as a possible heir
backstory: A tired, kind general in his sixties who would rather tend bees than be named emperor and cannot say so aloud.
-->
<!-- npc
id: npc_merel_voss_aden
name: Chaplain Merel Aden
tier: major
race: Human
region: reg_vharlen
settlement: The Imperial Capital
role: Chaplain of the barracks shrine
backstory: A gentle chaplain who tends the shrine above the carved pledge and has never read the whole text.
-->
<!-- npc
id: npc_rhea_kordan
name: Watch-Captain Rhea Kordan
tier: major
race: Human
region: reg_vharlen
settlement: The frontier forts
role: Watch-captain of a pass fort
backstory: A steady watch-captain whose horns have sounded twice this month for nothing and who knows the third time will be believed by no one.
-->

---

## 1. The Recruit Who Could Not Swear

*B · OddJob · the capital barracks · giver Drillmaster Hana Corvus*

**Short version.** A recruit, Teo, has passed every drill but will not speak the barracks pledge. Hana asks the player to find out why before he is dismissed.

**Really going on.** His brother fell at one of the forts last month. He is not afraid of the war; he is afraid the pledge is a promise to die, and he would rather be honest than lie.

**Scenes.**
**HANA:** "Nine thousand recruits. Nobody has ever stood at that stone and said nothing."
> ► **"Can I talk to him?"** — **HANA:** "Off duty. Not in uniform."
> ► **"What if he never swears?"** — **HANA:** "Then he goes home alive. That is not the worst outcome."

*Teo on the barracks roof at dusk, throwing pebbles.* The player may argue, listen, or read him the pledge's public lines.

**Outcomes.** He swears a modified line, or goes home with his brother's boots; either is honoured. **Receipt:** a pebble the player keeps from the roof.

<!-- quest
id: qst_vhl_recruit_swear
title: The Recruit Who Could Not Swear
rank: B
type: OddJob
giver: npc_hana_corvus
region: reg_vharlen
level: 100
act: 4
requires_rank: B
reward: 12000 | 700 | 54000
sets: vhl_recruit_done
summary: A recruit who passed every drill will not speak the barracks pledge.
objectives:
  talk npc_hana_corvus
  reach vharlen_barracks_roof
  choice argue_listen_or_read
-->

---

## 2. Horn Practice

*B · OddJob · a garrison town · giver Warden Pell Orrin*

**Short version.** Pell teaches the town children the alarm calls: one blast for scouts, two for a raid, three for the wall. This year he asks the player to play the "raid" so the drill feels real without being frightening.

**Really going on.** A small girl freezes in the street at the second blast and cannot move. The drill's job is to teach calm, not courage.

**Scenes.** A field of children, a rope line, a horn that is far too loud.
> ► **(Play the raid gently.)** — Children run to the cellars laughing.
> ► **(Play it hard.)** — The girl freezes.
> ► **(Let a child blow the horn.)** — A ripple of delight.

**Outcomes.** A calmer drill, or a hard lesson. **Receipt:** a child's drawing of the horn pinned in the watch-house.

<!-- quest
id: qst_vhl_horn_practice
title: Horn Practice
rank: B
type: OddJob
giver: npc_pell_orrin
region: reg_vharlen
level: 98
act: 4
requires_rank: B
reward: 11500 | 680 | 52000
sets: vhl_horn_done
summary: A horn-warden teaches the town's children the alarm calls without frightening them.
objectives:
  talk npc_pell_orrin
  reach vharlen_garrison_field
  choice gentle_hard_or_child
-->

---

## 3. A Grain Wagon for Fort Seven

*B · Escort · the frontier road · giver Quartermaster Ilsa Brandt*

**Short version.** Fort Seven is two days short of grain. Ilsa needs one wagon through the pass before the next demon patrol.

**Really going on.** Plain logistics under fear. The driver is a retired legionary who counts the miles aloud; the real danger is the wheel that is already cracked.

**Scenes.** A long road; a cracked axle; a patrol's torches on a ridge.
> ► **"Push through at night."** — Fast and risky.
> ► **"Repair first."** — Slower and safer.
> ► **"Split the load."** — Half arrives sooner.

**Outcomes.** The grain arrives, whole or half. **Receipt:** a stamped receipt from Fort Seven, signed in a shaky hand.

<!-- quest
id: qst_vhl_grain_wagon
title: A Grain Wagon for Fort Seven
rank: B
type: Escort
giver: npc_ilsa_brandt
region: reg_vharlen
level: 102
act: 4
requires_rank: B
reward: 12500 | 720 | 56000
sets: vhl_grain_done
summary: Fort Seven is two days short of grain and needs one wagon through the pass.
objectives:
  talk npc_ilsa_brandt
  escort npc_ilsa_brandt
  reach vharlen_fort_seven
-->

---

## 4. The Spy Who Paid His Bill

*B · Investigation · the diplomats' quarter · giver Innkeeper Gerd Aldous*

**Short version.** A guest at Gerd's inn pays in advance, leaves on time and never complains. Gerd, who has hosted informants from every nation, is certain he is working for someone, and cannot tell whom.

**Really going on.** The guest is a spy, but not for the demons: he is the empire's own, auditing the inn because a rival innkeeper accused Gerd of selling secrets. The player discovers this and chooses what to tell Gerd.

**Scenes.** A dull hour of watching the guest's door; a conversation over cards.
> ► **"Tell Gerd the truth."** — He is hurt, then relieved.
> ► **"Say he's harmless."** — A white lie.
> ► **"Let the audit finish."** — Quiet.

**Outcomes.** Gerd is cleared, or learns it later. **Receipt:** a very large tip left by the spy, with a note: "Good beds."

<!-- quest
id: qst_vhl_spy_bill
title: The Spy Who Paid His Bill
rank: B
type: Investigation
giver: npc_gerd_aldous
region: reg_vharlen
level: 100
act: 4
requires_rank: B
reward: 12000 | 700 | 54000
sets: vhl_spy_done
summary: A too-punctual guest at a diplomats' inn is certainly a spy, but whose?
objectives:
  talk npc_gerd_aldous
  reach vharlen_diplomats_inn
  choice truth_lie_or_wait
-->

---

## 5. Letters From the Fallen Fort

*B · Delivery · the dead-letter office · giver Clerk Tobin Wray*

**Short version.** Tobin holds the last letters of soldiers from the two fallen forts. He cannot bear to deliver them by post and asks the player to carry them by hand.

**Really going on.** Each letter is a small scene: a mother, a sweetheart, a child. Some families already know; some do not. The player is asked to read each family's face and decide how to hand it over.

**Scenes.** Three doorsteps, three very different welcomes.
> ► **(Say the truth first.)** — Gentle, direct.
> ► **(Hand the letter, say nothing.)** — A silence.
> ► **(Sit and stay.)** — A cup of tea.

**Outcomes.** Each family responds differently. **Receipt:** a bundle of empty envelopes tied with ribbon.

<!-- quest
id: qst_vhl_fallen_letters
title: Letters From the Fallen Fort
rank: B
type: Delivery
giver: npc_tobin_wray
region: reg_vharlen
level: 104
act: 4
requires_rank: B
reward: 13000 | 750 | 58000
sets: vhl_letters_done
summary: The last letters of soldiers from two fallen forts must be carried to their families by hand.
objectives:
  talk npc_tobin_wray
  reach vharlen_family_doorsteps
  choice truth_silence_or_stay
-->

---

## 6. The Senate Dinner

*A · Faction · a palace dining hall · giver Senator Valeria Dunmore*

**Short version.** Valeria hosts a dinner at which the senate will quietly sound out the empire's next heir. She asks the player to be a guest who listens.

**Really going on.** Nothing is decided at dinner; everything is revealed. The heir-candidates behave exactly as they are. The player is asked to report who spoke kindly to the servants.

**Scenes.** Seven courses, five generals, one nervous waiter.
> ► **(Listen to the toasts.)** — Pride.
> ► **(Chat with the kitchen.)** — Truth.
> ► **(Say nothing.)** — A quiet report.

**Outcomes.** Valeria receives an honest account. **Receipt:** a place-card in a general's handwriting.

<!-- quest
id: qst_vhl_senate_dinner
title: The Senate Dinner
rank: A
type: Faction
giver: npc_valeria_dunmore
region: reg_vharlen
level: 128
act: 4
requires_rank: A
reward: 30000 | 1500 | 132000
sets: vhl_dinner_done
summary: A senator hosts a dinner at which the empire's next heir is quietly sounded out.
objectives:
  talk npc_valeria_dunmore
  reach vharlen_palace_hall
  choice toasts_kitchen_or_silence
-->

---

## 7. Rank and File

*A · Faction · a garrison town · giver Sergeant Joss Harrow*

**Short version.** Joss is offered an officer's commission he believes belongs to the man who died in his place. He asks the player to find the dead man's family.

**Really going on.** The dead man left a letter naming Joss as the better officer. The family never sent it because they thought it would hurt. The player decides how it is delivered.

**Scenes.** A funeral cairn; a mother with a shoebox.
> ► **"Give him the letter."** — Joss reads it twice.
> ► **"Keep it from him."** — He declines the commission.
> ► **"Let the mother choose."** — She does.

**Outcomes.** Joss accepts or refuses with a clear conscience. **Receipt:** the letter, copied.

<!-- quest
id: qst_vhl_rank_file
title: Rank and File
rank: A
type: Faction
giver: npc_joss_harrow
region: reg_vharlen
level: 130
act: 4
requires_rank: A
reward: 31000 | 1550 | 135000
sets: vhl_rank_done
summary: A sergeant is offered the commission of the man who died in his place.
objectives:
  talk npc_joss_harrow
  reach vharlen_funeral_cairn
  choice give_keep_or_mother
-->

---

## 8. The General Who Wanted to Retire

*A · OddJob · the general's garden · giver General Auric Stolt*

**Short version.** Auric is named as a possible heir. He would rather keep bees. He asks the player to help him fail a test without shaming anyone.

**Really going on.** Refusing an appointment is treason by custom. The honest way out is to prove another general is better suited. He asks the player to help that general shine.

**Scenes.** A beehive; a gloved hand; a careful plan.
> ► **(Help the rival.)** — A quiet campaign.
> ► **(Talk him into it.)** — **AURIC:** "No."
> ► **(Take the bees.)** — He laughs for the first time in a year.

**Outcomes.** Auric steps aside, or does not. **Receipt:** a jar of honey stamped with a hive.

<!-- quest
id: qst_vhl_general_retire
title: The General Who Wanted to Retire
rank: A
type: OddJob
giver: npc_auric_stolt
region: reg_vharlen
level: 132
act: 4
requires_rank: A
reward: 32000 | 1600 | 140000
sets: vhl_general_done
summary: A general named as a possible heir would rather keep bees and needs a way out that shames no one.
objectives:
  talk npc_auric_stolt
  reach vharlen_general_garden
  choice rival_persuade_or_bees
-->

---

## 9. What the Pledge Cost

*A · Investigation · the barracks vault · giver Chaplain Merel Aden*

**Short version.** Merel tends the shrine above the carved pledge and has never read the whole text. She asks the player to take a rubbing, read it and tell her only what she needs to hear.

**Really going on.** *Nothing is explained.* The rubbing shows the public oath and, beneath it, a line in a different hand that has been chiselled out. The chisel marks are old. Merel decides not to learn what it said.

**Scenes.** A cold vault, paper and charcoal, a lamp.
> ► **(Read it all to her.)** — She stops you.
> ► **(Read the public part.)** — She nods.
> ► **(Keep the rubbing.)** — She does not ask.

**Outcomes.** The chiselled line stays unknown. **Canon-safe:** a pure seed; the pledge's cost is not revealed. **Receipt:** a charcoal rubbing with a gap.

<!-- quest
id: qst_vhl_pledge_cost
title: What the Pledge Cost
rank: A
type: Investigation
giver: npc_merel_voss_aden
region: reg_vharlen
level: 134
act: 4
requires_rank: A
reward: 32500 | 1620 | 142000
sets: vhl_pledge_done
summary: A chaplain asks for a rubbing of the carved pledge and learns there is a chiselled-out line beneath it.
objectives:
  talk npc_merel_voss_aden
  reach vharlen_barracks_vault
  choice read_public_or_keep
-->

---

## 10. The Night the Horns Failed

*A · Defense · a pass fort · giver Watch-Captain Rhea Kordan*

**Short version.** The horns have sounded twice this month for nothing. Tonight a third alarm is real, and no one believes it. Rhea asks the player to hold the gate until the fort wakes.

**Really going on.** The false alarms were a rival's prank, not enemy craft. The cost of the prank is that the garrison hesitates. The defense is as much about trust as about steel.

**Scenes.** A dark pass; a few scouts; a gate that must hold a quarter hour.
> ► **(Light the beacon.)** — A second signal.
> ► **(Hold alone.)** — Hard.
> ► **(Wake the cooks.)** — Unexpected help.

**Outcomes.** The fort holds. Rhea finds the prankster and does not punish. **Receipt:** a horn with a new notch.

<!-- quest
id: qst_vhl_horns_failed
title: The Night the Horns Failed
rank: A
type: Defense
giver: npc_rhea_kordan
region: reg_vharlen
level: 136
act: 4
requires_rank: A
reward: 33000 | 1650 | 145000
sets: vhl_horns_done
summary: After two false alarms, a real one is not believed, and the pass fort needs a gate held.
objectives:
  talk npc_rhea_kordan
  defend vharlen_pass_fort
  choice beacon_alone_or_cooks
-->
