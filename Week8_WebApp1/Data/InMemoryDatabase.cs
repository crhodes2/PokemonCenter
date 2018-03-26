using System.Collections.Generic;
using Week8_WebApp1.Data.Entities;

namespace Week4_WebApp1.Data
{
    public class InMemoryDatabase
    {
        public static List<Pokemon> Pokemons = new List<Pokemon>();
        public static List<Vitamins> Vitamins = new List<Vitamins>();

        public static int id = 0;

        public static int NextId()
        {
            return id++;
        }

        public static void DeletePokemon(int id)
        {
            var user = Pokemons.Find(u => u.Id == id);
            Pokemons.Remove(user);
        }

        public static void DeleteVitamins(int id)
        {
            var vit = Vitamins.Find(u => u.VitId == id);
            Vitamins.Remove(vit);
        }

    }
}