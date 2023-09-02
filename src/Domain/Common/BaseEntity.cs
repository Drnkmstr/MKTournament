namespace Domain.Common;

public class BaseEntity
{

    public BaseEntity(string createdBy, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
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