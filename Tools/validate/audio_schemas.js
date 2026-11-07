// Wave D schemas: adaptive music, environmental audio, accessibility and photo mode (12_Systems/audio_and_immersion.md).
// Called from build_schemas.js. Event names only: no audio files exist.
module.exports = function addAudioSchemas(SCHEMAS) {
  const ev = { type: 'string', pattern: '^[a-z][a-z0-9_]*$' };
  const gain = { type: 'number', minimum: 0, maximum: 1 };
  const gains = { type: 'object', additionalProperties: gain };
  const secs = { type: 'number', minimum: 0, maximum: 60 };

  SCHEMAS.music_states = {
    title: 'Adaptive music states (Wave D)', type: 'object', additionalProperties: false,
    required: ['version', 'tuning', 'layers', 'states', 'crossfades', 'overlays', 'companionThemes'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      tuning: { type: 'object', additionalProperties: false, required: ['defaultCrossfadeSeconds', 'reducedIntensityScale', 'regionArrivalStinger', 'bossPhaseStinger', 'companionThemeGain'],
        properties: { defaultCrossfadeSeconds: secs, reducedIntensityScale: gain, regionArrivalStinger: ev, bossPhaseStinger: ev, companionThemeGain: gain } },
      layers: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id'],
        properties: { id: ev, intense: { type: 'boolean' }, essential: { type: 'boolean' } } } },
      states: { type: 'array', minItems: 10, items: { type: 'object', additionalProperties: false, required: ['id', 'priority', 'minHoldSeconds', 'enterDelaySeconds', 'exitDelaySeconds', 'layers'],
        properties: {
          id: ev, priority: { type: 'integer', minimum: 0, maximum: 100 }, combatClass: { type: 'boolean' },
          minHoldSeconds: secs, enterDelaySeconds: secs, exitDelaySeconds: secs, retreatExitDelaySeconds: secs,
          daySplit: { type: 'boolean' }, allowCompanionTheme: { type: 'boolean' }, stingerOnEnter: ev,
          layers: gains, phaseLayers: { type: 'array', items: gains }
        } } },
      crossfades: { type: 'object', additionalProperties: secs },
      overlays: { type: 'object', additionalProperties: false, required: ['advantage', 'danger'],
        properties: {
          advantage: { type: 'object', additionalProperties: false, required: ['offDelaySeconds', 'layers'], properties: { offDelaySeconds: secs, layers: gains } },
          danger: { type: 'object', additionalProperties: false, required: ['enterBelowHp', 'exitAboveHp', 'layers'], properties: { enterBelowHp: gain, exitAboveHp: gain, layers: gains } }
        } },
      companionThemes: { type: 'array', items: { type: 'string', pattern: '^cmp_[a-z0-9_]+$' } }
    } };

  SCHEMAS.environment_audio = {
    title: 'Environmental audio (Wave D)', type: 'object', additionalProperties: false,
    required: ['version', 'fallbackSurface', 'gaits', 'surfaces', 'terrainSurface', 'wetOverlayEvent', 'weather', 'timeOfDay', 'biomeBeds', 'reverbZones'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' }, fallbackSurface: ev,
      gaits: { type: 'array', minItems: 1, items: ev },
      surfaces: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'wettable'], properties: { id: ev, wettable: { type: 'boolean' } } } },
      terrainSurface: { type: 'object', additionalProperties: ev }, wetOverlayEvent: ev,
      weather: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'layers'], properties: { id: ev, layers: gains, wetsSurfaces: { type: 'boolean' } } } },
      timeOfDay: { type: 'object', additionalProperties: gains },
      biomeBeds: { type: 'object', additionalProperties: ev },
      reverbZones: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false,
        required: ['id', 'reverbPreset', 'indoor', 'priority', 'weatherGain', 'timeOfDayGain', 'biomeBedGain', 'blendSeconds', 'layers'],
        properties: { id: ev, reverbPreset: ev, indoor: { type: 'boolean' }, priority: { type: 'integer', minimum: 0, maximum: 100 },
          weatherGain: gain, timeOfDayGain: gain, biomeBedGain: gain, blendSeconds: secs, layers: gains } } }
    } };

  const hex = { type: 'string', pattern: '^#[0-9A-Fa-f]{6}$' };
  const palette = { type: 'object', additionalProperties: false, required: ['parry', 'unblockable', 'grab', 'hpLow', 'positive', 'negative'],
    properties: { parry: hex, unblockable: hex, grab: hex, hpLow: hex, positive: hex, negative: hex } };
  const range = { type: 'array', minItems: 2, maxItems: 2, items: { type: 'number' } };
  SCHEMAS.accessibility = {
    title: 'Accessibility defaults and palettes (Wave D)', type: 'object', additionalProperties: false,
    required: ['version', 'defaults', 'ranges', 'reducedFlashCap', 'subtitleSizes', 'subtitleBackgrounds', 'holdActions', 'palettes', 'telegraphShapes'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      defaults: { type: 'object', additionalProperties: false,
        required: ['colorblindPalette', 'subtitlesEnabled', 'subtitleSize', 'subtitleBackground', 'dialogueTextSpeed', 'textScale', 'hudScale', 'highContrastPanels', 'dyslexiaFont', 'screenShake', 'flashIntensity', 'motionBlur', 'reducedFlash', 'noCombatMusic', 'reducedMusicIntensity', 'volumes'],
        properties: {
          colorblindPalette: { type: 'string', enum: ['off', 'protanopia', 'deuteranopia', 'tritanopia'] }, subtitlesEnabled: { type: 'boolean' },
          subtitleSize: { type: 'string', enum: ['small', 'medium', 'large', 'extraLarge'] }, subtitleBackground: { type: 'string', enum: ['none', 'shadow', 'box'] },
          dialogueTextSpeed: { type: 'number' }, textScale: { type: 'number' }, hudScale: { type: 'number' }, highContrastPanels: { type: 'boolean' }, dyslexiaFont: { type: 'boolean' },
          screenShake: gain, flashIntensity: gain, motionBlur: gain, reducedFlash: { type: 'boolean' }, noCombatMusic: { type: 'boolean' }, reducedMusicIntensity: { type: 'boolean' },
          volumes: { type: 'object', additionalProperties: false, required: ['master', 'music', 'effects', 'ambience', 'dialogue', 'callouts'],
            properties: { master: gain, music: gain, effects: gain, ambience: gain, dialogue: gain, callouts: gain } }
        } },
      ranges: { type: 'object', additionalProperties: range },
      reducedFlashCap: gain,
      subtitleSizes: { type: 'object', additionalProperties: { type: 'number', minimum: 0.5, maximum: 3 } },
      subtitleBackgrounds: { type: 'array', items: { type: 'string', enum: ['none', 'shadow', 'box'] } },
      holdActions: { type: 'array', minItems: 1, items: ev },
      palettes: { type: 'object', additionalProperties: palette },
      telegraphShapes: { type: 'object', additionalProperties: { type: 'string', enum: ['circle', 'triangle', 'square'] } }
    } };

  const opt = { type: 'object', additionalProperties: false, required: ['id', 'name'], properties: { id: ev, name: { type: 'string', minLength: 1 } } };
  SCHEMAS.photo_mode = {
    title: 'Photo mode (Wave D)', type: 'object', additionalProperties: false,
    required: ['version', 'tuning', 'blockedTags', 'blockedWhen', 'hideElements', 'poses', 'filters', 'frames'],
    properties: {
      version: { type: 'integer', minimum: 1 }, notes: { type: 'string' },
      tuning: { type: 'object', additionalProperties: false, required: ['fovMin', 'fovMax', 'fovDefault', 'hourStep', 'filterIntensityDefault'],
        properties: { fovMin: { type: 'number', minimum: 1 }, fovMax: { type: 'number', maximum: 120 }, fovDefault: { type: 'number' }, hourStep: { type: 'number', minimum: 0.05, maximum: 1 }, filterIntensityDefault: gain } },
      blockedTags: { type: 'array', minItems: 1, items: ev },
      blockedWhen: { type: 'array', minItems: 1, items: { type: 'string', enum: ['combat', 'cutscene', 'siege_battle', 'dialogue'] } },
      hideElements: { type: 'array', minItems: 1, items: ev },
      poses: { type: 'array', minItems: 1, items: { type: 'object', additionalProperties: false, required: ['id', 'name', 'target', 'tags'],
        properties: { id: { type: 'string', pattern: '^pose_[a-z0-9_]+$' }, name: { type: 'string', minLength: 1 }, target: { type: 'string', enum: ['player', 'companion', 'both'] }, tags: { type: 'array', minItems: 1, items: ev } } } },
      filters: { type: 'array', minItems: 1, items: opt }, frames: { type: 'array', minItems: 1, items: opt }
    } };
};
