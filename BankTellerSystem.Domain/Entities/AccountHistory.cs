namespace BankTellerSystem.Domain.Entities;

public sealed class AccountHistory
{
    public Guid Guid { get;  set; }
    public Guid AccountId { get; set; }
}
