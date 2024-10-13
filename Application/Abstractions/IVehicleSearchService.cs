using Application.Dtos;
using Domain.TechDoc.Entities;
using Domain.TechDoc.Entities.Abstractions;

namespace Application.Abstractions;

/// <summary>
/// Интерфейс сервиса поиска ТС
/// </summary>
public interface IVehicleSearchService
{
    /// <summary>
    /// Поиск марки (пр-ва)
    /// </summary>
    /// <param name="manufacture">Название марки (по нему идет поиск)</param>
    /// <param name="limit">Лимит результатов</param>
    /// <param name="offset">Сдвиг результатов</param>
    /// <returns>Список марок, соответствующих запросу</returns>
    List<ManufactureDto> FindManufacturers(string manufacture, int limit = 100, int offset = 0);

    /// <summary>
    /// Поиск модели, соответствующей указанной марки и названию модели
    /// </summary>
    /// <param name="manufactureId">Id марки</param>
    /// <param name="modelName">Название модели (полное или частичное)</param>
    /// <param name="limit">Лимит результатов</param>
    /// <param name="offset">Сдвиг результатов</param>
    /// <returns>Список моделей, соответствующих запросу</returns>
    List<ModelDto> FindModel(long manufactureId, string modelName = "", int limit = 100, int offset = 0);


    /// <summary>
    /// Поиск комплектаций (версий) ТС модели
    /// </summary>
    /// <param name="modelId">ID модели</param>
    /// <param name="limit">Лимит результатов</param>
    /// <param name="offset">Сдвиг результатов</param>
    /// <returns>Список комплектаций, соответствующих запросу</returns>
    List<VehicleDto> FindVehicleVersion(long modelId, int limit = 100, int offset = 0);
}