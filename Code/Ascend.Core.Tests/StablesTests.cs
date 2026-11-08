using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Stables, feeding, breeding, egg nests, the sanctuary and ground mounts on the REAL data
// (Data/Companions/stables.json, mounts.json, housing.json, species and the taming tuning).
[Tests]
static class StablesTests
{
    static TamingTuning T => Repo.Db.World.Taming;

    static Home HomeAt(string tierId)
    {
        var h = new Home(Repo.Db.Housing, Repo.Db.Crops, Repo.Db.Quality, null);
        var inv = new Inventory();
        if (tierId == Repo.Db.Housing.Tiers[0].Id) return h;
        foreach (var t in Repo.Db.Housing.Tiers.Skip(1))
        {
            inv.AddCopper(t.Cost);
            h.Upgrade(t.Id, "SSS", inv);
            if (t.Id == tierId) break;
        }
        return h;
    }

    static (Stables st, PartnerRoster roster) Make(string tier)
    {
        var roster = new PartnerRoster(T);
        var mounts = Repo.Load<MountTable>("Data/Companions/mounts.json");
        return (new Stables(Repo.Db.Stables, roster, T, HomeAt(tier), Repo.Db.Species, mounts), roster);
    }

    static PartnerData Tame(PartnerRoster r, string species, int bond = 5)
    {
        var p = r.Add(species, species);
        p.Bond = bond;
        return p;
    }

    public static void TheRulesFollowTheHomeTiers()
    {
        Assert.Equal(0, Make("inn_room").st.Capacity, "no stable in an inn room");
        Assert.Equal(0, Make("rented_room").st.Capacity, "none in a rented room either");
        Assert.Equal(6, Make("home_plot").st.Capacity, "six stalls at Home and Garden");
        Assert.Equal(12, Make("manor").st.Capacity, "twelve at the Manor");
    }

    // --- roster rules ---
    public static void BoardingNeedsRoomButTamingIsNeverRefused()
    {
        var (st, r) = Make("home_plot");
        var ps = Enumerable.Range(0, 10).Select(i => Tame(r, "mon_forest_wolf")).ToList();
        Assert.Equal(10, r.All.Count, "ten tamed partners are all kept (the kennel has no limit)");
        Assert.Equal(3, r.Active.Count(), "three travel");
        int boarded = 0, full = 0;
        foreach (var p in ps) { var res = st.Board(p); if (res == BoardResult.Ok) boarded++; else if (res == BoardResult.Full) full++; }
        Assert.Equal(6, boarded, "six boarded");
        Assert.Equal(4, full, "the other four are told the stable is full");
        Assert.Equal(0, ps.Count(p => p.Active && p.AtHome), "no partner is travelling and boarded at once");
        Assert.Equal(10, r.All.Count, "nobody was lost");
        Assert.True(st.Kenneled(ps[0]) && !ps[0].AtHome && !ps[0].Active, "to the kennel");
        Assert.True(!st.Activate(ps[5]) || r.Active.Count() <= 3, "never more than three travelling");
    }

    public static void NoStableMeansTheKennel()
    {
        var (st, r) = Make("rented_room");
        var p = Tame(r, "mon_forest_wolf");
        p.Active = false;
        Assert.True(st.Board(p) == BoardResult.NoStable, "no barn yet");
        Assert.Equal(1, st.Kennel.Count(), "it waits in the guild kennel");
        Assert.True(st.Board(null) == BoardResult.NotYours, "not yours");
    }

    // --- feeding ---
    public static void FeedingIsAnOptionalTreatWithNoPunishment()
    {
        var (st, r) = Make("home_plot");
        var p = Tame(r, "mon_forest_wolf", 2); // Beasts like prime meat
        string food = st.FavouriteOf(p);
        Assert.True(food != null, "the Beasts family has a favourite food");
        var inv = new Inventory(); inv.Add(food, 5); inv.Add("itm_minor_hp_potion");
        Assert.True(st.Feed(p, "itm_minor_hp_potion", inv, 0) == FeedResult.NotFavouriteFood && inv.Count("itm_minor_hp_potion") == 1, "other items are not taken");
        int before = p.Assists + p.Bond * T.BondPerAssists;
        Assert.True(st.Feed(p, food, inv, 100) == FeedResult.Ok, "fed");
        Assert.Equal(before + 1, p.Assists + p.Bond * T.BondPerAssists, "one shared moment");
        Assert.True(st.Feed(p, food, inv, 110) == FeedResult.TooSoon && inv.Count(food) == 4, "too soon: the treat is kept");
        Assert.True(st.Feed(p, food, inv, 125) == FeedResult.Ok, "a day later");
        // Months away change nothing: no needs, no loss, no penalty, and the next treat still works.
        int bond = p.Bond;
        Assert.True(st.Feed(p, food, inv, 125 + 24 * 500) == FeedResult.Ok && p.Bond >= bond, "absence is never punished");
        p.Bond = T.MaxBond;
        Assert.True(st.Feed(p, food, inv, 999999) == FeedResult.MaxBond && inv.Count(food) == 2, "at max Bond the treat is kept");
    }

