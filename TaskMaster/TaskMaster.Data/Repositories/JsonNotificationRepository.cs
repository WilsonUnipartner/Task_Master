using System.Text.Json;
using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;

namespace TaskMaster.Data.Repositories;

public class JsonNotificationRepository : INotificationRepository
{
    private readonly string _notificationsFilePath;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public JsonNotificationRepository(string notificationsFilePath)
    {
        _notificationsFilePath = notificationsFilePath;
    }

    public IReadOnlyCollection<Notification> GetForEmployee(int employeeId)
    {
        if (!File.Exists(_notificationsFilePath))
        {
            return Array.Empty<Notification>();
        }

        var json = File.ReadAllText(_notificationsFilePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return Array.Empty<Notification>();
        }

        var items = JsonSerializer.Deserialize<List<Notification>>(json, _options) ?? new List<Notification>();
        return items.Where(n => n.EmployeeId == employeeId).ToArray();
    }
}

