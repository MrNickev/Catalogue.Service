namespace Domain.TechDoc.Entities;

public partial class ArticleImage
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public string AdditionalDescription { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string DocumentName { get; set; } = null!;

    public string DocumentType { get; set; } = null!;

    public int NormedDescriptionId { get; set; }

    public string PictureName { get; set; } = null!;

    public string ShowImmediately { get; set; } = null!;
}
