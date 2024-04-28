using MKTournament.Domain.Common;

namespace MKTournament.Domain.Maps;

public class Map : BaseEntity
{
    private Map(Guid id, MapName name) : base(id)
    {
        Name = name;
    }

    public MapName Name { get; private set; }

    #region Methods

    public static Map Create(MapName name)
    {
        return new Map(default, name);
    }

    #endregion
}