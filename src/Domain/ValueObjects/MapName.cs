using Domain.Errors.MapExceptions;
using ValueOf;

namespace Domain.ValueObjects;

public class MapName : ValueOf<string, MapName>
{
    public const int MinLength = 2;
    public const int MaxLength = 50;
    
    protected override void Validate()
    {
        if (Value.Length is < MinLength or > MaxLength)
            throw new InvalidMapNameException(Value);
    }
}