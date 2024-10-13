using Microsoft.IdentityModel.Logging;

namespace Domain.TechDoc.Entities.Abstractions;

public abstract class Vehicle : ModelTypedEntity
{
    public long Id { get; set; }

    public string? Canbedisplayed { get; set; }

    public string? Constructioninterval { get; set; }

    public string? Description { get; set; }

    public string? Fulldescription { get; set; }

    public string? Haslink { get; set; }
    public bool HasLink => Haslink == "True";

    public string? Iscvmanufacturerid { get; set; }
    public bool IsCvmanufacturerId => Iscvmanufacturerid == "True";
    
    public long? Modelid { get; set; }
    
}

