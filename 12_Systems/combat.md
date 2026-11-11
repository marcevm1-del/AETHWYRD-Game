# 12a — Combat Design Spec (Ring 0 target)

**Weapon movesets:** see [weapon_movesets.md](weapon_movesets.md) (data: `Data/Combat/weapon_movesets.json`).

**Goal:** anime combat that is **fluid, fast, flashy and heavy** (Canon). Every number marked ⚙ lives in `Data/Combat/combat_tuning.json`, so feel can be tuned without code changes.

**Feel references:** *Genshin Impact* (readability, elemental reactions), *Devil May Cry* (combo freedom, style meter), *Monster Hunter* (weight, telegraphs), *Sekiro* (parry satisfaction), anime fight choreography (impact frames, speed lines, smears).

---

## 1. The Four Feel Pillars → Concrete Rules
| Pillar | Rule | How it's achieved |
|---|---|---|
| **Fluid** | You're never stuck in an animation you didn't choose | Every attack has a **dodge-cancel window**; inputs are buffered ⚙ `inputBufferSec` |
| **Fast** | Base movement and attacks are quicker than realistic | High run speed ⚙, short attack startup, air dash, launchers |
| **Heavy** | Every hit *lands* | **Hit-stop** (freeze frames) scaled by attack weight, camera shake, knockback, impact VFX, low-frequency sound |
| **Flashy** | Big moments look like an anime cut | Ultimate cut-ins, speed lines, impact frames (1-frame white/black flash), elemental trails |

## 2. Camera
| Mode | Behavior |
|---|---|
| **Free camera** (default) | Third-person orbit, distance ⚙ `camera.distance`, FOV ⚙ `camera.fov`; auto-pulls back when 3+ enemies are near |
| **Lock-on** (toggle, R3 / middle mouse) | Camera frames you + target; attacks track the target; flick the right stick to switch targets |
| **Free aim** (hold LT / right mouse) | Over-the-shoulder reticle for bows, spells and throws; works in or out of lock-on |
| **Cinematic** | Ultimates and finishers play a 1–2.5 s camera sequence (skippable in settings) |
- Soft targeting without lock-on: attacks snap toward the enemy nearest the stick direction within ⚙ `softLockAngleDeg`.
- Camera shake is capped and has an accessibility slider.

## 3. Movement
| Action | Spec |
|---|---|
| Walk / Run / Sprint | ⚙ `walkSpeed`, `runSpeed`, `sprintSpeed` (sprint costs stamina) |
| Jump | Single jump; double jump unlocks via Wind skills or race |
| **Dodge** | Short dash with **invincibility frames** ⚙ `dodge.iframeSec` inside ⚙ `dodge.durationSec`; costs ⚙ stamina; can chain twice |
| **Perfect dodge** | Dodging within ⚙ `perfectDodgeWindowSec` before a hit lands triggers **Flash Time**: world slows to ⚙ 25% for ⚙ 0.8 s, with a blue afterimage |
| Air dash | One per jump |
| Climb (Ring 0) | Ledge grab + mantle only; full climbing in Ring 1 |

## 4. Attack Framework
### 4.1 Combo grammar (weapon-agnostic; each weapon has its own animations)
```
L   L   L   L              → 4-hit ground chain (finisher knocks back)
L   L   H                  → LAUNCHER (enemy goes airborne; you can jump-cancel after it)
(air) L  L  L  H           → air chain → SLAM (bounces the enemy, small AoE)
H (hold)                   → CHARGED heavy: 3 charge levels ⚙, guard-break at level 2+
Dodge → L                  → dash strike (closes distance)
Perfect dodge → L          → counter flurry during Flash Time
Skill → Skill              → skill-cancel (costs 1 Combo Budget point)
```
- **Combo Budget:** 3 skill-cancels per airtime/ground string ⚙, refilled on landing or after 2 s. Keeps combos expressive but not infinite.
- **Cancel windows:** each attack has `startup → active → recovery`; dodge-cancel allowed from active frame 1; skill-cancel from the hit frame.

