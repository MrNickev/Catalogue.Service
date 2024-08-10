namespace Application.Common.Models;

public class SearchData
{
    public string? Article { get; set; }
    
    public string? Supplier { get; set; }
    
    public string? Description { get; set; }

    public bool IsEmpty()
    {
        return Article is null &&
               Supplier is null &&
               Description is null;
    }
}