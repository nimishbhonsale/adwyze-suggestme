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
    /// <summary>
    /// Wrapper over the Unity IoC container
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Provides intiial setup for registering the abstractions with concretes and manages its lifetime
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Setup()
        {
            // Instantiate Unity container
            var container = new UnityContainer();

            // Register Last Fm Service and config.
            container.RegisterType<ILastFmConfig, LastFmConfig>();
            container.RegisterType<ILastFmService, LastFmService>();

            // Regsitration in case the provider is mongo
            if (ConfigurationManager.AppSettings["Provider"] == ((int)DbProvider.Mongo).ToString(CultureInfo.InvariantCulture))
            {
                container.RegisterType<ISearchHistoryRepository, SearchHistoryRepository>();
                container.RegisterType<IUserRepository, UserRepository>();
                container.RegisterType<IConnectionManager, MongoConnectionManager>();
            }

            // Regsitration in case the provider is sql server
            if (ConfigurationManager.AppSettings["Provider"] == ((int)DbProvider.SqlServer).ToString(CultureInfo.InvariantCulture))
            {
                container.RegisterType<ISearchHistoryRepository, Repository.SqlServer.Search.SearchHistoryRepository>();
                container.RegisterType<IUserRepository, Repository.SqlServer.User.UserRepository>();
                container.RegisterType<IConnectionManager, SqlServerConnectionManager>();
            }

            // Register controllers
            container.RegisterType<IController, HomeController>("Home");
            container.RegisterType<IController, ArtistController>("Artist");
            container.RegisterType<IController, HistoryController>("History");

            // Set container
            Container = container;
            return container;
        }

        /// <summary>
        /// Instance of the Unity container
        /// </summary>
        public static UnityContainer Container { get; set; }
    }
}