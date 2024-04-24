using MKTournament.Domain.Common;

namespace MKTournament.Domain.Maps;

public class Map(Guid id, MapName name) : BaseEntity(id)
{
    public string Name { get; } = name.Value;
}