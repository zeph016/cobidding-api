namespace Cobid.Api.Connector;

public interface IHubConnector
{
    Task GetMessage(string message = null);
    Task GetLastMessage(ServiceResponse<Message> result);
    Task GetNewConversation(ServiceResponse<Conversation> result);
    Task CountParticipants(bool IsCount);
    Task UpdateAuctionEvent(bool isGet);

    //Auction Message Signals
    Task GetNewAuctionEventMessage(ServiceResponse<AuctionMessage> result);
    Task GetHighestAuctionBuid(bool IsGet);

    //Community Post Signals
    Task GetNewCommunityPost(bool isGet);
    Task GetNewCommunityPostMessage(bool isGet);
}
