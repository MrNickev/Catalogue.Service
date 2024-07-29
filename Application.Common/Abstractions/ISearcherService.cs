using Application.Common.Models.Dto;

namespace Application.Common.Abstractions;

/// <summary>
/// Сервис поиска запчасти
/// </summary>
public interface ISearcherService
{
    /// <summary>
    /// Поиск запчасти по артикулу и названию
    /// </summary>
    /// <param name="article">Артикул</param>
    /// <param name="name">Название</param>
    /// <returns>Коллекцию найденных товаров</returns>
    public Task<IEnumerable<PartDto>> FindPartAsync(string? article, string? name);
    
}