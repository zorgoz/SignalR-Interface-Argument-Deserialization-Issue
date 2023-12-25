using Microsoft.AspNetCore.SignalR.Client;
using SignalR_Interface_Argument_Deserialization_Issue;

var builder = WebApplication.CreateSlimBuilder();

builder.Services.AddSignalR(o => o.EnableDetailedErrors = true);

var app = builder.Build();
app.Urls.Add("http://localhost:3000");

app.MapHub<EmptyHub>("/hub");

var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:3000/hub")
            .Build();

await app.StartAsync();

await connection.StartAsync();

try
{
    III x1 = new C1 { A = 100 };
    III x2 = new C2 { B = 100 };

    await connection.InvokeAsync(nameof(EmptyHub.HubMethod3), new W(x1)); // ok
    await connection.InvokeAsync(nameof(EmptyHub.HubMethod3), new W(x2)); // ok
    await connection.InvokeAsync(nameof(EmptyHub.HubMethod2), new[] { x1, x2 }); // ok
    await connection.InvokeAsync(nameof(EmptyHub.HubMethodThatWillFail), x1); // will fail

    await Task.Delay(1000);
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "Problem");
}
finally
{
    await app.StopAsync();
}