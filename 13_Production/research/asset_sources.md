# Asset sources, licences and the compliance questions already open

> Entry format and verification vocabulary: [README.md](README.md). Nothing was downloaded, imported or
> signed up for. Audio is out of scope and already covered by [audio_source_shortlist.md](../audio_source_shortlist.md).
>
> **Not legal advice.** Canon already schedules an IP-lawyer review before release; the items marked
> "lawyer question" below belong in it.
>
> **State of this file:** Part A (the questions already open in this repo) is complete and sourced.
> **Part B (surveying new asset sources by category) was NOT written** — the sweep that was producing it
> was killed by the usage limit twice. It is queued at the bottom, not guessed at.

---

## A0. Two corrections to the register

**VERIFIED — read in the repo, 2026-11-15.**

1. **The register's source path is stale.** [third_party_assets.md](../third_party_assets.md) says the
   library is at `E:\Ideas\Asset-Library`. That folder no longer exists; it is now
   `E:\Ideas\Project-Ascend\Resources\Asset-Library\`. `E:\Ideas\README.md` has the same stale path.
2. **`Resources/Asset-Library/` is not gitignored.** `git check-ignore` returns no match and
   `git status` shows `?? Resources/` as one untracked directory. Nothing is tracked yet, so no damage is
   done — but a single `git add -A` from the repo root would stage about **140 MB of third-party
   archives** into a repo pushed to the `aetheria` remote, including `books-oga-gpl.blend`,
   `potions.blend` and `human.blend` (**GPL and CC-BY-SA art**). Pushing copyleft art into the game's own
   repository is exactly what the register's "Not for the game" table exists to prevent, and it is hard
   to undo once pushed. **Fix: one line in `.gitignore` beside `Art/ThirdParty/`.** Verdict: **adopt now,
   5 minutes.** (The `Resources/` directory is currently untracked in the main checkout, so this is the
   user's or the owning session's edit, not one made from this branch.)

---

## A1. The five archives with no licence file

Method: exact byte sizes recorded, archives listed **without extracting**, MTL/OBJ headers and texture
paths read with `unzip -p`, `.blend` files scanned byte-wise for embedded strings and Blender text
datablocks by a script run isolated (`-I`). Nothing was opened in Blender or imported.
**Method worth keeping:** for old Blender files the licence is often *inside the file* as a text
datablock, and internal paths identify the author when the archive has no readme. That resolved three of
five in minutes after web search found nothing.

| Archive | Author | Licence | Verdict |
|---|---|---|---|
| `rts-props.blend` | Lamoot (meshes), pfunked (textures) | **CC-BY 3.0** — **VERIFIED in-file** | **Trial** |
| `potions.blend` | Clint Bellanger, 2009 | **GPL 2 / GPL 3 / CC-BY-SA 3.0** — **VERIFIED in-file** | **Reject as licensed**; author invites relicensing |
| `human-base-mesh.zip` (`human.blend`) | Clint Bellanger, 2009 (+ pfunked) | **CC-BY-SA + GPL** — **VERIFIED in-file** | **Reject** |
| `claimed-dungeon-tiles-obj.zip` + textures | the **OpenDungeons** open-source project | **NOT VERIFIED** — project licence unread; art probably CC-BY-SA | **Hold** |
| `modular-village-collection.zip` | unknown (same as Dungeon Set 2) | **NOT SOURCEABLE** — no web search completed | **Hold** |
| `dungeon-collection-2.zip` | unknown | **NOT SOURCEABLE** | **Hold** |
| `destroyed-walls-lfa.zip` | unknown (`lfa` is a handle clue) | **NOT SOURCEABLE** | **Hold** |

**Pattern worth taking away: in this library, author identity predicts the licence.** Three of the four
loose Blender-2.49 files are Clint Bellanger / pfunked 2009 work under copyleft terms, and
`books-oga-gpl.blend` (already rejected) fits it. `rts-props.blend` is the odd one out only because its
*meshes* are by a different author.

### rts-props.blend — CC-BY 3.0, two attribution parties

Embedded text datablocks, read verbatim: *"RTS Props / Meshes by Lamoot / Textures and some mapping by
pfunked. / Released under CC-BY 3.0."* An embedded texture also carries its own public-domain statement.
Commercial use is permitted. **Needs a download page before import** (OpenGameArt is the strong candidate,
since both are OGA handles) so the register can carry a URL and the author's own attribution instruction,
and because an OGA page may offer **CC0 as well** — in which case take CC0. Until a page is read this is
"VERIFIED in-file", not "VERIFIED", which is why the verdict is *trial*.

**Exact credit line**, built from CC BY 3.0 §4(b) (title, every designated author, source URI, licence
link, and an adaptation credit — and anything entering `Game/` goes through the bake step, so it *is*
modified):

> **"RTS Props" — meshes by Lamoot, textures by pfunked. Used and modified under CC BY 3.0 —
> https://creativecommons.org/licenses/by/3.0/ — source: \<download page URL, once found\>.**

### potions.blend — the single highest-value relicensing ask

*"Potions / Created by Clint Bellanger. (C) 2009. These models are released under the following terms: GNU
GPL 2, GNU GPL 3, CC-BY-SA 3.0. **If you would like to use these models under different terms, please
contact Clint.**"* 21 potion, flask and vial meshes with glass-and-liquid material separation — a good fit
for the crafting and potion systems. All three offered licences are copyleft, so **reject as licensed**.
But the author offers relicensing **in writing**, and a one-off permissive grant would unblock the set.
**Needs the user's decision: contacting the author is not something Claude does.**

### human.blend — reject, and not worth a relicensing request

*"Copyright 2009 Clint Bellanger. Released under: Creative Commons By-CC-SA / GPL."* Neither is
permissive and the file states no version. It is a full-body rig (bones include `Back`, `Hip`,
`Thigh.Right`, `Shin.Right`), but a 2009 Blender-2.49 cartoon base is well behind what a purpose-built
base would give. **Recommend moving it from "Not imported until their licence is confirmed" to "Not for
the game" in the register**, reason: *CC-BY-SA / GPL only — same objection as `books-oga-gpl.blend`*.

### OpenDungeons tiles — origin certain, licence unread

The MTL header names `OD_Tilesets` under a `RawMedia` directory, which is the OpenDungeons source tree,
and the texture vocabulary (Claimed / Dirt / Gold / Lava / Rock / Water) matches it. **OpenDungeons is a
community open-source project, not another studio's commercial game**, so Canon's "never use other
studios' assets" rule is not what applies. The risk is the licence: I believe the art is CC-BY-SA, **which
is unverified — read the project's own licence file before concluding.** Even if clean, the tiles are
grim stone-and-lava and would need heavy recolouring against `art_direction.md` §2.

### The three unsourced archives

`modular-village-collection.zip` (143 pieces, flat-colour materials, stamped 2018-08-29),
`dungeon-collection-2.zip` (~90 pieces, one `.mtl` per `.obj`, 2018-03-14) and `destroyed-walls-lfa.zip`
(Maya + FBX + 2 OBJ + 2 BMP, 2010) have no source found. The first two share an unusual MTL dialect and a
non-Blender exporter, so they are almost certainly one author. **The village kit is the most valuable
unblock in the list if it clears** — a timber-frame kit with cobblestone-to-dirt transitions maps directly
onto [building_system.md](../building_system.md), and its untextured flat colours suit `Ascend/Toon`'s
one-`_BaseColor`-per-material limit. The destroyed walls are 2010 realistic BMP-textured, the opposite of
`art_direction.md` §3, so low priority even if licensed. **Match by byte size and piece count before
attributing — a same-named page is not proof.**

---

## A2. Steam's AI-content disclosure — read at Valve's own page

**VERIFIED — `partner.steamgames.com/doc/gettingstarted/contentsurvey`, read 2026-11-15, publicly
readable, no login.** `NOT VERIFIED — Valve's January 2024 announcement post: it renders its body in
JavaScript, which the fetch tool does not execute.` The Content Survey documentation is the operative
text and it is Valve's.

**What is in scope, in Valve's words:** the survey section *"is concerned with the use of AI in creating
content that ships with your game, and is consumed by players"*, and *"efficiency gains through the use of
these tools is not the focus of this section."* Valve will *"compare the answers relative to the content in
your build and on your store page."*

- **Pre-Generated AI Content** — *"any kind of content that ships with your game and is consumed by
  players… created with the help of AI tools during development."* Judged *"the same way we evaluate all
  non-AI content"*, resting on the Steam Distribution Agreement warranty that the game *"will not include
  illegal or infringing content"* and *"will be consistent with your marketing materials."*
- **Live-Generated AI Content** — created *"while the game is running"*; same rules plus a duty to
  describe guardrails against illegal content.

**Does concept art that never ships count? No** — it is not content that ships and is not consumed by
players. **But the boundary is narrow, and two realistic paths cross it:**

1. **A concept image reaches the store page** (capsule, header, screenshots, trailer, description). Then
   it is in scope. `SECONDARY` — press coverage of the **January 2026 form revision** says it now asks
   about generative AI in marketing materials explicitly; not read on Valve's own page. Either way the
   rule is the same, and the existing `Art/Generation/staging/` sidecar (tool, model, prompt, date, hash)
   is what makes it answerable: **let the sidecar decide whether an image may be used as a store asset.**
2. **A TripoSR mesh ships.** A finished mesh that began as TripoSR output is Pre-Generated AI Content —
   Valve's definition says *"with the help of AI tools"*, which is deliberately broad. `NOT SOURCEABLE —
   how much human reworking would make a mesh no longer AI-assisted is not answered by Valve's page`, so
   **do not assume a Blender cleanup pass removes the obligation.**

