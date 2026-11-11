# 12b — Weapon-Family Movesets (specification with timings)

**Data:** `Data/Combat/weapon_movesets.json` (schema `Data/Schemas/weapon_movesets.schema.json`, rules in `Tools/validate/weapon_checks.js`). This file turns the weapon-identity rule of [[Design Bible/12_Systems/combat|combat.md]] section 13 into numbers: every weapon family gets **one opener, one reliable punish, one spacing option, one crowd-control option and one high-commitment payoff**, with startup / active / recovery in seconds, reach, arc and lunge. All numbers are **proposals** for the user to tune; the doc below is generated from the data (do not hand-edit the tables).

## How to read the timings
- Baseline hit timings come from `combat_tuning.json` `attackTiming` (light .10/.08/.24, medium .16/.10/.36, heavy .26/.12/.46, launch .14/.10/.32 s). A family scales them: fast weapons shorten startup and recovery, heavy weapons lengthen them. Hit-stop, shake and Style points come from the hit **weight** (combat.md 4.2, section 8), so a family cannot dodge the feel rules.
- Every hit keeps the shared rules: dodge-cancel from active frame 1, input buffer `inputBufferSec`, Combo Budget for skill-cancels (combat.md 4.1).
- Reach is in metres from the player; arc is the hit cone in degrees; lunge is forward (+) or backward (-) displacement during the hit.
- **Telegraphs are untouched:** nothing here changes the monster colours (combat.md section 5). Weapon moves never remove a monster's tell.

## Checks the validator enforces
1. Every weapon type and every class in `Data/Classes/classes.json` belongs to at least one family (derived from the class data, so a new weapon cannot ship without a family).
2. Every family has all five roles exactly once; `skillId` values must exist in the kit of one of the family's classes.
3. Opener first hit starts within 0.35 s; the punish starts within 0.2 s (it must fit a recovery window); the payoff's last hit carries at least 1.5x the commitment (startup + active + recovery) of the opener's first hit; the spacing move moves you 1.5 m, works from 4 m or more, or pushes/slows; the crowd-control move controls or covers 180 degrees or more; no startup is below 0.06 s (unreadable).
Gap: **no Unity or Core code reads this file yet.** Families without a `skillId` (greatsword, twin blades, katana) need kit data from the class-skill-designer; the engine side goes to the gameplay-engineer (see "Hand-offs").

## Weapon families

### Sword (`wf_sword`)
The baseline: balanced reach, fast chain, honest recovery. Every other family is judged against it.
- **Weapons:** sword · **Classes:** cls_swordsman
- **Mobility:** Short lunge on every hit; Flash Step closes distance. · **Air:** Rising Cut launches; air chain ends in a slam.
- **Defense:** parry · **Resource rhythm:** Steady combos build Edge Flow; getting hit drops stacks.
- **Training-yard trial:** Land L-L-L-M, then Rising Cut into an air chain on the dummy.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Slash Chain (`skl_slash_chain`) | none, move 0.35 m | L 0.1/0.08/0.24, L 0.1/0.08/0.24, L 0.1/0.08/0.24, M 0.16/0.1/0.36 | 2.2 | 120 | Three light hits then a medium finisher that knocks back. |
| punish | Parry Riposte (`skl_parry_riposte`) | stagger, move 0.4 m | M 0.112/0.1/0.36 | 2.2 | 90 | Quick medium hit after a blue parry; big hit-stop. |
| spacing | Flash Step (`skl_flash_step`) | none, move 4 m | M 0.16/0.1/0.36 | 2.4 | 60 | Dash-slash that closes a 4 m gap. |
| crowd control | Whirlwind (`skl_whirlwind`) | push | M 0.16/0.1/0.36, M 0.16/0.1/0.36 | 2.4 | 360 | Full circle, pushes small enemies off you. |
| payoff | Guard Break (`skl_guard_break`) | guard_break, move 0.5 m | H 0.312/0.12/0.552 | 2.3 | 90 | Overhead that breaks guard; committed recovery. |

