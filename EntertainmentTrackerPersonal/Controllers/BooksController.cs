using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Books Home";

            return View();
        }

        public ActionResult AddBooks()
        {
            ViewBag.Message = "Too sexy";

            return View();
        }

        public ActionResult BooksLibrary()
        {
            ViewBag.Message = "Please Just dont";

            return View();
        }
       
       
    }
}
