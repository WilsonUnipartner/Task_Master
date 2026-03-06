using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;

namespace TaskMaster.Services.EmployeeProfile;

public class EmployeeService
{
    private readonly IEmployeeRepository _employees;
    private readonly ITaskRepository _tasks;

    public EmployeeService(IEmployeeRepository employees, ITaskRepository tasks)
    {
        _employees = employees;
        _tasks = tasks;
    }

    public Employee? GetEmployee(int employeeId) => _employees.GetById(employeeId);

    public IReadOnlyCollection<TaskItem> GetTasksForEmployee(int employeeId)
    {
        return _tasks.GetAll()
            .Where(t => t.EmployeeId == employeeId)
            .ToArray();
    }
}

