using Microsoft.AspNetCore.SignalR;

namespace SignalR_Interface_Argument_Deserialization_Issue;

public class EmptyHub(ILogger<EmptyHub> logger) : Hub
{
    public void HubMethodThatWillFail(III message)
    {
        logger.LogInformation(message.GetType().Name);
    }

    public void HubMethod2(IEnumerable<III> message)
    {
        logger.LogInformation(string.Join(", ", message.Select(x => x.GetType().Name)));
    }

    public void HubMethod3(W message)
    {
        logger.LogInformation(message.Data.GetType().Name);
    }

    public override Task OnConnectedAsync()
    {
        logger.LogInformation("Connected: {id}", Context.ConnectionId);
        return base.OnConnectedAsync();
    }
}
