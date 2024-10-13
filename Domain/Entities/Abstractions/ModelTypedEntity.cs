using Domain.TechDoc.Enums;

namespace Domain.TechDoc.Entities.Abstractions;

public abstract class ModelTypedEntity
{
    public string Isaxle { get; set; } = null!;
    public bool IsAxle => Isaxle == "True";

    public string Iscommercialvehicle { get; set; } = null!;
    public bool IsCommercialVehicle => Iscommercialvehicle == "True";

    public string Isengine { get; set; } = null!;
    public bool IsEngine => Isengine == "True";

    public string Ismotorbike { get; set; } = null!;
    public bool IsMotorbike => Ismotorbike == "True";

    public string Ispassengercar { get; set; } = null!;
    public bool IsPassengerCar => Ispassengercar == "True";

    public string Istransporter { get; set; } = null!;
    public bool IsTransporter => Istransporter == "True";

    public ModelType Type => GetModelType();

    private ModelType GetModelType()
    {
        if (IsPassengerCar)
        {
            return ModelType.PassengerCar;
        }

        if (IsCommercialVehicle)
        {
            return ModelType.CommercialVehicle;
        }
        
        if (IsMotorbike)
        {
            return ModelType.Motorbike;
        }

        if (IsAxle)
        {
            return ModelType.Axle;
        }

        if (IsEngine)
        {
            return ModelType.Engine;
        }

        return ModelType.Transporter;
    }
}