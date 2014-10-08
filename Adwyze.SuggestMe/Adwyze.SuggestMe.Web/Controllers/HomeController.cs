using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers.Abstraction;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        public IUserRepository UserRepository { get; private set; }

        public HomeController()
        {
            UserRepository = Bootstrapper.Container.Resolve<IUserRepository>();
        }

        // GET: Home page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(string userId)
        {
            if (Session!=null)
            Session["UserId"] = userId;
            var user = new User { UserId = userId };
            UserRepository.Save(user);
            return Json(new { sessionid = userId});
        }

        [HttpPost]
        public JsonResult Logout()
        {
            if (Session != null)
            Session["UserId"] = null;
            return Json(new { sessionid = string.Empty });
        }
    }
}