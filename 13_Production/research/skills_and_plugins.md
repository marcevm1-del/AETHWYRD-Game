# Claude Code skills, plugins and features

> Entry format and verification vocabulary: [README.md](README.md). Nothing was installed or enabled.
> Plugin files were read from disk where they are present on this machine; licences were read from
> `LICENSE` files, not from marketing.
>
> **The most useful part of this file is section 3.** The marketplace survey is the part that was asked
> for; the Claude Code settings that are already installed and unused are the part that would actually
> help, because their benefit multiplies across the roughly 40 sessions this project runs.

**Counts corrected while surveying:** `.claude/agents/` holds **61** files (not 59); `.claude/skills/`
holds **74** directories (not ~70). Also present and not previously catalogued: `.claude/scripts/` with
**34** shell scripts, `.claude/docs/`, `.claude/hooks/yaml-helper.sh`, and `.claude/rules/` (14).

---

## 1. Two facts that change every hook verdict below

**VERIFIED — read at `code.claude.com/docs/en/hooks`.**

**1a. `timeout` in a hook config is SECONDS.** Every `hooks.json` in the dev-gom marketplace writes
`"timeout": 5000`. That is not 5 seconds — it is **5000 seconds, about 83 minutes**. A hung hook script
blocks for that long instead of failing fast. It is a one-character class of bug, but it is in the
upstream files, so adopting any of those ten plugins as-is imports it.

**1b. `priority`, `enabled` and `continueOnError` are not recognised hook fields.** The documented
handler fields are `type`, `if`, `timeout`, `statusMessage`, `once`, plus per-type ones; failure handling
is `onFailure` (`"continue"` | `"block"`). Several dev-gom READMEs tell the user to turn a hook off with
`"enabled": false`. **It will keep firing.** On a project with ~40 parallel sessions, a hook you believe
you disabled and which fires in every session is materially worse than no hook at all.

A third, smaller one: on a `Stop` hook, **exit code 2 means "keep working"**, not "stop". The
`hook-git-auto-backup` loop guard exits 2 to break its own loop, which would do the opposite.
`NOT SOURCEABLE — whether Claude Code sets a STOP_HOOK_ACTIVE environment variable, as opposed to a
stop_hook_active field in the stdin JSON, is not covered by the portion of the hooks page retrieved.`
Either way the guard is wrong: dead code if the variable is never set, a loop re-trigger if it is.

---

## 2. The dev-gom marketplace (`E:/Ideas/claude-code-marketplace`)

**VERIFIED — licence read.** Apache-2.0 for the whole repo, and all 14 `plugin.json` files declare it.
`NOTICE` adds attribution requirements: retain NOTICE, include the LICENSE, **clearly indicate any
modifications**, retain copyright notices. Apache-2.0 permits commercial use, and these are dev-time
tools — with one exception at 2d, which would ship in the player.

Two quality signals before the individual verdicts. The manifest claims **2.31.0** while three plugins'
own `plugin.json` files disagree with it, two of them *backwards* — judge each plugin by its files, never
by the index. And **none of the three toolkits runs without `npm install`**: `blender-toolkit`,
`browser-pilot` and `unity-editor-toolkit` each ship a `package.json` with no `node_modules` and no built
`dist`. **Needs the user's decision:** an `npm install` of unreviewed dependency trees. The ten hook and
helper plugins are dependency-free Node and run as-is.

### Verdicts

| Plugin | Verdict | One-line reason |
|---|---|---|
| `unity-dev-toolkit` v1.4.0 | **Trial, for one file** | `parse-test-results.js` turns NUnit XML into a few lines; see 2a |
| `auto-release-manager` v1.0.3 | **Trial** | The only release tool here with a real Unity path (`bundleVersion` sync), invoked not hooked |
| `hook-session-summary` v1.1.1 | **Trial** | Aimed at reconstructing killed sessions — but only after its output is keyed to `session_id` |
| `hook-sound-notifications` v1.4.4 | **Trial** | Genuinely Windows-native; useful only if narrowed to `Stop` on one session |
| `hook-complexity-monitor` v1.1.1 | Hold | Real C# analyser, but brace-counting warnings on every edit across 40 sessions is a muted gate waiting to happen |
| `hook-todo-collector` v1.2.0 | Hold | Thin — a grep wrapper, already covered by `tech_debt_register.md` and `.claude/scripts/code-markers.sh` |
| `spec-kit` v2.3.2 | Hold | Zero technical footprint and well written, but it duplicates `create-epics`→`story-done` and stands up a rival constitution beside `Canon.md` |
| `blender-toolkit` v1.4.4 | Hold | Superseded by the Blender MCP already connected; see 2c |
| `hook-git-auto-backup` v1.1.1 | **Reject** | Bare `git add -A` on a shared `main`; see 2b |
| `hook-auto-docs` v1.4.1 | **Reject** | Auto-rewrites `README.md` and `CHANGELOG.md` with no ask, against CLAUDE.md's write-permission rule |
| `claude-dev-helper` v1.4.0 | **Reject** | Auto-stages git in a shared-`main` repo; its editor half assumes one watched session |
| `ai-pair-programming` v1.1.1 | **Reject** | Four generic agents (`architect`, `code-reviewer`, `performance-expert`) colliding with 61 existing ones, plus a review-nag hook |
| `browser-pilot` v1.10.0 | **Reject** | No web surface in an offline single-player game; zero repo attachment |
| `unity-editor-toolkit` v0.15.1 | **Reject** | Ships a WebSocket server into the player build; see 2d |

