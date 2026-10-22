using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Reads keyboard/mouse and gamepad and drives the PlayerMotor relative to the camera.
    /// Bindings are defined in code for Ring 0; a rebindable .inputactions asset replaces this in Ring 1.
    ///   Move: WASD / left stick · Sprint: Left Shift / left-stick press · Walk: Left Alt
    ///   Jump: Space / South (A) · Dodge: Left Ctrl or right mouse / East (B) · Attack: left mouse / West (X)
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerInputDriver : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        PlayerMotor _motor;
        PlayerCombat _combat;
        InputAction _move, _sprint, _walk, _jump, _dodge, _attack;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;

            _move = new InputAction("Move", InputActionType.Value);
            _move.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s").With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
            _move.AddBinding("<Gamepad>/leftStick");
            _sprint = new InputAction("Sprint", InputActionType.Button);
            _sprint.AddBinding("<Keyboard>/leftShift"); _sprint.AddBinding("<Gamepad>/leftStickPress");
            _walk = new InputAction("Walk", InputActionType.Button, "<Keyboard>/leftAlt");
            _jump = new InputAction("Jump", InputActionType.Button);
            _jump.AddBinding("<Keyboard>/space"); _jump.AddBinding("<Gamepad>/buttonSouth");
            _dodge = new InputAction("Dodge", InputActionType.Button);
            _dodge.AddBinding("<Keyboard>/leftCtrl"); _dodge.AddBinding("<Mouse>/rightButton"); _dodge.AddBinding("<Gamepad>/buttonEast");
            _attack = new InputAction("Attack", InputActionType.Button);
            _attack.AddBinding("<Mouse>/leftButton"); _attack.AddBinding("<Gamepad>/buttonWest");
        }

        InputAction[] Actions => new[] { _move, _sprint, _walk, _jump, _dodge, _attack };

        void OnEnable() { foreach (var a in Actions) a.Enable(); }
        void OnDisable() { foreach (var a in Actions) a.Disable(); }
        void OnDestroy() { foreach (var a in Actions) a.Dispose(); }

        void Update()
        {
            Vector2 input = _move.ReadValue<Vector2>();
            Vector3 world = CameraRelative(input);
            bool attacking = _combat != null && _combat.IsAttacking;
            if (_jump.WasPressedThisFrame() && !attacking) _motor.Jump();
            if (_dodge.WasPressedThisFrame() && (_combat == null || _combat.TryCancelForDodge())) _motor.Dodge(world);
            if (_attack.WasPressedThisFrame() && _combat != null) _combat.Attack();
            if (_combat != null) _combat.Tick(Time.deltaTime);
            // Attacks root the player (the lunge moves them); gravity and dodges still run through the motor.
            _motor.Tick(_combat != null && _combat.IsAttacking ? Vector3.zero : world, _walk.IsPressed(), _sprint.IsPressed(), Time.deltaTime);
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
