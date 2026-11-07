using System.Linq;
using Ascend.Core;

// Wave D review fixes: each test is the failing scenario the code review described.
[Tests]
static class WaveDFixTests
{
    static MusicMachine Make(MusicPrefs p = null) => new MusicMachine(AudioData.Music(), AudioData.Roster(), p);
    static MusicInput Fight(int threat = 2) => new MusicInput { InCombat = true, ThreatLevel = threat, Region = "reg_a" };

    public static void VictoryCountsEvenWhileTheCombatFlagIsStillOnThatTick()
    {
        var m = Make(); m.Update(0.5, Fight()); m.Update(9, Fight());
        var i = Fight(); i.Outcome = CombatOutcome.Victory;
        var f = m.Update(0.5, i);
        Assert.Equal("aftermath", f.StateId, "victory resolves even if InCombat has not cleared yet");
        Assert.True(f.Stingers.Contains("mus_stinger_victory"), "stinger fired");
    }

    public static void BossLayersHoldWhileTheBossStateLingers()
    {
        var m = Make(); var i = Fight(4); i.BossPhase = 3;
        m.Update(0.5, i); m.Update(0.5, i);
        var calm = new MusicInput { Region = "reg_a" };
        var f = m.Update(1, calm);
        Assert.Equal("boss", f.StateId, "boss lingers during its exit delay");
        Assert.Equal(3, f.BossPhase, "frame still reports the phase");
        Assert.Near(1.0, f.Layers["rock_lead"], 1e-9, "rock stem does not collapse early");
    }

    public static void TurningCombatMusicOffMidFightAppliesAtOnce()
    {
        var m = Make(); m.Update(0.5, Fight()); m.Update(1, Fight());
        m.Prefs.NoCombatMusic = true;
        Assert.Equal("explore", m.Update(0.5, Fight()).StateId, "no 8 s hold when the player switches combat music off");
    }

    public static void RockStemInAnOverlayIsRejected()
    {
        var f = AudioData.Music(); f.Overlays.Danger.Layers["rock_lead"] = 1;
        Assert.True(MusicRules.Validate(f, AudioData.Roster()).Any(e => e.Contains("overlay")), "overlay rock caught");
        f = AudioData.Music(); f.States.RemoveAll(s => s.Id == "dungeon");
        Assert.True(MusicRules.Validate(f, AudioData.Roster()).Any(e => e.Contains("missing state dungeon")), "dungeon is required");
    }

    public static void DangerDoesNotCarryIntoAFightFromTheHysteresisBand()
    {
        var m = Make();
        var calm = new MusicInput { Region = "reg_a", PlayerHpFraction = 0.2 };
        m.Update(0.5, calm);
        var i = Fight(); i.PlayerHpFraction = 0.4;
        Assert.True(!m.Update(0.5, i).Layers.ContainsKey("bass_weight"), "a fight begun at 40% HP is not in danger");
    }

    public static void ARetreatThatFailsDoesNotLengthenTheNextExit()
    {
        var m = Make(); m.Update(0.5, Fight()); m.Update(9, Fight());
        var r = Fight(); r.Outcome = CombatOutcome.Retreat; m.Update(0.5, r);
        m.Update(0.5, Fight()); // the fight resumed
        int n = 0; var calm = new MusicInput { Region = "reg_a" };
        while (m.CurrentState == "combat" && n < 100) { m.Update(1, calm); n++; }
        Assert.True(n < 12, $"a plain exit after a failed retreat takes the normal delay (took {n}s)");
    }

    public static void EnvironmentNeedsTheOverrideSurfaces()
    {
        var f = AudioData.Env(); f.Surfaces.RemoveAll(s => s.Id == "cobble");
        Assert.True(EnvironmentRules.Validate(f).Any(e => e.Contains("cobble")), "cobble required");
    }

    public static void PhotoSessionClosesItselfWhenTheWorldTurnsHostile()
    {
        var s = PhotoSession.Open(AudioData.Photo(), new EnvironmentAudio(AudioData.Env()), new PhotoWorldState { Hour = 9 }, out _);
        s.SetHour(3);
        Assert.True(s.Update(new PhotoWorldState { Hour = 9 }), "calm world keeps it open");
        Assert.True(!s.Update(new PhotoWorldState { Hour = 9, InCombat = true }) && !s.IsOpen && !s.HasOverrides, "combat closes it and drops the overrides");
    }

    public static void PhotoValidationRequiresTheTeenGuardTags()
    {
        var f = AudioData.Photo(); f.BlockedTags.Remove("undress");
        Assert.True(PhotoRules.Validate(f, new[] { "clear" }).Any(e => e.Contains("undress")), "guard list must keep its core tags");
        f = AudioData.Photo(); f.Poses[0].Tags.Add("Suggestive");
        Assert.True(PhotoRules.Validate(f, new[] { "clear" }).Any(e => e.Contains("Suggestive")), "tag match ignores case");
    }
}
