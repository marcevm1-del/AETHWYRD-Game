# World diorama, 2026-11-02 (technical-artist)

Script: `Tools/blender/world_diorama.py` (Blender 5.2.3, EEVEE). Docs: `10_World/physical_geography.md` section 12. Placement data: `reports/world_diorama_2026-11-02/placement.json`.

## Revision 2: anime-fantasy-director review fixes
1. **Mountain faces (redo).** Terrain is now a hard two-tone cel (shadow tint 0.58/0.56/0.78 below N.L 0.32, cream above), computed from the normal against the one NW sun. The first attempt used the render's diffuse result, but the world light lifted every face over the terminator, so the shader now ignores it. Cream rim 0.22 on the lit side, hard strata bands on rock. Rock colour is baked from slope and the same sun: warm tan or ochre lit, violet-grey in shadow. Ridged noise at three scales plus a crest taper turns tubes into jagged spines. Snow follows height (from about 2,400 m) and slope with a ragged one-step edge; steep faces stay bare. Cloud lumps are flat-bottomed cumulus with a violet underside, lifted 2.4 units clear of the peaks.
2. **Sea.** Sine waves and the glossy reflection (the tiled glint) are gone: waves are world-space noise and the only glint is a sparse noise sparkle. Pale cyan shallow ring, crisp foam line plus a fainter outer line, deep `#3F86B0` (colours pre-divided by the cream light so the lit result is exact). Skirt, plinth and table are hidden in the render; an ocean plane fades from deep blue to the horizon haze.
3. **Labels.** Ink `#3A2A1C` on `#F3E6C8` plates, 16 px (continent) and 22 px (heartland, spine), greedy auto-nudge over a ring of offsets, leader line plus ink diamond to the summit or town. Cartouche 18.5% of frame width (was 26%) with a gold rule and diamond ornament; Nox Dominion is no longer covered. Font: Blender's bundled Inter (SIL OFL). No display serif is in the third-party register, so none was used.
4. **Smears.** Biome colours meet in one short step (blurred weights to the 20th power); the forest halo is a hard edge; cliff-base rock uses a narrow slope step and less slope blur. The spine sky is a painted gradient slid to the horizon, with 13 stylised cumulus banks behind the range. The spine camera now looks from the south-west (yaw -50, pitch 8) so the lit faces show.
5. **Forest LOD.** The continent view swaps the trees for a deterministic subsample (every third tree, 2.2x larger, light/dark contrast); the Whisperwood now reads as trees.

## Renders (1920x1080, 24 samples, seed 7, up 3, exag 4.2)
- `10_World/maps/diorama_continent.png`, `diorama_heartland.png`, `diorama_spine.png`
- Whole run (fields, placement, build, 3 renders): about 12 s. Placement alone: 3 s. With `--outline`, about 90 s per frame at 960x540.

## Budgets (measured)
| Item | Count |
|---|---|
| Terrain nodes / triangles | 541,501 / about 1.08 M |
| Trees (cap 40,000) | 21,065 in 4 merged meshes, plus a 7,000-tree LOD set (continent view only) |
| Houses | 686 over 49 settlements, plus keep, 28 wall blocks, 7 towers, Brindlewick hall |
| Cloud clusters (cap 60) | 60 (300 lumps), plus 13 sky banks (91 lumps) in the spine view |
| Roads / rivers | 13 / 30 |
| Materials | terrain cel, dressing toon, cloud cel, flat label materials, ocean (vertex-colour emission) |

## Checks
- `python -m py_compile Tools/blender/world_diorama.py`: ok.
- Determinism: `--placement-only` run twice gave the same combined SHA-256 `3c4e1fd45f67595bc6b9251f1477b4b2f6f3be6eed36cec251d3063843e9540d` and byte-identical report JSON (`cmp`); a full render printed the same hash. It changed from `8159a592...` only because the terrain heights changed (ridged crests), which moves the tree and house positions that depend on height and slope; the same seed gives the same result. The cloud, sky-bank and LOD data use their own seeded generators and do not touch the shared rng.
- `render_physical_relief.py` still runs (heartland view at step 2, 480x270: DONE in 2.6 s).
- Looked at all three PNGs after each iteration and the final set.

