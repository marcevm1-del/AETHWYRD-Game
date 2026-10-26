# 11e — Side Quests: One Hundred Stories (draft)

> *"Nobody comes to the guild board for the stew. They come for what happens on the way home."*

**Status: draft proposal.** `Canon.md` wins; `Data/` is canonical for numbers. These **100 side quests** (ten regions, ten quests each) are the long-form companion to the 36 Brindlewick quests in [[brindlewick_side_quests]]. Every quest has a premise, the truth behind it, four scenes with dialogue and branching choices, outcomes and a visible receipt.

**How the files work.** Each region file holds the prose *and*, in hidden `<!-- quest -->` and `<!-- npc -->` comments, the data for that quest. `node Tools/quests/build_side_quests.js` reads those comments and merges them into `Data/Quests/quests.json`, `Data/Quests/story_flags.json` and `Data/NPCs/npcs.json`. It is idempotent, and it also runs as part of `npm run build`. Edit the prose and the block together; do not edit the generated rows by hand.

⚠️ **Spoilers:** several quests plant seeds for later reveals. They are all marked, and none answers a Canon question.

## 1. At a glance

| Region file | Region | Rank band | Tone |
|---|---|---|---|
| [01_whisperwood_millbrook](01_whisperwood_millbrook.md) | Whisperwood and Millbrook | F–E | Cozy, small, kind |
| [02_aldmere](02_aldmere.md) | Aldmere, the Crown Valley | E–C | Pastoral, political, haunted |
| [03_greymoor](03_greymoor.md) | Greymoor, the Silent Fen | D–C | Soft, damp, close-knit |
| [04_mossdeep](04_mossdeep.md) | Mossdeep, the Land of Small Things | D–C | Warm, formal, very brave |
| [05_sylvaran](05_sylvaran.md) | Sylvaran, the Canopy Kingdom | D–B | Slow, beautiful, afraid |
| [06_lirian](06_lirian.md) | Lirian, the Lantern Canals | D–B | Witty, theatrical, kind underneath |
| [07_fanghold](07_fanghold.md) | Fanghold, the Wind-Plains | D–B | Open, hospitable, windswept |
| [08_iron_hold](08_iron_hold.md) | Iron Hold, the Forge Under the Mountains | C–A | Dry, proud, loyal |
| [09_hoshizora](09_hoshizora.md) | Hoshizora, the Land Under the Star-Sky | C–A | Graceful, reserved, funny at the edges |
| [10_frostveil](10_frostveil.md) | Frostveil, the Long Winter | B–A | Stoic, warm, firelit |

**By rank:** F 2 · E 12 · D 24 · C 30 · B 22 · A 10 (total 100).  
**By type:** Faction 28 · Investigation 21 · OddJob 14 · Exploration 10 · Hidden 9 · Escort 7 · Defense 7 · Gathering 2 · Subjugation 1 · Capture 1.

## 2. All one hundred

