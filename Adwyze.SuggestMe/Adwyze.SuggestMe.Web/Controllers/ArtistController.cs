using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers.Abstraction;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.SuggestMe.Services;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    public class ArtistController : Controller, IArtistController
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILastFmService _lastFmService;

        public ArtistController()
        {
            _searchHistoryRepository = Bootstrapper.Container.Resolve <ISearchHistoryRepository>();
            _userRepository = Bootstrapper.Container.Resolve<IUserRepository>();
            
        }
        public ArtistController(ISearchHistoryRepository searchHistoryRepository, ILastFmService lastFmService, IUserRepository userRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
            _userRepository = userRepository;
            _lastFmService = lastFmService;
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
            var model = _lastFmService.GetArtistByName(name);
            return View(model);
        }
    }
}