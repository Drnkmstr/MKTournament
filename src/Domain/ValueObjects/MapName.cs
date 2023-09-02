using Domain.Errors.MapExceptions;
using ValueOf;

namespace Domain.ValueObjects;

public class MapName : ValueOf<string, MapName>
{
    public const int MinimumLength = 2;
    public const int MaximumLength = 50;
    
    protected override void Validate()
    {
        if (Value.Length is < MinimumLength or > MaximumLength)
            throw new InvalidMapNameException(Value);
    }
}