namespace ElsaServer.Model;

public class IdeaRequestModel
{
    public Guid? IdeaId { get; set; }

    public Guid? ReviewerId { get; set; }

    public string? Content { get; set; }
  
}