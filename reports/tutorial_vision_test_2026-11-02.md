# Tutorial Vision test report (2026-11-02)

Run in the cloud session: Linux, 4 CPUs, ffmpeg 6, yt-dlp 2026.10.26, Tesseract 5.3.4, Blender 5.2.3 headless on software OpenGL, no Unity. Tutorial frames stay in the local cache (`.tutorial_cache/`, gitignored). This report holds only our own renders and the numbers.

## 1. Self-test (synthetic tutorial, no network)
`python Tools/tutorial_vision/test_tv.py` returned **18 passed, 0 failed**. It checks:
- a frame after each event (panel at 5 s, value at 10 s, drag from 14–17 s, after the drag);
- the frame budget;
- that the change crop covers the new panel;
- OCR reads "Roughness 0.35";
- rolling captions are de-duplicated and the narration is aligned;
- on-demand crops and frame ranges;
- `compare` scores.

Picked frames: 0, 5.25, 10.25, 14.5, 15.5, 16.5, 17.25 and 21.75 s, that is, exactly the events.

## 2. YouTube access from the cloud
- `yt-dlp` search works.
- Downloads are refused with "Sign in to confirm you're not a bot" (HTTP 429). This is YouTube's bot check on cloud IPs.
- The tool reports this plainly and does **not** work around it: no cookies or accounts.
- On a home PC `yt-dlp` normally works. The tests below therefore use real tutorials from hosts that allow downloads.

## 3. Blender: "Blender Beginner Tutorial 3/4 | Shading" (Blender Foundation, video.blender.org)
- **Fetch:** 11 s (25.9 MB, 1080p, 328 s). No captions exist, so the frames were the only source.
- **Scan:** 98 s; 60 frames, 132 change crops, 5 contact sheets.
- **Steps recovered from frames:**
  - Shading workspace and HDRI preview.
  - Body, face, eyes and feet materials.
  - A 2048 px Color Grid image texture.
  - UV Editing and unwrapping.
- **Exact values, read from 3× crops:** the body colour is scrubbed in three moves over 17–24 s. HSV goes (0.064, 0.381, 0.906) → (0.077, 0.481, 0.906) → **(0.077, 0.481, 0.533)**, with Roughness **0.400**. Eyes are black, Specular 0.396, Roughness 0.240 (frame at 0:33.8). Blender version 2.90.2.
- **Recreated** with `tv_blender.py`: spec `tutorial_vision_test_2026-11-02/owl_body_spec.json`. The 2.90 "Specular" input was mapped automatically to 5.2's "Specular IOR Level".
- **Comparison**, on the lit side face, tutorial frame 0:33.8 vs render:

| Iteration | Preview settings | Mean RGB tutorial | Mean RGB render | Histogram overlap |
|---|---|---|---|---|
| 1 | Standard view, key 400 W, grey world | 0.560 0.445 0.298 | 0.699 0.545 0.428 | 0.015 |
| 2 | Filmic (the tutorial's 2.90 default), key 180 W | same | 0.583 0.486 0.405 | – |
| 3 | + warm world (their outdoor HDRI) | same | **0.583 0.475 0.351** | **0.394** |

  The material itself matches: the base colour in sRGB is (0.533, 0.411, 0.277), against the tutorial's lit surface at (0.560, 0.445, 0.298). The remaining difference is their HDRI, which isn't available. Renders: `owl_body_iter1.png`, `owl_body_iter3.png`.
- **Not done here:** the live Blender session through MCP for Blender. It needs Blender's GUI on the PC and your approval to install.

## 4. Unity: 3DBuzz "Unity Tracking & Analytics, 03 Player Set Up pt 1" (public domain, archive.org)
- **Fetch:** about 5 s. 1620×1080, 776 s, no captions.
- **Scan:** 67 s; 70 frames, 147 crops, 6 sheets.
- **Steps recovered from frames:** new 3D project (Unity 5.5.2f1); Plane with scale **(50, 1, 50)**; Capsules **Body** and **FacingDirection**. FacingDirection gets Rotation Z **90** and Position **(-0.61, 0.2, 0)**. A Rotation Y of 1.28 is typed by mistake and cleared, and this isn't narrated. An empty is created at (-2.3472, -1.042, -0.4296), reset to the origin (not narrated) and renamed **Player**, then Body and FacingDirection are parented under it.
- **OCR:** Tesseract could not read Unity 5's tiny Inspector font. The values were read visually from 1.6–2.5× crops, stacked into one strip to save images.
- **Apply plan (MCP for Unity calls)** is written in the cache's `steps.md`. **Not executed:** there's no Unity Editor in the cloud, and the package isn't installed in the game project yet.
- `TutorialVisionCapture.cs` passes a syntax check, but has not been compiled in Unity.

## 5. Not done, and why
- **MCP config:** writing the project `.mcp.json` (Blender and Unity MCP servers) was blocked pending your approval. The exact `claude mcp add` commands are in `13_Production/tutorial_vision.md`.
- **Live editors:** none of the live Blender or Unity steps ran (no PC connection to the editors).
- **Speech:** narration is not transcribed when a video has no captions.
