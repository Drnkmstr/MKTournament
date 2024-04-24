using ErrorOr;
using MKTournament.Domain.Common;
using MKTournament.Domain.Enums;

namespace MKTournament.Domain.GrandPrixx;

public class GrandPrix(
    Guid id,
    GrandPrixType? type = null,
    bool? teamMode = null,
    ObjectMode? objectMode = null,
    AiMode? aiMode = null,
    GrandPrixRaceNumber? raceNumberNumber = null)
    : BaseEntity(id)
{
    public DateTime Date { get; } = DateTime.Now;

    public string Type { get; } = type?.Value ?? GrandPrixType.Gp150.Value;

    public bool TeamMode { get; init; } = teamMode ?? false;

    public string ObjectMode { get; } = objectMode?.Value ?? Enums.ObjectMode.Normal.Value;

    public string AiMode { get; } = aiMode?.Value ?? Enums.AiMode.Normal.Value;

    public int RaceCount { get; } = raceNumberNumber?.Value ?? GrandPrixRaceNumber.R4.Value;
}