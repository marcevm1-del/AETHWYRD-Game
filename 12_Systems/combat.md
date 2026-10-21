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
