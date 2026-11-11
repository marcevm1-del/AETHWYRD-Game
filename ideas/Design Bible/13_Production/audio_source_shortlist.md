# Free audio source shortlist and licence check (job 3)

> **Status:** research note. **Nothing was downloaded, imported or added to `Game/`.** Per project rules a source only goes into the game after it is listed in `13_Production/third_party_assets.md` with the exact file, author, licence and the evidence (licence text or page, saved date). This note says which sources are worth that step. Owner: audio-designer. Research date 2026-11-09. Not legal advice; the IP lawyer review Canon asks for before release covers third-party audio too.

## 1. How each licence claim was checked

| Mark | Meaning |
|---|---|
| **VERIFIED** | I read the source's own page on 2026-11-09 and the claim below is what it says |
| **SECONDARY** | Confirmed only by search results (including third-party guides) that quote the source; re-check on the pack's own page at download time |
| **NOT VERIFIED** | The page could not be read (blocked, closed, 403). Claim is from memory or hearsay and **must not be relied on**; the source stays off the "use" list until checked |

A licence is always per file or per pack, never per site. The licence evidence for each file (screenshot or saved licence text plus URL and date) goes next to its row in `third_party_assets.md`.

## 2. Shortlist

| # | Source | Content | Licence | Commercial game OK | Attribution | Check | Use for |
|---|---|---|---|---|---|---|---|
| 1 | **Kenney** audio packs (UI Audio, RPG Audio, Impact Sounds, Interface Sounds, Sci-Fi Sounds) kenney.nl/assets | SFX packs | CC0 1.0 | Yes | Not required | **SECONDARY** (pack pages for Sci-Fi Sounds, RPG Audio and UI Audio list CC0; the site-wide support page was blocked) | UI sounds, footstep and cloth placeholders, impacts. Already the project's pack source for 3D (`third_party_assets.md`) |
| 2 | **Sonniss GameAudioGDC bundles** (2015-2024, 9 to 48 GB each) sonniss.com/gameaudiogdc | Professional SFX libraries, ambience, foley | Sonniss's own royalty-free licence | Yes, in games, film, TV and interactive projects | Not required | **VERIFIED** | Footsteps per surface, ambience beds, weather, cave and room tones, UI foley. The best match for the whole of job 2 |
| 3 | **Freesound**, filtered to **CC0 only** freesound.org | Individual user-uploaded SFX and field recordings | Per sound: CC0, CC-BY, CC-BY-NC, Sampling+ (retired) | **CC0 and CC-BY yes**; CC-BY-NC and Sampling+ **no** | CC0 none; CC-BY required | **VERIFIED** (FAQ) | Gap-filling single sounds. Rule: accept only CC0 (or CC-BY with a credits-screen entry); reject CC-BY-NC and Sampling+ |
| 4 | **Incompetech** (Kevin MacLeod) incompetech.com | Music | CC BY 4.0 | Yes (credit required; the site says to credit on a game's credits screen) | **Required**, with the wording the site gives: *Title, Kevin MacLeod (incompetech.com), Licensed under Creative Commons: By Attribution 4.0, https://creativecommons.org/licenses/by/4.0/* | **VERIFIED** | Placeholder and low-stakes music only (see §3 risks); needs a credits-screen entry |
| 5 | **Pixabay** Content Licence (music and sound effects) pixabay.com | Music, SFX | Pixabay Content Licence | Yes, free to use and modify, no attribution, **but not standalone redistribution** of the file | Not required | **VERIFIED** for the general summary; music and Content-ID specifics are in the full terms and were **not read** | Placeholders only until the full terms are read (a Content ID claim could hit a trailer using a Pixabay track) |
| 6 | **FreePD** freepd.com | Public-domain music | Called "Public Domain" by the site; no terms found | Unclear | Unclear | **NOT VERIFIED** (the site says it is closed and gives no licence terms) | Do not use unless an archived licence statement is found and saved |
| 7 | **OpenGameArt** (audio section) opengameart.org | Mixed music and SFX | Per file: CC0, CC-BY 3.0/4.0, CC-BY-SA, GPL, OGA-BY | CC0 and CC-BY yes; **GPL and CC-BY-SA are poor fits** (share-alike) | Per licence | **NOT VERIFIED** (the FAQ returned 403); a search result showed a CC0 pack "50 rpg sound effects" but I did not read its page | Candidate only, CC0 files, each checked on its own page; note the project already flagged an OGA GPL file as "not for the game" (`third_party_assets.md`) |
| 8 | **Zapsplat** zapsplat.com | SFX, music | "Standard" free licence | Unknown | Unknown | **NOT VERIFIED** (page returned 403). I recall that the free tier needs attribution; **unconfirmed** | Do not use until the terms page is read |
| 9 | **BBC Sound Effects archive** | Recorded SFX | RemArc licence (personal, educational, research) | **No** for a commercial game, as far as I recall | n/a | **NOT VERIFIED** | **Exclude** |
| 10 | **Musopen** and **Internet Archive** public-domain recordings | Classical recordings | Per recording (composition PD does not make a recording PD) | Per recording | Per recording | **NOT VERIFIED** | Only if a specific recording has a clear PD or CC0 statement; do not assume |

## 3. Risks that apply to the whole list

- **Anime-fantasy match.** Free libraries are rich in realistic foley and weak on stylised JRPG orchestral and rock. Free music is good for placeholder and for sparse beds, not for the boss rock stem or the Act openings. For those the existing plan stays: placeholders first, commission composers later (`opening_music_and_memories.md` §2, "Production Path").
- **Redistribution and extraction.** Sonniss (and Pixabay) forbid selling the sounds on their own. Packing audio into the game is fine; shipping raw `.wav` files in an open asset folder or in a public repo is not. Keep source audio out of git (this repo already ignores generated and third-party packs) and ship compiled banks only.
- **AI training clause.** Sonniss prohibits AI/ML training use. The project does not train models on audio, so it is fine, but do not feed the bundle to any future generation tool.
- **CC-BY needs a credits screen.** Any CC-BY file (Incompetech, some Freesound) adds a line to an in-game credits list. Track these in `third_party_assets.md` with the exact credit text.
- **Unity and Wwise/FMOD.** None assessed here; the audio middleware choice is open. This note does not add any plugin.
- **No fan or studio audio.** Music or sounds from other games or anime are never used (Canon rule: ideas only).

## 4. Recommended plan

1. **Primary pool:** Sonniss GDC bundles (footsteps, ambience, weather, room tones) plus Kenney CC0 packs (UI, impacts) plus Freesound CC0 for gaps. Estimated to cover the whole of `audio_sfx_event_list.md`.
2. **Music (placeholder only):** Incompetech (CC-BY, credits entry) and CC0 music verified file by file; nothing here is final.
3. **Before any import:** the user downloads (the project never creates accounts and the Sonniss download may ask for an account (not checked), so this is a user step); the file and its licence evidence are added to `third_party_assets.md` first; only then does `Game/Assets/_Game/Audio/` get anything.
4. **Open for the user:** whether to download (and sign up if asked for) the Sonniss bundles the bundles (tens of gigabytes), and whether placeholder music from Incompetech is acceptable on a public build.

## 5. Sources

- Sonniss GameAudioGDC page (read 2026-11-09): sonniss.com/gameaudiogdc
- Freesound FAQ (read 2026-11-09): freesound.org/help/faq
- Incompetech licence FAQ (read 2026-11-09): incompetech.com/music/royalty-free/faq.html
- Pixabay licence summary (read 2026-11-09): pixabay.com/service/license-summary
- Kenney pack pages via search (Sci-Fi Sounds, RPG Audio, UI Audio): kenney.nl/assets/sci-fi-sounds, kenney.nl/assets/rpg-audio, kenney.nl/assets/ui-audio
- Not readable on 2026-11-09: kenney.nl/support (blocked), opengameart.org/content/faq (403), zapsplat.com licence page (403), freepd.com terms (none shown)

## 6. What was not done

- No file downloaded or inspected; no licence text saved to the repo yet.
- `third_party_assets.md` is **not** edited (no asset is chosen, so there is nothing to register).
- Rows marked NOT VERIFIED are unresolved: Kenney site-wide terms, OpenGameArt, Zapsplat, FreePD, BBC, Musopen, Pixabay music terms.
