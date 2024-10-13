namespace Domain.TechDoc.Entities;

public partial class CommercialVehicleTree
{
    public int Commercialvehicleid { get; set; }

    public int Searchtreeid { get; set; }

    public int Id { get; set; }

    public int? Parentid { get; set; }

    public string? Description { get; set; }
}
