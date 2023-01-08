using Microsoft.AspNetCore.SignalR;

namespace CarDealerWebAPI.HubConfig
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string senderId,string receiverId,string message)
        {
            return Clients.All.SendAsync("receiveMessage",senderId,receiverId,message);
        }
    }
}
