using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    public interface IHistoryController
    {
        ActionResult Get();
    }
}