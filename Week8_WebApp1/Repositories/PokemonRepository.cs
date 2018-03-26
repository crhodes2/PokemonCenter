using System.Collections.Generic;
using System.Linq;
using Week8_WebApp1.Data.Entities;
using Week8_WebApp1.Models;

namespace Week8_WebApp1.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDbContext _dbContext;

        public PokemonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pokemon GetPokemon(int id)
        {
            return _dbContext.Pokemons.Find(id);
        }

        public IEnumerable<Pokemon> GetPokemonsForUser(string userId)
        {
            return _dbContext.Pokemons.Where(Pokemon => Pokemon.UserId == userId).ToList();
        }

        public void SavePokemon(Pokemon Pokemon)
        {
            _dbContext.Pokemons.Add(Pokemon);

            _dbContext.SaveChanges();
        }

        public void UpdatePokemon(Pokemon Pokemon)
        {
            _dbContext.SaveChanges();
        }

        public void DeletePokemon(int id)
        {
            var Pokemon = _dbContext.Pokemons.Find(id);

            if (Pokemon == null) return;

            _dbContext.Pokemons.Remove(Pokemon);
            _dbContext.SaveChanges();
        }
    }
}