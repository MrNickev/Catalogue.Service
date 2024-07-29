namespace Application.Common.Models.Dto;

/// <summary>
/// DTO для результата поиска товара 
/// </summary>
public class PartDto
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Article { get; set; }

    public PartDto(string? name, decimal price, string? article)
    {
        Name = name;
        Price = price;
        Article = article;
    }
}