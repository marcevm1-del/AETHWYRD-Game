# 12b — HUD & UI Design

**Look (Canon):** the classic anime **System window**: translucent blue-glass panels, thin glowing borders, angled corners, small filigree, a crisp sans-serif body font and a fantasy display font for headers. Pop-ups burst in with runes and soft chimes. **Minimal HUD while exploring, expanded HUD in combat.** Target readability: Steam Deck at 1280×800.

Two layers of UI live side by side:
| Layer | What it is | Look |
|---|---|---|
| **System UI** | What the System shows your character (Status, notifications, appraisal) | Blue glass, runes, chimes. **It can lie** (see §13) |
| **World UI** | Things that exist in the world (guild card, map, journal, letters, wanted posters) | Paper, wood, metal, ink, wax seals |

---

## 1. Rank Colors (used everywhere: cards, monsters, quests, loot, zones)
| Rank | Color | Card material | Frame effect |
|---|---|---|---|
| F | Ash grey | Oak wood | None |
| E | Copper orange | Copper | None |
| D | Leaf green | Iron | Thin shine |
| C | Sky blue | Silver | Shine sweep |
| B | Royal purple | Gold | Soft glow |
| A | Crimson | Platinum | Pulsing glow |
| S | Mithril cyan | Mithril | Floating motes |
| SS | Black with red veins | Adamantite | Heat-haze edges |
| SSS | Starlight gold | Starcard | Slowly turning constellation |
| EX | Shifting prismatic / void | — | The frame glitches |
Sub-grades: **−** dim, **+** a small star after the letter (C★).

## 2. HUD Presets
| Preset | For | Shows |
|---|---|---|
| **Immersive** | Explorers, screenshots | Nothing until needed. Health shows as screen-edge wear, quests as glowing footprints, enemies' rank as aura color |
| **Standard** (default) | Most players | The layout below |
| **Full Data** | Min-maxers | Exact numbers, DPS meter, buff timers, reaction log, enemy stats after appraisal |
Every element can also be toggled, moved and scaled on its own (HUD editor).

