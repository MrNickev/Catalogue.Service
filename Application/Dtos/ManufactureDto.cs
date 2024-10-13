using Domain.TechDoc.Entities;

namespace Application.Dtos;

/// <summary>
/// DTO для марки
/// </summary>
public class ManufactureDto
{
    /// <summary>
    /// Идентификатор марки
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Название марки
    /// </summary>
    public string? Name { get; set; } 
    
    public ManufactureDto()
    {
    }

    public ManufactureDto(long id, string? name)
    {
        Id = id;
        Name = name;
    }

    public ManufactureDto(Manufacturer manufacturer)
    {
        Id = manufacturer.Id;
        Name = manufacturer.Description;
    }
}