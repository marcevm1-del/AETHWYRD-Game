# 01c — Borrowed & Adapted: Best Mechanics from Similar Games (30)

Proven mechanics from games in our genre, **rebuilt on Ascend's existing systems** (no copied names, art or text: only the design ideas, which is how every studio learns). Each entry says what the original does, then the Ascend version and where it plugs in.

---

## Companions & Party

### 1. Inclinations & Living Guides — from *Dragon's Dogma 2* (pawns)
**Original:** AI companions have inclinations (supportive, defensive, item-loving, aggressive) that change their behavior and lines, and they guide you to treasure and quest spots.
**Ascend:**
- Every companion and hired mercenary has an **Inclination** you can nudge over time: *Protector · Tactician · Treasure-Nose · Vanguard*. It changes combat AI, banter and what they notice in the field.
- **Companions remember the world:** once a companion has been somewhere, or knows a region (Kiri in the Fanghold plains, Suzune in the Isles), they offer to **lead you** to places, shortcuts and secrets ("I know a way around the goblin camp").
- Dismissed mercenaries (Big Upgrade §35) accept a **farewell gift** and remember it if you hire them again.
- Plugs into: companion AI (Canon: quality is critical), the command wheel, hired party members.

### 2. Selective Hangouts — from *Rune Factory: Guardians of Azuma*
**Original:** hanging out with a character offers a few random activities that each take 10–60 in-game minutes, so you can't befriend everyone in one day; bond levels improve battle performance.
**Ascend:**
- **Hangouts** with a companion cost **in-game hours** (1–4) and offer **3 random activities** from that companion's list (Lyra: sparring, stew-tasting, sword-polishing; Kiri: a hunting race, stargazing, rooftop climbing).
- One hangout per companion per day. Spending your evening with one companion means not spending it with another, so choices feel personal.
- Bond levels add **small combat bonuses** (faster Union meter, cover-for-you reactions).
- **Avoiding that game's criticism:** companion AI must carry its weight in fights (we already prioritize this), and Liberated regions keep content (hunting contracts, rifts, museum hunts) so they're never empty after the "restore" goal.

### 3. Party Skits — from *Tales of* series
**Original:** optional short conversations with character portraits, triggered by places, events and items.
**Ascend:** **Party Skits**: manga-panel style chats (portraits + expressions, no animation) that pop up as a small prompt after events, at vistas or when you pick up odd items. Voiced lines optional. **Very cheap to make**, perfect for a two-person team, and they deliver tons of character.
- Plugs into: dialogue UI (portraits already planned), banter, the Legend log.

### 4. Learn Your Friends' Classes — from *Xenoblade Chronicles 3*
**Original:** fighting alongside characters of other classes lets you learn their classes and skills.
**Ascend:**
- Fighting beside a companion raises your **Affinity** with their class line. At Affinity 10, you can learn **one skill** from their class as a sub-skill (limited slots), with no class change needed.
- Taking their class fully still uses the Class Change rules (Rebirth Sigil, trial).
- Plugs into: classes, Union Skills, the respec rules (borrowed skills are kept).

### 5. Tea Time & Lessons — from *Fire Emblem: Three Houses*
**Original:** teaching students and choosing the right conversation topics over tea.
**Ascend:**
- **Mentoring** (Big Upgrade §13) gets **weekly lessons**: choose a topic (swordplay, monster lore, manners, survival). A mentee's **motivation** and talent decide how fast they grow.
- **Tea at the inn** (Inns §5) with a companion: pick topics they like (learned from bond talks) for bonus bond.
- Teacher old-world job (Character Creator §3.2) makes lessons stronger.

---

## Combat & Hunting