### Greatsword (`wf_greatsword`)
Heavy and wide: fewer, slower swings that stagger and carry through crowds.
- **Weapons:** greatsword · **Classes:** cls_swordsman
- **Mobility:** Each swing steps forward 0.8 m; no dash, the length is the spacing. · **Air:** Weak in the air: a single downward cleave that drives targets to the ground.
- **Defense:** guard · **Resource rhythm:** Charge a swing to level 2 for guard break; commit or cancel to a dodge.
- **Training-yard trial:** Hold the heavy for level 2 and break a guarding dummy.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Broad Cleave | stagger, move 0.8 m | M 0.2/0.1/0.414, H 0.299/0.12/0.506 | 2.8 | 140 | Two slow swings; the second staggers medium targets. |
| punish | Guard Counter | stagger, move 0.3 m | M 0.144/0.1/0.36 | 2.6 | 100 | Plants and swings after a block; stamina-free. |
| spacing | Pole Vault Slide | none, move 3 m | M 0.192/0.1/0.36 | 2.8 | 90 | Slide with the blade flat; ends in a short cleave. |
| crowd control | Sweep | knockdown | H 0.26/0.12/0.414 | 3 | 200 | Low wide sweep knocks small enemies down. |
| payoff | Earthsplitter | guard_break, move 0.6 m | H 0.442/0.144/0.69 | 2.8 | 70 | Charged overhead; long recovery, big hit-stop. |

### Twin Blades (`wf_twin_blades`)
Constant motion: short quick hits that stack small reactions and style.
- **Weapons:** dual_swords · **Classes:** cls_swordsman
- **Mobility:** Every hit lunges slightly; a dedicated forward lunge on the second dodge. · **Air:** Longer air chain than any other family (5 hits).
- **Defense:** dodge · **Resource rhythm:** Rewards unbroken pressure; recovery is the shortest of any family.
- **Training-yard trial:** Land a 5-hit air chain on a launched dummy.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Cross Slashes | none, move 0.5 m | L 0.08/0.08/0.192, L 0.08/0.08/0.192, L 0.08/0.08/0.192, M 0.144/0.1/0.324 | 1.9 | 130 | Four hits, fastest chain in the game. |
| punish | Reverse Flurry | stagger, move 0.3 m | L 0.07/0.08/0.24, L 0.07/0.08/0.24, M 0.144/0.1/0.36 | 1.9 | 120 | Quick three-hit punish during recovery. |
| spacing | Twin Dash | none, move 3.5 m | M 0.144/0.1/0.36 | 2 | 90 | Crossing dash that ends behind the target. |
| crowd control | Spin Cut | push | M 0.16/0.1/0.36, L 0.1/0.08/0.24 | 2 | 360 | Circle cut; short push. |
| payoff | Blade Storm | launch, move 1 m | L 0.14/0.1/0.32, M 0.176/0.1/0.36, H 0.286/0.12/0.529 | 2 | 150 | Launch, juggle and drive down; long recovery on the final hit. |

### Katana (`wf_katana`)
Precision and counters: cleaner arcs, longer reach, and a wider parry window.
- **Weapons:** katana · **Classes:** cls_swordsman
- **Mobility:** Drawing step: forward 1 m on the opener. · **Air:** One launching draw cut, then a precise downward finish.
- **Defense:** parry (parry window 0.16 s instead of the shared 0.12 s) · **Resource rhythm:** Perfect timing is rewarded: parry and perfect-dodge counters hit harder.
- **Training-yard trial:** Parry a goblin and land the draw-cut riposte.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Drawing Cuts | none, move 1 m | M 0.128/0.1/0.288, L 0.1/0.08/0.24, M 0.176/0.1/0.36 | 2.4 | 100 | Draw cut then two follow-ups. |
| punish | Counter Draw | stagger, move 0.3 m | M 0.104/0.1/0.36 | 2.4 | 80 | Wider parry window; fast, heavy-feeling riposte. |
| spacing | Gliding Step | none, move 3.5 m | L 0.1/0.08/0.24 | 2.4 | 60 | Low glide that resets spacing to 2.4 m. |
| crowd control | Moon Arc | stagger | M 0.176/0.1/0.36 | 3 | 180 | Wide arc that staggers a ring of small enemies. |
| payoff | Single Stroke | knockdown, move 2 m | H 0.39/0.12/0.598 | 3.2 | 40 | Long committed draw; wrecks anything it connects with. |

