using DockerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerApp.DB
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
        }
    }
}
