using System.Globalization;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace Ascend.Game.Tests
{
    /// <summary>The game must work on comma-decimal systems (the creative director's PC uses one).</summary>
    public sealed class LocalePlayModeTests
    {
        [Test]
        public void CameraLookBindingsSurviveACommaDecimalLocale()
        {
            var old = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            var go = new GameObject("TestCamera");
            try
            {
                go.AddComponent<Camera>();
                var cam = go.AddComponent<ThirdPersonCamera>();
                string p = cam.LookProcessors;
                StringAssert.Contains("x=0.12", p, "decimal point, not comma");
                StringAssert.DoesNotContain("0,12", p, "no locale comma in processor strings");
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = old;
                Object.DestroyImmediate(go);
            }
        }
    }
}
