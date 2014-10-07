using System.Web.Mvc;
using System.Web.Routing;
using Adwyze.SuggestMe.Helpers.Container;

namespace Adwyze.SuggestMe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Setup();
        }
    }
}
