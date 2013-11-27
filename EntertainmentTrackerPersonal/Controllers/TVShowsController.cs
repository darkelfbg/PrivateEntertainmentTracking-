using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class TVShowsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This Message comes from the controlelr and i dont like it";

            return View();
        }

        public ActionResult AddTVShows()
        {
            ViewBag.Message = "Too sexy";

            return View();
        }

        public ActionResult TVShowsLibrary()
        {
            ViewBag.Message = "Please Just dont";

            return View();
        }
       
    }
}
