namespace Domain.TechDoc.Entities;

public partial class PassangerCarTree
{
    public long Passangercarid { get; set; }

    public long Searchtreeid { get; set; }

    public long Id { get; set; }

    public long? Parentid { get; set; }

    public string? Description { get; set; }
}
