using System.Text.Json;
using TaskMaster.Core.Abstractions;
using TaskMaster.Core.Domain;

namespace TaskMaster.Data.Repositories;

public class JsonEmployeeRepository : IEmployeeRepository
{
    private readonly string _employeesFilePath;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public JsonEmployeeRepository(string employeesFilePath)
    {
        _employeesFilePath = employeesFilePath;
    }

    public IReadOnlyCollection<Employee> GetAll()
    {
        if (!File.Exists(_employeesFilePath))
        {
            return Array.Empty<Employee>();
        }

        var json = File.ReadAllText(_employeesFilePath);
        if (string.IsNullOrWhiteSpace(json))
        {
            return Array.Empty<Employee>();
        }

        var items = JsonSerializer.Deserialize<List<Employee>>(json, _options) ?? new List<Employee>();
        return items.ToArray();
    }

    public Employee? GetById(int id)
    {
        return GetAll().FirstOrDefault(e => e.Id == id);
    }
}