| # | Quest | Rank | Type | Region | Giver |
|---|---|---|---|---|---|
| 1 | Bread on the Step | F | OddJob | Whisperwood and Millbrook | Nan Corrow |
| 2 | Glowcap Night | F | Gathering | Whisperwood and Millbrook | Fenna Tilly |
| 3 | The White Stag | E | Exploration | Whisperwood and Millbrook | Wren Ashbourne |
| 4 | The Mill That Ran Backwards | E | Investigation | Whisperwood and Millbrook | Hesper Dunn |
| 5 | Lost in the Hush | E | Escort | Whisperwood and Millbrook | Marit Holloway |
| 6 | The Last Contract of the Silver Ladle | E | Escort | Whisperwood and Millbrook | Tobias Pryce |
| 7 | Lanterns, Not Lamp Oil | E | Faction | Whisperwood and Millbrook | Pocket Kobold |
| 8 | The Wolf Who Counted Sheep | E | Subjugation | Whisperwood and Millbrook | Tilda Cobb |
| 9 | Stew Diplomacy | E | Faction | Whisperwood and Millbrook | Grandmother Brub |
| 10 | Eight Lamps and an Empty Niche | E | Exploration | Whisperwood and Millbrook | Eolande Fairweather |
| 11 | A Sword Under Every Doorstep | E | Investigation | Aldmere | Calla Reeve |
| 12 | The Ring in the Barrow | E | Exploration | Aldmere | Ysolt Marne |
| 13 | The River Toll Quarrel | E | Faction | Aldmere | Hatty Swan |
| 14 | The Wheel Thief of Eastgate | E | Investigation | Aldmere | Maud Axle |
| 15 | The Plough Finds a Ledger | D | Investigation | Aldmere | Rook Tull |
| 16 | The Friend in the Mirror | D | Investigation | Aldmere | Edda Pryor |
| 17 | Stand Down, Soldier | D | Faction | Aldmere | Agna Dunmoor |
| 18 | The Duelist's Last Request | C | Hidden | Aldmere | Bertram Colt |
| 19 | The King Wants to Go Fishing | C | Escort | Aldmere | Osric Finch |
| 20 | What the Baron Refused | C | Investigation | Aldmere | Archivist Orrow |
| 21 | The Walking Hut Loses Its Way | D | Investigation | Greymoor | Tolliver Pegg |
| 22 | The Eel Moot | D | Faction | Greymoor | Marrel Sedge |
| 23 | Lanterns in Jars | D | OddJob | Greymoor | Idony Fenwater |
| 24 | The Clapper in the Peat | D | Exploration | Greymoor | Sorrel Boy |
| 25 | The Witch's Price | D | Faction | Greymoor | Granny Hexel |
| 26 | High Water on the Stilts | D | Defense | Greymoor | Alder Rushmoor |
| 27 | Tea with the Hag of Lowmere | C | Faction | Greymoor | Ysmay Hag |
| 28 | The Ferryman's Holiday | C | Hidden | Greymoor | Ferryman Odran |
| 29 | The Choir Passes | C | Investigation | Greymoor | Hester Mallow |
| 30 | The Book of Small Things | C | Faction | Greymoor | Mother Yarrow |
| 31 | A Thimble of Milk | D | OddJob | Mossdeep | Dilly Tuffet |
| 32 | The Beetle Rider's Test | D | OddJob | Mossdeep | Reedle Brisk |
| 33 | The Seed Recount | D | Faction | Mossdeep | Maplin Thorne |
| 34 | The Blue in the Tapestry | D | Exploration | Mossdeep | Odalie Fern |
| 35 | A Cat Called Disaster | D | OddJob | Mossdeep | Fiddlewick Brambly |
| 36 | The Aphid Run | D | Defense | Mossdeep | Pomfrey Dew |
| 37 | The Honey That Wasn't | C | Investigation | Mossdeep | Beatrix Combe |
| 38 | The Webcrawler's Larder | C | Escort | Mossdeep | Nettle Thrum |
| 39 | The Old Shade Grows Cold | C | Faction | Mossdeep | Mossy Pennywhistle |
| 40 | The Big Folk Are Asked | C | Faction | Mossdeep | Maplin Thorne |
| 41 | The Crooked Bridge | D | OddJob | Sylvaran | Ilmarin Thistledown |
| 42 | The Girl Who Drank the Moon | D | Investigation | Sylvaran | Elwyn Moonfern |
| 43 | A Bow Must Be Asked For | D | OddJob | Sylvaran | Aerendil Ashwood |
| 44 | Two Hundred Years of Silence | C | Faction | Sylvaran | Thessaly Elmwhisper |
| 45 | The Gentle Spores | C | Investigation | Sylvaran | Oriel Fenwood |
| 46 | What the Trees Remember | C | Exploration | Sylvaran | Ashael Dryad |
| 47 | The Pilgrim and the World Tree | C | Escort | Sylvaran | Joran Tarn |
| 48 | A Cup of Sunwine | B | Investigation | Sylvaran | Eredhel Fairbrook |
| 49 | The Rootward Watch | B | Defense | Sylvaran | Lirael Swiftthorn |
| 50 | The Last Planting | B | Faction | Sylvaran | Old Ambrael |
| 51 | A Coin for Every Deal | D | OddJob | Lirian | Pico Stella |
| 52 | The Counter-Song | D | Investigation | Lirian | Carlotta Dessi |
| 53 | A Glass Heart for the Lagoon | D | OddJob | Lirian | Orsino Vetri |
| 54 | Which Doge? | C | Investigation | Lirian | Fabrizio Ledo |
| 55 | Under the Rooftops | C | Exploration | Lirian | Nerea Salt |
| 56 | The Deaf Gondolier | C | Escort | Lirian | Tullio Brenta |
| 57 | The Auction of Masks | C | Hidden | Lirian | Lucia Marchetti |
| 58 | The Three Gaps | B | Defense | Lirian | Beatrice Morosina |
| 59 | The Last Song of Isolde Verro | B | Investigation | Lirian | Paolo Verro |
| 60 | Maelsday, All at Once | B | Faction | Lirian | Ottavia Ruzzini |
| 61 | The Foal Nobody Named | D | OddJob | Fanghold | Yaska Windtooth |
| 62 | Champion of Pasture Nine | D | Faction | Fanghold | Elder Oyun |
| 63 | The Eagle-Feather Trade | D | Investigation | Fanghold | Batu Eagle |
| 64 | The Ledger Is Longer Than the Whip | C | Investigation | Fanghold | Mother Sarnai |
| 65 | The Grandmother's Seat | C | Faction | Fanghold | Naran Dusksong |
| 66 | Stampede Season | C | Defense | Fanghold | Bayar Camp |
| 67 | The Wind Carries the Dead | C | Hidden | Fanghold | Old Temuge |
| 68 | Kade's Water Tax | B | Faction | Fanghold | Speaker Dolgor |
| 69 | The Last Free Stallion | B | Capture | Fanghold | Rider Khulan |
| 70 | The Moot of Nine Fires | B | Faction | Fanghold | Moot Keeper Tsetseg |
| 71 | The Stone She Carried | C | Investigation | Iron Hold | Hesta Coalhand |
| 72 | Three Hundred and One Mugs | C | OddJob | Iron Hold | Grumbald Oakbarrel |
| 73 | The Tap Code | C | Investigation | Iron Hold | Dibble Quickpick |
| 74 | Amend the Law | C | Faction | Iron Hold | Fizzwick Gearsoft |
| 75 | The Giant's Envoy | B | Faction | Iron Hold | Brunhild Ironvow |
| 76 | The Seal Is Warm | B | Exploration | Iron Hold | Orm Sparkbrow |
| 77 | Runes in Cold Iron | B | Hidden | Iron Hold | Kessa Quickspark |
| 78 | A Flame From Every Forge | B | Faction | Iron Hold | Dorn Coalheart |
| 79 | The Thane's Granddaughter | A | Escort | Iron Hold | Brunhild Ironvow |
| 80 | The Anvil That Counted | A | Hidden | Iron Hold | Baldur Anvilfast |
| 81 | The Last Pillar | C | Exploration | Hoshizora | Daigo Hanamura |
| 82 | The Spirit Who Had No Seat | C | OddJob | Hoshizora | Little Hana |
| 83 | The Kappa's Bow | C | Faction | Hoshizora | Genji Boatman |
| 84 | The Mask-Carver | B | Investigation | Hoshizora | Okuni Carver |
| 85 | Fourteen People and a Festival | B | Faction | Hoshizora | Headwoman Fumiko |
| 86 | The Tengu's Test | B | Hidden | Hoshizora | Tengu Soujo |
| 87 | The Sword Given to the Gods | B | OddJob | Hoshizora | Munetoshi Smith |
| 88 | The Masked Village | A | Faction | Hoshizora | Priestess Aoi |
| 89 | The Hundredth Lantern | A | Hidden | Hoshizora | Shino Lantern |
| 90 | A Letter Written in Courtesy | A | Faction | Hoshizora | Courier Benten |
| 91 | Wood for the Last Fire | B | Gathering | Frostveil | Hrefna Firekeeper |
| 92 | The Frozen Fleet | B | Defense | Frostveil | Eyvind Harbourmaster |
| 93 | A Frost Troll at the Door | B | Faction | Frostveil | Gudrun Goodwife |
| 94 | A Burning Ship on Ice | B | OddJob | Frostveil | Thora Widow |
| 95 | A Saga About the Living | B | Faction | Frostveil | Skald Ragnhild |
| 96 | The Survivor Who Came Back Older | A | Investigation | Frostveil | Old Halvard |
| 97 | A Cave of Summer | A | Exploration | Frostveil | Sigrid Iceguide |
| 98 | The Thing | A | Faction | Frostveil | Lawspeaker Vigdis |
| 99 | The Last Fire Goes Out | A | Defense | Frostveil | Hrefna Firekeeper |
| 100 | The Saga, Sung | A | Hidden | Frostveil | Skald Ragnhild |

