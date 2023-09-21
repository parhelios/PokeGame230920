using PokemonCommon.Pokemons;

namespace PokemonCommon.Characters
{
    public class Trainer
    {
        public string Name { get; set; }

        public List<Pokemon> PokemonCollection { get; set; } = new List<Pokemon>();

        public Trainer(string name)
        {
            Name = name;
        }

        // Detta är en instans-metod. Till skillnad från statiska metoder anropas dessa enbart genom objekt.
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
