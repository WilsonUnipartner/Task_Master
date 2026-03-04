namespace TaskMaster.Core.Domain;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int EmployeeId { get; set; }
    public TaskMaster.Core.Enums.TaskStatus Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? DueDateUtc { get; set; }
}