| Tool in [third_party_assets.md](../third_party_assets.md) | Disclose? |
|---|---|
| TripoSR (`Tools/ai3d/triposr_run.py`) — if any descendant mesh ships | **Yes**, Pre-Generated, described "in detail" |
| Gemini / OpenAI images (`Tools/ai_images/generate_image.py`) — reference only | **No**, while it genuinely never ships |
| The same images if used in capsule art, trailer or store page | **Yes** |
| Claude and other coding assistants on `Code/`, `Tools/`, `Game/` | **No** — efficiency tooling, explicitly not the focus |
| Runtime AI | **None exists** — offline-complete — so the Live-Generated guardrails question does not arise |

**Net:** tick *Pre-Generated: yes*, *Live-Generated: no*, and write a short honest description. Mild and
well-trodden, not a blocker. **The one real decision for the user** is whether to accept a public AI
disclosure on the store page in exchange for TripoSR in the shipping pipeline; if not, TripoSR must be
demoted to blockout/reference whose output never survives into a shipped mesh, and that needs writing into
[monster_model_pipeline.md](../monster_model_pipeline.md) as a rule. Also unread: the live wording of the
form as a developer sees it in Steamworks.

---

## A3. Unity licensing — read 2026-11-15, terms dated 30 June 2026

**VERIFIED — Unity Editor Software Terms (the binding contract), the pricing-updates page and the
compare-plans page.** Re-read the same URLs at ship time: Unity changed this model materially in 2023 and
2024.

