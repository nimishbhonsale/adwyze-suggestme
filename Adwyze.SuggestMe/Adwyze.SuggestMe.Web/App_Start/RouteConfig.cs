using System.Web.Mvc;
using System.Web.Routing;

namespace Adwyze.SuggestMe
{
    /// <summary>
    /// Specifies the configuration for the route table
    /// </summary>
    public class RouteConfig
    {
    /// <summary>
    /// Resgister the rules for routign the request in the route collection.
    /// </summary>
    /// <param name="routes">Route collection</param>
    public static void RegisterRoutes(RouteCollection routes)
    {
        // Ignore route
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Map route
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
