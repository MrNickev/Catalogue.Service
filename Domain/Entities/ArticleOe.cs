namespace Domain.TechDoc.Entities;

public partial class ArticleOe
{
    public int Supplierid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;

    public string IsAdditive { get; set; } = null!;

    public string Oenbr { get; set; } = null!;

    public long ManufacturerId { get; set; }
}
