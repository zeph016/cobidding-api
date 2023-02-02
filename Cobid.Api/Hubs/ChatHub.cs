using Microsoft.AspNetCore.SignalR;

namespace Cobid.Api.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string user, string messsage)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, messsage);
        }
    }
}
