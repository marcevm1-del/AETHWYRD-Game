using UnityEngine;
using UnityEngine.InputSystem;

namespace Ascend.Game
{
    /// <summary>
    /// Reads keyboard/mouse and gamepad and drives the PlayerMotor relative to the camera.
    /// Bindings are defined in code for Ring 0; a rebindable .inputactions asset replaces this in Ring 1.
    ///   Move: WASD / left stick · Sprint: Left Shift / left-stick press · Walk: Left Alt
    ///   Jump: Space / South (A) · Dodge: Left Ctrl or right mouse / East (B)
    /// </summary>
    [RequireComponent(typeof(PlayerMotor))]
    public sealed class PlayerInputDriver : MonoBehaviour
    {
        [SerializeField] Transform cameraTransform;

        PlayerMotor _motor;
        InputAction _move, _sprint, _walk, _jump, _dodge;

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
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
        }

        void OnEnable() { foreach (var a in new[] { _move, _sprint, _walk, _jump, _dodge }) a.Enable(); }
        void OnDisable() { foreach (var a in new[] { _move, _sprint, _walk, _jump, _dodge }) a.Disable(); }
        void OnDestroy() { foreach (var a in new[] { _move, _sprint, _walk, _jump, _dodge }) a.Dispose(); }

        void Update()
        {
            Vector2 input = _move.ReadValue<Vector2>();
            Vector3 world = CameraRelative(input);
            if (_jump.WasPressedThisFrame()) _motor.Jump();
            if (_dodge.WasPressedThisFrame()) _motor.Dodge(world);
            _motor.Tick(world, _walk.IsPressed(), _sprint.IsPressed(), Time.deltaTime);
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
