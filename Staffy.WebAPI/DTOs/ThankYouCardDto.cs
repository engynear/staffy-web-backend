namespace StaffyWebAPI.DTOs;

public class ThankYouCardDto
{
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
    public string Message { get; set; }
}