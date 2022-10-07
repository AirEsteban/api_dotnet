using Microsoft.AspNetCore.Mvc;

namespace Api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(_forecasts == null || !_forecasts.Any())
        {
            _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    public List<WeatherForecast> GetForecasts()
    {
        return _forecasts;
    }

    public void SetForecasts(WeatherForecast weather)
    {
        _forecasts.Add(weather);
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("/api/[controller]")]
    public IEnumerable<WeatherForecast> Get()
    {
        return GetForecasts();
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weather){
        try
        {
            this.SetForecasts(weather);
            return Ok();
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        try
        {
            _forecasts.RemoveAt(index);
            return Ok();
        }
        catch(IndexOutOfRangeException ex){
            return BadRequest("The index that you want to delete does not exist. " +
                "Please select another one.");
        }
        catch(Exception ex)
        {
            return Problem(ex.Message.ToString());
        } 
    }
}
