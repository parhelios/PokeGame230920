using PokeGame;
using PokemonCommon.Characters;
using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;


Trainer ash = new Trainer("Ash");

var sobble = new Pokemon("Sobble", PokeTypes.Water);
var charmander = new Pokemon("Charmander", PokeTypes.Fire);

var ember = new Ember();
var waterGun = new WaterGun();

charmander.LearnAttack(ember, 0);
sobble.LearnAttack(waterGun, 0);

Console.WriteLine("---------");
//foreach (var sobbleAttack in sobble.Attacks)
//{
//    if (sobbleAttack == null)
//    {
//        continue;
//    }
//    Console.WriteLine(sobbleAttack.Name);
//}

Console.WriteLine(sobble.HealthPoints);
BattleEngine.MakeAttack(sobble, ember);
Console.WriteLine(sobble.HealthPoints);