    // --- mounts ---
    public static void OnlyGroundMountSpeciesCanBeChosenAsMounts()
    {
        var (st, r) = Make("home_plot");
        var wolf = Tame(r, "mon_forest_wolf"); var slime = Tame(r, "mon_blue_slime");
        Assert.True(st.SetMount(slime, "SSS") == MountResult.NotMountable, "a slime is not a mount");
        Assert.True(st.SetMount(wolf, "F") == MountResult.RankTooLow, "wolves need rank E");
        Assert.True(st.SetMount(wolf, "E") == MountResult.Ok && st.Mount == wolf, "a wolf at rank E");
        st.ClearMount();
        Assert.True(st.Mount == null, "cleared");
        var table = Repo.Load<MountTable>("Data/Companions/mounts.json");
        foreach (var f in table.Families.Values)
            foreach (var id in f.Species)
                Assert.True(!Repo.Db.Species[id].Type.Contains("Dragon") && !Repo.Db.Species[id].Type.Contains("Avian") && !Repo.Db.Species[id].Type.Contains("Aquatic"), id + " is no flying or aquatic mount");
    }

    // --- sanctuary ---
    public static void TheSanctuaryGrowsWithEverySpeciesYouKnowAndNeverShrinks()
    {
        var (st, r) = Make("home_plot");
        Assert.Equal("Paddock", st.Sanctuary.Name, "starts as a paddock");
        var species = Repo.Db.Species.Values.Where(s => !s.IsUnique && !s.IsTyrant).Take(16).Select(s => s.Id).ToList();
        foreach (var id in species.Take(5)) Tame(r, id);
        Assert.Equal("Meadow Run", st.Sanctuary.Name, "five species");
        foreach (var id in species.Skip(5)) st.NoteSpecies(id);
        Assert.Equal("Grove Sanctuary", st.Sanctuary.Name, "sixteen species");
        foreach (var p in r.All.ToList()) st.Release(p);
        Assert.Equal("Grove Sanctuary", st.Sanctuary.Name, "releasing a partner never shrinks the sanctuary");
    }

    // --- breeding ---
    static (Stables st, PartnerRoster r, PartnerData a, PartnerData b) Pair(string sa, string sb)
    {
        var (st, r) = Make("home_plot");
        var a = Tame(r, sa); var b = Tame(r, sb);
        st.Board(a); st.Board(b);
        return (st, r, a, b);
    }

    public static void BreedingFollowsTheRanchRulesInCanon()
    {
        var (st, r, a, b) = Pair("mon_forest_wolf", "mon_forest_wolf");
        Assert.True(st.Breed(a, a, 0, 1).Result == BreedResult.SameCreature, "one partner is not a pair");
        a.Bond = 2;
        Assert.True(st.Breed(a, b, 0, 1).Result == BreedResult.BondTooLow, "needs Bond 3");
        a.Bond = 5;
        var rep = st.Breed(a, b, 0, 1);
        Assert.True(rep.Result == BreedResult.Ok && rep.Egg.SpeciesId == "mon_forest_wolf", "an egg of the same species");
        Assert.True(st.Breed(a, b, 10, 1).Result == BreedResult.PairResting, "the pair rests 72 hours");
        Assert.True(!st.Ready(rep.Egg, 47.9) && st.Ready(rep.Egg, 48), "ready after 48 in-game hours");
        Assert.True(st.Hatch(rep.Egg.Id, 10, null, out _) == HatchResult.NotReady, "not yet");
        Assert.True(st.Hatch(rep.Egg.Id, 24 * 3000, "Pup", out var baby) == HatchResult.Ok, "an egg waits forever");
        Assert.Equal(3, baby.Bond, "hatchlings start at Bond 3");
        Assert.True(!baby.Active, "a hatchling never auto-joins the party");
        Assert.Equal("Pup", baby.Name, "named");
        Assert.True(st.Breed(a, b, 72, 1).Result == BreedResult.Ok, "the pair can breed again after 72 hours");
        var (st2, r2, c, d) = Pair("mon_forest_wolf", "mon_dire_wolf");
        Assert.True(st2.Breed(c, d, 0, 1).Result == BreedResult.NotCompatible, "wolf and dire wolf are different trees here");
        var kennel = r2.Add("mon_forest_wolf", "k"); kennel.Bond = 5; kennel.Active = false;
        Assert.True(st2.Breed(c, kennel, 0, 1).Result == BreedResult.NotBoarded, "both must be boarded");
    }

