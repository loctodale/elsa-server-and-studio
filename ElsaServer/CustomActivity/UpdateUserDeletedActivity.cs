using System.Data.Entity;
using System.Diagnostics;
using Elsa.Extensions;
using Elsa.Workflows;
using ElsaServer.Context;
using Activity = Elsa.Workflows.Activity;

namespace ElsaServer.CustomActivity;

public class UpdateUserDeletedActivity : Activity
{
    private readonly MyDbContext _dbContext;

    public UpdateUserDeletedActivity()
    {
        _dbContext = new MyDbContext();
    }

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var userId = Guid.Parse("83ed7308-2ec1-4844-9ef0-c8e31face8bd");
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
        {
            Console.WriteLine($"User with ID {userId} not found.");
            return;
        }

        Console.WriteLine($"User found: {user.Username}");
        
        user.IsDeleted = !user.IsDeleted;
        await _dbContext.SaveChangesAsync();

        await context.CompleteActivityAsync();
    }
}



