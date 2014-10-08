using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    public interface IArtistController
    {
        ActionResult GetByName(string name, int page = 1);
    }
}