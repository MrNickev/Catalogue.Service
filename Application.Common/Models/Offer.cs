using System.Text.Json.Serialization;

namespace Application.Common.Models;

/// <summary>
/// Предложение цены и срока доставки
/// </summary>
public class Offer
{
    /// <summary>
    /// Цена
    /// </summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    
    /// <summary>
    /// Дата доставки
    /// </summary>
    [JsonPropertyName("delivery_date")]
    public DateTime? DeliveryDate { get; set; }

    public Offer()
    {
        
    }
    
    public Offer(decimal price)
    {
        Price = price;
    }
    
    public Offer(decimal price, DateTime? deliveryDate)
    {
        Price = price;
        DeliveryDate = deliveryDate;
    }
}