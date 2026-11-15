# Character customization

How the player's look is built, chosen, coloured, saved and shown. The bodies come from the character generator (`13_Production/character_system.md`); this system decides what goes on them. Canon wins any conflict: `Canon.md` §1 (cel-shaded anime look, teen rating, no fanservice) and §4 (male and female player characters, no gender locks).

Status on 2026-11-15, using the two-status ladder of `Planning/QUALITY_GATES.md`:

| Part | Rules layer | In the game |
|---|---|---|
| Catalog, palettes, silhouettes (data) | TESTED (validator, 19 Core tests) | Data shipped with the player build |
| Rules: normalise, palettes, RGB/HSV, randomise, reset, saved looks, legacy migration | TESTED (Core) | IMPLEMENTED, not compiled in Unity yet |
| Customization screen | TESTED (Core model) | IMPLEMENTED inside the creator, not compiled in Unity yet |
| Colour-slot masks in the generator | VERIFIED in Blender (reconstruction error per part, FBX round trip) | Read by the new shader, not compiled in Unity yet |
| `Ascend/ToonCharacter` shader, import post-processor | n/a | IMPLEMENTED, not compiled in Unity yet |
| Face expressions and blink on the face rig | TESTED (Core player) | IMPLEMENTED (driver), not compiled in Unity yet |
| Hair and cloak secondary motion | n/a | IMPLEMENTED (spring chains), not compiled in Unity yet |
| Samurai outfit, samurai hair, katana and other planned meshes | DESIGNED (catalog rows) | Not modelled |

"Not compiled in Unity yet" means the C# compiles against stand-ins for the Unity API used and the controller has no syntax errors, but nothing has run in the editor. The PlayMode tests in `Game/Assets/_Game/Tests/PlayMode/CharacterCustomizationPlayModeTests.cs` are written and waiting for the PC verify run.

## 1. Art direction for characters

The owner's concept sheet (`07_Characters/reference/violet_samurai_concept.png`) sets the first two looks: black and violet hair, red and magenta accents, black and white clothing with purple decoration, Japanese-inspired cuts, an elegant katana. Both families share proportions, materials, lighting and animation.

Adaptations to canon:
- **Teen rating, no fanservice** (`art_direction.md` §6.2). The concept's female costume becomes a wrapped kimono top (no cut-out bodice) and a knee-length layered skirt over leggings (no short skirt and thigh-highs). The silhouette library's female concepts follow the same rule: skirts reach the knee or wear leggings.
- **Cel-shaded, no textures.** The brief's PBR maps (albedo, normal, metallic, roughness, AO at 2048²) are not used: the game's look is two-tone toon shading with per-vertex colour (`art_direction.md` §3, `character_system.md`). This is cheaper and keeps characters consistent with creatures and buildings. Texture budgets in `art_budgets.md` stay in force for anything that does need a texture later.
- **Colour rules** (`art_direction.md` §2): every palette keeps value between 12 % and 95 % and saturation at or below 90 %. The Neon palette was pulled inside these limits, and its cyan moved away from the reserved interaction cyan. The player may turn the guard off for their own colours.

## 2. Data

`Data/Characters/customization.json` (schema `customization`, checked by `npm run build`):

| Key | What | Count |
|---|---|---|
| `families` | feminine and masculine: generator body, height band, builds, default look | 2 |
| `colourSlots` | hair base, highlights, tips; eyes; clothing main, second, accent, trim; footwear; gloves; armour; accessories; decorations; weapon handle, blade | 15 (+ skin from `player_appearance.json`) |
| `materialSlots` | generator material category to default slot | 7 |
| `palettes` | the brief's A to H, every slot filled | 8 |
| `hairColours`, `irisColours` | named swatches (any other colour by RGB/HSV) | 14, 11 |
| `eyeShapes`, `pupilStyles`, `brows`, `mouths` | face features with decal parameters | 6, 4, 7, 4 |
| `expressions` | the brief's ten faces, each mapped onto the face rig (`face_expressions.json`) | 10 |
| `faces` | presets combining features and a resting expression | 7 |
| `hairStyles` | 11 built by the generator, 10 planned | 21 |
| `outfitPieces` | by slot (top, outer, bottom, skirt, belt, footwear, gloves, arms, shoulder, neck, armour); 8 built, 16 planned | 24 |
| `accessories`, `weapons` | with sockets and weapon families (`weapon_movesets.json`) | 9, 6 |
| `sockets` | bone plus offset | 11 |
| `looks` | named presets: two Rank-F defaults (built), the two violet samurai (planned) | 4 |

