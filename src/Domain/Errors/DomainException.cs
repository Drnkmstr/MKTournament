namespace Domain.Errors;

// ReSharper disable UnusedMember.Global
public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string value) : base(value)
    {
    }

    public DomainException(string value, Exception inner) : base(value, inner)
    {
    }
}