### 4.2 Hit weight & hit-stop
| Weight | Examples | Hit-stop (attacker + target) | Shake | Reaction |
|---|---|---|---|---|
| Light | L1–L3, nibble | ⚙ 0.04 s | none | Flinch |
| Medium | L4, dash strike | ⚙ 0.07 s | small | Stagger |
| Heavy | charged H, slam | ⚙ 0.11 s | medium | Knockback / knockdown |
| Launch | launcher | ⚙ 0.08 s | small | Airborne |
| Ultimate | Ultimate, finishers | ⚙ 0.18 s + impact frame | large | Big knockback |

### 4.3 Enemy reactions & Poise
- Every enemy has **Poise** ⚙ per rig. Hits deplete poise; at 0 it **staggers** (open to bonus damage) and poise refills.
- **Bosses** have a separate **Break gauge**. Breaking it knocks them down for ⚙ 4 s, and Union Skills can be triggered during a break (Ring 1+).
- Small enemies can be launched; large rigs (`large_biped`, `golem`, `dragon`) can only be launched while staggered.

## 5. Defense
| Action | Spec |
|---|---|
| Block (shield classes, some weapons) | Reduces damage ⚙ 70%; drains stamina |
| **Parry** | Press block within ⚙ `parryWindowSec` of a **blue** attack → enemy stagger + **Riposte** prompt (heavy counter, big hit-stop) |
| Perfect dodge | See Flash Time |

### Telegraph colors (shared by every monster; `telegraph` in `Data/Monsters/attacks.json`)
| Color | Meaning | Answer |
|---|---|---|
| **Blue** flash | Parryable | Parry or dodge |
| **Red** flash | Unblockable | Dodge only |
| **Gold** flash | Grab | Dodge or interrupt with a heavy |
| None | Weak/chip attack | Anything |

## 6. Skills, Resources & Ultimates
- **4 skill slots** (6 at B, 8 at S), each with a cooldown and an MP/SP cost from the class data.
- **Awakening meter** fills from dealing/taking damage and Style Rank. At 100% you can trigger your **Ultimate** (cinematic) or **Awakening mode** (Ring 1+: aura, faster attacks, music swells).
- **Ring 0 kit (Swordsman):** Slash Chain, Rising Cut (launcher skill), Flash Step (dash-slash), Air Slash (ranged wave), Ultimate: *Thousand Petal Blade*.

