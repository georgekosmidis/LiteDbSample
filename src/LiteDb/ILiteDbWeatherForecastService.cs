using System.Collections.Generic;

namespace LiteDbSample.LiteDb;

public interface ILiteDbWeatherForecastService
{
    bool Delete(int id);
    IEnumerable<WeatherForecast> FindAll();
    WeatherForecast FindOne(int id);
    int Insert(WeatherForecast forecast);
    bool Update(WeatherForecast forecast);
}