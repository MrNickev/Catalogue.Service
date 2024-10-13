using Domain.TechDoc.Entities.Abstractions;

namespace Domain.TechDoc.Entities;

public partial class Motorbike : Vehicle
{
    public long Id { get; set; }

    public string? Canbedisplayed { get; set; }

    public string? Constructioninterval { get; set; }

    public string? Description { get; set; }

    public string? Fulldescription { get; set; }

    public string? Haslink { get; set; }

    public string? Isaxle { get; set; }

    public string? Iscommercialvehicle { get; set; }

    public string? Iscvmanufacturerid { get; set; }

    public string? Isengine { get; set; }

    public string? Ismotorbike { get; set; }

    public string? Ispassengercar { get; set; }

    public string? Istransporter { get; set; }

    public long? Modelid { get; set; }
}
