using DomainUser=Adwyze.SuggestMe.Entities.User.User;

namespace Adwyze.SuggestMe.Repository.Contracts.User
{
    public interface IUserRepository
    {
        DomainUser Get(string userid);
        void Save(DomainUser user);
    }
}