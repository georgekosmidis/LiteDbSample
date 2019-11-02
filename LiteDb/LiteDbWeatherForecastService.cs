using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteDbSample.LiteDb
{
    public class LiteDbWeatherForecastService : ILiteDbWeatherForecastService
    {

        private LiteDatabase _liteDb;

        public LiteDbWeatherForecastService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<WeatherForecast> FindAll()
        {
            var result = _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .FindAll();
            return result;
        }

        public WeatherForecast FindOne(int id)
        {
            return _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(WeatherForecast forecast)
        {
            return _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .Insert(forecast);
        }

        public bool Update(WeatherForecast forecast)
        {
            return _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .Update(forecast);
        }

        public int Delete(int id)
        {
            return _liteDb.GetCollection<WeatherForecast>("WeatherForecast")
                .Delete(x => x.Id == id);
        }
    }

}
