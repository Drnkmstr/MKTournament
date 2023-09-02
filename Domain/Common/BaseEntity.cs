namespace Domain.Common;

public class BaseEntity
{

    public BaseEntity(Guid id, string createdBy)
    {
        Id = id;
        CreatedBy = createdBy;
        ModifiedBy = createdBy;
        Created = DateTime.Now;
        Modified = Created;
    }
    
    public Guid Id { get; }
    
    public string CreatedBy { get; }
    
    public string ModifiedBy { get; }
    
    public DateTime Created { get; }
    
    public DateTime Modified { get; }
}