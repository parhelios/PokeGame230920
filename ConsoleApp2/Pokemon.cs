namespace PokeGame
{
    internal class Pokemon
    {
        // Property för health points 
        // Databehållaren "bakom" en property kallas för fält.
        private int _healthPoints = 100;
        public int HealthPoints
        {
            // Get är en metod som anropas när värdet på en property ska läsas
            get { return _healthPoints; }
            // Set är en metod som anropas när värdet på en property ska sättas
            set { _healthPoints = value; }
        }

        // Property för Name
        private string _name;
        public string Name 
        { 
            get 
            {
                return _name; 
            }
            set 
            {
                _name = value;
            }
        }

        // Property för Type
        private PokeTypes _type;
        public PokeTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Detta är en tom konstruktor, om ingen konstruktor deklareras så finns en sådan i alla klasser utan at tman behöver deklarera den.
        // En konstruktor är en metod som returnerar en ny instans av den typ den befinner sig i, returtyp och namn slås ihop.
        public Pokemon()
        {
            
        }

        // Detta är ytterligare en konstruktor, denna gång med parametrar. En klass kan ha 0 ... n konstruktorer, bara alla har olika signatur.
        public Pokemon(string name, PokeTypes type)
        {
            _name = name;
            _type = type;
        }

        // Detta är en instans-metod. Till skillnad från statiska metoder anropas dessa enbart genom objekt.
        public void Attack(Pokemon target)
        {
            target.HealthPoints -= 10;
            Console.WriteLine(_name + " Attacks " + target.Name);
        }

    }
}
