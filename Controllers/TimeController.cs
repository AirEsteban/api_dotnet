using Api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_dotnet.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        public ITimeService _timeService;
        public TimeController(ITimeService time)
        {
            this._timeService = time;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._timeService.GetDateTime());
        }
    }
