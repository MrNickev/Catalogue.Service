namespace Application.Common.Models.Dto;

/// <summary>
/// DTO для результата поиска запчасти 
/// </summary>
public class PartDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Артикул
    /// </summary>
    public string? Article { get; set; }
    
    /// <summary>
    /// Ссылка
    /// </summary>
    public string? Link { get; set; }
    
    /// <summary>
    /// Ссылка на изображение
    /// </summary>
    public List<string> ImageLinks { get; set; }

    public PartDto(string? name, decimal price, string? link, List<string> imageLinks)
    {
        Name = name;
        Price = price;
        ImageLinks = imageLinks;
        Link = link;
    }
}