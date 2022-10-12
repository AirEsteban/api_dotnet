using Api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_dotnet.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;
        public ITimeService _timeService;
        public TimeController(ITimeService time, ILogger<TimeController> log)
        {
            this._timeService = time;
            this._logger = log;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this._logger.LogDebug("Getting the local datetime.");
            return Ok(this._timeService.GetDateTime());
        }
    }
