# 12a — Combat Design Spec (Ring 0 target)

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
