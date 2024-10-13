using Application.Abstractions;
using Application.Dtos;
using Domain.TechDoc;
using Domain.TechDoc.Entities.Abstractions;
using Domain.TechDoc.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

/// <summary>
/// Сервис поиска автомобилей по базе TechDoc
/// </summary>
internal class TechDocVehicleSearchService(TechDocContext context) : IVehicleSearchService
{
    /// <inheritdoc/>>
    public List<ManufactureDto> FindManufacturers(string manufacture, int limit = 100, int offset = 0)
    {
        var manufactures = context.Manufacturers
            .Where(m => m.Description.Contains(manufacture))
            .Skip(offset)
            .Take(limit)
            .Select(m => new ManufactureDto(m))
            .ToList();

        return manufactures;
    }

    /// <inheritdoc/>>
    public List<ModelDto> FindModel(long manufactureId, string modelName = "", int limit = 100, int offset = 0)
    {
        var models = context.Models
            .Where(m => m.Manufacturerid == manufactureId && m.Description.Contains(modelName))
            .Skip(offset)
            .Take(limit)
            .Select(m => new ModelDto(m))
            .ToList();

        return models;
    }

    /// <inheritdoc/>>
    public List<VehicleDto> FindVehicleVersion(long modelId, int limit = 100, int offset = 0)
    {
        var model = context.Models.FirstOrDefault(m => m.Id == modelId);
        if (model == null)
            throw new KeyNotFoundException("Нет производителя с таким идентификатором");
        
        return (model.Type switch
        {
            ModelType.PassengerCar => GetVehicleById(context.PassangerCars, modelId, limit, offset),
            ModelType.Motorbike => GetVehicleById(context.Motorbikes, modelId, limit, offset),
            ModelType.Axle => GetVehicleById(context.Axles, modelId, limit, offset),
            ModelType.CommercialVehicle => GetVehicleById(context.CommercialVehicles, modelId, limit, offset),

            _ => null
        })!;
    }

    private List<VehicleDto> GetVehicleById<T>(DbSet<T> vehicles, long modelId, int limit, int offset) where T : Vehicle
    {
        return vehicles.Where(pc => pc.Modelid == modelId)
            .Skip(offset)
            .Take(limit)
            .Select(v => new VehicleDto(v))
            .ToList();
    }
    
}