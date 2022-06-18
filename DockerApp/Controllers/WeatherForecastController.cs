using DockerApp.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DockerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherContext _context; 

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public IActionResult Get()
        {
            IActionResult result = null;
            try
            {
                var forecasts = _context.WeatherForecast.ToList();
                result = Ok(forecasts);
            }
            catch
            {
                result = BadRequest();
            }
            return result;
        }
    }
}
