using System.Text.Json;

namespace TaskMaster.Website.Security;

public interface IAppUserStore
{
    Task<AppUser?> ValidateCredentialsAsync(string username, string password);
}

public class JsonAppUserStore : IAppUserStore
{
    private readonly string _usersFilePath;
    private readonly Lazy<Task<IReadOnlyList<AppUser>>> _usersLoader;

    public JsonAppUserStore(IHostEnvironment env)
    {
        var dataStorePath = Path.Combine(env.ContentRootPath, "..", "DataStore");
        _usersFilePath = Path.Combine(dataStorePath, "Users.json");
        _usersLoader = new Lazy<Task<IReadOnlyList<AppUser>>>(LoadUsersAsync);
    }

    public async Task<AppUser?> ValidateCredentialsAsync(string username, string password)
    {
        var users = await _usersLoader.Value;
        return users.FirstOrDefault(u =>
            string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);
    }

    private async Task<IReadOnlyList<AppUser>> LoadUsersAsync()
    {
        if (!File.Exists(_usersFilePath))
        {
            return Array.Empty<AppUser>();
        }

        await using var stream = File.OpenRead(_usersFilePath);
        var users = await JsonSerializer.DeserializeAsync<List<AppUser>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return users ?? new List<AppUser>();
    }
}

