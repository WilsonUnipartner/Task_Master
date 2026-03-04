using System.Text.Json;
using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;
using TaskMaster.Core.Enums;

namespace TaskMaster.Data.Repositories;

public class JsonTaskRepository : ITaskRepository
{
    private readonly string _tasksFilePath;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public JsonTaskRepository(string tasksFilePath)
    {
        _tasksFilePath = tasksFilePath;
    }

    public IReadOnlyCollection<TaskItem> GetAll()
    {
        if (!File.Exists(_tasksFilePath))
        {
            return Array.Empty<TaskItem>();
        }

        var json = File.ReadAllText(_tasksFilePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return Array.Empty<TaskItem>();
        }

        var items = JsonSerializer.Deserialize<List<TaskItemJson>>(json, _options) ?? new List<TaskItemJson>();
        return items.Select(Map).ToArray();
    }

    private static TaskItem Map(TaskItemJson dto)
    {
        return new TaskItem
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            EmployeeId = dto.EmployeeId,
            Status = ParseStatus(dto.Status),
            CreatedAtUtc = dto.CreatedAtUtc,
            DueDateUtc = dto.DueDateUtc
        };
    }

    private static TaskMaster.Core.Enums.TaskStatus ParseStatus(string status)
    {
        return Enum.TryParse<TaskMaster.Core.Enums.TaskStatus>(status, ignoreCase: true, out var value)
            ? value
            : TaskMaster.Core.Enums.TaskStatus.Backlog;
    }

    private sealed class TaskItemJson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? DueDateUtc { get; set; }
    }
}

