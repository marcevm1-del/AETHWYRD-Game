---
type: monster-rig
id: rig:small_biped
tags: [rig, animation, small-biped]
---
# small_biped rig

Goblins, kobolds, imps: 0.8–1.3 m. Oversized head and hands, short bowed legs, hunched spine. Humanoid-retargetable (Mixamo works with tweaks).

| Field | Value |
|---|---|
| Aliases | goblin, kobold, imp, gremlin, small_humanoid |
| Species using rig | 57 |
| Families represented | Goblinoids, Kobolds, Constructs & Mimics, Elementals & Spirits, Gremlins, Yokai-Inspired Spirits |
| Bone count · budget | 36 · 40 |
| Unity avatar · material | Humanoid · flesh |
| Reference size · axis | 1.1 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.25,"legFrac":0.4},{"name":"run","froude":2,"legFrac":0.4},{"name":"sprint_all_fours","froude":3.2,"legFrac":0.4}],"fantasyMult":1.3,"turnDegPerSecAt1m":420,"accelG":1,"jumpHeightFrac":0.7,"canClimb":"ledges","canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.016,"density":1000,"collider":{"type":"capsule","radiusFrac":0.2,"heightFrac":1},"gravityScale":1.5,"linearDrag":0.1,"knockbackResist":0.15,"launchable":true,"ragdoll":"full","deathStyle":"ragdoll_crumple"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"sprint_all_fours","frames":16,"loop":true,"rootMotion":true,"events":[]},{"name":"throw","frames":30,"loop":false,"rootMotion":false,"events":[{"f":14,"e":"hit_on"}]},{"name":"cower","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"cheer","frames":45,"loop":false,"rootMotion":false,"events":[]},{"name":"climb_up","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","hunch_breathing","ear_twitch","weapon_hand_swap"]

## Default hurtboxes

- **head** — sphere; radius 0.13; damage multiplier default
- **chest** — capsule; radius 0.12; damage multiplier default
- **pelvis** — sphere; radius 0.11; damage multiplier default
- **thigh_L** — capsule; radius 0.05; damage multiplier default
- **thigh_R** — capsule; radius 0.05; damage multiplier default
- **upperarm_L** — capsule; radius 0.04; damage multiplier default
- **upperarm_R** — capsule; radius 0.04; damage multiplier default

## Species

