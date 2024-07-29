using Aplication.Ozon.Abstractions;
using Aplication.Ozon.Models;
using Application.Common.Abstractions;
using Application.Common.Models.Dto;

namespace Aplication.Ozon.Services;

/// <summary>
/// Сервис поиска товара на Ozon
/// </summary>
public class OzonSearchService(IOzonRequestService searchService) : ISearcherService
{

    public async Task<IEnumerable<PartDto>> FindPartAsync(string? article, string? name)
    {

        var result = await searchService.FindPart(article + name);       
        
        var task = Task.Run(() => new PartDto[] { new PartDto("abc", 125, article) });

        return await task;
        
    }
}