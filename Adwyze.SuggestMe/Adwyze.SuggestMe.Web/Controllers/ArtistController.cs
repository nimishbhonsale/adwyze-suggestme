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

        /// <summary>
        /// Constructor which resolves explicitly from Unity IoC
        /// </summary>
        public ArtistController()
        {
            _searchHistoryRepository = Bootstrapper.Container.Resolve <ISearchHistoryRepository>();
            _userRepository = Bootstrapper.Container.Resolve<IUserRepository>();
            _lastFmService = Bootstrapper.Container.Resolve<ILastFmService>(); ;
        }

        /// <summary>
        /// Constructor - Inject dependencies
        /// </summary>
        /// <param name="searchHistoryRepository">Instance of <see cref="ISearchHistoryRepository"/></param>
        /// <param name="lastFmService">Instance of <see cref="ILastFmService"/></param>
        /// <param name="userRepository">Instance of <see cref="IUserRepository"/></param>
        public ArtistController(ISearchHistoryRepository searchHistoryRepository, ILastFmService lastFmService, IUserRepository userRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
            _userRepository = userRepository;
            _lastFmService = lastFmService;
        }

        
        /// <summary>
        /// Gets and artist by name
        /// </summary>
        /// <param name="name">Any keyword corresponding to the artist name</param>
        /// <param name="page">Page number for the search request</param>
        /// <returns>Action result corresponding to the action</returns>
        public ActionResult GetByName(string name, int page=1)
        {
            // Check for a valid session
            var userId = Session != null ? Session["UserId"] : "dummy";

            // Check if the user has identified herself/himself.
            if (userId != null && !string.IsNullOrEmpty(userId.ToString()))
            {

                var user = new User {UserId = userId.ToString()};
                var history = new History {Keyword = name};

                // Save the user details to repository if it does not exist
                _userRepository.Save(user);

                // Add history entry to repository
                _searchHistoryRepository.AddHistoryForUser(user, history);
            }

            // Retrieve the artists results from last fm API.
            var model = _lastFmService.GetArtistByName(name);

            // Show the view
            return View(model);
        }
    }
}