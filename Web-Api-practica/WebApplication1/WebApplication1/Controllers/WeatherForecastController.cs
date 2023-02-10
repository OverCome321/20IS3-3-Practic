using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (name == null)
            {
                return BadRequest("Имя не может быть пустым");
            }
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index,string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Индекс не может быть отрицательным");
            }
            if (name == null)
            {
                return BadRequest("Имя не может равняться null");
            }
            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index <  0 || index >= Summaries.Count)
            {
                return BadRequest("Индекс не может быть отрицательным");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetName(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Индекс не может быть отрицательным";
            }
            return Summaries[index];
        }
    }
}