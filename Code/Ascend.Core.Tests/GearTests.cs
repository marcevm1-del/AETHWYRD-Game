using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Ascend.Core;

// Runes, enchanting and modular parts on the REAL data (Data/Items/gear_rules.json, items, recipes, life skills).
[Tests]
static class GearTests
{
    const string Smith = "npc_torvald_stonebeard";   // forge and rune anvil
    const string Alchemist = "npc_fennick_reed";     // alembic and enchanting table

    static readonly string Dagger = "itm_moonfang_dagger";   // Epic: 2 sockets
    static readonly string Blade = "itm_hollis_practice_blade"; // Rare: 1 socket

    static Crafter Crafter(string rank = "F")
    {
        var ls = new LifeSkills(Repo.Db.LifeSkills);
        var s = new LifeSkillSave();
        foreach (var sk in new[] { "blacksmithing", "leatherworking", "runecraft", "enchanting" }) s.Rank[sk] = rank;
        ls.Load(s);
        var c = new Crafter(Repo.Db.Recipes, Repo.Db.Quality, ls);
        c.Load(Repo.Db.Recipes.Recipes.Select(r => r.Id));
        return c;
    }

    static GearFitter Fitter(Crafter c = null) => new GearFitter(Repo.Db.Gear, Repo.Db.Items, Repo.Db.Quality, c ?? Crafter());

    static Inventory Bag(params string[] keys)
    {
        var inv = new Inventory();
        foreach (var k in keys) inv.Add(k);
        return inv;
    }

    // --- data ---
    public static void EveryRuneScrollAndPartCanBeMade()
    {
        var c = Crafter("SSS");
        var wanted = Repo.Db.Gear.Runes.Select(r => r.Id).Concat(Repo.Db.Gear.Enchantments.Select(e => e.ItemId))
            .Concat(Repo.Db.Gear.Assemblies.SelectMany(a => a.Blades.Concat(a.Hilts))).Distinct().ToList();
        Assert.True(wanted.Count >= 14, "runes, scrolls and parts exist");
        foreach (var itemId in wanted)
        {
            var r = Repo.Db.Recipes.Recipes.FirstOrDefault(x => x.Output.ItemId == itemId);
            Assert.True(r != null, itemId + " has a recipe");
            var inv = new Inventory();
            foreach (var i in r.Inputs) inv.Add(i.ItemId, i.Count);
            var rep = c.Make(r.Id, inv, Repo.Db.Recipes.Stations[r.Station], new MakeOptions { Seed = 1 });
            Assert.True(rep.Result == CraftResult.Ok, itemId + " crafted: " + rep.Result);
            Assert.True(inv.Count(rep.OutputKey) == 1, itemId + " output arrived");
        }
    }

    public static void SocketsFollowRarityAndMasterwork()
    {
        var f = Fitter();
        Assert.Equal(0, f.SocketCount("itm_guild_issue_sword"), "Common");
        Assert.Equal(0, f.SocketCount("itm_fangblade"), "Uncommon");
        Assert.Equal(1, f.SocketCount(Blade), "Rare");
        Assert.Equal(2, f.SocketCount(Dagger), "Epic");
        Assert.Equal(1, f.SocketCount("itm_guild_issue_sword@masterwork"), "Common Masterwork gains one");
        Assert.Equal(3, f.SocketCount("itm_moonfang_dagger@masterwork"), "Epic Masterwork reaches the cap of 3");
        Assert.Equal(0, f.SocketCount("itm_minor_hp_potion"), "not gear");
    }

