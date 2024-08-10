using Aplication.Ozon.Models;
using System.Text.Json;
using System.Text.RegularExpressions;
using Application.Common.Abstractions;
using Application.Common.Helpers;
using Application.Common.Models;


namespace Aplication.Ozon.Services;

public class OzonSearchService : ISearcherService
{

    private static HttpClient _httpClient = new HttpClient();
    // private readonly ILogger _logger = logger;

    public async Task<IEnumerable<PartItem>> FindPartAsync(SearchData searchData)
    {

        string searchString = $"{searchData.Supplier} {searchData.Article} {searchData.Description}";

        var result = await _httpClient.GetAsync("https://www.ozon.ru/api/entrypoint-api.bx/page/json/v2?url=/search/?" +
                             "from_global=true" +
                             "&layout_container=searchMegapagination" +
                             "&layout_page_index=1" +
                             "&page=1" +
                             $"&text={searchString}");
        if (result.IsSuccessStatusCode)
        {
            var content = await result.Content.ReadAsStringAsync();
            
            return ParseJsonResponse(content);

        }

        return new List<OzonItem>();
    }

    
    /// <summary>
    /// Ищет значение свойства в json-объекте.
    /// </summary>
    /// <param name="jsonObject">Объект json в формате string, в котором ведется поиск</param>
    /// <param name="propertyName">Имя свойства, которое нужно найти или в котором нужно искать, если указан innerProperty</param>
    /// <param name="innerProperty">Имя внутреннего свойства, которое нужно найти. Если нужно только одно - указывается как null</param>
    /// <returns>Значение свойства в формате строки</returns>
    
    
    /// <summary>
    /// Метод парсит получаемый json, находит в нем результаты поиска и преобразует их в список <see cref="OzonItem"/> 
    /// </summary>
    /// <param name="jsonResponse">Объект json в формате строки</param>
    /// <returns>Список найденных предложений в виде списка <see cref="OzonItem"/></returns>
    private List<OzonItem> ParseJsonResponse(string jsonResponse)
    {
        List<OzonItem> foundItems = [];

        var searchResultValues = JsonHelper.FindJsonPropertyValue(jsonResponse, "widgetStates", "searchResults");
        if (searchResultValues is not null && searchResultValues.Value.ValueKind == JsonValueKind.String)
        {
            var items = JsonHelper.FindJsonPropertyValue(searchResultValues.Value.GetString(), "items");
            if (items is not null && items.Value.ValueKind == JsonValueKind.Array)
            {
                for (var i = 0; i < items.Value.GetArrayLength(); i++)
                {
                    foundItems.Add(ParseItemProperties(items.Value[i]));       
                }
            }
        }

        return foundItems;
    }

    public OzonItem ParseItemProperties(JsonElement item)
    {
        var ozonItem = new OzonItem();

        if (item.TryGetProperty("action", out JsonElement action))
            if (action.TryGetProperty("link", out JsonElement link))
                ozonItem.Link = "ozon.ru" + link.GetString();
        
        if (item.TryGetProperty("mainState", out JsonElement mainState))
        {
            for (var i = 0; i < mainState.GetArrayLength(); i++)
            {
                if (mainState[i].TryGetProperty("atom", out var atom) &&
                    atom.GetProperty("type").GetString() == "priceV2")
                {
                    var priceProperty = atom.GetProperty("priceV2").GetProperty("price");
                    for (var priceIterator = 0; priceIterator < priceProperty.GetArrayLength(); priceIterator++)
                    {

                        switch (priceProperty[priceIterator].GetProperty("textStyle").GetString())
                        {
                            case "PRICE":
                                
                                var stringPrice = priceProperty[priceIterator].GetProperty("text").GetString();
                                if (stringPrice is not null)
                                {
                                    stringPrice = Regex.Replace(stringPrice, @"[\s+₽]", "");
                                    ozonItem.Price = decimal.Parse(stringPrice);
                                }

                                break;

                            case "ORIGINAL_PRICE":
                                var stringOriginalPrice = priceProperty[priceIterator].GetProperty("text").GetString();
                                if (stringOriginalPrice is not null)
                                {
                                    stringOriginalPrice = Regex.Replace(stringOriginalPrice, @"[\s+₽]", "");
                                    ozonItem.OriginalPrice =
                                        decimal.Parse(stringOriginalPrice);
                                }
                                break;
                        }
                    }
                }

                if (mainState[i].TryGetProperty("id", out var name) && 
                    name.GetString() == "name" &&
                    mainState[i].TryGetProperty("atom", out var nameAtom) &&
                    nameAtom.TryGetProperty("textAtom", out var textAtom) &&
                    textAtom.TryGetProperty("text", out var partNameElement)
                    )
                {
                    ozonItem.Name = partNameElement.GetString();
                }

            }
        }

        if (item.TryGetProperty("tileImage", out var imageItems) && 
            imageItems.TryGetProperty("items", out var images))
        {
            foreach (var imageItem in images.EnumerateArray())
            {
                if (imageItem.TryGetProperty("image", out var image) &&
                    image.TryGetProperty("link", out var imageLink)
                    )
                {
                    var imageLinkText = imageLink.GetString();
                    if (imageLinkText is not null)
                        ozonItem.ImageLinks.Add(imageLinkText);
                }
            }
            
        }
        
        
        
        return ozonItem;
    }
}