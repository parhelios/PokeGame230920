using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;

namespace PokemonCommon;

public static class BattleEngine
{
    public static void BattleSimulator(Pokemon firstPokemon, Pokemon secondPokemon)
    {
        (Pokemon attacker, Pokemon defender) roles = (firstPokemon,  secondPokemon);
        int roundTracker = 1;
        
        while (roles.attacker.HealthPoints >= 0 && roles.defender.HealthPoints >= 0)
        {
            var rand = new Random();
            int randAttackIndex = rand.Next(0, roles.attacker.Attacks.Length);

            Console.WriteLine($"[Round {roundTracker}: {firstPokemon.Name} HP: {firstPokemon.HealthPoints} || {secondPokemon.Name} HP: {secondPokemon.HealthPoints}]");
            roundTracker++;
            double firstPokeHp = roles.defender.HealthPoints;
            MakeAttack(roles.defender, roles.attacker.Attacks[randAttackIndex]);

            double damage = firstPokeHp - roles.defender.HealthPoints;
            Console.WriteLine($"{roles.attacker.Name} attacks {roles.defender.Name} with {roles.attacker.Attacks[randAttackIndex].Name} and deals {damage} points of damage.");

            roles = RoleSwitcher(roles.attacker, roles.defender);
            Console.WriteLine("\n");

        }
        Console.WriteLine("---------------------------");

        if (firstPokemon.HealthPoints > secondPokemon.HealthPoints) 
        {
            Console.WriteLine($"{firstPokemon.Name} destroyed {secondPokemon.Name}.");
        }
        else if (firstPokemon.HealthPoints < secondPokemon.HealthPoints) 
        {
            Console.WriteLine($"{secondPokemon.Name} destroyed {firstPokemon.Name}.");
        }
        else if (firstPokemon.HealthPoints == secondPokemon.HealthPoints)
        {
            Console.WriteLine("The battle was a tie.");
        }

    }

    public static (Pokemon attacker, Pokemon defender) RoleSwitcher(Pokemon attacker, Pokemon defender)
    {
        (Pokemon attacker, Pokemon defender) roles = (defender, attacker);

        return roles;
    }


    // Detta är en statisk metod. Statiska metoder anropas via typen och inte via objekt.
    public static void MakeAttack(Pokemon target, Attack attack)
    {
        Effectiveness effectiveness = CheckEffectiveness(attack.Type, target.Types.ToArray());
        
        double modifier = (double)effectiveness / 100.0;

        target.HealthPoints -= attack.Damage * modifier;

        BattleUI.DisplayDamageEffectiveness(effectiveness);
    }
    public static Effectiveness CheckEffectiveness(PokeTypes attackType, PokeTypes[] targetTypes)
    {
        return attackType switch
        {
            PokeTypes.Normal => NormalAttackEffectiveness(targetTypes),
            PokeTypes.Fire => FireAttackEffectiveness(targetTypes),
            PokeTypes.Water => WaterAttackEffectiveness(targetTypes),
            PokeTypes.Grass => GrassAttackEffectiveness(targetTypes),
            PokeTypes.Electric => ElectricAttackEffectiveness(targetTypes),
            PokeTypes.Ice => IceAttackEffectiveness(targetTypes),
            PokeTypes.Fighting => FightingAttackEffectiveness(targetTypes),
            PokeTypes.Poison => PoisonAttackEffectiveness(targetTypes),
            PokeTypes.Ground => GroundAttackEffectiveness(targetTypes),
            PokeTypes.Flying => FlyingAttackEffectiveness(targetTypes),
            PokeTypes.Psychic => PsychicAttackEffectiveness(targetTypes),
            PokeTypes.Bug => BugAttackEffectiveness(targetTypes),
            PokeTypes.Rock => RockAttackEffectiveness(targetTypes),
            PokeTypes.Ghost => GhostAttackEffectiveness(targetTypes),
            PokeTypes.Dragon => DragonAttackEffectiveness(targetTypes),
            PokeTypes.Dark => DarkAttackEffectiveness(targetTypes),
            PokeTypes.Steel => SteelAttackEffectiveness(targetTypes),
            PokeTypes.Fairy => FairyAttackEffectiveness(targetTypes),
            _ => Effectiveness.Normal
        };
    }

    #region EffectivenessChecks
    private static Effectiveness FairyAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness SteelAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness DarkAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness DragonAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GhostAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Normal))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness RockAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness BugAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness PsychicAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FlyingAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fighting))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GroundAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness PoisonAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FightingAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Psychic))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fairy))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Normal))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Dark))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness IceAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness ElectricAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Electric))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness GrassAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Poison))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Flying))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness WaterAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ground))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness FireAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Fire))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Water))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Dragon))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Grass))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Ice))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Bug))
            return Effectiveness.Super;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.Super;

        return Effectiveness.Normal;
    }

    private static Effectiveness NormalAttackEffectiveness(PokeTypes[] targetTypes)
    {
        if (targetTypes.Contains(PokeTypes.Ghost))
            return Effectiveness.None;
        if (targetTypes.Contains(PokeTypes.Rock))
            return Effectiveness.NotVery;
        if (targetTypes.Contains(PokeTypes.Steel))
            return Effectiveness.NotVery;

        return Effectiveness.Normal;
    }

    #endregion
}