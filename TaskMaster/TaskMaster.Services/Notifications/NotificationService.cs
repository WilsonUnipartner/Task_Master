using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;

namespace TaskMaster.Services.Notifications;

public class NotificationService
{
    private readonly INotificationRepository _notifications;

    public NotificationService(INotificationRepository notifications)
    {
        _notifications = notifications;
    }

    public IReadOnlyCollection<Notification> GetForEmployee(int employeeId)
    {
        return _notifications.GetForEmployee(employeeId);
    }
}

