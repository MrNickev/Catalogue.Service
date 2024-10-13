namespace Domain.TechDoc.Entities;

public partial class Country
{
    public string Countrycode { get; set; } = null!;

    public string? Currencycode { get; set; }

    public string? Description { get; set; }

    public string? Isgroup { get; set; }

    public string? Isocode2 { get; set; }

    public string? Isocode3 { get; set; }

    public string? Isocodeno { get; set; }
}
