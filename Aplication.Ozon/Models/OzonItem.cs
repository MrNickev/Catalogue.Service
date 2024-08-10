using Application.Common.Abstractions;
using Application.Common.Models;

namespace Aplication.Ozon.Models;

public class OzonItem : PartItem
{

    private decimal _originalPrice;
    public decimal OriginalPrice
    {
        get => _originalPrice;
        set
        {
            _originalPrice = value;
            Offers.Add(new Offer(value));
        }
    }

    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            Offers.Add(new Offer(value));
        }
    }

    public OzonItem() : base()
    {
        
    }

}