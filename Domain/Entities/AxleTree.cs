namespace Domain.TechDoc.Entities;

public partial class AxleTree
{
    public long Axleid { get; set; }

    public long Searchtreeid { get; set; }

    public long Id { get; set; }

    public long? Parentid { get; set; }

    public string? Description { get; set; }
}
