using MKTournament.Domain.Abstractions;

namespace MKTournament.Domain.Players.Errors;

public record PlayerError(string Code, string Name) : Error(Code, Name)
{
    public static PlayerError EmailAlreadyConfirmed(PlayerEmailAddress email)
    {
        return new PlayerError(
            nameof(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed), 
            string.Format(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed, email.Value)
        );
    }

    public static PlayerError NotRegistered(PlayerEmailAddress email)
    {
        return new PlayerError(
            nameof(PlayerErrorMessages.Player_NotRegistered), 
            string.Format(PlayerErrorMessages.Player_NotRegistered, email.Value));
    }
    
    public static readonly PlayerError RegistrationTokenMismatch = new(
        nameof(PlayerErrorMessages.PlayerRegitrationToken_NotMatch), 
        string.Format(PlayerErrorMessages.PlayerRegitrationToken_NotMatch));

    public static PlayerError EmailAlreadyTaken(PlayerEmailAddress emailAddress)
    {
        return new PlayerError(
            nameof(PlayerErrorMessages.PlayerEmail_AlreadyTaken),
            string.Format(PlayerErrorMessages.PlayerEmail_AlreadyTaken, emailAddress.Value));
    }

    public static PlayerError NickNameAlreadyTaken(PlayerNickName playerNickName)
    {
        return new PlayerError(
            nameof(PlayerErrorMessages.PlayerNickName_AlreadyTaken),
            string.Format(PlayerErrorMessages.PlayerNickName_AlreadyTaken, playerNickName.Value));
    }
}