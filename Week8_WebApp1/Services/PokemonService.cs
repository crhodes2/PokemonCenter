using System;
using System.Collections.Generic;
using Week8_WebApp1.Data.Entities;
using Week8_WebApp1.Models.View;
using Week8_WebApp1.Repositories;

namespace Week8_WebApp1.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;

        public PokemonService(IPokemonRepository respository)
        {
            _repository = respository;
        }

        public PokemonViewModel GetPokemon(int id)
        {
            var Pokemon = _repository.GetPokemon(id);
            return MapToPokemonViewModel(Pokemon);
        }

        public IEnumerable<PokemonViewModel> GetPokemonsForUser(string userId)
        {
            var PokemonViewModels = new List<PokemonViewModel>();

            var Pokemons = _repository.GetPokemonsForUser(userId);

            foreach (var Pokemon in Pokemons)
            {
                PokemonViewModels.Add(MapToPokemonViewModel(Pokemon));
            }

            return PokemonViewModels;
        }

        public void SavePokemon(string userId, PokemonViewModel PokemonViewModel)
        {
            //throw new Exception("Test Exception");

            var Pokemon = MapToPokemon(userId, PokemonViewModel);

            _repository.SavePokemon(Pokemon);
        }

        public void UpdatePokemon(PokemonViewModel PokemonViewModel)
        {
            var Pokemon = _repository.GetPokemon(PokemonViewModel.Id);

            CopyToPokemon(PokemonViewModel, Pokemon);

            _repository.UpdatePokemon(Pokemon);
        }

        public void DeletePokemon(int id)
        {
            _repository.DeletePokemon(id);
        }

        private Pokemon MapToPokemon(string userId, PokemonViewModel PokemonViewModel)
        {
            return new Pokemon
            {
                Id = PokemonViewModel.Id,
                Name = PokemonViewModel.Name,
                Age = PokemonViewModel.Age,
                NextCheckup = PokemonViewModel.NextCheckup,
                VetName = PokemonViewModel.VetName,
                UserId = userId
            };
        }

        private PokemonViewModel MapToPokemonViewModel(Pokemon Pokemon)
        {
            var PokemonViewModel = new PokemonViewModel
            {
                Id = Pokemon.Id,
                Name = Pokemon.Name,
                Age = Pokemon.Age,
                NextCheckup = Pokemon.NextCheckup,
                VetName = Pokemon.VetName
            };

            PokemonViewModel.CheckupAlert = (PokemonViewModel.NextCheckup - DateTime.Now).Days < 14;

            return PokemonViewModel;
        }

        private void CopyToPokemon(PokemonViewModel PokemonViewModel, Pokemon Pokemon)
        {
            Pokemon.Id = PokemonViewModel.Id;
            Pokemon.Name = PokemonViewModel.Name;
            Pokemon.Age = PokemonViewModel.Age;
            Pokemon.NextCheckup = PokemonViewModel.NextCheckup;
            Pokemon.VetName = PokemonViewModel.VetName;
        }
    }
}