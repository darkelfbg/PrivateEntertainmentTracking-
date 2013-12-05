using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using DataObjects;
using EntertainmentTrackerPersonal.WebHelpers;
using WebMatrix.WebData;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class HomeController : Controller
    {
        WebServiceHelper _webHelper = new WebServiceHelper();

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            string requestUrl = ConfigurationManager.AppSettings["RequestUrlForGet"];

            var status = _webHelper.GetUserData(requestUrl,userModel);

            if (status == UserServiceStatusCode.Ok)
            {
                    FormsAuthentication.SetAuthCookie(userModel.UserName, userModel.RememberMe);
                    return RedirectToAction("UserHome", "Users");
            }

            return View();
        }
        
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserHome", "Users");
            }

            return View();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
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
