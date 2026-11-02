# Tutorial Vision (agent: youtube-beta)

> Learn a technique from a video tutorial by **watching** it, then apply it in Blender or Unity. Built 2026-11-02. Code: `Tools/tutorial_vision/`. Agent: `.claude/agents/youtube-beta.md`. Test report: `reports/tutorial_vision_test_2026-11-02.md`.

## Why frames, not transcripts
Tutorials show far more than they say: a node dragged onto a socket, a value scrubbed from 0.906 to 0.533, a rotation typed and corrected, an object reset to the origin before it becomes a parent. Both test tutorials had **no captions at all**. Tutorial Vision gives Claude the frames, zoomed crops and on-screen text, and Claude (a vision model) reads them. The transcript, when there is one, only labels what the frames show.

## How it works
1. **fetch** (`yt-dlp`): video up to 1080p (small UI text needs the pixels), metadata and chapters, subtitles (manual first, auto-captions second). Local files work too. Everything is cached in `.tutorial_cache/<id>/` (gitignored; it is other people's content).
2. **scan** (FFmpeg + numpy):
   - **Activity scan:** decodes the whole video at 4 fps, small and grey, and measures how much of the screen changes between samples.
   - **Frames kept:**
     - the still frame **after** each burst of activity (the result of an action);
     - the frame **before** it;
     - frames **inside** long movements (dragging, scrubbing, orbiting);
     - scene cuts;
     - a baseline frame every 10 s.
   - **Duplicates:** near-identical frames are dropped. A frame budget (default 60) keeps cost in check.
   - **Grabs:** every kept frame is pulled at full resolution with an accurate seek, and keeps its timestamp.
   - **Change crops:** regions that changed since the previous kept frame are cropped and upscaled up to 4× so small Inspector or node text is legible. A cursor-sized second region is ignored.
   - **OCR:** Tesseract reads the crops, and the full frame when nothing changed. It's a hint only: tiny UI fonts defeat it, so Claude reads the crops itself.
   - **Narration:** each subtitle cue is attached to exactly one frame.
   - **Outputs:** contact sheets (12 frames each, labelled with time and reason) and `review.md`.
3. **look:** Claude opens the sheets, then the frames and crops, and asks for more where two frames don't explain the step between them:
   - `frames --range A B --step 0.25` for fast actions;
   - `--at T --crop x,y,w,h --scale 3 --ocr` for small text.

   Several crops can be stacked into one image to save tokens.
4. **steps.md:** numbered visual steps with timestamps, frame references, exact values and a *not narrated* mark.
5. **apply:**
   - **Blender:** the live session through MCP for Blender, or headless with `tv_blender.py`. It builds node materials from a JSON spec, maps Blender 2.8–3.x socket names to 5.x (Specular → Specular IOR Level, Clearcoat → Coat Weight…), renders a preview with a matching view transform, light and world, and dumps materials back to a spec.
   - **Unity:** MCP for Unity. The menu item *Ascend ▸ Tutorial Vision ▸ Capture Game View* (`Game/Assets/_Game/Editor/TutorialVisionCapture.cs`) saves the Game and Scene views to `Game/Logs/tutorial_vision/` for comparison, because MCP for Unity has no screenshot tool.
6. **compare** (`tv.py compare`): side-by-side image, mean colour of each side, colour-histogram overlap and structure correlation. Crop the same surface on both sides with `--crop` and `--crop-result`. Iterate until close, then report what still differs.

## Commands
```
python Tools/tutorial_vision/tv.py fetch "https://www.youtube.com/watch?v=…"   # or a local .mp4
python Tools/tutorial_vision/tv.py scan <id> --budget 60
python Tools/tutorial_vision/tv.py frames <id> --range 18 24 --step 0.5 --crop 1612,480,308,130 --scale 2 --ocr
python Tools/tutorial_vision/tv.py compare <tutorial_frame.jpg> <render.png> --crop x,y,w,h --crop-result x,y,w,h
blender -b --factory-startup -P Tools/tutorial_vision/tv_blender.py -- --spec spec.json --render out.png --shape cube --view Filmic --light 180 --world 0.42,0.38,0.28
python Tools/tutorial_vision/test_tv.py        # self-test, no network
```
In a Claude Code session, ask: *"youtube-beta: recreate the procedural material in https://…"*.

## Setup on the PC (Windows)
1. **Pipeline:**
   - Run `pip install -r Tools/tutorial_vision/requirements.txt` (yt-dlp, numpy, Pillow).
   - Run `winget install Gyan.FFmpeg` (ffmpeg and ffprobe).
   - Optionally run `winget install UB-Mannheim.TesseractOCR` (OCR; add it to PATH).
   - Then run `python Tools/tutorial_vision/test_tv.py`.
2. **Blender bridge (MCP for Blender, ahujasid/blender-mcp, MIT).** Not installed yet; needs your OK because it lets Claude run Python inside Blender.
   - Run `claude mcp add blender -e DISABLE_TELEMETRY=true -- uvx mcp-for-blender`.
   - Run `uvx mcp-for-blender install-addon`, or install `addon.py` in Blender ▸ Preferences ▸ Add-ons.
   - In Blender press N ▸ *MCP for Blender* ▸ *Start*.
   - The server listens on localhost:9876 and has no authentication, so keep it local. `BLENDER_MCP_SAFE_MODE=1` screens scripts if you want an extra guard.
3. **Unity bridge (MCP for Unity, CoplayDev/unity-mcp, MIT, v10.x).** Not installed yet; it adds a package to the game project.
   - In Unity: *Window ▸ Package Manager ▸ + ▸ Add package from git URL* ▸ `https://github.com/CoplayDev/unity-mcp.git?path=/MCPForUnity#main`.
   - In Unity: *Window ▸ MCP for Unity ▸ Configure All Detected Clients*, or run `claude mcp add unity -- uvx --from mcpforunityserver mcp-for-unity --transport stdio`.
   - It's an editor-only package; record it in `13_Production/third_party_assets.md` when you approve it.
4. YouTube needs a normal home connection. Cloud machines get YouTube's bot check, and this tool never works around it or uses an account.

## Cost and speed
- **Scan time:** about 1–1.5 minutes per 5–13 minute video on 4 CPUs.
- **Reading:**
  - Claude reads 5–6 contact sheets (12 frames each) first, then only the frames and crops it needs.
  - About 10–20 targeted crops per recreated technique.
  - Strips of stacked crops cut the image count further.
- **Cache:** frames, crops, OCR and `steps.md` are cached per video, so a second question about the same tutorial reuses them.

## Limits
- **OCR:** tiny Unity 5 and Blender UI fonts defeat Tesseract. Claude reads the zoomed crops visually, which works, but is slower than text.
- **Audio-only narration:** with no captions, speech is not transcribed. Adding faster-whisper is a possible next step; the visuals are still analysed.
- **Lighting:** comparison matches colour and value well, but the tutorial's HDRI is usually not available, so lighting differs. Say so instead of over-fitting.
- **Live editors:** MCP for Blender and MCP for Unity need the editors open on the PC, plus your approval to install. Until then Blender work runs headless, and Unity work produces an MCP call plan.
