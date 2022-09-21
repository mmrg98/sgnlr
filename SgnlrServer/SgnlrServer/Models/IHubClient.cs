namespace SgnlrServer.Models
{
    public interface IHubClient
    {
        Task BroadcastCustumer(int i);
    }
}
