using MKTournament.Domain.Common;
using MKTournament.Domain.Enums;

namespace MKTournament.Domain.GrandPrixx;

public class GrandPrix : BaseEntity
{
    private GrandPrix(Guid id,
        GrandPrixType type,
        bool teamMode,
        ObjectMode objectMode,
        AiMode aiMode,
        GrandPrixRaceNumber raceNumberNumber) : base(id)
    {
        Type = type.Value;
        TeamMode = teamMode;
        ObjectMode = objectMode.Value;
        AiMode = aiMode.Value;
        RaceCount = raceNumberNumber.Value;
    }

    public DateTime Date { get; } = DateTime.UtcNow;

    public string Type { get; }

    public bool TeamMode { get; init; }

    public string ObjectMode { get; }

    public string AiMode { get; }

    public int RaceCount { get; }

    #region Methods

    public static GrandPrix Create(
        GrandPrixType? type = null,
        bool? teamMode = null,
        ObjectMode? objectMode = null,
        AiMode? aiMode = null,
        GrandPrixRaceNumber? raceNumberNumber = null)
    {
        return new GrandPrix(
            default,
            type ?? GrandPrixType.Gp150,
            teamMode ?? false,
            objectMode ?? Enums.ObjectMode.Normal,
            aiMode ?? Enums.AiMode.Normal,
            raceNumberNumber ?? GrandPrixRaceNumber.R4);
    }

    #endregion
}