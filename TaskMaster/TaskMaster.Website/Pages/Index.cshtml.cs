using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskMaster.Services.TaskManagement;

namespace TaskMaster.Website.Pages;

public class IndexModel : PageModel
{
    private readonly TaskDashboardService _dashboardService;

    public IndexModel(TaskDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public TaskDashboardViewModel Dashboard { get; private set; } = new();

    public void OnGet()
    {
        Dashboard = _dashboardService.GetCurrentWeekDashboard();

    }
}
