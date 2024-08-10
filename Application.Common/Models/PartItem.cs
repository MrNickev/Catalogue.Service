namespace Application.Common.Models;

/// <summary>
/// DTO для результата поиска запчасти 
/// </summary>
public class PartItem
{
    /// <summary>
    /// Название
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    public string? Supplier { get; set; }
    
    /// <summary>
    /// Артикул
    /// </summary>
    public string? Article { get; set; }
    
    /// <summary>
    /// Ссылка на деталь
    /// </summary>
    public string? Link { get; set; }
    
    /// <summary>
    /// Ссылка на изображение
    /// </summary>
    public List<string> ImageLinks { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public List<Offer> Offers { get; set; }

    /// <summary>
    /// Пустой коструктор для инициализации списков
    /// </summary>
    public PartItem()
    {
        ImageLinks = new List<string>();
        Offers = new List<Offer>();
    }

    /// <summary>
    /// Конструктор для полного создания
    /// </summary>
    /// <param name="name">Название детали</param>
    /// <param name="offers">Список предложений</param>
    /// <param name="article">Артикул детали</param>
    /// <param name="link">Ссылка</param>
    /// <param name="imageLinks">Список ссылок с изображениями</param>
    public PartItem(string? name, string? supplier, List<Offer> offers, string? article, string? link, List<string> imageLinks)
    {
        Name = name;
        Supplier = supplier;
        Offers = offers;
        Article = article;
        Link = link;
        ImageLinks = imageLinks;
    }

    /// <summary>
    /// Конструктор для случаев, когда для детали указано только 1 изображение
    /// </summary>
    /// <param name="name"></param>
    /// <param name="offers"></param>
    /// <param name="article"></param>
    /// <param name="link"></param>
    /// <param name="imageLink"></param>
    public PartItem(string? name, List<Offer> offers, string? article, string? link, string imageLink)
    {
        Name = name;
        Offers = offers;
        Article = article;
        Link = link;
        ImageLinks = new List<string>() { imageLink };
    }
    
    /// <summary>
    /// Конструктор для случаев, когда для детали указано только 1 изображение
    /// </summary>
    /// <param name="name"></param>
    /// <param name="offers"></param>
    /// <param name="article"></param>
    /// <param name="link"></param>
    /// <param name="imageLink"></param>
    public PartItem(string? name, string? supplier, List<Offer> offers, string? article, string? link, string imageLink)
    {
        Name = name;
        Supplier = supplier;
        Offers = offers;
        Article = article;
        Link = link;
        ImageLinks = new List<string>() { imageLink };
    }
}