namespace Domain.TechDoc.Entities;

public partial class Language
{
    public int Id { get; set; }

    public int? Codepage { get; set; }

    public string? Description { get; set; }

    public string? Isocode2 { get; set; }
}