    public static void EggsAreCappedButNeverLost()
    {
        var (st, r, a, b) = Pair("mon_forest_wolf", "mon_forest_wolf");
        Assert.Equal(3, st.EggCapacity, "six stalls hold three eggs");
        var c = Tame(r, "mon_forest_wolf"); var d = Tame(r, "mon_forest_wolf"); var e = Tame(r, "mon_forest_wolf");
        st.Board(c); st.Board(d); st.Board(e);
        Assert.True(st.Breed(a, b, 0, 1).Result == BreedResult.Ok, "egg 1");
        Assert.True(st.Breed(c, d, 0, 1).Result == BreedResult.Ok, "egg 2");
        Assert.True(st.Breed(a, e, 0, 1).Result == BreedResult.Ok, "egg 3");
        Assert.True(st.Breed(b, e, 0, 1).Result == BreedResult.EggsFull, "a fourth egg is refused");
        Assert.True(st.AddNestEgg("mon_forest_wolf", 0, 1) == null, "the nest egg stays in the nest when you are full");
        Assert.Equal(3, st.Eggs.Count, "no egg was lost or made");
    }

    public static void CrossElementHatchlingsAreRareButGuaranteedByPity()
    {
        var (st, r, a, b) = Pair("mon_tide_arachne", "mon_frost_arachne");
        Assert.True(st.Breed(a, b, 0, 5).Result == BreedResult.Ok, "breed 1");
        var cross = new List<bool>();
        for (int n = 1; n <= 8; n++)
        {
            foreach (var e in st.Eggs.ToList()) st.Hatch(e.Id, 1e6, null, out _);
            var rep = st.Breed(a, b, n * 100, 5);
            Assert.True(rep.Result == BreedResult.Ok, "breed " + (n + 1));
            cross.Add(rep.CrossElement);
        }
        Assert.True(cross.Any(x => x), "within the pity run a cross-element hatchling arrives");
        Assert.True(cross.Count(x => x) < cross.Count, "but not every egg is one");
        foreach (var e in st.Eggs) Assert.True(new[] { "mon_tide_arachne", "mon_frost_arachne", "mon_arachne" }.Contains(e.SpeciesId), "eggs stay within the family tree");
    }

    public static void MarkingsPassDownAndNestEggsGuaranteeOneEventually()
    {
        var (st, r, a, b) = Pair("mon_forest_wolf", "mon_forest_wolf");
        a.Marking = "Albino"; b.Marking = "Albino";
        int marked = 0;
        for (int n = 0; n < 12; n++)
        {
            var rep = st.Breed(a, b, n * 100, (ulong)n);
            if (rep.Result == BreedResult.Ok) { if (rep.Egg.Marking == "Albino") marked++; st.Hatch(rep.Egg.Id, 1e7, null, out var baby); r.Release(baby); }
        }
        Assert.True(marked > 0 && marked < 12, "the marking is inherited about half the time");

        var (s2, r2) = Make("manor");
        var nest = new List<EggSave>();
        for (int n = 0; n < 5; n++) { var e = s2.AddNestEgg("mon_forest_wolf", 0, (ulong)n); Assert.True(e != null, "nest egg " + n); nest.Add(e); s2.Hatch(e.Id, 1e6, null, out var h); r2.Release(h); }
        Assert.True(nest.Any(e => e.Marking != null), "five plain nest eggs in a row cannot happen: the fifth carries a marking");
        Assert.True(s2.MarkingsCollected >= 1, "the marking collection records it");
    }

    public static void BreedingIsDeterministic()
    {
        string Run()
        {
            var (st, r, a, b) = Pair("mon_tide_arachne", "mon_frost_arachne");
            var sb = new System.Text.StringBuilder();
            for (int n = 0; n < 6; n++) { var rep = st.Breed(a, b, n * 100, 99); sb.Append(rep.Egg?.SpeciesId).Append(rep.Egg?.Marking).Append(';'); foreach (var e in st.Eggs.ToList()) { st.Hatch(e.Id, 1e7, null, out var h); r.Release(h); } }
            return sb.ToString();
        }
        Assert.Equal(Run(), Run(), "same seed, same eggs");
    }

