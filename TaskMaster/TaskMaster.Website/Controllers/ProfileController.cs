using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    // GET: /api/profile
    // Interns can extend this to return real profile data from Core/Data/Services.
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Profile GET endpoint placeholder. Interns should wire this to employee profile data.",
            sample = new
            {
                employeeId = 1,
                fullName = "Sample User",
                completedTasks = 0,
                inProgressTasks = 0
            }
        });
    }
}

