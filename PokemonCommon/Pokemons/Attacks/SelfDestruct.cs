using PokemonCommon.Enums;

namespace PokemonCommon.Pokemons.Attacks;

public class SelfDestruct : Attack
{
    public SelfDestruct() : base(200, "Self Destruct", PokeTypes.Normal)
    {
    }
}