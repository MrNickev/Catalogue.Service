namespace Domain.TechDoc.Entities;

public partial class ArticleCross
{
    public long ManufacturerId { get; set; }

    public string Oenbr { get; set; } = null!;

    public int SupplierId { get; set; }

    public string PartsDataSupplierArticleNumber { get; set; } = null!;
}
