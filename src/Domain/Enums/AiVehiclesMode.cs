using Domain.Common;

namespace Domain.Enums;

public sealed class AiVehicleMode : Enumeration
{
    public static AiVehicleMode All = new(1, "All vehicles");
    public static AiVehicleMode NoBike = new(2, "No bikes");
    public static AiVehicleMode NoKart = new(3, "No karts");

    private AiVehicleMode(int id, string name) : base(id, name)
    {
    }
}