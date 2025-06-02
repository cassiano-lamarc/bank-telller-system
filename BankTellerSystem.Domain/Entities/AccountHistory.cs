using BankTellerSystem.Domain.Enums;

namespace BankTellerSystem.Domain.Entities;

public sealed class AccountHistory : BaseEntity
{
    public Guid AccountId { get; set; }

    public decimal CurrentBalance { get; private set; }
    public AccountStatusEnum Status { get; private set; }

    public string? DeactivationUserDocument { get; private set; }
    public DateTime? DeactivationDate { get; private set; }

    public Account? Account { get; set; }

    public AccountHistory()
    {
        
    }

    private AccountHistory(Guid guid, Guid accountId, decimal currentBalance, AccountStatusEnum status,
                   string? deactivationDoc = null, DateTime? deactivationDate = null)
    {
        Guid = guid;
        AccountId = accountId;
        CurrentBalance = currentBalance;
        Status = status;
        DeactivationUserDocument = deactivationDoc;
        DeactivationDate = deactivationDate;
    }

    public static AccountHistory Create(Guid accountId, decimal currentBalance)
        => new AccountHistory(Guid.NewGuid(), accountId, currentBalance, AccountStatusEnum.Active);

    public static AccountHistory DeactiveAccount(Guid accountId, decimal currentBalance, string deactivationDoc)
           => new AccountHistory(Guid.NewGuid(), accountId, currentBalance, AccountStatusEnum.Inactive, deactivationDoc, DateTime.UtcNow);

}