- [[Monsters/Goblinoids/Goblin|Goblin]] — anim_small_biped, 1 m high, override rig selection
- [[Monsters/Goblinoids/Goblin Archer|Goblin Archer]] — anim_small_biped, 1 m high, override rig selection
- [[Monsters/Goblinoids/Goblin Trapper|Goblin Trapper]] — anim_small_biped, 1 m high, override rig selection
- [[Monsters/Goblinoids/Goblin Shaman|Goblin Shaman]] — anim_small_biped, 1 m high, override rig selection
- [[Monsters/Goblinoids/Goblin Bomber|Goblin Bomber]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Goblinoids/Goblin Wolf Rider|Goblin Wolf Rider]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Scavenger|Kobold Scavenger]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Miner|Kobold Miner]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Sneak|Kobold Sneak]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Shaman|Kobold Shaman]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Trapmaster|Kobold Trapmaster]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Packleader|Kobold Packleader]] — anim_small_biped, 1.2 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Warlord|Kobold Warlord]] — anim_small_biped, 1.4 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Tunnel-Queen|Kobold Tunnel-Queen]] — anim_small_biped, 1.6 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Mud Doll|Mud Doll]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Gnome|Gnome]] — anim_small_biped, 0.7 m high, rigId rig selection
- [[Monsters/Gremlins/Gremlin|Gremlin]] — anim_small_biped, 0.6 m high, rigId rig selection
- [[Monsters/Gremlins/Saboteur Gremlin|Saboteur Gremlin]] — anim_small_biped, 0.7 m high, rigId rig selection
- [[Monsters/Gremlins/Gremlin King|Gremlin King]] — anim_small_biped, 1.2 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Umbrella Spirit|Umbrella Spirit]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/River Imp|River Imp]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Goblinoids/Grove Goblin|Grove Goblin]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Phantom Goblin Archer|Phantom Goblin Archer]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Grove Goblin Trapper|Grove Goblin Trapper]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Dawn Goblin Shaman|Dawn Goblin Shaman]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Vesper-Touched Goblin Bomber|Vesper-Touched Goblin Bomber]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Goblinoids/Ancient Goblin Wolf Rider|Ancient Goblin Wolf Rider]] — anim_small_biped, 1.5 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Scavenger Veteran|Kobold Scavenger Veteran]] — anim_small_biped, 1.4 m high, rigId rig selection
- [[Monsters/Kobolds/Ruin Kobold Miner|Ruin Kobold Miner]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Snow Kobold Sneak|Snow Kobold Sneak]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Kobolds/Cavern Kobold Shaman|Cavern Kobold Shaman]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Vesper-Touched Kobold Trapmaster|Vesper-Touched Kobold Trapmaster]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Kobolds/Vesper-Touched Kobold Packleader|Vesper-Touched Kobold Packleader]] — anim_small_biped, 1.2 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Warlord Veteran|Kobold Warlord Veteran]] — anim_small_biped, 2.2 m high, rigId rig selection
- [[Monsters/Kobolds/Vesper-Touched Kobold Tunnel-Queen|Vesper-Touched Kobold Tunnel-Queen]] — anim_small_biped, 1.6 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Greater Mud Doll|Greater Mud Doll]] — anim_small_biped, 1.3 m high, rigId rig selection
- [[Monsters/Elementals & Spirits/Greater Gnome|Greater Gnome]] — anim_small_biped, 1.1 m high, rigId rig selection
- [[Monsters/Gremlins/Ancient Gremlin|Ancient Gremlin]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Gremlins/Vesper-Touched Saboteur Gremlin|Vesper-Touched Saboteur Gremlin]] — anim_small_biped, 0.7 m high, rigId rig selection
- [[Monsters/Gremlins/Ruin Gremlin King|Ruin Gremlin King]] — anim_small_biped, 1.2 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Umbrella Spirit|Vesper-Touched Umbrella Spirit]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched River Imp|Vesper-Touched River Imp]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Goblinoids/Meadow Goblin|Meadow Goblin]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Ancient Goblin Archer|Ancient Goblin Archer]] — anim_small_biped, 1.5 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Elite Goblin Trapper|Elite Goblin Trapper]] — anim_small_biped, 1.6 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Ruin Goblin Shaman|Ruin Goblin Shaman]] — anim_small_biped, 1 m high, override (base species) rig selection
- [[Monsters/Goblinoids/Ruin Goblin Bomber|Ruin Goblin Bomber]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Goblinoids/Phantom Goblin Wolf Rider|Phantom Goblin Wolf Rider]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Kobolds/Phantom Kobold Scavenger|Phantom Kobold Scavenger]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Elite Kobold Miner|Elite Kobold Miner]] — anim_small_biped, 1.4 m high, rigId rig selection
- [[Monsters/Kobolds/Phantom Kobold Sneak|Phantom Kobold Sneak]] — anim_small_biped, 0.8 m high, rigId rig selection
- [[Monsters/Kobolds/Frost Kobold Shaman|Frost Kobold Shaman]] — anim_small_biped, 0.9 m high, rigId rig selection
- [[Monsters/Kobolds/Crag Kobold Trapmaster|Crag Kobold Trapmaster]] — anim_small_biped, 1 m high, rigId rig selection
- [[Monsters/Kobolds/Ancient Kobold Packleader|Ancient Kobold Packleader]] — anim_small_biped, 1.8 m high, rigId rig selection
- [[Monsters/Kobolds/Shade Kobold Warlord|Shade Kobold Warlord]] — anim_small_biped, 1.4 m high, rigId rig selection
- [[Monsters/Kobolds/Kobold Tunnel-Queen Veteran|Kobold Tunnel-Queen Veteran]] — anim_small_biped, 2.6 m high, rigId rig selection
- [[Monsters/Gremlins/Cogmaw, the Gremlin Engine-King|Cogmaw, the Gremlin Engine-King]] — anim_small_biped, 3 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
