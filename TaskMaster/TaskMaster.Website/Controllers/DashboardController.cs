using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    // GET: /api/dashboard
    // Intended for admin dashboard data. Interns can replace the sample with real aggregates.
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Admin Dashboard GET endpoint placeholder. Interns should calculate task metrics here.",
            totals = new
            {
                totalTasks = 0,
                overdue = 0,
                inReview = 0
            }
        });
    }
}

