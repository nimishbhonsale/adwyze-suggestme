using System.Collections.Generic;
using Adwyze.SuggestMe.Entities.History;
using DomainUser=Adwyze.SuggestMe.Entities.User.User;

namespace Adwyze.SuggestMe.Repository.Contracts.Search
{
    public interface ISearchHistoryRepository
    {
        IList<History> GetHistoryForUser(DomainUser user);
        void AddHistoryForUser(DomainUser user, History history);
    }
}