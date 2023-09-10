using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Player : BaseEntity
{
    public Player(PlayerNickName nickName,
        PlayerEmailAddress emailAddress,
        string? createdBy = null,
        Guid? id = null) : base(createdBy,
        id)
    {
        NickName = nickName.Value;
        EmailAddress = emailAddress.Value;
    }

    public string NickName { get; }
    
    public string EmailAddress { get; }
}