using Microsoft.AspNetCore.SignalR;

namespace SgnlrServer.Models
{
    public class BroadCastHub: Hub<IHubClient>
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}
