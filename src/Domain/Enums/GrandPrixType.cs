using Domain.Common;

namespace Domain.Enums;

public sealed class GrandPrixType : Enumeration
{
    public static GrandPrixType Gp50 = new(1, "50 cc");
    public static GrandPrixType Gp100 = new(2, "100 cc");
    public static GrandPrixType Gp150 = new(3, "150 cc");
    public static GrandPrixType Gp200 = new(4, "200 cc");
    public static GrandPrixType GpMirror = new(5, "150 cc - Mirror");

    private GrandPrixType(int id, string name) : base(id, name)
    {
    }
}