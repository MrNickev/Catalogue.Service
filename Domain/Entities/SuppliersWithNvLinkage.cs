namespace Domain.TechDoc.Entities;

public partial class SuppliersWithNvLinkage
{
    public int Id { get; set; }

    public int? Dataversion { get; set; }

    public string? Description { get; set; }

    public string? Matchcode { get; set; }

    public long? Nbrofarticles { get; set; }

    public string? Hasnewversionarticles { get; set; }
}
