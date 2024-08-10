using Application.Common.Models;

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
    public Task<IEnumerable<PartItem>> FindPartAsync(SearchData data);
    
}