using System.Collections.Generic;
using Adwyze.SuggestMe.Entities.History;
using DomainUser=Adwyze.SuggestMe.Entities.User.User;

namespace Adwyze.SuggestMe.Repository.Contracts.Search
{
    /// <summary>
    /// Search Repositoty Abstraction
    /// </summary>
    public interface ISearchHistoryRepository
    {
        /// <summary>
        /// Gets the history for user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <returns>History records corresponding to the user</returns>
        IList<History> GetHistoryForUser(DomainUser user);

        /// <summary>
        /// Adds history record for the user
        /// </summary>
        /// <param name="user">User dto</param>
        /// <param name="history">History record</param>
        void AddHistoryForUser(DomainUser user, History history);
    }
}