using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Destributed;

/// <summary>
/// Контроллер для поиска ТС
/// </summary>
[ApiController]
[Route("vehicles")]
public class VehicleSearcherController(IVehicleSearchService searchService) : ControllerBase
{
    /// <summary>
    /// Сервис поиска ТС по базе 
    /// </summary>
    private readonly IVehicleSearchService _searchService = searchService;
    
    
    /// <summary>
    /// Поиск марки (пр-ва) по части названия
    /// </summary>
    /// <param name="manufacture">Название производства по которому искать</param>
    /// <param name="limit">Лимит результатов поиска</param>
    /// <param name="offset">Сдвиг поиска</param>
    /// <returns>Список найденных марок (производств)</returns>
    [Route("manufacturers")]
    [HttpGet]
    public IActionResult FindManufacturers(string manufactureName, int limit = 100, int offset = 0)
    {
        var manufacturers = _searchService.FindManufacturers(manufactureName, limit, offset);
        
        return Ok(manufacturers);
    }

    
    /// <summary>
    /// Поиск моделей 
    /// </summary>
    /// <param name="manufactureId"></param>
    /// <param name="limit">Лимит результатов поиска</param>
    /// <param name="offset">Сдвиг поиска</param>
    /// <returns></returns>
    [Route("models")]
    [HttpGet]
    public IActionResult FindModels(long manufactureId, string modelName, int limit = 100, int offset = 0)
    {
        var models = _searchService.FindModel(manufactureId, modelName, limit, offset);
        return Ok(models);
    }

    /// <summary>
    /// Поиск комплектаций
    /// </summary>
    /// <param name="modelId"></param>
    /// <param name="limit">Лимит результатов поиска</param>
    /// <param name="offset">Сдвиг поиска</param>
    /// <returns></returns>
    [Route("versions")]
    [HttpGet]
    public IActionResult FindVersions([FromQuery] long modelId, int limit = 100, int offset = 0)
    {
        try
        {
            var versions = _searchService.FindVehicleVersion(modelId, limit, offset);
            return Ok(versions);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}