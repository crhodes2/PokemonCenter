using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Week8_WebApp1.Data;
using Week8_WebApp1.Data.Entities;
using Week8_WebApp1.Models.View;

namespace Week8_WebApp1.Controllers
{
    public class VitaminsController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var Vitamins = GetVitaminsForUser(userId);

            return View(Vitamins);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(VitaminsViewModel VitaminViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(VitaminViewModel);
                return RedirectToAction("List", new { UserId = VitaminViewModel.VitId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Vitamin = GetVitamin(id);

            return View(Vitamin);
        }

        [HttpPost]
        public ActionResult Edit(VitaminsViewModel VitaminViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateVitamin(VitaminViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Vitamin = GetVitamin(id);

            DeleteVitamin(id);

            return RedirectToAction("List", new { UserId = Vitamin.VitId });
        }

        private Vitamins GetVitamin(int VitaminId)
        {
            var dbContext = new AppDbContext();

            return dbContext.Vitamins.Find(VitaminId);
        }

        private ICollection<VitaminsViewModel> GetVitaminsForUser(int userId)
        {
            var VitaminViewModels = new List<VitaminsViewModel>();

            var dbContext = new AppDbContext();

            var Vitamins = dbContext.Vitamins.Where(Vitamin => Vitamin.VitId == userId).ToList();

            foreach (var Vitamin in Vitamins)
            {
                var VitaminViewModel = MapToVitaminViewModel(Vitamin);
                VitaminViewModels.Add(VitaminViewModel);
            }

            return VitaminViewModels;
        }

        private void Save(VitaminsViewModel VitaminViewModel)
        {
            var dbContext = new AppDbContext();

            var Vitamin = MapToVitamin(VitaminViewModel);

            dbContext.Vitamins.Add(Vitamin);

            dbContext.SaveChanges();
        }

        private void UpdateVitamin(VitaminsViewModel VitaminViewModel)
        {
            var dbContext = new AppDbContext();

            var Vitamin = dbContext.Vitamins.Find(VitaminViewModel.VitId);

            CopyToVitamin(VitaminViewModel, Vitamin);

            dbContext.SaveChanges();
        }

        private void DeleteVitamin(int id)
        {
            var dbContext = new AppDbContext();

            var Vitamin = dbContext.Vitamins.Find(id);

            if (Vitamin != null)
            {
                dbContext.Vitamins.Remove(Vitamin);
                dbContext.SaveChanges();
            }
        }

        private Vitamins MapToVitamin(VitaminsViewModel VitaminViewModel)
        {
            return new Vitamins
            {
                VitId = VitaminViewModel.VitId,
                VitaminName = VitaminViewModel.VitaminName,
                ServingSize = VitaminViewModel.ServingSize,
                AboutVitamin = VitaminViewModel.AboutVitamin,
                RefillDate = VitaminViewModel.RefillDate,
                PokemonId = VitaminViewModel.PokemonId
                
            };
        }

        private VitaminsViewModel MapToVitaminViewModel(Vitamins Vitamin)
        {
            return new VitaminsViewModel
            {
                VitId = Vitamin.VitId,
                VitaminName = Vitamin.VitaminName,
                ServingSize = Vitamin.ServingSize,
                AboutVitamin = Vitamin.AboutVitamin,
                RefillDate = Vitamin.RefillDate,
                PokemonId = Vitamin.PokemonId
            };
        }

        private void CopyToVitamin(VitaminsViewModel VitaminViewModel, Vitamins Vitamin)
        {
            Vitamin.VitId = VitaminViewModel.VitId;
            Vitamin.VitaminName = VitaminViewModel.VitaminName;
            Vitamin.ServingSize = VitaminViewModel.ServingSize;
            Vitamin.AboutVitamin = VitaminViewModel.AboutVitamin;
            Vitamin.RefillDate = VitaminViewModel.RefillDate;
            Vitamin.PokemonId = VitaminViewModel.PokemonId;
        }
    }
}