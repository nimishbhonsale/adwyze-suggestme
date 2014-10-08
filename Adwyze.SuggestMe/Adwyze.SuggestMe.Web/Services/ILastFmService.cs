using Adwyze.SuggestMe.Entities.Artist;

namespace Adwyze.SuggestMe.Services
{
    /// <summary>
    /// Last Fm Service abstraction
    /// </summary>
    public interface ILastFmService
    {
        /// <summary>
        /// Service that retrieves the data from last fm store using the API
        /// </summary>
        /// <param name="name">Artist name</param>
        /// <param name="page">Page for search</param>
        /// <returns>Valid Artist if exists</returns>
        Artist GetArtistByName(string name, int page = 1);
    }
}