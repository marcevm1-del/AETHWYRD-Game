---
type: monster-rig
id: rig:giant_biped
tags: [rig, animation, giant-biped]
---
# giant_biped rig

Giants 6–20 m. Same skeleton as large_biped plus climbable surfaces and weak-point sockets. Player can climb onto them (Shadow of the Colossus style grab points).

| Field | Value |
|---|---|
| Aliases | giant, titan, colossus_humanoid, frost_giant |
| Species using rig | 6 |
| Families represented | Plants & Fungi |
| Bone count · budget | 37 · 70 |
| Unity avatar · material | Humanoid · flesh |
| Reference size · axis | 10 · height |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.15,"legFrac":0.48},{"name":"run","froude":0.6,"legFrac":0.48}],"fantasyMult":1,"turnDegPerSecAt1m":300,"accelG":0.2,"jumpHeightFrac":0,"canClimb":false,"canSwim":"wade","canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.016,"density":1000,"collider":{"type":"capsule","radiusFrac":0.18,"heightFrac":1},"gravityScale":1,"linearDrag":0.02,"knockbackResist":1,"launchable":false,"ragdoll":"none","deathStyle":"cinematic_collapse"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":32,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":16,"e":"footstep_R"}]},{"name":"run","frames":20,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":10,"e":"footstep_R"}]},{"name":"walk_back","frames":32,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_L","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"strafe_R","frames":28,"loop":true,"rootMotion":true,"events":[]},{"name":"stomp","frames":50,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"telegraph"},{"f":34,"e":"hit_on"},{"f":35,"e":"land"}]},{"name":"sweep","frames":60,"loop":false,"rootMotion":false,"events":[{"f":12,"e":"telegraph"},{"f":36,"e":"hit_on"},{"f":46,"e":"hit_off"}]},{"name":"shake_off","frames":40,"loop":false,"rootMotion":false,"events":[]},{"name":"kneel","frames":40,"loop":false,"rootMotion":false,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","footstep_camera_shake","shake_off_climber","slow_head_track"]

## Default hurtboxes

- **head** — sphere; radius 0.08; damage multiplier default
- **back_weakpoint** — sphere; radius 0.05; damage multiplier default
- **chest** — capsule; radius 0.17; damage multiplier default
- **calf_L** — capsule; radius 0.05; damage multiplier default
- **calf_R** — capsule; radius 0.05; damage multiplier default

## Species

- [[Monsters/Plants & Fungi/Elder Treant|Elder Treant]] — anim_plant_walker, 12 m high, override rig selection
- [[Monsters/Plants & Fungi/Ancient Treant|Ancient Treant]] — anim_plant_walker, 30 m high, override rig selection
- [[Monsters/Plants & Fungi/Worldroot Behemoth|Worldroot Behemoth]] — anim_plant_walker, 80 m high, override rig selection
- [[Monsters/Plants & Fungi/Tide Elder Treant|Tide Elder Treant]] — anim_plant_walker, 12 m high, override (base species) rig selection
- [[Monsters/Plants & Fungi/Bog Ancient Treant|Bog Ancient Treant]] — anim_plant_walker, 30 m high, override (base species) rig selection
- [[Monsters/Plants & Fungi/Thunder Worldroot Behemoth|Thunder Worldroot Behemoth]] — anim_plant_walker, 80 m high, override (base species) rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
