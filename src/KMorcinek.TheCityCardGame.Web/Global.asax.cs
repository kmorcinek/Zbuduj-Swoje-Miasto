using System.Web.Http;

namespace KMorcinek.TheCityCardGame.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SerilogConfiguration.Configure();
        }
    }
}
