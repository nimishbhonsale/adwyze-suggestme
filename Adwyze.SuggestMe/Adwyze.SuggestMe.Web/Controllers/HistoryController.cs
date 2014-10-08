using System;
using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers.Abstraction;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Controllers
{
    public class HistoryController : Controller, IHistoryController
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        public HistoryController()
        {
            _searchHistoryRepository = Bootstrapper.Container.Resolve<ISearchHistoryRepository>();
        }

        // GET: Get all the history records
        public ActionResult Get()
        {
            var userId = Session["UserId"];

            if (userId != null && !string.IsNullOrEmpty(userId.ToString()))
            {
                var user = new User {UserId = userId.ToString()};
                var histories = _searchHistoryRepository.GetHistoryForUser(user);
                return View(histories);
            }
            return RedirectToAction("Login", "Home");
        }
    }
}