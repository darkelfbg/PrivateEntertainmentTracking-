using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using EntertainmentTrackerPersonal.Models;
using EntertainmentTrackerPersonal.WebHelpers;
using UserService;

namespace EntertainmentTrackerPersonal.Controllers
{
    public class HomeController : Controller
    {
        WebServiceHelper _webHelper = new WebServiceHelper();

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            string requestUrl = ConfigurationManager.AppSettings["RequestUrlForGet"] + userModel.UserName;

            User user = _webHelper.GetUserData(requestUrl);

            if ((user != null) && userModel.IsValid(user))
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
