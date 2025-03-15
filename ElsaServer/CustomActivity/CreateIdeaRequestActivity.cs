using AutoMapper;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Models;
using ElsaServer.Context;
using ElsaServer.Migrations;
using ElsaServer.Model;

namespace ElsaServer.CustomActivity;

public class CreateIdeaRequestActivity : Activity
{
    public CreateIdeaRequestActivity() {}

    public Input<Guid> ReviewerId { get; set; } 
    public Input<Guid> IdeaId { get; set; } 
    public Output<Guid> IdeaRequestId { get; set; }
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var _mapper = context.GetRequiredService<IMapper>();
        var _dbContext = context.GetRequiredService<MyDbContext>();
        try
        {
            var models = new IdeaRequestModel
            {
                ReviewerId = ReviewerId.Get(context),
                IdeaId = IdeaId.Get(context),
                Content = ""
            };
            var entity = _mapper.Map<IdeaRequest>(models);
            entity.ProcessDate = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.Status = "Pending";
            _dbContext.IdeaRequests.Add(entity);
            
            
            IdeaRequestId.Set(context, entity.Id);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await context.CompleteActivityAsync();
        }
    }
}