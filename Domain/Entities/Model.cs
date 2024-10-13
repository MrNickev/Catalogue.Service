using System.Diagnostics;
using Domain.TechDoc.Entities.Abstractions;
using Domain.TechDoc.Enums;

namespace Domain.TechDoc.Entities;

public partial class Model : ModelTypedEntity
{
    public long Id { get; set; }

    public string? Canbedisplayed { get; set; }

    public string? Constructioninterval { get; set; }

    public string? Description { get; set; }

    public string? Fulldescription { get; set; }

    public string? Haslink { get; set; }
    public bool HasLink => Haslink == "True";

    

    public long? Manufacturerid { get; set; }
}
