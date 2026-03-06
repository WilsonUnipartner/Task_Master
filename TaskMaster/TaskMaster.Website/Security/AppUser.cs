namespace TaskMaster.Website.Security;

public class AppUser
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; // Plain text for training only
    public string Role { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public string DisplayName { get; set; } = string.Empty;
}

