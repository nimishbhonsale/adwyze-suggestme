using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Adwyze.SuggestMe.Repository.Contracts.Connection;

namespace Adwyze.SuggestMe.Helpers.ConnectionManager
{
    public class MongoConnectionManager : IConnectionManager
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DbConnection"];
        }
    }
}