using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData() { Id = 1, Data = "11.04.2022", Degree = 10, Location = "Москва"},
            new WeatherData() { Id = 2, Data = "27.11.2022", Degree = -60, Location = "Якутия"},
            new WeatherData() { Id = 3, Data = "16.07.2022", Degree = 19, Location = "Омск"},
            new WeatherData() { Id = 4, Data = "18.01.2023", Degree = -20, Location = "Тула"},
            new WeatherData() { Id = 5, Data = "22.02.2023", Degree = -1, Location = "Тверь"},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public List<WeatherData> GetAll()
        {
            return weatherDatas;
        }

        [HttpGet("id")]
        public IActionResult GetName(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            if (data == null)
            {
                return BadRequest("Null значение");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("Запись с таким id уже есть");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if(weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpGet("location")]
        public IActionResult GetByCity(string location)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Location == location)
                {
                    return Ok();
                }
            }
            return BadRequest("Город не найден");
        }
    }
}