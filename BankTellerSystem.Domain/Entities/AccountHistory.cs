using BankTellerSystem.Domain.Enums;
using System.Text.Json.Serialization;

namespace BankTellerSystem.Domain.Entities;

public sealed class AccountHistory
{
    public Guid Guid { get; set; }
    public Guid AccountId { get; set; }

    public decimal CurrentBalance { get; private set; }
    public AccountStatusEnum Status { get; private set; }

    private string? DeactivationDoc { get; set; }
    private DateTime? DeactivationDate { get; set; }
    private string? DeactivationUser { get; set; }

    public Account? Account { get; set; }
}