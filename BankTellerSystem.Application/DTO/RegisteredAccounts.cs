using BankTellerSystem.Domain.Enums;

namespace BankTellerSystem.Application.DTO;

public class RegisteredAccounts
{
    public Guid AccountGuid { get; set; }
    public Guid ClientGuid { get; set; }
    public string ClientName { get; set; }
    public string ClientDocument { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime AccountCreatedAt { get; set; }
    public AccountStatusEnum AccountStatus { get; set; }
}
