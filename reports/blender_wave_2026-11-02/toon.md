# Toon preview tuning, 2026-11-02 (technical-artist)

Style guide §3.1, design review 2026-10-31 R1, B3 fix 1, §3, N2, N3, N5. Renders from a clean worktree of `main` ee7f861 (the environment-artist and creature-artist edits in flight are not in these sheets).

| Sheet | What |
|---|---|
| [creatures_toon_v2.png](toon/creatures_toon_v2.png) | the 12 species of `toon_preview_2026-10-31/creatures_toon.png` |
| [buildings_toon_v2.png](toon/buildings_toon_v2.png) | Iron Hold house and smithy, Umbravel house, Greymoor house, Hoshizora and Gearholm lamp posts |
| [buildings_glow_v2.json](toon/buildings_glow_v2.json) | glow measurement per tile and glowing material |

## What changed (`Tools/blender/toon_preview.py`, `render_toon_sheet.py`)
- **Emission keeps its hue (N3, B3 fix 1).** `Standard` view transform, no look, exposure 0 was already set; the real cause was the toon material *adding* emission x 0.5 on top of the lit base colour, which pushed two channels past 1 (`#FF8C26` read cream, violet read white). Glow is now a mix towards the emission colour scaled to full value, by `clamp(strength)`.
- **Framing on the subject only**, fitted on both the horizontal and the vertical field of view (N2), margin 1.2: every tile reports fill 83% of the shorter side. Lamp posts are no longer cropped.
- **Scale figure**: flat `#A9A6C2` silhouette, 1.7 m, head 1/7, shoulders, arms clear of the torso, legs and feet; behind and right of the subject, not framed (a shin beside the rabbit, the full figure beside the orc).
- **Labels** with the height in metres under every tile (built-in 5x7 font).
- **Lawn** `#8CC860` fading to `#A8D47A` at the rim. Creature pitch 16°, buildings 18°.
- `--glow-report <json>` renders an ID mask per tile and measures the beauty pixels of each glowing material (1 px eroded).
- One call for the library builders: `toon_preview.render_tiles()` + `toon_preview.sheet()`; it restores the scene so the .blend can be saved.

## Glow measurement (HSV of the rendered sRGB pixels)
The renderer now reproduces each material's key exactly (hue error 0°, saturation = key saturation). Where the check fails, the palette value is too pale:

| Tile, material | px | rendered hue / sat | palette key | guide key | result |
|---|---|---|---|---|---|
| Iron Hold house, ember | 35 | 35.8° / 58% | `#FFC46C` | `#FF8C26` (28.2°): Δ 7.6° | pass |
| Iron Hold smithy, window_glow | 1 | 35.8° / 57% | `#FFC46C` | `#FF8C26`: Δ 7.6° | pass (1 px: windows barely visible) |
| Umbravel house, window_glow | 75 | 277.6° / 28% | `#E5B8FF` | `#C77AFF` (274.7°): Δ 2.9° | **fail, saturation** |
| Umbravel house, lamp | 132 | 265.0° / 40% | `#C499FF` | amber `#FFB852` asked | **fail** |
| Greymoor house, lamp | 92 | 93.3° / 45% | `#BFFF8B` | `#BFFF8C` | **fail, saturation** (key itself is 45%) |
| Hoshizora lamp post | 2547 | 29.4° / 37% | `#FFCEA0` | | **fail, saturation** |
| Gearholm lamp post | 278 | 41.2° / 30% | `#FFE7B3` | | **fail, saturation** |

The palette values in `ascend_buildings/styles.py` are linear, but several were typed as sRGB-like numbers, so they render paler than the key. Umbravel `window_glow` for `#C77AFF` is linear (0.571, 0.195, 1.0); amber lamp `#FFB852` is (1.0, 0.48, 0.09). Owner: environment-artist. Iron Hold house windows show no lit pane at this angle (0 px), so the house cannot be measured on its windows.

Timings (headless software GL, 320 px tiles, 12 samples): creatures 7.0 s per tile (1 m 38 s total), buildings 17.5 s per tile with the glow pass (1 m 47 s).
