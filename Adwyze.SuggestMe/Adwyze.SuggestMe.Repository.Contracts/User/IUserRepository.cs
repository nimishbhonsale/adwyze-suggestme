using DomainUser=Adwyze.SuggestMe.Entities.User.User;

namespace Adwyze.SuggestMe.Repository.Contracts.User
{
    /// <summary>
    /// User repository abstraction
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get user coreesponding to the id
        /// </summary>
        /// <param name="userid">User identifier</param>
        /// <returns>User</returns>
        DomainUser Get(string userid);

        /// <summary>
        /// Saves the user to persistence store
        /// </summary>
        /// <param name="user">User</param>
        void Save(DomainUser user);
    }
}