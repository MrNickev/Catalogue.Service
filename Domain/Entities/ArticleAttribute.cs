namespace Domain.TechDoc.Entities;

public partial class ArticleAttribute
{
    public int Supplierid { get; set; }

    public string Datasupplierarticlenumber { get; set; } = null!;

    public int Id { get; set; }

    public string? Description { get; set; }

    public string Displaytitle { get; set; } = null!;

    public string Displayvalue { get; set; } = null!;
}
