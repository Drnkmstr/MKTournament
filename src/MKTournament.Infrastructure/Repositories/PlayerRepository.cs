using Microsoft.EntityFrameworkCore;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;
using MKTournament.Domain.Players.Errors;
using MKTournament.Infrastructure.Persistence;

namespace MKTournament.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext dbContext) : BaseRepository<Player>(dbContext), IPlayerRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public override async Task<Result> Add(Player player, CancellationToken cancellationToken = default)
    {
        var foundPlayer = await _dbContext
            .Set<Player>()
            .FirstOrDefaultAsync(
                p => p.NickName.Equals(player.NickName) || p.EmailAddress.Equals(player.EmailAddress),
                cancellationToken);

        if (foundPlayer is not null)
        {
            if (foundPlayer.EmailAddress.Equals(player.EmailAddress))
            { 
                return Result.Failure(PlayerError.EmailAlreadyTaken(player.EmailAddress));
            }

            if (foundPlayer.NickName.Equals(player.NickName))
            {
                return Result.Failure(PlayerError.NickNameAlreadyTaken(player.NickName));
            }
        }
        
        _dbContext.Add(player);
        
        return Result.Success();
    }
}