using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Map : BaseEntity
{
    public Map(MapName name, string? createdBy = null, Guid? id = null) : base(createdBy, id)
    {
        Name = name.Value;
    }

    public string Name { get; }
}