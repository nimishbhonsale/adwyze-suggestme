using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers.Abstraction;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    /// <summary>
    /// Search history controller
    /// </summary>
    public class HistoryController : Controller, IHistoryController
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        /// <summary>
        /// Constructor that resolves dependencies from Untiy container
        /// </summary>
        public HistoryController()
        {
            _searchHistoryRepository = Bootstrapper.Container.Resolve<ISearchHistoryRepository>();
        }

        /// <summary>
        /// Constructor with dependencies injected
        /// </summary>
        /// <param name="searchHistoryRepository">Instance of <see cref="ISearchHistoryRepository"/></param>
        public HistoryController(ISearchHistoryRepository searchHistoryRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
        }

        /// <summary>
        /// Gets the history records corresponding to the user
        /// </summary>
        /// <returns>View corresponding to the action</returns>
        public ActionResult Get()
        {
            // Check if user has identified himself/herself
            var userId = Session!= null ? Session["UserId"]: "dummy";

            if (userId != null && !string.IsNullOrEmpty(userId.ToString()))
            {
                var user = new User {UserId = userId.ToString()};
             
                // Get the history from the repository
                var histories = _searchHistoryRepository.GetHistoryForUser(user);

                // Show view with history
                return View(histories);
            }

            // Redirect to the search action.
            return RedirectToAction("Login", "Home");
        }
    }
}