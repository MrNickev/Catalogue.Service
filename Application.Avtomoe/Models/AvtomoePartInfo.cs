using System.Collections.Generic;
using System.Text.Json.Serialization;
using Application.Common.Models;

namespace Application.Avtomoe.Models;

public class AvtomoePartInfo
{
    /// <summary>
    /// Артикул, номер по каталогу
    /// </summary>
    [JsonPropertyName("catnum")]
    public string CatalogueNumber { get; set; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    [JsonPropertyName("vendor")]
    public string Vendor { get; set; }
    
    /// <summary>
    /// Наименование 
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// Ссылка на изображение
    /// </summary>
    [JsonPropertyName("image")]
    public string ImageLink { get; set; }
    
    /// <summary>
    /// Минимальная цена
    /// </summary>
    [JsonPropertyName("price_min")]
    public int PriceMin { get; set; }

    [JsonPropertyName("vendorOffers")]
    public List<Offer> Offers;

    public PartItem ConvertToPartItem()
    {
        return new PartItem(Name, Vendor, Offers, CatalogueNumber, null, ImageLink);
    }
}
