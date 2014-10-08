using System;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Repository.Contracts.User;

namespace Adwyze.Suggestme.Web.UnitTests.Stubs
{
    /// <summary>
    /// User repository stub
    /// </summary>
    public class StubUserRepository : IUserRepository
    {
        public StubUserRepository()
        {
            IsSaveInvoked = false;
            IsGetUserInvoked = false;
        }

        public User Get(string userid)
        {
            IsGetUserInvoked = true;
            return new User {Id = -1, UserId = "nimish"};
        }

        public void Save(User user)
        {
            IsSaveInvoked = true;
            if (OnSave != null)
                OnSave(user);
        }

        public bool IsSaveInvoked { get; set; }
        public bool IsGetUserInvoked { get; set; }

        public Action<User> OnSave;
    }
}