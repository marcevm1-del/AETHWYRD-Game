# Video tutorials and conference talks

> Mined, not linked. Each video was fetched and scanned with the repo's own tool
> (`python Tools/tutorial_vision/tv.py fetch <url>` then `scan <id>`, docs:
> [tutorial_vision.md](../tutorial_vision.md)), and the frames were read. Timestamps point at what is on
> screen, including steps the narrator never says out loud. Nothing is quoted from a transcript; the
> cache under `.tutorial_cache/` is other people's content and stays out of git.
>
> Entry format and verification vocabulary: [README.md](README.md).

**Tool state (2026-11-15):** `python Tools/tutorial_vision/test_tv.py` returned **`OK: 0 failed`** (18
checks). `yt-dlp`, `ffmpeg` and `ffprobe` are on PATH; **Tesseract is not installed**, so the OCR hint
column in `review.md` is empty and every frame below was read visually. That is the documented fallback,
not a failure.

**Five of eight videos were mined. Three fetches were refused with HTTP 429 and are recorded as
NOT ASSESSED below, by name.** The tool reports "the host refused this machine (bot check / rate limit).
This tool does not work around that," and it was not worked around.

---

## 1. Making a Toon Shader with Unity! (Shader Graph) — Unity, 6:27

**VERIFIED — fetched and scanned here** (`Youtube__jTXd3x6gOY`, 60 frames, 119 crops, 5 sheets, 155
transcript cues). https://www.youtube.com/watch?v=_jTXd3x6gOY

**1. What it is.** Unity's own channel building a cel shader in Shader Graph with a custom HLSL lighting
function, because the built-in Lit stack will not hand you raw `N·L` before it is shaded. It covers the
lighting maths, the banding, a ramp texture, and the HLSL file that feeds the graph.

**2. What it would do for us.** It is the direct comparison for
`Game/Assets/_Game/Art/Shaders/AscendToon.shader` (210 lines, two-tone smoothstep, violet shadow tint,
inverted-hull outline). Two things in it we do not have:

- **A ramp texture instead of a `smoothstep` pair.** At **2:16–2:30** and **4:05** the lighting term runs
  into a `Sample Texture 2D LOD` whose texture is a narrow gradient strip (the green/white/yellow bars
  visible beside the graph at **1:44**, **2:06**, **2:07**). Band count, band softness and shadow hue all
  live in that strip. For us that moves `_ShadowStep`, `_ShadowSoftness` and `_ShadowTint` out of shader
  properties and into an image the anime-fantasy-director can author and review on a contact sheet,
  without a shader edit per look. `13_Production/art_direction.md` §9 already defines three-tone ground
  colours; a ramp is that idea applied to lighting.
- **A `SHADERGRAPH_PREVIEW` fallback branch.** At **5:28** the HLSL is open in the editor and every
  function is wrapped: `#if SHADERGRAPH_PREVIEW` returns a fabricated light and `#else` calls
  `GetMainLight()`. Without it the graph preview is black, because the preview window has no scene light.
  Never said aloud, and the most common reason a custom-lighting graph "doesn't work".

**3. Cost, licence and requirements.** Free to watch. **The technique is reusable; the node names are
not.** The title bar at **0:02** reads `Unity 2019.2.0b7` and the narration at **0:05** says Shader Graph
6.9.1 — a 2019-era tutorial. The graph ends at an **Unlit Master** node (**1:44**), which Unity 6 replaced
with the Vertex/Fragment block stack; our URP is 17.6.0. Nothing may be copied as a file: the HLSL shown
is Unity's sample code, not ours to paste.

**4. Effort and risk.** Reading it: done, ~20 minutes. Adding an **optional** `_RampTex` path to
`AscendToon.shader` with the existing smoothstep as fallback: **4–6 hours**, including a ramp per material
family in `13_Production/anime_building_style.md` and a contact-sheet re-render. Risk is low and
contained — no material breaks if `_RampTex` is unset. The real risk is art drift: a ramp makes twenty
slightly different looks easy, so it needs the director's sign-off like any other style knob.

