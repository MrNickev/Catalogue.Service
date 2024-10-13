namespace Domain.TechDoc.Entities;

public partial class ArticleLink
{
    public int Supplierid { get; set; }

    public int Productid { get; set; }

    public int Linkagetypeid { get; set; }

    public long Linkageid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;
}
