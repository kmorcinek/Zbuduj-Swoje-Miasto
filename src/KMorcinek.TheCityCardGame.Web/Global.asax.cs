using System.Web.Http;

namespace KMorcinek.TheCityCardGame.Web
{
#pragma warning disable SA1649 // File name must match first type name
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SerilogConfiguration.Configure();
        }
    }
}
