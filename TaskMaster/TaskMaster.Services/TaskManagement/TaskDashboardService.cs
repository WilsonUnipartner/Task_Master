using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;
using TaskMaster.Core.Enums;

namespace TaskMaster.Services.TaskManagement;

public class TaskDashboardService
{
    private readonly ITaskRepository _repository;

    public TaskDashboardService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskDashboardViewModel GetCurrentWeekDashboard()
    {
        var allTasks = _repository.GetAll();

        var now = DateTime.UtcNow;
        var startOfWeek = now.Date.AddDays(-(int)now.DayOfWeek);
        var endOfWeek = startOfWeek.AddDays(7);

        var weekTasks = allTasks
            .Where(t => t.CreatedAtUtc >= startOfWeek &&
                        t.CreatedAtUtc < endOfWeek)
            .OrderBy(t => t.CreatedAtUtc)
            .ToList();

        return new TaskDashboardViewModel
        {
            TotalAssignments = allTasks.Count,
            TasksInProgress = allTasks.Count(t =>
                t.Status is TaskMaster.Core.Enums.TaskStatus.Analyzing
                    or TaskMaster.Core.Enums.TaskStatus.Implementing
                    or TaskMaster.Core.Enums.TaskStatus.Review),
            CompletedTasks = allTasks.Count(t =>
                t.Status == TaskMaster.Core.Enums.TaskStatus.Done),
            WeekTasks = weekTasks
        };
    }
}

public class TaskDashboardViewModel
{
    public int TotalAssignments { get; set; }
    public int TasksInProgress { get; set; }
    public int CompletedTasks { get; set; }
    public IReadOnlyCollection<TaskItem> WeekTasks { get; set; } = Array.Empty<TaskItem>();
}

