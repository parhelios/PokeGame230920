using PokemonCommon;
using PokemonCommon.Characters;
using PokemonCommon.Enums;
using PokemonCommon.Pokemons;
using PokemonCommon.Pokemons.Attacks;


Trainer ash = new Trainer("Ash");

var sobble = new Pokemon("Sobble", PokeTypes.Water);
var charmander = new Pokemon("Charmander", PokeTypes.Fire);

var ember = new Ember();
var fireBlast = new FireBlast();
var solarBeam = new SolarBeam();
var tackle = new Tackle();

var waterGun = new WaterGun();
var dig = new Dig();
var splash = new Splash();
var hyperBeam = new HyperBeam();

charmander.LearnAttack(ember, 0);
charmander.LearnAttack(fireBlast, 1);
charmander.LearnAttack(solarBeam, 2);
charmander.LearnAttack(tackle, 3);

sobble.LearnAttack(waterGun, 0);
sobble.LearnAttack(dig, 1);
sobble.LearnAttack(splash, 2);
sobble.LearnAttack(hyperBeam, 3);


//Console.WriteLine("---------");
//foreach (var sobbleAttack in sobble.Attacks)
//{
//    if (sobbleAttack == null)
//    {
//        continue;
//    }
//    Console.WriteLine(sobbleAttack.Name);
//}

//Console.WriteLine(sobble.HealthPoints);
//BattleEngine.MakeAttack(sobble, charmander.Attacks[0]);
//Console.WriteLine(sobble.HealthPoints);

BattleEngine.BattleSimulator(charmander, sobble);