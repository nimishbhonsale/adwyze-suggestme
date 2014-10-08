using System.Web.Mvc;

namespace Adwyze.SuggestMe.Controllers.Abstraction
{
    /// <summary>
    /// Abstraction for artist controller
    /// </summary>
    public interface IArtistController
    {
        /// <summary>
        /// Gets and artist by name
        /// </summary>
        /// <param name="name">Any keyword corresponding to the artist name</param>
        /// <param name="page">Page number for the search request</param>
        /// <returns>Action result corresponding to the action</returns>
        ActionResult GetByName(string name, int page = 1);
    }
}