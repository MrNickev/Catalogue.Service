namespace Domain.TechDoc.Entities;

public partial class ArticleInf
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public string InformationText { get; set; } = null!;

    public string InformationType { get; set; } = null!;

    public int InformationTypeKey { get; set; }
}
