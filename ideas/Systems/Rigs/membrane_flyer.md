---
type: monster-rig
id: rig:membrane_flyer
tags: [rig, animation, membrane-flyer]
---
# membrane_flyer rig

Bat-winged fliers: membrane wings on finger bones. Erratic flight, ceiling hang, swoops.

| Field | Value |
|---|---|
| Aliases | bat, winged_imp, gargoyle, flying_small |
| Species using rig | 4 |
| Families represented | Demons, Familiars & Gentle Creatures |
| Bone count · budget | 28 · 40 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 0.5 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"crawl","froude":0.3,"legFrac":0.15}],"fantasyMult":1,"turnDegPerSecAt1m":720,"accelG":1.5,"jumpHeightFrac":0.3,"canClimb":"walls_and_ceilings","canSwim":false,"canFly":true,"hovers":true,"flySpeedMult":4}
- **Physics profile:** {"shapeK":0.02,"density":1000,"collider":{"type":"sphere","radiusFrac":0.18,"centerZFrac":0.3},"gravityScale":0.8,"linearDrag":0.6,"knockbackResist":0.05,"launchable":true,"ragdoll":"full","deathStyle":"flutter_fall"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"fly_hover","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"fly_forward","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_glide","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"takeoff","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"fly_land","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"dive","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"crawl","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"ceiling_hang","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"swoop","frames":30,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"}]},{"name":"screech","frames":40,"loop":false,"rootMotion":false,"events":[{"f":8,"e":"vocal"},{"f":10,"e":"hit_on"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["erratic_flight_noise","ceiling_hang_flip","wing_membrane_cloth","bank_into_turns_in_air"]

## Default hurtboxes

- **body** — sphere; radius 0.12; damage multiplier default
- **head** — sphere; radius 0.06; damage multiplier default
- **wing_radius_L** — capsule; radius 0.02; damage multiplier default
- **wing_radius_R** — capsule; radius 0.02; damage multiplier default

## Species

- [[Monsters/Demons/Imp|Imp]] — anim_flyer_small, 0.26 m high, override rig selection
- [[Monsters/Familiars & Gentle Creatures/Lantern Moth|Lantern Moth]] — anim_flyer_small, 0.13 m high, override rig selection
- [[Monsters/Demons/Thorn Imp|Thorn Imp]] — anim_flyer_small, 0.26 m high, override (base species) rig selection
- [[Monsters/Familiars & Gentle Creatures/Elder Lantern Moth|Elder Lantern Moth]] — anim_flyer_small, 0.22 m high, override (base species) rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