**5. Verdict. Trial** — the ramp idea is worth 4–6 hours; the 2019 node layout is not worth following
step by step.

**Read off the frames, not narrated:**

| Time | What is on screen |
|---|---|
| 1:34 | Material inspector: `Toon Offset 0.221`, `Toon Smoothness 0.023`, `Toon Brightness 0.692`, **Enable GPU Instancing** ticked. Three knobs, not ten — a useful discipline. |
| 2:01–2:10 | The whole scene is switched to a white/grey material so the band edge is tuned on **lighting alone**, colour out of the way. We have no equivalent debug view in `Tools/blender/toon_preview.py` or in the Unity scene. |
| 4:18–4:32 | `Calculate Lighting` is a subgraph holding `Calculate Main Light` and `Calculate Additional Lights`, each emitting Diffuse and Specular, summed by two `Add` nodes. Splitting main from additional is what lets the key light band hard while fill lights stay smooth. |
| 4:36 | Inside `Calculate Main Light`: an `NdotL` group, an `Attenuation` group and a `Direct Specular` group, kept as three separate clusters. |
| 5:28 | `MainLight_half(float3 WorldPos, out half3 Direction, out half3 Color, out half DistanceAtten, out half ShadowAtten)`, and a specular helper converting smoothness to a power with `exp2(10 * Smoothness + 1)` before calling URP's `LightingSpecular`. |
| 5:00–5:11 | Specular colour is driven as a flat **tint** picked from a colour wheel — the anime look comes from a coloured specular lobe, not a white one. Our `_RimColor` default `(1, 0.97, 0.9, 0.22)` is near-white; a tinted variant is a cheap experiment. |

---

## 2. Automate Your Steam Builds With One Click In Unity! — Game Dev Guide, 13:24

**VERIFIED — fetched and scanned here** (`Youtube_IyzSkId4yCg`, 60 frames, 101 crops, 5 sheets, 412
transcript cues). https://www.youtube.com/watch?v=IyzSkId4yCg

**1. What it is.** Building an in-editor tool that goes from a Unity build to an uploaded Steam depot in
one button: a `ScriptableObject` holding the config, a UI Toolkit editor window bound to it, and
SteamPipe driven from the editor.

**2. What it would do for us.** This is the shape `Game/Assets/_Game/Editor/BuildPlayer.cs` and
`Tools/pc/update_and_verify.cmd` are missing a top half of. Today `BuildPlayer.BuildRing0` makes a player
and the .cmd takes screenshots; there is no release step at all, and
[13_Production/production.md](../production.md) has no Steam upload path. The concrete, copyable *pattern*
(not code):

| Time | Pattern |
|---|---|
| **2:13–2:33** | `[CreateAssetMenu(menuName = "Steam Builder/Steam Builder Config")] public class SteamBuilderConfig : ScriptableObject` with `appId`, `unityBuildFolder = "..\\Builds"`, `buildOutput = "output"`, `contentRoot = "content"`. **Config as an asset, not as `EditorPrefs`** — so it is versioned, diffable and reviewable, which fits a repo where `Data/` is already canonical. |
| **3:05–3:28** | The window is generated by Unity's **UI Toolkit Editor Window Creator** (C# + UXML + USS), not IMGUI. |
| **3:20, 6:55** | `[MenuItem("Window/Tools/SteamBuilderWindow")]` **and** `[MainToolbarElement("Steam Button", defaultDockPosition = MainToolbarDockPosition.Right)]` — the Unity 6 main-toolbar extension API, with the icon loaded by `EditorGUIUtility.Load("steam.png")`. An on-screen note says icons must live in a folder named **"Editor Default Resources"**. |
| **6:45** | Unity 6 UI Toolkit **data binding**: `root.dataSource = this;`, `configArea.dataSource = config;`, `branchDropdown.dataSource = config;`, and `EditorUtility.OpenPropertyEditor(config)` behind an Open button. No manual field-sync code. |
| **6:42–6:50** | The finished window: App Id, Unity Build Folder, Content Root, Build Output, a Depots list, a Branch dropdown, a Build Description box, and four buttons — Build, Copy, Upload, **Build And Upload**. |
| **9:10–9:11** | Steam credentials are read from **Windows environment variables**: `STEAM_ID`, `STEAM_PASSWORD`, `STEAM_SDK`, set in System Properties → Environment Variables. The password is blacked out in the video. |

