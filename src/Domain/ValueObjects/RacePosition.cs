using System.Diagnostics;
using Domain.Errors.RaceExceptions;
using ValueOf;

namespace Domain.ValueObjects;

public class RacePosition : ValueOf<int, RacePosition>
{
    public const int MinimumPosition = 0;
    
    public const int MaximumPosition = 12;

    public int Score;
    
    protected override void Validate()
    {
        Score = Value switch
        {
            0 => 0,
            1 => 15,
            2 => 12,
            3 => 10,
            4 => 9,
            5 => 8,
            6 => 7,
            7 => 6,
            8 => 5,
            9 => 4,
            10 => 3,
            11 => 2,
            12 => 1,
            _ => throw new InvalidRacePositionException(Value)
        };
    }
}