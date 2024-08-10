using System.Text.Json.Serialization;

namespace Application.Avtomoe.Models;

/// <summary>
/// Модель ответа на запрос от api Автомое
/// </summary>
public class AvtomoeResponse
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string? Message { get; set; }
    
    /// <summary>
    /// Метод запроса
    /// </summary>
    public string Method { get; set; }
    
    /// <summary>
    /// Успешен ли запрос
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// Код запроса
    /// </summary>
    [JsonPropertyName("status")]
    public int StatusCode { get; set; }
    
    /// <summary>
    /// Данные результата запроса
    /// </summary>
    public AvtomoeResponseData Data { get; set; }
}