using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Crafting on the REAL data (Data/Items/recipes.json, crafting_rules.json, life_skills.json, items and NPCs).
// The inline-fixture suites (QualityTests, LifeSkillTests, MealTests) prove the rules; these prove every shipped recipe obeys them.
[Tests]
static class RealCraftingTests
{
    static readonly string[] MealSkills = { "cooking", "brewing" };

    static IEnumerable<RecipeData> All => Repo.Db.Recipes.Recipes;
    static LifeSkills Ranked(string skill, string rank)
    {
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var s = new LifeSkillSave();
        s.Rank[skill] = rank;
        ls.Load(s);
        return ls;
    }

    /// <summary>A crafter that knows every recipe, with the recipe skill at the given rank.</summary>
    static Crafter Knowing(string skill, string rank)
    {
        var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, Ranked(skill, rank));
        c.Load(All.Select(r => r.Id));
        return c;
    }

    /// <summary>The NPC whose bench the recipe needs (null for the portable campfire).</summary>
    static string Owner(RecipeData r) => Repo.Db.Recipes.Stations[r.Station];

    static Inventory Ample(RecipeData r, string tier = null, int each = 20)
    {
        var inv = new Inventory();
        foreach (var i in r.Inputs) inv.Add(ItemQuality.Compose(i.ItemId, tier), each);
        return inv;
    }

    static int UnitsOf(Inventory inv, string itemId) => inv.Items.Where(kv => ItemQuality.BaseId(kv.Key) == itemId).Sum(kv => kv.Value);

    static int Idx(string tier) => Repo.Db.Quality.IndexOf(tier);

    static Dictionary<string, int> Snap(Inventory inv) => inv.Items.ToDictionary(kv => kv.Key, kv => kv.Value);

    static bool Same(Dictionary<string, int> a, Inventory inv)
    {
        var b = Snap(inv);
        return a.Count == b.Count && a.All(kv => b.TryGetValue(kv.Key, out var n) && n == kv.Value);
    }

    static string Bad(List<string> list) => string.Join("; ", list);

    // 0: the data shape the other tests lean on.
    public static void ThereAreThirtyTwoRecipesAndEveryReferenceResolves()
    {
        Assert.Equal(32, All.Count(), "recipe count");
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var bad = new List<string>();
        foreach (var r in All)
        {
            if (!Repo.Db.Items.ContainsKey(r.Output.ItemId)) bad.Add(r.Id + " output " + r.Output.ItemId);
            foreach (var i in r.Inputs) if (!Repo.Db.Items.ContainsKey(i.ItemId)) bad.Add(r.Id + " input " + i.ItemId);
            if (!ls.IsKnown(r.Skill) || ls.Def(r.Skill).Kind != "craft") bad.Add(r.Id + " skill " + r.Skill);
            if (!Repo.Db.Recipes.Stations.ContainsKey(r.Station)) bad.Add(r.Id + " station " + r.Station);
            if (!ls.Ranks.Contains(r.LifeRank)) bad.Add(r.Id + " lifeRank " + r.LifeRank);
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    // 1: every recipe is makeable.
    public static void EveryRecipeIsMakeableAtItsStationWithAmpleMaterialsAtItsRank()
    {
        var bad = new List<string>();
        foreach (var r in All)
        {
            var c = Knowing(r.Skill, r.LifeRank);
            var inv = Ample(r);
            var rep = c.Make(r.Id, inv, Owner(r), new MakeOptions { Seed = 5 });
            if (rep.Result != CraftResult.Ok) { bad.Add($"{r.Id}: {rep.Result}"); continue; }
            if (ItemQuality.BaseId(rep.OutputKey) != r.Output.ItemId) bad.Add($"{r.Id}: output key {rep.OutputKey}");
            if (UnitsOf(inv, r.Output.ItemId) != System.Math.Max(1, r.Output.Count)) bad.Add($"{r.Id}: output count");
            foreach (var i in r.Inputs)
                if (UnitsOf(inv, i.ItemId) != 20 - i.Count) bad.Add($"{r.Id}: {i.ItemId} used {20 - UnitsOf(inv, i.ItemId)} not {i.Count}");
            if (rep.XpGained <= 0) bad.Add($"{r.Id}: no XP");
            // The plain skip route works too (Normal quality, listed cost).
            var c2 = Knowing(r.Skill, r.LifeRank);
            var inv2 = Ample(r);
            if (c2.Craft(r.Id, inv2, Owner(r)) != CraftResult.Ok || inv2.Count(r.Output.ItemId) < 1) bad.Add($"{r.Id}: Craft() skip route");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void TheWrongBenchOrNobodyAtTheBenchIsRefusedForEveryOwnedStation()
    {
        var bad = new List<string>();
        foreach (var r in All.Where(r => Owner(r) != null))
        {
            var c = Knowing(r.Skill, r.LifeRank);
            var inv = Ample(r);
            var before = Snap(inv);
            foreach (var at in new string[] { null, "npc_nobody_at_all" })
                if (c.Make(r.Id, inv, at).Result != CraftResult.WrongStation) bad.Add($"{r.Id} at {at ?? "(nowhere)"}");
            if (!Same(before, inv)) bad.Add(r.Id + " consumed on WrongStation");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    // 2: rank gate.
    public static void ARecipeAboveYourRankIsRefusedAndConsumesNothing()
    {
        var ls0 = new LifeSkills(Repo.Db.LifeSkills);
        var bad = new List<string>();
        int tested = 0;
        foreach (var r in All.Where(r => ls0.RankIndex(r.LifeRank) > 0))
        {
            tested++;
            string below = ls0.Ranks[ls0.RankIndex(r.LifeRank) - 1];
            var skills = Ranked(r.Skill, below);
            var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, skills);
            c.Load(All.Select(x => x.Id));
            var inv = Ample(r);
            inv.AddCopper(7);
            var before = Snap(inv);
            var rep = c.Make(r.Id, inv, Owner(r));
            if (rep.Result != CraftResult.RankTooLow) bad.Add($"{r.Id} Make: {rep.Result}");
            if (c.Craft(r.Id, inv, Owner(r)) != CraftResult.RankTooLow) bad.Add($"{r.Id} Craft");
            if (c.CanCraft(r.Id, inv, Owner(r)) != CraftResult.RankTooLow) bad.Add($"{r.Id} CanCraft");
            if (!Same(before, inv) || inv.Copper != 7) bad.Add($"{r.Id} consumed on RankTooLow");
            if (skills.Xp(r.Skill) != 0 || skills.HasCrafted(r.Id)) bad.Add($"{r.Id} paid XP on RankTooLow");
            if (rep.OutputKey != null) bad.Add($"{r.Id} gave an output");
        }
        Assert.True(tested >= 15, "enough ranked recipes to matter: " + tested);
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void ARefusalNeverTouchesTheBagWhateverTheReason()
    {
        // Material count conservation (Canon 5.1: a refused craft never costs a rare material), on every real recipe.
        var bad = new List<string>();
        foreach (var r in All)
        {
            // Missing materials: one unit short of the first input.
            var c = Knowing(r.Skill, r.LifeRank);
            var inv = Ample(r, each: 0);
            foreach (var i in r.Inputs) inv.Add(i.ItemId, i.Count);
            inv.TryRemove(r.Inputs[0].ItemId, 1);
            inv.AddCopper(11);
            var before = Snap(inv);
            if (c.Make(r.Id, inv, Owner(r)).Result != CraftResult.MissingMaterials) bad.Add(r.Id + " short did not refuse");
            if (c.Craft(r.Id, inv, Owner(r)) != CraftResult.MissingMaterials) bad.Add(r.Id + " Craft short did not refuse");
            if (!Same(before, inv) || inv.Copper != 11) bad.Add(r.Id + " consumed when short");

            // Attune requested but only the bare recipe cost in the bag: refused, nothing spent.
            var inv2 = Ample(r, each: 0);
            foreach (var i in r.Inputs) inv2.Add(i.ItemId, i.Count);
            var before2 = Snap(inv2);
            var rep = Knowing(r.Skill, r.LifeRank).Make(r.Id, inv2, Owner(r), new MakeOptions { Attune = true });
            if (rep.Result != CraftResult.MissingMaterials) bad.Add(r.Id + " attune without the spare unit: " + rep.Result);
            if (!Same(before2, inv2)) bad.Add(r.Id + " consumed on a refused attune");

            // Unknown (not learned): refused, nothing spent, for taught recipes.
            if (r.LearnFrom != null)
            {
                var fresh = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, Ranked(r.Skill, r.LifeRank));
                var inv3 = Ample(r);
                var before3 = Snap(inv3);
                if (fresh.Make(r.Id, inv3, Owner(r)).Result != CraftResult.Unknown) bad.Add(r.Id + " unlearned recipe was craftable");
                if (!Same(before3, inv3)) bad.Add(r.Id + " consumed while unknown");
            }
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    // 3: the camp cap.
    public static void CampfireRecipesNeverExceedNormalEvenAtSssWithSuperiorInputs()
    {
        var camp = All.Where(r => r.Station == "campfire").ToList();
        Assert.True(camp.Count >= 3, "there are campfire recipes");
        var bad = new List<string>();
        foreach (var r in camp)
            foreach (bool attune in new[] { false, true })
                for (int n = 0; n < 40; n++)
                {
                    var c = Knowing(r.Skill, "SSS");
                    var inv = Ample(r, "superior");
                    var rep = c.Make(r.Id, inv, null, new MakeOptions { Attune = attune, Seed = 91, CraftCounter = n });
                    if (rep.Result != CraftResult.Ok) { bad.Add($"{r.Id} {rep.Result}"); break; }
                    if (Idx(rep.Quality) > Idx("normal")) { bad.Add($"{r.Id} attune={attune} counter={n} gave {rep.Quality}"); break; }
                    if (rep.Mark) bad.Add($"{r.Id} campfire output carries a Crafter's Mark");
                }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void HearthAndForgeCanExceedNormalWhereCampfiresCannot()
    {
        // Hearth: SSS cook, Superior ingredients.
        var stew = All.Single(r => r.Id == "rcp_hearth_stew");
        var rep = Knowing("cooking", "SSS").Make(stew.Id, Ample(stew, "superior"), Owner(stew), new MakeOptions { Seed = 3 });
        Assert.True(rep.Result == CraftResult.Ok, "hearth stew: " + rep.Result);
        Assert.True(Idx(rep.Quality) > Idx("normal"), "hearth beats Normal, got " + rep.Quality);
        Assert.Equal("masterwork", rep.Quality, "SSS cook with Superior ingredients tops out at Masterwork on the hearth");
        Assert.True(rep.Mark && rep.Nameable, "mark and nameable");

        // Forge: Fine ingredients, rank B, attuned.
        var blade = All.Single(r => r.Id == "rcp_fangblade");
        var forged = Knowing("blacksmithing", "B").Make(blade.Id, Ample(blade, "fine"), Owner(blade), new MakeOptions { Seed = 3, Attune = true });
        Assert.True(forged.Result == CraftResult.Ok && Idx(forged.Quality) > Idx("normal"), "forge beats Normal, got " + forged.Quality);

        // Every non-campfire station is allowed to reach Masterwork per the data.
        foreach (var kv in Repo.Db.Recipes.Stations.Where(kv => kv.Key != "campfire"))
            Assert.Equal("masterwork", Repo.Db.Quality.StationQualityCap[kv.Key], "station cap " + kv.Key);
        Assert.Equal("normal", Repo.Db.Quality.StationQualityCap["campfire"], "campfire cap");
    }

    public static void TheRankCapHoldsOnTheRealRecipes()
    {
        // F and E crafters cannot beat Normal, whatever the station or inputs.
        var bad = new List<string>();
        foreach (var r in All.Where(r => r.LifeRank == "F" && r.Station != "campfire").Take(20))
        {
            var rep = Knowing(r.Skill, "F").Make(r.Id, Ample(r, "masterwork"), Owner(r), new MakeOptions { Attune = true, Seed = 1 });
            if (rep.Result != CraftResult.Ok || Idx(rep.Quality) > Idx("normal")) bad.Add($"{r.Id} F rank gave {rep.Quality}");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    // 4: attunement.
    public static void EveryRecipeNamesAnAttuneItemThatIsOneOfItsInputs()
    {
        var bad = All.Where(r => string.IsNullOrEmpty(r.AttuneItem) || !r.Inputs.Any(i => i.ItemId == r.AttuneItem)).Select(r => r.Id + " -> " + (r.AttuneItem ?? "(none)")).ToList();
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void AttuningWithNormalInputsGivesAtMostFineAndSpendsOneExtraUnit()
    {
        var bad = new List<string>();
        foreach (var r in All)
        {
            for (int n = 0; n < 30; n++)
            {
                var c = Knowing(r.Skill, r.LifeRank);
                var inv = Ample(r);
                var rep = c.Make(r.Id, inv, Owner(r), new MakeOptions { Attune = true, Seed = 17, CraftCounter = n });
                if (rep.Result != CraftResult.Ok) { bad.Add($"{r.Id} {rep.Result}"); break; }
                if (Idx(rep.Quality) > Idx("fine")) { bad.Add($"{r.Id} counter {n} attuned Normal inputs gave {rep.Quality}"); break; }
                if (n == 0)
                {
                    foreach (var i in r.Inputs)
                    {
                        int expect = i.Count + (i.ItemId == r.AttuneItem ? 1 : 0);
                        if (UnitsOf(inv, i.ItemId) != 20 - expect) { bad.Add($"{r.Id} {i.ItemId} spent {20 - UnitsOf(inv, i.ItemId)}, expected {expect}"); }
                    }
                }
            }
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void QualityIsDeterministicOnTheRealData()
    {
        foreach (var r in All.Take(12))
        {
            var a = Knowing(r.Skill, r.LifeRank).Make(r.Id, Ample(r), Owner(r), new MakeOptions { Seed = 99, CraftCounter = 4, Attune = true });
            var b = Knowing(r.Skill, r.LifeRank).Make(r.Id, Ample(r), Owner(r), new MakeOptions { Seed = 99, CraftCounter = 4, Attune = true });
            Assert.Equal(a.OutputKey, b.OutputKey, r.Id + " same seed, same result");
            Assert.True(a.Quality != "poor" || Idx("poor") == 0, "never below Poor");
        }
    }

    // 5: meals.
    public static void EveryCookingAndBrewingRecipeOutputIsAMealWithSaneEffects()
    {
        var bad = new List<string>();
        foreach (var r in All.Where(r => MealSkills.Contains(r.Skill)))
        {
            var item = Repo.Db.Items[r.Output.ItemId];
            if (item.Meal == null) { bad.Add($"{r.Id} -> {item.Id} has no meal block"); continue; }
            if (item.Meal.Effects == null || item.Meal.Effects.Count == 0) bad.Add($"{item.Id} has no effects");
            else if (item.Meal.Effects.Any(e => string.IsNullOrEmpty(e.Stat) || e.Amount <= 0)) bad.Add($"{item.Id} has a blank or non-positive effect");
            if (item.Meal.Seconds < 300 || item.Meal.Seconds > 900) bad.Add($"{item.Id} lasts {item.Meal.Seconds}s, not 300 to 900");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void EatingAnyCraftedMealGivesWellFedAndTheNextMealReplacesIt()
    {
        var meals = All.Where(r => Repo.Db.Items[r.Output.ItemId].Meal != null).Select(r => r.Output.ItemId).Distinct().ToList();
        Assert.True(meals.Count >= 5, "several real meals: " + meals.Count);
        foreach (var id in meals)
        {
            var data = Repo.Db.Items[id].Meal;
            var m = new MealBuffs(Repo.Db.Items, Repo.Db.Quality);
            var inv = new Inventory(); inv.Add(id, 2);
            Assert.True(m.Eat(id, 100, inv), id + " eats");
            Assert.True(m.IsActive(101), id + " Well Fed");
            Assert.Equal(id, m.ItemKey, "slot holds " + id);
            Assert.Equal(1, inv.Count(id), id + " one meal used up");
            Assert.Near(data.Seconds, m.SecondsLeft(100), 1e-9, id + " Normal duration");
            foreach (var e in data.Effects) Assert.Near(e.Amount, m.Total(e.Stat, 101), 1e-9, id + " " + e.Stat);
            // Expires silently at the end, no debuff.
            Assert.True(m.IsActive(100 + data.Seconds - 1), id + " still on just before the end");
            Assert.True(!m.IsActive(100 + data.Seconds + 1), id + " expired");
            Assert.Equal(0, m.Active(100 + data.Seconds + 1).Count, id + " nothing left, no debuff");
            Assert.Equal(null, m.ItemKey, id + " slot cleared");
        }
        // A second meal replaces the first.
        string a = meals[0], b = meals.First(x => x != a && Repo.Db.Items[x].Meal.Effects.Select(e => e.Stat).Except(Repo.Db.Items[a].Meal.Effects.Select(e => e.Stat)).Any());
        var buffs = new MealBuffs(Repo.Db.Items, Repo.Db.Quality);
        Assert.True(buffs.Eat(a, 0) && buffs.Eat(b, 10), "two meals");
        Assert.Equal(b, buffs.ItemKey, "second replaced the first");
        foreach (var e in Repo.Db.Items[a].Meal.Effects.Where(e => Repo.Db.Items[b].Meal.Effects.All(x => x.Stat != e.Stat)))
            Assert.Near(0, buffs.Total(e.Stat, 11), 1e-9, "first meal's " + e.Stat + " is gone, not stacked");
        Assert.Near(10 + Repo.Db.Items[b].Meal.Seconds, buffs.ExpiresAt, 1e-9, "timer of the second meal");
    }

    public static void ACraftedFineMealFlowsFromTheHearthIntoTheSlotWithAStrongerBuff()
    {
        var r = All.Single(x => x.Id == "rcp_hearth_stew");
        var c = Knowing("cooking", "B");
        var inv = Ample(r, "fine");
        var rep = c.Make(r.Id, inv, Owner(r), new MakeOptions { Seed = 8, Attune = true });
        Assert.True(Idx(rep.Quality) >= Idx("fine"), "Fine or better from the hearth: " + rep.Quality);
        var m = new MealBuffs(Repo.Db.Items, Repo.Db.Quality);
        Assert.True(m.Eat(rep.OutputKey, 0, inv), "eat the crafted stack");
        var baseDef = Repo.Db.Items[r.Output.ItemId].Meal.Effects[0];
        Assert.Near(baseDef.Amount * Repo.Db.Quality.BuffMult(rep.Quality), m.Total(baseDef.Stat, 1), 1e-9, "scaled by quality");
        Assert.True(m.SecondsLeft(0) <= Repo.Db.Items[r.Output.ItemId].Meal.Seconds * MealBuffs.MaxDurationScale + 1e-9, "duration cap");
    }

    // 6: data integrity.
    public static void NoRecipeOutputRankExceedsItsBestInputRank()
    {
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var bad = new List<string>();
        foreach (var r in All)
        {
            int outRank = ls.RankIndex(Repo.Db.Items[r.Output.ItemId].Rank);
            int bestIn = r.Inputs.Max(i => ls.RankIndex(Repo.Db.Items[i.ItemId].Rank));
            if (outRank > bestIn) bad.Add($"{r.Id}: output {Repo.Db.Items[r.Output.ItemId].Rank} > best input {ls.Ranks[bestIn]}");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void NoRecipeIsTaughtByAnNpcWhoDoesNotExistAndBenchOwnersExist()
    {
        var bad = new List<string>();
        foreach (var r in All.Where(r => r.LearnFrom != null))
        {
            if (!Repo.Db.Npcs.ContainsKey(r.LearnFrom.NpcId)) bad.Add($"{r.Id} teacher {r.LearnFrom.NpcId} missing");
            if (r.LearnFrom.Price <= 0) bad.Add($"{r.Id} teacher price {r.LearnFrom.Price}");
        }
        foreach (var kv in Repo.Db.Recipes.Stations.Where(kv => kv.Value != null))
            if (!Repo.Db.Npcs.ContainsKey(kv.Value)) bad.Add($"station {kv.Key} owner {kv.Value} missing");
        Assert.True(bad.Count == 0, Bad(bad));
    }

    public static void EveryTaughtRecipeCanBeBoughtFromItsTeacherAndNoOneElse()
    {
        var bad = new List<string>();
        foreach (var r in All.Where(r => r.LearnFrom != null))
        {
            var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, Ranked(r.Skill, r.LifeRank));
            var inv = new Inventory(); inv.AddCopper(r.LearnFrom.Price + 5);
            if (c.Knows(r.Id)) bad.Add(r.Id + " known from the start despite a teacher");
            if (c.Learn(r.Id, inv, "npc_nobody_at_all") != CraftResult.NotTaughtHere) bad.Add(r.Id + " learnable from a stranger");
            if (c.Learn(r.Id, new Inventory(), r.LearnFrom.NpcId) != CraftResult.NotEnoughMoney) bad.Add(r.Id + " free");
            if (c.Learn(r.Id, inv, r.LearnFrom.NpcId) != CraftResult.Ok) { bad.Add(r.Id + " not learnable from " + r.LearnFrom.NpcId); continue; }
            if (inv.Copper != 5) bad.Add(r.Id + " price not charged: " + inv.Copper);
            if (!c.Knows(r.Id)) bad.Add(r.Id + " not known after learning");
            if (c.Learn(r.Id, inv, r.LearnFrom.NpcId) != CraftResult.AlreadyKnown) bad.Add(r.Id + " bought twice");
        }
        Assert.True(bad.Count == 0, Bad(bad));
    }

    // 7: known from the start.
    public static void StartingRecipesAreRankFAndCraftableAtTheirStationWithoutATeacher()
    {
        var start = All.Where(r => r.LearnFrom == null).ToList();
        Assert.True(start.Count >= 8, "several starting recipes: " + start.Count);
        var bad = new List<string>();
        foreach (var r in start)
        {
            if (r.LifeRank != "F") bad.Add(r.Id + " is known from the start but rank " + r.LifeRank);
            var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, Ranked(r.Skill, "F"));   // nothing loaded, nothing learned
            if (!c.Knows(r.Id)) { bad.Add(r.Id + " not known on a new game"); continue; }
            var inv = Ample(r);
            var rep = c.Make(r.Id, inv, Owner(r), new MakeOptions { Seed = 2 });
            if (rep.Result != CraftResult.Ok) bad.Add($"{r.Id}: {rep.Result}");
            else if (UnitsOf(inv, r.Output.ItemId) < 1) bad.Add(r.Id + " no output");
        }
        Assert.True(bad.Count == 0, Bad(bad));
        // The inverse: on a new game none of the taught recipes is known.
        var fresh = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, new LifeSkills(Repo.Db.LifeSkills));
        Assert.Equal(start.Count, fresh.Known.Count, "only the teacher-free recipes are known on a new game");
    }

    // 8: end to end.
    public static void NewGameSkewerPaysTripleXpOnceThenSavesAndLoadsTheWholeCraftingState()
    {
        var r = All.Single(x => x.Id == "rcp_hunters_skewer");
        var rules = Repo.Db.LifeSkills;
        long baseXp = r.Xp ?? rules.Xp.DefaultRecipeXpByRank[r.LifeRank];

        var ls = new LifeSkills(rules);
        var crafter = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, ls);
        var inv = new Inventory();
        inv.Add("itm_mat_prime_meat", 10);

        Assert.Equal("F", ls.Rank("cooking"), "new save is rank F");
        Assert.Equal(0L, ls.Xp("cooking"), "no XP yet");
        var first = crafter.Make(r.Id, inv, null, new MakeOptions { Seed = 1, CraftCounter = 0 });
        Assert.True(first.Result == CraftResult.Ok, "first craft: " + first.Result);
        Assert.Equal((long)(baseXp * rules.Xp.FirstCraftMultiplier), first.XpGained, "first craft pays x3");
        Assert.Equal(3.0, rules.Xp.FirstCraftMultiplier, "the multiplier is 3");
        var second = crafter.Make(r.Id, inv, null, new MakeOptions { Seed = 1, CraftCounter = 1 });
        Assert.Equal(baseXp, second.XpGained, "the bonus is paid once");
        long expectXp = first.XpGained + second.XpGained;
        Assert.Equal(expectXp, ls.Xp("cooking"), "skill XP is the sum");
        Assert.Equal(2, UnitsOf(inv, "itm_hunters_skewer"), "two skewers");
        Assert.Equal(6, UnitsOf(inv, "itm_mat_prime_meat"), "four meat used");
        Assert.Equal("normal", first.Quality, "campfire output is Normal");

        // Save to JSON the way the game does and load into a brand new session.
        var save = new SaveGame
        {
            Items = Snap(inv),
            Copper = 3,
            KnownRecipes = crafter.Known.OrderBy(x => x).ToList(),
            HandledItems = crafter.SeenItems.OrderBy(x => x).ToList(),
            LifeSkills = ls.Save()
        };
        var json = JsonSerializer.Serialize(save);
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json));
        Assert.Equal(0, SaveRules.Validate(back).Count, "a valid save");

        var ls2 = new LifeSkills(rules);
        ls2.Load(back.LifeSkills);
        var crafter2 = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, ls2);
        crafter2.Load(back.KnownRecipes, back.HandledItems);
        var inv2 = new Inventory();
        inv2.Load(back.Copper, back.Items);

        Assert.Equal(ls.Xp("cooking"), ls2.Xp("cooking"), "XP survives");
        Assert.Equal(ls.Rank("cooking"), ls2.Rank("cooking"), "rank survives");
        Assert.True(ls2.HasCrafted(r.Id) && !ls2.HasCrafted("rcp_tail_roast"), "first-craft ledger survives");
        Assert.True(crafter.Known.OrderBy(x => x).SequenceEqual(crafter2.Known.OrderBy(x => x)), "known recipes match");
        Assert.True(same(inv, inv2), "bag matches");
        Assert.True(ls.Save().Crafted.SequenceEqual(ls2.Save().Crafted), "saved ledger is identical on re-save");

        // After the reload the x3 bonus is not paid again, and a different recipe still gets its own first-time bonus.
        var again = crafter2.Make(r.Id, inv2, null, new MakeOptions { Seed = 1, CraftCounter = 2 });
        Assert.Equal(baseXp, again.XpGained, "no second x3 after a reload");
        var other = All.Single(x => x.Id == "rcp_tail_roast");
        inv2.Add("itm_mat_tail_meat", 4);
        long otherBase = other.Xp ?? rules.Xp.DefaultRecipeXpByRank[other.LifeRank];
        Assert.Equal((long)(otherBase * 3), crafter2.Make(other.Id, inv2, null).XpGained, "a different recipe is still a first time");

        static bool same(Inventory a, Inventory b) =>
            a.Items.Count == b.Items.Count && a.Items.All(kv => b.Count(kv.Key) == kv.Value);
    }

    public static void CraftingWalksTheLadderFromFToEToDWithTheCommissionGate()
    {
        // F -> E needs 250 XP; E -> D needs 800 and a passed commission (data says D). Uses a real E recipe.
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, ls);
        c.Load(All.Select(x => x.Id));
        var e = All.First(x => x.Skill == "alchemy" && x.LifeRank == "E");
        Assert.True(c.Make(e.Id, Ample(e), Owner(e)).Result == CraftResult.RankTooLow, "E recipe needs E");
        Assert.Equal("E", ls.AddXp("alchemy", 250), "250 XP reaches E");
        Assert.Equal("E", ls.Rank("alchemy"), "rank E");
        Assert.True(c.Make(e.Id, Ample(e), Owner(e)).Result == CraftResult.Ok, "now the E recipe works");
        ls.AddXp("alchemy", 2000);
        Assert.Equal("E", ls.Rank("alchemy"), "enough XP for D but no commission");
        Assert.True(ls.Eligible("alchemy"), "waiting on the commission, no XP lost");
        Assert.Equal("D", ls.PassCommission("alchemy"), "commission promotes");
        var d = All.First(x => x.Skill == "alchemy" && x.LifeRank == "D");
        Assert.True(c.Make(d.Id, Ample(d), Owner(d)).Result == CraftResult.Ok, "the D recipe opens");
    }
}
