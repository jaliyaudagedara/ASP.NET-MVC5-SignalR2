using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(AspNetMvc5SignalR2Demo.Api.Startup))]

namespace AspNetMvc5SignalR2Demo.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            //// Branch the pipeline here for requests that start with "/signalr
            //app.Map("/signalr", map =>
            //{
            //    map.UseCors(CorsOptions.AllowAll);
            //    map.RunSignalR();
            //});
        }
    }
}
