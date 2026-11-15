# Video tutorials and conference talks

> Mined, not linked. Each video was fetched and scanned with the repo's own tool
> (`python Tools/tutorial_vision/tv.py fetch <url>` then `scan <id>`, docs:
> [tutorial_vision.md](../tutorial_vision.md)), and the frames were read. Timestamps below point at
> what is on screen, including steps the narrator never says out loud. Nothing is quoted from a
> transcript; the cache under `.tutorial_cache/` is other people's content and stays out of git.
>
> Entry format and the verification vocabulary: [README.md](README.md).

**Tool state at the time of this sweep (2026-11-15):** `python Tools/tutorial_vision/test_tv.py`
returned **`OK: 0 failed`** (18 checks). `yt-dlp`, `ffmpeg` and `ffprobe` are on PATH; **Tesseract is
not installed**, so the OCR hint column in `review.md` is empty and every frame below was read
visually rather than through OCR. That is the documented fallback, not a failure.

---

## 1. Making a Toon Shader with Unity! (Shader Graph tutorial) — Unity, 6:27

`Verified: source read` — fetched and scanned here (`Youtube__jTXd3x6gOY`, 60 frames, 119 crops,
5 contact sheets, 155 transcript cues). Source: https://www.youtube.com/watch?v=_jTXd3x6gOY

**1. What it is.** Unity's own channel building a cel shader in Shader Graph with a custom HLSL
lighting function, because Shader Graph's built-in Lit master stack will not give you raw `N·L`
before it is shaded. It covers the lighting maths, the banding, a ramp texture, and the HLSL file
that feeds the graph.

**2. What it would do for us.** It is the direct comparison for
`Game/Assets/_Game/Art/Shaders/AscendToon.shader` (210 lines, hand-written HLSL, two-tone
smoothstep with a violet shadow tint and an inverted-hull outline). Two things in it we do not have:

- **A ramp texture instead of a `smoothstep` pair.** At **2:16–2:30** and again at **4:05** the graph
  runs the lighting term into a `Sample Texture 2D LOD` whose texture is a narrow gradient strip
  (visible as the green/white/yellow bars beside the graph at **1:44**, **2:06**, **2:07**). The band
  count, the band softness and the shadow hue all live in that strip. For us that would move
  `_ShadowStep`, `_ShadowSoftness` and `_ShadowTint` out of shader properties and into an image the
  anime-fantasy-director can author and review on a contact sheet, without a shader edit per look.
  `13_Production/art_direction.md` §9 already defines three-tone ground colours; a ramp is the same
  idea applied to lighting.
- **A `SHADERGRAPH_PREVIEW` fallback branch.** At **5:28** the HLSL file is open in the editor and
  every function is wrapped: `#if SHADERGRAPH_PREVIEW` returns a fabricated light (direction
  `half3(0.5, 0.5, 0)`, white colour, attenuation 1) and `#else` calls `GetMainLight()`. Without it
  the graph preview is black, because the preview window has no scene light. This is never said
  aloud and is the single most common reason a custom-lighting graph "doesn't work".

**3. Cost, licence and requirements.** Free to watch. No account, no key, no GPU cost. **The
technique is reusable; the video's node names are not.** The title bar at **0:02** reads
`Unity 2019.2.0b7`, and the narration at **0:05** says Shader Graph "6.9.1" — this is a 2019-era
tutorial. The graph ends at an **Unlit Master** node (**1:44**), which Unity 6 replaced with the
Vertex/Fragment block stack. Our URP is 17.6.0 (`Game/Packages/manifest.json`). Nothing in the video
may be copied as a file; it is a technique, and the HLSL shown is Unity's own sample code, not ours
to paste.

**4. Effort and risk.** Reading it: done, about 20 minutes. Adding a ramp-texture path to
`AscendToon.shader` as an *optional* `_RampTex` with the existing smoothstep as the fallback:
**4–6 hours**, including a ramp for each of the material families in
`13_Production/anime_building_style.md` and a contact-sheet re-render to compare. Risk is low and
contained: the existing two-tone path stays, and no material breaks if `_RampTex` is unset. The real
risk is art drift — a ramp makes it easy to produce twenty slightly different looks, so it needs the
director's sign-off like any other style knob.

