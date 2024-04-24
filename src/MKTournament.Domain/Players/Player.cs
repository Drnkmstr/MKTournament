using MKTournament.Domain.Common;

namespace MKTournament.Domain.Players;

public class Player(
    Guid id,
    PlayerNickName nickName,
    PlayerEmailAddress emailAddress)
    : BaseEntity(id)
{
    public string NickName { get; } = nickName.Value;

    public string EmailAddress { get; } = emailAddress.Value;
}