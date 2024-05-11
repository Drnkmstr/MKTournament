using MKTournament.Domain.Common;

namespace MKTournament.Domain.Players;

public interface IPlayerRepository : IBaseEntityRepository<Player>
{
    public Task<bool> IsEmailAlreadyTakenAsync(PlayerEmailAddress emailAddress, CancellationToken cancellationToken = default);
    
    public Task<bool> IsNickNameAlreadyTakenAsync(PlayerNickName nickName, CancellationToken cancellationToken = default);
}