### 6. Wounds & Part Breaks — from *Monster Hunter Wilds*
**Original:** hitting the same spot opens wounds; a focus mode targets wounds for big damage; breaking parts gives specific materials.
**Ascend:**
- Big monsters (rigs `large_biped`, `quad_large`, `golem`, `dragon`) have **breakable parts** (horn, tail, wing, crystal). Breaking a part gives **its own material** and changes the monster's moveset (no tail = no tail sweep).
- Repeated hits on a part open a **Wound** (glowing on the model). **Focus Strike**: a lock-on mode where your next skill targets the wound for bonus damage and poise damage.
- Plugs into: combat spec (poise, Break gauge), loot tables, Appraisal tier 3 (shows breakable parts).

### 7. Echo Shards — from *Wuthering Waves* (echoes)
**Original:** defeated enemies can be absorbed and used as summon skills and gear.
**Ascend:**
- Some defeated monsters drop an **Echo Shard** (an imprint of their soul). Equip up to 3 as **one-shot summon skills** (a Horned Rabbit Echo charges for you; a Goblin Echo throws junk).
- **Family set bonuses** for matching echoes.
- **Lore twist (Lying Interface):** echoes are stored **souls**, captured by the System. After Act V, the Status Window admits it, and you can **release** echoes for Thread instead of using them.
- Plugs into: bestiary, the System harvest secret, Thread.

### 8. Standoffs — from *Ghost of Tsushima*
**Original:** challenge a group to a standoff and cut them down one by one with perfectly timed strikes.
**Ascend:** Swordsman and Martial Artist lines can start a **Standoff** against a group that hasn't attacked yet: hold, wait for the enemy's telegraph flash, release. Each success chains to the next enemy. A missed timing starts a normal fight. It looks like a pure anime iai moment.

### 9. Field Fusion — from *The Legend of Zelda: Tears of the Kingdom*
**Original:** attach materials to weapons for new effects.
**Ascend:** **Field Imbue+**: at camp, attach a monster part to your weapon for a **temporary** effect (a slime gel = knockback, a fire core = fire aura, a goblin cleaver blade = bleed). It lasts a set number of hits, never replaces real crafting, and turns junk loot into fun.
- Plugs into: the Imbuing upgrade system (Alchemist oils), materials, monster cuisine side effects.

---

## World & Exploration

### 10. Path Actions — from *Octopath Traveler*
**Original:** each class has a unique way to interact with NPCs (steal, inquire, challenge, guide…).
**Ascend:** every **base class line** gives one **NPC field action**:
| Class | Action | Use |
|---|---|---|
| Swordsman | **Challenge** | Duel an NPC (Big Upgrade §31) |
| Guardian | **Escort** | An NPC follows you safely through danger |
| Mage | **Scrutinize** | Read an NPC's magic aura: hidden curses, illusions |
| Cleric | **Bless** | Heal or calm an NPC; opens confessions |
| Rogue | **Pilfer** | Steal (Karma and crime rules apply) |
| Ranger | **Track** | Follow an NPC's trail to where they've been |
| Tamer | **Befriend** | Calm hostile animals near NPCs, borrow pets |
| Artisan | **Appraise Goods** | See an NPC's real stock and prices; buy rare items |
| Lancer | **Command** | Order guards and militia (great in sieges) |
| Martial Artist | **Intimidate** | Make someone talk (Renown matters) |
| Bard | **Allure** | Charm an NPC into joining your party briefly or telling a secret |
| Occultist | **Read Soul** | See one secret or memory (and the System notices) |
Sub-class gives you a second action. Many quests have **multiple solutions** based on these.

### 11. Research Tasks — from *Pokémon Legends: Arceus*
**Original:** each species has research tasks (see it use a move, defeat X, catch at night) that complete its dex entry.
**Ascend:** every bestiary entry has **4–6 research tasks** ("parry its Charge 3 times", "observe it sleeping", "defeat one at night", "tame one"). Completing them fills the entry **and** raises Appraisal knowledge of that species (more HUD info). Done tasks feed the museum, Kaede's Cards and titles.

