using AutoMapper;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities.Flowchart.Attributes;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using ElsaServer.Context;
using ElsaServer.Migrations;
using ElsaServer.Model;

namespace ElsaServer.CustomActivity;

public class CreateIdeaActivity : Activity
{
    public CreateIdeaActivity () {}
   
    // Input
    public Input<IdeaModel> IdeaRequest { get; set; }
    
    // Output
    public Output<Guid> IdeaId { get; set; } = default!;
    public Output<Guid?> ReviewerId { get; set; } = default!;
    
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var _dbContext = context.GetRequiredService<MyDbContext>();
        var _mapper = context.GetRequiredService<IMapper>();
        try
        {
            var IdeaRequestConvert = IdeaRequest.Get(context);
            Console.WriteLine("Idea from request::", IdeaRequestConvert);
            Console.WriteLine(IdeaRequestConvert.EnglishName);
            
            var ideas = _mapper.Map<Idea>(IdeaRequestConvert);
            
            Console.WriteLine("Mapper success");
            ideas.CreatedDate = DateTime.UtcNow;
            ideas.CreatedBy = ideas.OwnerId.ToString();
            ideas.UpdatedDate = DateTime.UtcNow;
            ideas.UpdatedBy = ideas.OwnerId.ToString();
            ideas.IsDeleted = false;
            
            _dbContext.Ideas.Add(ideas);
            await _dbContext.SaveChangesAsync();
            
            // Set output
            IdeaId.Set(context, ideas.Id);
            ReviewerId.Set(context, ideas.MentorId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        await context.CompleteActivityAsync();

    }
}