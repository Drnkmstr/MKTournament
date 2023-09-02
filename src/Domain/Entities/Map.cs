using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Map : BaseEntity
{
    public Map(string createdBy, MapName name, Guid? id = null) : base(createdBy, id)
    {
        Name = name.Value;
    }

    public string Name { get; }
}