### 12. Egg Nests — from *Monster Hunter Stories*
**Original:** sneak into monster dens to take eggs and hatch your own monsters.
**Ascend:** some dens hold **eggs**. Sneak in (or fight the parent), carry the egg out (heavy, slows you), and hatch it at the ranch. Hatchlings start at Bond 3 with you and can roll rare markings. A second taming path for players who don't like weakening monsters.

### 13. Shrine Offerings & Mana Motes — from *Genshin Impact* (statues and oculi)
**Original:** collectibles scattered across the map are offered at statues for stamina and other boosts.
**Ascend:** **Mana Motes** (element-colored, hidden in hard places: cliff tops, behind waterfalls, inside puzzles) are offered at **shrines of the Eight** for permanent **stamina, HP and Devotion** boosts. Each region has its own mote type. Archivist System personality hints at nearby motes.

### 14. Region Ecology Cycles — from *Monster Hunter Wilds* (fallow / inclemency / plenty)
**Original:** regions cycle between harsh and plentiful phases that change monsters and resources.
**Ascend:** every region cycles through **Lean · Storm · Plenty** phases over in-game weeks. Storm phases bring tougher spawns and rare weather materials; Plenty brings herb blooms, migrating herds and fat fish. **Besieged** regions are stuck in Lean; **Liberation** starts the cycle again (the land "breathes").
- Plugs into: sieges, weather & sky events, the Adventurer Times forecast.

### 15. Lantern Echoes — from *Elden Ring* (bloodstains, offline-authored)
**Original:** stains show how other players died.
**Ascend (single-player, Canon):** blue **Morrowyn lanterns** mark where NPC adventurers died. Touch one to see their **last moments** as a ghostly replay. It's a warning about a trap or ambush, a lore fragment, and sometimes their unfinished quest. Authored, no online needed.

---

## Settlements & Slow Life

### 16. Town Restoration Bundles — from *Stardew Valley* (community center)
**Original:** donate bundles of items to restore a building and unlock features.
**Ascend:** every town has **Restoration Boards**: bundles of items (lumber, fish, monster parts, crops) that rebuild a specific place (the burned chapel, the old bridge, the bathhouse). Each finished bundle raises Prosperity and permanently changes the town's 3D look.

### 17. Monster Workers — from *Palworld* (base work)
**Original:** captured creatures work at your base based on their skills.
**Ascend:** ranch monsters can be **assigned jobs** at your home and territory by element and role: Water slimes water crops, Fire lizards keep the forge hot, Earth golems haul stone, Wind sprites turn windmills, Haulers deliver goods. Happy, well-fed workers produce more. Never cruel: overworking them lowers Bond and Thread.

### 18. Villager Traits — from *Rune Factory: Guardians of Azuma*
**Original:** villagers have traits that make them better at certain jobs.
**Ascend:** territory **residents** (Housing §6.4) have **up to 4 traits** (*Green Thumb, Night Owl, Former Soldier, Gossip, Clumsy Genius…*). Traits decide which job suits them, and some trigger small events ("the Gossip spreads a rumor about you").

### 19. Ability Outfits — from *Infinity Nikki*
**Original:** outfits give exploration abilities.
**Ascend:** special **Field Outfits** grant traversal or life abilities: a **Glider Cloak** (Canon allows gliding from items), an Angler's Coat (fishing bonus), Climber's Gear, a Diver's Suit (stretch goal: underwater), a Festival Kimono (dance minigame bonus). They use the cosmetic layer, so you can keep your look and still get the ability.

### 20. Material Trait Inheritance — from *Atelier Ryza*
**Original:** traits on materials pass into crafted items.
**Ascend:** materials can carry **traits** (*Sharp, Lucky, Fire-tempered, Beloved by Spirits*). Up to 3 transfer into the crafted item, and combining the right ones creates **higher traits**. This gives crafters a deep chase, and Named-monster materials carry unique traits.

