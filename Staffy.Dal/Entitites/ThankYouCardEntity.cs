namespace Staffy.Dal.Entitites;

public class ThankYouCardEntity
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
    public string Message { get; set; }
    public DateTimeOffset SendDate { get; set; }
}