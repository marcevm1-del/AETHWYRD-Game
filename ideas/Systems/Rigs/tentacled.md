---
type: monster-rig
id: rig:tentacled
tags: [rig, animation, tentacled]
---
# tentacled rig

Mantle + 8 tentacles (6 bones each). Tentacles are FABRIK chains that reach for targets; ink and grab attacks.

| Field | Value |
|---|---|
| Aliases | kraken, octopus, squid, jellyfish, tentacle, cephalopod |
| Species using rig | 7 |
| Families represented | Aquatic |
| Bone count · budget | 53 · 60 |
| Unity avatar · material | Generic · flesh |
| Reference size · axis | 3 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"tentacle_crawl","froude":0.2,"legFrac":0.3},{"name":"jet","froude":4,"legFrac":0.3}],"fantasyMult":1,"turnDegPerSecAt1m":300,"accelG":0.6,"jumpHeightFrac":0,"canClimb":"walls_slow","canSwim":true,"canFly":false,"hovers":false}
- **Physics profile:** {"shapeK":0.02,"density":1000,"collider":{"type":"sphere","radiusFrac":0.2,"centerZFrac":0.3},"gravityScale":1,"buoyancy":1,"linearDrag":0.8,"knockbackResist":0.7,"launchable":false,"ragdoll":"chain_physics","deathStyle":"sink_limp"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"tentacle_crawl","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"jet","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"ink_cloud","frames":30,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vfx"}]},{"name":"tentacle_slam","frames":36,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"},{"f":22,"e":"hit_on"},{"f":25,"e":"hit_off"}]},{"name":"grab_squeeze_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["tentacle_fabrik_reach","tentacle_idle_curl_noise","mantle_jet_pulse","color_shift_skin"]

## Default hurtboxes

- **head** — sphere; radius 0.12; damage multiplier default
- **mantle** — capsule; radius 0.14; damage multiplier default
- **tentacle1_03** — capsule; radius 0.03; damage multiplier default
- **tentacle3_03** — capsule; radius 0.03; damage multiplier default
- **tentacle5_03** — capsule; radius 0.03; damage multiplier default
- **tentacle7_03** — capsule; radius 0.03; damage multiplier default

## Species

- [[Monsters/Aquatic/Giant Octopus|Giant Octopus]] — anim_cephalopod, 5.5 m high, rigId rig selection
- [[Monsters/Aquatic/Kraken Spawn|Kraken Spawn]] — anim_cephalopod, 13.75 m high, rigId rig selection
- [[Monsters/Aquatic/Abyssal Kraken Queen|Abyssal Kraken Queen]] — anim_cephalopod, 110 m high, rigId rig selection
- [[Monsters/Aquatic/Reef Octopus|Reef Octopus]] — anim_cephalopod, 5.5 m high, rigId rig selection
- [[Monsters/Aquatic/Vesper-Touched Kraken Spawn|Vesper-Touched Kraken Spawn]] — anim_cephalopod, 13.75 m high, rigId rig selection
- [[Monsters/Aquatic/Phantom Abyssal Kraken Queen|Phantom Abyssal Kraken Queen]] — anim_cephalopod, 110 m high, rigId rig selection
- [[Monsters/Aquatic/Krakenmother Ys, Queen of the Wreck Tide|Krakenmother Ys, Queen of the Wreck Tide]] — anim_cephalopod, 22 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
