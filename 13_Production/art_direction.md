# Art Direction: the AETHWYRD Style Guide

> **Owner:** anime-fantasy-director. **Status:** v1.1, 2026-10-31 (adds §3.1 contact-sheet preview standard; Umbravel lantern and water-key notes in §4.2). Every art, shader, UI and bestiary agent builds to this page. When it disagrees with a tool's defaults, this page wins. When it disagrees with `Canon.md`, Canon wins and this page is the bug.
> **Sources:** Canon §1 (bright, flowing, Genshin-style cel-shaded anime; teen; no fanservice; warmth over comedy) · [[anime_building_style]] · [[building_system]] · [[creature_system]] · `12_Systems/hud_and_ui.md` · `08_Bestiary/monster_motion_bible.md` · `Tools/blender/ascend_buildings/styles.py`.
> **Latest review:** `reports/design_review_2026-10-31.md` (previous: `reports/design_review_2026-10-25.md`).

---

## 1. The three pillars

| Pillar | What it means on screen | Test |
|---|---|---|
| **Bright and flowing** | High-key frames, clean cel shading in two tones, soft gradient skies, wind in grass, cloth, hair and banners. Nothing muddy, nothing grey-brown by default | Squint at the frame: is the average value above 55%? Does something move in the wind? |
| **Warm and lived-in** | Every place shows the people who live there: flower boxes, laundry, lanterns, worn steps, a cat on a wall. Monsters have ecology (a nest, a trail, a food source). Warmth over comedy: gentle, not slapstick | Could you guess who lives here, and what they had for breakfast? |
| **Readable first** | Silhouette, then value, then colour, then detail. A player identifies a threat, a door or a shop in under half a second at gameplay distance | Turn the frame to greyscale and shrink it to 25%: does the key thing still pop? |

**Genre target in one line:** the cosy, sunlit isekai town and the wild that starts past its gate, rendered like a premium anime game. Familiar enough to feel like home on minute one, specific enough that no other game could own it.

