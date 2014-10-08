using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    /// <summary>
    /// Hisotry controller
    /// </summary>
    public interface IHistoryController
    {
        /// <summary>
        /// Gets the history
        /// </summary>
        /// <returns>View corresponding to the action</returns>
        ActionResult Get();
    }
}