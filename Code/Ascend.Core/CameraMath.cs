using System;

namespace Ascend.Core
{
    /// <summary>
    /// Engine-agnostic maths for the over-the-shoulder camera and mouse lock-on (combat.md section 2): frame-rate independent
    /// damping, asymmetric collision easing, a yaw clamp and a deliberate-flick detector. Unity code only feeds it numbers.
    /// </summary>
    public static class CameraMath
    {
        /// <summary>Fraction of the remaining gap closed this frame for a lag of <paramref name="lagSec"/> (time to ~63%). 0 or less snaps.</summary>
        public static double DampFactor(double lagSec, double dt) => lagSec <= 1e-6 ? 1.0 : (dt <= 0 ? 0.0 : 1.0 - Math.Exp(-dt / lagSec));

        public static double Damp(double current, double target, double lagSec, double dt) => current + (target - current) * DampFactor(lagSec, dt);

        public static double WrapDeg(double a) { a %= 360.0; if (a > 180) a -= 360; else if (a <= -180) a += 360; return a; }

        /// <summary>Damps an angle in degrees along the shortest way round.</summary>
        public static double DampAngle(double currentDeg, double targetDeg, double lagSec, double dt) =>
            currentDeg + WrapDeg(targetDeg - currentDeg) * DampFactor(lagSec, dt);

        /// <summary>Collision distance easing: pulls in fast (<paramref name="inLagSec"/>) when the wanted distance is shorter, eases out slowly otherwise.</summary>
        public static double DampDistance(double current, double wanted, double inLagSec, double outLagSec, double dt) =>
            Damp(current, wanted, wanted < current ? inLagSec : outLagSec, dt);

        /// <summary>Clamps a mouse yaw offset around the lock-on framing.</summary>
        public static double ClampYawOffset(double offsetDeg, double rangeDeg) => Math.Max(-rangeDeg, Math.Min(rangeDeg, offsetDeg));

        /// <summary>Camera distance wanted for the number of monsters engaged: the pull-back distance at or above <paramref name="minEngaged"/>, else the base.</summary>
        public static double GroupDistance(int engaged, int minEngaged, double baseDistance, double pullBackDistance) =>
            engaged >= minEngaged ? Math.Max(baseDistance, pullBackDistance) : baseDistance;
    }

    /// <summary>
    /// Decides when a mouse movement is a deliberate flick that switches lock-on target: the frame's speed must reach a velocity
    /// threshold and its size a deadzone, and a cooldown follows every switch. Slow aiming never switches.
    /// </summary>
    public sealed class FlickDetector
    {
        public double VelocityThresholdPxPerSec, DeadzonePx, CooldownSec;
        double _cool;

        public FlickDetector(double velocityThresholdPxPerSec, double deadzonePx, double cooldownSec)
        { VelocityThresholdPxPerSec = velocityThresholdPxPerSec; DeadzonePx = deadzonePx; CooldownSec = cooldownSec; }

        public bool CoolingDown => _cool > 0;

        /// <summary>Feeds one frame of horizontal mouse delta (pixels) over dt seconds. Returns -1 (left), +1 (right) or 0.</summary>
        public int Feed(double dxPx, double dt)
        {
            if (_cool > 0) { _cool -= dt; return 0; }
            if (dt <= 0 || Math.Abs(dxPx) < DeadzonePx) return 0;
            if (Math.Abs(dxPx) / dt < VelocityThresholdPxPerSec) return 0;
            _cool = CooldownSec;
            return dxPx > 0 ? 1 : -1;
        }

        /// <summary>Starts the cooldown without a flick (the stick switched, or the lock changed).</summary>
        public void Arm() => _cool = CooldownSec;
    }
}
