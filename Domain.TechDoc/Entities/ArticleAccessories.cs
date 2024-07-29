using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechDoc;

/// <summary>
/// Сопутствующие товары/акксессуары
/// </summary>
[Table("article_acc")]
public class ArticleAccessories
{
    /// <summary>
    /// Идентификатор производителя неоригинальных запчастей (связь с таблицей suppliers)
    /// </summary>
    [Column("supplierId")]
    public int SupplierId { get; set; }
    
    
    /// <summary>
    /// Артикул (связь с таблицей articles)
    /// </summary>
    public string DataSupplierArticleNumber { get; set; }
    
    
    /// <summary>
    /// Аксессуар: идентификатор бренда (связь с таблицей suppliers)
    /// </summary>
    [Column("AccSupplierId")]
    public int AccessorySupplierId { get; set; }
    
    /// <summary>
    /// Аксессуар: артикул (связь с таблицей articles)
    /// </summary>
    [Column("AccDataSupplierArticleNumber")]
    public string AccessoryDataSupplierArticleNumber { get; set; }
}