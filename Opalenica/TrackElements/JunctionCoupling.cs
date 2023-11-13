namespace Opalenica;

public class JunctionCoupling
{
    private static List<(CouplingRule, CouplingRule)> CouplingRules = new List<(CouplingRule, CouplingRule)>();

    public static void ExecuteRules(Junction junction, bool toMain)
    {
        foreach ((CouplingRule main, CouplingRule toChange) in CouplingRules)
        {
            var currentRule = new CouplingRule(junction, toMain);
            if (currentRule == main)
            {
                var jun = toChange.Junction;
                jun.ThrowJunction(toChange.Direction, jun.GetMainDirection());
            }
        }
    }

    public static void AddRule(Junction main, bool directionMain, Junction second, bool directionSecond) => AddRule(new CouplingRule(main, directionMain), new CouplingRule(second, directionSecond));
    public static void AddRule(Junction main, Junction second)
    {
        AddRule(new CouplingRule(main, true), new CouplingRule(second, true));
        AddRule(new CouplingRule(main, false), new CouplingRule(second, false));
    }

    public static void AddRule(CouplingRule main, CouplingRule second)
    {
        CouplingRules.Add((main, second));
    }
}
