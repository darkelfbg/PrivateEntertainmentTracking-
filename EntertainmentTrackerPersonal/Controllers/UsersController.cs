using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;


namespace EntertainmentTrackerPersonal.Controllers
{

    public class UsersController : Controller
    {
        public ActionResult UserHome()
        {
            if(User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "This Is the user Home Page";

                return View();
            }

            return RedirectToAction("Login", "Home");
        }
    }
}