### Sword and Shield (`wf_sword_shield`)
Hold the ground: the shield is a verb. Every move protects someone.
- **Weapons:** 1h_sword, mace, shield, tower_shield · **Classes:** cls_guardian
- **Mobility:** Slow advance; Charge is a committed rush. · **Air:** None to speak of: shield drop-bash lands you and pins.
- **Defense:** guard (parry window 0.14 s instead of the shared 0.12 s) · **Resource rhythm:** Stamina is the resource: blocks cost it, bashes refund some.
- **Training-yard trial:** Block a wolf lunge, bash, then counter.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Shield Combo (`skl_shield_combo`) | none, move 0.3 m | L 0.11/0.08/0.24, L 0.11/0.08/0.24, M 0.16/0.1/0.36 | 2 | 100 | Sword, bash, sword; shield up between hits. |
| punish | Shield Bash (`skl_shield_bash`) | stagger, move 0.3 m | M 0.128/0.1/0.36 | 1.8 | 70 | Quick bash after a block; staggers. |
| spacing | Charge (`skl_charge`) | push, move 5 m | M 0.192/0.1/0.36 | 2 | 70 | Rush that shoves small enemies aside. |
| crowd control | Earth Stomp (`skl_earth_stomp`) | knockdown | H 0.286/0.12/0.46 | 3 | 360 | Ground stomp that pins small enemies. |
| payoff | Shield Wall (`skl_shield_wall`) | none | H 0.312/0.12/0.598 | 2 | 180 | Plant and cover allies; punishes anything that strikes the wall. |

### Spear and Polearm (`wf_polearm`)
Own the range: longest reach, safe spacing, punish at the tip.
- **Weapons:** spear, lance, halberd, glaive, naginata, trident · **Classes:** cls_lancer, cls_guardian
- **Mobility:** Vault retreats; Comet Dive covers distance in the air. · **Air:** Dragon Ascent launches and the dive slams.
- **Defense:** dodge · **Resource rhythm:** Hit at max range for bonus; hits too close lose it.
- **Training-yard trial:** Poke a goblin pack from outside their reach.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Spear Thrusts (`skl_spear_thrusts`) | none, move 0.5 m | L 0.11/0.08/0.24, L 0.11/0.08/0.24, M 0.176/0.1/0.36 | 3 | 40 | Three quick thrusts at long reach. |
| punish | Piercing Thrust (`skl_piercing_thrust`) | stagger, move 0.6 m | M 0.128/0.1/0.36 | 3.4 | 30 | Long thrust that punishes from outside the enemy reach. |
| spacing | Vault (`skl_vault`) | none, move -3 m | L 0.14/0.1/0.32 | 2.4 | 60 | Retreating vault with a launching kick. |
| crowd control | Sweep (`skl_sweep`) | push | M 0.176/0.1/0.36 | 3.2 | 200 | Wide pole sweep; keeps a ring back. |
| payoff | Dragon Ascent (`skl_dragon_ascent`) | launch, move 1 m | L 0.168/0.1/0.416 | 3 | 60 | Rising thrust that launches; long recovery if it whiffs. |

### Daggers (`wf_daggers`)
Fast, close and tricky: low reach, backstab damage, light on defense.
- **Weapons:** daggers, short_sword, throwing_knives, ritual_dagger · **Classes:** cls_rogue, cls_occultist
- **Mobility:** Shadow Step and dodge-strikes; best movement of any family. · **Air:** Quick flip stab; no juggle.
- **Defense:** dodge · **Resource rhythm:** Rewards position: behind the target hits harder.
- **Training-yard trial:** Backstab a distracted dummy and fan the knives.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Dagger Flurry (`skl_dagger_flurry`) | none, move 0.5 m | L 0.08/0.08/0.192, L 0.08/0.08/0.192, L 0.08/0.08/0.192, L 0.09/0.08/0.216, M 0.144/0.1/0.36 | 1.6 | 110 | Five quick hits at close range. |
| punish | Backstab (`skl_backstab`) | none, move 0.4 m | M 0.112/0.1/0.36 | 1.6 | 60 | Bonus damage from behind or a stagger. |
| spacing | Shadow Step (`skl_shadow_step`) | none, move 4.5 m | M 0.128/0.1/0.36 | 1.8 | 60 | Blink-step behind the target. |
| crowd control | Fan of Knives (`skl_fan_of_knives`) | stagger | M 0.16/0.1/0.36 | 6 | 180 | Ranged cone that flinches small enemies. |
| payoff | Death Lotus (`skl_death_lotus`) | knockdown, move 1 m | H 0.312/0.12/0.598 | 2.6 | 360 | Ultimate-style spin; long recovery. |

