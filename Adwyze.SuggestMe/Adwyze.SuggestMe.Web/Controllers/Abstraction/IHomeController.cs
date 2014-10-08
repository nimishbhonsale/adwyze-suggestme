using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    public interface IHomeController
    {
        ActionResult Login();
        JsonResult Save(string userId);
        JsonResult Logout();
    }
}