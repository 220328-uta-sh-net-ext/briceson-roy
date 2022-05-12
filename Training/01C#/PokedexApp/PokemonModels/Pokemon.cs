namespace PokemonModels
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Health { get; set; }

        //Moves-> Attack, Power, Accuracy
        private List<Moves> _moves;
        public List<Moves> Moves
        {
            get { return _moves; }
            set
            {
                if (value.Count <= 4)
                {
                    _moves = value;
                }
                else
                {
                    throw new Exception("A Pokemon cannot know more than 4 moves");
                }
            }
        }
        //default Constructor


        public Pokemon()
        {
            Name = "Ditto";
            Level = 1;
            Attack = 55;
            Defense = 55;
            _moves = new List<Moves>()
            {
                new Moves()
            };

        }
    }
}