**3. Cost, licence and requirements.** The video is free. **The thing it automates is not: Steamworks
needs a Steam partner account and an appid, which is a paid registration. Needs the user's decision:
money / account.** It also needs the Steamworks SDK downloaded locally (`STEAM_SDK` points at it), and
that SDK carries Valve's own licence, which would need a row in
[third_party_assets.md](../third_party_assets.md).

**A caution the video does not give.** `STEAM_PASSWORD` in a plain user environment variable is readable
by every process running as that user, and Steam Guard will usually force an interactive code on a new
machine anyway. If this is built, the credential half belongs to the user alone: **Claude never enters
the Steam password, never stores it, and never runs the upload step** — same rule as `GEMINI_API_KEY` in
`Tools/ai_images/`. The right division is that Claude builds and stages the depot; the user presses
upload.

**4. Effort and risk.** A config `ScriptableObject` plus a build-and-stage window, without the upload
step: **6–10 hours**. Adding upload once an appid exists: **2–4 hours** more. Low risk — it is editor-only
code in `Game/Assets/_Game/Editor/`, it touches nothing at runtime, and it can wrap the existing
`BuildPlayer.BuildRing0` rather than replacing it. The main lock-in is UI Toolkit and the Unity 6
main-toolbar API, both first-party.

**5. Verdict. Trial, in two halves** — build the config asset and the staging window now (useful
immediately, no account needed); leave the upload half until the user decides about a Steam partner
account.

**Skip:** 7:58–8:37 is a sponsor segment for an unrelated AI level-design tool. It is not part of the
tutorial and was not assessed.

---

## 3. Unity's Toon Shader Is FREE and Awesome (URP / HDRP) — SpeedTutor, 5:33

**VERIFIED — fetched and scanned here** (`Youtube_79Ud-hlTRLM`, 60 frames, 105 crops, 5 sheets), **and
the package claim was checked against Unity's own documentation** rather than taken from the video.
https://www.youtube.com/watch?v=79Ud-hlTRLM

**1. What it is.** A walkthrough of `com.unity.toonshader` (Unity Toon Shader, UTS3 — successor to the
Unity-chan Toon Shader), shown on the Unity-chan sample character.

**2. What it would do for us.** It is the "should we just use Unity's?" question for
`AscendToon.shader`, and the answer is no — but one thing in it is worth taking. At **0:11** the video
puts up UTS3's own lighting-terminology diagram on a sphere: **Highlight, CenterLight, Halftone,
Terminator, Core of Shadow, Reflected Light, Cast Shadow, Occlusion Shadow**. That is the vocabulary a
full anime shader is built around, and `AscendToon.shader` currently expresses only three of those zones
(lit, shadow via `_ShadowStep`, and a rim). If the ramp-texture work in entry 1 happens, those names are
the checklist for what the ramp should be able to express, and they give the anime-fantasy-director
shared words for a review note. Later frames (**0:16–0:22**) show the same character under coloured point
lights, which is where a two-tone shader usually falls apart.

**3. Cost, licence and requirements.** **VERIFIED against
`docs.unity3d.com/Packages/com.unity.toonshader@0.16/manual/`, read 2026-11-15: the package is at
`0.16.1-preview`** and states compatibility with Built-in, URP and HDRP, noting that feature availability
differs per pipeline. `NOT SOURCEABLE — the documentation gives no general minimum Unity version; the
only version it names is Unity 6.3, and that is for 2D URP support specifically.` Free, no account.

