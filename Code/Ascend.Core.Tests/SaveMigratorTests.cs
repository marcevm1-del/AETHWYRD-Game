using System;
using System.Collections.Generic;
using System.Linq;
using Ascend.Core;

// The save version manager: a chain of one-version steps, future saves untouched, failures reported not swallowed.
[Tests]
static class SaveMigratorTests
{
    static SaveMigrationStep Step(int from, string name, Action<SaveGame> a = null) =>
        new SaveMigrationStep(from, from + 1, name, a ?? (s => { }));

    public static void TheRealChainHasNoGaps()
    {
        Assert.Equal(SaveGame.CurrentVersion, SaveMigrator.Default.CurrentVersion, "default migrator targets the current version");
        Assert.Equal(0, SaveMigrator.Default.MissingLinks().Count, "every shipped version has a step to the next");
    }

    public static void StepsRunInOrderAndEachOnce()
    {
        var log = new List<string>();
        var m = new SaveMigrator(4, new[] { Step(3, "c", s => log.Add("c")), Step(1, "a", s => log.Add("a")), Step(2, "b", s => log.Add("b")) });
        var save = new SaveGame { Version = 1 };
        var r = m.Migrate(save);
        Assert.True(r.Ok && r.Changed, "ok and changed");
        Assert.Equal("a,b,c", string.Join(",", log), "ordered");
        Assert.Equal(4, save.Version, "stamped to the target");
        Assert.Equal(1, r.FromVersion, "from"); Assert.Equal(4, r.ToVersion, "to");
        var again = m.Migrate(save);
        Assert.True(again.Ok && !again.Changed, "already current: nothing runs");
        Assert.Equal(3, log.Count, "no step ran twice");
    }

    public static void AStartInTheMiddleSkipsEarlierSteps()
    {
        var log = new List<string>();
        var m = new SaveMigrator(3, new[] { Step(1, "a", s => log.Add("a")), Step(2, "b", s => log.Add("b")) });
        m.Migrate(new SaveGame { Version = 2 });
        Assert.Equal("b", string.Join(",", log), "only the step from 2");
    }

    public static void AFutureSaveIsNeverTouched()
    {
        var ran = false;
        var m = new SaveMigrator(2, new[] { Step(1, "a", s => ran = true) });
        var save = new SaveGame { Version = 9, Level = 5 };
        var r = m.Migrate(save);
        Assert.True(r.TooNew && !r.Ok, "flagged too new");
        Assert.Equal(9, save.Version, "version left alone");
        Assert.True(!ran, "no step ran");
    }

    public static void InvalidVersionsAreErrorsNotMigrated()
    {
        var m = new SaveMigrator(2, new[] { Step(1, "a") });
        Assert.True(m.Migrate(new SaveGame { Version = 0 }).Error != null, "version 0");
        Assert.True(m.Migrate(new SaveGame { Version = -1 }).Error != null, "negative");
        Assert.True(m.Migrate(null).Error != null, "null");
    }

    public static void AThrowingStepStopsTheWalkAtTheLastGoodVersion()
    {
        var m = new SaveMigrator(4, new[] { Step(1, "a"), Step(2, "boom", s => throw new InvalidOperationException("bad data")), Step(3, "c") });
        var save = new SaveGame { Version = 1 };
        var r = m.Migrate(save);
        Assert.True(!r.Ok && r.Error.Contains("boom") && r.Error.Contains("bad data"), "error names the step and reason");
        Assert.Equal(2, save.Version, "stays at the last good version, so Validate rejects it");
        Assert.Equal(1, r.Applied.Count, "only step a applied");
    }

    public static void AMissingLinkIsReportedAndStopsTheWalk()
    {
        var m = new SaveMigrator(4, new[] { Step(1, "a"), Step(3, "c") });
        Assert.Equal("2", string.Join(",", m.MissingLinks()), "gap at 2");
        var save = new SaveGame { Version = 1 };
        var r = m.Migrate(save);
        Assert.True(r.Error != null && r.Error.Contains("2"), "error names the version");
        Assert.Equal(2, save.Version, "stops at the gap");
    }

    public static void BadStepsAreRejectedAtConstruction()
    {
        Assert.Throws<ArgumentException>(() => new SaveMigrator(3, new[] { new SaveMigrationStep(1, 3, "skip", s => { }) }), "jump of two");
        Assert.Throws<ArgumentException>(() => new SaveMigrator(2, new[] { Step(2, "past") }), "past current");
        Assert.Throws<ArgumentException>(() => new SaveMigrator(3, new[] { Step(1, "a"), Step(1, "dup") }), "duplicate");
    }

    public static void UpgradeLeavesAFailedMigrationInvalid()
    {
        // Validate must reject a save stuck below the current version, so a half-migrated save is never played or overwritten.
        var stuck = new SaveGame { Version = SaveGame.CurrentVersion };
        Assert.Equal(0, SaveRules.Validate(stuck).Count, "current is valid");
        if (SaveGame.CurrentVersion > 1)
            Assert.True(SaveRules.Validate(new SaveGame { Version = SaveGame.CurrentVersion - 1 }).Count > 0, "un-upgraded older save is invalid");
        Assert.True(SaveRules.Upgrade(new SaveGame { Version = 1 }) != null && SaveRules.LastMigration != null, "LastMigration is recorded");
    }

    public static void PeekVersionReadsRawJson()
    {
        Assert.Equal(7, SaveMigrator.PeekVersion("{\"Level\":2, \"Version\" : 7}").Value, "found");
        Assert.True(SaveMigrator.PeekVersion("{\"Level\":2}") == null, "absent");
        Assert.True(SaveMigrator.PeekVersion("") == null && SaveMigrator.PeekVersion(null) == null, "empty");
    }

    public static void BackupNamesAreSafeAndCarryTheVersion()
    {
        Assert.Equal("slot0.v1.bak.json", SaveMigrator.BackupName("slot0", 1), "plain");
        Assert.Equal("slot0.v3.bak.json", SaveMigrator.BackupName("..\\slot0/", 3), "path characters dropped");
        Assert.Equal("slot.v2.bak.json", SaveMigrator.BackupName(null, 2), "null slot");
    }
}
