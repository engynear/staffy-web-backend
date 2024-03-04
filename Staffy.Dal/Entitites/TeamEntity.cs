namespace Staffy.Dal.Entitites;


public class TeamEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ImageUrl { get; set; }
}