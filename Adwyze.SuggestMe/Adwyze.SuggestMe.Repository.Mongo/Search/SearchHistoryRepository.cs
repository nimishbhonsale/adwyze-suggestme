using System;
using System.Collections.Generic;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Repository.Contracts.Connection;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DomainUser = Adwyze.SuggestMe.Entities.User.User;

namespace Adwyze.SuggestMe.Repository.Mongo.Search
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly IConnectionManager _connectionManager;

        public SearchHistoryRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IList<History> GetHistoryForUser(DomainUser user)
        {
            var histories = new List<History>();
            var connectionString = _connectionManager.GetConnectionString();
            var client = new MongoClient(connectionString);
            var mongoServer = client.GetServer();
            var db = mongoServer.GetDatabase("suggestme");
            using (mongoServer.RequestStart(db))
            {
                var collection = db.GetCollection("users");
                var savedUser = collection.FindOne(Query.EQ("userid", user.UserId));
                if (savedUser != null && savedUser.Contains("history"))
                {
                    var asBsonArray = savedUser["history"].AsBsonArray;
                    foreach (var bson in asBsonArray)
                    {
                        var keyword = bson["keyword"].ToString();
                        var searchdate = bson["searchdate"].ToUniversalTime();
                        var history = new History {Keyword = keyword, SearchDate = searchdate};
                        histories.Add(history);
                    }
                }
            }
            return histories;
        }


        public void AddHistoryForUser(DomainUser user, History history)
        {
            var connectionString = _connectionManager.GetConnectionString();
            var client = new MongoClient(connectionString);
            var mongoServer = client.GetServer();
            var db = mongoServer.GetDatabase("suggestme");
            using (mongoServer.RequestStart(db))
            {
                var collection = db.GetCollection("users");
                var savedUser = collection.FindOne(Query.EQ("userid", user.UserId));
                if (savedUser != null && savedUser.Contains("history"))
                {
                    var doc = new BsonDocument { { "keyword", history.Keyword }, { "searchdate", DateTime.UtcNow } };
                    savedUser["history"].AsBsonArray.Add(doc);
                    collection.Save(savedUser);

                }
                else
                {
                    var userToAdd = new BsonDocument();
                    userToAdd["userid"] = user.UserId;
                    var doc = new BsonDocument {{"keyword", history.Keyword}, {"searchdate", DateTime.UtcNow}};
                    var hist = new BsonArray {doc};
                    userToAdd["history"] = hist;
                    collection.Insert(userToAdd);
                }
            }
        }
    }
}