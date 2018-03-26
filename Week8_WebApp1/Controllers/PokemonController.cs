using System;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using Week8_WebApp1.Models.View;
using Week8_WebApp1.Services;

namespace Week8_WebApp1.Controllers
{
    [Authorize]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _PokemonService;
        private readonly ILog _log = LogManager.GetLogger(typeof(PokemonController));

        public PokemonController(IPokemonService PokemonService)
        {
            _PokemonService = PokemonService;
        }
        
        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            _log.Debug("Getting list of Pokemons for user: " + userId);

            var PokemonViewModels = _PokemonService.GetPokemonsForUser(userId);

            return View(PokemonViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PokemonViewModel PokemonViewModel)
        {
            _log.Info("Creating Pokemon");

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _PokemonService.SavePokemon(userId, PokemonViewModel);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to save Pokemon.", ex);
                throw;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Pokemon = _PokemonService.GetPokemon(id);

            return View(Pokemon);
        }

        [HttpPost]
        public ActionResult Edit(PokemonViewModel PokemonViewModel)
        {
            if (ModelState.IsValid)
            {
                _PokemonService.UpdatePokemon(PokemonViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var Pokemon = _PokemonService.GetPokemon(id);

            return View(Pokemon);
        }
        
        public ActionResult Delete(int id)
        {
            _PokemonService.DeletePokemon(id);

            return RedirectToAction("List");
        }
    }
}