using TaskMaster.Core.Abstractions;
using TaskMaster.Data.Repositories;
using TaskMaster.Services.TaskManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddScoped<TaskDashboardService>();

builder.Services.AddSingleton<ITaskRepository>(sp =>
{
    var env = sp.GetRequiredService<IHostEnvironment>();
    var dataStorePath = Path.Combine(env.ContentRootPath, "..", "DataStore");
    var tasksFile = Path.Combine(dataStorePath, "Tasks.json");
    return new JsonTaskRepository(tasksFile);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapControllers();

app.Run();
