using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class GrandPrix: BaseEntity
{
    private List<Race> _races = new();
    private List<Player> _blueTeam = new();
    private List<Player> _redTeam = new();
    
    public GrandPrix(GrandPrixType? type = null,
        bool? teamMode = null,
        ObjectMode? objectMode = null,
        AiMode? aiMode = null,
        GrandPrixRaceNumber? raceNumberNumber = null,
        string? createdBy = null,
        Guid? id = null) : base(createdBy, id)
    {
        Date = DateTime.Now;
        Type = type?.Value ?? GrandPrixType.Gp150.Value;
        ObjectMode = objectMode?.Value ?? Enums.ObjectMode.Normal.Value;
        AiMode = aiMode?.Value ?? Enums.AiMode.Normal.Value;
        RacesNumber = raceNumberNumber?.Value ?? GrandPrixRaceNumber.R4.Value;
        TeamMode = teamMode ?? false;
    }
    
    public DateTime Date { get; }
    
    public string Type { get; }

    public bool TeamMode { get; init; }
    
    public string ObjectMode { get; }
    
    public string AiMode { get; }
    
    public int RacesNumber { get; }
}