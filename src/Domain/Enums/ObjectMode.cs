using Domain.Common;

namespace Domain.Enums;

public sealed class ObjectMode : Enumeration
{
    public static ObjectMode Normal = new(1, "Normal mode");
    public static ObjectMode Shell = new(2, "Shell only");
    public static ObjectMode Banana = new(3, "Banana only");
    public static ObjectMode Mushroom = new(4, "Mushrooms only");
    public static ObjectMode BobOmb = new(5, "Bob-ombs only");
    public static ObjectMode NoObjects = new(6, "No objects");
    public static ObjectMode NoObjectNoCoin = new(7, "No objects and no coins");
    public static ObjectMode Explosive = new(8, "Explosive mode");
    public static ObjectMode Custom = new(9, "Custom mode");

    private ObjectMode(int id, string name) : base(id, name)
    {
    }
}