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
        var task = Task.Run(async () =>
        {
            var findParts = await searchService.FindPart(article + name);
            if (findParts is not null)
                return findParts.Select(item => new PartDto(item.Name, item.Price, null, item.ImageLinks));
            
            return new List<PartDto>();
        });

        return await task;
        
    }
}