**Built and planned.** An option is `built` when the generator makes its mesh today and `planned` when it is designed only. The creator offers built options; planned ones appear, marked "(planned)", only with "Show planned options" on (a designer's switch). The validator refuses a `built` hair style or outfit piece that the generator does not build, and a `built` look that uses anything planned.

## 3. Rules (`Code/Ascend.Core/CharacterCustomization.cs`, `CharacterCustomizer.cs`)

- A look (`CustomLook`) stores ids and `#RRGGBB` per slot, never engine objects, so it serialises as plain JSON in the save (`SaveGame.Customization`) and in the saved-looks book (`character_looks.json` beside the save).
- `Normalize` repairs any look: unknown, retired, planned or wrong-family ids fall back to the family default; a piece in the wrong slot or hidden by another piece (a hakama hides the skirt) is removed; duplicate or same-socket accessories are dropped; height is clamped; every slot gets a valid colour inside the guard. It never throws, so a save made with an option that is later removed still loads.
- Old saves have no custom look: `FromLegacy` builds one from the Phase 1B body, hair colour and outfit colour.
- The creator's quick rows (body, hair colour, outfit colour) write into the custom look, so the two never disagree; changing body keeps every colour and resets face, hair and outfit to that body's default.
- `Randomize` is deterministic per seed and always valid; `Reset` returns the family default.
- The customization screen is `CustomizerModel`: categories Face, Hair, Body, Outfit, Gear, Colours and Presets. Colours has palette, part, picker (RGB or HSV), three channel rows, random colour and the style-guard switch. Presets has randomise, reset, save this look, load a saved look, the named presets, and show-planned.

## 4. Silhouettes

`Data/Characters/silhouettes.json`: 60 concepts, 30 per family, 3 in each of the brief's 10 categories (samurai, kunoichi, modern fighter, casual adventurer, fantasy warrior, lightweight assassin, heavy fighter, elegant, streetwear, experimental). Each is described on ten outline axes: hair, hair length, outer garment, sleeves, lower garment, armour, weapon, build, stance and headwear. Two decorative axes, footwear and accent, are also recorded but do not count toward distinctness.

`Tools/characters/silhouettes.py` draws them (sheets in `07_Characters/silhouettes/`) and measures distinctness on the drawn outlines. Two checks guard it:
- **Validator:** any two concepts in a family must differ on at least 3 outline axes.
- **Drawing script:** no two drawn outlines may overlap more than 85 % (intersection over union). On 2026-11-15 the closest pairs were 0.83 (female) and 0.85 (male), and the mean overlap was 0.57 and 0.60.

The library is a design target: each concept names, under `uses`, the catalog options it would need. Most need planned options; it guides which pieces to model next.

## 5. Colour in the game

The generator paints per vertex. At export, `Tools/blender/ascend_characters/slots.py` records for every vertex which colour slot the paint came from and how much lighter or darker it was:
- **UV1:** slot indices, with the blend between two slots (the hair's root-to-tip gradient).
- **UV2:** the shade.

The new `Ascend/ToonCharacter` shader rebuilds `lerp(slot A, slot B, t) × shade` from colours set per renderer with a `MaterialPropertyBlock`. So:
- any slot can take any colour with no new material or texture;
- two characters sharing a material never share colours;
- shading detail (trim bands, the lighter belly, the hair's highlight band) survives a recolour.

The sclera, eye highlights and anything painted outside the palette keep their painted colour.

Measured on 2026-11-15 on two variants (female base, male sturdy): mean reconstruction error per part 0.000 to 0.019 on a 0 to 1 scale, most parts under 0.005. Geometry hashes are unchanged. All three UV maps and the vertex colour survive an FBX round trip.

Why a new shader: `Ascend/Toon` uses the vertex colour channel for the outline's smoothed normal and ignores it for colour, so a generated character drawn with it would show one flat colour per material (whites of the eyes, iris and pupil alike). `Ascend/ToonCharacter` keeps the same lighting and outline and moves the smoothed normal to UV3, written by `Game/Assets/_Game/Editor/CharacterImport.cs`.

Cost: the per-renderer slot array is outside the material constant buffer, so the shader is not SRP-Batcher compatible. That is fine for the player, companions and a few NPCs; measure before crowds use it (risk R21).

## 6. In the game

- `CharacterAppearanceApplier`:
  - shows and hides generator parts by name and sets each renderer's slot colours;
  - attaches the weapon and accessories to sockets made under the rig's bones (`customization.json` `sockets`);
  - moves the weapon between sheath and hand with `SetWeaponDrawn`;
  - lists in `Missing` anything asked for that has no model.
- `FaceExpressionDriver`: runs `FaceExpressionPlayer` (Core) on the face rig's blend shapes, covering expression blends with an ease-out and automatic blinking (none while sleepy or blinking).
- `HairMotion`: one spring chain per rig extra chain (back hair, side hair, cloak), using the monsters' `SpringChain`; no physics simulation.
- `CharacterLook.Apply` runs all three on a generated body. The placeholder body takes hair, outfit and boot colours and a stand-in hair shape.
- The creator has a "Customize look" row that opens the customization screen in the same panel, with the turning preview live on the right. Leaving it writes the look back and saves the saved-looks book.

## 7. Performance targets

Inherited from `art_budgets.md`:
- **Triangles:** player 30k (generated bodies measure 21k to 26k).
- **Material slots:** at most 7 per character.
- **Textures:** none.
- **Draw calls:** each part is one renderer and one material. A character is about 13 renderers. Merging parts per character at load is the first optimisation if draw calls bite.

## 8. What needs outside work, and who does it

| Need | Why it cannot be done in the cloud | Owner |
|---|---|---|
| Compile and run in Unity; PlayMode tests | No Unity in the cloud | Owner's PC (`Tools/pc/update_and_verify.cmd`) |
| Import generated characters into `Art/Models/Characters/` and set them as `PlayerBodies/Feminine` and `Masculine` | Generated FBX files are local and gitignored; they need the import step | technical-artist with the owner |
| Samurai outfit pieces (haori, kimono top, hakama, obi, layered skirt, tabi boots, sleeve guards), samurai ponytail, messy and topknot hair | Generator modelling work, iterated with renders | creature-artist or environment-artist owner of `ascend_characters`, reviewed by anime-fantasy-director |
| Eye, brow and mouth shapes as options | `face.py` draws one shape per body today | character generator owner |
| Weapon and accessory meshes | None exist for characters; they go in `Resources/Characters/Weapons|Accessories/<id>` | technical-artist |
| Animation for draw and sheathe, victory, gestures | Clips exist for locomotion and combat (`locomotion_clips.md`, `combat_clips.md`); these are missing | animator-rigger |
