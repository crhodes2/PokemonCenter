using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week8_WebApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A Center for all Pokemon";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the webmaster today";

            return View();
        }

        public ActionResult Appt()
        {
            ViewBag.Message = "Set up an appointment with a nurse today";

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Groom()
        {
            ViewBag.Message = "Finest grooming service at an affordable price";

            return View();
        }

        public ActionResult Health()
        {
            ViewBag.Message = "Your Pokemon's health is very important to us";

            return View();
        }

        public ActionResult Pest()
        {
            ViewBag.Message = "Our 24/7 pest control specialty is always on-call";

            return View();
        }
    }
}