## 3. How a quest is built

Every quest follows the [quest outcome grammar](../quest_outcome_grammar.md): one **offer**, two or three **approaches**, a small **outcome record** and a visible **receipt**. In the data, branches are `choice` objectives; the chosen outcome is a runtime outcome record, not a separate quest row.

| Part | What it gives the writer |
|---|---|
| **The short version** | The offer as the player first hears it |
| **What is really going on** | The truth behind it, so every line can be written with it in mind |
| **Four scenes** | Offer → complication → turn → resolution, each with dialogue |
| **Choices** | `► ` lines; each is a real approach, not a flavour variant |
| **Outcomes and receipt** | What changes, and the one visible thing that proves it |
| **Data block** | A hidden comment: id, rank, giver, level, reward, flags, objectives |

**Dialogue conventions.** Speaker names in capitals; stage directions in italics; `► ` marks a player choice; `[SYSTEM]` is the System Voice. Voices are distinct per NPC (a goblin cook speaks in soup, a kobold in the third person, a Frostveil goodwife in laws). No fourth-wall breaks (Canon §4); the System speaks to the character.

## 4. Rules these quests keep

| Rule | How it shows up |
|---|---|
| **Teen rating, no fanservice** | Slavery, death and grief are present; none is shown graphically. Romance is background only |
| **Warmth over comedy** | The funniest quests (the false-bottomed mug, the soapbox racer) still end on a kindness |
| **Signposted loss** | Deaths and permanent losses are always a clear choice with the cost shown first |
| **Tyrants stay Tyrants** | No side quest kills a regional Tyrant or ends a siege. Several change *how the region prepares* and what the Tyrant says before the fight |
| **Named monsters stay impersonal** | No monster remembers the player (Canon §4d) |
| **No new mechanical power** | Rewards are the standard gold, GP and XP. Cosmetic or flavour rewards are described in prose and are not in `Data/Items/` |
| **Alternate routes** | None of these gates the main story |

