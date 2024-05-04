using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;
using MKTournament.Infrastructure.Persistence;

namespace MKTournament.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext dbContext) : BaseRepository<Player>(dbContext), IPlayerRepository;