using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Reads keyboard/mouse and gamepad and drives the player relative to the camera, following the default layout
    /// in 12_Systems/hud_and_ui.md §15. Bindings are defined in code for Ring 0; a rebindable .inputactions asset
    /// replaces this in Ring 1.
    ///   Move: WASD / left stick · Jump: Space / A · Dodge: Shift / B (hold to sprint) · Walk: Left Alt
    ///   Light: LMB / X · Heavy: RMB / Y (hold to charge; after two lights = launcher; in the air = slam)
    ///   Block / parry: Q / RT · Lock-on: MMB / R3 (flick to switch) · Jump during a launcher follows the target up
    ///   Skills: 1–4 / hold RB + X, Y, A, B · Ultimate: R / L3 + R3 · Fire Bomb (quick item): G / D-pad up
    /// During Flash Time the world slows but the player keeps real-time speed; hit-stop freezes everyone.
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerInputDriver : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        PlayerMotor _motor;
        PlayerCombat _combat;
        PlayerDefense _defense;
        LockOn _lockOn;
        InputAction _move, _dodge, _walk, _jump, _light, _heavy, _block, _lock, _skillMod, _ultimate, _l3, _bomb;
        readonly InputAction[] _skillKeys = new InputAction[4];

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
            _defense = GetComponent<PlayerDefense>();
            _lockOn = GetComponent<LockOn>();
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;

            _move = new InputAction("Move", InputActionType.Value);
            _move.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s").With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
            _move.AddBinding("<Gamepad>/leftStick");
            _dodge = Button("Dodge", "<Keyboard>/leftShift", "<Gamepad>/buttonEast");
            _walk = Button("Walk", "<Keyboard>/leftAlt");
            _jump = Button("Jump", "<Keyboard>/space", "<Gamepad>/buttonSouth");
            _light = Button("Light", "<Mouse>/leftButton", "<Gamepad>/buttonWest");
            _heavy = Button("Heavy", "<Mouse>/rightButton", "<Gamepad>/buttonNorth");
            _block = Button("Block", "<Keyboard>/q", "<Gamepad>/rightTrigger");
            _lock = Button("LockOn", "<Mouse>/middleButton", "<Gamepad>/rightStickPress");
            _skillMod = Button("SkillModifier", "<Gamepad>/rightShoulder");
            _ultimate = Button("Ultimate", "<Keyboard>/r");
            _l3 = Button("L3", "<Gamepad>/leftStickPress");
            _bomb = Button("QuickItem", "<Keyboard>/g", "<Gamepad>/dpad/up");
            for (int i = 0; i < 4; i++) _skillKeys[i] = Button($"Skill{i + 1}", $"<Keyboard>/{i + 1}");
        }

        static InputAction Button(string name, params string[] bindings)
        {
            var a = new InputAction(name, InputActionType.Button);
            foreach (var b in bindings) a.AddBinding(b);
            return a;
        }

        InputAction[] Actions => new[] { _move, _dodge, _walk, _jump, _light, _heavy, _block, _lock, _skillMod, _ultimate, _l3, _bomb,
            _skillKeys[0], _skillKeys[1], _skillKeys[2], _skillKeys[3] };

        void OnEnable() { foreach (var a in Actions) a.Enable(); }
        void OnDisable() { foreach (var a in Actions) a.Disable(); }
        void OnDestroy() { foreach (var a in Actions) a.Dispose(); }

        void Update()
        {
            float dt = PlayerDelta;
            Vector3 world = CameraRelative(_move.ReadValue<Vector2>());
            bool attacking = _combat != null && _combat.IsAttacking;
            if (_defense != null && _defense.IsHeld)
            {
                // Grabbed: only gravity runs until the monster lets go.
                if (_combat != null) _combat.Tick(dt);
                _motor.Tick(Vector3.zero, false, false, dt);
                return;
            }

            // Holding RB turns the face buttons into skills 1–4 (they don't jump, dodge or attack meanwhile).
            bool skillMode = _skillMod.IsPressed();
            var pad = Gamepad.current;
            if (_combat != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    bool padPress = skillMode && pad != null && WasPadPressed(pad, i);
                    if (_skillKeys[i].WasPressedThisFrame() || padPress) _combat.CastSlot(i);
                }
                bool padUltimate = pad != null && ((pad.leftStickButton.isPressed && pad.rightStickButton.wasPressedThisFrame) ||
                                                   (pad.rightStickButton.isPressed && pad.leftStickButton.wasPressedThisFrame));
                if (_ultimate.WasPressedThisFrame() || padUltimate) _combat.CastUltimate();
                if (_bomb.WasPressedThisFrame()) _combat.ThrowFireBomb();
            }
            bool padFaceBusy = skillMode && pad != null;
            bool ultimateChord = pad != null && pad.leftStickButton.isPressed && pad.rightStickButton.isPressed;

            if (!padFaceBusy && _jump.WasPressedThisFrame() && !(_combat != null && _combat.TryJumpCancel()) && !attacking) _motor.Jump();
            if (_lock.WasPressedThisFrame() && !ultimateChord && _lockOn != null) _lockOn.Toggle();
            if (!padFaceBusy && _dodge.WasPressedThisFrame() && (_combat == null || _combat.TryCancelForDodge())) _motor.Dodge(world);
            if (_defense != null) _defense.SetBlock(_block.IsPressed() && !attacking);
            if (_combat != null)
            {
                if (!padFaceBusy && _light.WasPressedThisFrame()) _combat.Attack();
                if (!padFaceBusy && _heavy.WasPressedThisFrame()) _combat.BeginHeavy();
                if (_heavy.WasReleasedThisFrame()) _combat.ReleaseHeavy();
                _combat.Tick(dt);
            }
            // Attacks and blocking root the player (the lunge moves them); gravity and dodges still run through the motor.
            bool rooted = (_combat != null && _combat.IsAttacking) || (_defense != null && _defense.IsBlocking);
            bool sprint = _dodge.IsPressed() && !_motor.IsDodging;
            _motor.Tick(rooted ? Vector3.zero : world, _walk.IsPressed(), sprint, dt);
        }

        /// <summary>The player's time step: 0 in hit-stop, real time during Flash Time, otherwise game time.</summary>
        public static float PlayerDelta => GameTime.HitStopActive ? 0f : GameTime.FlashTimeActive ? Time.unscaledDeltaTime : Time.deltaTime;

        static bool WasPadPressed(Gamepad pad, int slot)
        {
            switch (slot)
            {
                case 0: return pad.buttonWest.wasPressedThisFrame;
                case 1: return pad.buttonNorth.wasPressedThisFrame;
                case 2: return pad.buttonSouth.wasPressedThisFrame;
                default: return pad.buttonEast.wasPressedThisFrame;
            }
        }

        Vector3 CameraRelative(Vector2 input)
        {
            if (cameraTransform == null) return new Vector3(input.x, 0, input.y);
            Vector3 fwd = cameraTransform.forward; fwd.y = 0; fwd.Normalize();
            Vector3 right = cameraTransform.right; right.y = 0; right.Normalize();
            return fwd * input.y + right * input.x;
        }
    }
}
