# Progress log

Newest first. Each entry is one push to GitHub; the vault copy is pulled right after. Test counts are Core rules + Unity PlayMode. The milestone table and controls are in [[ring0_plan]].

## 2026-10-24

| Commit | What changed | Tests |
|---|---|---|
| Partner orders | Z / LB cycles Follow → Hold (guard a spot) → Focus (attack your lock-on target); each species learns orders by trainability per family (after RimWorld): beasts, birds and dragons all three, slimes and spirits Follow and Hold, plants only Follow | 158 + 120 |
| Pack calls | From Greyborn's fight-or-flee odds: pack and swarm monsters cry out when hit and their own kind within 12 m join in; a pack hunter left alone and hurt falls back home | 157 + 118 |
| Recipe ideas | From Grounded's analyzer / Subnautica's scanner, shaped by item_and_economy_design §6.2: handle every material of a recipe and you get an idea; experiment at the right station to make it and learn it free (the paid lesson stays as the other route) | 156 + 117 |
| Reference: Greyborn | From your Project Greyborn bot AI (ported logic): monsters that hit a wall head-on sidestep and work their way round; skittish and ambushing monsters hop back when badly hurt. reference_games.md lists what else is worth taking (utility goals with hysteresis, path budget, pack odds) | 155 + 116 |
| Reference: RimWorld | 13_Production/reference_games.md started (ideas only from other studios' games). From RimWorld's animal data: taming wildness by behaviour (moths easy, wolves hard), failed offers turn on you by temper (0% Passive … 50% Aggressive), partners nuzzle you now and then (counts toward Bond) | 155 + 114 |
| Gathering | Data/World/gathering.json (validated): herb patches, mushroom rings, weeping pines and goblin scrap heaps — 13 nodes across the field and Whisperwood. E gathers (whichever of NPC or node is closer), the node regrows over in-game hours and its regrowth is saved. A second source for healing herbs, sap, spore caps, scrap and crude iron | 154 + 113 |
| Bestiary | Appraisal tiers from hud_and_ui.md §9: monsters within 20 m are recorded, 3 kills reveal HP/element/weakness, 10 kills or taming the full entry (drops, look, field note); finding every drop stamps it 100%. Monster labels follow what you know (??? → name and rank → HP). B opens the Bestiary with Ring 0–1 completion. Thresholds in world_tuning.json → bestiary | 152 + 112 |
| Guild ranks | Adventurer rank from ranks.md §2 (Data/World/guild_ranks.json, validated): GP scales with quest rank vs yours (150% one above … 0% three below), quests at your rank, level, the special (F→E: learn a life skill from a teacher) and the trial; ask Mina about promotion for the checklist, rank-up ceremony at her desk with the Rank Gift; taming cap and Marta's tab use the guild rank; Rodrick Hale (F→E trial) added | 148 + 110 |
| Crafting | `Data/Items/recipes.json` (6 Ring 0 recipes; validated: items, stations, a result never above its best material). Learn at the teacher's workbench (Torvald's forge: Fangblade, Carapace Cap, Talon Charm; Fennick's alembic: Minor Healing Potion, Fire Bomb), cook Hunter's Skewers at a campfire from the bag. Fire Bombs from shops, loot or crafting go to the quick slot. Partners level with you (+6% ATK/HP per level above the species'); release a partner from the bag with a confirm step | 145 + 108 |
| Partners | Roles from behaviour (Vanguard / Support / Scout / Striker), monsters fight partners, knocked-out partners rest 20 s, Bond from shared wins, evolution at Bond 5 into a species variant (bag, with preview) | 140 + 104 |
| Taming | Weaken < 30%, calm and fear meters, favourite food, CHA check; rank cap; 3 partners travel, the rest to the ranch; Canon §6 proposal | 137 + 100 |
| Escort | Ottoline's cart to Millbrook with ambushes; NPC quest markers fixed (weren't saved in the scene) | 131 + 96 |
| Defence spots | Millbrook granary and the training-yard mock raid; shared monster spawner | 130 + 95 |
| Quest places | Lantern-post stand-ins for every reach target; scene components that failed to load fixed (classes now in their own files); field scene test | 130 + 94 |
| Guild board | Weekly board beside Mina (Day Special, dailies, weekly commission, raid warnings); liberation test; F8 playtest level-ups | 130 + 93 |
| Liberation | Slaying Grukk liberates Whisperwood | 127 + 91 |
| Sieges | Whisperwood raids on the Brindlewick gate, live or auto-resolved; F9 raid | 127 + 91 |
| Day clock & inn | 90-minute days, moving sun, Marta's rooms, rest XP, the tab | 122 + 88 |
| Equipment | Gear slots, class weapon and armour rules, bag window; flaky wall test fixed | 118 + 83 |
| Shops | Guild core buyback, Fennick, Torvald, Ottoline; buy / sell / buy back | 114 + 79 |
| Movement feel | Researched; acceleration, air control, coyote time, jump buffer, short hops (`movement_feel.md`) | 108 + 77 |
| Quests | Journal, NPC talk window, quest drops, places, potions | 108 + 71 |
| Flyers | Moths, crows and spirits hover | 101 + 65 |
| Whisperwood | Ring 1 test field past the gate | 100 + 64 |
| Death, loot, saves | Coins and loot, death screen and penalties, waystones, save/load; 677 blockout monster models (local) | 100 + 64 |
