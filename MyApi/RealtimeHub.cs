using Microsoft.AspNetCore.SignalR;
public class RealtimeHub:Hub
{
    public override async Task OnConnectedAsync(){
        var user=Context.GetHttpContext()?.Request.Query["user"];

        await Groups.AddToGroupAsync(Context.ConnectionId,user);

        await base.OnConnectedAsync();
    }

    public async Task SendPrivateMessage(string receiver,string sender,string message)
    {
        await Clients.Group(receiver).SendAsync("ReceiveMessage",sender,message);
    }
}