### 21. Pre-Hunt Feast — from *Monster Hunter* (canteen meals)
**Original:** eat before a hunt for buffs and a fun food scene.
**Ascend:** at inns and camp, a **party feast** before a big fight gives shared buffs and plays a short, warm cooking scene with the party (Monster Cuisine §9, Inns §1). Feasts with a companion's favorite dish raise Bond.

---

## Story Presentation

### 22. A Guiding Wisp — from *Ghost of Tsushima* (guiding wind)
**Original:** the wind points toward your objective instead of a HUD marker.
**Ascend:** in the **Immersive HUD preset**, a small **Maelis wisp** (or Mochi bouncing ahead) leads you to your tracked quest. Swipe the touchpad or press a button to call it.

### 23. Living Calendar — from *Persona 5 Royal*
**Original:** a calendar with time slots and social links that make each day a choice.
**Ascend:** the **weekly calendar** (HUD §11) gains **evening choices**: inn night, hangout, study at the library, part-time job, training. Each evening activity also raises a **life stat** (Knowledge, Courage, Charm, Kindness), which unlocks dialogue options and some class quests. It sits on top of the existing weekday system and never forces a choice.

---

---

## From *Echoes of Aincrad* (Sword Art Online, July 2026)
An action RPG where you play a custom avatar trapped in a deadly VR game, fighting real-time (dodge, parry, timed attacks) beside an anime partner. It's the closest recent game to Ascend's "trapped in a game-like world" theme.

### 24. "Switch!" — partner hand-off
**Original:** the Switch system lets you swap roles with your partner mid-fight and chain attacks; you can also hold back and split damage.
**Ascend:** a **Switch** call (tap the companion button during a combo):
- Your companion **steps in front of you** to take the enemy's next attack, and you leap back with a short stamina refill. Their next hit continues your combo count and **Style Rank**.
- **Perfect Switch:** call it right as an enemy telegraph flashes and the companion parries it, opening a stagger window.
- Each companion has their own Switch animation and line ("Switch! I've got it!"). Plugs into the command wheel, Union Skills and the Style meter.

