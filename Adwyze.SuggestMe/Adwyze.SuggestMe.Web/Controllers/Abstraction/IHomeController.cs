using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    /// <summary>
    /// Home controller
    /// </summary>
    public interface IHomeController
    {
        /// <summary>
        /// Login action
        /// </summary>
        /// <returns>View corresponding to the action</returns>
        ActionResult Login();

        /// <summary>
        /// Save details for user id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>Json corresponding to the action</returns>
        JsonResult Save(string userId);

        /// <summary>
        /// Logout action
        /// </summary>
        /// <returns>Json corresponding to the action</returns>
        JsonResult Logout();
    }
}