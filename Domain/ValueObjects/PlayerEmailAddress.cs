using System.Net.Mail;
using Domain.Errors.PlayerException;
using ValueOf;

namespace Domain.ValueObjects;

public class PlayerEmailAddress : ValueOf<string, PlayerEmailAddress>
{
    protected override void Validate()
    {
        if (!MailAddress.TryCreate(Value, out _)) throw new PlayerEmailAddressInvalidException(Value);
    }
}