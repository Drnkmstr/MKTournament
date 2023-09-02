using Domain.ValueObjects;

namespace Domain.Errors.PlayerException;

 // ReSharper disable UnusedMember.Global
public class PlayerNickNameInvalidException : DomainException
{
    private const string MessageTemplate = "{0} is an invalid name. It must be longer than {1} characters and shorter than {2}";

    public PlayerNickNameInvalidException(string value) : base(GetMessage(value))
    {
    }

    public PlayerNickNameInvalidException(string value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(string value)
    {
        return string.Format(MessageTemplate, value, PlayerNickName.MinimumLength, PlayerNickName.MaximumLength);
    }
}