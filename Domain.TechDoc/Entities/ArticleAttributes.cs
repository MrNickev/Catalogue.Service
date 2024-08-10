using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.TechDoc.Entities;

/// <summary>
/// Характеристики/Критерии
/// </summary>
[Table("article_attributes")]
public class ArticleAttributes
{
    /// <summary>
    /// Идентификатор производителя неоригинальных запчастей (связь с таблицей suppliers)
    /// </summary>
    [Column("supplierid")]
    public int SupplierId { get; set; }
    
    /// <summary>
    /// Артикул (связь с таблицей articles)
    /// </summary>
    [Column("datasupplierarticlenumber")]
    public string DataSupplierArticleNumber { get; set; }
    
    /// <summary>
    /// Идентификатор критерия
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// Описание критерия
    /// </summary>
    [Column("description")]
    public string Description { get; set; }
    
    /// <summary>
    /// Уточнение критерия (дополнение)
    /// </summary>
    [Column("displaytitle")]
    public string DisplayTitle { get; set; }
    
    /// <summary>
    /// свойство критерия (значение)
    /// </summary>
    [Column("displaytitle")]
    public string DisplayValue { get; set; }
    
}