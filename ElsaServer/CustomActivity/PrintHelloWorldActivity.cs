using Elsa.Workflows;
using Elsa.Extensions;
namespace ElsaServer.CustomActivity;

public class PrintHelloWorldActivity : Activity
{
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        Console.WriteLine("Hello World!");
        await context.CompleteActivityAsync();
    }
}