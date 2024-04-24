using MKTournament.Domain.Common;

namespace MKTournament.Domain.Enums;

public sealed class AiVehicleMode : Enumeration<string>
{
    public static readonly AiVehicleMode All = new(1, "All vehicles");
    public static readonly AiVehicleMode NoBike = new(2, "No bikes");
    public static readonly AiVehicleMode NoKart = new(3, "No karts");

    private AiVehicleMode(int id, string name) : base(id, name)
    {
    }
}