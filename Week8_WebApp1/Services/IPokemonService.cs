using System.Collections.Generic;
using Week8_WebApp1.Models.View;

namespace Week8_WebApp1.Services
{
    public interface IPokemonService
    {
        PokemonViewModel GetPokemon(int id);

        IEnumerable<PokemonViewModel> GetPokemonsForUser(string userId);

        void SavePokemon(string userId, PokemonViewModel Pokemon);

        void UpdatePokemon(PokemonViewModel user);

        void DeletePokemon(int id);
    }
}
