using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;

namespace PokeGame;

public static class BattleEngine
{
    // Detta är en statisk metod. Statiska metoder anropas via typen och inte via objekt.
    public static void MakeAttack(Pokemon target, Attack attack)
    {
        target.HealthPoints -= attack.Damage;
    }
}