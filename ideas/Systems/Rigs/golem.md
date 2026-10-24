---
type: monster-rig
id: rig:golem
tags: [rig, animation, golem]
---
# golem rig

Constructs: rigid segments (no skin deformation, every mesh piece parented to one bone), a glowing core. Joints may float with visible gaps.

| Field | Value |
|---|---|
| Aliases | construct, automaton, stone_golem, gargoyle_ground |
| Species using rig | 17 |
| Families represented | Constructs & Mimics, Floor-born |
| Bone count · budget | 27 · 40 |
| Unity avatar · material | Humanoid · stone |
| Reference size · axis | 3 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.15,"legFrac":0.48},{"name":"run","froude":0.7,"legFrac":0.48}],"fantasyMult":1,"turnDegPerSecAt1m":200,"accelG":0.3,"jumpHeightFrac":0.1,"canClimb":false,"canSwim":"sinks_walks_bottom","canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.02,"density":2400,"collider":{"type":"capsule","radiusFrac":0.22,"heightFrac":1},"gravityScale":1.2,"linearDrag":0,"knockbackResist":0.95,"launchable":"only_while_staggered","ragdoll":"shatter_pieces","deathStyle":"crumble_into_rubble"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"core_charge","frames":60,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"telegraph"},{"f":45,"e":"hit_on"}]},{"name":"reassemble","frames":60,"loop":false,"rootMotion":false,"events":[]},{"name":"ground_pound","frames":45,"loop":false,"rootMotion":false,"events":[{"f":8,"e":"telegraph"},{"f":28,"e":"hit_on"},{"f":30,"e":"land"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["rigid_segments","core_glow_pulse_by_hp","gap_jitter_when_damaged","footstep_camera_shake","dust_from_joints"]

## Default hurtboxes

- **core_gem** — sphere; radius 0.05; damage multiplier default
- **chest** — box; radius —; damage multiplier default
- **head** — box; radius —; damage multiplier default
- **forearm_L** — box; radius —; damage multiplier default
- **forearm_R** — box; radius —; damage multiplier default

## Species

- [[Monsters/Constructs & Mimics/Stone Golem|Stone Golem]] — anim_golem, 3 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Clockwork Sentinel|Clockwork Sentinel]] — anim_golem, 2.5 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Iron Golem|Iron Golem]] — anim_golem, 4 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Crystal Golem|Crystal Golem]] — anim_golem, 3.5 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Mithril Colossus|Mithril Colossus]] — anim_golem, 50 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Starmetal Colossus|Starmetal Colossus]] — anim_golem, 120 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Titan of the First Age|Titan of the First Age]] — anim_golem, 500 m high, rigId rig selection
- [[Monsters/Floor-born/Core Sentinel|Core Sentinel]] — anim_golem, 2.5 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Greater Stone Golem|Greater Stone Golem]] — anim_golem, 4.8 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Dusk Clockwork Sentinel|Dusk Clockwork Sentinel]] — anim_golem, 2.5 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Greater Iron Golem|Greater Iron Golem]] — anim_golem, 6.4 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Vesper-Touched Crystal Golem|Vesper-Touched Crystal Golem]] — anim_golem, 3.5 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Ancient Mithril Colossus|Ancient Mithril Colossus]] — anim_golem, 75 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/Tide Starmetal Colossus|Tide Starmetal Colossus]] — anim_golem, 120 m high, rigId rig selection
- [[Monsters/Floor-born/Greater Core Sentinel|Greater Core Sentinel]] — anim_golem, 4 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/The Tithe Colossus, Hunger of the Foundation Stones|The Tithe Colossus, Hunger of the Foundation Stones]] — anim_golem, 7 m high, rigId rig selection
- [[Monsters/Constructs & Mimics/The Colossus of Sunscar, Walker of the Dunes|The Colossus of Sunscar, Walker of the Dunes]] — anim_golem, 60 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
