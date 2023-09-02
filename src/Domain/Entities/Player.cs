using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Player : BaseEntity
{
    public Player(Guid id, string createdBy, PlayerNickName nickName, PlayerEmailAddress emailAddress) : base(id, createdBy)
    {
        NickName = nickName.Value;
        EmailAddress = emailAddress.Value;
    }

    public string NickName { get; }
    
    public string EmailAddress { get; }
}