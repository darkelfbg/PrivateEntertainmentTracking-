using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class AnimesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Animes Home Page";

            return View();
        }

        public ActionResult AddAnimes()
        {
            ViewBag.Message = "Add More Animes";

            return View();
        }

        public ActionResult AnimesLibrary()
        {
            ViewBag.Message = "Animes you have add";

            return View();
        }
       
    }
}
