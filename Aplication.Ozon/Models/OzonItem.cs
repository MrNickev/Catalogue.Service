namespace Aplication.Ozon.Models;

public class OzonItem
{
    public string? Name { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal OriginalPrice { get; set; }
    
    public List<string> ImageLinks { get; set; }
    
    public string? Link { get; set; }

    public OzonItem()
    {
        ImageLinks = new List<string>();
    }
}