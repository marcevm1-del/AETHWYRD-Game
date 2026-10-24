---
type: monster-rig
id: rig:taur
tags: [rig, animation, taur]
---
# taur rig

Humanoid torso on a four-legged body: centaurs. Lower body uses quad gaits; upper body aims weapons independently.

| Field | Value |
|---|---|
| Aliases | centaur, arachne, taur_beast |
| Species using rig | 8 |
| Families represented | Centaurs & Taurs |
| Bone count · budget | 39 · 60 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 2.4 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.25,"legFrac":0.6},{"name":"trot","froude":1,"legFrac":0.6},{"name":"gallop","froude":3.5,"legFrac":0.6}],"fantasyMult":1.1,"turnDegPerSecAt1m":360,"accelG":0.9,"jumpHeightFrac":0.5,"canClimb":false,"canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.02,"density":1000,"collider":{"type":"capsule","axis":"y","radiusFrac":0.16,"heightFrac":0.9},"gravityScale":1.3,"linearDrag":0.05,"knockbackResist":0.6,"launchable":"only_while_staggered","ragdoll":"partial","deathStyle":"ragdoll_slide"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":36,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":9,"e":"footstep_R"},{"f":18,"e":"footstep_R"},{"f":27,"e":"footstep_L"}]},{"name":"trot","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"gallop","frames":16,"loop":true,"rootMotion":true,"events":[{"f":3,"e":"footstep_L"},{"f":11,"e":"footstep_R"}]},{"name":"circle_L","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"circle_R","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"rear_up","frames":40,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"}]},{"name":"bow_shot_moving","frames":30,"loop":true,"rootMotion":false,"events":[{"f":18,"e":"hit_on"}]},{"name":"trample_charge","frames":16,"loop":true,"rootMotion":true,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["upper_body_aim_independent","foot_ik_ground","look_at_target","spine_bend_on_turn"]

## Default hurtboxes

- **h_head** — sphere; radius 0.04; damage multiplier default
- **torso_02** — capsule; radius 0.06; damage multiplier default
- **spine_01** — capsule; radius 0.14; damage multiplier default

## Species

- [[Monsters/Centaurs & Taurs/Centaur Scout|Centaur Scout]] — anim_taur, 2.52 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Centaur Lancer|Centaur Lancer]] — anim_taur, 2.73 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Scorpion Rider|Scorpion Rider]] — anim_taur, 3.15 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Centaur Khan|Centaur Khan]] — anim_taur, 3.15 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Shade Centaur Scout|Shade Centaur Scout]] — anim_taur, 2.52 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Crag Centaur Lancer|Crag Centaur Lancer]] — anim_taur, 2.73 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Ancient Scorpion Rider|Ancient Scorpion Rider]] — anim_taur, 4.73 m high, rigId rig selection
- [[Monsters/Centaurs & Taurs/Dune Centaur Khan|Dune Centaur Khan]] — anim_taur, 3.15 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
