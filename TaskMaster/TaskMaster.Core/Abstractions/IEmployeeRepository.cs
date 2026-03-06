using TaskMaster.Core.Domain;

namespace TaskMaster.Core.Abstractions;

public interface IEmployeeRepository
{
    IReadOnlyCollection<Employee> GetAll();
    Employee? GetById(int id);
}

