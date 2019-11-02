using System;

namespace LiteDbSample
{
    public class WeatherForecast
    {
        public int Id { get; set; }//New addition, Id wasn't there

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
