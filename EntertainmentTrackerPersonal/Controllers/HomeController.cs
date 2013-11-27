using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Too sexy";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please Just dont";

            return View();
        }
       
    }
}
