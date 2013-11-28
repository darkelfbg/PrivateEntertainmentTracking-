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
            string requestUrl = ConfigurationManager.AppSettings["RequestUrl"] + userModel.UserName;

            User user = _webHelper.GetUserData(requestUrl, "GET");

            if ((user != null) && userModel.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(userModel.UserName, userModel.RememberMe);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

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