### 25. Command vs Free Rein (with fatigue)
**Original:** a commanded mode where the partner follows your orders, or a free mode where they act independently, which is more effective but tires them faster.
**Ascend:** a toggle for each companion:
- **Command:** they follow the command wheel exactly.
- **Free Rein:** they fight on their own Inclination (borrowed #1) and deal more damage, but build **Fatigue**. High Fatigue slows them and blocks Union Skills until they rest (a camp, an inn, a feast).
- It makes resting at inns and camp matter in long dungeons.

### 26. Death Game Mode (free, never paywalled)
**Original:** one save file, no respawns, and the save is deleted if you die. It unlocks after finishing the game, or early in the paid Deluxe and Ultimate editions.
**Ascend:** our **Hardcore** mode gains a **"Death Game" presentation**: at creation, the System Voice announces, *"Respawn function: disabled. Do you understand?"* The Status Window shows a permanent skull mark, and NPCs who learn your rank treat you as someone who can truly die.
- **Never sold:** Canon says premium only with no paid extras, so it's available from the start for everyone (with a warning).
- On death, your character becomes a grave and journal for future runs (Systems §10.3, the Next Summoning).

### 27. Safe Areas reset the field
**Original:** exploring opens Safe Areas, and resting at one resets the enemies in that zone.
**Ascend:** a clear rule for **waystones and camps**: resting there **respawns nearby common monsters** (not Named monsters, Tyrants, bosses or cleared dens). Discovering a waystone also reveals the region's map around it. It gives farming routes a rhythm without making cleared areas feel pointless.

### 28. Floor-Boss Raid Councils
**Original:** set on a floating castle of deadly floors, retelling the series' first arc, where players band together against floor bosses.
**Ascend:** in the **Great Labyrinth**, every 10th floor's boss needs a **raid**:
- A **raid council** meets at the safe-floor inn (The Deep Pint on floor 30): NPC parties from the **Adventurer Rankings** argue strategy, rivals clash, and you can propose the plan. It's the classic anime strategy-meeting scene.
- In the fight, those NPC parties fight beside you with their own roles. Some can die if the plan is bad (only parties, never your companions unless Mortal Bonds is on).
- **The Frontline:** the guild tracks the deepest floor anyone has cleared. Clear a new floor first and it makes the Adventurer Times.

### 29. The Day the Windows Glitched
**Original:** the game recreates the shocking announcement and the panic in the trapped community.
**Ascend:** the existing Act II moment, when the **Lantern Seal cracks and every Status window glitches for one second**, becomes a **playable town event** in Brindlewick:
- People panic in the streets, adventurers argue at the guild, Brother Caspian calms the orphans, and Mina (still the real Mina at this point) organizes everyone.
- You choose how to help, and it shapes Brindlewick's Morale and how the town sees you for the rest of Act II.

### 30. The Veilborn Circle
**Original:** thousands of trapped players form communities, with the series' characters as part of them.
**Ascend:** every **Morrowsday evening**, Veilborn living in a town meet at the inn's back room to share Earth stories, food they miss, and news of the newly summoned. It's a hub for **Earth Relics** (Big Upgrade §44), mentoring newcomers (§13), the classmates from your old school (Canon), and quiet homesick moments. Some members are secretly planning something.

### Lessons From Its Reviews
Critics praised its faithful anime presentation (even the inventory screen looks like the show's) and its partner combat, but called its **dungeons monotonous**, its **combat too easy**, and the game **a standard RPG beyond the franchise touches**. Ascend already plans around all three:
- **Dungeons:** living dungeons with personalities, Rift Runs and wounds & part breaks keep them varied.
- **Combat:** the S-rank difficulty floor keeps late fights hard on every setting.
- **Identity:** the Lying Interface and Thread give Ascend its own hook beyond the tropes.
- **Rule:** no dungeon may reuse the same room template more than twice in a row, and every dungeon needs one unique set piece.

## Sources
- [Stars and Stripes — Echoes of Aincrad preview](https://www.stripes.com/living/entertainment/video_games/2026-07-03/preview:-with-echoes-of-aincrad,-sword-art-online-comes-to-life-as-a-video-game-22065299.html)
- [Bandai Namco — Echoes of Aincrad launch page](https://en.bandainamcoent.eu/sword-art-online/news/face-the-challenges-of-the-floating-castle-echoes-of-aincrad-launching-july)
- [RPGamer — Death Game Mode trailer](https://rpgamer.com/2026/07/echoes-of-aincrad-trailer-highlights-death-game-mode/)
- [RPG Site — Echoes of Aincrad gameplay trailer](https://www.rpgsite.net/news/20140-echoes-of-aincrad-new-gameplay-trailer-galaxies-spring-showcase)
- [GamingTrend — Rune Factory: Guardians of Azuma review](https://gamingtrend.com/reviews/rune-factory-guardians-of-azuma-review-a-fresh-breeze-from-the-east/) (villager traits, selective hangouts, criticisms)
- [PC Gamer — Dragon's Dogma 2 pawns](https://pcgamer.com/games/rpg/dragons-dogma-2-pawns) (inclinations, guiding, farewell gifts)
- [Game'n'Guide — Best anime games of 2026](https://www.gamenguide.com/articles/108781/20260812/best-games-based-anime-2026-action-rpgs-jrpgs-fighting-more.htm) (current genre landscape: Genshin, Zenless Zone Zero, Seven Deadly Sins: Origin, Persona 5 Royal, Monster Hunter Stories 3)
- Other mechanics (Monster Hunter Wilds, Wuthering Waves, Xenoblade 3, Octopath Traveler, Pokémon Legends: Arceus, Stardew Valley, Palworld, Infinity Nikki, Atelier Ryza, Ghost of Tsushima, Elden Ring, Fire Emblem: Three Houses, Tales of) are described from general knowledge of those games.
