using MKTournament.Domain.Abstractions;

namespace MKTournament.Domain.Players.Errors;

public record PlayerErrors(string Code, string Name) : Error(Code, Name)
{
    public static PlayerErrors EmailAlreadyConfirmed(PlayerEmailAddress email)
    {
        return new PlayerErrors(
            nameof(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed), 
            string.Format(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed, email.Value)
        );
    }

    public static PlayerErrors NotRegistered(PlayerEmailAddress email)
    {
        return new PlayerErrors(
            nameof(PlayerErrorMessages.Player_NotRegistered), 
            string.Format(PlayerErrorMessages.Player_NotRegistered, email.Value));
    }
    
    public static readonly PlayerErrors RegistrationTokenMismatch = new(
        nameof(PlayerErrorMessages.PlayerRegitrationToken_NotMatch), 
        string.Format(PlayerErrorMessages.PlayerRegitrationToken_NotMatch));
}