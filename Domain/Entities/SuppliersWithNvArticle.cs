namespace Domain.TechDoc.Entities;

public partial class SuppliersWithNvArticle
{
    public short Id { get; set; }

    public short? Dataversion { get; set; }

    public string? Description { get; set; }

    public string? Matchcode { get; set; }

    public long? Nbrofarticles { get; set; }

    public string? Hasnewversionarticles { get; set; }
}
