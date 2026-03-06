using TaskMaster.Core.Domain;

namespace TaskMaster.Core.Abstractions;

public interface INotificationRepository
{
    IReadOnlyCollection<Notification> GetForEmployee(int employeeId);
}

