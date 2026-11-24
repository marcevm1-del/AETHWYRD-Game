using Ascend.Core;
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
    ///   Talk / gather: E / D-pad down (opens the NPC dialog, or gathers a herb patch, pine or scrap heap) · Healing potion: H / D-pad right · Bag: I / Menu · Bestiary: B · Map: Tab or M / View
    ///   Partner order (Follow / Hold / Focus): Z / LB
    ///   Tame: T / D-pad left (PlayerTaming: begin near a weakened monster, press again to offer)
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
        InputBuffer _buffer;
        InputAction _move, _dodge, _walk, _jump, _light, _heavy, _heavyMod, _block, _lock, _skillMod, _ultimate, _l3, _bomb, _interact, _potion, _bag, _bestiary, _map;
        readonly InputAction[] _skillKeys = new InputAction[4];

        void Awake()
        {
            _motor = GetComponent<PlayerMotor>();
            _combat = GetComponent<PlayerCombat>();
            _defense = GetComponent<PlayerDefense>();
            _lockOn = GetComponent<LockOn>();
            _buffer = new InputBuffer(AscendData.Db.Tuning);
            if (cameraTransform == null && Camera.main != null) cameraTransform = Camera.main.transform;

            _move = new InputAction("Move", InputActionType.Value);
            _move.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s").With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
            _move.AddBinding("<Gamepad>/leftStick");
            _dodge = Button("Dodge", "<Keyboard>/space", "<Gamepad>/buttonEast");
            _walk = Button("Walk", "<Keyboard>/leftAlt");
            _jump = Button("Jump", "<Keyboard>/f", "<Gamepad>/buttonSouth");
            _light = Button("Light", "<Mouse>/leftButton", "<Gamepad>/rightShoulder");
            _heavy = Button("Heavy", "<Gamepad>/rightTrigger");
            _heavy.AddCompositeBinding("OneModifier").With("Modifier", "<Keyboard>/leftShift").With("Binding", "<Mouse>/leftButton");
            _heavyMod = Button("HeavyModifier", "<Keyboard>/leftShift");
            _block = Button("Block", "<Mouse>/rightButton", "<Gamepad>/leftShoulder");
            _lock = Button("LockOn", "<Keyboard>/q", "<Mouse>/middleButton", "<Gamepad>/rightStickPress");
            _skillMod = Button("SkillModifier", "<Gamepad>/leftTrigger");
            _ultimate = Button("Ultimate", "<Keyboard>/x");
            _l3 = Button("L3", "<Gamepad>/leftStickPress");
            _bomb = Button("QuickItem", "<Keyboard>/g", "<Gamepad>/dpad/up");
            _interact = Button("Interact", "<Keyboard>/e", "<Gamepad>/buttonNorth");
            _potion = Button("Potion", "<Keyboard>/r", "<Gamepad>/buttonWest");
            _bag = Button("Bag", "<Keyboard>/i", "<Gamepad>/dpad/right");
            _bestiary = Button("Bestiary", "<Keyboard>/b");
            _map = Button("Map", "<Keyboard>/tab", "<Keyboard>/m", "<Gamepad>/select");
            for (int i = 0; i < 4; i++) _skillKeys[i] = Button($"Skill{i + 1}", $"<Keyboard>/{i + 1}");
        }

        static readonly System.Collections.Generic.HashSet<(string action, string path)> Bound = new System.Collections.Generic.HashSet<(string, string)>();

        /// <summary>Every plain key or button a player action is bound to (no composites); tests check none is used twice.</summary>
        public static System.Collections.Generic.IEnumerable<string> SimpleBindings
        {
            get
            {
                foreach (var b in Bound) yield return b.path;
            }
        }

        static InputAction Button(string name, params string[] bindings)
        {
            foreach (var b in bindings) Bound.Add((name, b));
            var a = new InputAction(name, InputActionType.Button);
            foreach (var b in bindings) a.AddBinding(b);
            return a;
        }

        InputAction[] Actions => new[] { _move, _dodge, _walk, _jump, _light, _heavy, _heavyMod, _block, _lock, _skillMod, _ultimate, _l3, _bomb, _interact, _potion, _bag, _bestiary, _map,
            _skillKeys[0], _skillKeys[1], _skillKeys[2], _skillKeys[3] };

        void OnEnable() { foreach (var a in Actions) a.Enable(); }
        void OnDisable() { foreach (var a in Actions) a.Disable(); }
        void OnDestroy() { foreach (var a in Actions) a.Dispose(); }

        void Update()
        {
            float dt = PlayerDelta;
            Vector3 world = CameraRelative(_move.ReadValue<Vector2>());
            bool attacking = _combat != null && _combat.IsAttacking;
            if (_defense != null && (_defense.IsHeld || _defense.IsDead) || UiModal.Any)
            {
                // Grabbed, fallen or talking: only gravity runs. Drop buffered presses so they cannot fire when this ends.
                _buffer.Clear();
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
            if (_bestiary.WasPressedThisFrame() && !UiModal.Any && TryGetComponent<PlayerBestiary>(out var book)) { BestiaryWindow.Instance.Toggle(book); return; }
            if (_map.WasPressedThisFrame() && !UiModal.Any && TryGetComponent<PlayerMap>(out var map)) { WorldMapWindow.Instance.Toggle(map); return; }
            if (_bag.WasPressedThisFrame() && _combat != null && !NpcDialog.IsOpen) { BagWindow.Instance.Toggle(_combat); return; }
            if (!skillMode && _potion.WasPressedThisFrame() && TryGetComponent<PlayerInventory>(out var inv)) inv.DrinkHealingPotion();
            if (!skillMode && _interact.WasPressedThisFrame())
            {
                var quests = GetComponent<PlayerQuests>();
                var giver = quests != null ? QuestGiver.Nearest(transform.position) : null;
                var node = GatherNode.Nearest(transform.position);
                // Whichever is closer: talk to the NPC or gather the node.
                bool nodeFirst = node != null && (giver == null || Vector3.Distance(node.transform.position, transform.position) < Vector3.Distance(giver.transform.position, transform.position));
                if (nodeFirst && TryGetComponent<PlayerInventory>(out var bag)) { node.Gather(bag); return; }
                if (giver != null) { NpcDialog.Instance.Open(giver, quests); return; }
            }
            bool padFaceBusy = skillMode && pad != null;
            bool ultimateChord = pad != null && pad.leftStickButton.isPressed && pad.rightStickButton.isPressed;

            // A press the current attack refuses is buffered (inputBufferSec) and fires at the first legal moment.
            if (!padFaceBusy && _jump.WasPressedThisFrame() && !TryJump()) _buffer.Press(BufferedAction.Jump);
            if (_jump.WasReleasedThisFrame()) _motor.ReleaseJump();
            if (_lock.WasPressedThisFrame() && !ultimateChord && _lockOn != null) _lockOn.Toggle();
            if (!padFaceBusy && _dodge.WasPressedThisFrame() && !TryDodge(world)) _buffer.Press(BufferedAction.Dodge);
            if (_defense != null)
            {
                _defense.SetBlock(_block.IsPressed(), attacking, dt);
                if (_block.WasPressedThisFrame() && attacking) _buffer.Press(BufferedAction.Block);
            }
            if (_combat != null)
            {
                // Shift + click is the heavy attack, so it is not also a light one.
                bool shiftClick = _heavyMod.IsPressed() && Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
                if (!padFaceBusy && !shiftClick && _light.WasPressedThisFrame()) _combat.Attack();
                if (!padFaceBusy && _heavy.WasPressedThisFrame() && !_combat.BeginHeavy()) _buffer.Press(BufferedAction.Heavy);
                if (_heavy.WasReleasedThisFrame()) _combat.ReleaseHeavy(); // a tap released before the buffered heavy fires still fires (see FireBuffered)
                _combat.Tick(dt);
            }
            _buffer.Tick(dt);
            _buffer.Poll(a => FireBuffered(a, world));
            // Attacks and blocking root the player (the lunge moves them); gravity and dodges still run through the motor.
            bool rooted = (_combat != null && _combat.IsAttacking) || (_defense != null && _defense.IsBlocking);
            bool sprint = _dodge.IsPressed() && !_motor.IsDodging;
            _motor.Tick(rooted ? Vector3.zero : world, _walk.IsPressed(), sprint, dt);
        }

        bool TryJump()
        {
            if (_combat != null && _combat.TryJumpCancel()) return true;
            if (_combat != null && _combat.IsAttacking) return false;
            _motor.Jump();
            return true;
        }

        /// <summary>Dodge if the motor allows it and the current attack permits a cancel (not during startup).</summary>
        bool TryDodge(Vector3 world)
        {
            if (!_motor.CanDodge) return false;
            if (_combat != null && !_combat.TryCancelForDodge()) return false;
            return _motor.Dodge(world);
        }

        bool FireBuffered(BufferedAction a, Vector3 world)
        {
            switch (a)
            {
                case BufferedAction.Dodge: return TryDodge(world);
                case BufferedAction.Jump: return TryJump();
                case BufferedAction.Block:
                    if ((_combat != null && _combat.IsAttacking) || _motor.IsDodging) return false;
                    if (_block.IsPressed() && _defense != null) _defense.StampBufferedBlockPress(); // still held: a real press, just late
                    return true;
                case BufferedAction.Heavy:
                    if (_combat == null || !_combat.BeginHeavy()) return false;
                    if (!_heavy.IsPressed()) _combat.ReleaseHeavy(); // released while it waited: fire it as a tap
                    return true;
            }
            return true;
        }

        /// <summary>The player's time step: 0 in hit-stop, real time during Flash Time, otherwise game time.</summary>
        public static float PlayerDelta => GameTime.Paused || GameTime.HitStopActive ? 0f : GameTime.FlashTimeActive ? Time.unscaledDeltaTime : Time.deltaTime;

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