## 7. Elements & Reactions
Attacks apply an **element aura** to the target for ⚙ 6 s. Hitting an aura with a second element triggers a **Reaction**:
| Aura + Trigger | Reaction | Effect |
|---|---|---|
| Fire + Wind | **Firestorm** | Spreading fire tornado (AoE DoT) |
| Water + Lightning | **Storm Prison** | Chain shock + brief stun |
| Water + Ice | **Freeze** | Target frozen; next heavy **shatters** for bonus damage |
| Fire + Ice | **Thermal Shock** | Big burst damage, removes both auras |
| Earth + Fire | **Magma** | Molten ground hazard |
| Wind + any element | **Swirl** | Spreads that element's aura to nearby enemies |
| Nature + Fire | **Wildfire** | Burn spreads through grass (world interaction) |
| Light + Dark | **Twilight Burst** | Huge single-target damage (rare, late-game) |
| Poison + Fire | **Miasma Blast** | Explosion that leaves poison fog |
| Lightning + Earth | **Grounded** | Lightning damage absorbed, target slowed |
**Ring 0 includes:** Fire + Wind = Firestorm (a thrown **Fire Bomb** consumable applies Fire; the Swordsman's *Air Slash* applies Wind).

### 7a. Reaction table (data-driven, Wave A2)
The ten pairs above now live in `Data/Combat/reactions.json` so feel can be tuned without code. With no table loaded the game behaves exactly as before.
- Each reaction lists its two elements (order does not matter), whether it **consumes the aura** (all do except Swirl), an optional **bonus damage multiplier**, and optional **DoT**, **hazard zone** and **status** (freeze or stun).
- **Parity (matches today):** the pairs, aura consumption, Freeze 2.5 s and Storm Prison 1.2 s (copied from ⚙ `reactions`; a test keeps them equal), and the Firestorm zone (⚙ `firestorm`).
- **Proposals (user tunes):** bonus multipliers (Thermal Shock x2.0 (pinned by the sandbox tests), Twilight Burst x4.5, Miasma Blast x1.6, Firestorm x1.5 and so on), Wildfire's burn DoT, the Magma and Miasma ground zones, and all Swirl spread numbers.
- **Balance pass (2026-11):** a reaction's *extra value* is the damage beyond a plain hit for one target, in multiples of that hit: bonus above 1, plus DoT and hazard damage over their duration, plus the Freeze shatter bonus, plus Swirl's spread. Before the pass the rare late-game **Twilight Burst was the weakest damage reaction (1.5)** and Thermal Shock stays at 1.0 extra (its x2.0 is pinned by `CombatSandboxTests`; the pass did not touch it). After: Firestorm 3.3, Twilight Burst 3.5, Magma 2.7, Miasma Blast 2.6, Thermal Shock 1.0, Wildfire 1.8, Swirl 1.5 (area), Freeze 0.8, Storm Prison 0.2 plus its 1.2 s stun, Grounded -0.2 (a deliberate absorb). Rules kept by `Tools/validate/reaction_balance.js` (run it alone to print the table): Twilight Burst is the largest, every reaction but Grounded is worth at least 0.2, no synergy exceeds x1.5. Firestorm's numbers stay at parity with `combat_tuning.json`. Setup cost still matters: Fire + Wind is Ring 0, the others need a second element a class unlocks later, so the cheap, early reactions stay below the late one.
- **Open (not done):** Grounded's *slow* and a boss status-resist field have no data keys yet (the schema has only freeze and stun); proposal for the core-rules-engineer and the user.
- **Swirl** (table `swirl`; stored under Wind + Fire, but as in the table above Wind with any other element triggers it): Wind meeting a non-Wind element spreads that element to up to 3 neighbours within 5 m at x0.5 damage; the aura is kept.
- **Readability:** every hazard is a marked ground zone with a visible edge and a countdown, never an instant kill; the UI shows aura, trigger and remaining time (section 15).

### 7b. Reaction synergies
A **synergy** is a bonus when a second reaction fires on the same target within a short window of the first. They are separate records, not new reactions. Six proposals ship in the table:
| Synergy | First, then | Window | Bonus |
|---|---|---|---|
| Fanned Flames | Swirl, Firestorm | 4 s | x1.25 |
| Thaw Burst | Freeze, Thermal Shock | 3 s | x1.4 |
| Soaked Circuit | Freeze, Storm Prison | 3 s | x1.3 |
| Scorched Earth | Magma, Wildfire | 5 s | x1.2 |
| Miasma Ignition | Miasma Blast, Firestorm | 4 s | x1.25 |
| Storm Ground | Storm Prison, Grounded | 3 s | x1.2 |

Rules: bonuses do not stack with each other (the best one applies); a synergy never needs more than elements the player already uses; the HUD flashes the synergy name once.

### 7c. Boss armor and break
Bosses may carry an **armor gauge** (`Data/Monsters/boss_weakpoints.json`, `armor`). It is separate from the Break gauge (section 4.3): hits fill armor damage first; at zero the armor **breaks** for `breakSec`, during which the boss takes `damageTakenMultWhileBroken` more damage. After `regenDelaySec` without armor damage it regenerates. A break always has a sound cue and a visible crack; it is a reward window, never a requirement. No mandatory fight needs a break to be won (Canon combat/readability contract).

### 7d. Weak points
A weak point is a named body part (`bodyPart` from the rig hurtboxes) with its own damage multiplier and armor-damage multiplier, **exposed only in listed phases** (`exposedInPhases`, optionally for `exposedSec`). Exposure is announced: the part glows or the boss turns to show it, and the lock-on reticle gets a marker. The multiplier replaces the hurtbox multiplier for that part while exposed. Grukk has the starter record: the **cult-rune brand** on his chest, exposed in the Archers and Rage phases (x1.5 damage, x1.5 armor damage). Phases themselves stay in `boss_phases.json`. Six bosses now have records (Grukk, Ashgrave, Mother Webcrawler, Mycelia, the Drowned Choir, the Hollow Abbot); see `08_Bestiary/bosses_and_calamities.md` section 1.

### 7e. Combat sandbox (dev tool)
A headless **combat sandbox** spawns up to ⚙ `sandbox.maxDummies` dummies (species, element, HP, optional armor), applies scripted hits (element, weight, body part, attacker) on a manual clock and returns a readout per hit: damage, multiplier breakdown, reaction, synergy, armor and break state. It is deterministic (seeded, ⚙ `sandbox.defaultSeed`) and used by tests and the designer to judge reactions and armor without playing. It is a developer tool: no menu, no game mode, not shipped to players.

## 8. Style Rank
| Rank | Points needed ⚙ | Bonus |
|---|---|---|
| C | 0 | — |
| B | 100 | +5% XP |
| A | 250 | +10% XP, +5% drop rate |
| S | 450 | +15% XP, music adds a layer |
| SS | 700 | +20% XP, +10% drop rate |
| SSS | 1,000 | +30% XP, vocal chorus kicks in |
- **Base points per hit** ⚙ `style.hitPoints`: light 10 · medium 15 · heavy 25 · launch 20 · skill 20 · ultimate 80.
- **Gain:** varied hits (a new move type in the last 6 hits ⚙ ×1.5), reactions (+40), perfect dodges (+60), parries (+60), launch-to-slam (+50).
- **Loss:** points decay ⚙ 20/s after 2 s idle; **getting hit drops one full rank**; repeating the same move 4+ times in a row gives half points.
- The **Style meter matches the rank theme** (C→SSS), and it drives music intensity (see `13_Production/opening_music_and_memories.md`).

## 9. Damage Formula
```
physical = ATK × power × (100 / (100 + DEF)) × elementMult × critMult × variance(0.95–1.05)
magical  = MATK × power × (100 / (100 + MDEF)) × elementMult × critMult × variance
elementMult: weakness 1.5 · resist 0.5 · neutral 1.0 · reaction bonus per §7
critMult:   1.5 base (+ crit damage stats); crit chance from DEX
Backstab/stealth opener: ×2 (Rogue line ×2.5)
```
`power` comes from the attack's entry in `Data/Monsters/attacks.json` (monsters) or the skill data (player).

## 10. Monster AI (Ring 0 set)
AI patterns come from `aiPattern` in species data. Each monster's turn: **pick an attack from `attackIds` by range and cooldown → telegraph → strike → recovery (the player's punish window)**.
| Ring 0 monster | Pattern | Signature behavior |
|---|---|---|
| **Blue Slime** (F) | territorial_guard | Bounces toward you when you near its puddle; **Engulf** (gold grab) if you stand still; splits on death at higher tiers |
| **Goblin** (F) | pack_flank (Menace 3) | Groups of 3–5 circle you, one attacks while others feint; throws junk from range; flees at low HP to call more |
| **Horned Rabbit** (F) | skittish_flee | Runs, then **Charge** (red, unblockable) when cornered; the classic rookie killer |
- **Aggro token system:** at most ⚙ 2 enemies attack at once; others reposition or taunt (keeps big groups fair and cinematic).

