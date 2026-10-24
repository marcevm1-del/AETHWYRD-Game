---
type: monster-rig
id: rig:dragon
tags: [rig, animation, dragon]
---
# dragon rig

Four legs + a separate pair of wings (6 limbs): dragons, griffons, manticores. Long neck and tail. Flies in boss fights; never a mount (Canon).

| Field | Value |
|---|---|
| Aliases | winged_quad, griffon, manticore, chimera, elder_dragon |
| Species using rig | 19 |
| Families represented | Undead, Dragons |
| Bone count · budget | 63 · 90 |
| Unity avatar · material | Generic · scaled |
| Reference size · axis | 12 · length |

## Locomotion and animations

- **Locomotion:** {"gaits":[{"name":"walk","froude":0.18,"legFrac":0.3},{"name":"run","froude":1.4,"legFrac":0.3}],"fantasyMult":1,"turnDegPerSecAt1m":600,"accelG":0.35,"jumpHeightFrac":0.15,"canClimb":"cliffs","canSwim":true,"canFly":true,"hovers":true,"flySpeedMult":2.2}
- **Physics profile:** {"shapeK":0.006,"density":1150,"collider":{"type":"capsule","axis":"y","radiusFrac":0.08,"heightFrac":0.6},"gravityScale":1,"linearDrag":0.02,"knockbackResist":1,"launchable":false,"ragdoll":"none","deathStyle":"cinematic_collapse"}
- **Animation set:** [{"name":"idle","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_alert","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"idle_fidget_01","frames":120,"loop":false,"rootMotion":false,"events":[]},{"name":"turn_90_L","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_90_R","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"turn_180","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"hit_light_front","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_light_back","frames":12,"loop":false,"rootMotion":false,"events":[]},{"name":"hit_heavy","frames":22,"loop":false,"rootMotion":true,"events":[]},{"name":"stagger","frames":40,"loop":false,"rootMotion":true,"events":[]},{"name":"break_down_loop","frames":60,"loop":true,"rootMotion":false,"events":[]},{"name":"break_recover","frames":30,"loop":false,"rootMotion":false,"events":[]},{"name":"knockdown","frames":28,"loop":false,"rootMotion":true,"events":[]},{"name":"getup","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"death","frames":45,"loop":false,"rootMotion":true,"events":[{"f":30,"e":"ragdoll"}]},{"name":"spawn","frames":40,"loop":false,"rootMotion":false,"events":[{"f":0,"e":"vfx"}]},{"name":"taunt","frames":45,"loop":false,"rootMotion":false,"events":[{"f":10,"e":"vocal"}]},{"name":"flee_start","frames":15,"loop":false,"rootMotion":true,"events":[]},{"name":"sleep_loop","frames":120,"loop":true,"rootMotion":false,"events":[]},{"name":"eat_loop","frames":90,"loop":true,"rootMotion":false,"events":[]},{"name":"frozen_pose","frames":1,"loop":true,"rootMotion":false,"events":[]},{"name":"stun_loop","frames":40,"loop":true,"rootMotion":false,"events":[]},{"name":"walk","frames":36,"loop":true,"rootMotion":true,"events":[{"f":0,"e":"footstep_L"},{"f":9,"e":"footstep_R"},{"f":18,"e":"footstep_R"},{"f":27,"e":"footstep_L"}]},{"name":"trot","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"gallop","frames":16,"loop":true,"rootMotion":true,"events":[{"f":3,"e":"footstep_L"},{"f":11,"e":"footstep_R"}]},{"name":"circle_L","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"circle_R","frames":30,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_hover","frames":30,"loop":true,"rootMotion":false,"events":[]},{"name":"fly_forward","frames":24,"loop":true,"rootMotion":true,"events":[]},{"name":"fly_glide","frames":40,"loop":true,"rootMotion":true,"events":[]},{"name":"takeoff","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"fly_land","frames":30,"loop":false,"rootMotion":true,"events":[]},{"name":"dive","frames":20,"loop":false,"rootMotion":true,"events":[]},{"name":"breath_windup","frames":45,"loop":false,"rootMotion":false,"events":[{"f":2,"e":"telegraph"}]},{"name":"breath_loop","frames":30,"loop":true,"rootMotion":false,"events":[{"f":0,"e":"hit_on"}]},{"name":"tail_sweep","frames":40,"loop":false,"rootMotion":false,"events":[{"f":6,"e":"telegraph"},{"f":20,"e":"hit_on"},{"f":28,"e":"hit_off"}]},{"name":"wing_buffet","frames":36,"loop":false,"rootMotion":false,"events":[]},{"name":"roar","frames":75,"loop":false,"rootMotion":false,"events":[{"f":15,"e":"vocal"}]},{"name":"attack_01","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_02","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_03","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_04","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_05","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_06","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_07","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]},{"name":"attack_08","frames":40,"loop":false,"rootMotion":true,"events":[{"f":4,"e":"telegraph"},{"f":18,"e":"hit_on"},{"f":22,"e":"hit_off"},{"f":30,"e":"cancel"}]}]
- **Procedural motion:** ["neck_aim_ik","look_at_target","foot_ik_ground","tail_drag_physics","wing_fold_spring","breath_charge_throat_glow","footstep_camera_shake"]

## Default hurtboxes

- **head** — sphere; radius 0.05; damage multiplier default
- **neck_03** — capsule; radius 0.04; damage multiplier default
- **chest** — capsule; radius 0.1; damage multiplier default
- **spine_01** — capsule; radius 0.09; damage multiplier default
- **wing_radius_L** — capsule; radius 0.03; damage multiplier default
- **wing_radius_R** — capsule; radius 0.03; damage multiplier default
- **tail_06** — capsule; radius 0.025; damage multiplier default

## Species

- [[Monsters/Undead/Bone Dragon|Bone Dragon]] — anim_dragon, 11.2 m high, rigId rig selection
- [[Monsters/Dragons/Hatchling|Hatchling]] — anim_dragon, 0.28 m high, rigId rig selection
- [[Monsters/Dragons/Young Dragon|Young Dragon]] — anim_dragon, 6.72 m high, rigId rig selection
- [[Monsters/Dragons/Adult Dragon|Adult Dragon]] — anim_dragon, 14 m high, rigId rig selection
- [[Monsters/Dragons/Starfall Wyrm|Starfall Wyrm]] — anim_dragon, 33.6 m high, rigId rig selection
- [[Monsters/Dragons/Ignivar, the Ember Throne|Ignivar, the Ember Throne]] — anim_dragon, 44.8 m high, rigId rig selection
- [[Monsters/Dragons/Glacirra, the White Silence|Glacirra, the White Silence]] — anim_dragon, 44.8 m high, rigId rig selection
- [[Monsters/Dragons/Zephyros, the Endless Sky|Zephyros, the Endless Sky]] — anim_dragon, 50.4 m high, rigId rig selection
- [[Monsters/Dragons/Terragon, the Mountain That Breathes|Terragon, the Mountain That Breathes]] — anim_dragon, 1120 m high, rigId rig selection
- [[Monsters/Dragons/Umbrael, the Hollow Star|Umbrael, the Hollow Star]] — anim_dragon, 56 m high, rigId rig selection
- [[Monsters/Dragons/Solvoryn, the Dawnwyrm|Solvoryn, the Dawnwyrm]] — anim_dragon, 84 m high, rigId rig selection
- [[Monsters/Dragons/Nythraxa, the Duskwyrm|Nythraxa, the Duskwyrm]] — anim_dragon, 84 m high, rigId rig selection
- [[Monsters/Dragons/Kaelumbra, the Twilight Arbiter|Kaelumbra, the Twilight Arbiter]] — anim_dragon, 84 m high, rigId rig selection
- [[Monsters/Undead/Dawn Bone Dragon|Dawn Bone Dragon]] — anim_dragon, 11.2 m high, rigId rig selection
- [[Monsters/Dragons/Rime Hatchling|Rime Hatchling]] — anim_dragon, 0.28 m high, rigId rig selection
- [[Monsters/Dragons/Vesper-Touched Young Dragon|Vesper-Touched Young Dragon]] — anim_dragon, 6.72 m high, rigId rig selection
- [[Monsters/Dragons/Ancient Adult Dragon|Ancient Adult Dragon]] — anim_dragon, 21 m high, rigId rig selection
- [[Monsters/Dragons/Greater Starfall Wyrm|Greater Starfall Wyrm]] — anim_dragon, 53.76 m high, rigId rig selection
- [[Monsters/Undead/Elder Bone Dragon|Elder Bone Dragon]] — anim_dragon, 17.92 m high, rigId rig selection

## Production checks

Validate the rig export axes, root transform, bone presence, animator mapping, hurtbox placement and a representative locomotion cycle before using it for a new species. Motion overrides should be reserved for species whose signature silhouette or action cannot be expressed by the shared rig rules.
