namespace Domain.TechDoc.Entities;

public partial class SupplierDetail
{
    public int Supplierid { get; set; }

    public string? Addresstype { get; set; }

    public string Addresstypeid { get; set; } = null!;

    public string? City1 { get; set; }

    public string? City2 { get; set; }

    public string? Countrycode { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public string? Homepage { get; set; }

    public string? Name1 { get; set; }

    public string? Name2 { get; set; }

    public string? Postalcodecity { get; set; }

    public string? Postalcodepob { get; set; }

    public string? Postalcodewholesaler { get; set; }

    public string? Postalcountrycode { get; set; }

    public string? Postofficebox { get; set; }

    public string? Street1 { get; set; }

    public string? Street2 { get; set; }

    public string? Telephone { get; set; }
}
