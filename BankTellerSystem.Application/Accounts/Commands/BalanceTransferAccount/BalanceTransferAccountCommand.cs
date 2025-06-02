using MediatR;

namespace BankTellerSystem.Application.Accounts.Commands.BalanceTransferAccount;

public record BalanceTransferAccountCommand(Guid sourceAccountGuid, Guid destinationAccountGuid, decimal amount) : IRequest<bool>;
