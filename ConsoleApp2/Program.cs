using PokeGame;

// Här instansieras klassen Pokemon och ett objekt av typen Pokemon läggs i variabeln pikachu
// Detta görs med en konstruktor i klassen Pokemon som har 2 parametrar, name och type.
Pokemon pikachu = new Pokemon("Pikachu", PokeTypes.Electric);

// Här instansieras klassen Pokemon och ett objekt av typen Pokemon läggs i variabeln charmander
// Detta görs med en tom konstruktor och sedan tilldelas värden till Name och Type
Pokemon charmander = new Pokemon();
charmander.Name = "Charmander";
charmander.Type = PokeTypes.Fire;

// Här anropas metoden Attack på objektet charmander och en referens till objektet pikachu skickas in som argument
charmander.Attack(pikachu);
// Här anropas metoden Attack på objektet pikachu och en referens till objektet charmander skickas in som argument
pikachu.Attack(charmander);

// Här skrivs värdet på propertyn HealthPoints ut för båda objekten pikachu och charmander
Console.WriteLine("Pikachu health points: " + pikachu.HealthPoints);
Console.WriteLine("Charmander health points: " + charmander.HealthPoints);

//Console.WriteLine(pikachu.Name);
//Console.WriteLine(pikachu.Type);
//Console.WriteLine(charmander.Name);
//Console.WriteLine(charmander.Type);

//charmander.Type = "tjoho0";

//Console.WriteLine(charmander.Name);
//Console.WriteLine(charmander.Type);

Console.WriteLine("______________________");

Trainer niklas = new Trainer();

Pokemon psyduck = new Pokemon("Psyduck", PokeTypes.Psychic);
Pokemon mewtwo = new Pokemon("Mewtwo", PokeTypes.Psychic);
Pokemon squirtle = new Pokemon("Squirtle", PokeTypes.Water);

niklas.Catch(psyduck);
niklas.Catch(mewtwo);
niklas.Catch(squirtle);
niklas.Catch(pikachu);
niklas.Catch(charmander);

foreach (var pokemon in niklas.PokemonCollection)
{
    Console.WriteLine(pokemon.Name);
}

while (niklas.PokemonCollection.Count > 0)
{
    Console.WriteLine(niklas.PokemonCollection[0].Name);
    niklas.Release(niklas.PokemonCollection[0]);
}

Console.WriteLine(niklas.PokemonCollection.Count);

Console.WriteLine("___________________________________");

FirePokemon charmeleon = new FirePokemon();

charmeleon.Name = "Charmeleon";

niklas.Catch(charmeleon);

WaterPokemon wartorlte = new WaterPokemon();

wartorlte.Name = "Wartortle";

niklas.Catch(wartorlte);

MagmaPokemon magmar = new MagmaPokemon();
magmar.Name = "Magmar";

niklas.Catch(magmar);

foreach (Pokemon pokemon in niklas.PokemonCollection)
{
    if(pokemon is FirePokemon fire)
    {
       fire.Ember();
    }
    else if (pokemon is WaterPokemon water) 
    {
        water.Bubble();
    }

    Console.WriteLine(pokemon.Name);
    Console.WriteLine(pokemon.Type);
}
