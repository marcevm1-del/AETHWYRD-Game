// Schema for Data/Combat/weapon_movesets.json (12_Systems/weapon_movesets.md). Called from build_schemas.js.
module.exports = function addWeaponSchemas(SCHEMAS) {
  const hit = { type: 'object', additionalProperties: false, required: ['weight', 'startupSec', 'activeSec', 'recoverySec', 'reachM', 'arcDeg', 'lungeM'], properties: {
    weight: { type: 'string', enum: ['light', 'medium', 'heavy', 'launch'] },
    startupSec: { type: 'number', minimum: 0.06, maximum: 1.5 }, activeSec: { type: 'number', minimum: 0.04, maximum: 0.5 }, recoverySec: { type: 'number', minimum: 0.1, maximum: 1.5 },
    reachM: { type: 'number', minimum: 0, maximum: 25 }, arcDeg: { type: 'number', minimum: 0, maximum: 360 }, lungeM: { type: 'number', minimum: -8, maximum: 8 } } };
  const move = { type: 'object', additionalProperties: false, required: ['role', 'name', 'control', 'moveM', 'hits', 'note'], properties: {
    role: { type: 'string', enum: ['opener', 'punish', 'spacing', 'crowd_control', 'payoff'] }, name: { type: 'string', minLength: 1 },
    skillId: { type: 'string', pattern: '^skl_[a-z0-9_]+$' },
    control: { type: 'string', enum: ['none', 'stagger', 'launch', 'push', 'pull', 'bind', 'slow', 'guard_break', 'knockdown'] },
    moveM: { type: 'number', minimum: -8, maximum: 8 }, hits: { type: 'array', minItems: 1, maxItems: 6, items: hit }, note: { type: 'string', minLength: 1 } } };
  SCHEMAS.weapon_movesets = {
    title: 'Weapon-family movesets', type: 'object', additionalProperties: false, required: ['version', 'notes', 'roles', 'families'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' }, roles: { type: 'array', items: { type: 'string' } },
      families: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false,
        required: ['id', 'name', 'weaponTypes', 'classes', 'identity', 'mobility', 'airBehavior', 'defense', 'resourceRhythm', 'trainingYard', 'moves'],
        properties: {
          id: { type: 'string', pattern: '^wf_[a-z0-9_]+$' }, name: { type: 'string', minLength: 1 },
          weaponTypes: { type: 'array', minItems: 1, items: { type: 'string', minLength: 1 } }, classes: { type: 'array', minItems: 1, items: { type: 'string', pattern: '^cls_[a-z0-9_]+$' } },
          identity: { type: 'string', minLength: 1 }, mobility: { type: 'string', minLength: 1 }, airBehavior: { type: 'string', minLength: 1 },
          defense: { type: 'string', enum: ['guard', 'parry', 'dodge', 'ally_cover'] }, parryWindowSec: { type: 'number', minimum: 0.08, maximum: 0.2 },
          resourceRhythm: { type: 'string', minLength: 1 }, trainingYard: { type: 'string', minLength: 1 },
          moves: { type: 'array', minItems: 5, maxItems: 8, items: move } } } }
    } };
  // Mounted combat (Data/Combat/mounted_combat.json; 12_Systems/mounted_combat.md). Adds to Companions/mounts.json mountedCombat.
  const pos = max => ({ type: 'number', exclusiveMinimum: 0, maximum: max });
  SCHEMAS.mounted_combat = {
    title: 'Mounted combat (ground mounts)', type: 'object', additionalProperties: false,
    required: ['version', 'notes', 'charge', 'trample', 'mountedDodge', 'dismount', 'mountStamina', 'familyPoiseMult', 'weaponFamilies', 'polearmChargeMult'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      charge: { type: 'object', additionalProperties: false, required: ['minRunupM', 'minSpeedMps', 'windupSec', 'activeSec', 'recoverySec', 'powerMult', 'weight', 'knockbackM', 'oncePerTarget', 'mountStaminaCost'], properties: {
        minRunupM: pos(30), minSpeedMps: pos(20), windupSec: pos(2), activeSec: pos(2), recoverySec: pos(3), powerMult: pos(4), weight: { type: 'string', enum: ['medium', 'heavy', 'launch'] },
        knockbackM: { type: 'number', minimum: 0, maximum: 8 }, oncePerTarget: { type: 'boolean' }, mountStaminaCost: pos(100) } },
      trample: { type: 'object', additionalProperties: false, required: ['maxTargetPoise', 'powerMult', 'cooldownSec', 'mountStaminaCost', 'bossesImmune'], properties: {
        maxTargetPoise: pos(400), powerMult: pos(2), cooldownSec: pos(30), mountStaminaCost: { type: 'number', minimum: 0, maximum: 100 }, bossesImmune: { type: 'boolean', enum: [true] } } },
      mountedDodge: { type: 'object', additionalProperties: false, required: ['durationSec', 'iframeSec', 'distanceM', 'mountStaminaCost', 'maxChain'], properties: {
        durationSec: pos(2), iframeSec: pos(1), distanceM: pos(10), mountStaminaCost: pos(100), maxChain: { type: 'integer', minimum: 1, maximum: 3 } } },
      dismount: { type: 'object', additionalProperties: false, required: ['onlyOnStagger', 'graceInvulnSec', 'remountCooldownSec', 'mountCallSec', 'mountUpSec'], properties: {
        onlyOnStagger: { type: 'boolean', enum: [true] }, graceInvulnSec: { type: 'number', minimum: 0.5, maximum: 3 }, remountCooldownSec: { type: 'number', minimum: 0, maximum: 30 },
        mountCallSec: pos(30), mountUpSec: pos(5) } },
      mountStamina: { type: 'object', additionalProperties: false, required: ['notes', 'areaDamageDrainFraction', 'unseatAtZero'], properties: {
        notes: { type: 'string' }, areaDamageDrainFraction: { type: 'number', minimum: 0, maximum: 1 }, unseatAtZero: { type: 'boolean', enum: [true] } } },
      familyPoiseMult: { type: 'object', additionalProperties: { type: 'number', minimum: 1, maximum: 3 } },
      weaponFamilies: { type: 'object', additionalProperties: { type: 'object', additionalProperties: false, required: ['allowed', 'maxChainHits', 'reachCapM', 'note'], properties: {
        allowed: { type: 'boolean' }, maxChainHits: { type: 'integer', minimum: 0, maximum: 6 }, reachCapM: { type: 'number', minimum: 0, maximum: 25 }, note: { type: 'string', minLength: 1 } } } },
      polearmChargeMult: pos(3)
    } };
};
