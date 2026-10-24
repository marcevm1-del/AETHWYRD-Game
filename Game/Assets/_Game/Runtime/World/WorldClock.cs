using Ascend.Core;
using UnityEngine;

namespace Ascend.Game
{
    /// <summary>
    /// The day clock (world_tuning.json calendar: a 24-hour day in 90 minutes of play, seven named weekdays). It runs on
    /// game time, so hit-stop pauses it, and drives the sun: up at dawn (06:00), high at noon, down at 18:00, then a dim
    /// blue moonlight. Sleeping at an inn jumps it to the next dawn. New games start at 08:00 on Solenday.
    /// </summary>
    public sealed class WorldClock : MonoBehaviour
    {
        public const double StartHour = 8;

        [SerializeField] Light sun;
        [SerializeField] float sunYaw = -35f;

        GameCalendar _cal;

        public static WorldClock Instance { get; private set; }
        /// <summary>Play seconds since the first morning (the saved value).</summary>
        public double PlaySeconds { get; set; }
        public int Day => _cal.FromPlaySeconds(PlaySeconds).day;
        public double Hour => _cal.FromPlaySeconds(PlaySeconds).hour;
        public DayPart Part => _cal.PartOf(Hour);
        public string Weekday => _cal.Weekday(Day);
        public GameCalendar Calendar => _cal;
        public Light Sun { get => sun; set => sun = value; }

        public string Text
        {
            get
            {
                double h = Hour;
                int hh = (int)h, mm = (int)((h - hh) * 60);
                return $"{Weekday} (day {Day + 1}) · {hh:00}:{mm:00} · {Part}";
            }
        }

        void Awake()
        {
            Instance = this;
            _cal = new GameCalendar(AscendData.Db.World.Calendar);
            PlaySeconds = StartHour * _cal.SecondsPerHour;
            if (sun == null) sun = FindFirstObjectByType<Light>();
            ApplyLight();
        }

        void OnDestroy() { if (Instance == this) Instance = null; }

        void Update()
        {
            PlaySeconds += Time.deltaTime;
            ApplyLight();
        }

        /// <summary>Moves the clock forward (sleep, waiting).</summary>
        public void Advance(double hours)
        {
            PlaySeconds += System.Math.Max(0, hours) * _cal.SecondsPerHour;
            ApplyLight();
        }

        /// <summary>Sleeps to the next dawn; returns the hours slept.</summary>
        public double SleepUntilDawn()
        {
            double hours = _cal.HoursUntilDawn(Hour);
            Advance(hours);
            return hours;
        }

        void ApplyLight()
        {
            if (sun == null) return;
            float h = (float)Hour;
            // Sun elevation: 0° at 06:00, 90° at noon, 180° at 18:00; below the horizon at night (lit as moonlight).
            float elevation = (h - 6f) / 12f * 180f;
            bool day = h >= 6f && h < 18f;
            float noon = day ? Mathf.Sin((h - 6f) / 12f * Mathf.PI) : 0f;           // 0 at the horizon, 1 at noon
            if (day) sun.transform.rotation = Quaternion.Euler(Mathf.Clamp(elevation, 4f, 176f), sunYaw, 0f);
            else sun.transform.rotation = Quaternion.Euler(50f, sunYaw + 180f, 0f);  // moon high in the opposite sky
            float warm = 1f - Mathf.Clamp01(noon * 1.6f);                              // golden near dawn and dusk
            sun.color = day ? Color.Lerp(new Color(1f, 0.95f, 0.86f), new Color(1f, 0.62f, 0.38f), warm) : new Color(0.55f, 0.65f, 1f);
            sun.intensity = day ? Mathf.Lerp(0.5f, 1.6f, Mathf.Clamp01(noon * 1.4f)) : 0.25f;
            float amb = day ? Mathf.Lerp(0.45f, 1f, noon) : 0.22f;
            RenderSettings.ambientSkyColor = new Color(0.62f, 0.74f, 0.95f) * amb;
            RenderSettings.ambientEquatorColor = new Color(0.62f, 0.66f, 0.62f) * amb;
            RenderSettings.ambientGroundColor = new Color(0.35f, 0.32f, 0.28f) * amb;
        }
    }
}
