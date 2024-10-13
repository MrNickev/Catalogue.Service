using Domain.TechDoc.Entities;

namespace Application.Dtos;

public class ModelDto
{
    /// <summary>
    /// Идентификатор марки
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Название модели
    /// </summary>
    public string? Name { get; set; } 
    
    /// <summary>
    /// Даты производства
    /// </summary>
    public string? ConstructionInterval { get; set; }
    
    /// <summary>
    /// Стандартный конструктор для (де-)сериализации
    /// </summary>
    public ModelDto()
    {
    }

    public ModelDto(long id, string? name, string? constructionInterval)
    {
        Id = id;
        Name = name;
        ConstructionInterval = constructionInterval;
    }
    
    public ModelDto(Model model)
    {
        ConstructionInterval = model.Constructioninterval;
        Id = model.Id;
        Name = model.Description;
    }
}