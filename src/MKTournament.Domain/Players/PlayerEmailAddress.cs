using System.Net.Mail;
using MKTournament.Domain.Errors.PlayerExceptions;
using ValueOf;

namespace MKTournament.Domain.Players;

public class PlayerEmailAddress : ValueOf<string, PlayerEmailAddress>
{
    private const int MaxLocalePartLenght = 64;
    private const int MaxDomainPartLenght = 255;

    public const int MaxLength = MaxLocalePartLenght + MaxDomainPartLenght + 1;
    
    protected override void Validate()
    {
        if (!MailAddress.TryCreate(Value, out _)) throw new InvalidPlayerEmailAddressException(Value);
        Value?.TrimEnd('.');
    }
}