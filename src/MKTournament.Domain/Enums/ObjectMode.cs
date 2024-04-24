using MKTournament.Domain.Common;

namespace MKTournament.Domain.Enums;

public sealed class ObjectMode : Enumeration<string>
{
    public static readonly ObjectMode Normal = new(1, "Normal mode");
    public static readonly ObjectMode Shell = new(2, "Shell only");
    public static readonly ObjectMode Banana = new(3, "Banana only");
    public static readonly ObjectMode Mushroom = new(4, "Mushrooms only");
    public static readonly ObjectMode BobOmb = new(5, "Bob-ombs only");
    public static readonly ObjectMode NoObjects = new(6, "No objects");
    public static readonly ObjectMode NoObjectNoCoin = new(7, "No objects and no coins");
    public static readonly ObjectMode Explosive = new(8, "Explosive mode");
    public static readonly ObjectMode Custom = new(9, "Custom mode");

    private ObjectMode(int id, string name) : base(id, name)
    {
    }
}