using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    // GET: /api/notification
    // Interns can extend this to read notifications from JSON via a service.
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Notification GET endpoint placeholder. Interns should return notification center items from DataStore.",
            notifications = Array.Empty<object>()
        });
    }
}

