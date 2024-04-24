using ErrorOr;
using MKTournament.Domain.Common;
using MKTournament.Domain.Players;
using MKTournament.Domain.Races;

namespace MKTournament.Domain.GrandPrixx;

public interface IGrandPrixRepository : IBaseEntityRepository<GrandPrix>
{
    Task<ErrorOr<Created>> Create(GrandPrix grandPrix, List<Player> players);

    Task<ErrorOr<Success>> AddRace(GrandPrix grandPrix, Race race);
}