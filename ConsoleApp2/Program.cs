using PokemonCommon.Characters;
using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;


Trainer ash = new Trainer("Ash");

Pokemon sobble = new Pokemon("Sobble", PokeTypes.Water);

Tackle tackle = new Tackle();

sobble.LearnAttack(tackle, 0);

foreach (var sobbleAttack in sobble.Attacks)
{
    if (sobbleAttack == null)
    {
        continue;
    }
    Console.WriteLine(sobbleAttack.Name);
}
// Detta är en statisk metod. Statiska metoder anropas via typen och inte via objekt.