using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Map : BaseEntity
{
    public Map(Guid id, string createdBy, MapName name) : base(id, createdBy)
    {
        Name = name.Value;
    }

    public string Name { get; }
}