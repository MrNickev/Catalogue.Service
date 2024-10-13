namespace Domain.TechDoc.Entities;

public partial class EnginePrd
{
    public long Id { get; set; }

    public string Assemblygroupdescription { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Normalizeddescription { get; set; } = null!;

    public string Usagedescription { get; set; } = null!;
}
