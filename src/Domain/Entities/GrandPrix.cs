using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class GrandPrix: BaseEntity
{
    public GrandPrix(string createdBy, GrandPrixType type, ObjectMode objectMode, AiMode aiMode, Guid? id = null) : base(createdBy, id)
    {
        Type = type.Name;
        Date = DateTime.Now;
        ObjectMode = objectMode.Name;
        AiMode = aiMode.Name;
    }
    
    public DateTime Date { get; }
    
    public string Type { get; }
    
    public string ObjectMode { get; }
    
    public string AiMode { get; }
    
    public int RacesNumber { get; }
}