using Microsoft.AspNetCore.Mvc;
using TaskMaster.Services.TaskManagement;

namespace TaskMaster.Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly TaskDashboardService _dashboardService;

    public HomeController(TaskDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    // GET: /api/home
    [HttpGet]
    public ActionResult<TaskDashboardViewModel> Get()
    {
        var dashboard = _dashboardService.GetCurrentWeekDashboard();
        return Ok(dashboard);
    }
}

