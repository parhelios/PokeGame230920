using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeGame
{
    internal class FirePokemon : Pokemon
    {
        public FirePokemon()
        {
            Type = PokeTypes.Fire;
        }

        public void Ember()
        {
            Console.WriteLine("Burn baby burn!");
        }
    }
}
