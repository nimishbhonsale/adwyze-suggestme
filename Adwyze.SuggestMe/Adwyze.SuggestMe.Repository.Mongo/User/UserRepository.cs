
using Adwyze.SuggestMe.Repository.Contracts.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DomainUser = Adwyze.SuggestMe.Entities.User.User;
using Adwyze.SuggestMe.Repository.Contracts.User;

namespace Adwyze.SuggestMe.Repository.Mongo.User
{
    public class UserRepository : IUserRepository
    {
        
        private readonly IConnectionManager _connectionManager;

        public UserRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public DomainUser Get(string userid)
        {
            return new DomainUser{UserId = userid};
        }

        public void Save(DomainUser user)
        {
            var connectionString = _connectionManager.GetConnectionString();
            var client = new MongoClient(connectionString);
            var mongoServer = client.GetServer();
            var db = mongoServer.GetDatabase("suggestme");
            using (mongoServer.RequestStart(db))
            {
                var collection = db.GetCollection("users");
                var savedUser = collection.FindOne(Query.EQ("userid", user.UserId));
                if (savedUser == null)
                {
                    var userToAdd = new BsonDocument();
                    userToAdd["userid"] = user.UserId;
                    var hist = new BsonArray ();
                    userToAdd["history"] = hist;
                    collection.Insert(userToAdd);
                }
            }
        }
    }
}