using System.Configuration;
using System.Globalization;
using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers;
using Adwyze.SuggestMe.Helpers.Config;
using Adwyze.SuggestMe.Helpers.ConnectionManager;
using Adwyze.SuggestMe.Repository.Contracts.Connection;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.SuggestMe.Repository.Mongo.Search;
using Adwyze.SuggestMe.Repository.Mongo.User;
using Adwyze.SuggestMe.Services;
using DotLastFm.Api;
using Microsoft.Practices.Unity;

namespace Adwyze.SuggestMe.Helpers.Container
{
    public class Bootstrapper
    {
        public static IUnityContainer Setup()
        {
            var container = new UnityContainer();
            container.RegisterType<ILastFmConfig, LastFmConfig>();

            if (ConfigurationManager.AppSettings["Provider"] == ((int)DbProvider.Mongo).ToString(CultureInfo.InvariantCulture))
            {
                container.RegisterType<ISearchHistoryRepository, SearchHistoryRepository>();
                container.RegisterType<IUserRepository, UserRepository>();
                container.RegisterType<IConnectionManager, MongoConnectionManager>();
                container.RegisterType<ILastFmService, LastFmService>();
            }

            if (ConfigurationManager.AppSettings["Provider"] == ((int)DbProvider.SqlServer).ToString(CultureInfo.InvariantCulture))
            {
                container.RegisterType<ISearchHistoryRepository, Repository.SqlServer.Search.SearchHistoryRepository>();
                container.RegisterType<IUserRepository, Repository.SqlServer.User.UserRepository>();
                container.RegisterType<IConnectionManager, SqlServerConnectionManager>();
            }

            container.RegisterType<IController, HomeController>("Home");
            container.RegisterType<IController, ArtistController>("Artist");
            container.RegisterType<IController, HistoryController>("History");
            Container = container;
            return container;
        }

        public static UnityContainer Container { get; set; }
    }
}