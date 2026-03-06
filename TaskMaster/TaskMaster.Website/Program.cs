using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using AspNet.Security.OAuth.GitHub;
using TaskMaster.Core.Abstractions;
using TaskMaster.Data.Repositories;
using TaskMaster.Services.TaskManagement;
using TaskMaster.Website.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddScoped<TaskDashboardService>();
builder.Services.AddSingleton<IAppUserStore, JsonAppUserStore>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? string.Empty;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? string.Empty;
    })
    .AddGitHub(options =>
    {
        options.ClientId = builder.Configuration["Authentication:GitHub:ClientId"] ?? string.Empty;
        options.ClientSecret = builder.Configuration["Authentication:GitHub:ClientSecret"] ?? string.Empty;
        options.Scope.Add("user:email");
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Conventional routing for MVC controllers such as AccountController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
