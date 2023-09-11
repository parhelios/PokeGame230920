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