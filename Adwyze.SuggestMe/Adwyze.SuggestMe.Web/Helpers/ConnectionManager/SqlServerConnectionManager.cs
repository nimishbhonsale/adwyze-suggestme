using System.Configuration;
using Adwyze.SuggestMe.Repository.Contracts.Connection;

namespace Adwyze.SuggestMe.Helpers.ConnectionManager
{
    /// <summary>
    /// Sql Server Connection Manager
    /// </summary>
    public class SqlServerConnectionManager : IConnectionManager
    {
        /// <summary>
        /// Gets the connection string for Sql Server
        /// </summary>
        /// <returns>Connection string</returns>
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["SqlDbConnection"];
        }
    }
}