### Bow and Crossbow (`wf_bow`)
Aim and space: free-aim shots with real punish windows, never an auto-win.
- **Weapons:** shortbow, longbow, crossbow · **Classes:** cls_ranger
- **Mobility:** Backflip Shot resets spacing; strafe while drawing. · **Air:** Can shoot while air-dashing; no launch.
- **Defense:** dodge · **Resource rhythm:** Draw time against damage: hold for the charged shot.
- **Training-yard trial:** Free-aim a charged shot at a distant dummy.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Quick Shots (`skl_quick_shots`) | none | L 0.12/0.08/0.24, L 0.12/0.08/0.24, L 0.12/0.08/0.24 | 18 | 8 | Three arrows at fire rate; light damage. |
| punish | Power Shot (`skl_power_shot`) | stagger | M 0.192/0.1/0.36 | 20 | 5 | Aimed shot during a recovery; staggers. |
| spacing | Backflip Shot (`skl_backflip_shot`) | none, move -3.5 m | M 0.16/0.1/0.36 | 15 | 10 | Flip away and shoot: opens 3.5 m. |
| crowd control | Rain of Arrows (`skl_rain_of_arrows`) | slow | M 0.224/0.1/0.36 | 8 | 360 | Marked zone that slows; telegraphed. |
| payoff | Starfall Volley (`skl_starfall_volley`) | knockdown | H 0.39/0.12/0.644 | 20 | 30 | Charged ultimate volley; long vulnerable recovery. |

### Staff, Wand and Grimoire (`wf_caster_focus`)
Spell windows: cast cost time and commitment; protect it with spacing and cover.
- **Weapons:** staff, wand, grimoire, orb, bone_staff · **Classes:** cls_mage, cls_occultist, cls_cleric
- **Mobility:** Blink and short drift; cannot cast while sprinting. · **Air:** Floating cast: slow fall while channeling.
- **Defense:** dodge · **Resource rhythm:** MP; a cast window is the reward and the risk.
- **Training-yard trial:** Fire Bolt a Wind-aura dummy and watch Firestorm.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Arcane Bolts (`skl_arcane_bolts`) | none | L 0.12/0.08/0.24, L 0.12/0.08/0.24, M 0.176/0.1/0.36 | 14 | 10 | Three bolts; steady and free of MP. |
| punish | Fire Bolt (`skl_fire_bolt`) | stagger | M 0.144/0.1/0.36 | 14 | 8 | Fast single bolt; applies its element. |
| spacing | Blink (`skl_blink`) | none, move 5 m | L 0.1/0.08/0.24 | 0 | 0 | Short teleport; brief vulnerability on arrival. |
| crowd control | Frost Nova (`skl_frost_nova`) | slow | M 0.192/0.1/0.36 | 5 | 360 | Ring that slows; freezes with Water aura. |
| payoff | Fireball (`skl_fireball`) | knockdown | H 0.416/0.12/0.644 | 16 | 30 | Slow-cast area blast; the staple payoff. |

