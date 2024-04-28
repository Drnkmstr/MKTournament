using MKTournament.Domain.Common;
using MKTournament.Domain.Races.Events;

namespace MKTournament.Domain.Races;

public class PlayerRace : BaseEntity
{
    private PlayerRace(Guid id,
        Guid playerId,
        Guid mapId,
        Guid grandPrixId,
        RacePosition racePosition
        ) : base(id)
    {
        PlayerId = playerId;
        Position = racePosition.Value;
        Score = racePosition.Score;
        MapId = mapId;
        GrandPrixId = grandPrixId;
    }
    
    public Guid PlayerId { get; }
    public Guid GrandPrixId { get; }
    public Guid MapId { get; }
    public int Position { get; }
    public int Score { get; }

    #region Methods

    public static PlayerRace Create(
        Guid playerId,
        Guid mapId,
        Guid grandPrixId,
        RacePosition racePosition)
    {
        var race =  new PlayerRace(
            default,
            playerId,
            mapId,
            grandPrixId,
            racePosition
            );
        
        race.RaiseDomainEvent(new RaceCreatedDomainEvent(race.Id));

        return race;
    }

    #endregion
}