**4. Effort and risk. The version string is the whole story: `-preview`.** A preview package is not a
production dependency — it can change shape or be dropped, and it would sit underneath the entire look
of the game. Adopting it would also mean discarding a working 210-line shader whose inverted-hull outline
is wired to the smoothed normals that `BuildingImport.cs` writes into vertex colour, and whose three-tone
palette is pinned in `art_direction.md` §9. That is a rewrite of the art pipeline's bottom layer for a
preview dependency.

**5. Verdict. Reject as a dependency; adopt its vocabulary.** Steal the eight-zone terminology for the
style guide and the ramp work; do not take the package. (The `-preview` tag alone is enough under the
house rule that an unverified or unstable dependency cannot be "adopt now".)

---

## 4. How to Create Procedural Foot Placement in Unity with Animation Rigging — Games of Goutam, 15:52

**VERIFIED — fetched and scanned here** (`Youtube_p70Vj-c9eLA`, 60 frames, 134 crops, 5 sheets, 285
transcript cues). https://www.youtube.com/watch?v=p70Vj-c9eLA

**1. What it is.** Foot IK on uneven ground using Unity's Animation Rigging package: feet raycast down,
plant on the surface, and the hips drop so the character does not float or sink.

**2. What it would do for us.** `Game/Assets/_Game/Runtime/Player/FootIK.cs` already exists, and the
terrain this has to work on is the one `Tools/blender/ascend_terrain/` generates — 20 m resolution with
ridged detail, gullies, dune fields and settlement pads with smooth skirts. The first minute
(**0:00–0:35**) is the demo, and it is the useful part for judging fit: the character walks across
hard-angled ramps and a field of hemispherical bumps, which is a harsher test than our terrain, and the
feet hold. **The implementation section begins at 1:10** — an on-screen card says so from **0:11**
onwards, which is a sign the author knows the first minute is a showreel.

**3. Cost, licence and requirements.** Free to watch. The technique needs **`com.unity.animation.rigging`,
which is NOT in `Game/Packages/manifest.json`** — adding it is a first-party, free package, but it is a
new dependency on the animation pipeline that `.claude/agents/animator-rigger.md` owns. `NOT SOURCEABLE —
the Animation Rigging package's version and Unity 6 support were not read in this sweep; check
`docs.unity3d.com` before adding it.`

**4. Effort and risk.** `NOT ASSESSED — the implementation section from 1:10 onward was not read frame by
frame in this pass`, so no hours estimate is given here rather than a guessed one. What can be said: the
cost is not the IK itself but the per-frame raycasts against terrain for every character that needs it,
and with monsters and companions on screen that is a budget question on a GTX 1650, not a correctness
question.

**5. Verdict. Hold, pending a second pass** — the demo is convincing and the subject matters, but an
entry whose core section has not been read should not carry a stronger verdict than that. Queued below.

---

## 5. Toon Shading with Shader Graph — Unity 6 URP — Digvijaysinh Gohil, 18:22

**VERIFIED — fetched and scanned here** (`Youtube_BhhavYuT0E0`, 60 frames, 96 crops, 5 sheets, 355
transcript cues). https://www.youtube.com/watch?v=BhhavYuT0E0

**1. What it is.** The Unity 6 counterpart to entry 1: the same cel-shading subject, done in a current
URP project rather than a 2019 one.

**2. What it would do for us.** It would have been the version-correct companion to entry 1 — the
Vertex/Fragment block stack in place of `Unlit Master`.

**3. Cost, licence and requirements.** Free to watch. One content note: the demo model is a recognisable
Pokémon-style creature. Whatever its provenance, it is not something this project would use, and it is
not a reason to doubt the shading technique.

**4. Effort and risk.** **NOT ASSESSED, and the reason is a limitation in our own tool, which is the
finding worth keeping.** The video is a talking-head recording with a webcam inset in the lower-left
corner. `tv.py scan` chooses frames by how much of the screen changed between samples — and a moving face
changes pixels continuously, so **the 60-frame budget was spent on the presenter rather than on the
Shader Graph**. Sheet 3 covers 0:37 to 0:50 in twelve frames, every one of them a near-identical editor
window with a different facial expression. The scan is not broken; it optimised for the wrong region.

