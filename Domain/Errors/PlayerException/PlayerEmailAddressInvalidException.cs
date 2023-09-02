namespace Domain.Errors.PlayerException;

 // ReSharper disable UnusedMember.Global
public class PlayerEmailAddressInvalidException : DomainException
{
    private const string MessageTemplate = "{0} is not a valid email address.";

    public PlayerEmailAddressInvalidException(string value) : base(GetMessage(value))
    {
    }

    public PlayerEmailAddressInvalidException(string value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(string value)
    {
        return string.Format(MessageTemplate, value);
    }
}