### 2a. The one thing worth taking: `parse-test-results.js`

**VERIFIED — source read.** A standalone, dependency-free Node script (`fs` and `path` only) that parses
Unity Test Framework **NUnit XML** into `{summary: {total, passed, failed, skipped, duration}, failures:
[{name, fullName, message, stackTrace, file, line}]}`, with `--json` and `--help`.

**The project already produces exactly that input** — CLAUDE.md's `-runTests -testPlatform PlayMode
-testResults <xml>`, 196 PlayMode tests, logs under `Game/Logs/verify_<time>/`. It attacks "Unity
batch-mode runs are slow and **log-heavy**" directly: a multi-megabyte log plus an XML file becomes a few
lines naming each failure with file and line. For a project where dozens of sessions each burn context
reading logs, that saving multiplies. Apache-2.0, no install, **1–2 hours** to wire into
`Tools/pc/update_and_verify.cmd` after the PlayMode step, blast radius zero — it reads a file and prints.

**Do not use its sibling `find-unity-editor.js`:** it searches only the three default Hub paths, and this
project's editor is at `E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe`. Credit where it is due, though —
it returns `{found: false, searchedPaths: [...]}`, prints them to stderr and exits 1 rather than silently
reporting zero tests. That is `.claude/rules/skill-authoring.md` obligation 3 satisfied by a third party,
and it is a decent model for how the house standard wants a failed check to report.

### 2b. Why auto-commit is a reject, not a preference

`hook-git-auto-backup` runs `execSync('git add -A')` on every `Stop`. Four independent problems, any one
sufficient: CLAUDE.md requires `-c safe.directory=E:/Ideas/Project-Ascend` on every git call here and the
plugin runs bare `git`, with `showLogs` defaulting to **false**, so the dubious-ownership failure is
**swallowed silently** — the exact failure obligation 3 names. `git add -A` sweeps in untracked generator
output and the plugin config directories, none of which are gitignored. Its duplicate-suppression lock
lives inside the **plugin's own directory**, shared by every session on the machine, and suppresses any
run within 3 seconds — so with 40 sessions, backups are suppressed essentially at random and whichever
session wins the race is the one that commits. And a `Stop` in one session would commit another session's
half-finished edits under "Auto-backup", producing history with none of the `progress_log.md` rows
CLAUDE.md requires.

**There is also no need for it.** `/rewind` (or double-Escape) restores **conversation and code** to a
checkpoint. The accident this plugin guards against is already covered, without junk commits on `main`.

### 2c. `blender-toolkit` cannot participate in this pipeline at all

Its addon runs inside an **interactive** Blender started by hand, with the server enabled by clicking a
button in the N-panel. AETHWYRD drives Blender with `blender.exe -b --factory-startup -P <script>`, and
**`--factory-startup` explicitly disables addons** — so the toolkit cannot touch any of the 22 generator
scripts in `Tools/blender/`, nor run under `Tools/pc/update_and_verify.cmd`. Its one non-overlapping
feature is Mixamo retargeting. It also states Blender **4.0+** while the project runs **5.2**:
`NOT SOURCEABLE — whether this addon works on Blender 5.2 is not covered by its SKILL.md, README or addon
source, which say only "4.0+"; 4.x→5.x is exactly the kind of API break that moves bpy operators.`
Superseded by the Blender MCP already connected ([mcp_servers.md](mcp_servers.md) §1).

### 2d. `unity-editor-toolkit` would compile a socket server into the shipped game

**VERIFIED — all four `.asmdef` files read in full.** `Editor/UnityEditorToolkit.asmdef` is correctly
scoped to the Editor. **`Runtime/UnityEditorToolkit.asmdef` has `"includePlatforms": []`, which in Unity
means *all platforms*** — and `Runtime/` contains `Server/UnityEditorServer.cs`, the JSON-RPC protocol
classes and six scene-manipulation handlers. As shipped, **a WebSocket RPC server and its handlers
compile into the player build.**

For an offline-complete, teen-rated, commercially sold game that is three problems at once: a listening
socket inside a shipped offline binary (which contradicts the offline-complete promise and is what store
review and binary scanners look for), dead weight, and a remote-control surface on the player's machine.
It is a one-line asmdef fix — but one you would re-apply on every upgrade, and Apache-2.0 plus this NOTICE
require marking the modification.

It also carries three unread licences into `Game/`: a prebuilt **`websocket-sharp.dll` (250 KB) with no
licence file anywhere in the package**, and two Unity packages pulled **by git URL**, one of them
(`com.cysharp.unitask`) **unpinned** — no tag, no commit, so the build is not reproducible.
`NOT SOURCEABLE — the licences of websocket-sharp, UniTask and gilzoide/unity-sqlite-net are not covered
by anything in the marketplace; none is vendored, only referenced.` Under the house rule an unconfirmed
licence cannot be "adopt now", and this is an opaque binary destined for `Game/Assets` of a game that is
sold.

**And it is unnecessary:** `unity:unity-cli` (§4) gets the same live-Editor benefit from a first-party
package.

---

## 3. Claude Code features already installed and not used

**This is where the usage-limit problem is actually solved.** Everything here is configuration of
software already present: free, no account, no key, nothing to install except where noted. All
**VERIFIED — read at `code.claude.com/docs/en/costs` and `/hooks`**, plus local reads of `.claude/`.

### 3a. A `PreToolUse` hook that filters Unity, Blender and npm output — **adopt now**

A `PreToolUse` hook can rewrite the command Claude is about to run. The costs page documents this exact
pattern with a working example and states the effect plainly: instead of Claude reading a 10,000-line log
to find errors, a hook greps for errors and returns only those lines, *"reducing context from tens of
thousands of tokens to hundreds"*.

**Named targets in this repo:** the Unity batch-mode invocations (`Ring0SceneBuilder.BuildBatch`,
`BuildPlayer.BuildRing0`, `-runTests -testPlatform PlayMode`), whose logs run to megabytes of
asset-import and shader-compile chatter; `Tools/pc/update_and_verify.cmd`, whose five stages each write a
log into `Game/Logs/verify_<time>/`; `npm run build`, whose seven stages end in **770 tests** — on a green
run Claude needs one line, not 770; and `blender.exe -b -P <script>`, which prints per-object spam from 22
generators.

**The multiplier is what makes this first.** A filter is paid for once in configuration and collected in
every session, every run. Nothing else here has that shape: plugins add context, this subtracts it.

**4–8 hours**, and the risk is real and specific: **a filter that drops the wrong lines hides a failure.**
That is obligations 2 and 3 of `.claude/rules/skill-authoring.md` exactly, so the filtered output must say
what it suppressed (`"… 9,842 lines suppressed; 0 matched error|Exception"`), or a filtered-clean run and
a genuinely clean run produce the same artifact. Write it to the five obligations — the project already
owns the rule file that says how. Put it in **project** settings, not user settings, or it fires on every
project under `E:\Ideas`. Verify with `/hooks` and `claude --debug-file`, which logs a
`modified tool input keys` line. And write `"timeout": 5`, not `5000` (§1a). The documented example is a
bash script using `jq`; a Node hook avoids the question, since Node is already a project dependency.

### 3b. Run `/usage` first — 5 minutes, and it aims everything else

On a paid plan `/usage` now shows a **plan usage breakdown**: recent usage attributed to skills,
subagents, plugins and individual MCP servers, each as a percentage, plus recommendations covering at
least 10% of recent usage, and a Loops section listing the heaviest scheduled tasks. Figures are computed
from **local session history on this machine** — which, with ~40 local sessions, is ideal.

This is the measurement instrument for the whole parallel-session problem and it is installed and unused.
Everything else in this section is a hypothesis; this is how to test it. **Do it before 3a, 3c or 3d.**
One caution: the recommendations are generic ("trim CLAUDE.md"), and this project's CLAUDE.md is short
and load-bearing, so read before pressing the fix shortcut. **Verdict: adopt now.**

### 3c. 49 of 61 agents run at the parent session's model — **adopt now**

Measured locally across `.claude/agents/*.md`: `model: inherit` on **49**, `sonnet` on 10, `opus` on 2.
A session running a multi-agent wave is usually on the strongest model, because that is what the
orchestration warrants — so every agent in that wave inherits the most expensive setting, including the
mechanical ones. From `agent_team.md`'s own wave plan: `qa-tester` reading test XML,
`tools-pipeline-engineer` running `Tools/validate/`, and `canon-keeper` doing consistency greps are jobs a
smaller model does adequately, while `anime-fantasy-director` doing a genre-fit review and `producer`
splitting a goal into waves are the ones that want the top model.

**2–3 hours** to tier all 61 deliberately, one line per file, fully reversible. The risk is real but
avoidable: take the saving on mechanical agents, never on the directors — a design agent on too small a
model produces worse design, not a cheaper session. The pack's own authors already tiered some agents this
way, so the pattern exists in-repo.

### 3d. `maxTurns` is missing on exactly the 27 agents that do the work — **adopt now**

All 34 studio agents set `maxTurns` (20, or 10 on `accessibility-specialist`). **All 27 AETHWYRD agents
set none.** Given that usage limits have repeatedly killed waves of them, the uncapped ones are the
project's own team. An agent with no turn cap that falls into a retry loop spends the budget that would
have run the next wave. **About 1 hour**, zero risk, and half the roster already demonstrates the pattern.

### 3e. Background token drains nobody has turned off

Each is a documented setting at its default here, and with ~40 sessions idle drain is 40× whatever it is
per session:

- **`crossSessionInbound: hold`** — a message from another session is delivered to an idle session as a
  new turn, *"sending your full context each time"*. **This is specifically a 40-session problem** and
  the setting holds them instead. **Adopt now.**
- **`/clear` rather than `/compact`** between unrelated tasks — *"`/compact` reads the conversation it
  summarizes, so compacting a large context is itself a large request"*, while `/clear` costs nothing.
  Free operational knowledge. **Adopt now.**
- Session recap and **`idleCompaction`**, **prompt suggestions**, **goal check-ins**
  (`CLAUDE_CODE_GOAL_CHECKIN_MINUTES=0`), and scheduled tasks / `/loop`, which fire on their interval even
  while idle and send the full context each time. **Trial after 3b shows which matter.**
- Worth knowing before anyone turns it on: **agent teams** (distinct from subagents) *"use approximately
  7x more tokens than standard sessions when teammates run in plan mode"*, are disabled by default, and
  need an experimental environment variable. Given `agent_team.md`'s wave model someone will be tempted;
  7× is the number to weigh first.

### 3f. MCP context overhead — this session is the worked example

MCP tool definitions are deferred, but every configured server still contributes its name **and its
server instructions** to context. This session was started with Shopify, Twilio, Canva, Figma, Vercel,
Supabase, Gmail, Drive, Carta, Airtable, legal, marketing and SEO servers attached, **none** of which is
relevant to an offline Unity RPG; several injected multi-paragraph instruction blocks before any work
began. `ListPlugins` reports **30 enabled plugins, of which exactly two are on-subject.** Multiply by ~40
sessions.

`/context` measures it, `/mcp` disables servers. **1–2 hours, the largest pure subtraction available**,
and 3b can aim it by measurement. **Adopt now.**

### 3g. The enabling step, and the rest

**No `settings.json` or `settings.local.json` exists anywhere under `.claude/`.** Hooks live there, so
3a depends on it. A status line can also display token usage continuously and read a `prompt_cache`
object — for one developer supervising dozens of sessions, that is the difference between noticing a
runaway session and discovering it afterwards. (A dangling thread: `gate-check` already writes
`production/stage.txt` with a comment saying it *"updates the status line immediately"*, so the studio
pack was built expecting a status line that was never installed.) **2–4 hours. Adopt now, as the
prerequisite for 3a.**

Also worth a look, none of them expensive: **`/insights`** writes an HTML report on friction points across
up to 200 recent sessions — the cheapest possible retrospective for someone who cannot read 40
transcripts, though the analysis itself costs tokens and reports are deleted after 30 days, so anything
worth keeping belongs in `13_Production/`. **`/rate-limit-options`** and **`autoContinueAtUsageLimit`**
make a session wait for the reset and resume rather than dying at it; also useful to know that
*"you've hit your session limit"* and *"weekly limit"* are seat-based and switching model will not help,
whereas after an *Opus limit* specifically, `/model sonnet` does keep you working.
`NOT SOURCEABLE — whether a non-managed install can set autoContinueAtUsageLimit in ordinary project or
user settings is not covered by the costs page.` **Trial.** Plus `--max-budget-usd`,
`MAX_THINKING_TOKENS`, `/effort`, and plan mode before a wave that is about to touch 64 C# rule files.

### 3h. Code intelligence plugins for C# — **trial, the user's call**

Documented first-party: code intelligence plugins for typed languages give *"precise symbol navigation
instead of text-based search"*, and installed language servers *"report type errors automatically after
edits, so Claude catches mistakes without running a compiler"*. The second half is the valuable one here
— catching a typo without paying for a Unity batch-mode compile round-trip. C# is exactly the target, and
this repo is full of it. **Needs the user's decision: it is an install.**
`NOT SOURCEABLE — which plugin covers C#/.NET, which language server it needs, and that server's licence
are not covered by the costs page.` Check that `Game/Library` is excluded from indexing before enabling.

---

## 4. The official Unity plugin, already installed

**VERIFIED — `LICENSE.md` read.** *"Unity Agent Plugin © 2026 Unity Technologies. Licensed under the
Unity Companion License for Unity-dependent projects."* This is **not** Apache or MIT. The Unity
Companion License permits use only with Unity-dependent projects — which AETHWYRD is, so it is fine here
— but it is restrictive and "AS IS", and the plugin could not be reused for anything non-Unity. Worth a
row in [third_party_assets.md](../third_party_assets.md) if the project formally depends on it.
`NOT SOURCEABLE — the full licence text was not read; LICENSE.md only links to unity3d.com.` Authored
version **0.1.9-beta**: a beta from a partner is still a beta. 32 skills on disk.

**Triaged honestly, of the 32:**

- **Genuinely useful (11):** `unity-cli` (§4a), `urp-postprocessing` (the Volume framework — tonemapping
  and colour grading are exactly where `Tools/blender/toon_preview.py` and the Unity render have to
  agree; it pins `com.unity.render-pipelines.universal: ">=14.0.0"` in its frontmatter, which is a
  well-built skill declaring its prerequisite), `shader-graph-create-custom-node`,
  `validate-urp-render-graph-renderer-feature` (Unity 6 moved URP to Render Graph and the inverted-hull
  outline typically needs a renderer feature), `physics-3d-collision` (hurtboxes in
  `Code/Unity/Runtime`), `initialize-ai-navigation`, `audio-setup-mixers`, `optimize-audio`,
  `localization`, `unity-package-management`, and `ui-imgui` — see §4b.
- **Irrelevant (13):** nine 2D skills in a 3D RPG (`2d-pixel-perfect`, sprite and tilemap skills), plus
  `new-unity-project`, `migrate-birp-to-urp` (already URP), `optimize-web` (no web build), and
  `optimize-text-mesh-pro` — **confirmed: TextMeshPro is not used anywhere in `Game/Assets/_Game`.**
- **Hazardous for this product (4):** `implement-in-app-purchases` and `levelplay-unity-integration`
  (ad mediation) contradict *premium*; `setup-multiplayer-services` and `setup-vivox-voice-chat`
  contradict *offline-complete* and *single-player*, and both carry teen-rating and privacy implications.
  These are Unity's skills for Unity's broad audience, not errors — but in this repo they are hazards, of
  the same class as the `analytics-engineer` agent in §5.

**Verdict: keep, and prune.** `NOT SOURCEABLE — whether individual skills inside an enabled plugin can be
disabled without disabling the plugin is not covered by anything read; ListPlugins exposes enable state
per plugin, not per skill.` Even inert skills cost context through their descriptions, in every session.

### 4a. `unity:unity-cli` — the strongest external finding, and the user's call

**VERIFIED — SKILL.md read.** Its opening section is "Drive a running Unity Editor (if one is open)":
with `com.unity.pipeline` installed (Unity 6.0+), the CLI can control a live Editor — create and modify
GameObjects, edit scenes and assets, inspect the hierarchy, run arbitrary C# — with worked examples
(`unity status`, `unity command editor_play`, `unity command eval '…'`) and `--format json|tsv|ndjson`.

**What it would do for us.** Today every Unity interaction is a cold `Unity.exe -batchmode` start paying
full domain-reload and asset-import cost and emitting a megabyte log. A persistent Editor removes the cold
start from the inner loop, and `--format json` removes most of the log-parsing problem by giving
structured output. With 3a's filter hook, the log pain is attacked from both ends.
`Tools/pc/update_and_verify.cmd` keeps its place as the clean-room full verify. And unlike §2d, it is a
**first-party** package — no unlicensed DLL, no unpinned git dependency, no socket server in the player.

It is also honest about its own failure mode, which is why it is worth trusting: when a project has C#
compile errors the Editor boots into **Safe Mode**, where the Pipeline package does not load and the CLI
cannot connect at all — and the skill says so, names the cause, and tells you not to fall back to blind
file-editing. That is obligation 3 satisfied by a third party.

> **Correction from the MCP sweep ([mcp_servers.md](mcp_servers.md) §2a):** the CLI is **already
> installed on this machine** (`unity --version` → `1.0.0-beta.13`) and has an MCP server built in
> (`unity mcp`). The install caution below applies only to `com.unity.pipeline`, which still needs adding
> to `Game/Packages/manifest.json`. The licence gap and the beta status stand.

**Why it cannot be "adopt now".** The documented install is `irm …/install.ps1 | iex` with
`UNITY_CLI_CHANNEL='beta'` — piping a remote script into the shell, on a beta channel, which is the
user's call and not Claude's. It adds `com.unity.pipeline` to `Game/Packages/manifest.json`, and
`unity command eval` running arbitrary C# in the live Editor deserves a deliberate decision.
`NOT SOURCEABLE — the licences of com.unity.pipeline and of the unity CLI binary are not covered by the
plugin's LICENSE.md or by the skill.` **4–8 hours. Verdict: trial, top priority among external items.**

**One genuine open question, not oversold:** one live Editor versus ~40 parallel sessions. Unity holds a
project lock, so this is probably a tool for the developer's foreground session and one designated
session, not for every wave agent. `NOT SOURCEABLE — how the CLI arbitrates several clients against one
Editor, or whether a driven headless Editor is supported, is not covered by the part of SKILL.md read; it
points to references/integration-advanced.md, which is the first thing to read next.`

### 4b. The player-facing UI is runtime IMGUI

**VERIFIED — source read.** A grep across `Game/Assets/_Game/Runtime/UI/*.cs` returns **181 uses of
`GUI.*` and zero of `UnityEngine.UI`, `UnityEngine.UIElements` or `TMPro`**. There are no `.uxml` assets.
`BagWindow.cs` calls itself *"the bag (IMGUI placeholder)"* in its own header. So the bag, bestiary, world
map and NPC dialogue are all built on runtime IMGUI, which Unity positions as an Editor and debug API
rather than a shipping-game UI: no batching, per-frame allocation, no input-system integration, and no
localisation or accessibility story. On a 4 GB GPU target, per-frame UI allocation is also where GC
stutter comes from.

This connects three owners who are currently looking at it separately: `ui-engineer` owns `Runtime/UI/`,
`ux-designer` owns `12_Systems/hud_and_ui.md`, and the `accessibility-specialist` agent needs text scaling
and colourblind modes that IMGUI cannot cleanly provide. **`unity:ui-uitk` is then a migration target
rather than noise**, and `unity:ui-imgui` is the skill that matches today's code. Whether the migration
happens is a user and Canon decision — but the placeholder is self-declared, so someone already knows.

---

## 5. The 74 skills and 61 agents already installed

### 5a. The skills are better written than expected; the defect is structural

**VERIFIED — `perf-profile/SKILL.md` and `gate-check/SKILL.md` read in full, plus a mechanical audit
across all 74.** These are not boilerplate. Both open with an "insufficient input" protocol and carry
`NOT ASSESSED` in their verdict vocabulary; `perf-profile` says outright that *"a metric with no committed
budget is NOT ASSESSED, not a pass"* and warns against measuring against the template's placeholder. That
is `.claude/rules/skill-authoring.md`'s obligations honoured in the skill bodies. **"Noise" is the wrong
frame for the skill layer.**

**The structural defect is paths.** `.claude/agents/` carries the `<!-- ascend-path-map -->` block on
**22 of 61**; `.claude/skills/` carries it on **0 of 74**. Not one of the 74 skills mentions `AETHWYRD`,
`13_Production` or `12_Systems` anywhere, while **136 files under `.claude/skills/` reference studio paths**
(`design/gdd/`, `docs/architecture/`, `production/sprints/`, `production/qa/`). Worked examples:
`perf-profile` instructs *"write the report to `production/polish/[scope]-report-[date].md`"* and
reinforces it; `gate-check` writes `production/stage.txt`. **The only thing standing between a skill run
and a parallel studio folder tree is CLAUDE.md's prose line "Ask before creating a parallel studio
folder"** — a human gate, in a project with ~40 concurrent sessions. By the house standard's own closing
argument, a rule enforced only in prose and never surfaced where it would be violated is, to the reader,
identical to no rule at all. **Adding the path-map block to the ~25 skills that actually write files is
4–8 hours and is the highest-value single fix in this file**, because it converts a 40-session-wide prose
gate into a mechanical one and reuses a remediation the project has already designed.

**The actively misleading part is not the Godot leftovers** — `godot` appears in 56 files and `Unreal` in
50, but almost all are multi-engine branch tables where the Unity row is right and the others are inert,
and CLAUDE.md already says to ignore them. Two exceptions matter, because they decide *how tests run and
where they live* by engine, which is exactly where a wrong branch produces a confident green on an unrun
suite: `smoke-check/references/2-run-tests.md` and `test-setup/references/3-directories.md`.
(`.claude/scripts/godot-parse-check.gd` is simply dead; delete it.)

**The genuinely misleading thing is the static-analysis estimates.** `perf-profile` is candid in its own
rules that static analysis identifies candidates and runtime profiling confirms — yet its output table has
an "Estimated Current" column against a frame budget. **It cannot profile a GTX 1650 with 4 GB.** It reads
`Update()` bodies and guesses, and the binding constraint here is a VRAM ceiling that no amount of reading
C# reveals. A ranked list of candidates is a legitimate artifact; a number in an "Estimated Current" cell
beside 16.67 ms is not, and that cell is the one a reader will quote. The same caution applies to
`asset-audit`, `balance-check` and `content-audit`.

### 5b. The agents: the path fix stopped before the engineers

**VERIFIED — mechanical audit of all 61 plus `agent_team.md`.** The split is clean: the **27** named in
`agent_team.md` are the project's own team with file ownership; the other **34** came from the studio pack,
and 10 Godot/Unreal specialists are correctly parked in `.claude/agents-retired/`.

**22 of the 34 studio agents carry the path-map block. The 12 that do not are:** `ai-programmer`,
`devops-engineer`, `engine-programmer`, `gameplay-programmer`, `prototyper`, `tools-programmer`,
`ui-programmer`, `unity-addressables-specialist`, `unity-dots-specialist`, `unity-shader-specialist`,
`unity-specialist`, `unity-ui-specialist`. That is not a random twelve — it is **every engineer and every
Unity specialist**, precisely the agents that would write to `Game/Assets/_Game/Runtime`,
`Code/Ascend.Core/` and the shaders, and therefore precisely the ones where a wrong path writes code to
the wrong place. The remediation pass walked the designers, directors and producers and stopped before the
engineers. **1–2 hours with a known-good template to copy.**

**Four agents are actively wrong for this product**, and one is a rule conflict rather than a mismatch:
`network-programmer` (no multiplayer exists; `.claude/rules/network-code.md` likewise), `live-ops-designer`
(battle passes in a premium offline RPG is a category error), `community-manager` (not a development role
in a one-person project), and — the one that matters — **`analytics-engineer`**, whose job is event
tracking and telemetry pipelines in a game that must be **offline-complete**. An agent whose purpose
contradicts a hard product constraint is the one that could do real damage if a session took it
seriously. Retire all four to `.claude/agents-retired/`, which already exists for exactly this.

Borderline, judged on constraints rather than labels: `unity-dots-specialist` will propose an architecture
the project deliberately has not chosen; `unity-addressables-specialist` is plausible for streaming but
Addressables on an offline single-player game is often complexity for nothing; `economy-designer` overlaps
`items-designer` and `systems-designer`; and **`accessibility-specialist` is worth keeping** — remapping,
text scaling and colourblind modes are real Steam expectations and `12_Systems/hud_and_ui.md` is live.

**The merge also produced about a dozen duplicate-role pairs** — `ai-engineer`/`ai-programmer`,
`gameplay-engineer`/`gameplay-programmer`, `ui-engineer`/`ui-programmer`,
`core-rules-engineer`/`engine-programmer`, and so on. CLAUDE.md anticipates the name clash for five
agents, but the dangerous ones are the pairs with *different* names and the *same* job, which a name rule
cannot disambiguate. File ownership is the only working tie-breaker and nothing surfaces it at
agent-selection time; it should be documented beside the ownership table in `agent_team.md`.

**Containment, cheaply:** 25 of 61 agents declare no `tools:` allowlist, so they get everything. Only 12
set `disallowedTools` — but `disallowedTools: Bash` on `live-ops-designer` and `economy-designer` is a
nice touch: a design agent that cannot run shell commands cannot accidentally mutate the repo. Extending
that to the pure-design agents is cheap, and complements the `read-guard.sh` / `write-guard.sh` already in
`.claude/scripts/`. Note also that `memory: project` is in use on 14 agents; with ~40 sessions, two running
the same agent concurrently against one memory store is the same single-writer assumption that sinks the
auto-commit plugin, and `.claude/rules/agent-memory.md` should be checked against that case.

---

## 6. A negative finding worth reporting

**VERIFIED — `SearchSkills` returned zero results** for "JSON schema validation", "C# dotnet unit
testing", "NUnit xUnit", "Unity performance profiling" and "game design document". The official Anthropic
skills repository lists no game development, Unity, Blender, C#/.NET, JSON-schema or profiling skills;
testing appears only as "testing web apps".

So the project's most distinctive engineering asset — `Tools/validate/build_schemas.js` → `validate.js` →
`run_tests.js`, **770 tests** against `Data/Schemas/`, plus 196 PlayMode tests — **has no off-the-shelf
skill or plugin support anywhere searched**: not in the official repository, not in the user's catalog, not
in the dev-gom marketplace (whose only testing artifact is §2a's parser), not in the official Unity plugin.

The constructive reading: this is the gap to fill in-house. `.claude/rules/skill-authoring.md` plus
`anthropic-skills:skill-creator` are the right tools, the project already has `test-setup`,
`test-helpers`, `regression-suite`, `test-evidence-review` and `test-flakiness` to pattern-match against,
and a house-written `/validate-data` skill wrapping `npm run build` with a `NOT ASSESSED` verdict would fit
better than anything on offer. **Verdict: no external candidate; build in-house.**

---

## Licence traps collected, for `third_party_assets.md`

| Item | Status |
|---|---|
| `websocket-sharp.dll` (unity-editor-toolkit) | **No licence file shipped**, and it would land in `Game/Assets` |
| UniTask, gilzoide/unity-sqlite-net (same) | Git-URL dependencies, one **unpinned**; licences unread |
| 9 `.mp3` files (hook-sound-notifications) | Provenance unstated; dev-time only, so the asset filter is not engaged, but do not assume Apache-2.0 from the repo licence |
| Unity Agent Plugin | **Unity Companion License** — fine for a Unity-dependent project, unusable elsewhere, "AS IS", beta |
| `com.unity.pipeline` and the `unity` CLI | Licences unread; CLI on a **beta** channel, installed by piping a remote script into PowerShell |
| Sketchfab imports via the Blender MCP | **Per-model licences, some non-commercial.** The worst trap of the set, because an imported model looks like any other asset. See [mcp_servers.md](mcp_servers.md) §1a |
| Community Unity MCP servers | MIT through to **GPLv3**; GPLv3 inside `Game/Assets` of a closed-source commercial game is a genuine legal problem, not a technicality. `CoplayDev/unity-mcp` is **MIT — VERIFIED, LICENSE read** |
| dev-gom marketplace | **Apache-2.0 — VERIFIED, LICENSE and NOTICE read** |

---

## Still open

Queue for the next pass, in priority order.

1. `unity-cli/references/integration-advanced.md` — covers "launching a headless Editor to drive"; should
   settle how one Editor serves many sessions (§4a).
2. The `com.unity.pipeline` and `unity` CLI licences — unread, and they block any "adopt now" on §4a.
3. `code.claude.com/docs/en/settings-reference` — for `autoContinueAtUsageLimit` scope, `idleCompaction`,
   `crossSessionInbound` and `disableAllHooks`.
4. `code.claude.com/docs/en/cli-reference` — `--max-budget-usd` semantics, headless `claude -p` and
   `--max-turns` for unattended waves.
5. The code-intelligence docs — which plugin covers C#/.NET and its language server's licence (§3h).
6. The `Stop` hook input schema — whether `stop_hook_active` is a stdin field or an environment variable.
7. Whether individual skills inside an enabled plugin can be disabled (§4) — decides whether the 13 inert
   and 4 hazardous Unity skills can be pruned without losing the 11 good ones.
8. `auto-release-manager/skills/scripts/git_operations.py` — read for bare `git` versus
   `-c safe.directory=` before trialling it.
9. `anthropic-skills:unity-3d-rigging-hitboxes` and `anthropic-skills:fantasy-world-building` — both judged
   from their descriptions only; both look genuinely on-subject and deserve a real read. The second's own
   description names this project.
10. `.claude/scripts/` (34 shell scripts, only sampled) and `.claude/rules/` (14, only `skill-authoring.md`
    read in full).

**Resolved elsewhere:** the Blender MCP's identity, licence and telemetry were an open question in this
sweep and are answered in [mcp_servers.md](mcp_servers.md) §1 and §1d from the package source — it is
`ahujasid/blender-mcp` (MIT), and `disable_telemetry` only sets consent false while leaving a pseudonymous
usage stream running.