| Question | Answer | Needs the user? |
|---|---|---|
| Can we keep Unity Personal? | **Yes while under $200,000 USD** for the trailing 12 months. Terms §1.1: *"Tier Eligibility is measured each date you use the Unity Software for the most recent twelve (12) trailing month period"* — a **daily** rolling test, not an annual one | A watch item |
| What counts toward it? | The pricing page says "revenue and funding"; §1.1 defines Total Finances for a non-service-provider as *"the amount generated in connection with your use of the Software."* The binding wording is narrower than the marketing | **Lawyer question** |
| Is the splash screen mandatory? | **No.** *"Splash screen optional with Unity 6"*, and the Terms contain no splash requirement. This project is `6000.6.7f1` | No |
| Is it currently on? | **Yes** — `ProjectSettings.asset` has `m_ShowUnitySplashScreen: 1`, `m_ShowUnitySplashLogo: 1`, `m_SplashScreenLogos: []` | One-line change, under an hour with a player rebuild |
| Runtime fee? | **Cancelled 2024-09-12.** §2.2: *"without royalty, revenue share, or a runtime fee"* | No |
| Cost if the threshold is crossed? | Unity Pro, **$210/month or from $2,310/yr** per seat | **Yes — money**, but only on success |

**The Unity obligation that survives the splash relaxation: Terms §2.12.** If the project has a credits
screen it must carry: *"[Project name] was made with Unity®. Unity is a trademark or registered trademark
of Unity Technologies."* AETHWYRD's credits screen is **inevitable** — `rts-props.blend` (CC-BY 3.0) and
any CC-BY music force one — so the Unity notice is owed too. **Recommend the credits screen be generated
from a `Data/` JSON of credit entries** (title, author, source, licence, licence URL, with `third_party_assets.md`
the source of truth) rather than written at the end. It fits the project's data-driven pattern and makes
forgetting an asset impossible.

**Good news worth recording:** `Game/Packages/manifest.json` contains **no** `com.unity.services.*`,
`ads`, `analytics`, `purchasing` or `cloud` package, so no Unity-services privacy or data-collection
obligation is triggered at the package level. Adding any of them later changes that.

---

## A4. Creative Commons traps for a commercial game

**VERIFIED — read at creativecommons.org: the CC BY 4.0 and 3.0 legal code and the CC FAQ**, not the
deeds, which are explicitly not the licence.

- **CC0 is the only one with no strings — prefer it always.** Not just convenient: it makes every problem
  below *impossible* for that asset. Where a page offers several licences, **take CC0 and write down that
  you did.** A CC0 label still does not cover trademarks, or rights the uploader never held.
- **CC-BY needs real contents.** 4.0 §3(a)(1) lists creator identification, copyright notice, a notice
  referring to the licence, **a notice referring to the disclaimer of warranties** (the one most often
  dropped), a URI where practicable, and an indication of modification. 3.0 §4(b) instead requires the
  **title if supplied**, the author(s), the URI, and an adaptation credit. Many OpenGameArt entries are 3.0.
