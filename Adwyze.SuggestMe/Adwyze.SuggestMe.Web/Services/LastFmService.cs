using Adwyze.SuggestMe.Entities.Artist;
using Adwyze.SuggestMe.Helpers.Container;
using DotLastFm;
using DotLastFm.Api;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Services
{
    public class LastFmService : ILastFmService
    {
        private readonly ILastFmConfig _config;
        public LastFmService()
        {
            _config = Bootstrapper.Container.Resolve<ILastFmConfig>();
        }
        public Artist GetArtistByName(string name, int page=1)
        {
            var lastFmApi = new LastFmApi(_config);
            var artistWithDetails = lastFmApi.Artist.GetInfo(name);
            var tracksForArtist = lastFmApi.Artist.GetTopTracks(artistWithDetails.Name, page, 15);
            var model = new Artist { ArtistDetails = artistWithDetails, Tracks = tracksForArtist };
            return model;
        }
    }
}