### 10a. Group tactics (symmetric peers)
Packs fight smarter without any monster being in charge. Numbers: ⚙ `groupTactics` in `combat_tuning.json`. **Hard rules (Canon 4d):** no leader, captain, commander or rank among monsters; no learning or adapting to the player; nothing is remembered between fights or about the player. Every monster runs the same rules from the same inputs.
- **Flank slots:** each repositioning pack member is given one of ⚙ 3 angular slots (2 to 4 allowed) around the target, spread over a ⚙ 240 degree arc at ⚙ 4.5 m, assigned in a fixed member order (sorted by id, which is arbitrary and carries no rank) and reassigned every ⚙ 1.5 s. Players see enemies come from several sides, but never more than ⚙ `ai.maxSimultaneousAttackers` attack at once.
- **Threat read:** each monster scores risk to itself from the player's HP fraction, how outnumbered it is and its own HP (weights 0.4 / 0.35 / 0.25). Above ⚙ 0.6 it fights cautiously (keeps range, feints); below ⚙ 0.3 it presses. No history is kept; the score is recomputed every tick.
- **Retreat:** a pack member retreats at ⚙ 30% HP; a monster with no packmates nearby retreats at ⚙ 50% (today's rule). It rejoins after recovering to ⚙ 60% or after ⚙ 4 s. Retreat is visible, giving the player a choice to chase or not (section 14).
- **Yield:** a repositioning monster gives its slot or aggro token to a peer who is healthier by ⚙ 20% HP, holds the yield for ⚙ 1.5 s and will not yield again for ⚙ 3 s. Symmetric: any peer can yield to any other.
- **Archetypes:** the upgrade-v5 archetypes are expressed through existing `aiPattern` values; "Commander" is not used (Canon 4d) and "Shapeshifter" stays a boss-phase matter.
Unity wiring is a later wave; until then this is exercised by Core tests only.

## 11. Feedback Checklist (every hit must have)
1. Hit-stop · 2. Hit flash on the target (1 frame white) · 3. Impact VFX at the contact point · 4. Sound (layered: whoosh + impact + material) · 5. Damage number (toggleable) · 6. Reaction animation · 7. Controller rumble.

## 12. Ring 0 "Is It Fun?" Test
Ring 0 passes when, in a 10-minute session against slimes, goblins and rabbits:
- [ ] A new player can do the L-L-H launcher → air chain → slam within 5 minutes without reading anything.
- [ ] Perfect dodge and parry feel *rewarding* (players try to do them on purpose).
- [ ] A goblin pack of 5 feels dangerous at level 1 and trivial at level 10.
- [ ] Firestorm makes people say "whoa."
- [ ] Reaching S Style Rank feels earned and fun.
- [ ] Nothing feels floaty: every hit has weight.
- [ ] Wave A2: a Swirl-then-Firestorm opener makes you feel clever, and the synergy flash is readable.
- [ ] Breaking Grukk's armor feels like a payoff you noticed (sound plus crack), and fighting without it is still fair.
- [ ] You can tell when Grukk's rune brand is exposed without being told.
- [ ] Each of the five dungeon bosses above has one weak point you can find by watching it (glow, turn or posture), and a fight that ignores armor entirely is still winnable.
- [ ] Armor breaks arrive about once per fight for a player who hits heavy and weak, never twice in quick succession.
- [ ] A goblin pack comes from several sides, retreats visibly at low HP, and never feels like a boss goblin is giving orders.

**Where the fight lives (built).** Monsters stay in the forest and beyond; the town is safe ground.
- **Town ward** (`TownWard`): a box over Brindlewick (with its new quarter and farmstead), Millbrook's fields and the treeline camp (x −75…75, z −98…33). The field's own monsters don't notice you inside it, break off a chase when you step back in, and never walk across its edge. Monsters brought in on purpose ignore it: siege raiders, escort ambushes and defence-event raids (anything `MonsterSpawner.Spawn` creates). Core rule: `AiSense.TargetWarded`.
- **Ring 0's level-3 camps** sit just past the treeline:
  - 3 blue slimes at **Millbrook's old well** (26, 40), for "Slime in the Well";
  - the **goblin pack of 5** by the Old Watchtower (−22, 46);
  - 2 horned rabbits in the **east meadow** beyond the trees (48, 34), for "Rabbit Season".
- **Whisperwood's camps** get harder the deeper you go:
  - level 8 through the middle of the wood, with passive grazers (sheep, tortoise) in the meadows beyond its flanks;
  - level 13 deep in, each at least 24 m from Grukk's clearing so a fight there doesn't pull the tyrant.
- **Spacing:** camps are spaced so their alert circles don't chain, and a fight with one camp doesn't wake the next.

## 13. Combat Readability and Player Choice

The action should feel expressive without requiring the player to decode a wall of effects. Every dangerous action needs a readable **source → tell → active moment → recovery**. The tell may use color, silhouette, sound and movement together; color alone is never enough. Camera shake, impact flashes and effects must leave the enemy and player visible during the decision window.

### The response ladder

Give each attack a sensible set of answers, ordered from broadest to most demanding:

1. **Leave the danger area:** move out of range or out of the marked zone.
2. **Dodge:** use invulnerability and direction to avoid a committed strike.
3. **Guard:** absorb a supported attack at a stamina cost.
4. **Parry:** use timing for a higher-reward stagger or riposte.
5. **Interrupt:** use a heavy, skill or companion action when the attack permits it.
6. **Prevent:** use knowledge, terrain, element, stealth or preparation to stop the setup.

Not every attack supports every answer. The enemy must signal the correct subset. No mandatory story boss should require the top timing tier; advanced play can improve speed, safety or style, but ordinary play has a valid route through readable movement and defense.

### Targeting and camera responsibilities

Lock-on answers “which enemy am I committing to?” Free aim answers “where exactly do I want this effect to land?” Soft targeting should reduce accidental misses without taking control away from the player. The current mode must be obvious in the reticle and camera response.

When multiple enemies occupy the screen, maintain a clear visual hierarchy: the active target, the nearest imminent threat and the player’s current recovery state. Offscreen threats need a restrained direction cue and a sound source; do not solve them with constant camera snaps. Large enemy attacks should not be hidden by the boss’s own body or by the player’s effects.

### Weapon identity as rhythm

Weapons differ through the complete rhythm, not a damage multiplier alone:

- **Reach:** how soon the player can connect and where the safe spacing sits.
- **Commitment:** how long an attack occupies the player and how much recovery it carries.
- **Control:** whether it interrupts, launches, pushes, pulls, binds or breaks guard.
- **Mobility:** whether an attack advances, retreats, turns or holds ground.
- **Air behavior:** how it launches, juggles or returns the player to the ground.
- **Defense interaction:** whether it blocks, parries, deflects, dodges or protects allies.
- **Resource rhythm:** whether it rewards steady combos, charged commitment, spell windows or precise counters.

For each weapon family, author one simple opener, one reliable punish, one mobility or spacing option, one crowd-control option and one high-commitment payoff. A player should be able to identify a weapon’s rhythm after a short training-room trial before spending rare upgrade materials.

### A mastery ladder, not a parry gate

- **Entry:** ordinary chain, dodge and heal; the player can defeat common threats.
- **Learning:** recognize one telegraph and punish one recovery.
- **Fluency:** combine dodge, guard, spacing and skill use with weapon identity.
- **Expression:** vary strings, use reactions, air routes, companion arts and environment.
- **Mastery:** optimize boss openings, style score and risk without making lower tiers invalid.

This ladder defines what combat should teach, not a mandatory tutorial sequence. Players can learn through a training yard, journal clips, companion remarks or a low-stakes encounter. Turn off tutorial reminders after a skill is demonstrated.

## 14. Encounter Grammar

Common fights should be short enough to preserve exploration flow, while elites and bosses earn longer attention through new decisions. Length is a tuning outcome, not a hard promise for every enemy. Scale pressure through **behavioral combinations**, not only larger health bars.

### Common encounter

One enemy or a small group demonstrates a readable behavior. The player can finish quickly with basic attacks, but can also practice a counter. Avoid stacking multiple unblockable attacks or status effects before the player has seen their tells.

### Pack encounter

Members have simple roles—flanker, ranged pest, defender or caller—so the player can choose a priority. Aggro tokens limit simultaneous high-pressure attacks. When a creature retreats to call help, give the player a visible chance to stop it or choose not to pursue.

### Elite encounter

An elite changes one expected rule: a familiar attack has a delayed follow-up, a creature guards a weak side, or weather changes its movement. Introduce the change with evidence or a distinctive tell. Keep at least one familiar opening so the player can apply existing knowledge.

### Boss encounter

A boss is a conversation through action: it presents a pattern, the player tests a hypothesis, then the fight confirms or corrects it. Prepare with a distinct silhouette, phase language, attack families, recovery windows, arena affordances and a clear defeat state. Phases should add or combine verbs, not merely increase speed and damage.

Before an optional boss, display rank suitability and the known warning signs. Do not forbid an early challenge; communicate that it may be punishing and preserve a retreat path when fiction permits. A boss’s health, damage, poise and status resistance are tuned separately so one number does not make the encounter feel unfair.

## 15. Reactions and Environmental Payoff

Elemental reactions should reward setup and recognition. The UI records which element is present and what trigger caused the reaction; the visual effect communicates area and duration; audio marks activation without masking enemy telegraphs.

Environmental reactions need clear boundaries. Fire can spread through authored dry grass, not every green surface. Water can conduct lightning only in readable volumes. Ice can create a temporary hazard or frozen target, but should not trap the player in an unavoidable loop. Use a small number of predictable material classes before expanding interactions across all regions.

When a reaction causes a status, show the remaining time or condition and the valid counter. Freeze lasts for its configured duration and a heavy strike shatters it for the configured bonus; Storm Prison uses its configured brief stun. Bosses can resist or shorten a status, but communicate that resistance through a visible effect and data field rather than silently ignoring the player’s setup.

## 16. Companion Actions and Party Fairness

Companions are AI-controlled allies. The player can issue brief tactical intent—focus, hold, defend, use a skill or regroup—without switching to their character. The command wheel pauses or slows combat only if the selected mode says so, and every command has a clear acknowledgment.

Companions contribute by filling a role, creating an opening, defending the player, applying a reaction or responding to a known enemy behavior. They must not make ordinary enemies impossible to read through overlapping effects. If a companion’s action interrupts a boss, the boss’s state and the reward window are visible to both player and party.

Party investment should never be a hidden difficulty tax. Companions can provide advantages, but the player’s own defense, healing, recovery and damage must remain viable. Canon §5 governs mortality; ordinary combat failure does not permanently kill a companion unless the player deliberately enables the opt-in rule.

## 17. Fight Review and Tuning

For each test fight, record:

- time from first threat cue to first player decision;
- attacks seen, recognized and successfully answered;
- hits taken by source and whether the tell was visible;
- player movement, camera mode and target-switch errors;
- combo variety and whether the weapon’s identity appeared;
- companion actions and whether they helped or obscured;
- recovery time after a mistake and the player’s understanding of why it happened;
- whether the fight felt exciting, fair, repetitive, noisy or exhausting.

Do not optimize for raw damage-per-second alone. A fast kill can still feel empty; a difficult fight can still feel fair. If players take damage without knowing why, improve signaling before reducing enemy damage. If they understand the fight but cannot recover from a single mistake, add a recovery window, clearer healing opportunity or tuning option.

### Playtest matrix

Test each early encounter with at least these approaches: dodge-focused, guard-focused, parry-focused, ranged/free-aim, low-APM/accessibility assists, and an under-level or under-equipped challenge. The target is not identical speed; it is that each reasonable approach has an intelligible success path and the encounter expresses its intended fantasy.

Record settings alongside results. Difficulty, timing assists, camera shake, damage numbers and tutorial prompts change the experience; comparisons without those details are not useful.
