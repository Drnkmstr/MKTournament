using Domain.ValueObjects;

namespace Domain.Errors.MapExceptions;

 // ReSharper disable UnusedMember.Global
public class InvalidMapNameException : DomainException
{
    private const string MessageTemplate = "{0} is an invalid map name. Must be between {1} and {2} (included)";

    public InvalidMapNameException()
    {
    }

    public InvalidMapNameException(string value) : base(GetMessage(value))
    {
    }

    public InvalidMapNameException(string value, Exception inner) : base(GetMessage(value), inner)
    {
    }

    private static string GetMessage(string value)
    {
        return string.Format(MessageTemplate, value, MapName.MinLength, MapName.MaxLength);
    }
}