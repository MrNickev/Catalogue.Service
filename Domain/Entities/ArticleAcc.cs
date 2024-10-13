namespace Domain.TechDoc.Entities;

public partial class ArticleAcc
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public int AccSupplierId { get; set; }

    public string AccDataSupplierArticleNumber { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
