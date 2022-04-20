using PokemonModels;
using System.IO;

namespace PokemonDL
{
    public class Repository : IRepository
    {

        private string filePath = "../PokemonDL/Database";
        private string jsonString;
        public Pokemon AddPokemon(Pokemon poke)
        {
            throw new NotImplementedException();
        }

        public void  GetAllPokemon()
        {
            jsonString = File.ReadAllText(filePath+"Pokemon.json"); 
        }


    }
}