using Adwyze.SuggestMe.Entities.Artist;
using Adwyze.SuggestMe.Helpers.Container;
using DotLastFm;
using DotLastFm.Api;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Services
{
    /// <summary>
    /// Last Fm Service 
    /// </summary> 
    public class LastFmService : ILastFmService
    {
        private readonly ILastFmConfig _config;

        /// <summary>
        /// Construction which resolves dependencies using Unity container
        /// </summary>
        public LastFmService()
        {
            _config = Bootstrapper.Container.Resolve<ILastFmConfig>();
        }

        /// <summary>
        /// Construction which resolves dependencies using injection
        /// </summary>
        public LastFmService(ILastFmConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Service that retrieves the data from last fm store using the API
        /// </summary>
        /// <param name="name">Artist name</param>
        /// <param name="page">Page for search</param>
        /// <returns>Valid Artist if exists</returns>
        public Artist GetArtistByName(string name, int page=1)
        {
            // Create instance of lastFm Api
            var lastFmApi = new LastFmApi(_config);

            // Get artist info
            var artistWithDetails = lastFmApi.Artist.GetInfo(name);
            // Get artist tracks
            var tracksForArtist = lastFmApi.Artist.GetTopTracks(artistWithDetails.Name, page, 15);

            // Compose model
            var model = new Artist { ArtistDetails = artistWithDetails, Tracks = tracksForArtist };

            // Return the model
            return model;
        }
    }
}