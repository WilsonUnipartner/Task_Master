using TaskMaster.Core.Domain;

namespace TaskMaster.Core.Abstractions;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskItem> GetAll();
}

