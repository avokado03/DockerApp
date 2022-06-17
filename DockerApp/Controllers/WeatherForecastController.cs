using DockerApp.DB;
using DockerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Get()
        {
            var forecasts = _context.WeatherForecast.ToList();
            return Ok(forecasts);
        }
    }
}