## 3. Exploration HUD (Standard)
```
┌──────────────────────────────────────────────────────────────────┐
│        ◂ N ── ⚑ ─── ✦ ─── E ── ☠C ── S ▸        ☾◐ Maelsday·Dusk │  compass + moon/day dial
│                                                       ⚔ SIEGE: 2d │  siege warning (if Besieged)
│                                                                  │
│                                              ▸ Moonbloom Picking │  quest tracker (max 3)
│                                                 Herbs 4/6        │
│                                                                  │
│ ◉ Lyra  ◉ Kiri  ◉ Mochi                    [System] Skill up!    │  companions · notification feed
│ ▰▰▰▰▰▰▰▰▱▱ HP   ▰▰▰▰▱ MP   ▰▰▰▰▰ SP           Rank F · Lv 9     │  bars fade out at full
└──────────────────────────────────────────────────────────────────┘
```
- **Compass bar:** quest markers, discovered places, **rank-colored danger icons** (☠ + rank letter) for nearby threats, and a **"?" shimmer** for undiscovered secrets within 50 m (toggleable).
- **Moon & day dial:** Lumen and Vesper phases, the weekday's god icon, the time of day. It turns red before a **Blood Vesper**.
- **Bars fade** when full and out of combat. Stamina is a ring around the crosshair while sprinting or climbing.
- **Discovery pop-up:** new places get an anime-style **location title card** (name in the display font, the region's rank band, a one-line poem).
- **Postcard moments:** at planned vistas the HUD fades and the camera eases into a framed shot. One button saves it to the Memory Reel.

## 4. Combat HUD
```
┌──────────────────────────────────────────────────────────────────┐
│  [F+] GOBLIN ARCHER  👁👁👁   🔥            STYLE              │  target: rank · menace eyes · aura
│  ▰▰▰▰▰▰▰▱▱▱   poise ▰▰▱                      ▶ A ◀  ▰▰▰▱       │  HP · poise   |   Style Rank meter
│                                                                  │
│                    ⟨ FIRESTORM!! ⟩                               │  reaction callout
│                         ✕  ← lock-on reticle                     │
│                                                                  │
│ ◉Lyra ▰▰▰▱ [Union ready]                ◆◆◇ combo budget         │
│ HP ▰▰▰▰▰▰▱▱▱  MP ▰▰▰  SP ▰▰▰▰       [Q]Slash [E]Rise [R]Step [F]Wave │
│ AWAKENING ▰▰▰▰▰▰▰▱▱▱ 72%                     ✧ ULT ready ✧       │
└──────────────────────────────────────────────────────────────────┘
```
- **Target frame:** rank badge, name, **Menace eyes** (1–5 eye icons, from "cute" to "horror"), current element aura, HP and poise. The details depend on your **Appraisal level** (§9).
- **Telegraphs:** blue, red and gold flashes on the enemy, **plus shapes for colorblind players**: circle = parryable, triangle = unblockable, square = grab.
- **Style Rank meter:** letters **slam in** with a sound sting (C → SSS, matching the rank colors). At S the music adds a layer. At SSS the letters burn gold and a chorus joins.
- **Reaction callouts:** big anime text (*FIRESTORM!!*, *SHATTER!*) with speed lines, kept short so they don't block the view.
- **Damage numbers:** styles to choose from (classic, anime brush, minimal, off). Crits get a burst; weaknesses get the element icon.
- **Low HP:** the screen edge desaturates, a heartbeat plays, and your character's pose changes. No flashing red.
- **Flash Time:** the world turns blue-grey, an afterimage trails behind you, and a soft "tick-tock" plays.
- **Companion strip:** HP and a "Union ready" glow. The **command wheel** (hold) has *Focus my target · Defend me · Go wild · Heal · Fall back · Union Skill*.

## 5. Boss HUD
- **Boss title card** (anime intro freeze-frame): name, epithet, rank in its color, a calligraphy rune, and a 1-second music hit. *「 TAURGRIM — The Maze King · S 」*
- **Multi-bar HP** (layers in rank colors), a **Break gauge** under it, and **phase pips**.
- **Boss Suitability badge** (from the bestiary): *Good match · Hard · Deadly · Suicide*. It's shown on the quest card, on the map and here.
- **Phase change:** the screen flashes, the boss gets a short line of dialogue, the music shifts, and new telegraph colors are introduced.
- **Defeat banner:** a brush-stroke **"SUBJUGATED"**, the System announcement, and the loot burst.

## 6. System Notifications
| Type | Look | Example |
|---|---|---|
| Toast (small) | Bottom-right, 2 s | *Skill [Sword Mastery] Lv 4* |
| Level-up | Center ring of runes, chime, short stat count-up | *LEVEL UP · 9 → 10* |
| Skill acquired / evolved | Window bursts open, glowing skill icon | *Skill [Fire Bolt] has evolved into [Inferno Lance]!* |
| Title earned | Gold ribbon unfurls | *Title acquired: Goblin Bane* |
| **World Announcement** | Full-width banner, every NPC looks up | *"An individual has slain an Elder Dragon."* |
| Rank-up | Full ceremony scene; the card is restamped on screen | F → E: the oak card burns into copper |
| Warning | Red-edged glass | *Danger: an enemy of rank B approaches* |
- **Queue and priority:** combat suppresses toasts and only shows level-ups and warnings. The rest wait for a calm moment. A **notification log** holds everything.
- **Personality skins:** the System's 8 personalities change the wording and style of notifications:
  - **Administrator:** terse.
  - **Mentor:** warm.
  - **Companion:** uses ♥ and "you".
  - **Archivist:** adds a fact.
  - **Zealot:** praises the gods.
  - **Warden:** clinical threat notes.
  - **Duelist:** taunts.
  - **Fractured:** glitch text.

## 7. The Status Window (menu hub)
Opens with a rune burst. Tabs: **Status · Skills · Class · Titles · Bonds · Bestiary · Journal · Map · Memories · System.**
- **Status:** the panel from `systems.md` §1, plus **stat allocation with a live preview** (how damage, speed and carry weight change).
- **Skills = a woven constellation.** Each skill is a star tied by threads. Unlocked threads glow. Fusion skills appear where two threads cross. **You name your fused skills**, and the System comments on the name.
- **Class tree:** a vertical map from base to legendary. Hidden classes show as **blurred silhouettes with a rumor line** (*"A smith in Iron Hold speaks of a blade that sings…"*).
- **Titles:** card gallery; equip 1 main + 3 passives; locked titles show a riddle hint.
- **Bonds:** companion portraits with bond level, their current mood, a "wants to talk" bubble, their personal request and a romance status (if you're on that path).
- **System tab:** the System's current personality, a log of what it has told you and, after Act V, **what it hid**.

## 8. World UI
- **Guild Card (physical item):** inspect it to turn it in 3D. It shows your rank stamp, your main title, the guild seal, scratches from fights and the card material. **Show it to NPCs** in dialogue to unlock rank-gated reactions.
- **Map (parchment):** it starts blank. It inks itself as you explore, in your character's handwriting. Toggle the **System overlay** (blue grid, rank-colored zones, ley lines). Region borders show **siege status**: red smoke = Besieged, green banners = Liberated.
- **Journal:** handwritten pages with sketches. Your character **auto-sketches** new monsters and vistas. Old Hero journals you find are added as their own books.
- **Wanted posters and the guild board:** a pinned-paper board. Day Specials have a red wax seal, dailies are plain, and siege contracts are nailed with a dagger.
- **Letters:** companions, rivals and NPCs send letters to your home mailbox (gratitude, gossip, invitations, rival challenges).
- **The Adventurer Times:** a weekly broadsheet delivered every Solenday (see the Big Upgrade doc, §10).

## 9. Appraisal Tiers (UI)
| Appraisal level | Monsters show | People show |
|---|---|---|
| 0 | Silhouette, "???" | Name only |
| 1 | Name, rank, Menace | Name, job, rank |
| 2 | HP, element, weakness | Level, class, title |
| 3 | Attacks, drops, lore | Skills, mood, secrets hint |
| 4 (Appraiser class) | Future drops, hidden traits | **Seams in faked windows** (flickers, impossible values) |
The Bestiary fills in the same tiers: silhouette → sketch → full entry with lore → **100% completion stamp**.

## 10. Dialogue UI
- **Anime visual-novel style:** half-body portraits with **expressions** (6–10 per main character). The name plate is in the character's theme color.
- **Choice wheel with tone icons:** 😊 kind · 😏 sly · 😠 blunt · 🤔 ask · ❤ romance · 🗡 threaten. Hidden options unlock with Appraisal, rank, titles, Thread or Otherworld Knowledge (shown with a small icon).
- **Emote bubbles** above heads in the world: sweat drop, anger mark, sparkles, "…", hearts, a question mark.
- **System interjections:** a small blue box can pop into a conversation. *[System: This person is lying. Probability 72%.]* (Is the System telling the truth?)
- **Appraise in dialogue:** hold a button to read the speaker's Status while they talk.
- **Backlog, auto-advance and skip seen text.** All text is voice-ready.

## 11. Mode-Specific HUDs
- **Siege defence:**
  - Build-phase timer and a top-down **placement grid** for barricades, traps and ballistae.
  - Wave counter and a **town integrity** bar (district by district).
  - NPC defender icons, and a "Tyrant is watching" eye that opens when it adapts to your tactics.
- **Weekly calendar** (pause menu): 7 god-marked days, Day Specials, siege warnings, festivals, moon phases and companion birthdays.
- **Crafting minigames:** a forge rhythm bar, an alchemy color-mix wheel, a cooking timing ring with steam puffs, sewing as line-tracing. A **master stamp** appears after mastery (skippable from then on).
- **Taming:** a calm meter (heart) and a fear meter (sweat drop); snacks, posture and voice change them.
- **Mounts and pack animals:** a cargo weight bar and the animal's mood and stamina.
- **Photo mode:** poses, expressions, filters (anime cel, watercolor, sketch), frames, and a hide-everything toggle. Shots go to the **Memory Reel**.

## 12. Inventory & Gear
- **Grid with weight** (depending on difficulty). Items sort by rank color, type or newest.
- **Item cards:** 3D preview, rank frame, stats, **a line of flavor text on every item** (Canon), set bonuses, upgrade level and a "compare to equipped" arrow column.
- **Unidentified items** show as "???" until appraised. Cursed items show a fake (lying) card until Appraisal 3.
- **Equipment on the character:** a full-body view with slots around it, plus a transmog/outfit tab.

## 13. The Lying Interface: Corruption Stages
| Stage | When | What changes |
|---|---|---|
| 0 Clean | Prologue–Act II | Perfect blue glass. One `[REDACTED]` line on your Status |
| 1 Hairline | Lantern Seal cracks (Act II) | A one-second glitch across every window. Rare flickers on some people |
| 2 Fractured | Act III–IV | Hairline cracks in the panel corners, odd notifications, sometimes "recommended" quests that mostly help the System |
| 3 Gold Bleed | Ezrath reveal (Act V) | Gold handwriting appears **under** the blue text, showing what was hidden (Thread, harvest eligibility) |
| 4 Your Choice | Act VI path | **Hero:** restored, brighter. **Crimson Throne:** red-black glass. **Unwoven Sky:** the HUD dissolves into ink and paper. **Thirteenth Star:** constellation-UI |

## 14. Accessibility
- **Colorblind:** shapes plus colors for telegraphs, rank letters always written out, and three colorblind palettes.
- **Text and HUD scale,** high-contrast panels, a **dyslexia-friendly font** option, subtitle size and background, speaker names always shown.
- **Camera shake, flash and motion-blur sliders,** and a **reduced-flash** mode for impact frames and Ultimates.
- **Hold or toggle** for every hold action, full remapping, and a one-handed preset.
- **Story difficulty assists:** an auto-dodge window, slower Flash Time, parry timing indicators.
- **Menu narration** (text-to-speech) for the Status Window and dialogue.

## 15. Controller Layout (default)
| Input | Explore | Combat |
|---|---|---|
| A / Space | Jump / climb | Jump |
| B / Shift | Dodge | Dodge (perfect = Flash Time) |
| X / LMB | Interact | Light attack |
| Y / RMB (tap) | — | Heavy (hold = charge) |
| RB + face / 1–4 | — | Skills (hold RB+LB = second palette) |
| LB (hold) | Companion wheel | Companion wheel |
| LT / RMB (hold) | Free aim | Free aim |
| RT / Q | — | Block / parry |
| R3 / MMB | — | Lock-on (flick to switch) |
| L3 + R3 | — | Ultimate / Awakening |
| D-pad | Quick items, whistle mount | Quick items |
| Select / Tab | Map | — |
| Start / Esc | Status Window | Pause |