## Known gaps
- Terrain is emission-shaded from N.L, so mountains do not cast shadows on the lowlands (the old render did, softly). A cast-shadow pass would need a shadow-only light pass.
- Strata are evenly spaced wavy bands; fine for a promo shot, a close shot would want per-layer variation.
- The sea behind the spine is a flat blue wall fading to haze; real but plain. Could take a distant island or a sea-fog band.
- Hoshizora City and the Summer Court glades stand in a lake cell (physical_geography.md section 11), so they have no houses.
- Continent clouds still gather over the high ranges and read as puffs on the peaks from this angle; fewer or higher clusters would help.
- Label font is Inter, not a display serif. To get one, list an OFL serif (for example Lora or Cinzel) in `13_Production/third_party_assets.md`; I did not add any font.
- `Tools/atlas/render_physical_map.js` was not touched (the review found nothing wrong there).
- Freestyle outlines are slow and also outline the label cards; off by default.
- Unity-side use (world-map screen) would use the PNGs only; no meshes are exported.

## Revision 3: director re-review (lower conical Spine)
Changes: exag 2.4 (continent frame 2.0); high octave amplitude 0.18 to 0.108 and crest taper above 1,500 m; strata off main faces (faint, cliffs over about 55 deg below snowline only); terminator softness 0.06; baked mountain cast shadows on lowlands; clouds lifted over local peak height; summit-anchored Dragon Spine / Burning Peaks labels with leaders; 5 far conical islands behind the spine (a sea-fog band was tried and read as flat ice floes, so it is disabled); Aldmere wall ring and settlement tint less pale.
Checks: py_compile ok; `--placement-only` twice gave `7f2f359ea2a40d99d63e1e8fb4ddcf4b1d0f8794c66c23bbcdc5a51ade0c65c4` both times (replaces `3c4e1fd4...`); `render_physical_relief.py` DONE in 26.7 s; all three PNGs viewed.
Still weak: peaks read as broad conical massifs, not individual sharp cones (a per-peak cone stamp would do better); max land is about 3,000 m so snow still caps most crests; cast shadows are baked colour, not true lighting; far islands are plain; continent clouds still cluster over ranges.

## Revision 4: individual cone peaks
**Revision 4 (individual cone peaks).** Per-peak cone stamps replace the ridged-noise massifs: the named peaks in `physical_map.json`, secondary peaks every 3.4-5.8 km along each range crest, and local maxima where a massif has no crest data (about 130 peaks, own rng `seed+888`). Each is a slightly concave cone (radius 3 km + 0.95 km per 1,000 m) with 5-9 radial ridges (ridged noise in azimuth), kept apart by saddles and blended into the range through a smoothstep foothill ramp of about 4 km (green lower slopes; rock only above about 850-1,300 m). The baked terminator uses a low-pass normal so each cone splits into one lit tan half and one violet half; shadow tint lightened to `(166,162,206)`; the bump is faint. Snow also caps the top ~18% of each peak's own height, with a ragged one-step edge. Far islands: 3 irregular, differently sized, seeded and hazier with distance. Clouds: cap 12, placed on range flanks, lifted above nearby ground. Placement hash (seed 7, exag 2.4): `de2922513342da18554ebb9248e0ac0edfb034049de97853346e12da582eba55` (continent frame at exag 2.0: `fc9372f3...`).
Checks: py_compile ok; `--placement-only` twice gave `de2922513342da18...eba55` both times (replaces `7f2f359e...`); `render_physical_relief.py` DONE in 5.7 s; all three PNGs viewed after the final render.
Still weak: flattened crater lakes sit on steep slopes and show as thin blue "waterfall" strips under some peaks; peaks are somewhat uniform in shape; the continent frame shows brown lower faces on the Iron Hold range; far islands are plain.

## Revision 5: lake slopes and brown bases
**Revision 5 (lakes and foothills).** Lakes are kept only on flat ground: where the stamped relief under a lake is steeper than about 8% the water is dropped (the cell becomes foothill green) and the basin is not flattened, so no water sits on a slope. Volcanic ground is lighter, mountain/volcanic ground below the rock line blends to green foothill, and the baked cast-shadow multiply is gentler (0.84, 0.83, 0.95), so no mud brown at mountain bases. Placement hash (seed 7, exag 2.4): `28af1aab8d66c27e2dba544ef12697f173758c92e936f081b4d12b217dec3a20` (houses 701 now that dropped lakes free settlement cells; continent frame at exag 2.0: `557e8745...`). Supersedes the Revision 4 hash.
Checks: py_compile ok; `--placement-only` twice gave `28af1aab...3a20` both times; `render_physical_relief.py` DONE in 5.5 s; all three PNGs viewed after the final render. Still weak: the continent frame still has a few dark shaded faces on the Iron Hold range, and some lake cells became meadow patches rather than water.
