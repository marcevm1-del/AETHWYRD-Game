# Research library

> A standing index of things outside this project that would make AETHWYRD better or faster to build. One file per area; every entry answers the same five questions so entries can be compared and ranked. Opened 2026-11-15 on branch `research/standing-library`, base `8a81418e`.
>
> **Nothing here is installed, bought, signed up for or downloaded.** Entries are recommendations with the cost and the licence attached; adoption is the user's call. Anything that needs money, an account or an API key says so in its own words.

## How to read an entry

Every entry, whatever the area, answers these five in this order:

1. **What it is** — two or three sentences.
2. **What it would do for us** — the file, system or job in this repo it touches. An entry that cannot name one is a weak entry.
3. **Cost, licence and requirements** — money, sign-up, API key, GPU, internet, platform.
4. **Effort and risk** — an hours estimate, and what it would break or lock us into.
5. **Verdict** — `adopt now` / `trial` / `hold` / `reject`, reason in one line.

Each entry also carries a verification tag, using the vocabulary this repo already uses in
[audio_source_shortlist.md](../audio_source_shortlist.md):

| Tag | Meaning |
|---|---|
| **VERIFIED** | The primary source was read — repository, `LICENSE` file, release notes, official docs page, or the package source on this disk. The entry says which. |
| **SECONDARY** | Confirmed only by third-party pages quoting the source. Re-check on the source's own page before adoption. |
| **NOT VERIFIED** / **NOT SOURCEABLE** | The source could not be read, or the claim is not covered by the sources consulted. The entry names what was tried. The claim must not be relied on. |

**An unverified licence, price or version can never carry the verdict `adopt now`.** That is
`.claude/rules/skill-authoring.md` obligation 4 applied here: the gap is written down, and it is
wired to the verdict rather than sitting beside it.

## The areas

| File | Area | State |
|---|---|---|
| [mcp_servers.md](mcp_servers.md) | MCP servers for a Unity + Blender pipeline, including the ones already configured here | pending |
| [skills_and_plugins.md](skills_and_plugins.md) | Claude Code skills, plugins, hooks and marketplaces | pending |
| [video_tutorials.md](video_tutorials.md) | Video tutorials and conference talks, mined frame by frame with `Tools/tutorial_vision/` | pending |
| [techniques_and_systems.md](techniques_and_systems.md) | World streaming, companion and monster AI, combat feel, save migration | pending |
| [asset_sources.md](asset_sources.md) | Free and openly licensed asset sources, with exact licence terms | pending |
| [unprompted.md](unprompted.md) | Things nobody asked about: findings that fell out of the sweeps | pending |
| [shortlist.md](shortlist.md) | The top ten across all areas, ranked by help per hour of work | pending |

## Scope boundaries

These are deliberately **not** covered here, because the work is already done or is owned elsewhere:

- **Stylised character and creature art rules** — a sibling session (`art-research`) is on it. This library covers the *licensing* of character and animation assets, not the style.
- **Audio middleware** — decided: Unity's built-in audio with a mixer, not FMOD or Wwise. No entries propose middleware.
- **Free audio sources** — already delivered in [audio_source_shortlist.md](../audio_source_shortlist.md) (Sonniss, Kenney, Freesound CC0, Incompetech and the rest, with VERIFIED marks). [asset_sources.md](asset_sources.md) covers models, textures, HDRIs, characters, animation, fonts and 2D, and does not repeat audio.
- **The studio layer** (Claude Code Game Studios v1.2.0) — already merged; see [adoption-plan-2026-11-07.md](../adoption-plan-2026-11-07.md). [skills_and_plugins.md](skills_and_plugins.md) assesses what is installed rather than proposing it again.

## Queue and open items

Written here so a session that is cut off mid-sweep can be resumed by the next one.

- [ ] Nothing yet — the library was just opened.

**Canon §6 candidates** raised by this research (collected here; `Canon.md` is never edited from this branch):

- None yet.

**Not present at base `8a81418e`:** `13_Production/completion_plan.md` and `Tools/dashboard/agent_dashboard.py`, which a sibling session reports exist and score the game at 25.4%. Entries here therefore name files and systems rather than that board's goal ids. When the dashboard lands, the shortlist should be re-read against it.
