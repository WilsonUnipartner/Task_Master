namespace TaskMaster.Core.Domain;

public class Notification
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
    public bool IsRead { get; set; }
    public string Type { get; set; } = string.Empty;
    public int TaskId { get; set; }
}

