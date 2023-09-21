﻿using PokemonCommon.Enums;

namespace PokemonCommon;

public static class BattleUI
{
    private static Dictionary<Effectiveness, string> messages = new Dictionary<Effectiveness, string>()
    {
        { Effectiveness.None, "It has no effect!" },
        { Effectiveness.NotVery, "It's not very effective..." },
        { Effectiveness.Normal, "" },
        { Effectiveness.Super, "It's super effective!" }
        
    };

    public static void DisplayDamageEffectiveness(Effectiveness effectiveness)
    {
        Console.WriteLine(messages[effectiveness]);
    }

    public static void DisplayDamageEffectiveness(Effectiveness effectiveness, string attackName, string attacker)
    {
        Console.WriteLine($"{attacker} used {attackName}! {messages[effectiveness]}");
    }

    //public static List<string> texter = new List<string>()
    //{
    //    "Hej",
    //    "på",
    //    "dig!"
    //};
}