**5. Verdict. Trial** — the ramp-texture idea is worth 4–6 hours on `AscendToon.shader`; the video's
2019 node layout is not worth following step by step.

**Also worth writing down** (read off the frames, not narrated):

| Time | What is on screen |
|---|---|
| 1:34 | Material inspector: `Toon Offset 0.221`, `Toon Smoothness 0.023`, `Toon Brightness 0.692`, with **Enable GPU Instancing** ticked and render queue 2990. Three knobs, not ten — a useful discipline. |
| 2:01–2:10 | The whole scene is switched to a white/grey material so the band edge is tuned on **lighting alone**, with colour out of the way. We have no equivalent debug view in `Tools/blender/toon_preview.py` or in the Unity scene. |
| 4:18–4:32 | `Calculate Lighting` is a subgraph holding two custom-function nodes, `Calculate Main Light` and `Calculate Additional Lights`, each emitting Diffuse and Specular, summed by two `Add` nodes. Splitting main from additional lights is what lets the main light be banded hard while fill lights stay smooth. |
| 4:36 | Inside `Calculate Main Light`: an `NdotL` group, an `Attenuation` group and a `Direct Specular` group, kept as three visually separate clusters. |
| 5:28 | The HLSL: `MainLight_half(float3 WorldPos, out half3 Direction, out half3 Color, out half DistanceAtten, out half ShadowAtten)`, and a specular helper converting smoothness to a specular power with `exp2(10 * Smoothness + 1)` before calling URP's `LightingSpecular`. |
| 5:00–5:11 | Specular colour is driven as a *flat tint* picked from a colour wheel — the anime look comes from a coloured specular lobe, not a white one. Our `_RimColor` default `(1, 0.97, 0.9, 0.22)` is already near-white; a tinted variant is a cheap experiment. |

---

## Not assessed

Obligation 1 of `.claude/rules/skill-authoring.md`: a step that could not run says so by name.

| Video | Why | What to do |
|---|---|---|
| **Asset streaming in Valheim — Unite 2025** (Unity, 34:56, `Fzu2Das_1FU`) | `NOT ASSESSED` — the fetch was refused with `HTTP Error 429: Too Many Requests`. The tool reports "the host refused this machine (bot check / rate limit). This tool does not work around that," and it was not worked around. | Re-run `python Tools/tutorial_vision/tv.py fetch https://www.youtube.com/watch?v=Fzu2Das_1FU` later from the home connection, spaced out from other fetches. This is the highest-value unmined item in the queue: a shipped open-world game's streaming approach, on Unity's own channel. |
| **Understanding Unity memory — Unite 2025** (Unity, 40:14, `0y3erF2tzbI`) | `NOT ASSESSED` — same 429 refusal. | Same; it is the best single source for the 4 GB VRAM budget question. |

---

## Queue

Remaining shortlist, in fetch order, with why each was chosen:

1. `Fzu2Das_1FU` — Asset streaming in Valheim, Unite 2025 (streaming; retry after rate limit).
2. `0y3erF2tzbI` — Understanding Unity memory, Unite 2025 (low-end budget; retry).
3. `BhhavYuT0E0` — Toon Shading with Shader Graph, Unity 6 URP (18:22) — the Unity 6 counterpart to entry 1.
4. `s7NFsEPBtcA` — Blender geometry-nodes procedural dungeons (30:25) — `Tools/blender/` procgen.
5. `IyzSkId4yCg` — Automate Steam builds from Unity (13:24) — build and release pipeline.
6. `p70Vj-c9eLA` — Procedural foot placement with Animation Rigging (15:52) — `Runtime/Player/FootIK.cs`.
7. `79Ud-hlTRLM` — Unity's own Toon Shader package (5:34) — fact-check of `com.unity.toonshader`.

**Already in the cache from an earlier session, not re-scanned:** `Youtube_iDqDPsjrz94`, the GDC talk
"A No-Nonsense Approach to Designing Horizon Zero Dawn's Robot Dinosaurs" (60:57). It is a creature
and behaviour design talk rather than a technique tutorial; it belongs to the bestiary-designer and
anime-fantasy-director rather than to this library.
