using Domain.ValueObjects;

namespace Domain.Errors.PlayerExceptions;

 // ReSharper disable UnusedMember.Global
public class InvalidPlayerNickNameException : DomainException
{
    private const string MessageTemplate = "{0} is an invalid name. It must be longer than {1} characters and shorter than {2}";

    public InvalidPlayerNickNameException(string value) : base(GetMessage(value))
    {
    }

    public InvalidPlayerNickNameException(string value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(string value)
    {
        return string.Format(MessageTemplate, value, PlayerNickName.MinimumLength, PlayerNickName.MaximumLength);
    }
}