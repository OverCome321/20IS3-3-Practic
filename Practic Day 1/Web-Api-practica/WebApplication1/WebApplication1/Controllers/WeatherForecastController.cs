using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Cool", "Warm", "Balmy", "Cool", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (name == null)
            {
                return BadRequest("��� �� ����� ���� ������");
            }
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index,string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("������ �� ����� ���� �������������");
            }
            if (name == null)
            {
                return BadRequest("��� �� ����� ��������� null");
            }
            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index <  0 || index >= Summaries.Count)
            {
                return BadRequest("������ �� ����� ���� �������������");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("index")]
        public string GetName(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "������ �� ����� ���� �������������";
            }
            return Summaries[index];
        }
        [HttpGet("find-by-name")]
        public int GetNames(string name)
        {
            return Summaries.Count(x => x == name);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll (int? sortStrategy)
        {
            try
            {
                if (sortStrategy == null)
                {

                }
                if (sortStrategy == 1)
                {
                    Summaries.Sort();

                }
                if (sortStrategy == -1)
                {
                    Summaries.Sort();
                    Summaries.Reverse();
                }
                return Ok();
            }
            catch
            {
                return BadRequest("������������ �������� ��������� sortStrategy");
            }
            
        }
    }
}