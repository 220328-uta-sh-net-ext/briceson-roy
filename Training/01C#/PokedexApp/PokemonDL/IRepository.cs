using PokemonModels;

namespace PokemonDL
{
    public interface IRepository
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="poke"></param>
       /// <returns>The Pokemon is added</returns>

        Pokemon AddPokemon(Pokemon poke);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns collection of pokemon as Generics List</returns>
       List<Pokemon> GetAllPokemon();



    }
}
