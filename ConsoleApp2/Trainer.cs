using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace PokeGame
{
    internal class Trainer
    {
        public List<Pokemon> PokemonCollection { get; set; } = new List<Pokemon>();

        // Detta är en statisk metod. Statiska metoder anropas via typen och inte via objekt.
        public static void Greeting() 
        {
            Console.WriteLine("Hi!");
        }

        public void Catch(Pokemon pokemon)
        {
            PokemonCollection.Add(pokemon);
        }

        public void Release(Pokemon pokemon)
        {
            PokemonCollection.Remove(pokemon);
        }
    }
}
