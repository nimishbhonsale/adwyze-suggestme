using System.Web.Mvc;
using Adwyze.SuggestMe.Entities.Artist;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Adwyze.SuggestMe.Repository.Contracts.User;
using DotLastFm;
using DotLastFm.Api;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    public class ArtistController : Controller, IArtistController
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILastFmConfig _config;

        public ArtistController()
        {
            _searchHistoryRepository = Bootstrapper.Container.Resolve <ISearchHistoryRepository>();
            _userRepository = Bootstrapper.Container.Resolve<IUserRepository>();
            _config = Bootstrapper.Container.Resolve<ILastFmConfig>();
        }
        public ArtistController(ISearchHistoryRepository searchHistoryRepository, ILastFmConfig config, IUserRepository userRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
            _userRepository = userRepository;
            _config = config;
        }

        // GET: Artist by name
        public ActionResult GetByName(string name, int page=1)
        {
            // todo: Return error page in case no userid in session.
            var userId = Session["UserId"] ;

            if (userId != null && !string.IsNullOrEmpty(userId.ToString()))
            {
                var user = new User {UserId = userId.ToString()};
                var history = new History {Keyword = name};

                _userRepository.Save(user);
                _searchHistoryRepository.AddHistoryForUser(user, history);
            }

            var lastFmApi = new LastFmApi(_config);
            var artistWithDetails = lastFmApi.Artist.GetInfo(name);
            var tracksForArtist = lastFmApi.Artist.GetTopTracks(artistWithDetails.Name, page, 15);
            var model = new Artist { ArtistDetails = artistWithDetails, Tracks = tracksForArtist };
            return View(model);
        }
    }

    public interface IArtistController
    {
        ActionResult GetByName(string name, int page = 1);
    }
}