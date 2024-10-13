using Domain.TechDoc.Entities.Abstractions;

namespace Application.Dtos;

public class VehicleDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string ConstructionInterval { get; set; }

    public VehicleDto()
    {
    }

    public VehicleDto(long id, string name, string constructionInterval)
    {
        Id = id;
        Name = name;
        ConstructionInterval = constructionInterval;
    }

    public VehicleDto(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Name = vehicle.Description;
        ConstructionInterval = vehicle.Constructioninterval;
    }
}