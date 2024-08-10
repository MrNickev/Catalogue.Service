using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Avtomoe.Models;
using Application.Common.Abstractions;
using Application.Common.Helpers;
using Application.Common.Models;
using Microsoft.Extensions.Logging;

namespace Application.Avtomoe.Services;

public class AvtomoeSearchService(ILogger<AvtomoePartInfo> logger) : ISearcherService
{
    private static HttpClient _httpClient = new HttpClient();

    public async Task<IEnumerable<PartItem>> FindPartAsync(SearchData data)
    {

        //TODO: сделать автоматический поиск города или его указание
        var city = "ufa";
        var sendContent = JsonContent.Create(new { vendor = data.Supplier, catnum = data.Article });
        var result = await _httpClient.PostAsync($"https://{city}.avtomoe.com/api/partsoft-offers", sendContent);

        if (result.IsSuccessStatusCode)
        {
            var content = await result.Content.ReadAsStringAsync();
            return ParseJsonResponse(content).Select(x => x.ConvertToPartItem());
        }
        
        return new List<PartItem>();
    }

    private List<AvtomoePartInfo> ParseJsonResponse(string jsonResponse)
    {
        var partList = new List<AvtomoePartInfo>();
        
        var requestedOffers = JsonHelper.FindJsonPropertyValue(jsonResponse, "data", "requestedOffers");
        partList.AddRange(ParseItemsElementsArray(requestedOffers));
        
        var analogOffers = JsonHelper.FindJsonPropertyValue(jsonResponse, "data", "analogOffers");
        partList.AddRange(ParseItemsElementsArray(analogOffers));

        return partList;
    }

    private List<AvtomoePartInfo> ParseItemsElementsArray(JsonElement? element)
    {
        var partList = new List<AvtomoePartInfo>();
        if (element is not null)
        {
            foreach (var part in element.Value.EnumerateObject())
            {
                try
                {
                    var partInfo = part.Value.Deserialize<AvtomoePartInfo>();
                    
                    part.Value.TryGetProperty("vendorOffers", out var offers);
                    partInfo.Offers = offers.Deserialize<List<Offer>>();;
                        
                    partList.Add(partInfo);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Не удалось преобразовать объект из Json в AvtomoePartInfo");
                    throw;
                }
            }
        }

        return partList;
    }
}