### Mace, Censer and Tome (`wf_censer_mace`)
Support melee: strikes feed the heal and ward rhythm, not the highest damage.
- **Weapons:** mace, holy_tome, censer · **Classes:** cls_cleric, cls_occultist
- **Mobility:** Slow; Sanctuary plants a ward rather than moving. · **Air:** None: grounded fighter.
- **Defense:** ally_cover · **Resource rhythm:** Strike to build; heal and ward on cooldown.
- **Training-yard trial:** Heal a wounded companion while blocking a hit.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Censer Swings (`skl_censer_swings`) | none, move 0.3 m | L 0.12/0.08/0.24, L 0.12/0.08/0.24, M 0.176/0.1/0.36 | 2 | 110 | Swinging censer: blessing smoke on each hit. |
| punish | Smite Undead (`skl_smite_undead`) | stagger | M 0.144/0.1/0.36 | 10 | 20 | Ranged smite; extra on undead. |
| spacing | Sanctuary (`skl_sanctuary`) | none | M 0.208/0.1/0.36 | 4 | 360 | Plant a ward; you hold position, allies recover. |
| crowd control | Purify (`skl_purify`) | none | M 0.192/0.1/0.36 | 4 | 360 | Clears status from allies and slows enemies in the ring. |
| payoff | Holy Light (`skl_holy_light`) | stagger | H 0.364/0.12/0.552 | 12 | 40 | Committed beam; heals allies it crosses. |

### Fists and Gauntlets (`wf_fists`)
Body as weapon: the shortest reach with the fastest hands and best counters.
- **Weapons:** fists, knuckles, gauntlets, greaves, bo_staff · **Classes:** cls_martial_artist
- **Mobility:** Flash Kick closes gaps; no weapon length to space with. · **Air:** Uppercut launcher into the best air combo.
- **Defense:** parry (parry window 0.13 s instead of the shared 0.12 s) · **Resource rhythm:** Counter Stance trades a hit for a heavy riposte.
- **Training-yard trial:** Uppercut, jump, air combo, land.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Jab Flurry (`skl_jab_flurry`) | none, move 0.4 m | L 0.08/0.08/0.192, L 0.08/0.08/0.192, L 0.09/0.08/0.216, M 0.16/0.1/0.36 | 1.6 | 100 | Short fast jabs ending in a kick. |
| punish | Counter Stance (`skl_counter_stance`) | stagger, move 0.3 m | M 0.112/0.1/0.36 | 1.6 | 90 | Brace; if hit, riposte with a heavy counter. |
| spacing | Flash Kick (`skl_flash_kick`) | none, move 3.5 m | M 0.144/0.1/0.36 | 2 | 60 | Dash kick that closes 3.5 m. |
| crowd control | Palm Blast (`skl_palm_blast`) | push | M 0.16/0.1/0.36 | 5 | 60 | Shockwave palm that pushes a lane clear. |
| payoff | Rising Uppercut (`skl_rising_uppercut`) | launch, move 0.8 m | L 0.154/0.1/0.384 | 1.8 | 70 | Heavy launcher; opens the air combo. |

### Whip and Rod (`wf_whip_rod`)
Command and control: mid reach, pull and bind; the party acts with you.
- **Weapons:** whip, rod · **Classes:** cls_tamer
- **Mobility:** Whip pulls the player toward anchors; moderate. · **Air:** Whip swings from marked anchors; no launch.
- **Defense:** ally_cover · **Resource rhythm:** Unison Attack with a companion is the payoff.
- **Training-yard trial:** Pull a target into a companion strike.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Whip Lashes (`skl_whip_lashes`) | none, move 0.2 m | L 0.11/0.08/0.24, L 0.11/0.08/0.24, M 0.176/0.1/0.36 | 3 | 40 | Three snappy lashes at mid reach. |
| punish | Command (`skl_command`) | none | L 0.1/0.08/0.24 | 6 | 40 | Order a companion to strike the exposed target. |
| spacing | Swap (`skl_swap`) | none | L 0.1/0.08/0.24 | 5 | 0 | Swap places with a companion; you reposition at once. |
| crowd control | Rally (`skl_rally`) | none | M 0.176/0.1/0.36 | 6 | 360 | Calls the team into position; no damage. |
| payoff | Unison Attack (`skl_unison_attack`) | knockdown | H 0.338/0.12/0.552 | 3 | 90 | Coordinated strike with a companion. |

