using PokemonCommon.Characters;
using PokemonCommon.Pokemons;

Trainer niklas = new Trainer();

Console.WriteLine("___________________________________");

Pokemon charmeleon = new Pokemon();

charmeleon.Name = "Charmeleon";

niklas.Catch(charmeleon);

Pokemon wartorlte = new Pokemon();

wartorlte.Name = "Wartortle";

niklas.Catch(wartorlte);

foreach (Pokemon pokemon in niklas.PokemonCollection)
{
    pokemon.Attack(wartorlte);


    Console.WriteLine(pokemon.Name);
    Console.WriteLine(pokemon.Type);
}


//Hej på dig