namespace Domain.TechDoc.Entities;

public partial class ArticlePart
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public int Quantity { get; set; }

    public short PartsSupplierId { get; set; }

    public string PartsDataSupplierArticleNumber { get; set; } = null!;
}
