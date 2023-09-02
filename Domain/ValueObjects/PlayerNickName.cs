using Domain.Errors.PlayerException;
using ValueOf;

namespace Domain.ValueObjects;

public class PlayerNickName : ValueOf<string, PlayerNickName>
{
    public const int MinimumLength = 2;
    public const int MaximumLength = 50;
    
    protected override void Validate()
    {
        if (Value.Length is < MinimumLength or > MaximumLength)
            throw new PlayerNickNameInvalidException(Value);
    }
}