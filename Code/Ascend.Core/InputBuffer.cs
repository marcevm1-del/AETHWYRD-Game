using System;

namespace Ascend.Core
{
    /// <summary>
    /// Actions that can be buffered while an attack blocks them (combat.md §1: never stuck in an animation you didn't choose).
    /// Declaration order is the firing priority when several are buffered: defence first, then movement, then offence.
    /// Light attacks are buffered by <see cref="AttackChain"/> itself.
    /// </summary>
    public enum BufferedAction { Dodge = 0, Block = 1, Jump = 2, Heavy = 3 }

    /// <summary>
    /// Remembers presses that could not fire yet for `inputBufferSec`, then fires them at the first legal moment.
    /// Engine-free: the game calls Press on a press edge that was refused, Tick with the player's time step, and Poll
    /// each frame with a callback that attempts the action and says whether it fired.
    /// </summary>
    public sealed class InputBuffer
    {
        static readonly int Count = Enum.GetValues(typeof(BufferedAction)).Length;
        readonly double _windowSec;
        readonly double[] _left = new double[Count];

        public InputBuffer(CombatTuning tuning) : this((tuning ?? throw new ArgumentNullException(nameof(tuning))).InputBufferSec) { }
        public InputBuffer(double windowSec) { _windowSec = Math.Max(0, windowSec); }

        public double WindowSec => _windowSec;

        public void Press(BufferedAction action) => _left[(int)action] = _windowSec;
        public bool IsBuffered(BufferedAction action) => _left[(int)action] > 0;
        public void Clear() { for (int i = 0; i < _left.Length; i++) _left[i] = 0; }
        public void Clear(BufferedAction action) => _left[(int)action] = 0;

        /// <summary>Advances time; presses older than the window expire.</summary>
        public void Tick(double dt)
        {
            for (int i = 0; i < _left.Length; i++) if (_left[i] > 0) _left[i] = Math.Max(0, _left[i] - dt);
        }

        /// <summary>
        /// Offers buffered actions to <paramref name="tryFire"/> in priority order. The first one it accepts (returns true)
        /// is consumed and returned; refused ones stay buffered until they expire. At most one action fires per call.
        /// </summary>
        public BufferedAction? Poll(Func<BufferedAction, bool> tryFire)
        {
            for (int i = 0; i < _left.Length; i++)
            {
                if (_left[i] <= 0) continue;
                var a = (BufferedAction)i;
                if (!tryFire(a)) continue;
                _left[i] = 0;
                return a;
            }
            return null;
        }
    }
}
