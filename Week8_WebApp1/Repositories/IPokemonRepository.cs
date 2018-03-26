using System.Collections.Generic;
using Week8_WebApp1.Data.Entities;

namespace Week8_WebApp1.Repositories
{
    public interface IPokemonRepository
    {
        Pokemon GetPokemon(int id);

        IEnumerable<Pokemon> GetPokemonsForUser(string userId);

        void SavePokemon(Pokemon Pokemon);

        void UpdatePokemon(Pokemon user);

        void DeletePokemon(int id);
    }
}
