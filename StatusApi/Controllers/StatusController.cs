using Microsoft.AspNetCore.Mvc;
using StatusApi.Services;

namespace StatusApi.Controllers;

public class StatusController : ControllerBase
{
    private readonly ISystemTime _systemTime;

    public StatusController(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    //GET request http://localhost:5000/status
    [ResponseCache(Duration = 120)]
    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        var response = new StatusResponse { 
            Message = "The Server is great...Thanks", 
            LastChecked = _systemTime.GetCurrent()};
        return Ok(response);
    }
}


public class StatusResponse
{
    public string? Message { get; set; }
    public DateTime LastChecked { get; set; }
}