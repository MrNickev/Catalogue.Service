namespace Domain.TechDoc.Entities;

/// <summary>
/// Произовдитель ТС
/// </summary>
public partial class Manufacturer
{
    /// <summary>
    /// Идентификатор.
    /// <remarks>В данной таблице встречаются записи с одинаковым Id, но разным Description</remarks>
    /// </summary>
    public long Id { get; set; }

    public string? Canbedisplayed { get; set; }

    public string? Description { get; set; }

    public string? Fulldescription { get; set; }

    public string? Haslink { get; set; }

    public string Isaxle { get; set; } = null!;

    public string Iscommercialvehicle { get; set; } = null!;

    public string Isengine { get; set; } = null!;

    public string Ismotorbike { get; set; } = null!;

    public string Ispassengercar { get; set; } = null!;

    public string Istransporter { get; set; } = null!;

    public string? Isvgl { get; set; }

    public string? Matchcode { get; set; }
}
