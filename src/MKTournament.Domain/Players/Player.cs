using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Common;
using MKTournament.Domain.Players.Errors;
using MKTournament.Domain.Players.Events;

namespace MKTournament.Domain.Players;

public class Player(Guid id, PlayerNickName nickName, PlayerEmailAddress emailAddress)
    : BaseEntity (id)
{

    public PlayerNickName NickName { get; private set; } = nickName;

    public PlayerEmailAddress EmailAddress { get; private set; } = emailAddress;

    public DateTime? RegisteredOnUtc { get; private set; }
    
    public string RegistrationToken { get; private set; } = string.Empty;
    
    public DateTime? RegistrationTokenSentOnUtc { get; set; }
    
    public DateTime? EmailConfirmedOnUtc { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    #region Methods

    public static Player Create(PlayerNickName nickName, PlayerEmailAddress emailAddress)
    {
        var player = new Player(Guid.NewGuid(), nickName, emailAddress)
        {
            RegisteredOnUtc = DateTime.Now,
            RegistrationToken = PlayerTokenService.GenerateToken()
        };

        player.RaiseDomainEvent(new PlayerCreatedDomainEvent(player.Id));

        return player;
    }
    
    public Result ConfirmEmail(string registrationToken)
    {
        if (RegisteredOnUtc is null)
        {
            return Result.Failure(PlayerErrors.NotRegistered(EmailAddress));
        }
        
        if (EmailConfirmedOnUtc is not null)
        {
            return Result.Failure(PlayerErrors.EmailAlreadyConfirmed(EmailAddress));
        }

        if (!RegistrationToken.Equals(registrationToken))
        {
            return Result.Failure(PlayerErrors.RegistrationTokenMismatch);
        }

        var currentDateTime = DateTime.Now;

        EmailConfirmedOnUtc = currentDateTime;
        
        RaiseDomainEvent(new PlayerConfirmedDomainEvent(Id));

        return Result.Success();
    }
    #endregion
}