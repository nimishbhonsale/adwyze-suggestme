using System;
using System.Linq;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Repository.SqlServer.Mapping;
using DomainUser = Adwyze.SuggestMe.Entities.User.User;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using System.Collections.Generic;

namespace Adwyze.SuggestMe.Repository.SqlServer.Search
{
    /// <summary>
    /// Search repository for sql server
    /// </summary>
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        /// <summary>
        /// Gets the history for user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <returns>History records corresponding to the user</returns>
        public IList<History> GetHistoryForUser(DomainUser user)
        {
            var histories = new List<History>();

            using (var db = new Mapping.Mapping())
            {
                var profile = db.Profiles.FirstOrDefault(x => x.UserId == user.UserId);
                if (profile != null)
                {
                    foreach (var history in profile.SearchHistories)
                    {
                        var hist = new History
                        {
                            Id = history.Id,
                            Keyword = history.Keyword,
                            SearchDate = history.UpdateDate.Value
                        };
                        histories.Add(hist);
                    }
                }
            }

            return histories;
        }

        /// <summary>
        /// Adds history record for the user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <param name="history">History record</param>
        public void AddHistoryForUser(DomainUser user, History history)
        {
            using (var db = new Mapping.Mapping())
            {
                var profile = db.Profiles.FirstOrDefault(x => x.UserId == user.UserId);
                if (profile != null)
                {
                    var hist = new SearchHistory
                    {
                        Keyword = history.Keyword,
                        UpdateDate = DateTime.UtcNow
                    };
                    profile.SearchHistories.Add(hist);
                }
                db.SaveChanges();
            }
        }
    }
}