## 5. Seeds and proposals (listed in Canon §6)

These are the **new facts** the quests propose. All are drafts for approval.

| Region | Proposal | Quest |
|---|---|---|
| Aldmere | Every valley farm's doorstep sword is a **truce token** with the Greyhollow dead | A Sword Under Every Doorstep |
| Aldmere | **Ashgrave** refused the Grey Harvest grain-seizure order; the marching dead are still hauling grain | What the Baron Refused |
| Aldmere | A **Choir of Mirrors** recruiting pamphlet (hand-mirror sigil) in Aldmere orphanages | The Friend in the Mirror |
| Greymoor | The **Choir of Silence** takes memory in small things first; a written *Book of Small Things* is a ward | The Choir Passes · The Book of Small Things |
| Greymoor | The abbey bell's **clapper** was hidden because the bell called the Choir | The Clapper in the Peat |
| Mossdeep | The Thimblefolk's lost **silver-eyed panel** (an old hunger) and a human **Giant** who guards them | The Blue in the Tapestry · A Thimble of Milk |
| Sylvaran | **Something older than the elves** grew in the forest; a spiral stone and a different sky in black water (an unexplained seed) | What the Trees Remember |
| Lirian | The **Drowned Choir** were the old city's own choir, drowned mid-hymn | The Last Song of Isolde Verro |
| Fanghold | The Water-Peace gains a second line: *"Not even for an enemy"* | Kade's Water Tax |
| Iron Hold | The sealed shaft **answers** in the miners' rhythm, and Skarn seems to know of it (an unexplained seed) | The Tap Code · The Giant's Envoy · The Seal Is Warm |
| Hoshizora | **Kurogane's** masks are an attempt to keep his people from forgetting their faces | A Letter Written in Courtesy |
| Frostveil | A returned survivor saw **a door left ajar** in the Shattered Sky; a cave holds the hundred-year summer (both unexplained seeds) | The Survivor Who Came Back Older · A Cave of Summer |

## 6. Production notes

- **Ring placement.** Whisperwood and Brindlewick content is Ring 1. Aldmere E-rank quests are Ring 1–2. Every other quest belongs to the ring of its region (see `Data/World/regions.json`) and is **not needed** before that ring is built.
- **Rewards** are first-pass tuning, scaled from the nearest existing quest of the same rank and the promotion table in `Data/World/guild_ranks.json`. Hand them to `systems-designer` before Ring 2.
- **Reward items.** Only existing items are used (and rarely). Proposed new items (named bows, lanterns, small hammers) are in the prose, not in `Data/Items/`.
- **Voice.** About two thirds of the quests have a distinct comic or tender register that the audio and writing teams should preserve; a first-pass VO list can be built from the dialogue lines by speaker.
- **Open questions** are in each region file's placement notes and in Canon §6.