- **CC-BY-SA is a poor fit, not "forbidden".** Commercial use is allowed; the condition is the problem:
  per the FAQ, *"requires adaptations of the material be released under the same license."* A game asset
  is always adapted (retopologised, recoloured, baked into LODs by `Tools/blender/bake_to_game.py`), so we
  would be obliged to let anyone reuse our finished game-ready assets commercially. The register should
  say *poor fit*, not *forbidden*.
- **CC-BY-NC is simply out.** The FAQ: NC *"prohibit[s] uses that are primarily intended for or directed
  toward commercial advantage or monetary compensation,"* and *"does not turn on the type of user."* A
  premium Steam game is the paradigm case. CC's own advice for any doubt is to *"search for works that
  permit commercial uses"* — so apply NC as a **filter before looking at the art.** ND is also out: game
  assets are always modified.
- **"No downstream restrictions" (CC BY 4.0 §2(a)(5)(B)) versus DRM and our EULA** — the subtlest trap,
  and it applies to plain CC-BY. The FAQ answers "can I use DRM?" with *"No,"* but adds that *"merely
  converting material into a different format that is difficult to access or is only available for certain
  platforms does not violate the restriction"* — so **baking a CC-BY asset into compiled Unity data is
  fine.** Two live items remain: (1) Steamworks DRM wrapping, which is optional — the cheap answer is to
  **not enable it** on a build with CC-BY content (`NOT ASSESSED — Valve's DRM documentation was not read`;
  lawyer question); (2) **the EULA** — a clause forbidding asset extraction would, for CC-BY assets, be
  "additional or different terms". **The fix is a carve-out for third-party assets under their own open
  licences, pointing at the credits screen.** A drafting instruction to carry into the EULA work, cheap now
  and expensive to retrofit. None of this applies to CC0.
- **"Royalty-free" and "free to use" are not licences.** The first is a payment model (and usually means
  *paid*); the second is a claim on a listing page. A licence is a named, versioned instrument, and
  **it is per file, not per site** — OpenGameArt, itch.io and Sketchfab are hosts, not licensors. And it
  is only as good as the uploader's right to grant it.
- **Evidence to keep per asset, next to the file:** the licence text saved as a file (pages rot and uploads
  are edited or deleted); the download URL; the date read; the author exactly as named plus their own
  attribution instruction; the **exact credit string pre-written**; **the byte size and piece count at
  download** (the only defence against a page being edited later, and what let §A1 re-identify these
  archives); and which licence you **elected** on a multi-licence page.

---

## Part B — NOT WRITTEN. Queue, in priority order

`NOT ASSESSED` — no new asset source was surveyed. Two sweeps were cut off by the usage limit before
reaching it. Nothing here is a finding; it is the plan.

1. **Characters and base meshes** — the area with the most licence confusion. Mixamo (confirm on Adobe's
   own page, and separately whether the *characters* may ship, not just the animations); MakeHuman (app
   licence versus output licence, community assets having their own); VRM/VRoid (embedded licence
   metadata, per-model terms); Ready Player Me (a runtime service, so it fails offline-complete).
2. **Animations** — CMU mocap on its own site, ACCAD and other "research" collections for NC terms,
   Quaternius, against [animation_clips_required.md](../animation_clips_required.md).
3. **Textures and HDRIs** — Poly Haven's actual licence (read it, do not assume), ambientCG, cgbookcase.
4. **3D kits** — Kenney, Quaternius, Poly Pizza (per-model licence).
5. **Fonts** — SIL OFL and the Reserved Font Name trap; whether rendered or SDF-baked forms are covered.
   Canon says "English first" with no localisation committed, which scopes the list.
6. **2D/UI and icons** — Kenney UI; Game-icons.net (if CC-BY, credit is owed **per icon author**).
7. **Aggregators and how to read them** — itch.io (per-asset terms), Sketchfab (NC is common, and it hosts
   rips of commercial games, a hard-filter reject), Fab (engine-restricted tiers), CGTrader/TurboSquid
   (royalty-free ≠ free), OpenGameArt (per-file, GPL and CC-BY-SA present).
8. **The cheap register gaps:** TripoSR's Hugging Face model-card licence (the register asks for it
   explicitly); Gemini and OpenAI image-API terms on output ownership and commercial use.
9. **Resolve the unlicensed archives:** web-source the three unsourced ones (queries are listed in the raw
   notes: OpenGameArt and itch.io searches by piece names and counts); read OpenDungeons' art licence;
   find `rts-props.blend`'s download page.

**Adjacent compliance seeds, none verified:** Steam's EU trader-information requirement under the DSA;
whether the European Accessibility Act reaches games; whether EU AI Act Article 50 reaches shipped
pre-generated assets; copyrightability of AI output and what it means for TripoSR meshes; trademark
searches for AETHWYRD and for Karak (the repo already flags the dwarf-hold echo); the rights warranty in the
Steam Distribution Agreement.
