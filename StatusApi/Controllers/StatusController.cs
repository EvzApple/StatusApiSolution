using Microsoft.AspNetCore.Mvc;

namespace StatusApi.Controllers;

public class StatusController : ControllerBase
{
    //GET request http://localhost:5000/status
    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        var response = new StatusResponse { 
            Message = "The Server is great...Thanks", 
            LastChecked = DateTime.Now};
        return Ok(response);
    }
}


public class StatusResponse
{
    public string? Message { get; set; }
    public DateTime LastChecked { get; set; }
}