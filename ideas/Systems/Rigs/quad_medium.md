---
type: monster-rig
id: rig:quad_medium
tags: [rig, animation, quad-medium]
---
# quad_medium rig

Medium quadrupeds 1–2.5 m long. Full gait set (walk/trot/gallop), circling and pack flanking.

| Field | Value |
|---|---|
| Aliases | wolf, boar, beast, cat, deer, hound, quad |
| Species using rig | 6 |
| Families represented | Beasts |
| Bone count · budget | 39 · 44 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 1.5 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.25,"legFrac":0.5},{"name":"trot","froude":1,"legFrac":0.5},{"name":"gallop","froude":4.5,"legFrac":0.5}],"fantasyMult":1.15,"turnDegPerSecAt1m":400,"accelG":1.1,"jumpHeightFrac":0.6,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.012,"density":1000,"collider":{"type":"capsule","axis":"y","radiusFrac":0.16,"heightFrac":0.95},"gravityScale":1.4,"linearDrag":0.05,"knockbackResist":0.3,"launchable":true,"ragdoll":"full","deathStyle":"ragdoll_slide"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":36,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":9,"e":"footstep_R"},{"f":18,"e":"footstep_R"},{"f":27,"e":"footstep_L"}]},{"name":"trot","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"gallop","frames":16,"loop":true,"rootMotion":true,"events":[{"f":3,"e":"footstep_L"},{"f":11,"e":"footstep_R"}]},{"name":"circle_L","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"circle_R","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"launch_air","frames":14,"loop":false,"rootMotion":false,"events":[]},{"name":"air_hit","frames":10,"loop":false,"rootMotion":false,"events":[]},{"name":"fall_loop","frames":20,"loop":true,"rootMotion":false,"events":[]},{"name":"slam_bounce","frames":18,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"land"}]},{"name":"land","frames":14,"loop":false,"rootMotion":false,"events":[{"f":1,"e":"land"}]},{"name":"pounce","frames":30,"loop":false,"rootMotion":true,"events":[{"f":6,"e":"telegraph"},{"f":16,"e":"hit_on"},{"f":22,"e":"hit_off"}]},{"name":"howl","frames":60,"loop":false,"rootMotion":false,"events":[{"f":12,"e":"vocal"}]},{"name":"sniff_ground","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"shake_off_water","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"paw_scrape_charge_windup","frames":30,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"telegraph"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["look_at_target","foot_ik_ground","spine_bend_on_turn","body_tilt_on_slope","pant_breathing_after_run","hackles_raise_alert"]

## Default hurtboxes

- **head** — sphere; radius 0.08; damage multiplier default
- **chest** — capsule; radius 0.14; damage multiplier default
- **spine_01** — capsule; radius 0.13; damage multiplier default
- **tail_01** — capsule; radius 0.03; damage multiplier default

## Species

- [[Monsters/Beasts/Forest Wolf|Forest Wolf]] — anim_quad_large, 0.8 m high, override rig selection
- [[Monsters/Beasts/Wild Boar|Wild Boar]] — anim_quad_large, 0.94 m high, override rig selection
- [[Monsters/Beasts/Radiant Wolf|Radiant Wolf]] — anim_quad_large, 0.8 m high, override (base species) rig selection
- [[Monsters/Beasts/Crag Boar|Crag Boar]] — anim_quad_large, 0.94 m high, override (base species) rig selection
- [[Monsters/Beasts/Ancient Forest Wolf|Ancient Forest Wolf]] — anim_quad_large, 1.21 m high, override (base species) rig selection
- [[Monsters/Beasts/Phantom Wild Boar|Phantom Wild Boar]] — anim_quad_large, 0.94 m high, override (base species) rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
