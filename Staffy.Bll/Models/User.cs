namespace Staffy.Bll.Models;

public enum Role
{
    Unspecified,
    Admin,
    User
}

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
}