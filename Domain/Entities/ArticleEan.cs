namespace Domain.TechDoc.Entities;

public partial class ArticleEan
{
    public int Supplierid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;

    public string Ean { get; set; } = null!;
}
