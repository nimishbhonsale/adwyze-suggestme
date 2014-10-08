using System.Configuration;
using Adwyze.SuggestMe.Repository.Contracts.Connection;

namespace Adwyze.SuggestMe.Helpers.ConnectionManager
{
    /// <summary>
    /// Mongo Connection Manager
    /// </summary>
    public class MongoConnectionManager : IConnectionManager
    {
        /// <summary>
        /// Gets the connection string for Mongo
        /// </summary>
        /// <returns>Connection string</returns>
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DbConnection"];
        }
    }
}