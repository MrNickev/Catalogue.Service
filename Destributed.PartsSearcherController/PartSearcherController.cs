using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Abstractions;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PartsSearcherController;

[ApiController]
[Route("parts")]
public class PartSearcherController(IEnumerable<ISearcherService> services, ILogger<PartSearcherController> logger) : ControllerBase
{

    private readonly ILogger _logger = logger;
    
    /// <summary>
    /// Поиск запчасти по артикулу и/или названию
    /// </summary>
    /// <param name="article"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Find([FromQuery]SearchData data)
    {
        if (data.IsEmpty())
            return BadRequest("Должен быть указан хотя бы один параметр");

     
        var searchResults = new Dictionary<string, IEnumerable<PartItem>>();
        var tasks = new List<Task>();
        foreach (var service in services)
        {
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    var search = await service.FindPartAsync(data);
                    lock (searchResults)
                    {
                        searchResults[service.GetType().Name] = search;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Catched exception in service {service.GetType().Name}");
                }
                
            }));
        }

        await Task.WhenAll(tasks);
        
        return Ok(searchResults);
    }
}