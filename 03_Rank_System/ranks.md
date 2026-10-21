# 03 — Adventurer Rank System (v0.2)

> *"Your rank is what the world believes you can survive. Prove it wrong, upward."*
> — Engraved over the doors of every Guild Hall

## 1. The Nine Ranks
| Rank | Title | Lv | Guild Card | Threat definition (also used for monsters) | Share of guild |
|---|---|---|---|---|---|
| **F** | Rookie | 1–15 | **Oak wood**, burned stamp | A villager with a pitchfork could manage | 35% |
| **E** | Novice | 16–35 | **Copper** | A trained town guard | 25% |
| **D** | Journeyman | 36–60 | **Iron** | A squad of soldiers | 18% |
| **C** | Veteran | 61–90 | **Silver** | Can destroy a village | 12% |
| **B** | Elite | 91–125 | **Gold** | A threat to a town | 6% |
| **A** | Champion | 126–165 | **Platinum** | A threat to a city | 3% |
| **S** | Hero | 166–210 | **Mithril**, glows faintly | A threat to a nation | <1% (~40 alive) |
| **SS** | Calamity | 211–260 | **Adamantite**, black with red veins | A threat to a continent | 7 alive (named NPCs) |
| **SSS** | Transcendent | 261–300 + T1–T10 | **Starcard**, orichalcum; shows constellations | A threat to the world | 0 alive (last one 300 yrs ago) |
| **EX** | monsters only | — | — | *Beyond measure.* Calamity Beasts, Elder Dragons, gods | — |

Monsters and quests also use sub-grades **−/normal/+** (e.g. *C+ Named Ogre*).

## 2. Promotion Requirements
| Promotion | Lv | GP | Quests at rank | Special | Trial |
|---|---|---|---|---|---|
| F → E | 12 | 100 | 10 | Learn 1 Life Skill | **The Goblin Chief of Hollowpine** |
| E → D | 32 | 400 | 15 | Clear 1 dungeon | **The Proving Cave** (solo, no companions) |
| D → C | 56 | 1,200 | 20 | Advanced Class | **The Long Road**: escort + duel Examiner **Garrick "Ironjaw"** |
| C → B | 86 | 3,500 | 25 | Slay or recruit 1 Named Monster | **Leader's Burden**: lead an NPC party through a B dungeon; graded on their survival |
| B → A | 120 | 9,000 | 30 | "Honored" with 1 nation | **The Siege of Marrowgate**: hold the town 3 nights vs a Stampede |
| A → S | 160 | 22,000 | 35 | Expert Class + 1 Legendary | **Dragonbane**: defeat a Wyrm (A+) with ≤2 companions |
| S → SS | 205 | 50,000 | 40 | Defeat a Demon General | **Grandmaster's Gauntlet**: 5 rounds vs SS NPCs |
| SS → SSS | 260 | 120,000 | 50 | Master Class + Labyrinth floor 90 | **Trial of Ascension**: face the Avatar of your patron god |

### GP rules
| Quest rank vs yours | GP |
|---|---|
| +1 above (allowed, warned) | 150% |
| Same | 100% |
| −1 | 50% |
| −2 | 10% |
| −3 or lower | 0% (gold still paid) |
| Emergency / World Event | ×2 |
| First discovery reported to guild | +5–50 flat |

### Trial grading
- The Examiner scores **Speed, Damage Taken, Style, Allies/Civilians Saved, Creativity** (unusual solutions count).
- Grade **C/B/A/S**. An S grade gives a unique title, gear, and an examiner quote that NPCs repeat in gossip.
- Fail → retry next in-game day. Mina the receptionist gives a pep talk (new lines each time).

## 3. Rank-Up Ceremony
1. The Guild Master calls your name; adventurers in the hall react based on your reputation.
2. Your old card goes into a **ley-fountain**, melts, and re-forms as the new metal (a short unique cutscene per rank).
3. System Voice: *"Adventurer Rank updated: [C]. World recognition has increased."*
4. Rank Gift chest + new title.
5. At **S and up**, the promotion is announced kingdom-wide, and bards write songs about you (a real in-game song list that grows).

