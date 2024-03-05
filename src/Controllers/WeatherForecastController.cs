using LiteDbSample.LiteDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LiteDbSample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ILiteDbWeatherForecastService _forecastDbService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ILiteDbWeatherForecastService forecastDbService)
    {
        _forecastDbService = forecastDbService;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _forecastDbService.FindAll();
    }

    [HttpGet("{id}", Name = "FindOne")]
    public ActionResult<WeatherForecast> Get(int id)
    {
        var result = _forecastDbService.FindOne(id);
        return result != default ? (ActionResult<WeatherForecast>)Ok(result) : (ActionResult<WeatherForecast>)NotFound();
    }

    [HttpPost]
    public ActionResult<WeatherForecast> Insert(WeatherForecast dto)
    {
        var id = _forecastDbService.Insert(dto);
        return id != default ? (ActionResult<WeatherForecast>)CreatedAtRoute("FindOne", new { id = id }, dto) : (ActionResult<WeatherForecast>)BadRequest();
    }

    [HttpPut]
    public ActionResult<WeatherForecast> Update(WeatherForecast dto)
    {
        var result = _forecastDbService.Update(dto);
        return result ? (ActionResult<WeatherForecast>)NoContent() : (ActionResult<WeatherForecast>)NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult<WeatherForecast> Delete(int id)
    {
        var result = _forecastDbService.Delete(id);
        return result ? (ActionResult<WeatherForecast>)NoContent() : (ActionResult<WeatherForecast>)NotFound();
    }
}
