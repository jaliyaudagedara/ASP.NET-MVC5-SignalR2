using AspNetMvc5SignalR2Demo.Api.Hubs;
using Microsoft.AspNet.SignalR;
using System.Web.Http;

namespace AspNetMvc5SignalR2Demo.Api.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Post()
        {
            IHubContext myHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            myHub.Clients.All.addNewMessageToPage("System", "Invoked from outside");
            return Ok();
        }
    }
}
