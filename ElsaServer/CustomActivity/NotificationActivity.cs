using System.Text;
using System.Text.Json;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Models;
using ElsaServer.Model;

namespace ElsaServer.CustomActivity;

public class NotificationActivity : Activity
{
    public NotificationActivity() {}
    
    public Input<Guid> NotiUserId { get; set; }
    public Input<string> Content { get; set; }
    public Input<int> NotiType { get; set; }
    public Input<string> AccessToken {get;set;}
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        try
        {
            var httpClient = context.GetRequiredService<HttpClient>();
            var json = new SendNotiModel
            {
                UserId = NotiUserId.Get(context),
                Description = Content.Get(context),
                IsRead = false,
                Type = NotiType.Get(context)
            };
            
            var requestPayload = JsonSerializer.Serialize(json);
            var content = new StringContent(requestPayload, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", AccessToken.Get(context));
            var response = await httpClient.PostAsync("http://localhost:8081/api/notifications", content);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await context.CompleteActivityAsync();
    }
}