using System.Configuration;
using Adwyze.SuggestMe.Repository.Contracts.Connection;

namespace Adwyze.SuggestMe.Helpers.ConnectionManager
{
    public class SqlServerConnectionManager : IConnectionManager
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["SqlDbConnection"];
        }
    }
}