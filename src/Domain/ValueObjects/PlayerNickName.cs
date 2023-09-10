using Domain.Errors.PlayerExceptions;
using ValueOf;

namespace Domain.ValueObjects;

public class PlayerNickName : ValueOf<string, PlayerNickName>
{
    public const int MinLength = 2;
    public const int MaxLength = 50;
    
    protected override void Validate()
    {
        if (Value.Length is < MinLength or > MaxLength)
            throw new InvalidPlayerNickNameException(Value);
    }
}