    public static void UniquesAndTyrantsCannotBreed()
    {
        var u = Repo.Db.Species.Values.First(s => s.IsUnique);
        var (st, r) = Make("home_plot");
        var a = Tame(r, u.Id); var b = Tame(r, u.Id);
        st.Board(a); st.Board(b);
        Assert.True(st.Breed(a, b, 0, 1).Result == BreedResult.NotCompatible, "a unique is one of a kind");
    }

    // --- saves ---
    public static void StablesSurviveASaveAndOldSavesLoad()
    {
        var (st, r, a, b) = Pair("mon_forest_wolf", "mon_forest_wolf");
        st.Breed(a, b, 0, 3);
        st.SetMount(a, "E");
        var save = new SaveGame { Partners = r.All.ToList(), Stables = st.Save() };
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(JsonSerializer.Serialize(save)));
        var r2 = new PartnerRoster(T); r2.Load(back.Partners);
        var st2 = new Stables(Repo.Db.Stables, r2, T, HomeAt("home_plot"), Repo.Db.Species, Repo.Load<MountTable>("Data/Companions/mounts.json"));
        st2.Load(back.Stables);
        Assert.Equal(1, st2.Eggs.Count, "the egg");
        Assert.Equal(2, st2.Boarded.Count(), "both boarded");
        Assert.Equal(a.Id, st2.Mount?.Id, "the mount");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Partners\":[{\"SpeciesId\":\"mon_forest_wolf\",\"Name\":\"Old\",\"Active\":true,\"Bond\":4}]}"));
        var r3 = new PartnerRoster(T); r3.Load(old.Partners);
        Assert.True(r3.All[0].Id != null && r3.All[0].Active && r3.All[0].Bond == 4, "old partners get an id and keep everything");
        var st3 = new Stables(Repo.Db.Stables, r3, T, HomeAt("inn_room"), Repo.Db.Species);
        st3.Load(old.Stables); st3.Load(null);
        Assert.True(st3.Eggs.Count == 0 && SaveRules.Validate(old).Count == 0, "an old save is fine");
    }

    public static void IdsEggsAndCooldownsStayConsistent()
    {
        var r = new PartnerRoster(T);
        r.Load(new List<PartnerData> { new PartnerData { SpeciesId = "mon_forest_wolf" }, new PartnerData { Id = "ptn_001", SpeciesId = "mon_forest_wolf" }, new PartnerData { Id = "ptn_001", SpeciesId = "mon_forest_wolf" } });
        Assert.Equal(3, r.All.Select(p => p.Id).Distinct().Count(), "three distinct ids");
        Assert.Equal("ptn_001", r.All[1].Id, "the saved id is kept, the id-less partner takes another");

        var (st, r2) = Make("manor");
        var old = Tame(r2, "mon_forest_wolf"); string oldId = old.Id;
        st.SetMount(old, "E");
        r2.Release(old); // a release that bypasses Stables
        var fresh = Tame(r2, "mon_blue_slime");
        Assert.Equal(oldId, fresh.Id, "ids are reused");
        Assert.True(st.Mount == null, "a stale mount id never makes a slime the mount");

        var s2 = new Stables(Repo.Db.Stables, r2, T, HomeAt("manor"), Repo.Db.Species);
        s2.Load(new StablesSave { NextEgg = 1, Eggs = new List<EggSave> { new EggSave { Id = "egg_007", SpeciesId = "mon_forest_wolf" } } });
        var egg = s2.AddNestEgg("mon_forest_wolf", 0, 1);
        Assert.True(egg != null && egg.Id != "egg_007" && s2.Eggs.Select(e => e.Id).Distinct().Count() == 2, "a new egg never reuses an id");

        var (st3, r3) = Make("home_plot");
        var p = Tame(r3, "mon_forest_wolf"); string food = st3.FavouriteOf(p);
        var inv = new Inventory(); inv.Add(food, 3);
        st3.Feed(p, food, inv, 100);
        st3.Release(p);
        var q = Tame(r3, "mon_forest_wolf"); inv.Add(food, 0);
        Assert.True(st3.Feed(q, food, inv, 101) == FeedResult.Ok, "the newcomer does not inherit the old cooldown");
    }

    public static void ASmallerHomeNeverReleasesAnyone()
    {
        var (st, r) = Make("inn_room");
        var p = Tame(r, "mon_forest_wolf"); p.Active = false; p.AtHome = true;
        st.Reconcile();
        Assert.True(!p.AtHome && r.All.Contains(p), "moved to the kennel, still yours");
    }
}