### Instruments (`wf_instrument`)
Rhythm as combat: timed beats make songs stronger; fair to miss, rewarding to land.
- **Weapons:** flute, bell, lute, harp, war_drum, violin_blade · **Classes:** cls_bard, cls_tamer
- **Mobility:** Plays on the move; no dash of its own. · **Air:** Floats while playing.
- **Defense:** ally_cover · **Resource rhythm:** Songs have a beat window; on-beat inputs add power.
- **Training-yard trial:** Play Ballad of Courage on beat for a stronger buff.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Chord Strikes (`skl_chord_strikes`) | none | L 0.11/0.08/0.24, L 0.11/0.08/0.24, M 0.176/0.1/0.36 | 2 | 100 | Instrument strikes with a note on each hit. |
| punish | Sour Note (`skl_sour_note`) | stagger | M 0.144/0.1/0.36 | 10 | 30 | Ranged discord that staggers. |
| spacing | Song of Swiftness (`skl_song_of_swiftness`) | none | L 0.1/0.08/0.24 | 6 | 360 | Speed buff: spacing through movement speed. |
| crowd control | Lullaby (`skl_lullaby`) | bind | M 0.208/0.1/0.36 | 8 | 360 | Sleep that breaks on damage. |
| payoff | Grand Finale (`skl_grand_finale`) | knockdown | H 0.39/0.12/0.69 | 8 | 360 | Ultimate; long recovery. |

### Hammer and Tools (`wf_workshop`)
Heavy tools, utility on the side: slow but sturdy, with traps and turrets.
- **Weapons:** hammer, wrench, tool_staff, throwables · **Classes:** cls_artisan
- **Mobility:** Short forward swing; turrets anchor the ground. · **Air:** Overhead slam only.
- **Defense:** guard · **Resource rhythm:** Deployables carry the fight while you hit.
- **Training-yard trial:** Plant a turret then hammer a staggered target.

| Role | Move | Control | Hits (weight startup/active/recovery s) | Reach m | Arc | Note |
|---|---|---|---|---|---|---|
| opener | Hammer Strikes (`skl_hammer_strikes`) | none, move 0.5 m | M 0.16/0.1/0.36, M 0.16/0.1/0.36, H 0.26/0.12/0.46 | 2 | 110 | Three slower swings. |
| punish | Masterwork Strike (`skl_masterwork_strike`) | stagger, move 0.3 m | M 0.144/0.1/0.36 | 2.1 | 90 | Hit with a built-up swing. |
| spacing | Deploy Turret (`skl_deploy_turret`) | none | M 0.192/0.1/0.36 | 8 | 90 | Turret holds a lane while you reposition. |
| crowd control | Bomb Toss (`skl_bomb_toss`) | knockdown | M 0.208/0.1/0.36 | 8 | 360 | Thrown bomb; area knockdown. |
| payoff | Grand Invention (`skl_grand_invention`) | knockdown | H 0.416/0.12/0.69 | 4 | 360 | Ultimate area payoff. |

## Fun-test checklist (adds to combat.md section 12)
- [ ] After 2 minutes in the training yard a player can say which weapon is which by rhythm alone (reach, commitment, mobility), without reading numbers.
- [ ] Every family has a move that feels safe at the right spacing and a move that feels risky; no family is strictly best.
- [ ] A slow payoff (greatsword Earthsplitter, katana Single Stroke) feels like a decision: it lands big when read, and it is punishable when whiffed.
- [ ] Fast families (twin blades, daggers, fists) do not out-damage heavy ones per second of exposure.
- [ ] The five-role set of one family can be learned in one short trial.
- [ ] No weapon makes a boss fight trivial by staying out of reach (polearm and bow must still be punished by boss gap-closers).

## Decisions (user can overrule)
- **14 families, not 12 classes:** weapons that share a rhythm are one family (all polearms; all instruments), and classes that share a weapon share a family (cleric and occultist censer; mage and occultist focus).
- **Katana and sword-and-shield get wider parry windows (0.16 s and 0.14 s)** as the identity of a parry weapon; values stay within 0.08-0.2 s in the schema and are tuned against `parry.parryWindowSec` 0.12.
- **No new damage numbers here:** power per hit stays in the class kit data (`classes.json`); this file only specifies timing, reach and control, so it cannot desync damage balance.

## Hand-offs
- **gameplay-engineer:** read `weapon_movesets.json` for `AttackTiming` per family instead of the single global table (field names above).
- **class-skill-designer:** write kit entries for the three families without `skillId` (greatsword, twin blades, katana).
- **core-rules-engineer:** an optional `WeaponMovesets` loader and a test that pins hit weights to `attackTiming` baselines.
