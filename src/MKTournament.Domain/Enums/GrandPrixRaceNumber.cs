using MKTournament.Domain.Common;

// ReSharper disable UnusedMember.Global

namespace MKTournament.Domain.Enums;

public class GrandPrixRaceNumber : Enumeration<int>
{
    public static readonly GrandPrixRaceNumber R4 = new (1, 4);
    public static readonly GrandPrixRaceNumber R6 = new (2, 6);
    public static readonly GrandPrixRaceNumber R8 = new (3, 8);
    public static readonly GrandPrixRaceNumber R12 = new (4, 12);
    public static readonly GrandPrixRaceNumber R16 = new (5, 16);
    public static readonly GrandPrixRaceNumber R24 = new (6, 24);
    public static readonly GrandPrixRaceNumber R32 = new (7, 32);
    public static readonly GrandPrixRaceNumber R48 = new (8, 48);
    
    private GrandPrixRaceNumber(int id, int name) : base(id, name)
    {
    }
}