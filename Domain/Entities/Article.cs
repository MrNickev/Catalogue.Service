namespace Domain.TechDoc.Entities;

public partial class Article
{
    public int SupplierId { get; set; }

    public string DataSupplierArticleNumber { get; set; } = null!;

    public string ArticleStateDisplayValue { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FlagAccessory { get; set; } = null!;

    public string FlagMaterialCertification { get; set; } = null!;

    public string FlagRemanufactured { get; set; } = null!;

    public string FlagSelfServicePacking { get; set; } = null!;

    public string FoundString { get; set; } = null!;

    public string HasAxle { get; set; } = null!;

    public string HasCommercialVehicle { get; set; } = null!;

    public string HasCvmanuId { get; set; } = null!;

    public string HasEngine { get; set; } = null!;

    public string HasLinkitems { get; set; } = null!;

    public string HasMotorbike { get; set; } = null!;

    public string HasPassengerCar { get; set; } = null!;

    public string IsValid { get; set; } = null!;

    public long? LotSize1 { get; set; }

    public long? LotSize2 { get; set; }

    public string NormalizedDescription { get; set; } = null!;

    public long? PackingUnit { get; set; }

    public long? QuantityPerPackingUnit { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