    // --- runes ---
    public static void SocketingNeedsTheAnvilAndTheOwnerAndAFittingRune()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_ember", "itm_rune_stone");
        Assert.True(f.SocketRune(Dagger, "itm_rune_ember", inv, null, Alchemist) == FitResult.WrongStation, "not at the anvil");
        Assert.True(f.SocketRune("itm_fangblade", "itm_rune_ember", Bag("itm_fangblade", "itm_rune_ember"), null, Smith) == FitResult.NoFreeSocket, "no sockets on Uncommon gear");
        Assert.True(f.SocketRune(Dagger, "itm_rune_stone", inv, null, Smith) == FitResult.DoesNotFit, "a stone rune is armour only");
        Assert.True(f.SocketRune(Dagger, "itm_minor_hp_potion", inv, null, Smith) == FitResult.NotARune, "not a rune");
        Assert.True(f.SocketRune("itm_guild_issue_mace", "itm_rune_ember", inv, null, Smith) == FitResult.NotOwned, "you must own the gear");
        Assert.True(f.SocketRune(Dagger, "itm_rune_ember", inv, null, Smith) == FitResult.Ok, "socketed");
        Assert.Equal(0, inv.Count("itm_rune_ember"), "the rune left the bag");
        Assert.Equal(1, f.Of(Dagger).Runes.Count, "one rune fitted");
    }

    public static void RemovingARuneGivesItBackAtNoCost()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_ember@fine");
        f.SocketRune(Dagger, "itm_rune_ember@fine", inv, null, Smith);
        Assert.True(f.RemoveRune(Dagger, 0, inv, null, Smith) == FitResult.Ok, "removed");
        Assert.Equal(1, inv.Count("itm_rune_ember@fine"), "the same fine rune is back");
        Assert.True(f.Of(Dagger) == null, "an empty fitting is dropped");
        Assert.True(f.RemoveRune(Dagger, 0, inv, null, Smith) == FitResult.NothingToRemove, "nothing left");
        Assert.Equal(0, inv.Copper, "no money changed hands");
    }

    public static void RuneWordsNeedTheRightOrderAndRespectSockets()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_ember", "itm_rune_anvil");
        f.SocketRune(Dagger, "itm_rune_ember", inv, null, Smith);
        Assert.True(f.ActiveWord(Dagger) == null, "one rune is no word");
        f.SocketRune(Dagger, "itm_rune_anvil", inv, null, Smith);
        Assert.Equal("word_forge_oath", f.ActiveWord(Dagger)?.Id, "ember then anvil");
        var b = f.BonusFor(Dagger);
        Assert.Near(5, b.Atk, 1e-9, "ember 2 + word 3");
        Assert.Near(12, b.Hp, 1e-9, "anvil 12");
        Assert.Equal("word_forge_oath", b.RuneWord, "reported");

        var g = Fitter(); var inv2 = Bag(Dagger, "itm_rune_ember", "itm_rune_anvil");
        g.SocketRune(Dagger, "itm_rune_anvil", inv2, null, Smith);
        g.SocketRune(Dagger, "itm_rune_ember", inv2, null, Smith);
        Assert.True(g.ActiveWord(Dagger) == null, "anvil then ember is not the word");
        Assert.Near(2, g.BonusFor(Dagger).Atk, 1e-9, "only the plain rune bonuses");
    }

    public static void RuneQualityScalesTheBonus()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_anvil@masterwork");
        f.SocketRune(Dagger, "itm_rune_anvil@masterwork", inv, null, Smith);
        Assert.Near(12 * Repo.Db.Quality.StatMult("masterwork"), f.BonusFor(Dagger).Hp, 1e-9, "masterwork rune");
    }

    // --- enchanting ---
    public static void ScrollsApplyAtTheTableAndReplaceTheOldOne()
    {
        var f = Fitter(); var inv = Bag("itm_fangblade", "itm_scroll_emberbrand", "itm_scroll_stormthread@fine");
        Assert.True(f.ApplyScroll("itm_fangblade", "itm_scroll_emberbrand", inv, null, Smith) == FitResult.WrongStation, "not at the table");
        Assert.True(f.ApplyScroll("itm_fangblade", "itm_scroll_emberbrand", inv, null, Alchemist) == FitResult.Ok, "applied");
        Assert.Equal("Fire", f.BonusFor("itm_fangblade").Element, "fire element");
        Assert.Near(2, f.BonusFor("itm_fangblade").Atk, 1e-9, "+2 ATK");
        Assert.Equal("enc_emberbrand", f.WouldReplace("itm_fangblade"), "the preview names what would go");
        Assert.True(f.ApplyScroll("itm_fangblade", "itm_scroll_stormthread@fine", inv, null, Alchemist) == FitResult.Ok, "replaced");
        var b = f.BonusFor("itm_fangblade");
        Assert.Equal("Lightning", b.Element, "now lightning");
        Assert.Near(0, b.Atk, 1e-9, "the old bonus is gone");
        Assert.Near(3 * Repo.Db.Quality.StatMult("fine"), b.Matk, 1e-9, "fine scroll scales");
        Assert.True(f.RemoveEnchant("itm_fangblade", Alchemist) == FitResult.Ok && f.Of("itm_fangblade") == null, "removed");
        Assert.Equal(0, inv.Count("itm_fangblade") - 1, "the weapon was never touched");
    }

    public static void ScrollsOnlyFitTheirGear()
    {
        var f = Fitter(); var inv = Bag("itm_rookie_hood", "itm_scroll_emberbrand", "itm_scroll_wardweave", "itm_minor_hp_potion");
        Assert.True(f.ApplyScroll("itm_rookie_hood", "itm_scroll_emberbrand", inv, null, Alchemist) == FitResult.DoesNotFit, "a weapon scroll on a hood");
        Assert.True(f.ApplyScroll("itm_rookie_hood", "itm_minor_hp_potion", inv, null, Alchemist) == FitResult.NotAScroll, "not a scroll");
        Assert.True(f.ApplyScroll("itm_rookie_hood", "itm_scroll_wardweave", inv, null, Alchemist) == FitResult.Ok, "armour scroll");
        Assert.True(f.ApplyScroll("itm_minor_hp_potion", "itm_scroll_wardweave", inv, null, Alchemist) == FitResult.NotGear, "potions are not gear");
    }

    // --- equipment ---
    public static void EquipmentCountsQualityAndFittings()
    {
        var f = Fitter(); var inv = Bag("itm_fangblade", "itm_rune_ember");
        var eq = new Equipment(Repo.Db.Items, Repo.Db.Quality, f);
        var sword = Repo.Db.Classes["cls_swordsman"];
        Assert.True(eq.Equip("itm_fangblade", inv, sword) == EquipResult.Ok, "equipped");
        Assert.Equal(12, eq.Bonus().Atk, "plain stats are unchanged");
        f.ApplyScroll("itm_fangblade", "itm_scroll_emberbrand", Bag("itm_scroll_emberbrand"), eq, Alchemist);
        Assert.Equal(14, eq.Bonus().Atk, "the enchantment adds 2 while worn");
        Assert.Equal("Fire", eq.Bonus().ApplyElement, "the element shows");

        var q = new Equipment(Repo.Db.Items, Repo.Db.Quality);
        var inv2 = Bag("itm_fangblade@masterwork");
        Assert.True(q.Equip("itm_fangblade@masterwork", inv2, sword) == EquipResult.Ok, "a quality key equips");
        Assert.Equal((int)System.Math.Round(12 * Repo.Db.Quality.StatMult("masterwork")), q.Bonus().Atk, "masterwork scales ATK");
        Assert.True(q.Unequip("main_hand", inv2) && inv2.Count("itm_fangblade@masterwork") == 1, "the quality key goes back");

        var old = new Equipment(Repo.Db.Items);
        old.Equip("itm_fangblade", Bag("itm_fangblade"), sword);
        Assert.Equal(12, old.Bonus().Atk, "the old constructor still works");
    }

    // --- modular parts ---
    public static void PartsAssembleIntoTheAverageQuality()
    {
        var c = Crafter("C"); var a = new GearAssembler(Repo.Db.Gear, Repo.Db.Quality, c);
        var inv = Bag("itm_part_scrap_blade@fine", "itm_part_pelt_hilt@poor");
        var rep = a.Assemble("asm_tempered_shortsword", "itm_part_scrap_blade@fine", "itm_part_pelt_hilt@poor", inv, Smith);
        Assert.True(rep.Result == AssembleResult.Ok, "assembled: " + rep.Result);
        Assert.Equal("normal", rep.Quality, "(fine 2 + poor 0) / 2 = normal");
        Assert.Equal(1, inv.Count("itm_tempered_shortsword"), "the sword");
        Assert.Equal(0, inv.Count("itm_part_scrap_blade@fine") + inv.Count("itm_part_pelt_hilt@poor"), "both parts used");
        Assert.True(rep.XpGained > 0, "blacksmithing XP");

        var inv2 = Bag("itm_part_scrap_blade@fine", "itm_part_fang_hilt@fine");
        var r2 = a.Assemble("asm_tempered_shortsword", "itm_part_scrap_blade@fine", "itm_part_fang_hilt@fine", inv2, Smith);
        Assert.Equal("fine", r2.Quality, "two fine parts make a fine sword");
        Assert.Equal(1, inv2.Count("itm_tempered_shortsword@fine"), "keyed with its tier");
    }

    public static void AssemblyRefusesBeforeSpendingAnything()
    {
        var c = Crafter("F"); var a = new GearAssembler(Repo.Db.Gear, Repo.Db.Quality, c);
        var inv = Bag("itm_part_iron_blade", "itm_part_pelt_hilt");
        Assert.True(a.Assemble("asm_ironwrought_longsword", "itm_part_iron_blade", "itm_part_pelt_hilt", inv, Smith).Result == AssembleResult.RankTooLow, "needs rank E");
        var d = new GearAssembler(Repo.Db.Gear, Repo.Db.Quality, Crafter("E"));
        Assert.True(d.Assemble("asm_ironwrought_longsword", "itm_part_iron_blade", "itm_part_pelt_hilt", inv, Alchemist).Result == AssembleResult.WrongStation, "wrong bench");
        Assert.True(d.Assemble("asm_ironwrought_longsword", "itm_part_scrap_blade", "itm_part_pelt_hilt", inv, Smith).Result == AssembleResult.WrongPart, "wrong blade");
        Assert.True(d.Assemble("asm_ironwrought_longsword", "itm_part_iron_blade", "itm_part_fang_hilt", inv, Smith).Result == AssembleResult.MissingPart, "no such hilt");
        Assert.True(d.Assemble("asm_missing", "a", "b", inv, Smith).Result == AssembleResult.Unknown, "unknown");
        Assert.Equal(2, inv.Items.Values.Sum(), "nothing was consumed by any refusal");
        Assert.True(d.Assemble("asm_ironwrought_longsword", "itm_part_iron_blade", "itm_part_pelt_hilt", inv, Smith).Result == AssembleResult.Ok, "now it works");
    }

    // --- no loss, ever ---
    public static void NoSequenceOfFittingActionsDestroysARuneOrTheGear()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_ember", "itm_rune_anvil", "itm_rune_hearth");
        string[] runes = { "itm_rune_ember", "itm_rune_anvil", "itm_rune_hearth" };
        var rng = new System.Random(7);
        for (int n = 0; n < 300; n++)
        {
            if (rng.Next(2) == 0) f.SocketRune(Dagger, runes[rng.Next(3)], inv, null, Smith);
            else f.RemoveRune(Dagger, rng.Next(3), inv, null, Smith);
            int fitted = f.Of(Dagger)?.Runes.Count ?? 0;
            int bag = runes.Sum(r => inv.Count(r));
            Assert.Equal(3, fitted + bag, "every rune is either fitted or in the bag, step " + n);
            Assert.Equal(1, inv.Count(Dagger), "the gear never leaves");
            Assert.True(fitted <= 2, "never above the sockets");
        }
    }

    // --- saves ---
    public static void FittingsSurviveASaveAndOldSavesLoad()
    {
        var f = Fitter(); var inv = Bag(Dagger, "itm_rune_ember", "itm_rune_anvil", "itm_scroll_emberbrand@fine");
        f.SocketRune(Dagger, "itm_rune_ember", inv, null, Smith);
        f.SocketRune(Dagger, "itm_rune_anvil", inv, null, Smith);
        f.ApplyScroll(Dagger, "itm_scroll_emberbrand@fine", inv, null, Alchemist);
        var save = new SaveGame { GearFittings = f.Save() };
        var json = JsonSerializer.Serialize(save);
        var back = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>(json));
        var g = Fitter(); g.Load(back.GearFittings);
        Assert.Equal("word_forge_oath", g.ActiveWord(Dagger)?.Id, "the rune word came back");
        Assert.Equal("itm_scroll_emberbrand@fine", g.Of(Dagger).Enchant, "the enchantment kept its tier");
        Assert.Near(f.BonusFor(Dagger).Atk, g.BonusFor(Dagger).Atk, 1e-9, "same bonus after load");

        var old = SaveRules.Upgrade(JsonSerializer.Deserialize<SaveGame>("{\"Version\":1,\"Level\":3}"));
        Assert.True(old.GearFittings != null && old.GearFittings.Count == 0, "an old save gets no fittings");
        Assert.True(SaveRules.Validate(old).Count == 0, "and still validates");
        var h = Fitter(); h.Load(old.GearFittings); h.Load(null);
        Assert.True(h.Fittings.Count == 0, "load(null) is safe");
    }

    public static void LoadDropsUnknownGearAndRunes()
    {
        var h = Fitter();
        h.Load(new Dictionary<string, GearFitting>
        {
            ["itm_not_real"] = new GearFitting { Runes = new List<string> { "itm_rune_ember" } },
            [Dagger] = new GearFitting { Runes = new List<string> { "itm_rune_ember", "itm_gone_rune" }, Enchant = "itm_scroll_gone" },
            [Blade] = null
        });
        Assert.Equal(1, h.Fittings.Count, "only the real fitting stays");
        Assert.Equal(1, h.Of(Dagger).Runes.Count, "the unknown rune is dropped");
        Assert.True(h.Of(Dagger).Enchant == null, "the unknown scroll is dropped");
    }

    public static void WordsOnlyCountInRealSocketsAndDivineTakesNothing()
    {
        // A key holding more runes than sockets (an odd save): the word in the over-cap slot does not pay.
        var f = Fitter();
        f.Load(new Dictionary<string, GearFitting> { [Dagger] = new GearFitting { Runes = new List<string> { "itm_rune_hearth", "itm_rune_ember", "itm_rune_anvil" } } });
        Assert.True(f.ActiveWord(Dagger) == null, "ember+anvil would need the third socket");
        var inv = Bag(Dagger, "itm_rune_ember");
        Assert.True(Fitter().RemoveRune(Dagger, 0, null, null, Smith) == FitResult.NothingToRemove, "nothing fitted");
        var g = Fitter(); g.Load(new Dictionary<string, GearFitting> { [Dagger] = new GearFitting { Runes = new List<string> { "itm_rune_ember" } } });
        Assert.True(g.RemoveRune(Dagger, 0, null, null, Smith) == FitResult.NotOwned && g.Of(Dagger).Runes.Count == 1, "no bag, no removal, nothing lost");
    }
}
