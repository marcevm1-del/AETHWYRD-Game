# CANON — Settled Facts & Spoilers

**This file wins.** If any other doc disagrees with Canon.md, Canon.md is right and the other doc is a bug to fix. Data files in `Data/` are canonical for numbers (stats, habitats, rings); this file is canonical for story and design rules.

⚠️ **Full spoilers below.**

---

## 1. Product (locked)
| Topic | Canon |
|---|---|
| Format | 3D, third-person, **single-player only**, PC |
| Team | The user + Claude |
| Business | Premium, one-time purchase. **Release/Steam planning deferred until near the end** |
| Engine | Unity 6 (URP), data-driven JSON content |
| Art | Bright, flowing **Genshin-style cel-shaded** anime look |
| Music | Mostly instrumental (regional folk + orchestra); anime-rock / J-pop energy for bosses |
| Voice | English first; amount of voice acting TBD by the user |
| Title | Open ("Project Ascend" placeholder). **Ask the user on/after 2026-11-01** |
| Content rules | **No fanservice.** Teen rating; serious themes deepen later. Less comedy, more warmth |

## 2. Numbers
| Thing | Canon |
|---|---|
| Ranks | F, E, D, C, B, A, S, SS, SSS (+ **EX** for monsters only), with −/+ sub-grades |
| Level cap | **300**, then Transcendence T1–T10 at SSS. Bands: F 1–15 · E 16–35 · D 36–60 · C 61–90 · B 91–125 · A 126–165 · S 166–210 · SS 211–260 · SSS 261–300 |
| Pacing | Main story **~200–250 hrs focused**, ~600–800 hrs at explorer pace; **SSS + secret ending ≈ 1,000+ hrs** |
| In-game day | 90 real minutes (tunable 60–120) |
| Classes | **12 base → 24 advanced → 48 expert** → master → legendary (one per world) + hidden (scenario-unlocked) + monster evolution |
| Endings | **11 main + 1 secret** (*The Thirteenth Star*, ~1,000 hrs); ~100 epilogue variations |
| Villain structure | **Demon Overlord Azrael** + **5 Generals**: Ignarok, Morthis, Zephiel, Rhaka, Lady Nocturne |
| World | **40 surface regions + 5 Underworld layers + Great Labyrinth (120 floors, 3 depth bands) + Vesper (post-game)**. Canonical list: `Data/World/regions.json` |
| Monsters | 287 core species → 640 species → 6,714 population variants (`Data/Monsters/`) |
| NPCs | ~2,500 named NPCs, each with a backstory (150 core · 600 major · 1,750 townsfolk) |

## 3. The Big Secrets
| Secret | Truth | Revealed |
|---|---|---|
| The System | Ilvaris's Status System **harvests** the growth of souls who reach SSS to re-stitch the fraying Weave. Otherworld souls are summoned because they have no growth ceiling | Act V |
| Demon Overlord | **Azrael Noxveil is Adrian Vale, Hero #2** (the smashed statue). He learned the truth, refused to be harvested and was betrayed by the Church | Act V |
| The red moon | **Vesper is Valdrisia**, the lost capital, torn into the sky with its people's souls inside | Act V |
| The Red Prophet | **Malchior Vane = Malgareth Vey**, the first Demon Lord, alive for 3,000 years by body-hopping. His current host is **Brother Caspian**, the blindfolded orphanage monk who gives you your first meal. He wants to **devour Vesper** and become the only harvester. Not redeemable | Act V (Lantern Night) |
| The fake Mina | From early Act III, guild receptionist **Mina is Lady Nocturne** in disguise; the real Mina is imprisoned beneath Vharlen | Act III–IV |
| The Forgotten Ninth | **Ezrath the Unbound**, god of freedom, erased by Ilvaris at the Sundering; he is the **Hooded Traveler** | Act V |
| The inn cat | **Whiskers is Vex**, the god of luck, in disguise (secret companion) | Hidden quest |
| Nyx | A 900-year-old dragon, **Umbrael's daughter**, appearing as a child | Act IV |
| The ranks | Hero #1 **Kaede Aoyama**, a gamer, invented the F–SSS ranks from video games | Act V (her journal) |
| Ashen Gate | Malgareth was **not** destroyed at Ashen Gate; he escaped in a soldier's body | Act V |
| Tomás's seal | Hero #3 **Tomás Reyes** sealed Azrael with his own soul (the Lantern Seal); it cracks in 1024 SC | Act II |
| Floor 120 | The Loom: the Unclosed Knot at the center of the Weave (final superboss TBD) | Post-game |

## 4. Who Can Do What
| Question | Canon |
|---|---|
| Romanceable companions | **Lyra, Seraphine, Kiri, Sir Aldric, Bram, Kaito, Elira, Vexmor, Torvald, Suzune**, plus childhood friends **Tobin and Elsie** (origin-dependent). All are adults. Male and female player characters, no gender locks |
| **Not** romanceable | **Nyx** (childlike appearance, so never, whatever her true age), **Mochi**, Named-monster companions, Whiskers, **Azrael**, **Celestine** |
| Marriage & family | Yes; children are **adopted** |
| Redeemable villains | Dorran "Red Ledger" Hask, Sister Ivy Thorne, Kaito, Grukk the Younger; also Generals Ignarok, Morthis, Rhaka (and partly Zephiel) |
| Never redeemable | Malgareth / the Red Prophet, Lady Nocturne, Diego Alvarez |
| Player cannot | Become king/queen · own a guild · ride flying mounts (flight and teleport are **abilities** only; ground mounts are fine) · return to Earth |
| Dungeon cores | Never allies; dungeons stay reusable |
| Narrator | None. Only the System Voice (player picks male or female; 8 evolving personalities) |
| Fourth wall | Gods and the System speak to the **character**; only *The Unwoven Sky* and *The Thirteenth Star* address the **player** |

## 5. Loss Rules (protecting a 1,000-hour game)
- **Companion combat death is opt-in** (*Mortal Bonds* option; Hardcore turns it on). Otherwise downed companions are only "gravely wounded."
- **Story deaths** happen only through clearly signposted choices.
- Pack animals and porters are knocked out (cargo recoverable) on default settings; they die only with Hardcore/Mortal Bonds.
- Respec is always possible (free to Lv 10; one free token per class-tier change).
- Character level and learned skills are never lost on class change.

## 6. Proposed Locks (need the user's OK)
| Item | Proposal | Why |
|---|---|---|
| Companion roster | **12 companions + 2 childhood friends**, no more human-cast companions added after this | Romance + permadeath + mutual exclusivity + 12 endings multiply writing; capping the cast caps that |
| Named-monster companions | A **lighter dialogue tier**: personality, banter, bond levels, no romance or full personal arc | Lets the nemesis-to-companion system scale |
| Ring 2 roster | Trim ~145 tagged species to ~60 cores during Ring 2 planning | Art budget for two people |
