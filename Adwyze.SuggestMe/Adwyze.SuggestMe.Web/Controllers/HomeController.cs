using System.Web.Mvc;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private readonly IUserRepository _userRepository;

        public HomeController()
        {
            _userRepository = Bootstrapper.Container.Resolve<IUserRepository>();
        }

        // GET: Home page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(string userId)
        {
            Session["UserId"] = userId;
            var user = new User { UserId = userId };
            _userRepository.Save(user);
            return Json(new { sessionid = userId});
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Session["UserId"] = null;
            return Json(new { sessionid = string.Empty });
        }
    }

    public interface IHomeController
    {
        ActionResult Login();
        JsonResult Save(string userId);
        JsonResult Logout();
    }
}