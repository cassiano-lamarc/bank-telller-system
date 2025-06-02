using BankTellerSystem.Domain.Constants;
using BankTellerSystem.Domain.Enums;

namespace BankTellerSystem.Domain.Entities;

public sealed class Account : BaseEntity
{
    public Guid ClientGuid { get; private set; }
    public decimal CurrentBalance { get; private set; }
    public AccountStatusEnum Status { get; private set; }

    private string? DeactivationUserDocument { get; set; }
    private DateTime? DeactivationDate { get; set; }

    public ICollection<AccountHistory>? AccountHistories { get; set; }
    public Client? Client { get; set; }

    private Account(Guid clientGuid, decimal currentBalance, AccountStatusEnum status)
    {
        ClientGuid = clientGuid;
        CurrentBalance = currentBalance;
        Status = status;
    }

    public static Account Create(Guid clientGuid)
        => new Account(clientGuid, AccountInitialBalance.Value, AccountStatusEnum.Active);

    public bool IsActive() => string.IsNullOrEmpty(DeactivationUserDocument) ||
        !DeactivationDate.HasValue ||
        string.IsNullOrEmpty(DeactivationUserDocument);

    public void Deactive(string deactivationDoc)
    {
        DeactivationUserDocument = deactivationDoc;
        DeactivationDate = DateTime.UtcNow;
        Status = AccountStatusEnum.Inactive;
    }
}
