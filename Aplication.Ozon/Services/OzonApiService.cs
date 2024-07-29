using System.Web;
using Aplication.Ozon.Abstractions;
using Aplication.Ozon.Models;
using System.Text.Json;


namespace Aplication.Ozon.Services;

public class OzonApiService : IOzonRequestService
{

    private static HttpClient _httpClient = new HttpClient();
    // private readonly ILogger _logger = logger;

    public async Task<IEnumerable<OzonItem>?> FindPart(string searchString)
    {

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
    private JsonElement? FindJsonPropertyValue(string jsonObject, string propertyName, string? innerProperty = null)
    {
        var json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonObject);
        if (json.TryGetValue(propertyName, out JsonElement value))
        {
            if (innerProperty is not null)
            {
                foreach (var property in value.EnumerateObject())
                {
                    if (property.Name.StartsWith(innerProperty))
                    {
                        return property.Value;
                    }
                }
            }
            
            else return value;
        }
        

        return null;
    }
    
    /// <summary>
    /// Метод парсит получаемый json, находит в нем результаты поиска и преобразует их в список <see cref="OzonItem"/> 
    /// </summary>
    /// <param name="jsonResponse">Объект json в формате строки</param>
    /// <returns>Список найденных предложений в виде списка <see cref="OzonItem"/></returns>
    private List<OzonItem> ParseJsonResponse(string jsonResponse)
    {
        List<OzonItem> foundItems = [];

        var searchResultValues = FindJsonPropertyValue(jsonResponse, "widgetStates", "searchResults");
        if (searchResultValues is not null && searchResultValues.Value.ValueKind == JsonValueKind.String)
        {
            var items = FindJsonPropertyValue(searchResultValues.Value.GetString(), "items");
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

        // if (item.TryGetProperty("action", out JsonElement action))
        //     if (action.TryGetProperty("link", out JsonElement link))
        //         ozonItem.Link = link.GetString();
        //
        // if (item.TryGetProperty("mainState", out JsonElement mainState))
        //     for (var i = 0; i < mainState.GetArrayLength(); i++)
        //     {
        //         if (mainState[i].TryGetProperty("atom", out var atom))
        //             switch (atom.GetProperty("type").GetString())
        //             {
        //                 case "priceV2":
        //                     var priceProperty = atom.GetProperty("priceV2").GetProperty("price");
        //                     for (var priceIterator = 0; priceIterator < priceProperty.GetArrayLength(); priceIterator++)
        //                     {
        //
        //                         switch (priceProperty[priceIterator].GetProperty("textStyle").GetString())
        //                         {
        //                             case "PRICE":
        //                                 ozonItem.Price = priceProperty[priceIterator].GetProperty("text").GetDecimal();
        //                                 break;
        //                             
        //                             case "ORIGINAL_PRICE":
        //                                 ozonItem.OriginalPrice =
        //                                     priceProperty[priceIterator].GetProperty("text").GetDecimal();
        //                                 break;
        //                         }
        //                     }
        //                     break;
        //                 
        //                 case 
        //                     
        //             }
        //         
        //     }
        //
        
        return ozonItem;
    }
}