## 4. Rank Perks & Unlocks
| Rank | Gameplay unlocks | World/NPC changes | Rank Gift |
|---|---|---|---|
| **F** | Guild board F–E, inn room, 1 companion | Kids follow you; guards ignore you | Rookie's Pouch, 3 potions, town map |
| **E** | Dungeons, taming, party of 3, Life Skill trainers | Shopkeepers remember your name | Copper Compass (points to an unfinished quest) |
| **D** | **Advanced Class**, mounts, 2nd region, party of 4 | Bandits think twice; townsfolk ask for help | Horse whistle + saddle |
| **C** | Sub-Class, Named hunts, guild house, auction selling | Nobles notice you; rivals appear | Silver Ring of the Veteran |
| **B** | **Expert Class**, own land, party of 5, nation quests | Bards mention you; rookies idolize you | Deed to a plot in Brindlewick |
| **A** | Clan, shops, Baron title, first flight skill trainers | Kings grant audiences; assassins begin | Relic Codex upgrade + a Relic hint |
| **S** | **Master Class**, territory, legendary forge | Statues, songs, kingdom fame | Mithril cloak with your crest |
| **SS** | **Legendary Classes**, army command, cross-region teleport | Monsters below B flee on sight | Adamantite key to the Guild Vault |
| **SSS** | Transcendence powers | The world treats you as myth | Starcard; audience with Ilvaris |

## 5. Transcendence (SSS) — T1 to T10
| T | Power |
|---|---|
| T1 | **Aura of Dominion**: monsters below S won't attack |
| T2 | **Weather Call**: set a region's weather |
| T3 | **Waystride**: teleport anywhere you've stood |
| T4 | **Domain**: personal battlefield that boosts you and mutes enemies |
| T5 | **Genesis**: create a custom dungeon in your territory |
| T6 | **Rewrite**: change one rule of a region ("no undead in Sunscar") |
| T7 | **Avatar Form**: giant divine form for 30 seconds |
| T8 | **Grant Status**: give an NPC a class change or Unique Skill |
| T9 | **Unweave**: erase a Calamity permanently |
| T10 | **The Thirteenth Star**: final ending condition |

## 6. Rank Concealment & "The Reveal" (minor feature; see Relics in systems_addendum_v03)
- **[Concealment]** skill, the *Mask of the Humble*, or a guild favor makes your card show a lower rank.
- NPCs react to your *displayed* rank: tavern bullies, snobbish nobles, merchants overcharging rookies.
- **Reveal Events (20+ scripted):** when your real rank is exposed, there's a cinematic beat. The bully drops his mug, the hall goes silent, Mina faints.
  - *The Tavern Brawl*: thugs mock your "F" card; one punch later the System announces your real rank to the room.
  - *The Noble's Duel*: a rich D-Rank brat challenges you over someone's honor.
  - *The Examiner's Shock*: you retake an old trial in disguise and S-grade it in 4 seconds.

## 7. Parallel Rank Tracks
| Track | Ladder | Path |
|---|---|---|
| Merchant Rank | Peddler → Trader → Merchant → Magnate → Merchant King | Consortium |
| Knight Rank | Squire → Knight → Knight-Captain → Paladin Lord | Kingdom |
| Academy Rank | Freshman → Adept → Magister → Archmagister | Mages' Academy arc |
| Syndicate Mark | Rat → Blade → Shade → Shadow Hand | Criminal path |
| Monster Rank | Evolution stages (see Monster Evolution) | Reborn Monster Origin |

## 8. v0.3 Additions
- **Level cap 300**; bands above. Pacing to SSS ≈ 1,000 hrs (see `12_Systems/systems_addendum_v03.md`).
- **Exceptional Promotion:** beat content 2+ ranks above you → Guild Master's *Trial of Merit* → skip one rank (max one per band; not into SS/SSS).
- **S-Rank difficulty floor:** S+ content is brutal on every difficulty setting.
