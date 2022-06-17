using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DockerApp.Models
{
    [Table("weatherforecast")]
    public class WeatherForecast
    {
        [Key]
        [Column("forecast_id")]
        public int ForecastId { get; set; }

        [Column("forecast_date")]
        public DateTime ForecastDate { get; set; }

        [Column("forecast_temperature")]
        public float ForecastTemperature { get; set; }

        [Column("forecast_summary")]
        public string ForecastSummary { get; set; }
    }
}