**5. Verdict. Hold** — re-scan with the webcam region excluded before judging the tutorial.

**This is a concrete improvement to `Tools/tutorial_vision/`**, and it generalises past this one video:
most modern tutorials have a face cam. Either add a `--ignore-rect x,y,w,h` option that zeroes a region
before the activity measure (the scanner already has a cursor-sized-region exclusion, so the mechanism
exists), or detect a small persistent high-activity rectangle pinned to a corner and discount it
automatically. About **3–5 hours** in `Tools/tutorial_vision/tv.py`, owner `youtube-beta`, and it would
raise the yield of every talking-head tutorial the project ever scans. Verdict: **adopt** — it is cheap
and it compounds.

---

## Not assessed

Obligation 1 of `.claude/rules/skill-authoring.md`: a step that could not run says so by name.

| Video | Why | What to do |
|---|---|---|
| **Asset streaming in Valheim — Unite 2025** (Unity, 34:56, `Fzu2Das_1FU`) | `NOT ASSESSED` — fetch refused, `HTTP Error 429: Too Many Requests`, on the first run and on three spaced retries. | Retry from the home connection, well separated from other fetches. **This is the highest-value unmined item here:** a shipped open-world game's streaming approach, on Unity's own channel, and the subject [techniques_and_systems.md](techniques_and_systems.md) A1 says is designed but unbuilt. |
| **Understanding Unity memory — Unite 2025** (Unity, 40:14, `0y3erF2tzbI`) | `NOT ASSESSED` — same refusal, same retries. | Same. It is the best single source for the 4 GB VRAM budget question. |
| **Blender 3.3 — Procedural Dungeons with Geometry Nodes** (Retroshaper, 30:25, `s7NFsEPBtcA`) | `NOT ASSESSED` — same refusal. | Retry. Relevant to `Tools/blender/` and to dungeon generation; lower priority than the two Unite talks, and its Blender 3.3 vintage means node names will differ from Blender 5.2. |

A plain, honest note on why: eight YouTube searches and eight fetches were run from this machine inside a
few minutes, and the rate limit is the predictable result. A future sweep should space fetches out from
the start rather than batching them.

---

## Queue

1. The three refused videos above, spaced out.
2. A second pass on entry 4 (`p70Vj-c9eLA`) from **1:10 onward**, where the implementation is.
3. A re-scan of entry 5 (`BhhavYuT0E0`) once the webcam-region exclusion exists.
4. `WbZpj8WcjN0` — "Build a beautiful 3D open world in 5 minutes (updated for Unity 6!)", and
   `JOPgk3D66kA` — "How to Optimize Your Unity Game Worlds". Both were found in the search sweep and not
   fetched.
5. `gUZ9YXrJOAo` — Unity CI/CD with GitHub Actions, as the hosted counterpart to entry 2's local pipeline.

**Already in the cache from an earlier session, not re-scanned:** `Youtube_iDqDPsjrz94`, the GDC talk
"A No-Nonsense Approach to Designing Horizon Zero Dawn's Robot Dinosaurs" (60:57). A creature and
behaviour design talk rather than a technique tutorial; it belongs to the bestiary-designer and the
anime-fantasy-director rather than to this library.

**How the shortlist was chosen**, since the brief asked for sources to be weighed: ordinary web search on
these subjects returns mostly SEO aggregator pages — one search for Unity 6 toon shading returned eleven
near-identical scraper domains and no primary source. Searching YouTube directly through `yt-dlp`
(`ytsearch<N>:<query>` with `--flat-playlist --print`) returns real ids, durations, channels and view
counts, which makes it possible to prefer Unity's own channel and Unite talks over affiliate content.
That technique is worth reusing and costs nothing.

---

## Added 2026-11-21: three Blender tutorials, mined while teaching myself Blender

