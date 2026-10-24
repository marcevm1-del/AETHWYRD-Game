# Movement feel (research notes, 2026-10-24)

What "normal" third-person character movement does in action games, compared with ours, and what we changed.
All numbers are data in `Data/Combat/combat_tuning.json` → `movement`, so they can be tuned without code.

## What the research says
- **Responsiveness vs weight:** movement must answer input at once, but some ramp-up and ramp-down sells weight. Just Cause 3's GDC talk frames it as exactly that balance. Swink's *Game Feel* treats a character's response to input like an ADSR envelope (attack, decay, sustain, release).
- **Forgiveness:**
  - **Coyote time** lets you jump just after walking off a ledge. It also hides input latency, which can pass 100 ms on some setups.
  - **Jump buffering** fires a press made just before landing.
  - Common starting values are ~0.12 s for coyote time and ~0.15 s for the buffer.
- **Variable jump height:** release early for a hop, hold for the full jump (Mario, as opposed to Castlevania's fixed arc). A cut multiplier of about 0.45–0.5 is typical.
- **Realistic isn't right:** realistic jump heights and speeds often feel wrong to players.
- **Speeds:** real people walk 0.8–1.1 m/s, jog 1.7–2.2 m/s, run 2.8–3.3 m/s and sprint 4.2+ m/s. Games usually run faster.
- **Turning:** Unity's old Standard Assets controller turned at 360°/s while moving and 180°/s standing still. Action games turn faster.
- **Root motion vs in-place:** root motion lets animation drive movement; it looks grounded but can feel "clunky" for camera-relative action movement. In-place animation with code-driven speed, plus a blend tree keyed to speed, is the usual choice for responsive action games.

## Where we were
Our numbers were already fast:
- walk 2.2, run 6.5 and sprint 9.5 m/s
- a 1.6 m jump
- 720°/s turning
- −25 gravity

That's anime action, intentionally above real life. What was missing was the feel layer:
- velocity snapped instantly to full speed and to zero
- full steering in the air
- no coyote time
- no jump buffer
- a fixed jump arc
- a symmetric rise and fall

## What we changed
| Setting | Value | Effect |
|---|---|---|
| `accelSec` | 0.10 | Standing to full run in 0.1 s: responsive, with a hint of weight |
| `decelSec` | 0.06 | Stops faster than it starts, so attacks don't slide |
| `airControl` | 0.45 | In the air you steer at 45% of ground acceleration; momentum carries |
| `coyoteSec` | 0.12 | A jump still works 0.12 s after leaving a ledge |
| `jumpBufferSec` | 0.15 | A jump pressed up to 0.15 s before landing fires on landing |
| `jumpCutMult` | 0.5 | Releasing jump while rising halves the upward speed: short hop |
| `fallGravityMult` | 1.6 | Falls faster than it rises: a snappier, less floaty arc |
| `walkStickThreshold` | 0.5 | A light stick tilt walks; keyboard is always full tilt |

Unchanged: speeds, jump height (the full jump still reaches 1.6 m), dodge, sprint stamina, and 720°/s turning, which suits lock-on and fast direction changes.

Tests (PlayerPlayModeTests): acceleration and stopping, light tilt walks, coyote jump off a ledge, buffered jump on landing, short hop, fall faster than rise.

## Later, with real animation
- **In-place clips:** blend tree by speed (walk/jog/run/sprint), plus 90°/180° turn-in-place and quick-turn clips, and start/stop clips that match `accelSec`/`decelSec`.
- **Lean and tilt:** lean into turns and tilt with acceleration. The procedural monster animator already does this for monsters.
- **Landing:** a short recovery on a hard landing; none on small hops.
- **Motion matching:** worth a look once there is a large mocap set.

## Sources
- [GDC Vault: Finding Balance — Responsive High Fidelity Character Movement in Just Cause 3](https://www.gdcvault.com/play/1021981/Finding-Balance-Realizing-Responsive-High) ([summary](https://www.gameanim.com/2017/10/29/realizing-responsive-high-fidelity-character-movement-just-cause-3/))
- [GDC Vault: Grappling with Success — Smooth Movement on an Indie Budget](https://gdcvault.com/play/1035867/Grappling-with-Success-Smooth-Movement)
- [Building Better Movement in Godot (Swink's game feel applied)](https://nishchalb.github.io/posts/godot_building_better_movement/)
- [Game Developer: Run, Jump and Climb — Designing Fun Movement in Games](https://www.gamedeveloper.com/audio/run-jump-and-climb-designing-fun-movement-in-games)
- [Game feel (Wikipedia)](https://en.wikipedia.org/wiki/Game_feel)
- [incanto 3D character controller notes (coyote/buffer/jump-cut defaults)](https://cdn.jsdelivr.net/npm/incanto@0.79.1/skills/incanto-3d-character.md)
- [Snap Lens Studio: Character Controller (coyote time, jump buffer)](https://developers.snap.com/lens-studio/features/games/character-controller)
- [GMTK Platformer Toolkit discussion (input latency, turn speed)](https://gmtk.itch.io/platformer-toolkit/comments?before=112)
- [Mocap Online: Locomotion animations — walk, run, sprint and blend trees](https://mocaponline.com/blogs/mocap-news/locomotion-animations-game-dev)
- [Unity Discussions: moving relative to the camera without root motion](https://discussions.unity.com/t/how-do-i-move-character-in-relation-to-camera-without-root-motion/602216)
