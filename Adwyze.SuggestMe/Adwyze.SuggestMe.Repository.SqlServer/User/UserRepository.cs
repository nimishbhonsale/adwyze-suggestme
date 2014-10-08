using System;
using System.Linq;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.SuggestMe.Repository.SqlServer.Mapping;

namespace Adwyze.SuggestMe.Repository.SqlServer.User
{
    /// <summary>
    /// User repository for sql server
    /// </summary>
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Get user coreesponding to the id
        /// </summary>
        /// <param name="userid">User identifier</param>
        /// <returns>User</returns>
        public Entities.User.User Get(string userid)
        {
            var user = new Entities.User.User();
            using (var db = new Mapping.Mapping())
            {
                var profile = db.Profiles.FirstOrDefault(x => x.UserId == userid);

                if (profile != null)
                {
                    user.UserId = profile.UserId;
                    user.Id = profile.Id;
                }
            }
            return user;
        }

        /// <summary>
        /// Saves the user to persistence store
        /// </summary>
        /// <param name="user">User</param>
        public void Save(Entities.User.User user)
        {
            using (var db = new Mapping.Mapping())
            {
                var profile = db.Profiles.FirstOrDefault(x => x.UserId == user.UserId);
                if (profile == null)
                {
                    var hist = new Profile
                    {
                        UserId = user.UserId,
                        UpdateDate = DateTime.UtcNow
                    };
                    db.Profiles.Add(hist);
                }
                else
                {
                    profile.UpdateDate = DateTime.UtcNow;
                }
                db.SaveChanges();
            }
        }
    }
}
