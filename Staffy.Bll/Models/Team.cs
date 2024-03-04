namespace Staffy.Bll.Models;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ImageUrl { get; set; }
}