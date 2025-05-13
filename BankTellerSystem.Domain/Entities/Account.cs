using BankTellerSystem.Domain.Enums;

namespace BankTellerSystem.Domain.Entities;

public sealed class Account : BaseEntity
{
    public Guid ClientGuid { get; private set; }
    public decimal CurrentBalance { get; private set; }
    public AccountStatusEnum Status { get; private set; }

    private string? DeactivationDoc { get; set; }
    private DateTime? DeactivationDate { get; set; }
    public string? DeactivationUser { get; set; }

    public bool IsActive() => string.IsNullOrEmpty(DeactivationDoc) && !DeactivationDate.HasValue && string.IsNullOrEmpty(DeactivationUser);

    public void Deactive(string deactivationDoc, string deactivationUser, DateTime? deactivationDate)
    {
        DeactivationDoc = deactivationDoc;
        DeactivationUser = deactivationUser;
        DeactivationDate = deactivationDate ?? DateTime.UtcNow;
    }
}
