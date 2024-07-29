using Application.Common.Abstractions;
using Application.Common.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace PartsSearcherController;

[ApiController]
[Route("parts")]
public class PartSearcherController(IEnumerable<ISearcherService> services) : ControllerBase
{
    
    /// <summary>
    /// Поиск запчасти по артикулу и/или названию
    /// </summary>
    /// <param name="article"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Find(string? article, string? name)
    {
        if (article is null && name is null)
            return BadRequest("Должен быть указан хотя бы один параметр");

        var searchResults = new Dictionary<string, IEnumerable<PartDto>>();
        var tasks = new List<Task>();
        foreach (var service in services)
        {
            tasks.Add(Task.Run(async () =>
            {
                var search = await service.FindPartAsync(article, name);
                lock (searchResults)
                {
                    searchResults[service.GetType().Name] = search;
                }
            }));
        }

        await Task.WhenAll(tasks);
        
        return Ok(searchResults);
    }
}