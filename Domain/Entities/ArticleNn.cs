namespace Domain.TechDoc.Entities;

public partial class ArticleNn
{
    public int Supplierid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;

    public string Newnbr { get; set; } = null!;

    public int Newsupplierid { get; set; }

    public string Newdatasupplierarticlenumber { get; set; } = null!;
}
