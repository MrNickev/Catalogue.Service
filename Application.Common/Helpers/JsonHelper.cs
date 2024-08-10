using System.Text.Json;

namespace Application.Common.Helpers;

public static class JsonHelper
{
    public static JsonElement? FindJsonPropertyValue(string jsonObject, string propertyName, string? innerProperty = null)
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

    // public static JsonElement? FindJsonPropertyValue(JsonElement element, string propertyName,
    //     string? innerProperty = null)
    // {
    //     
    // }
}