using MKTournament.Domain.Common;
using MKTournament.Domain.Players;
using MKTournament.Domain.Races;

namespace MKTournament.Domain.GrandPrixx;

public interface IGrandPrixRepository : IBaseEntityRepository<GrandPrix>
{
    Task Create(GrandPrix grandPrix, List<Player> players);

    Task AddRace(GrandPrix grandPrix, PlayerRace playerRace);
}