**Named references (for *why* only, never copied):** Ghibli town warmth (*Kiki's Delivery Service*), the European-village isekai look (*Frieren*, *KonoSuba*), the cel lighting and wind of *Genshin Impact* and *Breath of the Wild*, monster appeal ladders from monster-collecting RPGs. We take principles, never designs, layouts, characters or assets.

---

## 2. Value, saturation and colour rules (everything)

1. **Value structure, three bands per frame.** Sky lightest (V 80–95%), the playable midground mid (V 55–75%), the framing foreground and shadows darkest (V 30–50%). Characters and monsters must differ from the ground behind them by **at least 25 points of value** or carry a rim light.
2. **60 / 30 / 10.** 60% dominant (walls, ground, a monster's body), 30% secondary (roofs, trim, belly), **10% or less a single accent** (shutters, banner, a crest, a glowing core). One accent per object, one hero accent per district.
3. **Saturation budget.** Bodies and walls S 25–60%. Roofs and cloth S 45–75%. The accent S 70–90%. Above 90% only for emissive magic, UI and telegraphs.
4. **No pure black, no pure white.** Darkest albedo V 12% (`#1F1F1F`-ish, always tinted), lightest V 95%. Dark creatures are navy, plum or umber, never `#000`.
5. **Shadows are cool, lights are warm.** Shadow tint violet-blue (`Ascend/Toon` `_ShadowTint` 0.58, 0.56, 0.78: keep). Sunlight warm cream `#FFF1D6`. Lamps amber `#FFB852`.
6. **Reserved colours.** These belong to gameplay and may not be used as a creature's or building's dominant colour or as a *pulsing* emissive:
   - telegraph **blue** `#3DA5FF` (parryable), **red** `#FF3B30` (unblockable), **gold** `#FFC93C` (grab);
   - rank colours (`hud_and_ui.md` §1) on auras, loot beams and frames;
   - quest gold `#FFD34D` and interaction cyan `#7FE3FF` on markers.
   A monster may *be* red (a fire salamander) but its red glow must not pulse; only telegraphs pulse.
7. **Colour-blind safety.** Every colour signal also has a shape (telegraphs: circle = parryable, triangle = unblockable, square = grab, per `hud_and_ui.md`). Never separate two states by red vs green alone.

---

## 3. Lighting, outlines, sky

| Element | Rule | Current value / target |
|---|---|---|
| Shading | Two tones, hard terminator | `_ShadowStep` 0.5, `_ShadowSoftness` 0.03 (buildings), **0.06 on characters and creatures** so round forms read soft |
| Ambient | Enough that shadows keep their hue | `_AmbientStrength` 0.35 day, 0.5 at dusk |
| Rim | Soft cream rim on the lit side | `_RimColor` (1, 0.97, 0.9, 0.22), power 3.5; **0.35 on creatures** so they separate from foliage |
| Outline colour | Darkened local colour, never flat black | Target: base colour × 0.35, hue kept. Today it is a fixed brown (0.16, 0.11, 0.09): acceptable for wood and plaster, wrong on blue slimes and white marble |
| Outline width | Thin, constant in screen space | **1.5 px at 1080p** for characters and monsters, **2 px** for buildings, **0 on grass, particles and water**. Distance-scale so it never exceeds 3 px or vanishes below 1 px |
| Specular | Painted, not physical | One soft highlight blob on gel, eyes, metal and wet surfaces only. No PBR gloss on fur, cloth, skin, stone |
| Sky | Painted gradient + stylised cumulus | Day: zenith `#5FA8E8` → horizon `#CFE8F5`; dusk: `#3E4A8C` → `#F6A96B`. Clouds as flat-shaded shapes with a lit cream top and lavender base |
| Fog | Colour of the horizon, starts late | Starts at 60 m, 30% at 200 m. It is atmosphere, not murk |
| Bloom | Only on emissives | Threshold 1.0, intensity 0.4. Lamps, runes, cores, magic. Never on white walls |
| Time of day | Morning gold, noon clean, dusk orange-violet, night blue with warm windows | Night is navy `#1B2440` with lit windows (`lamp` emission 2.0), never black |

### 3.1 Contact-sheet preview standard (set 2026-10-31)

Every contact sheet used to approve a look is rendered with the toon preview (`Tools/blender/toon_preview.py`, `render_toon_sheet.py`). The plain render (`--plain`) is for geometry debugging only and never for sign-off.

| Element | Rule |
|---|---|
| Shading | Two-tone ramp, shadow = base x (0.58, 0.56, 0.78); cream rim 0.35 on creatures |
| Outlines | Inverted hull at local colour x 0.35; 1.5 px creatures, 2 px buildings at tile size |
| Colour transform | **`Standard`** view transform, no look, exposure 0. AgX/Filmic is not allowed in previews because it bleaches emissives to white |
| Emission | lamp 1.5, window glow 2.0, ember 2.5, magic/rune/crystal 2.0. A lit pixel keeps saturation of at least 50% and its hue within 15 degrees of its palette key; a white lantern is a failed render |
| Sky and ground | Painted sky band; ground disc 3x the subject's bounds, `#8CC860` fading to `#A8D47A` at the rim |
| Framing | The camera frames the **subject only**. The subject fills 70-85% of the tile's shorter side, and the camera fits on the **vertical** field of view so tall, thin props (lamp posts, towers) are never cropped |
| Scale reference (creatures) | A 1.7 m flat lavender-grey `#A9A6C2` human silhouette (head 1/7 of height, shoulders, legs; not a capsule), standing behind and to the right of the subject. It may be cropped by the frame: a shin beside a rabbit is enough. The tile label gives the species and its height in metres |
| Camera | Yaw -35 degrees, pitch 16-28 degrees, the same for before and after sheets |

---

## 4. Shape language

### 4.1 The base vocabulary
- **Circle / soft:** friendly, safe, cute. Slimes, familiars, Thimblefolk toadstools, inns, bakeries, NPC children.
- **Triangle / sharp:** danger, speed, ambition. Goblins, wolves, demons, spires, the Vesper silhouette.
- **Square / heavy:** stability, defence, endurance. Golems, dwarves, guild halls, gatehouses, ogres.

Every design is **one dominant shape + one secondary**, never three in balance. Example: Goblin = triangle (ears, nose, blade) over a circle (chibi head and belly): menacing but small.

### 4.2 Building families (`styles.py`)

| Family | Dominant shape | Signature silhouette (must be visible at 100 m) | Palette notes (from `styles.py`) |
|---|---|---|---|
| Storybook half-timber (Whisperwood, Aldmere, Moraveil, Strife Marches, Ashira Vale) | Tall triangle | 50–55° roofs, turrets with witch-hat cones, chimneys | Cream plaster `#EDDBB2`, timber `#4C2E1A`, roofs cobalt `#336BB8` / vermilion `#CC4C2E` / green / slate, one shutter colour per house. **Whisperwood** leans wood, moss and lanterns; **Aldmere** leans stone ground floors, slate and royal blue-and-gold banners |
| Fen stilt village (Greymoor, Quaking Lands) | Triangle on thin verticals | Stilts + reed roofs + hanging lanterns | Weathered boards `#756957`, reed thatch `#9E8C5C`, accent = **green lantern glow `#BFFF8C`**, which must read at dusk |
| Elven living wood (Sylvaran, Everdusk) | Curve / teardrop | Onion towers, leaf-scale roofs, round windows | Pale wood `#DBCCA3`, leaf `#4C9E5C`, teal `#3D8C85`; accent mint glow `#8CFFD9`. Everdusk: amber and plum roofs |
| Thimblefolk toadstools (Mossdeep) | Circle | Spotted caps, bulging stalks | Cream stalk `#F0E6CC`, cap vermilion `#D12E26`, brown, violet; accent white spots |
| Lagoon canal city (Lirian) | Low square | Hip roofs at 24°, quoins, balconies, mooring poles | Pastel stucco coral `#EDA899` / apricot / cream, terracotta barrel tile `#C26138`, green shutters `#3D755C` |
| Wind-plains (Fanghold, Calamity Steppe, The Maw) | Dome + low square | Felt yurts, banner poles, stone forts | Felt cream, stone `#A89980`, plank roof `#735438`; **accent cloth red `#C73324` + blue `#3357A8` on bands, banners and door frames on every building** |
| Dwarven basalt halls (Iron Hold, Dragon Spine) | Square, buttressed | Massive bases, slit windows, forge chimneys | Basalt `#45424A`, bronze trim `#B87333`, accent **forge orange `#FF8C26`**, which must glow from doors, windows and chimneys |
| White-stone duchies (Velmark, Vharlen, Stormreach, Bastion, Aurumdeep) | Square + cone | Ashlar, blue slate hips, finials, banners | White ashlar `#E6E0D1`, slate `#4C5C75`, accent banner blue `#3357AD` + gold |
| Star-sky cedar halls (Hoshizora, Kitsune Isles) | Wide triangle with upturn | Curved eaves, raised ridges, pagoda, torii | Paper-white walls `#F2EDE0`, dark cedar `#42291A`, roof slate-blue `#3D4757`; accent vermilion `#D9381F` (torii, rails); Kitsune Isles more vermilion |
| Hundred-stair sect halls (Shen-Lu) | Wide triangle, strong upturn | Red columns, glazed green/gold roofs | Columns `#B8241A`, roof jade `#2E7557` + gold `#DBA833` |
| Sky-gate hanok (Haneul) | Gentle curve | Low, wide roofs, painted beams | Grey tile `#4C4F57`, beams red `#943324` + teal `#33857A` |
| Fjord longhouses (Frostveil, Whitewater Reach) | Long low triangle | Turf roofs under snow, dragon-board gables | Log `#66452E`, turf `#5C7A42`, snow `#F0F5FF`; accent red shutters `#B2382E` |
| Glass-desert adobe (Sunscar, Zaruma) | Square + dome | Flat roofs, parapets, vigas, **domes only on civic and temple buildings** | Adobe sand `#E0B885`, lime white `#F0E6D1`, accent turquoise shutters `#248CA8`; Zaruma red mud |
| Garden cities (Zarvan) | Square + onion | Turquoise tile bands, iwans, **onion domes only on civic and temple buildings** | Ochre brick `#D6A870`, turquoise `#1A8F9E`, cobalt `#1F4C9E` |
| Salvage coast (Goldmere, True-Name Isles, Hollow Sea, Lustrine, Dunewhale) | Triangle on stilts | Clapboard, portholes, nets, lighthouses | White clapboard `#EBEBE0`, sea blue `#5C8FB2`, accent buoy red `#D94C33` |
| Temple jungle (Xochitl Mire, Lumbaya) | Steep triangle on steps | Palm thatch, stepped pyramids | Carved stone `#C2B28F`, thatch `#B28F4C`, accent teal `#1A9E99` + red bands |
| Carved-mountain terraces (Apu Highlands) | Trapezoid | Fitted stone, steep thatch | Stone `#9E9180`, thatch gold `#D1B266`, accent textiles red + yellow |
| Clockwork tiers (Gearholm, Cinderhole) | Square + gears | Copper roofs, pipes, big gear faces | Red brick `#9E4733`, verdigris copper `#599E8C`, brass `#D99E40`. Gears at least 1.2 m across on landmarks so they read |
| Dark spires (Umbravel, Nox Dominion) | Tall sharp triangle | Spires, pointed arches, webs | Black-violet stone `#4C4557` (Umbravel `#5A5068`), slate `#3D334C`, accent **violet window glow `#C77AFF`**; Umbravel silk lanterns stay **warm amber `#FFB852`** (one cool and one warm light per facade, never violet lanterns); Nox: obsidian + red-orange glow |
| Heavenfolk marble (Heavenreach, Sky Archipelago) | Circle + column | Domes, columns, wings | Marble `#F2F2F7`, gold `#FFC74C`, sky glass `#9EC7F2` |
| Labyrinth stone (Great Labyrinth, Root of the World, Vesper) | Heavy square | Runes, crenels, ruin | Grey block `#8C8F94`, accent rune glow by band (teal / blue / pale gold); Vesper red stone |

**Family rules that apply everywhere**
- Shared props (market stall, lamp post, fountain, well, bridge, wall, windmill, granary tower) **must take the family's materials and forms**. A red-canopy European stall in Sunscar or a sail windmill in Frostveil breaks the region.
- A family's signature element (dome, onion, toadstool cap, pagoda roof) goes on **at most 1 building in 4**. Ubiquity kills a signature.
- Dark families (dwarven, gothic, fenland) keep their overall value low but must carry **at least 3 warm emissive points per building** (door, 2 windows or chimney) so they read as homes, not ruins.
- **Water is never the window colour.** Every family has its own `water` key (default `#7FB3D0`; dark families a darker cool blue such as `#5E8FA8`). Orange or violet water reads as lava or poison.

### 4.3 Creature families

| Family | Shape | Appeal ladder (low rank → boss) |
|---|---|---|
| Slimes | Circle (dome + skirt) | Round, glossy, big dot eyes, tiny mouth → King variants get the crown, a bigger skirt and an inner core |
| Beasts | Real-animal silhouette + **one** exaggeration | Rabbit: horn + oversized hind feet. Wolf: big ruff + long muzzle. Boar: tusks + shoulder hump. Bear: mass. No antlers unless it is a deer |
| Goblinoids | Triangle over circle | Goblin: chibi, green (`#6FAE45` skin), huge ears, sly almond eyes. Hobgoblin: taller, squarer, armour. Chief: cloak + a trophy |
| Kobolds | Small triangle | Lizard-dog chibis with oversized tools and lanterns |
| Undead | Thin verticals and broken shapes | Skeleton: readable ribcage and skull with glowing eye points. Ghost: teardrop with a trailing hem, no legs. Wight: tall, cloaked, crowned |
| Dragons | **S-curve + triangle** | Long neck, horned crown, wings at least 2× body length, tail tapering to a point. A dragon must never read as a winged dog |
| Lycanthropes | Inverted triangle | Huge shoulders, narrow waist, digitigrade legs, muzzle, mane. Natural fur colours only |
| Aquatic | Teardrop and spiral | Fins, frills, lures. Body colour by depth (shallow aqua, deep navy with bioluminescent spots) |
| Demons | Triangle + horns | Horns and wings frame the head; one glowing sigil accent |
| Plants and fungi | Circle cap / leaf fan | Must carry a petal, leaf, cap or bulb. A green stump with arms is not a plant |
| Yokai-inspired spirits | Object-made-alive | The object first (umbrella, lantern, scroll, kettle), the face second. Original designs; no recognisable folklore character from another work |
| Familiars and gentle creatures | Circle | Round, pastel, big eyes, no horns, no teeth showing |
| Orcs, ogres, giants | Square | Visible faces with tusks and brows. Ogres: tiny head on huge shoulders. Giants: proportioned like heroes, just huge |

---

## 5. Proportions

| Class | Heads tall | Head % of height | Notes |
|---|---|---|---|
| **Chibi monsters** (slimes, goblins, kobolds, imps, familiars, F–E beasts) | 2–2.5 | 35–45% | Short limbs (arm reaches the hip), wide stance, big eyes. Cute first, dangerous second |
| **Heroic humanoids** (player, companions, adult NPCs) | 6.5–7.5 | 13–15% | Slightly long legs (leg = 52% of height), small hands and feet, clear waist. Children 4–5 heads |
| **Medium monsters** (orcs, lycanthropes, undead knights) | 5–6 | 17–20% | Exaggerate shoulders and hands 1.2× |
| **Large monsters** (ogres, trolls, minotaurs, golems) | 3.5–4.5 | 10–14% (head deliberately small) | Shoulders 1.5–2× hip width; arms reach the knee |
| **Giant bosses and Tyrants** | n/a | n/a | Read as **three masses** at 60 m (head/upper, body, base or tail). One focal accent (a core, eye or crown) at 5–8% of the silhouette |

**Scale floors at gameplay distance** (1080p, 60° vertical FOV): a 1 m monster is ~47 px tall at 20 m. So every F–D species needs one **hero shape** at least 25% of its silhouette that reads at 47 px: the slime's dome, the goblin's ears, the rabbit's horn and ears, the wolf's muzzle and tail.

---

## 6. Eyes and faces

### 6.1 Monsters (creature generator parameters)
| Kind | Eye style | `eye_size` (× head radius) | `eye_spread` | `eye_up` |
|---|---|---|---|---|
| Slimes, familiars, F-rank cute | Dot or anime round, 1 big + 1 small highlight | 0.34–0.40 | 22–28° | 0–5° (low on the face reads cuter) |
| Chibi bipeds (goblins, kobolds) | Anime almond, slit pupil for goblins | 0.28–0.32 | 26–30° | 8° |
| Quadrupeds | Anime almond, visible from 3/4 front | **0.30 large, 0.36 small** | **30° large, 34° small** | **6°** |
| Medium bipeds | Almond, iris 0.55 of eye | 0.24–0.27 | 28° | 10° |
| Large brutes | Small and deep-set under a brow ridge, with a bright iris | 0.18–0.22 | 30° | 12° |
| Undead, spirits, constructs | Glowing points or slits, no white | 0.15–0.2 | 30° | 10° |

- **Every creature with a head shows a face** (eyes or eye-lights) from the front and 3/4 views. Masks are allowed only when the species' look text asks for one, and then the mask itself carries carved eye holes with a glow inside.
- **Menace scale by rank:** F–E big round irises and two sparkles; D–C almond shape, one sparkle; B+ narrowed, glowing irises; bosses get a unique eye shape (ringed, multiple pupils, a burning iris).
- **No plain white oval masks on a dark hooded body.** That combination reads as a famous character from another studio's film. Masks must be carved, painted, horned or species-specific.

### 6.2 NPCs and companions
- Eyes sit on the head's midline band (50–55% of head height), each **20–24% of face width**, one eye-width apart.
- Iris fills ~60% of eye height; two highlights (upper-outer large, lower-inner small); upper lash line thickest at the outer corner, coloured dark from the hair hue, never pure black.
- Nose: a single soft shade or a tiny wedge. Mouth: a short line; open shapes only when talking or emoting.
- Face shadows use a hand-authored face normal (no noisy self-shadow across the face); hair gets an anime highlight band ("angel ring") at 25% down the hair mass.
- Expressions: 6–10 portraits per main character (per `hud_and_ui.md`). Warmth: default expression is a soft, open look, not a smirk.
- **Teen rating, no fanservice:** practical outfits, no costume or camera framing that sexualises anyone; childlike characters are always framed as children.

---

## 7. Monster readability and combat signals

1. **Silhouette test:** each species is identifiable in solid black at 64 px. If two species in the same ring fail side by side, change one's hero shape, not its colour.
2. **Ground contrast:** body value ≥ 25 points from its home biome's ground, or a rim of 0.35. Whisperwood monsters are warm (rust, tan, cream, bright green) against the cool green floor; Greymoor monsters are lighter than the bog.
3. **Telegraphs** (`monster_motion_bible.md` §3, `hud_and_ui.md`):

| Signal | Colour | Shape icon | On the monster |
|---|---|---|---|
| Normal / parryable | Blue `#3DA5FF` | Circle | Rim flash 0.25 s at windup start, weapon trail blue |
| **Unblockable** | **Red `#FF3B30`** with a white-hot core | **Triangle** | Full-body rim pulse ×2 + a red glint on the striking part + a short sting. Windup ×1.15 |
| **Grab** | **Gold `#FFC93C`** | **Square** | Gold rim on the hands or jaws + gold ground ring at grab range. Windup ×1.1 |

   Telegraph colours are additive rim/flash effects drawn **over** the toon shader, so they read on any body colour. Body emissives (Vesper-Touched cracks, fire veins) stay steady; only telegraphs pulse.
4. **Rank aura** uses the rank colour at low opacity at the feet; F has none (matches the loot-beam rule).
5. **Variants** must keep the base silhouette and change one channel: Elder = size + scars; Phantom = 60% opacity + inner glow; Vesper-Touched = steady crimson cracks; Elemental = element growths. Never two channels on one variant.
6. **Weapons:** only species whose look text says they carry one. Weapon length is set per class (goblin dagger 0.35 m, hobgoblin sword 0.8 m, ogre club 1.6 m) and **thick enough to read at 20 m** (blade width ≥ 6 cm).

---

## 8. UI: the "anime System window"

The System window is the genre's most recognisable furniture. It should feel like the world's magic speaking to you: crisp, luminous, slightly uncanny, never like a spreadsheet.

| Element | Spec |
|---|---|
| Panel | Deep navy glass `#0E1A2E` at 82% opacity, 6 px corner radius, 1 px inner line cyan `#7FE3FF` at 60%, bracket corners 14 px long |
| Header | Bar with a chevron and the window name in caps, letter-spaced 8%; a thin scan line drifts down every 6 s |
| Open / close | Scale 0.96 → 1.0 with a top-to-bottom wipe, 180 ms ease-out, soft chime; close 120 ms |
| Type | One rounded sans for UI (e.g. Noto Sans / M PLUS Rounded, OFL), tabular figures for numbers. Body ≥ 18 px at 1080p, labels ≥ 14 px, nothing smaller |
| Numbers | Gains flash cyan then settle white; losses flash coral `#FF7A6B`; never red telegraph red |
| Rank letters | Rank colours from `hud_and_ui.md` §1, slab-serif, with the frame effect for that rank |
| Notifications | "System" toasts slide in from the top-right with a 1 px cyan underline, 3 s, max 3 stacked |
| HUD over the world | Text on the world always has a 2 px dark outline or a 40% navy backing plate. Nameplates: name 16 px, title 12 px at 70%, fade beyond 15 m, never stack over a monster's face |
| Diegetic parchment | The map, quest board and letters are warm paper `#F3E6C8` with ink `#3A2A1C`, a deliberate contrast to the cool System |

---

## 9. Environment dressing (outside the building kit)

- **Trees:** layered clumps with 3–5 lobes, lit tops a 15% lighter, warmer green, under-canopy cool. Not single spheres. Trunks taper and flare at the root.
- **Ground:** three tones per biome with soft-edged patches (dirt path `#C9A66B`, lit grass `#8CC860`, shade grass `#5E9A4A`); grass cards near the camera; flowers in clusters of one colour.
- **Density:** one point of interest every 30–40 m of travel (a shrine, a fallen log with mushrooms, a ruined arch, a campsite).
- **Landmarks:** each district and region has one skyline anchor visible from its entrances (Brindlewick: the clock tower; Whisperwood: the ruined arch and a giant tree).

---

## 10. Do and don't

| Do | Don't |
|---|---|
| Keep one accent colour per object and make it count | Paint every building in the same three saturated colours |
| Give the first monsters classic, friendly reads: blue slime, green goblin, brown horned rabbit, grey-brown wolf | Ship F-rank monsters in grey `#8A8F98`; the first fight should be colourful |
| Put faces on creatures, with eyes visible from the front and 3/4 | Hide faces behind plain white masks or put the eyes on the sides of the skull |
| Use real-animal anatomy plus one fantasy twist | Give wolves antlers or rabbits horns *and* spikes *and* armour |
| Restyle every shared prop per region | Reuse the red-canopy stall, the iron lamp post and the stone fountain in every region |
| Use a signature form (dome, toadstool, pagoda) on 1 building in 4 | Put an onion dome on the stable |
| Light dark districts with warm windows | Let a dark-stone town go monochrome grey-violet |
| Tint shadows violet, keep outlines a dark version of the local colour | Use black outlines and black shadows |
| Keep telegraph red, gold and blue reserved and pulsing | Let a monster's idle glow pulse red |
| Make the System window luminous and crisp | Use default IMGUI boxes and thin text over the sky |
| Respectful costumes and camera, warmth over comedy | Fanservice framing, gag faces in serious beats |
| Reference other works for *why* they work | Copy another studio's characters, designs, text or assets |

---

## 11. Checklist before an asset is "on style"

1. Greyscale at 25% size: the hero shape and face read.
2. Value differs from its home ground by ≥ 25 points (or rim 0.35).
3. 60/30/10 with one accent; no reserved colour as dominant.
4. Proportions match its class row in §5; eyes match §6.
5. Region family materials on every prop (§4.2).
6. Rendered once with `Ascend/Toon` and outlines before sign-off (contact sheets without outlines are previews, not approval).
7. Passes `13_Production/style_consistency_checklist.md` (characters, outfits, screens: sections A to E), with every line PASS, FAIL or NOT ASSESSED; a line not looked at is never PASS.
