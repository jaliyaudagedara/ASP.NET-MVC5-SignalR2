using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetMvc5SignalR2Demo.Api.Hubs
{
    public static class ChatInfoHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class MyHub : Hub
    {
        public override Task OnConnected()
        {
            ChatInfoHandler.ConnectedIds.Add(Context.ConnectionId);
            return Clients.All.updateConnectedIds(ChatInfoHandler.ConnectedIds);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            ChatInfoHandler.ConnectedIds.Remove(Context.ConnectionId);
            return Clients.All.updateConnectedIds(ChatInfoHandler.ConnectedIds);
        }

        public void SendToAll(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public void SendToOthers(string name, string message)
        {
            Clients.Others.addNewMessageToPage(name, message);
        }

        public void SendToConnectionId(string connectionId, string name, string message)
        {
            Clients.Client(connectionId).addNewMessageToPage(name, message);
        }

        public void SendToGroup(string groupName, string name, string message)
        {
            Clients.Group(groupName).addNewMessageToPage(name, message);
        }

        public async Task JoinGroup(string groupName, string name)
        {
            await Groups.Add(Context.ConnectionId, groupName);
            Clients.Group(groupName).addNewMessageToPage(name, $"Joined the group {groupName}");
        }

        public async Task LeaveGroup(string groupName, string name)
        {
            await Groups.Remove(Context.ConnectionId, groupName);
            Clients.Group(groupName).addNewMessageToPage(name, $"Left the group {groupName}");
        }

        public List<string> GetSomeStrings()
        {
            return new List<string>() { "Apple", "Banana" };
        }
    }
}