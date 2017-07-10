using System.Web;
using System.Web.Http;

namespace AspNetMvc5SignalR2Demo.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}