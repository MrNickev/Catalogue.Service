namespace Domain.TechDoc.Entities;

public partial class ArticleRn
{
    public int Supplierid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;

    public string Replacenbr { get; set; } = null!;

    public int Replacedupplierid { get; set; }

    public string Replacedatasupplierarticlenumber { get; set; } = null!;
}
