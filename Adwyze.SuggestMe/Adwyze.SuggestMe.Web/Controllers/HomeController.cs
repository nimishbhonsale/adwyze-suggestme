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
        /// <summary>
        /// User repository
        /// </summary>
        public IUserRepository UserRepository { get; private set; }

        /// <summary>
        /// Constructor that resolves dependencies from Unity container
        /// </summary>
        public HomeController()
        {
            UserRepository = Bootstrapper.Container.Resolve<IUserRepository>();
        }

        /// <summary>
        /// Constructor that resolves dependencies injection
        /// </summary>
        public HomeController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        /// <summary>
        /// Login action
        /// </summary>
        /// <returns>Json corresponding to the action</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Save details for user id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>Json corresponding to the action</returns>
        [HttpPost]
        public JsonResult Save(string userId)
        {
            // Save the user session id
            if (Session!=null)
            Session["UserId"] = userId;

            // Save user to repository if it does not exist
            var user = new User { UserId = userId };
            UserRepository.Save(user);

            // Return json
            return Json(new { sessionid = userId});
        }

        /// <summary>
        /// Logout action
        /// </summary>
        /// <returns>Json corresponding to the action</returns>
        [HttpPost]
        public JsonResult Logout()
        {
            // Nullify the user session id
            if (Session != null)
            Session["UserId"] = null;

            // Return json
            return Json(new { sessionid = string.Empty });
        }
    }
}