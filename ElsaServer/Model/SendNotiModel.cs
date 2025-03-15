namespace ElsaServer.Model;

public class SendNotiModel
{
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public int Type { get; set; }
    public bool IsRead { get; set; }
}