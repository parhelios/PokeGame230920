using PokemonCommon.Enums;

namespace PokemonCommon.Pokemons.Attacks;

public class Earthquake : Attack
{
    public Earthquake() : base(100, "Earthquake", PokeTypes.Ground)
    {
    }
}