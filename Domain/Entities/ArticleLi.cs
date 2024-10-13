namespace Domain.TechDoc.Entities;

public partial class ArticleLi
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public string LinkageTypeId { get; set; } = null!;

    public long LinkageId { get; set; }
}
