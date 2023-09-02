namespace Domain.Errors.PlayerExceptions;

 // ReSharper disable UnusedMember.Global
public class InvalidPlayerEmailAddressException : DomainException
{
    private const string MessageTemplate = "{0} is not a valid email address.";

    public InvalidPlayerEmailAddressException(string value) : base(GetMessage(value))
    {
    }

    public InvalidPlayerEmailAddressException(string value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(string value)
    {
        return string.Format(MessageTemplate, value);
    }
}