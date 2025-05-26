namespace BankTellerSystem.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Guid { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}
