using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Players;
using MKTournament.Infrastructure.Persistence;

namespace MKTournament.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext dbContext) : BaseRepository<Player>(dbContext), IPlayerRepository
{
    public async Task<bool> IsEmailAlreadyTakenAsync(PlayerEmailAddress emailAddress, CancellationToken cancellationToken)
    {
        return await DbContext.AnyAsync(p => p.EmailAddress.Equals(emailAddress), cancellationToken);
    }

    public async Task<bool> IsNickNameAlreadyTakenAsync(PlayerNickName nickName, CancellationToken cancellationToken = default)
    {
        return await DbContext.AnyAsync(p => p.NickName.Equals(nickName), cancellationToken);
    }
}