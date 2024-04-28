using ErrorOr;
using MKTournament.Domain.Common;
using MKTournament.Domain.Players.Events;

namespace MKTournament.Domain.Players;

public class Player(
    Guid id,
    PlayerNickName nickName,
    PlayerEmailAddress emailAddress)
    : BaseEntity(id)
{
    public string NickName { get; } = nickName.Value;

    public string EmailAddress { get; } = emailAddress.Value;

    public DateTime? RegisteredOnUtc { get; private set; }
    
    public string RegistrationToken { get; private set; } = string.Empty;
    
    public DateTime? RegistrationTokenSentOnUtc { get; set; }
    
    public DateTime? EmailConfirmedOnUtc { get; private set; }

    public ErrorOr<Success> Register()
    {
        if (EmailConfirmedOnUtc is not null)
        {
            return Error.Failure(
                nameof(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed), 
                string.Format(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed, emailAddress));
        }
        
        var currentDateTime = DateTime.Now;
        
        RegisteredOnUtc = currentDateTime;

        RegistrationToken = PlayerTokenService.GenerateToken();
        
        RaiseDomainEvent(new PlayerRegisteredDomainEvent(Id));
        
        return Result.Success;
    }

    public ErrorOr<Success> ConfirmEmail(string registrationToken)
    {
        if (RegisteredOnUtc is null)
        {
            return Error.Failure(
                nameof(PlayerErrorMessages.Player_NotRegistered), 
                string.Format(PlayerErrorMessages.Player_NotRegistered, emailAddress));
        }
        
        if (EmailConfirmedOnUtc is not null)
        {
            return Error.Failure(
                nameof(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed), 
                string.Format(PlayerErrorMessages.PlayerEmail_AlreadyConfirmed, emailAddress));
        }

        if (!RegistrationToken.Equals(registrationToken))
        {
            return Error.Failure(
                nameof(PlayerErrorMessages.PlayerRegitrationToken_NotMatch), 
                string.Format(PlayerErrorMessages.PlayerRegitrationToken_NotMatch));
        }

        var currentDateTime = DateTime.Now;

        EmailConfirmedOnUtc = currentDateTime;
        
        RaiseDomainEvent(new PlayerConfirmedDomainEvent(Id));

        return Result.Success;
    }
}