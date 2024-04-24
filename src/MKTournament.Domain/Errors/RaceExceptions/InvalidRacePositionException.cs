using MKTournament.Domain.Races;

namespace MKTournament.Domain.Errors.RaceExceptions;

// ReSharper disable UnusedMember.Global
public class InvalidRacePositionException : DomainException
{
    private const string MessageTemplate = "{0} is not a valid position number. Must be between {1} and {2} (included)";
    
    public InvalidRacePositionException(int value) : base(GetMessage(value))
    {
    }

    public InvalidRacePositionException(int value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(int value)
    {
        return string.Format(MessageTemplate, value, RacePosition.MinPosition, RacePosition.MaxPosition);
    }
}