Fetched and scanned with `tv.py` (cache `Youtube_<id>`). Of the five short Blender videos queued, **three
scanned**, one (`4tt3tW1Pz5U`, colour-palette atlas textures) returned **HTTP 403 on the video data**, and one
(`agpDTz4ZqYA`, Blender 4.5 vertex colours into Unity 6 — the most directly relevant) was **refused with HTTP
429**. Neither was worked around. **Both stay NOT ASSESSED.**

### 6. Rigging for impatient people — Joey Carlino, 10:02 (`DDeB4tDVCGY`)

`Verified: source read` for the chapter list and the weight-paint frames I opened (contact sheet 2, 3:19–4:40);
the other four sheets were **not read**. https://www.youtube.com/watch?v=DDeB4tDVCGY

**What it teaches.** Chapters: armature setup (0:00), names and symmetry (1:23), **automatic weights and common
issues (1:56)**, weight tricks (3:13), weight-paint settings (4:17), rigid rigging (5:34), inverse kinematics
(7:32). What is on screen, including what the narration does not say:

| Time | On screen |
|---|---|
| 3:36 | The Weight Paint **Weights menu**: *Assign Automatic from Bones*, *Assign from Bone Envelopes*, *Normalize All*, *Normalize*, *Mirror*, *Invert*, *Clean*, *Quantize*, *Levels*, *Smooth*, **Transfer Weights**, **Limit Total**, *Fix Deforms*, *Set Weight*, *Locks*. This is the whole toolbox in one menu |
| 3:39 | A split view labelled "old weights / new weights" on a creature-shaped mesh with four limbs — the before/after of fixing a bad auto-weight on an arm |
| 3:53 | **Edit → Lock Object Modes** ticked. The tutorial turns it *off* so that you can switch between the armature and the mesh without leaving weight-paint — the single most useful workflow switch shown |
| 4:27–4:40 | Weight-paint **Options**: *Auto Normalize*, *Lock-Relative*, *Multi-Paint*, *Restrict*; a mesh with a heat-map of one bone's influence fading across the shoulder |

**What it does for us.** It is the manual counterpart to the automatic path this session verified
([blender_primer.md](blender_primer.md) §13) and to `Tools/blender/rig_creature.py`, which caps weights at four
influences. **Limit Total is that cap's UI name**, and **Transfer Weights is the tool for the missing LOD1/LOD2
weight transfer** the monster sweep identified ([§16b](blender_primer.md)). The common issues it shows at
1:56 (an arm pulling in the torso) are what to look for when `rig_creature.py` output deforms badly.

**Cost and verdict.** Free; Blender 3.x-era UI, so menu positions drift in 5.3 but the operation names match
the API. **Effort:** none to adopt, it is reference. **Verdict: adopt as reading** for whoever debugs a rig
by hand. `NOT ASSESSED` — chapters 5:34 (rigid rigging) and 7:32 (IK) were not read frame by frame.

### 7. Video Game Textures Explained — Vertex Arcade, 5:29 (`53Rdzthjuu0`) and 8. What are Blender Geometry Nodes? — Blender, 4:25 (`kMDB7c0ZiKA`)

**Scanned, not read.** I have only the chapter lists: textures — Texture Types (0:50), Other Texture Types
(2:15), **Packed Texture (3:40)**, Node Wrangler (4:25); geometry nodes — what they are (0:09), how they work
(0:49), the power of procedural systems (2:45). The textures video bears on **channel packing**, which is the
same idea as the vertex-channel budget in [blender_primer.md](blender_primer.md) §15 (E22); the Geometry Nodes
one is Blender's own 4-minute orientation. **NOT ASSESSED** beyond that — the sheets are in the cache for a
later pass.

### Queue additions

- `agpDTz4ZqYA` — Blender 4.5 vertex colours into Unity 6 (3:33): **first priority**, retry spaced out.
- `4tt3tW1Pz5U` — colour-palette texture atlas (5:44): retry.
- The 49-minute official Blender scripting talk (`wWTAQP7-ZUQ`) was **stopped mid-download** and is read from
  its captions only ([blender_primer.md](blender_primer.md) §10).
