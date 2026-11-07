# 08c — Bosses, Generals, Elder Dragons & Calamities (v0.2)

## 1. Boss Design Rules
- Every boss has **2–4 phases**, a **break gauge** (stagger), **breakable parts** (horns, wings, tails → special loot), an **arena** that changes per phase, and a **musical theme**.
- Bosses **telegraph**: magic circles, glowing eyes, wind-ups, color-coded (red = unblockable, blue = parryable, gold = grab).
- **Mercy/Talk** options exist for intelligent bosses. About 30% of bosses can be negotiated with, recruited or spared.
- Single-player tuning: companions draw aggro. "Party Command" lets you call Union Skills at break windows.

### Armor and weak points (Wave A2, proposals)
- A boss may carry an **armor gauge** and named **weak points** exposed in chosen phases; data in `Data/Monsters/boss_weakpoints.json`, rules in `12_Systems/combat.md` sections 7c and 7d. Phases stay in `Data/Monsters/boss_phases.json`.
- Armor break and weak-point exposure are always announced (sound, visible crack, glow) and are a reward window, never required to win.
- **Goblin Chief Grukk** (starter record): armor 300, breaks for 5 s (+25% damage taken), regenerates after 6 s; the **cult-rune brand** on his chest is exposed in the Archers and Rage phases (x1.5 damage).
- Other bosses below (Proving Golem's rotating runes, Ozymarch's clock-core, Mycelia's hearts) are natural next records; add them one at a time.

## 2. Dungeon Bosses (sample)
| Boss | Rank | Dungeon | Phases / Mechanics | Unique drop |
|---|---|---|---|---|
| **Goblin Chief Grukk** | E | Hollowpine Camp | P1 duel; P2 calls archers; P3 rage swing | Grukk's Cleaver |
| **The Proving Golem** | D− | Proving Cave | Rune weak points rotate; tests every mechanic | Examiner's Badge |
| **Mother Webcrawler** | D | Silkhollow Cave | Webs on floor slow you; burn to clear | Spider Queen's Silk |
| **Baron Ashgrave** (Death Knight) | C | Greyhollow Keep | Summons his old guard; P2 mounted charge | Ashgrave's Oathblade |
| **The Drowned Choir** (3 Sirens) | C+ | Saltwater Grotto | Sing in harmony; silence one to break the song | Choir Pearl |
| **Mycelia, the Spore Lord** | B | Fungal Deep | Spores = confusion; destroy 4 hearts across the cave | Spore Crown |
| **Vault Warden Ozymarch** | B+ | Valdrisian Vault | Rewinds time on itself; break the clock-core | Chronoshard |
| **Sylphara, Queen of Winds** | A | Spire of Gales | Arena becomes floating platforms | Windqueen's Veil |
| **Bloodmoon Countess Velaria** | A+ | Crimson Manor | Ballroom fight; dance-floor tiles; mirror clones | Velaria's Rose |

## 3. The Great Labyrinth — Floor Guardians
| Floor | Guardian | Rank | Biome | Gimmick |
|---|---|---|---|---|
| 10 | **Minotaur Warden** | D | Stone maze | Charges break walls, reshaping the maze |
| 20 | **Twin Gorgons** | C | Sunken temple | One petrifies, one poisons; mirrors reflect gaze |
| 30 | **Iron Jaw Hydra** | C+ | Swamp | Heads of different elements |
| 40 | **The Hollow Choir** | B | Cathedral of bones | Phantom bell puzzle mid-fight |
| 50 | **Twin Chimera Abraxas** | A | Lava fields | Two chimeras that swap heads |
| 60 | **Glacial Matriarch** | A | Frozen ocean | Ice floor breaks; underwater phase |
| 70 | **Mirror Self** | A+ | Mirror world | Fights with **your** build and skills |
| 80 | **Clockwork Seraph** | S | Titan machinery | Time-slows; parry-only phase |
| 90 | **Gatekeeper Xal'ziir** | S+ | Void edge | Arena shrinks; Void erases your skills temporarily |
| 100 | **The Last Titan's Heart** | SS | Titan's chest cavity | You are *inside* a living Titan |
| 110 | **The Prior Hero** | SS+ | Hall of Heroes | The first summoned hero's echo |
| 120 | **??? (the Forgotten)** | EX | The Loom | Story-secret final superboss |

## 4. Field Bosses (open world, roaming/scheduled)
| Boss | Rank | Region | Spawn | Notes |
|---|---|---|---|---|
| **Thunderhorn Behemoth** | A | Beastkin Plains | Storms | Stampedes the herd with it |
| **Greymoor Wyrm** | A | Greymoor marsh | Fog | Hides in fog; sound-tracking |
| **Colossus of Sunscar** | A+ | Sunscar Desert | Sandstorm | Walks the desert; climbable (Shadow-of-the-Colossus style) |
| **The Glass Stag** | B | Whisperwood | Full Lumen | Peaceful; legendary bow if befriended |
| **Krakenmother Ys** | S | Abyssal Coast | High tide at night | Ship battle |
| **Frost Sovereign Ymgrir** | S | Frostveil | Blizzard | Frost giant king |
| **Ashen Phoenix** | S | Iron Hold volcano | Eruption event | Resurrects once; break the egg |

## 5. The Five Demon Generals (Act IV)

The fifth General, **Lady Nocturne, the Veiled Mirror**, is fought in a hall of mirrors after her infiltration arc (see `02_Lore/story.md`).
### GENERAL IGNAROK, the Flame Unbroken — *Iron Hold*
- **Rank:** S → SS (true form). **Race:** Fire Demon (former dwarf champion).
- **Motive:** wants a death worthy of a warrior; respects duels.
- **Fight:** P1 honor duel in the Great Forge; P2 molten armor (fire floor); P3 **true form** volcanic giant, with the forge collapsing.
- **Choice:** grant him an honorable death, or redeem him (he becomes Torvald's lost brother).
- **Drop:** *Ignarok's Unbroken Heart* (Fire Legendary core).

### GENERAL MORTHIS, the Queen Under Sand — *Sunscar Desert*
- **Rank:** SS. **Race:** Lich-queen of fallen Valdrisia.
- **Motive:** resurrect her entire lost nation, even as undead.
- **Fight:** a palace that shifts between ruin and its living past (time-phase arena); she summons her royal guard; P3 her phylactery is the pyramid itself.
- **Choice:** destroy her, or release her people's souls peacefully (Morrowyn quest).

### GENERAL ZEPHIEL, the Storm Architect — *Sky Archipelago*
- **Rank:** SS. **Race:** Fallen angel-like Titan-construct hybrid.
- **Motive:** take Titan tech to "fix" the world without gods.
- **Fight:** aerial battle on airships → inside a storm engine → zero-gravity eye of the storm.
- **Twist:** he's partly right. His notes help the Unwoven Sky ending.

### GENERAL RHAKA, the Beast Mother — *Beastkin Plains*
- **Rank:** SS. **Race:** Ancient chimera-beastkin.
- **Motive:** free monsters from being "farmed" for cores by the Guild.
- **Fight:** a multi-boss with her four children (Wolf, Serpent, Eagle, Bear), followed by her merged form.
- **Choice:** she can be **recruited** with Monster Speech/Beast paths, which changes the war.

## 6. The Five Elder Dragons (optional, EX)
| Dragon | Element | Lair | Personality | Trial (to befriend) | Battle gimmick |
|---|---|---|---|---|---|
| **Ignivar, the Ember Throne** | Fire | Heart of the volcano under Iron Hold | Proud, vain, loves gold and flattery | Bring a gift worthy of a dragon (crafted masterwork) | Lava lake rises each phase |
| **Glacirra, the White Silence** | Ice | Frozen lake above Frostveil | Melancholic, poetic | Answer her three questions about loss | Time freezes; you move between frames |
| **Zephyros, the Endless Sky** | Storm | Eye of a permanent hurricane | Playful, chaotic | Win a sky race (flight ability or airship) | Fought on falling cloud-islands inside the storm |
| **Terragon, the Mountain That Breathes** | Earth | He IS the Dragon Spine mountain range | Sleepy, ancient, wise | Climb him without waking him | Climb his body while he shakes the world |
| **Umbrael, the Hollow Star** | Void | Rift in the Shattered Sky | Nyx's father; tragic; corrupting | Requires Nyx's arc completion | Reality breaks; arena shifts dimensions |

Befriend or defeat all 5 → **Dragon Emperor** legendary class.

## 7. Calamity Beasts (EX raid-tier, single-player tuned with full party)
| Calamity | Where | Trigger | Encounter |
|---|---|---|---|
| **Leviathan** | Abyssal Sea | Late-game world event | Naval + underwater multi-stage |
| **Titan of the First Age** | Sky Archipelago | After Zephiel | Climb-and-fight across a walking continent |
| **Garmrok, the World-Eater Wolf** | Shattered Sky | Its chain breaks (Act V) | Chase across regions; it devours terrain |
| **Hive Mother of the Abyss** | Abyssal rift | Ignoring Stampedes too long | Defend 3 towns at once, then descend |
| **No-Life King** | Valdrisian necropolis | Morrowyn's lantern goes out | Army battle + duel |
| **Aethernax, the Sky Devourer** | Above the clouds | Twin Eclipse year 2 | The sky goes dark; fight on falling islands |
| **Primordial Ooze** | Labyrinth 115 | Post-game | Absorbs your skills each phase |
| **Elemental Primarch** | Weave core | Post-game | Cycles all elements |

## 8. Final Bosses (by ending)
| Ending | Final encounter |
|---|---|
| Hero's Dawn | **Azrael Noxveil** (3 phases: Demon Overlord → Fallen Hero → both at once) |
| Crimson Throne | **Archbishop Crowe + the Avatar of Ilvaris** |
| Unwoven Sky | **The System** itself: a fight inside the Status Window UI (meta battle) |
| Quiet Field | No fight; a final quiet conversation with Ilvaris on your farm |
| Thirteenth Star | **Ilvaris, Weaver of Fates (true form)**, then **Ezrath**. The game's hardest fight |
